namespace BibliotecaCompras
{
    partial class GerarNecessidadeMateriaPrimaAuxiliarForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.btnGerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkTodosAgrupadores = new System.Windows.Forms.CheckBox();
            this.livAgrupadores = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.Descrição = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data de Término";
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(104, 24);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(104, 20);
            this.dtpFim.TabIndex = 1;
            // 
            // btnGerar
            // 
            this.btnGerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerar.Location = new System.Drawing.Point(290, 263);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(75, 23);
            this.btnGerar.TabIndex = 2;
            this.btnGerar.Text = "Gerar";
            this.btnGerar.UseVisualStyleBackColor = true;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Agrupadores de Materiais";
            // 
            // chkTodosAgrupadores
            // 
            this.chkTodosAgrupadores.AutoSize = true;
            this.chkTodosAgrupadores.Location = new System.Drawing.Point(309, 82);
            this.chkTodosAgrupadores.Name = "chkTodosAgrupadores";
            this.chkTodosAgrupadores.Size = new System.Drawing.Size(56, 17);
            this.chkTodosAgrupadores.TabIndex = 5;
            this.chkTodosAgrupadores.Text = "Todos";
            this.chkTodosAgrupadores.UseVisualStyleBackColor = true;
            this.chkTodosAgrupadores.CheckedChanged += new System.EventHandler(this.chkTodosAgrupadores_CheckedChanged);
            // 
            // livAgrupadores
            // 
            this.livAgrupadores.AutoArrange = false;
            this.livAgrupadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.Descrição});
            this.livAgrupadores.FullRowSelect = true;
            this.livAgrupadores.Location = new System.Drawing.Point(15, 98);
            this.livAgrupadores.Name = "livAgrupadores";
            this.livAgrupadores.Size = new System.Drawing.Size(350, 159);
            this.livAgrupadores.TabIndex = 6;
            this.livAgrupadores.UseCompatibleStateImageBehavior = false;
            this.livAgrupadores.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Identificação";
            this.columnHeader1.Width = 150;
            // 
            // Descrição
            // 
            this.Descrição.Text = "Descrição";
            this.Descrição.Width = 193;
            // 
            // GerarNecessidadeMateriaPrimaAuxiliarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(377, 298);
            this.Controls.Add(this.livAgrupadores);
            this.Controls.Add(this.chkTodosAgrupadores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGerar);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.label1);
            this.Name = "GerarNecessidadeMateriaPrimaAuxiliarForm";
            this.Text = "Relatório de Necessidade de Matéria Prima";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTodosAgrupadores;
        private System.Windows.Forms.ListView livAgrupadores;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader Descrição;
    }
}