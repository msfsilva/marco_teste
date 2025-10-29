namespace BibliotecaCadastrosBasicos
{
    partial class CadProgramacaoNovoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NomeLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Nome = new IWTDotNetLib.IWTTextBox(this.components);
            this.dgvPedidosDisponiveis = new IWTDotNetLib.IWTDataGridView(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnInclui1 = new IWTDotNetLib.IWTButton(this.components);
            this.btnRemove1 = new IWTDotNetLib.IWTButton(this.components);
            this.txtBuscaDisponiveis = new IWTDotNetLib.IWTTextBox(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPedidos = new IWTDotNetLib.IWTDataGridView(this.components);
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtBuscaProgramados = new IWTDotNetLib.IWTTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosDisponiveis)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.NomeLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Nome);
            this.splitContainer1.Size = new System.Drawing.Size(964, 697);
            this.splitContainer1.SplitterDistance = 628;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(12, 23);
            this.btnCancelar.Size = new System.Drawing.Size(75, 25);
            this.btnCancelar.Text = "   Fechar";
            // 
            // btnSalvar
            // 
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(877, 23);
            this.btnSalvar.Size = new System.Drawing.Size(75, 25);
            this.btnSalvar.Text = "   Salvar";
            // 
            // NomeLabel
            // 
            this.NomeLabel.AutoSize = true;
            this.NomeLabel.BindingField = null;
            this.NomeLabel.LiberadoQuandoCadastroUtilizado = false;
            this.NomeLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.NomeLabel.Location = new System.Drawing.Point(67, 16);
            this.NomeLabel.Name = "NomeLabel";
            this.NomeLabel.Size = new System.Drawing.Size(35, 13);
            this.NomeLabel.TabIndex = 0;
            this.NomeLabel.Text = "Nome";
            // 
            // Nome
            // 
            this.Nome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Nome.BindingField = "Nome";
            this.Nome.DebugMode = false;
            this.Nome.LiberadoQuandoCadastroUtilizado = false;
            this.Nome.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Nome.Location = new System.Drawing.Point(106, 12);
            this.Nome.MaxLength = 255;
            this.Nome.ModoBarcode = false;
            this.Nome.ModoBusca = false;
            this.Nome.Name = "Nome";
            this.Nome.NaoLimparDepoisBarcode = false;
            this.Nome.Size = new System.Drawing.Size(646, 20);
            this.Nome.TabIndex = 1;
            // 
            // dgvPedidosDisponiveis
            // 
            this.dgvPedidosDisponiveis.AllowUserToAddRows = false;
            this.dgvPedidosDisponiveis.AllowUserToDeleteRows = false;
            this.dgvPedidosDisponiveis.AllowUserToOrderColumns = true;
            this.dgvPedidosDisponiveis.AllowUserToResizeRows = false;
            this.dgvPedidosDisponiveis.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidosDisponiveis.CacheDados = null;
            this.dgvPedidosDisponiveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosDisponiveis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.ProdutoColumn,
            this.DescricaoColumn,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidosDisponiveis.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPedidosDisponiveis.Location = new System.Drawing.Point(3, 23);
            this.dgvPedidosDisponiveis.Name = "dgvPedidosDisponiveis";
            this.dgvPedidosDisponiveis.ReadOnly = true;
            this.dgvPedidosDisponiveis.RowHeadersVisible = false;
            this.dgvPedidosDisponiveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidosDisponiveis.Size = new System.Drawing.Size(435, 495);
            this.dgvPedidosDisponiveis.TabIndex = 4;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(3, 0);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(168, 18);
            this.iwtLabel2.TabIndex = 6;
            this.iwtLabel2.Text = "Pedidos Liberados";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(498, 0);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(230, 18);
            this.iwtLabel3.TabIndex = 7;
            this.iwtLabel3.Text = "Pedidos Na Programação";
            // 
            // btnInclui1
            // 
            this.btnInclui1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInclui1.LiberadoQuandoCadastroUtilizado = false;
            this.btnInclui1.Location = new System.Drawing.Point(3, 119);
            this.btnInclui1.Name = "btnInclui1";
            this.btnInclui1.Size = new System.Drawing.Size(42, 23);
            this.btnInclui1.TabIndex = 8;
            this.btnInclui1.Text = ">";
            this.btnInclui1.UseVisualStyleBackColor = true;
            this.btnInclui1.Click += new System.EventHandler(this.btnInclui1_Click);
            // 
            // btnRemove1
            // 
            this.btnRemove1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove1.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemove1.Location = new System.Drawing.Point(3, 210);
            this.btnRemove1.Name = "btnRemove1";
            this.btnRemove1.Size = new System.Drawing.Size(42, 23);
            this.btnRemove1.TabIndex = 10;
            this.btnRemove1.Text = "<";
            this.btnRemove1.UseVisualStyleBackColor = true;
            this.btnRemove1.Click += new System.EventHandler(this.btnRemove1_Click);
            // 
            // txtBuscaDisponiveis
            // 
            this.txtBuscaDisponiveis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaDisponiveis.BindingField = null;
            this.txtBuscaDisponiveis.DebugMode = false;
            this.txtBuscaDisponiveis.LiberadoQuandoCadastroUtilizado = false;
            this.txtBuscaDisponiveis.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBuscaDisponiveis.Location = new System.Drawing.Point(46, 7);
            this.txtBuscaDisponiveis.ModoBarcode = false;
            this.txtBuscaDisponiveis.ModoBusca = true;
            this.txtBuscaDisponiveis.Name = "txtBuscaDisponiveis";
            this.txtBuscaDisponiveis.NaoLimparDepoisBarcode = false;
            this.txtBuscaDisponiveis.Size = new System.Drawing.Size(386, 20);
            this.txtBuscaDisponiveis.TabIndex = 13;
            this.txtBuscaDisponiveis.OperacaoBuscaEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBuscaEncerradaDelegate(this.txtBusca_OperacaoBuscaEncerrada);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPedidosDisponiveis, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.iwtLabel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.iwtLabel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvPedidos, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 56);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(936, 561);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInclui1);
            this.panel1.Controls.Add(this.btnRemove1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(444, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 495);
            this.panel1.TabIndex = 5;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(3, 10);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel4.TabIndex = 15;
            this.iwtLabel4.Text = "Busca";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NumeroPosicao";
            this.dataGridViewTextBoxColumn1.HeaderText = "Pedido";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProjetoCliente";
            this.dataGridViewTextBoxColumn3.HeaderText = "Projeto";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ProdutoColumn
            // 
            this.ProdutoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoColumn.DataPropertyName = "Produto";
            this.ProdutoColumn.HeaderText = "Produto";
            this.ProdutoColumn.Name = "ProdutoColumn";
            this.ProdutoColumn.ReadOnly = true;
            this.ProdutoColumn.Width = 150;
            // 
            // DescricaoColumn
            // 
            this.DescricaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescricaoColumn.DataPropertyName = "ProdutoDescricao";
            this.DescricaoColumn.HeaderText = "Descrição";
            this.DescricaoColumn.Name = "DescricaoColumn";
            this.DescricaoColumn.ReadOnly = true;
            this.DescricaoColumn.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SemanaEntrega";
            this.dataGridViewTextBoxColumn2.HeaderText = "Semana";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToOrderColumns = true;
            this.dgvPedidos.AllowUserToResizeRows = false;
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.CacheDados = null;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPedidos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPedidos.Location = new System.Drawing.Point(498, 23);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersVisible = false;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(435, 495);
            this.dgvPedidos.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NumeroPosicao";
            this.dataGridViewTextBoxColumn4.HeaderText = "Pedido";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ProjetoCliente";
            this.dataGridViewTextBoxColumn5.HeaderText = "Projeto";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Produto";
            this.dataGridViewTextBoxColumn6.HeaderText = "Produto";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ProdutoDescricao";
            this.dataGridViewTextBoxColumn7.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "SemanaEntrega";
            this.dataGridViewTextBoxColumn8.HeaderText = "Semana";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.iwtLabel4);
            this.panel2.Controls.Add(this.txtBuscaDisponiveis);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 524);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 34);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.iwtLabel1);
            this.panel3.Controls.Add(this.txtBuscaProgramados);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(498, 524);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(435, 34);
            this.panel3.TabIndex = 10;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(3, 10);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 15;
            this.iwtLabel1.Text = "Busca";
            // 
            // txtBuscaProgramados
            // 
            this.txtBuscaProgramados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscaProgramados.BindingField = null;
            this.txtBuscaProgramados.DebugMode = false;
            this.txtBuscaProgramados.LiberadoQuandoCadastroUtilizado = false;
            this.txtBuscaProgramados.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBuscaProgramados.Location = new System.Drawing.Point(46, 7);
            this.txtBuscaProgramados.ModoBarcode = false;
            this.txtBuscaProgramados.ModoBusca = true;
            this.txtBuscaProgramados.Name = "txtBuscaProgramados";
            this.txtBuscaProgramados.NaoLimparDepoisBarcode = false;
            this.txtBuscaProgramados.Size = new System.Drawing.Size(386, 20);
            this.txtBuscaProgramados.TabIndex = 13;
            this.txtBuscaProgramados.OperacaoBuscaEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBuscaEncerradaDelegate(this.txtBuscaProgramados_OperacaoBuscaEncerrada);
            // 
            // CadProgramacaoNovoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(964, 697);
            this.Name = "CadProgramacaoNovoForm";
            this.Text = "Programação";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosDisponiveis)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel NomeLabel;
        private IWTDotNetLib.IWTTextBox Nome;
        private IWTDotNetLib.IWTDataGridView dgvPedidosDisponiveis;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTButton btnInclui1;
        private IWTDotNetLib.IWTButton btnRemove1;
        private IWTDotNetLib.IWTTextBox txtBuscaDisponiveis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private IWTDotNetLib.IWTDataGridView dgvPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox txtBuscaProgramados;
    }
} 
