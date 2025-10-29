namespace BibliotecaProdutos
{
    partial class CargaFabricaReportForm
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rdbCompleto = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEntrega = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbEntrada = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbClassificacao = new IWTDotNetLib.IWTRadioButton(this.components);
            this.ensClassificacao = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.grbDatas = new System.Windows.Forms.GroupBox();
            this.dtpAte = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.dtpDe = new IWTDotNetLib.IWTDateTimePicker(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnGerar = new IWTDotNetLib.IWTButton(this.components);
            this.grbDatas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDe)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(2, 154);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(907, 459);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // rdbCompleto
            // 
            this.rdbCompleto.AutoSize = true;
            this.rdbCompleto.BindingField = null;
            this.rdbCompleto.Checked = true;
            this.rdbCompleto.LiberadoQuandoCadastroUtilizado = false;
            this.rdbCompleto.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbCompleto.Location = new System.Drawing.Point(14, 16);
            this.rdbCompleto.Name = "rdbCompleto";
            this.rdbCompleto.Size = new System.Drawing.Size(69, 17);
            this.rdbCompleto.TabIndex = 1;
            this.rdbCompleto.TabStop = true;
            this.rdbCompleto.Text = "Completo";
            this.rdbCompleto.UseVisualStyleBackColor = true;
            this.rdbCompleto.CheckedChanged += new System.EventHandler(this.rdbCompleto_CheckedChanged);
            // 
            // rdbEntrega
            // 
            this.rdbEntrega.AutoSize = true;
            this.rdbEntrega.BindingField = null;
            this.rdbEntrega.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEntrega.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEntrega.Location = new System.Drawing.Point(14, 39);
            this.rdbEntrega.Name = "rdbEntrega";
            this.rdbEntrega.Size = new System.Drawing.Size(103, 17);
            this.rdbEntrega.TabIndex = 2;
            this.rdbEntrega.Text = "Data de Entrega";
            this.rdbEntrega.UseVisualStyleBackColor = true;
            this.rdbEntrega.CheckedChanged += new System.EventHandler(this.rdbEntrega_CheckedChanged);
            // 
            // rdbEntrada
            // 
            this.rdbEntrada.AutoSize = true;
            this.rdbEntrada.BindingField = null;
            this.rdbEntrada.LiberadoQuandoCadastroUtilizado = false;
            this.rdbEntrada.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbEntrada.Location = new System.Drawing.Point(14, 62);
            this.rdbEntrada.Name = "rdbEntrada";
            this.rdbEntrada.Size = new System.Drawing.Size(103, 17);
            this.rdbEntrada.TabIndex = 3;
            this.rdbEntrada.Text = "Data de Entrada";
            this.rdbEntrada.UseVisualStyleBackColor = true;
            this.rdbEntrada.CheckedChanged += new System.EventHandler(this.rdbEntrada_CheckedChanged);
            // 
            // rdbClassificacao
            // 
            this.rdbClassificacao.AutoSize = true;
            this.rdbClassificacao.BindingField = null;
            this.rdbClassificacao.LiberadoQuandoCadastroUtilizado = false;
            this.rdbClassificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbClassificacao.Location = new System.Drawing.Point(14, 85);
            this.rdbClassificacao.Name = "rdbClassificacao";
            this.rdbClassificacao.Size = new System.Drawing.Size(87, 17);
            this.rdbClassificacao.TabIndex = 4;
            this.rdbClassificacao.Text = "Classificação";
            this.rdbClassificacao.UseVisualStyleBackColor = true;
            this.rdbClassificacao.CheckedChanged += new System.EventHandler(this.rdbClassificacao_CheckedChanged);
            // 
            // ensClassificacao
            // 
            this.ensClassificacao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensClassificacao.BindingField = null;
            this.ensClassificacao.ColunasDropdown = null;
            this.ensClassificacao.DesabilitarAutoCompletar = false;
            this.ensClassificacao.DesabilitarChekBox = true;
            this.ensClassificacao.DesabilitarLupa = false;
            this.ensClassificacao.DesabilitarSeta = false;
            this.ensClassificacao.EntidadeSelecionada = null;
            this.ensClassificacao.FormSelecao = null;
            this.ensClassificacao.LiberadoQuandoCadastroUtilizado = false;
            this.ensClassificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensClassificacao.Location = new System.Drawing.Point(123, 85);
            this.ensClassificacao.ModoVisualizacaoGrid = null;
            this.ensClassificacao.Name = "ensClassificacao";
            this.ensClassificacao.ParametroBuscaGuiada = null;
            this.ensClassificacao.ParametrosBuscaObrigatorios = null;
            this.ensClassificacao.Size = new System.Drawing.Size(777, 23);
            this.ensClassificacao.TabIndex = 5;
            // 
            // grbDatas
            // 
            this.grbDatas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDatas.Controls.Add(this.dtpAte);
            this.grbDatas.Controls.Add(this.iwtLabel2);
            this.grbDatas.Controls.Add(this.dtpDe);
            this.grbDatas.Controls.Add(this.iwtLabel1);
            this.grbDatas.Location = new System.Drawing.Point(123, 39);
            this.grbDatas.Name = "grbDatas";
            this.grbDatas.Size = new System.Drawing.Size(777, 38);
            this.grbDatas.TabIndex = 6;
            this.grbDatas.TabStop = false;
            // 
            // dtpAte
            // 
            this.dtpAte.BindingField = null;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.LiberadoQuandoCadastroUtilizado = false;
            this.dtpAte.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpAte.Location = new System.Drawing.Point(264, 10);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(100, 20);
            this.dtpAte.TabIndex = 3;
            this.dtpAte.Value = new System.DateTime(2021, 11, 12, 17, 9, 27, 478);
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(237, 14);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(23, 13);
            this.iwtLabel2.TabIndex = 2;
            this.iwtLabel2.Text = "Até";
            // 
            // dtpDe
            // 
            this.dtpDe.BindingField = null;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.LiberadoQuandoCadastroUtilizado = false;
            this.dtpDe.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.dtpDe.Location = new System.Drawing.Point(71, 12);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(100, 20);
            this.dtpDe.TabIndex = 1;
            this.dtpDe.Value = new System.DateTime(2021, 11, 12, 17, 9, 27, 486);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(44, 16);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(21, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "De";
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.LiberadoQuandoCadastroUtilizado = false;
            this.btnGerar.Location = new System.Drawing.Point(825, 125);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 7;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // CargaFabricaReportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(912, 617);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.grbDatas);
            this.Controls.Add(this.ensClassificacao);
            this.Controls.Add(this.rdbClassificacao);
            this.Controls.Add(this.rdbEntrada);
            this.Controls.Add(this.rdbEntrega);
            this.Controls.Add(this.rdbCompleto);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "CargaFabricaReportForm";
            this.Text = "Carga de Fábrica";
            this.Shown += new System.EventHandler(this.CargaFabricaReportForm_Shown);
            this.grbDatas.ResumeLayout(false);
            this.grbDatas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private IWTDotNetLib.IWTRadioButton rdbCompleto;
        private IWTDotNetLib.IWTRadioButton rdbEntrega;
        private IWTDotNetLib.IWTRadioButton rdbEntrada;
        private IWTDotNetLib.IWTRadioButton rdbClassificacao;
        private IWTDotNetLib.IWTEntitySelection ensClassificacao;
        private System.Windows.Forms.GroupBox grbDatas;
        private IWTDotNetLib.IWTButton btnGerar;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDateTimePicker dtpDe;
        private IWTDotNetLib.IWTDateTimePicker dtpAte;
        private IWTDotNetLib.IWTLabel iwtLabel2;
    }
}