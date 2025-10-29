#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaProdutos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

#endregion

namespace BibliotecaCompras
{
    enum ModosTela { SelecionaProduto, SelecionaMaterial, ProdutoSelecionado, MaterialSelecionado, SelecionaEpi, EpiSelecionado};




    public partial class SolicitacaoCompraForm : IWTBaseForm
    {


        #region Configurações

        private static int diasVerde = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
        private static int diasAmarelo = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
        private static int diasVermelho = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));
        private static int mesesMedia = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
        private static double categoriaAAcimaDe = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_A));
        private static double categoriaBAcimaDe = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_B));
        private static double margemAvisoKB = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB));

        private static int diasPCP = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_PCP));


        private static int leadtimeCompras = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_COMPRAS));
        private static double sugeridoAcimaCompras = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.SUGESTAO_ACIMA_CONFIGURADO));
        private static readonly string tipoCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO);
        private static readonly string diaCalculoSemana = IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA);

        #endregion


        private readonly AcsUsuarioClass Usuario;
        private BindingList<SolicitacaoCompraClass> SolicitacoesCompra;
        private List<SolicitacaoCompraClass> SolicitacoesCompraRemover;
        private readonly bool _aprovarPcp;
        private readonly IWTPostgreNpgsqlConnection conn;

        private MaterialClass materialSelecionado = null;
        private ProdutoClass produtoSelecionado = null;
        private EpiClass epiSelecionado = null;

        private double QtdTotalSCsUnidadeUso
        {
            get { return this.SolicitacoesCompra.Sum(a => a.QtdUnidadeUso); }
        }

        private double QtdTotalSCsUnidadeCompra
        {
            get { return this.SolicitacoesCompra.Sum(a => a.Quantidade); }
        }

        private ModosTela modoAtualTela = ModosTela.SelecionaMaterial;

        private string _historicoCalculo = "";
        private SolicitacaoCompraClass solicitacaoCompraOriginal;



        public SolicitacaoCompraForm(SolicitacaoCompraClass solicitacaoCompra, bool aprovarPCP, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            _aprovarPcp = aprovarPCP;
            this.conn = conn;
            this.Usuario = Usuario;
            this.SolicitacoesCompra = new BindingList<SolicitacaoCompraClass>();



            if (solicitacaoCompra != null)
            {
                this.SolicitacoesCompra.Add(solicitacaoCompra);
                solicitacaoCompraOriginal = solicitacaoCompra;
                this.loadEdit();
            }
            else
            {
                this.setModoTela(ModosTela.SelecionaMaterial);
            }




            this.Shown += new EventHandler(SolicitacaoCompraForm_Shown);

            if (TipoModulo.Tipo == TipoForm.Compras)
            {
                this.rdbProduto.Enabled = false;
                this.rdbProduto.Checked = false;
            }



        }

        private void SolicitacaoCompraForm_Shown(object sender, EventArgs e)
        {
            if (this.SolicitacoesCompra.Count == 0)
            {
                this.txtBusca.Focus();
            }
        }

        private void setModoTela(ModosTela novoModo)
        {
            ModosTela modoAnterior = this.modoAtualTela;
            try
            {
                this.modoAtualTela = novoModo;

                switch (this.modoAtualTela)
                {
                    case ModosTela.SelecionaMaterial:
                        this.splGridsSelecao.Visible = true;
                        this.panDetalhes.Visible = false;
                        this.produtoSelecionado = null;
                        this.materialSelecionado = null;
                        this.epiSelecionado = null;

                        this.dgvMaterial.Visible = true;
                        this.dgvProduto.Visible = false;
                        this.dgvEpi.Visible = false;

                        this.rdbMaterial.Checked = true;
                        //this.txtBusca.Text = "";

                        this.loadGridMateriais();

                        this.btnCancel.Text = "Fechar";
                        this.btnConfirm.Text = "Avançar";

                        this.txtBusca.Focus();
                        break;

                    case ModosTela.SelecionaProduto:
                        this.splGridsSelecao.Visible = true;
                        this.panDetalhes.Visible = false;
                        this.produtoSelecionado = null;
                        this.materialSelecionado = null;
                        this.epiSelecionado = null;

                        this.dgvMaterial.Visible = false;
                        this.dgvProduto.Visible = true;
                        this.dgvEpi.Visible = false;

                        this.rdbProduto.Checked = true;
                        //this.txtBusca.Text = "";

                        this.loadGrID();

                        this.btnCancel.Text = "Fechar";
                        this.btnConfirm.Text = "Avançar";
                        this.txtBusca.Focus();

                        break;
                    case ModosTela.MaterialSelecionado:
                        this.splGridsSelecao.Visible = false;
                        this.panDetalhes.Visible = true;

                        this.grbInfoMaterial.Visible = true;
                        this.grbInfoProduto.Visible = false;
                        this.gbxInfoEpi.Visible = false;

                        this.btnCancel.Text = "Fechar";
                        this.btnConfirm.Text = _aprovarPcp ? "Salvar e Aprovar" : "Salvar";


                        this.loadInfosMaterial();
                        this.InitializeGridSCs();


                        if (materialSelecionado.FamiliaMaterial == null || materialSelecionado.FamiliaMaterial.AgrupadorMaterial == null)
                        {
                            this.ConsumoColumn.ReadOnly = true;
                        }
                        else
                        {
                            switch (materialSelecionado.FamiliaMaterial.AgrupadorMaterial.TipoConsumoEstoque)
                            {
                                case EASITipoConsumoEstoque.MateriaPrima:
                                    this.ConsumoColumn.ReadOnly = true;
                                    break;
                                case EASITipoConsumoEstoque.Consumo:
                                    this.ConsumoColumn.ReadOnly = true;
                                    break;
                                case EASITipoConsumoEstoque.Escolher:
                                    this.ConsumoColumn.ReadOnly = false;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }


                        break;

                    case ModosTela.ProdutoSelecionado:
                        this.splGridsSelecao.Visible = false;
                        this.panDetalhes.Visible = true;

                        this.grbInfoMaterial.Visible = false;
                        this.grbInfoProduto.Visible = true;
                        this.gbxInfoEpi.Visible = false;

                        this.btnCancel.Text = "Fechar";
                        this.btnConfirm.Text = _aprovarPcp ? "Salvar e Aprovar" : "Salvar";

                        this.loadInfosProduto();
                        this.InitializeGridSCs();

                        if (produtoSelecionado.ClassificacaoProduto == null )
                        {
                            this.ConsumoColumn.ReadOnly = true;
                        }
                        else
                        {
                            switch (produtoSelecionado.ClassificacaoProduto.TipoConsumoEstoque)
                            {
                                case EASITipoConsumoEstoque.MateriaPrima:
                                    this.ConsumoColumn.ReadOnly = true;
                                    break;
                                case EASITipoConsumoEstoque.Consumo:
                                    this.ConsumoColumn.ReadOnly = true;
                                    break;
                                case EASITipoConsumoEstoque.Escolher:
                                    this.ConsumoColumn.ReadOnly = false;
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }



                        break;

                    case ModosTela.SelecionaEpi:
                        this.splGridsSelecao.Visible = true;
                        this.panDetalhes.Visible = false;
                        this.produtoSelecionado = null;
                        this.materialSelecionado = null;
                        this.epiSelecionado = null;

                        this.dgvMaterial.Visible = false;
                        this.dgvProduto.Visible = false;
                        this.dgvEpi.Visible = true;

                        this.rdbEpi.Checked = true;
                        //this.txtBusca.Text = "";

                        this.loadGridEpi();

                        this.btnCancel.Text = "Fechar";
                        this.btnConfirm.Text = "Avançar";
                        this.txtBusca.Focus();

                        break;

                    case ModosTela.EpiSelecionado:
                        this.splGridsSelecao.Visible = false;
                        this.panDetalhes.Visible = true;

                        this.grbInfoMaterial.Visible = false;
                        this.grbInfoProduto.Visible = false;
                        this.gbxInfoEpi.Visible = true;

                        this.btnCancel.Text = "Fechar";

                        this.btnConfirm.Text = _aprovarPcp ? "Salvar e Aprovar" : "Salvar";



                        this.loadInfosEpi();
                        this.InitializeGridSCs();
                        this.ConsumoColumn.ReadOnly = true;

                        break;
                    default:
                        throw new Exception("Modo de tela inválido.");
                }

            }
            catch (Exception e)
            {
                this.modoAtualTela = modoAnterior;
                throw new Exception("Erro ao mudar o modo da tela.\r\n" + e.Message, e);
            }
        }

        private void InitializeGridSCs()
        {
            this.dgvSolicitacoes.AutoGenerateColumns = false;
            this.dgvSolicitacoes.DataSource = null;
            this.dgvSolicitacoes.DataSource = this.SolicitacoesCompra;
        }

        private void loadEdit()
        {
            try
            {

                SolicitacaoCompraClass sc = this.SolicitacoesCompra[0];
                _historicoCalculo = sc.HistoricoCalculoNecessidade;

                if (sc.Produto != null)
                {
                    this.produtoSelecionado = sc.Produto;
                    this.setModoTela(ModosTela.ProdutoSelecionado);

                }
                else
                {
                    if (sc.Epi != null)
                    {
                        this.epiSelecionado = sc.Epi;
                        this.setModoTela(ModosTela.EpiSelecionado);
                    }
                    else
                    {
                        this.materialSelecionado = sc.Material;
                        this.setModoTela(ModosTela.MaterialSelecionado);

                    }
                }

                this.txtObservacao.Text = sc.Observacao;



            }
            catch (Exception e)
            {

                throw new Exception("Erro ao carregar a edição da solicitação.\r\n" + e.Message, e);
            }
        }

        private void loadInfosMaterial()
        {
            try
            {
                this.lblMatCodigo.Text = this.materialSelecionado.ToString() + " (" + this.materialSelecionado.CodigoInterno + ")";
                this.lblMatDescricao.Text = this.materialSelecionado.Descricao;
                this.lblMatDescricaoAdicional.Text = this.materialSelecionado.DescricaoAdicional;
                this.lblMatMedida.Text = this.materialSelecionado.MedidaCompleta;

                this.lblMatUnidadeCompra.Text = this.materialSelecionado.UnidadeMedidaCompra != null ? this.materialSelecionado.UnidadeMedidaCompra.ToString() : "";

                this.lblMatUnidadeUso.Text = this.materialSelecionado.UnidadeMedida.ToString();


                this.dtpDataPrevistaLeadtime.Value = this.materialSelecionado.calculaEntregaPrevistaCompra(Configurations.DataIndependenteClass.GetData());

                DateTime? tmp = this.materialSelecionado.calculaDataProximaUtilizacao();
                if (tmp == null)
                {
                    this.lblSemUtilizacao1.Visible = true;
                    this.dtpPrimeraUtilizacao.Visible = false;
                    this.btnPrimeiraUtilizacao.Visible = false;
                }
                else
                {
                    this.lblSemUtilizacao1.Visible = false;
                    this.dtpPrimeraUtilizacao.Visible = true;
                    this.btnPrimeiraUtilizacao.Visible = true;
                    this.dtpPrimeraUtilizacao.Value = tmp.Value;
                }

                tmp = this.materialSelecionado.calculaDataZeraEstoque();
                if (tmp == null)
                {
                    this.lblSemUtilizacao2.Visible = true;
                    this.dtpEncerramentoEstoque.Visible = false;
                    this.btnEncerramentoEstoque.Visible = false;
                }
                else
                {
                    this.lblSemUtilizacao1.Visible = false;
                    this.dtpEncerramentoEstoque.Visible = true;
                    this.btnEncerramentoEstoque.Visible = true;
                    this.dtpEncerramentoEstoque.Value = tmp.Value;
                }

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                this.lblEstoqueAtual.Text = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueMaterial(this.materialSelecionado, ref command).ToString("F4", CultureInfo.CurrentCulture) + " " + this.materialSelecionado.UnidadeMedida.ToString();


                NecessidadeCompra necessidade = new NecessidadeCompra(tipoCalculoSemana, diaCalculoSemana,
                    diasPCP, leadtimeCompras, diasVerde, diasAmarelo, diasVermelho,
                    mesesMedia, categoriaAAcimaDe, categoriaBAcimaDe, margemAvisoKB,
                    sugeridoAcimaCompras,
                    conn, Usuario);

                necessidade.gerarRelatorio(null, materialSelecionado.ID, null, new List<SolicitacaoCompraClass>() {solicitacaoCompraOriginal});

                foreach (KeyValuePair<itemNecessidadeCompraKey, itemNecessidadeCompra> item in necessidade.itensComprar)
                {
                    if (TipoItemCompra.Material == item.Value.tipoItem && item.Value.Item.ID == this.materialSelecionado.ID)
                    {
                        this.lblEVP.Text = item.Value.EVP.ToString("F4", CultureInfo.CurrentCulture) + " " + this.materialSelecionado.UnidadeMedida.ToString(); 
                        this.lblQtdNecessaria.Text = item.Value.qtdNecessaria.ToString("F4", CultureInfo.CurrentCulture) + " " + this.materialSelecionado.UnidadeMedida;
                        this.lblDemandaSugeriaVerde.Text = item.Value.estoqueMinimo.ToString("F4", CultureInfo.CurrentCulture) + " " + this.materialSelecionado.UnidadeMedida;

                        this.lblOCAguardandoRecebimento.Text = item.Value.qtdSolicitacoesCompraCompradas.ToString("F4", CultureInfo.CurrentCulture) + " " + this.materialSelecionado.UnidadeMedida;

                        this.lblScsPrendentes.Text = item.Value.qtdSolicitacoesCompraAguardandoCompra.ToString("F4", CultureInfo.CurrentCulture) + " " + this.materialSelecionado.UnidadeMedida;

                        if (string.IsNullOrWhiteSpace(_historicoCalculo))
                        {
                            _historicoCalculo = item.Value.HistoricoCalculo;
                        }
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as informações do material.\r\n" + e.Message, e);
            }
        }

        private void loadInfosProduto()
        {
            try
            {
                this.lblProCodigo.Text = this.produtoSelecionado.Codigo;
                this.lblProCodigoCliente.Text = this.produtoSelecionado.CodigoCliente;
                this.lblProDescricao.Text = this.produtoSelecionado.Descricao;
                this.lblProEmiteOP.Text = this.produtoSelecionado.EmiteOp ? "Sim" : "Não";
                this.lblProLocalFabricacao.Text = this.produtoSelecionado.LocalFabricacao != null ? this.produtoSelecionado.LocalFabricacao.ToString() : null;
                this.lblProRevisaoCadastro.Text = this.produtoSelecionado.DataRevisaoCadastro.ToString("dd/MM/yyyy") + " " + this.produtoSelecionado.UltimaRevisaoEstruturaMotivo;

                this.lblMatUnidadeUso.Text = this.produtoSelecionado.UnidadeMedida.ToString();

                this.dtpDataPrevistaLeadtime.Value = this.produtoSelecionado.calculaEntregaPrevistaCompra(diasPCP, Configurations.DataIndependenteClass.GetData());

                DateTime? tmp = this.produtoSelecionado.calculaDataProximaUtilizacao();
                if (tmp == null)
                {
                    this.lblSemUtilizacao1.Visible = true;
                    this.dtpPrimeraUtilizacao.Visible = false;
                    this.btnPrimeiraUtilizacao.Visible = false;
                }
                else
                {
                    this.lblSemUtilizacao1.Visible = false;
                    this.dtpPrimeraUtilizacao.Visible = true;
                    this.btnPrimeiraUtilizacao.Visible = true;
                    this.dtpPrimeraUtilizacao.Value = tmp.Value;
                }

                tmp = this.produtoSelecionado.calculaDataZeraEstoque();
                if (tmp == null)
                {
                    this.lblSemUtilizacao2.Visible = true;
                    this.dtpEncerramentoEstoque.Visible = false;
                    this.btnEncerramentoEstoque.Visible = false;
                }
                else
                {
                    this.lblSemUtilizacao1.Visible = false;
                    this.dtpEncerramentoEstoque.Visible = true;
                    this.btnEncerramentoEstoque.Visible = true;
                    this.dtpEncerramentoEstoque.Value = tmp.Value;
                }


                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                this.lblEstoqueAtual.Text = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(this.produtoSelecionado, ref command).ToString("F4", CultureInfo.CurrentCulture) + " " + this.produtoSelecionado.UnidadeMedida.ToString(); 

                NecessidadeCompra necessidade = new NecessidadeCompra(tipoCalculoSemana, diaCalculoSemana,
                    diasPCP, leadtimeCompras, diasVerde, diasAmarelo, diasVermelho,
                    mesesMedia, categoriaAAcimaDe, categoriaBAcimaDe, margemAvisoKB,
                    sugeridoAcimaCompras,
                    conn, Usuario);

                necessidade.gerarRelatorio(produtoSelecionado.ID, null, null, new List<SolicitacaoCompraClass>() { solicitacaoCompraOriginal });

                foreach (KeyValuePair<itemNecessidadeCompraKey, itemNecessidadeCompra> item in necessidade.itensComprar)
                {
                    if (TipoItemCompra.Produto == item.Value.tipoItem && item.Value.Item.ID == this.produtoSelecionado.ID)
                    {
                        this.lblEVP.Text = item.Value.EVP.ToString("F4", CultureInfo.CurrentCulture) + " " + this.produtoSelecionado.UnidadeMedida.ToString(); 
                        this.lblQtdNecessaria.Text = item.Value.qtdNecessaria.ToString("F4", CultureInfo.CurrentCulture) + " " + this.produtoSelecionado.UnidadeMedida;
                        this.lblDemandaSugeriaVerde.Text = item.Value.estoqueMinimo.ToString("F4", CultureInfo.CurrentCulture) + " " + this.produtoSelecionado.UnidadeMedida;

                        this.lblOCAguardandoRecebimento.Text = item.Value.qtdSolicitacoesCompraCompradas.ToString("F4", CultureInfo.CurrentCulture) + " " + this.produtoSelecionado.UnidadeMedida;
                        this.lblScsPrendentes.Text = (item.Value.qtdSolicitacoesCompraAguardandoCompra).ToString("F4", CultureInfo.CurrentCulture) + " " + this.produtoSelecionado.UnidadeMedida;

                        if (string.IsNullOrWhiteSpace(_historicoCalculo))
                        {
                            _historicoCalculo = item.Value.HistoricoCalculo;
                        }
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as informações do produto.\r\n" + e.Message, e);
            }
        }

        private void loadInfosEpi()
        {
            try
            {
                this.lblEpiIdentificacao.Text = this.epiSelecionado.Identificacao;
                this.lblEpiDescricao.Text = this.epiSelecionado.Descricao;
                this.lblEpiDescricaoAdicional.Text = this.epiSelecionado.DescricaoAdicional;

                this.lblProLocalFabricacao.Text = "";
                this.lblProRevisaoCadastro.Text = this.epiSelecionado.UltimaRevisaoData.ToString() + " " + this.epiSelecionado.UltimaRevisao;

                if (this.epiSelecionado.UnidadeMedidaCompra != null)
                {
                    this.lblEpiUnidadeCompra.Text = this.epiSelecionado.UnidadeMedidaCompra.ToString();
                }
                else
                {
                    this.lblEpiUnidadeCompra.Text = this.epiSelecionado.UnidadeMedidaUso.ToString();
                }

                this.lblEpiUnidadeUso.Text = this.epiSelecionado.UnidadeMedidaUso.ToString();

                this.dtpDataPrevistaLeadtime.Value = this.epiSelecionado.calculaEntregaPrevistaCompra(diasPCP, Configurations.DataIndependenteClass.GetData());

                DateTime? tmp = this.epiSelecionado.calculaDataProximaUtilizacao();
                if (tmp == null)
                {
                    this.lblSemUtilizacao1.Visible = true;
                    this.dtpPrimeraUtilizacao.Visible = false;
                    this.btnPrimeiraUtilizacao.Visible = false;
                }
                else
                {
                    this.lblSemUtilizacao1.Visible = false;
                    this.dtpPrimeraUtilizacao.Visible = true;
                    this.btnPrimeiraUtilizacao.Visible = true;
                    this.dtpPrimeraUtilizacao.Value = tmp.Value;
                }

                tmp = this.epiSelecionado.calculaDataZeraEstoque();
                if (tmp == null)
                {
                    this.lblSemUtilizacao2.Visible = true;
                    this.dtpEncerramentoEstoque.Visible = false;
                    this.btnEncerramentoEstoque.Visible = false;
                }
                else
                {
                    this.lblSemUtilizacao1.Visible = false;
                    this.dtpEncerramentoEstoque.Visible = true;
                    this.btnEncerramentoEstoque.Visible = true;
                    this.dtpEncerramentoEstoque.Value = tmp.Value;
                }


                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                this.lblEstoqueAtual.Text = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueEpi(this.epiSelecionado, ref command).ToString("F4", CultureInfo.CurrentCulture) + " " + this.epiSelecionado.UnidadeMedidaUso.ToString(); 

                NecessidadeCompra necessidade = new NecessidadeCompra(tipoCalculoSemana, diaCalculoSemana,
                    diasPCP, leadtimeCompras, diasVerde, diasAmarelo, diasVermelho,
                    mesesMedia, categoriaAAcimaDe, categoriaBAcimaDe, margemAvisoKB,
                    sugeridoAcimaCompras,
                    conn, Usuario);

                necessidade.gerarRelatorio(null, null, this.epiSelecionado.ID, new List<SolicitacaoCompraClass>() { solicitacaoCompraOriginal });

                foreach (KeyValuePair<itemNecessidadeCompraKey, itemNecessidadeCompra> item in necessidade.itensComprar)
                {
                    if (TipoItemCompra.Epi == item.Value.tipoItem && item.Value.Item.ID == this.epiSelecionado.ID)
                    {
                        this.lblEVP.Text = item.Value.EVP.ToString("F4", CultureInfo.CurrentCulture) + " " + this.epiSelecionado.UnidadeMedidaUso.ToString(); 
                        this.lblQtdNecessaria.Text = item.Value.qtdNecessaria.ToString("F4", CultureInfo.CurrentCulture) + " " + this.epiSelecionado.UnidadeMedidaUso;
                        this.lblDemandaSugeriaVerde.Text = item.Value.estoqueMinimo.ToString("F4", CultureInfo.CurrentCulture) + " " + this.epiSelecionado.UnidadeMedidaUso;

                        this.lblOCAguardandoRecebimento.Text = item.Value.qtdSolicitacoesCompraCompradas.ToString("F4", CultureInfo.CurrentCulture) + " " + this.epiSelecionado.UnidadeMedidaUso;
                        this.lblScsPrendentes.Text = (item.Value.qtdSolicitacoesCompraAguardandoCompra).ToString("F4", CultureInfo.CurrentCulture) + " " + this.epiSelecionado.UnidadeMedidaUso;

                        if (string.IsNullOrWhiteSpace(_historicoCalculo))
                        {
                            _historicoCalculo = item.Value.HistoricoCalculo;
                        }
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as informações do Epi.\r\n" + e.Message, e);
            }
        }

        private void loadGrID()
        {
            try
            {
                if (this.modoAtualTela != ModosTela.SelecionaProduto) return;

                string filter = " AND (" +
                                " UPPER(pro_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR UPPER(pro_codigo_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR UPPER(pro_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR UPPER(lof_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR LOWER(pro_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR LOWER(pro_codigo_cliente) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR LOWER(pro_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR LOWER(lof_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " ) ";


                BindingSource bindingProd = new BindingSource();

                string sql = "SELECT  " +
                             "  id_produto, " +
                             "  pro_codigo, " +
                             "  pro_codigo_cliente, " +
                             "  pro_descricao, " +
                             "  CASE pro_tipo_aquisicao WHEN 0 THEN 'Fabricado' WHEN 1 THEN 'Comprado' ELSE 'Inválido' END, " +
                             "  CASE WHEN u2.unm_abreviada IS NOT NULL THEN u2.unm_abreviada ELSE public.unidade_medida.unm_abreviada END as unidade, " +
                             "  pro_emite_op, " +
                             "  pro_versao_estrutura_atual " +
                             "FROM  " +
                             "  public.produto " +
                             "  LEFT OUTER JOIN public.local_fabricacao ON (public.produto.id_local_fabricacao = public.local_fabricacao.id_local_fabricacao) " +
                             "  LEFT JOIN public.unidade_medida ON (public.produto.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                             "  LEFT JOIN public.unidade_medida u2 ON (public.produto.id_unidade_medida_compra = u2.id_unidade_medida) " +
                             "WHERE pro_tipo_aquisicao = 1 AND pro_ativo = 1 " +
                             filter +
                             "ORDER BY " +
                             "  pro_codigo";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    bindingProd.DataSource = ds.Tables[0];


                    dgvProduto.AutoGenerateColumns = true;
                    dgvProduto.DataSource = bindingProd;

                    dgvProduto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvProduto.MultiSelect = false;

                    this.dgvProduto.Columns[0].Visible = false;
                    this.dgvProduto.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[1], "Código", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[2], "Código Cliente", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[3], "Descrição", 160, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[4], "Aquisição", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[5], "Unidade Compra", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[6], "Emite OP", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[7], "Rev. Atual", 60, DataGridViewAutoSizeColumnMode.None, true);


                    DataGridViewColumn column = dgvProduto.Columns["pro_emite_op"];
                    DataGridViewCheckBoxColumn tmp = null;

                    tmp = new DataGridViewCheckBoxColumn();
                    tmp.FalseValue = "0";
                    tmp.TrueValue = "1";
                    tmp.DataPropertyName = column.DataPropertyName;
                    tmp.DisplayIndex = column.DisplayIndex;
                    tmp.ReadOnly = column.ReadOnly;
                    tmp.AutoSizeMode = column.AutoSizeMode;
                    tmp.Width = column.Width;
                    tmp.Name = column.Name;
                    tmp.HeaderText = column.HeaderText;
                    dgvProduto.Columns.Remove(tmp.Name);
                    dgvProduto.Columns.Add(tmp);

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o grid de produtos.\r\n" + e.Message, e);
            }
        }

        private void loadGridMateriais()
        {
            try
            {
                if (this.modoAtualTela != ModosTela.SelecionaMaterial) return;

                BindingSource bindingMat = new BindingSource();
                string filter = " ( " +
                                " UPPER(fam_codigo || ' ' || mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR UPPER(mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR UPPER(mat_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR LOWER(fam_codigo || ' ' || mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR LOWER(mat_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR LOWER(mat_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR ('M'||material.id_material) LIKE UPPER('%" + this.txtBusca.Text.Trim() + "%') " +

                                " ) " +
                                " AND mat_ativo = 1 ";

                //Compras só emite SC de material de consumo
                if (TipoModulo.Tipo == TipoForm.Compras)
                {
                    //filter += " AND agrupador_material.agm_materiais_consumo = 1 ";
                    filter += " AND agrupador_material.agm_tipo_consumo_estoque = " + Convert.ToInt16(EASITipoConsumoEstoque.Consumo) + " ";
                }

                string sql = "SELECT  " +
                             "  public.material.id_material, " +
                             "  'M'||public.material.id_material as codigo_interno, " +
                             "  public.familia_material.fam_codigo || ' ' || public.material.mat_codigo as codigo, " +
                             "  public.material.mat_descricao, " +
                             "  public.material.mat_descricao_adicional, " +
                             "  public.material.mat_medida, " +
                             "  public.material.mat_medida_largura, " +
                             "  public.material.mat_medida_comprimento, " +
                             "  CASE WHEN u2.unm_abreviada IS NOT NULL THEN u2.unm_abreviada ELSE public.unidade_medida.unm_abreviada END as unidade, " +
                             "  CASE public.material.mat_politica_estoque WHEN 0 THEN 'MRP' WHEN 1 THEN 'Kanban' ELSE 'Não Aplicável' END AS politica_estoque " +
                             "FROM " +
                             "  public.material " +
                             "  LEFT JOIN public.unidade_medida ON (public.material.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                             "  LEFT JOIN public.unidade_medida u2 ON (public.material.id_unidade_medida_compra = u2.id_unidade_medida) " +
                             "  LEFT JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                             "  LEFT JOIN public.agrupador_material ON (public.agrupador_material.id_agrupador_material = public.familia_material.id_agrupador_material) " +
                             "WHERE " +
                             filter +
                             "ORDER BY " +
                             "  mat_descricao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    bindingMat.DataSource = ds.Tables[0];

                    dgvMaterial.AutoGenerateColumns = true;
                    dgvMaterial.DataSource = bindingMat;

                    dgvMaterial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMaterial.MultiSelect = false;

                    this.dgvMaterial.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[1], "Código Interno", 60, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[2], "Material", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[3], "Descrição", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[4], "Descrição Adicional", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[5], "Dimensão 1", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[6], "Dimensão 2", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[7], "Dimensão 3", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[8], "Unidade Compra", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[9], "Politica Estoque", 100, DataGridViewAutoSizeColumnMode.None, true);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o grid de materiais.\r\n" + e.Message, e);
            }

        }

        private void loadGridEpi()
        {
            try
            {
                if (this.modoAtualTela != ModosTela.SelecionaEpi) return;

                string filter = " (" +
                                " UPPER(epi_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR UPPER(epi_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR UPPER(epi_descricao_adicional) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                                " OR LOWER(epi_identificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR LOWER(epi_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " OR LOWER(epi_descricao_adicional) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                                " ) ";


                BindingSource bindingProd = new BindingSource();

                string sql = "SELECT  " +
                             "  id_epi, " +
                             "  epi_identificacao, " +
                             "  epi_descricao, " +
                             "  epi_descricao_adicional, " +
                             "  CASE WHEN u2.unm_abreviada IS NOT NULL THEN u2.unm_abreviada ELSE public.unidade_medida.unm_abreviada END as unidade " +
                             "FROM  " +
                             "  public.epi " +
                             "  LEFT JOIN public.unidade_medida ON (public.epi.id_unidade_medida_uso = public.unidade_medida.id_unidade_medida) " +
                             "  LEFT JOIN public.unidade_medida u2 ON (public.epi.id_unidade_medida_compra = u2.id_unidade_medida) " +
                             "WHERE " +
                             filter +
                             "ORDER BY " +
                             "  epi_identificacao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    bindingProd.DataSource = ds.Tables[0];

                    dgvEpi.AutoGenerateColumns = true;
                    dgvEpi.DataSource = bindingProd;

                    dgvEpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEpi.MultiSelect = false;

                    this.dgvEpi.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[1], "Identificação", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[2], "Descrição", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[3], "Descrição Adicional", 160, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[4], "Unidade Compra", 80, DataGridViewAutoSizeColumnMode.None, true);

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o grid de Epi.\r\n" + e.Message, e);
            }
        }

        private void updateSearch()
        {
            try
            {
                if (rdbProduto.Checked)
                {
                    this.loadGrID();
                }
                else
                {
                    if (rdbMaterial.Checked)
                    {
                        this.loadGridMateriais();
                    }
                    else
                    {
                        this.loadGridEpi();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message);
            }
        }

        private void Avancar()
        {
            try
            {
                string msgSalvar;
                switch (this.modoAtualTela)
                {
                    case ModosTela.SelecionaMaterial:
                        if (this.dgvMaterial.SelectedRows.Count > 0)
                        {
                            this.materialSelecionado =
                                MaterialBaseClass.GetEntidade(
                                    Convert.ToInt32(dgvMaterial.SelectedRows[0].Cells["id_material"].Value),
                                    this.Usuario, this.conn);
                            this.produtoSelecionado = null;
                            this.epiSelecionado = null;

                            while (this.SolicitacoesCompra.Count > 0)
                            {
                                this.SolicitacoesCompra.RemoveAt(0);
                            }

                            this.AdicionarSc(this.materialSelecionado, null, null);


                            this.setModoTela(ModosTela.MaterialSelecionado);
                        }
                        else
                        {
                            throw new Exception("Selecione um material para continuar.\r\n");
                        }
                        break;

                    case ModosTela.SelecionaProduto:
                        if (this.dgvProduto.SelectedRows.Count > 0)
                        {
                            this.produtoSelecionado =
                                ProdutoBaseClass.GetEntidade(Convert.ToInt32(dgvProduto.SelectedRows[0].Cells["id_produto"].Value),
                                    this.Usuario, this.conn);
                            this.materialSelecionado = null;
                            this.epiSelecionado = null;

                            while (this.SolicitacoesCompra.Count > 0)
                            {
                                this.SolicitacoesCompra.RemoveAt(0);
                            }

                            this.AdicionarSc(null, produtoSelecionado, null);

                            this.setModoTela(ModosTela.ProdutoSelecionado);
                        }
                        else
                        {
                            throw new Exception("Selecione um produto para continuar.\r\n");
                        }
                        break;

                    case ModosTela.SelecionaEpi:
                        if (this.dgvEpi.SelectedRows.Count > 0)
                        {
                            this.epiSelecionado = EpiBaseClass.GetEntidade(Convert.ToInt32(dgvEpi.SelectedRows[0].Cells["id_epi"].Value), this.Usuario, this.SingleConnection);
                            this.materialSelecionado = null;
                            this.produtoSelecionado = null;

                            while (this.SolicitacoesCompra.Count > 0)
                            {
                                this.SolicitacoesCompra.RemoveAt(0);
                            }

                            this.AdicionarSc(null, null, epiSelecionado);

                            this.setModoTela(ModosTela.EpiSelecionado);
                        }
                        else
                        {
                            throw new Exception("Selecione um Epi para continuar.\r\n");
                        }
                        break;

                    case ModosTela.MaterialSelecionado:
                    case ModosTela.ProdutoSelecionado:
                    case ModosTela.EpiSelecionado:
                        this.Salvar();
                        break;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao avançar.\r\n" + a.Message);
            }
        }

        private void Salvar()
        {
            this.validarCamposObrigatorios();

            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                foreach (SolicitacaoCompraClass sc in SolicitacoesCompra)
                {
                    sc.Observacao = this.txtObservacao.Text.Trim();
                    if (_aprovarPcp)
                    {
                        sc.aprovarPCP();
                    }
                    sc.Save(ref command, null);
                }

                if (this.SolicitacoesCompraRemover != null)
                {
                    foreach (SolicitacaoCompraClass sc in SolicitacoesCompraRemover)
                    {
                        sc.Cancelar();
                        sc.Save(ref command, null);
                    }
                }

                command.Transaction.Commit();
                string msg = "Salvas";
                if (_aprovarPcp)
                {
                    msg = "Aprovadas e " + msg;
                }
                MessageBox.Show(this, "Solicitações " + msg + " com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("\r\n" + e.Message, e);
            }


        }

        private void AdicionarSc(MaterialClass material, ProdutoClass produto, EpiClass epi)
        {
            SolicitacaoCompraClass sc = new SolicitacaoCompraClass(null, null, this.Usuario, this.conn);
            if (material != null)
            {
                sc.setMaterial(material, 0, 0, null, DataIndependenteClass.GetData(), "");
            }

            if (produto != null)
            {
                sc.setProduto(produto, 0, 0, null, DataIndependenteClass.GetData(), "");
            }

            if (epi != null)
            {
                sc.setEpi(epi, 0, 0, null, DataIndependenteClass.GetData(), "");
            }

            sc.Consumo = false;
            this.SolicitacoesCompra.Add(sc);
            this.InitializeGridSCs();
        }

        private void RemoverSc()
        {
            try
            {

                List<int> rows = new List<int>();
                if (this.dgvSolicitacoes.SelectedRows.Count <= 0)
                {
                    if (this.dgvSolicitacoes.SelectedCells.Count != 0)
                    {
                        foreach (DataGridViewCell cell in this.dgvSolicitacoes.SelectedCells)
                        {
                            if (!rows.Contains(cell.RowIndex))
                            {
                                rows.Add(cell.RowIndex);
                            }
                        }
                    }
                }
                else
                {
                    rows.AddRange(from DataGridViewRow row in dgvSolicitacoes.SelectedRows select row.Index);
                }






                if (rows.Count <= 0) return;

                if (DialogResult.Yes != MessageBox.Show(this, "Deseja remover a(s) SC(s) selecionada(s)?", "Exclusão da SC", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }

                if (this.SolicitacoesCompra.Count - rows.Count < 1)
                {
                    throw new ExcecaoTratada("Não é possível remover a última SC, para excluir a SC utilize a função correspondente na listagem.");
                }

                if (SolicitacoesCompraRemover == null)
                {
                    SolicitacoesCompraRemover = new List<SolicitacaoCompraClass>();
                }

                foreach (int i in rows)
                {
                    DataGridViewRow row = this.dgvSolicitacoes.Rows[i];
                    SolicitacaoCompraClass sc = (SolicitacaoCompraClass) row.DataBoundItem;
                    this.SolicitacoesCompra.Remove(sc);
                    if (sc.idSolicitacaoCompra.HasValue)
                    {
                        SolicitacoesCompraRemover.Add(sc);
                    }
                }

                this.InitializeGridSCs();

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao remover a SC\r\n" + e.Message, e);
            }
        }

        private void validarCamposObrigatorios()
        {
            try
            {
                if (this.txtObservacao.Text.Trim().Length < 5)
                {
                    throw new Exception("O campo observação deve possuir pelo menos 5 caracteres");
                }

                foreach (SolicitacaoCompraClass sc in SolicitacoesCompra)
                {
                    if (!(sc.Quantidade > 0))
                    {
                        throw new Exception("O campo quantidade deve ser maior que zero");
                    }


                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message, e);
            }

        }

        private void HistoricoQuantidade()
        {
           SolicitacaoCompraHistoricoCalculoForm form = new SolicitacaoCompraHistoricoCalculoForm(_historicoCalculo);
            form.Show();
        }

        #region Eventos

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.Avancar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbMaterial.Checked)
                {
                    this.setModoTela(ModosTela.SelecionaMaterial);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbProduto.Checked)
                {
                    this.setModoTela(ModosTela.SelecionaProduto);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void rdbEpi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbEpi.Checked)
                {
                    this.setModoTela(ModosTela.SelecionaEpi);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Stop();
                this.timerBusca.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Enabled = false;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ProdutoClass prod = ProdutoBaseClass.GetEntidade(Convert.ToInt32(dgvProduto.SelectedRows[0].Cells["id_produto"].Value), this.Usuario, this.conn);
                CadProdutoPCPForm form = new CadProdutoPCPForm(prod);

                form.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MaterialClass mat = MaterialBaseClass.GetEntidade(Convert.ToInt32(dgvMaterial.SelectedRows[0].Cells["id_material"].Value), this.Usuario, this.conn);
                CadMaterialForm form = new CadMaterialForm(mat) {SomenteLeitura = true};
                form.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEpi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CadEpiForm form = new CadEpiForm(EpiBaseClass.GetEntidade(Convert.ToInt32(dgvEpi.SelectedRows[0].Cells["id_material"].Value), this.Usuario, this.SingleConnection));
                form.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkMaterial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                CadMaterialForm form = new CadMaterialForm(this.materialSelecionado) {SomenteLeitura = true};
                form.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkProduto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                CadProdutoPCPForm form = new CadProdutoPCPForm(this.produtoSelecionado, true);


                form.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkEpi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                try
                {
                    CadEpiForm form = new CadEpiForm(this.epiSelecionado);
                    form.Show();
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLeadtime_Click(object sender, EventArgs e)
        {
            List<int> rows = new List<int>();
            if (this.dgvSolicitacoes.SelectedRows.Count <= 0)
            {
                if (this.dgvSolicitacoes.SelectedCells.Count != 0)
                {
                    foreach (DataGridViewCell cell in this.dgvSolicitacoes.SelectedCells)
                    {
                        if (!rows.Contains(cell.RowIndex))
                        {
                            rows.Add(cell.RowIndex);
                        }
                    }
                }
            }
            else
            {
                rows.AddRange(from DataGridViewRow row in dgvSolicitacoes.SelectedRows select row.Index);
            }


            foreach (int i in rows)
            {
                DataGridViewRow row = this.dgvSolicitacoes.Rows[i];
                SolicitacaoCompraClass sc = (SolicitacaoCompraClass) row.DataBoundItem;
                sc.DataEntregaPrevista = this.dtpDataPrevistaLeadtime.Value;
                this.dgvSolicitacoes.InvalidateRow(row.Index);
            }
        }

        private void btnPrimeiraUtilizacao_Click(object sender, EventArgs e)
        {
            List<int> rows = new List<int>();
            if (this.dgvSolicitacoes.SelectedRows.Count <= 0)
            {
                if (this.dgvSolicitacoes.SelectedCells.Count != 0)
                {
                    foreach (DataGridViewCell cell in this.dgvSolicitacoes.SelectedCells)
                    {
                        if (!rows.Contains(cell.RowIndex))
                        {
                            rows.Add(cell.RowIndex);
                        }
                    }
                }
            }
            else
            {
                rows.AddRange(from DataGridViewRow row in dgvSolicitacoes.SelectedRows select row.Index);
            }


            foreach (int i in rows)
            {
                DataGridViewRow row = this.dgvSolicitacoes.Rows[i];
                SolicitacaoCompraClass sc = (SolicitacaoCompraClass) row.DataBoundItem;
                sc.DataEntregaPrevista = this.dtpPrimeraUtilizacao.Value;
                this.dgvSolicitacoes.InvalidateRow(row.Index);
            }
        }

        private void btnEncerramentoEstoque_Click(object sender, EventArgs e)
        {
            List<int> rows = new List<int>();
            if (this.dgvSolicitacoes.SelectedRows.Count <= 0)
            {
                if (this.dgvSolicitacoes.SelectedCells.Count != 0)
                {
                    foreach (DataGridViewCell cell in this.dgvSolicitacoes.SelectedCells)
                    {
                        if (!rows.Contains(cell.RowIndex))
                        {
                            rows.Add(cell.RowIndex);
                        }
                    }
                }
            }
            else
            {
                rows.AddRange(from DataGridViewRow row in dgvSolicitacoes.SelectedRows select row.Index);
            }


            foreach (int i in rows)
            {
                DataGridViewRow row = this.dgvSolicitacoes.Rows[i];
                SolicitacaoCompraClass sc = (SolicitacaoCompraClass) row.DataBoundItem;
                sc.DataEntregaPrevista = this.dtpEncerramentoEstoque.Value;
                this.dgvSolicitacoes.InvalidateRow(row.Index);
            }
        }

        private void btnAdicionarSc_Click(object sender, EventArgs e)
        {
            try
            {
                this.AdicionarSc(this.materialSelecionado, this.produtoSelecionado, this.epiSelecionado);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverSc_Click(object sender, EventArgs e)
        {
            try
            {
                this.RemoverSc();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSolicitacoes_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvSolicitacoes.InvalidateRow(e.RowIndex);

        }

        private void btnHistoricoCalculoQuantidades_Click(object sender, EventArgs e)
        {
            try
            {
                this.HistoricoQuantidade();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        #endregion


    }
}
