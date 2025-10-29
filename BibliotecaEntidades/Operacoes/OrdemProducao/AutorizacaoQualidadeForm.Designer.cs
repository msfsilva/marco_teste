namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    partial class AutorizacaoQualidadeForm
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
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblProduto = new IWTDotNetLib.IWTLabel(this.components);
            this.lblOp = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLiberar = new IWTDotNetLib.IWTButton(this.components);
            this.txtObservacaoQualidade = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel6 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtSenha = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel5 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtUsuario = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 9);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(515, 42);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "O produto da ordem de produção possui ao menos um bloqueio de qualidade ativo, é " +
    "necessária uma autorização da qualidade para o encerramento da OP";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(12, 51);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(47, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "Produto:";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.BindingField = null;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.LiberadoQuandoCadastroUtilizado = false;
            this.lblProduto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblProduto.Location = new System.Drawing.Point(65, 51);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(0, 13);
            this.lblProduto.TabIndex = 2;
            // 
            // lblOp
            // 
            this.lblOp.AutoSize = true;
            this.lblOp.BindingField = null;
            this.lblOp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOp.LiberadoQuandoCadastroUtilizado = false;
            this.lblOp.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblOp.Location = new System.Drawing.Point(65, 75);
            this.lblOp.Name = "lblOp";
            this.lblOp.Size = new System.Drawing.Size(0, 13);
            this.lblOp.TabIndex = 4;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(34, 75);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(25, 13);
            this.iwtLabel4.TabIndex = 3;
            this.iwtLabel4.Text = "OP:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLiberar);
            this.groupBox1.Controls.Add(this.txtObservacaoQualidade);
            this.groupBox1.Controls.Add(this.iwtLabel6);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Controls.Add(this.iwtLabel5);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.iwtLabel3);
            this.groupBox1.Location = new System.Drawing.Point(15, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 204);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Responsável pela Qualidade";
            // 
            // btnLiberar
            // 
            this.btnLiberar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLiberar.LiberadoQuandoCadastroUtilizado = false;
            this.btnLiberar.Location = new System.Drawing.Point(431, 175);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(75, 23);
            this.btnLiberar.TabIndex = 6;
            this.btnLiberar.Text = "Liberar";
            this.btnLiberar.UseVisualStyleBackColor = true;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // txtObservacaoQualidade
            // 
            this.txtObservacaoQualidade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObservacaoQualidade.BindingField = null;
            this.txtObservacaoQualidade.DebugMode = false;
            this.txtObservacaoQualidade.LiberadoQuandoCadastroUtilizado = false;
            this.txtObservacaoQualidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtObservacaoQualidade.Location = new System.Drawing.Point(55, 105);
            this.txtObservacaoQualidade.ModoBarcode = false;
            this.txtObservacaoQualidade.ModoBusca = false;
            this.txtObservacaoQualidade.Multiline = true;
            this.txtObservacaoQualidade.Name = "txtObservacaoQualidade";
            this.txtObservacaoQualidade.NaoLimparDepoisBarcode = false;
            this.txtObservacaoQualidade.Size = new System.Drawing.Size(451, 64);
            this.txtObservacaoQualidade.TabIndex = 5;
            // 
            // iwtLabel6
            // 
            this.iwtLabel6.AutoSize = true;
            this.iwtLabel6.BindingField = null;
            this.iwtLabel6.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel6.Location = new System.Drawing.Point(6, 89);
            this.iwtLabel6.Name = "iwtLabel6";
            this.iwtLabel6.Size = new System.Drawing.Size(131, 13);
            this.iwtLabel6.TabIndex = 4;
            this.iwtLabel6.Text = "Observação da Qualidade";
            // 
            // txtSenha
            // 
            this.txtSenha.BindingField = null;
            this.txtSenha.DebugMode = false;
            this.txtSenha.LiberadoQuandoCadastroUtilizado = false;
            this.txtSenha.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtSenha.Location = new System.Drawing.Point(55, 49);
            this.txtSenha.ModoBarcode = false;
            this.txtSenha.ModoBusca = false;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.NaoLimparDepoisBarcode = false;
            this.txtSenha.Size = new System.Drawing.Size(202, 20);
            this.txtSenha.TabIndex = 3;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // iwtLabel5
            // 
            this.iwtLabel5.AutoSize = true;
            this.iwtLabel5.BindingField = null;
            this.iwtLabel5.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel5.Location = new System.Drawing.Point(6, 52);
            this.iwtLabel5.Name = "iwtLabel5";
            this.iwtLabel5.Size = new System.Drawing.Size(38, 13);
            this.iwtLabel5.TabIndex = 2;
            this.iwtLabel5.Text = "Senha";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BindingField = null;
            this.txtUsuario.DebugMode = false;
            this.txtUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.txtUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtUsuario.Location = new System.Drawing.Point(55, 23);
            this.txtUsuario.ModoBarcode = false;
            this.txtUsuario.ModoBusca = false;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.NaoLimparDepoisBarcode = false;
            this.txtUsuario.Size = new System.Drawing.Size(202, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(6, 26);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(43, 13);
            this.iwtLabel3.TabIndex = 0;
            this.iwtLabel3.Text = "Usuário";
            // 
            // AutorizacaoQualidadeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 324);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblOp);
            this.Controls.Add(this.iwtLabel4);
            this.Controls.Add(this.lblProduto);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "AutorizacaoQualidadeForm";
            this.Text = "Autorização da Qualidade";
            this.Shown += new System.EventHandler(this.AutorizacaoQualidadeForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel lblProduto;
        private IWTDotNetLib.IWTLabel lblOp;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTTextBox txtUsuario;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTTextBox txtSenha;
        private IWTDotNetLib.IWTLabel iwtLabel5;
        private IWTDotNetLib.IWTLabel iwtLabel6;
        private IWTDotNetLib.IWTTextBox txtObservacaoQualidade;
        private IWTDotNetLib.IWTButton btnLiberar;
    }
}