namespace BibliotecaCadastrosBasicos
{
    partial class CadNcmBeneficioFiscalForm
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
            this.EstadoLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Estado = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.CodigoBeneficioFiscalLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.CodigoBeneficioFiscal = new IWTDotNetLib.IWTTextBox(this.components);
            this.CfopLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Cfop = new IWTDotNetLib.IWTNumericUpDown(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cfop)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.CfopLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Cfop);
            this.splitContainer1.Panel1.Controls.Add(this.EstadoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Estado);
            this.splitContainer1.Panel1.Controls.Add(this.CodigoBeneficioFiscalLabel);
            this.splitContainer1.Panel1.Controls.Add(this.CodigoBeneficioFiscal);
            this.splitContainer1.Size = new System.Drawing.Size(480, 168);
            this.splitContainer1.SplitterDistance = 102;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(393, 20);
            // 
            // EstadoLabel
            // 
            this.EstadoLabel.AutoSize = true;
            this.EstadoLabel.BindingField = null;
            this.EstadoLabel.LiberadoQuandoCadastroUtilizado = false;
            this.EstadoLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.EstadoLabel.Location = new System.Drawing.Point(89, 42);
            this.EstadoLabel.Name = "EstadoLabel";
            this.EstadoLabel.Size = new System.Drawing.Size(40, 13);
            this.EstadoLabel.TabIndex = 4;
            this.EstadoLabel.Text = "Estado";
            // 
            // Estado
            // 
            this.Estado.BindingField = "Estado";
            this.Estado.ColunasDropdown = null;
            this.Estado.DesabilitarAutoCompletar = false;
            this.Estado.DesabilitarChekBox = true;
            this.Estado.DesabilitarLupa = false;
            this.Estado.DesabilitarSeta = false;
            this.Estado.EntidadeSelecionada = null;
            this.Estado.FormSelecao = null;
            this.Estado.LiberadoQuandoCadastroUtilizado = false;
            this.Estado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Estado.Location = new System.Drawing.Point(134, 39);
            this.Estado.ModoVisualizacaoGrid = null;
            this.Estado.Name = "Estado";
            this.Estado.ParametroBuscaGuiada = null;
            this.Estado.ParametrosBuscaObrigatorios = null;
            this.Estado.Size = new System.Drawing.Size(334, 21);
            this.Estado.TabIndex = 1;
            // 
            // CodigoBeneficioFiscalLabel
            // 
            this.CodigoBeneficioFiscalLabel.AutoSize = true;
            this.CodigoBeneficioFiscalLabel.BindingField = null;
            this.CodigoBeneficioFiscalLabel.LiberadoQuandoCadastroUtilizado = false;
            this.CodigoBeneficioFiscalLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.CodigoBeneficioFiscalLabel.Location = new System.Drawing.Point(12, 69);
            this.CodigoBeneficioFiscalLabel.Name = "CodigoBeneficioFiscalLabel";
            this.CodigoBeneficioFiscalLabel.Size = new System.Drawing.Size(117, 13);
            this.CodigoBeneficioFiscalLabel.TabIndex = 6;
            this.CodigoBeneficioFiscalLabel.Text = "Código Beneficio Fiscal";
            // 
            // CodigoBeneficioFiscal
            // 
            this.CodigoBeneficioFiscal.BindingField = "CodigoBeneficioFiscal";
            this.CodigoBeneficioFiscal.DebugMode = false;
            this.CodigoBeneficioFiscal.LiberadoQuandoCadastroUtilizado = false;
            this.CodigoBeneficioFiscal.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.CodigoBeneficioFiscal.Location = new System.Drawing.Point(134, 66);
            this.CodigoBeneficioFiscal.MaxLength = 10;
            this.CodigoBeneficioFiscal.ModoBarcode = false;
            this.CodigoBeneficioFiscal.ModoBusca = false;
            this.CodigoBeneficioFiscal.Name = "CodigoBeneficioFiscal";
            this.CodigoBeneficioFiscal.NaoLimparDepoisBarcode = false;
            this.CodigoBeneficioFiscal.Size = new System.Drawing.Size(334, 20);
            this.CodigoBeneficioFiscal.TabIndex = 2;
            // 
            // CfopLabel
            // 
            this.CfopLabel.AutoSize = true;
            this.CfopLabel.BindingField = null;
            this.CfopLabel.LiberadoQuandoCadastroUtilizado = false;
            this.CfopLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.CfopLabel.Location = new System.Drawing.Point(100, 15);
            this.CfopLabel.Name = "CfopLabel";
            this.CfopLabel.Size = new System.Drawing.Size(29, 13);
            this.CfopLabel.TabIndex = 8;
            this.CfopLabel.Text = "Cfop";
            // 
            // Cfop
            // 
            this.Cfop.BindingField = "Cfop";
            this.Cfop.LiberadoQuandoCadastroUtilizado = false;
            this.Cfop.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Cfop.Location = new System.Drawing.Point(134, 13);
            this.Cfop.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Cfop.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.Cfop.Name = "Cfop";
            this.Cfop.Size = new System.Drawing.Size(150, 20);
            this.Cfop.TabIndex = 0;
            // 
            // CadNcmBeneficioFiscalForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 168);
            this.Name = "CadNcmBeneficioFiscalForm";
            this.Text = "Benefício Fiscal";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Cfop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private IWTDotNetLib.IWTLabel EstadoLabel;
        private IWTDotNetLib.IWTEntitySelection Estado;
        private IWTDotNetLib.IWTLabel CodigoBeneficioFiscalLabel;
        private IWTDotNetLib.IWTTextBox CodigoBeneficioFiscal;
        private IWTDotNetLib.IWTLabel CfopLabel;
        private IWTDotNetLib.IWTNumericUpDown Cfop;
    }
} 
