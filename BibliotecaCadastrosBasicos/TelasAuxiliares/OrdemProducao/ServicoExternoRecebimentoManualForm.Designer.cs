namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class ServicoExternoRecebimentoManualForm
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
            this.txtChaveNota = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudLinhaNota = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.lblInformacoesNfe = new IWTDotNetLib.IWTLabel(this.components);
            this.lblQtdReceber = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQuantidadeReceber = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.btnSalvar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.lblInformacoesItens = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNota = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhaNota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeReceber)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 25);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(109, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Chave da Nota Fiscal";
            // 
            // txtChaveNota
            // 
            this.txtChaveNota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChaveNota.BindingField = null;
            this.txtChaveNota.DebugMode = false;
            this.txtChaveNota.LiberadoQuandoCadastroUtilizado = false;
            this.txtChaveNota.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtChaveNota.Location = new System.Drawing.Point(38, 41);
            this.txtChaveNota.ModoBarcode = false;
            this.txtChaveNota.ModoBusca = false;
            this.txtChaveNota.Name = "txtChaveNota";
            this.txtChaveNota.NaoLimparDepoisBarcode = false;
            this.txtChaveNota.Size = new System.Drawing.Size(518, 20);
            this.txtChaveNota.TabIndex = 1;
            this.txtChaveNota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChaveNota_KeyDown);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(12, 207);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(123, 13);
            this.iwtLabel2.TabIndex = 2;
            this.iwtLabel2.Text = "Número do Item da Nota";
            // 
            // nudLinhaNota
            // 
            this.nudLinhaNota.BindingField = null;
            this.nudLinhaNota.Enabled = false;
            this.nudLinhaNota.LiberadoQuandoCadastroUtilizado = false;
            this.nudLinhaNota.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLinhaNota.Location = new System.Drawing.Point(38, 223);
            this.nudLinhaNota.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudLinhaNota.Name = "nudLinhaNota";
            this.nudLinhaNota.Size = new System.Drawing.Size(120, 20);
            this.nudLinhaNota.TabIndex = 3;
            this.nudLinhaNota.ValueChanged += new System.EventHandler(this.nudLinhaNota_ValueChanged);
            // 
            // lblInformacoesNfe
            // 
            this.lblInformacoesNfe.BindingField = null;
            this.lblInformacoesNfe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInformacoesNfe.LiberadoQuandoCadastroUtilizado = false;
            this.lblInformacoesNfe.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblInformacoesNfe.Location = new System.Drawing.Point(3, 16);
            this.lblInformacoesNfe.Name = "lblInformacoesNfe";
            this.lblInformacoesNfe.Size = new System.Drawing.Size(556, 95);
            this.lblInformacoesNfe.TabIndex = 4;
            // 
            // lblQtdReceber
            // 
            this.lblQtdReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtdReceber.AutoSize = true;
            this.lblQtdReceber.BindingField = null;
            this.lblQtdReceber.LiberadoQuandoCadastroUtilizado = false;
            this.lblQtdReceber.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblQtdReceber.Location = new System.Drawing.Point(21, 379);
            this.lblQtdReceber.Name = "lblQtdReceber";
            this.lblQtdReceber.Size = new System.Drawing.Size(115, 13);
            this.lblQtdReceber.TabIndex = 5;
            this.lblQtdReceber.Text = "Quantidade a Receber";
            // 
            // nudQuantidadeReceber
            // 
            this.nudQuantidadeReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudQuantidadeReceber.BindingField = null;
            this.nudQuantidadeReceber.DecimalPlaces = 5;
            this.nudQuantidadeReceber.Enabled = false;
            this.nudQuantidadeReceber.LiberadoQuandoCadastroUtilizado = false;
            this.nudQuantidadeReceber.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQuantidadeReceber.Location = new System.Drawing.Point(38, 395);
            this.nudQuantidadeReceber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudQuantidadeReceber.Name = "nudQuantidadeReceber";
            this.nudQuantidadeReceber.Size = new System.Drawing.Size(120, 20);
            this.nudQuantidadeReceber.TabIndex = 6;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.LiberadoQuandoCadastroUtilizado = false;
            this.btnSalvar.Location = new System.Drawing.Point(525, 431);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(12, 431);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblInformacoesItens
            // 
            this.lblInformacoesItens.BindingField = null;
            this.lblInformacoesItens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInformacoesItens.LiberadoQuandoCadastroUtilizado = false;
            this.lblInformacoesItens.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblInformacoesItens.Location = new System.Drawing.Point(3, 16);
            this.lblInformacoesItens.Name = "lblInformacoesItens";
            this.lblInformacoesItens.Size = new System.Drawing.Size(556, 81);
            this.lblInformacoesItens.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblInformacoesNfe);
            this.groupBox1.Location = new System.Drawing.Point(38, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 114);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Nota Selecionada";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblInformacoesItens);
            this.groupBox2.Location = new System.Drawing.Point(38, 251);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados da Operação";
            // 
            // btnNota
            // 
            this.btnNota.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNota.LiberadoQuandoCadastroUtilizado = false;
            this.btnNota.Location = new System.Drawing.Point(562, 39);
            this.btnNota.Name = "btnNota";
            this.btnNota.Size = new System.Drawing.Size(38, 23);
            this.btnNota.TabIndex = 2;
            this.btnNota.Text = ">>";
            this.btnNota.UseVisualStyleBackColor = true;
            this.btnNota.Click += new System.EventHandler(this.btnNota_Click);
            // 
            // ServicoExternoRecebimentoManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 466);
            this.Controls.Add(this.btnNota);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.nudQuantidadeReceber);
            this.Controls.Add(this.lblQtdReceber);
            this.Controls.Add(this.nudLinhaNota);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.txtChaveNota);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "ServicoExternoRecebimentoManualForm";
            this.Text = "Recebimento Manual de Serviço Externo";
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhaNota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidadeReceber)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox txtChaveNota;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTNumericUpDown nudLinhaNota;
        private IWTDotNetLib.IWTLabel lblInformacoesNfe;
        private IWTDotNetLib.IWTLabel lblQtdReceber;
        private IWTDotNetLib.IWTNumericUpDown nudQuantidadeReceber;
        private IWTDotNetLib.IWTButton btnSalvar;
        private IWTDotNetLib.IWTButton btnCancelar;
        private IWTDotNetLib.IWTLabel lblInformacoesItens;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTButton btnNota;
    }
}