using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaNotasFiscais;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTNFCompleto.BibliotecaTelasPadrao.Telas;
using IWTPostgreNpgsql;
using dbProvider;
using ProjectConstants;

namespace BibliotecaNFeCompleta
{
    public class NFeEmititdaEasiListForm : CadNFeEmitidaListForm
    {
        private readonly EmitenteClass _emitente;

        public NFeEmititdaEasiListForm(EmitenteClass emitente, byte[] logoDanfe) : base(emitente.Cnpj, emitente.SerialCertificado, logoDanfe,new BibliotecaImpressoraTermica.ImpressoraBmp.ImpressoraTermicaBmpOnlyFactory(), null,null,null)
        {
            _emitente = emitente;

            ExibirDuplicatas = true;
            ExibirFaturas = false;

            IWTNFCompleto.DanfeNFeClass.IncluirDuplicatasObs = false;
            base.ImprimirZerosTributosVazios = IWTConfiguration.Conf.getBoolConf(Constants.IMPRESSAO_VALORES_ZERO_DANFE);


        }

        public static void ConcluirCancelamentoManualmente(EmitenteClass emitente,  byte[] logoDanfe,NfeCompletoNotaClass nota, string justificativa)
        {
            NFeEmititdaEasiListForm formtemp = new NFeEmititdaEasiListForm(emitente, logoDanfe);
            formtemp.CancelarSistemaCliente(nota, justificativa);
        }

        protected override void CancelarSistemaCliente(NfeCompletoNotaClass nota, string justificativa)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                NfPrincipalClass nfPrincipal;
                if (nota.NfPrincipal == null)
                {

                    //Nota de Entrada
                    NfPrincipalClass search = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, command.Connection);
                    nfPrincipal = (NfPrincipalClass) search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("CnpjEmitente", nota.CnpjEmitente),
                        new SearchParameterClass("Numero", nota.Numero),
                        new SearchParameterClass("Serie", nota.Serie),
                        new SearchParameterClass("ModeloDocFiscalExato", "55")
                    }).FirstOrDefault();

                }
                else
                {
                    nfPrincipal = nota.NfPrincipal;
                }

                if (nfPrincipal == null)
                {
                    MessageBox.Show(null, "Não foi possível encontrar a NfPrincipal com os dados indicados, não é possível prosseguir com o processo de cancelamento no sistema cliente",
                        "Canceladmento de Nota fiscal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nfPrincipal.Tipo == TipoNota.Saida)
                {
                    NotaFiscalFuncoesAuxiliares.CancelarNFe(nfPrincipal, getUsuarioAtual(), command, justificativa);
                }
                else
                {
                    nfPrincipal.Situacao = "C";
                    nfPrincipal.CollectionNfPrincipalCancelamentoJustificativaClassNfPrincipal.Add(new NfPrincipalCancelamentoJustificativaClass(LoginClass.UsuarioLogado.loggedUser, command.Connection)
                    {
                        NfPrincipal = nfPrincipal,
                        Data = Configurations.DataIndependenteClass.GetData(),
                        AcsUsuario = LoginClass.UsuarioLogado.loggedUser,
                        Justificativa = justificativa
                    });

                    nfPrincipal.Save(ref command);


                    NotaFiscalEntradaClass search2 = new NotaFiscalEntradaClass(LoginClass.UsuarioLogado.loggedUser, command.Connection);
                    NotaFiscalEntradaClass nfEntrada = (NotaFiscalEntradaClass) search2.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("NfPrincipal", nfPrincipal)
                    }).FirstOrDefault();

                    if (nfEntrada == null)
                    {
                        MessageBox.Show(null,
                            "A nota fiscal " + nota.Numero + " foi cancelada. A nota é de entrada mas não foi encontrada nf de entrada para excluir.",
                            "Nota fiscal Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        command.Transaction.Commit();
                        return;
                    }

                    if (nfEntrada.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Any(a => a.Vinculada))
                    {
                        MessageBox.Show(null,
                            "A nota fiscal " + nota.Numero + " foi cancelada. A nota é de entrada, no entanto ela já possui recebimentos realizados, você deve ajustar o estoque manualmente.",
                            "Nota fiscal Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        command.Transaction.Commit();
                        return;
                    }

                    nfEntrada.Delete(ref command);


                }







                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw;
            }
        }

        protected override bool ValidaCancelamentoSistemaCliente(NfeCompletoNotaClass nota)
        {
            bool toRet;



            NfPrincipalClass search = new NfPrincipalClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
            NfPrincipalClass nf = search.Search(nota.Numero, nota.Serie, "55");

            if (nf == null) return true;

            IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

            toRet = NotaFiscalFuncoesAuxiliares.ValidarCancelamentoNFe(nf, ref command);


            return toRet;
        }
    }
}
