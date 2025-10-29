namespace BibliotecaCadastrosBasicos.Operacoes
{
    partial class AtualizarEntregaPedidoMultiploForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.NumeroPedidoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PosicaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NovaDataEntregaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JustificativaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(711, 480);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroPedidoColumn,
            this.PosicaoColumn,
            this.NovaDataEntregaColumn,
            this.JustificativaColumn});
            this.dgvDados.Location = new System.Drawing.Point(12, 12);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(774, 462);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDados_CellValidating);
            this.dgvDados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDados_KeyDown);
            // 
            // NumeroPedidoColumn
            // 
            this.NumeroPedidoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroPedidoColumn.DataPropertyName = "Pedido";
            this.NumeroPedidoColumn.HeaderText = "Pedido";
            this.NumeroPedidoColumn.Name = "NumeroPedidoColumn";
            this.NumeroPedidoColumn.Width = 150;
            // 
            // PosicaoColumn
            // 
            this.PosicaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PosicaoColumn.DataPropertyName = "Posicao";
            this.PosicaoColumn.HeaderText = "Posição";
            this.PosicaoColumn.Name = "PosicaoColumn";
            this.PosicaoColumn.Width = 60;
            // 
            // NovaDataEntregaColumn
            // 
            this.NovaDataEntregaColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NovaDataEntregaColumn.DataPropertyName = "DataEntrega";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.NovaDataEntregaColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.NovaDataEntregaColumn.HeaderText = "Nova Data de Entrega";
            this.NovaDataEntregaColumn.Name = "NovaDataEntregaColumn";
            this.NovaDataEntregaColumn.Width = 150;
            // 
            // JustificativaColumn
            // 
            this.JustificativaColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.JustificativaColumn.DataPropertyName = "Justificativa";
            this.JustificativaColumn.HeaderText = "Justificativa";
            this.JustificativaColumn.Name = "JustificativaColumn";
            this.JustificativaColumn.Width = 300;
            // 
            // AtualizarEntregaPedidoMultiploForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 515);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.btnSalvar);
            this.Name = "AtualizarEntregaPedidoMultiploForm";
            this.Text = "Alteração em Lote da data de Entrega";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPedidoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PosicaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NovaDataEntregaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JustificativaColumn;
    }
}