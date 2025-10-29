namespace BibliotecaCadastrosBasicos
{
    partial class CadPalletForm
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
            this.lblNumeroInicial = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudNumeroFinal = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.btnCriar = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(26, 20);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(74, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Número Inicial";
            // 
            // lblNumeroInicial
            // 
            this.lblNumeroInicial.AutoSize = true;
            this.lblNumeroInicial.BindingField = null;
            this.lblNumeroInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroInicial.LiberadoQuandoCadastroUtilizado = false;
            this.lblNumeroInicial.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblNumeroInicial.Location = new System.Drawing.Point(106, 20);
            this.lblNumeroInicial.Name = "lblNumeroInicial";
            this.lblNumeroInicial.Size = new System.Drawing.Size(0, 13);
            this.lblNumeroInicial.TabIndex = 1;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(31, 46);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(69, 13);
            this.iwtLabel2.TabIndex = 2;
            this.iwtLabel2.Text = "Número Final";
            // 
            // nudNumeroFinal
            // 
            this.nudNumeroFinal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudNumeroFinal.BindingField = null;
            this.nudNumeroFinal.LiberadoQuandoCadastroUtilizado = false;
            this.nudNumeroFinal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudNumeroFinal.Location = new System.Drawing.Point(106, 44);
            this.nudNumeroFinal.Maximum = new decimal(new int[] {
            500000,
            0,
            0,
            0});
            this.nudNumeroFinal.Name = "nudNumeroFinal";
            this.nudNumeroFinal.Size = new System.Drawing.Size(120, 20);
            this.nudNumeroFinal.TabIndex = 3;
            // 
            // btnCriar
            // 
            this.btnCriar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCriar.Location = new System.Drawing.Point(193, 90);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(75, 23);
            this.btnCriar.TabIndex = 4;
            this.btnCriar.Text = "Criar";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // CadPalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 125);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.nudNumeroFinal);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.lblNumeroInicial);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "CadPalletForm";
            this.Text = "Adicionar novos Pallets";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumeroFinal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel lblNumeroInicial;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTNumericUpDown nudNumeroFinal;
        private IWTDotNetLib.IWTButton btnCriar;
    }
}