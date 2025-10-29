namespace BibliotecaCadastrosBasicos
{
    partial class CadClassificacaoProdutoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbComprador = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.cbxComprador = new IWTDotNetLib.IWTCheckBox(this.components);
            this.TipoConsumoEstoque_MateriaPrimaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.TipoConsumoEstoque_MateriaPrima = new IWTDotNetLib.IWTRadioButton(this.components);
            this.TipoConsumoEstoque_ConsumoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.TipoConsumoEstoque_Consumo = new IWTDotNetLib.IWTRadioButton(this.components);
            this.TipoConsumoEstoque_EscolherLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.TipoConsumoEstoque_Escolher = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.ConfiguracaoAutomatica = new IWTDotNetLib.IWTCheckBox(this.components);
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.ConfiguracaoAutomaticaReferencia_DataCadastro = new IWTDotNetLib.IWTRadioButton(this.components);
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.ConfiguracaoAutomaticaReferencia_DataEntrega = new IWTDotNetLib.IWTRadioButton(this.components);
            this.ConfiguracaoAutomaticaIntervaloLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.ConfiguracaoAutomaticaIntervalo = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.grbConfiguracaoAutomatica = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConfiguracaoAutomaticaIntervalo)).BeginInit();
            this.grbConfiguracaoAutomatica.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbConfiguracaoAutomatica);
            this.splitContainer1.Panel1.Controls.Add(this.ConfiguracaoAutomatica);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_MateriaPrimaLabel);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_MateriaPrima);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_ConsumoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_Consumo);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_EscolherLabel);
            this.splitContainer1.Panel1.Controls.Add(this.TipoConsumoEstoque_Escolher);
            this.splitContainer1.Panel1.Controls.Add(this.cbxComprador);
            this.splitContainer1.Panel1.Controls.Add(this.cmbComprador);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(571, 485);
            this.splitContainer1.SplitterDistance = 419;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(484, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblRevisao);
            this.groupBox1.Controls.Add(this.lblRevisaoData);
            this.groupBox1.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox1.Controls.Add(this.iwtLabel7);
            this.groupBox1.Controls.Add(this.iwtLabel6);
            this.groupBox1.Controls.Add(this.iwtLabel5);
            this.groupBox1.Location = new System.Drawing.Point(17, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Revisão";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisao.Location = new System.Drawing.Point(100, 62);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 5;
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(100, 39);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 4;
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(100, 16);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 3;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(16, 62);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel7.TabIndex = 2;
            this.iwtLabel7.Text = "Justificativa";
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(48, 39);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(30, 13);
            this.iwtLabel6.TabIndex = 1;
            this.iwtLabel6.Text = "Data";
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(35, 16);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel5.TabIndex = 0;
            this.iwtLabel5.Text = "Usuário";
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(179, 37);
            this.iwtTextBox2.MaxLength = 255;
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.ModoBusca = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.NaoLimparDepoisBarcode = false;
            this.iwtTextBox2.Size = new System.Drawing.Size(362, 20);
            this.iwtTextBox2.TabIndex = 1;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(118, 40);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel2.TabIndex = 12;
            this.iwtLabel2.Text = "Descrição";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(105, 14);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel1.TabIndex = 10;
            this.iwtLabel1.Text = "Identificação";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(115, 66);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(58, 13);
            this.iwtLabel3.TabIndex = 15;
            this.iwtLabel3.Text = "Comprador";
            // 
            // cmbComprador
            // 
            this.cmbComprador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbComprador.BindingField = "Comprador";
            this.cmbComprador.ColumnsToDisplay = null;
            this.cmbComprador.DisableAutoSelectOnEmpty = false;
            this.cmbComprador.DropDownHeight = 1;
            this.cmbComprador.Enabled = false;
            this.cmbComprador.FormattingEnabled = true;
            this.cmbComprador.IntegralHeight = false;
            this.cmbComprador.LiberadoQuandoCadastroUtilizado = true;
            this.cmbComprador.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbComprador.Location = new System.Drawing.Point(179, 63);
            this.cmbComprador.Name = "cmbComprador";
            this.cmbComprador.SelectedRow = null;
            this.cmbComprador.Size = new System.Drawing.Size(362, 21);
            this.cmbComprador.TabIndex = 3;
            this.cmbComprador.Table = null;
            // 
            // cbxComprador
            // 
            this.cbxComprador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxComprador.AutoSize = true;
            this.cbxComprador.BindingField = "CompradorDef";
            this.cbxComprador.LiberadoQuandoCadastroUtilizado = true;
            this.cbxComprador.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cbxComprador.Location = new System.Drawing.Point(547, 66);
            this.cbxComprador.Name = "cbxComprador";
            this.cbxComprador.Size = new System.Drawing.Size(15, 14);
            this.cbxComprador.TabIndex = 2;
            this.cbxComprador.UseVisualStyleBackColor = true;
            this.cbxComprador.CheckedChanged += new System.EventHandler(this.cbxComprador_CheckedChanged);
            // 
            // TipoConsumoEstoque_MateriaPrimaLabel
            // 
            this.TipoConsumoEstoque_MateriaPrimaLabel.AutoSize = true;
            this.TipoConsumoEstoque_MateriaPrimaLabel.BindingField = null;
            this.TipoConsumoEstoque_MateriaPrimaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_MateriaPrimaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_MateriaPrimaLabel.Location = new System.Drawing.Point(102, 111);
            this.TipoConsumoEstoque_MateriaPrimaLabel.Name = "TipoConsumoEstoque_MateriaPrimaLabel";
            this.TipoConsumoEstoque_MateriaPrimaLabel.Size = new System.Drawing.Size(71, 13);
            this.TipoConsumoEstoque_MateriaPrimaLabel.TabIndex = 21;
            this.TipoConsumoEstoque_MateriaPrimaLabel.Text = "Matéria Prima";
            // 
            // TipoConsumoEstoque_MateriaPrima
            // 
            this.TipoConsumoEstoque_MateriaPrima.AutoSize = true;
            this.TipoConsumoEstoque_MateriaPrima.BindingField = "TipoConsumoEstoque_MateriaPrima";
            this.TipoConsumoEstoque_MateriaPrima.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_MateriaPrima.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_MateriaPrima.Location = new System.Drawing.Point(179, 111);
            this.TipoConsumoEstoque_MateriaPrima.Name = "TipoConsumoEstoque_MateriaPrima";
            this.TipoConsumoEstoque_MateriaPrima.Size = new System.Drawing.Size(14, 13);
            this.TipoConsumoEstoque_MateriaPrima.TabIndex = 4;
            this.TipoConsumoEstoque_MateriaPrima.UseVisualStyleBackColor = true;
            // 
            // TipoConsumoEstoque_ConsumoLabel
            // 
            this.TipoConsumoEstoque_ConsumoLabel.AutoSize = true;
            this.TipoConsumoEstoque_ConsumoLabel.BindingField = null;
            this.TipoConsumoEstoque_ConsumoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_ConsumoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_ConsumoLabel.Location = new System.Drawing.Point(122, 138);
            this.TipoConsumoEstoque_ConsumoLabel.Name = "TipoConsumoEstoque_ConsumoLabel";
            this.TipoConsumoEstoque_ConsumoLabel.Size = new System.Drawing.Size(51, 13);
            this.TipoConsumoEstoque_ConsumoLabel.TabIndex = 22;
            this.TipoConsumoEstoque_ConsumoLabel.Text = "Consumo";
            // 
            // TipoConsumoEstoque_Consumo
            // 
            this.TipoConsumoEstoque_Consumo.AutoSize = true;
            this.TipoConsumoEstoque_Consumo.BindingField = "TipoConsumoEstoque_Consumo";
            this.TipoConsumoEstoque_Consumo.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_Consumo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_Consumo.Location = new System.Drawing.Point(179, 138);
            this.TipoConsumoEstoque_Consumo.Name = "TipoConsumoEstoque_Consumo";
            this.TipoConsumoEstoque_Consumo.Size = new System.Drawing.Size(14, 13);
            this.TipoConsumoEstoque_Consumo.TabIndex = 5;
            this.TipoConsumoEstoque_Consumo.UseVisualStyleBackColor = true;
            // 
            // TipoConsumoEstoque_EscolherLabel
            // 
            this.TipoConsumoEstoque_EscolherLabel.AutoSize = true;
            this.TipoConsumoEstoque_EscolherLabel.BindingField = null;
            this.TipoConsumoEstoque_EscolherLabel.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_EscolherLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_EscolherLabel.Location = new System.Drawing.Point(12, 165);
            this.TipoConsumoEstoque_EscolherLabel.Name = "TipoConsumoEstoque_EscolherLabel";
            this.TipoConsumoEstoque_EscolherLabel.Size = new System.Drawing.Size(161, 13);
            this.TipoConsumoEstoque_EscolherLabel.TabIndex = 23;
            this.TipoConsumoEstoque_EscolherLabel.Text = "Definir na Solicitação de Compra";
            // 
            // TipoConsumoEstoque_Escolher
            // 
            this.TipoConsumoEstoque_Escolher.AutoSize = true;
            this.TipoConsumoEstoque_Escolher.BindingField = "TipoConsumoEstoque_Escolher";
            this.TipoConsumoEstoque_Escolher.LiberadoQuandoCadastroUtilizado = false;
            this.TipoConsumoEstoque_Escolher.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoConsumoEstoque_Escolher.Location = new System.Drawing.Point(179, 165);
            this.TipoConsumoEstoque_Escolher.Name = "TipoConsumoEstoque_Escolher";
            this.TipoConsumoEstoque_Escolher.Size = new System.Drawing.Size(14, 13);
            this.TipoConsumoEstoque_Escolher.TabIndex = 6;
            this.TipoConsumoEstoque_Escolher.UseVisualStyleBackColor = true;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Identificacao";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(179, 11);
            this.iwtTextBox1.MaxLength = 255;
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(159, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // ConfiguracaoAutomatica
            // 
            this.ConfiguracaoAutomatica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfiguracaoAutomatica.AutoSize = true;
            this.ConfiguracaoAutomatica.BindingField = "ConfiguracaoAutomatica";
            this.ConfiguracaoAutomatica.LiberadoQuandoCadastroUtilizado = false;
            this.ConfiguracaoAutomatica.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConfiguracaoAutomatica.Location = new System.Drawing.Point(547, 249);
            this.ConfiguracaoAutomatica.Name = "ConfiguracaoAutomatica";
            this.ConfiguracaoAutomatica.Size = new System.Drawing.Size(15, 14);
            this.ConfiguracaoAutomatica.TabIndex = 25;
            this.ConfiguracaoAutomatica.UseVisualStyleBackColor = true;
            this.ConfiguracaoAutomatica.CheckedChanged += new System.EventHandler(this.ConfiguracaoAutomatica_CheckedChanged);
            // 
            // ConfiguracaoAutomaticaReferencia_DataCadastroLabel
            // 
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.AutoSize = true;
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.BindingField = null;
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.Location = new System.Drawing.Point(6, 18);
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.Name = "ConfiguracaoAutomaticaReferencia_DataCadastroLabel";
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.Size = new System.Drawing.Size(90, 13);
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.TabIndex = 26;
            this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel.Text = "Data de Cadastro";
            // 
            // ConfiguracaoAutomaticaReferencia_DataCadastro
            // 
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.AutoSize = true;
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.BindingField = "ConfiguracaoAutomaticaReferencia_DataCadastro";
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.LiberadoQuandoCadastroUtilizado = false;
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.Location = new System.Drawing.Point(102, 18);
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.Name = "ConfiguracaoAutomaticaReferencia_DataCadastro";
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.Size = new System.Drawing.Size(14, 13);
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.TabIndex = 27;
            this.ConfiguracaoAutomaticaReferencia_DataCadastro.UseVisualStyleBackColor = true;
            // 
            // ConfiguracaoAutomaticaReferencia_DataEntregaLabel
            // 
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.AutoSize = true;
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.BindingField = null;
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.Location = new System.Drawing.Point(11, 45);
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.Name = "ConfiguracaoAutomaticaReferencia_DataEntregaLabel";
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.Size = new System.Drawing.Size(85, 13);
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.TabIndex = 28;
            this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel.Text = "Data de Entrega";
            // 
            // ConfiguracaoAutomaticaReferencia_DataEntrega
            // 
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.AutoSize = true;
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.BindingField = "ConfiguracaoAutomaticaReferencia_DataEntrega";
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.LiberadoQuandoCadastroUtilizado = false;
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.Location = new System.Drawing.Point(102, 45);
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.Name = "ConfiguracaoAutomaticaReferencia_DataEntrega";
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.Size = new System.Drawing.Size(14, 13);
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.TabIndex = 29;
            this.ConfiguracaoAutomaticaReferencia_DataEntrega.UseVisualStyleBackColor = true;
            // 
            // ConfiguracaoAutomaticaIntervaloLabel
            // 
            this.ConfiguracaoAutomaticaIntervaloLabel.AutoSize = true;
            this.ConfiguracaoAutomaticaIntervaloLabel.BindingField = null;
            this.ConfiguracaoAutomaticaIntervaloLabel.LiberadoQuandoCadastroUtilizado = false;
            this.ConfiguracaoAutomaticaIntervaloLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConfiguracaoAutomaticaIntervaloLabel.Location = new System.Drawing.Point(20, 72);
            this.ConfiguracaoAutomaticaIntervaloLabel.Name = "ConfiguracaoAutomaticaIntervaloLabel";
            this.ConfiguracaoAutomaticaIntervaloLabel.Size = new System.Drawing.Size(76, 13);
            this.ConfiguracaoAutomaticaIntervaloLabel.TabIndex = 30;
            this.ConfiguracaoAutomaticaIntervaloLabel.Text = "Intervalo (dias)";
            // 
            // ConfiguracaoAutomaticaIntervalo
            // 
            this.ConfiguracaoAutomaticaIntervalo.BindingField = "ConfiguracaoAutomaticaIntervalo";
            this.ConfiguracaoAutomaticaIntervalo.LiberadoQuandoCadastroUtilizado = false;
            this.ConfiguracaoAutomaticaIntervalo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ConfiguracaoAutomaticaIntervalo.Location = new System.Drawing.Point(102, 68);
            this.ConfiguracaoAutomaticaIntervalo.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.ConfiguracaoAutomaticaIntervalo.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.ConfiguracaoAutomaticaIntervalo.Name = "ConfiguracaoAutomaticaIntervalo";
            this.ConfiguracaoAutomaticaIntervalo.Size = new System.Drawing.Size(150, 20);
            this.ConfiguracaoAutomaticaIntervalo.TabIndex = 31;
            // 
            // grbConfiguracaoAutomatica
            // 
            this.grbConfiguracaoAutomatica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbConfiguracaoAutomatica.Controls.Add(this.ConfiguracaoAutomaticaIntervalo);
            this.grbConfiguracaoAutomatica.Controls.Add(this.ConfiguracaoAutomaticaIntervaloLabel);
            this.grbConfiguracaoAutomatica.Controls.Add(this.ConfiguracaoAutomaticaReferencia_DataCadastroLabel);
            this.grbConfiguracaoAutomatica.Controls.Add(this.ConfiguracaoAutomaticaReferencia_DataEntrega);
            this.grbConfiguracaoAutomatica.Controls.Add(this.ConfiguracaoAutomaticaReferencia_DataCadastro);
            this.grbConfiguracaoAutomatica.Controls.Add(this.ConfiguracaoAutomaticaReferencia_DataEntregaLabel);
            this.grbConfiguracaoAutomatica.Location = new System.Drawing.Point(17, 193);
            this.grbConfiguracaoAutomatica.Name = "grbConfiguracaoAutomatica";
            this.grbConfiguracaoAutomatica.Size = new System.Drawing.Size(524, 112);
            this.grbConfiguracaoAutomatica.TabIndex = 32;
            this.grbConfiguracaoAutomatica.TabStop = false;
            this.grbConfiguracaoAutomatica.Text = "Configuração Automatica";
            // 
            // CadClassificacaoProdutoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(571, 485);
            this.Name = "CadClassificacaoProdutoForm";
            this.Text = "Classificação de Itens na Expedição";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConfiguracaoAutomaticaIntervalo)).EndInit();
            this.grbConfiguracaoAutomatica.ResumeLayout(false);
            this.grbConfiguracaoAutomatica.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbComprador;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTCheckBox cbxComprador;
        private IWTDotNetLib.IWTLabel TipoConsumoEstoque_MateriaPrimaLabel;
        private IWTDotNetLib.IWTRadioButton TipoConsumoEstoque_MateriaPrima;
        private IWTDotNetLib.IWTLabel TipoConsumoEstoque_ConsumoLabel;
        private IWTDotNetLib.IWTRadioButton TipoConsumoEstoque_Consumo;
        private IWTDotNetLib.IWTLabel TipoConsumoEstoque_EscolherLabel;
        private IWTDotNetLib.IWTRadioButton TipoConsumoEstoque_Escolher;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTCheckBox ConfiguracaoAutomatica;
        private IWTDotNetLib.IWTLabel ConfiguracaoAutomaticaReferencia_DataCadastroLabel;
        private IWTDotNetLib.IWTRadioButton ConfiguracaoAutomaticaReferencia_DataCadastro;
        private IWTDotNetLib.IWTLabel ConfiguracaoAutomaticaReferencia_DataEntregaLabel;
        private IWTDotNetLib.IWTRadioButton ConfiguracaoAutomaticaReferencia_DataEntrega;
        private IWTDotNetLib.IWTLabel ConfiguracaoAutomaticaIntervaloLabel;
        private IWTDotNetLib.IWTNumericUpDown ConfiguracaoAutomaticaIntervalo;
        private System.Windows.Forms.GroupBox grbConfiguracaoAutomatica;
    }
}