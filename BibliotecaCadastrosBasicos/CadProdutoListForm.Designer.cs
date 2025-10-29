using Configurations;
using IWTDotNetLib;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos 
{ 
    partial class CadProdutoListForm 
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.iwtSearchPanel1 = new IWTDotNetLib.IWTSearchPanel();
            this.grbFiltroStatus = new System.Windows.Forms.GroupBox();
            this.iwtRadioButton3 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtRadioButton2 = new IWTDotNetLib.IWTRadioButton(this.components);
            this.rdbAtivo = new IWTDotNetLib.IWTRadioButton(this.components);
            this.iwtTextBox1 = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.iwtDataGridView1 = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstruturaEmRevisao = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstruturaEmRevisaoObservacaoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gtin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoAquisicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoliticaEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmiteOp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EmitePlanoCorte = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EtiquetaInterna = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LocalFabricacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataRevisaoCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcsUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoRevisao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VersaoEstruturaAtual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FamiliaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadTimeFabrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegraDimensao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculoPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteEconomico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassificacaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModeloEtiqueta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtdEtiquetaExpedicaoVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Embalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoIngles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoEspanhol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CadastroPcp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CadastroEngenharia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Acabamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variavel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variavel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variavel3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variavel4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UtilizaDimensaoMaiorFilho = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AgrupadorOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AplicacaoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempoLimite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CadastroPreco = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Temporario = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Vermelho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amarelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotePadraoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoteMinimoCompraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedidaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadesPorUnCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadTimeCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarcasHomologadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImpedirSolicitacaoAuto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RastreamentoMaterial = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RegraValidVar1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegraValidVar2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegraValidVar3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegraValidVar4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UtilizandoEstoqueSeguranca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UtilizandoEstoqueSegurancaData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResponsavelFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comprador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PermiteVenda = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DescricaoAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImprimirEstruturaOp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ImprimeOpsRelacionadas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MargemRecebimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidacaoPesoExpedicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BloqueioPrecoVencido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEstrutura = new IWTDotNetLib.IWTButton(this.components);
            this.btnPCP = new IWTDotNetLib.IWTButton(this.components);
            this.btnCusto = new IWTDotNetLib.IWTButton(this.components);
            this.btnRevisao = new IWTDotNetLib.IWTButton(this.components);
            this.btnEtiqueta = new IWTDotNetLib.IWTButton(this.components);
            this.btnCriarEditarKbMan = new IWTDotNetLib.IWTButton(this.components);
            this.btnEditar = new IWTDotNetLib.IWTEditarButton(this.components);
            this.btnNovo = new IWTDotNetLib.IWTNovoButton(this.components);
            this.btnExcluir = new IWTDotNetLib.IWTExcluirButton(this.components);
            this.iwtSelecionarButton1 = new IWTDotNetLib.IWTSelecionarButton(this.components);
            this.btnHistoricoCompra = new IWTDotNetLib.IWTButton(this.components);
            this.btnVisualizarEstrutura = new IWTDotNetLib.IWTButton(this.components);
            this.btnDesbloqueioVencido = new IWTDotNetLib.IWTButton(this.components);
            this.btnBloqueioVencido = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.iwtSearchPanel1.SuspendLayout();
            this.grbFiltroStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Location = new System.Drawing.Point(0, 337);
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.iwtSearchPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnDesbloqueioVencido);
            this.splitContainer2.Panel2.Controls.Add(this.btnBloqueioVencido);
            this.splitContainer2.Panel2.Controls.Add(this.btnVisualizarEstrutura);
            this.splitContainer2.Panel2.Controls.Add(this.btnHistoricoCompra);
            this.splitContainer2.Panel2.Controls.Add(this.btnExcluir);
            this.splitContainer2.Panel2.Controls.Add(this.btnNovo);
            this.splitContainer2.Panel2.Controls.Add(this.btnEditar);
            this.splitContainer2.Panel2.Controls.Add(this.btnCriarEditarKbMan);
            this.splitContainer2.Panel2.Controls.Add(this.btnEtiqueta);
            this.splitContainer2.Panel2.Controls.Add(this.btnRevisao);
            this.splitContainer2.Panel2.Controls.Add(this.btnEstrutura);
            this.splitContainer2.Panel2.Controls.Add(this.btnCusto);
            this.splitContainer2.Panel2.Controls.Add(this.btnPCP);
            this.splitContainer2.Panel2.Controls.Add(this.iwtSelecionarButton1);
            this.splitContainer2.Size = new System.Drawing.Size(900, 109);
            this.splitContainer2.SplitterDistance = 411;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iwtDataGridView1);
            this.panel1.Size = new System.Drawing.Size(900, 303);
            this.panel1.Controls.SetChildIndex(this.iwtDataGridView1, 0);
            // 
            // iwtSearchPanel1
            // 
            this.iwtSearchPanel1.Controls.Add(this.grbFiltroStatus);
            this.iwtSearchPanel1.Controls.Add(this.iwtTextBox1);
            this.iwtSearchPanel1.Controls.Add(this.iwtLabel1);
            this.iwtSearchPanel1.Location = new System.Drawing.Point(0, 0);
            this.iwtSearchPanel1.Name = "iwtSearchPanel1";
            this.iwtSearchPanel1.ParametrosBuscaIniciais = null;
            this.iwtSearchPanel1.Size = new System.Drawing.Size(411, 109);
            this.iwtSearchPanel1.TabIndex = 0;
            // 
            // grbFiltroStatus
            // 
            this.grbFiltroStatus.Controls.Add(this.iwtRadioButton3);
            this.grbFiltroStatus.Controls.Add(this.iwtRadioButton2);
            this.grbFiltroStatus.Controls.Add(this.rdbAtivo);
            this.grbFiltroStatus.Location = new System.Drawing.Point(19, 43);
            this.grbFiltroStatus.Name = "grbFiltroStatus";
            this.grbFiltroStatus.Size = new System.Drawing.Size(389, 51);
            this.grbFiltroStatus.TabIndex = 2;
            this.grbFiltroStatus.TabStop = false;
            this.grbFiltroStatus.Text = "Status";
            // 
            // iwtRadioButton3
            // 
            this.iwtRadioButton3.AutoSize = true;
            this.iwtRadioButton3.BindingField = "Todos";
            this.iwtRadioButton3.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton3.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton3.Location = new System.Drawing.Point(271, 19);
            this.iwtRadioButton3.Name = "iwtRadioButton3";
            this.iwtRadioButton3.Size = new System.Drawing.Size(55, 17);
            this.iwtRadioButton3.TabIndex = 2;
            this.iwtRadioButton3.Text = "Todos";
            this.iwtRadioButton3.UseVisualStyleBackColor = true;
            // 
            // iwtRadioButton2
            // 
            this.iwtRadioButton2.AutoSize = true;
            this.iwtRadioButton2.BindingField = "Inativo";
            this.iwtRadioButton2.LiberadoQuandoCadastroUtilizado = false;
            this.iwtRadioButton2.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtRadioButton2.Location = new System.Drawing.Point(163, 19);
            this.iwtRadioButton2.Name = "iwtRadioButton2";
            this.iwtRadioButton2.Size = new System.Drawing.Size(62, 17);
            this.iwtRadioButton2.TabIndex = 1;
            this.iwtRadioButton2.Text = "Inativos";
            this.iwtRadioButton2.UseVisualStyleBackColor = true;
            // 
            // rdbAtivo
            // 
            this.rdbAtivo.AutoSize = true;
            this.rdbAtivo.BindingField = "Ativo";
            this.rdbAtivo.Checked = true;
            this.rdbAtivo.LiberadoQuandoCadastroUtilizado = false;
            this.rdbAtivo.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.rdbAtivo.Location = new System.Drawing.Point(63, 19);
            this.rdbAtivo.Name = "rdbAtivo";
            this.rdbAtivo.Size = new System.Drawing.Size(54, 17);
            this.rdbAtivo.TabIndex = 0;
            this.rdbAtivo.TabStop = true;
            this.rdbAtivo.Text = "Ativos";
            this.rdbAtivo.UseVisualStyleBackColor = true;
            // 
            // iwtTextBox1
            // 
            this.iwtTextBox1.BindingField = "BuscaCompleta";
            this.iwtTextBox1.DebugMode = false;
            this.iwtTextBox1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtTextBox1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtTextBox1.Location = new System.Drawing.Point(56, 17);
            this.iwtTextBox1.ModoBarcode = false;
            this.iwtTextBox1.ModoBusca = false;
            this.iwtTextBox1.Name = "iwtTextBox1";
            this.iwtTextBox1.NaoLimparDepoisBarcode = false;
            this.iwtTextBox1.Size = new System.Drawing.Size(352, 20);
            this.iwtTextBox1.TabIndex = 1;
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(16, 20);
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
            this.Codigo,
            this.EstruturaEmRevisao,
            this.CodigoCliente,
            this.EstruturaEmRevisaoObservacaoColumn,
            this.Descricao,
            this.Gtin,
            this.Cliente,
            this.TipoAquisicao,
            this.PoliticaEstoque,
            this.EmiteOp,
            this.EmitePlanoCorte,
            this.EtiquetaInterna,
            this.LocalFabricacao,
            this.DataRevisaoCadastro,
            this.AcsUsuario,
            this.MotivoRevisao,
            this.VersaoEstruturaAtual,
            this.FamiliaCliente,
            this.LeadTimeFabrica,
            this.RegraDimensao,
            this.CalculoPreco,
            this.LoteEconomico,
            this.ClassificacaoProduto,
            this.ModeloEtiqueta,
            this.QtdEtiquetaExpedicaoVolume,
            this.Embalagem,
            this.DescricaoIngles,
            this.DescricaoEspanhol,
            this.PesoUnitario,
            this.CadastroPcp,
            this.CadastroEngenharia,
            this.Acabamento,
            this.Variavel1,
            this.Variavel2,
            this.Variavel3,
            this.Variavel4,
            this.UnidadeMedida,
            this.UtilizaDimensaoMaiorFilho,
            this.AgrupadorOp,
            this.AplicacaoCliente,
            this.TempoLimite,
            this.CadastroPreco,
            this.Temporario,
            this.Vermelho,
            this.Verde,
            this.Amarelo,
            this.LotePadraoCompra,
            this.LoteMinimoCompraColumn,
            this.UnidadeMedidaCompra,
            this.UnidadesPorUnCompra,
            this.LeadTimeCompra,
            this.MarcasHomologadas,
            this.ImpedirSolicitacaoAuto,
            this.RastreamentoMaterial,
            this.RegraValidVar1,
            this.RegraValidVar2,
            this.RegraValidVar3,
            this.RegraValidVar4,
            this.UtilizandoEstoqueSeguranca,
            this.UtilizandoEstoqueSegurancaData,
            this.ResponsavelFrete,
            this.Comprador,
            this.PermiteVenda,
            this.DescricaoAdicional,
            this.ImprimirEstruturaOp,
            this.ImprimeOpsRelacionadas,
            this.MargemRecebimento,
            this.ValidacaoPesoExpedicao,
            this.Ativo,
            this.BloqueioPrecoVencido});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(209)))), ((int)(((byte)(234)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.iwtDataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.iwtDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.iwtDataGridView1.Name = "iwtDataGridView1";
            this.iwtDataGridView1.ReadOnly = true;
            this.iwtDataGridView1.RowHeadersVisible = false;
            this.iwtDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iwtDataGridView1.Size = new System.Drawing.Size(900, 265);
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
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // EstruturaEmRevisao
            // 
            this.EstruturaEmRevisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EstruturaEmRevisao.DataPropertyName = "EstruturaEmRevisao";
            this.EstruturaEmRevisao.HeaderText = "Estr. em Rev";
            this.EstruturaEmRevisao.Name = "EstruturaEmRevisao";
            this.EstruturaEmRevisao.ReadOnly = true;
            this.EstruturaEmRevisao.Width = 80;
            // 
            // CodigoCliente
            // 
            this.CodigoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodigoCliente.DataPropertyName = "CodigoCliente";
            this.CodigoCliente.HeaderText = "Código Cliente";
            this.CodigoCliente.Name = "CodigoCliente";
            this.CodigoCliente.ReadOnly = true;
            // 
            // EstruturaEmRevisaoObservacaoColumn
            // 
            this.EstruturaEmRevisaoObservacaoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EstruturaEmRevisaoObservacaoColumn.DataPropertyName = "EstruturaEmRevisaoObservacao";
            this.EstruturaEmRevisaoObservacaoColumn.HeaderText = "Observação do Item em Revisão";
            this.EstruturaEmRevisaoObservacaoColumn.Name = "EstruturaEmRevisaoObservacaoColumn";
            this.EstruturaEmRevisaoObservacaoColumn.ReadOnly = true;
            this.EstruturaEmRevisaoObservacaoColumn.Visible = false;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 160;
            // 
            // Gtin
            // 
            this.Gtin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Gtin.DataPropertyName = "Gtin";
            this.Gtin.HeaderText = "GTIN";
            this.Gtin.Name = "Gtin";
            this.Gtin.ReadOnly = true;
            this.Gtin.Visible = false;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 80;
            // 
            // TipoAquisicao
            // 
            this.TipoAquisicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoAquisicao.DataPropertyName = "TipoAquisicao";
            this.TipoAquisicao.HeaderText = "Aquisição";
            this.TipoAquisicao.Name = "TipoAquisicao";
            this.TipoAquisicao.ReadOnly = true;
            this.TipoAquisicao.Width = 80;
            // 
            // PoliticaEstoque
            // 
            this.PoliticaEstoque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PoliticaEstoque.DataPropertyName = "PoliticaEstoqueTela";
            this.PoliticaEstoque.HeaderText = "Politica Estoque";
            this.PoliticaEstoque.Name = "PoliticaEstoque";
            this.PoliticaEstoque.ReadOnly = true;
            this.PoliticaEstoque.Width = 80;
            // 
            // EmiteOp
            // 
            this.EmiteOp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmiteOp.DataPropertyName = "EmiteOp";
            this.EmiteOp.HeaderText = "Emite Op";
            this.EmiteOp.Name = "EmiteOp";
            this.EmiteOp.ReadOnly = true;
            this.EmiteOp.Width = 80;
            // 
            // EmitePlanoCorte
            // 
            this.EmitePlanoCorte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EmitePlanoCorte.DataPropertyName = "EmitePlanoCorte";
            this.EmitePlanoCorte.HeaderText = "Emite PC";
            this.EmitePlanoCorte.Name = "EmitePlanoCorte";
            this.EmitePlanoCorte.ReadOnly = true;
            this.EmitePlanoCorte.Width = 80;
            // 
            // EtiquetaInterna
            // 
            this.EtiquetaInterna.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EtiquetaInterna.DataPropertyName = "EtiquetaInterna";
            this.EtiquetaInterna.HeaderText = "Conf. Expedição";
            this.EtiquetaInterna.Name = "EtiquetaInterna";
            this.EtiquetaInterna.ReadOnly = true;
            this.EtiquetaInterna.Width = 80;
            // 
            // LocalFabricacao
            // 
            this.LocalFabricacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LocalFabricacao.DataPropertyName = "LocalFabricacao";
            this.LocalFabricacao.HeaderText = "Local de Fabricação";
            this.LocalFabricacao.Name = "LocalFabricacao";
            this.LocalFabricacao.ReadOnly = true;
            this.LocalFabricacao.Width = 70;
            // 
            // DataRevisaoCadastro
            // 
            this.DataRevisaoCadastro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataRevisaoCadastro.DataPropertyName = "RevisaoUltimaData";
            this.DataRevisaoCadastro.HeaderText = "Rev. Cadastro";
            this.DataRevisaoCadastro.Name = "DataRevisaoCadastro";
            this.DataRevisaoCadastro.ReadOnly = true;
            // 
            // AcsUsuario
            // 
            this.AcsUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AcsUsuario.DataPropertyName = "RevisaoUltimaUsuario";
            this.AcsUsuario.HeaderText = "Revisor";
            this.AcsUsuario.Name = "AcsUsuario";
            this.AcsUsuario.ReadOnly = true;
            this.AcsUsuario.Width = 80;
            // 
            // MotivoRevisao
            // 
            this.MotivoRevisao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MotivoRevisao.DataPropertyName = "RevisaoUltimaMotivo";
            this.MotivoRevisao.HeaderText = "Revisão";
            this.MotivoRevisao.Name = "MotivoRevisao";
            this.MotivoRevisao.ReadOnly = true;
            // 
            // VersaoEstruturaAtual
            // 
            this.VersaoEstruturaAtual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.VersaoEstruturaAtual.DataPropertyName = "VersaoEstruturaAtual";
            this.VersaoEstruturaAtual.HeaderText = "Nº. Revisão Atual";
            this.VersaoEstruturaAtual.Name = "VersaoEstruturaAtual";
            this.VersaoEstruturaAtual.ReadOnly = true;
            this.VersaoEstruturaAtual.Width = 60;
            // 
            // FamiliaCliente
            // 
            this.FamiliaCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FamiliaCliente.DataPropertyName = "FamiliaCliente";
            this.FamiliaCliente.HeaderText = "Agrup. Cliente";
            this.FamiliaCliente.Name = "FamiliaCliente";
            this.FamiliaCliente.ReadOnly = true;
            this.FamiliaCliente.Width = 80;
            // 
            // LeadTimeFabrica
            // 
            this.LeadTimeFabrica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LeadTimeFabrica.DataPropertyName = "LeadTimeFabrica";
            this.LeadTimeFabrica.HeaderText = "Lead Time";
            this.LeadTimeFabrica.Name = "LeadTimeFabrica";
            this.LeadTimeFabrica.ReadOnly = true;
            this.LeadTimeFabrica.Visible = false;
            this.LeadTimeFabrica.Width = 70;
            // 
            // RegraDimensao
            // 
            this.RegraDimensao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RegraDimensao.DataPropertyName = "RegraDimensao";
            this.RegraDimensao.HeaderText = "Regra Dimensão";
            this.RegraDimensao.Name = "RegraDimensao";
            this.RegraDimensao.ReadOnly = true;
            this.RegraDimensao.Visible = false;
            this.RegraDimensao.Width = 150;
            // 
            // CalculoPreco
            // 
            this.CalculoPreco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CalculoPreco.DataPropertyName = "CalculoPreco";
            this.CalculoPreco.HeaderText = "Cálculo Preco";
            this.CalculoPreco.Name = "CalculoPreco";
            this.CalculoPreco.ReadOnly = true;
            this.CalculoPreco.Visible = false;
            this.CalculoPreco.Width = 150;
            // 
            // LoteEconomico
            // 
            this.LoteEconomico.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LoteEconomico.DataPropertyName = "LoteEconomico";
            this.LoteEconomico.HeaderText = "Lote Padrão";
            this.LoteEconomico.Name = "LoteEconomico";
            this.LoteEconomico.ReadOnly = true;
            this.LoteEconomico.Visible = false;
            // 
            // ClassificacaoProduto
            // 
            this.ClassificacaoProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClassificacaoProduto.DataPropertyName = "ClassificacaoProduto";
            this.ClassificacaoProduto.HeaderText = "Classificação";
            this.ClassificacaoProduto.Name = "ClassificacaoProduto";
            this.ClassificacaoProduto.ReadOnly = true;
            this.ClassificacaoProduto.Visible = false;
            this.ClassificacaoProduto.Width = 150;
            // 
            // ModeloEtiqueta
            // 
            this.ModeloEtiqueta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ModeloEtiqueta.DataPropertyName = "ModeloEtiquetaExpedicao";
            this.ModeloEtiqueta.HeaderText = "Modelo Etiqueta";
            this.ModeloEtiqueta.Name = "ModeloEtiqueta";
            this.ModeloEtiqueta.ReadOnly = true;
            this.ModeloEtiqueta.Visible = false;
            this.ModeloEtiqueta.Width = 150;
            // 
            // QtdEtiquetaExpedicaoVolume
            // 
            this.QtdEtiquetaExpedicaoVolume.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.QtdEtiquetaExpedicaoVolume.DataPropertyName = "QtdEtiquetaExpedicaoVolume";
            this.QtdEtiquetaExpedicaoVolume.HeaderText = "Qtd Etiqueta Expedicao Volume";
            this.QtdEtiquetaExpedicaoVolume.Name = "QtdEtiquetaExpedicaoVolume";
            this.QtdEtiquetaExpedicaoVolume.ReadOnly = true;
            this.QtdEtiquetaExpedicaoVolume.Visible = false;
            this.QtdEtiquetaExpedicaoVolume.Width = 70;
            // 
            // Embalagem
            // 
            this.Embalagem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Embalagem.DataPropertyName = "Embalagem";
            this.Embalagem.HeaderText = "Embalagem";
            this.Embalagem.Name = "Embalagem";
            this.Embalagem.ReadOnly = true;
            this.Embalagem.Visible = false;
            this.Embalagem.Width = 150;
            // 
            // DescricaoIngles
            // 
            this.DescricaoIngles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescricaoIngles.DataPropertyName = "DescricaoIngles";
            this.DescricaoIngles.HeaderText = "Descrição Inglês";
            this.DescricaoIngles.Name = "DescricaoIngles";
            this.DescricaoIngles.ReadOnly = true;
            this.DescricaoIngles.Visible = false;
            this.DescricaoIngles.Width = 150;
            // 
            // DescricaoEspanhol
            // 
            this.DescricaoEspanhol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescricaoEspanhol.DataPropertyName = "DescricaoEspanhol";
            this.DescricaoEspanhol.HeaderText = "Descrição Espanhol";
            this.DescricaoEspanhol.Name = "DescricaoEspanhol";
            this.DescricaoEspanhol.ReadOnly = true;
            this.DescricaoEspanhol.Visible = false;
            this.DescricaoEspanhol.Width = 150;
            // 
            // PesoUnitario
            // 
            this.PesoUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PesoUnitario.DataPropertyName = "PesoUnitario";
            this.PesoUnitario.HeaderText = "Peso Unitário";
            this.PesoUnitario.Name = "PesoUnitario";
            this.PesoUnitario.ReadOnly = true;
            this.PesoUnitario.Visible = false;
            // 
            // CadastroPcp
            // 
            this.CadastroPcp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CadastroPcp.DataPropertyName = "CadastroPcp";
            this.CadastroPcp.HeaderText = "Cadastro Pcp Realizado";
            this.CadastroPcp.Name = "CadastroPcp";
            this.CadastroPcp.ReadOnly = true;
            this.CadastroPcp.Visible = false;
            this.CadastroPcp.Width = 70;
            // 
            // CadastroEngenharia
            // 
            this.CadastroEngenharia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CadastroEngenharia.DataPropertyName = "CadastroEngenharia";
            this.CadastroEngenharia.HeaderText = "Cadastro Engenharia Realizado";
            this.CadastroEngenharia.Name = "CadastroEngenharia";
            this.CadastroEngenharia.ReadOnly = true;
            this.CadastroEngenharia.Visible = false;
            this.CadastroEngenharia.Width = 70;
            // 
            // Acabamento
            // 
            this.Acabamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Acabamento.DataPropertyName = "Acabamento";
            this.Acabamento.HeaderText = "Acabamento";
            this.Acabamento.Name = "Acabamento";
            this.Acabamento.ReadOnly = true;
            this.Acabamento.Visible = false;
            this.Acabamento.Width = 150;
            // 
            // Variavel1
            // 
            this.Variavel1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Variavel1.DataPropertyName = "Variavel1";
            this.Variavel1.HeaderText = "Variável 1";
            this.Variavel1.Name = "Variavel1";
            this.Variavel1.ReadOnly = true;
            this.Variavel1.Visible = false;
            this.Variavel1.Width = 150;
            // 
            // Variavel2
            // 
            this.Variavel2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Variavel2.DataPropertyName = "Variavel2";
            this.Variavel2.HeaderText = "Variável 2";
            this.Variavel2.Name = "Variavel2";
            this.Variavel2.ReadOnly = true;
            this.Variavel2.Visible = false;
            this.Variavel2.Width = 150;
            // 
            // Variavel3
            // 
            this.Variavel3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Variavel3.DataPropertyName = "Variavel3";
            this.Variavel3.HeaderText = "Variável 3";
            this.Variavel3.Name = "Variavel3";
            this.Variavel3.ReadOnly = true;
            this.Variavel3.Visible = false;
            this.Variavel3.Width = 150;
            // 
            // Variavel4
            // 
            this.Variavel4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Variavel4.DataPropertyName = "Variavel4";
            this.Variavel4.HeaderText = "Variável 4";
            this.Variavel4.Name = "Variavel4";
            this.Variavel4.ReadOnly = true;
            this.Variavel4.Visible = false;
            this.Variavel4.Width = 150;
            // 
            // UnidadeMedida
            // 
            this.UnidadeMedida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadeMedida.DataPropertyName = "UnidadeMedida";
            this.UnidadeMedida.HeaderText = "Unidade de Medida";
            this.UnidadeMedida.Name = "UnidadeMedida";
            this.UnidadeMedida.ReadOnly = true;
            this.UnidadeMedida.Visible = false;
            this.UnidadeMedida.Width = 150;
            // 
            // UtilizaDimensaoMaiorFilho
            // 
            this.UtilizaDimensaoMaiorFilho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UtilizaDimensaoMaiorFilho.DataPropertyName = "UtilizaDimensaoMaiorFilho";
            this.UtilizaDimensaoMaiorFilho.HeaderText = "Utiliza Dimensão Maior Filho";
            this.UtilizaDimensaoMaiorFilho.Name = "UtilizaDimensaoMaiorFilho";
            this.UtilizaDimensaoMaiorFilho.ReadOnly = true;
            this.UtilizaDimensaoMaiorFilho.Visible = false;
            this.UtilizaDimensaoMaiorFilho.Width = 70;
            // 
            // AgrupadorOp
            // 
            this.AgrupadorOp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AgrupadorOp.DataPropertyName = "AgrupadorOp";
            this.AgrupadorOp.HeaderText = "Agrupador de Op";
            this.AgrupadorOp.Name = "AgrupadorOp";
            this.AgrupadorOp.ReadOnly = true;
            this.AgrupadorOp.Visible = false;
            this.AgrupadorOp.Width = 150;
            // 
            // AplicacaoCliente
            // 
            this.AplicacaoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AplicacaoCliente.DataPropertyName = "AplicacaoCliente";
            this.AplicacaoCliente.HeaderText = "Aplicação no Cliente";
            this.AplicacaoCliente.Name = "AplicacaoCliente";
            this.AplicacaoCliente.ReadOnly = true;
            this.AplicacaoCliente.Visible = false;
            this.AplicacaoCliente.Width = 150;
            // 
            // TempoLimite
            // 
            this.TempoLimite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TempoLimite.DataPropertyName = "TempoLimite";
            this.TempoLimite.HeaderText = "Tempo Limite Conferência";
            this.TempoLimite.Name = "TempoLimite";
            this.TempoLimite.ReadOnly = true;
            this.TempoLimite.Visible = false;
            this.TempoLimite.Width = 70;
            // 
            // CadastroPreco
            // 
            this.CadastroPreco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CadastroPreco.DataPropertyName = "CadastroPreco";
            this.CadastroPreco.HeaderText = "Cadastro Preco Realizado";
            this.CadastroPreco.Name = "CadastroPreco";
            this.CadastroPreco.ReadOnly = true;
            this.CadastroPreco.Visible = false;
            this.CadastroPreco.Width = 70;
            // 
            // Temporario
            // 
            this.Temporario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Temporario.DataPropertyName = "Temporario";
            this.Temporario.HeaderText = "Produto Temporário";
            this.Temporario.Name = "Temporario";
            this.Temporario.ReadOnly = true;
            this.Temporario.Visible = false;
            this.Temporario.Width = 70;
            // 
            // Vermelho
            // 
            this.Vermelho.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Vermelho.DataPropertyName = "Vermelho";
            this.Vermelho.HeaderText = "Vermelho";
            this.Vermelho.Name = "Vermelho";
            this.Vermelho.ReadOnly = true;
            this.Vermelho.Visible = false;
            // 
            // Verde
            // 
            this.Verde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Verde.DataPropertyName = "Verde";
            this.Verde.HeaderText = "Verde";
            this.Verde.Name = "Verde";
            this.Verde.ReadOnly = true;
            this.Verde.Visible = false;
            // 
            // Amarelo
            // 
            this.Amarelo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Amarelo.DataPropertyName = "Amarelo";
            this.Amarelo.HeaderText = "Amarelo";
            this.Amarelo.Name = "Amarelo";
            this.Amarelo.ReadOnly = true;
            this.Amarelo.Visible = false;
            // 
            // LotePadraoCompra
            // 
            this.LotePadraoCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LotePadraoCompra.DataPropertyName = "LotePadraoCompra";
            this.LotePadraoCompra.HeaderText = "Lote Padrão Compra";
            this.LotePadraoCompra.Name = "LotePadraoCompra";
            this.LotePadraoCompra.ReadOnly = true;
            this.LotePadraoCompra.Visible = false;
            // 
            // LoteMinimoCompraColumn
            // 
            this.LoteMinimoCompraColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LoteMinimoCompraColumn.DataPropertyName = "LoteMinimo";
            this.LoteMinimoCompraColumn.HeaderText = "Lote Mínimo Compra";
            this.LoteMinimoCompraColumn.Name = "LoteMinimoCompraColumn";
            this.LoteMinimoCompraColumn.ReadOnly = true;
            // 
            // UnidadeMedidaCompra
            // 
            this.UnidadeMedidaCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadeMedidaCompra.DataPropertyName = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.HeaderText = "Unidade Medida Compra";
            this.UnidadeMedidaCompra.Name = "UnidadeMedidaCompra";
            this.UnidadeMedidaCompra.ReadOnly = true;
            this.UnidadeMedidaCompra.Visible = false;
            this.UnidadeMedidaCompra.Width = 150;
            // 
            // UnidadesPorUnCompra
            // 
            this.UnidadesPorUnCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnidadesPorUnCompra.DataPropertyName = "UnidadesPorUnCompra";
            this.UnidadesPorUnCompra.HeaderText = "Unidades Por Un Compra";
            this.UnidadesPorUnCompra.Name = "UnidadesPorUnCompra";
            this.UnidadesPorUnCompra.ReadOnly = true;
            this.UnidadesPorUnCompra.Visible = false;
            // 
            // LeadTimeCompra
            // 
            this.LeadTimeCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LeadTimeCompra.DataPropertyName = "LeadTimeCompra";
            this.LeadTimeCompra.HeaderText = "Leadtime Compra";
            this.LeadTimeCompra.Name = "LeadTimeCompra";
            this.LeadTimeCompra.ReadOnly = true;
            this.LeadTimeCompra.Visible = false;
            this.LeadTimeCompra.Width = 70;
            // 
            // MarcasHomologadas
            // 
            this.MarcasHomologadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MarcasHomologadas.DataPropertyName = "MarcasHomologadas";
            this.MarcasHomologadas.HeaderText = "Marcas Homologadas";
            this.MarcasHomologadas.Name = "MarcasHomologadas";
            this.MarcasHomologadas.ReadOnly = true;
            this.MarcasHomologadas.Visible = false;
            this.MarcasHomologadas.Width = 150;
            // 
            // ImpedirSolicitacaoAuto
            // 
            this.ImpedirSolicitacaoAuto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImpedirSolicitacaoAuto.DataPropertyName = "ImpedirSolicitacaoAuto";
            this.ImpedirSolicitacaoAuto.HeaderText = "Impedir Solicitação Auto";
            this.ImpedirSolicitacaoAuto.Name = "ImpedirSolicitacaoAuto";
            this.ImpedirSolicitacaoAuto.ReadOnly = true;
            this.ImpedirSolicitacaoAuto.Visible = false;
            this.ImpedirSolicitacaoAuto.Width = 70;
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
            // RegraValidVar1
            // 
            this.RegraValidVar1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RegraValidVar1.DataPropertyName = "RegraValidVar1";
            this.RegraValidVar1.HeaderText = "Regra Validação da Variável 1";
            this.RegraValidVar1.Name = "RegraValidVar1";
            this.RegraValidVar1.ReadOnly = true;
            this.RegraValidVar1.Visible = false;
            this.RegraValidVar1.Width = 150;
            // 
            // RegraValidVar2
            // 
            this.RegraValidVar2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RegraValidVar2.DataPropertyName = "RegraValidVar2";
            this.RegraValidVar2.HeaderText = "Regra Validação da Variável 2";
            this.RegraValidVar2.Name = "RegraValidVar2";
            this.RegraValidVar2.ReadOnly = true;
            this.RegraValidVar2.Visible = false;
            this.RegraValidVar2.Width = 150;
            // 
            // RegraValidVar3
            // 
            this.RegraValidVar3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RegraValidVar3.DataPropertyName = "RegraValidVar3";
            this.RegraValidVar3.HeaderText = "Regra Validação da Variável 3";
            this.RegraValidVar3.Name = "RegraValidVar3";
            this.RegraValidVar3.ReadOnly = true;
            this.RegraValidVar3.Visible = false;
            this.RegraValidVar3.Width = 150;
            // 
            // RegraValidVar4
            // 
            this.RegraValidVar4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RegraValidVar4.DataPropertyName = "RegraValidVar4";
            this.RegraValidVar4.HeaderText = "Regra Validação da Variável 4";
            this.RegraValidVar4.Name = "RegraValidVar4";
            this.RegraValidVar4.ReadOnly = true;
            this.RegraValidVar4.Visible = false;
            this.RegraValidVar4.Width = 150;
            // 
            // UtilizandoEstoqueSeguranca
            // 
            this.UtilizandoEstoqueSeguranca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UtilizandoEstoqueSeguranca.DataPropertyName = "UtilizandoEstoqueSeguranca";
            this.UtilizandoEstoqueSeguranca.HeaderText = "Utilizando Estoque Segurança";
            this.UtilizandoEstoqueSeguranca.Name = "UtilizandoEstoqueSeguranca";
            this.UtilizandoEstoqueSeguranca.ReadOnly = true;
            this.UtilizandoEstoqueSeguranca.Visible = false;
            this.UtilizandoEstoqueSeguranca.Width = 150;
            // 
            // UtilizandoEstoqueSegurancaData
            // 
            this.UtilizandoEstoqueSegurancaData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UtilizandoEstoqueSegurancaData.DataPropertyName = "UtilizandoEstoqueSegurancaData";
            this.UtilizandoEstoqueSegurancaData.HeaderText = "Utilizando Estoque Segurança Data";
            this.UtilizandoEstoqueSegurancaData.Name = "UtilizandoEstoqueSegurancaData";
            this.UtilizandoEstoqueSegurancaData.ReadOnly = true;
            this.UtilizandoEstoqueSegurancaData.Visible = false;
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
            // Comprador
            // 
            this.Comprador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Comprador.DataPropertyName = "Comprador";
            this.Comprador.HeaderText = "Comprador";
            this.Comprador.Name = "Comprador";
            this.Comprador.ReadOnly = true;
            this.Comprador.Visible = false;
            this.Comprador.Width = 150;
            // 
            // PermiteVenda
            // 
            this.PermiteVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PermiteVenda.DataPropertyName = "PermiteVenda";
            this.PermiteVenda.HeaderText = "Permite Venda";
            this.PermiteVenda.Name = "PermiteVenda";
            this.PermiteVenda.ReadOnly = true;
            this.PermiteVenda.Visible = false;
            this.PermiteVenda.Width = 70;
            // 
            // DescricaoAdicional
            // 
            this.DescricaoAdicional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DescricaoAdicional.DataPropertyName = "DescricaoAdicional";
            this.DescricaoAdicional.HeaderText = "Descrição Adicional";
            this.DescricaoAdicional.Name = "DescricaoAdicional";
            this.DescricaoAdicional.ReadOnly = true;
            this.DescricaoAdicional.Visible = false;
            this.DescricaoAdicional.Width = 150;
            // 
            // ImprimirEstruturaOp
            // 
            this.ImprimirEstruturaOp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImprimirEstruturaOp.DataPropertyName = "ImprimirEstruturaOp";
            this.ImprimirEstruturaOp.HeaderText = "Imprimir Estrutura Com a OP";
            this.ImprimirEstruturaOp.Name = "ImprimirEstruturaOp";
            this.ImprimirEstruturaOp.ReadOnly = true;
            this.ImprimirEstruturaOp.Visible = false;
            this.ImprimirEstruturaOp.Width = 70;
            // 
            // ImprimeOpsRelacionadas
            // 
            this.ImprimeOpsRelacionadas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ImprimeOpsRelacionadas.DataPropertyName = "ImprimeOpsRelacionadas";
            this.ImprimeOpsRelacionadas.HeaderText = "Imprime Ops Relacionadas";
            this.ImprimeOpsRelacionadas.Name = "ImprimeOpsRelacionadas";
            this.ImprimeOpsRelacionadas.ReadOnly = true;
            this.ImprimeOpsRelacionadas.Visible = false;
            this.ImprimeOpsRelacionadas.Width = 70;
            // 
            // MargemRecebimento
            // 
            this.MargemRecebimento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MargemRecebimento.DataPropertyName = "MargemRecebimento";
            this.MargemRecebimento.HeaderText = "Margem Recebimento";
            this.MargemRecebimento.Name = "MargemRecebimento";
            this.MargemRecebimento.ReadOnly = true;
            this.MargemRecebimento.Visible = false;
            // 
            // ValidacaoPesoExpedicao
            // 
            this.ValidacaoPesoExpedicao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ValidacaoPesoExpedicao.DataPropertyName = "ValidacaoPesoExpedicao";
            this.ValidacaoPesoExpedicao.HeaderText = "Validação Peso na Expedição";
            this.ValidacaoPesoExpedicao.Name = "ValidacaoPesoExpedicao";
            this.ValidacaoPesoExpedicao.ReadOnly = true;
            this.ValidacaoPesoExpedicao.Visible = false;
            this.ValidacaoPesoExpedicao.Width = 70;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            // 
            // BloqueioPrecoVencido
            // 
            this.BloqueioPrecoVencido.DataPropertyName = "BloqueioPrecoVencido";
            this.BloqueioPrecoVencido.HeaderText = "Bloqueado por Preço Vencido";
            this.BloqueioPrecoVencido.Name = "BloqueioPrecoVencido";
            this.BloqueioPrecoVencido.ReadOnly = true;
            // 
            // btnEstrutura
            // 
            this.btnEstrutura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstrutura.LiberadoQuandoCadastroUtilizado = false;
            this.btnEstrutura.Location = new System.Drawing.Point(129, 28);
            this.btnEstrutura.Name = "btnEstrutura";
            this.btnEstrutura.Size = new System.Drawing.Size(111, 23);
            this.btnEstrutura.TabIndex = 5;
            this.btnEstrutura.Text = "Editar Estrutura";
            this.btnEstrutura.UseVisualStyleBackColor = true;
            this.btnEstrutura.Click += new System.EventHandler(this.btnEstrutura_Click);
            // 
            // btnPCP
            // 
            this.btnPCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPCP.LiberadoQuandoCadastroUtilizado = false;
            this.btnPCP.Location = new System.Drawing.Point(246, 2);
            this.btnPCP.Name = "btnPCP";
            this.btnPCP.Size = new System.Drawing.Size(110, 23);
            this.btnPCP.TabIndex = 2;
            this.btnPCP.Text = "PCP";
            this.btnPCP.UseVisualStyleBackColor = true;
            this.btnPCP.Click += new System.EventHandler(this.btnPCP_Click);
            // 
            // btnCusto
            // 
            this.btnCusto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCusto.LiberadoQuandoCadastroUtilizado = false;
            this.btnCusto.Location = new System.Drawing.Point(362, 28);
            this.btnCusto.Name = "btnCusto";
            this.btnCusto.Size = new System.Drawing.Size(115, 23);
            this.btnCusto.TabIndex = 7;
            this.btnCusto.Text = "Simulador Custo";
            this.btnCusto.UseVisualStyleBackColor = true;
            this.btnCusto.Click += new System.EventHandler(this.btnCusto_Click);
            // 
            // btnRevisao
            // 
            this.btnRevisao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRevisao.LiberadoQuandoCadastroUtilizado = false;
            this.btnRevisao.Location = new System.Drawing.Point(7, 28);
            this.btnRevisao.Name = "btnRevisao";
            this.btnRevisao.Size = new System.Drawing.Size(116, 23);
            this.btnRevisao.TabIndex = 4;
            this.btnRevisao.Text = "Produto em Revisão";
            this.btnRevisao.UseVisualStyleBackColor = true;
            this.btnRevisao.Click += new System.EventHandler(this.btnRevisao_Click);
            // 
            // btnEtiqueta
            // 
            this.btnEtiqueta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEtiqueta.LiberadoQuandoCadastroUtilizado = false;
            this.btnEtiqueta.Location = new System.Drawing.Point(129, 57);
            this.btnEtiqueta.Name = "btnEtiqueta";
            this.btnEtiqueta.Size = new System.Drawing.Size(166, 23);
            this.btnEtiqueta.TabIndex = 9;
            this.btnEtiqueta.Text = "Etiqueta de KB de comprados";
            this.btnEtiqueta.UseVisualStyleBackColor = true;
            this.btnEtiqueta.Click += new System.EventHandler(this.btnEtiqueta_Click);
            // 
            // btnCriarEditarKbMan
            // 
            this.btnCriarEditarKbMan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriarEditarKbMan.LiberadoQuandoCadastroUtilizado = false;
            this.btnCriarEditarKbMan.Location = new System.Drawing.Point(301, 57);
            this.btnCriarEditarKbMan.Name = "btnCriarEditarKbMan";
            this.btnCriarEditarKbMan.Size = new System.Drawing.Size(175, 23);
            this.btnCriarEditarKbMan.TabIndex = 10;
            this.btnCriarEditarKbMan.Text = "Criar/Editar KB de manufaturados";
            this.btnCriarEditarKbMan.UseVisualStyleBackColor = true;
            this.btnCriarEditarKbMan.Click += new System.EventHandler(this.btnCriarEditarKbMan_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.LiberadoQuandoCadastroUtilizado = false;
            this.btnEditar.Location = new System.Drawing.Point(129, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(111, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.LiberadoQuandoCadastroUtilizado = false;
            this.btnNovo.Location = new System.Drawing.Point(7, 2);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(115, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.LiberadoQuandoCadastroUtilizado = false;
            this.btnExcluir.Location = new System.Drawing.Point(362, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(114, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // iwtSelecionarButton1
            // 
            this.iwtSelecionarButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iwtSelecionarButton1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtSelecionarButton1.Location = new System.Drawing.Point(363, 2);
            this.iwtSelecionarButton1.Name = "iwtSelecionarButton1";
            this.iwtSelecionarButton1.Size = new System.Drawing.Size(114, 23);
            this.iwtSelecionarButton1.TabIndex = 4;
            this.iwtSelecionarButton1.Text = "Selecionar";
            this.iwtSelecionarButton1.UseVisualStyleBackColor = true;
            // 
            // btnHistoricoCompra
            // 
            this.btnHistoricoCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistoricoCompra.LiberadoQuandoCadastroUtilizado = false;
            this.btnHistoricoCompra.Location = new System.Drawing.Point(7, 56);
            this.btnHistoricoCompra.Name = "btnHistoricoCompra";
            this.btnHistoricoCompra.Size = new System.Drawing.Size(115, 24);
            this.btnHistoricoCompra.TabIndex = 8;
            this.btnHistoricoCompra.Text = "Histórico Compra";
            this.btnHistoricoCompra.UseVisualStyleBackColor = true;
            this.btnHistoricoCompra.Click += new System.EventHandler(this.btnHistoricoCompra_Click);
            // 
            // btnVisualizarEstrutura
            // 
            this.btnVisualizarEstrutura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizarEstrutura.LiberadoQuandoCadastroUtilizado = false;
            this.btnVisualizarEstrutura.Location = new System.Drawing.Point(246, 28);
            this.btnVisualizarEstrutura.Name = "btnVisualizarEstrutura";
            this.btnVisualizarEstrutura.Size = new System.Drawing.Size(111, 23);
            this.btnVisualizarEstrutura.TabIndex = 6;
            this.btnVisualizarEstrutura.Text = "Visualizar Estrutura";
            this.btnVisualizarEstrutura.UseVisualStyleBackColor = true;
            this.btnVisualizarEstrutura.Click += new System.EventHandler(this.btnVisualizarEstrutura_Click);
            // 
            // btnDesbloqueioVencido
            // 
            this.btnDesbloqueioVencido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDesbloqueioVencido.LiberadoQuandoCadastroUtilizado = false;
            this.btnDesbloqueioVencido.Location = new System.Drawing.Point(246, 83);
            this.btnDesbloqueioVencido.Name = "btnDesbloqueioVencido";
            this.btnDesbloqueioVencido.Size = new System.Drawing.Size(231, 23);
            this.btnDesbloqueioVencido.TabIndex = 12;
            this.btnDesbloqueioVencido.Text = "Desbloquear por Preço Vencido";
            this.btnDesbloqueioVencido.UseVisualStyleBackColor = true;
            this.btnDesbloqueioVencido.Click += new System.EventHandler(this.btnDesbloqueioVencido_Click);
            // 
            // btnBloqueioVencido
            // 
            this.btnBloqueioVencido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBloqueioVencido.LiberadoQuandoCadastroUtilizado = false;
            this.btnBloqueioVencido.Location = new System.Drawing.Point(7, 83);
            this.btnBloqueioVencido.Name = "btnBloqueioVencido";
            this.btnBloqueioVencido.Size = new System.Drawing.Size(233, 23);
            this.btnBloqueioVencido.TabIndex = 11;
            this.btnBloqueioVencido.Text = "Bloquear por Preço Vencido";
            this.btnBloqueioVencido.UseVisualStyleBackColor = true;
            this.btnBloqueioVencido.Click += new System.EventHandler(this.btnBloqueioVencido_Click);
            // 
            // CadProdutoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(900, 446);
            this.Name = "CadProdutoListForm";
            this.Text = "Produtos - Manufaturados ou comprados Sob Desenho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadProdutoListForm_FormClosing);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.iwtSearchPanel1.ResumeLayout(false);
            this.iwtSearchPanel1.PerformLayout();
            this.grbFiltroStatus.ResumeLayout(false);
            this.grbFiltroStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iwtDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTSearchPanel iwtSearchPanel1;
        private IWTDotNetLib.IWTTextBox iwtTextBox1;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private IWTDotNetLib.IWTDataGridView iwtDataGridView1;
        private IWTDotNetLib.IWTButton btnCriarEditarKbMan;
        private IWTDotNetLib.IWTButton btnEtiqueta;
        private IWTDotNetLib.IWTButton btnRevisao;
        private IWTDotNetLib.IWTButton btnEstrutura;
        private IWTDotNetLib.IWTButton btnCusto;
        private IWTDotNetLib.IWTButton btnPCP;
        private IWTSelecionarButton iwtSelecionarButton1;
        private IWTExcluirButton btnExcluir;
        private IWTNovoButton btnNovo;
        private IWTEditarButton btnEditar;
        private IWTButton btnHistoricoCompra;
        private IWTButton btnVisualizarEstrutura;
        private System.Windows.Forms.GroupBox grbFiltroStatus;
        private IWTRadioButton iwtRadioButton3;
        private IWTRadioButton iwtRadioButton2;
        private IWTRadioButton rdbAtivo;
        private IWTButton btnDesbloqueioVencido;
        private IWTButton btnBloqueioVencido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EstruturaEmRevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstruturaEmRevisaoObservacaoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gtin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAquisicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoliticaEstoque;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EmiteOp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EmitePlanoCorte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EtiquetaInterna;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalFabricacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataRevisaoCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcsUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoRevisao;
        private System.Windows.Forms.DataGridViewTextBoxColumn VersaoEstruturaAtual;
        private System.Windows.Forms.DataGridViewTextBoxColumn FamiliaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadTimeFabrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegraDimensao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalculoPreco;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoteEconomico;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassificacaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModeloEtiqueta;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtdEtiquetaExpedicaoVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Embalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoIngles;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoEspanhol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoUnitario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CadastroPcp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CadastroEngenharia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acabamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variavel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variavel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variavel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variavel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedida;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UtilizaDimensaoMaiorFilho;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgrupadorOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn AplicacaoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempoLimite;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CadastroPreco;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Temporario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vermelho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verde;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amarelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotePadraoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoteMinimoCompraColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedidaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadesPorUnCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadTimeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarcasHomologadas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImpedirSolicitacaoAuto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RastreamentoMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegraValidVar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegraValidVar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegraValidVar3;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegraValidVar4;
        private System.Windows.Forms.DataGridViewTextBoxColumn UtilizandoEstoqueSeguranca;
        private System.Windows.Forms.DataGridViewTextBoxColumn UtilizandoEstoqueSegurancaData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResponsavelFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comprador;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PermiteVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoAdicional;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImprimirEstruturaOp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ImprimeOpsRelacionadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn MargemRecebimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidacaoPesoExpedicao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BloqueioPrecoVencido;
    }
} 
