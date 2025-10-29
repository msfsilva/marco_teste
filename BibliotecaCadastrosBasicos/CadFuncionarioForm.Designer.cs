using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadFuncionarioForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFuncao = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InicioVigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FimVigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbFuncao = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnAddFuncao = new IWTDotNetLib.IWTButton(this.components);
            this.btnRemoveFuncao = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.iwtDateTimePicker2 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtLabel12 = new IWTDotNetLib.IWTLabel(this.components);
            this.labEstado = new IWTDotNetLib.IWTLabel(this.components);
            this.iesCidade = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iesEstadoCtps = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtImage1 = new IWTDotNetLib.IWTImage();
            this.iwtLabel10 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox6 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel9 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox5 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel8 = new IWTDotNetLib.IWTLabel(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox4 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel7 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtEmail = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtTextBox3 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtNumeroCob = new IWTDotNetLib.IWTTextBox(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtComplementoCob = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtFone2 = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.label28 = new IWTDotNetLib.IWTLabel(this.components);
            this.label55 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCepCob = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtFone1 = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.txtBairroCob = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtEnderecoCob = new IWTDotNetLib.IWTTextBox(this.components);
            this.label29 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.label30 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDateTimePicker1 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label31 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.label32 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.label34 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.label35 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCNPJ = new IWTDotNetLib.IWTMaskedTextBox(this.components);
            this.txtNomeResumido = new IWTDotNetLib.IWTTextBox(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtNome = new IWTDotNetLib.IWTTextBox(this.components);
            this.lblCNPJ = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.iwtLabel11 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtdEpi = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.rdbTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbDescart = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbVenc = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbRet = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbPendRet = new IWTDotNetLib.IWTRadioButton(this.components);
            this.btnRemoverEpi = new IWTDotNetLib.IWTButton(this.components);
            this.btnAddEpi = new IWTDotNetLib.IWTButton(this.components);
            this.btnRetiradaEpi = new IWTDotNetLib.IWTButton(this.components);
            this.dgvEpi = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataVencimentoPrevista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataDescarte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbEpi = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnDocumentoAbrir = new IWTDotNetLib.IWTButton(this.components);
            this.btnDocumentoExcluir = new IWTDotNetLib.IWTButton(this.components);
            this.btnDocumentoNovo = new IWTDotNetLib.IWTButton(this.components);
            this.dgvDocumentos = new IWTDotNetLib.IWTDataGridView(this.components);
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncao)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdEpi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(898, 598);
            this.splitContainer1.SplitterDistance = 532;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(811, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvFuncao);
            this.groupBox1.Controls.Add(this.cmbFuncao);
            this.groupBox1.Controls.Add(this.iwtLabel3);
            this.groupBox1.Controls.Add(this.btnAddFuncao);
            this.groupBox1.Controls.Add(this.btnRemoveFuncao);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 494);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funções";
            // 
            // dgvFuncao
            // 
            this.dgvFuncao.AllowUserToAddRows = false;
            this.dgvFuncao.AllowUserToDeleteRows = false;
            this.dgvFuncao.AllowUserToOrderColumns = true;
            this.dgvFuncao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFuncao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFuncao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Funcao,
            this.InicioVigencia,
            this.FimVigencia});
            this.dgvFuncao.Location = new System.Drawing.Point(0, 44);
            this.dgvFuncao.MultiSelect = false;
            this.dgvFuncao.Name = "dgvFuncao";
            this.dgvFuncao.ReadOnly = true;
            this.dgvFuncao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFuncao.Size = new System.Drawing.Size(871, 442);
            this.dgvFuncao.TabIndex = 14;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Funcao
            // 
            this.Funcao.DataPropertyName = "Funcao";
            this.Funcao.HeaderText = "Função";
            this.Funcao.Name = "Funcao";
            this.Funcao.ReadOnly = true;
            this.Funcao.Width = 400;
            // 
            // InicioVigencia
            // 
            this.InicioVigencia.DataPropertyName = "InicioVigencia";
            this.InicioVigencia.HeaderText = "Início Vigência";
            this.InicioVigencia.Name = "InicioVigencia";
            this.InicioVigencia.ReadOnly = true;
            this.InicioVigencia.Width = 200;
            // 
            // FimVigencia
            // 
            this.FimVigencia.DataPropertyName = "FimVigencia";
            this.FimVigencia.HeaderText = "Fim Vigência";
            this.FimVigencia.Name = "FimVigencia";
            this.FimVigencia.ReadOnly = true;
            this.FimVigencia.Width = 200;
            // 
            // cmbFuncao
            // 
            this.cmbFuncao.BindingField = null;
            this.cmbFuncao.ColumnsToDisplay = null;
            this.cmbFuncao.DisableAutoSelectOnEmpty = false;
            this.cmbFuncao.DropDownHeight = 1;
            this.cmbFuncao.FormattingEnabled = true;
            this.cmbFuncao.IntegralHeight = false;
            this.cmbFuncao.LiberadoQuandoCadastroUtilizado = false;
            this.cmbFuncao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbFuncao.Location = new System.Drawing.Point(77, 17);
            this.cmbFuncao.Name = "cmbFuncao";
            this.cmbFuncao.SelectedRow = null;
            this.cmbFuncao.Size = new System.Drawing.Size(342, 21);
            this.cmbFuncao.TabIndex = 10;
            this.cmbFuncao.Table = null;
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(28, 20);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel3.TabIndex = 11;
            this.iwtLabel3.Text = "Função";
            // 
            // btnAddFuncao
            // 
            this.btnAddFuncao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFuncao.LiberadoQuandoCadastroUtilizado = false;
            this.btnAddFuncao.Location = new System.Drawing.Point(715, 10);
            this.btnAddFuncao.Name = "btnAddFuncao";
            this.btnAddFuncao.Size = new System.Drawing.Size(75, 23);
            this.btnAddFuncao.TabIndex = 12;
            this.btnAddFuncao.Text = "Adicionar";
            this.btnAddFuncao.UseVisualStyleBackColor = true;
            this.btnAddFuncao.Click += new System.EventHandler(this.btnAddFuncao_Click);
            // 
            // btnRemoveFuncao
            // 
            this.btnRemoveFuncao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFuncao.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemoveFuncao.Location = new System.Drawing.Point(796, 10);
            this.btnRemoveFuncao.Name = "btnRemoveFuncao";
            this.btnRemoveFuncao.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFuncao.TabIndex = 13;
            this.btnRemoveFuncao.Text = "Remover";
            this.btnRemoveFuncao.UseVisualStyleBackColor = true;
            this.btnRemoveFuncao.Click += new System.EventHandler(this.btnRemoveFuncao_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.lblRevisao);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.lblRevisaoData);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox2.Location = new System.Drawing.Point(21, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 94);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Revisão";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(28, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "Usuário";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisao.Location = new System.Drawing.Point(111, 73);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(41, 45);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(30, 13);
            this.label25.TabIndex = 7;
            this.label25.Text = "Data";
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(111, 45);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 10;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(9, 73);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(62, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "Justificativa";
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(111, 17);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 9;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(898, 532);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.iwtDateTimePicker2);
            this.tabPage1.Controls.Add(this.iwtLabel12);
            this.tabPage1.Controls.Add(this.labEstado);
            this.tabPage1.Controls.Add(this.iesCidade);
            this.tabPage1.Controls.Add(this.iesEstadoCtps);
            this.tabPage1.Controls.Add(this.iwtImage1);
            this.tabPage1.Controls.Add(this.iwtLabel10);
            this.tabPage1.Controls.Add(this.iwtTextBox6);
            this.tabPage1.Controls.Add(this.iwtLabel9);
            this.tabPage1.Controls.Add(this.iwtTextBox5);
            this.tabPage1.Controls.Add(this.iwtLabel8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.iwtTextBox4);
            this.tabPage1.Controls.Add(this.iwtLabel7);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.iwtTextBox3);
            this.tabPage1.Controls.Add(this.iwtLabel6);
            this.tabPage1.Controls.Add(this.txtNumeroCob);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtComplementoCob);
            this.tabPage1.Controls.Add(this.txtFone2);
            this.tabPage1.Controls.Add(this.label28);
            this.tabPage1.Controls.Add(this.label55);
            this.tabPage1.Controls.Add(this.txtCepCob);
            this.tabPage1.Controls.Add(this.txtFone1);
            this.tabPage1.Controls.Add(this.txtBairroCob);
            this.tabPage1.Controls.Add(this.txtEnderecoCob);
            this.tabPage1.Controls.Add(this.label29);
            this.tabPage1.Controls.Add(this.iwtLabel5);
            this.tabPage1.Controls.Add(this.label30);
            this.tabPage1.Controls.Add(this.iwtDateTimePicker1);
            this.tabPage1.Controls.Add(this.label31);
            this.tabPage1.Controls.Add(this.iwtTextBox2);
            this.tabPage1.Controls.Add(this.label32);
            this.tabPage1.Controls.Add(this.iwtLabel2);
            this.tabPage1.Controls.Add(this.label34);
            this.tabPage1.Controls.Add(this.iwtTextBox1);
            this.tabPage1.Controls.Add(this.label35);
            this.tabPage1.Controls.Add(this.iwtLabel1);
            this.tabPage1.Controls.Add(this.txtCNPJ);
            this.tabPage1.Controls.Add(this.txtNomeResumido);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.lblCNPJ);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(890, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Funcionário";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // iwtDateTimePicker2
            // 
            this.iwtDateTimePicker2.BindingField = "DataAdmissao";
            this.iwtDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker2.Location = new System.Drawing.Point(449, 428);
            this.iwtDateTimePicker2.Name = "iwtDateTimePicker2";
            this.iwtDateTimePicker2.Size = new System.Drawing.Size(208, 20);
            this.iwtDateTimePicker2.TabIndex = 161;
            this.iwtDateTimePicker2.Value = new System.DateTime(2022, 5, 16, 15, 20, 3, 596);
            // 
            // iwtLabel12
            // 
            this.iwtLabel12.AutoSize = true;
            this.iwtLabel12.BindingField = null;
            this.iwtLabel12.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel12.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel12.Location = new System.Drawing.Point(351, 432);
            this.iwtLabel12.Name = "iwtLabel12";
            this.iwtLabel12.Size = new System.Drawing.Size(93, 13);
            this.iwtLabel12.TabIndex = 160;
            this.iwtLabel12.Text = "Data de Admissão";
            // 
            // labEstado
            // 
            this.labEstado.AutoSize = true;
            this.labEstado.BindingField = "Estado";
            this.labEstado.LiberadoQuandoCadastroUtilizado = false;
            this.labEstado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.labEstado.Location = new System.Drawing.Point(450, 294);
            this.labEstado.Name = "labEstado";
            this.labEstado.Size = new System.Drawing.Size(0, 13);
            this.labEstado.TabIndex = 159;
            // 
            // iesCidade
            // 
            this.iesCidade.BindingField = "Cidade";
            this.iesCidade.ColunasDropdown = null;
            this.iesCidade.DesabilitarAutoCompletar = false;
            this.iesCidade.DesabilitarChekBox = true;
            this.iesCidade.DesabilitarLupa = false;
            this.iesCidade.DesabilitarSeta = false;
            this.iesCidade.EntidadeSelecionada = null;
            this.iesCidade.FormSelecao = null;
            this.iesCidade.LiberadoQuandoCadastroUtilizado = false;
            this.iesCidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iesCidade.Location = new System.Drawing.Point(76, 292);
            this.iesCidade.ModoVisualizacaoGrid = null;
            this.iesCidade.Name = "iesCidade";
            this.iesCidade.ParametroBuscaGuiada = null;
            this.iesCidade.ParametrosBuscaObrigatorios = null;
            this.iesCidade.Size = new System.Drawing.Size(299, 23);
            this.iesCidade.TabIndex = 158;
            this.iesCidade.EntityChange += new System.EventHandler(this.iesCidade_EntityChange);
            // 
            // iesEstadoCtps
            // 
            this.iesEstadoCtps.BindingField = "EstadoCtps";
            this.iesEstadoCtps.ColunasDropdown = null;
            this.iesEstadoCtps.DesabilitarAutoCompletar = false;
            this.iesEstadoCtps.DesabilitarChekBox = false;
            this.iesEstadoCtps.DesabilitarLupa = false;
            this.iesEstadoCtps.DesabilitarSeta = false;
            this.iesEstadoCtps.EntidadeSelecionada = null;
            this.iesEstadoCtps.FormSelecao = null;
            this.iesEstadoCtps.LiberadoQuandoCadastroUtilizado = false;
            this.iesEstadoCtps.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iesEstadoCtps.Location = new System.Drawing.Point(75, 121);
            this.iesEstadoCtps.ModoVisualizacaoGrid = null;
            this.iesEstadoCtps.Name = "iesEstadoCtps";
            this.iesEstadoCtps.ParametroBuscaGuiada = null;
            this.iesEstadoCtps.ParametrosBuscaObrigatorios = null;
            this.iesEstadoCtps.Size = new System.Drawing.Size(321, 23);
            this.iesEstadoCtps.TabIndex = 157;
            // 
            // iwtImage1
            // 
            this.iwtImage1.BindingField = "Foto";
            this.iwtImage1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtImage1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtImage1.Location = new System.Drawing.Point(744, 15);
            this.iwtImage1.Name = "iwtImage1";
            this.iwtImage1.Size = new System.Drawing.Size(107, 160);
            this.iwtImage1.TabIndex = 22;
            this.iwtImage1.Value = null;
            // 
            // iwtLabel10
            // 
            this.iwtLabel10.AutoSize = true;
            this.iwtLabel10.BindingField = null;
            this.iwtLabel10.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel10.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel10.Location = new System.Drawing.Point(16, 121);
            this.iwtLabel10.Name = "iwtLabel10";
            this.iwtLabel10.Size = new System.Drawing.Size(52, 13);
            this.iwtLabel10.TabIndex = 156;
            this.iwtLabel10.Text = "UF CTPS";
            // 
            // iwtTextBox6
            // 
            this.iwtTextBox6.BindingField = "CtpsSerie";
            this.iwtTextBox6.DebugMode = false;
            this.iwtTextBox6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox6.Location = new System.Drawing.Point(448, 91);
            this.iwtTextBox6.MaxLength = 50;
            this.iwtTextBox6.ModoBarcode = false;
            this.iwtTextBox6.ModoBusca = false;
            this.iwtTextBox6.Name = "iwtTextBox6";
            this.iwtTextBox6.NaoLimparDepoisBarcode = false;
            this.iwtTextBox6.Size = new System.Drawing.Size(209, 20);
            this.iwtTextBox6.TabIndex = 6;
            // 
            // iwtLabel9
            // 
            this.iwtLabel9.AutoSize = true;
            this.iwtLabel9.BindingField = null;
            this.iwtLabel9.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel9.Location = new System.Drawing.Point(380, 95);
            this.iwtLabel9.Name = "iwtLabel9";
            this.iwtLabel9.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel9.TabIndex = 154;
            this.iwtLabel9.Text = "Série CTPS";
            // 
            // iwtTextBox5
            // 
            this.iwtTextBox5.BindingField = "Conta";
            this.iwtTextBox5.DebugMode = false;
            this.iwtTextBox5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox5.Location = new System.Drawing.Point(77, 395);
            this.iwtTextBox5.MaxLength = 50;
            this.iwtTextBox5.ModoBarcode = false;
            this.iwtTextBox5.ModoBusca = false;
            this.iwtTextBox5.Name = "iwtTextBox5";
            this.iwtTextBox5.NaoLimparDepoisBarcode = false;
            this.iwtTextBox5.Size = new System.Drawing.Size(257, 20);
            this.iwtTextBox5.TabIndex = 20;
            // 
            // iwtLabel8
            // 
            this.iwtLabel8.AutoSize = true;
            this.iwtLabel8.BindingField = null;
            this.iwtLabel8.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel8.Location = new System.Drawing.Point(36, 398);
            this.iwtLabel8.Name = "iwtLabel8";
            this.iwtLabel8.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel8.TabIndex = 119;
            this.iwtLabel8.Text = "Conta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(34, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 130;
            this.label9.Text = "Email";
            // 
            // iwtTextBox4
            // 
            this.iwtTextBox4.BindingField = "Agencia";
            this.iwtTextBox4.DebugMode = false;
            this.iwtTextBox4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox4.Location = new System.Drawing.Point(448, 369);
            this.iwtTextBox4.MaxLength = 50;
            this.iwtTextBox4.ModoBarcode = false;
            this.iwtTextBox4.ModoBusca = false;
            this.iwtTextBox4.Name = "iwtTextBox4";
            this.iwtTextBox4.NaoLimparDepoisBarcode = false;
            this.iwtTextBox4.Size = new System.Drawing.Size(209, 20);
            this.iwtTextBox4.TabIndex = 19;
            // 
            // iwtLabel7
            // 
            this.iwtLabel7.AutoSize = true;
            this.iwtLabel7.BindingField = null;
            this.iwtLabel7.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel7.Location = new System.Drawing.Point(396, 372);
            this.iwtLabel7.Name = "iwtLabel7";
            this.iwtLabel7.Size = new System.Drawing.Size(46, 13);
            this.iwtLabel7.TabIndex = 118;
            this.iwtLabel7.Text = "Agência";
            // 
            // txtEmail
            // 
            this.txtEmail.BindingField = "Email";
            this.txtEmail.DebugMode = false;
            this.txtEmail.LiberadoQuandoCadastroUtilizado = false;
            this.txtEmail.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtEmail.Location = new System.Drawing.Point(74, 164);
            this.txtEmail.MaxLength = 255;
            this.txtEmail.ModoBarcode = false;
            this.txtEmail.ModoBusca = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.NaoLimparDepoisBarcode = false;
            this.txtEmail.Size = new System.Drawing.Size(258, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // iwtTextBox3
            // 
            this.iwtTextBox3.BindingField = "Banco";
            this.iwtTextBox3.DebugMode = false;
            this.iwtTextBox3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox3.Location = new System.Drawing.Point(76, 369);
            this.iwtTextBox3.MaxLength = 50;
            this.iwtTextBox3.ModoBarcode = false;
            this.iwtTextBox3.ModoBusca = false;
            this.iwtTextBox3.Name = "iwtTextBox3";
            this.iwtTextBox3.NaoLimparDepoisBarcode = false;
            this.iwtTextBox3.Size = new System.Drawing.Size(259, 20);
            this.iwtTextBox3.TabIndex = 18;
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(32, 372);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(38, 13);
            this.iwtLabel6.TabIndex = 116;
            this.iwtLabel6.Text = "Banco";
            // 
            // txtNumeroCob
            // 
            this.txtNumeroCob.BindingField = "EnderecoNumero";
            this.txtNumeroCob.DebugMode = false;
            this.txtNumeroCob.LiberadoQuandoCadastroUtilizado = false;
            this.txtNumeroCob.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtNumeroCob.Location = new System.Drawing.Point(450, 239);
            this.txtNumeroCob.MaxLength = 255;
            this.txtNumeroCob.ModoBarcode = false;
            this.txtNumeroCob.ModoBusca = false;
            this.txtNumeroCob.Name = "txtNumeroCob";
            this.txtNumeroCob.NaoLimparDepoisBarcode = false;
            this.txtNumeroCob.Size = new System.Drawing.Size(208, 20);
            this.txtNumeroCob.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(30, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 127;
            this.label5.Text = "Fone 1";
            // 
            // txtComplementoCob
            // 
            this.txtComplementoCob.BindingField = "EnderecoComplemento";
            this.txtComplementoCob.DebugMode = false;
            this.txtComplementoCob.LiberadoQuandoCadastroUtilizado = false;
            this.txtComplementoCob.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtComplementoCob.Location = new System.Drawing.Point(450, 265);
            this.txtComplementoCob.MaxLength = 255;
            this.txtComplementoCob.ModoBarcode = false;
            this.txtComplementoCob.ModoBusca = false;
            this.txtComplementoCob.Name = "txtComplementoCob";
            this.txtComplementoCob.NaoLimparDepoisBarcode = false;
            this.txtComplementoCob.Size = new System.Drawing.Size(208, 20);
            this.txtComplementoCob.TabIndex = 14;
            // 
            // txtFone2
            // 
            this.txtFone2.BindingField = "Fone2";
            this.txtFone2.LiberadoQuandoCadastroUtilizado = false;
            this.txtFone2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtFone2.Location = new System.Drawing.Point(448, 189);
            this.txtFone2.Mask = "(99)09999-0000";
            this.txtFone2.Name = "txtFone2";
            this.txtFone2.Size = new System.Drawing.Size(207, 20);
            this.txtFone2.TabIndex = 10;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BindingField = null;
            this.label28.LiberadoQuandoCadastroUtilizado = false;
            this.label28.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label28.Location = new System.Drawing.Point(374, 268);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(71, 13);
            this.label28.TabIndex = 152;
            this.label28.Text = "Complemento";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BindingField = null;
            this.label55.LiberadoQuandoCadastroUtilizado = false;
            this.label55.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label55.Location = new System.Drawing.Point(402, 193);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(40, 13);
            this.label55.TabIndex = 128;
            this.label55.Text = "Fone 2";
            // 
            // txtCepCob
            // 
            this.txtCepCob.BindingField = "Cep";
            this.txtCepCob.DebugMode = false;
            this.txtCepCob.LiberadoQuandoCadastroUtilizado = false;
            this.txtCepCob.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCepCob.Location = new System.Drawing.Point(75, 320);
            this.txtCepCob.MaxLength = 100;
            this.txtCepCob.ModoBarcode = false;
            this.txtCepCob.ModoBusca = false;
            this.txtCepCob.Name = "txtCepCob";
            this.txtCepCob.NaoLimparDepoisBarcode = false;
            this.txtCepCob.Size = new System.Drawing.Size(259, 20);
            this.txtCepCob.TabIndex = 17;
            // 
            // txtFone1
            // 
            this.txtFone1.BindingField = "Fone1";
            this.txtFone1.LiberadoQuandoCadastroUtilizado = false;
            this.txtFone1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtFone1.Location = new System.Drawing.Point(75, 190);
            this.txtFone1.Mask = "(99)09999-0000";
            this.txtFone1.Name = "txtFone1";
            this.txtFone1.Size = new System.Drawing.Size(258, 20);
            this.txtFone1.TabIndex = 9;
            // 
            // txtBairroCob
            // 
            this.txtBairroCob.BindingField = "Bairro";
            this.txtBairroCob.DebugMode = false;
            this.txtBairroCob.LiberadoQuandoCadastroUtilizado = false;
            this.txtBairroCob.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBairroCob.Location = new System.Drawing.Point(76, 267);
            this.txtBairroCob.MaxLength = 100;
            this.txtBairroCob.ModoBarcode = false;
            this.txtBairroCob.ModoBusca = false;
            this.txtBairroCob.Name = "txtBairroCob";
            this.txtBairroCob.NaoLimparDepoisBarcode = false;
            this.txtBairroCob.Size = new System.Drawing.Size(259, 20);
            this.txtBairroCob.TabIndex = 13;
            // 
            // txtEnderecoCob
            // 
            this.txtEnderecoCob.BindingField = "Endereco";
            this.txtEnderecoCob.DebugMode = false;
            this.txtEnderecoCob.LiberadoQuandoCadastroUtilizado = false;
            this.txtEnderecoCob.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtEnderecoCob.Location = new System.Drawing.Point(76, 241);
            this.txtEnderecoCob.MaxLength = 255;
            this.txtEnderecoCob.ModoBarcode = false;
            this.txtEnderecoCob.ModoBusca = false;
            this.txtEnderecoCob.Name = "txtEnderecoCob";
            this.txtEnderecoCob.NaoLimparDepoisBarcode = false;
            this.txtEnderecoCob.Size = new System.Drawing.Size(259, 20);
            this.txtEnderecoCob.TabIndex = 11;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BindingField = null;
            this.label29.LiberadoQuandoCadastroUtilizado = false;
            this.label29.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label29.Location = new System.Drawing.Point(37, 268);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(34, 13);
            this.label29.TabIndex = 151;
            this.label29.Text = "Bairro";
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(338, 69);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(104, 13);
            this.iwtLabel5.TabIndex = 122;
            this.iwtLabel5.Text = "Data de Nascimento";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BindingField = null;
            this.label30.LiberadoQuandoCadastroUtilizado = false;
            this.label30.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label30.Location = new System.Drawing.Point(400, 242);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(44, 13);
            this.label30.TabIndex = 150;
            this.label30.Text = "Numero";
            // 
            // iwtDateTimePicker1
            // 
            this.iwtDateTimePicker1.BindingField = "DataNascimento";
            this.iwtDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.iwtDateTimePicker1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtDateTimePicker1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtDateTimePicker1.Location = new System.Drawing.Point(448, 65);
            this.iwtDateTimePicker1.Name = "iwtDateTimePicker1";
            this.iwtDateTimePicker1.Size = new System.Drawing.Size(210, 20);
            this.iwtDateTimePicker1.TabIndex = 4;
            this.iwtDateTimePicker1.Value = new System.DateTime(2022, 5, 16, 15, 20, 3, 705);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BindingField = null;
            this.label31.LiberadoQuandoCadastroUtilizado = false;
            this.label31.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label31.Location = new System.Drawing.Point(31, 294);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(40, 13);
            this.label31.TabIndex = 149;
            this.label31.Text = "Cidade";
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.BindingField = "NumeroCtps";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(75, 92);
            this.iwtTextBox2.MaxLength = 50;
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.ModoBusca = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.NaoLimparDepoisBarcode = false;
            this.iwtTextBox2.Size = new System.Drawing.Size(258, 20);
            this.iwtTextBox2.TabIndex = 5;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BindingField = null;
            this.label32.LiberadoQuandoCadastroUtilizado = false;
            this.label32.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label32.Location = new System.Drawing.Point(424, 294);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(21, 13);
            this.label32.TabIndex = 148;
            this.label32.Text = "UF";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(34, 95);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(35, 13);
            this.iwtLabel2.TabIndex = 120;
            this.iwtLabel2.Text = "CTPS";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BindingField = null;
            this.label34.LiberadoQuandoCadastroUtilizado = false;
            this.label34.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label34.Location = new System.Drawing.Point(41, 320);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(28, 13);
            this.label34.TabIndex = 146;
            this.label34.Text = "CEP";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "Pis";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(75, 66);
            this.iwtTextBox1.MaxLength = 50;
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(258, 20);
            this.iwtTextBox1.TabIndex = 3;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BindingField = null;
            this.label35.LiberadoQuandoCadastroUtilizado = false;
            this.label35.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label35.Location = new System.Drawing.Point(18, 244);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 13);
            this.label35.TabIndex = 145;
            this.label35.Text = "Endereço";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(45, 69);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(24, 13);
            this.iwtLabel1.TabIndex = 118;
            this.iwtLabel1.Text = "PIS";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.BindingField = "Cpf";
            this.txtCNPJ.LiberadoQuandoCadastroUtilizado = false;
            this.txtCNPJ.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCNPJ.Location = new System.Drawing.Point(449, 39);
            this.txtCNPJ.Mask = "000\\.000\\.000\\-00";
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(208, 20);
            this.txtCNPJ.TabIndex = 2;
            // 
            // txtNomeResumido
            // 
            this.txtNomeResumido.BindingField = "Rg";
            this.txtNomeResumido.DebugMode = false;
            this.txtNomeResumido.LiberadoQuandoCadastroUtilizado = false;
            this.txtNomeResumido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtNomeResumido.Location = new System.Drawing.Point(75, 40);
            this.txtNomeResumido.MaxLength = 50;
            this.txtNomeResumido.ModoBarcode = false;
            this.txtNomeResumido.ModoBusca = false;
            this.txtNomeResumido.Name = "txtNomeResumido";
            this.txtNomeResumido.NaoLimparDepoisBarcode = false;
            this.txtNomeResumido.Size = new System.Drawing.Size(258, 20);
            this.txtNomeResumido.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(45, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 114;
            this.label3.Text = "RG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(34, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.BindingField = "Nome";
            this.txtNome.DebugMode = false;
            this.txtNome.LiberadoQuandoCadastroUtilizado = false;
            this.txtNome.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtNome.Location = new System.Drawing.Point(75, 15);
            this.txtNome.MaxLength = 255;
            this.txtNome.ModoBarcode = false;
            this.txtNome.ModoBusca = false;
            this.txtNome.Name = "txtNome";
            this.txtNome.NaoLimparDepoisBarcode = false;
            this.txtNome.Size = new System.Drawing.Size(582, 20);
            this.txtNome.TabIndex = 0;
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.BindingField = null;
            this.lblCNPJ.LiberadoQuandoCadastroUtilizado = false;
            this.lblCNPJ.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblCNPJ.Location = new System.Drawing.Point(416, 42);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(27, 13);
            this.lblCNPJ.TabIndex = 116;
            this.lblCNPJ.Text = "CPF";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(890, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Função";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(890, 506);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "EPI";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.iwtLabel11);
            this.groupBox3.Controls.Add(this.nudQtdEpi);
            this.groupBox3.Controls.Add(this.rdbTodos);
            this.groupBox3.Controls.Add(this.rdbDescart);
            this.groupBox3.Controls.Add(this.rdbVenc);
            this.groupBox3.Controls.Add(this.rdbRet);
            this.groupBox3.Controls.Add(this.rdbPendRet);
            this.groupBox3.Controls.Add(this.btnRemoverEpi);
            this.groupBox3.Controls.Add(this.btnAddEpi);
            this.groupBox3.Controls.Add(this.btnRetiradaEpi);
            this.groupBox3.Controls.Add(this.dgvEpi);
            this.groupBox3.Controls.Add(this.cmbEpi);
            this.groupBox3.Controls.Add(this.iwtLabel4);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(879, 494);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EPIs";
            // 
            // iwtLabel11
            // 
            this.iwtLabel11.AutoSize = true;
            this.iwtLabel11.BindingField = null;
            this.iwtLabel11.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel11.Location = new System.Drawing.Point(452, 23);
            this.iwtLabel11.Name = "iwtLabel11";
            this.iwtLabel11.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel11.TabIndex = 26;
            this.iwtLabel11.Text = "Quantidade";
            // 
            // nudQtdEpi
            // 
            this.nudQtdEpi.BindingField = null;
            this.nudQtdEpi.LiberadoQuandoCadastroUtilizado = false;
            this.nudQtdEpi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdEpi.Location = new System.Drawing.Point(520, 21);
            this.nudQtdEpi.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudQtdEpi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtdEpi.Name = "nudQtdEpi";
            this.nudQtdEpi.Size = new System.Drawing.Size(120, 20);
            this.nudQtdEpi.TabIndex = 25;
            this.nudQtdEpi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdbTodos
            // 
            this.rdbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.BindingField = null;
            this.rdbTodos.Checked = true;
            this.rdbTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodos.Location = new System.Drawing.Point(388, 471);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 24;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbDescart
            // 
            this.rdbDescart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbDescart.AutoSize = true;
            this.rdbDescart.BindingField = null;
            this.rdbDescart.LiberadoQuandoCadastroUtilizado = false;
            this.rdbDescart.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbDescart.Location = new System.Drawing.Point(297, 471);
            this.rdbDescart.Name = "rdbDescart";
            this.rdbDescart.Size = new System.Drawing.Size(85, 17);
            this.rdbDescart.TabIndex = 23;
            this.rdbDescart.Text = "Descartados";
            this.rdbDescart.UseVisualStyleBackColor = true;
            this.rdbDescart.CheckedChanged += new System.EventHandler(this.rdbDescart_CheckedChanged);
            // 
            // rdbVenc
            // 
            this.rdbVenc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbVenc.AutoSize = true;
            this.rdbVenc.BindingField = null;
            this.rdbVenc.LiberadoQuandoCadastroUtilizado = false;
            this.rdbVenc.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbVenc.Location = new System.Drawing.Point(222, 470);
            this.rdbVenc.Name = "rdbVenc";
            this.rdbVenc.Size = new System.Drawing.Size(69, 17);
            this.rdbVenc.TabIndex = 22;
            this.rdbVenc.Text = "Vencidos";
            this.rdbVenc.UseVisualStyleBackColor = true;
            this.rdbVenc.CheckedChanged += new System.EventHandler(this.rdbVenc_CheckedChanged);
            // 
            // rdbRet
            // 
            this.rdbRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbRet.AutoSize = true;
            this.rdbRet.BindingField = null;
            this.rdbRet.LiberadoQuandoCadastroUtilizado = false;
            this.rdbRet.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbRet.Location = new System.Drawing.Point(146, 470);
            this.rdbRet.Name = "rdbRet";
            this.rdbRet.Size = new System.Drawing.Size(70, 17);
            this.rdbRet.TabIndex = 21;
            this.rdbRet.Text = "Retirados";
            this.rdbRet.UseVisualStyleBackColor = true;
            this.rdbRet.CheckedChanged += new System.EventHandler(this.rdbRet_CheckedChanged);
            // 
            // rdbPendRet
            // 
            this.rdbPendRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbPendRet.AutoSize = true;
            this.rdbPendRet.BindingField = null;
            this.rdbPendRet.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPendRet.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPendRet.Location = new System.Drawing.Point(6, 470);
            this.rdbPendRet.Name = "rdbPendRet";
            this.rdbPendRet.Size = new System.Drawing.Size(134, 17);
            this.rdbPendRet.TabIndex = 20;
            this.rdbPendRet.Text = "Pendentes de Retirada";
            this.rdbPendRet.UseVisualStyleBackColor = true;
            this.rdbPendRet.CheckedChanged += new System.EventHandler(this.rdbPendRet_CheckedChanged);
            // 
            // btnRemoverEpi
            // 
            this.btnRemoverEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverEpi.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemoverEpi.Location = new System.Drawing.Point(798, 18);
            this.btnRemoverEpi.Name = "btnRemoverEpi";
            this.btnRemoverEpi.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverEpi.TabIndex = 13;
            this.btnRemoverEpi.Text = "Descartar";
            this.btnRemoverEpi.UseVisualStyleBackColor = true;
            this.btnRemoverEpi.Click += new System.EventHandler(this.btnRemoverEpi_Click_1);
            // 
            // btnAddEpi
            // 
            this.btnAddEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEpi.LiberadoQuandoCadastroUtilizado = false;
            this.btnAddEpi.Location = new System.Drawing.Point(717, 18);
            this.btnAddEpi.Name = "btnAddEpi";
            this.btnAddEpi.Size = new System.Drawing.Size(75, 23);
            this.btnAddEpi.TabIndex = 12;
            this.btnAddEpi.Text = "Adicionar";
            this.btnAddEpi.UseVisualStyleBackColor = true;
            this.btnAddEpi.Click += new System.EventHandler(this.btnAddEpi_Click_1);
            // 
            // btnRetiradaEpi
            // 
            this.btnRetiradaEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRetiradaEpi.LiberadoQuandoCadastroUtilizado = false;
            this.btnRetiradaEpi.Location = new System.Drawing.Point(774, 465);
            this.btnRetiradaEpi.Name = "btnRetiradaEpi";
            this.btnRetiradaEpi.Size = new System.Drawing.Size(104, 23);
            this.btnRetiradaEpi.TabIndex = 15;
            this.btnRetiradaEpi.Text = "Retirada de EPIs";
            this.btnRetiradaEpi.UseVisualStyleBackColor = true;
            this.btnRetiradaEpi.Click += new System.EventHandler(this.btnRelatEpi_Click_1);
            // 
            // dgvEpi
            // 
            this.dgvEpi.AllowUserToAddRows = false;
            this.dgvEpi.AllowUserToDeleteRows = false;
            this.dgvEpi.AllowUserToOrderColumns = true;
            this.dgvEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEpi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.DataRetirada,
            this.DataVencimentoPrevista,
            this.DataDescarte,
            this.Situacao});
            this.dgvEpi.Location = new System.Drawing.Point(6, 48);
            this.dgvEpi.Name = "dgvEpi";
            this.dgvEpi.ReadOnly = true;
            this.dgvEpi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpi.Size = new System.Drawing.Size(873, 413);
            this.dgvEpi.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Epi";
            this.dataGridViewTextBoxColumn2.HeaderText = "EPI";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // DataRetirada
            // 
            this.DataRetirada.DataPropertyName = "DataRetirada";
            this.DataRetirada.HeaderText = "Data Retirada";
            this.DataRetirada.Name = "DataRetirada";
            this.DataRetirada.ReadOnly = true;
            this.DataRetirada.Width = 150;
            // 
            // DataVencimentoPrevista
            // 
            this.DataVencimentoPrevista.DataPropertyName = "DataVencimentoPrevista";
            this.DataVencimentoPrevista.HeaderText = "Substituir Até";
            this.DataVencimentoPrevista.Name = "DataVencimentoPrevista";
            this.DataVencimentoPrevista.ReadOnly = true;
            this.DataVencimentoPrevista.Width = 150;
            // 
            // DataDescarte
            // 
            this.DataDescarte.DataPropertyName = "DataDescarte";
            this.DataDescarte.HeaderText = "Data Descarte";
            this.DataDescarte.Name = "DataDescarte";
            this.DataDescarte.ReadOnly = true;
            this.DataDescarte.Width = 150;
            // 
            // Situacao
            // 
            this.Situacao.DataPropertyName = "Situacao";
            this.Situacao.HeaderText = "Situação";
            this.Situacao.Name = "Situacao";
            this.Situacao.ReadOnly = true;
            this.Situacao.Width = 150;
            // 
            // cmbEpi
            // 
            this.cmbEpi.BindingField = null;
            this.cmbEpi.ColumnsToDisplay = null;
            this.cmbEpi.DisableAutoSelectOnEmpty = false;
            this.cmbEpi.DropDownHeight = 1;
            this.cmbEpi.FormattingEnabled = true;
            this.cmbEpi.IntegralHeight = false;
            this.cmbEpi.LiberadoQuandoCadastroUtilizado = false;
            this.cmbEpi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbEpi.Location = new System.Drawing.Point(76, 21);
            this.cmbEpi.Name = "cmbEpi";
            this.cmbEpi.SelectedRow = null;
            this.cmbEpi.Size = new System.Drawing.Size(342, 21);
            this.cmbEpi.TabIndex = 10;
            this.cmbEpi.Table = null;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(48, 24);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(22, 13);
            this.iwtLabel4.TabIndex = 11;
            this.iwtLabel4.Text = "Epi";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnDocumentoAbrir);
            this.tabPage5.Controls.Add(this.btnDocumentoExcluir);
            this.tabPage5.Controls.Add(this.btnDocumentoNovo);
            this.tabPage5.Controls.Add(this.dgvDocumentos);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(890, 506);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Documentos";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnDocumentoAbrir
            // 
            this.btnDocumentoAbrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentoAbrir.LiberadoQuandoCadastroUtilizado = true;
            this.btnDocumentoAbrir.Location = new System.Drawing.Point(807, 7);
            this.btnDocumentoAbrir.Name = "btnDocumentoAbrir";
            this.btnDocumentoAbrir.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentoAbrir.TabIndex = 2;
            this.btnDocumentoAbrir.Text = "Visualizar";
            this.btnDocumentoAbrir.UseVisualStyleBackColor = true;
            this.btnDocumentoAbrir.Click += new System.EventHandler(this.btnDocumentoAbrir_Click);
            // 
            // btnDocumentoExcluir
            // 
            this.btnDocumentoExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentoExcluir.LiberadoQuandoCadastroUtilizado = false;
            this.btnDocumentoExcluir.Location = new System.Drawing.Point(726, 7);
            this.btnDocumentoExcluir.Name = "btnDocumentoExcluir";
            this.btnDocumentoExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentoExcluir.TabIndex = 1;
            this.btnDocumentoExcluir.Text = "Remover";
            this.btnDocumentoExcluir.UseVisualStyleBackColor = true;
            this.btnDocumentoExcluir.Click += new System.EventHandler(this.btnDocumentoExcluir_Click);
            // 
            // btnDocumentoNovo
            // 
            this.btnDocumentoNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentoNovo.LiberadoQuandoCadastroUtilizado = false;
            this.btnDocumentoNovo.Location = new System.Drawing.Point(645, 7);
            this.btnDocumentoNovo.Name = "btnDocumentoNovo";
            this.btnDocumentoNovo.Size = new System.Drawing.Size(75, 23);
            this.btnDocumentoNovo.TabIndex = 0;
            this.btnDocumentoNovo.Text = "Adicionar";
            this.btnDocumentoNovo.UseVisualStyleBackColor = true;
            this.btnDocumentoNovo.Click += new System.EventHandler(this.btnDocumentoNovo_Click);
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AllowUserToOrderColumns = true;
            this.dgvDocumentos.AllowUserToResizeRows = false;
            this.dgvDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocumentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvDocumentos.CacheDados = null;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.Identificacao,
            this.NomeArquivo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocumentos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.None;
            this.dgvDocumentos.Location = new System.Drawing.Point(3, 36);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.RowHeadersVisible = false;
            this.dgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumentos.Size = new System.Drawing.Size(879, 464);
            this.dgvDocumentos.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // Identificacao
            // 
            this.Identificacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Identificacao.DataPropertyName = "Identificacao";
            this.Identificacao.HeaderText = "Identificação";
            this.Identificacao.MinimumWidth = 150;
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.ReadOnly = true;
            // 
            // NomeArquivo
            // 
            this.NomeArquivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NomeArquivo.DataPropertyName = "NomeArquivo";
            this.NomeArquivo.HeaderText = "Nome Arquivo";
            this.NomeArquivo.Name = "NomeArquivo";
            this.NomeArquivo.ReadOnly = true;
            this.NomeArquivo.Width = 200;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(890, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Revisão";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CadFuncionarioForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(898, 598);
            this.Name = "CadFuncionarioForm";
            this.Text = "Funcionário";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncao)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdEpi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFuncao;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbFuncao;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label24;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private System.Windows.Forms.Label label25;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private System.Windows.Forms.Label label26;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private IWTButton btnAddFuncao;
        private IWTButton btnRemoveFuncao;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTMaskedTextBox txtCNPJ;
        private IWTDotNetLib.IWTTextBox txtNomeResumido;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTLabel label4;
        private IWTDotNetLib.IWTTextBox txtNome;
        private IWTDotNetLib.IWTLabel lblCNPJ;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTDateTimePicker iwtDateTimePicker1;
        private IWTDotNetLib.IWTTextBox txtNumeroCob;
        private IWTDotNetLib.IWTTextBox txtComplementoCob;
        private IWTDotNetLib.IWTLabel label28;
        private IWTDotNetLib.IWTTextBox txtCepCob;
        private IWTDotNetLib.IWTTextBox txtBairroCob;
        private IWTDotNetLib.IWTTextBox txtEnderecoCob;
        private IWTDotNetLib.IWTLabel label29;
        private IWTDotNetLib.IWTLabel label30;
        private IWTDotNetLib.IWTLabel label31;
        private IWTDotNetLib.IWTLabel label32;
        private IWTDotNetLib.IWTLabel label34;
        private IWTDotNetLib.IWTLabel label35;
        private IWTDotNetLib.IWTLabel label5;
        private IWTMaskedTextBox txtFone2;
        private IWTDotNetLib.IWTLabel label55;
        private IWTMaskedTextBox txtFone1;
        private IWTDotNetLib.IWTLabel label9;
        private IWTDotNetLib.IWTTextBox txtEmail;
        private IWTDotNetLib.IWTTextBox iwtTextBox5;
        private IWTDotNetLib.IWTLabel iwtLabel8;
        private IWTDotNetLib.IWTTextBox iwtTextBox4;
        private IWTDotNetLib.IWTLabel iwtLabel7;
        private IWTDotNetLib.IWTTextBox iwtTextBox3;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTButton btnRemoverEpi;
        private IWTButton btnAddEpi;
        private IWTButton btnRetiradaEpi;
        private System.Windows.Forms.DataGridView dgvEpi;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbEpi;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTRadioButton rdbTodos;
        private IWTDotNetLib.IWTRadioButton rdbDescart;
        private IWTDotNetLib.IWTRadioButton rdbVenc;
        private IWTDotNetLib.IWTRadioButton rdbRet;
        private IWTDotNetLib.IWTRadioButton rdbPendRet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcao;
        private System.Windows.Forms.DataGridViewTextBoxColumn InicioVigencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn FimVigencia;
        private IWTDotNetLib.IWTLabel iwtLabel10;
        private IWTDotNetLib.IWTTextBox iwtTextBox6;
        private IWTDotNetLib.IWTLabel iwtLabel9;
        private IWTDotNetLib.IWTImage iwtImage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataVencimentoPrevista;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataDescarte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
        private IWTDotNetLib.IWTLabel iwtLabel11;
        private IWTDotNetLib.IWTNumericUpDown nudQtdEpi;
        private IWTDotNetLib.IWTEntitySelection iesEstadoCtps;
        private IWTDotNetLib.IWTEntitySelection iesCidade;
        private IWTDotNetLib.IWTLabel labEstado;
        private IWTDateTimePicker iwtDateTimePicker2;
        private IWTLabel iwtLabel12;
        private System.Windows.Forms.TabPage tabPage5;
        private IWTButton btnDocumentoAbrir;
        private IWTButton btnDocumentoExcluir;
        private IWTButton btnDocumentoNovo;
        private IWTDataGridView dgvDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeArquivo;
    }
}