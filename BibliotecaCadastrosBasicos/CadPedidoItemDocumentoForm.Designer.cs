using System.Windows.Forms;

namespace BibliotecaCadastrosBasicos
{
    partial class CadPedidoItemDocumentoForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.btnOk = new IWTDotNetLib.IWTButton(this.components);
            this.btnExcluir = new IWTDotNetLib.IWTButton(this.components);
            this.txtRevisao = new IWTDotNetLib.IWTTextBox(this.components);
            this.label4 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtIdentificacao = new IWTDotNetLib.IWTTextBox(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.txtFamilia = new IWTDotNetLib.IWTTextBox(this.components);
            this.label2 = new IWTDotNetLib.IWTLabel(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.cmbItem = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.btnFechar = new IWTDotNetLib.IWTButton(this.components);
            this.PedidoItemSubLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoItemProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnFechar);
            this.splitContainer1.Size = new System.Drawing.Size(649, 479);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnOk);
            this.splitContainer2.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer2.Panel2.Controls.Add(this.txtRevisao);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.txtIdentificacao);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.txtFamilia);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Controls.Add(this.cmbItem);
            this.splitContainer2.Size = new System.Drawing.Size(649, 411);
            this.splitContainer2.SplitterDistance = 467;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.CacheDados = null;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PedidoItemSubLinha,
            this.PedidoItemProduto,
            this.Tipo,
            this.Codigo,
            this.Revisao});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(467, 411);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.LiberadoQuandoCadastroUtilizado = false;
            this.btnOk.Location = new System.Drawing.Point(91, 209);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.LiberadoQuandoCadastroUtilizado = false;
            this.btnExcluir.Location = new System.Drawing.Point(91, 373);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtRevisao
            // 
            this.txtRevisao.BindingField = null;
            this.txtRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.txtRevisao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtRevisao.Location = new System.Drawing.Point(12, 183);
            this.txtRevisao.Name = "txtRevisao";
            this.txtRevisao.Size = new System.Drawing.Size(154, 20);
            this.txtRevisao.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BindingField = null;
            this.label4.LiberadoQuandoCadastroUtilizado = false;
            this.label4.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label4.Location = new System.Drawing.Point(9, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Revisão";
            // 
            // txtIdentificacao
            // 
            this.txtIdentificacao.BindingField = null;
            this.txtIdentificacao.LiberadoQuandoCadastroUtilizado = false;
            this.txtIdentificacao.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtIdentificacao.Location = new System.Drawing.Point(12, 131);
            this.txtIdentificacao.Name = "txtIdentificacao";
            this.txtIdentificacao.Size = new System.Drawing.Size(154, 20);
            this.txtIdentificacao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(9, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Identificação";
            // 
            // txtFamilia
            // 
            this.txtFamilia.BindingField = null;
            this.txtFamilia.LiberadoQuandoCadastroUtilizado = false;
            this.txtFamilia.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtFamilia.Location = new System.Drawing.Point(12, 79);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(154, 20);
            this.txtFamilia.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BindingField = null;
            this.label2.LiberadoQuandoCadastroUtilizado = false;
            this.label2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Familia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item";
            // 
            // cmbItem
            // 
            this.cmbItem.BindingField = null;
            this.cmbItem.ColumnsToDisplay = null;
            this.cmbItem.DropDownHeight = 1;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.IntegralHeight = false;
            this.cmbItem.LiberadoQuandoCadastroUtilizado = false;
            this.cmbItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbItem.Location = new System.Drawing.Point(12, 26);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.SelectedRow = null;
            this.cmbItem.Size = new System.Drawing.Size(154, 21);
            this.cmbItem.TabIndex = 0;
            this.cmbItem.Table = null;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.LiberadoQuandoCadastroUtilizado = false;
            this.btnFechar.Location = new System.Drawing.Point(562, 21);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // PedidoItemSubLinha
            // 
            this.PedidoItemSubLinha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PedidoItemSubLinha.DataPropertyName = "PedidoItemSubLinha";
            this.PedidoItemSubLinha.HeaderText = "Sublinha";
            this.PedidoItemSubLinha.Name = "PedidoItemSubLinha";
            this.PedidoItemSubLinha.ReadOnly = true;
            this.PedidoItemSubLinha.Width = 60;
            // 
            // PedidoItemProduto
            // 
            this.PedidoItemProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PedidoItemProduto.DataPropertyName = "PedidoItemProduto";
            this.PedidoItemProduto.HeaderText = "Item";
            this.PedidoItemProduto.Name = "PedidoItemProduto";
            this.PedidoItemProduto.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Familia";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Width = 60;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Identificação";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Revisao
            // 
            this.Revisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Revisao.DataPropertyName = "Revisao";
            this.Revisao.HeaderText = "Revisão";
            this.Revisao.Name = "Revisao";
            this.Revisao.ReadOnly = true;
            // 
            // CadPedidoItemDocumentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(649, 479);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadPedidoItemDocumentoForm";
            this.Text = "Documentos do Pedido";
            this.Shown += new System.EventHandler(this.CadPedidoDocumentoForm_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private IWTDotNetLib.IWTButton btnFechar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private IWTDotNetLib.IWTDataGridView dataGridView1;
        private IWTDotNetLib.IWTLabel label1;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbItem;
        private IWTDotNetLib.IWTLabel label2;
        private IWTDotNetLib.IWTTextBox txtRevisao;
        private IWTDotNetLib.IWTLabel label4;
        private IWTDotNetLib.IWTTextBox txtIdentificacao;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTTextBox txtFamilia;
        private IWTDotNetLib.IWTButton btnExcluir;
        private IWTDotNetLib.IWTButton btnOk;
        private DataGridViewTextBoxColumn PedidoItemSubLinha;
        private DataGridViewTextBoxColumn PedidoItemProduto;
        private DataGridViewTextBoxColumn Tipo;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Revisao;
    }
}