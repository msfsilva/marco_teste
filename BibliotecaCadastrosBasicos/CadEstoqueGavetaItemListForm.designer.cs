namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadEstoqueGavetaItemListForm 
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
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstoqueGaveta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocumentoCopia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Epi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 274);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(582, 62);
            this.splitContainer2.SplitterDistance = 308;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(582, 240);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
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
            this.iwtTextBox1.BindingField = "IdentificacaoCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 20);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(231, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 23);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
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
            this.ID,
            this.EstoqueGaveta,
            this.Produto,
            this.Material,
            this.DocumentoCopia,
            this.Recurso,
            this.ProdutoK,
            this.Epi,
            this.Quantidade,
            this.Ativo});
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
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 70;
            // 
            // EstoqueGaveta
            // 
            this.EstoqueGaveta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EstoqueGaveta.DataPropertyName = "IdentificacaoCompleta";
            this.EstoqueGaveta.HeaderText = "Gaveta";
            this.EstoqueGaveta.Name = "EstoqueGaveta";
            this.EstoqueGaveta.ReadOnly = true;
            this.EstoqueGaveta.Width = 300;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Visible = false;
            this.Produto.Width = 150;
            // 
            // Material
            // 
            this.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Material.DataPropertyName = "Material";
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Visible = false;
            this.Material.Width = 150;
            // 
            // DocumentoCopia
            // 
            this.DocumentoCopia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DocumentoCopia.DataPropertyName = "DocumentoCopia";
            this.DocumentoCopia.HeaderText = "Cópia de Documento";
            this.DocumentoCopia.Name = "DocumentoCopia";
            this.DocumentoCopia.ReadOnly = true;
            this.DocumentoCopia.Visible = false;
            this.DocumentoCopia.Width = 150;
            // 
            // Recurso
            // 
            this.Recurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Recurso.DataPropertyName = "Recurso";
            this.Recurso.HeaderText = "Recurso";
            this.Recurso.Name = "Recurso";
            this.Recurso.ReadOnly = true;
            this.Recurso.Visible = false;
            this.Recurso.Width = 150;
            // 
            // ProdutoK
            // 
            this.ProdutoK.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoK.DataPropertyName = "ProdutoK";
            this.ProdutoK.HeaderText = "Agrupador de Item Semelhante";
            this.ProdutoK.Name = "ProdutoK";
            this.ProdutoK.ReadOnly = true;
            this.ProdutoK.Visible = false;
            this.ProdutoK.Width = 150;
            // 
            // Epi
            // 
            this.Epi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Epi.DataPropertyName = "Epi";
            this.Epi.HeaderText = "EPI";
            this.Epi.Name = "Epi";
            this.Epi.ReadOnly = true;
            this.Epi.Visible = false;
            this.Epi.Width = 150;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Width = 70;
            // 
            // CadEstoqueGavetaItemListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 336);
            this.Name = "CadEstoqueGavetaItemListForm";
            this.Text = "Itens da Gaveta";
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstoqueGavetaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoCopiaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecursoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AtivoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoKColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EpiColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstoqueGaveta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentoCopia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Epi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
    }
} 
