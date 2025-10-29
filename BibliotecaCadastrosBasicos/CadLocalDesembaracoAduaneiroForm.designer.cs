namespace BibliotecaCadastrosBasicos
{
    partial class CadLocalDesembaracoAduaneiroForm
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
            this.IdentificacaoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Identificacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.EstadoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Estado = new IWTDotNetLib.IWTEntitySelection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.IdentificacaoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Identificacao);
            this.splitContainer1.Panel1.Controls.Add(this.EstadoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Estado);
            this.splitContainer1.Size = new System.Drawing.Size(521, 189);
            this.splitContainer1.SplitterDistance = 123;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(434, 20);
            // 
            // IdentificacaoLabel
            // 
            this.IdentificacaoLabel.AutoSize = true;
            this.IdentificacaoLabel.BindingField = null;
            this.IdentificacaoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.IdentificacaoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.IdentificacaoLabel.Location = new System.Drawing.Point(20, 16);
            this.IdentificacaoLabel.Name = "IdentificacaoLabel";
            this.IdentificacaoLabel.Size = new System.Drawing.Size(68, 13);
            this.IdentificacaoLabel.TabIndex = 0;
            this.IdentificacaoLabel.Text = "Identificação";
            // 
            // Identificacao
            // 
            this.Identificacao.BindingField = "Identificacao";
            this.Identificacao.LiberadoQuandoCadastroUtilizado = false;
            this.Identificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Identificacao.Location = new System.Drawing.Point(94, 12);
            this.Identificacao.MaxLength = 255;
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.Size = new System.Drawing.Size(376, 20);
            this.Identificacao.TabIndex = 1;
            // 
            // EstadoLabel
            // 
            this.EstadoLabel.AutoSize = true;
            this.EstadoLabel.BindingField = null;
            this.EstadoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.EstadoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.EstadoLabel.Location = new System.Drawing.Point(48, 43);
            this.EstadoLabel.Name = "EstadoLabel";
            this.EstadoLabel.Size = new System.Drawing.Size(40, 13);
            this.EstadoLabel.TabIndex = 2;
            this.EstadoLabel.Text = "Estado";
            // 
            // Estado
            // 
            this.Estado.BindingField = "Estado";
            this.Estado.DesabilitarAutoCompletar = false;
            this.Estado.DesabilitarChekBox = true;
            this.Estado.DesabilitarLupa = false;
            this.Estado.DesabilitarSeta = false;
            this.Estado.EntidadeSelecionada = null;
            this.Estado.FormSelecao = null;
            this.Estado.LiberadoQuandoCadastroUtilizado = false;
            this.Estado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Estado.Location = new System.Drawing.Point(94, 38);
            this.Estado.ModoVisualizacaoGrid = null;
            this.Estado.Name = "Estado";
            this.Estado.ParametrosBuscaObrigatorios = null;
            this.Estado.Size = new System.Drawing.Size(415, 21);
            this.Estado.TabIndex = 3;
            // 
            // CadLocalDesembaracoAduaneiroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(521, 189);
            this.Name = "CadLocalDesembaracoAduaneiroForm";
            this.Text = "Local de Desembaraço Aduaneiro";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel IdentificacaoLabel;
        private IWTDotNetLib.IWTTextBox Identificacao;
        private IWTDotNetLib.IWTLabel EstadoLabel;
        private IWTDotNetLib.IWTEntitySelection Estado;
    }
} 
