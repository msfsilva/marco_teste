#region Referencias

using System;
using System.Collections.Generic;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using BibliotecaNotasFiscais;

using BibliotecaProdutos;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using LoteClass = BibliotecaEntidades.Operacoes.Compras.LoteClass;
using OrdemProducaoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoClass;
using OrdemProducaoPostoTrabalhoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoPostoTrabalhoClass;

#endregion

namespace BibliotecaPontosControle
{
    public class PontoControleClass
    {
        int? idPostoTrabalho = null;
        public string PostoTrabalhoSelecionado { get; private set; }
        public bool conferenciaSequencial = false;
        public AcsUsuarioClass usuario { get; private set; }
        readonly IWTPostgreNpgsqlConnection conn;
        //private string AREA_NAME = "PONTO_CONTROLE";

        public Dictionary<int, LoteClass> lotesMP;
        private IObservacaoCustomizada _observacaoCustomizada;

        public PontoControleClass(IWTPostgreNpgsqlConnection conn, IObservacaoCustomizada observacaoCustomizada)
        {
          
            this.conn = conn;
            _observacaoCustomizada = observacaoCustomizada;
            this.lotesMP = new Dictionary<int, LoteClass>();
        }

        public void setUsuario(AcsUsuarioClass Usuario)
        {
            try
            {
                usuario = Usuario;
                this.validarUsuario();
            }
            catch (Exception e)
            {
                usuario = null;
                throw new Exception("Erro ao definir o usuário.\r\n" + e.Message);
            }
        }

        private void validarUsuario()
        {
            //if (!usuario.HasAccess(AREA_NAME, accessType.readAccess))
            //{
            //    throw new Exception("O usuário selecionado não tem acesso a esta área do sistema.");
            //}
        }

        public void setUsuario(int idUserProgram)
        {
            try
            {
                usuario = AcsUsuarioClass.GetEntidade(idUserProgram, LoginClass.UsuarioLogado.loggedUser,this.conn);
            }
            catch (Exception e)
            {
                usuario = null;
                throw new Exception("Erro ao definir o usuário.\r\n" + e.Message);
            }
        }

        public void setPostoTrabalho(int idPostoTrabalho)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  pos_rastreamento, " +
                    "  pos_conferencia_sequencial, "+
                    "  pos_codigo "+
                    "FROM  " +
                    "  public.posto_trabalho " +
                    "WHERE " +
                    "  id_posto_trabalho = :id_posto_trabalho ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idPostoTrabalho;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    read.Read();
                    if (Convert.ToInt16(read["pos_rastreamento"]) == 1)
                    {
                        this.idPostoTrabalho = idPostoTrabalho;
                        this.conferenciaSequencial = Convert.ToBoolean(Convert.ToInt16(read["pos_conferencia_sequencial"]));
                        this.PostoTrabalhoSelecionado = read["pos_codigo"].ToString();
                        read.Close();
                    }
                    else
                    {
                        read.Close();
                        throw new Exception("Esse posto de trabalho não está configurado para utilização de rastreamento eletrônico.");
                    }
                }
                else
                {
                    read.Close();
                    throw new Exception("ID Inválido");
                }

            }
            catch (Exception e)
            {
                this.idPostoTrabalho = null;
                this.PostoTrabalhoSelecionado = null;
                this.conferenciaSequencial = false;
                throw new Exception("Erro ao definir o posto de trabalho.\r\n" + e.Message);
            }

        }

        //Função para verificar se a próxima leitura de uma op exigirá a informação da quantidade de entrada ou saida.
        //Retorno:
        //0: Não exige Quantidade
        //1: Exige Quantidade de Entrada
        //2: Exige Quantidade de Saida

        public int exigeQuantidade(OrdemProducaoClass ordemProducao, out string stringTempo, out double qtdRecebida, out bool exigeRastreamentoMateriais, out bool somenteAbrirProducao, out List<string> historicoMovimentacaoPostos)
        {
            try
            {
                historicoMovimentacaoPostos = ordemProducao.getHistoricoPostos();
                OrdemProducaoPostoTrabalhoClass posto;
                int indiceTempo;
                //double? qtdRecebida;
                exigeRastreamentoMateriais = false;
                int toRet = this.exigeQuantidade(ordemProducao, out posto, out indiceTempo, out qtdRecebida, out exigeRastreamentoMateriais,out somenteAbrirProducao);

                switch (posto.Acompanhamento)
                {
                    //Atendimento 1, controla 2 tempos
                    case PostoTrabalhoAcompanhamento.UmTempo:
                    case PostoTrabalhoAcompanhamento.UmTempoComQtd:
                        stringTempo = "Passagem";
                        break;

                    case PostoTrabalhoAcompanhamento.DoisTempos:
                        if (somenteAbrirProducao)
                        {
                            stringTempo = "Continuação do Processo";
                        }
                        else
                        {
                            if (indiceTempo == 1)
                            {
                                stringTempo = "Início do Processo";
                            }
                            else
                            {
                                stringTempo = "Fim do Processo";
                            }
                        }
                        break;
                    case PostoTrabalhoAcompanhamento.TresTempos:
                        if (somenteAbrirProducao)
                        {
                            stringTempo = "Continuação do Processo";
                        }
                        else
                        {

                            if (indiceTempo == 1)
                            {
                                stringTempo = "Início do Setup";
                            }
                            else
                            {

                                if (indiceTempo == 2)
                                {
                                    stringTempo = "Fim do Setup e Início do Processo";
                                }
                                else
                                {

                                    stringTempo = "Fim do Processo";
                                }
                            }
                        }
                        break;
                    default:
                        stringTempo = "";
                        break;
                }

                stringTempo = posto.Codigo + " : " + stringTempo;

               
                return toRet;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        internal int exigeQuantidade(OrdemProducaoClass ordemProducao, out OrdemProducaoPostoTrabalhoClass postoSelecionado, out int indiceTempo, out double qtdRecebida, out bool exigeRastreamentoMateriais, out bool somenteAbrirProducao)
        {
            try
            {
                somenteAbrirProducao = false;

                if (ordemProducao.Situacao != 0 && ordemProducao.Situacao != 1)
                {
                    throw new Exception("Não é possível marcar tempos em uma Ordem de Produção Cancelada, Encerrada ou Aguardando Serviço Externo");
                }

                if (ordemProducao.Suspensa)
                {
                    throw new Exception("Não é possível marcar tempos em uma Ordem de Produção Suspensa");
                }


                //identifica o posto atual busca a primeira ocorrencia livre do posto de trabalho selecionado utilizando a sequencia do processo
                ordemProducao.postosTrabalho.Sort(new OrdemProducaoPostoTrabalhoComparer());
                qtdRecebida = ordemProducao.Quantidade;

                

                foreach (OrdemProducaoPostoTrabalhoClass posto in ordemProducao.postosTrabalho)
                {
                    if (posto.qtdSaida != null)
                    {
                        qtdRecebida = (double)posto.qtdSaida;
                    }

                    if (posto.idPostoTrabalho == this.idPostoTrabalho)
                    {
                        if (!posto.Rastreamento)
                        {
                            throw new Exception("Não é possível registrar tempos em um posto que não está definido para utilização de rastreamento.");
                        }

                        exigeRastreamentoMateriais = ordemProducao.rastrearMP && posto.rastreamentoMP;

                        switch (posto.Acompanhamento)
                        {
                            case PostoTrabalhoAcompanhamento.UmTempo:
                                if (posto.Tempo1 == null)
                                {
                                    postoSelecionado = posto;
                                    indiceTempo = 1;
                                    qtdRecebida = qtdRecebida - posto.qtdProduzida;
                                    if (posto.existeProducaoAberta())
                                    {
                                        exigeRastreamentoMateriais = false;
                                    }
                                    

                                    return 0;
                                }
                                else
                                {
                                    continue;
                                }
                                break;

                            case PostoTrabalhoAcompanhamento.UmTempoComQtd:
                                if (posto.Tempo1 == null)
                                {
                                    postoSelecionado = posto;
                                    indiceTempo = 1;
                                    qtdRecebida = qtdRecebida - posto.qtdProduzida;
                                    if (posto.existeProducaoAberta())
                                    {
                                        exigeRastreamentoMateriais = false;
                                    }


                                    return 1;
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            //Atendimento 1, controla 2 tempos
                            case PostoTrabalhoAcompanhamento.DoisTempos:
                                if (posto.Tempo1 == null || posto.Tempo2 == null)
                                {
                                    postoSelecionado = posto;
                                    qtdRecebida = qtdRecebida - posto.qtdProduzida;


                                    if (posto.Tempo1 == null)
                                    {
                                        indiceTempo = 1;
                                        if (posto.existeProducaoAberta())
                                        {
                                            exigeRastreamentoMateriais = false;
                                        }

                                        return 1;
                                    }

                                    if (posto.Tempo2 == null)
                                    {
                                        indiceTempo = 2;
                                        if (posto.existeProducaoAberta())
                                        {
                                            exigeRastreamentoMateriais = false;
                                        }
                                        else
                                        {
                                            somenteAbrirProducao = true;
                                        }

                                        return 2;
                                    }

                                }
                                else
                                {
                                    continue;
                                }

                                break;
                            //Atendimento 2, controla 3 tempos
                            case PostoTrabalhoAcompanhamento.TresTempos:
                                if (posto.Tempo1 == null || posto.Tempo2 == null || posto.Tempo3 == null)
                                {
                                    postoSelecionado = posto;
                                    qtdRecebida = qtdRecebida - posto.qtdProduzida;
                                    if (posto.Tempo1 == null)
                                    {
                                        indiceTempo = 1;
                                        if (posto.existeProducaoAberta())
                                        {
                                            exigeRastreamentoMateriais = false;
                                        }
                                        return 1;
                                    }

                                    if (posto.Tempo2 == null)
                                    {
                                        indiceTempo = 2;
                                        if (posto.existeProducaoAberta())
                                        {
                                            exigeRastreamentoMateriais = false;
                                        }
                                        else
                                        {
                                            somenteAbrirProducao = true;
                                        }
                                        return 0;
                                    }

                                    if (posto.Tempo3 == null)
                                    {
                                        indiceTempo = 3;
                                        if (posto.existeProducaoAberta())
                                        {
                                            exigeRastreamentoMateriais = false;
                                        }
                                        else
                                        {
                                            somenteAbrirProducao = true;
                                        }
                                        return 2;
                                    }
                                }
                                else
                                {
                                    continue;
                                }


                                break;
                            default:
                                throw new Exception("Acompanhamento inválido.");
                        }


                    }
                    else
                    {
                        //Não é o posto selecionado mas é rastreado
                        if (posto.Rastreamento)
                        {
                            switch (posto.Acompanhamento)
                            {
                                //Atendimento 1, controla 2 tempos
                                case PostoTrabalhoAcompanhamento.UmTempo:
                                    if (posto.Tempo1 == null)
                                    {
                                        throw new Exception("Não é possível registrar tempos para o posto selecionado pois os tempos do posto " + posto.Codigo + " não foram registrados.");
                                    }
                                    break;

                                case PostoTrabalhoAcompanhamento.UmTempoComQtd:
                                    if (posto.Tempo1 == null)
                                    {
                                        throw new Exception("Não é possível registrar tempos para o posto selecionado pois os tempos do posto " + posto.Codigo + " não foram registrados.");
                                    }
                                    break;
                                case PostoTrabalhoAcompanhamento.DoisTempos:
                                    if (posto.Tempo1 == null || posto.Tempo2 == null)
                                    {
                                        throw new Exception("Não é possível registrar tempos para o posto selecionado pois os tempos do posto " + posto.Codigo + " não foram registrados.");
                                    }
                                    break;
                                case PostoTrabalhoAcompanhamento.TresTempos:
                                    if (posto.Tempo1 == null || posto.Tempo2 == null || posto.Tempo3 == null)
                                    {
                                        throw new Exception("Não é possível registrar tempos para o posto selecionado pois os tempos do posto " + posto.Codigo + " não foram registrados.");
                                    }
                                    break;
                            }
                        }




                    }


                }

                throw new Exception("Posto não encontrado ou com todas as leituras já realizadas.");
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o próximo ponto de leitura.\r\n" + e.Message);
            }

        }

        public void marcarTempoPosto(OrdemProducaoClass ordemProducao, double? qtd)
        {
            try
            {
                if (this.usuario == null)
                {
                    throw new Exception("É necessário selecionar um usuário antes de continuar.");
                }

                if (this.idPostoTrabalho == null)
                {
                    throw new Exception("É necessário selecionar um posto de trabalho antes de continuar.");
                }

                OrdemProducaoPostoTrabalhoClass posto;
                int indiceTempo;

                double qtdRecebida;
                bool garbage;
                bool garbage2;

                int exigeQtd = this.exigeQuantidade(ordemProducao, out posto, out indiceTempo, out qtdRecebida, out garbage, out garbage2);

                List<LoteClass> lotes = null;
                if (this.lotesMP != null)
                {
                    lotes = new List<LoteClass>(this.lotesMP.Values);
                }
                posto.setTempo(indiceTempo, Configurations.DataIndependenteClass.GetData(), this.usuario, this.usuario.Login, lotes);


                switch (exigeQtd)
                {
                    case 0:
                        posto.setQtdSaida(qtdRecebida, this.usuario);

                        break;
                    case 1:
                        if (qtd != null)
                        {
                            if (posto.Acompanhamento == PostoTrabalhoAcompanhamento.UmTempo || posto.Acompanhamento == PostoTrabalhoAcompanhamento.UmTempoComQtd)
                            {
                                posto.setQtdSaida((double) qtd, this.usuario);
                            }
                            else
                            {
                                posto.setQtdEntrada((double) qtd);
                            }
                        }
                        else
                        {
                            throw new Exception("Quantidade de Entrada obrigatória para o posto selecionado.");
                        }
                        break;
                    case 2:
                        if (qtd != null)
                        {
                            posto.setQtdSaida((double)qtd, this.usuario);
                        }
                        else
                        {
                            throw new Exception("Quantidade de Saída obrigatória para o posto selecionado.");
                        }
                        break;
                    default:
                        throw new Exception("Resultado inválido para a função de quantidade.");
                        break;
                }
                

                if (posto.Sequencia == ordemProducao.maxSequenciaPosto)
                {
                    //Ultimo posto
                    switch (posto.Acompanhamento)
                    {
                        case PostoTrabalhoAcompanhamento.UmTempo:
                        case PostoTrabalhoAcompanhamento.UmTempoComQtd:
                            ordemProducao.Encerrar(this.usuario, false, false);
                            break;

                        case PostoTrabalhoAcompanhamento.DoisTempos:
                            if (indiceTempo == 2)
                            {
                                ordemProducao.Encerrar(this.usuario, false, false);
                            }
                            else
                            {
                              

                                ordemProducao.Save();
                            }
                            break;
                        case PostoTrabalhoAcompanhamento.TresTempos:
                            if (indiceTempo == 3)
                            {
                                ordemProducao.Encerrar(this.usuario, false, false);
                            }
                            else
                            {
                                ordemProducao.Save();
                            }
                            break;
                        default:
                            ordemProducao.Save();
                            break;
                    }

                }
                else
                {
                    //TODO: https://iwtv2s.atlassian.net/browse/SPIN-94 se o cliente concordar
                    if (posto.PostoTrabalho.PostoExterno)
                    {
                        ordemProducao.SetAguardandoServicoExterno();
                    }

                    ordemProducao.Save();
                }

                this.lotesMP = null;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao marcar o tempo da oc.\r\n"+e.Message);
            }
        }

        public void Suspender(OrdemProducaoClass ordemProducao,double qtd)
        {
            try
            {
                bool garbage;
                bool somenteAbrirProducao;
                if (this.usuario == null)
                {
                    throw new Exception("É necessário selecionar um usuário antes de continuar.");
                }

                if (this.idPostoTrabalho == null)
                {
                    throw new Exception("É necessário selecionar um posto de trabalho antes de continuar.");
                }

                OrdemProducaoPostoTrabalhoClass posto;
                int indiceTempo;
                double qtdRecebida;

                this.exigeQuantidade(ordemProducao, out posto, out indiceTempo, out qtdRecebida, out garbage, out somenteAbrirProducao);



                posto.interromperProcesso(this.usuario, qtd);
                ordemProducao.setSuspensa(true, this.usuario);

                ordemProducao.Save();

                this.lotesMP = null;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao suspender a oc.\r\n" + e.Message);
            }

        }

        public void trocarOperador(OrdemProducaoClass ordemProducao, double qtd)
        {
            try
            {
                bool garbage;
                if (this.usuario == null)
                {
                    throw new Exception("É necessário selecionar um usuário antes de continuar.");
                }

                if (this.idPostoTrabalho == null)
                {
                    throw new Exception("É necessário selecionar um posto de trabalho antes de continuar.");
                }

                OrdemProducaoPostoTrabalhoClass posto;
                int indiceTempo;
                double qtdRecebida;

                bool somenteAbrirProducao = false;
                this.exigeQuantidade(ordemProducao, out posto, out indiceTempo, out qtdRecebida, out garbage, out somenteAbrirProducao);

                if (somenteAbrirProducao)
                {
                    throw new Exception("Não é possível interromper um processo não iniciado.");
                }


                posto.interromperProcesso(this.usuario, qtd);

                ordemProducao.Save();

                this.lotesMP = null;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao trocar de operador na oc.\r\n" + e.Message);
            }

        }

        internal void abrirProducao(OrdemProducaoClass ordemProducao, AcsUsuarioClass _acsUsuario)
        {
            try
            {
                bool garbage;
                if (this.usuario == null)
                {
                    throw new Exception("É necessário selecionar um usuário antes de continuar.");
                }

                if (this.idPostoTrabalho == null)
                {
                    throw new Exception("É necessário selecionar um posto de trabalho antes de continuar.");
                }

                
                OrdemProducaoPostoTrabalhoClass posto;
                int indiceTempo;
                double qtdRecebida;

                bool somenteAbrirProducao = false;
                this.exigeQuantidade(ordemProducao, out posto, out indiceTempo, out qtdRecebida, out garbage, out somenteAbrirProducao);

                if (!somenteAbrirProducao)
                {
                    throw new Exception("Não é possível abrir um processo pois já existe um iniciado.");
                }


                posto.abrirProducao(this.usuario, new List<LoteClass>(this.lotesMP.Values));

                ordemProducao.Save();

                this.lotesMP = null;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir a produção da oc.\r\n" + e.Message);
            }
        }
    }
}
