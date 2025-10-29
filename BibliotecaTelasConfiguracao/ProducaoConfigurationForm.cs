#region Referencias

using System;
using System.Drawing.Printing;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using ProjectConstants;

#endregion

namespace BibliotecaTelasConfiguracao
{
    public partial class ProducaoConfigurationForm : IWTBaseForm
   {
      public ProducaoConfigurationForm()
      {
         InitializeComponent();


         this.carregarImpressoras();
      }

      private void button1_Click(object sender, EventArgs e)
      {
          this.salvarImpressoras();
         this.Close();
      }


      private void carregarImpressoras()
      {
          cmbImpressoraExpedicao.Items.Clear();
          cmbImpressoraInterna.Items.Clear();

          foreach (string strPrinter in PrinterSettings.InstalledPrinters)
          {
              cmbImpressoraExpedicao.Items.Add(strPrinter);
              cmbImpressoraInterna.Items.Add(strPrinter);
          }

          cmbPapelExpedicao.Items.Clear();
          cmbPapelInterno.Items.Clear();

          this.cmbPapelExpedicao.Enabled = true;
          this.cmbPapelInterno.Enabled = true;

          this.cmbImpressoraExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PRINTER);
          this.cmbPapelExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PAPER);

          this.cmbImpressoraInterna.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER);
          this.cmbPapelInterno.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER);
      }

      private string salvarImpressoras()
      {
          string err = "";
          err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PRINTER, cmbImpressoraInterna.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PAPER, cmbPapelInterno.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PRINTER, cmbImpressoraExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PAPER, cmbPapelExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);

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

      private void ConfigurationForm_Shown(object sender, EventArgs e)
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
