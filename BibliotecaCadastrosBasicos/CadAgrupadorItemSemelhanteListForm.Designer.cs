namespace BibliotecaCadastrosBasicos
{
    partial class CadAgrupadorItemSemelhanteListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EmiteOp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ImprimeEtiqueta = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClassificacaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UtilizaDimensaoComoQuantidadeNaBaixa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisaoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisaoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEtiquetaKb = new System.Windows.Forms.Button();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.iwtExcluirButton1 = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.rdbInativos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbAtivos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.btnAtivarDesativar = new IWTDotNetLib.IWTButton(this.components);
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 255);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnAtivarDesativar);
            this.splitContainer2.Panel2.Controls.Add(this.iwtExcluirButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.btnEtiquetaKb);
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Size = new System.Drawing.Size(648, 68);
            this.splitContainer2.SplitterDistance = 322;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(648, 227);
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
            this.Codigo,
            this.Dimensao,
            this.Ativo,
            this.EmiteOp,
            this.ImprimeEtiqueta,
            this.ClassificacaoProduto,
            this.UtilizaDimensaoComoQuantidadeNaBaixa,
            this.Descricao,
            this.UltimaRevisaoUsuario,
            this.UltimaRevisao,
            this.UltimaRevisaoData});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(648, 189);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Identificação";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 120;
            // 
            // Dimensao
            // 
            this.Dimensao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Dimensao.DataPropertyName = "Dimensao";
            this.Dimensao.HeaderText = "Dimensão Variável";
            this.Dimensao.Name = "Dimensao";
            this.Dimensao.ReadOnly = true;
            // 
            // Ativo
            // 
            this.Ativo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Width = 50;
            // 
            // EmiteOp
            // 
            this.EmiteOp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmiteOp.DataPropertyName = "EmiteOp";
            this.EmiteOp.HeaderText = "Emite OP";
            this.EmiteOp.Name = "EmiteOp";
            this.EmiteOp.ReadOnly = true;
            this.EmiteOp.Width = 50;
            // 
            // ImprimeEtiqueta
            // 
            this.ImprimeEtiqueta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImprimeEtiqueta.DataPropertyName = "ImprimeEtiqueta";
            this.ImprimeEtiqueta.HeaderText = "Imprime Etiqueta";
            this.ImprimeEtiqueta.Name = "ImprimeEtiqueta";
            this.ImprimeEtiqueta.ReadOnly = true;
            this.ImprimeEtiqueta.Width = 80;
            // 
            // ClassificacaoProduto
            // 
            this.ClassificacaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClassificacaoProduto.DataPropertyName = "ClassificacaoProduto";
            this.ClassificacaoProduto.HeaderText = "Classificação";
            this.ClassificacaoProduto.Name = "ClassificacaoProduto";
            this.ClassificacaoProduto.ReadOnly = true;
            // 
            // UtilizaDimensaoComoQuantidadeNaBaixa
            // 
            this.UtilizaDimensaoComoQuantidadeNaBaixa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UtilizaDimensaoComoQuantidadeNaBaixa.DataPropertyName = "UtilizaDimensaoQuantidadeBaixa";
            this.UtilizaDimensaoComoQuantidadeNaBaixa.HeaderText = "Utiliza Dimensão como Quantidade";
            this.UtilizaDimensaoComoQuantidadeNaBaixa.Name = "UtilizaDimensaoComoQuantidadeNaBaixa";
            this.UtilizaDimensaoComoQuantidadeNaBaixa.ReadOnly = true;
            this.UtilizaDimensaoComoQuantidadeNaBaixa.Width = 80;
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
            // UltimaRevisaoUsuario
            // 
            this.UltimaRevisaoUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaRevisaoUsuario.DataPropertyName = "UltimaRevisaoUsuario";
            this.UltimaRevisaoUsuario.HeaderText = "Revisor";
            this.UltimaRevisaoUsuario.Name = "UltimaRevisaoUsuario";
            this.UltimaRevisaoUsuario.ReadOnly = true;
            this.UltimaRevisaoUsuario.Width = 80;
            // 
            // UltimaRevisao
            // 
            this.UltimaRevisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaRevisao.DataPropertyName = "UltimaRevisao";
            this.UltimaRevisao.HeaderText = "Revisão";
            this.UltimaRevisao.Name = "UltimaRevisao";
            this.UltimaRevisao.ReadOnly = true;
            // 
            // UltimaRevisaoData
            // 
            this.UltimaRevisaoData.DataPropertyName = "UltimaRevisaoData";
            this.UltimaRevisaoData.HeaderText = "Data Revisão";
            this.UltimaRevisaoData.Name = "UltimaRevisaoData";
            this.UltimaRevisaoData.ReadOnly = true;
            // 
            // btnEtiquetaKb
            // 
            this.btnEtiquetaKb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEtiquetaKb.Location = new System.Drawing.Point(165, 37);
            this.btnEtiquetaKb.Name = "btnEtiquetaKb";
            this.btnEtiquetaKb.Size = new System.Drawing.Size(115, 23);
            this.btnEtiquetaKb.TabIndex = 4;
            this.btnEtiquetaKb.Text = "Etiquetas de Kanban";
            this.btnEtiquetaKb.UseVisualStyleBackColor = true;
            this.btnEtiquetaKb.Click += new System.EventHandler(this.btnEtiquetaKb_Click);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.rdbInativos);
            this.iwtSearchPanel1.Controls.Add(this.rdbAtivos);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(322, 68);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(55, 6);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(253, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 9);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(43, 10);
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
            this.iwtEditarButton1.Location = new System.Drawing.Point(124, 10);
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
            this.iwtExcluirButton1.Location = new System.Drawing.Point(205, 10);
            this.iwtExcluirButton1.Name = "iwtExcluirButton1";
            this.iwtExcluirButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtExcluirButton1.TabIndex = 2;
            this.iwtExcluirButton1.Text = "Excluir";
            this.iwtExcluirButton1.UseVisualStyleBackColor = true;
            // 
            // rdbInativos
            // 
            this.rdbInativos.AutoSize = true;
            this.rdbInativos.BindingField = "";
            this.rdbInativos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbInativos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbInativos.Location = new System.Drawing.Point(115, 39);
            this.rdbInativos.Name = "rdbInativos";
            this.rdbInativos.Size = new System.Drawing.Size(62, 17);
            this.rdbInativos.TabIndex = 2;
            this.rdbInativos.Text = "Inativos";
            this.rdbInativos.UseVisualStyleBackColor = true;
            this.rdbInativos.CheckedChanged += new System.EventHandler(this.rdbInativos_CheckedChanged);
            // 
            // rdbAtivos
            // 
            this.rdbAtivos.AutoSize = true;
            this.rdbAtivos.BindingField = "Ativo";
            this.rdbAtivos.Checked = true;
            this.rdbAtivos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAtivos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAtivos.Location = new System.Drawing.Point(55, 38);
            this.rdbAtivos.Name = "rdbAtivos";
            this.rdbAtivos.Size = new System.Drawing.Size(54, 17);
            this.rdbAtivos.TabIndex = 1;
            this.rdbAtivos.TabStop = true;
            this.rdbAtivos.Text = "Ativos";
            this.rdbAtivos.UseVisualStyleBackColor = true;
            this.rdbAtivos.CheckedChanged += new System.EventHandler(this.rdbAtivos_CheckedChanged);
            // 
            // btnAtivarDesativar
            // 
            this.btnAtivarDesativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtivarDesativar.LiberadoQuandoCadastroUtilizado = false;
            this.btnAtivarDesativar.Location = new System.Drawing.Point(43, 37);
            this.btnAtivarDesativar.Name = "btnAtivarDesativar";
            this.btnAtivarDesativar.Size = new System.Drawing.Size(116, 23);
            this.btnAtivarDesativar.TabIndex = 3;
            this.btnAtivarDesativar.Text = "Desativar";
            this.btnAtivarDesativar.UseVisualStyleBackColor = true;
            this.btnAtivarDesativar.Click += new System.EventHandler(this.btnAtivarDesativar_Click);
            // 
            // CadAgrupadorItemSemelhanteListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(648, 323);
            this.Name = "CadAgrupadorItemSemelhanteListForm";
            this.Text = "Kanban de Itens Manufaturados";
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
        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private System.Windows.Forms.Button btnEtiquetaKb;
        private IWTDotNetLib.IWTExcluirButton iwtExcluirButton1;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
        private IWTDotNetLib.IWTNovoButton iwtNovoButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimensao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EmiteOp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImprimeEtiqueta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassificacaoProduto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UtilizaDimensaoComoQuantidadeNaBaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisaoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisaoData;
        private IWTDotNetLib.IWTRadioButton rdbInativos;
        private IWTDotNetLib.IWTRadioButton rdbAtivos;
        private IWTDotNetLib.IWTButton btnAtivarDesativar;
    }
}