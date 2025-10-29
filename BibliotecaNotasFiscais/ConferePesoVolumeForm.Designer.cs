namespace BibliotecaNotasFiscais
{
    partial class ConferePesoVolumeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConferePesoVolumeForm));
            this.btnContinuar = new IWTDotNetLib.IWTButton(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudPesoBruto = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.nudPesoLiquido = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudVolumes = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoBruto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoLiquido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolumes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContinuar.LiberadoQuandoCadastroUtilizado = false;
            this.btnContinuar.Location = new System.Drawing.Point(440, 141);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(75, 23);
            this.btnContinuar.TabIndex = 0;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 71);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(59, 13);
            this.iwtLabel1.TabIndex = 1;
            this.iwtLabel1.Text = "Peso Bruto";
            // 
            // nudPesoBruto
            // 
            this.nudPesoBruto.BindingField = null;
            this.nudPesoBruto.DecimalPlaces = 3;
            this.nudPesoBruto.LiberadoQuandoCadastroUtilizado = false;
            this.nudPesoBruto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPesoBruto.Location = new System.Drawing.Point(81, 69);
            this.nudPesoBruto.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudPesoBruto.Name = "nudPesoBruto";
            this.nudPesoBruto.Size = new System.Drawing.Size(120, 20);
            this.nudPesoBruto.TabIndex = 2;
            // 
            // nudPesoLiquido
            // 
            this.nudPesoLiquido.BindingField = null;
            this.nudPesoLiquido.DecimalPlaces = 3;
            this.nudPesoLiquido.LiberadoQuandoCadastroUtilizado = false;
            this.nudPesoLiquido.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudPesoLiquido.Location = new System.Drawing.Point(81, 95);
            this.nudPesoLiquido.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudPesoLiquido.Name = "nudPesoLiquido";
            this.nudPesoLiquido.Size = new System.Drawing.Size(120, 20);
            this.nudPesoLiquido.TabIndex = 4;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(5, 97);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(70, 13);
            this.iwtLabel2.TabIndex = 3;
            this.iwtLabel2.Text = "Peso Líquido";
            // 
            // nudVolumes
            // 
            this.nudVolumes.BindingField = null;
            this.nudVolumes.LiberadoQuandoCadastroUtilizado = false;
            this.nudVolumes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudVolumes.Location = new System.Drawing.Point(81, 121);
            this.nudVolumes.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nudVolumes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVolumes.Name = "nudVolumes";
            this.nudVolumes.Size = new System.Drawing.Size(120, 20);
            this.nudVolumes.TabIndex = 6;
            this.nudVolumes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(28, 123);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(47, 13);
            this.iwtLabel3.TabIndex = 5;
            this.iwtLabel3.Text = "Volumes";
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(9, 9);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(506, 57);
            this.iwtLabel4.TabIndex = 7;
            this.iwtLabel4.Text = resources.GetString("iwtLabel4.Text");
            this.iwtLabel4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ConferePesoVolumeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 176);
            this.Controls.Add(this.iwtLabel4);
            this.Controls.Add(this.nudVolumes);
            this.Controls.Add(this.iwtLabel3);
            this.Controls.Add(this.nudPesoLiquido);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.nudPesoBruto);
            this.Controls.Add(this.iwtLabel1);
            this.Controls.Add(this.btnContinuar);
            this.Name = "ConferePesoVolumeForm";
            this.Text = "Conferência de Peso e Volumes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConferePesoVolumeForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoBruto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPesoLiquido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolumes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTButton btnContinuar;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTNumericUpDown nudPesoBruto;
        private IWTDotNetLib.IWTNumericUpDown nudPesoLiquido;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTNumericUpDown nudVolumes;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTLabel iwtLabel4;
    }
}