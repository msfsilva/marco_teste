namespace BibliotecaCompras
{
    partial class CadNFEntradaItemForm
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
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtCodigo = new IWTDotNetLib.IWTTextBox(this.components);
            this.txtDescricao = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudValorUnitario = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudQuantidade = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.label5 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblValorTotal = new IWTDotNetLib.IWTLabel(this.components);
            this.nudImcsIncluso = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label6 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudIPINaoIncluso = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.label7 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnOk = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.txtNCM = new IWTDotNetLib.IWTTextBox(this.components);
            this.label8 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtUnidade = new IWTDotNetLib.IWTTextBox(this.components);
            this.label9 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtXped = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudPosicao = new IWTDotNetLib.IWTNumericUpDown(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImcsIncluso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIPINaoIncluso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código do Item";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BindingField = null;
            this.txtCodigo.DebugMode = false;
            this.txtCodigo.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigo.Location = new System.Drawing.Point(111, 15);
            this.txtCodigo.ModoBarcode = false;
            this.txtCodigo.ModoBusca = false;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.NaoLimparDepoisBarcode = false;
            this.txtCodigo.Size = new System.Drawing.Size(229, 20);
            this.txtCodigo.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BindingField = null;
            this.txtDescricao.DebugMode = false;
            this.txtDescricao.LiberadoQuandoCadastroUtilizado = false;
            this.txtDescricao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtDescricao.Location = new System.Drawing.Point(111, 43);
            this.txtDescricao.ModoBarcode = false;
            this.txtDescricao.ModoBusca = false;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.NaoLimparDepoisBarcode = false;
            this.txtDescricao.Size = new System.Drawing.Size(229, 20);
            this.txtDescricao.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descrição do Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(35, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Valor Unitário";
            // 
            // nudValorUnitario
            // 
            this.nudValorUnitario.BindingField = null;
            this.nudValorUnitario.DecimalPlaces = 2;
            this.nudValorUnitario.LiberadoQuandoCadastroUtilizado = false;
            this.nudValorUnitario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudValorUnitario.Location = new System.Drawing.Point(111, 128);
            this.nudValorUnitario.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudValorUnitario.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudValorUnitario.Name = "nudValorUnitario";
            this.nudValorUnitario.Size = new System.Drawing.Size(120, 20);
            this.nudValorUnitario.TabIndex = 4;
            this.nudValorUnitario.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudValorUnitario.ValueChanged += new System.EventHandler(this.nudValorUnitario_ValueChanged);
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.BindingField = null;
            this.nudQuantidade.DecimalPlaces = 4;
            this.nudQuantidade.LiberadoQuandoCadastroUtilizado = false;
            this.nudQuantidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQuantidade.Location = new System.Drawing.Point(111, 154);
            this.nudQuantidade.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 20);
            this.nudQuantidade.TabIndex = 5;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidade.ValueChanged += new System.EventHandler(this.nudQuantidade_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(43, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quantidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BindingField = null;
            this.label5.LiberadoQuandoCadastroUtilizado = false;
            this.label5.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label5.Location = new System.Drawing.Point(47, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Valor Total";
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.BindingField = null;
            this.lblValorTotal.LiberadoQuandoCadastroUtilizado = false;
            this.lblValorTotal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblValorTotal.Location = new System.Drawing.Point(111, 177);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(0, 13);
            this.lblValorTotal.TabIndex = 6;
            // 
            // nudImcsIncluso
            // 
            this.nudImcsIncluso.BindingField = null;
            this.nudImcsIncluso.DecimalPlaces = 2;
            this.nudImcsIncluso.LiberadoQuandoCadastroUtilizado = false;
            this.nudImcsIncluso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudImcsIncluso.Location = new System.Drawing.Point(111, 195);
            this.nudImcsIncluso.Name = "nudImcsIncluso";
            this.nudImcsIncluso.Size = new System.Drawing.Size(120, 20);
            this.nudImcsIncluso.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BindingField = null;
            this.label6.LiberadoQuandoCadastroUtilizado = false;
            this.label6.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label6.Location = new System.Drawing.Point(18, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "ICMS Incluso (%)";
            // 
            // nudIPINaoIncluso
            // 
            this.nudIPINaoIncluso.BindingField = null;
            this.nudIPINaoIncluso.DecimalPlaces = 2;
            this.nudIPINaoIncluso.LiberadoQuandoCadastroUtilizado = false;
            this.nudIPINaoIncluso.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudIPINaoIncluso.Location = new System.Drawing.Point(111, 221);
            this.nudIPINaoIncluso.Name = "nudIPINaoIncluso";
            this.nudIPINaoIncluso.Size = new System.Drawing.Size(120, 20);
            this.nudIPINaoIncluso.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BindingField = null;
            this.label7.LiberadoQuandoCadastroUtilizado = false;
            this.label7.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label7.Location = new System.Drawing.Point(8, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "IPI Não Incluso (%)";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.LiberadoQuandoCadastroUtilizado = false;
            this.btnOk.Location = new System.Drawing.Point(288, 335);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(11, 335);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNCM
            // 
            this.txtNCM.BindingField = null;
            this.txtNCM.DebugMode = false;
            this.txtNCM.LiberadoQuandoCadastroUtilizado = false;
            this.txtNCM.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtNCM.Location = new System.Drawing.Point(111, 69);
            this.txtNCM.MaxLength = 8;
            this.txtNCM.ModoBarcode = false;
            this.txtNCM.ModoBusca = false;
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.NaoLimparDepoisBarcode = false;
            this.txtNCM.Size = new System.Drawing.Size(229, 20);
            this.txtNCM.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BindingField = null;
            this.label8.LiberadoQuandoCadastroUtilizado = false;
            this.label8.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label8.Location = new System.Drawing.Point(74, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "NCM";
            // 
            // txtUnidade
            // 
            this.txtUnidade.BindingField = null;
            this.txtUnidade.DebugMode = false;
            this.txtUnidade.LiberadoQuandoCadastroUtilizado = false;
            this.txtUnidade.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtUnidade.Location = new System.Drawing.Point(111, 95);
            this.txtUnidade.ModoBarcode = false;
            this.txtUnidade.ModoBusca = false;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.NaoLimparDepoisBarcode = false;
            this.txtUnidade.Size = new System.Drawing.Size(229, 20);
            this.txtUnidade.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BindingField = null;
            this.label9.LiberadoQuandoCadastroUtilizado = false;
            this.label9.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label9.Location = new System.Drawing.Point(58, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Unidade";
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(27, 270);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(73, 13);
            this.iwtLabel1.TabIndex = 19;
            this.iwtLabel1.Text = "Pedido (xPed)";
            // 
            // txtXped
            // 
            this.txtXped.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtXped.BindingField = null;
            this.txtXped.DebugMode = false;
            this.txtXped.LiberadoQuandoCadastroUtilizado = false;
            this.txtXped.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtXped.Location = new System.Drawing.Point(111, 267);
            this.txtXped.ModoBarcode = false;
            this.txtXped.ModoBusca = false;
            this.txtXped.Name = "txtXped";
            this.txtXped.NaoLimparDepoisBarcode = false;
            this.txtXped.Size = new System.Drawing.Size(229, 20);
            this.txtXped.TabIndex = 20;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(4, 295);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(96, 13);
            this.iwtLabel2.TabIndex = 21;
            this.iwtLabel2.Text = "Posição do Pedido";
            // 
            // nudPosicao
            // 
            this.nudPosicao.BindingField = null;
            this.nudPosicao.LiberadoQuandoCadastroUtilizado = false;
            this.nudPosicao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPosicao.Location = new System.Drawing.Point(111, 293);
            this.nudPosicao.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudPosicao.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPosicao.Name = "nudPosicao";
            this.nudPosicao.Size = new System.Drawing.Size(120, 20);
            this.nudPosicao.TabIndex = 22;
            this.nudPosicao.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CadNFEntradaItemForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(375, 370);
            this.Controls.Add(this.nudPosicao);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.txtXped);
            this.Controls.Add(this.iwtLabel1);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNCM);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.nudIPINaoIncluso);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudImcsIncluso);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudValorUnitario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Name = "CadNFEntradaItemForm";
            this.Text = "Item NF Entrada";
            ((System.ComponentModel.ISupportInitialize)(this.nudValorUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudImcsIncluso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIPINaoIncluso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPosicao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel label1;
        private IWTDotNetLib.IWTTextBox txtCodigo;
        private IWTDotNetLib.IWTTextBox txtDescricao;
        private IWTDotNetLib.IWTLabel label2;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTNumericUpDown nudValorUnitario;
        private IWTDotNetLib.IWTNumericUpDown nudQuantidade;
        private IWTDotNetLib.IWTLabel label4;
        private IWTDotNetLib.IWTLabel label5;
        private IWTDotNetLib.IWTLabel lblValorTotal;
        private IWTDotNetLib.IWTNumericUpDown nudImcsIncluso;
        private IWTDotNetLib.IWTLabel label6;
        private IWTDotNetLib.IWTNumericUpDown nudIPINaoIncluso;
        private IWTDotNetLib.IWTLabel label7;
        private IWTDotNetLib.IWTButton btnOk;
        private IWTDotNetLib.IWTButton btnCancelar;
        private IWTDotNetLib.IWTTextBox txtNCM;
        private IWTDotNetLib.IWTLabel label8;
        private IWTDotNetLib.IWTTextBox txtUnidade;
        private IWTDotNetLib.IWTLabel label9;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox txtXped;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTNumericUpDown nudPosicao;
    }
}