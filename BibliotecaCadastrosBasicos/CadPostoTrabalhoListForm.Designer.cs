namespace BibliotecaCadastrosBasicos
{
    partial class CadPostoTrabalhoListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnImprimirEtiqueta = new System.Windows.Forms.Button();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.iwtExcluirButton1 = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rastreamento = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Produtivo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TipoAcompanhamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostoExternoColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TaxaHoraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRevisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.splitContainer2.Panel2.Controls.Add(this.iwtExcluirButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Panel2.Controls.Add(this.btnImprimirEtiqueta);
            this.splitContainer2.Size = new System.Drawing.Size(648, 62);
            this.splitContainer2.SplitterDistance = 289;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(648, 240);
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
            this.ID,
            this.Codigo,
            this.Nome,
            this.Operacao,
            this.Rastreamento,
            this.Produtivo,
            this.TipoAcompanhamento,
            this.PostoExternoColumn,
            this.TaxaHoraColumn,
            this.Revisor,
            this.Revisao,
            this.DataRevisao});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(648, 202);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // btnImprimirEtiqueta
            // 
            this.btnImprimirEtiqueta.Location = new System.Drawing.Point(25, 20);
            this.btnImprimirEtiqueta.Name = "btnImprimirEtiqueta";
            this.btnImprimirEtiqueta.Size = new System.Drawing.Size(75, 23);
            this.btnImprimirEtiqueta.TabIndex = 3;
            this.btnImprimirEtiqueta.Text = "Etiqueta";
            this.btnImprimirEtiqueta.UseVisualStyleBackColor = true;
            this.btnImprimirEtiqueta.Click += new System.EventHandler(this.btnImprimirEtiqueta_Click);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(289, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(40, 23);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(233, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(2, 25);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(106, 20);
            this.iwtNovoButton1.Name = "iwtNovoButton1";
            this.iwtNovoButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtNovoButton1.TabIndex = 4;
            this.iwtNovoButton1.Text = "Novo";
            this.iwtNovoButton1.UseVisualStyleBackColor = true;
            // 
            // iwtEditarButton1
            // 
            this.iwtEditarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtEditarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtEditarButton1.Location = new System.Drawing.Point(187, 20);
            this.iwtEditarButton1.Name = "iwtEditarButton1";
            this.iwtEditarButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtEditarButton1.TabIndex = 5;
            this.iwtEditarButton1.Text = "Editar";
            this.iwtEditarButton1.UseVisualStyleBackColor = true;
            // 
            // iwtExcluirButton1
            // 
            this.iwtExcluirButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtExcluirButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtExcluirButton1.Location = new System.Drawing.Point(268, 20);
            this.iwtExcluirButton1.Name = "iwtExcluirButton1";
            this.iwtExcluirButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtExcluirButton1.TabIndex = 6;
            this.iwtExcluirButton1.Text = "Excluir";
            this.iwtExcluirButton1.UseVisualStyleBackColor = true;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 120;
            // 
            // Operacao
            // 
            this.Operacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operacao.DataPropertyName = "OperacaoPosto";
            this.Operacao.HeaderText = "Operação";
            this.Operacao.Name = "Operacao";
            this.Operacao.ReadOnly = true;
            this.Operacao.Width = 120;
            // 
            // Rastreamento
            // 
            this.Rastreamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Rastreamento.DataPropertyName = "Rastreamento";
            this.Rastreamento.HeaderText = "Rastreamento";
            this.Rastreamento.Name = "Rastreamento";
            this.Rastreamento.ReadOnly = true;
            this.Rastreamento.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rastreamento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rastreamento.Width = 80;
            // 
            // Produtivo
            // 
            this.Produtivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Produtivo.DataPropertyName = "Produtivo";
            this.Produtivo.HeaderText = "Produtivo";
            this.Produtivo.Name = "Produtivo";
            this.Produtivo.ReadOnly = true;
            this.Produtivo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Produtivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Produtivo.Width = 80;
            // 
            // TipoAcompanhamento
            // 
            this.TipoAcompanhamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoAcompanhamento.DataPropertyName = "TipoAcompanhamento";
            this.TipoAcompanhamento.HeaderText = "Tipo Acompanhamento";
            this.TipoAcompanhamento.Name = "TipoAcompanhamento";
            this.TipoAcompanhamento.ReadOnly = true;
            // 
            // PostoExternoColumn
            // 
            this.PostoExternoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PostoExternoColumn.DataPropertyName = "PostoExterno";
            this.PostoExternoColumn.HeaderText = "Posto Externo";
            this.PostoExternoColumn.Name = "PostoExternoColumn";
            this.PostoExternoColumn.ReadOnly = true;
            this.PostoExternoColumn.Width = 70;
            // 
            // TaxaHoraColumn
            // 
            this.TaxaHoraColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaxaHoraColumn.DataPropertyName = "TaxaHora";
            dataGridViewCellStyle1.NullValue = null;
            this.TaxaHoraColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.TaxaHoraColumn.HeaderText = "Taxa Hora";
            this.TaxaHoraColumn.Name = "TaxaHoraColumn";
            this.TaxaHoraColumn.ReadOnly = true;
            // 
            // Revisor
            // 
            this.Revisor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Revisor.DataPropertyName = "UltimaRevisaoUsuario";
            this.Revisor.HeaderText = "Revisor";
            this.Revisor.Name = "Revisor";
            this.Revisor.ReadOnly = true;
            this.Revisor.Width = 80;
            // 
            // Revisao
            // 
            this.Revisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Revisao.DataPropertyName = "UltimaRevisao";
            this.Revisao.HeaderText = "Revisão";
            this.Revisao.Name = "Revisao";
            this.Revisao.ReadOnly = true;
            this.Revisao.Width = 80;
            // 
            // DataRevisao
            // 
            this.DataRevisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataRevisao.DataPropertyName = "UltimaRevisaoData";
            this.DataRevisao.HeaderText = "Data Revisão";
            this.DataRevisao.Name = "DataRevisao";
            this.DataRevisao.ReadOnly = true;
            // 
            // CadPostoTrabalhoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(648, 336);
            this.Name = "CadPostoTrabalhoListForm";
            this.Text = "Postos de Trabalho";
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
        private System.Windows.Forms.Button btnImprimirEtiqueta;
        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTExcluirButton iwtExcluirButton1;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
        private IWTDotNetLib.IWTNovoButton iwtNovoButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Rastreamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Produtivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAcompanhamento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PostoExternoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxaHoraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Revisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRevisao;
    }
}