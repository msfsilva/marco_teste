namespace BibliotecaProdutos
{
    partial class DemandaMediaProdutoMaterialEpiReportForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.ensSelecaoItem = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.rdbEpi = new System.Windows.Forms.RadioButton();
            this.btnGerarRep = new System.Windows.Forms.Button();
            this.rdbMaterial = new System.Windows.Forms.RadioButton();
            this.rdbProduto = new System.Windows.Forms.RadioButton();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rdbProdutoK = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.ensSelecaoItem);
            this.splitContainer1.Panel1.Controls.Add(this.rdbEpi);
            this.splitContainer1.Panel1.Controls.Add(this.btnGerarRep);
            this.splitContainer1.Panel1.Controls.Add(this.rdbMaterial);
            this.splitContainer1.Panel1.Controls.Add(this.rdbProdutoK);
            this.splitContainer1.Panel1.Controls.Add(this.rdbProduto);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(869, 519);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecionar";
            // 
            // ensSelecaoItem
            // 
            this.ensSelecaoItem.BindingField = null;
            this.ensSelecaoItem.ColunasDropdown = null;
            this.ensSelecaoItem.DesabilitarAutoCompletar = false;
            this.ensSelecaoItem.DesabilitarChekBox = false;
            this.ensSelecaoItem.DesabilitarLupa = false;
            this.ensSelecaoItem.DesabilitarSeta = false;
            this.ensSelecaoItem.Enabled = false;
            this.ensSelecaoItem.EntidadeSelecionada = null;
            this.ensSelecaoItem.FormSelecao = null;
            this.ensSelecaoItem.LiberadoQuandoCadastroUtilizado = false;
            this.ensSelecaoItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensSelecaoItem.Location = new System.Drawing.Point(339, 30);
            this.ensSelecaoItem.ModoVisualizacaoGrid = null;
            this.ensSelecaoItem.Name = "ensSelecaoItem";
            this.ensSelecaoItem.ParametroBuscaGuiada = null;
            this.ensSelecaoItem.ParametrosBuscaObrigatorios = null;
            this.ensSelecaoItem.Size = new System.Drawing.Size(315, 23);
            this.ensSelecaoItem.TabIndex = 5;
            // 
            // rdbEpi
            // 
            this.rdbEpi.AutoSize = true;
            this.rdbEpi.Location = new System.Drawing.Point(193, 21);
            this.rdbEpi.Name = "rdbEpi";
            this.rdbEpi.Size = new System.Drawing.Size(47, 17);
            this.rdbEpi.TabIndex = 2;
            this.rdbEpi.Text = "EPIs";
            this.rdbEpi.UseVisualStyleBackColor = true;
            this.rdbEpi.CheckedChanged += new System.EventHandler(this.rdbEpi_CheckedChanged);
            // 
            // btnGerarRep
            // 
            this.btnGerarRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarRep.Location = new System.Drawing.Point(755, 26);
            this.btnGerarRep.Name = "btnGerarRep";
            this.btnGerarRep.Size = new System.Drawing.Size(80, 27);
            this.btnGerarRep.TabIndex = 6;
            this.btnGerarRep.Text = "Gerar";
            this.btnGerarRep.UseVisualStyleBackColor = true;
            this.btnGerarRep.Click += new System.EventHandler(this.btnGerarRep_Click);
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.Checked = true;
            this.rdbMaterial.Location = new System.Drawing.Point(27, 21);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(67, 17);
            this.rdbMaterial.TabIndex = 0;
            this.rdbMaterial.TabStop = true;
            this.rdbMaterial.Text = "Materiais";
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.CheckedChanged += new System.EventHandler(this.rdbMaterial_CheckedChanged);
            // 
            // rdbProduto
            // 
            this.rdbProduto.AutoSize = true;
            this.rdbProduto.Location = new System.Drawing.Point(109, 21);
            this.rdbProduto.Name = "rdbProduto";
            this.rdbProduto.Size = new System.Drawing.Size(67, 17);
            this.rdbProduto.TabIndex = 1;
            this.rdbProduto.Text = "Produtos";
            this.rdbProduto.UseVisualStyleBackColor = true;
            this.rdbProduto.CheckedChanged += new System.EventHandler(this.rdbProduto_CheckedChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(869, 439);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // rdbProdutoK
            // 
            this.rdbProdutoK.AutoSize = true;
            this.rdbProdutoK.Location = new System.Drawing.Point(27, 44);
            this.rdbProdutoK.Name = "rdbProdutoK";
            this.rdbProdutoK.Size = new System.Drawing.Size(177, 17);
            this.rdbProdutoK.TabIndex = 3;
            this.rdbProdutoK.Text = "Kanban de Itens Manufaturados";
            this.rdbProdutoK.UseVisualStyleBackColor = true;
            this.rdbProdutoK.CheckedChanged += new System.EventHandler(this.rdbProdutoK_CheckedChanged);
            // 
            // DemandaMediaProdutoMaterialEpiReportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(869, 519);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DemandaMediaProdutoMaterialEpiReportForm";
            this.Text = "Relatório de Demanda Média ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnGerarRep;
        private System.Windows.Forms.RadioButton rdbMaterial;
        private System.Windows.Forms.RadioButton rdbProduto;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.RadioButton rdbEpi;
        private System.Windows.Forms.Label label1;
        private IWTDotNetLib.IWTEntitySelection ensSelecaoItem;
        private System.Windows.Forms.RadioButton rdbProdutoK;
    }
}