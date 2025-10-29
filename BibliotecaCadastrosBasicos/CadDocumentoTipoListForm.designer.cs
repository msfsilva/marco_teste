namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadDocumentoTipoListForm 
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
            this.Identificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RevisaoAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisaoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaRevisaoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.iwtExcluirButton1 = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.btnCopias = new IWTDotNetLib.IWTButton(this.components);
            this.grbAcessoDiretoCopias = new System.Windows.Forms.GroupBox();
            this.ensFamiliaDocumento = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.grbAcessoDiretoCopias.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 237);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grbAcessoDiretoCopias);
            this.splitContainer2.Panel2.Controls.Add(this.iwtExcluirButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Size = new System.Drawing.Size(777, 99);
            this.splitContainer2.SplitterDistance = 342;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(777, 203);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(342, 99);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 39);
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
            this.iwtLabel1.Location = new System.Drawing.Point(16, 42);
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
            this.Identificacao,
            this.Descricao,
            this.RevisaoAtual,
            this.UltimaRevisao,
            this.UltimaRevisaoData,
            this.UltimaRevisaoUsuario});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(777, 165);
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
            // Identificacao
            // 
            this.Identificacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Identificacao.DataPropertyName = "Identificacao";
            this.Identificacao.HeaderText = "Identificação";
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.ReadOnly = true;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 120;
            // 
            // RevisaoAtual
            // 
            this.RevisaoAtual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RevisaoAtual.DataPropertyName = "RevisaoAtual";
            this.RevisaoAtual.HeaderText = "Revisão Atual";
            this.RevisaoAtual.Name = "RevisaoAtual";
            this.RevisaoAtual.ReadOnly = true;
            this.RevisaoAtual.Width = 50;
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
            this.UltimaRevisaoData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaRevisaoData.DataPropertyName = "UltimaRevisaoData";
            this.UltimaRevisaoData.HeaderText = "Data da Revisão";
            this.UltimaRevisaoData.Name = "UltimaRevisaoData";
            this.UltimaRevisaoData.ReadOnly = true;
            // 
            // UltimaRevisaoUsuario
            // 
            this.UltimaRevisaoUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaRevisaoUsuario.DataPropertyName = "UltimaRevisaoUsuario";
            this.UltimaRevisaoUsuario.HeaderText = "Usuário Revisão";
            this.UltimaRevisaoUsuario.Name = "UltimaRevisaoUsuario";
            this.UltimaRevisaoUsuario.ReadOnly = true;
            this.UltimaRevisaoUsuario.Width = 80;
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(182, 11);
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
            this.iwtEditarButton1.Location = new System.Drawing.Point(263, 11);
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
            this.iwtExcluirButton1.Location = new System.Drawing.Point(344, 11);
            this.iwtExcluirButton1.Name = "iwtExcluirButton1";
            this.iwtExcluirButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtExcluirButton1.TabIndex = 2;
            this.iwtExcluirButton1.Text = "Excluir";
            this.iwtExcluirButton1.UseVisualStyleBackColor = true;
            // 
            // btnCopias
            // 
            this.btnCopias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopias.LiberadoQuandoCadastroUtilizado = false;
            this.btnCopias.Location = new System.Drawing.Point(345, 22);
            this.btnCopias.Name = "btnCopias";
            this.btnCopias.Size = new System.Drawing.Size(65, 23);
            this.btnCopias.TabIndex = 3;
            this.btnCopias.Text = "Cópias";
            this.btnCopias.UseVisualStyleBackColor = true;
            this.btnCopias.Click += new System.EventHandler(this.btnCopias_Click);
            // 
            // grbAcessoDiretoCopias
            // 
            this.grbAcessoDiretoCopias.Controls.Add(this.ensFamiliaDocumento);
            this.grbAcessoDiretoCopias.Controls.Add(this.label1);
            this.grbAcessoDiretoCopias.Controls.Add(this.btnCopias);
            this.grbAcessoDiretoCopias.Location = new System.Drawing.Point(3, 39);
            this.grbAcessoDiretoCopias.Name = "grbAcessoDiretoCopias";
            this.grbAcessoDiretoCopias.Size = new System.Drawing.Size(416, 57);
            this.grbAcessoDiretoCopias.TabIndex = 4;
            this.grbAcessoDiretoCopias.TabStop = false;
            this.grbAcessoDiretoCopias.Text = "Acesso Direto as Cópias";
            // 
            // ensFamiliaDocumento
            // 
            this.ensFamiliaDocumento.BindingField = null;
            this.ensFamiliaDocumento.ColunasDropdown = null;
            this.ensFamiliaDocumento.DesabilitarAutoCompletar = false;
            this.ensFamiliaDocumento.DesabilitarChekBox = true;
            this.ensFamiliaDocumento.DesabilitarLupa = false;
            this.ensFamiliaDocumento.DesabilitarSeta = false;
            this.ensFamiliaDocumento.EntidadeSelecionada = null;
            this.ensFamiliaDocumento.FormSelecao = null;
            this.ensFamiliaDocumento.LiberadoQuandoCadastroUtilizado = false;
            this.ensFamiliaDocumento.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFamiliaDocumento.Location = new System.Drawing.Point(51, 22);
            this.ensFamiliaDocumento.ModoVisualizacaoGrid = null;
            this.ensFamiliaDocumento.Name = "ensFamiliaDocumento";
            this.ensFamiliaDocumento.ParametroBuscaGuiada = null;
            this.ensFamiliaDocumento.ParametrosBuscaObrigatorios = null;
            this.ensFamiliaDocumento.Size = new System.Drawing.Size(284, 23);
            this.ensFamiliaDocumento.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Familia";
            // 
            // CadDocumentoTipoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(777, 336);
            this.Name = "CadDocumentoTipoListForm";
            this.Text = "Documentos";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.grbAcessoDiretoCopias.ResumeLayout(false);
            this.grbAcessoDiretoCopias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn RevisaoAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisaoData;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaRevisaoUsuario;
        private IWTDotNetLib.IWTButton btnCopias;
        private IWTDotNetLib.IWTExcluirButton iwtExcluirButton1;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
        private IWTDotNetLib.IWTNovoButton iwtNovoButton1;
        private System.Windows.Forms.GroupBox grbAcessoDiretoCopias;
        private IWTDotNetLib.IWTEntitySelection ensFamiliaDocumento;
        private System.Windows.Forms.Label label1;
    }
} 
