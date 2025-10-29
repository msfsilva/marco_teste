namespace BibliotecaCadastrosBasicos
{
    partial class CadAliquotaFundoCombatePobrezaForm
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
            this.AliquotaLabel = new IWTDotNetLib.IWTLabel(this.components);
            this.Aliquota = new IWTDotNetLib.IWTNumericUpDown(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Aliquota)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.EstadoLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Estado);
            this.splitContainer1.Panel1.Controls.Add(this.AliquotaLabel);
            this.splitContainer1.Panel1.Controls.Add(this.Aliquota);
            this.splitContainer1.Size = new System.Drawing.Size(480, 161);
            this.splitContainer1.SplitterDistance = 95;
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
            this.EstadoLabel.Location = new System.Drawing.Point(36, 14);
            this.EstadoLabel.Name = "EstadoLabel";
            this.EstadoLabel.Size = new System.Drawing.Size(40, 13);
            this.EstadoLabel.TabIndex = 0;
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
            this.Estado.Location = new System.Drawing.Point(91, 12);
            this.Estado.ModoVisualizacaoGrid = null;
            this.Estado.Name = "Estado";
            this.Estado.ParametroBuscaGuiada = null;
            this.Estado.ParametrosBuscaObrigatorios = null;
            this.Estado.Size = new System.Drawing.Size(377, 21);
            this.Estado.TabIndex = 1;
            // 
            // AliquotaLabel
            // 
            this.AliquotaLabel.AutoSize = true;
            this.AliquotaLabel.BindingField = null;
            this.AliquotaLabel.LiberadoQuandoCadastroUtilizado = false;
            this.AliquotaLabel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.AliquotaLabel.Location = new System.Drawing.Point(12, 41);
            this.AliquotaLabel.Name = "AliquotaLabel";
            this.AliquotaLabel.Size = new System.Drawing.Size(64, 13);
            this.AliquotaLabel.TabIndex = 2;
            this.AliquotaLabel.Text = "Alíquota (%)";
            // 
            // Aliquota
            // 
            this.Aliquota.BindingField = "Aliquota";
            this.Aliquota.DecimalPlaces = 4;
            this.Aliquota.LiberadoQuandoCadastroUtilizado = false;
            this.Aliquota.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.Aliquota.Location = new System.Drawing.Point(91, 39);
            this.Aliquota.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.Aliquota.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.Aliquota.Name = "Aliquota";
            this.Aliquota.Size = new System.Drawing.Size(150, 20);
            this.Aliquota.TabIndex = 3;
            // 
            // CadAliquotaFundoCombatePobrezaForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(480, 161);
            this.Name = "CadAliquotaFundoCombatePobrezaForm";
            this.Text = "Alíquota do Fundo de Combate a Pobrea";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Aliquota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel EstadoLabel;
        private IWTDotNetLib.IWTEntitySelection Estado;
        private IWTDotNetLib.IWTLabel AliquotaLabel;
        private IWTDotNetLib.IWTNumericUpDown Aliquota;
    }
} 
