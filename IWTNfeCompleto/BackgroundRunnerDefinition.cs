using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;

namespace IWTNFCompleto
{
    internal class BackgroundRunnerDefinition
    {
        private ServicoNFe tipoServico;
        private List<object> ArgumentosEntrada;
        internal List<object> ArgumentosSaida;
        private readonly ComunicacaoWaitForm _waitForm;
        internal object Retorno;

        public BackgroundRunnerDefinition(ServicoNFe tipoServico, List<object> argumentosEntrada, List<object> argumentosSaida, ComunicacaoWaitForm waitForm)
        {
            this.tipoServico = tipoServico;
            ArgumentosEntrada = argumentosEntrada;
            ArgumentosSaida = argumentosSaida;
            _waitForm = waitForm;
        }


        public void Run(object sender, DoWorkEventArgs e)
        {
            string retornoDetalhado;

           
            RetornoNFe notasRetonada;
            switch (tipoServico)
            {
                case ServicoNFe.NfeRecepcao:
                    if (ArgumentosEntrada[0] is NfPrincipalClass)
                    {

                        Retorno = NFeOperacoes.EnviaNfeInterno(
                            (NfPrincipalClass) ArgumentosEntrada[0],
                            (TCodUfIBGELegado) ArgumentosEntrada[1],
                            (TAmbLegado) ArgumentosEntrada[2],
                            (string) ArgumentosEntrada[3],
                            (IWTPostgreNpgsqlConnection) ArgumentosEntrada[4],
                            (string) ArgumentosEntrada[5],
                            (string) ArgumentosEntrada[6],
                            (string)ArgumentosEntrada[7],
                            (AcsUsuarioClass) ArgumentosEntrada[8],
                            (ComunicacaoWaitForm) ArgumentosEntrada[9],
                            
                            out notasRetonada);
                        ArgumentosSaida[0] = notasRetonada;

                    }
                    else
                    {
                        Retorno = NFeOperacoes.EnviaNfeInterno(
                            (NotaEnviar) ArgumentosEntrada[0],
                            (TCodUfIBGELegado) ArgumentosEntrada[1],
                            (TAmbLegado) ArgumentosEntrada[2],
                            (string) ArgumentosEntrada[3],
                            (IWTPostgreNpgsqlConnection) ArgumentosEntrada[4],
                            (string) ArgumentosEntrada[5],
                            (AcsUsuarioClass) ArgumentosEntrada[6],
                            (ComunicacaoWaitForm) ArgumentosEntrada[7],
                            
                            out notasRetonada);
                        ArgumentosSaida[0] = notasRetonada;
                    }
                    break;

                case ServicoNFe.NfeRetRecepcao:

                    List<RetornoNFe> notasRejeitadas;
                    List<RetornoNFe> notasDenegadas;
                    List<RetornoNFe> notasProcessadas;
                    Retorno = NFeOperacoes.ResultadoProcessamentoNFeInterno(
                        (NfeCompletoLoteClass) ArgumentosEntrada[0],
                        (TCodUfIBGELegado) ArgumentosEntrada[1],
                        (string) ArgumentosEntrada[4],
                        (IWTPostgreNpgsqlCommand) ArgumentosEntrada[5],
                        out retornoDetalhado,
                        out notasRejeitadas,
                        out notasDenegadas,
                        out notasProcessadas,
                        (AcsUsuarioClass) ArgumentosEntrada[6],
                        (bool)ArgumentosEntrada[7]
                        );

                    ArgumentosSaida[0] = retornoDetalhado;
                    ArgumentosSaida[1] = notasRejeitadas;
                    ArgumentosSaida[2] = notasDenegadas;
                    ArgumentosSaida[3] = notasProcessadas;
                     
                    
                    break;
                case ServicoNFe.NfeCancelamento:
                    Retorno = NFeOperacoes.CancelaNfeEventoInterno(
                        (NfeCompletoNotaClass) ArgumentosEntrada[0],
                        (TAmbLegado) ArgumentosEntrada[1],
                        (string) ArgumentosEntrada[2],
                        (string) ArgumentosEntrada[3],
                        out retornoDetalhado,
                        (bool)ArgumentosEntrada[4]);

                    ArgumentosSaida[0] = retornoDetalhado;
                    break;

                case ServicoNFe.NfeInutilizacao:
                    Retorno = NFeOperacoes.InutilizarFaixaNumeracaoInterno(
                        (int) ArgumentosEntrada[0],
                        (int) ArgumentosEntrada[1],
                        (int) ArgumentosEntrada[2],
                        (string) ArgumentosEntrada[3],
                        (TCodUfIBGELegado) ArgumentosEntrada[4],
                        (TAmbLegado) ArgumentosEntrada[5],
                        (TMod)ArgumentosEntrada[6],
                        (string) ArgumentosEntrada[7],
                        (string) ArgumentosEntrada[8],
                        out retornoDetalhado,
                        (string) ArgumentosEntrada[9],
                        (IWTPostgreNpgsqlConnection) ArgumentosEntrada[10],
                        (bool)ArgumentosEntrada[11]);
                    ArgumentosSaida[0] = retornoDetalhado;
                    break;

                case ServicoNFe.NfeConsultaProtocolo:
                    TRetConsSitNFe resultatoCompleto;
                    Retorno = NFeOperacoes.consultaSituacaoNfe((string)ArgumentosEntrada[0], (TAmbLegado)ArgumentosEntrada[1], (string)ArgumentosEntrada[2], out retornoDetalhado, out resultatoCompleto, (bool)ArgumentosEntrada[3]);
                    ArgumentosSaida[0] = retornoDetalhado;
                    ArgumentosSaida[1] = resultatoCompleto;
                    break;

                case ServicoNFe.NfeStatusServico:
                    Retorno = NFeOperacoes.SituacaoServicoInterno(
                        (TCodUfIBGELegado) ArgumentosEntrada[0],
                        (TAmbLegado) ArgumentosEntrada[1],
                        (string) ArgumentosEntrada[2],
                        out retornoDetalhado,
                        (bool)ArgumentosEntrada[3],
                        (TMod) ArgumentosEntrada[4]
                        );
                    ArgumentosSaida[0] = retornoDetalhado;
                    break;
                case ServicoNFe.NfeConsultaCadastro:
                    throw new NotImplementedException();
                    //Retorno = NFeOperacoes.ConsultaCadastroInterno(
                    //    (NFeTipoDocumento) ArgumentosEntrada[0],
                    //    (string) ArgumentosEntrada[1],
                    //    (TCodUfIBGE) ArgumentosEntrada[2],
                    //    (TAmb) ArgumentosEntrada[3],
                    //    (string)ArgumentosEntrada[4],
                    //    out retornoDetalhado,
                    //    (bool)ArgumentosEntrada[5]
                    //    );
                    //ArgumentosSaida[0] = retornoDetalhado;
                    break;

                case ServicoNFe.RecepcaoEvento:

                    Retorno = NFeOperacoes.CartaCorrecaoInterno(
                        (NfeCompletoNotaClass) ArgumentosEntrada[0],
                        (string) ArgumentosEntrada[1],
                        (TAmbLegado) ArgumentosEntrada[2],
                        (string) ArgumentosEntrada[3],
                        (string)ArgumentosEntrada[4],
                        (IWTPostgreNpgsqlCommand) ArgumentosEntrada[5],
                        out retornoDetalhado,
                        (bool)ArgumentosEntrada[6]
                        );
                    ArgumentosSaida[0] = retornoDetalhado;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            _waitForm.Fechar();

            if (e.Error!=null)
            {
                throw new Exception(e.Error.Message);
            }

            
        }
    }
}