namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class GerarOpAvulsaForm
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblSugestaoProducao = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOpsAberto = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVermelho = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblAmarelo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblVerde = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblEstoqueAtual = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPedidosPendentes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rdbProduto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbProdutoK = new IWTDotNetLib.IWTRadioButton(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.chkCarregarQuantidadesEstoque = new IWTDotNetLib.IWTCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Size = new System.Drawing.Size(922, 364);
            this.splitContainer1.SplitterDistance = 303;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.chkCarregarQuantidadesEstoque);
            this.splitContainer3.Panel2.Controls.Add(this.lblSugestaoProducao);
            this.splitContainer3.Panel2.Controls.Add(this.label10);
            this.splitContainer3.Panel2.Controls.Add(this.lblOpsAberto);
            this.splitContainer3.Panel2.Controls.Add(this.label6);
            this.splitContainer3.Panel2.Controls.Add(this.lblVermelho);
            this.splitContainer3.Panel2.Controls.Add(this.label11);
            this.splitContainer3.Panel2.Controls.Add(this.lblAmarelo);
            this.splitContainer3.Panel2.Controls.Add(this.label9);
            this.splitContainer3.Panel2.Controls.Add(this.lblVerde);
            this.splitContainer3.Panel2.Controls.Add(this.label7);
            this.splitContainer3.Panel2.Controls.Add(this.lblEstoqueAtual);
            this.splitContainer3.Panel2.Controls.Add(this.label5);
            this.splitContainer3.Panel2.Controls.Add(this.lblPedidosPendentes);
            this.splitContainer3.Panel2.Controls.Add(this.label3);
            this.splitContainer3.Size = new System.Drawing.Size(922, 303);
            this.splitContainer3.SplitterDistance = 700;
            this.splitContainer3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(700, 303);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // lblSugestaoProducao
            // 
            this.lblSugestaoProducao.AutoSize = true;
            this.lblSugestaoProducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSugestaoProducao.Location = new System.Drawing.Point(119, 240);
            this.lblSugestaoProducao.Name = "lblSugestaoProducao";
            this.lblSugestaoProducao.Size = new System.Drawing.Size(0, 13);
            this.lblSugestaoProducao.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Sugestão de Qtd";
            // 
            // lblOpsAberto
            // 
            this.lblOpsAberto.AutoSize = true;
            this.lblOpsAberto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpsAberto.Location = new System.Drawing.Point(119, 207);
            this.lblOpsAberto.Name = "lblOpsAberto";
            this.lblOpsAberto.Size = new System.Drawing.Size(0, 13);
            this.lblOpsAberto.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "OPs em Aberto";
            // 
            // lblVermelho
            // 
            this.lblVermelho.AutoSize = true;
            this.lblVermelho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVermelho.Location = new System.Drawing.Point(119, 174);
            this.lblVermelho.Name = "lblVermelho";
            this.lblVermelho.Size = new System.Drawing.Size(0, 13);
            this.lblVermelho.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 174);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Demanda Vermelho";
            // 
            // lblAmarelo
            // 
            this.lblAmarelo.AutoSize = true;
            this.lblAmarelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmarelo.Location = new System.Drawing.Point(119, 141);
            this.lblAmarelo.Name = "lblAmarelo";
            this.lblAmarelo.Size = new System.Drawing.Size(0, 13);
            this.lblAmarelo.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Demanda Amarelo";
            // 
            // lblVerde
            // 
            this.lblVerde.AutoSize = true;
            this.lblVerde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerde.Location = new System.Drawing.Point(119, 108);
            this.lblVerde.Name = "lblVerde";
            this.lblVerde.Size = new System.Drawing.Size(0, 13);
            this.lblVerde.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Demanda Verde";
            // 
            // lblEstoqueAtual
            // 
            this.lblEstoqueAtual.AutoSize = true;
            this.lblEstoqueAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoqueAtual.Location = new System.Drawing.Point(119, 75);
            this.lblEstoqueAtual.Name = "lblEstoqueAtual";
            this.lblEstoqueAtual.Size = new System.Drawing.Size(0, 13);
            this.lblEstoqueAtual.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Estoque Atual";
            // 
            // lblPedidosPendentes
            // 
            this.lblPedidosPendentes.AutoSize = true;
            this.lblPedidosPendentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidosPendentes.Location = new System.Drawing.Point(119, 42);
            this.lblPedidosPendentes.Name = "lblPedidosPendentes";
            this.lblPedidosPendentes.Size = new System.Drawing.Size(0, 13);
            this.lblPedidosPendentes.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pedidos Pendentes";
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(54, 19);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(182, 20);
            this.txtBusca.TabIndex = 4;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Busca";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(835, 17);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.rdbProduto);
            this.splitContainer2.Panel1.Controls.Add(this.rdbProdutoK);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(922, 430);
            this.splitContainer2.SplitterDistance = 62;
            this.splitContainer2.TabIndex = 1;
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.BindingField = null;
            this.rdbProduto.LiberadoQuandoCadastroUtilizado = false;
            this.rdbProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbProduto.Location = new System.Drawing.Point(212, 33);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(62, 17);
            this.rdbProduto.TabIndex = 2;
            this.rdbProduto.TabStop = true;
            this.rdbProduto.Text = "Produto";
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // rdbProdutoK
            // 
            this.rdbProdutoK.AutoSize = true;
            this.rdbProdutoK.BindingField = null;
            this.rdbProdutoK.LiberadoQuandoCadastroUtilizado = false;
            this.rdbProdutoK.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbProdutoK.Location = new System.Drawing.Point(12, 33);
            this.rdbProdutoK.Name = "rdbProdutoK";
            this.rdbProdutoK.Size = new System.Drawing.Size(177, 17);
            this.rdbProdutoK.TabIndex = 1;
            this.rdbProdutoK.TabStop = true;
            this.rdbProdutoK.Text = "Kanban de Itens Manufaturados";
            this.rdbProdutoK.UseVisualStyleBackColor = true;
            this.rdbProdutoK.CheckedChanged += new System.EventHandler(this.rdbProdutoK_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(905, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selecione o tipo e preencha a coluna quantidade dos itens para os quais você dese" +
    "ja emitir as Ordens de Produção. Itens com quantidade 0 serão ignorados.";
            // 
            // chkCarregarQuantidadesEstoque
            // 
            this.chkCarregarQuantidadesEstoque.AutoSize = true;
            this.chkCarregarQuantidadesEstoque.BindingField = null;
            this.chkCarregarQuantidadesEstoque.LiberadoQuandoCadastroUtilizado = false;
            this.chkCarregarQuantidadesEstoque.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkCarregarQuantidadesEstoque.Location = new System.Drawing.Point(3, 3);
            this.chkCarregarQuantidadesEstoque.Name = "chkCarregarQuantidadesEstoque";
            this.chkCarregarQuantidadesEstoque.Size = new System.Drawing.Size(171, 17);
            this.chkCarregarQuantidadesEstoque.TabIndex = 14;
            this.chkCarregarQuantidadesEstoque.Text = "Carregar Quantidades Estoque";
            this.chkCarregarQuantidadesEstoque.UseVisualStyleBackColor = true;
            this.chkCarregarQuantidadesEstoque.CheckedChanged += new System.EventHandler(this.chkCarregarQuantidadesEstoque_CheckedChanged);
            // 
            // GerarOpAvulsaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(922, 430);
            this.Controls.Add(this.splitContainer2);
            this.Name = "GerarOpAvulsaForm";
            this.Text = "Gerar Ordem de Produção Avulsa";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lblVermelho;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblAmarelo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblVerde;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEstoqueAtual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPedidosPendentes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSugestaoProducao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOpsAberto;
        private System.Windows.Forms.Label label6;
        private IWTDotNetLib.IWTRadioButton rdbProduto;
        private IWTDotNetLib.IWTRadioButton rdbProdutoK;
        private IWTDotNetLib.IWTCheckBox chkCarregarQuantidadesEstoque;
    }
}