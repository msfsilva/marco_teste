using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using BibliotecaComunicacaoGAD.api;
using BibliotecaComunicacaoGAD.dto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Configurador;
using BibliotecaEntidades.Operacoes.EnvioEmail;
using BibliotecaTributos;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;
using ProjectConstants;

namespace BibliotecaAutomacoes
{
    public class IntegracaoGad
    {

        private const int LIMITE_TENTATIVAS_ENVIO = 100;

        private readonly Semaphore _semaphore;
        private readonly string _connString;


        private Boolean _toStop;
        readonly int _sleepTimeAfterRun = 1800;//segundos
        private readonly string _logFile;

        

        public IntegracaoGad(ref Semaphore semaphore, string connString)
        {
            _semaphore = semaphore;
        
            _connString = connString;
         
            _logFile = AppDomain.CurrentDomain.BaseDirectory + "\\logIntegracaoGad" + DataIndependenteClass.GetData().ToString("yyyMMdd") + ".txt";
           
        }

        

        public void Start()
        {


            while (!_toStop)
            {
                try
                {
                    _semaphore?.WaitOne();
                    IWTPostgreNpgsqlConnection conn = null;
                    try
                    {
                        conn = new IWTPostgreNpgsqlConnection(_connString);
                        conn.Open();
                        EnviarPedidos(conn);
                        VerificaSituacaoPedidos(conn);
                        EnviarProgramacaoGad(conn);
                    }
                    finally
                    {
                        try
                        {
                            conn?.ForceClose();
                        }
                        catch
                        {

                        }
                        _semaphore?.Release();
                    }
                }
                catch (Exception a)
                {
                    try
                    {
                        if (File.Exists(_logFile))
                        {
                            FileInfo fi = new FileInfo(_logFile);
                            if (fi.Length > 104857600)
                            {
                                fi.Delete();
                            }
                        }

                        StreamWriter logWriter = new StreamWriter(_logFile, true);
                        logWriter.WriteLine("Erro não esperado: " + a);
                        logWriter.Close();
                    }
                    catch
                    {
                    }
                }
                finally
                {
                    int segundos = _sleepTimeAfterRun;
                    while (!_toStop && segundos > 0)
                    {
                        Thread.Sleep(1000);
                        segundos--;
                    }
                }
            }
        }

        private void VerificaSituacaoPedidos(IWTPostgreNpgsqlConnection conn)
        {
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText =
                "SELECT " +
                "  public.pedido_item.id_pedido_item, " +
                "  public.pedido_item.pei_numero, " +
                "  public.pedido_item.pei_posicao " +
                "FROM " +
                "  public.pedido_item " +
                "WHERE " +
                "  public.pedido_item.pei_sub_linha = 0 AND " +
                "  (public.pedido_item.pei_status = 0 OR public.pedido_item.pei_status = 3 OR public.pedido_item.pei_status = 4)";

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            List<PedidoSituacaoDto> dtoList = new List<PedidoSituacaoDto>();
            Dictionary<string, long> ids = new Dictionary<string, long>();
            while (read.Read())
            {
                dtoList.Add(new PedidoSituacaoDto()
                {
                    numeroPedido = read["pei_numero"].ToString(),
                    posicaoPedido = Convert.ToInt32(read["pei_posicao"]),
                    idFornecedor = ConexaoGad.IdFornecedor
                });

                string chave = read["pei_numero"] + "/" + read["pei_posicao"];
                ids.Add(chave, Convert.ToInt64(read["id_pedido_item"]));
            }
            read.Close();

            if (_toStop) return;

            dtoList = PedidoControll.VerificaSituacaoPedidos(dtoList);
            if (_toStop) return;
            command.CommandText =
                "UPDATE  " +
                "  public.pedido_item " +
                "SET " +
                "  pei_situacao_gad = :situacaoGad, " +
                "  pei_situacao_gad_mensagem = :situacaoGadMensagem, " +
                "  pei_gad_programado = :pei_gad_programado, "+
                "  pei_gad_programacao_nome = :pei_gad_programacao_nome, "+
                "  pei_gad_programacao_data = :pei_gad_programacao_data "+
                "WHERE " +
                "  public.pedido_item.pei_sub_linha = 0 AND " +
                "  public.pedido_item.id_pedido_item = :id_pedido_item ";

            command.Parameters.Clear();
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("situacaoGad", NpgsqlDbType.Smallint));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("situacaoGadMensagem", NpgsqlDbType.Text));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_gad_programado", NpgsqlDbType.Smallint));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_gad_programacao_nome", NpgsqlDbType.Varchar));
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_gad_programacao_data", NpgsqlDbType.Varchar));

            //Atualiza os pedidos
            foreach (PedidoSituacaoDto retorno in dtoList)
            {
                if (_toStop) return;
                string chave = retorno.numeroPedido + "/" + retorno.posicaoPedido;
                if (!ids.ContainsKey(chave))
                {
                    throw new ExcecaoTratada("Erro inesperado ao verificar os pedidos no gad, pedido não encontrado na base do cliente. " + retorno.numeroPedido + "/" + retorno.posicaoPedido);
                }

                long id = ids[chave];
                command.Parameters["id_pedido_item"].Value = id;
                if (retorno.atualizar)
                {
                    command.Parameters["situacaoGad"].Value = retorno.situacaoPedido;
                    command.Parameters["situacaoGadMensagem"].Value = retorno.situacaoMensagem;
                    command.Parameters["pei_gad_programado"].Value = retorno.programado?1:0;
                    command.Parameters["pei_gad_programacao_nome"].Value = retorno.programacaoNome;
                    command.Parameters["pei_gad_programacao_data"].Value = retorno.programacaoDataCriacao;
                }
                else
                {
                    command.Parameters["situacaoGad"].Value = Convert.ToInt16(GadIntegracaoPedidoSituacao.SemGad);
                    command.Parameters["situacaoGadMensagem"].Value = null;
                    command.Parameters["pei_gad_programado"].Value = 0;
                    command.Parameters["pei_gad_programacao_nome"].Value = null;
                    command.Parameters["pei_gad_programacao_data"].Value = null;
                }

                command.ExecuteNonQuery();
            }
        }

        private class ProgramacaoInternaDto
        {
            public long Id { get; set; }
            public string Nome { get; set; }
            public short TentativasEnvio { get; set; }
        }

        private void EnviarProgramacaoGad(IWTPostgreNpgsqlConnection conn)
        {
            Dictionary<long, ProgramacaoInternaDto> programacoesPendentes = new Dictionary<long, ProgramacaoInternaDto>();
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText =
                "SELECT DISTINCT " +
                "  public.programacao.id_programacao, " +
                "  public.programacao.prg_nome, " +
                "  prg_tentativas_envio "+
                "FROM " +
                "  public.programacao " +
                "  INNER JOIN public.pedido_item ON(public.programacao.id_programacao = public.pedido_item.id_programacao) " +
                "WHERE " +
                "  public.programacao.prg_programacao_gad_id IS NULL AND " +
                "  public.programacao.prg_situacao_gad = 0 ";

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                programacoesPendentes.Add(Convert.ToInt64(read["id_programacao"]),
                    new ProgramacaoInternaDto()
                    {
                        Id = Convert.ToInt64(read["id_programacao"]),
                        Nome = read["prg_nome"].ToString(),
                        TentativasEnvio = Convert.ToInt16(read["prg_tentativas_envio"])
                    });
            }
            read.Close();

            foreach (KeyValuePair<long, ProgramacaoInternaDto> pendente in programacoesPendentes)
            {
                try
                {
                    List<PedidoAcaoDto> pedidos = new List<PedidoAcaoDto>();
                    command.CommandText =
                        "SELECT DISTINCT " +
                        "  public.pedido_item.pei_numero, " +
                        "  public.pedido_item.pei_posicao " +
                        "FROM " +
                        "  public.pedido_item " +
                        "WHERE " +
                        "  public.pedido_item.pei_situacao_gad <> 0 AND " +
                        "  public.pedido_item.id_programacao = :id_programacao";
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_programacao", NpgsqlDbType.Bigint, pendente.Key));

                    read = command.ExecuteReader();
                    while (read.Read())
                    {
                        pedidos.Add(new PedidoAcaoDto()
                        {
                            idFornecedor = ConexaoGad.IdFornecedor,
                            numero = read["pei_numero"].ToString(),
                            posicao = Convert.ToInt32(read["pei_posicao"])
                        });
                    }
                    read.Close();
                    if (pedidos.Count == 0)
                    {
                        continue;
                    }


                    ProgramacaoDto programacaoDto = new ProgramacaoDto()
                    {
                        idFornecedor = ConexaoGad.IdFornecedor,
                        nomeProgramacao = pendente.Value.Nome,
                        pedidos = pedidos
                    };

                    programacaoDto = ProgramacaoControll.criaProgramacao(programacaoDto);

                    GadIntegracaoProgramacaoSituacao situacao;
                    string mensagemGad;
                    int? idProgramacaoGad;

                    if (!programacaoDto.programacaoCriada)
                    {
                        if (pendente.Value.TentativasEnvio > LIMITE_TENTATIVAS_ENVIO)
                        {
                            situacao = GadIntegracaoProgramacaoSituacao.ErroFinal;
                        }
                        else
                        {
                            situacao = GadIntegracaoProgramacaoSituacao.Pendente;
                            pendente.Value.TentativasEnvio++;
                        }
                        
                        mensagemGad = "A programação não foi criada no GAD devido aos seguintes problemas: " + programacaoDto.pedidos.Where(a => !a.acaoExecutada).Select(x => string.Format("{0}/{1}: {2}", x.numero, x.posicao, x.mensagem)).Aggregate((current, next) => current + " - " + next);
                        idProgramacaoGad = null;
                    }
                    else
                    {
                        situacao = GadIntegracaoProgramacaoSituacao.Enviada;
                        mensagemGad = "";
                        idProgramacaoGad = programacaoDto.idProgramacao;
                    }

                    command.CommandText =
                        "UPDATE " +
                        "  public.pedido_item " +
                        "SET " +
                        "  pei_situacao_gad = :pei_situacao_gad, " +
                        "  pei_situacao_gad_mensagem = :pei_situacao_gad_mensagem " +
                        "WHERE " +
                        "  public.pedido_item.id_programacao  = :id_programacao AND "+
                        "  public.pedido_item.pei_situacao_gad  <> 0 ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad", NpgsqlDbType.Smallint, Convert.ToInt16(GadIntegracaoPedidoSituacao.Programado)));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad_mensagem", NpgsqlDbType.Text, ""));
                    command.ExecuteNonQuery();

                    command.CommandText =
                        "UPDATE " +
                        "  public.programacao " +
                        "SET " +
                        "  prg_situacao_gad = :prg_situacao_gad, " +
                        "  prg_situacao_gad_mensagem = :prg_situacao_gad_mensagem, " +
                        "  prg_programacao_gad_id = :prg_programacao_gad_id, " +
                        "  prg_tentativas_envio  = :prg_tentativas_envio " +
                        "WHERE " +
                        "  public.programacao.id_programacao =:id_programacao ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_situacao_gad", NpgsqlDbType.Smallint, Convert.ToInt16(situacao)));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_situacao_gad_mensagem", NpgsqlDbType.Text, mensagemGad));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_programacao_gad_id", NpgsqlDbType.Integer, idProgramacaoGad));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("prg_tentativas_envio", NpgsqlDbType.Smallint, pendente.Value.TentativasEnvio));
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    StreamWriter logWriter = new StreamWriter(_logFile, true);
                    logWriter.WriteLine("Erro não esperado ao enviar a programação: " + e.Message);
                    logWriter.Close();
                }
            }
        }


        private class PedidoInternoDto
        {
            public long Id { get; set; }
            public string NomeArquivo { get; set; }
            public byte[] Arquivo { get; set; }
            public int Tentativas { get; set; }
            public long IdPedidoItem { get; set; }
        }

        private void EnviarPedidos(IWTPostgreNpgsqlConnection conn)
        {
            List<PedidoInternoDto> pedidosPendentes = new List<PedidoInternoDto>();
            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText =
                "SELECT DISTINCT " +
                "  id_gad_pedidos_upload, " +
                "  gpu_nome_arquivo, " +
                "  gpu_arquivo, " +
                "  gpu_tentativas, " +
                "  id_pedido_item " +
                "FROM " +
                "  public.gad_pedidos_upload " +
                "WHERE " +
                "  gpu_tentativas < " + LIMITE_TENTATIVAS_ENVIO.ToString("D",CultureInfo.InvariantCulture);

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                pedidosPendentes.Add(
                    new PedidoInternoDto()
                    {
                        Id = Convert.ToInt64(read["id_gad_pedidos_upload"]),
                        NomeArquivo = read["gpu_nome_arquivo"].ToString(),
                        Arquivo = (byte[]) read["gpu_arquivo"],
                        Tentativas = Convert.ToInt16(read["gpu_tentativas"]),
                        IdPedidoItem = Convert.ToInt64(read["id_pedido_item"]),
                    });
            }
            read.Close();

            foreach (PedidoInternoDto pendente in pedidosPendentes)
            {
                try
                {
                    StreamReader sr = new StreamReader(new MemoryStream(pendente.Arquivo));
                    GadIntegracaoPedidoSituacao situacao;
                    string mensagem = null;
                    bool excluir = true;
                    try
                    {
                        bool resultado = PedidoControll.UploadPedidoMilkrun(sr, pendente.NomeArquivo);
                        situacao = resultado ? GadIntegracaoPedidoSituacao.Enviado : GadIntegracaoPedidoSituacao.SemGad;
                    }
                    catch (Exception e)
                    {
                        situacao = GadIntegracaoPedidoSituacao.ErroRecepcionarPedido;
                        mensagem = e.Message;

                        excluir = false;

                    }

                    command.CommandText =
                        "UPDATE " +
                        "  public.pedido_item " +
                        "SET " +
                        "  pei_situacao_gad = :pei_situacao_gad, " +
                        "  pei_situacao_gad_mensagem = :pei_situacao_gad_mensagem " +
                        "WHERE " +
                        "  public.pedido_item.id_pedido_item = :id_pedido_item  ";
                    
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Bigint, pendente.IdPedidoItem));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad", NpgsqlDbType.Smallint, Convert.ToInt16(situacao)));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad_mensagem", NpgsqlDbType.Text, mensagem));
                    command.ExecuteNonQuery();

                    if (excluir)
                    {
                        command.CommandText =
                            "DELETE FROM " +
                            "  public.gad_pedidos_upload " +
                            "WHERE " +
                            "  public.gad_pedidos_upload.id_gad_pedidos_upload = :id_gad_pedidos_upload  ";

                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_gad_pedidos_upload", NpgsqlDbType.Bigint, pendente.Id));
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        pendente.Tentativas++;

                        command.CommandText =
                            "UPDATE " +
                            "  public.gad_pedidos_upload " +
                            "SET "+
                            "  gpu_tentativas = :gpu_tentativas, "+
                            "  gpu_erro = :gpu_erro "+
                            "WHERE " +
                            "  public.gad_pedidos_upload.id_gad_pedidos_upload = :id_gad_pedidos_upload  ";

                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_gad_pedidos_upload", NpgsqlDbType.Bigint, pendente.Id));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gpu_tentativas", NpgsqlDbType.Integer, pendente.Tentativas));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("gpu_erro", NpgsqlDbType.Varchar, mensagem));
                        command.ExecuteNonQuery();
                    }


                }
                catch (Exception e)
                {
                    StreamWriter logWriter = new StreamWriter(_logFile, true);
                    logWriter.WriteLine("Erro não esperado ao enviar a programação: " + e.Message);
                    logWriter.Close();
                }
            }
        }



        public void SafeStop()
        {
            _toStop = true;
        }
    }
}