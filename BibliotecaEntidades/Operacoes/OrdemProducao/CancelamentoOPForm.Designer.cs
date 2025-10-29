using IWTDotNetLib;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    partial class CancelamentoOPForm
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
            this.lblNumeroOP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new IWTDotNetLib.IWTTextBox(this.components);
            this.btnAbortar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leia o código de barras para cancelar a Ordem de Produção Nº.";
            // 
            // lblNumeroOP
            // 
            this.lblNumeroOP.AutoSize = true;
            this.lblNumeroOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroOP.Location = new System.Drawing.Point(334, 18);
            this.lblNumeroOP.Name = "lblNumeroOP";
            this.lblNumeroOP.Size = new System.Drawing.Size(0, 13);
            this.lblNumeroOP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código de Barras";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.BindingField = null;
            this.txtCodigoBarras.DebugMode = false;
            this.txtCodigoBarras.LiberadoQuandoCadastroUtilizado = false;
            this.txtCodigoBarras.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtCodigoBarras.Location = new System.Drawing.Point(28, 68);
            this.txtCodigoBarras.ModoBarcode = true;
            this.txtCodigoBarras.ModoBusca = false;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.NaoLimparDepoisBarcode = false;
            this.txtCodigoBarras.Size = new System.Drawing.Size(339, 20);
            this.txtCodigoBarras.TabIndex = 3;
            this.txtCodigoBarras.OperacaoBarcodeEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBarcodeEncerradaDelegate(this.txtCodigoBarras_OperacaoBarcodeEncerrada);
            // 
            // btnAbortar
            // 
            this.btnAbortar.Location = new System.Drawing.Point(12, 112);
            this.btnAbortar.Name = "btnAbortar";
            this.btnAbortar.Size = new System.Drawing.Size(75, 23);
            this.btnAbortar.TabIndex = 4;
            this.btnAbortar.Text = "Abortar";
            this.btnAbortar.UseVisualStyleBackColor = true;
            this.btnAbortar.Click += new System.EventHandler(this.btnAbortar_Click);
            // 
            // CancelamentoOPForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(392, 154);
            this.Controls.Add(this.btnAbortar);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumeroOP);
            this.Controls.Add(this.label1);
            this.Name = "CancelamentoOPForm";
            this.Text = "Cancelamento de Ordem de Produção";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumeroOP;
        private System.Windows.Forms.Label label2;
        private IWTTextBox txtCodigoBarras;
        private System.Windows.Forms.Button btnAbortar;
    }
}