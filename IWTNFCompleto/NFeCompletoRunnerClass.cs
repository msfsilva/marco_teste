using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.Shared;
using IWTCustomControls;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using TAmb = IWTNFCompleto.BibliotecaDatasets.v4_0.TAmb;
using TCodUfIBGE = IWTNFCompleto.BibliotecaDatasets.v4_0.TCodUfIBGE;

namespace IWTNFCompleto
{

    public abstract class NFeCompletoRunnerClass:Control
    {
        private delegate void InterromperThreadSafeDelegate();

        protected readonly string _certificado;
        protected readonly Semaphore _semaforoEmissaoNf;
        protected readonly TCodUfIBGELegado _ufEmitente;
        protected readonly string _cnpjTransmissor;
        protected AcsUsuarioClass _usuarioAtual;
        protected readonly byte[] _logoDanfe;
        protected readonly DadosSalvarEnviarNfe _dadosSalvarEnviarNfe;

        protected bool ExibirFaturas { get; set; } = true;
        protected bool ExibirDuplicatas { get; set; } = false;

        protected bool Parar { get; private set; }
        private const int intervalo = 1000;

        public bool SuprimirRetornosRejeicao { get; protected set; }

        private string _connectionString;

        private string caminhoLogFinalErroSuprimido ;

        public bool ImprimirZerosTributosVazios { get; protected set; } = false;

        public NFeCompletoRunnerClass(string certificado, Semaphore semaforoEmissaoNf, string ufEmitente, string cnpjTransmissor, AcsUsuarioClass usuarioAtual, string connectionString, byte[] logoDanfe,DadosSalvarEnviarNfe dadosSalvarEnviarNfe, string identificadorLog = "")
        {
            _certificado = certificado;
            _semaforoEmissaoNf = semaforoEmissaoNf;
            _ufEmitente = FuncoesAuxiliares.Sigla2TCodUfIBGE(ufEmitente);
            _cnpjTransmissor = cnpjTransmissor;
            _usuarioAtual = usuarioAtual;
            _connectionString = connectionString;
            _logoDanfe = logoDanfe;
            _dadosSalvarEnviarNfe = dadosSalvarEnviarNfe;

            caminhoLogFinalErroSuprimido = AppDomain.CurrentDomain.BaseDirectory + "\\" + identificadorLog + "LogEnvioFinalErroSuprimido.txt";
        }

        public void Start()
        {
            try
            {
                while (!Parar)
                {
                    IWTPostgreNpgsqlConnection singleConnection = null;

                    try
                    {
                        _semaforoEmissaoNf.WaitOne();

                        #region Cria a Conexão
                        singleConnection = new IWTPostgreNpgsqlConnection(_connectionString);
                        singleConnection.Open();
                        #endregion


                        BufferAbstractEntity.limparBuffer();
                        #region Envio das Nfes

                        #region Notas no ambiente normal em homologação

                        this.EnviaNfs( true, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente normal em produção

                        this.EnviaNfs( false, singleConnection);

                        #endregion

                        #endregion

                        if (Parar) break;

                        #region Resultado de Processamento

                        Thread.Sleep(15000);

                        #region Notas no ambiente normal em homologação

                        this.buscaResultadoLote(false, true, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente normal em produção

                        this.buscaResultadoLote(false, false, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente scan em homologação

                        this.buscaResultadoLote(true, true, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente scan em produção

                        this.buscaResultadoLote(true, false, singleConnection);

                        #endregion

                        #endregion
                        
                        if (Parar) break;

                        #region Funções Customizadas

                        #region Notas no ambiente normal em homologação

                        this.FuncaoSistemaCliente1(false, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente2(false, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente3(false, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente4(false, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente5(false, true, singleConnection);


                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente normal em produção

                        this.FuncaoSistemaCliente1(false, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente2(false, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente3(false, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente4(false, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente5(false, false, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente scan em homologação

                        this.FuncaoSistemaCliente1(true, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente2(true, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente3(true, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente4(true, true, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente5(true, true, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente scan em produção

                        this.FuncaoSistemaCliente1(true, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente2(true, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente3(true, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente4(true, false, singleConnection);
                        if (Parar) break;
                        this.FuncaoSistemaCliente5(true, false, singleConnection);

                        #endregion

                        #endregion

                        
                    }
                    catch (ThreadAbortException)
                    {
                        if (Parar) break;
                    }
                    catch (Exception e)
                    {
                        if (!SuprimirRetornosRejeicao)
                        {
                            MessageBox.Show(this, "Erro inesperado ao realizar as operações da NFe.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LogClass.EscreverLog("Erro inesperado ao realizar as operações da NFe: " + e.Message, @caminhoLogFinalErroSuprimido);
                        }
                    }
                    finally
                    {
                        try
                        {
                            if (singleConnection != null && singleConnection.State == ConnectionState.Open)
                            {
                                singleConnection.ForceClose();
                            }
                        }
                        catch
                        {
                        }

                        if (Thread.CurrentThread.IsAlive)
                        {
                            try
                            {
                                _semaforoEmissaoNf.Release();
                            }
                            catch (SemaphoreFullException)
                            {

                            }
                        }

                        if (!Parar)
                        {
                            Thread.Sleep(intervalo);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                if (!SuprimirRetornosRejeicao)
                {
                    MessageBox.Show(this, "Erro inesperado ao realizar o envio das notas fiscais pendentes.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LogClass.EscreverLog("Erro inesperado ao realizar o envio das notas fiscais pendentes: " + e.Message, @caminhoLogFinalErroSuprimido);


                }
            }
        }


        #region Envio da NFe
        private void EnviaNfs(bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {

            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = singleConnection.CreateCommand();

                NfPrincipalClass searchNf = new NfPrincipalClass(_usuarioAtual, singleConnection);

                List<NfPrincipalClass> notasEnviar = searchNf.getNotasPendentesEnvioReceita(homologacao, "55", _cnpjTransmissor);

                NfeCompletoNotaClass search = new NfeCompletoNotaClass(_usuarioAtual, singleConnection);
                for (int i = 0; i < notasEnviar.Count; i++)
                {
                    NfPrincipalClass nfEnviar = notasEnviar[i];

                    List<NfeCompletoNotaClass> notasEnviadasAntes = search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Homologacao", nfEnviar.Homologacao),
                        new SearchParameterClass("Numero", nfEnviar.Numero),
                        new SearchParameterClass("Serie", nfEnviar.Serie),
                        new SearchParameterClass("CnpjEmitenteExato", nfEnviar.NfEmitente.CnpjCpf),
                        new SearchParameterClass("SomenteNFe", "true")

                    }).ToList().ConvertAll(a => (NfeCompletoNotaClass) a);

                    if (notasEnviadasAntes.Count != 0)
                    {
                        //Nota já foi transmitida anteriormente, ignora e não transmite
                        //nfEnviar.EnviarNfeReceita = false;
                        //nfEnviar.Save();
                        notasEnviar.RemoveAt(i);
                        i--;
                    }
                    else
                    {

                    }
                }


                if (notasEnviar.Count > 0)
                {

                    string retornoNotasRejeitadas = "";
                    string retornoNotasDenegadas = "";
                    List<RetornoNFe> notasEnviarEmail = new List<RetornoNFe>();
                    for (int i = 0; i < notasEnviar.Count; i++)
                    {

                        bool respostaSistemaClienteEnviada = false;
                        NfPrincipalClass nota = null;
                        try
                        {
                            //Testa se recebimento está disponível
                            bool scan = false;
                            string retornoDetalhado;
                            const TMod modelo = TMod.Item55;

                            nota = notasEnviar[i];

                            if (NFeOperacoes.SituacaoServicoInterno(this._ufEmitente, homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao, _certificado, out retornoDetalhado, false, modelo) != SituacaoServico.EmOperacao)
                            {
                                string retornoDetalhadoScan;
                                if (NFeOperacoes.SituacaoServicoInterno(this._ufEmitente, homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao, _certificado, out retornoDetalhadoScan, true, modelo) != SituacaoServico.EmOperacao)
                                {
                                    string mensagemErro = "Existem notas fiscais pendentes para serem transmitidas mas nem o ambiente de produção nem o de contingência estão operacionais. Retorno Produção: " + retornoDetalhado + " - Retorno Contingência: " + retornoDetalhadoScan;

                                    if (!SuprimirRetornosRejeicao)
                                    {
                                        MessageBox.Show(this, mensagemErro, "Transmissão não disponível", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        throw new Exception(mensagemErro);
                                    }
                                    return;
                                }
                                else
                                {
                                    scan = true;
                                }
                            }
                            
                           
                            if (scan)
                            {
                                nota.FormaEmissao = FormaEmissaoNFe.ContingenciaScan;
                            }

                            this.ProcessaNotasAEnviarInterno(nota, homologacao, command);


                            string emailXml;
                            string emailDanfe;
                            getEmailsCliente(nota, out emailXml,out emailDanfe, ref command );

                            if (!string.IsNullOrWhiteSpace(emailXml))
                            {
                                if (!IWTFunctions.IWTFunctions.ValidaEmail(emailXml))
                                {
                                    throw new Exception("Email para envio do XML inválido: " + emailXml);
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(emailDanfe))
                            {
                                if (!IWTFunctions.IWTFunctions.ValidaEmail(emailDanfe))
                                {
                                    throw new Exception("Email para envio do Danfe inválido: " + emailDanfe);
                                }
                            }


                            RetornoNFe notaRetornada;
                            LoteEnviar lote = NFeOperacoes.EnviaNfeInterno(
                                nota,
                                _ufEmitente,
                                homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao,
                                _certificado,
                                singleConnection,
                                _cnpjTransmissor,
                                "",
                                "",
                                _usuarioAtual,
                                null,
                                out notaRetornada);



                            command.Transaction = command.Connection.BeginTransaction();

                            if (notaRetornada != null)
                            {
                                nota.EnviarNfeReceita = false;
                                nota.Save(ref command);

                                if (notaRetornada.situacao == SituacaoNFe.Autorizada)
                                {
                                    this.ProcessaNFeProcessadaInterna(notaRetornada, ref command);
                                    notasEnviarEmail.Add(notaRetornada);
                                    respostaSistemaClienteEnviada = true;
                                }
                                else
                                {
                                    if (notaRetornada.situacao == SituacaoNFe.Rejeitada)
                                    {
                                        retornoNotasRejeitadas += "NFe" + notaRetornada.NotaFiscal.infNFe.ide.nNF + ":" + notaRetornada.codigoRetorno + " - " + notaRetornada.observacaoRetorno + "\r\n";
                                        this.ProcessaNFeRejeitadaInterna(notaRetornada, ref command);
                                        respostaSistemaClienteEnviada = true;
                                    }
                                    else
                                    {
                                        if (notaRetornada.situacao == SituacaoNFe.Denegada)
                                        {
                                            retornoNotasDenegadas += "NFe" + notaRetornada.NotaFiscal.infNFe.ide.nNF + ":" + notaRetornada.codigoRetorno + " - " + notaRetornada.observacaoRetorno + "\r\n";
                                            this.ProcessaNFeDenegadaInterna(notaRetornada, ref command);
                                            respostaSistemaClienteEnviada = true;
                                        }
                                        else
                                        {
                                            throw new Exception("Situação inesperada da nota retornada: " + notaRetornada.situacao);
                                        }
                                    }
                                }
                            }
                            else
                            {

                                if (lote.LoteEnviado)
                                {

                                    nota.EnviarNfeReceita = false;
                                    nota.Save(ref command);
                                }
                                else
                                {

                                    this.ProcessaLoteRejeitadoInterno(lote, notasEnviar, command);
                                    respostaSistemaClienteEnviada = true;
                                }
                            }
                            command.Transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            if (command != null && command.Transaction != null && command.Transaction.IsActive)
                            {
                                command.Transaction.Rollback();
                            }

                            if (command != null && nota != null)
                            {
                                if (!respostaSistemaClienteEnviada)
                                {
                                    ProcessaNFeRejeitadaAntesTransmissaoInterno(nota, e.Message, ref command);
                                    continue;
                                }
                            }

                            throw new Exception("Erro ao processar o lote enviado/rejeitado.\r\n" + e.Message);

                        }

                    }

                    if (!SuprimirRetornosRejeicao)
                    {
                        if (!String.IsNullOrEmpty(retornoNotasRejeitadas))
                        {

                            ScrollableMessageBox scrollableMessageBox = new ScrollableMessageBox(null, "As seguintes notas foram rejeitadas e devem ser emitidas novamente: \r\n" + retornoNotasRejeitadas, "Notas Rejeitadas", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            scrollableMessageBox.ShowDialog();
                        }

                        if (!String.IsNullOrEmpty(retornoNotasDenegadas))
                        {
                            ScrollableMessageBox scrollableMessageBox = new ScrollableMessageBox(null, "As seguintes notas foram denegadas e não podem ser utilizadas: \r\n" + retornoNotasDenegadas, "Notas Denegadas", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            scrollableMessageBox.ShowDialog();
                        }
                    }


                    foreach (RetornoNFe nota in notasEnviarEmail)
                    {
                        this.EnviaNfeEmail(nota, ref command);
                    }
                    
                }

            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception e)
            {
                BufferAbstractEntity.limparBuffer();
                if (!SuprimirRetornosRejeicao)
                {
                    MessageBox.Show(this, "Erro ao realizar o envio das notas fiscais, (" + (homologacao ? "Homologação" : "Produção") + ") pendentes.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new Exception("Erro ao realizar o envio das notas fiscais, (" + (homologacao ? "Homologação" : "Produção") + ") pendentes.\r\n" + e.Message + "StackTrace: " + e.StackTrace);
                }
            }
        }

        private void ProcessaNFeRejeitadaAntesTransmissaoInterno( NfPrincipalClass nf, string motivo, ref IWTPostgreNpgsqlCommand command)
        {
            NfeSituacaoTransmissaoClass transmissao =
              (NfeSituacaoTransmissaoClass)
                  new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                      new List<SearchParameterClass>()
                      {
                                new SearchParameterClass("IdNfPrincipal", nf.ID)
                      }).FirstOrDefault();


            if (transmissao == null)
            {
                transmissao = new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection)
                {
                    IdNfPrincipal = (int)nf.ID,
                    NotaTipo = nf.ModeloDocFiscal == "55" ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                    Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                    NotaNumero = nf.Numero,
                    NotaSerie = nf.Serie.ToString(),
                    NotaModelo = nf.ModeloDocFiscal,
                    NotaEmitente = nf.NfEmitente.Razao,
                    NotaDestinatario = nf.NfCliente.Razao,
                    NotaDataEmissao = nf.DataEmissao,
                    NotaChave = "Não Gerada",
                    IdNfCompletoNota = null
                };
            }
            

            transmissao.Situacao = IWTNFSituacaoTransmissao.Rejeitada;
            transmissao.Mensagem = "Erro antes da Transmissão: " + motivo;
            transmissao.DataAtualizacao = DataIndependenteClass.GetData();

            transmissao.Save(ref command);

            try
            {
                command.Transaction = command.Connection.BeginTransaction();

                ProcessaNFeRejeitadaAntesTransmissao(nf, motivo, ref command);

                command.Transaction.Commit();
            }
            catch (Exception)
            {
                command.Transaction?.Rollback();
                throw;
            }
        }

        protected abstract void ProcessaNFeRejeitadaAntesTransmissao(NfPrincipalClass nf, string motivo, ref IWTPostgreNpgsqlCommand command);


        private void ProcessaLoteRejeitadoInterno(LoteEnviar lote, List<NfPrincipalClass> notasLote,IWTPostgreNpgsqlCommand command)
        {

            foreach (NotaEnviar nota in lote.Notas)
            {
                NfeSituacaoTransmissaoClass transmissao =
                    (NfeSituacaoTransmissaoClass)
                        new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                            new List<SearchParameterClass>()
                            {
                                new SearchParameterClass("IdNfPrincipal", nota.NfPrincipal.ID)
                            }).FirstOrDefault();


                if (transmissao == null)
                {
                    transmissao = new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection)
                    {
                        IdNfPrincipal = (int)nota.NfPrincipal.ID,
                        NotaTipo =
                            nota.NfTnfe.infNFe.ide.mod == TMod.Item55 ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                        Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                        NotaNumero = nota.NfPrincipal.Numero,
                        NotaSerie = nota.NfTnfe.infNFe.ide.serie,
                        NotaModelo = nota.NfTnfe.infNFe.ide.mod.ToString().Replace("Item", ""),
                        NotaEmitente = nota.NfTnfe.infNFe.emit.xNome,
                        NotaDestinatario = nota.NfTnfe.infNFe.dest.xNome,
                        NotaDataEmissao = nota.NfPrincipal.DataEmissao,
                        NotaChave = nota.NfTnfe.infNFe.Id.Replace("NFe", ""),
                        
                    };
                }

                transmissao.Situacao = IWTNFSituacaoTransmissao.Rejeitada;
                transmissao.Mensagem = lote.Observacao;
                transmissao.DataAtualizacao = DataIndependenteClass.GetData();
                

                transmissao.Save(ref command);


            }

            ProcessaLoteRejeitado(lote, notasLote, command);
        }
        protected abstract void ProcessaLoteRejeitado(LoteEnviar lote, List<NfPrincipalClass> notasLote, IWTPostgreNpgsqlCommand command);


        private void ProcessaNotasAEnviarInterno(NfPrincipalClass notaAEnviar, bool homologacao,
            IWTPostgreNpgsqlCommand command)
        {
            NfeSituacaoTransmissaoClass transmissao =
                  (NfeSituacaoTransmissaoClass)
                      new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                          new List<SearchParameterClass>()
                          {
                                new SearchParameterClass("IdNfPrincipal", notaAEnviar.ID)
                          }).FirstOrDefault();


            if (transmissao == null)
            {
                transmissao = new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection)
                {
                    IdNfPrincipal = (int)notaAEnviar.ID,
                    NotaTipo = notaAEnviar.ModeloDocFiscal == "55" ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                    Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                    NotaNumero = notaAEnviar.Numero,
                    NotaSerie = notaAEnviar.Serie.ToString(),
                    NotaModelo = notaAEnviar.ModeloDocFiscal,
                    NotaEmitente = notaAEnviar.NfEmitente.Razao,
                    NotaDestinatario = notaAEnviar.NfCliente.Razao,
                    NotaDataEmissao = notaAEnviar.DataEmissao,
                    Mensagem = "Aguardando o Envio para Receita",
                    DataAtualizacao = DataIndependenteClass.GetData()

                };
                transmissao.Save(ref command);
            }
            

            ProcessaNotasAEnviar(notaAEnviar, homologacao, command);
        }
        protected abstract void ProcessaNotasAEnviar(NfPrincipalClass notaAEnviar, bool homologacao, IWTPostgreNpgsqlCommand command);

        #endregion

        #region Resultado de Processamento

        private void buscaResultadoLote(bool scan, bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {
            IWTPostgreNpgsqlCommand command = null;

            try
            {
                command = singleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                List<NfeCompletoLoteClass> lotesBuscar = new NfeCompletoLoteClass(_usuarioAtual, singleConnection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Homologacao", homologacao),
                    new SearchParameterClass("Scan", scan),
                    new SearchParameterClass("Modelo", "55"),
                    new SearchParameterClass("Situacao", SituacaoLote.Enviado),
                    new SearchParameterClass("ExisteRecibo", true),
                    new SearchParameterClass("CnpjTransmissorExato", _cnpjTransmissor),
                    new SearchParameterClass("ID",null,SearchOperacao.SomenteOrdenacao,SearchOrdenacao.Asc,TipoOrdenacao.Automatica)

                }).ConvertAll(a => (NfeCompletoLoteClass) a).ToList();


                command.Transaction.Commit();

                //if (lotesBuscar.Any())
                //{
                //    //Testa se recebimento está disponível
                //    if (scan)
                //    {
                //        string retornoDetalhadoScan;
                //        if (NFeOperacoes.SituacaoServicoInterno(this._ufEmitente, homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao, _certificado, out retornoDetalhadoScan, true, TMod.Item55) != SituacaoServico.EmOperacao)
                //        {
                //            if (!SuprimirRetornosRejeicao)
                //            {
                //                MessageBox.Show(this, "Existem lotes pendentes para serem recuperados em ambiente de contingência mas o ambiente de scan não está ativo, cancele essas notas e emita novamente.",
                //                    "Scan não disponível", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //            else
                //            {
                //                throw new Exception("Existem lotes pendentes para serem recuperados em ambiente de contingência mas o ambiente de scan não está ativo, cancele essas notas e emita novamente.");
                //            }

                //            return;
                //        }
                //    }
                //    else
                //    {
                //        string retornoDetalhado;
                //        if (NFeOperacoes.SituacaoServicoInterno(this._ufEmitente, homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao, _certificado, out retornoDetalhado, false, TMod.Item55) != SituacaoServico.EmOperacao)
                //        {
                //            if (!SuprimirRetornosRejeicao)
                //            {
                //                MessageBox.Show(this, "Existem lotes pendentes para serem recuperados em ambiente de normal mas o ambiente não está ativo, cancele essas notas e emita novamente.",
                //                    "Ambiente normal não disponível", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            }
                //            else
                //            {
                //                throw new Exception("Existem lotes pendentes para serem recuperados em ambiente de normal mas o ambiente não está ativo, cancele essas notas e emita novamente.");
                //            }

                //            return;
                //        }
                //    }
                //}

                string retornoNotasRejeitadas = "";
                string retornoNotasDenegadas = "";

                List<RetornoNFe> notasEnviarEmail = new List<RetornoNFe>();

                string errosLotes = "";

                foreach (NfeCompletoLoteClass lote in lotesBuscar)
                {
                    List<RetornoNFe> notasRejeitadas;
                    List<RetornoNFe> notasDenegadas;
                    List<RetornoNFe> notasProcessadas;
                    string retorno;

                    command.Transaction = null;
                    try
                    {
                        command.Transaction = command.Connection.BeginTransaction();


                        RetornoProcessamentoLote ret = NFeOperacoes.ResultadoProcessamentoNFeInterno(lote,
                            _ufEmitente,
                            _certificado,
                            command,
                            out retorno,
                            out notasRejeitadas,
                            out notasDenegadas,
                            out notasProcessadas,
                            _usuarioAtual,
                            scan);



                        lote.Save(ref command);

                        if (ret == RetornoProcessamentoLote.Erro || ret == RetornoProcessamentoLote.ProcessadoComProblemas)
                        {
                            foreach (RetornoNFe nota in notasRejeitadas)
                            {
                                lote.CollectionNfeCompletoNotaClassNfeCompletoLote.Remove(nota.NFeEmitida);
                                retornoNotasRejeitadas += "NFe" + nota.NotaFiscal.infNFe.ide.nNF + ":" + nota.codigoRetorno + " - " + nota.observacaoRetorno + "\r\n";
                                this.ProcessaNFeRejeitadaInterna(nota, ref command);

                            }

                            foreach (RetornoNFe nota in notasDenegadas)
                            {
                                retornoNotasDenegadas += "NFe" + nota.NotaFiscal.infNFe.ide.nNF + ":" + nota.codigoRetorno + " - " + nota.observacaoRetorno + "\r\n";
                                this.ProcessaNFeDenegadaInterna(nota, ref command);
                            }

                        }

                        if (lote.Situacao == SituacaoLote.ErroLote && notasDenegadas.Count == 0 && notasRejeitadas.Count == 0)
                        {
                            //Tratamento para que o erro no lote não passe despecebido
                            errosLotes += "Erro ao buscar o resultado do lote " + lote.NumeroLote + ": " + lote.ResultadoObs + Environment.NewLine;
                        }

                        foreach (RetornoNFe nota in notasProcessadas)
                        {
                            this.ProcessaNFeProcessadaInterna(nota, ref command);

#if DEBUG
                            notasEnviarEmail.Add(nota);
#else
                        notasEnviarEmail.Add(nota);
#endif
                        }

                        command.Transaction.Commit();

                    }
                    catch
                    {
                        command.Transaction?.Rollback();
                        throw;
                    }
                }


                if (!SuprimirRetornosRejeicao)
                {
                    if (!String.IsNullOrEmpty(retornoNotasRejeitadas))
                    {

                        ScrollableMessageBox scrollableMessageBox = new ScrollableMessageBox(null, "As seguintes notas foram rejeitadas e devem ser emitidas novamente: \r\n" + retornoNotasRejeitadas, "Notas Rejeitadas", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        scrollableMessageBox.ShowDialog();
                    }

                    if (!String.IsNullOrEmpty(retornoNotasDenegadas))
                    {
                        ScrollableMessageBox scrollableMessageBox = new ScrollableMessageBox(null, "As seguintes notas foram denegadas e não podem ser utilizadas: \r\n" + retornoNotasDenegadas, "Notas Denegadas", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        scrollableMessageBox.ShowDialog();
                    }

                    if (!String.IsNullOrEmpty(errosLotes))
                    {
                        ScrollableMessageBox scrollableMessageBox = new ScrollableMessageBox(null, "Os seguintes lotes apresentaram problemas inesperados: \r\n" + errosLotes, "Erros de Lote", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        scrollableMessageBox.ShowDialog();
                    }


                }
             
                command.Transaction = null;

                foreach (RetornoNFe nota in notasEnviarEmail)
                {
                    this.EnviaNfeEmail(nota, ref command);
                }

            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                if (!SuprimirRetornosRejeicao)
                {
                    MessageBox.Show(this, "Erro ao verificar o resultado do processamento das notas fiscais.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new Exception( "Erro ao verificar o resultado do processamento das notas fiscais.\r\n" + e.Message);
                }
            }
            finally
            {
            }
        }

        public void EnviaNfeEmail(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                string danfeNome;
                DanfeNFeReport danfeReport;
                Stream danfe = null;
                try
                {
                    danfe = this.gerarDanfe(nota.NFeEmitida, nota.NFeProc, out danfeNome, out danfeReport);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar a danfe da nfe: "+e.Message);
                }
                string xmlNome = null;
                Stream xml = null;
                try
                {
                    xml = this.gerarXML(nota.NFeEmitida, out xmlNome);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar o xml da nfe");
                }


                if (_dadosSalvarEnviarNfe.EnvioEmailHabilitado)
                {
                    try
                    {
                        EnvioEmailNFe envio = new EnvioEmailNFe(_logoDanfe);

                        #region Cópias para a empresa

                        string emailXML = null;
                        string emailDanfe = null;

                        if (_dadosSalvarEnviarNfe.EnvioEmailXmlHhabilitado)
                        {
                            emailXML = _dadosSalvarEnviarNfe.EnvioEmailXmlDestino;
                        }

                        if (_dadosSalvarEnviarNfe.EnvioEmailDanfeHabilitado)
                        {
                            emailDanfe = _dadosSalvarEnviarNfe.EnvioEmailDanfeDestino;
                        }

                        if (!string.IsNullOrWhiteSpace(emailXML))
                        {
                            if (emailXML.Equals(emailDanfe))
                            {
                                envio.enviaEmail(emailXML, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaAmbos,_usuarioAtual,command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);

                            }
                            else
                            {
                                envio.enviaEmail(emailXML, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaXML, _usuarioAtual, command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);
                                if (!string.IsNullOrWhiteSpace(emailDanfe))
                                {
                                    envio.enviaEmail(emailDanfe, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaDanfe, _usuarioAtual, command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(emailDanfe))
                            {
                                envio.enviaEmail(emailDanfe, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaDanfe, _usuarioAtual, command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);
                            }
                        }

                        #endregion

                        #region Email Cliente

                        if (_dadosSalvarEnviarNfe.EnvioEmailClienteHabilitado)
                        {
                            string emailXMLCliente;
                            string emailDanfeCliente;
                            this.getEmailsCliente(nota, out emailXMLCliente, out emailDanfeCliente, ref command);


                            if (!string.IsNullOrWhiteSpace(emailXMLCliente))
                            {
                                if (emailXMLCliente.Equals(emailDanfeCliente))
                                {
                                    envio.enviaEmail(emailXMLCliente, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaAmbos, _usuarioAtual, command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);
                                }
                                else
                                {
                                    envio.enviaEmail(emailXMLCliente, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaXML, _usuarioAtual, command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);
                                    if (!string.IsNullOrWhiteSpace(emailDanfeCliente))
                                    {
                                        envio.enviaEmail(emailDanfeCliente, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaDanfe, _usuarioAtual, command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);
                                    }
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(emailDanfeCliente))
                                {
                                    envio.enviaEmail(emailDanfeCliente, nota, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, danfe, danfeNome, TipoEmailNF.CopiaDanfe,_usuarioAtual,command, _dadosSalvarEnviarNfe.EnvioEmailRemetente);
                                }
                            }
                        }

                        #endregion
                    }
                    catch (Exception e)
                    {
                        if (!SuprimirRetornosRejeicao)
                        {
                            MessageBox.Show(null, "Erro ao enviar por email a NFe.\r\n" + e.Message, "Problema ao enviar a NFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            LogClass.EscreverLog("Erro ao enviar por email a NFe: " + e.Message, @caminhoLogFinalErroSuprimido);
                        }
                        
                    }
                }

                #region Imprimir DANFE
                if (_dadosSalvarEnviarNfe.ImprimirDanfeHabilitado)
                {
                    string impressora1 = _dadosSalvarEnviarNfe.ImprimirDanfeImpressora1;
                    string impressora2 = _dadosSalvarEnviarNfe.ImprimirDanfeImpressora2;

                    if (!string.IsNullOrWhiteSpace(impressora1))
                    {
                        danfeReport.PrintOptions.PrinterName = impressora1;
                        danfeReport.PrintToPrinter(1, true, 1, 9999);

                        nota.NFeEmitida.DanfeImpressa = true;
                    }

                    if (!string.IsNullOrWhiteSpace(impressora2))
                    {
                        danfeReport.PrintOptions.PrinterName = impressora2;
                        danfeReport.PrintToPrinter(1, true, 1, 9999);

                        nota.NFeEmitida.DanfeImpressa = true;
                    }
                }
                #endregion

                #region Salvar Pastas NFe
                if (_dadosSalvarEnviarNfe.SalvarPastaHabilitado)
                {
                    string pastaDanfe = _dadosSalvarEnviarNfe.SalvarPastaDanfe;
                    string pastaXML = _dadosSalvarEnviarNfe.SalvarPastaXml;

                    if (Directory.Exists(@pastaDanfe))
                    {
                        FileStream stream = new FileStream(@pastaDanfe + "\\" + danfeNome, FileMode.Create);
                        danfe.Seek(0, SeekOrigin.Begin);
                        byte[] danfeBytes = new byte[danfe.Length];
                        danfe.Read(danfeBytes, 0, danfeBytes.Length);

                        stream.Write(danfeBytes, 0, danfeBytes.Length);
                        stream.Close();

                        nota.NFeEmitida.DanfeImpressa = true;
                    }

                    if (Directory.Exists(@pastaXML))
                    {
                        StreamWriter writer = new StreamWriter(@pastaXML + "\\" + xmlNome, false);
                        writer.Write(nota.NFeEmitida.Xml);
                        writer.Close();

                        nota.NFeEmitida.XmlGerado = true;
                    }

                }

                #endregion

                nota.NFeEmitida.Save(ref command);
            }
            catch (Exception e)
            {
                if (!SuprimirRetornosRejeicao)
                {
                    MessageBox.Show(null, "Erro ao arquivar a NFe.\r\n" + e.Message, "Problema ao arquivar a NFe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    throw new Exception("Erro ao arquivar a NFe.\r\n" + e.Message);
                }

            }
        }

        private Stream gerarXML(NfeCompletoNotaClass nota, out string xmlNome)
        {
            string tempDir = Environment.GetEnvironmentVariable("temp");


            xmlNome = nota.Chave + "-procNfe.xml";


            StreamWriter writer = new StreamWriter(@tempDir + xmlNome, false);
            writer.Write(nota.Xml);
            writer.Close();


            return new StreamReader(@tempDir + xmlNome, false).BaseStream;

        }

        private Stream gerarDanfe(NfeCompletoNotaClass nota, TNfeProc nfe, out string danfeNome, out DanfeNFeReport danfeReport)
        {
            danfeNome = "";
            danfeReport = null;
            if (nota.Situacao != SituacaoNFe.Autorizada) return null;

            danfeNome = "DANFE-" + nota.Chave + ".pdf";
            List<TNfeProc> listNFs = new List<TNfeProc> { nfe };


            List<DanfeNFeClass> list = DanfeNFeClass.preencheDanfe(listNFs, _logoDanfe, ImprimirZerosTributosVazios);
            List<DanfeNFeItemCompleto> listPaginada = new List<DanfeNFeItemCompleto>();
            foreach (DanfeNFeClass danfeNFeClass in list)
            {
                listPaginada.AddRange(danfeNFeClass.paginarNFe());
            }
   

            danfeReport = new DanfeNFeReport();

            danfeReport.SetDataSource(listPaginada);

            List<DanfeDuplicatasDto> subDs = new List<DanfeDuplicatasDto>();
            foreach (DanfeNFeClass danfe in list)
            {
                if (danfe.DfeDuplicatasDto != null)
                {
                    subDs.AddRange(danfe.DfeDuplicatasDto);
                }
            }


            danfeReport.Subreports[0].SetDataSource(subDs);

            danfeReport.SetParameterValue("ExibirDuplicatas", ExibirDuplicatas);
            danfeReport.SetParameterValue("ExibirFatura", ExibirFaturas);

            return danfeReport.ExportToStream(ExportFormatType.PortableDocFormat);
        }


        private void ProcessaNFeDenegadaInterna(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {

            NfeSituacaoTransmissaoClass transmissao =
                 (NfeSituacaoTransmissaoClass)
                     new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                         new List<SearchParameterClass>()
                         {
                                new SearchParameterClass("IdNfPrincipal", nota.NFeEmitida.NfPrincipal.ID)
                         }).FirstOrDefault();


            if (transmissao == null)
            {
                transmissao = new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection)
                {
                    IdNfPrincipal = (int)nota.NFeEmitida.NfPrincipal.ID,
                    NotaTipo =
                        nota.NFeProc.NFe.infNFe.ide.mod == TMod.Item55 ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                    Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                    NotaNumero = nota.NFeEmitida.NfPrincipal.Numero,
                    NotaSerie = nota.NFeProc.NFe.infNFe.ide.serie,
                    NotaModelo = nota.NFeProc.NFe.infNFe.ide.mod.ToString().Replace("Item", ""),
                    NotaEmitente = nota.NFeProc.NFe.infNFe.emit.xNome,
                    NotaDestinatario = nota.NFeProc.NFe.infNFe.dest.xNome,
                    NotaDataEmissao = nota.NFeEmitida.NfPrincipal.DataEmissao,
                    NotaChave = nota.NFeProc.protNFe.infProt.chNFe,
                    IdNfCompletoNota = (int)nota.NFeEmitida.ID
                };
            }

            transmissao.Situacao = IWTNFSituacaoTransmissao.Denegada;
            transmissao.Mensagem = nota.codigoRetorno + " - " + nota.observacaoRetorno;
            transmissao.DataAtualizacao = DataIndependenteClass.GetData();


            transmissao.Save(ref command);

            ProcessaNFeDenegada(nota, ref command);
        }
        protected abstract void ProcessaNFeDenegada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command);

        private void ProcessaNFeRejeitadaInterna(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            NfeSituacaoTransmissaoClass transmissao = null;
            if (nota.NFeEmitida.NfPrincipal != null)
            {
                transmissao =
                    (NfeSituacaoTransmissaoClass)
                    new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                        new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("IdNfPrincipal", nota.NFeEmitida.NfPrincipal.ID)
                        }).FirstOrDefault();
            }
            else
            {
                transmissao =
                    (NfeSituacaoTransmissaoClass)
                    new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                        new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("IdNfCompletoNota", nota.NFeEmitida.ID)
                        }).FirstOrDefault();
            }


            
            if (transmissao == null)
            {

                if (nota.NFeProc != null)
                {
                    int numeroInt = -1;
                    int.TryParse(nota.NFeProc.NFe.infNFe.ide.nNF, out numeroInt);

                    DateTime dataEmissao;
                    DateTime.TryParse(nota.NFeProc.NFe.infNFe.ide.dhEmi, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out dataEmissao);

                    transmissao = new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection)
                    {
                        IdNfPrincipal = (int?) nota.NFeEmitida.NfPrincipal?.ID,
                        NotaTipo =
                            nota.NFeProc.NFe.infNFe.ide.mod == TMod.Item55 ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                        Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                        NotaNumero = numeroInt == -1 ? null : (int?) numeroInt,
                        NotaSerie = nota.NFeProc.NFe.infNFe.ide.serie,
                        NotaModelo = nota.NFeProc.NFe.infNFe.ide.mod.ToString().Replace("Item", ""),
                        NotaEmitente = nota.NFeProc.NFe.infNFe.emit.xNome,
                        NotaDestinatario = nota.NFeProc.NFe.infNFe.dest.xNome,
                        NotaDataEmissao = dataEmissao,
                        NotaChave = nota.NFeProc.protNFe.infProt.chNFe,
                        IdNfCompletoNota = (int) nota.NFeEmitida.ID
                    };
                }
            }

            if (transmissao != null)
            {
                transmissao.Situacao = IWTNFSituacaoTransmissao.Rejeitada;
                transmissao.Mensagem = nota.codigoRetorno + " - " + nota.observacaoRetorno;
                transmissao.DataAtualizacao = DataIndependenteClass.GetData();

                transmissao.Save(ref command);
            }

            ProcessaNFeRejeitada(nota, ref command);
        }

        protected abstract void ProcessaNFeRejeitada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command);

      

        private void ProcessaNFeProcessadaInterna(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            NfeSituacaoTransmissaoClass transmissao = null;
            if (nota.NFeEmitida.NfPrincipal != null)
            {

                transmissao =
                    (NfeSituacaoTransmissaoClass)
                    new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                        new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("IdNfPrincipal", nota.NFeEmitida.NfPrincipal.ID)
                        }).FirstOrDefault();

            }
            else
            {
                transmissao =
                    (NfeSituacaoTransmissaoClass)
                    new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection).Search(
                        new List<SearchParameterClass>()
                        {
                            new SearchParameterClass("IdNfCompletoNota", nota.NFeEmitida.ID)
                        }).FirstOrDefault();
            }

            if (nota.NFeProc != null)
            {
                int numeroInt = -1;
                int.TryParse(nota.NFeProc.NFe.infNFe.ide.nNF, out numeroInt);

                DateTime dataEmissao;
                DateTime.TryParse(nota.NFeProc.NFe.infNFe.ide.dhEmi, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out dataEmissao);

                transmissao = new NfeSituacaoTransmissaoClass(_usuarioAtual, command.Connection)
                {
                    IdNfPrincipal = (int?)nota.NFeEmitida.NfPrincipal?.ID,
                    NotaTipo =
                        nota.NFeProc.NFe.infNFe.ide.mod == TMod.Item55 ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                    Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                    NotaNumero = numeroInt == -1 ? null : (int?)numeroInt,
                    NotaSerie = nota.NFeProc.NFe.infNFe.ide.serie,
                    NotaModelo = nota.NFeProc.NFe.infNFe.ide.mod.ToString().Replace("Item", ""),
                    NotaEmitente = nota.NFeProc.NFe.infNFe.emit.xNome,
                    NotaDestinatario = nota.NFeProc.NFe.infNFe.dest.xNome,
                    NotaDataEmissao = dataEmissao,
                    NotaChave = nota.NFeProc.protNFe.infProt.chNFe,
                    IdNfCompletoNota = (int)nota.NFeEmitida.ID
                };
            }

            if (transmissao != null)
            {
                transmissao.Situacao = IWTNFSituacaoTransmissao.Processada;
                transmissao.Mensagem = nota.codigoRetorno + " - " + nota.observacaoRetorno;
                transmissao.DataAtualizacao = DataIndependenteClass.GetData();


                transmissao.Save(ref command);
            }

            ProcessaNFeProcessada(nota, ref command);
        }

        protected abstract void ProcessaNFeProcessada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command);


        private void getEmailsCliente(RetornoNFe nota, out string emailXML, out string emailDanfe, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                getEmailsCliente(nota.NFeEmitida.NfPrincipal, out emailXML, out emailDanfe, ref command);

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar os emails do cliente para envio da NFe\r\n" + e.Message, e);
            }
        }

        protected abstract void getEmailsCliente(NfPrincipalClass nf, out string emailXML, out string emailDanfe, ref IWTPostgreNpgsqlCommand command);
        #endregion

        public void Interromper()
        {
            //if (this.InvokeRequired)
            //{
            //    this.Invoke(new InterromperThreadSafeDelegate(Interromper), new object[] { });
            //}
            //else
            //{
                this.Parar = true;
            //}
        }

        protected virtual void FuncaoSistemaCliente1(bool scan, bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {
            
        }

        protected virtual void FuncaoSistemaCliente2(bool scan, bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {

        }

        protected virtual void FuncaoSistemaCliente3(bool scan, bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {

        }

        protected virtual void FuncaoSistemaCliente4(bool scan, bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {

        }

        protected virtual void FuncaoSistemaCliente5(bool scan, bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {

        }
    }
}
