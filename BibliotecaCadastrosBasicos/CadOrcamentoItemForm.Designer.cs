using System.Windows.Forms;

namespace BibliotecaCadastrosBasicos
{
    partial class CadOrcamentoItemForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.nudFrete = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label11 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label35 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtOrdemVenda = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtProjeto = new IWTDotNetLib.IWTTextBox(this.components);
            this.label19 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtArmazenagem = new IWTDotNetLib.IWTTextBox(this.components);
            this.label20 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxEntregaParc = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cbxVolumeUnico = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkExportacao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ensFormaPagamento = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label33 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkCentroCusto = new IWTDotNetLib.IWTCheckBox(this.components);
            this.btnCentroCusto = new IWTDotNetLib.IWTButton(this.components);
            this.txtCentroCusto = new IWTDotNetLib.IWTTextBox(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkContaBancaria = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cmbContaBancaria = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label32 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkTipoKit = new IWTDotNetLib.IWTCheckBox(this.components);
            this.cmbTipoKit = new IWTDotNetLib.IWTComboBox(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtInfoEspeciais = new IWTDotNetLib.IWTTextBox(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.label31 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpDataPedido = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.grbCancelamento = new System.Windows.Forms.GroupBox();
            this.txtCancelamentoJustificativa = new IWTDotNetLib.IWTTextBox(this.components);
            this.label30 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpCancelamentoData = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label29 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCancelamentoUsuario = new IWTDotNetLib.IWTTextBox(this.components);
            this.label26 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnVariaveis = new IWTDotNetLib.IWTButton(this.components);
            this.label22 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbCliente = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.dtpDataEntrega = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.label17 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtOc = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.label23 = new IWTDotNetLib.IWTLabel(this.components);
            this.label18 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbOperacao = new IWTDotNetLib.IWTComboBox(this.components);
            this.txtPos = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.gbxPrincipal = new System.Windows.Forms.GroupBox();
            this.btnBuscaProduto = new IWTDotNetLib.IWTButton(this.components);
            this.txtBuscaProduto = new IWTDotNetLib.IWTTextBox(this.components);
            this.lnkDetalhesPrincipal = new System.Windows.Forms.LinkLabel();
            this.chkNCM = new IWTDotNetLib.IWTCheckBox(this.components);
            this.lblTotal = new IWTDotNetLib.IWTLabel(this.components);
            this.txtNCM = new IWTDotNetLib.IWTTextBox(this.components);
            this.label21 = new IWTDotNetLib.IWTLabel(this.components);
            this.label15 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudValorUnit = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtd = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.txtDescricao = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCodigo = new IWTDotNetLib.IWTTextBox(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.gbxItem = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnBuscaProdItem = new IWTDotNetLib.IWTButton(this.components);
            this.txtBuscaProdItem = new IWTDotNetLib.IWTTextBox(this.components);
            this.lnkDetalhesSub = new System.Windows.Forms.LinkLabel();
            this.btnEditarItem = new IWTDotNetLib.IWTButton(this.components);
            this.label28 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCodigoItem = new IWTDotNetLib.IWTTextBox(this.components);
            this.label27 = new IWTDotNetLib.IWTLabel(this.components);
            this.label10 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtDescricaoItem = new IWTDotNetLib.IWTTextBox(this.components);
            this.nudQtdItem = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label25 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnAdicionar = new IWTDotNetLib.IWTButton(this.components);
            this.btnRemover = new IWTDotNetLib.IWTButton(this.components);
            this.btnConfirmarEdicao = new IWTDotNetLib.IWTButton(this.components);
            this.dataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.label24 = new IWTDotNetLib.IWTLabel(this.components);
            this.comboBox4 = new IWTDotNetLib.IWTComboBox(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtObservacaoEspelhoPed = new IWTDotNetLib.IWTTextBox(this.components);
            this.label36 = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grpComissaoVendedor = new System.Windows.Forms.GroupBox();
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudComissaoVendedor = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.cmbVendedor = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkVendedor = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grpComissaoRepresentante = new System.Windows.Forms.GroupBox();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudComissaoRepresentante = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.cmbRepresentante = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.label34 = new IWTDotNetLib.IWTLabel(this.components);
            this.chkRepresentante = new IWTDotNetLib.IWTCheckBox(this.components);
            this.btnCopiar = new IWTDotNetLib.IWTButton(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrete)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataPedido)).BeginInit();
            this.grbCancelamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCancelamentoData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataEntrega)).BeginInit();
            this.gbxPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtd)).BeginInit();
            this.gbxItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.grpComissaoVendedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoVendedor)).BeginInit();
            this.grpComissaoRepresentante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoRepresentante)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCopiar);
            this.splitContainer1.Size = new System.Drawing.Size(1012, 726);
            this.splitContainer1.SplitterDistance = 675;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 12);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(925, 12);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 675);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1004, 649);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do Pedido";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbxItem);
            this.splitContainer2.Size = new System.Drawing.Size(998, 643);
            this.splitContainer2.SplitterDistance = 443;
            this.splitContainer2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gbxPrincipal);
            this.splitContainer3.Size = new System.Drawing.Size(998, 443);
            this.splitContainer3.SplitterDistance = 374;
            this.splitContainer3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.chkTipoKit);
            this.groupBox1.Controls.Add(this.cmbTipoKit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtInfoEspeciais);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.dtpDataPedido);
            this.groupBox1.Controls.Add(this.grbCancelamento);
            this.groupBox1.Controls.Add(this.btnVariaveis);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cmbCliente);
            this.groupBox1.Controls.Add(this.dtpDataEntrega);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtOc);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cmbOperacao);
            this.groupBox1.Controls.Add(this.txtPos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(998, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pedido";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.nudFrete);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(348, 69);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 105);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Frete";
            // 
            // nudFrete
            // 
            this.nudFrete.BindingField = "Frete";
            this.nudFrete.DecimalPlaces = 4;
            this.nudFrete.LiberadoQuandoCadastroUtilizado = false;
            this.nudFrete.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudFrete.Location = new System.Drawing.Point(42, 30);
            this.nudFrete.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudFrete.Name = "nudFrete";
            this.nudFrete.Size = new System.Drawing.Size(88, 20);
            this.nudFrete.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BindingField = null;
            this.label11.LiberadoQuandoCadastroUtilizado = false;
            this.label11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label11.Location = new System.Drawing.Point(11, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Valor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.txtOrdemVenda);
            this.groupBox2.Controls.Add(this.txtProjeto);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtArmazenagem);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(400, 293);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 75);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informações do Cliente";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BindingField = null;
            this.label35.LiberadoQuandoCadastroUtilizado = false;
            this.label35.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label35.Location = new System.Drawing.Point(213, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 13);
            this.label35.TabIndex = 50;
            this.label35.Text = "Ordem Venda";
            // 
            // txtOrdemVenda
            // 
            this.txtOrdemVenda.BindingField = "OrdemVenda";
            this.txtOrdemVenda.DebugMode = false;
            this.txtOrdemVenda.LiberadoQuandoCadastroUtilizado = false;
            this.txtOrdemVenda.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtOrdemVenda.Location = new System.Drawing.Point(291, 17);
            this.txtOrdemVenda.MaxLength = 50;
            this.txtOrdemVenda.ModoBarcode = false;
            this.txtOrdemVenda.Name = "txtOrdemVenda";
            this.txtOrdemVenda.Size = new System.Drawing.Size(153, 20);
            this.txtOrdemVenda.TabIndex = 49;
            // 
            // txtProjeto
            // 
            this.txtProjeto.BindingField = "ProjetoCliente";
            this.txtProjeto.DebugMode = false;
            this.txtProjeto.LiberadoQuandoCadastroUtilizado = false;
            this.txtProjeto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtProjeto.Location = new System.Drawing.Point(84, 16);
            this.txtProjeto.MaxLength = 255;
            this.txtProjeto.ModoBarcode = false;
            this.txtProjeto.Name = "txtProjeto";
            this.txtProjeto.Size = new System.Drawing.Size(108, 20);
            this.txtProjeto.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BindingField = null;
            this.label19.LiberadoQuandoCadastroUtilizado = false;
            this.label19.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label19.Location = new System.Drawing.Point(38, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 46;
            this.label19.Text = "Projeto";
            // 
            // txtArmazenagem
            // 
            this.txtArmazenagem.BindingField = "ArmazenagemCliente";
            this.txtArmazenagem.DebugMode = false;
            this.txtArmazenagem.LiberadoQuandoCadastroUtilizado = false;
            this.txtArmazenagem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtArmazenagem.Location = new System.Drawing.Point(84, 42);
            this.txtArmazenagem.MaxLength = 255;
            this.txtArmazenagem.ModoBarcode = false;
            this.txtArmazenagem.Name = "txtArmazenagem";
            this.txtArmazenagem.Size = new System.Drawing.Size(111, 20);
            this.txtArmazenagem.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BindingField = null;
            this.label20.LiberadoQuandoCadastroUtilizado = false;
            this.label20.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label20.Location = new System.Drawing.Point(4, 45);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "Armazenagem";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxEntregaParc);
            this.groupBox3.Controls.Add(this.cbxVolumeUnico);
            this.groupBox3.Controls.Add(this.chkExportacao);
            this.groupBox3.Location = new System.Drawing.Point(8, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 75);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configurações";
            // 
            // cbxEntregaParc
            // 
            this.cbxEntregaParc.AutoSize = true;
            this.cbxEntregaParc.BindingField = "PermiteEntregaParcial";
            this.cbxEntregaParc.Checked = true;
            this.cbxEntregaParc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxEntregaParc.LiberadoQuandoCadastroUtilizado = false;
            this.cbxEntregaParc.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxEntregaParc.Location = new System.Drawing.Point(14, 21);
            this.cbxEntregaParc.Name = "cbxEntregaParc";
            this.cbxEntregaParc.Size = new System.Drawing.Size(136, 17);
            this.cbxEntregaParc.TabIndex = 0;
            this.cbxEntregaParc.Text = "Permite Entrega Parcial";
            this.cbxEntregaParc.UseVisualStyleBackColor = true;
            // 
            // cbxVolumeUnico
            // 
            this.cbxVolumeUnico.AutoSize = true;
            this.cbxVolumeUnico.BindingField = "VolumeUnico";
            this.cbxVolumeUnico.Checked = true;
            this.cbxVolumeUnico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxVolumeUnico.LiberadoQuandoCadastroUtilizado = false;
            this.cbxVolumeUnico.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxVolumeUnico.Location = new System.Drawing.Point(14, 38);
            this.cbxVolumeUnico.Name = "cbxVolumeUnico";
            this.cbxVolumeUnico.Size = new System.Drawing.Size(92, 17);
            this.cbxVolumeUnico.TabIndex = 1;
            this.cbxVolumeUnico.Text = "Volume Único";
            this.cbxVolumeUnico.UseVisualStyleBackColor = true;
            // 
            // chkExportacao
            // 
            this.chkExportacao.AutoSize = true;
            this.chkExportacao.BindingField = "Exportacao";
            this.chkExportacao.LiberadoQuandoCadastroUtilizado = false;
            this.chkExportacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkExportacao.Location = new System.Drawing.Point(156, 21);
            this.chkExportacao.Name = "chkExportacao";
            this.chkExportacao.Size = new System.Drawing.Size(80, 17);
            this.chkExportacao.TabIndex = 2;
            this.chkExportacao.Text = "Exportação";
            this.chkExportacao.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ensFormaPagamento);
            this.groupBox7.Controls.Add(this.label33);
            this.groupBox7.Controls.Add(this.chkCentroCusto);
            this.groupBox7.Controls.Add(this.btnCentroCusto);
            this.groupBox7.Controls.Add(this.txtCentroCusto);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.chkContaBancaria);
            this.groupBox7.Controls.Add(this.cmbContaBancaria);
            this.groupBox7.Controls.Add(this.label32);
            this.groupBox7.Location = new System.Drawing.Point(8, 179);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(786, 108);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Informações Financeiras";
            // 
            // ensFormaPagamento
            // 
            this.ensFormaPagamento.BindingField = "FormaPagamento";
            this.ensFormaPagamento.DesabilitarAutoCompletar = false;
            this.ensFormaPagamento.DesabilitarChekBox = false;
            this.ensFormaPagamento.DesabilitarLupa = false;
            this.ensFormaPagamento.DesabilitarSeta = false;
            this.ensFormaPagamento.EntidadeSelecionada = null;
            this.ensFormaPagamento.FormSelecao = null;
            this.ensFormaPagamento.LiberadoQuandoCadastroUtilizado = false;
            this.ensFormaPagamento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFormaPagamento.Location = new System.Drawing.Point(128, 70);
            this.ensFormaPagamento.ModoVisualizacaoGrid = null;
            this.ensFormaPagamento.Name = "ensFormaPagamento";
            this.ensFormaPagamento.ParametrosBuscaObrigatorios = null;
            this.ensFormaPagamento.Size = new System.Drawing.Size(607, 23);
            this.ensFormaPagamento.TabIndex = 14;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BindingField = null;
            this.label33.LiberadoQuandoCadastroUtilizado = false;
            this.label33.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label33.Location = new System.Drawing.Point(14, 75);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(108, 13);
            this.label33.TabIndex = 13;
            this.label33.Text = "Forma de Pagamento";
            // 
            // chkCentroCusto
            // 
            this.chkCentroCusto.AutoSize = true;
            this.chkCentroCusto.BindingField = "PossuiCentroCustoLucro";
            this.chkCentroCusto.LiberadoQuandoCadastroUtilizado = false;
            this.chkCentroCusto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkCentroCusto.Location = new System.Drawing.Point(720, 49);
            this.chkCentroCusto.Name = "chkCentroCusto";
            this.chkCentroCusto.Size = new System.Drawing.Size(15, 14);
            this.chkCentroCusto.TabIndex = 4;
            this.chkCentroCusto.UseVisualStyleBackColor = true;
            this.chkCentroCusto.CheckedChanged += new System.EventHandler(this.chkCentroCusto_CheckedChanged);
            // 
            // btnCentroCusto
            // 
            this.btnCentroCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCentroCusto.Enabled = false;
            this.btnCentroCusto.LiberadoQuandoCadastroUtilizado = false;
            this.btnCentroCusto.Location = new System.Drawing.Point(741, 42);
            this.btnCentroCusto.Name = "btnCentroCusto";
            this.btnCentroCusto.Size = new System.Drawing.Size(38, 23);
            this.btnCentroCusto.TabIndex = 3;
            this.btnCentroCusto.Text = "...";
            this.btnCentroCusto.UseVisualStyleBackColor = true;
            this.btnCentroCusto.Click += new System.EventHandler(this.btnCentroCusto_Click);
            // 
            // txtCentroCusto
            // 
            this.txtCentroCusto.BindingField = "CentroCustoLucro";
            this.txtCentroCusto.DebugMode = false;
            this.txtCentroCusto.LiberadoQuandoCadastroUtilizado = false;
            this.txtCentroCusto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCentroCusto.Location = new System.Drawing.Point(128, 46);
            this.txtCentroCusto.ModoBarcode = false;
            this.txtCentroCusto.Name = "txtCentroCusto";
            this.txtCentroCusto.ReadOnly = true;
            this.txtCentroCusto.Size = new System.Drawing.Size(586, 20);
            this.txtCentroCusto.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(39, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Centro de Lucro";
            // 
            // chkContaBancaria
            // 
            this.chkContaBancaria.AutoSize = true;
            this.chkContaBancaria.BindingField = "PossuiContaBancaria";
            this.chkContaBancaria.LiberadoQuandoCadastroUtilizado = false;
            this.chkContaBancaria.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkContaBancaria.Location = new System.Drawing.Point(720, 22);
            this.chkContaBancaria.Name = "chkContaBancaria";
            this.chkContaBancaria.Size = new System.Drawing.Size(15, 14);
            this.chkContaBancaria.TabIndex = 1;
            this.chkContaBancaria.UseVisualStyleBackColor = true;
            this.chkContaBancaria.CheckedChanged += new System.EventHandler(this.chkContaBancaria_CheckedChanged);
            // 
            // cmbContaBancaria
            // 
            this.cmbContaBancaria.BindingField = "ContaBancaria";
            this.cmbContaBancaria.ColumnsToDisplay = null;
            this.cmbContaBancaria.DisableAutoSelectOnEmpty = false;
            this.cmbContaBancaria.DropDownHeight = 1;
            this.cmbContaBancaria.Enabled = false;
            this.cmbContaBancaria.FormattingEnabled = true;
            this.cmbContaBancaria.IntegralHeight = false;
            this.cmbContaBancaria.LiberadoQuandoCadastroUtilizado = false;
            this.cmbContaBancaria.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbContaBancaria.Location = new System.Drawing.Point(128, 19);
            this.cmbContaBancaria.Name = "cmbContaBancaria";
            this.cmbContaBancaria.SelectedRow = null;
            this.cmbContaBancaria.Size = new System.Drawing.Size(587, 21);
            this.cmbContaBancaria.TabIndex = 0;
            this.cmbContaBancaria.Table = null;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BindingField = null;
            this.label32.LiberadoQuandoCadastroUtilizado = false;
            this.label32.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label32.Location = new System.Drawing.Point(42, 22);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 13);
            this.label32.TabIndex = 7;
            this.label32.Text = "Conta Bancária";
            // 
            // chkTipoKit
            // 
            this.chkTipoKit.AutoSize = true;
            this.chkTipoKit.BindingField = "PossuiKit";
            this.chkTipoKit.LiberadoQuandoCadastroUtilizado = false;
            this.chkTipoKit.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkTipoKit.Location = new System.Drawing.Point(691, 49);
            this.chkTipoKit.Name = "chkTipoKit";
            this.chkTipoKit.Size = new System.Drawing.Size(15, 14);
            this.chkTipoKit.TabIndex = 75;
            this.chkTipoKit.UseVisualStyleBackColor = true;
            this.chkTipoKit.CheckedChanged += new System.EventHandler(this.chkTipoKit_CheckedChanged);
            // 
            // cmbTipoKit
            // 
            this.cmbTipoKit.BindingField = "Kit";
            this.cmbTipoKit.Enabled = false;
            this.cmbTipoKit.FormattingEnabled = true;
            this.cmbTipoKit.LiberadoQuandoCadastroUtilizado = false;
            this.cmbTipoKit.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbTipoKit.Location = new System.Drawing.Point(503, 46);
            this.cmbTipoKit.Name = "cmbTipoKit";
            this.cmbTipoKit.Size = new System.Drawing.Size(186, 21);
            this.cmbTipoKit.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(478, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Kit";
            // 
            // txtInfoEspeciais
            // 
            this.txtInfoEspeciais.BindingField = "InformacaoEspecial";
            this.txtInfoEspeciais.DebugMode = false;
            this.txtInfoEspeciais.LiberadoQuandoCadastroUtilizado = false;
            this.txtInfoEspeciais.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtInfoEspeciais.Location = new System.Drawing.Point(81, 73);
            this.txtInfoEspeciais.MaxLength = 255;
            this.txtInfoEspeciais.ModoBarcode = false;
            this.txtInfoEspeciais.Name = "txtInfoEspeciais";
            this.txtInfoEspeciais.Size = new System.Drawing.Size(256, 20);
            this.txtInfoEspeciais.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(5, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 72;
            this.label3.Text = "Inf. Especiais";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BindingField = null;
            this.label31.LiberadoQuandoCadastroUtilizado = false;
            this.label31.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label31.Location = new System.Drawing.Point(502, 20);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(75, 13);
            this.label31.TabIndex = 70;
            this.label31.Text = "Data Cadastro";
            // 
            // dtpDataPedido
            // 
            this.dtpDataPedido.BindingField = "DataEntrada";
            this.dtpDataPedido.Enabled = false;
            this.dtpDataPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataPedido.LiberadoQuandoCadastroUtilizado = false;
            this.dtpDataPedido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpDataPedido.Location = new System.Drawing.Point(583, 16);
            this.dtpDataPedido.Name = "dtpDataPedido";
            this.dtpDataPedido.Size = new System.Drawing.Size(106, 20);
            this.dtpDataPedido.TabIndex = 4;
            this.dtpDataPedido.Value = new System.DateTime(2015, 5, 12, 14, 52, 49, 764);
            // 
            // grbCancelamento
            // 
            this.grbCancelamento.Controls.Add(this.txtCancelamentoJustificativa);
            this.grbCancelamento.Controls.Add(this.label30);
            this.grbCancelamento.Controls.Add(this.dtpCancelamentoData);
            this.grbCancelamento.Controls.Add(this.label29);
            this.grbCancelamento.Controls.Add(this.txtCancelamentoUsuario);
            this.grbCancelamento.Controls.Add(this.label26);
            this.grbCancelamento.Location = new System.Drawing.Point(8, 293);
            this.grbCancelamento.Name = "grbCancelamento";
            this.grbCancelamento.Size = new System.Drawing.Size(386, 75);
            this.grbCancelamento.TabIndex = 19;
            this.grbCancelamento.TabStop = false;
            this.grbCancelamento.Text = "Cancelamento";
            // 
            // txtCancelamentoJustificativa
            // 
            this.txtCancelamentoJustificativa.BindingField = "JustificativaCancelamento";
            this.txtCancelamentoJustificativa.DebugMode = false;
            this.txtCancelamentoJustificativa.Enabled = false;
            this.txtCancelamentoJustificativa.LiberadoQuandoCadastroUtilizado = false;
            this.txtCancelamentoJustificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCancelamentoJustificativa.Location = new System.Drawing.Point(77, 47);
            this.txtCancelamentoJustificativa.ModoBarcode = false;
            this.txtCancelamentoJustificativa.Name = "txtCancelamentoJustificativa";
            this.txtCancelamentoJustificativa.Size = new System.Drawing.Size(295, 20);
            this.txtCancelamentoJustificativa.TabIndex = 2;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BindingField = null;
            this.label30.LiberadoQuandoCadastroUtilizado = false;
            this.label30.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label30.Location = new System.Drawing.Point(10, 50);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(62, 13);
            this.label30.TabIndex = 70;
            this.label30.Text = "Justificativa";
            // 
            // dtpCancelamentoData
            // 
            this.dtpCancelamentoData.BindingField = "DataCancelamento";
            this.dtpCancelamentoData.Enabled = false;
            this.dtpCancelamentoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCancelamentoData.LiberadoQuandoCadastroUtilizado = false;
            this.dtpCancelamentoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpCancelamentoData.Location = new System.Drawing.Point(266, 21);
            this.dtpCancelamentoData.Name = "dtpCancelamentoData";
            this.dtpCancelamentoData.Size = new System.Drawing.Size(106, 20);
            this.dtpCancelamentoData.TabIndex = 1;
            this.dtpCancelamentoData.Value = new System.DateTime(2015, 5, 12, 14, 52, 49, 771);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BindingField = null;
            this.label29.LiberadoQuandoCadastroUtilizado = false;
            this.label29.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label29.Location = new System.Drawing.Point(230, 24);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 13);
            this.label29.TabIndex = 2;
            this.label29.Text = "Data";
            // 
            // txtCancelamentoUsuario
            // 
            this.txtCancelamentoUsuario.BindingField = "AcsUsuarioCancelamento";
            this.txtCancelamentoUsuario.DebugMode = false;
            this.txtCancelamentoUsuario.Enabled = false;
            this.txtCancelamentoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.txtCancelamentoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCancelamentoUsuario.Location = new System.Drawing.Point(77, 22);
            this.txtCancelamentoUsuario.ModoBarcode = false;
            this.txtCancelamentoUsuario.Name = "txtCancelamentoUsuario";
            this.txtCancelamentoUsuario.Size = new System.Drawing.Size(80, 20);
            this.txtCancelamentoUsuario.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BindingField = null;
            this.label26.LiberadoQuandoCadastroUtilizado = false;
            this.label26.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label26.Location = new System.Drawing.Point(30, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 13);
            this.label26.TabIndex = 0;
            this.label26.Text = "Usuario";
            // 
            // btnVariaveis
            // 
            this.btnVariaveis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVariaveis.Enabled = false;
            this.btnVariaveis.LiberadoQuandoCadastroUtilizado = false;
            this.btnVariaveis.Location = new System.Drawing.Point(856, 309);
            this.btnVariaveis.Name = "btnVariaveis";
            this.btnVariaveis.Size = new System.Drawing.Size(131, 23);
            this.btnVariaveis.TabIndex = 20;
            this.btnVariaveis.Text = "Variáveis do Pedido";
            this.btnVariaveis.UseVisualStyleBackColor = true;
            this.btnVariaveis.Click += new System.EventHandler(this.btnVariaveis_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BindingField = null;
            this.label22.LiberadoQuandoCadastroUtilizado = false;
            this.label22.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label22.Location = new System.Drawing.Point(249, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 52;
            this.label22.Text = "Data Entrega";
            // 
            // cmbCliente
            // 
            this.cmbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCliente.BindingField = "Cliente";
            this.cmbCliente.ColumnsToDisplay = null;
            this.cmbCliente.DisableAutoSelectOnEmpty = false;
            this.cmbCliente.DropDownHeight = 1;
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.IntegralHeight = false;
            this.cmbCliente.LiberadoQuandoCadastroUtilizado = false;
            this.cmbCliente.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbCliente.Location = new System.Drawing.Point(81, 18);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.SelectedRow = null;
            this.cmbCliente.Size = new System.Drawing.Size(161, 21);
            this.cmbCliente.TabIndex = 0;
            this.cmbCliente.Table = null;
            this.cmbCliente.SelectedIndexChanged += new System.EventHandler(this.cmbCliente_SelectedIndexChanged);
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.BindingField = "DataEntrega";
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrega.LiberadoQuandoCadastroUtilizado = false;
            this.dtpDataEntrega.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpDataEntrega.Location = new System.Drawing.Point(325, 45);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(106, 20);
            this.dtpDataEntrega.TabIndex = 6;
            this.dtpDataEntrega.Value = new System.DateTime(2015, 5, 12, 14, 52, 49, 788);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(36, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Cliente";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BindingField = null;
            this.label17.LiberadoQuandoCadastroUtilizado = false;
            this.label17.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label17.Location = new System.Drawing.Point(242, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "Pedido / Linha";
            // 
            // txtOc
            // 
            this.txtOc.AsciiOnly = true;
            this.txtOc.BindingField = "Numero";
            this.txtOc.LiberadoQuandoCadastroUtilizado = false;
            this.txtOc.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtOc.Location = new System.Drawing.Point(325, 19);
            this.txtOc.Mask = "AAAAAAAAAA";
            this.txtOc.Name = "txtOc";
            this.txtOc.Size = new System.Drawing.Size(106, 20);
            this.txtOc.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BindingField = null;
            this.label23.LiberadoQuandoCadastroUtilizado = false;
            this.label23.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label23.Location = new System.Drawing.Point(20, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 13);
            this.label23.TabIndex = 54;
            this.label23.Text = "Operação";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BindingField = null;
            this.label18.LiberadoQuandoCadastroUtilizado = false;
            this.label18.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label18.Location = new System.Drawing.Point(430, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "/";
            // 
            // cmbOperacao
            // 
            this.cmbOperacao.BindingField = "Operacao";
            this.cmbOperacao.FormattingEnabled = true;
            this.cmbOperacao.LiberadoQuandoCadastroUtilizado = false;
            this.cmbOperacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbOperacao.Location = new System.Drawing.Point(81, 45);
            this.cmbOperacao.Name = "cmbOperacao";
            this.cmbOperacao.Size = new System.Drawing.Size(161, 21);
            this.cmbOperacao.TabIndex = 5;
            // 
            // txtPos
            // 
            this.txtPos.BindingField = "Posicao";
            this.txtPos.LiberadoQuandoCadastroUtilizado = false;
            this.txtPos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtPos.Location = new System.Drawing.Point(443, 19);
            this.txtPos.Mask = "999";
            this.txtPos.Name = "txtPos";
            this.txtPos.Size = new System.Drawing.Size(35, 20);
            this.txtPos.TabIndex = 2;
            this.txtPos.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // gbxPrincipal
            // 
            this.gbxPrincipal.Controls.Add(this.btnBuscaProduto);
            this.gbxPrincipal.Controls.Add(this.txtBuscaProduto);
            this.gbxPrincipal.Controls.Add(this.lnkDetalhesPrincipal);
            this.gbxPrincipal.Controls.Add(this.chkNCM);
            this.gbxPrincipal.Controls.Add(this.lblTotal);
            this.gbxPrincipal.Controls.Add(this.txtNCM);
            this.gbxPrincipal.Controls.Add(this.label21);
            this.gbxPrincipal.Controls.Add(this.label15);
            this.gbxPrincipal.Controls.Add(this.nudValorUnit);
            this.gbxPrincipal.Controls.Add(this.label1);
            this.gbxPrincipal.Controls.Add(this.label5);
            this.gbxPrincipal.Controls.Add(this.nudQtd);
            this.gbxPrincipal.Controls.Add(this.txtDescricao);
            this.gbxPrincipal.Controls.Add(this.label2);
            this.gbxPrincipal.Controls.Add(this.txtCodigo);
            this.gbxPrincipal.Controls.Add(this.label4);
            this.gbxPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxPrincipal.Location = new System.Drawing.Point(0, 0);
            this.gbxPrincipal.Name = "gbxPrincipal";
            this.gbxPrincipal.Size = new System.Drawing.Size(998, 65);
            this.gbxPrincipal.TabIndex = 0;
            this.gbxPrincipal.TabStop = false;
            this.gbxPrincipal.Text = "Item Principal (Pai)";
            // 
            // btnBuscaProduto
            // 
            this.btnBuscaProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscaProduto.LiberadoQuandoCadastroUtilizado = false;
            this.btnBuscaProduto.Location = new System.Drawing.Point(261, 16);
            this.btnBuscaProduto.Name = "btnBuscaProduto";
            this.btnBuscaProduto.Size = new System.Drawing.Size(78, 23);
            this.btnBuscaProduto.TabIndex = 85;
            this.btnBuscaProduto.Text = "Selecionar";
            this.btnBuscaProduto.UseVisualStyleBackColor = true;
            this.btnBuscaProduto.Click += new System.EventHandler(this.btnBuscaProduto_Click);
            // 
            // txtBuscaProduto
            // 
            this.txtBuscaProduto.BindingField = "Produto";
            this.txtBuscaProduto.DebugMode = false;
            this.txtBuscaProduto.LiberadoQuandoCadastroUtilizado = false;
            this.txtBuscaProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBuscaProduto.Location = new System.Drawing.Point(83, 17);
            this.txtBuscaProduto.ModoBarcode = false;
            this.txtBuscaProduto.Name = "txtBuscaProduto";
            this.txtBuscaProduto.Size = new System.Drawing.Size(172, 20);
            this.txtBuscaProduto.TabIndex = 84;
            this.txtBuscaProduto.TextChanged += new System.EventHandler(this.txtBuscaProduto_TextChanged);
            this.txtBuscaProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscaProduto_KeyDown);
            // 
            // lnkDetalhesPrincipal
            // 
            this.lnkDetalhesPrincipal.AutoSize = true;
            this.lnkDetalhesPrincipal.Location = new System.Drawing.Point(345, 22);
            this.lnkDetalhesPrincipal.Name = "lnkDetalhesPrincipal";
            this.lnkDetalhesPrincipal.Size = new System.Drawing.Size(49, 13);
            this.lnkDetalhesPrincipal.TabIndex = 51;
            this.lnkDetalhesPrincipal.TabStop = true;
            this.lnkDetalhesPrincipal.Text = "Detalhes";
            this.lnkDetalhesPrincipal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetalhesPrincipal_LinkClicked);
            // 
            // chkNCM
            // 
            this.chkNCM.AutoSize = true;
            this.chkNCM.BindingField = "PossuiNbm";
            this.chkNCM.LiberadoQuandoCadastroUtilizado = false;
            this.chkNCM.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkNCM.Location = new System.Drawing.Point(211, 46);
            this.chkNCM.Name = "chkNCM";
            this.chkNCM.Size = new System.Drawing.Size(15, 14);
            this.chkNCM.TabIndex = 3;
            this.toolTip1.SetToolTip(this.chkNCM, "Utilize esse campo para que o sistema sobrescreva o valor do NCM padrão nos cadas" +
                    "tros por esse no momento da emissão da NFe");
            this.chkNCM.UseVisualStyleBackColor = true;
            this.chkNCM.CheckedChanged += new System.EventHandler(this.chkNCM_CheckedChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BindingField = null;
            this.lblTotal.LiberadoQuandoCadastroUtilizado = false;
            this.lblTotal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblTotal.Location = new System.Drawing.Point(854, 50);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.Text = "Total: ";
            // 
            // txtNCM
            // 
            this.txtNCM.BindingField = "Nbm";
            this.txtNCM.DebugMode = false;
            this.txtNCM.Enabled = false;
            this.txtNCM.LiberadoQuandoCadastroUtilizado = false;
            this.txtNCM.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtNCM.Location = new System.Drawing.Point(83, 43);
            this.txtNCM.MaxLength = 8;
            this.txtNCM.ModoBarcode = false;
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.Size = new System.Drawing.Size(122, 20);
            this.txtNCM.TabIndex = 4;
            this.toolTip1.SetToolTip(this.txtNCM, "Utilize esse campo para que o sistema sobrescreva o valor do NCM padrão nos cadas" +
                    "tros por esse no momento da emissão da NFe");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BindingField = null;
            this.label21.LiberadoQuandoCadastroUtilizado = false;
            this.label21.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label21.Location = new System.Drawing.Point(46, 46);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(31, 13);
            this.label21.TabIndex = 50;
            this.label21.Text = "NCM";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BindingField = null;
            this.label15.LiberadoQuandoCadastroUtilizado = false;
            this.label15.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label15.Location = new System.Drawing.Point(602, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Valor Unit.";
            // 
            // nudValorUnit
            // 
            this.nudValorUnit.BindingField = "PrecoUnitario";
            this.nudValorUnit.DecimalPlaces = 4;
            this.nudValorUnit.LiberadoQuandoCadastroUtilizado = false;
            this.nudValorUnit.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudValorUnit.Location = new System.Drawing.Point(664, 43);
            this.nudValorUnit.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudValorUnit.Name = "nudValorUnit";
            this.nudValorUnit.Size = new System.Drawing.Size(72, 20);
            this.nudValorUnit.TabIndex = 6;
            this.nudValorUnit.ValueChanged += new System.EventHandler(this.nudValorUnit_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Código Interno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(480, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Qtd";
            // 
            // nudQtd
            // 
            this.nudQtd.BindingField = "Quantidade";
            this.nudQtd.DecimalPlaces = 5;
            this.nudQtd.LiberadoQuandoCadastroUtilizado = false;
            this.nudQtd.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtd.Location = new System.Drawing.Point(510, 43);
            this.nudQtd.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQtd.Name = "nudQtd";
            this.nudQtd.Size = new System.Drawing.Size(66, 20);
            this.nudQtd.TabIndex = 5;
            this.nudQtd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtd.ValueChanged += new System.EventHandler(this.nudQtd_ValueChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BindingField = "ProdutoDescricaoCliente";
            this.txtDescricao.DebugMode = false;
            this.txtDescricao.LiberadoQuandoCadastroUtilizado = false;
            this.txtDescricao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtDescricao.Location = new System.Drawing.Point(765, 19);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.ModoBarcode = false;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(221, 20);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(683, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Descrição Fat.";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BindingField = "ProdutoCodigoCliente";
            this.txtCodigo.DebugMode = false;
            this.txtCodigo.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigo.Location = new System.Drawing.Point(511, 19);
            this.txtCodigo.MaxLength = 15;
            this.txtCodigo.ModoBarcode = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(162, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(403, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Código Faturamento";
            // 
            // gbxItem
            // 
            this.gbxItem.Controls.Add(this.splitContainer4);
            this.gbxItem.Controls.Add(this.label24);
            this.gbxItem.Controls.Add(this.comboBox4);
            this.gbxItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxItem.Enabled = false;
            this.gbxItem.Location = new System.Drawing.Point(0, 0);
            this.gbxItem.Name = "gbxItem";
            this.gbxItem.Size = new System.Drawing.Size(998, 196);
            this.gbxItem.TabIndex = 0;
            this.gbxItem.TabStop = false;
            this.gbxItem.Text = "Sublinhas (Kit)";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(3, 16);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.btnBuscaProdItem);
            this.splitContainer4.Panel1.Controls.Add(this.txtBuscaProdItem);
            this.splitContainer4.Panel1.Controls.Add(this.lnkDetalhesSub);
            this.splitContainer4.Panel1.Controls.Add(this.btnEditarItem);
            this.splitContainer4.Panel1.Controls.Add(this.label28);
            this.splitContainer4.Panel1.Controls.Add(this.txtCodigoItem);
            this.splitContainer4.Panel1.Controls.Add(this.label27);
            this.splitContainer4.Panel1.Controls.Add(this.label10);
            this.splitContainer4.Panel1.Controls.Add(this.txtDescricaoItem);
            this.splitContainer4.Panel1.Controls.Add(this.nudQtdItem);
            this.splitContainer4.Panel1.Controls.Add(this.label25);
            this.splitContainer4.Panel1.Controls.Add(this.btnAdicionar);
            this.splitContainer4.Panel1.Controls.Add(this.btnRemover);
            this.splitContainer4.Panel1.Controls.Add(this.btnConfirmarEdicao);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer4.Size = new System.Drawing.Size(992, 177);
            this.splitContainer4.SplitterDistance = 338;
            this.splitContainer4.TabIndex = 63;
            // 
            // btnBuscaProdItem
            // 
            this.btnBuscaProdItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscaProdItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnBuscaProdItem.Location = new System.Drawing.Point(258, 5);
            this.btnBuscaProdItem.Name = "btnBuscaProdItem";
            this.btnBuscaProdItem.Size = new System.Drawing.Size(78, 23);
            this.btnBuscaProdItem.TabIndex = 87;
            this.btnBuscaProdItem.Text = "Selecionar";
            this.btnBuscaProdItem.UseVisualStyleBackColor = true;
            this.btnBuscaProdItem.Click += new System.EventHandler(this.btnBuscaProdItem_Click);
            // 
            // txtBuscaProdItem
            // 
            this.txtBuscaProdItem.BindingField = null;
            this.txtBuscaProdItem.DebugMode = false;
            this.txtBuscaProdItem.LiberadoQuandoCadastroUtilizado = false;
            this.txtBuscaProdItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBuscaProdItem.Location = new System.Drawing.Point(94, 7);
            this.txtBuscaProdItem.ModoBarcode = false;
            this.txtBuscaProdItem.Name = "txtBuscaProdItem";
            this.txtBuscaProdItem.Size = new System.Drawing.Size(158, 20);
            this.txtBuscaProdItem.TabIndex = 86;
            this.txtBuscaProdItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscaProdItem_KeyDown);
            // 
            // lnkDetalhesSub
            // 
            this.lnkDetalhesSub.AutoSize = true;
            this.lnkDetalhesSub.Location = new System.Drawing.Point(203, 31);
            this.lnkDetalhesSub.Name = "lnkDetalhesSub";
            this.lnkDetalhesSub.Size = new System.Drawing.Size(49, 13);
            this.lnkDetalhesSub.TabIndex = 51;
            this.lnkDetalhesSub.TabStop = true;
            this.lnkDetalhesSub.Text = "Detalhes";
            this.lnkDetalhesSub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetalhesSub_LinkClicked);
            // 
            // btnEditarItem
            // 
            this.btnEditarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditarItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditarItem.Location = new System.Drawing.Point(12, 123);
            this.btnEditarItem.Name = "btnEditarItem";
            this.btnEditarItem.Size = new System.Drawing.Size(103, 23);
            this.btnEditarItem.TabIndex = 63;
            this.btnEditarItem.Text = "Editar Subitem";
            this.btnEditarItem.UseVisualStyleBackColor = true;
            this.btnEditarItem.Click += new System.EventHandler(this.btnEditarItem_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BindingField = null;
            this.label28.LiberadoQuandoCadastroUtilizado = false;
            this.label28.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label28.Location = new System.Drawing.Point(2, 48);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 13);
            this.label28.TabIndex = 28;
            this.label28.Text = "Cód. Faturamento";
            // 
            // txtCodigoItem
            // 
            this.txtCodigoItem.BindingField = null;
            this.txtCodigoItem.DebugMode = false;
            this.txtCodigoItem.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigoItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigoItem.Location = new System.Drawing.Point(94, 45);
            this.txtCodigoItem.MaxLength = 15;
            this.txtCodigoItem.ModoBarcode = false;
            this.txtCodigoItem.Name = "txtCodigoItem";
            this.txtCodigoItem.Size = new System.Drawing.Size(158, 20);
            this.txtCodigoItem.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BindingField = null;
            this.label27.LiberadoQuandoCadastroUtilizado = false;
            this.label27.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label27.Location = new System.Drawing.Point(38, 74);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 13);
            this.label27.TabIndex = 29;
            this.label27.Text = "Descrição";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BindingField = null;
            this.label10.LiberadoQuandoCadastroUtilizado = false;
            this.label10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label10.Location = new System.Drawing.Point(12, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Qtd";
            // 
            // txtDescricaoItem
            // 
            this.txtDescricaoItem.BindingField = null;
            this.txtDescricaoItem.DebugMode = false;
            this.txtDescricaoItem.LiberadoQuandoCadastroUtilizado = false;
            this.txtDescricaoItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtDescricaoItem.Location = new System.Drawing.Point(94, 71);
            this.txtDescricaoItem.MaxLength = 255;
            this.txtDescricaoItem.ModoBarcode = false;
            this.txtDescricaoItem.Name = "txtDescricaoItem";
            this.txtDescricaoItem.Size = new System.Drawing.Size(158, 20);
            this.txtDescricaoItem.TabIndex = 2;
            // 
            // nudQtdItem
            // 
            this.nudQtdItem.BindingField = null;
            this.nudQtdItem.DecimalPlaces = 5;
            this.nudQtdItem.LiberadoQuandoCadastroUtilizado = false;
            this.nudQtdItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdItem.Location = new System.Drawing.Point(39, 93);
            this.nudQtdItem.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nudQtdItem.Name = "nudQtdItem";
            this.nudQtdItem.Size = new System.Drawing.Size(66, 20);
            this.nudQtdItem.TabIndex = 4;
            this.nudQtdItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BindingField = null;
            this.label25.LiberadoQuandoCadastroUtilizado = false;
            this.label25.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label25.Location = new System.Drawing.Point(17, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(76, 13);
            this.label25.TabIndex = 32;
            this.label25.Text = "Código Interno";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdicionar.LiberadoQuandoCadastroUtilizado = false;
            this.btnAdicionar.Location = new System.Drawing.Point(121, 123);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(103, 23);
            this.btnAdicionar.TabIndex = 6;
            this.btnAdicionar.Text = "Adicionar Subitem";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemover.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemover.Location = new System.Drawing.Point(13, 151);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(102, 23);
            this.btnRemover.TabIndex = 7;
            this.btnRemover.Text = "Remover Subitem";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnConfirmarEdicao
            // 
            this.btnConfirmarEdicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmarEdicao.LiberadoQuandoCadastroUtilizado = false;
            this.btnConfirmarEdicao.Location = new System.Drawing.Point(11, 123);
            this.btnConfirmarEdicao.Name = "btnConfirmarEdicao";
            this.btnConfirmarEdicao.Size = new System.Drawing.Size(103, 23);
            this.btnConfirmarEdicao.TabIndex = 64;
            this.btnConfirmarEdicao.Text = "Confirmar Edição";
            this.btnConfirmarEdicao.UseVisualStyleBackColor = true;
            this.btnConfirmarEdicao.Visible = false;
            this.btnConfirmarEdicao.Click += new System.EventHandler(this.btnConfirmarEdicao_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.CacheDados = null;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(650, 177);
            this.dataGridView1.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BindingField = null;
            this.label24.LiberadoQuandoCadastroUtilizado = false;
            this.label24.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label24.Location = new System.Drawing.Point(235, -18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "CST";
            // 
            // comboBox4
            // 
            this.comboBox4.BindingField = null;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.LiberadoQuandoCadastroUtilizado = false;
            this.comboBox4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.comboBox4.Location = new System.Drawing.Point(269, -21);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(223, 21);
            this.comboBox4.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1004, 649);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informações Adicionais";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.txtObservacaoEspelhoPed);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(985, 89);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Espelho do Pedido";
            // 
            // txtObservacaoEspelhoPed
            // 
            this.txtObservacaoEspelhoPed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacaoEspelhoPed.BindingField = "ObsPadraoEspelho";
            this.txtObservacaoEspelhoPed.DebugMode = false;
            this.txtObservacaoEspelhoPed.LiberadoQuandoCadastroUtilizado = false;
            this.txtObservacaoEspelhoPed.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtObservacaoEspelhoPed.Location = new System.Drawing.Point(129, 19);
            this.txtObservacaoEspelhoPed.ModoBarcode = false;
            this.txtObservacaoEspelhoPed.Multiline = true;
            this.txtObservacaoEspelhoPed.Name = "txtObservacaoEspelhoPed";
            this.txtObservacaoEspelhoPed.Size = new System.Drawing.Size(832, 57);
            this.txtObservacaoEspelhoPed.TabIndex = 1;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BindingField = null;
            this.label36.LiberadoQuandoCadastroUtilizado = false;
            this.label36.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label36.Location = new System.Drawing.Point(21, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(102, 13);
            this.label36.TabIndex = 0;
            this.label36.Text = "Observação Padrão";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grpComissaoVendedor);
            this.tabPage4.Controls.Add(this.grpComissaoRepresentante);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1004, 649);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Comissões";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grpComissaoVendedor
            // 
            this.grpComissaoVendedor.Controls.Add(this.iwtLabel2);
            this.grpComissaoVendedor.Controls.Add(this.nudComissaoVendedor);
            this.grpComissaoVendedor.Controls.Add(this.cmbVendedor);
            this.grpComissaoVendedor.Controls.Add(this.iwtLabel3);
            this.grpComissaoVendedor.Controls.Add(this.chkVendedor);
            this.grpComissaoVendedor.Location = new System.Drawing.Point(8, 87);
            this.grpComissaoVendedor.Name = "grpComissaoVendedor";
            this.grpComissaoVendedor.Size = new System.Drawing.Size(988, 66);
            this.grpComissaoVendedor.TabIndex = 1;
            this.grpComissaoVendedor.TabStop = false;
            this.grpComissaoVendedor.Text = "Comissão Vendedor";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(26, 20);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(53, 13);
            this.iwtLabel2.TabIndex = 13;
            this.iwtLabel2.Text = "Vendedor";
            // 
            // nudComissaoVendedor
            // 
            this.nudComissaoVendedor.BindingField = "PercComissaoVendedor";
            this.nudComissaoVendedor.DecimalPlaces = 2;
            this.nudComissaoVendedor.Enabled = false;
            this.nudComissaoVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.nudComissaoVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudComissaoVendedor.Location = new System.Drawing.Point(86, 40);
            this.nudComissaoVendedor.Name = "nudComissaoVendedor";
            this.nudComissaoVendedor.Size = new System.Drawing.Size(120, 20);
            this.nudComissaoVendedor.TabIndex = 2;
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVendedor.BindingField = "Vendedor";
            this.cmbVendedor.ColumnsToDisplay = null;
            this.cmbVendedor.DisableAutoSelectOnEmpty = false;
            this.cmbVendedor.DropDownHeight = 1;
            this.cmbVendedor.Enabled = false;
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.IntegralHeight = false;
            this.cmbVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.cmbVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbVendedor.Location = new System.Drawing.Point(85, 16);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.SelectedRow = null;
            this.cmbVendedor.Size = new System.Drawing.Size(872, 21);
            this.cmbVendedor.TabIndex = 1;
            this.cmbVendedor.Table = null;
            this.cmbVendedor.SelectedIndexChanged += new System.EventHandler(this.cmbVendedor_SelectedIndexChanged);
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(15, 44);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(66, 13);
            this.iwtLabel3.TabIndex = 16;
            this.iwtLabel3.Text = "Comissão(%)";
            // 
            // chkVendedor
            // 
            this.chkVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVendedor.AutoSize = true;
            this.chkVendedor.BindingField = "PossuiVendedor";
            this.chkVendedor.LiberadoQuandoCadastroUtilizado = false;
            this.chkVendedor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkVendedor.Location = new System.Drawing.Point(963, 20);
            this.chkVendedor.Name = "chkVendedor";
            this.chkVendedor.Size = new System.Drawing.Size(15, 14);
            this.chkVendedor.TabIndex = 0;
            this.chkVendedor.UseVisualStyleBackColor = true;
            this.chkVendedor.CheckedChanged += new System.EventHandler(this.chkVendedor_CheckedChanged);
            // 
            // grpComissaoRepresentante
            // 
            this.grpComissaoRepresentante.Controls.Add(this.iwtLabel1);
            this.grpComissaoRepresentante.Controls.Add(this.nudComissaoRepresentante);
            this.grpComissaoRepresentante.Controls.Add(this.cmbRepresentante);
            this.grpComissaoRepresentante.Controls.Add(this.label34);
            this.grpComissaoRepresentante.Controls.Add(this.chkRepresentante);
            this.grpComissaoRepresentante.Location = new System.Drawing.Point(8, 6);
            this.grpComissaoRepresentante.Name = "grpComissaoRepresentante";
            this.grpComissaoRepresentante.Size = new System.Drawing.Size(988, 75);
            this.grpComissaoRepresentante.TabIndex = 0;
            this.grpComissaoRepresentante.TabStop = false;
            this.grpComissaoRepresentante.Text = "Comissão Representante";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(6, 23);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(77, 13);
            this.iwtLabel1.TabIndex = 13;
            this.iwtLabel1.Text = "Representante";
            // 
            // nudComissaoRepresentante
            // 
            this.nudComissaoRepresentante.BindingField = "PercComissaoRepresentante";
            this.nudComissaoRepresentante.DecimalPlaces = 2;
            this.nudComissaoRepresentante.Enabled = false;
            this.nudComissaoRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.nudComissaoRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudComissaoRepresentante.Location = new System.Drawing.Point(86, 46);
            this.nudComissaoRepresentante.Name = "nudComissaoRepresentante";
            this.nudComissaoRepresentante.Size = new System.Drawing.Size(120, 20);
            this.nudComissaoRepresentante.TabIndex = 4;
            // 
            // cmbRepresentante
            // 
            this.cmbRepresentante.BindingField = "Representante";
            this.cmbRepresentante.ColumnsToDisplay = null;
            this.cmbRepresentante.DisableAutoSelectOnEmpty = false;
            this.cmbRepresentante.DropDownHeight = 1;
            this.cmbRepresentante.Enabled = false;
            this.cmbRepresentante.FormattingEnabled = true;
            this.cmbRepresentante.IntegralHeight = false;
            this.cmbRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.cmbRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbRepresentante.Location = new System.Drawing.Point(85, 19);
            this.cmbRepresentante.Name = "cmbRepresentante";
            this.cmbRepresentante.SelectedRow = null;
            this.cmbRepresentante.Size = new System.Drawing.Size(872, 21);
            this.cmbRepresentante.TabIndex = 3;
            this.cmbRepresentante.Table = null;
            this.cmbRepresentante.SelectedIndexChanged += new System.EventHandler(this.cmbRepresentante_SelectedIndexChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BindingField = null;
            this.label34.LiberadoQuandoCadastroUtilizado = false;
            this.label34.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label34.Location = new System.Drawing.Point(15, 50);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(66, 13);
            this.label34.TabIndex = 16;
            this.label34.Text = "Comissão(%)";
            // 
            // chkRepresentante
            // 
            this.chkRepresentante.AutoSize = true;
            this.chkRepresentante.BindingField = "PossuiRepresentante";
            this.chkRepresentante.LiberadoQuandoCadastroUtilizado = false;
            this.chkRepresentante.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkRepresentante.Location = new System.Drawing.Point(963, 23);
            this.chkRepresentante.Name = "chkRepresentante";
            this.chkRepresentante.Size = new System.Drawing.Size(15, 14);
            this.chkRepresentante.TabIndex = 2;
            this.chkRepresentante.UseVisualStyleBackColor = true;
            this.chkRepresentante.CheckedChanged += new System.EventHandler(this.chkRepresentante_CheckedChanged);
            // 
            // btnCopiar
            // 
            this.btnCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCopiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCopiar.Location = new System.Drawing.Point(407, 12);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(205, 23);
            this.btnCopiar.TabIndex = 2;
            this.btnCopiar.Text = "Copiar Orçamento";
            this.btnCopiar.UseVisualStyleBackColor = false;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "C:\\";
            this.openFileDialog1.Title = "Localizar Arquivos";
            // 
            // CadOrcamentoItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1012, 726);
            this.Name = "CadOrcamentoItemForm";
            this.Text = "Orçamento";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadOrcamentoForm_FormClosing);
            this.Shown += new System.EventHandler(this.CadOrcamentoForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrete)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataPedido)).EndInit();
            this.grbCancelamento.ResumeLayout(false);
            this.grbCancelamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpCancelamentoData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDataEntrega)).EndInit();
            this.gbxPrincipal.ResumeLayout(false);
            this.gbxPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtd)).EndInit();
            this.gbxItem.ResumeLayout(false);
            this.gbxItem.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.grpComissaoVendedor.ResumeLayout(false);
            this.grpComissaoVendedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoVendedor)).EndInit();
            this.grpComissaoRepresentante.ResumeLayout(false);
            this.grpComissaoRepresentante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudComissaoRepresentante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


        private IWTDotNetLib.IWTButton btnCopiar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private IWTDotNetLib.IWTNumericUpDown nudFrete;
        private IWTDotNetLib.IWTLabel label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTLabel label35;
        private IWTDotNetLib.IWTTextBox txtOrdemVenda;
        private IWTDotNetLib.IWTTextBox txtProjeto;
        private IWTDotNetLib.IWTLabel label19;
        private IWTDotNetLib.IWTTextBox txtArmazenagem;
        private IWTDotNetLib.IWTLabel label20;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTDotNetLib.IWTCheckBox cbxEntregaParc;
        private IWTDotNetLib.IWTCheckBox cbxVolumeUnico;
        private IWTDotNetLib.IWTCheckBox chkExportacao;
        private System.Windows.Forms.GroupBox groupBox7;
        private IWTDotNetLib.IWTLabel label33;
        private IWTDotNetLib.IWTCheckBox chkCentroCusto;
        private IWTDotNetLib.IWTButton btnCentroCusto;
        private IWTDotNetLib.IWTTextBox txtCentroCusto;
        private IWTDotNetLib.IWTLabel label9;
        private IWTDotNetLib.IWTCheckBox chkContaBancaria;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbContaBancaria;
        private IWTDotNetLib.IWTLabel label32;
        private IWTDotNetLib.IWTCheckBox chkTipoKit;
        private IWTDotNetLib.IWTComboBox cmbTipoKit;
        private IWTDotNetLib.IWTLabel label8;
        private IWTDotNetLib.IWTTextBox txtInfoEspeciais;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTLabel label31;
        private IWTDotNetLib.IWTDateTimePicker dtpDataPedido;
        private System.Windows.Forms.GroupBox grbCancelamento;
        private IWTDotNetLib.IWTTextBox txtCancelamentoJustificativa;
        private IWTDotNetLib.IWTLabel label30;
        private IWTDotNetLib.IWTDateTimePicker dtpCancelamentoData;
        private IWTDotNetLib.IWTLabel label29;
        private IWTDotNetLib.IWTTextBox txtCancelamentoUsuario;
        private IWTDotNetLib.IWTLabel label26;
        private IWTDotNetLib.IWTButton btnVariaveis;
        private IWTDotNetLib.IWTLabel label22;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbCliente;
        private IWTDotNetLib.IWTDateTimePicker dtpDataEntrega;
        private IWTDotNetLib.IWTLabel label7;
        private IWTDotNetLib.IWTLabel label17;
        private IWTDotNetLib.IWTMaskedTextBox txtOc;
        private IWTDotNetLib.IWTLabel label23;
        private IWTDotNetLib.IWTLabel label18;
        private IWTDotNetLib.IWTComboBox cmbOperacao;
        private IWTDotNetLib.IWTMaskedTextBox txtPos;
        private System.Windows.Forms.GroupBox gbxPrincipal;
        private IWTDotNetLib.IWTButton btnBuscaProduto;
        private IWTDotNetLib.IWTTextBox txtBuscaProduto;
        private System.Windows.Forms.LinkLabel lnkDetalhesPrincipal;
        private IWTDotNetLib.IWTCheckBox chkNCM;
        private IWTDotNetLib.IWTLabel lblTotal;
        private IWTDotNetLib.IWTTextBox txtNCM;
        private IWTDotNetLib.IWTLabel label21;
        private IWTDotNetLib.IWTLabel label15;
        private IWTDotNetLib.IWTNumericUpDown nudValorUnit;
        private IWTDotNetLib.IWTLabel label1;
        private IWTDotNetLib.IWTLabel label5;
        private IWTDotNetLib.IWTNumericUpDown nudQtd;
        private IWTDotNetLib.IWTTextBox txtDescricao;
        private IWTDotNetLib.IWTLabel label2;
        private IWTDotNetLib.IWTTextBox txtCodigo;
        private IWTDotNetLib.IWTLabel label4;
        private System.Windows.Forms.GroupBox gbxItem;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private IWTDotNetLib.IWTButton btnBuscaProdItem;
        private IWTDotNetLib.IWTTextBox txtBuscaProdItem;
        private System.Windows.Forms.LinkLabel lnkDetalhesSub;
        private IWTDotNetLib.IWTButton btnEditarItem;
        private IWTDotNetLib.IWTLabel label28;
        private IWTDotNetLib.IWTTextBox txtCodigoItem;
        private IWTDotNetLib.IWTLabel label27;
        private IWTDotNetLib.IWTLabel label10;
        private IWTDotNetLib.IWTTextBox txtDescricaoItem;
        private IWTDotNetLib.IWTNumericUpDown nudQtdItem;
        private IWTDotNetLib.IWTLabel label25;
        private IWTDotNetLib.IWTButton btnAdicionar;
        private IWTDotNetLib.IWTButton btnRemover;
        private IWTDotNetLib.IWTButton btnConfirmarEdicao;
        private IWTDotNetLib.IWTDataGridView dataGridView1;
        private IWTDotNetLib.IWTLabel label24;
        private IWTDotNetLib.IWTComboBox comboBox4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox6;
        private IWTDotNetLib.IWTLabel label36;
        private IWTDotNetLib.IWTTextBox txtObservacaoEspelhoPed;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private TabPage tabPage4;
        private GroupBox grpComissaoRepresentante;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTNumericUpDown nudComissaoRepresentante;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbRepresentante;
        private IWTDotNetLib.IWTLabel label34;
        private IWTDotNetLib.IWTCheckBox chkRepresentante;
        private GroupBox grpComissaoVendedor;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTNumericUpDown nudComissaoVendedor;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbVendedor;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTCheckBox chkVendedor;
        private IWTDotNetLib.IWTEntitySelection ensFormaPagamento;
    }
}