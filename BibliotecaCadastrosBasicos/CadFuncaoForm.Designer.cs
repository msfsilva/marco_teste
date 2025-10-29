using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadFuncaoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEpis = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Identificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoverEpi = new IWTDotNetLib.IWTButton(this.components);
            this.btnAddEpi = new IWTDotNetLib.IWTButton(this.components);
            this.cmbEpi = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox2 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label24 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisao = new IWTDotNetLib.IWTLabel(this.components);
            this.label25 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoData = new IWTDotNetLib.IWTLabel(this.components);
            this.label26 = new IWTDotNetLib.IWTLabel(this.components);
            this.lblRevisaoUsuario = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel4 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox3 = new IWTDotNetLib.IWTTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpis)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox3);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox2);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtTextBox1);
            this.splitContainer1.Panel1.Controls.Add(this.iwtLabel2);
            this.splitContainer1.Size = new System.Drawing.Size(837, 543);
            this.splitContainer1.SplitterDistance = 477;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(750, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvEpis);
            this.groupBox1.Controls.Add(this.btnRemoverEpi);
            this.groupBox1.Controls.Add(this.btnAddEpi);
            this.groupBox1.Controls.Add(this.cmbEpi);
            this.groupBox1.Controls.Add(this.iwtLabel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(813, 244);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "EPIs";
            // 
            // dgvEpis
            // 
            this.dgvEpis.AllowUserToAddRows = false;
            this.dgvEpis.AllowUserToDeleteRows = false;
            this.dgvEpis.AllowUserToOrderColumns = true;
            this.dgvEpis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEpis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEpis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Identificacao,
            this.Descricao});
            this.dgvEpis.Location = new System.Drawing.Point(3, 44);
            this.dgvEpis.MultiSelect = false;
            this.dgvEpis.Name = "dgvEpis";
            this.dgvEpis.ReadOnly = true;
            this.dgvEpis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpis.Size = new System.Drawing.Size(807, 197);
            this.dgvEpis.TabIndex = 14;
            this.dgvEpis.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvEpis_DataError);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Identificacao
            // 
            this.Identificacao.DataPropertyName = "Epi";
            this.Identificacao.HeaderText = "Identificação";
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.ReadOnly = true;
            this.Identificacao.Width = 200;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "EpiDescricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 300;
            // 
            // btnRemoverEpi
            // 
            this.btnRemoverEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoverEpi.LiberadoQuandoCadastroUtilizado = true;
            this.btnRemoverEpi.Location = new System.Drawing.Point(732, 15);
            this.btnRemoverEpi.Name = "btnRemoverEpi";
            this.btnRemoverEpi.Size = new System.Drawing.Size(75, 23);
            this.btnRemoverEpi.TabIndex = 13;
            this.btnRemoverEpi.Text = "Remover";
            this.btnRemoverEpi.UseVisualStyleBackColor = true;
            this.btnRemoverEpi.Click += new System.EventHandler(this.btnRemoverEpi_Click);
            // 
            // btnAddEpi
            // 
            this.btnAddEpi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEpi.LiberadoQuandoCadastroUtilizado = true;
            this.btnAddEpi.Location = new System.Drawing.Point(651, 15);
            this.btnAddEpi.Name = "btnAddEpi";
            this.btnAddEpi.Size = new System.Drawing.Size(75, 23);
            this.btnAddEpi.TabIndex = 12;
            this.btnAddEpi.Text = "Adicionar";
            this.btnAddEpi.UseVisualStyleBackColor = true;
            this.btnAddEpi.Click += new System.EventHandler(this.btnAddEpi_Click);
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
            this.cmbEpi.LiberadoQuandoCadastroUtilizado = true;
            this.cmbEpi.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbEpi.Location = new System.Drawing.Point(77, 17);
            this.cmbEpi.Name = "cmbEpi";
            this.cmbEpi.SelectedRow = null;
            this.cmbEpi.Size = new System.Drawing.Size(568, 21);
            this.cmbEpi.TabIndex = 10;
            this.cmbEpi.Table = null;
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(49, 20);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(22, 13);
            this.iwtLabel3.TabIndex = 11;
            this.iwtLabel3.Text = "Epi";
            // 
            // iwtTextBox2
            // 
            this.iwtTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox2.BindingField = "Descricao";
            this.iwtTextBox2.DebugMode = false;
            this.iwtTextBox2.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox2.Location = new System.Drawing.Point(136, 56);
            this.iwtTextBox2.ModoBarcode = false;
            this.iwtTextBox2.ModoBusca = false;
            this.iwtTextBox2.Name = "iwtTextBox2";
            this.iwtTextBox2.NaoLimparDepoisBarcode = false;
            this.iwtTextBox2.Size = new System.Drawing.Size(352, 20);
            this.iwtTextBox2.TabIndex = 16;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(75, 59);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(55, 13);
            this.iwtLabel1.TabIndex = 15;
            this.iwtLabel1.Text = "Descrição";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox1.BindingField = "Identificacao";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(136, 30);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(352, 20);
            this.iwtTextBox1.TabIndex = 14;
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(62, 33);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(68, 13);
            this.iwtLabel2.TabIndex = 13;
            this.iwtLabel2.Text = "Identificação";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.lblRevisao);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.lblRevisaoData);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.lblRevisaoUsuario);
            this.groupBox2.Location = new System.Drawing.Point(494, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 94);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Revisão";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BindingField = null;
            this.label24.LiberadoQuandoCadastroUtilizado = false;
            this.label24.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label24.Location = new System.Drawing.Point(28, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 6;
            this.label24.Text = "Usuário";
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.BindingField = "UltimaRevisao";
            this.lblRevisao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisao.Location = new System.Drawing.Point(111, 73);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(0, 13);
            this.lblRevisao.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BindingField = null;
            this.label25.LiberadoQuandoCadastroUtilizado = false;
            this.label25.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label25.Location = new System.Drawing.Point(41, 45);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(30, 13);
            this.label25.TabIndex = 7;
            this.label25.Text = "Data";
            // 
            // lblRevisaoData
            // 
            this.lblRevisaoData.AutoSize = true;
            this.lblRevisaoData.BindingField = "UltimaRevisaoData";
            this.lblRevisaoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisaoData.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoData.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoData.Location = new System.Drawing.Point(111, 45);
            this.lblRevisaoData.Name = "lblRevisaoData";
            this.lblRevisaoData.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoData.TabIndex = 10;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BindingField = null;
            this.label26.LiberadoQuandoCadastroUtilizado = false;
            this.label26.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label26.Location = new System.Drawing.Point(9, 73);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(62, 13);
            this.label26.TabIndex = 8;
            this.label26.Text = "Justificativa";
            // 
            // lblRevisaoUsuario
            // 
            this.lblRevisaoUsuario.AutoSize = true;
            this.lblRevisaoUsuario.BindingField = "UltimaRevisaoUsuario";
            this.lblRevisaoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevisaoUsuario.LiberadoQuandoCadastroUtilizado = false;
            this.lblRevisaoUsuario.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.lblRevisaoUsuario.Location = new System.Drawing.Point(111, 17);
            this.lblRevisaoUsuario.Name = "lblRevisaoUsuario";
            this.lblRevisaoUsuario.Size = new System.Drawing.Size(0, 13);
            this.lblRevisaoUsuario.TabIndex = 9;
            // 
            // iwtLabel4
            // 
            this.iwtLabel4.AutoSize = true;
            this.iwtLabel4.BindingField = null;
            this.iwtLabel4.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel4.Location = new System.Drawing.Point(28, 89);
            this.iwtLabel4.Name = "iwtLabel4";
            this.iwtLabel4.Size = new System.Drawing.Size(102, 13);
            this.iwtLabel4.TabIndex = 19;
            this.iwtLabel4.Text = "Descrição Completa";
            // 
            // iwtTextBox3
            // 
            this.iwtTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtTextBox3.BindingField = "DescricaoCompleta";
            this.iwtTextBox3.DebugMode = false;
            this.iwtTextBox3.LiberadoQuandoCadastroUtilizado = true;
            this.iwtTextBox3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox3.Location = new System.Drawing.Point(136, 86);
            this.iwtTextBox3.ModoBarcode = false;
            this.iwtTextBox3.ModoBusca = false;
            this.iwtTextBox3.Multiline = true;
            this.iwtTextBox3.Name = "iwtTextBox3";
            this.iwtTextBox3.NaoLimparDepoisBarcode = false;
            this.iwtTextBox3.Size = new System.Drawing.Size(352, 138);
            this.iwtTextBox3.TabIndex = 20;
            // 
            // CadFuncaoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(837, 543);
            this.Name = "CadFuncaoForm";
            this.Text = "Função";
            this.Shown += new System.EventHandler(this.CadFuncaoForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpis)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEpis;
        private IWTButton btnRemoverEpi;
        private IWTButton btnAddEpi;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbEpi;
        private IWTDotNetLib.IWTLabel iwtLabel3;
        private IWTDotNetLib.IWTTextBox iwtTextBox2;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.GroupBox groupBox2;
        private IWTDotNetLib.IWTLabel label24;
        private IWTDotNetLib.IWTLabel lblRevisao;
        private IWTDotNetLib.IWTLabel label25;
        private IWTDotNetLib.IWTLabel lblRevisaoData;
        private IWTDotNetLib.IWTLabel label26;
        private IWTDotNetLib.IWTLabel lblRevisaoUsuario;
        private IWTTextBox iwtTextBox3;
        private IWTLabel iwtLabel4;
    }
}