namespace BibliotecaCadastrosBasicos.Estoque
{
    partial class InventarioReportForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbOrdenacaoCodigo = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbOrdenacaoDataMovimentacao = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSepararMateriais = new IWTDotNetLib.IWTCheckBox(this.components);
            this.rdbLista = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbArvore = new IWTDotNetLib.IWTRadioButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIncluirColunaLocalizacao = new IWTDotNetLib.IWTCheckBox(this.components);
            this.chkIncluirPrecos = new IWTDotNetLib.IWTCheckBox(this.components);
            this.rdb90Dias = new System.Windows.Forms.RadioButton();
            this.rdbTodos = new System.Windows.Forms.RadioButton();
            this.grbDataUltimaUtilizacao = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDataFinal = new System.Windows.Forms.CheckBox();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.chkDataInicial = new System.Windows.Forms.CheckBox();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.rdbDataUltimaUtilizacao = new System.Windows.Forms.RadioButton();
            this.btnGerar = new System.Windows.Forms.Button();
            this.chkIncluirColunaUltimaUtilizacao = new IWTDotNetLib.IWTCheckBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbDataUltimaUtilizacao.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(790, 430);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
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
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnGerar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(790, 604);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rdbOrdenacaoCodigo);
            this.groupBox3.Controls.Add(this.rdbOrdenacaoDataMovimentacao);
            this.groupBox3.Location = new System.Drawing.Point(513, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 64);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ordenação";
            // 
            // rdbOrdenacaoCodigo
            // 
            this.rdbOrdenacaoCodigo.AutoSize = true;
            this.rdbOrdenacaoCodigo.BindingField = null;
            this.rdbOrdenacaoCodigo.LiberadoQuandoCadastroUtilizado = false;
            this.rdbOrdenacaoCodigo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbOrdenacaoCodigo.Location = new System.Drawing.Point(6, 39);
            this.rdbOrdenacaoCodigo.Name = "rdbOrdenacaoCodigo";
            this.rdbOrdenacaoCodigo.Size = new System.Drawing.Size(58, 17);
            this.rdbOrdenacaoCodigo.TabIndex = 1;
            this.rdbOrdenacaoCodigo.Text = "Código";
            this.rdbOrdenacaoCodigo.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenacaoDataMovimentacao
            // 
            this.rdbOrdenacaoDataMovimentacao.AutoSize = true;
            this.rdbOrdenacaoDataMovimentacao.BindingField = null;
            this.rdbOrdenacaoDataMovimentacao.Checked = true;
            this.rdbOrdenacaoDataMovimentacao.LiberadoQuandoCadastroUtilizado = false;
            this.rdbOrdenacaoDataMovimentacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbOrdenacaoDataMovimentacao.Location = new System.Drawing.Point(6, 19);
            this.rdbOrdenacaoDataMovimentacao.Name = "rdbOrdenacaoDataMovimentacao";
            this.rdbOrdenacaoDataMovimentacao.Size = new System.Drawing.Size(136, 17);
            this.rdbOrdenacaoDataMovimentacao.TabIndex = 0;
            this.rdbOrdenacaoDataMovimentacao.TabStop = true;
            this.rdbOrdenacaoDataMovimentacao.Text = "Data de Movimentação";
            this.rdbOrdenacaoDataMovimentacao.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkSepararMateriais);
            this.groupBox2.Controls.Add(this.rdbLista);
            this.groupBox2.Controls.Add(this.rdbArvore);
            this.groupBox2.Location = new System.Drawing.Point(12, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(495, 64);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Formato do Relatório";
            // 
            // chkSepararMateriais
            // 
            this.chkSepararMateriais.AutoSize = true;
            this.chkSepararMateriais.BindingField = null;
            this.chkSepararMateriais.Enabled = false;
            this.chkSepararMateriais.LiberadoQuandoCadastroUtilizado = false;
            this.chkSepararMateriais.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkSepararMateriais.Location = new System.Drawing.Point(6, 41);
            this.chkSepararMateriais.Name = "chkSepararMateriais";
            this.chkSepararMateriais.Size = new System.Drawing.Size(297, 17);
            this.chkSepararMateriais.TabIndex = 8;
            this.chkSepararMateriais.Text = "Separar Produtos/Materiais/Documentos/Recursos/EPIs";
            this.chkSepararMateriais.UseVisualStyleBackColor = true;
            // 
            // rdbLista
            // 
            this.rdbLista.AutoSize = true;
            this.rdbLista.BindingField = null;
            this.rdbLista.LiberadoQuandoCadastroUtilizado = false;
            this.rdbLista.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbLista.Location = new System.Drawing.Point(68, 19);
            this.rdbLista.Name = "rdbLista";
            this.rdbLista.Size = new System.Drawing.Size(47, 17);
            this.rdbLista.TabIndex = 1;
            this.rdbLista.Text = "Lista";
            this.rdbLista.UseVisualStyleBackColor = true;
            this.rdbLista.CheckedChanged += new System.EventHandler(this.rdbLista_CheckedChanged);
            // 
            // rdbArvore
            // 
            this.rdbArvore.AutoSize = true;
            this.rdbArvore.BindingField = null;
            this.rdbArvore.Checked = true;
            this.rdbArvore.LiberadoQuandoCadastroUtilizado = false;
            this.rdbArvore.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbArvore.Location = new System.Drawing.Point(6, 19);
            this.rdbArvore.Name = "rdbArvore";
            this.rdbArvore.Size = new System.Drawing.Size(56, 17);
            this.rdbArvore.TabIndex = 0;
            this.rdbArvore.TabStop = true;
            this.rdbArvore.Text = "Árvore";
            this.rdbArvore.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkIncluirColunaUltimaUtilizacao);
            this.groupBox1.Controls.Add(this.chkIncluirColunaLocalizacao);
            this.groupBox1.Controls.Add(this.chkIncluirPrecos);
            this.groupBox1.Controls.Add(this.rdb90Dias);
            this.groupBox1.Controls.Add(this.rdbTodos);
            this.groupBox1.Controls.Add(this.grbDataUltimaUtilizacao);
            this.groupBox1.Controls.Add(this.rdbDataUltimaUtilizacao);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 85);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Relatório";
            // 
            // chkIncluirColunaLocalizacao
            // 
            this.chkIncluirColunaLocalizacao.AutoSize = true;
            this.chkIncluirColunaLocalizacao.BindingField = null;
            this.chkIncluirColunaLocalizacao.Enabled = false;
            this.chkIncluirColunaLocalizacao.LiberadoQuandoCadastroUtilizado = false;
            this.chkIncluirColunaLocalizacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkIncluirColunaLocalizacao.Location = new System.Drawing.Point(99, 62);
            this.chkIncluirColunaLocalizacao.Name = "chkIncluirColunaLocalizacao";
            this.chkIncluirColunaLocalizacao.Size = new System.Drawing.Size(162, 17);
            this.chkIncluirColunaLocalizacao.TabIndex = 8;
            this.chkIncluirColunaLocalizacao.Text = "Exibir Coluna de Localização";
            this.chkIncluirColunaLocalizacao.UseVisualStyleBackColor = true;
            // 
            // chkIncluirPrecos
            // 
            this.chkIncluirPrecos.AutoSize = true;
            this.chkIncluirPrecos.BindingField = null;
            this.chkIncluirPrecos.LiberadoQuandoCadastroUtilizado = false;
            this.chkIncluirPrecos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkIncluirPrecos.Location = new System.Drawing.Point(6, 62);
            this.chkIncluirPrecos.Name = "chkIncluirPrecos";
            this.chkIncluirPrecos.Size = new System.Drawing.Size(87, 17);
            this.chkIncluirPrecos.TabIndex = 7;
            this.chkIncluirPrecos.Text = "Exibir Preços";
            this.chkIncluirPrecos.UseVisualStyleBackColor = true;
            // 
            // rdb90Dias
            // 
            this.rdb90Dias.AutoSize = true;
            this.rdb90Dias.Checked = true;
            this.rdb90Dias.Location = new System.Drawing.Point(6, 34);
            this.rdb90Dias.Name = "rdb90Dias";
            this.rdb90Dias.Size = new System.Drawing.Size(276, 17);
            this.rdb90Dias.TabIndex = 0;
            this.rdb90Dias.TabStop = true;
            this.rdb90Dias.Text = "Somente Itens em Estoque com Atividade em 90 dias";
            this.rdb90Dias.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.Location = new System.Drawing.Point(294, 34);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(95, 17);
            this.rdbTodos.TabIndex = 1;
            this.rdbTodos.Text = "Todos os Itens";
            this.rdbTodos.UseVisualStyleBackColor = true;
            // 
            // grbDataUltimaUtilizacao
            // 
            this.grbDataUltimaUtilizacao.Controls.Add(this.label2);
            this.grbDataUltimaUtilizacao.Controls.Add(this.label1);
            this.grbDataUltimaUtilizacao.Controls.Add(this.chkDataFinal);
            this.grbDataUltimaUtilizacao.Controls.Add(this.dtpDataFinal);
            this.grbDataUltimaUtilizacao.Controls.Add(this.chkDataInicial);
            this.grbDataUltimaUtilizacao.Controls.Add(this.dtpDataInicial);
            this.grbDataUltimaUtilizacao.Enabled = false;
            this.grbDataUltimaUtilizacao.Location = new System.Drawing.Point(395, 15);
            this.grbDataUltimaUtilizacao.Name = "grbDataUltimaUtilizacao";
            this.grbDataUltimaUtilizacao.Size = new System.Drawing.Size(339, 44);
            this.grbDataUltimaUtilizacao.TabIndex = 2;
            this.grbDataUltimaUtilizacao.TabStop = false;
            this.grbDataUltimaUtilizacao.Text = "Data da Última Utilização";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "De";
            // 
            // chkDataFinal
            // 
            this.chkDataFinal.AutoSize = true;
            this.chkDataFinal.Checked = true;
            this.chkDataFinal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataFinal.Location = new System.Drawing.Point(313, 21);
            this.chkDataFinal.Name = "chkDataFinal";
            this.chkDataFinal.Size = new System.Drawing.Size(15, 14);
            this.chkDataFinal.TabIndex = 3;
            this.chkDataFinal.UseVisualStyleBackColor = true;
            this.chkDataFinal.CheckedChanged += new System.EventHandler(this.chkDataFinal_CheckedChanged);
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(198, 17);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(109, 20);
            this.dtpDataFinal.TabIndex = 2;
            // 
            // chkDataInicial
            // 
            this.chkDataInicial.AutoSize = true;
            this.chkDataInicial.Checked = true;
            this.chkDataInicial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataInicial.Location = new System.Drawing.Point(148, 21);
            this.chkDataInicial.Name = "chkDataInicial";
            this.chkDataInicial.Size = new System.Drawing.Size(15, 14);
            this.chkDataInicial.TabIndex = 1;
            this.chkDataInicial.UseVisualStyleBackColor = true;
            this.chkDataInicial.CheckedChanged += new System.EventHandler(this.chkDataInicial_CheckedChanged);
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(33, 19);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(109, 20);
            this.dtpDataInicial.TabIndex = 0;
            // 
            // rdbDataUltimaUtilizacao
            // 
            this.rdbDataUltimaUtilizacao.AutoSize = true;
            this.rdbDataUltimaUtilizacao.Location = new System.Drawing.Point(740, 32);
            this.rdbDataUltimaUtilizacao.Name = "rdbDataUltimaUtilizacao";
            this.rdbDataUltimaUtilizacao.Size = new System.Drawing.Size(14, 13);
            this.rdbDataUltimaUtilizacao.TabIndex = 3;
            this.rdbDataUltimaUtilizacao.UseVisualStyleBackColor = true;
            this.rdbDataUltimaUtilizacao.CheckedChanged += new System.EventHandler(this.rdbDataUltimaUtilizacao_CheckedChanged);
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.Location = new System.Drawing.Point(703, 138);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 4;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // chkIncluirColunaUltimaUtilizacao
            // 
            this.chkIncluirColunaUltimaUtilizacao.AutoSize = true;
            this.chkIncluirColunaUltimaUtilizacao.BindingField = null;
            this.chkIncluirColunaUltimaUtilizacao.Checked = true;
            this.chkIncluirColunaUltimaUtilizacao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncluirColunaUltimaUtilizacao.LiberadoQuandoCadastroUtilizado = false;
            this.chkIncluirColunaUltimaUtilizacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.chkIncluirColunaUltimaUtilizacao.Location = new System.Drawing.Point(267, 62);
            this.chkIncluirColunaUltimaUtilizacao.Name = "chkIncluirColunaUltimaUtilizacao";
            this.chkIncluirColunaUltimaUtilizacao.Size = new System.Drawing.Size(183, 17);
            this.chkIncluirColunaUltimaUtilizacao.TabIndex = 9;
            this.chkIncluirColunaUltimaUtilizacao.Text = "Exibir Coluna de Última Utilização";
            this.chkIncluirColunaUltimaUtilizacao.UseVisualStyleBackColor = true;
            // 
            // InventarioReportForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(790, 604);
            this.Controls.Add(this.splitContainer1);
            this.Name = "InventarioReportForm";
            this.Text = "Inventário";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDataUltimaUtilizacao.ResumeLayout(false);
            this.grbDataUltimaUtilizacao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rdbTodos;
        private System.Windows.Forms.RadioButton rdb90Dias;
        private System.Windows.Forms.RadioButton rdbDataUltimaUtilizacao;
        private System.Windows.Forms.GroupBox grbDataUltimaUtilizacao;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.CheckBox chkDataInicial;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTCheckBox chkIncluirPrecos;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTRadioButton rdbLista;
        private IWTDotNetLib.IWTRadioButton rdbArvore;
        private IWTDotNetLib.IWTCheckBox chkIncluirColunaLocalizacao;
        private IWTDotNetLib.IWTCheckBox chkSepararMateriais;
        private System.Windows.Forms.GroupBox groupBox3;
        private IWTDotNetLib.IWTRadioButton rdbOrdenacaoCodigo;
        private IWTDotNetLib.IWTRadioButton rdbOrdenacaoDataMovimentacao;
        private IWTDotNetLib.IWTCheckBox chkIncluirColunaUltimaUtilizacao;

    }
}