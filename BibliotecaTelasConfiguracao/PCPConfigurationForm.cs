#region Referencias

using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using ProjectConstants;

#endregion

namespace BibliotecaTelasConfiguracao
{
    public partial class PCPConfigurationForm : IWTBaseForm
    {
        ConfLoader ConfMngr;
        public PCPConfigurationForm(ConfLoader Conf)
        {
            InitializeComponent();
            this.ConfMngr = Conf;

            this.carregarImpressoras();
        }

        private bool ValidConfigs()
        {

            if (cmbPapelInterno.SelectedItem == null)
            {
                MessageBox.Show("Selecione o papel para etiquetas internas.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectTab(1);
                cmbPapelInterno.Focus();
                return false;
            }

            if (cmbPapelExpedicao.SelectedItem == null)
            {
                MessageBox.Show("Selecione o papel para etiquetas de expedição.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectTab(1);
                cmbPapelExpedicao.Focus();
                return false;
            }

            if (cmbImpressoraMedia.SelectedItem == null)
            {
                MessageBox.Show("Selecione o papel para etiquetas médias.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectTab(1);
                cmbImpressoraMedia.Focus();
                return false;
            }

            if (cmbImpressoraOP.SelectedItem == null)
            {
                MessageBox.Show("Selecione a Impressora de Ordem de Produção.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectTab(0);
                cmbImpressoraOP.Focus();
                return false;
            }


            return true;
        }

        private string SaveConf()
        {
            string err = "";


            err = this.salvarImpressoras();
            if (err != "") return err;

            return "";
        }

        private void carregarImpressoras()
        {
            foreach (string strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbImpressoraExpedicao.Items.Add(strPrinter);
                cmbImpressoraInterna.Items.Add(strPrinter);
                cmbImpressoraMedia.Items.Add(strPrinter);
                cmbImpressoraOP.Items.Add(strPrinter);
            }

            this.cmbImpressoraExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PRINTER);
            this.cmbImpressoraInterna.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER);
            this.cmbPapelExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PAPER);
            this.cmbPapelInterno.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER);

            this.cmbImpressoraMedia.SelectedItem = IWTConfiguration.Conf.getConf(Constants.MEDIUM_LABEL_PRINTER);
            this.cmbPapelMedio.SelectedItem = IWTConfiguration.Conf.getConf(Constants.MEDIUM_LABEL_PAPER);
            

            this.cmbImpressoraOP.SelectedItem = IWTConfiguration.Conf.getConf(Constants.IMPRESSORA_OP);
        }

        private string salvarImpressoras()
        {
            string err = "";
            err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PRINTER, cmbImpressoraInterna.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PRINTER, cmbImpressoraExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PAPER, cmbPapelInterno.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PAPER, cmbPapelExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            err += IWTConfiguration.Conf.setConf(Constants.IMPRESSORA_OP, cmbImpressoraOP.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            err += IWTConfiguration.Conf.setConf(Constants.MEDIUM_LABEL_PRINTER, cmbImpressoraMedia.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            err += IWTConfiguration.Conf.setConf(Constants.MEDIUM_LABEL_PAPER, cmbPapelMedio.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
            return err;

        }

        #region Eventos
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.ValidConfigs())
            {
                string msg = this.SaveConf();
                if (msg != "")
                {
                    MessageBox.Show(msg, "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void cmbImpressoraMedia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPapelMedio.Items.Clear();

            PrintDocument doctoprint = new PrintDocument();
            doctoprint.PrinterSettings.PrinterName = cmbImpressoraMedia.SelectedItem.ToString();
             PrinterSettings.PaperSizeCollection paperSizeCollection = doctoprint.PrinterSettings.PaperSizes;

            for (int j = 0; j < paperSizeCollection.Count; j++)
            {
                cmbPapelMedio.Items.Add(paperSizeCollection[j].PaperName);
            }

            cmbPapelMedio.SelectedItem = null;
        }
        #endregion

        private void ConfigurationsForm_Shown(object sender, EventArgs e)
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
