using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;
using OrdemProducaoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoClass;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares.OrdemProducao
{

    public partial class GerarOpAvulsaForm : IWTBaseForm
    {
        AcsUsuarioClass Usuario;
        IWTPostgreNpgsqlConnection conn;
        private BindingSource binding;

        private enum TipoSelecaoTela
        {
            Produto,
            ProdutoK
        }

        private TipoSelecaoTela? _tipoSelecaoTela = null;

        private IOrdemProducaoFactory iOrdemProducaoFactory;
        private bool _produtoChecked = false;
        private ICarregarDocumentosImpressaoOp _carregarDocumentosImpressaoOp;

        public GerarOpAvulsaForm(AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory, ICarregarDocumentosImpressaoOp carregarDocumentosImpressaoOp = null)
        {
            InitializeComponent();
            this.Usuario = usuario;
            this.conn = conn;


            this.iOrdemProducaoFactory = iOrdemProducaoFactory;
            _carregarDocumentosImpressaoOp = carregarDocumentosImpressaoOp;

            this.initializeGrid();
        }

        

        private void initializeGrid()
        {
            try
            {

                #region Salvando Posição do Grid

                int scrollIndex = 0;
                if (this.dataGridView1.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dataGridView1.SelectedRows[0].Index;
                }

                #endregion

                #region Salvando FiltroAtual

                string atualFilter;
                if (this.binding != null)
                {
                    atualFilter = this.binding.Filter;
                }
                else
                {
                    atualFilter = "";
                }

                #endregion

                #region Salvando o Sort Atual do Grid

                string sortedColumName = null;
                SortOrder? sortedMode = null;
                if (this.dataGridView1.SortedColumn != null)
                {
                    sortedColumName = this.dataGridView1.SortedColumn.Name;
                    sortedMode = this.dataGridView1.SortOrder;
                }

                #endregion

                if (rdbProduto.Checked)
                {
                    if (!_produtoChecked)
                    {
                        atualFilter = null;
                        txtBusca.Clear();
                    }

                    _produtoChecked = true;
                    _tipoSelecaoTela = TipoSelecaoTela.Produto;
                    InicializeGridProduto(atualFilter);
                }
                else
                {
                    if (rdbProdutoK.Checked)
                    {
                        if (_produtoChecked)
                        {
                            atualFilter = null;
                            txtBusca.Clear();
                        }
                        _produtoChecked = false;
                        _tipoSelecaoTela = TipoSelecaoTela.ProdutoK;
                        InicializeGridProdutoK(atualFilter);
                    }
                    else
                    {
                        atualFilter = null;
                        _tipoSelecaoTela = null;
                        dataGridView1.DataSource = null;
                        binding = null;
                        return;
                    }
                }

                #region Restaurando Sort Atual do Grid

                if (sortedColumName != null)
                {
                    string sortString = sortedColumName;
                    switch (sortedMode)
                    {
                        case SortOrder.Ascending:
                            sortString += " ASC";
                            break;
                        case SortOrder.Descending:
                            sortString += " DESC";
                            break;
                    }

                    this.binding.Sort = sortString;
                }

                #endregion

                #region Restaurando Posição do Grid

                for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                {
                    this.dataGridView1.SelectedRows[i].Selected = false;
                }

                if (this.dataGridView1.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dataGridView1.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dataGridView1.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dataGridView1.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dataGridView1.FirstDisplayedScrollingRowIndex = scrollIndex;
                }

                #endregion

                this.updateSearch();

            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void InicializeGridProduto(string atualFilter)
        {

            string sql =
                "SELECT " +
                "  pro_codigo,        " +
                "  pro_codigo_cliente,  " +
                "  pro_descricao, " +
                "  clp_identificacao,    " +
                "  CASE pro_utilizando_estoque_seguranca WHEN 1 THEN 'Verde' WHEN 2 THEN 'Amarelo' WHEN 3 THEN 'Vermelho' ELSE '' END as usando_estoque_seguranca, " +
                "  0 as qtd,    " +
                "  0 , " +
                "  id_produto " +
                "FROM                       " +
                "  public.produto         " +
                "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto)    " +
                "WHERE    " +
                "  pro_ativo = 1 AND pro_emite_op = 1   " +
                "ORDER BY                   " +
                "  UPPER(pro_codigo),              " +
                "  UPPER(clp_identificacao) ; ";

            //Alteração Marcelo na consulta acima

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            binding = new BindingSource {DataSource = ds.Tables[0], Filter = atualFilter};
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = binding;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.ReadOnly = false;

            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Identificação", 120, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Código Cliente", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Descrição", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Classificação", 80, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Est. Seg. Acionado", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Quantidade Produzir", 100, DataGridViewAutoSizeColumnMode.None, true);
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[7].Visible = false;

            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = true;
            this.dataGridView1.Columns[4].ReadOnly = true;
            this.dataGridView1.Columns[5].ReadOnly = false;
            this.dataGridView1.Columns[6].ReadOnly = true;

        }

        private void InicializeGridProdutoK(string atualFilter)
        {


            string sql =
                "SELECT " +
                "  prk_codigo,        " +
                "  prk_dimensao,  " +
                "  prk_descricao, " +
                "  clp_identificacao,    " +
                "  CASE prk_utilizando_estoque_seguranca WHEN 1 THEN 'Verde' WHEN 2 THEN 'Amarelo' WHEN 3 THEN 'Vermelho' ELSE '' END as usando_estoque_seguranca, " +
                "  0 as qtd,    " +
                "  CASE \"isNumber\"(translate(prk_dimensao,'/*+!@#$%', 'ssssssss')) WHEN true THEN CAST(prk_dimensao AS DOUBLE PRECISION) ELSE 99999999 END, " +
                "  id_produto_k " +
                "FROM                       " +
                "  public.produto_k         " +
                "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto_k.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto)    " +
                "WHERE    " +
                "  prk_ativo = 1 AND prk_emite_op = 1   " +
                "ORDER BY                   " +
                "  UPPER(prk_codigo),              " +
                "  CASE \"isNumber\"(translate(prk_dimensao,'/*+!@#$%', 'ssssssss')) WHEN true THEN CAST(prk_dimensao AS DOUBLE PRECISION) ELSE 99999999 END,           " +
                "  UPPER(clp_identificacao) ; ";

            //Alteração Marcelo na consulta acima

            IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            binding = new BindingSource {DataSource = ds.Tables[0], Filter = atualFilter};
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = binding;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.ReadOnly = false;

            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Identificação", 120, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Dimensão Variável", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Descrição", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Classificação", 80, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Est. Seg. Acionado", 100, DataGridViewAutoSizeColumnMode.None, true);
            IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Quantidade Produzir", 100, DataGridViewAutoSizeColumnMode.None, true);
            this.dataGridView1.Columns[6].Visible = false;
            this.dataGridView1.Columns[7].Visible = false;

            this.dataGridView1.Columns[0].ReadOnly = true;
            this.dataGridView1.Columns[1].ReadOnly = true;
            this.dataGridView1.Columns[2].ReadOnly = true;
            this.dataGridView1.Columns[3].ReadOnly = true;
            this.dataGridView1.Columns[4].ReadOnly = true;
            this.dataGridView1.Columns[5].ReadOnly = false;
            this.dataGridView1.Columns[6].ReadOnly = true;


        }

        private void updateSearch()
        {
            try
            {

                string search = "";



                if (this.txtBusca.Text.Trim().Length > 0)
                {
                    switch (_tipoSelecaoTela)
                    {
                        case TipoSelecaoTela.Produto:
                            search += " AND (pro_codigo LIKE '%" + this.txtBusca.Text.Trim() + "%' OR pro_codigo_cliente LIKE '%" + this.txtBusca.Text.Trim() + "%' OR clp_identificacao LIKE '%" + this.txtBusca.Text.Trim() + "%') ";
                            break;
                        case TipoSelecaoTela.ProdutoK:
                            search += " AND (prk_codigo LIKE '%" + this.txtBusca.Text.Trim() + "%' OR clp_identificacao LIKE '%" + this.txtBusca.Text.Trim() + "%') ";
                            break;
                        case null:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                }


                if (search.Length > 0)
                {
                    this.binding.Filter = search.Substring(4);
                }
                else
                {
                    this.binding.Filter = "";
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message, e);
            }
        }

        private List<OrdemProducaoClass> GerarProduto()
        {
            List<GeradorOpAvulsa.GerarOpAvulsaParametros> itens = new List<GeradorOpAvulsa.GerarOpAvulsaParametros>();

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (Convert.ToDouble(row.Cells["qtd"].Value) > 0)
                {
                    long idProduto = Convert.ToInt64(row.Cells["id_produto"].Value);
                    double qtd = Convert.ToDouble(row.Cells["qtd"].Value);

                    itens.Add(new GeradorOpAvulsa.GerarOpAvulsaParametros()
                        {
                            Produto = ProdutoClass.GetEntidade(idProduto,Usuario,conn),
                            Quantidade = qtd
                        }
                    );
                }
            }

            if (itens.Count == 0)
            {
                throw new Exception("Indique a quantidade de ao menos um item para a geração");
            }

            return GeradorOpAvulsa.Gerar(itens, Usuario, conn, this.iOrdemProducaoFactory);
        }

        private List<OrdemProducaoClass> GerarProdutoK()
        {
            List<ItemOpAgrupadorClass> itens = new List<ItemOpAgrupadorClass>();

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (Convert.ToDouble(row.Cells["qtd"].Value) > 0)
                {
                    itens.Add(new ItemOpAgrupadorClass(
                            row.Cells["prk_codigo"].Value.ToString(),
                            row.Cells["prk_descricao"].Value.ToString(),
                            row.Cells["prk_dimensao"].Value.ToString(),
                            Convert.ToDouble(row.Cells["qtd"].Value)
                        )
                    );
                }
            }

            if (itens.Count == 0)
            {
                throw new Exception("Indique a quantidade de ao menos um item para a geração");
            }

            GeradorOpAgrupadorClass ger = new GeradorOpAgrupadorClass(itens, Usuario, conn, this.iOrdemProducaoFactory);
            return ger.Gerar();
        }

        private void Gerar()
        {
            List<OrdemProducaoClass> ops;
            switch (_tipoSelecaoTela)
            {
                case TipoSelecaoTela.Produto:
                    ops= GerarProduto();
                    break;
                case TipoSelecaoTela.ProdutoK:
                    ops =GerarProdutoK();
                    break;
                case null:
                    ops = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }


            if (ops?.Count > 0)
            {
                OpReportForm form;
                if (MessageBox.Show(null, "Você deseja imprimir as ops geradas agora?\r\nSim: Imprime as Ordens\r\nNão: Somente Visualização em tela", "Impressão de OP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (OrdemProducaoClass op in ops)
                    {
                        op.setImpressao(this.Usuario);
                        op.Save();
                    }

                    form = new OpReportForm(ops, true, this.Usuario, this.conn, _carregarDocumentosImpressaoOp);



                }
                else
                {

                    form = new OpReportForm(ops, false, this.Usuario, this.conn, _carregarDocumentosImpressaoOp);

                }

                if (!form.IsDisposed)
                {
                    form.ShowDialog();
                }

                this.Close();
            }
            else
            {
                throw new Exception("Não é possível gerar nenhuma OP para os parâmetros selecionados.");
            }

        }

        private void SelecionarProdutoK(long idProdutoK)
        {
            ProdutoKClass produtoK = ProdutoKClass.GetEntidade(idProdutoK, Usuario, conn);
            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

            #region Médias

            int numeroMeses = int.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
            DateTime dataInicio = Configurations.DataIndependenteClass.GetData().AddMonths(numeroMeses * -1);

            command.CommandText =
                "SELECT  " +
                "  SUM(order_item_etiqueta.oie_quantidade) as qtdTotal " +
                "FROM   " +
                "  order_item_etiqueta   " +
                "  INNER JOIN (" +
                "    SELECT pedido_item.pei_numero,pedido_item.pei_posicao, pedido_item.id_cliente,pedido_item.pei_data_entrada FROM  " +
                "       public.pedido_item WHERE pei_sub_linha = 0 " +
                " ) as tab ON " +
                "    (tab.pei_numero = public.order_item_etiqueta.oie_order_number) AND " +
                "    (tab.pei_posicao = public.order_item_etiqueta.oie_order_pos) AND " +
                "    (tab.id_cliente = public.order_item_etiqueta.id_cliente)  " +
                "  INNER JOIN public.produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k " +
                "WHERE " +
                "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                "  produto_k.id_produto_k = " + produtoK.ID + " " +
                " GROUP BY " +
                "  public.produto_k.id_produto_k,   " +
                "  public.produto_k.prk_codigo, " +
                "  public.order_item_etiqueta.oie_dimensao ";


            double? tmp = command.ExecuteScalar() as double?;
            double mediaMensal = tmp.HasValue ? tmp.Value : 0;


            double mediaDiaria = mediaMensal / (numeroMeses * 30);
            int diasVerde = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
            int diasAmarelo = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
            int diasVermelho = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));

            double estoqueVerde = (mediaDiaria * diasVerde);
            this.lblVerde.Text = estoqueVerde.ToString("F4", CultureInfo.CurrentCulture);
            this.lblAmarelo.Text = (mediaDiaria * diasAmarelo).ToString("F4", CultureInfo.CurrentCulture);
            this.lblVermelho.Text = (mediaDiaria * diasVermelho).ToString("F4", CultureInfo.CurrentCulture);



            #endregion

            #region Estoque Atual

            double estoqueAtual = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProdutoK(produtoK, ref command);
            this.lblEstoqueAtual.Text = estoqueAtual.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

            #region Pedidos Pendentes

            command.CommandText =
                "SELECT  " +
                "  SUM(order_item_etiqueta.oie_saldo) as qtdTotal " +
                "FROM   " +
                "  order_item_etiqueta   " +
                "  INNER JOIN (" +
                "    SELECT pedido_item.pei_numero,pedido_item.pei_posicao, pedido_item.id_cliente,pedido_item.pei_data_entrada FROM  " +
                "       public.pedido_item WHERE pei_sub_linha = 0 AND (pei_status = 3 OR pei_status = 0) " +
                " ) as tab ON " +
                "    (tab.pei_numero = public.order_item_etiqueta.oie_order_number) AND " +
                "    (tab.pei_posicao = public.order_item_etiqueta.oie_order_pos) AND " +
                "    (tab.id_cliente = public.order_item_etiqueta.id_cliente)  " +
                "  INNER JOIN public.produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k " +
                "WHERE " +
                " produto_k.id_produto_k = " + produtoK.ID + " " +
                " GROUP BY " +
                "  public.produto_k.id_produto_k,   " +
                "  public.produto_k.prk_codigo, " +
                "  public.order_item_etiqueta.oie_dimensao ";


            tmp = command.ExecuteScalar() as double?;
            double pedidosPendentes = tmp.HasValue ? tmp.Value : 0;
            this.lblPedidosPendentes.Text = pedidosPendentes.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

            #region Ops Pendentes

            double OpsAbertas = 0;
            command.CommandText =
                "SELECT  " +
                "  SUM(public.ordem_producao.orp_quantidade)  " +
                "FROM " +
                "  public.ordem_producao " +
                "WHERE " +
                "  public.ordem_producao.id_produto_k =" + produtoK.ID + " AND  " +
                "  (public.ordem_producao.orp_situacao = 0 OR " +
                "  public.ordem_producao.orp_situacao = 4 OR " +
                "  public.ordem_producao.orp_situacao = 1) ";
            tmp = command.ExecuteScalar() as double?;
            if (tmp.HasValue)
            {
                OpsAbertas = tmp.Value;
            }



            this.lblOpsAberto.Text = OpsAbertas.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

            #region Sugestão Quantidade

            double sugestaoQtd = estoqueVerde * (1 + (Convert.ToDouble(decimal.Parse(IWTConfiguration.Conf.getConf(Constants.PERCENTUAL_GERACAO_OP_KB_ACIMA_ESTOQUE_VERDE))) / 100));
            sugestaoQtd += pedidosPendentes;
            sugestaoQtd -= OpsAbertas;
            sugestaoQtd -= estoqueAtual;

            this.lblSugestaoProducao.Text = sugestaoQtd.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

        }

        private void SelecionarProduto(long idProduto)
        {
            ProdutoClass produto = ProdutoClass.GetEntidade(idProduto, Usuario, conn);
            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

            #region Médias

            int numeroMeses = int.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
            DateTime dataInicio = Configurations.DataIndependenteClass.GetData().AddMonths(numeroMeses * -1);

            command.CommandText =
                "SELECT  " +
                "  SUM(order_item_etiqueta.oie_quantidade) as qtdTotal " +
                "FROM   " +
                "  order_item_etiqueta   " +
                "  INNER JOIN (" +
                "    SELECT pedido_item.pei_numero,pedido_item.pei_posicao, pedido_item.id_cliente,pedido_item.pei_data_entrada FROM  " +
                "       public.pedido_item WHERE pei_sub_linha = 0 " +
                " ) as tab ON " +
                "    (tab.pei_numero = public.order_item_etiqueta.oie_order_number) AND " +
                "    (tab.pei_posicao = public.order_item_etiqueta.oie_order_pos) AND " +
                "    (tab.id_cliente = public.order_item_etiqueta.id_cliente)  " +
                "  INNER JOIN public.produto ON produto.id_produto = order_item_etiqueta.id_produto " +
                "WHERE " +
                "  pei_data_entrada > '" + dataInicio.ToString("yyyy-MM-dd") + "' AND " +
                "  produto.id_produto = " + produto.ID + " " +
                " GROUP BY " +
                "  public.produto.id_produto,   " +
                "  public.produto.pro_codigo, " +
                "  public.order_item_etiqueta.oie_dimensao ";


            double? tmp = command.ExecuteScalar() as double?;
            double mediaMensal = tmp.HasValue ? tmp.Value : 0;


            double mediaDiaria = mediaMensal / (numeroMeses * 30);
            int diasVerde = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
            int diasAmarelo = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
            int diasVermelho = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));

            double estoqueVerde = (mediaDiaria * diasVerde);
            this.lblVerde.Text = estoqueVerde.ToString("F4", CultureInfo.CurrentCulture);
            this.lblAmarelo.Text = (mediaDiaria * diasAmarelo).ToString("F4", CultureInfo.CurrentCulture);
            this.lblVermelho.Text = (mediaDiaria * diasVermelho).ToString("F4", CultureInfo.CurrentCulture);



            #endregion

            #region Estoque Atual

            double estoqueAtual = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(produto, ref command);
            this.lblEstoqueAtual.Text = estoqueAtual.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

            #region Pedidos Pendentes

            command.CommandText =
                "SELECT  " +
                "  SUM(order_item_etiqueta.oie_saldo) as qtdTotal " +
                "FROM   " +
                "  order_item_etiqueta   " +
                "  INNER JOIN (" +
                "    SELECT pedido_item.pei_numero,pedido_item.pei_posicao, pedido_item.id_cliente,pedido_item.pei_data_entrada FROM  " +
                "       public.pedido_item WHERE pei_sub_linha = 0 AND (pei_status = 3 OR pei_status = 0) " +
                " ) as tab ON " +
                "    (tab.pei_numero = public.order_item_etiqueta.oie_order_number) AND " +
                "    (tab.pei_posicao = public.order_item_etiqueta.oie_order_pos) AND " +
                "    (tab.id_cliente = public.order_item_etiqueta.id_cliente)  " +
                "  INNER JOIN public.produto ON produto.id_produto = order_item_etiqueta.id_produto " +
                "WHERE " +
                " produto.id_produto = " + produto.ID + " " +
                " GROUP BY " +
                "  public.produto.id_produto,   " +
                "  public.produto.pro_codigo, " +
                "  public.order_item_etiqueta.oie_dimensao ";


            tmp = command.ExecuteScalar() as double?;
            double pedidosPendentes = tmp.HasValue ? tmp.Value : 0;
            this.lblPedidosPendentes.Text = pedidosPendentes.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

            #region Ops Pendentes
            double OpsAbertas = 0;
            command.CommandText =
                "SELECT  " +
                "  SUM(public.ordem_producao.orp_quantidade)  " +
                "FROM " +
                "  public.ordem_producao " +
                "WHERE " +
                "  public.ordem_producao.id_produto =" + produto.ID + " AND  " +
                "  (public.ordem_producao.orp_situacao = 0 OR " +
                "  public.ordem_producao.orp_situacao = 4 OR " +
                "  public.ordem_producao.orp_situacao = 1) ";
            tmp = command.ExecuteScalar() as double?;
            if (tmp.HasValue)
            {
                OpsAbertas = tmp.Value;
            }



            this.lblOpsAberto.Text = OpsAbertas.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

            #region Sugestão Quantidade

            double sugestaoQtd = estoqueVerde * (1 + (Convert.ToDouble(decimal.Parse(IWTConfiguration.Conf.getConf(Constants.PERCENTUAL_GERACAO_OP_KB_ACIMA_ESTOQUE_VERDE))) / 100));
            sugestaoQtd += pedidosPendentes;
            sugestaoQtd -= OpsAbertas;
            sugestaoQtd -= estoqueAtual;

            this.lblSugestaoProducao.Text = sugestaoQtd.ToString("F4", CultureInfo.CurrentCulture);

            #endregion

        }

        private void selecionarLinha()
        {
            try
            {
                this.lblAmarelo.Text = "";
                this.lblEstoqueAtual.Text = "";
                this.lblOpsAberto.Text = "";
                this.lblPedidosPendentes.Text = "";
                this.lblSugestaoProducao.Text = "";
                this.lblVerde.Text = "";
                this.lblVermelho.Text = "";


                if (chkCarregarQuantidadesEstoque.Checked)
                {
                    if (this.dataGridView1.SelectedRows.Count > 0)
                    {
                        DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                        switch (_tipoSelecaoTela)
                        {
                            case TipoSelecaoTela.Produto:
                                SelecionarProduto(Convert.ToInt64(row.Cells["id_produto"].Value));
                                break;
                            case TipoSelecaoTela.ProdutoK:
                                SelecionarProdutoK(Convert.ToInt64(row.Cells["id_produto_k"].Value));
                                break;
                            case null:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        

                    }
                }




            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar a linha.\r\n" + e.Message, e);
            }

        }

        #region Eventos

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Gerar();
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.Rows[e.RowIndex].ErrorText = String.Empty;

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            if (e.Exception != null)
            {
                if ((e.Context & DataGridViewDataErrorContexts.Parsing) != 0)
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Quantidade Inválida";
                    MessageBox.Show(this, "Valor inválido para a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                double temp = 0;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Quantidade inválida";
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    MessageBox.Show(this, "Valor inválido para a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.selecionarLinha();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void rdbProdutoK_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!rdbProdutoK.Checked) return;
                this.initializeGrid();
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

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!rdbProduto.Checked) return;

                this.initializeGrid();
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

        private void chkCarregarQuantidadesEstoque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                selecionarLinha();
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
