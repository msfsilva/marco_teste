namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{
    partial class ServicoExternoRecebimentoAutomaticoForm
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
            this.btnFechar = new IWTDotNetLib.IWTButton(this.components);
            this.txtChaveNota = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFechar.LiberadoQuandoCadastroUtilizado = false;
            this.btnFechar.Location = new System.Drawing.Point(12, 80);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // txtChaveNota
            // 
            this.txtChaveNota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChaveNota.BindingField = null;
            this.txtChaveNota.DebugMode = false;
            this.txtChaveNota.LiberadoQuandoCadastroUtilizado = false;
            this.txtChaveNota.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtChaveNota.Location = new System.Drawing.Point(41, 30);
            this.txtChaveNota.ModoBarcode = true;
            this.txtChaveNota.ModoBusca = false;
            this.txtChaveNota.Name = "txtChaveNota";
            this.txtChaveNota.NaoLimparDepoisBarcode = false;
            this.txtChaveNota.ShortcutsEnabled = false;
            this.txtChaveNota.Size = new System.Drawing.Size(545, 20);
            this.txtChaveNota.TabIndex = 3;
            this.txtChaveNota.OperacaoBarcodeEncerrada += new IWTDotNetLib.IWTTextBox.OperacaoBarcodeEncerradaDelegate(this.txtChaveNota_OperacaoBarcodeEncerrada);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(15, 14);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(109, 13);
            this.iwtLabel1.TabIndex = 2;
            this.iwtLabel1.Text = "Chave da Nota Fiscal";
            // 
            // ServicoExternoRecebimentoAutomaticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 115);
            this.Controls.Add(this.txtChaveNota);
            this.Controls.Add(this.iwtLabel1);
            this.Controls.Add(this.btnFechar);
            this.Name = "ServicoExternoRecebimentoAutomaticoForm";
            this.Text = "Recebimento Automático de Serviço Externo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTButton btnFechar;
        private IWTDotNetLib.IWTTextBox txtChaveNota;
        private IWTDotNetLib.IWTLabel iwtLabel1;
    }
}