#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using BibliotecaCentroCusto;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTNFCompleto;
using ProjectConstants;

#endregion

namespace BibliotecaTelasConfiguracao
{
   public partial class GerencialConfigurationForm : IWTBaseForm
   {
       readonly ConfLoader ConfMngr;
       private CentroCustoLucroClass centroCusto = null;

       public GerencialConfigurationForm(ConfLoader Conf)
       {
           InitializeComponent();
           this.ConfMngr = Conf;



           nudSegundosConferencia.Value = int.Parse(IWTConfiguration.Conf.getConf(Constants.SECONDS_TO_CONF));

           nudPorcentagemCancelamentoSaldo.Value = int.Parse(IWTConfiguration.Conf.getConf(Constants.PERCENT_CANCEL_LEFTOVER));

           nudDiasDuplicata.Value = int.Parse(IWTConfiguration.Conf.getConf(Constants.NF_DAYS_TO_PAYMENT));
           //dateTimePicker1.CustomFormat = "HH:MM";


           LimiteSessaonumericUpDown.Value = int.Parse(this.ConfMngr.getConf(Constants.SESSION_LIMIT_TIME));

           nudIntervaloImportacaoPedidos.Value = int.Parse(this.ConfMngr.getConf(Constants.INTERVALO_IMPORTACAO_PEDIDOS));
           nudIntervaloImportacaoNFEntrada.Value = int.Parse(this.ConfMngr.getConf(Constants.INTERVALO_IMPORTACAO_NF_COMPRA));
           this.loadComboContaBancaria();
           this.carregarImpressoras();
           this.carregarEmail();
           this.carregarSemana();
           this.carregarQualidade();
           this.carregarEstoque();
           this.carregarCompras();
           this.carregarNFeEntrada();
           this.carregarDocumentos();
           this.carregarLogo();
           this.carregarExportacoes();
           this.carregarVendas();
           this.carregarFinanceiro();
           this.carregarOP();
           this.carregarConfigPedidoOrcamento();
           this.LoadConfiguracoesEtiquetaCliente();

           this.chkSupplyOn.Checked = Convert.ToBoolean(Convert.ToInt16(this.ConfMngr.getConf(Constants.USE_SUPPLYON)));

           this.nudNumThreads.Value = Convert.ToInt32(this.ConfMngr.getConf(Constants.NUM_THREADS));

           this.rdbTabelaPrecosAutomatico.Checked = IWTConfiguration.Conf.getBoolConf(Constants.TABELA_PRECOS_AUTOMATICO);
           this.iwtRadioButton1.Checked = !IWTConfiguration.Conf.getBoolConf(Constants.TABELA_PRECOS_AUTOMATICO);
           this.nudTabelaPrecosHora.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.TABELA_PRECOS_HORA));
           this.nudTabelaPrecosMinutos.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.TABELA_PRECOS_MINUTO));

           this.numDiasvalidadePrecoProduto.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_VALIDADE_PRECO));

           txtEstacaoAutomacao.Text = IWTConfiguration.Conf.getConf(Constants.ESTACAO_AUTORIZADA_AUTOMACAO);
       }



       private void button1_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      private bool ValidConfigs()
      {

         if (cmbPapelInterno.SelectedItem == null)
         {
             MessageBox.Show("Selecione o papel para etiquetas internas.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             tabControl1.SelectTab(getTabPai(cmbPapelInterno));
             cmbPapelInterno.Focus();
             return false;
         }

         if (cmbPapelExpedicao.SelectedItem == null)
         {
             MessageBox.Show("Selecione o papel para etiquetas de expedição.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             tabControl1.SelectTab(getTabPai(cmbPapelExpedicao));
             cmbPapelExpedicao.Focus();
             return false;
         }

         if (cmbImpressoraOP.SelectedItem == null)
         {
             MessageBox.Show("Selecione a Impressora de Ordem de Produção.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             tabControl1.SelectTab(getTabPai(cmbImpressoraOP));
             cmbImpressoraOP.Focus();
             return false;
         }

         return this.validConfEmail() && this.validaConfSemana() && validConfVendas();
                   
         return true;
      }

      private void button2_Click(object sender, EventArgs e)
      {
          try
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
          catch (Exception a)
          {
              MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }

      }

      private string SaveConf()
      {
          string err = "";


          err = this.ConfMngr.SetConf(Constants.SECONDS_TO_CONF, nudSegundosConferencia.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;



          err = this.ConfMngr.SetConf(Constants.PERCENT_CANCEL_LEFTOVER, nudPorcentagemCancelamentoSaldo.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;

          err = this.ConfMngr.SetConf(Constants.NF_DAYS_TO_PAYMENT, nudDiasDuplicata.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;



          err = this.ConfMngr.SetConf(Constants.SESSION_LIMIT_TIME, LimiteSessaonumericUpDown.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;

          err = this.ConfMngr.SetConf(Constants.INTERVALO_IMPORTACAO_PEDIDOS, nudIntervaloImportacaoPedidos.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;

          err = this.ConfMngr.SetConf(Constants.INTERVALO_IMPORTACAO_NF_COMPRA, nudIntervaloImportacaoNFEntrada.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;

          err = this.salvarImpressoras();
          if (err != "") return err;

          err = this.ConfMngr.SetConf(Constants.USE_SUPPLYON, Convert.ToInt16(this.chkSupplyOn.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;

          err = this.salvarEmail();
          if (err != "") return err;

          err = this.salvarSemana();
          if (err != "") return err;

          err = this.salvarQualidade();
          if (err != "") return err;

          err = this.salvarEstoque();
          if (err != "") return err;

          err = this.salvarCompras();
          if (err != "") return err;

          err = this.salvarNFeEntrada();
          if (err != "") return err;

          err = this.salvarDocumentos();
          if (err != "") return err;

          err = this.salvarLogo();
          if (err != "") return err;

          err = this.salvarExportacoes();
          if (err != "") return err;

          err = this.salvarVendas();
          if (err != "") return err;

          err = this.salvarFinanceiro();
          if (err != "") return err;

          err = this.salvarOP();
          if (err != "") return err;

          err = this.salvarPedidoOrcamento();
          if (err != "") return err;

          err = this.SalvarConfiguracoesEtiquetaCliente();
          if (err != "") return err;

          err = this.ConfMngr.SetConf(Constants.NUM_THREADS, this.nudNumThreads.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          err = IWTConfiguration.Conf.SetConf(Constants.TABELA_PRECOS_AUTOMATICO, Convert.ToInt16(this.rdbTabelaPrecosAutomatico.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err = IWTConfiguration.Conf.SetConf(Constants.TABELA_PRECOS_HORA, Convert.ToInt32(this.nudTabelaPrecosHora.Value).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err = IWTConfiguration.Conf.SetConf(Constants.TABELA_PRECOS_MINUTO, Convert.ToInt32(this.nudTabelaPrecosMinutos.Value).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          err = IWTConfiguration.Conf.SetConf(Constants.ESTACAO_AUTORIZADA_AUTOMACAO, txtEstacaoAutomacao.Text, LoginClass.UsuarioLogado.loggedUser.Login);

          err = this.ConfMngr.SetConf(Constants.DIAS_VALIDADE_PRECO, numDiasvalidadePrecoProduto.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          if (err != "") return err;

            return "";
      }

      private void btnCodigoBarras_Click(object sender, EventArgs e)
      {
          if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
          {
              txtDiretorioExportacaoCSV.Text = folderBrowserDialog1.SelectedPath;
          }
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
       
      private void carregarImpressoras()
      {
          foreach (string strPrinter in PrinterSettings.InstalledPrinters)
          {
              cmbImpressoraExpedicao.Items.Add(strPrinter);
              cmbImpressoraInterna.Items.Add(strPrinter);
              cmbImpressoraOP.Items.Add(strPrinter);
              cmbEtiquetaClienteImpressora.Items.Add(strPrinter);
          }

          this.cmbPapelExpedicao.Enabled = true;
          this.cmbPapelInterno.Enabled = true;

          this.cmbImpressoraExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PRINTER);
          this.cmbImpressoraInterna.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER);
          this.cmbPapelExpedicao.SelectedItem = IWTConfiguration.Conf.getConf(Constants.EXPEDITION_LABEL_PAPER);
          this.cmbPapelInterno.SelectedItem = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER);

          this.cmbImpressoraOP.SelectedItem = IWTConfiguration.Conf.getConf(Constants.IMPRESSORA_OP);

          this.rdbEtiquetaGrande.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_EXPEDICAO) == "0";
          this.rdbEtiquetaMedia.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_EXPEDICAO) == "1";
          this.rdbEtiquetaPequena.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_EXPEDICAO) == "2";
          
          this.rdbEtiquetaMediaRecebimento.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_RECEBIMENTO) == "0";
          this.rdbEtiquetaPequenaRecebimento.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_RECEBIMENTO) == "1";

          rdbEtiquetaProdutoHorizontal.Checked = !IWTConfiguration.Conf.getBoolConf(Constants.ETIQUETA_PRODUTO_VERTICAL);
          rdbEtiquetaProdutoVertical.Checked = IWTConfiguration.Conf.getBoolConf(Constants.ETIQUETA_PRODUTO_VERTICAL);


        }



      private void carregarConfigPedidoOrcamento()
      {
          this.rdImprimirTodos.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_IMPRESSAO_ESPELHO_PEDIDO) == "0";
          this.rdSomenteSbZero.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_IMPRESSAO_ESPELHO_PEDIDO) == "1";
          //this.rdSomenteNaoSubZero.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_IMPRESSAO_ESPELHO_PEDIDO) == "2";

          this.txtObsPadraoEspelho.Text = IWTConfiguration.Conf.getConf(Constants.OBSERVACAO_PADRAO_ESPELHO_PEDIDO_ORCAMENTO) ;

          this.chkPermitirFaturarPedido.Checked = IWTConfiguration.Conf.getBoolConf(Constants.NF_PERMITIR_FATURAR_PEDIDO);


          string tipoInclusaoPedidoNf = IWTConfiguration.Conf.getConf(Constants.NF_INCLUIR_NUMERO_PEDIDO_NF);
          switch (tipoInclusaoPedidoNf)
          {
              case "0":
                  this.rdbNumeroPedidoNaoIncluir.Checked = true;
                  break;
              case "1":
                  this.rdbNumeroPedidoDescricaoItem.Checked = true;
                  break;
              case "2":
                  this.rdbNumeroPedidoObservacao.Checked = true;
                  break;
              default:
                  this.rdbNumeroPedidoDescricaoItem.Checked = true;
                  break;
          }

          chkPesoVolumeNFe.Checked = IWTConfiguration.Conf.getBoolConf(Constants.VALIDAR_PESO_VOLUMES_NFE);

          chkRegistrarAlteracoesPedido.Checked = IWTConfiguration.Conf.getBoolConf(Constants.HISTORICO_ALTERACOES_PEDIDO);

      }

      private string salvarImpressoras()
      {
          string err = "";
          err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PRINTER, cmbImpressoraInterna.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PRINTER, cmbImpressoraExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.setConf(Constants.INTERNAL_LABEL_PAPER, cmbPapelInterno.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.setConf(Constants.EXPEDITION_LABEL_PAPER, cmbPapelExpedicao.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.setConf(Constants.IMPRESSORA_OP, cmbImpressoraOP.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);

          string tipoEtiqueta = "0";
          if (this.rdbEtiquetaGrande.Checked)
          {
              tipoEtiqueta = "0";
          }
          if (this.rdbEtiquetaMedia.Checked)
          {
              tipoEtiqueta = "1";
          }
          if (this.rdbEtiquetaPequena.Checked)
          {
              tipoEtiqueta = "2";
          }

          err += IWTConfiguration.Conf.SetConf(Constants.TIPO_ETIQUETA_EXPEDICAO, tipoEtiqueta, LoginClass.UsuarioLogado.loggedUser.Login);  

          string tipoEtiquetaRecebimento = "0";
          if (this.rdbEtiquetaMediaRecebimento.Checked)
          {
              tipoEtiquetaRecebimento = "0";
          }
          if (this.rdbEtiquetaPequenaRecebimento.Checked)
          {
              tipoEtiquetaRecebimento = "1";
          }

          err += IWTConfiguration.Conf.SetConf(Constants.TIPO_ETIQUETA_RECEBIMENTO, tipoEtiquetaRecebimento, LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.ETIQUETA_PRODUTO_VERTICAL, Convert.ToInt16(rdbEtiquetaProdutoVertical.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

            return err;

      }

      private void chkAvisoEmissaoNF_CheckedChanged(object sender, EventArgs e)
      {
          this.grbAvisoEmissaoNF.Enabled = this.chkAvisoEmissaoNF.Checked;
      }

      private void chkSmtpAutenticado_CheckedChanged(object sender, EventArgs e)
      {
          this.txtSmtpUsuario.Enabled = this.chkSmtpAutenticado.Checked;
          this.txtSmtpSenha.Enabled = this.chkSmtpAutenticado.Checked;
          this.chkSmtpSSH.Enabled = this.chkSmtpAutenticado.Checked;

      }

       private void carregarEmail()
       {
           this.txtSmtpHost.Text = IWTConfiguration.Conf.getConf(Constants.SMTP_HOST);

           try
           {
               this.nudSmtpPort.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.SMTP_PORT));
           }
           catch
           {
               this.nudSmtpPort.Value = 25;
           }

           this.chkSmtpAutenticado.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.SMTP_AUTHENTICATION)));
           this.chkSmtpSSH.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.SMTP_AUTHENTICATION_SSH)));
           this.txtSmtpUsuario.Text = IWTConfiguration.Conf.getConf(Constants.SMTP_USER);
           this.txtSmtpSenha.Text = IWTConfiguration.Conf.getConf(Constants.SMTP_PASSWORD);

           this.chkAvisoEmissaoNF.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.AVISO_NF_ATIVO)));
           this.txtRemetente.Text = IWTConfiguration.Conf.getConf(Constants.AVISO_NF_REMETENTE);
           this.txtDestinatario.Text = IWTConfiguration.Conf.getConf(Constants.AVISO_NF_DESTINATARIO);

           this.txtRemetenteCompras.Text = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_REMETENTE);
           this.txtRementePedidoOrcamento.Text = IWTConfiguration.Conf.getConf(Constants.PEDIDO_EMAIL_REMETENTE);

           chkEnvioPedidoDestInterno.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.ENVIO_EMAIL_DESTINATARIO_INTERNO_PEDIDO)));
           txtDestinatarioInternoPedido.Text = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_INTERNO_PEDIDO);

           chkEnvioOrcamentoDestInterno.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.ENVIO_EMAIL_DESTINATARIO_INTERNO_ORCAMENTO)));
           txtDestinatarioInternoOrcamento.Text = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_INTERNO_ORCAMENTO);

           chkDestinatarioConfiguracaoAutomatica.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.ENVIO_EMAIL_CONFIGURACAO_AUTOMATICA_PEDIDOS)));
           txtDestinatarioConfiguracaoAutomatica.Text = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_CONFIGURACAO_AUTOMATICA_PEDIDOS);

       }

       private string salvarEmail()
       {
           string err = "";
           err += IWTConfiguration.Conf.SetConf(Constants.SMTP_HOST, this.txtSmtpHost.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.SMTP_PORT, this.nudSmtpPort.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.SMTP_AUTHENTICATION, Convert.ToInt16(this.chkSmtpAutenticado.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.SMTP_AUTHENTICATION_SSH, Convert.ToInt16(this.chkSmtpSSH.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.SMTP_USER, this.txtSmtpUsuario.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.SMTP_PASSWORD, this.txtSmtpSenha.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.AVISO_NF_ATIVO, Convert.ToInt16(this.chkAvisoEmissaoNF.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.AVISO_NF_REMETENTE, this.txtRemetente.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.AVISO_NF_DESTINATARIO, this.txtDestinatario.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.COMPRAS_EMAIL_REMETENTE, this.txtRemetenteCompras.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.PEDIDO_EMAIL_REMETENTE, this.txtRementePedidoOrcamento.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.ENVIO_EMAIL_DESTINATARIO_INTERNO_PEDIDO, Convert.ToInt16(this.chkEnvioPedidoDestInterno.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.DESTINATARIO_INTERNO_PEDIDO, this.txtDestinatarioInternoPedido.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.ENVIO_EMAIL_DESTINATARIO_INTERNO_ORCAMENTO, Convert.ToInt16(this.chkEnvioOrcamentoDestInterno.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.DESTINATARIO_INTERNO_ORCAMENTO, this.txtDestinatarioInternoOrcamento.Text, LoginClass.UsuarioLogado.loggedUser.Login);

           err += IWTConfiguration.Conf.SetConf(Constants.ENVIO_EMAIL_CONFIGURACAO_AUTOMATICA_PEDIDOS, Convert.ToInt16(this.chkDestinatarioConfiguracaoAutomatica.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.DESTINATARIO_CONFIGURACAO_AUTOMATICA_PEDIDOS, this.txtDestinatarioConfiguracaoAutomatica.Text, LoginClass.UsuarioLogado.loggedUser.Login);




           err += IWTConfiguration.Conf.SetConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_HOST, this.txtSmtpHost.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_PORT, this.nudSmtpPort.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_AUTHENTICATION, Convert.ToInt16(this.chkSmtpAutenticado.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_AUTHENTICATION_SSH, Convert.ToInt16(this.chkSmtpSSH.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_USER, this.txtSmtpUsuario.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(NFeConstantes.NFE_ENVIO_EMAIL_SMTP_PASSWORD, this.txtSmtpSenha.Text, LoginClass.UsuarioLogado.loggedUser.Login);

           return err;
       }

       private bool validConfEmail()
      {
          if (txtSmtpHost.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe o servidor de envio de email.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(txtSmtpHost));
              txtSmtpHost.Focus();
              return false;
          }


          if (chkSmtpAutenticado.Checked && txtSmtpUsuario.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe o usuário do servidor de envio de email.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(chkSmtpAutenticado));
              txtSmtpUsuario.Focus();
              return false;
          }

          if (chkSmtpAutenticado.Checked && txtSmtpSenha.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe a senha do servidor de envio de email.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(chkSmtpAutenticado));
              txtSmtpSenha.Focus();
              return false;
          }

          if (chkAvisoEmissaoNF.Checked && txtRemetente.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe o remetente de envio de email.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(chkAvisoEmissaoNF));
              txtRemetente.Focus();
              return false;
          }

          if (chkAvisoEmissaoNF.Checked && txtDestinatario.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe o destinatário de envio de email.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(chkAvisoEmissaoNF));
              txtDestinatario.Focus();
              return false;
          }

          if(txtRementePedidoOrcamento.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe o remetente de envio de email para Pedido e Orçamento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(txtRementePedidoOrcamento));
              txtRementePedidoOrcamento.Focus();
              return false;
          }

          if (chkEnvioPedidoDestInterno.Checked && txtDestinatarioInternoPedido.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe o destinatário interno para envio de email de Pedido.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(chkEnvioPedidoDestInterno));
              txtDestinatarioInternoPedido.Focus();
              return false;
          }

          if (chkEnvioOrcamentoDestInterno.Checked && txtDestinatarioInternoOrcamento.Text.Trim().Length == 0)
          {
              MessageBox.Show("Informe o destinatário interno para envio de email de Orçamento.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(chkEnvioOrcamentoDestInterno));
              txtDestinatarioInternoOrcamento.Focus();
              return false;
          }

            if (chkDestinatarioConfiguracaoAutomatica.Checked && txtDestinatarioConfiguracaoAutomatica.Text.Trim().Length == 0)
            {
                MessageBox.Show("Informe o destinatário para envio das notificações de configuração automática de pedidos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectTab(getTabPai(chkDestinatarioConfiguracaoAutomatica));
                txtDestinatarioConfiguracaoAutomatica.Focus();
                return false;
            }



            return true;
      }

       private void carregarSemana()
       {
           switch (IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO))
           {
               case "0":
                   rdbSemanaPrimeiroDia.Checked = true;
                   break;
               case "1":
                   rdSemanaInteira.Checked = true;
                   break;
               case "2":
                   rdbSemanaQuatroDias.Checked = true;
                   break;
               default:
                   rdbSemanaPrimeiroDia.Checked = true;
                   break;
           }

           this.cmbSemanaDia.SelectedItem = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA);

           this.chkUtilizarEstoqueOP.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.UTILIZA_ESTOQUE_OP)));
           this.chkQtdFracionariaOP.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.PERMITIR_QTD_FRACIONARIA_OP)));


           this.chkAvisoItensSemPedido.Checked = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.AVISO_PEDIDO_ITEM_SEM_FATURAMENTO)));
           int tmp;
           this.nudAvisoItensSemPedido.Value = int.TryParse(IWTConfiguration.Conf.getConf(Constants.AVISO_PEDIDO_ITEM_SEM_FATURAMENTO_DIAS), out tmp) ? tmp : 0;
       }

       private string salvarSemana()
       {
           string err = "";
           if (rdbSemanaPrimeiroDia.Checked)
           {
               err += IWTConfiguration.Conf.SetConf(Constants.SEMANA_TIPO_DEFINICAO, "0", LoginClass.UsuarioLogado.loggedUser.Login);
           }

           if (rdSemanaInteira.Checked)
           {
               err += IWTConfiguration.Conf.SetConf(Constants.SEMANA_TIPO_DEFINICAO, "1", LoginClass.UsuarioLogado.loggedUser.Login);
           }

           if (rdbSemanaQuatroDias.Checked)
           {
               err += IWTConfiguration.Conf.SetConf(Constants.SEMANA_TIPO_DEFINICAO, "2", LoginClass.UsuarioLogado.loggedUser.Login);
           }

           err += IWTConfiguration.Conf.SetConf(Constants.SEMANA_DIA, this.cmbSemanaDia.SelectedItem.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

           err += IWTConfiguration.Conf.SetConf(Constants.UTILIZA_ESTOQUE_OP, Convert.ToInt16(this.chkUtilizarEstoqueOP.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.PERMITIR_QTD_FRACIONARIA_OP, Convert.ToInt16(this.chkQtdFracionariaOP.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

           err += IWTConfiguration.Conf.SetConf(Constants.AVISO_PEDIDO_ITEM_SEM_FATURAMENTO, Convert.ToInt16(this.chkAvisoItensSemPedido.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.AVISO_PEDIDO_ITEM_SEM_FATURAMENTO_DIAS, nudAvisoItensSemPedido.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

           return err;
       }

       private bool validaConfSemana()
      {
          if (cmbSemanaDia.SelectedItem == null)
          {
              MessageBox.Show("Informe o dia da semana.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              tabControl1.SelectTab(getTabPai(cmbSemanaDia));
              this.cmbSemanaDia.Focus();
              return false;
          }
          return true;
      }

      private void carregarQualidade()
      {
          this.nudDiasArmazenagemOP.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.PRAZO_ARMAZENAMENTO_OP));
      }

      private string salvarQualidade()
      {
          string err = "";
          err += IWTConfiguration.Conf.SetConf(Constants.PRAZO_ARMAZENAMENTO_OP, this.nudDiasArmazenagemOP.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          return err;
      }


      private void carregarEstoque()
      {
          this.nudEstoqueMeses.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
          this.nudEstoqueDiasVerde.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
          this.nudEstoqueDiasAmarelo.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
          this.nudEstoqueDiasVermelho.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));
          this.nudEstoqueMargemRevisaoKb.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB));
          this.nudEstoqueClassificacaoA.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_A));
          this.nudEstoqueClassificacaoB.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_B));

          this.rdbTipoFormMovA5.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_FORMULARIO_MOVIMENTACAO) == "0";
          this.rdbTipoFormMovEtqM.Checked = IWTConfiguration.Conf.getConf(Constants.TIPO_FORMULARIO_MOVIMENTACAO) == "1";

          this.chkEstoqueInventarioPrecoMedio.Checked = IWTConfiguration.Conf.getBoolConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO);
          if (this.chkEstoqueInventarioPrecoMedio.Checked)
          {
              this.nudEstoqueInventarioPrecoMedioMeses.Value = decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO_MESES));
          }

          this.chkEstoquePermitirCriacaoLocalEstoque.Checked = IWTConfiguration.Conf.getBoolConf(Constants.ESTOQUE_PERMITIR_CRIAR_LOCAL_ESTOQUE);

      }

      private string salvarEstoque()
      {
          string err = "";
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_N_MESES_MEDIA, this.nudEstoqueMeses.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_DIAS_VERDE, this.nudEstoqueDiasVerde.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_DIAS_AMARELO, this.nudEstoqueDiasAmarelo.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_DIAS_VERMELHO, this.nudEstoqueDiasVermelho.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_MARGEM_REVISAO_KB, this.nudEstoqueMargemRevisaoKb.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_CLASSIFICACAO_A, this.nudEstoqueClassificacaoA.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_CLASSIFICACAO_B, this.nudEstoqueClassificacaoB.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_CLASSIFICACAO_B, this.nudEstoqueClassificacaoB.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          string tipoFormularioMovimentacao = "0";
          if (this.rdbTipoFormMovA5.Checked)
          {
              tipoFormularioMovimentacao = "0";
          }

          if (this.rdbTipoFormMovEtqM.Checked)
          {
              tipoFormularioMovimentacao = "1";
          }

          err += IWTConfiguration.Conf.SetConf(Constants.TIPO_FORMULARIO_MOVIMENTACAO, tipoFormularioMovimentacao, LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO, Convert.ToInt16(this.chkEstoqueInventarioPrecoMedio.Checked).ToString(CultureInfo.InvariantCulture), LoginClass.UsuarioLogado.loggedUser.Login);
          if (this.chkEstoqueInventarioPrecoMedio.Checked)
          {
              err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO_MESES, this.nudEstoqueInventarioPrecoMedioMeses.Value.ToString(CultureInfo.InvariantCulture), LoginClass.UsuarioLogado.loggedUser.Login);
          }

          err += IWTConfiguration.Conf.SetConf(Constants.ESTOQUE_PERMITIR_CRIAR_LOCAL_ESTOQUE, Convert.ToInt16(this.chkEstoquePermitirCriacaoLocalEstoque.Checked).ToString(CultureInfo.InvariantCulture), LoginClass.UsuarioLogado.loggedUser.Login);
          return err;
      }


      private void carregarCompras()
      {
          this.nudComprasDiasPCP.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_PCP));
          this.nudComprasDias.Value = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_COMPRAS));
          this.nudComprasDisparoSolicitacaoCompra.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.DISPARO_SOLICACAO_COMPRAS));
          this.nudComprasSugeridoAcimaConfigurado.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.SUGESTAO_ACIMA_CONFIGURADO));

          this.txtComprasRodape.Text = IWTConfiguration.Conf.getConf(Constants.COMPRAS_RODAPE);
          this.txtComprasEmailTexto.Text = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_MENSAGEM);

          this.nudMargemRecebimento.Value =
              Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS));

          chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.Checked = IWTConfiguration.Conf.getBoolConf(Constants.MARCAR_AUTOMATICAMENTE_OC_COM_DESCONTO_PARA_NAO_ATUALIZAR_PRECO_PRODUTOS);
          chkComprasPermitirPrazoSabado.Checked = IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_SABADO);
          chkComprasPermitirPrazoDomingo.Checked = IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_PERMITIR_SC_DOMINGO);
          chkComprasFluxoAprovacao.Checked = IWTConfiguration.Conf.getBoolConf(Constants.FLUXO_APROVACAO_COMPRAS_HABILITADO) && IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO);
          chkComprasFluxoAprovacao.Enabled = IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO);
          chkComprasContasRevisarPadraoFornecedores.Checked = IWTConfiguration.Conf.getBoolConf(Constants.COMPRA_REVISAR_NOVOS_FORNEC);
        }

      private string salvarCompras()
      {
          string err = "";
          err += IWTConfiguration.Conf.SetConf(Constants.DIAS_PROGRAMACAO_PCP, this.nudComprasDiasPCP.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.DIAS_PROGRAMACAO_COMPRAS, this.nudComprasDias.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.DISPARO_SOLICACAO_COMPRAS, this.nudComprasDisparoSolicitacaoCompra.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.SUGESTAO_ACIMA_CONFIGURADO, this.nudComprasSugeridoAcimaConfigurado.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.COMPRAS_RODAPE, this.txtComprasRodape.Text, LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.COMPRAS_EMAIL_MENSAGEM, this.txtComprasEmailTexto.Text, LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS, this.nudMargemRecebimento.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.COMPRA_PERMITIR_SC_SABADO, Convert.ToInt16(chkComprasPermitirPrazoSabado.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.COMPRA_PERMITIR_SC_DOMINGO, Convert.ToInt16(chkComprasPermitirPrazoDomingo.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.MARCAR_AUTOMATICAMENTE_OC_COM_DESCONTO_PARA_NAO_ATUALIZAR_PRECO_PRODUTOS, Convert.ToInt16(chkMarcarAutomaticamenteOcComDescontoParaNaoAtualizarPrecoProduto.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.COMPRA_REVISAR_NOVOS_FORNEC, Convert.ToInt16(chkComprasContasRevisarPadraoFornecedores.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.FLUXO_APROVACAO_COMPRAS_HABILITADO, Convert.ToInt16(chkComprasFluxoAprovacao.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          return err;
      }


      private void carregarNFeEntrada()
      {
          this.txtEntradaNFeEntrada.Text = IWTConfiguration.Conf.getConf(Constants.NFE_COMPRA_ENTRADA);
          this.txtSaidaNFeEntrada.Text = IWTConfiguration.Conf.getConf(Constants.NFE_COMPRA_SAIDA);
      }
      private string salvarNFeEntrada()
      {
          string err = "";
          err += IWTConfiguration.Conf.SetConf(Constants.NFE_COMPRA_ENTRADA, this.txtEntradaNFeEntrada.Text, LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.NFE_COMPRA_SAIDA, this.txtSaidaNFeEntrada.Text, LoginClass.UsuarioLogado.loggedUser.Login);
          return err;
      }

      private void btnEntradaNFeEntrada_Click(object sender, EventArgs e)
      {
          if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
          {
              txtEntradaNFeEntrada.Text = folderBrowserDialog1.SelectedPath;
          }
      }

      private void btnSaidaNFeEntrada_Click(object sender, EventArgs e)
      {
          if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
          {
              txtSaidaNFeEntrada.Text = folderBrowserDialog1.SelectedPath;
          }
      }

      private void carregarDocumentos()
      {
          this.nudDocumentosQtdMaximaCopias.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.DOCUMENTOS_QTD_MAXIMA_COPIAS));
         
      }
      private string salvarDocumentos()
      {
          string err = "";
          err += IWTConfiguration.Conf.SetConf(Constants.DOCUMENTOS_QTD_MAXIMA_COPIAS, this.nudDocumentosQtdMaximaCopias.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          return err;
      }

      private void btnLogo_Click(object sender, EventArgs e)
      {
          try
          {
              if (this.ofdLogo.ShowDialog() == DialogResult.OK)
              {
                  this.pcbLogo.Image = Image.FromFile(this.ofdLogo.FileName);
                  this.pcbLogo.ImageLocation = this.ofdLogo.FileName;

              }
          }
          catch (Exception a)
          {
              MessageBox.Show(this, "Erro ao selecionar a imagem.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
      }

      private void carregarLogo()
      {
          byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);
          if (tmp != null)
          {
               MemoryStream ms = new MemoryStream(tmp);
               this.pcbLogo.Image = Image.FromStream(ms);
          }

      }
      private string salvarLogo()
      {
          string err = "";

          if (this.pcbLogo.Image != null)
          {
              MemoryStream ms = new MemoryStream();
              this.pcbLogo.Image.Save(ms, ImageFormat.Jpeg);
              err = IWTConfiguration.Conf.setConf(Constants.LOGO_EMPRESA, ms.ToArray(), LoginClass.UsuarioLogado.loggedUser.Login);
          }
          return err;
      }

      private void rdbEtiquetaGrande_CheckedChanged(object sender, EventArgs e)
      {
          if (this.rdbEtiquetaGrande.Checked)
          {
              this.grbEtiquetaExpedicao.Text = "Etiqueta Expedição (10,8 cm x 18,9 cm)";
          }
          else
          {
              this.grbEtiquetaExpedicao.Text = "Etiqueta Expedição (8,5 cm x 5 cm)";
          }
      }

      private void rdbEtiquetaMedia_CheckedChanged(object sender, EventArgs e)
      {
          if (this.rdbEtiquetaGrande.Checked)
          {
              this.grbEtiquetaExpedicao.Text = "Etiqueta Expedição (10,8 cm x 18,9 cm)";
          }
          else
          {
              this.grbEtiquetaExpedicao.Text = "Etiqueta Expedição (8,5 cm x 5 cm)";
          }
      }

      private void chkExportacaoPedidos_CheckedChanged(object sender, EventArgs e)
      {
          this.grbExportacaoPedidos.Enabled = this.chkExportacaoPedidos.Checked;
      }

      private void chkExportacaoContas_CheckedChanged(object sender, EventArgs e)
      {
          this.grbExportacaoContas.Enabled = this.chkExportacaoContas.Checked;
      }

      private void chkEnvioPedidoDestInterno_CheckedChanged(object sender, EventArgs e)
      {
          grpDestInternoPedido.Enabled = chkEnvioPedidoDestInterno.Checked;
      }

      private void chkEnvioOrcamentoDestInterno_CheckedChanged(object sender, EventArgs e)
      {
          grpDestInternoOrcamento.Enabled = chkEnvioOrcamentoDestInterno.Checked;
      }


      private void carregarExportacoes()
      {
          
          this.txtDiretorioExportacaoCSV.Text = IWTConfiguration.Conf.getConf(Constants.DIRETORIO_EXPORTACAO_CSV);
          
          this.chkExportacaoPedidos.Checked = IWTConfiguration.Conf.getBoolConf(Constants.EXPORTACAO_PEDIDOS_ATIVA);
          this.nudExportacaoPedidosIntervalo.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.EXPORTACAO_PEDIDOS_INTERVALO));

          this.chkExportacaoContas.Checked = IWTConfiguration.Conf.getBoolConf(Constants.EXPORTACAO_CONTAS_ATIVA);
          this.nudExportacaoContasMinuto.Value = Convert.ToDecimal(IWTConfiguration.Conf.getConf(Constants.EXPORTACAO_CONTAS_INTERVALO));

          this.txtDiretorioLogEasi.Text = IWTConfiguration.Conf.getConf(Constants.LOG_EASI);


      }
      private string salvarExportacoes()
      {
          string err = "";


          err += IWTConfiguration.Conf.SetConf(Constants.DIRETORIO_EXPORTACAO_CSV, this.txtDiretorioExportacaoCSV.Text, LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.EXPORTACAO_PEDIDOS_ATIVA, Convert.ToInt16(this.chkExportacaoPedidos.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
     
          err += IWTConfiguration.Conf.SetConf(Constants.EXPORTACAO_PEDIDOS_INTERVALO, this.nudExportacaoPedidosIntervalo.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);


          err += IWTConfiguration.Conf.SetConf(Constants.EXPORTACAO_CONTAS_ATIVA, Convert.ToInt16(this.chkExportacaoContas.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
          err += IWTConfiguration.Conf.SetConf(Constants.EXPORTACAO_CONTAS_INTERVALO, this.nudExportacaoContasMinuto.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

          err += IWTConfiguration.Conf.SetConf(Constants.LOG_EASI, this.txtDiretorioLogEasi.Text, LoginClass.UsuarioLogado.loggedUser.Login);
          
          return err;
      }

      private void btnCentroCusto_Click(object sender, EventArgs e)
      {
          try
          {
              this.selecionarCentroCusto();
          }
          catch (Exception a)
          {
              MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
      }


      private void selecionarCentroCusto()
      {
          try
          {
              SelecaoCentroCustoLucroForm form = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Custo);
              form.ShowDialog();

              if (form.CentroSelecionado != null)
              {
                  this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                  this.centroCusto = form.CentroSelecionado;
                  txtCentroCusto.Text = this.centroCusto.ToString();
              }

          }
          catch (Exception e)
          {
              throw new Exception("Erro ao selecionar o centro de custo padrão\r\n" + e.Message, e);
          }
      }

      private void carregarVendas()
      {
          string idCentroCusto = IWTConfiguration.Conf.getConf(Constants.CENTRO_CUSTO_PADRAO_COMISSOES);
          string idContaBancaria = IWTConfiguration.Conf.getConf(Constants.CONTA_BANCARIA_PADRAO_COMISSOES);
          bool enviarEmail = Convert.ToBoolean(Convert.ToInt16(IWTConfiguration.Conf.getConf(Constants.ENVIAR_EMAIL_COPIA_RELATORIO_COMISSOES)));
          string emailRelatorioComissoes = IWTConfiguration.Conf.getConf(Constants.DESTINATARIO_EMAIL_COPIA_RELATORIO_COMISSOES);
          if (!string.IsNullOrWhiteSpace(idCentroCusto))
          {
              centroCusto = CentroCustoLucroBaseClass.GetEntidade(int.Parse(idCentroCusto), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
              if (centroCusto != null)
              {
                  txtCentroCusto.Text = centroCusto.ToString();
              }
          }

          if (!string.IsNullOrWhiteSpace(idContaBancaria))
          {
              this.cmbContaBancaria.SelectedValue = long.Parse(idContaBancaria);
          }

          chkEnviarEmailRelComissoes.Checked = enviarEmail;
          this.txtEmailRelComissoes.Enabled = enviarEmail;

          if (!string.IsNullOrWhiteSpace(emailRelatorioComissoes))
          {
              this.txtEmailRelComissoes.Text = emailRelatorioComissoes;
          }


      }

     private string salvarVendas()
     {
         string err = "";

         err += IWTConfiguration.Conf.SetConf(Constants.CENTRO_CUSTO_PADRAO_COMISSOES, centroCusto.ID.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
         err += IWTConfiguration.Conf.SetConf(Constants.CONTA_BANCARIA_PADRAO_COMISSOES, cmbContaBancaria.SelectedValue.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
         err += IWTConfiguration.Conf.SetConf(Constants.ENVIAR_EMAIL_COPIA_RELATORIO_COMISSOES, Convert.ToString(Convert.ToInt32(chkEnviarEmailRelComissoes.Checked)), LoginClass.UsuarioLogado.loggedUser.Login);
         err += IWTConfiguration.Conf.SetConf(Constants.DESTINATARIO_EMAIL_COPIA_RELATORIO_COMISSOES, txtEmailRelComissoes.Text, LoginClass.UsuarioLogado.loggedUser.Login);

         return err;
     }

     private TabPage getTabPai(Control controle)
     {
         if (controle.Parent == null)
         {
             return null;
         }

         var page = controle.Parent as TabPage;
         if (page != null)
         {
             return page;
         }
         else
         {
             return getTabPai(controle.Parent);
         }
     }


       private bool validConfVendas()
     {
         if (this.centroCusto == null)
         {
             MessageBox.Show("Informe o centro de custo padrão para comissões.", "Alerta", MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);
             tabControl1.SelectTab(11);
             txtCentroCusto.Focus();
             return false;
         }

         if (this.cmbContaBancaria.SelectedValue == null)
         {
             MessageBox.Show("Informe a conta bancária padrão para comissões.", "Alerta", MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);
             tabControl1.SelectTab(getTabPai(cmbContaBancaria));
             cmbContaBancaria.Focus();
             return false;
         }

         if (this.chkEnviarEmailRelComissoes.Checked && this.txtEmailRelComissoes.Text == "")
         {
             MessageBox.Show("Informe o destinatário de envio de cópia por email do relatório de comissões ou desmarque o campo.", "Alerta", MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);
             tabControl1.SelectTab(getTabPai(chkEnviarEmailRelComissoes));
             cmbContaBancaria.Focus();
             return false;
         }
         return true;
     }

       private void loadComboContaBancaria()
      {
          try
          {
              ContaBancariaClass contaBancaria = new ContaBancariaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
              List<ContaBancariaClass> contasBancarias =
                  contaBancaria.Search(new List<SearchParameterClass>() { new SearchParameterClass("cba_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (ContaBancariaClass)a);


              this.cmbContaBancaria.DataSource = contasBancarias;
              this.cmbContaBancaria.DisplayMember = "Identificacao";
              this.cmbContaBancaria.ValueMember = "ID";
              this.cmbContaBancaria.autoSize = true;
              this.cmbContaBancaria.Table = contasBancarias;
              this.cmbContaBancaria.ColumnsToDisplay = new[] { "Identificacao", "NomeBanco", "Agencia", "NumeroConta", "CodigoBanco" };
              this.cmbContaBancaria.HeadersToDisplay = new[] { "Identificação", "Banco", "Agência", "Conta", "Código Banco" };

          }
          catch (Exception e)
          {
              throw new Exception("Erro ao carregar os dados para seleção da Conta Bancária.\r\n" + e.Message);
          }
      }

       private void cbxAvisoConciliacao_CheckedChanged(object sender, EventArgs e)
       {
           this.nudDiasAvisoConc.Enabled = this.cbxAvisoConciliacao.Checked;
       }

       private void carregarFinanceiro()
       {
           this.cbxAvisoConciliacao.Checked = IWTConfiguration.Conf.getBoolConf(Constants.AVISO_CONCILIACAO_HABILITADO);
           this.nudDiasAvisoConc.Value = decimal.Parse("0"+IWTConfiguration.Conf.getConf(Constants.DIAS_AVISO_CONCILIACAO));


           this.chkAvisoContaRecorrente.Checked = IWTConfiguration.Conf.getBoolConf(Constants.AVISO_CONTA_RECORRENTE_HABILITADA);
           this.nudDiasAvisoContaRecorrente.Value = decimal.Parse(IWTConfiguration.Conf.getConf(Constants.DIAS_AVISO_CONTA_RECORRENTE));

       }

       private string salvarFinanceiro()
       {
           string err = "";

           err += IWTConfiguration.Conf.SetConf(Constants.AVISO_CONCILIACAO_HABILITADO, Convert.ToInt16(this.cbxAvisoConciliacao.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.DIAS_AVISO_CONCILIACAO, this.nudDiasAvisoConc.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

           err += IWTConfiguration.Conf.SetConf(Constants.AVISO_CONTA_RECORRENTE_HABILITADA, Convert.ToInt16(this.chkAvisoContaRecorrente.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.DIAS_AVISO_CONTA_RECORRENTE, this.nudDiasAvisoContaRecorrente.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);


           return err;
       }

       private void carregarOP()
       {
           this.chkSuprimirOrdensZeradasKb.Checked = IWTConfiguration.Conf.getBoolConf(Constants.SUPRIMIR_IMPRESSAO_OP_KB_ZERADA);
           this.nudMesesCustoHora.Value = decimal.Parse(IWTConfiguration.Conf.getConf(Constants.MESES_CALCULO_CUSTO_HORA));
           this.nudPorcentagemProducaoAcima.Value = decimal.Parse(IWTConfiguration.Conf.getConf(Constants.PERCENTUAL_GERACAO_OP_KB_ACIMA_ESTOQUE_VERDE));
           if (IWTConfiguration.Conf.getConf(Constants.PERMITIR_SELECAO_IMPRESSORA_EXP) != null)
           {
               this.chkPermitirSelecaoImpressoraExp.Checked = IWTConfiguration.Conf.getBoolConf(Constants.PERMITIR_SELECAO_IMPRESSORA_EXP);

           }
           this.chkSuprimirQtdUnitariaMaterialOP.Checked = IWTConfiguration.Conf.getBoolConf(Constants.SUPRIMIR_IMPRESSAO_QTD_UNITARIA_OP);
           this.chkExigirDocumentosOpZerada.Checked = IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_COPIA_DOC_OP_ZERADA);



       }

       private string salvarOP()
       {
           string err = "";

           err += IWTConfiguration.Conf.SetConf(Constants.SUPRIMIR_IMPRESSAO_OP_KB_ZERADA, Convert.ToInt16(this.chkSuprimirOrdensZeradasKb.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.MESES_CALCULO_CUSTO_HORA, this.nudMesesCustoHora.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.PERCENTUAL_GERACAO_OP_KB_ACIMA_ESTOQUE_VERDE, this.nudPorcentagemProducaoAcima.Value.ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.PERMITIR_SELECAO_IMPRESSORA_EXP, Convert.ToInt16(this.chkPermitirSelecaoImpressoraExp.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

           err += IWTConfiguration.Conf.SetConf(Constants.SUPRIMIR_IMPRESSAO_QTD_UNITARIA_OP, Convert.ToInt16(this.chkSuprimirQtdUnitariaMaterialOP.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.EXIGIR_COPIA_DOC_OP_ZERADA,Convert.ToInt16(this.chkExigirDocumentosOpZerada.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
            return err;
       }


       private string salvarPedidoOrcamento()
       {
           string err = "";

           string tipoImpressao = "0";
           if (this.rdImprimirTodos.Checked)
           {
               tipoImpressao = "0";
           }
           if (this.rdSomenteSbZero.Checked)
           {
               tipoImpressao = "1";
           }
           //if (this.rdSomenteNaoSubZero.Checked)
           //{
           //    tipoImpressao = "2";
           //}

           err += IWTConfiguration.Conf.SetConf(Constants.TIPO_IMPRESSAO_ESPELHO_PEDIDO, tipoImpressao, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.OBSERVACAO_PADRAO_ESPELHO_PEDIDO_ORCAMENTO, txtObsPadraoEspelho.Text, LoginClass.UsuarioLogado.loggedUser.Login);
           err +=IWTConfiguration.Conf.SetConf(Constants.NF_PERMITIR_FATURAR_PEDIDO, Convert.ToInt16(this.chkPermitirFaturarPedido.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

           string tipoInclusaoPedidoNf = "1";
           if (this.rdbNumeroPedidoNaoIncluir.Checked)
           {
               tipoInclusaoPedidoNf = "0";

           }

           if (this.rdbNumeroPedidoDescricaoItem.Checked)
           {
               tipoInclusaoPedidoNf = "1";

           }

           if (this.rdbNumeroPedidoObservacao.Checked)
           {
               tipoInclusaoPedidoNf = "2";

           }

           err += IWTConfiguration.Conf.SetConf(Constants.NF_INCLUIR_NUMERO_PEDIDO_NF, tipoInclusaoPedidoNf, LoginClass.UsuarioLogado.loggedUser.Login);
           err += IWTConfiguration.Conf.SetConf(Constants.VALIDAR_PESO_VOLUMES_NFE, Convert.ToInt16(this.chkPesoVolumeNFe.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);

           err += IWTConfiguration.Conf.SetConf(Constants.HISTORICO_ALTERACOES_PEDIDO, Convert.ToInt16(this.chkRegistrarAlteracoesPedido.Checked).ToString(), LoginClass.UsuarioLogado.loggedUser.Login);
           return err;
       }

       private void chkAvisoContaRecorrente_CheckedChanged(object sender, EventArgs e)
       {
           this.nudDiasAvisoContaRecorrente.Enabled = this.chkAvisoContaRecorrente.Checked;
       }

       private void chkEnviarEmailRelComissoes_CheckedChanged(object sender, EventArgs e)
       {
           txtEmailRelComissoes.Enabled = chkEnviarEmailRelComissoes.Checked;
       }

       private void btnLogEasi_Click(object sender, EventArgs e)
       {
           if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
           {
               txtDiretorioLogEasi.Text = folderBrowserDialog1.SelectedPath;
           }
       }

       private void chkEstoqueInventarioPrecoMedio_CheckedChanged(object sender, EventArgs e)
       {
           this.nudEstoqueInventarioPrecoMedioMeses.Enabled = chkEstoqueInventarioPrecoMedio.Checked;
       }

       private void rdbEtiquetaClienteZebra_CheckedChanged(object sender, EventArgs e)
       {
           this.grbEtiquetaClienteComum.Enabled = rdbEtiquetaClienteComum.Checked;
           this.grbEtiquetaClienteZebra.Enabled = rdbEtiquetaClienteZebra.Checked;
       }

       private void rdbEtiquetaClienteComum_CheckedChanged(object sender, EventArgs e)
       {
           this.grbEtiquetaClienteComum.Enabled = rdbEtiquetaClienteComum.Checked;
           this.grbEtiquetaClienteZebra.Enabled = rdbEtiquetaClienteZebra.Checked;
       }



      
       private void ValidaFormatoEtiquetaCliente()
       {
           float paginaAltura = (float)nudPapelAltura.Value;
           float paginaLargura = (float)nudPapelLargura.Value;
           float paginaMargemEsquerda = (float)nudPapelMargemEsquerda.Value;
           float paginaMargemDireita = (float)nudPapelMargemDireita.Value;
           float paginaMargemSuperior = (float)nudPapelMargemSuperior.Value;
           float paginaMargemInferior = (float)nudPapelMargemInferior.Value;


           float etiquetaAltura = (float)nudEtiquetaAltura.Value;
           float etiquetaLargura = (float)nudEtiquetaLargura.Value;
           float etiquetaIntevaloVertical = (float)nudEtiquetaIntervaloVertical.Value;
           float etiquetaIntervaloHorizontal = (float)nudEtiquetaIntervaloHorizontal.Value;
           int etiquetaColunas = (int)nudEtiquetaColunas.Value;
           int etiquetaLinhas = (int)nudEtiquetaLinhas.Value;


           float larguraMinimaPagina = (etiquetaLargura * etiquetaColunas) + (paginaMargemEsquerda + paginaMargemDireita) + (etiquetaIntervaloHorizontal * (etiquetaColunas - 1));
           if (larguraMinimaPagina > paginaLargura)
           {
               throw new ExcecaoTratada("A largura minima da página para os parâmetros selecionados é de " + larguraMinimaPagina + "mm");
           }

           float alturaMinimaPagina = (etiquetaAltura * etiquetaLinhas) + (paginaMargemSuperior + paginaMargemInferior) + (etiquetaIntevaloVertical * (etiquetaLinhas - 1));
           if (alturaMinimaPagina > paginaAltura)
           {
               throw new ExcecaoTratada("A altura minima da página para os parâmetros selecionados é de " + alturaMinimaPagina + "mm");
           }
       }

       private string SalvarConfiguracoesEtiquetaCliente()
       {
           try
           {
             

               string erro = "";
              


               if (rdbEtiquetaClienteComum.Checked)
               {
                   this.ValidaFormatoEtiquetaCliente();

                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_DPI, this.nudResolucao.Value.ToString(CultureInfo.InvariantCulture),"XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_ALTURA, this.nudPapelAltura.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_LARGURA, this.nudPapelLargura.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_SUP, this.nudPapelMargemSuperior.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_INF, this.nudPapelMargemInferior.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_ESQ, this.nudPapelMargemEsquerda.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_DIR, this.nudPapelMargemDireita.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_ALTURA, this.nudEtiquetaAltura.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LARGURA, this.nudEtiquetaLargura.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_HOR, this.nudEtiquetaIntervaloHorizontal.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_VER, this.nudEtiquetaIntervaloVertical.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS, this.nudEtiquetaColunas.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS, this.nudEtiquetaLinhas.Value.ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);

               }

               if (rdbEtiquetaClienteZebra.Checked)
               {

                   if (this.cmbEtiquetaClienteImpressora.SelectedItem == null)
                   {
                       throw new ExcecaoTratada("Selecione a impressora para etiqueta de cliente");
                   }

                   if (this.cmbEtiquetaClientePapel.SelectedItem == null)
                   {
                       throw new ExcecaoTratada("Selecione o papel para etiqueta de cliente");
                   }

                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_ZEBRA_IMPRESSORA, this.cmbEtiquetaClienteImpressora.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
                   erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_ZEBRA_PAPEL, this.cmbEtiquetaClientePapel.SelectedItem.ToString(), "XML", LoginClass.UsuarioLogado.loggedUser.Login);

               }



               erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_LASER, Convert.ToInt16(rdbEtiquetaClienteComum.Checked).ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);
               erro += IWTConfiguration.Conf.setConf(Constants.ETIQUETA_CLIENTE_ZEBRA, Convert.ToInt16(rdbEtiquetaClienteZebra.Checked).ToString(CultureInfo.InvariantCulture), "XML", LoginClass.UsuarioLogado.loggedUser.Login);

               return erro;


           }
           catch (ExcecaoTratada)
           {
               throw;
           }
           catch (Exception e)
           {
               throw new Exception("Erro inesperado ao salvar as configurações da etiqueta.\r\n" + e.Message, e);
           }
       }

       private void LoadConfiguracoesEtiquetaCliente()
       {
           try
           {
               if (IWTConfiguration.Conf.getBoolConf(Constants.ETIQUETA_CLIENTE_LASER))
               {
                   this.rdbEtiquetaClienteComum.Checked = true;
               }
               else
               {
                   this.rdbEtiquetaClienteZebra.Checked = true;
               }

               this.nudResolucao.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_DPI) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_DPI), CultureInfo.InvariantCulture)
                   : this.nudResolucao.Value;
               this.nudPapelAltura.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_ALTURA) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_ALTURA), CultureInfo.InvariantCulture)
                   : this.nudPapelAltura.Value;
               this.nudPapelLargura.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_LARGURA) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_LARGURA), CultureInfo.InvariantCulture)
                   : this.nudPapelLargura.Value;
               this.nudPapelMargemSuperior.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_SUP) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_SUP), CultureInfo.InvariantCulture)
                   : this.nudPapelMargemSuperior.Value;
               this.nudPapelMargemInferior.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_INF) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_INF), CultureInfo.InvariantCulture)
                   : this.nudPapelMargemInferior.Value;
               this.nudPapelMargemEsquerda.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_ESQ) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_ESQ), CultureInfo.InvariantCulture)
                   : this.nudPapelMargemEsquerda.Value;
               this.nudPapelMargemDireita.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_DIR) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_PAPEL_MARGEM_DIR), CultureInfo.InvariantCulture)
                   : this.nudPapelMargemDireita.Value;
               this.nudEtiquetaAltura.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_ALTURA) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_ALTURA), CultureInfo.InvariantCulture)
                   : this.nudEtiquetaAltura.Value;
               this.nudEtiquetaLargura.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LARGURA) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LARGURA), CultureInfo.InvariantCulture)
                   : this.nudEtiquetaLargura.Value;
               this.nudEtiquetaIntervaloHorizontal.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_HOR) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_HOR), CultureInfo.InvariantCulture)
                   : this.nudEtiquetaIntervaloHorizontal.Value;
               this.nudEtiquetaIntervaloVertical.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_VER) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_INTERVALO_VER), CultureInfo.InvariantCulture)
                   : this.nudEtiquetaIntervaloVertical.Value;
               this.nudEtiquetaColunas.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_COLUNAS), CultureInfo.InvariantCulture)
                   : this.nudEtiquetaColunas.Value;
               this.nudEtiquetaLinhas.Value = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS) != null
                   ? decimal.Parse(IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_LASER_ETIQUETA_LINHAS), CultureInfo.InvariantCulture)
                   : this.nudEtiquetaLinhas.Value;

               this.cmbEtiquetaClienteImpressora.SelectedItem = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_ZEBRA_IMPRESSORA);
               this.cmbEtiquetaClientePapel.SelectedItem = IWTConfiguration.Conf.getConf(Constants.ETIQUETA_CLIENTE_ZEBRA_PAPEL);
           }
           catch (ExcecaoTratada)
           {
               throw;
           }
           catch (Exception e)
           {
               throw new Exception("Erro inesperado ao carregar as configurações da etiqueta\r\n" + e.Message, e);
           }
       }

       private void cmbEtiquetaClienteImpressora_SelectedIndexChanged(object sender, EventArgs e)
       {
           cmbEtiquetaClientePapel.Items.Clear();

           PrintDocument doctoprint = new PrintDocument();
           doctoprint.PrinterSettings.PrinterName = cmbEtiquetaClienteImpressora.SelectedItem.ToString();
           PrinterSettings.PaperSizeCollection paperSizeCollection = doctoprint.PrinterSettings.PaperSizes;

           for (int j = 0; j < paperSizeCollection.Count; j++)
           {
               cmbEtiquetaClientePapel.Items.Add(paperSizeCollection[j].PaperName);
           }

           cmbEtiquetaClientePapel.SelectedItem = null;
       }

        private void chkAvisoItensSemPedido_CheckedChanged(object sender, EventArgs e)
        {
            this.nudAvisoItensSemPedido.Enabled = chkAvisoItensSemPedido.Checked;
        }

        private void chkDestinatarioConfiguracaoAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            grbDestinatarioConfiguracaoAutomatica.Enabled = chkDestinatarioConfiguracaoAutomatica.Checked;
        }

        private void rdbTabelaPrecosAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            nudTabelaPrecosHora.Enabled = !rdbTabelaPrecosAutomatico.Checked;
            nudTabelaPrecosMinutos.Enabled = !rdbTabelaPrecosAutomatico.Checked;
        }


    }
}
