namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadProgramacaoListForm 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioCriacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SituacaoGadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MensagemGadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtExcluirButton1 = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 351);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Panel2.Controls.Add(this.button1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtExcluirButton1);
            this.splitContainer2.Size = new System.Drawing.Size(767, 62);
            this.splitContainer2.SplitterDistance = 493;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(767, 317);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(493, 62);
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
            this.Nome,
            this.DataCriacao,
            this.AcsUsuarioCriacao,
            this.SituacaoGadColumn,
            this.MensagemGadColumn});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(767, 279);
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
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 150;
            // 
            // DataCriacao
            // 
            this.DataCriacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataCriacao.DataPropertyName = "DataCriacao";
            this.DataCriacao.HeaderText = "Data Criação";
            this.DataCriacao.Name = "DataCriacao";
            this.DataCriacao.ReadOnly = true;
            // 
            // AcsUsuarioCriacao
            // 
            this.AcsUsuarioCriacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioCriacao.DataPropertyName = "AcsUsuarioCriacao";
            this.AcsUsuarioCriacao.HeaderText = "Usuário Criação";
            this.AcsUsuarioCriacao.Name = "AcsUsuarioCriacao";
            this.AcsUsuarioCriacao.ReadOnly = true;
            this.AcsUsuarioCriacao.Width = 150;
            // 
            // SituacaoGadColumn
            // 
            this.SituacaoGadColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SituacaoGadColumn.DataPropertyName = "SituacaoGadTraduzida";
            this.SituacaoGadColumn.HeaderText = "Situação GAD";
            this.SituacaoGadColumn.Name = "SituacaoGadColumn";
            this.SituacaoGadColumn.ReadOnly = true;
            // 
            // MensagemGadColumn
            // 
            this.MensagemGadColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MensagemGadColumn.DataPropertyName = "SituacaoGadMensagem";
            this.MensagemGadColumn.HeaderText = "Mensagem GAD";
            this.MensagemGadColumn.MinimumWidth = 100;
            this.MensagemGadColumn.Name = "MensagemGadColumn";
            this.MensagemGadColumn.ReadOnly = true;
            this.MensagemGadColumn.Width = 150;
            // 
            // iwtExcluirButton1
            // 
            this.iwtExcluirButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtExcluirButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtExcluirButton1.Location = new System.Drawing.Point(187, 3);
            this.iwtExcluirButton1.Name = "iwtExcluirButton1";
            this.iwtExcluirButton1.Size = new System.Drawing.Size(75, 25);
            this.iwtExcluirButton1.TabIndex = 2;
            this.iwtExcluirButton1.Text = "Excluir";
            this.iwtExcluirButton1.UseVisualStyleBackColor = true;
            // 
            // iwtEditarButton1
            // 
            this.iwtEditarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtEditarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtEditarButton1.Location = new System.Drawing.Point(108, 3);
            this.iwtEditarButton1.Name = "iwtEditarButton1";
            this.iwtEditarButton1.Size = new System.Drawing.Size(75, 25);
            this.iwtEditarButton1.TabIndex = 1;
            this.iwtEditarButton1.Text = "Editar";
            this.iwtEditarButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::BibliotecaCadastrosBasicos.Properties.Resources.cloud_download_black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(29, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "     Download Documentos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(29, 3);
            this.iwtNovoButton1.Name = "iwtNovoButton1";
            this.iwtNovoButton1.Size = new System.Drawing.Size(75, 25);
            this.iwtNovoButton1.TabIndex = 0;
            this.iwtNovoButton1.Text = "Novo";
            this.iwtNovoButton1.UseVisualStyleBackColor = true;
            // 
            // CadProgramacaoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(767, 413);
            this.Name = "CadProgramacaoListForm";
            this.Text = "Programações";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCriacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioCriacaoColumn;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
        private IWTDotNetLib.IWTExcluirButton iwtExcluirButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioCriacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SituacaoGadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MensagemGadColumn;
        private IWTDotNetLib.IWTNovoButton iwtNovoButton1;
    }
} 
