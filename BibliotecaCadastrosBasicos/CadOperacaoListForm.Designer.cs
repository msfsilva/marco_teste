namespace BibliotecaCadastrosBasicos
{
    partial class CadOperacaoListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.iwtDefaultListButtons1 = new IWTDotNetLib.IWTDefaultListButtons();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GerarContasReceberColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DevolucaoMaterialColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EntregaFuturaColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SomaFreteBcIcmsColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SomaFreteBcIpiColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.iwtSearchPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 274);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.iwtDefaultListButtons1);
            this.splitContainer2.Size = new System.Drawing.Size(582, 62);
            this.splitContainer2.SplitterDistance = 308;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(582, 240);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtDataGridView1
            // 
            this.iwtDataGridView1.AllowUserToAddRows = false;
            this.iwtDataGridView1.AllowUserToDeleteRows = false;
            this.iwtDataGridView1.AllowUserToOrderColumns = true;
            this.iwtDataGridView1.AllowUserToResizeRows = false;
            this.iwtDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.iwtDataGridView1.CacheDados = null;
            this.iwtDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iwtDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descricao,
            this.Column1,
            this.Column2,
            this.Column3,
            this.GerarContasReceberColumn,
            this.DevolucaoMaterialColumn,
            this.EntregaFuturaColumn,
            this.SomaFreteBcIcmsColumn,
            this.SomaFreteBcIpiColumn});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(582, 202);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // iwtDefaultListButtons1
            // 
            this.iwtDefaultListButtons1.Location = new System.Drawing.Point(0, 0);
            this.iwtDefaultListButtons1.Name = "iwtDefaultListButtons1";
            this.iwtDefaultListButtons1.Size = new System.Drawing.Size(270, 62);
            this.iwtDefaultListButtons1.TabIndex = 0;
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(308, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 20);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(249, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 23);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 150;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.DataPropertyName = "Cfop";
            this.Column1.HeaderText = "CFOP dentro Estado";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "CfopForaEstado";
            this.Column2.HeaderText = "CFOP fora Estado";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.DataPropertyName = "NaturezaOperacao";
            this.Column3.HeaderText = "Natureza";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // GerarContasReceberColumn
            // 
            this.GerarContasReceberColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GerarContasReceberColumn.DataPropertyName = "GerarContasReceber";
            this.GerarContasReceberColumn.HeaderText = "Gerar Contas a Receber";
            this.GerarContasReceberColumn.Name = "GerarContasReceberColumn";
            this.GerarContasReceberColumn.ReadOnly = true;
            // 
            // DevolucaoMaterialColumn
            // 
            this.DevolucaoMaterialColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DevolucaoMaterialColumn.DataPropertyName = "DevolucaoMaterial";
            this.DevolucaoMaterialColumn.HeaderText = "Devolução de Materiais do Cliente";
            this.DevolucaoMaterialColumn.Name = "DevolucaoMaterialColumn";
            this.DevolucaoMaterialColumn.ReadOnly = true;
            // 
            // EntregaFuturaColumn
            // 
            this.EntregaFuturaColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EntregaFuturaColumn.DataPropertyName = "EntregaFutura";
            this.EntregaFuturaColumn.HeaderText = "Permite Entrega Futura";
            this.EntregaFuturaColumn.Name = "EntregaFuturaColumn";
            this.EntregaFuturaColumn.ReadOnly = true;
            // 
            // SomaFreteBcIcmsColumn
            // 
            this.SomaFreteBcIcmsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SomaFreteBcIcmsColumn.DataPropertyName = "SomaFreteBcIcms";
            this.SomaFreteBcIcmsColumn.HeaderText = "Soma Frete na BC Icms";
            this.SomaFreteBcIcmsColumn.Name = "SomaFreteBcIcmsColumn";
            this.SomaFreteBcIcmsColumn.ReadOnly = true;
            // 
            // SomaFreteBcIpiColumn
            // 
            this.SomaFreteBcIpiColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SomaFreteBcIpiColumn.DataPropertyName = "SomaFreteBcIpi";
            this.SomaFreteBcIpiColumn.HeaderText = "Soma Frete na BC do Ipi";
            this.SomaFreteBcIpiColumn.Name = "SomaFreteBcIpiColumn";
            this.SomaFreteBcIpiColumn.ReadOnly = true;
            this.SomaFreteBcIpiColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SomaFreteBcIpiColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CadOperacaoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 336);
            this.Name = "CadOperacaoListForm";
            this.Text = "Lista de Operações";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTDefaultListButtons iwtDefaultListButtons1;
        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GerarContasReceberColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DevolucaoMaterialColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EntregaFuturaColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SomaFreteBcIcmsColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SomaFreteBcIpiColumn;
    }
}