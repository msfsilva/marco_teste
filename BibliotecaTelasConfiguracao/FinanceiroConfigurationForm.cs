#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Security.Cryptography.X509Certificates;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTFunctions;
using ProjectConstants;

#endregion

namespace BibliotecaTelasConfiguracao
{
    public partial class FinanceiroConfigurationForm : IWTBaseForm
    {
        public FinanceiroConfigurationForm()
        {

            InitializeComponent();
            this.carregarImpressoras();
            

            if (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE)=="0")
            {
                this.grbCertificado.Visible = false;
            }
            else
            {
                this.carregarCertificados();
            }
        }



        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.salvarImpressoras();
            if (this.grbCertificado.Visible)
            {
                this.salvarCertificados();
            }
            IWTConfiguration.Conf.RefreshConfs();
            this.Close();
        }

        private void carregarImpressoras()
        {
            foreach (string strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbImpressoraExpedicao.Items.Add(strPrinter);
                cmbImpressoraInterna.Items.Add(strPrinter);
            }

            this.cmbPapelExpedicao.Enabled = true;
            this.cmbPapelInterno.Enabled = true;

            this.cmbImpressoraExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PRINTER);
            this.cmbImpressoraInterna.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER);
            this.cmbPapelExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PAPER);
            this.cmbPapelInterno.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER);
        }

        private string salvarImpressoras()
        {
            string err = "";

            if (cmbImpressoraInterna.SelectedItem != null)
            {
                err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PRINTER, cmbImpressoraInterna.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            }

            if (cmbImpressoraExpedicao.SelectedItem != null)
            {
                err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PRINTER, cmbImpressoraExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            }

            if (cmbPapelInterno.SelectedItem != null)
            {
                err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PAPER, cmbPapelInterno.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            }

            if (cmbPapelExpedicao.SelectedItem != null)
            {
                err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PAPER, cmbPapelExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            }


            return err;

        }

        private void carregarCertificados()
        {
            try
            {

                this.cmbCertificados.Items.Clear();
                this.cmbCertificados.DataSource = null;

                X509Store store = new X509Store(StoreName.My);
                store.Open(OpenFlags.ReadOnly);

                List<LoadClass> ds = new List<LoadClass>();
                foreach (X509Certificate2 certificate in store.Certificates)
                {
                    if (Configurations.DataIndependenteClass.GetData() <= certificate.NotAfter && Configurations.DataIndependenteClass.GetData() >= certificate.NotBefore)
                    {
                        if (certificate.SerialNumber != null)
                        {
                            ds.Add(new LoadClass(certificate.SerialNumber, certificate.FriendlyName));
                        }
                    }
                }

                this.cmbCertificados.DataSource = ds;
                this.cmbCertificados.ValueMember = "id";
                this.cmbCertificados.DisplayMember = "descricao";

                string certificado = IWTConfiguration.Conf.getConf(Constants.NF_EMITENTE_CERTIFICADO);
                if (!string.IsNullOrWhiteSpace(certificado))
                {
                        this.cmbCertificados.SelectedValue = certificado;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os certificados\r\n" + e.Message, e);
            }
        }

        private string salvarCertificados()
        {
            string err = "";
            if (cmbCertificados.SelectedItem != null)
            {
             
                err += IWTConfiguration.Conf.setConf(Constants.NF_EMITENTE_CERTIFICADO, cmbCertificados.SelectedValue.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                
            }
            return err;
        }

        private void cmbImpressoraInterna_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmbPapelInterno.Items.Clear();

            PrintDocument doctoprint = new PrintDocument();
            doctoprint.PrinterSettings.PrinterName = cmbImpressoraInterna.SelectedItem.ToString();
            PrinterSettings.PaperSizeCollection paperSizeCollection = doctoprint.PrinterSettings.PaperSizes;

            for (int j = 0; j < paperSizeCollection.Count; j++)
            {
                cmbPapelInterno.Items.Add(paperSizeCollection[j].PaperName);
            }

            cmbPapelInterno.SelectedItem = null;
        }

        private void cmbImpressoraExpedicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPapelExpedicao.Items.Clear();

            PrintDocument doctoprint = new PrintDocument();
            doctoprint.PrinterSettings.PrinterName = cmbImpressoraExpedicao.SelectedItem.ToString();
            PrinterSettings.PaperSizeCollection paperSizeCollection = doctoprint.PrinterSettings.PaperSizes;

            for (int j = 0; j < paperSizeCollection.Count; j++)
            {
                cmbPapelExpedicao.Items.Add(paperSizeCollection[j].PaperName);
            }

            cmbPapelExpedicao.SelectedItem = null;
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
            if (IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_EXPEDICAO) == "1")
            {
                this.groupBox2.Text = "Etiqueta Expedição (10,8 cm x 18,9 cm)";
            }
            else
            {
                this.groupBox2.Text = "Etiqueta Expedição (8,5 cm x 5 cm)";
            }
        }
    }
}
