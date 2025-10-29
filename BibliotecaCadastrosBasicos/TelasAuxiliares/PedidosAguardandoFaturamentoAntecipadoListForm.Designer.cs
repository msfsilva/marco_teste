namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    partial class PedidosAguardandoFaturamentoAntecipadoListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPedidos = new IWTDotNetLib.IWTDataGridView(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroPosicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusTraduzido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdutoCodigoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassificacaoProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjetoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SemanaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataConfiguracao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaNf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataUltimaNf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataEncerramento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Feedback = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuspensaoObs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubLinha = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Urgente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrgenteSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrgenteDataPrometida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UrgenteInformacoesComplementares = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.txtBusca = new IWTDotNetLib.IWTTextBox(this.components);
            this.iwtLabel1 = new IWTDotNetLib.IWTLabel(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFaturar = new IWTDotNetLib.IWTButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.AllowUserToAddRows = false;
            this.dgvPedidos.AllowUserToDeleteRows = false;
            this.dgvPedidos.AllowUserToOrderColumns = true;
            this.dgvPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedidos.CacheDados = null;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Cliente,
            this.NumeroPosicao,
            this.StatusTraduzido,
            this.ProdutoCodigoCliente,
            this.ClassificacaoProduto,
            this.ProjetoCliente,
            this.Quantidade,
            this.Saldo,
            this.DataEntrega,
            this.SemanaEntrega,
            this.DataEntrada,
            this.DataConfiguracao,
            this.UltimaNf,
            this.DataUltimaNf,
            this.DataEncerramento,
            this.Feedback,
            this.SuspensaoObs,
            this.Numero,
            this.Posicao,
            this.SubLinha,
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
            this.Urgente,
            this.UrgenteSolicitante,
            this.UrgenteDataPrometida,
            this.UrgenteInformacoesComplementares,
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
            this.dgvPedidos.Dock = System.Windows.Forms.DockStyle.None;
            this.dgvPedidos.Location = new System.Drawing.Point(4, 3);
            this.dgvPedidos.MultiSelect = false;
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidos.Size = new System.Drawing.Size(976, 326);
            this.dgvPedidos.TabIndex = 1;
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
            this.NumeroPosicao.HeaderText = "OC/Pos";
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
            // Saldo
            // 
            this.Saldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Saldo.DataPropertyName = "Saldo";
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 50;
            // 
            // DataEntrega
            // 
            this.DataEntrega.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEntrega.DataPropertyName = "DataEntrega";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.DataEntrega.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.DataEntrada.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataEntrada.HeaderText = "Cadastro";
            this.DataEntrada.Name = "DataEntrada";
            this.DataEntrada.ReadOnly = true;
            this.DataEntrada.Width = 95;
            // 
            // DataConfiguracao
            // 
            this.DataConfiguracao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataConfiguracao.DataPropertyName = "DataConfiguracao";
            this.DataConfiguracao.HeaderText = "Configuração";
            this.DataConfiguracao.Name = "DataConfiguracao";
            this.DataConfiguracao.ReadOnly = true;
            this.DataConfiguracao.Width = 95;
            // 
            // UltimaNf
            // 
            this.UltimaNf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UltimaNf.DataPropertyName = "UltimaNf";
            this.UltimaNf.HeaderText = "Última NF";
            this.UltimaNf.Name = "UltimaNf";
            this.UltimaNf.ReadOnly = true;
            this.UltimaNf.Width = 60;
            // 
            // DataUltimaNf
            // 
            this.DataUltimaNf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataUltimaNf.DataPropertyName = "DataUltimaNf";
            this.DataUltimaNf.HeaderText = "Data última NF";
            this.DataUltimaNf.Name = "DataUltimaNf";
            this.DataUltimaNf.ReadOnly = true;
            this.DataUltimaNf.Width = 80;
            // 
            // DataEncerramento
            // 
            this.DataEncerramento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DataEncerramento.DataPropertyName = "DataEncerramento";
            this.DataEncerramento.HeaderText = "Encerramento";
            this.DataEncerramento.Name = "DataEncerramento";
            this.DataEncerramento.ReadOnly = true;
            // 
            // Feedback
            // 
            this.Feedback.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Feedback.DataPropertyName = "FeedbackAtual";
            this.Feedback.HeaderText = "Feedback";
            this.Feedback.Name = "Feedback";
            this.Feedback.ReadOnly = true;
            this.Feedback.Width = 350;
            // 
            // SuspensaoObs
            // 
            this.SuspensaoObs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SuspensaoObs.DataPropertyName = "SuspensaoObs";
            this.SuspensaoObs.HeaderText = "Observação de Suspensão / Retirada de Suspensão";
            this.SuspensaoObs.Name = "SuspensaoObs";
            this.SuspensaoObs.ReadOnly = true;
            this.SuspensaoObs.Width = 350;
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
            // SubLinha
            // 
            this.SubLinha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SubLinha.DataPropertyName = "SubLinha";
            this.SubLinha.HeaderText = "SubLinha";
            this.SubLinha.Name = "SubLinha";
            this.SubLinha.ReadOnly = true;
            this.SubLinha.Visible = false;
            this.SubLinha.Width = 70;
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
            // Urgente
            // 
            this.Urgente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Urgente.DataPropertyName = "Urgente";
            this.Urgente.HeaderText = "Urgente";
            this.Urgente.Name = "Urgente";
            this.Urgente.ReadOnly = true;
            this.Urgente.Visible = false;
            this.Urgente.Width = 150;
            // 
            // UrgenteSolicitante
            // 
            this.UrgenteSolicitante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UrgenteSolicitante.DataPropertyName = "UrgenteSolicitante";
            this.UrgenteSolicitante.HeaderText = "Urgente Solicitante";
            this.UrgenteSolicitante.Name = "UrgenteSolicitante";
            this.UrgenteSolicitante.ReadOnly = true;
            this.UrgenteSolicitante.Visible = false;
            this.UrgenteSolicitante.Width = 150;
            // 
            // UrgenteDataPrometida
            // 
            this.UrgenteDataPrometida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UrgenteDataPrometida.DataPropertyName = "UrgenteDataPrometida";
            this.UrgenteDataPrometida.HeaderText = "Urgente Data Prometida";
            this.UrgenteDataPrometida.Name = "UrgenteDataPrometida";
            this.UrgenteDataPrometida.ReadOnly = true;
            this.UrgenteDataPrometida.Visible = false;
            // 
            // UrgenteInformacoesComplementares
            // 
            this.UrgenteInformacoesComplementares.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UrgenteInformacoesComplementares.DataPropertyName = "UrgenteInformacoesComplementares";
            this.UrgenteInformacoesComplementares.HeaderText = "Urgente Informações Complementares";
            this.UrgenteInformacoesComplementares.Name = "UrgenteInformacoesComplementares";
            this.UrgenteInformacoesComplementares.ReadOnly = true;
            this.UrgenteInformacoesComplementares.Visible = false;
            this.UrgenteInformacoesComplementares.Width = 150;
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
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBusca.BindingField = "";
            this.txtBusca.DebugMode = false;
            this.txtBusca.LiberadoQuandoCadastroUtilizado = false;
            this.txtBusca.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.txtBusca.Location = new System.Drawing.Point(57, 355);
            this.txtBusca.ModoBarcode = false;
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.ShortcutsEnabled = false;
            this.txtBusca.Size = new System.Drawing.Size(329, 20);
            this.txtBusca.TabIndex = 2;
            this.txtBusca.TextChanged += new System.EventHandler(this.iwtTextBox1_TextChanged);
            // 
            // iwtLabel1
            // 
            this.iwtLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iwtLabel1.AutoSize = true;
            this.iwtLabel1.BindingField = null;
            this.iwtLabel1.LiberadoQuandoCadastroUtilizado = false;
            this.iwtLabel1.LocalBuscaOrdenacao = IWTDotNetLib.LocalOrdenacao.BD;
            this.iwtLabel1.Location = new System.Drawing.Point(17, 359);
            this.iwtLabel1.Name = "iwtLabel1";
            this.iwtLabel1.Size = new System.Drawing.Size(37, 13);
            this.iwtLabel1.TabIndex = 3;
            this.iwtLabel1.Text = "Busca";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnFaturar
            // 
            this.btnFaturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFaturar.LiberadoQuandoCadastroUtilizado = false;
            this.btnFaturar.Location = new System.Drawing.Point(776, 354);
            this.btnFaturar.Name = "btnFaturar";
            this.btnFaturar.Size = new System.Drawing.Size(196, 23);
            this.btnFaturar.TabIndex = 4;
            this.btnFaturar.Text = "Faturar";
            this.btnFaturar.UseVisualStyleBackColor = true;
            this.btnFaturar.Click += new System.EventHandler(this.btnFaturar_Click);
            // 
            // PedidosAguardandoFaturamentoAntecipadoListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(984, 401);
            this.Controls.Add(this.btnFaturar);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.iwtLabel1);
            this.Controls.Add(this.dgvPedidos);
            this.Name = "PedidosAguardandoFaturamentoAntecipadoListForm";
            this.Text = "Pedidos Aguardando Faturamento Antecipado";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IWTDotNetLib.IWTDataGridView dgvPedidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroPosicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusTraduzido;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutoCodigoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassificacaoProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjetoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn SemanaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataConfiguracao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaNf;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataUltimaNf;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataEncerramento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feedback;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuspensaoObs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubLinha;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Urgente;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrgenteSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrgenteDataPrometida;
        private System.Windows.Forms.DataGridViewTextBoxColumn UrgenteInformacoesComplementares;
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
        private IWTDotNetLib.IWTTextBox txtBusca;
        private IWTDotNetLib.IWTLabel iwtLabel1;
        private System.Windows.Forms.Timer timer1;
        private IWTDotNetLib.IWTButton btnFaturar;
    }
}