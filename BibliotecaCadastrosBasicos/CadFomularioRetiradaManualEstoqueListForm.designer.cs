namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadFomularioRetiradaManualEstoqueListForm 
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
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Epi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAbertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEstoqueGaveta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEstoqueGavetaDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.iwtExcluirButton1 = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.btnImprimirEtiqueta = new IWTDotNetLib.IWTButton(this.components);
            this.btnImprimirFormulario = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 240);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnImprimirFormulario);
            this.splitContainer2.Panel2.Controls.Add(this.btnImprimirEtiqueta);
            this.splitContainer2.Panel2.Controls.Add(this.iwtExcluirButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Size = new System.Drawing.Size(582, 96);
            this.splitContainer2.SplitterDistance = 308;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(582, 206);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(308, 96);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 38);
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
            this.iwtLabel1.Location = new System.Drawing.Point(16, 41);
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
            this.Produto,
            this.Material,
            this.Epi,
            this.Quantidade,
            this.AcsUsuarioAbertura,
            this.DataAbertura,
            this.AcsUsuarioRetirada,
            this.DataRetirada,
            this.IdEstoqueGaveta,
            this.IdEstoqueGavetaDestino,
            this.Observacao});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(582, 168);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Número";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 70;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Width = 150;
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
            // Epi
            // 
            this.Epi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Epi.DataPropertyName = "Epi";
            this.Epi.HeaderText = "EPI";
            this.Epi.Name = "Epi";
            this.Epi.ReadOnly = true;
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
            // AcsUsuarioAbertura
            // 
            this.AcsUsuarioAbertura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioAbertura.DataPropertyName = "AcsUsuarioAbertura";
            this.AcsUsuarioAbertura.HeaderText = "Usuário Abertura";
            this.AcsUsuarioAbertura.Name = "AcsUsuarioAbertura";
            this.AcsUsuarioAbertura.ReadOnly = true;
            this.AcsUsuarioAbertura.Width = 150;
            // 
            // DataAbertura
            // 
            this.DataAbertura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataAbertura.DataPropertyName = "DataAbertura";
            this.DataAbertura.HeaderText = "Data de Abertura";
            this.DataAbertura.Name = "DataAbertura";
            this.DataAbertura.ReadOnly = true;
            // 
            // AcsUsuarioRetirada
            // 
            this.AcsUsuarioRetirada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioRetirada.DataPropertyName = "AcsUsuarioRetirada";
            this.AcsUsuarioRetirada.HeaderText = "Usuário Retirada";
            this.AcsUsuarioRetirada.Name = "AcsUsuarioRetirada";
            this.AcsUsuarioRetirada.ReadOnly = true;
            this.AcsUsuarioRetirada.Width = 150;
            // 
            // DataRetirada
            // 
            this.DataRetirada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataRetirada.DataPropertyName = "DataRetirada";
            this.DataRetirada.HeaderText = "Data da Retirada";
            this.DataRetirada.Name = "DataRetirada";
            this.DataRetirada.ReadOnly = true;
            // 
            // IdEstoqueGaveta
            // 
            this.IdEstoqueGaveta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdEstoqueGaveta.DataPropertyName = "EstoqueGaveta";
            this.IdEstoqueGaveta.HeaderText = "Origem";
            this.IdEstoqueGaveta.Name = "IdEstoqueGaveta";
            this.IdEstoqueGaveta.ReadOnly = true;
            this.IdEstoqueGaveta.Width = 70;
            // 
            // IdEstoqueGavetaDestino
            // 
            this.IdEstoqueGavetaDestino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IdEstoqueGavetaDestino.DataPropertyName = "EstoqueGavetaDestino";
            this.IdEstoqueGavetaDestino.HeaderText = "Destino";
            this.IdEstoqueGavetaDestino.Name = "IdEstoqueGavetaDestino";
            this.IdEstoqueGavetaDestino.ReadOnly = true;
            this.IdEstoqueGavetaDestino.Width = 70;
            // 
            // Observacao
            // 
            this.Observacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Observacao.DataPropertyName = "Observacao";
            this.Observacao.HeaderText = "Observação";
            this.Observacao.Name = "Observacao";
            this.Observacao.ReadOnly = true;
            this.Observacao.Width = 150;
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(20, 8);
            this.iwtNovoButton1.Name = "iwtNovoButton1";
            this.iwtNovoButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtNovoButton1.TabIndex = 0;
            this.iwtNovoButton1.Text = "Novo";
            this.iwtNovoButton1.UseVisualStyleBackColor = true;
            // 
            // iwtEditarButton1
            // 
            this.iwtEditarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtEditarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtEditarButton1.Location = new System.Drawing.Point(101, 8);
            this.iwtEditarButton1.Name = "iwtEditarButton1";
            this.iwtEditarButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtEditarButton1.TabIndex = 1;
            this.iwtEditarButton1.Text = "Editar";
            this.iwtEditarButton1.UseVisualStyleBackColor = true;
            // 
            // iwtExcluirButton1
            // 
            this.iwtExcluirButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtExcluirButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtExcluirButton1.Location = new System.Drawing.Point(182, 8);
            this.iwtExcluirButton1.Name = "iwtExcluirButton1";
            this.iwtExcluirButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtExcluirButton1.TabIndex = 2;
            this.iwtExcluirButton1.Text = "Excluir";
            this.iwtExcluirButton1.UseVisualStyleBackColor = true;
            // 
            // btnImprimirEtiqueta
            // 
            this.btnImprimirEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirEtiqueta.LiberadoQuandoCadastroUtilizado = false;
            this.btnImprimirEtiqueta.Location = new System.Drawing.Point(20, 37);
            this.btnImprimirEtiqueta.Name = "btnImprimirEtiqueta";
            this.btnImprimirEtiqueta.Size = new System.Drawing.Size(237, 23);
            this.btnImprimirEtiqueta.TabIndex = 3;
            this.btnImprimirEtiqueta.Text = "Imprimir Formulário em Etiqueta";
            this.btnImprimirEtiqueta.UseVisualStyleBackColor = true;
            this.btnImprimirEtiqueta.Click += new System.EventHandler(this.btnImprimirEtiqueta_Click);
            // 
            // btnImprimirFormulario
            // 
            this.btnImprimirFormulario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirFormulario.LiberadoQuandoCadastroUtilizado = false;
            this.btnImprimirFormulario.Location = new System.Drawing.Point(20, 66);
            this.btnImprimirFormulario.Name = "btnImprimirFormulario";
            this.btnImprimirFormulario.Size = new System.Drawing.Size(237, 23);
            this.btnImprimirFormulario.TabIndex = 3;
            this.btnImprimirFormulario.Text = "Imprimir Formulário em A4";
            this.btnImprimirFormulario.UseVisualStyleBackColor = true;
            this.btnImprimirFormulario.Click += new System.EventHandler(this.btnImprimirFormulario_Click);
            // 
            // CadFomularioRetiradaManualEstoqueListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 336);
            this.Name = "CadFomularioRetiradaManualEstoqueListForm";
            this.Text = "Formulários de Movimentação Manual de Estoque";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaterialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioAberturaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAberturaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioRetiradaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRetiradaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstoqueGavetaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstoqueGavetaDestinoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EpiColumn;
        private IWTDotNetLib.IWTExcluirButton iwtExcluirButton1;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
        private IWTDotNetLib.IWTNovoButton iwtNovoButton1;
        private IWTDotNetLib.IWTButton btnImprimirFormulario;
        private IWTDotNetLib.IWTButton btnImprimirEtiqueta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Epi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAbertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstoqueGaveta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstoqueGavetaDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
    }
} 
