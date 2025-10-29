namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class EmissaoNfeImportacaoForm
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
            this.btnGerar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.ensOperacao = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.ensTransporte = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.chk = new IWTDotNetLib.IWTCheckBox(this.components);
            this.txt = new IWTDotNetLib.IWTTextBox(this.components);
            this.ensTransporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerar.Location = new System.Drawing.Point(403, 105);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 0;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(12, 105);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ensOperacao
            // 
            this.ensOperacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensOperacao.BindingField = null;
            this.ensOperacao.DesabilitarAutoCompletar = false;
            this.ensOperacao.DesabilitarChekBox = true;
            this.ensOperacao.DesabilitarLupa = false;
            this.ensOperacao.DesabilitarSeta = false;
            this.ensOperacao.EntidadeSelecionada = null;
            this.ensOperacao.FormSelecao = null;
            this.ensOperacao.LiberadoQuandoCadastroUtilizado = false;
            this.ensOperacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensOperacao.Location = new System.Drawing.Point(92, 16);
            this.ensOperacao.ModoVisualizacaoGrid = null;
            this.ensOperacao.Name = "ensOperacao";
            this.ensOperacao.ParametrosBuscaObrigatorios = null;
            this.ensOperacao.Size = new System.Drawing.Size(358, 23);
            this.ensOperacao.TabIndex = 2;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(32, 22);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(54, 13);
            this.iwtLabel1.TabIndex = 3;
            this.iwtLabel1.Text = "Operação";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(28, 51);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(58, 13);
            this.iwtLabel2.TabIndex = 5;
            this.iwtLabel2.Text = "Transporte";
            // 
            // ensTransporte
            // 
            this.ensTransporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensTransporte.BindingField = null;
            this.ensTransporte.Controls.Add(this.chk);
            this.ensTransporte.Controls.Add(this.txt);
            this.ensTransporte.DesabilitarAutoCompletar = false;
            this.ensTransporte.DesabilitarChekBox = true;
            this.ensTransporte.DesabilitarLupa = false;
            this.ensTransporte.DesabilitarSeta = false;
            this.ensTransporte.EntidadeSelecionada = null;
            this.ensTransporte.FormSelecao = null;
            this.ensTransporte.LiberadoQuandoCadastroUtilizado = false;
            this.ensTransporte.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensTransporte.Location = new System.Drawing.Point(92, 45);
            this.ensTransporte.ModoVisualizacaoGrid = null;
            this.ensTransporte.Name = "ensTransporte";
            this.ensTransporte.ParametrosBuscaObrigatorios = null;
            this.ensTransporte.Size = new System.Drawing.Size(358, 23);
            this.ensTransporte.TabIndex = 4;
            // 
            // chk
            // 
            this.chk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk.AutoSize = true;
            this.chk.BindingField = "";
            this.chk.Checked = true;
            this.chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk.LiberadoQuandoCadastroUtilizado = false;
            this.chk.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chk.Location = new System.Drawing.Point(598, 5);
            this.chk.Name = "chk";
            this.chk.Size = new System.Drawing.Size(15, 14);
            this.chk.TabIndex = 1;
            this.chk.UseVisualStyleBackColor = true;
            this.chk.Visible = false;
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.BindingField = "";
            this.txt.LiberadoQuandoCadastroUtilizado = false;
            this.txt.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txt.Location = new System.Drawing.Point(0, 1);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(573, 20);
            this.txt.TabIndex = 3;
            // 
            // EmissaoNfeImportacaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(490, 140);
            this.Controls.Add(this.iwtLabel2);
            this.Controls.Add(this.ensTransporte);
            this.Controls.Add(this.iwtLabel1);
            this.Controls.Add(this.ensOperacao);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGerar);
            this.Name = "EmissaoNfeImportacaoForm";
            this.Text = "Emissão da Nota Fiscal de Importação";
            this.ensTransporte.ResumeLayout(false);
            this.ensTransporte.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTButton btnGerar;
        private IWTDotNetLib.IWTButton btnCancelar;
        private IWTDotNetLib.IWTEntitySelection ensOperacao;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTEntitySelection ensTransporte;
        private IWTDotNetLib.IWTCheckBox chk;
        private IWTDotNetLib.IWTTextBox txt;
    }
}