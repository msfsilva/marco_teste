namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class CadEmbarqueTransportadoraForm
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
            this.ensTransportadora = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnSalvar = new IWTDotNetLib.IWTButton(this.components);
            this.SuspendLayout();
            // 
            // ensTransportadora
            // 
            this.ensTransportadora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensTransportadora.BindingField = null;
            this.ensTransportadora.ColunasDropdown = null;
            this.ensTransportadora.DesabilitarAutoCompletar = false;
            this.ensTransportadora.DesabilitarChekBox = false;
            this.ensTransportadora.DesabilitarLupa = false;
            this.ensTransportadora.DesabilitarSeta = false;
            this.ensTransportadora.EntidadeSelecionada = null;
            this.ensTransportadora.FormSelecao = null;
            this.ensTransportadora.LiberadoQuandoCadastroUtilizado = false;
            this.ensTransportadora.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensTransportadora.Location = new System.Drawing.Point(97, 25);
            this.ensTransportadora.ModoVisualizacaoGrid = null;
            this.ensTransportadora.Name = "ensTransportadora";
            this.ensTransportadora.ParametroBuscaGuiada = null;
            this.ensTransportadora.ParametrosBuscaObrigatorios = null;
            this.ensTransportadora.Size = new System.Drawing.Size(490, 23);
            this.ensTransportadora.TabIndex = 0;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 30);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(79, 13);
            this.iwtLabel1.TabIndex = 1;
            this.iwtLabel1.Text = "Transportadora";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.LiberadoQuandoCadastroUtilizado = false;
            this.btnSalvar.Location = new System.Drawing.Point(512, 71);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // CadEmbarqueTransportadoraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 106);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.iwtLabel1);
            this.Controls.Add(this.ensTransportadora);
            this.Name = "CadEmbarqueTransportadoraForm";
            this.Text = "Transportadora do Embarque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTEntitySelection ensTransportadora;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTButton btnSalvar;
    }
}