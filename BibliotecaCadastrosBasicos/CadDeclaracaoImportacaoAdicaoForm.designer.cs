namespace BibliotecaCadastrosBasicos
{
    partial class CadDeclaracaoImportacaoAdicaoForm
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
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.dgvItens = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeclaracaoImportacaoAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroSequencialNaAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AliquotaIi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitarioDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitarioReais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotalDolares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotalReais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionarItem = new IWTDotNetLib.IWTButton(this.components);
            this.btnEditarItem = new IWTDotNetLib.IWTButton(this.components);
            this.btnRemoverItem = new IWTDotNetLib.IWTButton(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Size = new System.Drawing.Size(718, 644);
            this.splitContainer1.SplitterDistance = 578;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(631, 20);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 18);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(98, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Número da Adição:";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = "Numero";
            this.iwtLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(116, 18);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(0, 13);
            this.iwtLabel2.TabIndex = 1;
            // 
            // dgvItens
            // 
            this.dgvItens.AllowUserToAddRows = false;
            this.dgvItens.AllowUserToDeleteRows = false;
            this.dgvItens.AllowUserToOrderColumns = true;
            this.dgvItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItens.CacheDados = null;
            this.dgvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.DeclaracaoImportacaoAdicao,
            this.NumeroSequencialNaAdicao,
            this.Material,
            this.AliquotaIi,
            this.Quantidade,
            this.ValorUnitarioDolares,
            this.ValorUnitarioReais,
            this.ValorTotalDolares,
            this.ValorTotalReais});
            this.dgvItens.Dock = System.Windows.Forms.DockStyle.None;
            this.dgvItens.Location = new System.Drawing.Point(6, 48);
            this.dgvItens.MultiSelect = false;
            this.dgvItens.Name = "dgvItens";
            this.dgvItens.ReadOnly = true;
            this.dgvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItens.Size = new System.Drawing.Size(700, 471);
            this.dgvItens.TabIndex = 2;
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
            // DeclaracaoImportacaoAdicao
            // 
            this.DeclaracaoImportacaoAdicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeclaracaoImportacaoAdicao.DataPropertyName = "DeclaracaoImportacaoAdicao";
            this.DeclaracaoImportacaoAdicao.HeaderText = "Adição da Declaração de Importação";
            this.DeclaracaoImportacaoAdicao.Name = "DeclaracaoImportacaoAdicao";
            this.DeclaracaoImportacaoAdicao.ReadOnly = true;
            this.DeclaracaoImportacaoAdicao.Visible = false;
            this.DeclaracaoImportacaoAdicao.Width = 150;
            // 
            // NumeroSequencialNaAdicao
            // 
            this.NumeroSequencialNaAdicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroSequencialNaAdicao.DataPropertyName = "NumeroSequencialNaAdicao";
            this.NumeroSequencialNaAdicao.HeaderText = "Número Sequencial na Adição";
            this.NumeroSequencialNaAdicao.Name = "NumeroSequencialNaAdicao";
            this.NumeroSequencialNaAdicao.ReadOnly = true;
            this.NumeroSequencialNaAdicao.Width = 70;
            // 
            // Material
            // 
            this.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Material.DataPropertyName = "Material";
            this.Material.HeaderText = "Material";
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            this.Material.Width = 150;
            // 
            // AliquotaIi
            // 
            this.AliquotaIi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AliquotaIi.DataPropertyName = "AliquotaIi";
            this.AliquotaIi.HeaderText = "Alíquota II";
            this.AliquotaIi.Name = "AliquotaIi";
            this.AliquotaIi.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            // 
            // ValorUnitarioDolares
            // 
            this.ValorUnitarioDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorUnitarioDolares.DataPropertyName = "ValorUnitarioDolares";
            this.ValorUnitarioDolares.HeaderText = "Valor Unitário em Dólar";
            this.ValorUnitarioDolares.Name = "ValorUnitarioDolares";
            this.ValorUnitarioDolares.ReadOnly = true;
            // 
            // ValorUnitarioReais
            // 
            this.ValorUnitarioReais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorUnitarioReais.DataPropertyName = "ValorUnitarioReais";
            this.ValorUnitarioReais.HeaderText = "Valor Unitário em Reais";
            this.ValorUnitarioReais.Name = "ValorUnitarioReais";
            this.ValorUnitarioReais.ReadOnly = true;
            this.ValorUnitarioReais.Visible = false;
            // 
            // ValorTotalDolares
            // 
            this.ValorTotalDolares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorTotalDolares.DataPropertyName = "ValorTotalDolares";
            this.ValorTotalDolares.HeaderText = "Valor Total em Dólar";
            this.ValorTotalDolares.Name = "ValorTotalDolares";
            this.ValorTotalDolares.ReadOnly = true;
            // 
            // ValorTotalReais
            // 
            this.ValorTotalReais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValorTotalReais.DataPropertyName = "ValorTotalReais";
            this.ValorTotalReais.HeaderText = "Valor Total Reais";
            this.ValorTotalReais.Name = "ValorTotalReais";
            this.ValorTotalReais.ReadOnly = true;
            this.ValorTotalReais.Visible = false;
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnAdicionarItem.Location = new System.Drawing.Point(470, 19);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionarItem.TabIndex = 3;
            this.btnAdicionarItem.Text = "Adicionar";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // btnEditarItem
            // 
            this.btnEditarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditarItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditarItem.Location = new System.Drawing.Point(551, 19);
            this.btnEditarItem.Name = "btnEditarItem";
            this.btnEditarItem.Size = new System.Drawing.Size(75, 23);
            this.btnEditarItem.TabIndex = 4;
            this.btnEditarItem.Text = "Editar";
            this.btnEditarItem.UseVisualStyleBackColor = true;
            this.btnEditarItem.Click += new System.EventHandler(this.btnEditarItem_Click);
            // 
            // btnRemoverItem
            // 
            this.btnRemoverItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemoverItem.Location = new System.Drawing.Point(631, 19);
            this.btnRemoverItem.Name = "btnRemoverItem";
            this.btnRemoverItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverItem.TabIndex = 5;
            this.btnRemoverItem.Text = "Remover";
            this.btnRemoverItem.UseVisualStyleBackColor = true;
            this.btnRemoverItem.Click += new System.EventHandler(this.btnRemoverItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvItens);
            this.groupBox1.Controls.Add(this.btnRemoverItem);
            this.groupBox1.Controls.Add(this.btnAdicionarItem);
            this.groupBox1.Controls.Add(this.btnEditarItem);
            this.groupBox1.Location = new System.Drawing.Point(3, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 525);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens da Adição";
            // 
            // CadDeclaracaoImportacaoAdicaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(718, 644);
            this.Name = "CadDeclaracaoImportacaoAdicaoForm";
            this.Text = "Adição da Declaração de Importação";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItens)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView dgvItens;
        private System.Windows.Forms.GroupBox groupBox1;
        private IWTDotNetLib.IWTButton btnRemoverItem;
        private IWTDotNetLib.IWTButton btnAdicionarItem;
        private IWTDotNetLib.IWTButton btnEditarItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeclaracaoImportacaoAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroSequencialNaAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn AliquotaIi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitarioDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitarioReais;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotalDolares;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotalReais;

    }
} 
