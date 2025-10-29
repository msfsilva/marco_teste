#region Referencias

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaTributos;
using Configurations;
using CrystalDecisions.Shared;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;
using ProjectConstants;

#endregion

namespace BibliotecaCompras
{
    public partial class OrcamentoReportForm : IWTBaseForm
    {
        private readonly EnviaOrcamentoEmailClass enviadorEmail;
        
        public OrcamentoReportForm(ref IWTPostgreNpgsqlCommand command, List<OrcamentoCompraClass> orcamentosList, bool visualizacao)
        {
            InitializeComponent();
            try
            {
                OrcamentoReport rep;
                List<OrcamentoCompraItemClass> listItensReport = new List<OrcamentoCompraItemClass>();
               
                foreach (OrcamentoCompraClass orc in orcamentosList)
                {   
                    listItensReport.AddRange(orc.orcamentoCompraItemList.Values);
                }

                rep = new OrcamentoReport();
                rep.SetDataSource(listItensReport);

                if (!visualizacao)
                {
                    

                    foreach (OrcamentoCompraClass orcamento in orcamentosList)
                    {

                        enviadorEmail = new EnviaOrcamentoEmailClass(NotaFiscalFuncoesAuxiliares.CarregaNomeEmpresa(), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                        if (this.enviadorEmail != null && orcamento.fornecedorEnviaEmail)
                        {
                            if (
                                MessageBox.Show(this,
                                                "O EASI está configurado para e enviar automaticamente a Solicitação de Orçamento para o fornecedor " +
                                                orcamento.razaoFornecedor + ".\r\nDeseja enviar agora?",
                                                "Envio Automático de Email", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                string Destinatario = orcamento.forEmail;
                                string Remetente = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_REMETENTE); 
                                string msgEmail = "";
                                
                                rep.SetParameterValue("idImprimir", orcamento.idOrcamentoCompra);
                                
                                this.enviadorEmail.setOrc(orcamento.idOrcamentoCompra.Value,
                                                          rep.ExportToStream(ExportFormatType.PortableDocFormat));
                                this.enviadorEmail.Enviar(Destinatario, Remetente, msgEmail);

                                orcamento.setEnviada();
                                orcamento.save(ref command);
                            }
                        }
                    }
                }

                string pam = "*";
                rep.SetParameterValue("idImprimir", pam);
                this.crystalReportViewer1.ReportSource = rep;
            }
            catch (Exception a)
            {
                throw new Exception(a.Message);
            }
        }
    }
}
