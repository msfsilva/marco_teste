using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadDocumentoTipoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.IdentificacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Identificacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.DescricaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Descricao = new IWTDotNetLib.IWTTextBox(this.components);
            this.grbRevisao = new System.Windows.Forms.GroupBox();
            this.lblRevisaoJustificativa = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoJustificativaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoDataLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuarioLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtRevisao = new IWTDotNetLib.IWTTextBox(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvFamilias = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnCopias = new IWTDotNetLib.IWTButton(this.components);
            this.chkBloqueado = new IWTDotNetLib.IWTCheckBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnkDocumento = new IWTDotNetLib.IWTLinkLabel(this.components);
            this.btnDocumentoEscaneado = new IWTDotNetLib.IWTButton(this.components);
            this.grbValidacaoDocumento = new System.Windows.Forms.GroupBox();
            this.txtClienteDocumentoFamilia = new IWTDotNetLib.IWTTextBox(this.components);
            this.label6 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtClienteDocumento = new IWTDotNetLib.IWTTextBox(this.components);
            this.rdbNaoPermitir = new IWTDotNetLib.IWTRadioButton(this.components);
            this.txtClienteDocumentoRevisao = new IWTDotNetLib.IWTTextBox(this.components);
            this.rdbPermitirComAviso = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbNaoValidar = new IWTDotNetLib.IWTRadioButton(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbFamilia = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.btnFamiliaDel = new IWTDotNetLib.IWTButton(this.components);
            this.btnFamiliaAdd = new IWTDotNetLib.IWTButton(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.ofdDocumento = new System.Windows.Forms.OpenFileDialog();
            this.fbdDocumento = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbRevisao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grbValidacaoDocumento.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(790, 620);
            this.splitContainer1.SplitterDistance = 554;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(703, 20);
            // 
            // IdentificacaoLabel
            // 
            this.IdentificacaoLabel.AutoSize = true;
            this.IdentificacaoLabel.BindingField = null;
            this.IdentificacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.IdentificacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.IdentificacaoLabel.Location = new System.Drawing.Point(13, 17);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(68, 13);
            this.IdentificacaoLabel.TabIndex = 0;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // Identificacao
            // 
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.DebugMode = false;
            this.Identificacao.LiberadoQuandoCadastroUtilizado = false;
            this.Identificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Identificacao.Location = new System.Drawing.Point(87, 14);
            this.Identificacao.ModoBarcode = false;
            this.Identificacao.ModoBusca = false;
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.NaoLimparDepoisBarcode = false;
            this.Identificacao.Size = new System.Drawing.Size(150, 20);
            this.Identificacao.TabIndex = 1;
            // 
            // DescricaoLabel
            // 
            this.DescricaoLabel.AutoSize = true;
            this.DescricaoLabel.BindingField = null;
            this.DescricaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.DescricaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.DescricaoLabel.Location = new System.Drawing.Point(26, 43);
            this.DescricaoLabel.Name = "DescricaoLabel";
            this.DescricaoLabel.Size = new System.Drawing.Size(55, 13);
            this.DescricaoLabel.TabIndex = 2;
            this.DescricaoLabel.Text = "Descrição";
            // 
            // Descricao
            // 
            this.Descricao.BindingField = "Descricao";
            this.Descricao.DebugMode = false;
            this.Descricao.LiberadoQuandoCadastroUtilizado = true;
            this.Descricao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Descricao.Location = new System.Drawing.Point(87, 40);
            this.Descricao.ModoBarcode = false;
            this.Descricao.ModoBusca = false;
            this.Descricao.Name = "Descricao";
            this.Descricao.NaoLimparDepoisBarcode = false;
            this.Descricao.Size = new System.Drawing.Size(296, 20);
            this.Descricao.TabIndex = 3;
            // 
            // grbRevisao
            // 
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativa);
            this.grbRevisao.Controls.Add(this.lblRevisaoData);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuario);
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativaLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoDataLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuarioLabel);
            this.grbRevisao.Location = new System.Drawing.Point(389, 2);
            this.grbRevisao.Name = "grbRevisao";
            this.grbRevisao.Size = new System.Drawing.Size(382, 94);
            this.grbRevisao.TabIndex = 8;
            this.grbRevisao.TabStop = false;
            this.grbRevisao.Text = "Revisão";
            // 
            // lblRevisaoJustificativa
            // 
            this.lblRevisaoJustificativa.AutoSize = true;
            this.lblRevisaoJustificativa.BindingField = "UltimaRevisao";
            this.lblRevisaoJustificativa.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoJustificativa.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoJustificativa.Location = new System.Drawing.Point(100, 62);
            this.lblRevisaoJustificativa.Name = "lblRevisaoJustificativa";
            this.lblRevisaoJustificativa.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoJustificativa.TabIndex = 5;
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
            // lblRevisaoJustificativaLabel
            // 
            this.lblRevisaoJustificativaLabel.AutoSize = true;
            this.lblRevisaoJustificativaLabel.BindingField = null;
            this.lblRevisaoJustificativaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoJustificativaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoJustificativaLabel.Location = new System.Drawing.Point(16, 62);
            this.lblRevisaoJustificativaLabel.Name = "lblRevisaoJustificativaLabel";
            this.lblRevisaoJustificativaLabel.Size = new System.Drawing.Size(62, 13);
            this.lblRevisaoJustificativaLabel.TabIndex = 2;
            this.lblRevisaoJustificativaLabel.Text = "Justificativa";
            // 
            // lblRevisaoDataLabel
            // 
            this.lblRevisaoDataLabel.AutoSize = true;
            this.lblRevisaoDataLabel.BindingField = null;
            this.lblRevisaoDataLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoDataLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoDataLabel.Location = new System.Drawing.Point(48, 39);
            this.lblRevisaoDataLabel.Name = "lblRevisaoDataLabel";
            this.lblRevisaoDataLabel.Size = new System.Drawing.Size(30, 13);
            this.lblRevisaoDataLabel.TabIndex = 1;
            this.lblRevisaoDataLabel.Text = "Data";
            // 
            // lblRevisaoUsuarioLabel
            // 
            this.lblRevisaoUsuarioLabel.AutoSize = true;
            this.lblRevisaoUsuarioLabel.BindingField = null;
            this.lblRevisaoUsuarioLabel.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuarioLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuarioLabel.Location = new System.Drawing.Point(35, 16);
            this.lblRevisaoUsuarioLabel.Name = "lblRevisaoUsuarioLabel";
            this.lblRevisaoUsuarioLabel.Size = new System.Drawing.Size(43, 13);
            this.lblRevisaoUsuarioLabel.TabIndex = 0;
            this.lblRevisaoUsuarioLabel.Text = "Usuário";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(35, 69);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(46, 13);
            this.iwtLabel1.TabIndex = 9;
            this.iwtLabel1.Text = "Revisão";
            // 
            // txtRevisao
            // 
            this.txtRevisao.BindingField = "RevisaoAtual";
            this.txtRevisao.DebugMode = false;
            this.txtRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.txtRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtRevisao.Location = new System.Drawing.Point(87, 66);
            this.txtRevisao.ModoBarcode = false;
            this.txtRevisao.ModoBusca = false;
            this.txtRevisao.Name = "txtRevisao";
            this.txtRevisao.NaoLimparDepoisBarcode = false;
            this.txtRevisao.Size = new System.Drawing.Size(39, 20);
            this.txtRevisao.TabIndex = 10;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.Identificacao);
            this.splitContainer3.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.grbRevisao);
            this.splitContainer3.Panel1.Controls.Add(this.txtRevisao);
            this.splitContainer3.Panel1.Controls.Add(this.Descricao);
            this.splitContainer3.Panel1.Controls.Add(this.IdentificacaoLabel);
            this.splitContainer3.Panel1.Controls.Add(this.DescricaoLabel);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(790, 554);
            this.splitContainer3.SplitterDistance = 101;
            this.splitContainer3.TabIndex = 11;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvFamilias);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnCopias);
            this.splitContainer4.Panel2.Controls.Add(this.chkBloqueado);
            this.splitContainer4.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer4.Panel2.Controls.Add(this.grbValidacaoDocumento);
            this.splitContainer4.Panel2.Controls.Add(this.cmbFamilia);
            this.splitContainer4.Panel2.Controls.Add(this.btnFamiliaDel);
            this.splitContainer4.Panel2.Controls.Add(this.btnFamiliaAdd);
            this.splitContainer4.Panel2.Controls.Add(this.label9);
            this.splitContainer4.Size = new System.Drawing.Size(790, 449);
            this.splitContainer4.SplitterDistance = 517;
            this.splitContainer4.TabIndex = 0;
            // 
            // dgvFamilias
            // 
            this.dgvFamilias.AllowUserToAddRows = false;
            this.dgvFamilias.AllowUserToDeleteRows = false;
            this.dgvFamilias.AllowUserToOrderColumns = true;
            this.dgvFamilias.AllowUserToResizeRows = false;
            this.dgvFamilias.BackgroundColor = System.Drawing.Color.White;
            this.dgvFamilias.CacheDados = null;
            this.dgvFamilias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFamilias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFamilias.Location = new System.Drawing.Point(0, 0);
            this.dgvFamilias.Name = "dgvFamilias";
            this.dgvFamilias.ReadOnly = true;
            this.dgvFamilias.RowHeadersVisible = false;
            this.dgvFamilias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFamilias.Size = new System.Drawing.Size(517, 449);
            this.dgvFamilias.TabIndex = 0;
            this.dgvFamilias.SelectionChanged += new System.EventHandler(this.dgvFamilias_SelectionChanged);
            // 
            // btnCopias
            // 
            this.btnCopias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopias.LiberadoQuandoCadastroUtilizado = false;
            this.btnCopias.Location = new System.Drawing.Point(6, 423);
            this.btnCopias.Name = "btnCopias";
            this.btnCopias.Size = new System.Drawing.Size(258, 23);
            this.btnCopias.TabIndex = 6;
            this.btnCopias.Text = "Cópias do Documento/Familia";
            this.btnCopias.UseVisualStyleBackColor = true;
            this.btnCopias.Click += new System.EventHandler(this.btnCopias_Click);
            // 
            // chkBloqueado
            // 
            this.chkBloqueado.AutoSize = true;
            this.chkBloqueado.BindingField = null;
            this.chkBloqueado.LiberadoQuandoCadastroUtilizado = false;
            this.chkBloqueado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkBloqueado.Location = new System.Drawing.Point(11, 124);
            this.chkBloqueado.Name = "chkBloqueado";
            this.chkBloqueado.Size = new System.Drawing.Size(77, 17);
            this.chkBloqueado.TabIndex = 2;
            this.chkBloqueado.Text = "Bloqueado";
            this.chkBloqueado.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnkDocumento);
            this.groupBox2.Controls.Add(this.btnDocumentoEscaneado);
            this.groupBox2.Location = new System.Drawing.Point(9, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 57);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documento Escaneado/PDF";
            // 
            // lnkDocumento
            // 
            this.lnkDocumento.BindingField = null;
            this.lnkDocumento.LiberadoQuandoCadastroUtilizado = true;
            this.lnkDocumento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lnkDocumento.Location = new System.Drawing.Point(6, 29);
            this.lnkDocumento.Name = "lnkDocumento";
            this.lnkDocumento.Size = new System.Drawing.Size(156, 13);
            this.lnkDocumento.TabIndex = 11;
            this.lnkDocumento.TabStop = true;
            this.lnkDocumento.Text = "Download: ";
            this.lnkDocumento.Visible = false;
            this.lnkDocumento.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDocumento_LinkClicked);
            // 
            // btnDocumentoEscaneado
            // 
            this.btnDocumentoEscaneado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDocumentoEscaneado.LiberadoQuandoCadastroUtilizado = false;
            this.btnDocumentoEscaneado.Location = new System.Drawing.Point(168, 24);
            this.btnDocumentoEscaneado.Name = "btnDocumentoEscaneado";
            this.btnDocumentoEscaneado.Size = new System.Drawing.Size(85, 23);
            this.btnDocumentoEscaneado.TabIndex = 0;
            this.btnDocumentoEscaneado.Text = "Selecionar";
            this.btnDocumentoEscaneado.UseVisualStyleBackColor = true;
            this.btnDocumentoEscaneado.Click += new System.EventHandler(this.btnDocumentoEscaneado_Click);
            // 
            // grbValidacaoDocumento
            // 
            this.grbValidacaoDocumento.Controls.Add(this.txtClienteDocumentoFamilia);
            this.grbValidacaoDocumento.Controls.Add(this.label6);
            this.grbValidacaoDocumento.Controls.Add(this.txtClienteDocumento);
            this.grbValidacaoDocumento.Controls.Add(this.rdbNaoPermitir);
            this.grbValidacaoDocumento.Controls.Add(this.txtClienteDocumentoRevisao);
            this.grbValidacaoDocumento.Controls.Add(this.rdbPermitirComAviso);
            this.grbValidacaoDocumento.Controls.Add(this.rdbNaoValidar);
            this.grbValidacaoDocumento.Controls.Add(this.label7);
            this.grbValidacaoDocumento.Controls.Add(this.label8);
            this.grbValidacaoDocumento.Location = new System.Drawing.Point(9, 153);
            this.grbValidacaoDocumento.Name = "grbValidacaoDocumento";
            this.grbValidacaoDocumento.Size = new System.Drawing.Size(258, 176);
            this.grbValidacaoDocumento.TabIndex = 3;
            this.grbValidacaoDocumento.TabStop = false;
            this.grbValidacaoDocumento.Text = "Validação de documento do pedido do Cliente";
            // 
            // txtClienteDocumentoFamilia
            // 
            this.txtClienteDocumentoFamilia.BindingField = null;
            this.txtClienteDocumentoFamilia.DebugMode = false;
            this.txtClienteDocumentoFamilia.Enabled = false;
            this.txtClienteDocumentoFamilia.LiberadoQuandoCadastroUtilizado = false;
            this.txtClienteDocumentoFamilia.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtClienteDocumentoFamilia.Location = new System.Drawing.Point(74, 98);
            this.txtClienteDocumentoFamilia.MaxLength = 10;
            this.txtClienteDocumentoFamilia.ModoBarcode = false;
            this.txtClienteDocumentoFamilia.ModoBusca = false;
            this.txtClienteDocumentoFamilia.Name = "txtClienteDocumentoFamilia";
            this.txtClienteDocumentoFamilia.NaoLimparDepoisBarcode = false;
            this.txtClienteDocumentoFamilia.Size = new System.Drawing.Size(126, 20);
            this.txtClienteDocumentoFamilia.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BindingField = null;
            this.label6.Enabled = false;
            this.label6.LiberadoQuandoCadastroUtilizado = false;
            this.label6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label6.Location = new System.Drawing.Point(29, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Familia";
            // 
            // txtClienteDocumento
            // 
            this.txtClienteDocumento.BindingField = null;
            this.txtClienteDocumento.DebugMode = false;
            this.txtClienteDocumento.Enabled = false;
            this.txtClienteDocumento.LiberadoQuandoCadastroUtilizado = false;
            this.txtClienteDocumento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtClienteDocumento.Location = new System.Drawing.Point(74, 121);
            this.txtClienteDocumento.MaxLength = 10;
            this.txtClienteDocumento.ModoBarcode = false;
            this.txtClienteDocumento.ModoBusca = false;
            this.txtClienteDocumento.Name = "txtClienteDocumento";
            this.txtClienteDocumento.NaoLimparDepoisBarcode = false;
            this.txtClienteDocumento.Size = new System.Drawing.Size(126, 20);
            this.txtClienteDocumento.TabIndex = 7;
            // 
            // rdbNaoPermitir
            // 
            this.rdbNaoPermitir.AutoSize = true;
            this.rdbNaoPermitir.BindingField = null;
            this.rdbNaoPermitir.LiberadoQuandoCadastroUtilizado = false;
            this.rdbNaoPermitir.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbNaoPermitir.Location = new System.Drawing.Point(13, 65);
            this.rdbNaoPermitir.Name = "rdbNaoPermitir";
            this.rdbNaoPermitir.Size = new System.Drawing.Size(177, 17);
            this.rdbNaoPermitir.TabIndex = 2;
            this.rdbNaoPermitir.Text = "Não Permitir documento inválido";
            this.rdbNaoPermitir.UseVisualStyleBackColor = true;
            this.rdbNaoPermitir.CheckedChanged += new System.EventHandler(this.rdbNaoPermitir_CheckedChanged);
            // 
            // txtClienteDocumentoRevisao
            // 
            this.txtClienteDocumentoRevisao.BindingField = null;
            this.txtClienteDocumentoRevisao.DebugMode = false;
            this.txtClienteDocumentoRevisao.Enabled = false;
            this.txtClienteDocumentoRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.txtClienteDocumentoRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtClienteDocumentoRevisao.Location = new System.Drawing.Point(74, 144);
            this.txtClienteDocumentoRevisao.MaxLength = 2;
            this.txtClienteDocumentoRevisao.ModoBarcode = false;
            this.txtClienteDocumentoRevisao.ModoBusca = false;
            this.txtClienteDocumentoRevisao.Name = "txtClienteDocumentoRevisao";
            this.txtClienteDocumentoRevisao.NaoLimparDepoisBarcode = false;
            this.txtClienteDocumentoRevisao.Size = new System.Drawing.Size(36, 20);
            this.txtClienteDocumentoRevisao.TabIndex = 8;
            // 
            // rdbPermitirComAviso
            // 
            this.rdbPermitirComAviso.AutoSize = true;
            this.rdbPermitirComAviso.BindingField = null;
            this.rdbPermitirComAviso.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPermitirComAviso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPermitirComAviso.Location = new System.Drawing.Point(13, 42);
            this.rdbPermitirComAviso.Name = "rdbPermitirComAviso";
            this.rdbPermitirComAviso.Size = new System.Drawing.Size(206, 17);
            this.rdbPermitirComAviso.TabIndex = 1;
            this.rdbPermitirComAviso.Text = "Permitir documento inválido com Aviso";
            this.rdbPermitirComAviso.UseVisualStyleBackColor = true;
            this.rdbPermitirComAviso.CheckedChanged += new System.EventHandler(this.rdbPermitirComAviso_CheckedChanged);
            // 
            // rdbNaoValidar
            // 
            this.rdbNaoValidar.AutoSize = true;
            this.rdbNaoValidar.BindingField = null;
            this.rdbNaoValidar.Checked = true;
            this.rdbNaoValidar.LiberadoQuandoCadastroUtilizado = false;
            this.rdbNaoValidar.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbNaoValidar.Location = new System.Drawing.Point(13, 19);
            this.rdbNaoValidar.Name = "rdbNaoValidar";
            this.rdbNaoValidar.Size = new System.Drawing.Size(80, 17);
            this.rdbNaoValidar.TabIndex = 0;
            this.rdbNaoValidar.TabStop = true;
            this.rdbNaoValidar.Text = "Não Validar";
            this.rdbNaoValidar.UseVisualStyleBackColor = true;
            this.rdbNaoValidar.CheckedChanged += new System.EventHandler(this.rdbNaoValidar_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.Enabled = false;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(22, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Revisão";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.Enabled = false;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(5, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Documento";
            // 
            // cmbFamilia
            // 
            this.cmbFamilia.BindingField = null;
            this.cmbFamilia.ColumnsToDisplay = null;
            this.cmbFamilia.DisableAutoSelectOnEmpty = false;
            this.cmbFamilia.DropDownHeight = 1;
            this.cmbFamilia.FormattingEnabled = true;
            this.cmbFamilia.IntegralHeight = false;
            this.cmbFamilia.LiberadoQuandoCadastroUtilizado = false;
            this.cmbFamilia.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbFamilia.Location = new System.Drawing.Point(9, 29);
            this.cmbFamilia.Name = "cmbFamilia";
            this.cmbFamilia.SelectedRow = null;
            this.cmbFamilia.Size = new System.Drawing.Size(169, 21);
            this.cmbFamilia.TabIndex = 0;
            this.cmbFamilia.Table = null;
            this.cmbFamilia.SelectedIndexChanged += new System.EventHandler(this.cmbFamilia_SelectedIndexChanged);
            // 
            // btnFamiliaDel
            // 
            this.btnFamiliaDel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFamiliaDel.LiberadoQuandoCadastroUtilizado = false;
            this.btnFamiliaDel.Location = new System.Drawing.Point(6, 364);
            this.btnFamiliaDel.Name = "btnFamiliaDel";
            this.btnFamiliaDel.Size = new System.Drawing.Size(258, 23);
            this.btnFamiliaDel.TabIndex = 5;
            this.btnFamiliaDel.Text = "Remover Familia";
            this.btnFamiliaDel.UseVisualStyleBackColor = true;
            this.btnFamiliaDel.Click += new System.EventHandler(this.btnFamiliaDel_Click);
            // 
            // btnFamiliaAdd
            // 
            this.btnFamiliaAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFamiliaAdd.LiberadoQuandoCadastroUtilizado = false;
            this.btnFamiliaAdd.Location = new System.Drawing.Point(6, 335);
            this.btnFamiliaAdd.Name = "btnFamiliaAdd";
            this.btnFamiliaAdd.Size = new System.Drawing.Size(258, 23);
            this.btnFamiliaAdd.TabIndex = 4;
            this.btnFamiliaAdd.Text = "Adicionar/Atualizar Familia";
            this.btnFamiliaAdd.UseVisualStyleBackColor = true;
            this.btnFamiliaAdd.Click += new System.EventHandler(this.btnFamiliaAdd_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(8, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Adicionar Familia";
            // 
            // ofdDocumento
            // 
            this.ofdDocumento.DefaultExt = "pdf";
            this.ofdDocumento.Filter = "PDF|*.pdf|JPG|*.jpg|BMP|*.bmp|PNG|*.png";
            this.ofdDocumento.RestoreDirectory = true;
            // 
            // CadDocumentoTipoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(790, 620);
            this.Name = "CadDocumentoTipoForm";
            this.Text = "Documento";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbRevisao.ResumeLayout(false);
            this.grbRevisao.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grbValidacaoDocumento.ResumeLayout(false);
            this.grbValidacaoDocumento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel IdentificacaoLabel;
        private IWTDotNetLib.IWTTextBox Identificacao;
        private IWTDotNetLib.IWTLabel DescricaoLabel;
        private IWTDotNetLib.IWTTextBox Descricao;
        private System.Windows.Forms.GroupBox grbRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativaLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoDataLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuarioLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativa;
        private IWTDotNetLib.IWTLabel lblRevisaoData; 
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox txtRevisao;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private IWTDotNetLib.IWTDataGridView dgvFamilias;
        private IWTDotNetLib.IWTCheckBox chkBloqueado;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTLinkLabel lnkDocumento;
        private IWTDotNetLib.IWTButton btnDocumentoEscaneado;
        private System.Windows.Forms.GroupBox grbValidacaoDocumento;
        private IWTDotNetLib.IWTTextBox txtClienteDocumentoFamilia;
        private IWTDotNetLib.IWTLabel label6;
        private IWTDotNetLib.IWTTextBox txtClienteDocumento;
        private IWTDotNetLib.IWTRadioButton rdbNaoPermitir;
        private IWTDotNetLib.IWTTextBox txtClienteDocumentoRevisao;
        private IWTDotNetLib.IWTRadioButton rdbPermitirComAviso;
        private IWTDotNetLib.IWTRadioButton rdbNaoValidar;
        private IWTDotNetLib.IWTLabel label7;
        private IWTDotNetLib.IWTLabel label8;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbFamilia;
        private IWTDotNetLib.IWTButton btnFamiliaDel;
        private IWTDotNetLib.IWTButton btnFamiliaAdd;
        private IWTDotNetLib.IWTLabel label9;
        private System.Windows.Forms.OpenFileDialog ofdDocumento;
        private System.Windows.Forms.FolderBrowserDialog fbdDocumento;
        private IWTButton btnCopias; 
    }
} 
