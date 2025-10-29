namespace BibliotecaCadastrosBasicos
{
    partial class CadGerenciamentoEpiFuncionarioForm
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
            this.ensFuncionario = new IWTDotNetLib.IWTEntitySelection(this.components);
            this.grbEpi = new System.Windows.Forms.GroupBox();
            this.iwtLabel11 = new IWTDotNetLib.IWTLabel(this.components);
            this.nudQtdEpi = new IWTDotNetLib.IWTNumericUpDown(this.components);
            this.rdbTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbDescart = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbVenc = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbRet = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbPendRet = new IWTDotNetLib.IWTRadioButton(this.components);
            this.btnRemoverEpi = new IWTDotNetLib.IWTButton(this.components);
            this.btnAddEpi = new IWTDotNetLib.IWTButton(this.components);
            this.btnRetiradaEpi = new IWTDotNetLib.IWTButton(this.components);
            this.dgvEpi = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRetirada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataVencimentoPrevista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataDescarte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbEpi = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnSalvar = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.grbEpi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdEpi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).BeginInit();
            this.SuspendLayout();
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 16);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Funcionário";
            // 
            // ensFuncionario
            // 
            this.ensFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ensFuncionario.BindingField = null;
            this.ensFuncionario.ColunasDropdown = null;
            this.ensFuncionario.DesabilitarAutoCompletar = false;
            this.ensFuncionario.DesabilitarChekBox = true;
            this.ensFuncionario.DesabilitarLupa = true;
            this.ensFuncionario.DesabilitarSeta = false;
            this.ensFuncionario.EntidadeSelecionada = null;
            this.ensFuncionario.FormSelecao = null;
            this.ensFuncionario.LiberadoQuandoCadastroUtilizado = false;
            this.ensFuncionario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.ensFuncionario.Location = new System.Drawing.Point(80, 12);
            this.ensFuncionario.ModoVisualizacaoGrid = null;
            this.ensFuncionario.Name = "ensFuncionario";
            this.ensFuncionario.ParametroBuscaGuiada = null;
            this.ensFuncionario.ParametrosBuscaObrigatorios = null;
            this.ensFuncionario.Size = new System.Drawing.Size(637, 23);
            this.ensFuncionario.TabIndex = 0;
            this.ensFuncionario.EntityChange += new System.EventHandler(this.ensFuncionario_EntityChange);
            // 
            // grbEpi
            // 
            this.grbEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbEpi.Controls.Add(this.iwtLabel11);
            this.grbEpi.Controls.Add(this.nudQtdEpi);
            this.grbEpi.Controls.Add(this.rdbTodos);
            this.grbEpi.Controls.Add(this.rdbDescart);
            this.grbEpi.Controls.Add(this.rdbVenc);
            this.grbEpi.Controls.Add(this.rdbRet);
            this.grbEpi.Controls.Add(this.rdbPendRet);
            this.grbEpi.Controls.Add(this.btnRemoverEpi);
            this.grbEpi.Controls.Add(this.btnAddEpi);
            this.grbEpi.Controls.Add(this.btnRetiradaEpi);
            this.grbEpi.Controls.Add(this.dgvEpi);
            this.grbEpi.Controls.Add(this.cmbEpi);
            this.grbEpi.Controls.Add(this.iwtLabel4);
            this.grbEpi.Enabled = false;
            this.grbEpi.Location = new System.Drawing.Point(5, 51);
            this.grbEpi.Name = "grbEpi";
            this.grbEpi.Size = new System.Drawing.Size(722, 525);
            this.grbEpi.TabIndex = 1;
            this.grbEpi.TabStop = false;
            this.grbEpi.Text = "EPIs";
            // 
            // iwtLabel11
            // 
            this.iwtLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtLabel11.AutoSize = true;
            this.iwtLabel11.BindingField = null;
            this.iwtLabel11.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel11.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel11.Location = new System.Drawing.Point(410, 24);
            this.iwtLabel11.Name = "iwtLabel11";
            this.iwtLabel11.Size = new System.Drawing.Size(62, 13);
            this.iwtLabel11.TabIndex = 26;
            this.iwtLabel11.Text = "Quantidade";
            // 
            // nudQtdEpi
            // 
            this.nudQtdEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudQtdEpi.BindingField = null;
            this.nudQtdEpi.LiberadoQuandoCadastroUtilizado = false;
            this.nudQtdEpi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.nudQtdEpi.Location = new System.Drawing.Point(478, 21);
            this.nudQtdEpi.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudQtdEpi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtdEpi.Name = "nudQtdEpi";
            this.nudQtdEpi.Size = new System.Drawing.Size(76, 20);
            this.nudQtdEpi.TabIndex = 1;
            this.nudQtdEpi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rdbTodos
            // 
            this.rdbTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.BindingField = null;
            this.rdbTodos.Checked = true;
            this.rdbTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodos.Location = new System.Drawing.Point(388, 502);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 10;
            this.rdbTodos.TabStop = true;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            this.rdbTodos.CheckedChanged += new System.EventHandler(this.rdbTodos_CheckedChanged);
            // 
            // rdbDescart
            // 
            this.rdbDescart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbDescart.AutoSize = true;
            this.rdbDescart.BindingField = null;
            this.rdbDescart.LiberadoQuandoCadastroUtilizado = false;
            this.rdbDescart.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbDescart.Location = new System.Drawing.Point(297, 502);
            this.rdbDescart.Name = "rdbDescart";
            this.rdbDescart.Size = new System.Drawing.Size(85, 17);
            this.rdbDescart.TabIndex = 9;
            this.rdbDescart.Text = "Descartados";
            this.rdbDescart.UseVisualStyleBackColor = true;
            this.rdbDescart.CheckedChanged += new System.EventHandler(this.rdbDescart_CheckedChanged);
            // 
            // rdbVenc
            // 
            this.rdbVenc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbVenc.AutoSize = true;
            this.rdbVenc.BindingField = null;
            this.rdbVenc.LiberadoQuandoCadastroUtilizado = false;
            this.rdbVenc.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbVenc.Location = new System.Drawing.Point(222, 501);
            this.rdbVenc.Name = "rdbVenc";
            this.rdbVenc.Size = new System.Drawing.Size(69, 17);
            this.rdbVenc.TabIndex = 7;
            this.rdbVenc.Text = "Vencidos";
            this.rdbVenc.UseVisualStyleBackColor = true;
            this.rdbVenc.CheckedChanged += new System.EventHandler(this.rdbVenc_CheckedChanged);
            // 
            // rdbRet
            // 
            this.rdbRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbRet.AutoSize = true;
            this.rdbRet.BindingField = null;
            this.rdbRet.LiberadoQuandoCadastroUtilizado = false;
            this.rdbRet.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbRet.Location = new System.Drawing.Point(146, 501);
            this.rdbRet.Name = "rdbRet";
            this.rdbRet.Size = new System.Drawing.Size(70, 17);
            this.rdbRet.TabIndex = 6;
            this.rdbRet.Text = "Retirados";
            this.rdbRet.UseVisualStyleBackColor = true;
            this.rdbRet.CheckedChanged += new System.EventHandler(this.rdbRet_CheckedChanged);
            // 
            // rdbPendRet
            // 
            this.rdbPendRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rdbPendRet.AutoSize = true;
            this.rdbPendRet.BindingField = null;
            this.rdbPendRet.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPendRet.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPendRet.Location = new System.Drawing.Point(6, 501);
            this.rdbPendRet.Name = "rdbPendRet";
            this.rdbPendRet.Size = new System.Drawing.Size(134, 17);
            this.rdbPendRet.TabIndex = 5;
            this.rdbPendRet.Text = "Pendentes de Retirada";
            this.rdbPendRet.UseVisualStyleBackColor = true;
            this.rdbPendRet.CheckedChanged += new System.EventHandler(this.rdbPendRet_CheckedChanged);
            // 
            // btnRemoverEpi
            // 
            this.btnRemoverEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverEpi.LiberadoQuandoCadastroUtilizado = false;
            this.btnRemoverEpi.Location = new System.Drawing.Point(641, 18);
            this.btnRemoverEpi.Name = "btnRemoverEpi";
            this.btnRemoverEpi.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverEpi.TabIndex = 3;
            this.btnRemoverEpi.Text = "Descartar";
            this.btnRemoverEpi.UseVisualStyleBackColor = true;
            this.btnRemoverEpi.Click += new System.EventHandler(this.btnRemoverEpi_Click);
            // 
            // btnAddEpi
            // 
            this.btnAddEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEpi.LiberadoQuandoCadastroUtilizado = false;
            this.btnAddEpi.Location = new System.Drawing.Point(560, 18);
            this.btnAddEpi.Name = "btnAddEpi";
            this.btnAddEpi.Size = new System.Drawing.Size(75, 23);
            this.btnAddEpi.TabIndex = 2;
            this.btnAddEpi.Text = "Adicionar";
            this.btnAddEpi.UseVisualStyleBackColor = true;
            this.btnAddEpi.Click += new System.EventHandler(this.btnAddEpi_Click);
            // 
            // btnRetiradaEpi
            // 
            this.btnRetiradaEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRetiradaEpi.LiberadoQuandoCadastroUtilizado = false;
            this.btnRetiradaEpi.Location = new System.Drawing.Point(612, 499);
            this.btnRetiradaEpi.Name = "btnRetiradaEpi";
            this.btnRetiradaEpi.Size = new System.Drawing.Size(104, 23);
            this.btnRetiradaEpi.TabIndex = 15;
            this.btnRetiradaEpi.Text = "Retirada de EPIs";
            this.btnRetiradaEpi.UseVisualStyleBackColor = true;
            this.btnRetiradaEpi.Click += new System.EventHandler(this.btnRetiradaEpi_Click);
            // 
            // dgvEpi
            // 
            this.dgvEpi.AllowUserToAddRows = false;
            this.dgvEpi.AllowUserToDeleteRows = false;
            this.dgvEpi.AllowUserToOrderColumns = true;
            this.dgvEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEpi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.DataRetirada,
            this.DataVencimentoPrevista,
            this.DataDescarte,
            this.Situacao});
            this.dgvEpi.Location = new System.Drawing.Point(6, 48);
            this.dgvEpi.Name = "dgvEpi";
            this.dgvEpi.ReadOnly = true;
            this.dgvEpi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpi.Size = new System.Drawing.Size(716, 444);
            this.dgvEpi.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Epi";
            this.dataGridViewTextBoxColumn2.HeaderText = "EPI";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // DataRetirada
            // 
            this.DataRetirada.DataPropertyName = "DataRetirada";
            this.DataRetirada.HeaderText = "Data Retirada";
            this.DataRetirada.Name = "DataRetirada";
            this.DataRetirada.ReadOnly = true;
            this.DataRetirada.Width = 150;
            // 
            // DataVencimentoPrevista
            // 
            this.DataVencimentoPrevista.DataPropertyName = "DataVencimentoPrevista";
            this.DataVencimentoPrevista.HeaderText = "Substituir Até";
            this.DataVencimentoPrevista.Name = "DataVencimentoPrevista";
            this.DataVencimentoPrevista.ReadOnly = true;
            this.DataVencimentoPrevista.Width = 150;
            // 
            // DataDescarte
            // 
            this.DataDescarte.DataPropertyName = "DataDescarte";
            this.DataDescarte.HeaderText = "Data Descarte";
            this.DataDescarte.Name = "DataDescarte";
            this.DataDescarte.ReadOnly = true;
            this.DataDescarte.Width = 150;
            // 
            // Situacao
            // 
            this.Situacao.DataPropertyName = "Situacao";
            this.Situacao.HeaderText = "Situação";
            this.Situacao.Name = "Situacao";
            this.Situacao.ReadOnly = true;
            this.Situacao.Width = 150;
            // 
            // cmbEpi
            // 
            this.cmbEpi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEpi.BindingField = null;
            this.cmbEpi.ColumnsToDisplay = null;
            this.cmbEpi.DisableAutoSelectOnEmpty = false;
            this.cmbEpi.DropDownHeight = 1;
            this.cmbEpi.FormattingEnabled = true;
            this.cmbEpi.IntegralHeight = false;
            this.cmbEpi.LiberadoQuandoCadastroUtilizado = false;
            this.cmbEpi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbEpi.Location = new System.Drawing.Point(41, 21);
            this.cmbEpi.Name = "cmbEpi";
            this.cmbEpi.SelectedRow = null;
            this.cmbEpi.Size = new System.Drawing.Size(352, 21);
            this.cmbEpi.TabIndex = 0;
            this.cmbEpi.Table = null;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(13, 24);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(22, 13);
            this.iwtLabel4.TabIndex = 11;
            this.iwtLabel4.Text = "Epi";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.LiberadoQuandoCadastroUtilizado = false;
            this.btnSalvar.Location = new System.Drawing.Point(646, 590);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(12, 590);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CadGerenciamentoEpiFuncionarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 625);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.grbEpi);
            this.Controls.Add(this.ensFuncionario);
            this.Controls.Add(this.iwtLabel1);
            this.Name = "CadGerenciamentoEpiFuncionarioForm";
            this.Text = "Gerenciamento de EPIs dos Funcionários";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadGerenciamentoEpiFuncionarioForm_FormClosing);
            this.grbEpi.ResumeLayout(false);
            this.grbEpi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtdEpi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTEntitySelection ensFuncionario;
        private System.Windows.Forms.GroupBox grbEpi;
        private IWTDotNetLib.IWTLabel iwtLabel11;
        private IWTDotNetLib.IWTNumericUpDown nudQtdEpi;
        private IWTDotNetLib.IWTRadioButton rdbTodos;
        private IWTDotNetLib.IWTRadioButton rdbDescart;
        private IWTDotNetLib.IWTRadioButton rdbVenc;
        private IWTDotNetLib.IWTRadioButton rdbRet;
        private IWTDotNetLib.IWTRadioButton rdbPendRet;
        private IWTDotNetLib.IWTButton btnRemoverEpi;
        private IWTDotNetLib.IWTButton btnAddEpi;
        private IWTDotNetLib.IWTButton btnRetiradaEpi;
        private System.Windows.Forms.DataGridView dgvEpi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRetirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataVencimentoPrevista;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataDescarte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbEpi;
        private IWTDotNetLib.IWTLabel iwtLabel4;
        private IWTDotNetLib.IWTButton btnSalvar;
        private IWTDotNetLib.IWTButton btnCancelar;
    }
}