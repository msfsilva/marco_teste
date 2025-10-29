namespace BibliotecaCadastrosBasicos
{
    partial class CadTransporteListForm
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
            this.iwtDefaultListButtons1 = new IWTDotNetLib.IWTDefaultListButtons();
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Identificacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 339);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.iwtDefaultListButtons1);
            this.splitContainer2.Size = new System.Drawing.Size(612, 62);
            this.splitContainer2.SplitterDistance = 353;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(612, 305);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtDefaultListButtons1
            // 
            this.iwtDefaultListButtons1.Location = new System.Drawing.Point(0, 0);
            this.iwtDefaultListButtons1.Name = "iwtDefaultListButtons1";
            this.iwtDefaultListButtons1.Size = new System.Drawing.Size(255, 62);
            this.iwtDefaultListButtons1.TabIndex = 0;
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
            this.Identificacao,
            this.Descricao,
            this.Placa,
            this.Contato,
            this.Telefone,
            this.Email});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(612, 267);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // Identificacao
            // 
            this.Identificacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Identificacao.DataPropertyName = "Identificacao";
            this.Identificacao.HeaderText = "Identificacao";
            this.Identificacao.Name = "Identificacao";
            this.Identificacao.ReadOnly = true;
            this.Identificacao.Width = 80;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 220;
            // 
            // Placa
            // 
            this.Placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Placa.DataPropertyName = "PlacaSigla";
            this.Placa.HeaderText = "Placa";
            this.Placa.Name = "Placa";
            this.Placa.ReadOnly = true;
            this.Placa.Width = 80;
            // 
            // Contato
            // 
            this.Contato.DataPropertyName = "Contato";
            this.Contato.HeaderText = "Contato";
            this.Contato.Name = "Contato";
            this.Contato.ReadOnly = true;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "Telefone";
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(353, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(55, 20);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(294, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(12, 22);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 0;
            this.iwtLabel1.Text = "Busca";
            // 
            // CadTransporteListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(612, 401);
            this.Name = "CadTransporteListForm";
            this.Text = "Transportes";
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

        private IWTDotNetLib.IWTDefaultListButtons iwtDefaultListButtons1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}