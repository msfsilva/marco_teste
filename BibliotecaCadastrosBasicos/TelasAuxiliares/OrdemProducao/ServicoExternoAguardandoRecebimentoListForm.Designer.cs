namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class ServicoExternoAguardandoRecebimentoListForm
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
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.nudIdOrdemProducao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.chkIdOP = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnRecebimentoManual = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelamentoSaldoRecebimento = new IWTDotNetLib.IWTButton(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdemProducao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdNfPrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdAcsUsuarioEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoReceberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOrdemProducao)).BeginInit();
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
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelamentoSaldoRecebimento);
            this.splitContainer2.Panel2.Controls.Add(this.btnRecebimentoManual);
            this.splitContainer2.Size = new System.Drawing.Size(1051, 147);
            this.splitContainer2.SplitterDistance = 725;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(1051, 287);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Controls.Add(this.label1);
            this.iwtSearchPanel1.Controls.Add(this.nudIdOrdemProducao);
            this.iwtSearchPanel1.Controls.Add(this.chkIdOP);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(725, 147);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(113, 16);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(319, 20);
            this.iwtTextBox1.TabIndex = 38;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(73, 19);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 39;
            this.iwtLabel1.Text = "Busca";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ordem de Produção";
            // 
            // nudIdOrdemProducao
            // 
            this.nudIdOrdemProducao.BindingField = "OrdemProducaoId";
            this.nudIdOrdemProducao.Enabled = false;
            this.nudIdOrdemProducao.LiberadoQuandoCadastroUtilizado = false;
            this.nudIdOrdemProducao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudIdOrdemProducao.Location = new System.Drawing.Point(113, 42);
            this.nudIdOrdemProducao.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudIdOrdemProducao.Name = "nudIdOrdemProducao";
            this.nudIdOrdemProducao.Size = new System.Drawing.Size(120, 20);
            this.nudIdOrdemProducao.TabIndex = 40;
            // 
            // chkIdOP
            // 
            this.chkIdOP.AutoSize = true;
            this.chkIdOP.BindingField = null;
            this.chkIdOP.LiberadoQuandoCadastroUtilizado = false;
            this.chkIdOP.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkIdOP.Location = new System.Drawing.Point(239, 44);
            this.chkIdOP.Name = "chkIdOP";
            this.chkIdOP.Size = new System.Drawing.Size(15, 14);
            this.chkIdOP.TabIndex = 41;
            this.chkIdOP.UseVisualStyleBackColor = true;
            this.chkIdOP.CheckedChanged += new System.EventHandler(this.chkIdOP_CheckedChanged);
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
            this.OrdemProducao,
            this.ProdutoColumn,
            this.Fornecedor,
            this.IdNfPrincipal,
            this.Quantidade,
            this.DataEnvio,
            this.IdAcsUsuarioEnvio,
            this.SaldoReceberColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(1051, 249);
            this.iwtDataGridView1.TabIndex = 1;
            // 
            // btnRecebimentoManual
            // 
            this.btnRecebimentoManual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecebimentoManual.LiberadoQuandoCadastroUtilizado = false;
            this.btnRecebimentoManual.Location = new System.Drawing.Point(66, 19);
            this.btnRecebimentoManual.Name = "btnRecebimentoManual";
            this.btnRecebimentoManual.Size = new System.Drawing.Size(244, 23);
            this.btnRecebimentoManual.TabIndex = 0;
            this.btnRecebimentoManual.Text = "Recebimento Manual";
            this.btnRecebimentoManual.UseVisualStyleBackColor = true;
            this.btnRecebimentoManual.Click += new System.EventHandler(this.btnRecebimentoManual_Click);
            // 
            // btnCancelamentoSaldoRecebimento
            // 
            this.btnCancelamentoSaldoRecebimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelamentoSaldoRecebimento.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelamentoSaldoRecebimento.Location = new System.Drawing.Point(66, 101);
            this.btnCancelamentoSaldoRecebimento.Name = "btnCancelamentoSaldoRecebimento";
            this.btnCancelamentoSaldoRecebimento.Size = new System.Drawing.Size(244, 23);
            this.btnCancelamentoSaldoRecebimento.TabIndex = 1;
            this.btnCancelamentoSaldoRecebimento.Text = "Cancelamento de Saldo de Recebimento";
            this.btnCancelamentoSaldoRecebimento.UseVisualStyleBackColor = true;
            this.btnCancelamentoSaldoRecebimento.Click += new System.EventHandler(this.btnCancelamentoSaldoRecebimento_Click);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 150;
            // 
            // OrdemProducao
            // 
            this.OrdemProducao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrdemProducao.DataPropertyName = "OrdemProducao";
            this.OrdemProducao.HeaderText = "Ordem Produção";
            this.OrdemProducao.Name = "OrdemProducao";
            this.OrdemProducao.ReadOnly = true;
            this.OrdemProducao.Width = 150;
            // 
            // ProdutoColumn
            // 
            this.ProdutoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoColumn.DataPropertyName = "Produto";
            this.ProdutoColumn.HeaderText = "Produto";
            this.ProdutoColumn.Name = "ProdutoColumn";
            this.ProdutoColumn.ReadOnly = true;
            // 
            // Fornecedor
            // 
            this.Fornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fornecedor.DataPropertyName = "Fornecedor";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            this.Fornecedor.Width = 150;
            // 
            // IdNfPrincipal
            // 
            this.IdNfPrincipal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdNfPrincipal.DataPropertyName = "NfPrincipal";
            this.IdNfPrincipal.HeaderText = "Nota Fiscal de Envio";
            this.IdNfPrincipal.Name = "IdNfPrincipal";
            this.IdNfPrincipal.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // DataEnvio
            // 
            this.DataEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEnvio.DataPropertyName = "DataEnvio";
            this.DataEnvio.HeaderText = "Data Envio";
            this.DataEnvio.Name = "DataEnvio";
            this.DataEnvio.ReadOnly = true;
            // 
            // IdAcsUsuarioEnvio
            // 
            this.IdAcsUsuarioEnvio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdAcsUsuarioEnvio.DataPropertyName = "AcsUsuarioEnvio";
            this.IdAcsUsuarioEnvio.HeaderText = "Usuário Envio";
            this.IdAcsUsuarioEnvio.Name = "IdAcsUsuarioEnvio";
            this.IdAcsUsuarioEnvio.ReadOnly = true;
            // 
            // SaldoReceberColumn
            // 
            this.SaldoReceberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SaldoReceberColumn.DataPropertyName = "SaldoRecebimento";
            this.SaldoReceberColumn.HeaderText = "Saldo à Receber";
            this.SaldoReceberColumn.Name = "SaldoReceberColumn";
            this.SaldoReceberColumn.ReadOnly = true;
            // 
            // ServicoExternoAguardandoRecebimentoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 468);
            this.Name = "ServicoExternoAguardandoRecebimentoListForm";
            this.Text = "Itens Aguardando Recebimento de Serviço Externo";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIdOrdemProducao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private System.Windows.Forms.Label label1;
        private IWTDotNetLib.IWTNumericUpDown nudIdOrdemProducao;
        private IWTDotNetLib.IWTCheckBox chkIdOP;
        private IWTDotNetLib.IWTButton btnRecebimentoManual;
        private IWTDotNetLib.IWTButton btnCancelamentoSaldoRecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdemProducao;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNfPrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAcsUsuarioEnvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoReceberColumn;
    }
}