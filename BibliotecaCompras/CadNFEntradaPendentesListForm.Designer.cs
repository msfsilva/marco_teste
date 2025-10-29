namespace BibliotecaCompras
{
    partial class CadNFEntradaPendentesListForm
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
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkAtivaBuscaDataImp = new System.Windows.Forms.CheckBox();
            this.grpDataImportacao = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDataImpFim = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDataImpInicio = new System.Windows.Forms.DateTimePicker();
            this.chkAtivaBuscaDataNF = new System.Windows.Forms.CheckBox();
            this.grpBuscaDataNF = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDataNFFim = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDataNFInicio = new System.Windows.Forms.DateTimePicker();
            this.btnReceber = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timerBusca = new System.Windows.Forms.Timer(this.components);
            this.btnExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpDataImportacao.SuspendLayout();
            this.grpBuscaDataNF.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(57, 6);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(185, 20);
            this.txtBusca.TabIndex = 4;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer1.Panel2.Controls.Add(this.chkAtivaBuscaDataImp);
            this.splitContainer1.Panel2.Controls.Add(this.grpDataImportacao);
            this.splitContainer1.Panel2.Controls.Add(this.chkAtivaBuscaDataNF);
            this.splitContainer1.Panel2.Controls.Add(this.grpBuscaDataNF);
            this.splitContainer1.Panel2.Controls.Add(this.btnReceber);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(828, 405);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(828, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // chkAtivaBuscaDataImp
            // 
            this.chkAtivaBuscaDataImp.AutoSize = true;
            this.chkAtivaBuscaDataImp.Location = new System.Drawing.Point(518, 46);
            this.chkAtivaBuscaDataImp.Name = "chkAtivaBuscaDataImp";
            this.chkAtivaBuscaDataImp.Size = new System.Drawing.Size(15, 14);
            this.chkAtivaBuscaDataImp.TabIndex = 15;
            this.chkAtivaBuscaDataImp.UseVisualStyleBackColor = true;
            this.chkAtivaBuscaDataImp.CheckedChanged += new System.EventHandler(this.chkAtivaBuscaDataImp_CheckedChanged);
            // 
            // grpDataImportacao
            // 
            this.grpDataImportacao.Controls.Add(this.label4);
            this.grpDataImportacao.Controls.Add(this.dtpDataImpFim);
            this.grpDataImportacao.Controls.Add(this.label5);
            this.grpDataImportacao.Controls.Add(this.dtpDataImpInicio);
            this.grpDataImportacao.Enabled = false;
            this.grpDataImportacao.Location = new System.Drawing.Point(289, 39);
            this.grpDataImportacao.Name = "grpDataImportacao";
            this.grpDataImportacao.Size = new System.Drawing.Size(223, 79);
            this.grpDataImportacao.TabIndex = 14;
            this.grpDataImportacao.TabStop = false;
            this.grpDataImportacao.Text = "Data Importação";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Data Fim";
            // 
            // dtpDataImpFim
            // 
            this.dtpDataImpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataImpFim.Location = new System.Drawing.Point(100, 45);
            this.dtpDataImpFim.Name = "dtpDataImpFim";
            this.dtpDataImpFim.Size = new System.Drawing.Size(106, 20);
            this.dtpDataImpFim.TabIndex = 2;
            this.dtpDataImpFim.ValueChanged += new System.EventHandler(this.dtpDataImpFim_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data Início";
            // 
            // dtpDataImpInicio
            // 
            this.dtpDataImpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataImpInicio.Location = new System.Drawing.Point(100, 19);
            this.dtpDataImpInicio.Name = "dtpDataImpInicio";
            this.dtpDataImpInicio.Size = new System.Drawing.Size(106, 20);
            this.dtpDataImpInicio.TabIndex = 0;
            this.dtpDataImpInicio.ValueChanged += new System.EventHandler(this.dtpDataImpInicio_ValueChanged);
            // 
            // chkAtivaBuscaDataNF
            // 
            this.chkAtivaBuscaDataNF.AutoSize = true;
            this.chkAtivaBuscaDataNF.Location = new System.Drawing.Point(248, 46);
            this.chkAtivaBuscaDataNF.Name = "chkAtivaBuscaDataNF";
            this.chkAtivaBuscaDataNF.Size = new System.Drawing.Size(15, 14);
            this.chkAtivaBuscaDataNF.TabIndex = 13;
            this.chkAtivaBuscaDataNF.UseVisualStyleBackColor = true;
            this.chkAtivaBuscaDataNF.CheckedChanged += new System.EventHandler(this.chkAtivaBuscaDataNF_CheckedChanged);
            // 
            // grpBuscaDataNF
            // 
            this.grpBuscaDataNF.Controls.Add(this.label3);
            this.grpBuscaDataNF.Controls.Add(this.dtpDataNFFim);
            this.grpBuscaDataNF.Controls.Add(this.label2);
            this.grpBuscaDataNF.Controls.Add(this.dtpDataNFInicio);
            this.grpBuscaDataNF.Enabled = false;
            this.grpBuscaDataNF.Location = new System.Drawing.Point(19, 39);
            this.grpBuscaDataNF.Name = "grpBuscaDataNF";
            this.grpBuscaDataNF.Size = new System.Drawing.Size(223, 79);
            this.grpBuscaDataNF.TabIndex = 12;
            this.grpBuscaDataNF.TabStop = false;
            this.grpBuscaDataNF.Text = "Data NF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data Fim";
            // 
            // dtpDataNFFim
            // 
            this.dtpDataNFFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNFFim.Location = new System.Drawing.Point(100, 45);
            this.dtpDataNFFim.Name = "dtpDataNFFim";
            this.dtpDataNFFim.Size = new System.Drawing.Size(106, 20);
            this.dtpDataNFFim.TabIndex = 2;
            this.dtpDataNFFim.ValueChanged += new System.EventHandler(this.dtpDataNFFim_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Início";
            // 
            // dtpDataNFInicio
            // 
            this.dtpDataNFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataNFInicio.Location = new System.Drawing.Point(100, 19);
            this.dtpDataNFInicio.Name = "dtpDataNFInicio";
            this.dtpDataNFInicio.Size = new System.Drawing.Size(106, 20);
            this.dtpDataNFInicio.TabIndex = 0;
            this.dtpDataNFInicio.ValueChanged += new System.EventHandler(this.dtpDataNFInicio_ValueChanged);
            // 
            // btnReceber
            // 
            this.btnReceber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceber.Location = new System.Drawing.Point(642, 46);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(164, 23);
            this.btnReceber.TabIndex = 5;
            this.btnReceber.Text = "Receber Nota Selecionada";
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.btnReceber_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Busca";
            // 
            // timerBusca
            // 
            this.timerBusca.Tick += new System.EventHandler(this.timerBusca_Tick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Location = new System.Drawing.Point(642, 81);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(164, 23);
            this.btnExcluir.TabIndex = 16;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // CadNFEntradaPendentesListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(828, 405);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadNFEntradaPendentesListForm";
            this.Text = "Notas Fiscais com Recebimento Pendentes ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpDataImportacao.ResumeLayout(false);
            this.grpDataImportacao.PerformLayout();
            this.grpBuscaDataNF.ResumeLayout(false);
            this.grpBuscaDataNF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerBusca;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.CheckBox chkAtivaBuscaDataImp;
        private System.Windows.Forms.GroupBox grpDataImportacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDataImpFim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDataImpInicio;
        private System.Windows.Forms.CheckBox chkAtivaBuscaDataNF;
        private System.Windows.Forms.GroupBox grpBuscaDataNF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDataNFFim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDataNFInicio;
        private System.Windows.Forms.Button btnExcluir;
    }
}