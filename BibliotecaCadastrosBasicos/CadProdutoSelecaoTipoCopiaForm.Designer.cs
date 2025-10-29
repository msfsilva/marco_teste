namespace BibliotecaCadastrosBasicos
{
    partial class CadProdutoSelecaoTipoCopiaForm
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
            this.chkEstrutura = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkFiscal = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkPrecos = new IWTDotNetLib.IWTCheckBox(this.components);
            this.iwtButton1 = new IWTDotNetLib.IWTButton(this.components);
            this.SuspendLayout();
            // 
            // chkEstrutura
            // 
            this.chkEstrutura.AutoSize = true;
            this.chkEstrutura.BindingField = null;
            this.chkEstrutura.Checked = true;
            this.chkEstrutura.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEstrutura.LiberadoQuandoCadastroUtilizado = false;
            this.chkEstrutura.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkEstrutura.Location = new System.Drawing.Point(39, 27);
            this.chkEstrutura.Name = "chkEstrutura";
            this.chkEstrutura.Size = new System.Drawing.Size(123, 17);
            this.chkEstrutura.TabIndex = 0;
            this.chkEstrutura.Text = "Estrutura do Produto";
            this.chkEstrutura.UseVisualStyleBackColor = true;
            // 
            // chkFiscal
            // 
            this.chkFiscal.AutoSize = true;
            this.chkFiscal.BindingField = null;
            this.chkFiscal.Checked = true;
            this.chkFiscal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFiscal.LiberadoQuandoCadastroUtilizado = false;
            this.chkFiscal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkFiscal.Location = new System.Drawing.Point(39, 50);
            this.chkFiscal.Name = "chkFiscal";
            this.chkFiscal.Size = new System.Drawing.Size(98, 17);
            this.chkFiscal.TabIndex = 1;
            this.chkFiscal.Text = "Cadastro Fiscal";
            this.chkFiscal.UseVisualStyleBackColor = true;
            // 
            // chkPrecos
            // 
            this.chkPrecos.AutoSize = true;
            this.chkPrecos.BindingField = null;
            this.chkPrecos.Checked = true;
            this.chkPrecos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrecos.LiberadoQuandoCadastroUtilizado = false;
            this.chkPrecos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkPrecos.Location = new System.Drawing.Point(39, 73);
            this.chkPrecos.Name = "chkPrecos";
            this.chkPrecos.Size = new System.Drawing.Size(119, 17);
            this.chkPrecos.TabIndex = 2;
            this.chkPrecos.Text = "Cadastro de Preços";
            this.chkPrecos.UseVisualStyleBackColor = true;
            // 
            // iwtButton1
            // 
            this.iwtButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtButton1.Location = new System.Drawing.Point(197, 121);
            this.iwtButton1.Name = "iwtButton1";
            this.iwtButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtButton1.TabIndex = 3;
            this.iwtButton1.Text = "Confirmar";
            this.iwtButton1.UseVisualStyleBackColor = true;
            this.iwtButton1.Click += new System.EventHandler(this.iwtButton1_Click);
            // 
            // CadProdutoSelecaoTipoCopiaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Controls.Add(this.iwtButton1);
            this.Controls.Add(this.chkPrecos);
            this.Controls.Add(this.chkFiscal);
            this.Controls.Add(this.chkEstrutura);
            this.Name = "CadProdutoSelecaoTipoCopiaForm";
            this.Text = "Seleção do Tipo de Cópia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadProdutoSelecaoTipoCopiaForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTCheckBox chkEstrutura;
        private IWTDotNetLib.IWTCheckBox chkFiscal;
        private IWTDotNetLib.IWTCheckBox chkPrecos;
        private IWTDotNetLib.IWTButton iwtButton1;
    }
}