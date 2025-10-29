namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadContaBancariaListForm 
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
            this.NomeBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtSelecionarButton1 = new IWTDotNetLib.IWTSelecionarButton(this.components);
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 274);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.iwtSelecionarButton1);
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
            this.iwtTextBox1.BindingField = "BuscaCompleta";
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
            this.Identificacao,
            this.NomeBanco,
            this.Agencia,
            this.NumeroConta,
            this.CodigoBanco});
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
            this.ID.HeaderText = "C�digo";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 70;
            // 
            // Identificacao
            // 
            this.Identificacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Identificacao.DataPropertyName = "Identificacao";
            this.Identificacao.HeaderText = "Identifica��o";
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.ReadOnly = true;
            this.Identificacao.Width = 150;
            // 
            // NomeBanco
            // 
            this.NomeBanco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NomeBanco.DataPropertyName = "NomeBanco";
            this.NomeBanco.HeaderText = "Banco";
            this.NomeBanco.Name = "NomeBanco";
            this.NomeBanco.ReadOnly = true;
            this.NomeBanco.Width = 150;
            // 
            // Agencia
            // 
            this.Agencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Agencia.DataPropertyName = "Agencia";
            this.Agencia.HeaderText = "Ag�ncia";
            this.Agencia.Name = "Agencia";
            this.Agencia.ReadOnly = true;
            this.Agencia.Width = 150;
            // 
            // NumeroConta
            // 
            this.NumeroConta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroConta.DataPropertyName = "NumeroConta";
            this.NumeroConta.HeaderText = "N�mero da Conta";
            this.NumeroConta.Name = "NumeroConta";
            this.NumeroConta.ReadOnly = true;
            this.NumeroConta.Width = 150;
            // 
            // CodigoBanco
            // 
            this.CodigoBanco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoBanco.DataPropertyName = "CodigoBanco";
            this.CodigoBanco.HeaderText = "C�digo do Banco";
            this.CodigoBanco.Name = "CodigoBanco";
            this.CodigoBanco.ReadOnly = true;
            this.CodigoBanco.Visible = false;
            this.CodigoBanco.Width = 150;
            // 
            // iwtSelecionarButton1
            // 
            this.iwtSelecionarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtSelecionarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtSelecionarButton1.Location = new System.Drawing.Point(168, 20);
            this.iwtSelecionarButton1.Name = "iwtSelecionarButton1";
            this.iwtSelecionarButton1.Size = new System.Drawing.Size(90, 23);
            this.iwtSelecionarButton1.TabIndex = 0;
            this.iwtSelecionarButton1.Text = "&Selecionar";
            this.iwtSelecionarButton1.UseVisualStyleBackColor = true;
            // 
            // CadContaBancariaListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 336);
            this.Name = "CadContaBancariaListForm";
            this.Text = "Contas Banc�rias";
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
        private IWTDotNetLib.IWTSelecionarButton iwtSelecionarButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroConta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBanco;
    }
} 
