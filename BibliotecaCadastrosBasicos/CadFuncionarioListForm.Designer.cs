namespace BibliotecaCadastrosBasicos
{
    partial class CadFuncionarioListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.rdbInativos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbAtivos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataAdmissaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataDemissaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AtivoColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.iwtNovoButton1 = new IWTDotNetLib.IWTNovoButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.iwtExcluirButton1 = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.btnDemitir = new System.Windows.Forms.Button();
            this.btnResumoEPI = new System.Windows.Forms.Button();
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 249);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnResumoEPI);
            this.splitContainer2.Panel2.Controls.Add(this.btnDemitir);
            this.splitContainer2.Panel2.Controls.Add(this.iwtExcluirButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.iwtNovoButton1);
            this.splitContainer2.Size = new System.Drawing.Size(582, 87);
            this.splitContainer2.SplitterDistance = 308;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(582, 215);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
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
            this.iwtSearchPanel1.Size = new System.Drawing.Size(308, 87);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // rdbInativos
            // 
            this.rdbInativos.AutoSize = true;
            this.rdbInativos.BindingField = null;
            this.rdbInativos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbInativos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbInativos.Location = new System.Drawing.Point(236, 46);
            this.rdbInativos.Name = "rdbInativos";
            this.rdbInativos.Size = new System.Drawing.Size(62, 17);
            this.rdbInativos.TabIndex = 3;
            this.rdbInativos.Text = "Inativos";
            this.rdbInativos.UseVisualStyleBackColor = true;
            // 
            // rdbAtivos
            // 
            this.rdbAtivos.AutoSize = true;
            this.rdbAtivos.BindingField = "Ativo";
            this.rdbAtivos.Checked = true;
            this.rdbAtivos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAtivos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAtivos.Location = new System.Drawing.Point(236, 23);
            this.rdbAtivos.Name = "rdbAtivos";
            this.rdbAtivos.Size = new System.Drawing.Size(54, 17);
            this.rdbAtivos.TabIndex = 2;
            this.rdbAtivos.TabStop = true;
            this.rdbAtivos.Text = "Ativos";
            this.rdbAtivos.UseVisualStyleBackColor = true;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 32);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(174, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 35);
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
            this.Rg,
            this.CPF,
            this.Fone1,
            this.DataAdmissaoColumn,
            this.DataDemissaoColumn,
            this.AtivoColumn});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(582, 177);
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
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Width = 200;
            // 
            // Rg
            // 
            this.Rg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Rg.DataPropertyName = "Rg";
            this.Rg.HeaderText = "RG";
            this.Rg.Name = "Rg";
            this.Rg.ReadOnly = true;
            // 
            // CPF
            // 
            this.CPF.DataPropertyName = "Cpf";
            this.CPF.HeaderText = "CPF";
            this.CPF.Name = "CPF";
            this.CPF.ReadOnly = true;
            this.CPF.Width = 120;
            // 
            // Fone1
            // 
            this.Fone1.DataPropertyName = "Fone1";
            this.Fone1.HeaderText = "Fone1";
            this.Fone1.Name = "Fone1";
            this.Fone1.ReadOnly = true;
            this.Fone1.Width = 110;
            // 
            // DataAdmissaoColumn
            // 
            this.DataAdmissaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataAdmissaoColumn.DataPropertyName = "DataAdmissao";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.DataAdmissaoColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataAdmissaoColumn.HeaderText = "Data de Admissão";
            this.DataAdmissaoColumn.Name = "DataAdmissaoColumn";
            this.DataAdmissaoColumn.ReadOnly = true;
            this.DataAdmissaoColumn.Visible = false;
            this.DataAdmissaoColumn.Width = 80;
            // 
            // DataDemissaoColumn
            // 
            this.DataDemissaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataDemissaoColumn.DataPropertyName = "DataDemissao";
            dataGridViewCellStyle2.Format = "d";
            this.DataDemissaoColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataDemissaoColumn.HeaderText = "Data de Demissão";
            this.DataDemissaoColumn.Name = "DataDemissaoColumn";
            this.DataDemissaoColumn.ReadOnly = true;
            this.DataDemissaoColumn.Visible = false;
            this.DataDemissaoColumn.Width = 80;
            // 
            // AtivoColumn
            // 
            this.AtivoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AtivoColumn.DataPropertyName = "Ativo";
            this.AtivoColumn.HeaderText = "Ativo";
            this.AtivoColumn.Name = "AtivoColumn";
            this.AtivoColumn.ReadOnly = true;
            this.AtivoColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AtivoColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AtivoColumn.Visible = false;
            this.AtivoColumn.Width = 80;
            // 
            // iwtNovoButton1
            // 
            this.iwtNovoButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtNovoButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtNovoButton1.Location = new System.Drawing.Point(16, 8);
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
            this.iwtEditarButton1.Location = new System.Drawing.Point(97, 8);
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
            this.iwtExcluirButton1.Location = new System.Drawing.Point(178, 8);
            this.iwtExcluirButton1.Name = "iwtExcluirButton1";
            this.iwtExcluirButton1.Size = new System.Drawing.Size(75, 23);
            this.iwtExcluirButton1.TabIndex = 2;
            this.iwtExcluirButton1.Text = "Excluir";
            this.iwtExcluirButton1.UseVisualStyleBackColor = true;
            // 
            // btnDemitir
            // 
            this.btnDemitir.Location = new System.Drawing.Point(16, 35);
            this.btnDemitir.Name = "btnDemitir";
            this.btnDemitir.Size = new System.Drawing.Size(237, 23);
            this.btnDemitir.TabIndex = 3;
            this.btnDemitir.Text = "Demitir Funcionário";
            this.btnDemitir.UseVisualStyleBackColor = true;
            this.btnDemitir.Click += new System.EventHandler(this.btnDemitir_Click);
            // 
            // btnResumoEPI
            // 
            this.btnResumoEPI.Location = new System.Drawing.Point(16, 61);
            this.btnResumoEPI.Name = "btnResumoEPI";
            this.btnResumoEPI.Size = new System.Drawing.Size(237, 23);
            this.btnResumoEPI.TabIndex = 4;
            this.btnResumoEPI.Text = "Resumo de Utilização de EPI";
            this.btnResumoEPI.UseVisualStyleBackColor = true;
            this.btnResumoEPI.Click += new System.EventHandler(this.btnResumoEPI_Click);
            // 
            // CadFuncionarioListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(582, 336);
            this.Name = "CadFuncionarioListForm";
            this.Text = "Funcionários";
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
        private IWTDotNetLib.IWTRadioButton rdbAtivos;
        private IWTDotNetLib.IWTRadioButton rdbInativos;
        private IWTDotNetLib.IWTExcluirButton iwtExcluirButton1;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
        private IWTDotNetLib.IWTNovoButton iwtNovoButton1;
        private System.Windows.Forms.Button btnDemitir;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rg;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataAdmissaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataDemissaoColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AtivoColumn;
        private System.Windows.Forms.Button btnResumoEPI;
    }
}