using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using BibliotecaImpressoraTermica;
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

    public class NFCeCompletoRunnerClass : Control
    {
        private delegate void InterromperThreadSafeDelegate();

        protected readonly string _certificado;
        protected readonly Semaphore _semaforoEmissaoNf;
        protected readonly TCodUfIBGELegado _ufEmitente;
        protected readonly string _cnpjTransmissor;
        protected AcsUsuarioClass _usuarioAtual;
        private readonly DadosSalvarEnviarNfe _dadosSalvarEnviarNfe;

        protected bool Parar { get; private set; }
        private const int intervalo = 1000;

        public bool SuprimirRetornosRejeicao { get; protected set; }

        private string _connectionString;
        private readonly string _csc;
        private readonly string _idCsc;
        private IImpressoraTermicaFactory _factoryImpressora;
        private string _enderecoImpressora;
        private int _larguraPapel;

        private string caminhoLogFinalErroSuprimido;

        public NFCeCompletoRunnerClass(
            string certificado,
             string ufEmitente, 
            string cnpjTransmissor, 
            string connectionString,
            string csc, string idCSC,
            AcsUsuarioClass usuarioAtual, 
            DadosSalvarEnviarNfe dadosSalvarEnviarNfe,
            Semaphore semaforoEmissaoNf
            )
        {
            _certificado = certificado;
            _semaforoEmissaoNf = semaforoEmissaoNf;
            _ufEmitente = FuncoesAuxiliares.Sigla2TCodUfIBGE(ufEmitente);
            _cnpjTransmissor = cnpjTransmissor;
            _usuarioAtual = usuarioAtual;
            _dadosSalvarEnviarNfe = dadosSalvarEnviarNfe;
            _connectionString = connectionString;
            _csc = csc;
            _idCsc = idCSC;

            caminhoLogFinalErroSuprimido = AppDomain.CurrentDomain.BaseDirectory + "\\LogEnvioFinalErroSuprimido.txt";


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

                        #endregion


                        BufferAbstractEntity.limparBuffer();

                        #region Criação dos Lotes

                        #region Notas no ambiente normal em homologação

                        this.CriaLotesNFCe(true, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente normal em produção

                        this.CriaLotesNFCe(false, singleConnection);

                        #endregion

                        #endregion

                        if (Parar) break;

                        #region Envio dos Lotes

                        #region Notas no ambiente normal em homologação

                        this.EnviaLotesNFCe(true, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente normal em produção

                        this.EnviaLotesNFCe(false, singleConnection);

                        #endregion

                        #endregion

                        if (Parar) break;

                        Thread.Sleep(15000);

                        #region Resultado de Processamento

                        #region Notas no ambiente normal em homologação

                        this.buscaResultadoLote(true, singleConnection);

                        #endregion

                        if (Parar) break;

                        #region Notas no ambiente normal em produção

                        this.buscaResultadoLote(false, singleConnection);

                        #endregion


                        #endregion

                        if (Parar) break;
                        
                    }
                    catch (ThreadAbortException)
                    {
                        if (Parar) break;
                    }
                    catch (Exception e)
                    {
                        if (!SuprimirRetornosRejeicao)
                        {
                            MessageBox.Show(this, "Erro inesperado ao realizar as operações da NFCe.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            LogClass.EscreverLog("Erro inesperado ao realizar as operações da NFCe: " + e.Message, @caminhoLogFinalErroSuprimido);
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
                            _semaforoEmissaoNf.Release();
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

        private void CriaLotesNFCe(bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = singleConnection.CreateCommand();

                NfPrincipalClass searchNf = new NfPrincipalClass(_usuarioAtual, singleConnection);

                List<NfPrincipalClass> notasEnviar = searchNf.getNotasPendentesEnvioReceita(homologacao,"65", _cnpjTransmissor);

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
                        new SearchParameterClass("Modelo", "65")
                    }).ToList().ConvertAll(a => (NfeCompletoNotaClass) a);

                    if (notasEnviadasAntes.Count != 0)
                    {
                        notasEnviar.RemoveAt(i);
                        i--;
                    }
                }


                if (notasEnviar.Count > 0)
                {
                    foreach (NfPrincipalClass nota in notasEnviar)
                    {
                        try
                        {
                            this.ProcessaNotasAEnviarInterno(nota, homologacao, command);

                            RetornoNFe notaRetornada;
                            LoteEnviar lote = NFeOperacoes.EnviaNfeInterno(
                                nota,
                                _ufEmitente,
                                homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao,
                                _certificado,
                                singleConnection,
                                _cnpjTransmissor,
                                _csc, 
                                _idCsc,
                                _usuarioAtual,
                                null,
                                out notaRetornada);
                        }
                        catch (Exception e)
                        {
                            IWTPostgreNpgsqlCommand command2 = singleConnection.CreateCommand();
                            RetornoNFe notaRet = new RetornoNFe
                            {
                                codigoRetorno = "INT",
                                NFeEmitida = new NfeCompletoNotaClass(_usuarioAtual, singleConnection)
                                {
                                    NfPrincipal = nota
                                },
                                observacaoRetorno = e.Message,
                                situacao = SituacaoNFe.Rejeitada
                            };

                            ProcessaNFeRejeitadaInterno(notaRet, ref command2);
                        }
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
                    MessageBox.Show(this, "Erro ao realizar o envio das notas fiscais (Criação do Lote), " + (homologacao ? "Homologação" : "Produção") + ") pendentes.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new Exception("Erro ao realizar o envio das notas fiscais (Criação do Lote), " + (homologacao ? "Homologação" : "Produção") + ") pendentes.\r\n" + e.Message);
                }
            }
        }

        private void EnviaLotesNFCe(bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {
            List<RetornoNFe> notasEnviarEmail = new List<RetornoNFe>();
            string retornoNotasRejeitadas = "";
            string retornoNotasDenegadas = "";
            string retornoEnvioEmail = "";
            try
            {
                List<NfeCompletoLoteClass> lotesEnviar = new NfeCompletoLoteClass(_usuarioAtual, singleConnection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Homologacao", homologacao),
                    new SearchParameterClass("Modelo", "65"),
                    new SearchParameterClass("Situacao", SituacaoLote.AguardandoEnvio),
                    new SearchParameterClass("CnpjTransmissorExato", _cnpjTransmissor)

                }).ConvertAll(a => (NfeCompletoLoteClass) a).ToList();

                foreach (NfeCompletoLoteClass lote in lotesEnviar)
                {
                    IWTPostgreNpgsqlCommand command = null;
                    try
                    {
                        //TODO: Tratar as notas no caso de rejeição do lote, excluir o lote
                        RetornoNFe notaRetornada = null;
                        try
                        {
                            notaRetornada = NFCeOperacoes.EnviarLote(
                                lote,
                                _ufEmitente,
                                homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao,
                                _certificado,
                                singleConnection,
                                _cnpjTransmissor,
                                _csc,
                                _idCsc,
                                _usuarioAtual,
                                null
                                );
                        }
                        catch (Exception e)
                        {
                            IWTPostgreNpgsqlCommand command2 = null;
                            try
                            {
                                command2 = singleConnection.CreateCommand();

                                command2.Transaction = command2.Connection.BeginTransaction();
                                lote.ResultadoObs = e.Message;
                                lote.Situacao = SituacaoLote.Enviado;
                                ProcessaLoteRejeitadoInterno(lote, command2);
                                lote.Delete(ref command2);

                                command2.Transaction.Commit();
                                continue;

                            }
                            catch (Exception a)
                            {
                                if (command2 != null && command2.Transaction != null)
                                {
                                    command2.Transaction.Rollback();
                                }
                                throw a;
                            }
                        }
                    
                        

                        command = singleConnection.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();


                        NfeCompletoNotaClass notaEnviada = lote.CollectionNfeCompletoNotaClassNfeCompletoLote.First();
                        if (lote.Scan && lote.GerarDanfeOffline)
                        {

                            notaEnviada.NfPrincipal.ImpressaoDanfeContingencia = true;
                            notaEnviada.NfPrincipal.ImpressaoDanfeLiberada = true;

                            notaEnviada.NfPrincipal.Save(ref command);

                            lote.Save(ref command);
                            command.Transaction.Commit();

                            continue;

                        }


                        if (notaRetornada != null)
                        {
                            notaEnviada.Save(ref command);

                            if (notaRetornada.situacao == SituacaoNFe.Autorizada)
                            {
                                this.ProcessaNFeProcessadaInterno(notaRetornada, ref command);

                                notaEnviada.NfPrincipal.ImpressaoDanfeContingencia = false;
                                notaEnviada.NfPrincipal.ImpressaoDanfeLiberada = true;

                                notaEnviada.NfPrincipal.Save(ref command);

                                try
                                {
                                    this.EnviaNfeEmail(notaRetornada, ref command);

                                }
                                catch (Exception e)
                                {
                                    retornoEnvioEmail += "NFe" + notaRetornada.NotaFiscal.infNFe.ide.nNF + ":" + e.Message + "\r\n";
                                }
                            }
                            else
                            {
                                if (notaRetornada.situacao == SituacaoNFe.Rejeitada)
                                {
                                    retornoNotasRejeitadas += "NFe" + notaRetornada.NotaFiscal.infNFe.ide.nNF + ":" + notaRetornada.codigoRetorno + " - " + notaRetornada.observacaoRetorno + "\r\n";
                                    this.ProcessaNFeRejeitadaInterno(notaRetornada, ref command);
                                }
                                else
                                {
                                    if (notaRetornada.situacao == SituacaoNFe.Denegada)
                                    {
                                        retornoNotasDenegadas += "NFe" + notaRetornada.NotaFiscal.infNFe.ide.nNF + ":" + notaRetornada.codigoRetorno + " - " + notaRetornada.observacaoRetorno + "\r\n";
                                        this.ProcessaNFeDenegadaInterno(notaRetornada, ref command);
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
                            if (!lote.Retry && lote.Situacao != SituacaoLote.Enviado )
                            {
                                this.ProcessaLoteRejeitadoInterno(lote, command);
                            }
                           
                        }

                        lote.Save(ref command);

                        command.Transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        if (command != null && command.Transaction != null)
                        {
                            command.Transaction.Rollback();
                        }
                        throw e;
                    }

                }
            }
            catch (Exception e)
            {
              
                throw new Exception("Erro ao processar o lote enviado/rejeitado.\r\n" + e.Message);

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

                
                if (!String.IsNullOrEmpty(retornoEnvioEmail))
                {

                    ScrollableMessageBox scrollableMessageBox = new ScrollableMessageBox(null, "As seguintes notas aceitas mas houveram problemas no envio do email e/ou no arquivamento: \r\n" + retornoEnvioEmail, "Envio de Email", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    scrollableMessageBox.ShowDialog();
                }
            }


            
        }

        private void ProcessaLoteRejeitadoInterno(NfeCompletoLoteClass lote, IWTPostgreNpgsqlCommand command)
        {
            foreach (NfeCompletoNotaClass nota in lote.CollectionNfeCompletoNotaClassNfeCompletoLote)
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
                        NotaTipo = nota.NfPrincipal.ModeloDocFiscal == "55" ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                        Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                        NotaNumero = nota.NfPrincipal.Numero,
                        NotaSerie = nota.NfPrincipal.Serie.ToString(),
                        NotaModelo = nota.NfPrincipal.ModeloDocFiscal,
                        NotaEmitente = nota.NfPrincipal.NfEmitente.Razao,
                        NotaDestinatario = nota.NfPrincipal.NfCliente.Razao,
                        NotaDataEmissao = nota.NfPrincipal.DataEmissao,
                        NotaChave = nota.Chave,
                        

                    };
                }

                transmissao.Situacao = IWTNFSituacaoTransmissao.Rejeitada;
                transmissao.Mensagem = lote.ResultadoObs;
                transmissao.DataAtualizacao = DataIndependenteClass.GetData();


                transmissao.Save(ref command);


            }
            ProcessaLoteRejeitado(lote, command);
        }

        protected virtual void ProcessaLoteRejeitado(NfeCompletoLoteClass lote, IWTPostgreNpgsqlCommand command)
        {
            throw new NotImplementedException();
        }

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
        protected virtual void ProcessaNotasAEnviar(NfPrincipalClass notaAEnviar, bool homologacao,
            IWTPostgreNpgsqlCommand command)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Resultado de Processamento

        private void buscaResultadoLote(bool homologacao, IWTPostgreNpgsqlConnection singleConnection)
        {
            IWTPostgreNpgsqlCommand command = null;

            try
            {
                List<NfeCompletoLoteClass> lotesBuscar = new NfeCompletoLoteClass(_usuarioAtual, singleConnection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Homologacao", homologacao),
                    new SearchParameterClass("Modelo", "65"),
                    new SearchParameterClass("Situacao", SituacaoLote.Enviado),
                    new SearchParameterClass("ExisteRecibo", true),
                    new SearchParameterClass("CnpjTransmissorExato", _cnpjTransmissor)

                }).ConvertAll(a => (NfeCompletoLoteClass)a).ToList();

                if (lotesBuscar.Any())
                {
                    string retornoDetalhado;
                    if (NFeOperacoes.SituacaoServicoInterno(this._ufEmitente, homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao, _certificado, out retornoDetalhado, false, TMod.Item65) != SituacaoServico.EmOperacao)
                    {
                        return;
                    }
                }

                string retornoNotasRejeitadas = "";
                string retornoNotasDenegadas = "";


                string retornoEnvioEmail = "";
                foreach (NfeCompletoLoteClass lote in lotesBuscar)
                {
                    try
                    {
                        command = singleConnection.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();

                        List<RetornoNFe> notasRejeitadas;
                        List<RetornoNFe> notasDenegadas;
                        List<RetornoNFe> notasProcessadas;
                        string retorno;



                        RetornoProcessamentoLote ret = NFeOperacoes.ResultadoProcessamentoNFeInterno(
                            lote,
                            _ufEmitente,
                            _certificado,
                            command,
                            out retorno,
                            out notasRejeitadas,
                            out notasDenegadas,
                            out notasProcessadas,
                            _usuarioAtual,
                            false);




                        if (ret == RetornoProcessamentoLote.Erro || ret == RetornoProcessamentoLote.ProcessadoComProblemas)
                        {
                            foreach (RetornoNFe nota in notasRejeitadas)
                            {
                                retornoNotasRejeitadas += "NFe" + nota.NotaFiscal.infNFe.ide.nNF + ":" + nota.codigoRetorno + " - " + nota.observacaoRetorno + "\r\n";
                                this.ProcessaNFeRejeitadaInterno(nota, ref command);
                                lote.CollectionNfeCompletoNotaClassNfeCompletoLote.Remove(nota.NFeEmitida);
                            }

                            foreach (RetornoNFe nota in notasDenegadas)
                            {
                                retornoNotasDenegadas += "NFe" + nota.NotaFiscal.infNFe.ide.nNF + ":" + nota.codigoRetorno + " - " + nota.observacaoRetorno + "\r\n";
                                this.ProcessaNFeDenegadaInterno(nota, ref command);
                            }
                        }

                        foreach (RetornoNFe nota in notasProcessadas)
                        {

                            if (!nota.NFeEmitida.NfPrincipal.ImpressaoDanfeLiberada)
                            {
                                nota.NFeEmitida.NfPrincipal.ImpressaoDanfeLiberada = true;
                                nota.NFeEmitida.NfPrincipal.Save(ref command);
                            }

                            this.ProcessaNFeProcessadaInterno(nota, ref command);
                            
                            try
                            {
                                this.EnviaNfeEmail(nota, ref command);

                            }
                            catch (Exception e)
                            {
                                retornoEnvioEmail += "NFe" + nota.NotaFiscal.infNFe.ide.nNF + ":" + e.Message + "\r\n";
                            }
                        }

                        lote.Save(ref command);

                        command.Transaction.Commit();
                        command.Transaction = null;


                    }
                    catch (Exception e)
                    {
                        if (command != null && command.Transaction != null)
                        {
                            command.Transaction.Rollback();
                        }

                        throw e;
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


                    if (!String.IsNullOrEmpty(retornoEnvioEmail))
                    {

                        ScrollableMessageBox scrollableMessageBox = new ScrollableMessageBox(null, "As seguintes notas aceitas mas houveram problemas no envio do email e/ou no arquivamento: \r\n" + retornoEnvioEmail, "Envio de Email", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        scrollableMessageBox.ShowDialog();
                    }
                }

           

              

            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception e)
            {
                if (!SuprimirRetornosRejeicao)
                {
                    MessageBox.Show(this, "Erro ao verificar o resultado do processamento das notas fiscais.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    throw new Exception("Erro ao verificar o resultado do processamento das notas fiscais.\r\n" + e.Message);
                }
            }
            finally
            {
                
            }
        }

        private void EnviaNfeEmail(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                #if DEBUG
                    return;
                #endif

                string xmlNome = null;
                Stream xml = null;
                try
                {
                    xml = this.gerarXML(nota.NFeEmitida, out xmlNome);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar o xml da nfce");
                }


                if (_dadosSalvarEnviarNfe.EnvioEmailHabilitado)
                {
                    try
                    {
                        EnvioEmailNFCe envio = new EnvioEmailNFCe(_dadosSalvarEnviarNfe.EnvioEmailRemetente);

                        #region Cópias para a empresa

                        string emailXML = null;

                        if (_dadosSalvarEnviarNfe.EnvioEmailXmlHhabilitado)
                        {
                            emailXML = _dadosSalvarEnviarNfe.EnvioEmailXmlDestino;
                        }



                        if (!string.IsNullOrWhiteSpace(emailXML))
                        {
                            envio.enviaEmail(emailXML, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, TipoEmailNF.CopiaXML);
                        }

                        #endregion

                        #region Email Cliente

                        if (_dadosSalvarEnviarNfe.EnvioEmailClienteHabilitado)
                        {
                            string emailXMLCliente = null;
                            if (nota.NFeProc.NFe.infNFe.dest != null)
                            {
                                emailXMLCliente = nota.NFeProc.NFe.infNFe.dest.email;
                            }

                            if (!string.IsNullOrWhiteSpace(emailXMLCliente))
                            {
                                envio.enviaEmail(emailXMLCliente, nota.NFeEmitida, nota.NFeProc, xml, xmlNome, TipoEmailNF.CopiaXML);
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
                            throw new Exception("Erro ao enviar por email a NFe.\r\n" + e.Message);
                        }
                    }
                }

                #region Salvar Pastas NFe

                if (_dadosSalvarEnviarNfe.SalvarPastaHabilitado)
                {
                    string pastaXML = _dadosSalvarEnviarNfe.SalvarPastaXml;

                    if (Directory.Exists(@pastaXML))
                    {
                        StreamWriter writer = new StreamWriter(@pastaXML + "\\" + xmlNome, false);
                        writer.Write(nota.NFeEmitida.Xml);
                        writer.Close();

                        nota.NFeEmitida.XmlGerado = true;
                    }

                }

                #endregion

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
            writer.Write(XElement.Parse(nota.Xml).ToString());
            writer.Close();


            return new StreamReader(@tempDir + xmlNome, false).BaseStream;

        }


        private void ProcessaNFeDenegadaInterno(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
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
            transmissao.NotaEnderecoConsultaDireto = nota.NotaFiscal.infNFeSupl.qrCode;


            transmissao.Save(ref command);

            ProcessaNFeDenegada(nota, ref command);
        }
        protected virtual void ProcessaNFeDenegada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            throw new NotImplementedException();
        }

        private void ProcessaNFeRejeitadaInterno(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
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

            transmissao.Situacao = IWTNFSituacaoTransmissao.Rejeitada;
            transmissao.Mensagem = nota.codigoRetorno + " - " + nota.observacaoRetorno;
            transmissao.DataAtualizacao = DataIndependenteClass.GetData();


            transmissao.Save(ref command);

            ProcessaNFeRejeitada(nota, ref command);
        }
        protected virtual void ProcessaNFeRejeitada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            throw new NotImplementedException();
        }

        private void ProcessaNFeProcessadaInterno(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
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

            transmissao.Situacao = IWTNFSituacaoTransmissao.Processada;
            transmissao.Mensagem = nota.codigoRetorno + " - " + nota.observacaoRetorno;
            transmissao.DataAtualizacao = DataIndependenteClass.GetData();
            transmissao.NotaEnderecoConsultaDireto = nota.NotaFiscal.infNFeSupl.qrCode;


            transmissao.Save(ref command);

            ProcessaNFeProcessada(nota, ref command);
        }
        protected virtual void ProcessaNFeProcessada(RetornoNFe nota, ref IWTPostgreNpgsqlCommand command)
        {
            throw new NotImplementedException();
        }
  
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
    }


}
