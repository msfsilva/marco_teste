namespace BibliotecaWhereUsed
{
    partial class WhereUsedReportForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rdbFornecedores = new System.Windows.Forms.RadioButton();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbAcabamento = new System.Windows.Forms.RadioButton();
            this.rdbRecursos = new System.Windows.Forms.RadioButton();
            this.rdbDocumentos = new System.Windows.Forms.RadioButton();
            this.rdbProdutos = new System.Windows.Forms.RadioButton();
            this.rdbMaterial = new System.Windows.Forms.RadioButton();
            this.btnFechar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rdbPostos = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.rdbPostos);
            this.splitContainer1.Panel2.Controls.Add(this.rdbFornecedores);
            this.splitContainer1.Panel2.Controls.Add(this.txtBusca);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.rdbAcabamento);
            this.splitContainer1.Panel2.Controls.Add(this.rdbRecursos);
            this.splitContainer1.Panel2.Controls.Add(this.rdbDocumentos);
            this.splitContainer1.Panel2.Controls.Add(this.rdbProdutos);
            this.splitContainer1.Panel2.Controls.Add(this.rdbMaterial);
            this.splitContainer1.Panel2.Controls.Add(this.btnFechar);
            this.splitContainer1.Size = new System.Drawing.Size(696, 411);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(696, 326);
            this.dataGridView1.TabIndex = 1;
            // 
            // rdbFornecedores
            // 
            this.rdbFornecedores.AutoSize = true;
            this.rdbFornecedores.Location = new System.Drawing.Point(347, 43);
            this.rdbFornecedores.Name = "rdbFornecedores";
            this.rdbFornecedores.Size = new System.Drawing.Size(90, 17);
            this.rdbFornecedores.TabIndex = 6;
            this.rdbFornecedores.Text = "Fornecedores";
            this.rdbFornecedores.UseVisualStyleBackColor = true;
            this.rdbFornecedores.CheckedChanged += new System.EventHandler(this.rdbFornecedores_CheckedChanged);
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(24, 23);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(171, 20);
            this.txtBusca.TabIndex = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Busca Identificação (min 3 caracteres)";
            // 
            // rdbAcabamento
            // 
            this.rdbAcabamento.AutoSize = true;
            this.rdbAcabamento.Location = new System.Drawing.Point(347, 23);
            this.rdbAcabamento.Name = "rdbAcabamento";
            this.rdbAcabamento.Size = new System.Drawing.Size(90, 17);
            this.rdbAcabamento.TabIndex = 5;
            this.rdbAcabamento.Text = "Acabamentos";
            this.rdbAcabamento.UseVisualStyleBackColor = true;
            this.rdbAcabamento.CheckedChanged += new System.EventHandler(this.rdbAcabamento_CheckedChanged);
            // 
            // rdbRecursos
            // 
            this.rdbRecursos.AutoSize = true;
            this.rdbRecursos.Location = new System.Drawing.Point(347, 3);
            this.rdbRecursos.Name = "rdbRecursos";
            this.rdbRecursos.Size = new System.Drawing.Size(70, 17);
            this.rdbRecursos.TabIndex = 4;
            this.rdbRecursos.Text = "Recursos";
            this.rdbRecursos.UseVisualStyleBackColor = true;
            this.rdbRecursos.CheckedChanged += new System.EventHandler(this.rdbRecursos_CheckedChanged);
            // 
            // rdbDocumentos
            // 
            this.rdbDocumentos.AutoSize = true;
            this.rdbDocumentos.Location = new System.Drawing.Point(222, 43);
            this.rdbDocumentos.Name = "rdbDocumentos";
            this.rdbDocumentos.Size = new System.Drawing.Size(85, 17);
            this.rdbDocumentos.TabIndex = 3;
            this.rdbDocumentos.Text = "Documentos";
            this.rdbDocumentos.UseVisualStyleBackColor = true;
            this.rdbDocumentos.CheckedChanged += new System.EventHandler(this.rdbDocumentos_CheckedChanged);
            // 
            // rdbProdutos
            // 
            this.rdbProdutos.AutoSize = true;
            this.rdbProdutos.Location = new System.Drawing.Point(222, 23);
            this.rdbProdutos.Name = "rdbProdutos";
            this.rdbProdutos.Size = new System.Drawing.Size(67, 17);
            this.rdbProdutos.TabIndex = 2;
            this.rdbProdutos.Text = "Produtos";
            this.rdbProdutos.UseVisualStyleBackColor = true;
            this.rdbProdutos.CheckedChanged += new System.EventHandler(this.rdbProdutos_CheckedChanged);
            // 
            // rdbMaterial
            // 
            this.rdbMaterial.AutoSize = true;
            this.rdbMaterial.Checked = true;
            this.rdbMaterial.Location = new System.Drawing.Point(222, 3);
            this.rdbMaterial.Name = "rdbMaterial";
            this.rdbMaterial.Size = new System.Drawing.Size(67, 17);
            this.rdbMaterial.TabIndex = 1;
            this.rdbMaterial.TabStop = true;
            this.rdbMaterial.Text = "Materiais";
            this.rdbMaterial.UseVisualStyleBackColor = true;
            this.rdbMaterial.CheckedChanged += new System.EventHandler(this.rdbMaterial_CheckedChanged);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(609, 46);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rdbPostos
            // 
            this.rdbPostos.AutoSize = true;
            this.rdbPostos.Location = new System.Drawing.Point(445, 5);
            this.rdbPostos.Name = "rdbPostos";
            this.rdbPostos.Size = new System.Drawing.Size(117, 17);
            this.rdbPostos.TabIndex = 7;
            this.rdbPostos.Text = "Postos de Trabalho";
            this.rdbPostos.UseVisualStyleBackColor = true;
            this.rdbPostos.CheckedChanged += new System.EventHandler(this.rdbPostos_CheckedChanged);
            // 
            // WhereUsedReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(696, 411);
            this.Controls.Add(this.splitContainer1);
            this.Name = "WhereUsedReportForm";
            this.Text = "Where Used";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.RadioButton rdbAcabamento;
        private System.Windows.Forms.RadioButton rdbRecursos;
        private System.Windows.Forms.RadioButton rdbDocumentos;
        private System.Windows.Forms.RadioButton rdbProdutos;
        private System.Windows.Forms.RadioButton rdbMaterial;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton rdbFornecedores;
        private System.Windows.Forms.RadioButton rdbPostos;
    }
}