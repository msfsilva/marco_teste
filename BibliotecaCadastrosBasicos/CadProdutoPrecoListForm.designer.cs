using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadProdutoPrecoListForm 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.rdbTodas = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbNaoVigentes = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbVigentes = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoDescricaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoliticaPrecoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Regra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InicioVigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FimVigencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClienteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Justificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataUltimaVendaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 321);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Size = new System.Drawing.Size(785, 62);
            this.splitContainer2.SplitterDistance = 511;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(785, 287);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox2);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel2);
            this.iwtSearchPanel1.Controls.Add(this.rdbTodas);
            this.iwtSearchPanel1.Controls.Add(this.rdbNaoVigentes);
            this.iwtSearchPanel1.Controls.Add(this.rdbVigentes);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(511, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox2.BindingField = "BuscaClienteString";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(59, 29);
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.ModoBusca = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.NaoLimparDepoisBarcode = false;
            this.iwtTextBox2.Size = new System.Drawing.Size(355, 20);
            this.iwtTextBox2.TabIndex = 12;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(17, 32);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(39, 13);
            this.iwtLabel2.TabIndex = 11;
            this.iwtLabel2.Text = "Cliente";
            // 
            // rdbTodas
            // 
            this.rdbTodas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbTodas.AutoSize = true;
            this.rdbTodas.BindingField = null;
            this.rdbTodas.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodas.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodas.Location = new System.Drawing.Point(429, 40);
            this.rdbTodas.Name = "rdbTodas";
            this.rdbTodas.Size = new System.Drawing.Size(55, 17);
            this.rdbTodas.TabIndex = 10;
            this.rdbTodas.Text = "Todas";
            this.rdbTodas.UseVisualStyleBackColor = true;
            // 
            // rdbNaoVigentes
            // 
            this.rdbNaoVigentes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbNaoVigentes.AutoSize = true;
            this.rdbNaoVigentes.BindingField = "Encerradas";
            this.rdbNaoVigentes.LiberadoQuandoCadastroUtilizado = false;
            this.rdbNaoVigentes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbNaoVigentes.Location = new System.Drawing.Point(429, 23);
            this.rdbNaoVigentes.Name = "rdbNaoVigentes";
            this.rdbNaoVigentes.Size = new System.Drawing.Size(79, 17);
            this.rdbNaoVigentes.TabIndex = 9;
            this.rdbNaoVigentes.Text = "Encerradas";
            this.rdbNaoVigentes.UseVisualStyleBackColor = true;
            // 
            // rdbVigentes
            // 
            this.rdbVigentes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbVigentes.AutoSize = true;
            this.rdbVigentes.BindingField = "Vigentes";
            this.rdbVigentes.Checked = true;
            this.rdbVigentes.LiberadoQuandoCadastroUtilizado = false;
            this.rdbVigentes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbVigentes.Location = new System.Drawing.Point(429, 6);
            this.rdbVigentes.Name = "rdbVigentes";
            this.rdbVigentes.Size = new System.Drawing.Size(66, 17);
            this.rdbVigentes.TabIndex = 8;
            this.rdbVigentes.TabStop = true;
            this.rdbVigentes.Text = "Vigentes";
            this.rdbVigentes.UseVisualStyleBackColor = true;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(59, 3);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(355, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(19, 6);
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
            this.Produto,
            this.ProdutoDescricaoColumn,
            this.Preco,
            this.PoliticaPrecoColumn,
            this.Regra,
            this.InicioVigencia,
            this.FimVigencia,
            this.ClienteColumn,
            this.Justificativa,
            this.AcsUsuario,
            this.DataUltimaVendaColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(785, 249);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 70;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Width = 150;
            // 
            // ProdutoDescricaoColumn
            // 
            this.ProdutoDescricaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoDescricaoColumn.DataPropertyName = "ProdutoDescricao";
            this.ProdutoDescricaoColumn.HeaderText = "Descrição";
            this.ProdutoDescricaoColumn.Name = "ProdutoDescricaoColumn";
            this.ProdutoDescricaoColumn.ReadOnly = true;
            this.ProdutoDescricaoColumn.Width = 150;
            // 
            // Preco
            // 
            this.Preco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Preco.DataPropertyName = "Preco";
            this.Preco.HeaderText = "Preço";
            this.Preco.Name = "Preco";
            this.Preco.ReadOnly = true;
            // 
            // PoliticaPrecoColumn
            // 
            this.PoliticaPrecoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PoliticaPrecoColumn.DataPropertyName = "PoliticaPrecoTela";
            this.PoliticaPrecoColumn.HeaderText = "Política de Preço";
            this.PoliticaPrecoColumn.Name = "PoliticaPrecoColumn";
            this.PoliticaPrecoColumn.ReadOnly = true;
            this.PoliticaPrecoColumn.Width = 200;
            // 
            // Regra
            // 
            this.Regra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Regra.DataPropertyName = "Regra";
            this.Regra.HeaderText = "Regra";
            this.Regra.Name = "Regra";
            this.Regra.ReadOnly = true;
            this.Regra.Width = 150;
            // 
            // InicioVigencia
            // 
            this.InicioVigencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InicioVigencia.DataPropertyName = "InicioVigencia";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.InicioVigencia.DefaultCellStyle = dataGridViewCellStyle1;
            this.InicioVigencia.HeaderText = "Início da Vigência";
            this.InicioVigencia.Name = "InicioVigencia";
            this.InicioVigencia.ReadOnly = true;
            // 
            // FimVigencia
            // 
            this.FimVigencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FimVigencia.DataPropertyName = "FimVigencia";
            dataGridViewCellStyle2.Format = "d";
            this.FimVigencia.DefaultCellStyle = dataGridViewCellStyle2;
            this.FimVigencia.HeaderText = "Fim da Vigência";
            this.FimVigencia.Name = "FimVigencia";
            this.FimVigencia.ReadOnly = true;
            // 
            // ClienteColumn
            // 
            this.ClienteColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClienteColumn.DataPropertyName = "ClienteProduto";
            this.ClienteColumn.HeaderText = "Cliente";
            this.ClienteColumn.Name = "ClienteColumn";
            this.ClienteColumn.ReadOnly = true;
            // 
            // Justificativa
            // 
            this.Justificativa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Justificativa.DataPropertyName = "Justificativa";
            this.Justificativa.HeaderText = "Justificativa";
            this.Justificativa.Name = "Justificativa";
            this.Justificativa.ReadOnly = true;
            this.Justificativa.Width = 150;
            // 
            // AcsUsuario
            // 
            this.AcsUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuario.DataPropertyName = "AcsUsuario";
            this.AcsUsuario.HeaderText = "Usuário Responsável";
            this.AcsUsuario.Name = "AcsUsuario";
            this.AcsUsuario.ReadOnly = true;
            this.AcsUsuario.Width = 150;
            // 
            // DataUltimaVendaColumn
            // 
            this.DataUltimaVendaColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataUltimaVendaColumn.DataPropertyName = "DataUltimaVenda";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DataUltimaVendaColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataUltimaVendaColumn.HeaderText = "Data de Entrada do Último Pedido";
            this.DataUltimaVendaColumn.Name = "DataUltimaVendaColumn";
            this.DataUltimaVendaColumn.ReadOnly = true;
            this.DataUltimaVendaColumn.Visible = false;
            // 
            // iwtEditarButton1
            // 
            this.iwtEditarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtEditarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtEditarButton1.Location = new System.Drawing.Point(183, 19);
            this.iwtEditarButton1.Name = "iwtEditarButton1";
            this.iwtEditarButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtEditarButton1.TabIndex = 0;
            this.iwtEditarButton1.Text = "Revisar";
            this.iwtEditarButton1.UseVisualStyleBackColor = true;
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(102, 19);
            this.iwtNovoButton1.Name = "iwtNovoButton1";
            this.iwtNovoButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtNovoButton1.TabIndex = 1;
            this.iwtNovoButton1.Text = "Novo";
            this.iwtNovoButton1.UseVisualStyleBackColor = true;
            // 
            // CadProdutoPrecoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(785, 383);
            this.Name = "CadProdutoPrecoListForm";
            this.Text = "Regras de Preço do Produtos";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InicioVigenciaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FimVigenciaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JustificativaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioColumn;
        private IWTRadioButton rdbTodas;
        private IWTRadioButton rdbNaoVigentes;
        private IWTRadioButton rdbVigentes;
        private IWTEditarButton iwtEditarButton1;
        private IWTNovoButton iwtNovoButton1;
        private IWTTextBox iwtTextBox2;
        private IWTLabel iwtLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoDescricaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoliticaPrecoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Regra;
        private System.Windows.Forms.DataGridViewTextBoxColumn InicioVigencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn FimVigencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Justificativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataUltimaVendaColumn;
    }
} 
