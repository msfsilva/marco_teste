namespace BibliotecaCadastrosBasicos.ClassesAuxiliares
{
    partial class TelaPosicaoInicialImpressaoEtiqueta
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
            this.nudLinhaInicial = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudColunaInicial = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnImprimir = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhaInicial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColunaInicial)).BeginInit();
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(19, 33);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(63, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Linha Inicial";
            // 
            // nudLinhaInicial
            // 
            this.nudLinhaInicial.BindingField = null;
            this.nudLinhaInicial.LiberadoQuandoCadastroUtilizado = false;
            this.nudLinhaInicial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudLinhaInicial.Location = new System.Drawing.Point(88, 31);
            this.nudLinhaInicial.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLinhaInicial.Name = "nudLinhaInicial";
            this.nudLinhaInicial.Size = new System.Drawing.Size(120, 20);
            this.nudLinhaInicial.TabIndex = 1;
            this.nudLinhaInicial.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudColunaInicial
            // 
            this.nudColunaInicial.BindingField = null;
            this.nudColunaInicial.LiberadoQuandoCadastroUtilizado = false;
            this.nudColunaInicial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudColunaInicial.Location = new System.Drawing.Point(88, 57);
            this.nudColunaInicial.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColunaInicial.Name = "nudColunaInicial";
            this.nudColunaInicial.Size = new System.Drawing.Size(120, 20);
            this.nudColunaInicial.TabIndex = 3;
            this.nudColunaInicial.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(12, 59);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(70, 13);
            this.iwtLabel2.TabIndex = 2;
            this.iwtLabel2.Text = "Coluna Inicial";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.LiberadoQuandoCadastroUtilizado = false;
            this.btnImprimir.Location = new System.Drawing.Point(236, 111);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 4;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // TelaPosicaoInicialImpressaoEtiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(323, 146);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.nudColunaInicial);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.nudLinhaInicial);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "TelaPosicaoInicialImpressaoEtiqueta";
            this.Text = "Tela de Posicionamento de Etiqueta";
            ((System.ComponentModel.ISupportInitialize)(this.nudLinhaInicial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColunaInicial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTNumericUpDown nudLinhaInicial;
        private IWTDotNetLib.IWTNumericUpDown nudColunaInicial;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTButton btnImprimir;
    }
}