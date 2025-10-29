namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class CancelamentoOpEncerradaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelamentoOpEncerradaForm));
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtOps = new IWTDotNetLib.IWTTextBox(this.components);
            this.btnOk = new IWTDotNetLib.IWTButton(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 9);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(660, 61);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = resources.GetString("iwtLabel1.Text");
            this.iwtLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOps
            // 
            this.txtOps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOps.BindingField = null;
            this.txtOps.DebugMode = false;
            this.txtOps.LiberadoQuandoCadastroUtilizado = false;
            this.txtOps.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtOps.Location = new System.Drawing.Point(12, 116);
            this.txtOps.ModoBarcode = false;
            this.txtOps.ModoBusca = false;
            this.txtOps.Multiline = true;
            this.txtOps.Name = "txtOps";
            this.txtOps.NaoLimparDepoisBarcode = false;
            this.txtOps.Size = new System.Drawing.Size(660, 116);
            this.txtOps.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.LiberadoQuandoCadastroUtilizado = false;
            this.btnOk.Location = new System.Drawing.Point(559, 238);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(113, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Efetivar Alteração";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(12, 100);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(411, 13);
            this.iwtLabel2.TabIndex = 3;
            this.iwtLabel2.Text = "Preencha com os números das Ordens de Produção separados por ponto e vírgula (;)";
            // 
            // CancelamentoOpEncerradaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 273);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtOps);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "CancelamentoOpEncerradaForm";
            this.Text = "Cancelamento de Ordem de Produçao Encerrada";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox txtOps;
        private IWTDotNetLib.IWTButton btnOk;
        private IWTDotNetLib.IWTLabel iwtLabel2;
    }
}