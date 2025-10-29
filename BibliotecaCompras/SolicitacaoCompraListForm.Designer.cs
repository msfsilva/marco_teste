using IWTDotNetLib;

namespace BibliotecaCompras
{
    partial class SolicitacaoCompraListForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblRecebimentos = new System.Windows.Forms.Label();
            this.txtRecebimentos = new IWTDotNetLib.IWTTextBox(this.components);
            this.btnGerenciarFeedbaks = new System.Windows.Forms.Button();
            this.btnGerarOC = new System.Windows.Forms.Button();
            this.cmbComprador = new System.Windows.Forms.ComboBox();
            this.rdbCompradorAtual = new System.Windows.Forms.RadioButton();
            this.rdbTodosCompradores = new System.Windows.Forms.RadioButton();
            this.rdbBuscaComprador = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkDadosAdicionais = new System.Windows.Forms.LinkLabel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblQtdSolicitacoes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSc = new System.Windows.Forms.CheckBox();
            this.nudSC = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCanceladas = new System.Windows.Forms.CheckBox();
            this.chkRecebidas = new System.Windows.Forms.CheckBox();
            this.chkRecebidasParcial = new System.Windows.Forms.CheckBox();
            this.chkCompradas = new System.Windows.Forms.CheckBox();
            this.chkAprovadasCompras = new System.Windows.Forms.CheckBox();
            this.chkAprovadasPCP = new System.Windows.Forms.CheckBox();
            this.chkNovas = new System.Windows.Forms.CheckBox();
            this.btnAprovacaoPCP = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.chkOc = new System.Windows.Forms.CheckBox();
            this.nudOC = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSC)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOC)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkOc);
            this.splitContainer1.Panel2.Controls.Add(this.nudOC);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblRecebimentos);
            this.splitContainer1.Panel2.Controls.Add(this.txtRecebimentos);
            this.splitContainer1.Panel2.Controls.Add(this.btnGerenciarFeedbaks);
            this.splitContainer1.Panel2.Controls.Add(this.btnGerarOC);
            this.splitContainer1.Panel2.Controls.Add(this.cmbComprador);
            this.splitContainer1.Panel2.Controls.Add(this.rdbCompradorAtual);
            this.splitContainer1.Panel2.Controls.Add(this.rdbTodosCompradores);
            this.splitContainer1.Panel2.Controls.Add(this.rdbBuscaComprador);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.lnkDadosAdicionais);
            this.splitContainer1.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer1.Panel2.Controls.Add(this.lblQtdSolicitacoes);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.chkSc);
            this.splitContainer1.Panel2.Controls.Add(this.nudSC);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnAprovacaoPCP);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer1.Size = new System.Drawing.Size(984, 414);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(984, 265);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // lblRecebimentos
            // 
            this.lblRecebimentos.AutoSize = true;
            this.lblRecebimentos.Location = new System.Drawing.Point(5, 94);
            this.lblRecebimentos.Name = "lblRecebimentos";
            this.lblRecebimentos.Size = new System.Drawing.Size(75, 13);
            this.lblRecebimentos.TabIndex = 19;
            this.lblRecebimentos.Text = "Recebimentos";
            this.lblRecebimentos.Visible = false;
            // 
            // txtRecebimentos
            // 
            this.txtRecebimentos.BindingField = null;
            this.txtRecebimentos.DebugMode = false;
            this.txtRecebimentos.LiberadoQuandoCadastroUtilizado = false;
            this.txtRecebimentos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtRecebimentos.Location = new System.Drawing.Point(86, 91);
            this.txtRecebimentos.ModoBarcode = false;
            this.txtRecebimentos.ModoBusca = true;
            this.txtRecebimentos.Name = "txtRecebimentos";
            this.txtRecebimentos.NaoLimparDepoisBarcode = false;
            this.txtRecebimentos.Size = new System.Drawing.Size(276, 20);
            this.txtRecebimentos.TabIndex = 18;
            this.txtRecebimentos.Visible = false;
            this.txtRecebimentos.OperacaoBuscaEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBuscaEncerradaDelegate(this.txtRecebimentos_OperacaoBuscaEncerrada);
            // 
            // btnGerenciarFeedbaks
            // 
            this.btnGerenciarFeedbaks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerenciarFeedbaks.Location = new System.Drawing.Point(736, 91);
            this.btnGerenciarFeedbaks.Name = "btnGerenciarFeedbaks";
            this.btnGerenciarFeedbaks.Size = new System.Drawing.Size(236, 23);
            this.btnGerenciarFeedbaks.TabIndex = 11;
            this.btnGerenciarFeedbaks.Text = "Gerenciar Feedbacks";
            this.btnGerenciarFeedbaks.UseVisualStyleBackColor = true;
            this.btnGerenciarFeedbaks.Visible = false;
            this.btnGerenciarFeedbaks.Click += new System.EventHandler(this.btnGerenciarFeedbaks_Click);
            // 
            // btnGerarOC
            // 
            this.btnGerarOC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarOC.Location = new System.Drawing.Point(736, 45);
            this.btnGerarOC.Name = "btnGerarOC";
            this.btnGerarOC.Size = new System.Drawing.Size(236, 23);
            this.btnGerarOC.TabIndex = 8;
            this.btnGerarOC.Text = "Gerar OC";
            this.btnGerarOC.UseVisualStyleBackColor = true;
            this.btnGerarOC.Visible = false;
            this.btnGerarOC.Click += new System.EventHandler(this.btnGerarOC_Click);
            // 
            // cmbComprador
            // 
            this.cmbComprador.FormattingEnabled = true;
            this.cmbComprador.Location = new System.Drawing.Point(104, 64);
            this.cmbComprador.Name = "cmbComprador";
            this.cmbComprador.Size = new System.Drawing.Size(176, 21);
            this.cmbComprador.TabIndex = 3;
            this.cmbComprador.SelectedIndexChanged += new System.EventHandler(this.cmbComprador_SelectedIndexChanged);
            // 
            // rdbCompradorAtual
            // 
            this.rdbCompradorAtual.AutoSize = true;
            this.rdbCompradorAtual.Checked = true;
            this.rdbCompradorAtual.Location = new System.Drawing.Point(347, 67);
            this.rdbCompradorAtual.Name = "rdbCompradorAtual";
            this.rdbCompradorAtual.Size = new System.Drawing.Size(49, 17);
            this.rdbCompradorAtual.TabIndex = 6;
            this.rdbCompradorAtual.TabStop = true;
            this.rdbCompradorAtual.Text = "Atual";
            this.rdbCompradorAtual.UseVisualStyleBackColor = true;
            this.rdbCompradorAtual.CheckedChanged += new System.EventHandler(this.rdbCompradorAtual_CheckedChanged);
            // 
            // rdbTodosCompradores
            // 
            this.rdbTodosCompradores.AutoSize = true;
            this.rdbTodosCompradores.Location = new System.Drawing.Point(286, 67);
            this.rdbTodosCompradores.Name = "rdbTodosCompradores";
            this.rdbTodosCompradores.Size = new System.Drawing.Size(55, 17);
            this.rdbTodosCompradores.TabIndex = 5;
            this.rdbTodosCompradores.Text = "Todos";
            this.rdbTodosCompradores.UseVisualStyleBackColor = true;
            this.rdbTodosCompradores.CheckedChanged += new System.EventHandler(this.rdbTodosCompradores_CheckedChanged);
            // 
            // rdbBuscaComprador
            // 
            this.rdbBuscaComprador.AutoSize = true;
            this.rdbBuscaComprador.Location = new System.Drawing.Point(86, 69);
            this.rdbBuscaComprador.Name = "rdbBuscaComprador";
            this.rdbBuscaComprador.Size = new System.Drawing.Size(14, 13);
            this.rdbBuscaComprador.TabIndex = 4;
            this.rdbBuscaComprador.UseVisualStyleBackColor = true;
            this.rdbBuscaComprador.CheckedChanged += new System.EventHandler(this.rdbBuscaComprador_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Comprador";
            // 
            // lnkDadosAdicionais
            // 
            this.lnkDadosAdicionais.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkDadosAdicionais.AutoSize = true;
            this.lnkDadosAdicionais.Location = new System.Drawing.Point(12, 124);
            this.lnkDadosAdicionais.Name = "lnkDadosAdicionais";
            this.lnkDadosAdicionais.Size = new System.Drawing.Size(154, 13);
            this.lnkDadosAdicionais.TabIndex = 16;
            this.lnkDadosAdicionais.TabStop = true;
            this.lnkDadosAdicionais.Text = "Exibir/Ocultar dados Adicionais";
            this.lnkDadosAdicionais.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDadosAdicionais_LinkClicked);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Location = new System.Drawing.Point(736, 68);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(115, 23);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblQtdSolicitacoes
            // 
            this.lblQtdSolicitacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtdSolicitacoes.AutoSize = true;
            this.lblQtdSolicitacoes.Location = new System.Drawing.Point(923, 3);
            this.lblQtdSolicitacoes.Name = "lblQtdSolicitacoes";
            this.lblQtdSolicitacoes.Size = new System.Drawing.Size(0, 13);
            this.lblQtdSolicitacoes.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(854, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Quantidade:";
            // 
            // chkSc
            // 
            this.chkSc.AutoSize = true;
            this.chkSc.Location = new System.Drawing.Point(172, 41);
            this.chkSc.Name = "chkSc";
            this.chkSc.Size = new System.Drawing.Size(15, 14);
            this.chkSc.TabIndex = 1;
            this.chkSc.UseVisualStyleBackColor = true;
            this.chkSc.CheckedChanged += new System.EventHandler(this.chkIdOC_CheckedChanged);
            // 
            // nudSC
            // 
            this.nudSC.Enabled = false;
            this.nudSC.Location = new System.Drawing.Point(86, 39);
            this.nudSC.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudSC.Name = "nudSC";
            this.nudSC.Size = new System.Drawing.Size(80, 20);
            this.nudSC.TabIndex = 2;
            this.nudSC.ValueChanged += new System.EventHandler(this.nudIdOC_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Número SC";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(736, 114);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(115, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCanceladas);
            this.groupBox1.Controls.Add(this.chkRecebidas);
            this.groupBox1.Controls.Add(this.chkRecebidasParcial);
            this.groupBox1.Controls.Add(this.chkCompradas);
            this.groupBox1.Controls.Add(this.chkAprovadasCompras);
            this.groupBox1.Controls.Add(this.chkAprovadasPCP);
            this.groupBox1.Controls.Add(this.chkNovas);
            this.groupBox1.Location = new System.Drawing.Point(440, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 90);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // chkCanceladas
            // 
            this.chkCanceladas.AutoSize = true;
            this.chkCanceladas.Location = new System.Drawing.Point(140, 65);
            this.chkCanceladas.Name = "chkCanceladas";
            this.chkCanceladas.Size = new System.Drawing.Size(82, 17);
            this.chkCanceladas.TabIndex = 6;
            this.chkCanceladas.Text = "Canceladas";
            this.chkCanceladas.UseVisualStyleBackColor = true;
            this.chkCanceladas.CheckedChanged += new System.EventHandler(this.chkCanceladas_CheckedChanged);
            // 
            // chkRecebidas
            // 
            this.chkRecebidas.AutoSize = true;
            this.chkRecebidas.Location = new System.Drawing.Point(140, 42);
            this.chkRecebidas.Name = "chkRecebidas";
            this.chkRecebidas.Size = new System.Drawing.Size(77, 17);
            this.chkRecebidas.TabIndex = 5;
            this.chkRecebidas.Text = "Recebidas";
            this.chkRecebidas.UseVisualStyleBackColor = true;
            this.chkRecebidas.CheckedChanged += new System.EventHandler(this.chkRecebidas_CheckedChanged);
            // 
            // chkRecebidasParcial
            // 
            this.chkRecebidasParcial.AutoSize = true;
            this.chkRecebidasParcial.Location = new System.Drawing.Point(140, 19);
            this.chkRecebidasParcial.Name = "chkRecebidasParcial";
            this.chkRecebidasParcial.Size = new System.Drawing.Size(141, 17);
            this.chkRecebidasParcial.TabIndex = 4;
            this.chkRecebidasParcial.Text = "Recebidas Parcialmente";
            this.chkRecebidasParcial.UseVisualStyleBackColor = true;
            this.chkRecebidasParcial.CheckedChanged += new System.EventHandler(this.chkRecebidasParcial_CheckedChanged);
            // 
            // chkCompradas
            // 
            this.chkCompradas.AutoSize = true;
            this.chkCompradas.Location = new System.Drawing.Point(18, 67);
            this.chkCompradas.Name = "chkCompradas";
            this.chkCompradas.Size = new System.Drawing.Size(79, 17);
            this.chkCompradas.TabIndex = 3;
            this.chkCompradas.Text = "Compradas";
            this.chkCompradas.UseVisualStyleBackColor = true;
            this.chkCompradas.CheckedChanged += new System.EventHandler(this.chkCompradas_CheckedChanged);
            // 
            // chkAprovadasCompras
            // 
            this.chkAprovadasCompras.AutoSize = true;
            this.chkAprovadasCompras.Location = new System.Drawing.Point(18, 50);
            this.chkAprovadasCompras.Name = "chkAprovadasCompras";
            this.chkAprovadasCompras.Size = new System.Drawing.Size(121, 17);
            this.chkAprovadasCompras.TabIndex = 2;
            this.chkAprovadasCompras.Text = "Aprovadas Compras";
            this.chkAprovadasCompras.UseVisualStyleBackColor = true;
            this.chkAprovadasCompras.CheckedChanged += new System.EventHandler(this.chkAprovadasCompras_CheckedChanged);
            // 
            // chkAprovadasPCP
            // 
            this.chkAprovadasPCP.AutoSize = true;
            this.chkAprovadasPCP.Location = new System.Drawing.Point(18, 33);
            this.chkAprovadasPCP.Name = "chkAprovadasPCP";
            this.chkAprovadasPCP.Size = new System.Drawing.Size(101, 17);
            this.chkAprovadasPCP.TabIndex = 1;
            this.chkAprovadasPCP.Text = "Aprovadas PCP";
            this.chkAprovadasPCP.UseVisualStyleBackColor = true;
            this.chkAprovadasPCP.CheckedChanged += new System.EventHandler(this.chkAprovadasPCP_CheckedChanged);
            // 
            // chkNovas
            // 
            this.chkNovas.AutoSize = true;
            this.chkNovas.Checked = true;
            this.chkNovas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNovas.Location = new System.Drawing.Point(18, 16);
            this.chkNovas.Name = "chkNovas";
            this.chkNovas.Size = new System.Drawing.Size(95, 17);
            this.chkNovas.TabIndex = 0;
            this.chkNovas.Text = "Não Liberadas";
            this.chkNovas.UseVisualStyleBackColor = true;
            this.chkNovas.CheckedChanged += new System.EventHandler(this.chkNovas_CheckedChanged);
            // 
            // btnAprovacaoPCP
            // 
            this.btnAprovacaoPCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprovacaoPCP.Location = new System.Drawing.Point(857, 68);
            this.btnAprovacaoPCP.Name = "btnAprovacaoPCP";
            this.btnAprovacaoPCP.Size = new System.Drawing.Size(115, 23);
            this.btnAprovacaoPCP.TabIndex = 10;
            this.btnAprovacaoPCP.Text = "Aprovação PCP";
            this.btnAprovacaoPCP.UseVisualStyleBackColor = true;
            this.btnAprovacaoPCP.Click += new System.EventHandler(this.btnAprovacaoPCP_Click);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(86, 13);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(276, 20);
            this.txtBusca.TabIndex = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Identificação";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(857, 114);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(115, 23);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Location = new System.Drawing.Point(857, 45);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(115, 23);
            this.btnNovo.TabIndex = 4;
            this.btnNovo.Text = "Gerar Nova SC";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // chkOc
            // 
            this.chkOc.AutoSize = true;
            this.chkOc.Location = new System.Drawing.Point(347, 40);
            this.chkOc.Name = "chkOc";
            this.chkOc.Size = new System.Drawing.Size(15, 14);
            this.chkOc.TabIndex = 20;
            this.chkOc.UseVisualStyleBackColor = true;
            this.chkOc.CheckedChanged += new System.EventHandler(this.chkOc_CheckedChanged);
            // 
            // nudOC
            // 
            this.nudOC.Enabled = false;
            this.nudOC.Location = new System.Drawing.Point(261, 38);
            this.nudOC.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudOC.Name = "nudOC";
            this.nudOC.Size = new System.Drawing.Size(80, 20);
            this.nudOC.TabIndex = 21;
            this.nudOC.ValueChanged += new System.EventHandler(this.nudOC_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Número OC";
            // 
            // SolicitacaoCompraListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(984, 414);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SolicitacaoCompraListForm";
            this.Text = "Solicitações de Compra";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.Button btnAprovacaoPCP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkNovas;
        private System.Windows.Forms.CheckBox chkCanceladas;
        private System.Windows.Forms.CheckBox chkRecebidas;
        private System.Windows.Forms.CheckBox chkRecebidasParcial;
        private System.Windows.Forms.CheckBox chkCompradas;
        private System.Windows.Forms.CheckBox chkAprovadasCompras;
        private System.Windows.Forms.CheckBox chkAprovadasPCP;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkSc;
        private System.Windows.Forms.NumericUpDown nudSC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQtdSolicitacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.LinkLabel lnkDadosAdicionais;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbCompradorAtual;
        private System.Windows.Forms.RadioButton rdbTodosCompradores;
        private System.Windows.Forms.RadioButton rdbBuscaComprador;
        private System.Windows.Forms.ComboBox cmbComprador;
        private System.Windows.Forms.Button btnGerarOC;
        private System.Windows.Forms.Button btnGerenciarFeedbaks;
        private System.Windows.Forms.Label lblRecebimentos;
        private IWTTextBox txtRecebimentos;
        private System.Windows.Forms.CheckBox chkOc;
        private System.Windows.Forms.NumericUpDown nudOC;
        private System.Windows.Forms.Label label5;
    }
}