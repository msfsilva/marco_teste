using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadOrdemProducaoListForm 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.chkBuscaDataImpressao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grbBuscaDataImpressao = new System.Windows.Forms.GroupBox();
            this.iwtDateTimePicker2 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtDateTimePicker1 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPedido = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.rdbSuspensa = new IWTDotNetLib.IWTRadioButton(this.components);
            this.chkIdOP = new IWTDotNetLib.IWTCheckBox(this.components);
            this.rdbTodas = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbCancelada = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEncerrada = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEmProducao = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbNova = new IWTDotNetLib.IWTRadioButton(this.components);
            this.nudIdOrdemProducao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataImpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataReimpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEncerramento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgrupadorOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassificacaoProdutoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suspensa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Pendencia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AcsUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioImpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioReimpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioEncerramento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidosColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RevisaoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VersaoEstruturaProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadePedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEstoqueGaveta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RastreamentoMaterial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OrdemProducaoGrupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImprimeRelacionadas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UsuarioLiberacaoQualidadeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservacaoLiberacaoQualidadeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostoUltimaLeituraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGerarAvulsas = new IWTDotNetLib.IWTButton(this.components);
            this.btnVisualizar = new IWTDotNetLib.IWTButton(this.components);
            this.btnImprimir = new IWTDotNetLib.IWTButton(this.components);
            this.btnResolverPendencia = new IWTDotNetLib.IWTButton(this.components);
            this.btnRetirarSuspensao = new IWTDotNetLib.IWTButton(this.components);
            this.btnEncerrar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.btnReimprimir = new IWTDotNetLib.IWTButton(this.components);
            this.btnGerar = new IWTDotNetLib.IWTButton(this.components);
            this.rdbAguardandoServicoExterno = new IWTDotNetLib.IWTRadioButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            this.grbBuscaDataImpressao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOrdemProducao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 295);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnGerarAvulsas);
            this.splitContainer2.Panel2.Controls.Add(this.btnVisualizar);
            this.splitContainer2.Panel2.Controls.Add(this.btnImprimir);
            this.splitContainer2.Panel2.Controls.Add(this.btnResolverPendencia);
            this.splitContainer2.Panel2.Controls.Add(this.btnRetirarSuspensao);
            this.splitContainer2.Panel2.Controls.Add(this.btnEncerrar);
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnReimprimir);
            this.splitContainer2.Panel2.Controls.Add(this.btnGerar);
            this.splitContainer2.Size = new System.Drawing.Size(976, 150);
            this.splitContainer2.SplitterDistance = 587;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(976, 261);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.chkBuscaDataImpressao);
            this.iwtSearchPanel1.Controls.Add(this.grbBuscaDataImpressao);
            this.iwtSearchPanel1.Controls.Add(this.txtPedido);
            this.iwtSearchPanel1.Controls.Add(this.label2);
            this.iwtSearchPanel1.Controls.Add(this.rdbAguardandoServicoExterno);
            this.iwtSearchPanel1.Controls.Add(this.rdbSuspensa);
            this.iwtSearchPanel1.Controls.Add(this.chkIdOP);
            this.iwtSearchPanel1.Controls.Add(this.rdbTodas);
            this.iwtSearchPanel1.Controls.Add(this.rdbCancelada);
            this.iwtSearchPanel1.Controls.Add(this.rdbEncerrada);
            this.iwtSearchPanel1.Controls.Add(this.rdbEmProducao);
            this.iwtSearchPanel1.Controls.Add(this.rdbNova);
            this.iwtSearchPanel1.Controls.Add(this.nudIdOrdemProducao);
            this.iwtSearchPanel1.Controls.Add(this.label1);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(587, 150);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // chkBuscaDataImpressao
            // 
            this.chkBuscaDataImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBuscaDataImpressao.AutoSize = true;
            this.chkBuscaDataImpressao.BindingField = null;
            this.chkBuscaDataImpressao.LiberadoQuandoCadastroUtilizado = false;
            this.chkBuscaDataImpressao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkBuscaDataImpressao.Location = new System.Drawing.Point(353, 121);
            this.chkBuscaDataImpressao.Name = "chkBuscaDataImpressao";
            this.chkBuscaDataImpressao.Size = new System.Drawing.Size(15, 14);
            this.chkBuscaDataImpressao.TabIndex = 12;
            this.chkBuscaDataImpressao.UseVisualStyleBackColor = true;
            this.chkBuscaDataImpressao.CheckedChanged += new System.EventHandler(this.dhkBuscaDataImpressao_CheckedChanged);
            // 
            // grbBuscaDataImpressao
            // 
            this.grbBuscaDataImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBuscaDataImpressao.Controls.Add(this.iwtDateTimePicker2);
            this.grbBuscaDataImpressao.Controls.Add(this.iwtDateTimePicker1);
            this.grbBuscaDataImpressao.Controls.Add(this.label4);
            this.grbBuscaDataImpressao.Controls.Add(this.label3);
            this.grbBuscaDataImpressao.Enabled = false;
            this.grbBuscaDataImpressao.Location = new System.Drawing.Point(12, 100);
            this.grbBuscaDataImpressao.Name = "grbBuscaDataImpressao";
            this.grbBuscaDataImpressao.Size = new System.Drawing.Size(334, 47);
            this.grbBuscaDataImpressao.TabIndex = 11;
            this.grbBuscaDataImpressao.TabStop = false;
            this.grbBuscaDataImpressao.Text = "Data de Impressão";
            // 
            // iwtDateTimePicker2
            // 
            this.iwtDateTimePicker2.BindingField = "DataImpressaoFim";
            this.iwtDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker2.Location = new System.Drawing.Point(211, 15);
            this.iwtDateTimePicker2.Name = "iwtDateTimePicker2";
            this.iwtDateTimePicker2.Size = new System.Drawing.Size(108, 20);
            this.iwtDateTimePicker2.TabIndex = 1;
            this.iwtDateTimePicker2.Value = new System.DateTime(2021, 2, 18, 10, 53, 44, 64);
            // 
            // iwtDateTimePicker1
            // 
            this.iwtDateTimePicker1.BindingField = "DataImpressaoInicio";
            this.iwtDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker1.Location = new System.Drawing.Point(43, 15);
            this.iwtDateTimePicker1.Name = "iwtDateTimePicker1";
            this.iwtDateTimePicker1.Size = new System.Drawing.Size(108, 20);
            this.iwtDateTimePicker1.TabIndex = 0;
            this.iwtDateTimePicker1.Value = new System.DateTime(2021, 2, 18, 10, 53, 44, 65);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Até";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "De";
            // 
            // txtPedido
            // 
            this.txtPedido.BindingField = "Pedidos";
            this.txtPedido.DebugMode = false;
            this.txtPedido.LiberadoQuandoCadastroUtilizado = false;
            this.txtPedido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtPedido.Location = new System.Drawing.Point(55, 52);
            this.txtPedido.ModoBarcode = false;
            this.txtPedido.ModoBusca = false;
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.NaoLimparDepoisBarcode = false;
            this.txtPedido.Size = new System.Drawing.Size(319, 20);
            this.txtPedido.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Pedido";
            // 
            // rdbSuspensa
            // 
            this.rdbSuspensa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbSuspensa.AutoSize = true;
            this.rdbSuspensa.BindingField = "Suspensa";
            this.rdbSuspensa.LiberadoQuandoCadastroUtilizado = false;
            this.rdbSuspensa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbSuspensa.Location = new System.Drawing.Point(410, 82);
            this.rdbSuspensa.Name = "rdbSuspensa";
            this.rdbSuspensa.Size = new System.Drawing.Size(72, 17);
            this.rdbSuspensa.TabIndex = 7;
            this.rdbSuspensa.Text = "Suspensa";
            this.rdbSuspensa.UseVisualStyleBackColor = true;
            // 
            // chkIdOP
            // 
            this.chkIdOP.AutoSize = true;
            this.chkIdOP.BindingField = null;
            this.chkIdOP.LiberadoQuandoCadastroUtilizado = false;
            this.chkIdOP.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkIdOP.Location = new System.Drawing.Point(181, 28);
            this.chkIdOP.Name = "chkIdOP";
            this.chkIdOP.Size = new System.Drawing.Size(15, 14);
            this.chkIdOP.TabIndex = 2;
            this.chkIdOP.UseVisualStyleBackColor = true;
            this.chkIdOP.CheckedChanged += new System.EventHandler(this.chkIdOP_CheckedChanged);
            // 
            // rdbTodas
            // 
            this.rdbTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbTodas.AutoSize = true;
            this.rdbTodas.BindingField = null;
            this.rdbTodas.Checked = true;
            this.rdbTodas.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodas.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodas.Location = new System.Drawing.Point(410, 116);
            this.rdbTodas.Name = "rdbTodas";
            this.rdbTodas.Size = new System.Drawing.Size(55, 17);
            this.rdbTodas.TabIndex = 9;
            this.rdbTodas.TabStop = true;
            this.rdbTodas.Text = "Todas";
            this.rdbTodas.UseVisualStyleBackColor = true;
            // 
            // rdbCancelada
            // 
            this.rdbCancelada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbCancelada.AutoSize = true;
            this.rdbCancelada.BindingField = "Cancelada";
            this.rdbCancelada.LiberadoQuandoCadastroUtilizado = false;
            this.rdbCancelada.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbCancelada.Location = new System.Drawing.Point(410, 65);
            this.rdbCancelada.Name = "rdbCancelada";
            this.rdbCancelada.Size = new System.Drawing.Size(76, 17);
            this.rdbCancelada.TabIndex = 6;
            this.rdbCancelada.Text = "Cancelada";
            this.rdbCancelada.UseVisualStyleBackColor = true;
            // 
            // rdbEncerrada
            // 
            this.rdbEncerrada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbEncerrada.AutoSize = true;
            this.rdbEncerrada.BindingField = "Encerrada";
            this.rdbEncerrada.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEncerrada.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEncerrada.Location = new System.Drawing.Point(410, 48);
            this.rdbEncerrada.Name = "rdbEncerrada";
            this.rdbEncerrada.Size = new System.Drawing.Size(74, 17);
            this.rdbEncerrada.TabIndex = 5;
            this.rdbEncerrada.Text = "Encerrada";
            this.rdbEncerrada.UseVisualStyleBackColor = true;
            // 
            // rdbEmProducao
            // 
            this.rdbEmProducao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbEmProducao.AutoSize = true;
            this.rdbEmProducao.BindingField = "EmProducao";
            this.rdbEmProducao.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEmProducao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEmProducao.Location = new System.Drawing.Point(410, 31);
            this.rdbEmProducao.Name = "rdbEmProducao";
            this.rdbEmProducao.Size = new System.Drawing.Size(89, 17);
            this.rdbEmProducao.TabIndex = 4;
            this.rdbEmProducao.Text = "Em Produção";
            this.rdbEmProducao.UseVisualStyleBackColor = true;
            // 
            // rdbNova
            // 
            this.rdbNova.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbNova.AutoSize = true;
            this.rdbNova.BindingField = "Nova";
            this.rdbNova.LiberadoQuandoCadastroUtilizado = false;
            this.rdbNova.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbNova.Location = new System.Drawing.Point(410, 14);
            this.rdbNova.Name = "rdbNova";
            this.rdbNova.Size = new System.Drawing.Size(51, 17);
            this.rdbNova.TabIndex = 3;
            this.rdbNova.Text = "Nova";
            this.rdbNova.UseVisualStyleBackColor = true;
            // 
            // nudIdOrdemProducao
            // 
            this.nudIdOrdemProducao.BindingField = "Numero";
            this.nudIdOrdemProducao.Enabled = false;
            this.nudIdOrdemProducao.LiberadoQuandoCadastroUtilizado = false;
            this.nudIdOrdemProducao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudIdOrdemProducao.Location = new System.Drawing.Point(55, 26);
            this.nudIdOrdemProducao.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudIdOrdemProducao.Name = "nudIdOrdemProducao";
            this.nudIdOrdemProducao.Size = new System.Drawing.Size(120, 20);
            this.nudIdOrdemProducao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Número";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(55, 0);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(319, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(15, 3);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
            // 
            // iwtDataGridView1
            // 
            this.iwtDataGridView1.AllowUserToAddRows = false;
            this.iwtDataGridView1.AllowUserToDeleteRows = false;
            this.iwtDataGridView1.AllowUserToOrderColumns = true;
            this.iwtDataGridView1.AllowUserToResizeRows = false;
            this.iwtDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.iwtDataGridView1.CacheDados = null;
            this.iwtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iwtDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProdutoCodigo,
            this.Data,
            this.DataImpressao,
            this.DataReimpressao,
            this.DataEncerramento,
            this.AgrupadorOp,
            this.ProdutoDescricao,
            this.ClassificacaoProdutoColumn,
            this.Situacao,
            this.Dimensao,
            this.Quantidade,
            this.Suspensa,
            this.Pendencia,
            this.AcsUsuario,
            this.AcsUsuarioImpressao,
            this.AcsUsuarioReimpressao,
            this.AcsUsuarioEncerramento,
            this.PedidosColumn,
            this.TipoDocumento,
            this.NumeroDocumento,
            this.RevisaoDocumento,
            this.VersaoEstruturaProduto,
            this.QuantidadeEstoque,
            this.QuantidadePedido,
            this.QuantidadeExtra,
            this.IdEstoqueGaveta,
            this.RastreamentoMaterial,
            this.OrdemProducaoGrupo,
            this.ImprimeRelacionadas,
            this.UsuarioLiberacaoQualidadeColumn,
            this.ObservacaoLiberacaoQualidadeColumn,
            this.PostoUltimaLeituraColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(976, 223);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Número";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 70;
            // 
            // ProdutoCodigo
            // 
            this.ProdutoCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoCodigo.DataPropertyName = "ProdutoCodigo";
            this.ProdutoCodigo.HeaderText = "Código do Produto";
            this.ProdutoCodigo.Name = "ProdutoCodigo";
            this.ProdutoCodigo.ReadOnly = true;
            this.ProdutoCodigo.Width = 150;
            // 
            // Data
            // 
            this.Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Data.DataPropertyName = "Data";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // DataImpressao
            // 
            this.DataImpressao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataImpressao.DataPropertyName = "DataImpressao";
            this.DataImpressao.HeaderText = "Data da Impressão";
            this.DataImpressao.Name = "DataImpressao";
            this.DataImpressao.ReadOnly = true;
            // 
            // DataReimpressao
            // 
            this.DataReimpressao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataReimpressao.DataPropertyName = "DataReimpressao";
            this.DataReimpressao.HeaderText = "Data da Reimpressão";
            this.DataReimpressao.Name = "DataReimpressao";
            this.DataReimpressao.ReadOnly = true;
            // 
            // DataEncerramento
            // 
            this.DataEncerramento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEncerramento.DataPropertyName = "DataEncerramento";
            this.DataEncerramento.HeaderText = "Data de Encerramento";
            this.DataEncerramento.Name = "DataEncerramento";
            this.DataEncerramento.ReadOnly = true;
            // 
            // AgrupadorOp
            // 
            this.AgrupadorOp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AgrupadorOp.DataPropertyName = "AgrupadorOp";
            this.AgrupadorOp.HeaderText = "Agrupador da OP";
            this.AgrupadorOp.Name = "AgrupadorOp";
            this.AgrupadorOp.ReadOnly = true;
            this.AgrupadorOp.Visible = false;
            this.AgrupadorOp.Width = 150;
            // 
            // ProdutoDescricao
            // 
            this.ProdutoDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoDescricao.DataPropertyName = "ProdutoDescricao";
            this.ProdutoDescricao.HeaderText = "Descrição do Produto";
            this.ProdutoDescricao.Name = "ProdutoDescricao";
            this.ProdutoDescricao.ReadOnly = true;
            this.ProdutoDescricao.Width = 150;
            // 
            // ClassificacaoProdutoColumn
            // 
            this.ClassificacaoProdutoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClassificacaoProdutoColumn.DataPropertyName = "ClassificacaoProduto";
            this.ClassificacaoProdutoColumn.HeaderText = "Classificação do Produto";
            this.ClassificacaoProdutoColumn.Name = "ClassificacaoProdutoColumn";
            this.ClassificacaoProdutoColumn.ReadOnly = true;
            this.ClassificacaoProdutoColumn.Width = 150;
            // 
            // Situacao
            // 
            this.Situacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Situacao.DataPropertyName = "SituacaoTraduzida";
            this.Situacao.HeaderText = "Situação";
            this.Situacao.Name = "Situacao";
            this.Situacao.ReadOnly = true;
            this.Situacao.Width = 150;
            // 
            // Dimensao
            // 
            this.Dimensao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao.DataPropertyName = "Dimensao";
            this.Dimensao.HeaderText = "Dimensão";
            this.Dimensao.Name = "Dimensao";
            this.Dimensao.ReadOnly = true;
            this.Dimensao.Width = 150;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade a Produzir";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // Suspensa
            // 
            this.Suspensa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Suspensa.DataPropertyName = "Suspensa";
            this.Suspensa.HeaderText = "Suspensa";
            this.Suspensa.Name = "Suspensa";
            this.Suspensa.ReadOnly = true;
            this.Suspensa.Width = 70;
            // 
            // Pendencia
            // 
            this.Pendencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Pendencia.DataPropertyName = "Pendencia";
            this.Pendencia.HeaderText = "Pendências";
            this.Pendencia.Name = "Pendencia";
            this.Pendencia.ReadOnly = true;
            this.Pendencia.Width = 70;
            // 
            // AcsUsuario
            // 
            this.AcsUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuario.DataPropertyName = "AcsUsuario";
            this.AcsUsuario.HeaderText = "Usuário";
            this.AcsUsuario.Name = "AcsUsuario";
            this.AcsUsuario.ReadOnly = true;
            this.AcsUsuario.Width = 150;
            // 
            // AcsUsuarioImpressao
            // 
            this.AcsUsuarioImpressao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioImpressao.DataPropertyName = "AcsUsuarioImpressao";
            this.AcsUsuarioImpressao.HeaderText = "Usuário Impressão";
            this.AcsUsuarioImpressao.Name = "AcsUsuarioImpressao";
            this.AcsUsuarioImpressao.ReadOnly = true;
            this.AcsUsuarioImpressao.Width = 150;
            // 
            // AcsUsuarioReimpressao
            // 
            this.AcsUsuarioReimpressao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioReimpressao.DataPropertyName = "AcsUsuarioReimpressao";
            this.AcsUsuarioReimpressao.HeaderText = "Usuário Reimpressão";
            this.AcsUsuarioReimpressao.Name = "AcsUsuarioReimpressao";
            this.AcsUsuarioReimpressao.ReadOnly = true;
            this.AcsUsuarioReimpressao.Width = 150;
            // 
            // AcsUsuarioEncerramento
            // 
            this.AcsUsuarioEncerramento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioEncerramento.DataPropertyName = "AcsUsuarioEncerramento";
            this.AcsUsuarioEncerramento.HeaderText = "Usuário Encerramento";
            this.AcsUsuarioEncerramento.Name = "AcsUsuarioEncerramento";
            this.AcsUsuarioEncerramento.ReadOnly = true;
            this.AcsUsuarioEncerramento.Width = 150;
            // 
            // PedidosColumn
            // 
            this.PedidosColumn.DataPropertyName = "Pedidos";
            this.PedidosColumn.HeaderText = "Pedidos";
            this.PedidosColumn.Name = "PedidosColumn";
            this.PedidosColumn.ReadOnly = true;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoDocumento.DataPropertyName = "TipoDocumento";
            this.TipoDocumento.HeaderText = "Tipo do documento";
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            this.TipoDocumento.Visible = false;
            this.TipoDocumento.Width = 150;
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.NumeroDocumento.HeaderText = "Número do Documento";
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.ReadOnly = true;
            this.NumeroDocumento.Visible = false;
            this.NumeroDocumento.Width = 150;
            // 
            // RevisaoDocumento
            // 
            this.RevisaoDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RevisaoDocumento.DataPropertyName = "RevisaoDocumento";
            this.RevisaoDocumento.HeaderText = "Revisão do Documento";
            this.RevisaoDocumento.Name = "RevisaoDocumento";
            this.RevisaoDocumento.ReadOnly = true;
            this.RevisaoDocumento.Visible = false;
            this.RevisaoDocumento.Width = 150;
            // 
            // VersaoEstruturaProduto
            // 
            this.VersaoEstruturaProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VersaoEstruturaProduto.DataPropertyName = "VersaoEstruturaProduto";
            this.VersaoEstruturaProduto.HeaderText = "Versão da Estrutura do Produto";
            this.VersaoEstruturaProduto.Name = "VersaoEstruturaProduto";
            this.VersaoEstruturaProduto.ReadOnly = true;
            this.VersaoEstruturaProduto.Visible = false;
            this.VersaoEstruturaProduto.Width = 70;
            // 
            // QuantidadeEstoque
            // 
            this.QuantidadeEstoque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuantidadeEstoque.DataPropertyName = "QuantidadeEstoque";
            this.QuantidadeEstoque.HeaderText = "Quantidade a Utilizar do Estoque";
            this.QuantidadeEstoque.Name = "QuantidadeEstoque";
            this.QuantidadeEstoque.ReadOnly = true;
            this.QuantidadeEstoque.Visible = false;
            // 
            // QuantidadePedido
            // 
            this.QuantidadePedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuantidadePedido.DataPropertyName = "QuantidadePedido";
            this.QuantidadePedido.HeaderText = "Quantidade Necessária para os Pedidos";
            this.QuantidadePedido.Name = "QuantidadePedido";
            this.QuantidadePedido.ReadOnly = true;
            this.QuantidadePedido.Visible = false;
            // 
            // QuantidadeExtra
            // 
            this.QuantidadeExtra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QuantidadeExtra.DataPropertyName = "QuantidadeExtra";
            this.QuantidadeExtra.HeaderText = "Quantidade a Repor no Estoque";
            this.QuantidadeExtra.Name = "QuantidadeExtra";
            this.QuantidadeExtra.ReadOnly = true;
            this.QuantidadeExtra.Visible = false;
            // 
            // IdEstoqueGaveta
            // 
            this.IdEstoqueGaveta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdEstoqueGaveta.DataPropertyName = "IdEstoqueGaveta";
            this.IdEstoqueGaveta.HeaderText = "Local de Estoque";
            this.IdEstoqueGaveta.Name = "IdEstoqueGaveta";
            this.IdEstoqueGaveta.ReadOnly = true;
            this.IdEstoqueGaveta.Visible = false;
            this.IdEstoqueGaveta.Width = 70;
            // 
            // RastreamentoMaterial
            // 
            this.RastreamentoMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RastreamentoMaterial.DataPropertyName = "RastreamentoMaterial";
            this.RastreamentoMaterial.HeaderText = "Rastreamento de Material";
            this.RastreamentoMaterial.Name = "RastreamentoMaterial";
            this.RastreamentoMaterial.ReadOnly = true;
            this.RastreamentoMaterial.Visible = false;
            this.RastreamentoMaterial.Width = 70;
            // 
            // OrdemProducaoGrupo
            // 
            this.OrdemProducaoGrupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrdemProducaoGrupo.DataPropertyName = "OrdemProducaoGrupo";
            this.OrdemProducaoGrupo.HeaderText = "Grupo da OP";
            this.OrdemProducaoGrupo.Name = "OrdemProducaoGrupo";
            this.OrdemProducaoGrupo.ReadOnly = true;
            this.OrdemProducaoGrupo.Visible = false;
            this.OrdemProducaoGrupo.Width = 150;
            // 
            // ImprimeRelacionadas
            // 
            this.ImprimeRelacionadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImprimeRelacionadas.DataPropertyName = "ImprimeRelacionadas";
            this.ImprimeRelacionadas.HeaderText = "Iimprime Relacionadas";
            this.ImprimeRelacionadas.Name = "ImprimeRelacionadas";
            this.ImprimeRelacionadas.ReadOnly = true;
            this.ImprimeRelacionadas.Visible = false;
            this.ImprimeRelacionadas.Width = 70;
            // 
            // UsuarioLiberacaoQualidadeColumn
            // 
            this.UsuarioLiberacaoQualidadeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UsuarioLiberacaoQualidadeColumn.DataPropertyName = "AcsUsuarioLiberacaoQualidade";
            this.UsuarioLiberacaoQualidadeColumn.HeaderText = "Usuário Liberação Qualidade";
            this.UsuarioLiberacaoQualidadeColumn.Name = "UsuarioLiberacaoQualidadeColumn";
            this.UsuarioLiberacaoQualidadeColumn.ReadOnly = true;
            this.UsuarioLiberacaoQualidadeColumn.Visible = false;
            this.UsuarioLiberacaoQualidadeColumn.Width = 150;
            // 
            // ObservacaoLiberacaoQualidadeColumn
            // 
            this.ObservacaoLiberacaoQualidadeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ObservacaoLiberacaoQualidadeColumn.DataPropertyName = "ObservacaoLiberacaoQualidade";
            this.ObservacaoLiberacaoQualidadeColumn.HeaderText = "Observação da Qualidade";
            this.ObservacaoLiberacaoQualidadeColumn.Name = "ObservacaoLiberacaoQualidadeColumn";
            this.ObservacaoLiberacaoQualidadeColumn.ReadOnly = true;
            this.ObservacaoLiberacaoQualidadeColumn.Width = 150;
            // 
            // PostoUltimaLeituraColumn
            // 
            this.PostoUltimaLeituraColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PostoUltimaLeituraColumn.DataPropertyName = "PostoUltimaLeitura";
            this.PostoUltimaLeituraColumn.HeaderText = "Posto da Última Leitura";
            this.PostoUltimaLeituraColumn.Name = "PostoUltimaLeituraColumn";
            this.PostoUltimaLeituraColumn.ReadOnly = true;
            this.PostoUltimaLeituraColumn.Visible = false;
            this.PostoUltimaLeituraColumn.Width = 150;
            // 
            // btnGerarAvulsas
            // 
            this.btnGerarAvulsas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarAvulsas.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerarAvulsas.Location = new System.Drawing.Point(217, 9);
            this.btnGerarAvulsas.Name = "btnGerarAvulsas";
            this.btnGerarAvulsas.Size = new System.Drawing.Size(156, 23);
            this.btnGerarAvulsas.TabIndex = 24;
            this.btnGerarAvulsas.Text = "Gerar OPs Avulsas";
            this.btnGerarAvulsas.UseVisualStyleBackColor = true;
            this.btnGerarAvulsas.Click += new System.EventHandler(this.btnGerarAvulsas_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizar.LiberadoQuandoCadastroUtilizado = false;
            this.btnVisualizar.Location = new System.Drawing.Point(55, 32);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(102, 23);
            this.btnVisualizar.TabIndex = 25;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.UseVisualStyleBackColor = true;
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.LiberadoQuandoCadastroUtilizado = false;
            this.btnImprimir.Location = new System.Drawing.Point(163, 32);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(102, 23);
            this.btnImprimir.TabIndex = 26;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnResolverPendencia
            // 
            this.btnResolverPendencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolverPendencia.Enabled = false;
            this.btnResolverPendencia.LiberadoQuandoCadastroUtilizado = false;
            this.btnResolverPendencia.Location = new System.Drawing.Point(217, 80);
            this.btnResolverPendencia.Name = "btnResolverPendencia";
            this.btnResolverPendencia.Size = new System.Drawing.Size(156, 23);
            this.btnResolverPendencia.TabIndex = 22;
            this.btnResolverPendencia.Text = "Resolver Pendência";
            this.btnResolverPendencia.UseVisualStyleBackColor = true;
            this.btnResolverPendencia.Click += new System.EventHandler(this.btnResolverPendencia_Click);
            // 
            // btnRetirarSuspensao
            // 
            this.btnRetirarSuspensao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetirarSuspensao.Enabled = false;
            this.btnRetirarSuspensao.LiberadoQuandoCadastroUtilizado = false;
            this.btnRetirarSuspensao.Location = new System.Drawing.Point(55, 80);
            this.btnRetirarSuspensao.Name = "btnRetirarSuspensao";
            this.btnRetirarSuspensao.Size = new System.Drawing.Size(156, 23);
            this.btnRetirarSuspensao.TabIndex = 21;
            this.btnRetirarSuspensao.Text = "Retirar Suspensão";
            this.btnRetirarSuspensao.UseVisualStyleBackColor = true;
            this.btnRetirarSuspensao.Click += new System.EventHandler(this.btnRetirarSuspensao_Click);
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEncerrar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEncerrar.Location = new System.Drawing.Point(55, 56);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(156, 23);
            this.btnEncerrar.TabIndex = 19;
            this.btnEncerrar.Text = "Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(217, 56);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(156, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnReimprimir
            // 
            this.btnReimprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReimprimir.LiberadoQuandoCadastroUtilizado = false;
            this.btnReimprimir.Location = new System.Drawing.Point(271, 32);
            this.btnReimprimir.Name = "btnReimprimir";
            this.btnReimprimir.Size = new System.Drawing.Size(102, 23);
            this.btnReimprimir.TabIndex = 18;
            this.btnReimprimir.Text = "Reimprimir";
            this.btnReimprimir.UseVisualStyleBackColor = true;
            this.btnReimprimir.Click += new System.EventHandler(this.btnReimprimir_Click);
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerar.Location = new System.Drawing.Point(55, 8);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(156, 23);
            this.btnGerar.TabIndex = 23;
            this.btnGerar.Text = "Gerar OPs / PCs";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // rdbAguardandoServicoExterno
            // 
            this.rdbAguardandoServicoExterno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbAguardandoServicoExterno.AutoSize = true;
            this.rdbAguardandoServicoExterno.BindingField = "AguardandoServicoExterno";
            this.rdbAguardandoServicoExterno.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAguardandoServicoExterno.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAguardandoServicoExterno.Location = new System.Drawing.Point(410, 99);
            this.rdbAguardandoServicoExterno.Name = "rdbAguardandoServicoExterno";
            this.rdbAguardandoServicoExterno.Size = new System.Drawing.Size(161, 17);
            this.rdbAguardandoServicoExterno.TabIndex = 8;
            this.rdbAguardandoServicoExterno.Text = "Aguardando Serviço Externo";
            this.rdbAguardandoServicoExterno.UseVisualStyleBackColor = true;
            // 
            // CadOrdemProducaoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(976, 445);
            this.Name = "CadOrdemProducaoListForm";
            this.Text = "Ordens de Produção";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            this.grbBuscaDataImpressao.ResumeLayout(false);
            this.grbBuscaDataImpressao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOrdemProducao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SituacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoDescricaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RevisaoDocumentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteNaoUsarColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DimensaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoCodigoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeEstoqueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadePedidoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PendenciaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SuspensaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QtdMaiorVerificadaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdemProducaoGrupoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataReimpressaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioReimpressaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioImpressaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataImpressaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgrupadorOpColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioEncerramentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEncerramentoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VersaoEstruturaProdutoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RastreamentoMaterialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeExtraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstoqueGavetaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImprimeRelacionadasColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoKColumn;
        private IWTTextBox txtPedido;
        private System.Windows.Forms.Label label2;
        private IWTRadioButton rdbSuspensa;
        private IWTCheckBox chkIdOP;
        private IWTRadioButton rdbTodas;
        private IWTRadioButton rdbCancelada;
        private IWTRadioButton rdbEncerrada;
        private IWTRadioButton rdbEmProducao;
        private IWTRadioButton rdbNova;
        private IWTNumericUpDown nudIdOrdemProducao;
        private System.Windows.Forms.Label label1;
        private IWTButton btnGerarAvulsas;
        private IWTButton btnVisualizar;
        private IWTButton btnImprimir;
        private IWTButton btnResolverPendencia;
        private IWTButton btnRetirarSuspensao;
        private IWTButton btnEncerrar;
        private IWTButton btnCancelar;
        private IWTButton btnReimprimir;
        private IWTButton btnGerar;
        private System.Windows.Forms.GroupBox grbBuscaDataImpressao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private IWTDateTimePicker iwtDateTimePicker2;
        private IWTDateTimePicker iwtDateTimePicker1;
        private IWTCheckBox chkBuscaDataImpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataImpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataReimpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEncerramento;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgrupadorOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassificacaoProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Suspensa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Pendencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioImpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioReimpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioEncerramento;
        private System.Windows.Forms.DataGridViewTextBoxColumn PedidosColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn RevisaoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn VersaoEstruturaProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadePedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeExtra;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstoqueGaveta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RastreamentoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdemProducaoGrupo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImprimeRelacionadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioLiberacaoQualidadeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservacaoLiberacaoQualidadeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostoUltimaLeituraColumn;
        private IWTRadioButton rdbAguardandoServicoExterno;
    }
} 
