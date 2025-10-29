using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    partial class CadOrcamentoItemVariavelListForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvVariaveisPedido = new IWTDotNetLib.IWTDataGridView(this.components);
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VariavelDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtValor = new IWTDotNetLib.IWTTextBox(this.components);
            this.cmbVariavel = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.btnExcluir = new IWTDotNetLib.IWTButton(this.components);
            this.btnOK = new IWTDotNetLib.IWTButton(this.components);
            this.label3 = new IWTDotNetLib.IWTLabel(this.components);
            this.label1 = new IWTDotNetLib.IWTLabel(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvVariaveisItensPedido = new IWTDotNetLib.IWTDataGridView(this.components);
            this.PedidoItemSubLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PedidoItemProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtValorItem = new IWTDotNetLib.IWTTextBox(this.components);
            this.cmbSublinha = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.cmbVariavelItem = new IWTDotNetLib.IWTMultiColumnComboBox(this.components);
            this.btnExcluirItem = new IWTDotNetLib.IWTButton(this.components);
            this.btnOkItem = new IWTDotNetLib.IWTButton(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel2 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtLabel3 = new IWTDotNetLib.IWTLabel(this.components);
            this.btnSalvar = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariaveisPedido)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariaveisItensPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSalvar);
            this.splitContainer1.Size = new System.Drawing.Size(799, 507);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 454);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 428);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Variáveis do Pedido";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvVariaveisPedido);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtValor);
            this.splitContainer2.Panel2.Controls.Add(this.cmbVariavel);
            this.splitContainer2.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer2.Panel2.Controls.Add(this.btnOK);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(785, 422);
            this.splitContainer2.SplitterDistance = 593;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvVariaveisPedido
            // 
            this.dgvVariaveisPedido.AllowUserToAddRows = false;
            this.dgvVariaveisPedido.AllowUserToDeleteRows = false;
            this.dgvVariaveisPedido.AllowUserToOrderColumns = true;
            this.dgvVariaveisPedido.CacheDados = null;
            this.dgvVariaveisPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVariaveisPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.VariavelDescricao,
            this.Valor});
            this.dgvVariaveisPedido.Location = new System.Drawing.Point(0, 0);
            this.dgvVariaveisPedido.Name = "dgvVariaveisPedido";
            this.dgvVariaveisPedido.ReadOnly = true;
            this.dgvVariaveisPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVariaveisPedido.Size = new System.Drawing.Size(593, 422);
            this.dgvVariaveisPedido.TabIndex = 0;
            this.dgvVariaveisPedido.SelectionChanged += new System.EventHandler(this.dgvVariaveisPedido_SelectionChanged);
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 150;
            // 
            // VariavelDescricao
            // 
            this.VariavelDescricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VariavelDescricao.DataPropertyName = "VariavelDescricao";
            this.VariavelDescricao.HeaderText = "Descrição";
            this.VariavelDescricao.Name = "VariavelDescricao";
            this.VariavelDescricao.ReadOnly = true;
            this.VariavelDescricao.Width = 250;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Valor.DataPropertyName = "Valor";
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // txtValor
            // 
            this.txtValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValor.BindingField = null;
            this.txtValor.LiberadoQuandoCadastroUtilizado = false;
            this.txtValor.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtValor.Location = new System.Drawing.Point(15, 74);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(161, 20);
            this.txtValor.TabIndex = 9;
            // 
            // cmbVariavel
            // 
            this.cmbVariavel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVariavel.BindingField = null;
            this.cmbVariavel.ColumnsToDisplay = null;
            this.cmbVariavel.DropDownHeight = 1;
            this.cmbVariavel.FormattingEnabled = true;
            this.cmbVariavel.IntegralHeight = false;
            this.cmbVariavel.LiberadoQuandoCadastroUtilizado = false;
            this.cmbVariavel.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbVariavel.Location = new System.Drawing.Point(15, 25);
            this.cmbVariavel.Name = "cmbVariavel";
            this.cmbVariavel.SelectedRow = null;
            this.cmbVariavel.Size = new System.Drawing.Size(161, 21);
            this.cmbVariavel.TabIndex = 6;
            this.cmbVariavel.Table = null;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.LiberadoQuandoCadastroUtilizado = false;
            this.btnExcluir.Location = new System.Drawing.Point(101, 391);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.LiberadoQuandoCadastroUtilizado = false;
            this.btnOK.Location = new System.Drawing.Point(130, 100);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(46, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BindingField = null;
            this.label3.LiberadoQuandoCadastroUtilizado = false;
            this.label3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BindingField = null;
            this.label1.LiberadoQuandoCadastroUtilizado = false;
            this.label1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Variável";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Variáveis dos Itens do Pedido";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvVariaveisItensPedido);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.txtValorItem);
            this.splitContainer3.Panel2.Controls.Add(this.cmbSublinha);
            this.splitContainer3.Panel2.Controls.Add(this.cmbVariavelItem);
            this.splitContainer3.Panel2.Controls.Add(this.btnExcluirItem);
            this.splitContainer3.Panel2.Controls.Add(this.btnOkItem);
            this.splitContainer3.Panel2.Controls.Add(this.iwtLabel1);
            this.splitContainer3.Panel2.Controls.Add(this.iwtLabel2);
            this.splitContainer3.Panel2.Controls.Add(this.iwtLabel3);
            this.splitContainer3.Size = new System.Drawing.Size(785, 422);
            this.splitContainer3.SplitterDistance = 593;
            this.splitContainer3.TabIndex = 1;
            // 
            // dgvVariaveisItensPedido
            // 
            this.dgvVariaveisItensPedido.AllowUserToAddRows = false;
            this.dgvVariaveisItensPedido.AllowUserToDeleteRows = false;
            this.dgvVariaveisItensPedido.AllowUserToOrderColumns = true;
            this.dgvVariaveisItensPedido.CacheDados = null;
            this.dgvVariaveisItensPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVariaveisItensPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PedidoItemSubLinha,
            this.PedidoItemProduto,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgvVariaveisItensPedido.Location = new System.Drawing.Point(0, 0);
            this.dgvVariaveisItensPedido.Name = "dgvVariaveisItensPedido";
            this.dgvVariaveisItensPedido.ReadOnly = true;
            this.dgvVariaveisItensPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVariaveisItensPedido.Size = new System.Drawing.Size(593, 422);
            this.dgvVariaveisItensPedido.TabIndex = 1;
            this.dgvVariaveisItensPedido.SelectionChanged += new System.EventHandler(this.dgvVariaveisItensPedido_SelectionChanged);
            // 
            // PedidoItemSubLinha
            // 
            this.PedidoItemSubLinha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PedidoItemSubLinha.DataPropertyName = "PedidoItemSubLinha";
            this.PedidoItemSubLinha.HeaderText = "Sublinha";
            this.PedidoItemSubLinha.Name = "PedidoItemSubLinha";
            this.PedidoItemSubLinha.ReadOnly = true;
            this.PedidoItemSubLinha.Width = 55;
            // 
            // PedidoItemProduto
            // 
            this.PedidoItemProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PedidoItemProduto.DataPropertyName = "PedidoItemProduto";
            this.PedidoItemProduto.HeaderText = "Item";
            this.PedidoItemProduto.Name = "PedidoItemProduto";
            this.PedidoItemProduto.ReadOnly = true;
            this.PedidoItemProduto.Width = 110;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Codigo";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 130;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "VariavelDescricao";
            this.dataGridViewTextBoxColumn2.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Valor";
            this.dataGridViewTextBoxColumn3.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // txtValorItem
            // 
            this.txtValorItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorItem.BindingField = null;
            this.txtValorItem.LiberadoQuandoCadastroUtilizado = false;
            this.txtValorItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtValorItem.Location = new System.Drawing.Point(15, 125);
            this.txtValorItem.Name = "txtValorItem";
            this.txtValorItem.Size = new System.Drawing.Size(161, 20);
            this.txtValorItem.TabIndex = 9;
            // 
            // cmbSublinha
            // 
            this.cmbSublinha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSublinha.BindingField = null;
            this.cmbSublinha.ColumnsToDisplay = null;
            this.cmbSublinha.DropDownHeight = 1;
            this.cmbSublinha.FormattingEnabled = true;
            this.cmbSublinha.IntegralHeight = false;
            this.cmbSublinha.LiberadoQuandoCadastroUtilizado = false;
            this.cmbSublinha.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbSublinha.Location = new System.Drawing.Point(15, 76);
            this.cmbSublinha.Name = "cmbSublinha";
            this.cmbSublinha.SelectedRow = null;
            this.cmbSublinha.Size = new System.Drawing.Size(161, 21);
            this.cmbSublinha.TabIndex = 7;
            this.cmbSublinha.Table = null;
            // 
            // cmbVariavelItem
            // 
            this.cmbVariavelItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVariavelItem.BindingField = null;
            this.cmbVariavelItem.ColumnsToDisplay = null;
            this.cmbVariavelItem.DropDownHeight = 1;
            this.cmbVariavelItem.FormattingEnabled = true;
            this.cmbVariavelItem.IntegralHeight = false;
            this.cmbVariavelItem.LiberadoQuandoCadastroUtilizado = false;
            this.cmbVariavelItem.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.cmbVariavelItem.Location = new System.Drawing.Point(15, 25);
            this.cmbVariavelItem.Name = "cmbVariavelItem";
            this.cmbVariavelItem.SelectedRow = null;
            this.cmbVariavelItem.Size = new System.Drawing.Size(161, 21);
            this.cmbVariavelItem.TabIndex = 6;
            this.cmbVariavelItem.Table = null;
            // 
            // btnExcluirItem
            // 
            this.btnExcluirItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnExcluirItem.Location = new System.Drawing.Point(101, 391);
            this.btnExcluirItem.Name = "btnExcluirItem";
            this.btnExcluirItem.Size = new System.Drawing.Size(75, 23);
            this.btnExcluirItem.TabIndex = 5;
            this.btnExcluirItem.Text = "Excluir";
            this.btnExcluirItem.UseVisualStyleBackColor = true;
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);
            // 
            // btnOkItem
            // 
            this.btnOkItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkItem.LiberadoQuandoCadastroUtilizado = false;
            this.btnOkItem.Location = new System.Drawing.Point(130, 151);
            this.btnOkItem.Name = "btnOkItem";
            this.btnOkItem.Size = new System.Drawing.Size(46, 23);
            this.btnOkItem.TabIndex = 3;
            this.btnOkItem.Text = "OK";
            this.btnOkItem.UseVisualStyleBackColor = true;
            this.btnOkItem.Click += new System.EventHandler(this.btnOkItem_Click);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(3, 109);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(31, 13);
            this.iwtLabel1.TabIndex = 2;
            this.iwtLabel1.Text = "Valor";
            // 
            // iwtLabel2
            // 
            this.iwtLabel2.AutoSize = true;
            this.iwtLabel2.BindingField = null;
            this.iwtLabel2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel2.Location = new System.Drawing.Point(3, 60);
            this.iwtLabel2.Name = "iwtLabel2";
            this.iwtLabel2.Size = new System.Drawing.Size(48, 13);
            this.iwtLabel2.TabIndex = 1;
            this.iwtLabel2.Text = "Sublinha";
            // 
            // iwtLabel3
            // 
            this.iwtLabel3.AutoSize = true;
            this.iwtLabel3.BindingField = null;
            this.iwtLabel3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel3.Location = new System.Drawing.Point(3, 9);
            this.iwtLabel3.Name = "iwtLabel3";
            this.iwtLabel3.Size = new System.Drawing.Size(45, 13);
            this.iwtLabel3.TabIndex = 0;
            this.iwtLabel3.Text = "Variável";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.LiberadoQuandoCadastroUtilizado = false;
            this.btnSalvar.Location = new System.Drawing.Point(712, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // CadPedidoItemVariavelListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(799, 507);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CadPedidoItemVariavelListForm";
            this.Text = "Variáveis";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariaveisPedido)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariaveisItensPedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private IWTDotNetLib.IWTButton btnSalvar;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private IWTDotNetLib.IWTDataGridView dgvVariaveisPedido;
        private IWTDotNetLib.IWTMultiColumnComboBox cmbVariavel;
        private IWTDotNetLib.IWTButton btnExcluir;
        private IWTDotNetLib.IWTButton btnOK;
        private IWTDotNetLib.IWTLabel label3;
        private IWTDotNetLib.IWTLabel label1;
        private IWTDotNetLib.IWTTextBox txtValor;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private SplitContainer splitContainer3;
        private IWTTextBox txtValorItem;
        private IWTMultiColumnComboBox cmbSublinha;
        private IWTMultiColumnComboBox cmbVariavelItem;
        private IWTButton btnExcluirItem;
        private IWTButton btnOkItem;
        private IWTLabel iwtLabel1;
        private IWTLabel iwtLabel2;
        private IWTLabel iwtLabel3;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn VariavelDescricao;
        private DataGridViewTextBoxColumn Valor;
        private IWTDataGridView dgvVariaveisItensPedido;
        private DataGridViewTextBoxColumn PedidoItemSubLinha;
        private DataGridViewTextBoxColumn PedidoItemProduto;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}