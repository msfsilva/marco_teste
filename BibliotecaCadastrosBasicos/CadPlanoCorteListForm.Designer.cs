namespace BibliotecaCadastrosBasicos
{
    partial class CadPlanoCorteListForm
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
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cancelado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CancelamentoJustificativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CancelamentoData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.btnImprimir = new IWTDotNetLib.IWTButton(this.components);
            this.iwtEditarButton1 = new IWTDotNetLib.IWTEditarButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 243);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.iwtEditarButton1);
            this.splitContainer2.Panel2.Controls.Add(this.btnImprimir);
            this.splitContainer2.Size = new System.Drawing.Size(648, 62);
            this.splitContainer2.SplitterDistance = 322;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(645, 209);
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
            this.Numero,
            this.Data,
            this.Usuario,
            this.Cancelado,
            this.CancelamentoJustificativa,
            this.CancelamentoData,
            this.AcsUsuarioCancelamento});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.MultiSelect = false;
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(645, 171);
            this.iwtDataGridView1.TabIndex = 0;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "ID";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Width = 150;
            // 
            // Data
            // 
            this.Data.DataPropertyName = "Data";
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "AcsUsuario";
            this.Usuario.HeaderText = "Usuário";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 150;
            // 
            // Cancelado
            // 
            this.Cancelado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cancelado.DataPropertyName = "Cancelado";
            this.Cancelado.HeaderText = "Cancelado";
            this.Cancelado.Name = "Cancelado";
            this.Cancelado.ReadOnly = true;
            this.Cancelado.Width = 70;
            // 
            // CancelamentoJustificativa
            // 
            this.CancelamentoJustificativa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CancelamentoJustificativa.DataPropertyName = "CancelamentoJustificativa";
            this.CancelamentoJustificativa.HeaderText = "Cancelamento Justificativa";
            this.CancelamentoJustificativa.Name = "CancelamentoJustificativa";
            this.CancelamentoJustificativa.ReadOnly = true;
            this.CancelamentoJustificativa.Width = 150;
            // 
            // CancelamentoData
            // 
            this.CancelamentoData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CancelamentoData.DataPropertyName = "CancelamentoData";
            this.CancelamentoData.HeaderText = "Cancelamento Data";
            this.CancelamentoData.Name = "CancelamentoData";
            this.CancelamentoData.ReadOnly = true;
            // 
            // AcsUsuarioCancelamento
            // 
            this.AcsUsuarioCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioCancelamento.DataPropertyName = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.HeaderText = "Usuário Cancelamento";
            this.AcsUsuarioCancelamento.Name = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.ReadOnly = true;
            this.AcsUsuarioCancelamento.Width = 150;
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(322, 62);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(3, 25);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 1;
            this.iwtLabel1.Text = "Busca";
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaNumero";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(46, 22);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(261, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.LiberadoQuandoCadastroUtilizado = false;
            this.btnImprimir.Location = new System.Drawing.Point(163, 20);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // iwtEditarButton1
            // 
            this.iwtEditarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtEditarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtEditarButton1.Location = new System.Drawing.Point(65, 20);
            this.iwtEditarButton1.Name = "iwtEditarButton1";
            this.iwtEditarButton1.Size = new System.Drawing.Size(92, 23);
            this.iwtEditarButton1.TabIndex = 0;
            this.iwtEditarButton1.Text = "Visualizar Itens";
            this.iwtEditarButton1.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(244, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CadPlanoCorteListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(648, 305);
            this.Name = "CadPlanoCorteListForm";
            this.Text = "Planos de Corte";
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
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Cancelado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CancelamentoJustificativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn CancelamentoData;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioCancelamento;
        private IWTDotNetLib.IWTButton btnImprimir;
        private IWTDotNetLib.IWTButton btnCancelar;
        private IWTDotNetLib.IWTEditarButton iwtEditarButton1;
    }
}