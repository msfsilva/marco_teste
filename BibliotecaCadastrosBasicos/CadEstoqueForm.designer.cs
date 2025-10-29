namespace BibliotecaCadastrosBasicos
{
    partial class CadEstoqueForm
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
            this.grbRevisao = new System.Windows.Forms.GroupBox();
            this.lblRevisaoJustificativa = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoJustificativaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoDataLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuarioLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TipoAlocacaoEstoque_MateriaPrima = new IWTDotNetLib.IWTRadioButton(this.components);
            this.TipoAlocacaoEstoque_Consumo = new IWTDotNetLib.IWTRadioButton(this.components);
            this.Identificacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.IdentificacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.DescricaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Descricao = new IWTDotNetLib.IWTTextBox(this.components);
            this.AtivoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Ativo = new IWTDotNetLib.IWTCheckBox(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.treEstoque = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.btnSubAtualizar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSubIncluir = new System.Windows.Forms.Button();
            this.txtSubDescricao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubIdentificacao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubEtiqueta = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbRevisao.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(559, 475);
            this.splitContainer1.SplitterDistance = 409;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(472, 20);
            // 
            // grbRevisao
            // 
            this.grbRevisao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativa);
            this.grbRevisao.Controls.Add(this.lblRevisaoData);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuario);
            this.grbRevisao.Controls.Add(this.lblRevisaoJustificativaLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoDataLabel);
            this.grbRevisao.Controls.Add(this.lblRevisaoUsuarioLabel);
            this.grbRevisao.Location = new System.Drawing.Point(8, 224);
            this.grbRevisao.Name = "grbRevisao";
            this.grbRevisao.Size = new System.Drawing.Size(456, 94);
            this.grbRevisao.TabIndex = 10;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(559, 409);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.Identificacao);
            this.tabPage1.Controls.Add(this.IdentificacaoLabel);
            this.tabPage1.Controls.Add(this.DescricaoLabel);
            this.tabPage1.Controls.Add(this.Descricao);
            this.tabPage1.Controls.Add(this.AtivoLabel);
            this.tabPage1.Controls.Add(this.Ativo);
            this.tabPage1.Controls.Add(this.grbRevisao);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(472, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do Estoque";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.TipoAlocacaoEstoque_MateriaPrima);
            this.groupBox1.Controls.Add(this.TipoAlocacaoEstoque_Consumo);
            this.groupBox1.Location = new System.Drawing.Point(8, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 72);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Itens Alocados";
            // 
            // TipoAlocacaoEstoque_MateriaPrima
            // 
            this.TipoAlocacaoEstoque_MateriaPrima.AutoSize = true;
            this.TipoAlocacaoEstoque_MateriaPrima.BindingField = "TipoAlocacaoEstoque_MateriaPrima";
            this.TipoAlocacaoEstoque_MateriaPrima.LiberadoQuandoCadastroUtilizado = false;
            this.TipoAlocacaoEstoque_MateriaPrima.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoAlocacaoEstoque_MateriaPrima.Location = new System.Drawing.Point(19, 19);
            this.TipoAlocacaoEstoque_MateriaPrima.Name = "TipoAlocacaoEstoque_MateriaPrima";
            this.TipoAlocacaoEstoque_MateriaPrima.Size = new System.Drawing.Size(350, 17);
            this.TipoAlocacaoEstoque_MateriaPrima.TabIndex = 18;
            this.TipoAlocacaoEstoque_MateriaPrima.Text = "Matéria Prima (Itens com estoque e baixa por estrutura ou nota fiscal)";
            this.TipoAlocacaoEstoque_MateriaPrima.UseVisualStyleBackColor = true;
            // 
            // TipoAlocacaoEstoque_Consumo
            // 
            this.TipoAlocacaoEstoque_Consumo.AutoSize = true;
            this.TipoAlocacaoEstoque_Consumo.BindingField = "TipoAlocacaoEstoque_Consumo";
            this.TipoAlocacaoEstoque_Consumo.LiberadoQuandoCadastroUtilizado = false;
            this.TipoAlocacaoEstoque_Consumo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.TipoAlocacaoEstoque_Consumo.Location = new System.Drawing.Point(19, 42);
            this.TipoAlocacaoEstoque_Consumo.Name = "TipoAlocacaoEstoque_Consumo";
            this.TipoAlocacaoEstoque_Consumo.Size = new System.Drawing.Size(110, 17);
            this.TipoAlocacaoEstoque_Consumo.TabIndex = 20;
            this.TipoAlocacaoEstoque_Consumo.Text = "Itens de Consumo";
            this.TipoAlocacaoEstoque_Consumo.UseVisualStyleBackColor = true;
            // 
            // Identificacao
            // 
            this.Identificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.DebugMode = false;
            this.Identificacao.LiberadoQuandoCadastroUtilizado = false;
            this.Identificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Identificacao.Location = new System.Drawing.Point(103, 7);
            this.Identificacao.MaxLength = 255;
            this.Identificacao.ModoBarcode = false;
            this.Identificacao.ModoBusca = false;
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.NaoLimparDepoisBarcode = false;
            this.Identificacao.Size = new System.Drawing.Size(361, 20);
            this.Identificacao.TabIndex = 12;
            // 
            // IdentificacaoLabel
            // 
            this.IdentificacaoLabel.AutoSize = true;
            this.IdentificacaoLabel.BindingField = null;
            this.IdentificacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.IdentificacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.IdentificacaoLabel.Location = new System.Drawing.Point(29, 10);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(68, 13);
            this.IdentificacaoLabel.TabIndex = 11;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // DescricaoLabel
            // 
            this.DescricaoLabel.AutoSize = true;
            this.DescricaoLabel.BindingField = null;
            this.DescricaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.DescricaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.DescricaoLabel.Location = new System.Drawing.Point(42, 37);
            this.DescricaoLabel.Name = "DescricaoLabel";
            this.DescricaoLabel.Size = new System.Drawing.Size(55, 13);
            this.DescricaoLabel.TabIndex = 13;
            this.DescricaoLabel.Text = "Descrição";
            // 
            // Descricao
            // 
            this.Descricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Descricao.BindingField = "Descricao";
            this.Descricao.DebugMode = false;
            this.Descricao.LiberadoQuandoCadastroUtilizado = false;
            this.Descricao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Descricao.Location = new System.Drawing.Point(103, 34);
            this.Descricao.MaxLength = 255;
            this.Descricao.ModoBarcode = false;
            this.Descricao.ModoBusca = false;
            this.Descricao.Name = "Descricao";
            this.Descricao.NaoLimparDepoisBarcode = false;
            this.Descricao.Size = new System.Drawing.Size(361, 20);
            this.Descricao.TabIndex = 14;
            // 
            // AtivoLabel
            // 
            this.AtivoLabel.AutoSize = true;
            this.AtivoLabel.BindingField = null;
            this.AtivoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.AtivoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.AtivoLabel.Location = new System.Drawing.Point(66, 61);
            this.AtivoLabel.Name = "AtivoLabel";
            this.AtivoLabel.Size = new System.Drawing.Size(31, 13);
            this.AtivoLabel.TabIndex = 15;
            this.AtivoLabel.Text = "Ativo";
            // 
            // Ativo
            // 
            this.Ativo.AutoSize = true;
            this.Ativo.BindingField = "Ativo";
            this.Ativo.LiberadoQuandoCadastroUtilizado = false;
            this.Ativo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Ativo.Location = new System.Drawing.Point(103, 61);
            this.Ativo.Name = "Ativo";
            this.Ativo.Size = new System.Drawing.Size(15, 14);
            this.Ativo.TabIndex = 16;
            this.Ativo.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(551, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Estrutura do Estoque";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.treEstoque);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btnSubEtiqueta);
            this.splitContainer4.Panel2.Controls.Add(this.label6);
            this.splitContainer4.Panel2.Controls.Add(this.chkAtivo);
            this.splitContainer4.Panel2.Controls.Add(this.btnSubAtualizar);
            this.splitContainer4.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer4.Panel2.Controls.Add(this.btnSubIncluir);
            this.splitContainer4.Panel2.Controls.Add(this.txtSubDescricao);
            this.splitContainer4.Panel2.Controls.Add(this.label4);
            this.splitContainer4.Panel2.Controls.Add(this.txtSubIdentificacao);
            this.splitContainer4.Panel2.Controls.Add(this.label3);
            this.splitContainer4.Size = new System.Drawing.Size(545, 377);
            this.splitContainer4.SplitterDistance = 373;
            this.splitContainer4.TabIndex = 7;
            // 
            // treEstoque
            // 
            this.treEstoque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treEstoque.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treEstoque.HideSelection = false;
            this.treEstoque.Location = new System.Drawing.Point(0, 0);
            this.treEstoque.Name = "treEstoque";
            this.treEstoque.Size = new System.Drawing.Size(373, 377);
            this.treEstoque.TabIndex = 0;
            this.treEstoque.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treEstoque_DrawNode);
            this.treEstoque.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treEstoque_NodeMouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Ativo";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(43, 94);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(15, 14);
            this.chkAtivo.TabIndex = 16;
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // btnSubAtualizar
            // 
            this.btnSubAtualizar.Location = new System.Drawing.Point(6, 170);
            this.btnSubAtualizar.Name = "btnSubAtualizar";
            this.btnSubAtualizar.Size = new System.Drawing.Size(157, 23);
            this.btnSubAtualizar.TabIndex = 6;
            this.btnSubAtualizar.Text = "<< - Atualizar Selecionado";
            this.btnSubAtualizar.UseVisualStyleBackColor = true;
            this.btnSubAtualizar.Click += new System.EventHandler(this.btnSubAtualizar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcluir.Location = new System.Drawing.Point(6, 351);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(157, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir Selecionado";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnSubIncluir
            // 
            this.btnSubIncluir.Location = new System.Drawing.Point(6, 141);
            this.btnSubIncluir.Name = "btnSubIncluir";
            this.btnSubIncluir.Size = new System.Drawing.Size(157, 23);
            this.btnSubIncluir.TabIndex = 4;
            this.btnSubIncluir.Text = "<< - Incluir na Seleção";
            this.btnSubIncluir.UseVisualStyleBackColor = true;
            this.btnSubIncluir.Click += new System.EventHandler(this.btnSubIncluir_Click);
            // 
            // txtSubDescricao
            // 
            this.txtSubDescricao.Location = new System.Drawing.Point(6, 68);
            this.txtSubDescricao.Name = "txtSubDescricao";
            this.txtSubDescricao.Size = new System.Drawing.Size(157, 20);
            this.txtSubDescricao.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Descrição";
            // 
            // txtSubIdentificacao
            // 
            this.txtSubIdentificacao.Location = new System.Drawing.Point(6, 29);
            this.txtSubIdentificacao.Name = "txtSubIdentificacao";
            this.txtSubIdentificacao.Size = new System.Drawing.Size(157, 20);
            this.txtSubIdentificacao.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Identificação";
            // 
            // btnSubEtiqueta
            // 
            this.btnSubEtiqueta.Location = new System.Drawing.Point(6, 238);
            this.btnSubEtiqueta.Name = "btnSubEtiqueta";
            this.btnSubEtiqueta.Size = new System.Drawing.Size(157, 37);
            this.btnSubEtiqueta.TabIndex = 18;
            this.btnSubEtiqueta.Text = "Gerar Etiqueta do Selecionado";
            this.btnSubEtiqueta.UseVisualStyleBackColor = true;
            this.btnSubEtiqueta.Click += new System.EventHandler(this.btnSubEtiqueta_Click);
            // 
            // CadEstoqueForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(559, 475);
            this.Name = "CadEstoqueForm";
            this.Text = "Almoxarifado";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbRevisao.ResumeLayout(false);
            this.grbRevisao.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grbRevisao;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativaLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoDataLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuarioLabel;
        private IWTDotNetLib.IWTLabel lblRevisaoJustificativa;
        private IWTDotNetLib.IWTLabel lblRevisaoData; 
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private IWTDotNetLib.IWTTextBox Identificacao;
        private IWTDotNetLib.IWTLabel IdentificacaoLabel;
        private IWTDotNetLib.IWTRadioButton TipoAlocacaoEstoque_Consumo;
        private IWTDotNetLib.IWTLabel DescricaoLabel;
        private IWTDotNetLib.IWTRadioButton TipoAlocacaoEstoque_MateriaPrima;
        private IWTDotNetLib.IWTTextBox Descricao;
        private IWTDotNetLib.IWTLabel AtivoLabel;
        private IWTDotNetLib.IWTCheckBox Ativo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TreeView treEstoque;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Button btnSubAtualizar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSubIncluir;
        private System.Windows.Forms.TextBox txtSubDescricao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubIdentificacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubEtiqueta;
    }
} 
