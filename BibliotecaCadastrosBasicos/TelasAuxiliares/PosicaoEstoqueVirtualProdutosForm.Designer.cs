namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class PosicaoEstoqueVirtualProdutosForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ensProduto = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSaldoVirtualEstoque = new System.Windows.Forms.Label();
            this.lblQtdReservada = new System.Windows.Forms.Label();
            this.lblQtdProducao = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEstoqueFisico = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ensProdutoK = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.rdbProduto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbProdutoK = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto";
            // 
            // ensProduto
            // 
            this.ensProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensProduto.BindingField = null;
            this.ensProduto.ColunasDropdown = null;
            this.ensProduto.DesabilitarAutoCompletar = false;
            this.ensProduto.DesabilitarChekBox = true;
            this.ensProduto.DesabilitarLupa = false;
            this.ensProduto.DesabilitarSeta = false;
            this.ensProduto.EntidadeSelecionada = null;
            this.ensProduto.FormSelecao = null;
            this.ensProduto.LiberadoQuandoCadastroUtilizado = false;
            this.ensProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProduto.Location = new System.Drawing.Point(174, 12);
            this.ensProduto.ModoVisualizacaoGrid = null;
            this.ensProduto.Name = "ensProduto";
            this.ensProduto.ParametroBuscaGuiada = null;
            this.ensProduto.ParametrosBuscaObrigatorios = null;
            this.ensProduto.Size = new System.Drawing.Size(374, 23);
            this.ensProduto.TabIndex = 0;
            this.ensProduto.EntityChange += new System.EventHandler(this.ensProduto_EntityChange);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblSaldoVirtualEstoque);
            this.groupBox1.Controls.Add(this.lblQtdReservada);
            this.groupBox1.Controls.Add(this.lblQtdProducao);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblEstoqueFisico);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 154);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Posição Atual";
            // 
            // lblSaldoVirtualEstoque
            // 
            this.lblSaldoVirtualEstoque.AutoSize = true;
            this.lblSaldoVirtualEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoVirtualEstoque.Location = new System.Drawing.Point(317, 115);
            this.lblSaldoVirtualEstoque.Name = "lblSaldoVirtualEstoque";
            this.lblSaldoVirtualEstoque.Size = new System.Drawing.Size(14, 13);
            this.lblSaldoVirtualEstoque.TabIndex = 7;
            this.lblSaldoVirtualEstoque.Text = "0";
            // 
            // lblQtdReservada
            // 
            this.lblQtdReservada.AutoSize = true;
            this.lblQtdReservada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdReservada.Location = new System.Drawing.Point(317, 89);
            this.lblQtdReservada.Name = "lblQtdReservada";
            this.lblQtdReservada.Size = new System.Drawing.Size(14, 13);
            this.lblQtdReservada.TabIndex = 6;
            this.lblQtdReservada.Text = "0";
            // 
            // lblQtdProducao
            // 
            this.lblQtdProducao.AutoSize = true;
            this.lblQtdProducao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtdProducao.Location = new System.Drawing.Point(317, 63);
            this.lblQtdProducao.Name = "lblQtdProducao";
            this.lblQtdProducao.Size = new System.Drawing.Size(14, 13);
            this.lblQtdProducao.TabIndex = 5;
            this.lblQtdProducao.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Saldo Virtual do Etoque:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantidade reservada pelos pedidos configurados e abertos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantidade em Produção (OP):";
            // 
            // lblEstoqueFisico
            // 
            this.lblEstoqueFisico.AutoSize = true;
            this.lblEstoqueFisico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoqueFisico.Location = new System.Drawing.Point(317, 37);
            this.lblEstoqueFisico.Name = "lblEstoqueFisico";
            this.lblEstoqueFisico.Size = new System.Drawing.Size(14, 13);
            this.lblEstoqueFisico.TabIndex = 1;
            this.lblEstoqueFisico.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Estoque Fisico:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Kanban de Itens Manufaturados";
            // 
            // ensProdutoK
            // 
            this.ensProdutoK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensProdutoK.BindingField = null;
            this.ensProdutoK.ColunasDropdown = null;
            this.ensProdutoK.DesabilitarAutoCompletar = false;
            this.ensProdutoK.DesabilitarChekBox = true;
            this.ensProdutoK.DesabilitarLupa = false;
            this.ensProdutoK.DesabilitarSeta = false;
            this.ensProdutoK.EntidadeSelecionada = null;
            this.ensProdutoK.FormSelecao = null;
            this.ensProdutoK.LiberadoQuandoCadastroUtilizado = false;
            this.ensProdutoK.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensProdutoK.Location = new System.Drawing.Point(174, 41);
            this.ensProdutoK.ModoVisualizacaoGrid = null;
            this.ensProdutoK.Name = "ensProdutoK";
            this.ensProdutoK.ParametroBuscaGuiada = null;
            this.ensProdutoK.ParametrosBuscaObrigatorios = null;
            this.ensProdutoK.Size = new System.Drawing.Size(374, 23);
            this.ensProdutoK.TabIndex = 1;
            this.ensProdutoK.EntityChange += new System.EventHandler(this.ensProduto_EntityChange);
            // 
            // rdbProduto
            // 
            this.rdbProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.BindingField = null;
            this.rdbProduto.Checked = true;
            this.rdbProduto.LiberadoQuandoCadastroUtilizado = false;
            this.rdbProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbProduto.Location = new System.Drawing.Point(551, 16);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(14, 13);
            this.rdbProduto.TabIndex = 3;
            this.rdbProduto.TabStop = true;
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // rdbProdutoK
            // 
            this.rdbProdutoK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbProdutoK.AutoSize = true;
            this.rdbProdutoK.BindingField = null;
            this.rdbProdutoK.LiberadoQuandoCadastroUtilizado = false;
            this.rdbProdutoK.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbProdutoK.Location = new System.Drawing.Point(551, 45);
            this.rdbProdutoK.Name = "rdbProdutoK";
            this.rdbProdutoK.Size = new System.Drawing.Size(14, 13);
            this.rdbProdutoK.TabIndex = 4;
            this.rdbProdutoK.UseVisualStyleBackColor = true;
            // 
            // PosicaoEstoqueVirtualProdutosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 283);
            this.Controls.Add(this.rdbProdutoK);
            this.Controls.Add(this.rdbProduto);
            this.Controls.Add(this.ensProdutoK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ensProduto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "PosicaoEstoqueVirtualProdutosForm";
            this.Text = "Posição Virtual do Estoque de Produtos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private IWTDotNetLib.IWTEntitySelection ensProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEstoqueFisico;
        private System.Windows.Forms.Label lblSaldoVirtualEstoque;
        private System.Windows.Forms.Label lblQtdReservada;
        private System.Windows.Forms.Label lblQtdProducao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private IWTDotNetLib.IWTEntitySelection ensProdutoK;
        private IWTDotNetLib.IWTRadioButton rdbProduto;
        private IWTDotNetLib.IWTRadioButton rdbProdutoK;
    }
}