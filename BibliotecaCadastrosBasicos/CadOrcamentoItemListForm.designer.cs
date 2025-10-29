using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos 
{
    partial class CadOrcamentoItemListForm 
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
            this.rdbAprovado = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbTodos = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbCancelado = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbPendentes = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPosicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusTraduzido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassificacaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjetoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemanaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoDescricaoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnpjCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArmazenagemCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PermiteEntregaParcial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VolumeUnico = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Configurado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Exportacao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrecoTotalOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JustificativaCancelamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntregaOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InformacaoEspecial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RastreamentoMaterial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ContaBancaria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CentroCustoLucro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponsavelFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdemVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Representante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercComissaoRepresentante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObsPadraoEspelho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataUltimaAlteracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuarioResponsavelSuspensao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercComissaoVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImprimirPedido = new IWTDotNetLib.IWTButton(this.components);
            this.btnCancelar = new IWTDotNetLib.IWTButton(this.components);
            this.btnEditar = new IWTDotNetLib.IWTEditarButton(this.components);
            this.btnNovo = new IWTDotNetLib.IWTNovoButton(this.components);
            this.btnAprovar = new IWTDotNetLib.IWTButton(this.components);
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
            this.splitContainer2.Location = new System.Drawing.Point(0, 290);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnAprovar);
            this.splitContainer2.Panel2.Controls.Add(this.btnImprimirPedido);
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer2.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer2.Size = new System.Drawing.Size(931, 104);
            this.splitContainer2.SplitterDistance = 629;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(931, 256);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.rdbAprovado);
            this.iwtSearchPanel1.Controls.Add(this.rdbTodos);
            this.iwtSearchPanel1.Controls.Add(this.rdbCancelado);
            this.iwtSearchPanel1.Controls.Add(this.rdbPendentes);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(629, 104);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // rdbAprovado
            // 
            this.rdbAprovado.AutoSize = true;
            this.rdbAprovado.BindingField = "Aprovado";
            this.rdbAprovado.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAprovado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAprovado.Location = new System.Drawing.Point(322, 54);
            this.rdbAprovado.Name = "rdbAprovado";
            this.rdbAprovado.Size = new System.Drawing.Size(71, 17);
            this.rdbAprovado.TabIndex = 3;
            this.rdbAprovado.Text = "Aprovado";
            this.rdbAprovado.UseVisualStyleBackColor = true;
            // 
            // rdbTodos
            // 
            this.rdbTodos.AutoSize = true;
            this.rdbTodos.BindingField = "Todos";
            this.rdbTodos.LiberadoQuandoCadastroUtilizado = false;
            this.rdbTodos.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbTodos.Location = new System.Drawing.Point(403, 55);
            this.rdbTodos.Name = "rdbTodos";
            this.rdbTodos.Size = new System.Drawing.Size(55, 17);
            this.rdbTodos.TabIndex = 4;
            this.rdbTodos.Text = "Todos";
            this.rdbTodos.UseVisualStyleBackColor = true;
            // 
            // rdbCancelado
            // 
            this.rdbCancelado.AutoSize = true;
            this.rdbCancelado.BindingField = "Cancelado";
            this.rdbCancelado.LiberadoQuandoCadastroUtilizado = false;
            this.rdbCancelado.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbCancelado.Location = new System.Drawing.Point(403, 32);
            this.rdbCancelado.Name = "rdbCancelado";
            this.rdbCancelado.Size = new System.Drawing.Size(76, 17);
            this.rdbCancelado.TabIndex = 2;
            this.rdbCancelado.Text = "Cancelado";
            this.rdbCancelado.UseVisualStyleBackColor = true;
            // 
            // rdbPendentes
            // 
            this.rdbPendentes.AutoSize = true;
            this.rdbPendentes.BindingField = "Pendente";
            this.rdbPendentes.Checked = true;
            this.rdbPendentes.LiberadoQuandoCadastroUtilizado = false;
            this.rdbPendentes.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbPendentes.Location = new System.Drawing.Point(322, 32);
            this.rdbPendentes.Name = "rdbPendentes";
            this.rdbPendentes.Size = new System.Drawing.Size(71, 17);
            this.rdbPendentes.TabIndex = 1;
            this.rdbPendentes.TabStop = true;
            this.rdbPendentes.Text = "Pendente";
            this.rdbPendentes.UseVisualStyleBackColor = true;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 41);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(231, 20);
            this.iwtTextBox1.TabIndex = 0;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 44);
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
            this.Cliente,
            this.NumeroPosicao,
            this.StatusTraduzido,
            this.ProdutoCodigoCliente,
            this.ClassificacaoProduto,
            this.ProjetoCliente,
            this.Quantidade,
            this.DataEntrega,
            this.SemanaEntrega,
            this.DataEntrada,
            this.Numero,
            this.Posicao,
            this.Produto,
            this.ProdutoDescricaoCliente,
            this.PrecoUnitario,
            this.PrecoTotal,
            this.CnpjCliente,
            this.ArmazenagemCliente,
            this.Frete,
            this.Nbm,
            this.Status,
            this.Operacao,
            this.PermiteEntregaParcial,
            this.VolumeUnico,
            this.Configurado,
            this.Exportacao,
            this.PrecoTotalOriginal,
            this.AcsUsuarioCancelamento,
            this.DataCancelamento,
            this.JustificativaCancelamento,
            this.DataEntregaOriginal,
            this.InformacaoEspecial,
            this.RastreamentoMaterial,
            this.ContaBancaria,
            this.CentroCustoLucro,
            this.FormaPagamento,
            this.FormaFrete,
            this.ResponsavelFrete,
            this.OrdemVenda,
            this.Representante,
            this.PercComissaoRepresentante,
            this.ObsPadraoEspelho,
            this.DataUltimaAlteracao,
            this.AcsUsuarioResponsavelSuspensao,
            this.Vendedor,
            this.PercComissaoVendedor});
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
            this.iwtDataGridView1.Size = new System.Drawing.Size(931, 218);
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
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // NumeroPosicao
            // 
            this.NumeroPosicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroPosicao.DataPropertyName = "NumeroPosicao";
            this.NumeroPosicao.HeaderText = "Número/Pos";
            this.NumeroPosicao.Name = "NumeroPosicao";
            this.NumeroPosicao.ReadOnly = true;
            // 
            // StatusTraduzido
            // 
            this.StatusTraduzido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StatusTraduzido.DataPropertyName = "StatusTraduzido";
            this.StatusTraduzido.HeaderText = "Status";
            this.StatusTraduzido.Name = "StatusTraduzido";
            this.StatusTraduzido.ReadOnly = true;
            this.StatusTraduzido.Width = 60;
            // 
            // ProdutoCodigoCliente
            // 
            this.ProdutoCodigoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoCodigoCliente.DataPropertyName = "ProdutoCodigoCliente";
            this.ProdutoCodigoCliente.HeaderText = "Código";
            this.ProdutoCodigoCliente.Name = "ProdutoCodigoCliente";
            this.ProdutoCodigoCliente.ReadOnly = true;
            // 
            // ClassificacaoProduto
            // 
            this.ClassificacaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClassificacaoProduto.DataPropertyName = "ClassificacaoProduto";
            this.ClassificacaoProduto.HeaderText = "Classificação";
            this.ClassificacaoProduto.Name = "ClassificacaoProduto";
            this.ClassificacaoProduto.ReadOnly = true;
            this.ClassificacaoProduto.Width = 90;
            // 
            // ProjetoCliente
            // 
            this.ProjetoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProjetoCliente.DataPropertyName = "ProjetoCliente";
            this.ProjetoCliente.HeaderText = "Projeto";
            this.ProjetoCliente.Name = "ProjetoCliente";
            this.ProjetoCliente.ReadOnly = true;
            this.ProjetoCliente.Width = 65;
            // 
            // Quantidade
            // 
            this.Quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Quantidade.DataPropertyName = "Quantidade";
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            this.Quantidade.ReadOnly = true;
            this.Quantidade.Width = 70;
            // 
            // DataEntrega
            // 
            this.DataEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEntrega.DataPropertyName = "DataEntrega";
            this.DataEntrega.HeaderText = "Data Entrega";
            this.DataEntrega.Name = "DataEntrega";
            this.DataEntrega.ReadOnly = true;
            this.DataEntrega.Width = 80;
            // 
            // SemanaEntrega
            // 
            this.SemanaEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SemanaEntrega.DataPropertyName = "SemanaEntrega";
            this.SemanaEntrega.HeaderText = "Semana Entrega";
            this.SemanaEntrega.Name = "SemanaEntrega";
            this.SemanaEntrega.ReadOnly = true;
            this.SemanaEntrega.Width = 80;
            // 
            // DataEntrada
            // 
            this.DataEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEntrada.DataPropertyName = "DataEntrada";
            this.DataEntrada.HeaderText = "Cadastro";
            this.DataEntrada.Name = "DataEntrada";
            this.DataEntrada.ReadOnly = true;
            this.DataEntrada.Width = 95;
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Visible = false;
            this.Numero.Width = 150;
            // 
            // Posicao
            // 
            this.Posicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Posicao.DataPropertyName = "Posicao";
            this.Posicao.HeaderText = "Posição";
            this.Posicao.Name = "Posicao";
            this.Posicao.ReadOnly = true;
            this.Posicao.Visible = false;
            this.Posicao.Width = 70;
            // 
            // Produto
            // 
            this.Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Produto.DataPropertyName = "Produto";
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            this.Produto.Visible = false;
            this.Produto.Width = 150;
            // 
            // ProdutoDescricaoCliente
            // 
            this.ProdutoDescricaoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ProdutoDescricaoCliente.DataPropertyName = "ProdutoDescricaoCliente";
            this.ProdutoDescricaoCliente.HeaderText = "Produto Descrição Cliente";
            this.ProdutoDescricaoCliente.Name = "ProdutoDescricaoCliente";
            this.ProdutoDescricaoCliente.ReadOnly = true;
            this.ProdutoDescricaoCliente.Visible = false;
            this.ProdutoDescricaoCliente.Width = 150;
            // 
            // PrecoUnitario
            // 
            this.PrecoUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrecoUnitario.DataPropertyName = "PrecoUnitario";
            this.PrecoUnitario.HeaderText = "Preço Unitário";
            this.PrecoUnitario.Name = "PrecoUnitario";
            this.PrecoUnitario.ReadOnly = true;
            this.PrecoUnitario.Visible = false;
            // 
            // PrecoTotal
            // 
            this.PrecoTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrecoTotal.DataPropertyName = "PrecoTotal";
            this.PrecoTotal.HeaderText = "Preço Total";
            this.PrecoTotal.Name = "PrecoTotal";
            this.PrecoTotal.ReadOnly = true;
            this.PrecoTotal.Visible = false;
            // 
            // CnpjCliente
            // 
            this.CnpjCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CnpjCliente.DataPropertyName = "CnpjCliente";
            this.CnpjCliente.HeaderText = "Cnpj Cliente";
            this.CnpjCliente.Name = "CnpjCliente";
            this.CnpjCliente.ReadOnly = true;
            this.CnpjCliente.Visible = false;
            this.CnpjCliente.Width = 150;
            // 
            // ArmazenagemCliente
            // 
            this.ArmazenagemCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ArmazenagemCliente.DataPropertyName = "ArmazenagemCliente";
            this.ArmazenagemCliente.HeaderText = "Armazenagem Cliente";
            this.ArmazenagemCliente.Name = "ArmazenagemCliente";
            this.ArmazenagemCliente.ReadOnly = true;
            this.ArmazenagemCliente.Visible = false;
            this.ArmazenagemCliente.Width = 150;
            // 
            // Frete
            // 
            this.Frete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Frete.DataPropertyName = "Frete";
            this.Frete.HeaderText = "Frete";
            this.Frete.Name = "Frete";
            this.Frete.ReadOnly = true;
            this.Frete.Visible = false;
            // 
            // Nbm
            // 
            this.Nbm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Nbm.DataPropertyName = "Nbm";
            this.Nbm.HeaderText = "Nbm";
            this.Nbm.Name = "Nbm";
            this.Nbm.ReadOnly = true;
            this.Nbm.Visible = false;
            this.Nbm.Width = 150;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            this.Status.Width = 150;
            // 
            // Operacao
            // 
            this.Operacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operacao.DataPropertyName = "Operacao";
            this.Operacao.HeaderText = "Operação";
            this.Operacao.Name = "Operacao";
            this.Operacao.ReadOnly = true;
            this.Operacao.Visible = false;
            this.Operacao.Width = 150;
            // 
            // PermiteEntregaParcial
            // 
            this.PermiteEntregaParcial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PermiteEntregaParcial.DataPropertyName = "PermiteEntregaParcial";
            this.PermiteEntregaParcial.HeaderText = "Permite Entrega Parcial";
            this.PermiteEntregaParcial.Name = "PermiteEntregaParcial";
            this.PermiteEntregaParcial.ReadOnly = true;
            this.PermiteEntregaParcial.Visible = false;
            this.PermiteEntregaParcial.Width = 70;
            // 
            // VolumeUnico
            // 
            this.VolumeUnico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VolumeUnico.DataPropertyName = "VolumeUnico";
            this.VolumeUnico.HeaderText = "Volume Único";
            this.VolumeUnico.Name = "VolumeUnico";
            this.VolumeUnico.ReadOnly = true;
            this.VolumeUnico.Visible = false;
            this.VolumeUnico.Width = 70;
            // 
            // Configurado
            // 
            this.Configurado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Configurado.DataPropertyName = "Configurado";
            this.Configurado.HeaderText = "Configurado";
            this.Configurado.Name = "Configurado";
            this.Configurado.ReadOnly = true;
            this.Configurado.Visible = false;
            this.Configurado.Width = 70;
            // 
            // Exportacao
            // 
            this.Exportacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Exportacao.DataPropertyName = "Exportacao";
            this.Exportacao.HeaderText = "Exportação";
            this.Exportacao.Name = "Exportacao";
            this.Exportacao.ReadOnly = true;
            this.Exportacao.Visible = false;
            this.Exportacao.Width = 70;
            // 
            // PrecoTotalOriginal
            // 
            this.PrecoTotalOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PrecoTotalOriginal.DataPropertyName = "PrecoTotalOriginal";
            this.PrecoTotalOriginal.HeaderText = "Preço Total Original";
            this.PrecoTotalOriginal.Name = "PrecoTotalOriginal";
            this.PrecoTotalOriginal.ReadOnly = true;
            this.PrecoTotalOriginal.Visible = false;
            // 
            // AcsUsuarioCancelamento
            // 
            this.AcsUsuarioCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioCancelamento.DataPropertyName = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.HeaderText = "Usuário Cancelamento";
            this.AcsUsuarioCancelamento.Name = "AcsUsuarioCancelamento";
            this.AcsUsuarioCancelamento.ReadOnly = true;
            this.AcsUsuarioCancelamento.Visible = false;
            this.AcsUsuarioCancelamento.Width = 150;
            // 
            // DataCancelamento
            // 
            this.DataCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataCancelamento.DataPropertyName = "DataCancelamento";
            this.DataCancelamento.HeaderText = "Data Cancelamento";
            this.DataCancelamento.Name = "DataCancelamento";
            this.DataCancelamento.ReadOnly = true;
            this.DataCancelamento.Visible = false;
            // 
            // JustificativaCancelamento
            // 
            this.JustificativaCancelamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.JustificativaCancelamento.DataPropertyName = "JustificativaCancelamento";
            this.JustificativaCancelamento.HeaderText = "Justificativa Cancelamento";
            this.JustificativaCancelamento.Name = "JustificativaCancelamento";
            this.JustificativaCancelamento.ReadOnly = true;
            this.JustificativaCancelamento.Visible = false;
            this.JustificativaCancelamento.Width = 150;
            // 
            // DataEntregaOriginal
            // 
            this.DataEntregaOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEntregaOriginal.DataPropertyName = "DataEntregaOriginal";
            this.DataEntregaOriginal.HeaderText = "Data Entrega Original";
            this.DataEntregaOriginal.Name = "DataEntregaOriginal";
            this.DataEntregaOriginal.ReadOnly = true;
            this.DataEntregaOriginal.Visible = false;
            // 
            // InformacaoEspecial
            // 
            this.InformacaoEspecial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InformacaoEspecial.DataPropertyName = "InformacaoEspecial";
            this.InformacaoEspecial.HeaderText = "Informação Especial";
            this.InformacaoEspecial.Name = "InformacaoEspecial";
            this.InformacaoEspecial.ReadOnly = true;
            this.InformacaoEspecial.Visible = false;
            this.InformacaoEspecial.Width = 150;
            // 
            // RastreamentoMaterial
            // 
            this.RastreamentoMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RastreamentoMaterial.DataPropertyName = "RastreamentoMaterial";
            this.RastreamentoMaterial.HeaderText = "Rastreamento Material";
            this.RastreamentoMaterial.Name = "RastreamentoMaterial";
            this.RastreamentoMaterial.ReadOnly = true;
            this.RastreamentoMaterial.Visible = false;
            this.RastreamentoMaterial.Width = 70;
            // 
            // ContaBancaria
            // 
            this.ContaBancaria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ContaBancaria.DataPropertyName = "ContaBancaria";
            this.ContaBancaria.HeaderText = "Conta Bancária";
            this.ContaBancaria.Name = "ContaBancaria";
            this.ContaBancaria.ReadOnly = true;
            this.ContaBancaria.Visible = false;
            this.ContaBancaria.Width = 150;
            // 
            // CentroCustoLucro
            // 
            this.CentroCustoLucro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CentroCustoLucro.DataPropertyName = "CentroCustoLucro";
            this.CentroCustoLucro.HeaderText = "Centro Custo";
            this.CentroCustoLucro.Name = "CentroCustoLucro";
            this.CentroCustoLucro.ReadOnly = true;
            this.CentroCustoLucro.Visible = false;
            this.CentroCustoLucro.Width = 150;
            // 
            // FormaPagamento
            // 
            this.FormaPagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FormaPagamento.DataPropertyName = "FormaPagamento";
            this.FormaPagamento.HeaderText = "Forma Pagamento";
            this.FormaPagamento.Name = "FormaPagamento";
            this.FormaPagamento.ReadOnly = true;
            this.FormaPagamento.Visible = false;
            this.FormaPagamento.Width = 150;
            // 
            // FormaFrete
            // 
            this.FormaFrete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FormaFrete.DataPropertyName = "FormaFrete";
            this.FormaFrete.HeaderText = "Forma Frete";
            this.FormaFrete.Name = "FormaFrete";
            this.FormaFrete.ReadOnly = true;
            this.FormaFrete.Visible = false;
            this.FormaFrete.Width = 150;
            // 
            // ResponsavelFrete
            // 
            this.ResponsavelFrete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ResponsavelFrete.DataPropertyName = "ResponsavelFrete";
            this.ResponsavelFrete.HeaderText = "Responsável Frete";
            this.ResponsavelFrete.Name = "ResponsavelFrete";
            this.ResponsavelFrete.ReadOnly = true;
            this.ResponsavelFrete.Visible = false;
            this.ResponsavelFrete.Width = 150;
            // 
            // OrdemVenda
            // 
            this.OrdemVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrdemVenda.DataPropertyName = "OrdemVenda";
            this.OrdemVenda.HeaderText = "Ordem Venda";
            this.OrdemVenda.Name = "OrdemVenda";
            this.OrdemVenda.ReadOnly = true;
            this.OrdemVenda.Visible = false;
            this.OrdemVenda.Width = 150;
            // 
            // Representante
            // 
            this.Representante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Representante.DataPropertyName = "Representante";
            this.Representante.HeaderText = "Representante";
            this.Representante.Name = "Representante";
            this.Representante.ReadOnly = true;
            this.Representante.Visible = false;
            this.Representante.Width = 150;
            // 
            // PercComissaoRepresentante
            // 
            this.PercComissaoRepresentante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PercComissaoRepresentante.DataPropertyName = "PercComissaoRepresentante";
            this.PercComissaoRepresentante.HeaderText = "Comissão Representante";
            this.PercComissaoRepresentante.Name = "PercComissaoRepresentante";
            this.PercComissaoRepresentante.ReadOnly = true;
            this.PercComissaoRepresentante.Visible = false;
            // 
            // ObsPadraoEspelho
            // 
            this.ObsPadraoEspelho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ObsPadraoEspelho.DataPropertyName = "ObsPadraoEspelho";
            this.ObsPadraoEspelho.HeaderText = "Obs Padrão Espelho";
            this.ObsPadraoEspelho.Name = "ObsPadraoEspelho";
            this.ObsPadraoEspelho.ReadOnly = true;
            this.ObsPadraoEspelho.Visible = false;
            this.ObsPadraoEspelho.Width = 150;
            // 
            // DataUltimaAlteracao
            // 
            this.DataUltimaAlteracao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataUltimaAlteracao.DataPropertyName = "DataUltimaAlteracao";
            this.DataUltimaAlteracao.HeaderText = "Data Última Alteração";
            this.DataUltimaAlteracao.Name = "DataUltimaAlteracao";
            this.DataUltimaAlteracao.ReadOnly = true;
            this.DataUltimaAlteracao.Visible = false;
            // 
            // AcsUsuarioResponsavelSuspensao
            // 
            this.AcsUsuarioResponsavelSuspensao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuarioResponsavelSuspensao.DataPropertyName = "AcsUsuarioResponsavelSuspensao";
            this.AcsUsuarioResponsavelSuspensao.HeaderText = "Usuário Responsável Suspensão";
            this.AcsUsuarioResponsavelSuspensao.Name = "AcsUsuarioResponsavelSuspensao";
            this.AcsUsuarioResponsavelSuspensao.ReadOnly = true;
            this.AcsUsuarioResponsavelSuspensao.Visible = false;
            this.AcsUsuarioResponsavelSuspensao.Width = 150;
            // 
            // Vendedor
            // 
            this.Vendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Vendedor.DataPropertyName = "Vendedor";
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            this.Vendedor.Visible = false;
            this.Vendedor.Width = 150;
            // 
            // PercComissaoVendedor
            // 
            this.PercComissaoVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PercComissaoVendedor.DataPropertyName = "PercComissaoVendedor";
            this.PercComissaoVendedor.HeaderText = "Comissão Vendedor";
            this.PercComissaoVendedor.Name = "PercComissaoVendedor";
            this.PercComissaoVendedor.ReadOnly = true;
            this.PercComissaoVendedor.Visible = false;
            // 
            // btnImprimirPedido
            // 
            this.btnImprimirPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimirPedido.LiberadoQuandoCadastroUtilizado = false;
            this.btnImprimirPedido.Location = new System.Drawing.Point(49, 70);
            this.btnImprimirPedido.Name = "btnImprimirPedido";
            this.btnImprimirPedido.Size = new System.Drawing.Size(237, 23);
            this.btnImprimirPedido.TabIndex = 4;
            this.btnImprimirPedido.Text = "Imprimir";
            this.btnImprimirPedido.UseVisualStyleBackColor = true;
            this.btnImprimirPedido.Click += new System.EventHandler(this.btnImprimirPedido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.LiberadoQuandoCadastroUtilizado = false;
            this.btnCancelar.Location = new System.Drawing.Point(165, 41);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(121, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditar.Location = new System.Drawing.Point(165, 12);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(121, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.LiberadoQuandoCadastroUtilizado = false;
            this.btnNovo.Location = new System.Drawing.Point(49, 12);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(110, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnAprovar
            // 
            this.btnAprovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprovar.LiberadoQuandoCadastroUtilizado = false;
            this.btnAprovar.Location = new System.Drawing.Point(49, 41);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(110, 23);
            this.btnAprovar.TabIndex = 2;
            this.btnAprovar.Text = "Aprovar";
            this.btnAprovar.UseVisualStyleBackColor = true;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // CadOrcamentoItemListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(931, 394);
            this.Name = "CadOrcamentoItemListForm";
            this.Text = "Orçamentos";
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
        private IWTDotNetLib.IWTRadioButton rdbCancelado;
        private IWTDotNetLib.IWTRadioButton rdbPendentes;
        private IWTDotNetLib.IWTButton btnImprimirPedido;
        private IWTDotNetLib.IWTButton btnCancelar;
        private IWTDotNetLib.IWTEditarButton btnEditar;
        private IWTDotNetLib.IWTNovoButton btnNovo;
        private IWTRadioButton rdbAprovado;
        private IWTRadioButton rdbTodos;
        private IWTButton btnAprovar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPosicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusTraduzido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassificacaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjetoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemanaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoDescricaoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CnpjCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArmazenagemCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermiteEntregaParcial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn VolumeUnico;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Configurado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Exportacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoTotalOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioCancelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCancelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn JustificativaCancelamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntregaOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn InformacaoEspecial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RastreamentoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContaBancaria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CentroCustoLucro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsavelFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdemVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Representante;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercComissaoRepresentante;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObsPadraoEspelho;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataUltimaAlteracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuarioResponsavelSuspensao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercComissaoVendedor;
    }
} 
