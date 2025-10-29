using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.ClassesAuxiliares;
using BibliotecaCentroCusto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using BibliotecaPedidos;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoSimplificadoForm : IWTBaseForm
    {

        private CentroCustoLucroClass centroCustoSelecionado;

        private IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;
        public DateTime dataEntregaTmp;
        private PedidoItemClass _pedidoPosicao1;
        SortedDictionary<int, PedidoLinhaTelaClass> pedidos;
        private TipoForm tipo;
        string numeroAutomatico;


        List<PedidoItemClass> pedidosRemover = new List<PedidoItemClass>();

        public CadPedidoSimplificadoForm(IWTPostgreNpgsqlConnection _conn, AcsUsuarioClass usuario, TipoForm tipo)
        {
            this.conn = _conn;
            this.Usuario = usuario;
            this.tipo = tipo;

            InitTela();

            int pos;
            PedidoItemClass.CarregarNumeroPedidoAutomatico(conn, out numeroAutomatico, out pos);
            this.txtOc.Text = numeroAutomatico;


        }


        public CadPedidoSimplificadoForm(PedidoItemClass pedidoItem, IWTPostgreNpgsqlConnection _conn, AcsUsuarioClass usuario, TipoForm tipo)
        {
            this.conn = _conn;
            this.Usuario = usuario;
            this.tipo = tipo;

            InitTela();

            LoadDadosPedido(pedidoItem);

        }

        private void LoadDadosPedido(PedidoItemClass pedidoPaiTemp)
        {
            if (pedidoPaiTemp.Posicao != 1)
            {
                List<PedidoItemClass> possiveisPedidos = PedidoItemClass.BuscaPedido(pedidoPaiTemp.Numero, 1, pedidoPaiTemp.Cliente, Usuario, conn);
                if (possiveisPedidos.Count == 0)
                {
                    throw new ExcecaoTratada("Não foi possível encontrar a posição 1 do pedido " + pedidoPaiTemp.Numero);
                }

                if (possiveisPedidos.Count > 1)
                {
                    throw new ExcecaoTratada("Foram encontrados múltiplos pedidos para a posição 1 do pedido " + pedidoPaiTemp.Numero);
                }

                _pedidoPosicao1 = possiveisPedidos.First();

            }
            else
            {
                _pedidoPosicao1 = pedidoPaiTemp;
            }

            txtOc.Text = _pedidoPosicao1.Numero;

            txtProjeto.Text = _pedidoPosicao1.ProjetoCliente;
            txtOrdemVenda.Text = _pedidoPosicao1.OrdemVenda;
            txtArmazenagem.Text = _pedidoPosicao1.ArmazenagemCliente;

            cmbCliente.SelectedItem = _pedidoPosicao1.Cliente;

            rdbEmissorNFePrimario.Checked = _pedidoPosicao1.EmissorNfe == EasiEmissorNFe.Primario;
            rdbEmissorNFeSecundario.Checked = _pedidoPosicao1.EmissorNfe == EasiEmissorNFe.Secundario;

            ensOperacaoCompleta.EntidadeSelecionada = _pedidoPosicao1.OperacaoCompleta;
            cmbOperacao.SelectedItem = _pedidoPosicao1.Operacao;


            if (_pedidoPosicao1.Urgente == UrgenciaPedido.Normal)
            {
                rdbUrgenteNormal.Checked = true;
            }

            if (_pedidoPosicao1.Urgente == UrgenciaPedido.Antecipacao)
            {
                rdbUrgenteAntecipacao.Checked = true;
                this.txtUrgenteInfos.Text = _pedidoPosicao1.UrgenteInformacoesComplementares;
                this.txtUrgenteSolicitante.Text = _pedidoPosicao1.UrgenteSolicitante;
                if (_pedidoPosicao1.UrgenteDataPrometida.HasValue)
                {
                    this.dtpUrgenteData.Value = _pedidoPosicao1.UrgenteDataPrometida.Value;
                }
            }

            if (_pedidoPosicao1.Urgente == UrgenciaPedido.Urgente)
            {
                rdbUrgenteUrgente.Checked = true;
                this.txtUrgenteInfos.Text = _pedidoPosicao1.UrgenteInformacoesComplementares;
                this.txtUrgenteSolicitante.Text = _pedidoPosicao1.UrgenteSolicitante;
                if (_pedidoPosicao1.UrgenteDataPrometida.HasValue)
                {
                    this.dtpUrgenteData.Value = _pedidoPosicao1.UrgenteDataPrometida.Value;
                }
            }


            if (_pedidoPosicao1.Urgente == UrgenciaPedido.Critico)
            {
                rdbUrgenteCritico.Checked = true;
                this.txtUrgenteInfos.Text = _pedidoPosicao1.UrgenteInformacoesComplementares;
                this.txtUrgenteSolicitante.Text = _pedidoPosicao1.UrgenteSolicitante;
                if (_pedidoPosicao1.UrgenteDataPrometida.HasValue)
                {
                    this.dtpUrgenteData.Value = _pedidoPosicao1.UrgenteDataPrometida.Value;
                }
            }


            if (_pedidoPosicao1.ResponsavelFrete == null)
            {
                chkFreteSemResponsavel.Checked = true;
            }
            else
            {

                switch (_pedidoPosicao1.ResponsavelFrete)
                {
                    case ResponsavelFrete.ProprioRemetente:
                        this.rdbFreteProprioRemetente.Checked = true;
                        break;
                    case ResponsavelFrete.ProprioDestinatario:
                        this.rdbFreteProprioDestinatario.Checked = true;
                        break;
                    case ResponsavelFrete.Emitente:
                        this.rdbFreteEmitente.Checked = true;
                        break;
                    case ResponsavelFrete.Cliente:
                        this.rdbFreteDestinatario.Checked = true;
                        break;
                    case ResponsavelFrete.Terceiros:
                        this.rdbFreteTerceiros.Checked = true;
                        break;
                    case ResponsavelFrete.SemFrete:
                        this.rdbFreteSemFrete.Checked = true;
                        break;
                    case null:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }

            if (_pedidoPosicao1.Representante != null && _pedidoPosicao1.PercComissaoRepresentante.HasValue)
            {
                grpComissaoRepresentante.Enabled = true;
                chkRepresentante.Checked = true;
                cmbRepresentante.SelectedItem = _pedidoPosicao1.Representante;
                nudComissaoRepresentante.Value = (decimal) (_pedidoPosicao1.PercComissaoRepresentante ?? 0);
            }

            if (_pedidoPosicao1.Vendedor != null && _pedidoPosicao1.PercComissaoVendedor.HasValue)
            {

                grpComissaoVendedor.Enabled = true;
                chkVendedor.Checked = true;
                cmbVendedor.SelectedItem = _pedidoPosicao1.Vendedor;
                nudComissaoVendedor.Value = (decimal) (_pedidoPosicao1.PercComissaoVendedor ?? 0);
            }



            if (_pedidoPosicao1.ContaBancaria != null)
            {
                this.cmbContaBancaria.Enabled = true;
                cmbContaBancaria.SelectedItem = _pedidoPosicao1.ContaBancaria;
            }
            else
            {
                chkContaBancaria.Checked = false;
                cmbContaBancaria.SelectedItem = null;
            }


            if (_pedidoPosicao1.FormaPagamento != null)
            {
                this.ensFormaPagamento.Enabled = true;
                ensFormaPagamento.EntidadeSelecionada = _pedidoPosicao1.FormaPagamento;
            }
            else
            {
                ensFormaPagamento.Enabled = false;
                ensFormaPagamento.EntidadeSelecionada = null;
            }



            if (_pedidoPosicao1.CentroCustoLucro == null)
            {
                this.chkCentroCusto.Checked = false;
            }
            else
            {
                this.txtCentroCusto.Text = _pedidoPosicao1.CentroCustoLucro.ToString();
                this.centroCustoSelecionado = _pedidoPosicao1.CentroCustoLucro;
            }

            txtObservacaoNf.Text = _pedidoPosicao1.ObservacaoNf;
            txtObservacaoEspelhoPedido.Text = _pedidoPosicao1.ObsPadraoEspelho;
            nudFrete.Value = (decimal) _pedidoPosicao1.Frete;


            if (_pedidoPosicao1.PedidoClassificacao == null)
            {
                ensPedidoClassificacao.Enabled = false;
                ensPedidoClassificacao.EntidadeSelecionada = null;
            }
            else
            {
                ensPedidoClassificacao.Enabled = true;
                ensPedidoClassificacao.EntidadeSelecionada = _pedidoPosicao1.PedidoClassificacao;
            }
            

            List<PedidoItemClass> pedidosItem = PedidoItemClass.BuscaPedido(_pedidoPosicao1.Numero, null, _pedidoPosicao1.Cliente, Usuario, conn).OrderBy(a => a.Posicao).ToList();

            foreach (PedidoItemClass item in pedidosItem)
            {
                PedidoLinhaTelaClass pedidoTela = new PedidoLinhaTelaClass()
                {
                    Posicao = item.Posicao,
                    CodProduto = item.Produto.Codigo,
                    CodProdutoCliente = item.ProdutoCodigoCliente,
                    DataEntrega = item.DataEntrega,
                    Descricao = item.ProdutoDescricaoCliente,
                    EntregaParcial = item.PermiteEntregaParcial,
                    Exportacao = item.Exportacao,
                    InformacoesEspeciais = item.InformacaoEspecial,
                    Ncm = item.Ncm,
                    Pedido = item,
                    Produto = item.Produto,
                    Qtd = item.Quantidade,
                    RastrearMp = item.RastreamentoMaterial,
                    ValorUnitario = item.PrecoUnitario,
                    VolumeUnico = item.VolumeUnico,

                };

                pedidos.Add(item.Posicao, pedidoTela);
            }


            nudDescontoPedido.Value = (decimal) pedidosItem.Sum(a => a.Desconto);

            if (pedidosItem.Any(a => a.Configurado))
            {
                btnAdicionar.forceDisable();

                btnExcluir.forceDisable();

                cmbCliente.forceDisable();
                this.txtOc.forceDisable();

                this.txtProjeto.forceDisable();
                this.txtArmazenagem.forceDisable();
            }

            Label possuiProdutosVencidos = this.possuiProdutosVencidosLbl;

            foreach (PedidoLinhaTelaClass pedido in this.pedidos.Values)
            {
                if (pedido.Pedido.possuiProdutoVencido())
                {
                    possuiProdutosVencidos.Visible = true;
                    break;
                }
            }
            
            InitializeGrid();


        }

        private void InitTela()
        {
            InitializeComponent();

            this.dataEntregaTmp = Configurations.DataIndependenteClass.GetData().Date;

            this.loadComboOperação();
            this.loadClientes();
            this.loadComboRepresentante();
            this.loadComboVendedor();
            this.loadComboContaBancaria();

            ensFormaPagamento.FormSelecao = new CadFormaPagamentoListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            ensOperacaoCompleta.FormSelecao = new CadOperacaoCompletaListForm();
            ensPedidoClassificacao.FormSelecao = new CadPedidoClassificacaoListForm();

            this.pedidos = new SortedDictionary<int, PedidoLinhaTelaClass>();

        }

        private void loadComboOperação()
        {
            try
            {

                OperacaoClass search = new OperacaoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<OperacaoClass> operacoes =
                    search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("ope_descricao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                    }).ConvertAll(a => (OperacaoClass) a);


                this.cmbOperacao.DataSource = operacoes;
                this.cmbOperacao.DisplayMember = "Descricao";
                this.cmbOperacao.ValueMember = "ID";

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados das operações.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void loadClientes()
        {
            try
            {


                ClienteClass search = new ClienteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ClienteClass> clientes =
                    search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("cli_nome_resumido", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                        new SearchParameterClass("cli_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                    }).ConvertAll(a => (ClienteClass) a);


                this.cmbCliente.DataSource = clientes;
                this.cmbCliente.DisplayMember = "NomeResumido";
                this.cmbCliente.ValueMember = "ID";
                this.cmbCliente.autoSize = true;
                this.cmbCliente.Table = clientes;
                this.cmbCliente.ColumnsToDisplay = new string[] {"NomeResumido", "Nome"};
                this.cmbCliente.HeadersToDisplay = new string[] {"Nome Resumido", "Razão"};




                this.selecionarCliente();
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados do cliente.\r\n" + a.Message, "Dados do Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void loadComboContaBancaria()
        {
            try
            {


                ContaBancariaClass search = new ContaBancariaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ContaBancariaClass> contas =
                    search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("cba_nome_banco", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                        new SearchParameterClass("cba_agencia", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                        new SearchParameterClass("cba_numero_conta", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                    }).ConvertAll(a => (ContaBancariaClass) a);


                this.cmbContaBancaria.DataSource = contas;
                this.cmbContaBancaria.DisplayMember = "NomeBanco";
                this.cmbContaBancaria.ValueMember = "ID";
                this.cmbContaBancaria.autoSize = true;
                this.cmbContaBancaria.Table = contas;
                this.cmbContaBancaria.ColumnsToDisplay = new string[] {"NomeBanco", "Agencia", "NumeroConta"};
                this.cmbContaBancaria.HeadersToDisplay = new string[] {"Banco", "Agência", "Conta"};





            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da conta bancária.\r\n" + e.Message);
            }
        }

        private void loadComboRepresentante()
        {
            try
            {

                RepresentanteClass representante = new RepresentanteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<RepresentanteClass> representantes =
                    representante.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("rep_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                    }).ConvertAll(a => (RepresentanteClass) a);


                this.cmbRepresentante.DataSource = representantes;
                this.cmbRepresentante.DisplayMember = "RazaoSocial";
                this.cmbRepresentante.ValueMember = "ID";
                this.cmbRepresentante.autoSize = true;
                this.cmbRepresentante.Table = representantes;
                this.cmbRepresentante.ColumnsToDisplay = new[] {"RazaoSocial", "Cnpj", "Fone1", "Email"};
                this.cmbRepresentante.HeadersToDisplay = new[] {"Razão Social", "Cnpj", "Fone", "E-mail"};


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção de Representantes.\r\n" + e.Message);
            }
        }

        private void loadComboVendedor()
        {
            try
            {

                VendedorClass vendedor = new VendedorClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<VendedorClass> vendedores =
                    vendedor.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("ven_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                    }).ConvertAll(a => (VendedorClass) a);


                this.cmbVendedor.DataSource = vendedores;
                this.cmbVendedor.DisplayMember = "RazaoSocial";
                this.cmbVendedor.ValueMember = "ID";
                this.cmbVendedor.autoSize = true;
                this.cmbVendedor.Table = vendedores;
                this.cmbVendedor.ColumnsToDisplay = new[] {"RazaoSocial", "Cnpj", "Fone1", "Email"};
                this.cmbVendedor.HeadersToDisplay = new[] {"Razão Social", "Cnpj", "Fone", "E-mail"};


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção de Vendedores.\r\n" + e.Message);
            }
        }

        private void selcionarCentroCusto()
        {
            try
            {
                SelecaoCentroCustoLucroForm form = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Lucro);
                form.ShowDialog();

                if (form.CentroSelecionado == null)
                {
                    this.chkCentroCusto.Checked = false;
                }
                else
                {
                    this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                    this.centroCustoSelecionado = form.CentroSelecionado;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o centro de custo padrão\r\n" + e.Message, e);
            }
        }

        private void InitializeGrid()
        {
            try
            {
                this.dataGridView1.Columns.Clear();
                this.dataGridView1.AutoGenerateColumns = true;

                this.dataGridView1.DataSource = new List<PedidoLinhaTelaClass>(this.pedidos.Values);

                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Linha", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Produto", 60, DataGridViewAutoSizeColumnMode.AllCells, false);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Código Interno", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Código Faturamento", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Descrição Faturamentoo", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Quantidade", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Val. Unitário", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Valor Total", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "NCM", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Entrega Parcial", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Vol. Único", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Exportação", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Rastrear MP", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[13], "Inf. Especiais", 60, DataGridViewAutoSizeColumnMode.AllCells, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[14], "Data Entrega", 60, DataGridViewAutoSizeColumnMode.AllCells, true);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de linhas\r\n" + e.Message, e);
            }
        }

        private void Salvar()
        {
            IWTPostgreNpgsqlCommand command = null;

            try
            {
                if (this.txtOc.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Numero do pedido é obrigatório.");
                }

                if (this.cmbCliente.SelectedItem == null)
                {
                    throw new Exception("Campo Cliente é obrigatório. Selecione um item da lista de seleção.");
                }

                if (!IWTConfiguration.Conf.getBoolConf(Constants.PERMITE_PEDIDO_SEM_OPERACAO))
                {
                    if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                    {
                        if (this.ensOperacaoCompleta.EntidadeSelecionada == null)
                        {
                            throw new Exception("Campo Operação é obrigatório. Selecione um item da lista de seleção.");
                        }
                    }
                    else
                    {
                        if (this.cmbOperacao.SelectedItem == null)
                        {
                            throw new Exception("Campo Operação é obrigatório. Selecione um item da lista de seleção.");
                        }
                    }
                }


                if (gbxUrgente.Enabled)
                {
                    if (this.txtUrgenteSolicitante.Text.Trim().Length == 0)
                    {
                        throw new Exception("Campo de Solicitante é obrigatório para pedidos urgentes.");
                    }
                }

                if (cmbContaBancaria.Enabled && (cmbContaBancaria.SelectedItem == null || cmbContaBancaria.SelectedItem.ToString().Length == 0))
                {
                    throw new Exception("Selecione uma conta bancária ou desabilite o campo");
                }

                if (btnCentroCusto.Enabled && this.centroCustoSelecionado == null)
                {
                    throw new Exception("Selecione um centro de custo ou desabilite o campo");
                }

                if (chkRepresentante.Checked)
                {
                    if (cmbRepresentante.SelectedItem == null)
                    {
                        throw new Exception("Informe o Representante a receber comissão ou inabilite os campos de Comissão");
                    }

                    if (nudComissaoRepresentante.Value == 0)
                    {
                        throw new Exception("Informe um percentual de Comissão para o Representante ou inabilite os campos de Comissão");
                    }
                }

                if (chkVendedor.Checked)
                {
                    if (cmbVendedor.SelectedItem == null)
                    {
                        throw new Exception("Informe o Vendedor a receber comissão ou inabilite os campos de Comissão");
                    }

                    if (nudComissaoVendedor.Value == 0)
                    {
                        throw new Exception("Informe um percentual de Comissão para o Vendedor ou inabilite os campos de Comissão");
                    }
                }


                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();



                foreach (PedidoItemClass toDelete in pedidosRemover)
                {
                    toDelete.Delete(ref command);
                }


                bool numeroAuto;
                if (_pedidoPosicao1 == null)
                {
                    numeroAuto = numeroAutomatico == this.txtOc.Text;
                }
                else
                {
                    numeroAuto = _pedidoPosicao1.NumeroPedidoAutomatico;
                }

                EasiEmissorNFe emissor = EasiEmissorNFe.Primario;
                if (rdbEmissorNFeSecundario.Checked)
                {
                    emissor = EasiEmissorNFe.Secundario;
                }

                OperacaoCompletaClass operacaoCompleta = null;
                OperacaoClass operacao = null;

                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    operacaoCompleta = (OperacaoCompletaClass) this.ensOperacaoCompleta.EntidadeSelecionada;
                }
                else
                {
                    operacao = (OperacaoClass) cmbOperacao.SelectedItem;
                }


                double saldoDesconto = (double) nudDescontoPedido.Value;
                double valorTotalDesconto = saldoDesconto;

                double valorTotalPedido = this.pedidos.Values.Sum(a => a.ValorTotal);


                foreach (PedidoLinhaTelaClass pedidoLinha in pedidos.Values)
                {
                    PedidoItemClass pedido;
                    if (pedidoLinha.Pedido == null)
                    {
                        pedidoLinha.Pedido = new PedidoItemClass(this.Usuario, this.conn);
                        ;
                    }

                    pedido = pedidoLinha.Pedido;

                    pedido.Numero = txtOc.Text;
                    pedido.Posicao = pedidoLinha.Posicao;
                    pedido.DataEntrega = pedidoLinha.DataEntrega;
                    pedido.VolumeUnico = pedidoLinha.VolumeUnico;
                    pedido.PermiteEntregaParcial = pedidoLinha.EntregaParcial;
                    pedido.Operacao = operacao;
                    pedido.OperacaoCompleta = operacaoCompleta;
                    pedido.ProjetoCliente = txtProjeto.Text;
                    pedido.OrdemVenda = txtOrdemVenda.Text;
                    pedido.ArmazenagemCliente = txtArmazenagem.Text;
                    pedido.Frete = 0;
                    pedido.Cliente = (ClienteClass) cmbCliente.SelectedItem;
                    pedido.CnpjCliente = pedido.Cliente.Cnpj;
                    pedido.Exportacao = pedidoLinha.Exportacao;
                    pedido.EmissorNfe = emissor;

                    if (rdbUrgenteNormal.Checked)
                    {
                        pedido.Urgente = UrgenciaPedido.Normal;
                    }

                    if (rdbUrgenteAntecipacao.Checked)
                    {
                        pedido.Urgente = UrgenciaPedido.Antecipacao;
                        pedido.UrgenteInformacoesComplementares = this.txtUrgenteInfos.Text;
                        pedido.UrgenteSolicitante = this.txtUrgenteSolicitante.Text;
                        pedido.UrgenteDataPrometida = this.dtpUrgenteData.Value;
                    }

                    if (rdbUrgenteUrgente.Checked)
                    {
                        pedido.Urgente = UrgenciaPedido.Urgente;
                        pedido.UrgenteInformacoesComplementares = this.txtUrgenteInfos.Text;
                        pedido.UrgenteSolicitante = this.txtUrgenteSolicitante.Text;
                        pedido.UrgenteDataPrometida = this.dtpUrgenteData.Value;
                    }


                    if (rdbUrgenteCritico.Checked)
                    {
                        pedido.Urgente = UrgenciaPedido.Critico;
                        pedido.UrgenteInformacoesComplementares = this.txtUrgenteInfos.Text;
                        pedido.UrgenteSolicitante = this.txtUrgenteSolicitante.Text;
                        pedido.UrgenteDataPrometida = this.dtpUrgenteData.Value;
                    }

                    if (chkFreteSemResponsavel.Checked)
                    {
                        pedido.ResponsavelFrete = null;
                    }
                    else
                    {
                        if (this.rdbFreteEmitente.Checked)
                            pedido.ResponsavelFrete = ResponsavelFrete.Emitente;
                        if (this.rdbFreteDestinatario.Checked)
                            pedido.ResponsavelFrete = ResponsavelFrete.Cliente;
                        if (this.rdbFreteTerceiros.Checked)
                            pedido.ResponsavelFrete = ResponsavelFrete.Terceiros;
                        if (this.rdbFreteSemFrete.Checked)
                            pedido.ResponsavelFrete = ResponsavelFrete.SemFrete;
                        if (this.rdbFreteProprioDestinatario.Checked)
                            pedido.ResponsavelFrete = ResponsavelFrete.ProprioDestinatario;
                        if (this.rdbFreteProprioRemetente.Checked)
                            pedido.ResponsavelFrete = ResponsavelFrete.ProprioRemetente;
                    }





                    double comissao = 0;
                    RepresentanteClass representante = null;
                    if (grpComissaoRepresentante.Enabled && chkRepresentante.Checked)
                    {
                        representante = (RepresentanteClass) cmbRepresentante.SelectedItem;
                        comissao = (double) nudComissaoRepresentante.Value;
                    }



                    double comissaoVendedor = 0;
                    VendedorClass vendedor = null;
                    if (grpComissaoVendedor.Enabled && chkVendedor.Checked)
                    {
                        vendedor = (VendedorClass) cmbVendedor.SelectedItem;
                        comissaoVendedor = (double) nudComissaoVendedor.Value;
                    }





                    pedido.Produto = pedidoLinha.Produto;
                    pedido.ProdutoCodigoCliente = pedidoLinha.CodProdutoCliente;
                    pedido.ProdutoDescricaoCliente = pedidoLinha.Descricao;
                    pedido.Ncm = pedidoLinha.Ncm;
                    pedido.Quantidade = pedidoLinha.Qtd;
                    pedido.PercComissaoRepresentante = comissao;
                    pedido.Representante = representante;
                    pedido.PrecoUnitario = pedidoLinha.ValorUnitario;
                    pedido.Vendedor = vendedor;
                    pedido.PercComissaoVendedor = comissaoVendedor;



                    pedido.InformacaoEspecial = pedidoLinha.InformacoesEspeciais?.Trim();
                    pedido.RastreamentoMaterial = pedidoLinha.RastrearMp;

                    if (this.cmbContaBancaria.Enabled)
                    {
                        pedido.ContaBancaria = (ContaBancariaClass) cmbContaBancaria.SelectedItem;
                    }
                    else
                    {
                        pedido.ContaBancaria = null;
                    }

                    if (this.ensFormaPagamento.Enabled)
                    {
                        pedido.FormaPagamento = (FormaPagamentoClass) ensFormaPagamento.EntidadeSelecionada;
                    }
                    else
                    {
                        pedido.FormaPagamento = null;
                    }



                    if (this.centroCustoSelecionado != null)
                    {
                        pedido.CentroCustoLucro = centroCustoSelecionado;
                    }
                    else
                    {
                        pedido.CentroCustoLucro = null;
                    }

                    pedido.FormaFrete = FormaFretePedido.Normal;

                    if (numeroAuto)
                    {
                        pedido.NumeroPedidoOriginal = pedido.Numero;
                        pedido.NumeroPedidoAutomatico = true;
                    }

                    pedido.ObservacaoNf = txtObservacaoNf.Text;
                    pedido.ObsPadraoEspelho = txtObservacaoEspelhoPedido.Text;

                    if (pedido.Posicao == 1)
                    {
                        pedido.Frete = (double) nudFrete.Value;
                    }
                    else
                    {
                        pedido.Frete = 0;
                    }


                    pedido.Desconto = Math.Round((valorTotalDesconto / valorTotalPedido) * pedido.PrecoTotal, 2);
                    saldoDesconto = Math.Round(saldoDesconto - pedido.Desconto,2);

                    if (this.ensPedidoClassificacao.Enabled)
                    {
                        pedido.PedidoClassificacao = (PedidoClassificacaoClass) ensPedidoClassificacao.EntidadeSelecionada;
                    }
                    else
                    {
                        pedido.PedidoClassificacao = null;
                    }

                    pedido.Save(ref command);
                }

                if (Math.Abs(saldoDesconto) > 0.001)
                {
                    PedidoLinhaTelaClass ultimoPedido = pedidos.Values.Last();
                    ultimoPedido.Pedido.Desconto = Math.Round(ultimoPedido.Pedido.Desconto + saldoDesconto, 2);
                    ultimoPedido.Pedido.Save(ref command);
                }


                command.Transaction.Commit();

                try
                {

                    ClienteClass cliente = (ClienteClass) cmbCliente.SelectedItem;
                    RepresentanteClass representante = (RepresentanteClass) (this.cmbRepresentante.Enabled ? this.cmbRepresentante.SelectedItem : null);
                    VendedorClass vendedor = (VendedorClass) (this.cmbVendedor.Enabled ? this.cmbVendedor.SelectedItem : null);

                    PedidoAgrupador agrupador = new PedidoAgrupador(
                        PedidoOrcamento.Pedido,
                        this.txtOc.Text.Trim(),
                        cliente,
                        representante,
                        vendedor,
                        LoginClass.UsuarioLogado.loggedUser,
                        this.SingleConnection
                    );

                    BibliotecaEntidades.Entidades.PedidoItemClass search = new BibliotecaEntidades.Entidades.PedidoItemClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    List<BibliotecaEntidades.Entidades.PedidoItemClass> itens = search.Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("Numero", agrupador.Numero, SearchOperacao.FiltroNormal, SearchOrdenacao.Asc, TipoOrdenacao.String),
                        new SearchParameterClass("Cliente", agrupador.Cliente)
                    }).ConvertAll(a => (BibliotecaEntidades.Entidades.PedidoItemClass) a);

                    foreach (BibliotecaEntidades.Entidades.PedidoItemClass item in itens)
                    {
                        agrupador.AdicionarPedido(item);
                    }


                    agrupador.EnviarEmail();
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, "Ocorreu um erro ao enviar os emails do pedido.\r\n" + e.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    pedidosRemover.Clear();
                }

                MessageBox.Show(this, "Pedidos Salvos com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                throw new Exception("Erro ao salvar todas as linhas do pedido.\r\n" + e.Message, e);
            }
        }

        private void Remover()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception("Selecione uma linha antes de continuar.");
                }

                if (MessageBox.Show(this, "Essa operação irá remover uma linha e ajusar a numeração das demais, deseja continuar?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                PedidoLinhaTelaClass linhaSelecionada = this.pedidos[(int) this.dataGridView1.SelectedRows[0].Cells["Posicao"].Value];
                this.pedidos.Remove(linhaSelecionada.Posicao);
                if (linhaSelecionada.Pedido != null)
                {
                    pedidosRemover.Add(linhaSelecionada.Pedido);
                }

                //Reordenar vetor de linhas para mante-las de forma sequencial
                for (int i = 1; i <= this.pedidos.Count + 1; i++)
                {
                    if (i > linhaSelecionada.Posicao)
                    {
                        PedidoLinhaTelaClass tmp = this.pedidos[i];
                        this.pedidos.Remove(i);
                        tmp.Posicao = tmp.Posicao - 1;
                        this.pedidos.Add(tmp.Posicao, tmp);
                    }
                }


                this.InitializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar uma linha.\r\n" + e.Message, e);
            }
        }

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception("Selecione uma linha antes de continuar.");
                }

                PedidoLinhaTelaClass linhaSelecionada = this.pedidos[(int) this.dataGridView1.SelectedRows[0].Cells["Posicao"].Value];

                CadPedidoSimplificadoItemForm form = new CadPedidoSimplificadoItemForm(linhaSelecionada, this.dataEntregaTmp, pedidos.Values.Any(a => a.Pedido != null && a.Pedido.Configurado));
                form.ShowDialog();


                //this.pedidos[form.LinhaPedido.Posicao] = form.LinhaPedido;

                this.InitializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar uma linha.\r\n" + e.Message, e);
            }
        }

        private void Adicionar()
        {
            try
            {
                CadPedidoSimplificadoItemForm form = new CadPedidoSimplificadoItemForm(null, this.dataEntregaTmp, false);
                form.ShowDialog();

                if (!form.OkClicked) return;
                form.LinhaPedido.Posicao = this.pedidos.Count + 1;
                this.dataEntregaTmp = form.dataEntTmp;
                this.pedidos.Add(form.LinhaPedido.Posicao, form.LinhaPedido);
                this.InitializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar uma linha.\r\n" + e.Message, e);
            }
        }

        private void selecionarCliente()
        {
            try
            {
                if (this.cmbCliente.SelectedItem != null)
                {
                    ClienteClass cliente = (ClienteClass) this.cmbCliente.SelectedItem;

                    if (!chkCentroCusto.Checked)
                    {
                        if (cliente.CentroCustoLucro != null)
                        {
                            this.txtCentroCusto.Text = cliente.CentroCustoLucro.ToString();
                            this.centroCustoSelecionado = cliente.CentroCustoLucro;
                        }
                        else
                        {
                            this.centroCustoSelecionado = null;
                            this.txtCentroCusto.Text = "";
                        }
                    }

                    if (!chkContaBancaria.Checked)
                    {
                        if (cliente.ContaBancaria != null)
                        {
                            this.cmbContaBancaria.SelectedItem = cliente.ContaBancaria;
                        }
                        else
                        {
                            this.cmbContaBancaria.SelectedItem = null;
                            this.cmbContaBancaria.Text = "";
                        }
                    }

                    if (!ensFormaPagamento.Enabled)
                    {
                        if (cliente.FormaPagamento != null)
                        {
                            this.ensFormaPagamento.EntidadeSelecionada = cliente.FormaPagamento;
                        }
                        else
                        {
                            this.ensFormaPagamento.Clear();
                        }
                    }


                    if (cliente.Representante != null)
                    {
                        chkRepresentante.Checked = true;
                        cmbRepresentante.SelectedItem = cliente.Representante;
                        if (cliente.PercComissaoRepresentante.HasValue)
                        {
                            nudComissaoRepresentante.Value = (decimal) cliente.PercComissaoRepresentante;
                        }
                        else
                        {
                            nudComissaoRepresentante.Value = (decimal) cliente.Representante.Comissao;
                        }
                    }
                    else
                    {
                        chkRepresentante.Checked = false;
                        nudComissaoRepresentante.Value = 0;
                    }

                    if (cliente.Vendedor != null)
                    {
                        chkVendedor.Checked = true;
                        cmbVendedor.SelectedItem = cliente.Vendedor;
                        if (cliente.PercComissaoVendedor.HasValue)
                        {
                            nudComissaoVendedor.Value = (decimal) cliente.PercComissaoVendedor;
                        }
                        else
                        {
                            nudComissaoVendedor.Value = (decimal) cliente.Vendedor.Comissao;
                        }
                    }
                    else
                    {
                        chkVendedor.Checked = false;
                        nudComissaoVendedor.Value = 0;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o cliente.\r\n" + e.Message, e);
            }
        }

        private void CalculaValorFinal()
        {
            lblValorBruto.Text = (pedidos.Values.Sum(a => a.ValorTotal) + (double) nudFrete.Value).ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
            lblValorFinal.Text = (pedidos.Values.Sum(a => a.ValorTotal) + (double) nudFrete.Value - (double) nudDescontoPedido.Value).ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));
        }



        #region Eventos

        private void rdbUrgenteNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;
        }

        private void rdbUrgenteAntecipacao_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;
        }

        private void rdbUrgenteUrgente_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;

        }

        private void rdbUrgenteCritico_CheckedChanged(object sender, EventArgs e)
        {
            this.gbxUrgente.Enabled = !rdbUrgenteNormal.Checked;

        }

        private void chkContaBancaria_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbContaBancaria.Enabled = this.chkContaBancaria.Checked;
        }

        private void chkCentroCusto_CheckedChanged(object sender, EventArgs e)
        {
            this.btnCentroCusto.Enabled = this.chkCentroCusto.Checked;
            if (!this.chkCentroCusto.Checked)
            {
                this.centroCustoSelecionado = null;
                this.txtCentroCusto.Clear();
            }
        }

        private void btnCentroCusto_Click(object sender, EventArgs e)
        {
            try
            {
                this.selcionarCentroCusto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Adicionar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CalculaValorFinal();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Editar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CalculaValorFinal();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Remover();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CalculaValorFinal();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Salvar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.selecionarCliente();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadPedidoSimplificadoForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.selecionarCliente();


                if (IWTConfiguration.Conf.getBoolConf(Constants.EMITENTE_NF_SECUNDARIO_HABILITADO))
                {
                    rdbEmissorNFePrimario.Text = "Principal (" + NotaFiscalFuncoesAuxiliares.CarregaNomeEmpresa(EasiEmissorNFe.Primario) + ")";
                    rdbEmissorNFeSecundario.Text = "Secundário (" + NotaFiscalFuncoesAuxiliares.CarregaNomeEmpresa(EasiEmissorNFe.Secundario) + ")";
                }
                else
                {
                    rdbEmissorNFePrimario.Checked = true;
                    rdbEmissorNFePrimario.Visible = false;
                    rdbEmissorNFeSecundario.Visible = false;
                    grbEmitenteNfe.Visible = false;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkRepresentante_CheckedChanged(object sender, EventArgs e)
        {
            cmbRepresentante.Enabled = chkRepresentante.Checked;
            nudComissaoRepresentante.Enabled = chkRepresentante.Checked;
        }

        private void cmbRepresentante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRepresentante.SelectedItem != null)
                {
                    nudComissaoRepresentante.Value = (Decimal) ((RepresentanteClass) cmbRepresentante.SelectedItem).Comissao;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar a comissão do Representante selecionado\r\n" + a.Message);
            }
        }

        private void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            cmbVendedor.Enabled = chkVendedor.Checked;
            nudComissaoVendedor.Enabled = chkVendedor.Checked;
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbVendedor.SelectedItem != null)
                {
                    nudComissaoVendedor.Value = (Decimal) ((VendedorClass) cmbVendedor.SelectedItem).Comissao;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar a comissão do Vendedor selecionado\r\n" + a.Message);
            }
        }

        private void chkFreteSemResponsavel_CheckedChanged(object sender, EventArgs e)
        {
            grpFreteResponsavel.Enabled = !chkFreteSemResponsavel.Checked;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
            {
                cmbOperacao.forceDisable();
                cmbOperacao.Visible = false;
            }
            else
            {
                ensOperacaoCompleta.forceDisable();
                ensOperacaoCompleta.Visible = false;
            }

            CalculaValorFinal();
        }


        private void nudDescontoPedido_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalculaValorFinal();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudFrete_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalculaValorFinal();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
