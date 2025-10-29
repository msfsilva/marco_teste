#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaNotasFiscais;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTFunctions;
using IWTNFCompleto;
using ProjectConstants;

#endregion

namespace BibliotecaFinanceiro
{
    public partial class CadEmitenteForm : IWTBaseForm
    {
        private readonly EasiEmissorNFe _tipoEmissor;
        private readonly EmitenteClass _emitente;

        bool loading = true;
        private Dictionary<string, X509Certificate2> certificados;


        private BindingList<DocumentosString> _documentosAutorizados;

        public CadEmitenteForm( EasiEmissorNFe tipoEmissor)
        {
            _tipoEmissor = tipoEmissor;
            

            InitializeComponent();

            PisCofinsInfo PisCofinsDefault;
            NotaFiscalFuncoesAuxiliares.CarregaEmitente(this.SingleConnection, out _emitente, _tipoEmissor, out PisCofinsDefault);

            this.loadCombos();
            this.loadFields();
            this.PISFields();
            this.COFINSFields();

            switch (IWTConfiguration.Conf.getConf(Constants.TIPO_EMISSAO_NFE))
            {
                case "0":
                    this.grbCertificado.Visible = false;

                    this.tabControl1.TabPages.Remove(this.tabPage5);
                    break;

                case "1":
                    this.carregarCertificados();
                    this.CarregarConfiguracoesNFe();
                    this.chkEnvioNFeCliente.Checked = false;
                    this.chkEnvioNFeCliente.Enabled = false;
                    break;


                case "2":
                    this.carregarCertificados();
                    this.CarregarConfiguracoesNFe();

                    this.label16.Visible = false;
                    this.label27.Visible = false;
                    this.txtPathOutNF.Visible = false;
                    this.btnPath.Visible = false;
                    this.txtVersaoEmissor.Visible = false;
                    break;
            }

            this.ensCidade.FormSelecao = new CadCidadeListForm(TipoModulo.Tipo);


            InitializeGridAutorizados();
        }

        private void loadCombos()
        {
            try
            {
                List<LoadClass> loadCST_PIS = new List<LoadClass>();
                loadCST_PIS.Add(new LoadClass("01", "(01)Operação Tributável(BC = valor da operação normal)"));
                loadCST_PIS.Add(new LoadClass("02", "(02)Operação Tributável(BC = valor da operação(alíquota diferenciada))"));
                loadCST_PIS.Add(new LoadClass("03", "(03)Operação Tributável(BC = quantidade vendida x aliquota por unidade de produto)"));
                loadCST_PIS.Add(new LoadClass("04", "(04)Operação Tributável(Tributação monofásica(alíquota zero))"));
                loadCST_PIS.Add(new LoadClass("06", "(06)Operação Tributável(Alíquota zero)"));
                loadCST_PIS.Add(new LoadClass("07", "(07)Operação Isenta da Contribuição"));
                loadCST_PIS.Add(new LoadClass("08", "(08)Operação Sem Incidência da Contribuição"));
                loadCST_PIS.Add(new LoadClass("09", "(09)Operação com Suspensão da Contribuição"));
                loadCST_PIS.Add(new LoadClass("49", "(49)Outras Operações de Saída"));
                loadCST_PIS.Add(new LoadClass("50", "(50)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
                loadCST_PIS.Add(new LoadClass("51", "(51)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno"));
                loadCST_PIS.Add(new LoadClass("52", "(52)Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação"));
                loadCST_PIS.Add(new LoadClass("53", "(53)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
                loadCST_PIS.Add(new LoadClass("54", "(54)Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
                loadCST_PIS.Add(new LoadClass("55", "(55)Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
                loadCST_PIS.Add(new LoadClass("56", "(56)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
                loadCST_PIS.Add(new LoadClass("60", "(60)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
                loadCST_PIS.Add(new LoadClass("61", "(61)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno"));
                loadCST_PIS.Add(new LoadClass("62", "(62)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação"));
                loadCST_PIS.Add(new LoadClass("63", "(63)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
                loadCST_PIS.Add(new LoadClass("64", "(64)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
                loadCST_PIS.Add(new LoadClass("65", "(65)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
                loadCST_PIS.Add(new LoadClass("66", "(66)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
                loadCST_PIS.Add(new LoadClass("67", "(67)Crédito Presumido - Outras Operações"));
                loadCST_PIS.Add(new LoadClass("70", "(70)Operação de Aquisição sem Direito a Crédito"));
                loadCST_PIS.Add(new LoadClass("71", "(71)Operação de Aquisição com Isenção"));
                loadCST_PIS.Add(new LoadClass("72", "(72)Operação de Aquisição com Suspensão"));
                loadCST_PIS.Add(new LoadClass("73", "(73)Operação de Aquisição a Alíquota Zero"));
                loadCST_PIS.Add(new LoadClass("74", "(74)Operação de Aquisição; sem Incidência da Contribuição"));
                loadCST_PIS.Add(new LoadClass("75", "(75)Operação de Aquisição por Substituição Tributária"));
                loadCST_PIS.Add(new LoadClass("98", "(98)Outras Operações de Entrada"));
                loadCST_PIS.Add(new LoadClass("99", "(99)Outras Operações"));

                cmbCSTPis.ValueMember = "id";
                cmbCSTPis.DisplayMember = "descricao";
                cmbCSTPis.DataSource = loadCST_PIS;

                List<LoadClass> loadCST_COFINS = new List<LoadClass>();
                loadCST_COFINS.Add(new LoadClass("01", "(01)Operação Tributável(BC = valor da operação normal)"));
                loadCST_COFINS.Add(new LoadClass("02", "(02)Operação Tributável(BC = valor da operação(alíquota diferenciada))"));
                loadCST_COFINS.Add(new LoadClass("03", "(03)Operação Tributável(BC = quantidade vendida x aliquota por unidade de produto)"));
                loadCST_COFINS.Add(new LoadClass("04", "(04)Operação Tributável(Tributação monofásica(alíquota zero))"));
                loadCST_COFINS.Add(new LoadClass("06", "(06)Operação Tributável(Alíquota zero)"));
                loadCST_COFINS.Add(new LoadClass("07", "(07)Operação Isenta da Contribuição"));
                loadCST_COFINS.Add(new LoadClass("08", "(08)Operação Sem Incidência da Contribuição"));
                loadCST_COFINS.Add(new LoadClass("09", "(09)Operação com Suspensão da Contribuição"));
                loadCST_COFINS.Add(new LoadClass("49", "(49)Outras Operações de Saída"));
                loadCST_COFINS.Add(new LoadClass("50", "(50)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
                loadCST_COFINS.Add(new LoadClass("51", "(51)Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Não Tributada no Mercado Interno"));
                loadCST_COFINS.Add(new LoadClass("52", "(52)Operação com Direito a Crédito – Vinculada Exclusivamente a Receita de Exportação"));
                loadCST_COFINS.Add(new LoadClass("53", "(53)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
                loadCST_COFINS.Add(new LoadClass("54", "(54)Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
                loadCST_COFINS.Add(new LoadClass("55", "(55)Operação com Direito a Crédito - Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
                loadCST_COFINS.Add(new LoadClass("56", "(56)Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
                loadCST_COFINS.Add(new LoadClass("60", "(60)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
                loadCST_COFINS.Add(new LoadClass("61", "(61)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno"));
                loadCST_COFINS.Add(new LoadClass("62", "(62)Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação"));
                loadCST_COFINS.Add(new LoadClass("63", "(63)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
                loadCST_COFINS.Add(new LoadClass("64", "(64)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
                loadCST_COFINS.Add(new LoadClass("65", "(65)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
                loadCST_COFINS.Add(new LoadClass("66", "(66)Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno, e de Exportação"));
                loadCST_COFINS.Add(new LoadClass("67", "(67)Crédito Presumido - Outras Operações"));
                loadCST_COFINS.Add(new LoadClass("70", "(70)Operação de Aquisição sem Direito a Crédito"));
                loadCST_COFINS.Add(new LoadClass("71", "(71)Operação de Aquisição com Isenção"));
                loadCST_COFINS.Add(new LoadClass("72", "(72)Operação de Aquisição com Suspensão"));
                loadCST_COFINS.Add(new LoadClass("73", "(73)Operação de Aquisição a Alíquota Zero"));
                loadCST_COFINS.Add(new LoadClass("74", "(74)Operação de Aquisição; sem Incidência da Contribuição"));
                loadCST_COFINS.Add(new LoadClass("75", "(75)Operação de Aquisição por Substituição Tributária"));
                loadCST_COFINS.Add(new LoadClass("98", "(98)Outras Operações de Entrada"));
                loadCST_COFINS.Add(new LoadClass("99", "(99)Outras Operações"));

                cmbCSTCofins.ValueMember = "id";
                cmbCSTCofins.DisplayMember = "descricao";
                cmbCSTCofins.DataSource = loadCST_COFINS;

                List<LoadClass> loadModTributPis = new List<LoadClass>();
                loadModTributPis.Add(new LoadClass("0", "Valor"));
                loadModTributPis.Add(new LoadClass("1", "Quantidade"));
                loadModTributPis.Add(new LoadClass("2", "Não tributado"));

                cmbModTributPis.ValueMember = "id";
                cmbModTributPis.DisplayMember = "descricao";
                cmbModTributPis.DataSource = loadModTributPis;

                List<LoadClass> loadModDTributCofins = new List<LoadClass>();
                loadModDTributCofins.Add(new LoadClass("0", "Valor"));
                loadModDTributCofins.Add(new LoadClass("1", "Quantidade"));
                loadModDTributCofins.Add(new LoadClass("2", "Não tributado"));

                cmbModTributCofins.ValueMember = "id";
                cmbModTributCofins.DisplayMember = "descricao";
                cmbModTributCofins.DataSource = loadModDTributCofins;

                this.loading = false;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar os dados para seleção do estado.\r\n" + e.Message);
            }
        }



        private void loadFields()
        {


            txtEmpresa.Text = this._emitente.RazaoSocial;
            txtCNPJ.Text = this._emitente.Cnpj;
            txtIE.Text = this._emitente.InscricaoEstadual;
            txtEndereco.Text = this._emitente.Endereco;
            txtNumero.Text = this._emitente.Numero;
            txtComplento.Text = this._emitente.Complemento;
            txtCep.Text = this._emitente.Cep;
            txtBairro.Text = this._emitente.Bairro;

            ensCidade.EntidadeSelecionada = this._emitente.CidadeEntidade;

            txtTelefone.Text = this._emitente.Telefone;
            txtFax.Text = this._emitente.Fax;
            txtNomeContato.Text = this._emitente.Contato;


            txtPathOutNF.Text = this._emitente.PastaSaidaNFe;

            cmbCSTPis.SelectedValue = this._emitente.PisCst??"";
            nudAliquotaPis.Value = Convert.ToDecimal(this._emitente.PisAliquota);
            cmbModTributPis.SelectedValue = this._emitente.PisModalidade.ToString(CultureInfo.InvariantCulture);
            cbxImpRetidoPis.Checked = this._emitente.PisImpostoRetido;
            cmbCSTCofins.SelectedValue = this._emitente.CofinsCst ?? "";
            nudAliquotaCofins.Value = Convert.ToDecimal(this._emitente.CofinsAliquota);
            cmbModTributCofins.SelectedValue = this._emitente.CofinsModalidade.ToString(CultureInfo.InvariantCulture) ?? "";
            cbxImpRetidoCofins.Checked = this._emitente.CofinsImpostoRetido;

            switch (this._emitente.Crt)
            {
                case CRTTipo.Simples:
                    this.rdbSimples.Checked = true;
                    break;
                case CRTTipo.SimplesExcesso:
                    this.rdbSimplesExcesso.Checked = true;
                    break;
                case CRTTipo.Normal:
                default:
                    this.rdbNormal.Checked = true;
                    break;
            }

            this.txtVersaoEmissor.Text = this._emitente.VersaoEmissorNFe;
            this.txtObsPadraoNfe.Text = this._emitente.ObservacaoEmitente;

            this.txtCNAE.Text = this._emitente.Cnae;
            this.txtIM.Text = this._emitente.InscricaoMunicipal;
        }



        private void PISFields()
        {

            switch (Convert.ToInt32(cmbCSTPis.SelectedValue))
            {
                case 1:
                case 2:
                    this.cmbModTributPis.SelectedIndex = 0;
                    this.nudAliquotaPis.Enabled = true;
                    this.cbxImpRetidoPis.Enabled = true;
                    this.cmbModTributPis.Enabled = false;
                    break;
                case 3:
                    this.cmbModTributPis.SelectedIndex = 1;
                    this.nudAliquotaPis.Enabled = true;
                    this.cbxImpRetidoPis.Enabled = true;
                    this.cmbModTributPis.Enabled = false;
                    break;
                case 4:
                case 6:
                case 7:
                case 8:
                case 9:
                    this.nudAliquotaPis.Enabled = false;
                    this.nudAliquotaPis.Value = 0;
                    this.cbxImpRetidoPis.Enabled = false;
                    this.cmbModTributPis.Enabled = false;
                    this.cmbModTributPis.SelectedIndex = 2;
                    break;
                default:
                    this.nudAliquotaPis.Enabled = true;
                    this.cbxImpRetidoPis.Enabled = true;
                    this.cmbModTributPis.Enabled = true;
                    break;
            }
        }

        private void COFINSFields()
        {
            switch (Convert.ToInt32(cmbCSTCofins.SelectedValue))
            {
                case 1:
                case 2:
                    this.cmbModTributCofins.SelectedIndex = 0;
                    this.nudAliquotaCofins.Enabled = true;
                    this.cbxImpRetidoCofins.Enabled = true;
                    this.cmbModTributCofins.Enabled = false;
                    break;
                case 3:
                    this.cmbModTributCofins.SelectedIndex = 1;
                    this.nudAliquotaCofins.Enabled = true;
                    this.cbxImpRetidoCofins.Enabled = true;
                    this.cmbModTributCofins.Enabled = false;
                    break;
                case 4:
                case 6:
                case 7:
                case 8:
                case 9:
                    this.nudAliquotaCofins.Enabled = false;
                    this.cbxImpRetidoCofins.Enabled = false;
                    this.cmbModTributCofins.Enabled = false;
                    this.cmbModTributCofins.SelectedIndex = 2;
                    this.nudAliquotaCofins.Value = 0;
                    break;
                default:
                    this.nudAliquotaCofins.Enabled = true;
                    this.cbxImpRetidoCofins.Enabled = true;
                    this.cmbModTributCofins.Enabled = true;
                    break;
            }
        }

        private void carregarCertificados()
        {
            try
            {

                certificados = new Dictionary<string, X509Certificate2>();

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
                            certificados.Add(certificate.SerialNumber, certificate);
                            cmbCertificados.Items.Add(certificate.SerialNumber + " (" + certificate.Subject + ")");
                        }
                    }
                }



                string certificado = this._emitente.SerialCertificado;
                if (!string.IsNullOrWhiteSpace(certificado))
                {
                    foreach (string item in this.cmbCertificados.Items)
                    {
                        if (item.StartsWith(certificado + " ("))
                        {
                            this.cmbCertificados.SelectedItem = item;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar os certificados\r\n" + e.Message, e);
            }
        }

        private string salvarCertificados()
        {
            string err = "";
            if (cmbCertificados.SelectedItem == null && cmbCertificados.Items.Count > 0)
            {
                cmbCertificados.SelectedItem = cmbCertificados.Items[0];
            }

            if (cmbCertificados.SelectedItem != null)
            {
                string numeroSerie = this.cmbCertificados.SelectedItem.ToString().Substring(0, this.cmbCertificados.SelectedItem.ToString().IndexOf("(", StringComparison.Ordinal)).Trim();

                _emitente.SerialCertificado = certificados[numeroSerie].SerialNumber;
            }

            return err;
        }

        private void CarregarConfiguracoesNFe()
        {
            try
            {
                cmbImpressoraDanfe1.Items.Clear();
                cmbImpressoraDanfe2.Items.Clear();

                cmbImpressoraDanfe1.Items.Add("");
                cmbImpressoraDanfe2.Items.Add("");

                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                {
                    cmbImpressoraDanfe1.Items.Add(strPrinter);
                    cmbImpressoraDanfe2.Items.Add(strPrinter);
                }

                this.chkImpressaoDanfe.Checked = _emitente.DadosSalvarEnviarNfe.ImprimirDanfeHabilitado;
                this.cmbImpressoraDanfe1.SelectedItem = _emitente.DadosSalvarEnviarNfe.ImprimirDanfeImpressora1;
                this.cmbImpressoraDanfe2.SelectedItem = _emitente.DadosSalvarEnviarNfe.ImprimirDanfeImpressora2;

                this.chkEnvioNfeEmail.Checked = _emitente.DadosSalvarEnviarNfe.EnvioEmailHabilitado;

                this.chkEnvioXML.Checked = _emitente.DadosSalvarEnviarNfe.EnvioEmailXmlHhabilitado;
                this.txtEnvioXMLDestino.Text = _emitente.DadosSalvarEnviarNfe.EnvioEmailXmlDestino;

                this.chkEnvioDANFE.Checked = _emitente.DadosSalvarEnviarNfe.EnvioEmailDanfeHabilitado;
                this.txtEnvioDANFEDestino.Text = _emitente.DadosSalvarEnviarNfe.EnvioEmailDanfeDestino;

                this.chkEnvioNFeCliente.Checked = _emitente.DadosSalvarEnviarNfe.EnvioEmailClienteHabilitado;

                this.chkArquivamentoNFe.Checked = _emitente.DadosSalvarEnviarNfe.SalvarPastaHabilitado;
                this.txtPastaDanfe.Text = _emitente.DadosSalvarEnviarNfe.SalvarPastaDanfe;
                this.txtPastaXML.Text = _emitente.DadosSalvarEnviarNfe.SalvarPastaXml;

                this.txtEnvioNFeRemetente.Text = _emitente.DadosSalvarEnviarNfe.EnvioEmailRemetente;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao carregar as Configurações da NFe\r\n" + e.Message, e);
            }

        }

        private void SalvarConfiguracoesNFe()
        {

            _emitente.DadosSalvarEnviarNfe.ImprimirDanfeHabilitado = this.chkImpressaoDanfe.Checked;
            _emitente.DadosSalvarEnviarNfe.ImprimirDanfeImpressora1 = this.cmbImpressoraDanfe1.SelectedItem != null ? this.cmbImpressoraDanfe1.SelectedItem.ToString() : "";
            _emitente.DadosSalvarEnviarNfe.ImprimirDanfeImpressora2 = this.cmbImpressoraDanfe2.SelectedItem != null ? this.cmbImpressoraDanfe2.SelectedItem.ToString() : "";

            _emitente.DadosSalvarEnviarNfe.EnvioEmailHabilitado = this.chkEnvioNfeEmail.Checked;

            _emitente.DadosSalvarEnviarNfe.EnvioEmailXmlHhabilitado = this.chkEnvioXML.Checked;
            _emitente.DadosSalvarEnviarNfe.EnvioEmailXmlDestino = this.txtEnvioXMLDestino.Text;

            _emitente.DadosSalvarEnviarNfe.EnvioEmailDanfeHabilitado = this.chkEnvioDANFE.Checked;
            _emitente.DadosSalvarEnviarNfe.EnvioEmailDanfeDestino = this.txtEnvioDANFEDestino.Text;

            _emitente.DadosSalvarEnviarNfe.EnvioEmailClienteHabilitado = this.chkEnvioNFeCliente.Checked;

            _emitente.DadosSalvarEnviarNfe.SalvarPastaHabilitado = this.chkArquivamentoNFe.Checked;
            _emitente.DadosSalvarEnviarNfe.SalvarPastaDanfe = this.txtPastaDanfe.Text;
            _emitente.DadosSalvarEnviarNfe.SalvarPastaXml = this.txtPastaXML.Text;
            
            _emitente.DadosSalvarEnviarNfe.EnvioEmailRemetente = this.txtEnvioNFeRemetente.Text;

        }


        private void InitializeGridAutorizados()
        {
            _documentosAutorizados = new BindingList<DocumentosString>(_emitente.AutorizadosDownloadNf.ConvertAll(a => new DocumentosString() {DocumentoAutorizado = a}));

            dgvAutorizados.DataSource = _documentosAutorizados;
        }

        private void AutorizadosNovo()
        {
            txtAutorizadoDocumento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

            string docLimpo = txtAutorizadoDocumento.Text;

            txtAutorizadoDocumento.TextMaskFormat = MaskFormat.IncludeLiterals;

            string docFormatado = txtAutorizadoDocumento.Text;
            

            if (!IWTFunctions.IWTFunctions.ValidaCnpj(docLimpo) && !IWTFunctions.IWTFunctions.validaCPF(docLimpo))
            {
                throw new ExcecaoTratada("CPF/CNPJ Inválido: "+ docFormatado);
            }



            if (_documentosAutorizados.Any(a=> a.DocumentoAutorizado == docFormatado ))
            {
                throw new ExcecaoTratada("Esse CPF/CNPJ já foi incluído anteriormente");
            }

            _documentosAutorizados.Add(new DocumentosString()
            {
                DocumentoAutorizado = docFormatado
            });

            txtAutorizadoDocumento.Clear();

            dgvAutorizados.Invalidate();
        }

        private void AutorizadosExcluir()
        {
            if (dgvAutorizados.SelectedRows.Count == 0)
            {
                throw new ExcecaoTratada("Selecione um documento para excluir");
            }
            
            _documentosAutorizados.Remove((DocumentosString) this.dgvAutorizados.SelectedRows[0].DataBoundItem);

            dgvAutorizados.Invalidate();

        }

        private void FormatarCampoAutorizados()
        {
            txtAutorizadoDocumento.Mask = rdbAutorizadosCPF.Checked ? "000,000,000-00" : "00,000,000/0000-00";
        }


      

        #region Eventos

        private void chkEnvioNfeEmail_CheckedChanged(object sender, EventArgs e)
        {
            this.grbEnvioNFeEmail.Enabled = this.chkEnvioNfeEmail.Checked;
        }

        private void chkImpressaoDanfe_CheckedChanged(object sender, EventArgs e)
        {
            this.grbImpressaoDanfe.Enabled = this.chkImpressaoDanfe.Checked;
        }

        private void chkArquivamentoNFe_CheckedChanged(object sender, EventArgs e)
        {
            this.grbArquivamentoNFe.Enabled = this.chkArquivamentoNFe.Checked;
        }

        private void chkEnvioXML_CheckedChanged(object sender, EventArgs e)
        {
            txtEnvioXMLDestino.Enabled = this.chkEnvioXML.Checked;
        }

        private void chkEnvioDANFE_CheckedChanged(object sender, EventArgs e)
        {
            txtEnvioDANFEDestino.Enabled = this.chkEnvioDANFE.Checked;
        }

        private void btnPastaXML_Click(object sender, EventArgs e)
        {

            this.folderBrowserDialog1.Description = "Selecione a pasta para salvar os XMLs das notas geradas.";
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtPastaXML.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnPastaDanfe_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.Description = "Selecione a pasta para salvar os DANFEs das notas geradas.";
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtPastaDanfe.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validateRequiredField())
                {
                    this._emitente.RazaoSocial = txtEmpresa.Text;
                    this._emitente.Cnpj = txtCNPJ.Text;
                    this._emitente.InscricaoEstadual = txtIE.Text;
                    this._emitente.Endereco = txtEndereco.Text;
                    this._emitente.Numero = txtNumero.Text;
                    this._emitente.Complemento = txtComplento.Text;
                    this._emitente.Bairro = txtBairro.Text;
                    this._emitente.Cep = txtCep.Text.Replace("-", "");

                    this._emitente.CidadeEntidade = (CidadeClass) this.ensCidade.EntidadeSelecionada;
                    this._emitente.Telefone = txtTelefone.Text;
                    this._emitente.Fax = txtFax.Text;
                    this._emitente.Contato = txtNomeContato.Text;

                    this._emitente.PastaSaidaNFe = txtPathOutNF.Text;

                    this._emitente.PisCst = cmbCSTPis.SelectedValue.ToString();
                    this._emitente.PisAliquota = (double) nudAliquotaPis.Value;
                    this._emitente.PisModalidade = Convert.ToInt32(cmbModTributPis.SelectedValue);
                    this._emitente.PisImpostoRetido = Convert.ToBoolean(Convert.ToInt16(cbxImpRetidoPis.Checked));
                    this._emitente.CofinsCst = cmbCSTCofins.SelectedValue.ToString();
                    this._emitente.CofinsAliquota = (double) nudAliquotaCofins.Value;
                    this._emitente.CofinsModalidade = Convert.ToInt32(cmbModTributCofins.SelectedValue);
                    this._emitente.CofinsImpostoRetido = Convert.ToBoolean(Convert.ToInt16(cbxImpRetidoCofins.Checked));

                    if (this.rdbSimples.Checked)
                    {
                        this._emitente.Crt = CRTTipo.Simples;
                    }

                    if (this.rdbSimplesExcesso.Checked)
                    {
                        this._emitente.Crt = CRTTipo.SimplesExcesso;
                    }

                    if (this.rdbNormal.Checked)
                    {
                        this._emitente.Crt = CRTTipo.Normal;
                    }

                    this._emitente.VersaoEmissorNFe = this.txtVersaoEmissor.Text;
                    this._emitente.ObservacaoEmitente = this.txtObsPadraoNfe.Text;

                    if (this.grbCertificado.Visible)
                    {
                        this.salvarCertificados();
                    }

                    if (this.tabControl1.TabPages.Contains(tabPage5))
                    {
                        this.SalvarConfiguracoesNFe();
                    }

                    this._emitente.Cnae = this.txtCNAE.Text;
                    this._emitente.InscricaoMunicipal = this.txtIM.Text;
                    
                    _emitente.AutorizadosDownloadNf = _documentosAutorizados.ToList().ConvertAll(a => a.DocumentoAutorizado);
                    NotaFiscalFuncoesAuxiliares.SalvaEmitente(_emitente, _tipoEmissor);

                    this.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao salvar\r\n" + a.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validateRequiredField()
        {
            if (txtCNPJ.Text.Length == 0)
            {
                throw new ExcecaoTratada("Digite o Cnpj do emitente.");
            }

            if (!IWTFunctions.IWTFunctions.validaCNPJ(txtCNPJ.Text.Trim().Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
            {
                throw new ExcecaoTratada("O Cnpj digitado é inválido.");
            }

            if (txtEmpresa.Text.Length < 2)
            {
                throw new ExcecaoTratada("O nome da empresa é inválido, número mínimo de caracteres não atingido.");
            }

            if (txtEndereco.Text.Length < 2)
            {
                throw new ExcecaoTratada("O campo Endereço é inválido, número mínimo de caracteres não atingido.");
            }

            if (txtNumero.Text.Length < 1 || txtNumero.Text == "0")
            {
                throw new ExcecaoTratada("Preencha o número do endereço do emitente.");
            }

            if (txtBairro.Text.Length < 2)
            {
                throw new ExcecaoTratada("O campo Bairro é inválido, número mínimo de caracteres não atingido.");
            }

            if (txtCep.Text.Replace("-", "").Length < 8)
            {
                throw new ExcecaoTratada("O campo Cep é inválido, número mínimo de caracteres não atingido.");
            }

            if (ensCidade.EntidadeSelecionada == null)
            {
                throw new ExcecaoTratada("Selecione a cidade do emitente.");
            }

            if (cmbCSTPis.SelectedValue == null)
            {
                throw new ExcecaoTratada("Informe o CST do PIS.");
            }

            if (cmbCSTCofins.SelectedValue == null)
            {
                throw new ExcecaoTratada("Informe o CST do Cofins.");
            }

            return true;
        }


        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            txtPathOutNF.Text = @folderDialog.SelectedPath;
        }

        private void cmbCSTPis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                this.PISFields();
            }
        }

        private void cmbCSTCofins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                this.COFINSFields();
            }
        }



        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char) 8)
            {
                e.Handled = true;
            }
        }

    


  
        private void btnAutorizadosNovo_Click(object sender, EventArgs e)
        {
            try
            {
                AutorizadosNovo();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnAutorizadosExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                AutorizadosExcluir();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void rdbAutorizadosCPF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FormatarCampoAutorizados();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbAutorizadosCNPJ_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FormatarCampoAutorizados();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            rdbAutorizadosCPF.Checked = true;
            FormatarCampoAutorizados();
        }

        #endregion

    }

    public class DocumentosString
    {
        public string DocumentoAutorizado { get; set; }
    }
}
