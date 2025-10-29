namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class OpAguardandoExpedicaoServicoExterno
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
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataImpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataReimpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgrupadorOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassificacaoProdutoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoEnvioFornecedorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostoAtualColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioImpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioReimpressao = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.UsuarioLiberacaoQualidadeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservacaoLiberacaoQualidadeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEnviarFornecedor = new IWTDotNetLib.IWTButton(this.components);
            this.chkBuscaDataImpressao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.grbBuscaDataImpressao = new System.Windows.Forms.GroupBox();
            this.iwtDateTimePicker2 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtDateTimePicker1 = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPedido = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chkIdOP = new IWTDotNetLib.IWTCheckBox(this.components);
            this.nudIdOrdemProducao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.btnCancelarSaldoEnvio = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.grbBuscaDataImpressao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOrdemProducao)).BeginInit();
            this.iwtSearchPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 481);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelarSaldoEnvio);
            this.splitContainer2.Panel2.Controls.Add(this.btnEnviarFornecedor);
            this.splitContainer2.Size = new System.Drawing.Size(950, 146);
            this.splitContainer2.SplitterDistance = 611;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(950, 447);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
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
            this.AgrupadorOp,
            this.ProdutoDescricao,
            this.ClassificacaoProdutoColumn,
            this.Dimensao,
            this.Quantidade,
            this.SaldoEnvioFornecedorColumn,
            this.PostoAtualColumn,
            this.AcsUsuario,
            this.AcsUsuarioImpressao,
            this.AcsUsuarioReimpressao,
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
            this.UsuarioLiberacaoQualidadeColumn,
            this.ObservacaoLiberacaoQualidadeColumn});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(950, 409);
            this.iwtDataGridView1.TabIndex = 1;
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
            // SaldoEnvioFornecedorColumn
            // 
            this.SaldoEnvioFornecedorColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SaldoEnvioFornecedorColumn.DataPropertyName = "SaldoEnvioFornecedor";
            this.SaldoEnvioFornecedorColumn.HeaderText = "Saldo Envio Fornecedor";
            this.SaldoEnvioFornecedorColumn.Name = "SaldoEnvioFornecedorColumn";
            this.SaldoEnvioFornecedorColumn.ReadOnly = true;
            // 
            // PostoAtualColumn
            // 
            this.PostoAtualColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PostoAtualColumn.DataPropertyName = "PostoUltimaLeitura";
            this.PostoAtualColumn.HeaderText = "Posto de Trabalho Atual";
            this.PostoAtualColumn.Name = "PostoAtualColumn";
            this.PostoAtualColumn.ReadOnly = true;
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
            // btnEnviarFornecedor
            // 
            this.btnEnviarFornecedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarFornecedor.LiberadoQuandoCadastroUtilizado = false;
            this.btnEnviarFornecedor.Location = new System.Drawing.Point(149, 26);
            this.btnEnviarFornecedor.Name = "btnEnviarFornecedor";
            this.btnEnviarFornecedor.Size = new System.Drawing.Size(174, 23);
            this.btnEnviarFornecedor.TabIndex = 0;
            this.btnEnviarFornecedor.Text = "Enviar Item para Fornecedor";
            this.btnEnviarFornecedor.UseVisualStyleBackColor = true;
            this.btnEnviarFornecedor.Click += new System.EventHandler(this.btnEnviarFornecedor_Click);
            // 
            // chkBuscaDataImpressao
            // 
            this.chkBuscaDataImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBuscaDataImpressao.AutoSize = true;
            this.chkBuscaDataImpressao.BindingField = null;
            this.chkBuscaDataImpressao.LiberadoQuandoCadastroUtilizado = false;
            this.chkBuscaDataImpressao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkBuscaDataImpressao.Location = new System.Drawing.Point(381, 118);
            this.chkBuscaDataImpressao.Name = "chkBuscaDataImpressao";
            this.chkBuscaDataImpressao.Size = new System.Drawing.Size(15, 14);
            this.chkBuscaDataImpressao.TabIndex = 36;
            this.chkBuscaDataImpressao.UseVisualStyleBackColor = true;
            this.chkBuscaDataImpressao.CheckedChanged += new System.EventHandler(this.chkBuscaDataImpressao_CheckedChanged);
            // 
            // grbBuscaDataImpressao
            // 
            this.grbBuscaDataImpressao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grbBuscaDataImpressao.Controls.Add(this.iwtDateTimePicker2);
            this.grbBuscaDataImpressao.Controls.Add(this.iwtDateTimePicker1);
            this.grbBuscaDataImpressao.Controls.Add(this.label4);
            this.grbBuscaDataImpressao.Controls.Add(this.label3);
            this.grbBuscaDataImpressao.Enabled = false;
            this.grbBuscaDataImpressao.Location = new System.Drawing.Point(40, 97);
            this.grbBuscaDataImpressao.Name = "grbBuscaDataImpressao";
            this.grbBuscaDataImpressao.Size = new System.Drawing.Size(334, 47);
            this.grbBuscaDataImpressao.TabIndex = 35;
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
            this.iwtDateTimePicker2.Value = new System.DateTime(2021, 2, 22, 15, 30, 8, 825);
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
            this.iwtDateTimePicker1.Value = new System.DateTime(2021, 2, 22, 15, 30, 8, 828);
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
            this.txtPedido.Location = new System.Drawing.Point(77, 55);
            this.txtPedido.ModoBarcode = false;
            this.txtPedido.ModoBusca = false;
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.NaoLimparDepoisBarcode = false;
            this.txtPedido.Size = new System.Drawing.Size(319, 20);
            this.txtPedido.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Pedido";
            // 
            // chkIdOP
            // 
            this.chkIdOP.AutoSize = true;
            this.chkIdOP.BindingField = null;
            this.chkIdOP.LiberadoQuandoCadastroUtilizado = false;
            this.chkIdOP.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkIdOP.Location = new System.Drawing.Point(203, 31);
            this.chkIdOP.Name = "chkIdOP";
            this.chkIdOP.Size = new System.Drawing.Size(15, 14);
            this.chkIdOP.TabIndex = 33;
            this.chkIdOP.UseVisualStyleBackColor = true;
            this.chkIdOP.CheckedChanged += new System.EventHandler(this.chkIdOP_CheckedChanged);
            // 
            // nudIdOrdemProducao
            // 
            this.nudIdOrdemProducao.BindingField = "Numero";
            this.nudIdOrdemProducao.Enabled = false;
            this.nudIdOrdemProducao.LiberadoQuandoCadastroUtilizado = false;
            this.nudIdOrdemProducao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudIdOrdemProducao.Location = new System.Drawing.Point(77, 29);
            this.nudIdOrdemProducao.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudIdOrdemProducao.Name = "nudIdOrdemProducao";
            this.nudIdOrdemProducao.Size = new System.Drawing.Size(120, 20);
            this.nudIdOrdemProducao.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Número";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(77, 3);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(319, 20);
            this.iwtTextBox1.TabIndex = 30;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(37, 6);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 31;
            this.iwtLabel1.Text = "Busca";
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.chkBuscaDataImpressao);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Controls.Add(this.grbBuscaDataImpressao);
            this.iwtSearchPanel1.Controls.Add(this.label1);
            this.iwtSearchPanel1.Controls.Add(this.txtPedido);
            this.iwtSearchPanel1.Controls.Add(this.nudIdOrdemProducao);
            this.iwtSearchPanel1.Controls.Add(this.label2);
            this.iwtSearchPanel1.Controls.Add(this.chkIdOP);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(611, 146);
            this.iwtSearchPanel1.TabIndex = 39;
            // 
            // btnCancelarSaldoEnvio
            // 
            this.btnCancelarSaldoEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelarSaldoEnvio.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelarSaldoEnvio.Location = new System.Drawing.Point(149, 86);
            this.btnCancelarSaldoEnvio.Name = "btnCancelarSaldoEnvio";
            this.btnCancelarSaldoEnvio.Size = new System.Drawing.Size(174, 23);
            this.btnCancelarSaldoEnvio.TabIndex = 1;
            this.btnCancelarSaldoEnvio.Text = "Cancelar Saldo de Envio";
            this.btnCancelarSaldoEnvio.UseVisualStyleBackColor = true;
            this.btnCancelarSaldoEnvio.Click += new System.EventHandler(this.btnCancelarSaldoEnvio_Click);
            // 
            // OpAguardandoExpedicaoServicoExterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 627);
            this.Name = "OpAguardandoExpedicaoServicoExterno";
            this.Text = "Itens Aguardando Expedição Para Posto de Trabalho Externo";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.grbBuscaDataImpressao.ResumeLayout(false);
            this.grbBuscaDataImpressao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDateTimePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOrdemProducao)).EndInit();
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTButton btnEnviarFornecedor;
        private IWTDotNetLib.IWTCheckBox chkBuscaDataImpressao;
        private System.Windows.Forms.GroupBox grbBuscaDataImpressao;
        private IWTDotNetLib.IWTDateTimePicker iwtDateTimePicker2;
        private IWTDotNetLib.IWTDateTimePicker iwtDateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private IWTDotNetLib.IWTTextBox txtPedido;
        private System.Windows.Forms.Label label2;
        private IWTDotNetLib.IWTCheckBox chkIdOP;
        private IWTDotNetLib.IWTNumericUpDown nudIdOrdemProducao;
        private System.Windows.Forms.Label label1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataImpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataReimpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgrupadorOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassificacaoProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoEnvioFornecedorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostoAtualColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioImpressao;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioReimpressao;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioLiberacaoQualidadeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservacaoLiberacaoQualidadeColumn;
        private IWTDotNetLib.IWTButton btnCancelarSaldoEnvio;
    }
}