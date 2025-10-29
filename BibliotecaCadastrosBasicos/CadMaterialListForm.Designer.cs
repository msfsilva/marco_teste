using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadMaterialListForm 
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
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.rdbInativos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbAtivos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnSelecionar = new IWTDotNetLib.IWTSelecionarButton(this.components);
            this.btnNovo = new IWTDotNetLib.IWTNovoButton(this.components);
            this.btnFiscal = new IWTDotNetLib.IWTButton(this.components);
            this.btnEditar = new IWTDotNetLib.IWTEditarButton(this.components);
            this.btnEtiqueta = new IWTDotNetLib.IWTButton(this.components);
            this.btnExcluir = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.btnHistoricoCompra = new IWTDotNetLib.IWTButton(this.components);
            this.btnAtivarDesativar = new IWTDotNetLib.IWTButton(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoInterno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gtin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedidaLargura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedidaComprimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoliticaEstoqueTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisaoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisaoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AtivoColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamiliaMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acabamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotePadrao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteMinimoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amarelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vermelho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedidaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadesPorUnCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadTimeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcasHomologadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpedirSolicitacaoAuto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UtilizandoEstoqueSeguranca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UtilizandoEstoqueSegurancaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControleValidade = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ControleValidadeMeses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MargemRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 310);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnAtivarDesativar);
            this.splitContainer2.Panel2.Controls.Add(this.btnHistoricoCompra);
            this.splitContainer2.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer2.Panel2.Controls.Add(this.btnFiscal);
            this.splitContainer2.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer2.Panel2.Controls.Add(this.btnEtiqueta);
            this.splitContainer2.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer2.Panel2.Controls.Add(this.btnSelecionar);
            this.splitContainer2.Size = new System.Drawing.Size(991, 90);
            this.splitContainer2.SplitterDistance = 481;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(991, 276);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.rdbInativos);
            this.iwtSearchPanel1.Controls.Add(this.rdbAtivos);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(481, 90);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // rdbInativos
            // 
            this.rdbInativos.AutoSize = true;
            this.rdbInativos.BindingField = "";
            this.rdbInativos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbInativos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbInativos.Location = new System.Drawing.Point(328, 49);
            this.rdbInativos.Name = "rdbInativos";
            this.rdbInativos.Size = new System.Drawing.Size(62, 17);
            this.rdbInativos.TabIndex = 3;
            this.rdbInativos.Text = "Inativos";
            this.rdbInativos.UseVisualStyleBackColor = true;
            this.rdbInativos.CheckedChanged += new System.EventHandler(this.rdbInativos_CheckedChanged);
            // 
            // rdbAtivos
            // 
            this.rdbAtivos.AutoSize = true;
            this.rdbAtivos.BindingField = "Ativo";
            this.rdbAtivos.Checked = true;
            this.rdbAtivos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAtivos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAtivos.Location = new System.Drawing.Point(328, 25);
            this.rdbAtivos.Name = "rdbAtivos";
            this.rdbAtivos.Size = new System.Drawing.Size(54, 17);
            this.rdbAtivos.TabIndex = 2;
            this.rdbAtivos.TabStop = true;
            this.rdbAtivos.Text = "Ativos";
            this.rdbAtivos.UseVisualStyleBackColor = true;
            this.rdbAtivos.CheckedChanged += new System.EventHandler(this.rdbAtivos_CheckedChanged);
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompletaCustom";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 35);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(231, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 38);
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
            this.CodigoInterno,
            this.CodigoCompleto,
            this.Descricao,
            this.Gtin,
            this.DescricaoAdicional,
            this.Medida,
            this.MedidaLargura,
            this.MedidaComprimento,
            this.UnidadeMedida,
            this.PoliticaEstoqueTela,
            this.UltimaRevisaoUsuario,
            this.UltimaRevisao,
            this.UltimaRevisaoData,
            this.AtivoColumn,
            this.Codigo,
            this.FamiliaMaterial,
            this.Acabamento,
            this.LotePadrao,
            this.LoteMinimoColumn,
            this.Verde,
            this.Amarelo,
            this.Vermelho,
            this.UnidadeMedidaCompra,
            this.UnidadesPorUnCompra,
            this.LeadTimeCompra,
            this.MarcasHomologadas,
            this.ImpedirSolicitacaoAuto,
            this.UtilizandoEstoqueSeguranca,
            this.UtilizandoEstoqueSegurancaData,
            this.Comprador,
            this.ControleValidade,
            this.ControleValidadeMeses,
            this.MargemRecebimento});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(991, 238);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelecionar.LiberadoQuandoCadastroUtilizado = false;
            this.btnSelecionar.Location = new System.Drawing.Point(428, 7);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionar.TabIndex = 2;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Visible = false;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.LiberadoQuandoCadastroUtilizado = false;
            this.btnNovo.Location = new System.Drawing.Point(266, 7);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnFiscal
            // 
            this.btnFiscal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiscal.LiberadoQuandoCadastroUtilizado = false;
            this.btnFiscal.Location = new System.Drawing.Point(266, 32);
            this.btnFiscal.Name = "btnFiscal";
            this.btnFiscal.Size = new System.Drawing.Size(116, 23);
            this.btnFiscal.TabIndex = 3;
            this.btnFiscal.Text = "Fiscal";
            this.btnFiscal.UseVisualStyleBackColor = true;
            this.btnFiscal.Click += new System.EventHandler(this.btnFiscal_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditar.Location = new System.Drawing.Point(347, 7);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnEtiqueta
            // 
            this.btnEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEtiqueta.LiberadoQuandoCadastroUtilizado = false;
            this.btnEtiqueta.Location = new System.Drawing.Point(388, 57);
            this.btnEtiqueta.Name = "btnEtiqueta";
            this.btnEtiqueta.Size = new System.Drawing.Size(115, 23);
            this.btnEtiqueta.TabIndex = 5;
            this.btnEtiqueta.Text = "Etiquetas de Kanban";
            this.btnEtiqueta.UseVisualStyleBackColor = true;
            this.btnEtiqueta.Click += new System.EventHandler(this.btnEtiqueta_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.LiberadoQuandoCadastroUtilizado = false;
            this.btnExcluir.Location = new System.Drawing.Point(428, 7);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnHistoricoCompra
            // 
            this.btnHistoricoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoricoCompra.LiberadoQuandoCadastroUtilizado = false;
            this.btnHistoricoCompra.Location = new System.Drawing.Point(388, 32);
            this.btnHistoricoCompra.Name = "btnHistoricoCompra";
            this.btnHistoricoCompra.Size = new System.Drawing.Size(115, 23);
            this.btnHistoricoCompra.TabIndex = 4;
            this.btnHistoricoCompra.Text = "Histórico Compra";
            this.btnHistoricoCompra.UseVisualStyleBackColor = true;
            this.btnHistoricoCompra.Click += new System.EventHandler(this.btnHistoricoCompra_Click);
            // 
            // btnAtivarDesativar
            // 
            this.btnAtivarDesativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtivarDesativar.LiberadoQuandoCadastroUtilizado = false;
            this.btnAtivarDesativar.Location = new System.Drawing.Point(266, 57);
            this.btnAtivarDesativar.Name = "btnAtivarDesativar";
            this.btnAtivarDesativar.Size = new System.Drawing.Size(116, 23);
            this.btnAtivarDesativar.TabIndex = 6;
            this.btnAtivarDesativar.Text = "Desativar";
            this.btnAtivarDesativar.UseVisualStyleBackColor = true;
            this.btnAtivarDesativar.Click += new System.EventHandler(this.btnAtivarDesativar_Click);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 70;
            // 
            // CodigoInterno
            // 
            this.CodigoInterno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoInterno.DataPropertyName = "CodigoInterno";
            this.CodigoInterno.HeaderText = "Código Interno";
            this.CodigoInterno.Name = "CodigoInterno";
            this.CodigoInterno.ReadOnly = true;
            this.CodigoInterno.Width = 80;
            // 
            // CodigoCompleto
            // 
            this.CodigoCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoCompleto.DataPropertyName = "CodigoComFamilia";
            this.CodigoCompleto.HeaderText = "Código Completo";
            this.CodigoCompleto.Name = "CodigoCompleto";
            this.CodigoCompleto.ReadOnly = true;
            this.CodigoCompleto.Width = 160;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 150;
            // 
            // Gtin
            // 
            this.Gtin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Gtin.DataPropertyName = "Gtin";
            this.Gtin.HeaderText = "GTIN";
            this.Gtin.Name = "Gtin";
            this.Gtin.ReadOnly = true;
            this.Gtin.Visible = false;
            // 
            // DescricaoAdicional
            // 
            this.DescricaoAdicional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescricaoAdicional.DataPropertyName = "DescricaoAdicional";
            this.DescricaoAdicional.HeaderText = "Descrição Adicional";
            this.DescricaoAdicional.Name = "DescricaoAdicional";
            this.DescricaoAdicional.ReadOnly = true;
            this.DescricaoAdicional.Width = 150;
            // 
            // Medida
            // 
            this.Medida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Dimensão 1";
            this.Medida.Name = "Medida";
            this.Medida.ReadOnly = true;
            this.Medida.Width = 80;
            // 
            // MedidaLargura
            // 
            this.MedidaLargura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MedidaLargura.DataPropertyName = "MedidaLargura";
            this.MedidaLargura.HeaderText = "Dimensão 2";
            this.MedidaLargura.Name = "MedidaLargura";
            this.MedidaLargura.ReadOnly = true;
            this.MedidaLargura.Width = 80;
            // 
            // MedidaComprimento
            // 
            this.MedidaComprimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MedidaComprimento.DataPropertyName = "MedidaComprimento";
            this.MedidaComprimento.HeaderText = "Dimensão 3";
            this.MedidaComprimento.Name = "MedidaComprimento";
            this.MedidaComprimento.ReadOnly = true;
            this.MedidaComprimento.Width = 80;
            // 
            // UnidadeMedida
            // 
            this.UnidadeMedida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadeMedida.DataPropertyName = "UnidadeMedida";
            this.UnidadeMedida.HeaderText = "Unidade";
            this.UnidadeMedida.Name = "UnidadeMedida";
            this.UnidadeMedida.ReadOnly = true;
            this.UnidadeMedida.Width = 150;
            // 
            // PoliticaEstoqueTela
            // 
            this.PoliticaEstoqueTela.DataPropertyName = "PoliticaEstoqueTela";
            this.PoliticaEstoqueTela.HeaderText = "Politica de Estoque";
            this.PoliticaEstoqueTela.Name = "PoliticaEstoqueTela";
            this.PoliticaEstoqueTela.ReadOnly = true;
            // 
            // UltimaRevisaoUsuario
            // 
            this.UltimaRevisaoUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaRevisaoUsuario.DataPropertyName = "UltimaRevisaoUsuario";
            this.UltimaRevisaoUsuario.HeaderText = "Usuário Revisão";
            this.UltimaRevisaoUsuario.Name = "UltimaRevisaoUsuario";
            this.UltimaRevisaoUsuario.ReadOnly = true;
            this.UltimaRevisaoUsuario.Width = 80;
            // 
            // UltimaRevisao
            // 
            this.UltimaRevisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaRevisao.DataPropertyName = "UltimaRevisao";
            this.UltimaRevisao.HeaderText = "Revisão";
            this.UltimaRevisao.Name = "UltimaRevisao";
            this.UltimaRevisao.ReadOnly = true;
            this.UltimaRevisao.Width = 150;
            // 
            // UltimaRevisaoData
            // 
            this.UltimaRevisaoData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaRevisaoData.DataPropertyName = "UltimaRevisaoData";
            this.UltimaRevisaoData.HeaderText = "Data da Revisão";
            this.UltimaRevisaoData.Name = "UltimaRevisaoData";
            this.UltimaRevisaoData.ReadOnly = true;
            // 
            // AtivoColumn
            // 
            this.AtivoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AtivoColumn.DataPropertyName = "Ativo";
            this.AtivoColumn.FillWeight = 80F;
            this.AtivoColumn.HeaderText = "Ativo";
            this.AtivoColumn.Name = "AtivoColumn";
            this.AtivoColumn.ReadOnly = true;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Visible = false;
            this.Codigo.Width = 150;
            // 
            // FamiliaMaterial
            // 
            this.FamiliaMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FamiliaMaterial.DataPropertyName = "FamiliaMaterial";
            this.FamiliaMaterial.HeaderText = "Família de Material";
            this.FamiliaMaterial.Name = "FamiliaMaterial";
            this.FamiliaMaterial.ReadOnly = true;
            this.FamiliaMaterial.Visible = false;
            this.FamiliaMaterial.Width = 150;
            // 
            // Acabamento
            // 
            this.Acabamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Acabamento.DataPropertyName = "Acabamento";
            this.Acabamento.HeaderText = "Acabamento";
            this.Acabamento.Name = "Acabamento";
            this.Acabamento.ReadOnly = true;
            this.Acabamento.Visible = false;
            this.Acabamento.Width = 150;
            // 
            // LotePadrao
            // 
            this.LotePadrao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LotePadrao.DataPropertyName = "LotePadrao";
            this.LotePadrao.HeaderText = "Lote Padrão";
            this.LotePadrao.Name = "LotePadrao";
            this.LotePadrao.ReadOnly = true;
            this.LotePadrao.Visible = false;
            // 
            // LoteMinimoColumn
            // 
            this.LoteMinimoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LoteMinimoColumn.DataPropertyName = "LoteMinimo";
            this.LoteMinimoColumn.HeaderText = "Lote Mínimo";
            this.LoteMinimoColumn.Name = "LoteMinimoColumn";
            this.LoteMinimoColumn.ReadOnly = true;
            // 
            // Verde
            // 
            this.Verde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Verde.DataPropertyName = "Verde";
            this.Verde.HeaderText = "Verde";
            this.Verde.Name = "Verde";
            this.Verde.ReadOnly = true;
            this.Verde.Visible = false;
            // 
            // Amarelo
            // 
            this.Amarelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Amarelo.DataPropertyName = "Amarelo";
            this.Amarelo.HeaderText = "Amarelo";
            this.Amarelo.Name = "Amarelo";
            this.Amarelo.ReadOnly = true;
            this.Amarelo.Visible = false;
            // 
            // Vermelho
            // 
            this.Vermelho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Vermelho.DataPropertyName = "Vermelho";
            this.Vermelho.HeaderText = "Vermelho";
            this.Vermelho.Name = "Vermelho";
            this.Vermelho.ReadOnly = true;
            this.Vermelho.Visible = false;
            // 
            // UnidadeMedidaCompra
            // 
            this.UnidadeMedidaCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadeMedidaCompra.DataPropertyName = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.HeaderText = "Unidade de Medida de Compra";
            this.UnidadeMedidaCompra.Name = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.ReadOnly = true;
            this.UnidadeMedidaCompra.Visible = false;
            this.UnidadeMedidaCompra.Width = 150;
            // 
            // UnidadesPorUnCompra
            // 
            this.UnidadesPorUnCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadesPorUnCompra.DataPropertyName = "UnidadesPorUnCompra";
            this.UnidadesPorUnCompra.HeaderText = "Unidades por Un de Compra";
            this.UnidadesPorUnCompra.Name = "UnidadesPorUnCompra";
            this.UnidadesPorUnCompra.ReadOnly = true;
            this.UnidadesPorUnCompra.Visible = false;
            // 
            // LeadTimeCompra
            // 
            this.LeadTimeCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LeadTimeCompra.DataPropertyName = "LeadTimeCompra";
            this.LeadTimeCompra.HeaderText = "Leadtime de Compra";
            this.LeadTimeCompra.Name = "LeadTimeCompra";
            this.LeadTimeCompra.ReadOnly = true;
            this.LeadTimeCompra.Visible = false;
            this.LeadTimeCompra.Width = 70;
            // 
            // MarcasHomologadas
            // 
            this.MarcasHomologadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MarcasHomologadas.DataPropertyName = "MarcasHomologadas";
            this.MarcasHomologadas.HeaderText = "Marcas Homologadas";
            this.MarcasHomologadas.Name = "MarcasHomologadas";
            this.MarcasHomologadas.ReadOnly = true;
            this.MarcasHomologadas.Visible = false;
            this.MarcasHomologadas.Width = 150;
            // 
            // ImpedirSolicitacaoAuto
            // 
            this.ImpedirSolicitacaoAuto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImpedirSolicitacaoAuto.DataPropertyName = "ImpedirSolicitacaoAuto";
            this.ImpedirSolicitacaoAuto.HeaderText = "Impedir Geração de Solicitação Automática";
            this.ImpedirSolicitacaoAuto.Name = "ImpedirSolicitacaoAuto";
            this.ImpedirSolicitacaoAuto.ReadOnly = true;
            this.ImpedirSolicitacaoAuto.Visible = false;
            this.ImpedirSolicitacaoAuto.Width = 70;
            // 
            // UtilizandoEstoqueSeguranca
            // 
            this.UtilizandoEstoqueSeguranca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UtilizandoEstoqueSeguranca.DataPropertyName = "UtilizandoEstoqueSeguranca";
            this.UtilizandoEstoqueSeguranca.HeaderText = "Utilizando Estoque de Segurança";
            this.UtilizandoEstoqueSeguranca.Name = "UtilizandoEstoqueSeguranca";
            this.UtilizandoEstoqueSeguranca.ReadOnly = true;
            this.UtilizandoEstoqueSeguranca.Visible = false;
            this.UtilizandoEstoqueSeguranca.Width = 150;
            // 
            // UtilizandoEstoqueSegurancaData
            // 
            this.UtilizandoEstoqueSegurancaData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UtilizandoEstoqueSegurancaData.DataPropertyName = "UtilizandoEstoqueSegurancaData";
            this.UtilizandoEstoqueSegurancaData.HeaderText = "Data de Estoque Segurança";
            this.UtilizandoEstoqueSegurancaData.Name = "UtilizandoEstoqueSegurancaData";
            this.UtilizandoEstoqueSegurancaData.ReadOnly = true;
            this.UtilizandoEstoqueSegurancaData.Visible = false;
            // 
            // Comprador
            // 
            this.Comprador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Comprador.DataPropertyName = "Comprador";
            this.Comprador.HeaderText = "Comprador";
            this.Comprador.Name = "Comprador";
            this.Comprador.ReadOnly = true;
            this.Comprador.Visible = false;
            this.Comprador.Width = 150;
            // 
            // ControleValidade
            // 
            this.ControleValidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ControleValidade.DataPropertyName = "ControleValidade";
            this.ControleValidade.HeaderText = "Controle de Validade";
            this.ControleValidade.Name = "ControleValidade";
            this.ControleValidade.ReadOnly = true;
            this.ControleValidade.Visible = false;
            this.ControleValidade.Width = 70;
            // 
            // ControleValidadeMeses
            // 
            this.ControleValidadeMeses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ControleValidadeMeses.DataPropertyName = "ControleValidadeMeses";
            this.ControleValidadeMeses.HeaderText = "Meses de Validade";
            this.ControleValidadeMeses.Name = "ControleValidadeMeses";
            this.ControleValidadeMeses.ReadOnly = true;
            this.ControleValidadeMeses.Visible = false;
            this.ControleValidadeMeses.Width = 70;
            // 
            // MargemRecebimento
            // 
            this.MargemRecebimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MargemRecebimento.DataPropertyName = "MargemRecebimento";
            this.MargemRecebimento.HeaderText = "Margem de Aceite de Recebimento";
            this.MargemRecebimento.Name = "MargemRecebimento";
            this.MargemRecebimento.ReadOnly = true;
            this.MargemRecebimento.Visible = false;
            // 
            // CadMaterialListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(991, 400);
            this.Name = "CadMaterialListForm";
            this.Text = "Materiais - Commodities de Mercado";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTSelecionarButton btnSelecionar;
        private IWTDotNetLib.IWTNovoButton btnNovo;
        private IWTDotNetLib.IWTButton btnFiscal;
        private IWTDotNetLib.IWTEditarButton btnEditar;
        private IWTDotNetLib.IWTButton btnEtiqueta;
        private IWTDotNetLib.IWTExcluirButton btnExcluir;
        private IWTButton btnHistoricoCompra;
        private IWTRadioButton rdbInativos;
        private IWTRadioButton rdbAtivos;
        private IWTButton btnAtivarDesativar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoInterno;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gtin;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoAdicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedidaLargura;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedidaComprimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoliticaEstoqueTela;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisaoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisaoData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AtivoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FamiliaMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acabamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotePadrao;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoteMinimoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amarelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vermelho;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedidaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadesPorUnCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadTimeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcasHomologadas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImpedirSolicitacaoAuto;
        private System.Windows.Forms.DataGridViewTextBoxColumn UtilizandoEstoqueSeguranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn UtilizandoEstoqueSegurancaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ControleValidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControleValidadeMeses;
        private System.Windows.Forms.DataGridViewTextBoxColumn MargemRecebimento;
    }
} 
