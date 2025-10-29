#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaProdutos;
using BibliotecaTributos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;
using dbProvider;
using MaterialClass = BibliotecaEntidades.Entidades.MaterialClass;
using OrdemCompraClass = BibliotecaEntidades.Operacoes.Compras.OrdemCompraClass;

#endregion

namespace BibliotecaCompras
{
    public partial class OCForm : IWTBaseForm
    {

        Dictionary<string, FornecedorUnidadePrecoClass> fornecPrecoList;
        bool step1 = true;
        int? idOc = null;
        double valorTotalOC = 0;
        readonly byte[] logoEmpresa;

        private string nomeEmpresa
        {
            get { return NotaFiscalFuncoesAuxiliares.CarregaNomeEmpresa(); }
        }
        readonly string remetenteCompras;

        

        private readonly string rodapeOC;
        private readonly string msgEmail;

        private int idComprador;
        private Dictionary<int, int> formaPagamentoFornecedorList;


        public OCForm(int idComprador)
        {
            InitializeComponent();


            this.logoEmpresa = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);
            

            this.remetenteCompras = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_REMETENTE);

         

            this.rodapeOC = IWTConfiguration.Conf.getConf(Constants.COMPRAS_RODAPE);
            this.msgEmail = IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_MENSAGEM);




            this.fornecPrecoList = new Dictionary<string, FornecedorUnidadePrecoClass>();
            this.rdbProduto.Checked = true;
            this.cmbProduto.Enabled = true;
            this.cmbMaterial.Enabled = false;
            this.cmbFornecedor.Enabled = false;
            this.cmbEpi.Enabled = false;



            this.idComprador = idComprador;

            this.loadCombos();
            this.loadComboFormaPagto();
        }

        private void loadCombos()
        {

            try
            {
                //Produto
                string sql = "SELECT  " +
                                    "  produto.id_produto, " +
                                    "  produto.pro_codigo, " +
                                    "  produto.pro_codigo_cliente, " +
                                    "  produto.pro_descricao, " +
                                    "  SUM(soc_qtd) as quantidade, "+
                                    "  CASE produto.pro_tipo_aquisicao WHEN 0 THEN 'Fabricado' WHEN 1 THEN 'Comprado' ELSE 'Inválido' END AS tipo_aquisicao, " +
                                    "  public.local_fabricacao.lof_identificacao " +
                                    "FROM " +
                                    "  public.solicitacao_compra " +
                                    "  INNER JOIN public.produto ON (public.solicitacao_compra.id_produto = public.produto.id_produto) " +
                                    "  INNER JOIN public.local_fabricacao ON (public.produto.id_local_fabricacao = public.local_fabricacao.id_local_fabricacao) " +
                                    "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) "+
                                    "WHERE " +
                                    "  public.solicitacao_compra.soc_status = 1 AND  " +
                                    "  public.solicitacao_compra.id_ordem_compra IS NULL AND " +
                                    "  ("+
                                    "    COALESCE(public.produto.id_comprador, public.classificacao_produto.id_comprador) = "+this.idComprador+" OR "+
                                    "    COALESCE(public.produto.id_comprador, public.classificacao_produto.id_comprador) IS NULL " +
                                    "   )"+
                                    "GROUP BY "+
                                    "  produto.id_produto, " +
                                    "  produto.pro_codigo, " +
                                    "  produto.pro_codigo_cliente, " +
                                    "  produto.pro_descricao, " +
                                    "  produto.pro_tipo_aquisicao, " +
                                    "  public.local_fabricacao.lof_identificacao " +
                                    "ORDER BY " +
                                    "  pro_codigo";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbProduto.DataSource = binding;
                    this.cmbProduto.ValueMember = "id_produto";
                    this.cmbProduto.DisplayMember = "pro_codigo";
                    this.cmbProduto.autoSize = true;
                    this.cmbProduto.Table = ds.Tables[0];
                    this.cmbProduto.ColumnsToDisplay = new string[] { "pro_codigo", "pro_codigo_cliente", "pro_descricao", "quantidade", "tipo_aquisicao", "lof_identificacao" };
                    this.cmbProduto.HeadersToDisplay = new string[] { "Código", "Código Cliente", "Descrição", "Quantidade", "Tipo Aquisição", "Local de Fabricação" };

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        this.rdbProduto.Checked = false;
                        this.rdbProduto.Enabled = false;
                        this.cmbProduto.Enabled = false;
                    }
                }

                //Material
                string sql2 =
                                    "SELECT  " +
                                    "  public.material.id_material, " +
                                    "  public.familia_material.fam_codigo || ' ' || public.material.mat_codigo ||' (M'|| material.id_material||')' as codigo, " +
                                    "  public.familia_material.fam_codigo, " +
                                    "  public.material.mat_codigo, " +
                                    "  public.material.mat_descricao, " +
                                    "  SUM(soc_qtd) as quantidade, " +
                                    "  public.material.mat_descricao_adicional, " +
                                    //"  public.material.mat_medida, " +
                                    //"  public.material.mat_medida_largura, " +
                                    //"  public.material.mat_medida_comprimento, " +
                                    "  public.unidade_medida.unm_abreviada, " +
                                    "  CASE public.material.mat_politica_estoque WHEN 0 THEN 'MRP' WHEN 1 THEN 'Kanban' ELSE 'Não Aplicável' END AS politica_estoque " +
                                    "FROM " +
                                    "  public.solicitacao_compra " +
                                    "  INNER JOIN public.material ON (public.solicitacao_compra.id_material = public.material.id_material) " +
                                    "  INNER JOIN public.unidade_medida ON (public.material.id_unidade_medida = public.unidade_medida.id_unidade_medida) " +
                                    "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                                    "WHERE " +
                                    "  public.solicitacao_compra.soc_status = 1 AND  " +
                                    "  public.solicitacao_compra.id_ordem_compra IS NULL AND " +

                                    "  (" +
                                    "    COALESCE(public.material.id_comprador, public.familia_material.id_comprador) = " + this.idComprador + " OR " +
                                    "    COALESCE(public.material.id_comprador, public.familia_material.id_comprador) IS NULL " +
                                    "   )" +
                                    "GROUP BY "+
                                    "  public.material.id_material, " +
                                    "  public.familia_material.fam_codigo, " +
                                    "  public.material.mat_codigo, " +
                                    "  public.material.mat_descricao, " +
                                    "  public.material.mat_descricao_adicional, " +
                                    //"  public.material.mat_medida, " +
                                    //"  public.material.mat_medida_largura, " +
                                    //"  public.material.mat_medida_comprimento, " +
                                    "  public.unidade_medida.unm_abreviada, " +
                                    "  public.material.mat_politica_estoque "+
                                    "ORDER BY " +
                                    "  mat_descricao";

                IWTPostgreNpgsqlAdapter adapter2 = new IWTPostgreNpgsqlAdapter(sql2, DbConnection.Connection);
                if (adapter2 != null)
                {
                    DataSet ds = new DataSet();
                    adapter2.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbMaterial.DataSource = binding;
                    this.cmbMaterial.ValueMember = "id_material";
                    this.cmbMaterial.DisplayMember = "codigo";
                    this.cmbMaterial.autoSize = true;
                    this.cmbMaterial.Table = ds.Tables[0];
                    this.cmbMaterial.ColumnsToDisplay = new string[] { "codigo", "fam_codigo", "mat_codigo", "mat_descricao","quantidade", "mat_descricao_adicional", "unm_abreviada", "politica_estoque" };
                    this.cmbMaterial.HeadersToDisplay = new string[] { "Material", "Familia", "Identificação", "Descrição", "Quantidade", "Desc. Adic.", "Unidade", "Politica Estoque" };

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        this.rdbMaterial.Checked = false;
                        this.rdbMaterial.Enabled = false;
                        this.cmbMaterial.Enabled = false;
                    }
                }


                //Fornecedor
                string sql3 =
                    " SELECT                                                                                                                                                         " +
                    "    id_fornecedor,                                                                                                                                              " +
                    "    for_razao_social,                                                                                                                                           " +
                    "    for_nome_fantasia,                                                                                                                                          " +
                    "    for_cnpj,                                                                                                                                                   " +
                    "    for_fone1,                                                                                                                                                  " +
                    "    for_email," +
                    "    tab.ipi," +
                    "    tab.icms " +
                    "  FROM  (                                                                                                                                                       " +
                    "SELECT                                                                                                                                                          " +
                    "  public.fornecedor.id_fornecedor,                                                                                                                              " +
                    "  public.fornecedor.for_razao_social,                                                                                                                           " +
                    "  public.fornecedor.for_nome_fantasia,                                                                                                                          " +
                    "  public.fornecedor.for_cnpj,                                                                                                                                   " +
                    "  public.fornecedor.for_email,                                                                                                                                  " +
                    "  public.fornecedor.for_fone1," +
                    "  public.material_fornecedor.maf_ipi AS ipi, " +
                    "  public.material_fornecedor.maf_icms AS icms " +
                    "FROM                                                                                                                                                            " +
                    "  public.material_fornecedor                                                                                                                                    " +
                    "  INNER JOIN public.fornecedor ON (public.material_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor)                                                  " +
                    "  INNER JOIN public.material ON (public.material_fornecedor.id_material = public.material.id_material)                                                          " +
                    "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material)                                     " +
                    "  INNER JOIN public.solicitacao_compra ON (public.solicitacao_compra.id_material = public.material.id_material)                                                 " +
                    "WHERE                                                                                                                                                           " +
                    "  public.solicitacao_compra.soc_status = 1 AND                                                                                                                  " +
                    "  public.solicitacao_compra.id_ordem_compra IS NULL AND                                                                                                         " +
                    "  public.material_fornecedor.maf_ativo = 1 AND                                                                                                                  " +
                    "  (                                                                                                                                                             " +
                    "      COALESCE(public.material.id_comprador, public.familia_material.id_comprador) = " + this.idComprador + " OR                                                                       " +
                    "      COALESCE(public.material.id_comprador, public.familia_material.id_comprador) IS NULL                                                                      " +
                    "  )                                                                                                                                                             " +
                    "  UNION                                                                                                                                                         " +
                    "  SELECT                                                                                                                                                        " +
                    "    public.fornecedor.id_fornecedor,                                                                                                                            " +
                    "    public.fornecedor.for_razao_social,                                                                                                                         " +
                    "    public.fornecedor.for_nome_fantasia,                                                                                                                        " +
                    "    public.fornecedor.for_cnpj,                                                                                                                                 " +
                    "    public.fornecedor.for_email,                                                                                                                                " +
                    "    public.fornecedor.for_fone1, " +
                    "    public.produto_fornecedor.prf_ipi AS ipi, " +
                    "    public.produto_fornecedor.prf_icms AS icms " +
                    "  FROM                                                                                                                                                          " +
                    "    public.produto_fornecedor                                                                                                                                   " +
                    "    INNER JOIN public.fornecedor ON (public.produto_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor)                                                 " +
                    "    INNER JOIN public.produto ON (public.produto_fornecedor.id_produto = public.produto.id_produto)                                                             " +
                    "    INNER JOIN public.solicitacao_compra ON (public.solicitacao_compra.id_produto = public.produto.id_produto)                                                  " +
                    "    LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto)           " +
                    "  WHERE                                                                                                                                                         " +
                    "    public.solicitacao_compra.soc_status = 1 AND                                                                                                                " +
                    "    public.solicitacao_compra.id_ordem_compra IS NULL AND                                                                                                       " +
                    "    public.produto_fornecedor.prf_ativo = 1 AND                                                                                                                 " +
                    "    (                                                                                                                                                           " +
                    "        COALESCE(public.produto.id_comprador, public.classificacao_produto.id_comprador) = " + this.idComprador + "  OR                                                                " +
                    "        COALESCE(public.produto.id_comprador, public.classificacao_produto.id_comprador) IS NULL                                                                " +
                    "     )                                                                                                                                                          " +
                    "  UNION " +

                    "  SELECT                                               " +
                    "    public.fornecedor.id_fornecedor,              " +
                    "    public.fornecedor.for_razao_social,        " +
                    "    public.fornecedor.for_nome_fantasia,    " +
                    "    public.fornecedor.for_cnpj,          " +
                    "    public.fornecedor.for_email,      " +
                    "    public.fornecedor.for_fone1,   " +
                    "    public.epi_fornecedor.epf_ipi AS ipi,   " +
                    "    public.epi_fornecedor.epf_icms AS icms                                                                                                                " +
                    "  FROM                                                                                                                                                 " +
                    "    public.epi_fornecedor                                                                                                                           " +
                    "    INNER JOIN public.fornecedor ON (public.epi_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor)                                      " +
                    "    INNER JOIN public.epi ON (public.epi_fornecedor.id_epi = public.epi.id_epi)                                                               " +
                    "    INNER JOIN public.solicitacao_compra ON (public.solicitacao_compra.id_epi = public.epi.id_epi)                                                    " +
                    "  WHERE                                                                                                                                                           " +
                    "    public.solicitacao_compra.soc_status = 1 AND                                                                                                                  " +
                    "    public.solicitacao_compra.id_ordem_compra IS NULL AND                                                                                                         " +
                    "    public.epi_fornecedor.epf_ativo = 1   " +

                    "   ) as tab                                                                                                                                                     " +
                    "  ORDER BY                                                                                                                                                      " +
                    "    for_nome_fantasia;                                                                                                                                      ";


                IWTPostgreNpgsqlAdapter adapter3 = new IWTPostgreNpgsqlAdapter(sql3, DbConnection.Connection);
                if (adapter3 != null)
                {
                    DataSet ds = new DataSet();
                    adapter3.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbFornecedor.DataSource = binding;
                    this.cmbFornecedor.ValueMember = "id_fornecedor";
                    this.cmbFornecedor.DisplayMember = "for_nome_fantasia";
                    this.cmbFornecedor.autoSize = true;
                    this.cmbFornecedor.Table = ds.Tables[0];
                    this.cmbFornecedor.ColumnsToDisplay = new string[] { "for_razao_social", "for_nome_fantasia", "for_cnpj", "for_fone1", "for_email" };
                    this.cmbFornecedor.HeadersToDisplay = new string[] { "Razão", "Nome Fantasia", "CNPJ", "Fone", "Email"};

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        this.rdbFornecedor.Checked = false;
                        this.rdbFornecedor.Enabled = false;
                        this.cmbFornecedor.Enabled = false;
                    }
                }
                
                //Epi
                EpiClass search = new EpiClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<EpiClass> epis =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("epi_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                      })
                        .ConvertAll(a => (EpiClass) a)
                        .Where(b => b.CollectionSolicitacaoCompraClassEpi
                                        .Any(a => a.Status.HasValue && a.Status.Value == StatusSolicitacaoCompra.AprovadaPCP && a.OrdemCompra == null)
                        )
                        .ToList();

                this.cmbEpi.DataSource = epis;
                this.cmbEpi.DisplayMember = "Identificacao";
                this.cmbEpi.ValueMember = "ID";
                this.cmbEpi.autoSize = true;
                this.cmbEpi.Table = epis;
                this.cmbEpi.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbEpi.HeadersToDisplay = new[] { "Identificação", "Descrição" };

                if (epis.Count == 0)
                {
                    this.rdbEpi.Checked = false;
                    this.rdbEpi.Enabled = false;
                    this.cmbEpi.Enabled = false;
                }



                if (rdbProduto.Enabled)
                {
                    this.rdbProduto.Checked = true;
                }
                else
                {
                    if (rdbMaterial.Enabled)
                    {
                        this.rdbMaterial.Checked = true;
                    }
                    else
                    {
                        if (rdbFornecedor.Enabled)
                        {
                            this.rdbFornecedor.Checked = true;
                        }
                        else
                        {
                            if (rdbEpi.Enabled)
                            {
                                this.rdbEpi.Checked = true;
                            }
                            else
                            {
                                throw new Exception("Não existem solicitações de compra livres para serem adicionadas à uma OC.");
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção dos itens.\r\n" + e.Message);
            }


        }

        private void loadComboFornecedor2(string sql)
        {
            try
            {
                //Fornecedor2
                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql,this.SingleConnection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        BindingSource binding = new BindingSource();
                        binding.DataSource = ds.Tables[0];
                        this.cmbFornecedor2.DataSource = binding;
                        this.cmbFornecedor2.DisplayMember = "for_nome_fantasia";
                        this.cmbFornecedor2.ValueMember = "id_fornecedor";
                        this.cmbFornecedor2.autoSize = true;
                        this.cmbFornecedor2.Table = ds.Tables[0];
                        this.cmbFornecedor2.ColumnsToDisplay = new string[] { "for_razao_social", "for_nome_fantasia", "for_cnpj", "cid_nome", "ultimo_preco", "ultima_compra", "unm_abreviada", "unidades_unidade_compra", "ipi", "icms" };
                        this.cmbFornecedor2.HeadersToDisplay = new string[] { "Razão", "Nome Fantasia", "CNPJ", "Cidade", "Ultimo Preço", "Data Última Compra", "Unidade Compra", "Qtd Por Un Compra", "IPI", "ICMS" };
                    }
                    else
                    {
                        throw new Exception("O item não possui fornecedor cadastrado.");
                    }

                }

                if (!rdbFornecedor.Checked)
                {
                    this.fornecPrecoList = new Dictionary<string, FornecedorUnidadePrecoClass>();
                    IWTPostgreNpgsqlCommand cmd = DbConnection.Connection.CreateCommand();
                    cmd.CommandText = sql;
                    IWTPostgreNpgsqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        double? preco = read["ultimo_preco"] as double?;
                        double? qtdPorUnidadeCompra = read["unidades_unidade_compra"] as double?;
                        string unidade= read["unm_abreviada"].ToString();
                        
                        

                        this.fornecPrecoList.Add(read["id_fornecedor"].ToString(), new FornecedorUnidadePrecoClass(
                           read["id_fornecedor"].ToString(),
                           preco,
                           qtdPorUnidadeCompra,
                           unidade));
                    }
                    read.Close();
                }

            }
            catch (Exception a)
            {
                throw;
            }
        }

        private void loadComboFormaPagto()
        {
            try
            {
                string sql =
                    "SELECT                     " +
                    "  id_forma_pagamento,      " +
                    "  fop_identificacao,       " +
                    "  fop_descricao,           " +
                    "  fop_entrada,             " +
                    "  fop_dias_entrada,        " +
                    "  fop_periodicidade,       " +
                    "  fop_quantidade_parcelas, " +
                    "  fop_ativo,               " +
                    "  fop_observacao           " +
                    "FROM                       " +
                    "  public.forma_pagamento   " +
                    "WHERE                      " +
                    "  CAST(fop_ativo as boolean) = true " +
                    "ORDER BY                   " +
                    "  fop_identificacao;       ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.SingleConnection);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource();
                binding.DataSource = ds.Tables[0];
                this.cmbFormaPagto.DataSource = binding;
                this.cmbFormaPagto.ValueMember = "id_forma_pagamento";
                this.cmbFormaPagto.DisplayMember = "fop_identificacao";
                this.cmbFormaPagto.autoSize = true;
                this.cmbFormaPagto.Table = ds.Tables[0];
                this.cmbFormaPagto.ColumnsToDisplay = new string[] { "fop_identificacao", "fop_descricao", "fop_entrada", "fop_dias_entrada", "fop_periodicidade", "fop_quantidade_parcelas", "fop_ativo", "fop_observacao" };
                this.cmbFormaPagto.HeadersToDisplay = new string[] { "Identificação", "Descrição", "Entrada", "Dias da Entrada", "Periodicidade", "Quantidade de Parcelas", "Ativo", "Observacao" };


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da conta bancária.\r\n" + e.Message);
            }
        }

        private void nextStep()
        {
            if (step1)
            {
                try
                {
                    if (rdbMaterial.Checked)
                    {
                        //MATERIAL
                        this.loadSolicitacoesMaterial();
                    }
                    else
                    {
                        if (rdbProduto.Checked)
                        {
                            //PRODUTO
                            this.loadSolicitacoesProduto();
                        }
                        else
                        {
                            if (rdbEpi.Checked)
                            {
                                //EPI
                                this.loadSolicitacoesEpi();
                            }
                            else
                            {
                                //FORNECEDOR
                                this.loadSolicitacoesFornecedor();
                            }
                        }
                    }

                    this.step1 = false;
                    this.wizardStep1.Visible = false;
                    this.wizardStep2.Visible = true;
                    this.btnNextFinish.Text = "Finalizar";
                    this.loadFormaPagamentoFornecedor();
                    this.atualizaTotal();
                }
                catch (Exception a)
                {
                    throw new Exception(a.Message);
                }
            }
            else
            {
                //Step2
                IWTPostgreNpgsqlCommand command = null;
                try
                {
                    command = DbConnection.Connection.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    this.gerarOC(ref command);
                    this.printOC(ref command);

                    command.Transaction.Commit();

                    this.Close();

                }
                catch (Exception q)
                {
                    if (command != null && command.Transaction!=null)
                    {
                       command.Transaction.Rollback();
                    }
                    throw new Exception(q.Message);
                }
            }
        }

        private void printOC(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                var envia = new EnviaOCEmailClass(
                    this.nomeEmpresa, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection
                );


                OcReportForm rep = new OcReportForm(ref command, idOc, this.logoEmpresa, envia, this.remetenteCompras);
                rep.ShowDialog();

                MessageBox.Show(this, "Processo concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception s)
            {
                throw new Exception("Erro ao imprimir OC. \r\n" + s.Message);
            }
        }

        /*
        private void gerarOC(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.cmbFornecedor2.Enabled && this.cmbFornecedor2.SelectedValue == null)
                {
                    throw new Exception("Selecione um fornecedor!");
                }

                //Calcula e confere os totais


                double valorTotal = 0;
                double valorTotalComImpostos = 0;

                List<SolicitacaoCompraClass> Solicitacoes = new List<SolicitacaoCompraClass>();

                bool umaSelecionada = false;
                int idFornecedor = (int) cmbFornecedor2.SelectedValue;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["selected"].Value.ToString() == "1")
                    {
                        SolicitacaoCompraClass sol =
                            new SolicitacaoCompraClass(Convert.ToInt32(row.Cells["id_solicitacao_compra"].Value),
                                                       null,
                                                       this._acsUsuario, this.conn);

                        Solicitacoes.Add(sol);
                        double valorUnitario = 0;
                        double aliquotaICMS = 0;
                        double aliquotaIPI = 0;

                        if (sol.Produto!=null)
                        {
                            valorUnitario= sol.Produto.Fornecedores[idFornecedor].ultimoPreco;
                            aliquotaICMS = sol.Produto.Fornecedores[idFornecedor].Icms;
                            aliquotaIPI = sol.Produto.Fornecedores[idFornecedor].Ipi;
                        }
                        else
                        {
                            if (sol.Material!=null)
                            {
                                valorUnitario = sol.Material.Fornecedores[idFornecedor].ultimoPreco;
                                aliquotaICMS = sol.Material.Fornecedores[idFornecedor].Icms;
                                aliquotaIPI = sol.Material.Fornecedores[idFornecedor].Ipi;
                                
                            }
                        }

                        valorTotal += valorUnitario*sol.Quantidade;
                        valorTotalComImpostos += (valorUnitario*sol.Quantidade)*(1 + (aliquotaIPI/100));

                        umaSelecionada = true;
                    }
                }

                if (!umaSelecionada)
                {
                    throw new Exception("Selecione pelo menos uma solicitação de compra na listagem");
                }




                command.CommandText = "INSERT INTO           " +
                                      "  public.ordem_compra " +
                                      "(                     " +
                                      "  id_fornecedor,      " +
                                      "  id_acs_usuario,    " +
                                      "  orc_valor,          " +
                                      "  orc_status,         " +
                                      "  orc_tipo, " +
                                      "  orc_data, " +
                                      "  orc_valor_com_impostos, " +
                                      "  orc_rodape, " +
                                      "  orc_msg_email, " +
                                      "  id_comprador "+
                                      ")                     " +
                                      "VALUES (              " +
                                      "  :id_fornecedor,     " +
                                      "  :id_acs_usuario,   " +
                                      "  :orc_valor,         " +
                                      "  :orc_status,         " +
                                      "  1, " +
                                      "  :orc_data,  " +
                                      "  :orc_valor_com_impostos, " +
                                      "  :orc_rodape, " +
                                      "  :orc_msg_email, " +
                                      "  :id_comprador " +
                                      ")RETURNING id_ordem_compra;";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (Int32) this.cmbFornecedor2.SelectedValue;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this._acsUsuario.Id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = valorTotalOC;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = 0;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data", DbType.DateTime));
                command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_valor_com_impostos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = valorTotalComImpostos;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_rodape", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.rodapeOC;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_msg_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.msgEmail;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idComprador;
                

                idOc = Convert.ToInt32(command.ExecuteScalar());

                int i = 1;
                foreach (SolicitacaoCompraClass solicitacao in Solicitacoes)
                {
                    solicitacao.Comprar(idOc.Value, i);
                    solicitacao.Save(ref command);
                    i++;
                }

            }
            catch (Exception w)
            {

                throw new Exception("Erro ao gerar OC.\r\n" + w.Message);
            }

        }
        */

        private void gerarOC(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                if (this.cmbFormaPagto.Enabled && this.cmbFormaPagto.SelectedValue == null)
                {
                    throw new Exception("Selecione a forma de pagamento ou desabilite o campo");
                }

                int? formaPagto = null;
                if (this.cmbFormaPagto.Enabled)
                {
                    formaPagto = Convert.ToInt32(this.cmbFormaPagto.SelectedValue);
                }
                
                OrdemCompraClass oc = new OrdemCompraClass(
                    TipoOC.OC,
                    FornecedorClass.GetEntidade((int) cmbFornecedor2.SelectedValue, LoginClass.UsuarioLogado.loggedUser, SingleConnection),
                    this.idComprador,
                    this.rodapeOC,
                    this.msgEmail,
                    DbConnection.Connection,
                    LoginClass.UsuarioLogado.loggedUser,
                    formaPagto,
                    this.txtObs.Text,
                    Convert.ToDouble(this.nudDesconto.Value));

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["selected"].Value.ToString() == "1")
                    {
                        oc.adicionarSolicitacao(Convert.ToInt32(row.Cells["id_solicitacao_compra"].Value), ref command);
                    }
                }

                oc.recalcularTotais();
                oc.Salvar(ref command);
                this.idOc = oc.Id;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar a ordem de compra\r\n" + e.Message, e);
            }
            
        }

        private void loadSolicitacoesMaterial()
        {
            string sql = "";
            string sqlForc = "";
            try
            {
                sqlForc =
                    "SELECT " +
                    " public.fornecedor.id_fornecedor, " +
                    " public.fornecedor.for_razao_social, " +
                    " public.fornecedor.for_nome_fantasia, " +
                    " public.fornecedor.for_cnpj, " +
                    " public.cidade.cid_nome, " +
                    " public.material_fornecedor.maf_ultimo_preco AS ultimo_preco, " +
                    " public.material_fornecedor.maf_data_ultima_compra AS ultima_compra, " +
                    " public.unidade_medida.unm_abreviada, " +
                    " public.material_fornecedor.maf_unidades_por_un_compra AS unidades_unidade_compra, " +
                    "  public.material_fornecedor.maf_ipi AS ipi, " +
                    "  public.material_fornecedor.maf_icms AS icms " +
                    " FROM " +
                    "  public.material_fornecedor " +
                    "  INNER JOIN public.fornecedor ON (public.material_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor) " +
                    "  LEFT JOIN unidade_medida ON material_fornecedor.id_unidade_medida_compra = unidade_medida.id_unidade_medida " +
                    "  LEFT JOIN cidade ON cidade.id_cidade = fornecedor.id_cidade " +
                    " WHERE                                                                                                          " +
                    "  material_fornecedor.id_material = " + cmbMaterial.SelectedValue +
                    "  AND material_fornecedor.maf_ativo = 1 "+
                    " ORDER BY               " +
                    "  COALESCE(public.material_fornecedor.maf_data_ultima_compra,'1900-01-01') DESC, for_nome_fantasia;    ";

                this.loadComboFornecedor2(sqlForc);

                this.label1.Visible = true;
                this.cmbFornecedor2.Visible = true;
                this.cmbFornecedor2.Enabled = true;
                this.btnOutroFornecedor.Visible = true;
                this.btnOutroFornecedor.Enabled = true;

                this.label2.Visible = true;

                sql = "SELECT                                                                                                                         " +
                       "  0 AS selected,                                                                           " +
                       "  public.solicitacao_compra.id_solicitacao_compra,                                                                           " +
                       "  familia_material.fam_codigo ||' '||public.material.mat_codigo ||' (M'|| material.id_material||')',                                                                                                 " +
                       "  public.material.mat_descricao,                                                                                             " +
                       "  public.solicitacao_compra.soc_qtd,                                                                                         " +
                       "  solicitacao_compra.soc_unidade_compra as unidade, " +                       
                       "  CASE solicitacao_compra.soc_status " +
                       "     WHEN 0 THEN 'Nova' " +
                       "     WHEN 1 THEN 'Aprovada PCP' " +
                       "     WHEN 2 THEN 'Aprovada Compras' " +
                       "     WHEN 3 THEN 'Comprada' " +
                       "     WHEN 4 THEN 'Recebida Parcial' " +
                       "     WHEN 5 THEN 'Recebida Total' " +
                       "     WHEN 6 THEN 'Cancelada' " +
                       "     ELSE '' END " +
                       "  AS status_traduzido, " +
                       "  CAST(soc_entrega_prevista AS DATE), " +
                       "  soc_data_aprovacao_pcp,                                                                                                         " +
                       "  aus_login,                                                                                                                   " +
                       "  soc_qtd_unidade_uso "+                       
                       "FROM                                                                                                                         " +
                       "  public.solicitacao_compra                                                                                                  " +
                       "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)        " +
                       "  INNER JOIN public.material ON (public.solicitacao_compra.id_material = public.material.id_material)                        " +
                       "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material)  " +
                       "WHERE                                                                                                                        " +
                       "   solicitacao_compra.id_material = " + cmbMaterial.SelectedValue + " AND soc_status = 1 "+
                       "ORDER BY " +
                       "  CAST (soc_entrega_prevista AS DATE), soc_data_aprovacao_pcp, familia_material.fam_codigo,public.material.mat_codigo ; ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;
                    dataGridView1.ReadOnly = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "", 40, DataGridViewAutoSizeColumnMode.None, false);
                    this.dataGridView1.Columns[0].ReadOnly = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "N° da\r\nSolicitação", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[1].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Material", 120, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[2].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[3].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[4].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Unidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[5].ReadOnly = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Status", 90, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[6].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Entrega", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[7].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Aprov. PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[8].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Solicitante", 70, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[9].ReadOnly = true;

                    this.dataGridView1.Columns[10].Visible = false;

                    DataGridViewColumn column = dataGridView1.Columns["selected"];
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
                    dataGridView1.Columns.Remove(tmp.Name);
                    dataGridView1.Columns.Add(tmp);
                }
            }
            catch (Exception s)
            {
                throw new Exception("Erro ao carregar solicitações do material selecionado.\r\n" + s.Message);
            }
        }

        private void loadSolicitacoesProduto()
        {
            string sql = "";
            string sqlForc = "";
            try
            {
                sqlForc =
                        "SELECT " +
                        " public.fornecedor.id_fornecedor, " +
                        " public.fornecedor.for_razao_social, " +
                        " public.fornecedor.for_nome_fantasia, " +
                        " public.fornecedor.for_cnpj, " +
                        " public.cidade.cid_nome, " +
                        " public.produto_fornecedor.prf_ultimo_preco AS ultimo_preco, " +
                        " public.produto_fornecedor.prf_data_ultima_compra AS ultima_compra, " +
                        " public.unidade_medida.unm_abreviada, " +
                        " public.produto_fornecedor.prf_unidades_por_un_compra AS unidades_unidade_compra, " +
                        " public.produto_fornecedor.prf_ipi AS ipi, " +
                        " public.produto_fornecedor.prf_icms AS icms " +      
                        " FROM " +
                            " public.produto_fornecedor " +
                            " INNER JOIN public.fornecedor ON (public.produto_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor) " +
                            "  LEFT JOIN unidade_medida ON produto_fornecedor.id_unidade_medida_compra = unidade_medida.id_unidade_medida " +
                            "  LEFT JOIN cidade ON cidade.id_cidade = fornecedor.id_cidade " +
                            " WHERE     " +
                            "  produto_fornecedor.id_produto = " + cmbProduto.SelectedValue +
                            "  AND produto_fornecedor.prf_ativo = 1 " +
                        " ORDER BY               " +
                        "  for_nome_fantasia;    ";

                this.loadComboFornecedor2(sqlForc);

                this.label1.Visible = true;
                this.cmbFornecedor2.Visible = true;
                this.cmbFornecedor2.Enabled = true;
                this.btnOutroFornecedor.Visible = true;
                this.btnOutroFornecedor.Enabled = true;

                sql = "SELECT                                                                                                                " +
                      "  0 AS selected,                                                                                                      " +
                      "  public.solicitacao_compra.id_solicitacao_compra,                                                                    " +
                      "  public.produto.pro_codigo,                                                                                          " +
                      "  public.produto.pro_descricao,                                                                                       " +
                      "  public.solicitacao_compra.soc_qtd,                                                                                  " +
                      "  solicitacao_compra.soc_unidade_compra as unidade, " +                                           
                      "  CASE solicitacao_compra.soc_status " +
                      "     WHEN 0 THEN 'Nova' " +
                      "     WHEN 1 THEN 'Aprovada PCP' " +
                      "     WHEN 2 THEN 'Aprovada Compras' " +
                      "     WHEN 3 THEN 'Comprada' " +
                      "     WHEN 4 THEN 'Recebida Parcial' " +
                      "     WHEN 5 THEN 'Recebida Total' " +
                      "     WHEN 6 THEN 'Cancelada' " +
                      "     ELSE '' END " +
                      "  AS status_traduzido, " +
                      "  CAST(soc_entrega_prevista AS DATE), " +
                      "	 soc_data_aprovacao_pcp,                                                                                                         " +
                      "	 aus_login,                                                                                                                   " +
                      "  soc_qtd_unidade_uso " +
                      "FROM                                                                                                                  " +
                      "  public.solicitacao_compra                                                                                           " +
                      "  INNER JOIN public.produto ON (public.solicitacao_compra.id_produto = public.produto.id_produto)                     " +
                      "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                      "WHERE                                                                                                                 " +
                      "  solicitacao_compra.id_produto = " + cmbProduto.SelectedValue + " AND soc_status = 1 " +
                      "ORDER BY " +
                      "  CAST (soc_entrega_prevista AS DATE), soc_data_aprovacao_pcp, pro_codigo; ";
                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;
                    dataGridView1.ReadOnly = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "", 40, DataGridViewAutoSizeColumnMode.None, false);
                    this.dataGridView1.Columns[0].ReadOnly = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "N° da\r\nSolicitação", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[1].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Cód. Produto", 120, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[2].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[3].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[4].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Unidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[5].ReadOnly = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Status", 90, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[6].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Entrega", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[7].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Aprov. PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[8].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Solicitante", 70, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[9].ReadOnly = true;
                    
                    this.dataGridView1.Columns[10].Visible = false;


                    DataGridViewColumn column = dataGridView1.Columns["selected"];
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
                    dataGridView1.Columns.Remove(tmp.Name);
                    dataGridView1.Columns.Add(tmp);
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar solicitações do produto selecionado.\r\n" + a.Message);
            }
        }

        private void loadSolicitacoesFornecedor()
        {
            string sql = "";
            string sqlForc = "";
            try
            {
                sqlForc = "SELECT " +
                          " public.fornecedor.id_fornecedor, " +
                          " public.fornecedor.for_razao_social, " +
                          " public.fornecedor.for_nome_fantasia, " +
                          " public.fornecedor.for_cnpj, " +
                          " public.cidade.cid_nome, " +
                          " '' AS ipi, " +
                          " '' AS icms " +
                          " FROM " +
                          " public.fornecedor " +
                          "  LEFT JOIN cidade ON cidade.id_cidade = fornecedor.id_cidade " +
                          " ORDER BY               " +
                          "  for_nome_fantasia;    ";

                this.loadComboFornecedor2(sqlForc);
                this.label1.Visible = true;
                this.cmbFornecedor2.Visible = true;
                this.cmbFornecedor2.SelectedValue = cmbFornecedor.SelectedValue;
                this.cmbFornecedor2.Enabled = false;

                this.btnOutroFornecedor.Visible = false;
                this.btnOutroFornecedor.Enabled = false;


                sql = "SELECT                                                                                                                      " +
                        "	selected,                                                                                                                      " +
                        "	tipo,                                                                                                                  " +
                        "	id_solicitacao_compra,                                                                                                     " +
                        "	codigo,                                                                                                                    " +
                        "	descricao,                                                                                                                 " +
                        "	qtd,                                                                                                                   " +
                        "   unidade_compra, "+
                        "  CASE soc_status " +
                        "     WHEN 0 THEN 'Nova' " +
                        "     WHEN 1 THEN 'Aprovada PCP' " +
                        "     WHEN 2 THEN 'Aprovada Compras' " +
                        "     WHEN 3 THEN 'Comprada' " +
                        "     WHEN 4 THEN 'Recebida Parcial' " +
                        "     WHEN 5 THEN 'Recebida Total' " +
                        "     WHEN 6 THEN 'Cancelada' " +
                        "     ELSE '' END " +
                        "   AS status_traduzido, " +
                        "   CAST(soc_entrega_prevista AS DATE), " +
                        "	soc_data_aprovacao_pcp,                                                                                                         " +
                        "	aus_login,                                                                                                                   " +
                        "	ultimo_preco,                                                                                                                   " +
                        "   ultima_compra, "+
                        "   id_fornecedor_menor_preco, " +
                        "   fornecedor_menor_preco, " +
                        "   menor_preco, " +
                        "   soc_qtd_unidade_uso, " +
                        "   ipi, " +
                        "   icms " +
                        "FROM (                                                                                                                      " +
                        "SELECT                                                                                                                      " +
                        "  'MATERIAL' AS tipo,                                                                                                       " +
                        "  0 AS selected,                                                                                                            " +
                        "  public.solicitacao_compra.id_solicitacao_compra,                                                                          " +
                        "  familia_material.fam_codigo ||' '||public.material.mat_codigo ||' (M'|| material.id_material||')' AS codigo,                                                                                     " +
                        "  public.material.mat_descricao AS descricao,                                                                               " +
                        "  CASE WHEN material_fornecedor.id_unidade_medida_compra IS NULL THEN  " +
                        "  	 public.solicitacao_compra.soc_qtd "+
                        "  ELSE "+
                        "    public.solicitacao_compra.soc_qtd_unidade_uso/material_fornecedor.maf_unidades_por_un_compra "+
                        "  END as qtd,                                                             "+                             
                        "  CASE WHEN material_fornecedor.id_unidade_medida_compra IS NULL THEN  "+
                        "  	 public.solicitacao_compra.soc_unidade_compra "+
                        "  ELSE "+
                        "	 public.unidade_medida.unm_abreviada "+
                        "  END as unidade_compra, "+
                        "  public.solicitacao_compra.soc_data_aprovacao_pcp,                                                                              " +
                        "  public.solicitacao_compra.soc_entrega_prevista, " +
                        "  public.solicitacao_compra.soc_saldo_recebimento,                                                                          " +
                        "  public.acs_usuario.aus_login,                                                                                             " +
                        "  public.material_fornecedor.maf_ultimo_preco AS ultimo_preco,                                                                               " +
                        "  public.fornecedor.id_fornecedor,                                                                                           " +
                        "  public.solicitacao_compra.soc_status,                                                                                          " +
                        "  public.material_fornecedor.maf_data_ultima_compra AS ultima_compra, " +
                        "  public.material_menor_preco.id_fornecedor_menor_preco, "+
                        "  public.material_menor_preco.fornecedor_menor_preco, " +
                        "  public.material_menor_preco.menor_preco, " +
                        "  soc_qtd_unidade_uso, " +
                        "  public.material_fornecedor.maf_ipi AS ipi, " +
                        "  public.material_fornecedor.maf_icms AS icms " +
                        "FROM                                                                                                                        " +
                        "  public.solicitacao_compra                                                                                                 " +
                        "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)       " +
                        "  INNER JOIN public.material ON (public.solicitacao_compra.id_material = public.material.id_material)                       " +
                        "  INNER JOIN public.material_fornecedor ON (public.solicitacao_compra.id_material = public.material_fornecedor.id_material) " +
                        "  INNER JOIN public.fornecedor ON (public.fornecedor.id_fornecedor = public.material_fornecedor.id_fornecedor)              " +
                        "  LEFT JOIN familia_material ON familia_material.id_familia_material = material.id_familia_material "+
                        "  LEFT JOIN material_menor_preco ON material.id_material = material_menor_preco.id_material "+
                        "  LEFT JOIN unidade_medida ON (unidade_medida.id_unidade_medida = material_fornecedor.id_unidade_medida_compra)           " +
                        "WHERE material_fornecedor.maf_ativo = 1 "+
                        "  UNION ALL                                                                                                                     " +
                        "                                                                                                                            " +
                        " SELECT                                                                                                                     " +
                        "  'PRODUTO' AS tipo,                                                                                                        " +
                        "  0 AS selected,                                                                                                            " +
                        "  public.solicitacao_compra.id_solicitacao_compra,                                                                          " +
                        "  public.produto.pro_codigo AS codigo,                                                                                      " +
                        "  public.produto.pro_descricao AS descricao,                                                                                " +
                        "  CASE WHEN produto_fornecedor.id_unidade_medida_compra IS NULL THEN  " +
                        "  	 public.solicitacao_compra.soc_qtd " +
                        "  ELSE " +
                        "    public.solicitacao_compra.soc_qtd_unidade_uso/produto_fornecedor.prf_unidades_por_un_compra " +
                        "  END as qtd,                                                             " +
                        "  CASE WHEN produto_fornecedor.id_unidade_medida_compra IS NULL THEN  " +
                        "  	 public.solicitacao_compra.soc_unidade_compra " +
                        "  ELSE " +
                        "	 public.unidade_medida.unm_abreviada " +
                        "  END as unidade_compra, " +
                        "  public.solicitacao_compra.soc_data_aprovacao_pcp,                                                                              " +
                        "  public.solicitacao_compra.soc_entrega_prevista, "+
                        "  public.solicitacao_compra.soc_saldo_recebimento,                                                                          " +
                        "  public.acs_usuario.aus_login,                                                                                             " +
                        "  public.produto_fornecedor.prf_ultimo_preco AS ultimo_preco,                                                                               " +
                        "  public.fornecedor.id_fornecedor,                                                                                           " +
                        "  public.solicitacao_compra.soc_status,                                                                                           " +
                        "  public.produto_fornecedor.prf_data_ultima_compra AS ultima_compra, " +
                        "  public.produto_menor_preco.id_fornecedor_menor_preco, " +
                        "  public.produto_menor_preco.fornecedor_menor_preco, " +
                        "  public.produto_menor_preco.menor_preco, " +
                        "  soc_qtd_unidade_uso, " +
                        "  public.produto_fornecedor.prf_ipi AS ipi, " +
                        "  public.produto_fornecedor.prf_icms AS icms " +              
                        "FROM                                                                                                                        " +
                        "  public.solicitacao_compra                                                                                                 " +
                        "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)       " +
                        "  INNER JOIN public.produto ON (public.solicitacao_compra.id_produto = public.produto.id_produto)                           " +
                        "  INNER JOIN public.produto_fornecedor ON (public.solicitacao_compra.id_produto = public.produto_fornecedor.id_produto)     " +
                        "  INNER JOIN public.fornecedor ON (public.fornecedor.id_fornecedor = public.produto_fornecedor.id_fornecedor)               " +
                        "  LEFT JOIN produto_menor_preco ON produto.id_produto = produto_menor_preco.id_produto " +
                        "  LEFT JOIN unidade_medida ON (unidade_medida.id_unidade_medida = produto_fornecedor.id_unidade_medida_compra)           " +
                        "WHERE produto_fornecedor.prf_ativo = 1 " +
                        " UNION ALL " +
                        "                                                                                                                          " +
                        "SELECT                                                                                                                      " +
                        "  'EPI' AS tipo,                                                                                                       " +
                        "  0 AS selected,                                                                                                            " +
                        "  public.solicitacao_compra.id_solicitacao_compra,                                                                          " +
                        "  public.epi.epi_identificacao AS codigo,                                                                                     " +
                        "  public.epi.epi_descricao AS descricao,                                                                               " +
                        "  CASE WHEN epi_fornecedor.id_unidade_medida_compra IS NULL THEN  " +
                        "  	 public.solicitacao_compra.soc_qtd " +
                        "  ELSE " +
                        "    public.solicitacao_compra.soc_qtd_unidade_uso/epi_fornecedor.epf_unidades_por_un_compra " +
                        "  END as qtd,                                                             " +
                        "  CASE WHEN epi_fornecedor.id_unidade_medida_compra IS NULL THEN  " +
                        "  	 public.solicitacao_compra.soc_unidade_compra " +
                        "  ELSE " +
                        "	 public.unidade_medida.unm_abreviada " +
                        "  END as unidade_compra, " +
                        "  public.solicitacao_compra.soc_data_aprovacao_pcp,                                                                              " +
                        "  public.solicitacao_compra.soc_entrega_prevista, " +
                        "  public.solicitacao_compra.soc_saldo_recebimento,                                                                          " +
                        "  public.acs_usuario.aus_login,                                                                                             " +
                        "  public.epi_fornecedor.epf_ultimo_preco AS ultimo_preco,                                                                               " +
                        "  public.fornecedor.id_fornecedor,                                                                                           " +
                        "  public.solicitacao_compra.soc_status,                                                                                          " +
                        "  public.epi_fornecedor.epf_data_ultima_compra AS ultima_compra, " +
                        "  public.epi_menor_preco.id_fornecedor_menor_preco, " +
                        "  public.epi_menor_preco.fornecedor_menor_preco, " +
                        "  public.epi_menor_preco.menor_preco, " +
                        "  soc_qtd_unidade_uso, " +
                        "  public.epi_fornecedor.epf_ipi AS ipi, " +
                        "  public.epi_fornecedor.epf_icms AS icms " +
                        "FROM                                                                                                                        " +
                        "  public.solicitacao_compra                                                                                                 " +
                        "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario)       " +
                        "  INNER JOIN public.epi ON (public.solicitacao_compra.id_epi = public.epi.id_epi)                       " +
                        "  INNER JOIN public.epi_fornecedor ON (public.solicitacao_compra.id_epi = public.epi_fornecedor.id_epi) " +
                        "  INNER JOIN public.fornecedor ON (public.fornecedor.id_fornecedor = public.epi_fornecedor.id_fornecedor)              " +
                        "  LEFT JOIN epi_menor_preco ON epi.id_epi = epi_menor_preco.id_epi " +
                        "  LEFT JOIN unidade_medida ON (unidade_medida.id_unidade_medida = epi_fornecedor.id_unidade_medida_compra)           " +
                        "WHERE epi_fornecedor.epf_ativo = 1 " +
                        "  ) AS tab                                                                                                                  " +
                        "WHERE                                                                                                                       " +
                        "  id_fornecedor =  " + cmbFornecedor.SelectedValue + " AND soc_status = 1                                       " +
                        "ORDER BY                                                                                                                    " +
                        "  CAST (soc_entrega_prevista AS DATE), soc_data_aprovacao_pcp, tipo, codigo;                                                                                          ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;
                    dataGridView1.ReadOnly = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "", 40, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[0].ReadOnly = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Tipo", 90, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[1].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "N° da\r\nSolicitação", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[2].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Código", 120, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[3].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[4].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[5].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Unidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[6].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Status", 90, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[7].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Entrega", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[8].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Aprov. PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[9].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Solicitante", 70, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[10].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Último Preço", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[11].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Data última Compra", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[12].ReadOnly = true;
                    this.dataGridView1.Columns[13].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[14], "Melhor Fornecedor", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[14].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[15], "Melhor Preço", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[15].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[16], "Quantidade Unid. Uso", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[16].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[17], "IPI", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[17].ReadOnly = true;
                    this.dataGridView1.Columns[17].DefaultCellStyle.Format = "0.00\\%";
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[18], "ICMS", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[18].ReadOnly = true;
                    this.dataGridView1.Columns[18].DefaultCellStyle.Format = "0.00\\%";
                    this.dataGridView1.Columns[13].Visible = false;

                    DataGridViewColumn column = dataGridView1.Columns["selected"];
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

                    dataGridView1.Columns.Remove(tmp.Name);
                    dataGridView1.Columns.Add(tmp);
                }
            }
            catch (Exception x)
            {
                throw new Exception("Erro ao carregar solicitações do fornecedor selecionado.\r\n" + x.Message);
            }
        }

        private void loadSolicitacoesEpi()
        {
            string sql = "";
            string sqlForc = "";
            try
            {
                if (cmbEpi.SelectedItem == null) throw new Exception("Selecione um Epi.");
                
                sqlForc =
                                       "SELECT " +
                                        " public.fornecedor.id_fornecedor, " +
                                        " public.fornecedor.for_razao_social, " +
                                        " public.fornecedor.for_nome_fantasia, " +
                                        " public.fornecedor.for_cnpj, " +
                                        " public.cidade.cid_nome, " +
                                        " public.epi_fornecedor.epf_ultimo_preco AS ultimo_preco, " +
                                        " public.epi_fornecedor.epf_data_ultima_compra AS ultima_compra, " +
                                        " public.unidade_medida.unm_abreviada, " +
                                        " public.epi_fornecedor.epf_unidades_por_un_compra AS unidades_unidade_compra, " +
                                        " public.epi_fornecedor.epf_ipi AS ipi, " +
                                        " public.epi_fornecedor.epf_icms AS icms " +
                                       " FROM " +
                                         " public.epi_fornecedor " +
                                         " INNER JOIN public.fornecedor ON (public.epi_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor) " +
                                         "  LEFT JOIN unidade_medida ON epi_fornecedor.id_unidade_medida_compra = unidade_medida.id_unidade_medida " +
                                         "  LEFT JOIN cidade ON cidade.id_cidade = fornecedor.id_cidade " +
                                       " WHERE                                                                                                                 " +
                                          "  epi_fornecedor.id_epi = " + ((EpiClass)cmbEpi.SelectedItem).ID +
                                       " ORDER BY               " +
                                       "  for_nome_fantasia;    ";

                this.loadComboFornecedor2(sqlForc);

                this.label1.Visible = true;
                this.cmbFornecedor2.Visible = true;
                this.cmbFornecedor2.Enabled = true;
                this.btnOutroFornecedor.Visible = true;
                this.btnOutroFornecedor.Enabled = true;

                sql = "SELECT                                                                                                                " +
                      "  0 AS selected,                                                                                                      " +
                      "  public.solicitacao_compra.id_solicitacao_compra,                                                                    " +
                      "  public.epi.epi_identificacao,                                                                                          " +
                      "  public.epi.epi_descricao,                                                                                       " +
                      "  public.solicitacao_compra.soc_qtd,                                                                                  " +
                      "  solicitacao_compra.soc_unidade_compra as unidade, " +
                      "  CASE solicitacao_compra.soc_status " +
                      "     WHEN 0 THEN 'Nova' " +
                      "     WHEN 1 THEN 'Aprovada PCP' " +
                      "     WHEN 2 THEN 'Aprovada Compras' " +
                      "     WHEN 3 THEN 'Comprada' " +
                      "     WHEN 4 THEN 'Recebida Parcial' " +
                      "     WHEN 5 THEN 'Recebida Total' " +
                      "     WHEN 6 THEN 'Cancelada' " +
                      "     ELSE '' END " +
                      "  AS status_traduzido, " +
                      "  CAST(soc_entrega_prevista AS DATE), " +
                      "	 soc_data_aprovacao_pcp,                                                                                                         " +
                      "	 aus_login,                                                                                                                   " +
                      "  soc_qtd_unidade_uso " +
                      "FROM                                                                                                                  " +
                      "  public.solicitacao_compra                                                                                           " +
                      "  INNER JOIN public.epi ON (public.solicitacao_compra.id_epi = public.epi.id_epi)                     " +
                      "  INNER JOIN public.acs_usuario ON (public.solicitacao_compra.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                      "WHERE                                                                                                                 " +
                      "  solicitacao_compra.id_epi = " + ((EpiClass)cmbEpi.SelectedItem).ID + " AND soc_status = 1 " +
                      "ORDER BY " +
                      "  CAST (soc_entrega_prevista AS DATE), soc_data_aprovacao_pcp, epi_identificacao; ";
                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;
                    dataGridView1.ReadOnly = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "", 40, DataGridViewAutoSizeColumnMode.None, false);
                    this.dataGridView1.Columns[0].ReadOnly = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "N° da\r\nSolicitação", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[1].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Identificação", 120, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[2].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[3].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[4].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Unidade", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[5].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Status", 90, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[6].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Entrega", 80, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[7].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Aprov. PCP", 100, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[8].ReadOnly = true;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Solicitante", 70, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[9].ReadOnly = true;

                    this.dataGridView1.Columns[10].Visible = false;


                    DataGridViewColumn column = dataGridView1.Columns["selected"];
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
                    dataGridView1.Columns.Remove(tmp.Name);
                    dataGridView1.Columns.Add(tmp);
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar solicitações do Epi selecionado.\r\n" + a.Message);
            }
        }

        private void atualizaTotal()
        {
            try
            {
                this.dataGridView1.EndEdit();

                this.valorTotalOC = 0;
                double valorUnit = 0;
                double? qtdPorUnidadeUso = null;
                if (!rdbFornecedor.Checked)
                {
                    if (this.cmbFornecedor2.SelectedValue == null)
                    {
                        return;
                    }
                    valorUnit = fornecPrecoList[this.cmbFornecedor2.SelectedValue.ToString()].Preco;
                    qtdPorUnidadeUso =
                        fornecPrecoList[this.cmbFornecedor2.SelectedValue.ToString()].QtdUnidadeUsoPorUnidadeCompra;
                }

                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    
                    if (Convert.ToBoolean((int)row.Cells[0].Value))
                    {
                        double qtd = 0;
                        if (rdbFornecedor.Checked)
                        {
                            valorUnit = Convert.ToDouble(row.Cells["ultimo_preco"].Value);
                            qtd = Convert.ToDouble(row.Cells["qtd"].Value);
                        }
                        else
                        {
                            if (qtdPorUnidadeUso.HasValue)
                            {
                                qtd = Convert.ToDouble(row.Cells["soc_qtd_unidade_uso"].Value)/qtdPorUnidadeUso.Value;
                            }
                            else
                            {
                                qtd = Convert.ToDouble(row.Cells["soc_qtd"].Value);
                            }
                        }


                        this.valorTotalOC += qtd * valorUnit;
                    }
                }

                if (this.nudDesconto.Value>0)
                {
                    this.valorTotalOC = Math.Round(this.valorTotalOC*(1-(Convert.ToDouble(this.nudDesconto.Value)/100)), 2, MidpointRounding.AwayFromZero);
                }


                this.label2.Visible = true;
                this.label2.Text = "TOTAL: " + valorTotalOC.ToString("C2", CultureInfo.CurrentCulture) + " ";


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar o total.\r\n" + e.Message);
            }
        }

        private void outroFornecedor()
        {
            try
            {
                if (this.cmbMaterial.Enabled)
                {
                    int idMaterial = Convert.ToInt32(cmbMaterial.SelectedValue);
                    MaterialClass mat = MaterialBaseClass.GetEntidade(idMaterial, LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    CadMaterialForm form = new CadMaterialForm(mat);
                    form.ModoMasterDetail = false;
                    form.ShowDialog();
                    this.loadSolicitacoesMaterial();
                }
                else
                {
                    if (this.cmbProduto.Enabled)
                    {
                        int idProduto = Convert.ToInt32(cmbProduto.SelectedValue);
                        ProdutoClass pro = ProdutoBaseClass.GetEntidade(idProduto, LoginClass.UsuarioLogado.loggedUser, DbConnection.Connection);
                        CadProdutoPCPForm form = new CadProdutoPCPForm(pro);
                        form.ModoMasterDetail = false;

                        form.ShowDialog();
                        this.loadSolicitacoesProduto();

                    }
                    else
                    {
                        throw new Exception("Função Inválida.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar outro fornecedor.\r\n" + e.Message, e);
            }
        }

        private void loadFormaPagamentoFornecedor()
        {
            try
            {
                if (this.formaPagamentoFornecedorList == null)
                {
                    IWTPostgreNpgsqlCommand cmd = DbConnection.Connection.CreateCommand();
                    cmd.CommandText = "SELECT                                                                                     " +
                                        "  public.fornecedor.id_fornecedor,                                                         " +
                                        "  public.forma_pagamento.id_forma_pagamento                                                " +
                                        "FROM                                                                                       " +
                                        "  public.fornecedor                                                                        " +
                                        "  INNER JOIN public.forma_pagamento                                                        " +
                                        "	  ON (public.fornecedor.id_forma_pagamento = public.forma_pagamento.id_forma_pagamento) ";
                    IWTPostgreNpgsqlDataReader read = cmd.ExecuteReader();

                    this.formaPagamentoFornecedorList = new Dictionary<int, int>();
                    while (read.Read())
                    {
                        this.formaPagamentoFornecedorList.Add(Convert.ToInt32(read["id_fornecedor"]), Convert.ToInt32(read["id_forma_pagamento"]));
                    }
                }


                if (this.cmbFornecedor2.SelectedValue != null)
                {
                    int idFornec = Convert.ToInt32(this.cmbFornecedor2.SelectedValue);
                    if (this.formaPagamentoFornecedorList.ContainsKey(idFornec))
                    {
                        this.cmbFormaPagto.SelectedValue = this.formaPagamentoFornecedorList[idFornec];
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao carregar forma de pagamento do fornecedor.\r\n " +  a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Eventos

        private void btnNextFinish_Click(object sender, EventArgs e)
        {
            try
            {
                this.nextStep();
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbProduto.Enabled = rdbProduto.Checked;
            this.cmbMaterial.Enabled = rdbMaterial.Checked;
            this.cmbFornecedor.Enabled = rdbFornecedor.Checked;
            this.cmbEpi.Enabled = rdbEpi.Checked;
        }

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbProduto.Enabled = rdbProduto.Checked;
            this.cmbMaterial.Enabled = rdbMaterial.Checked;
            this.cmbFornecedor.Enabled = rdbFornecedor.Checked;
            this.cmbEpi.Enabled = rdbEpi.Checked;
        }

        private void rdbFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbProduto.Enabled = rdbProduto.Checked;
            this.cmbMaterial.Enabled = rdbMaterial.Checked;
            this.cmbFornecedor.Enabled = rdbFornecedor.Checked;
            this.cmbEpi.Enabled = rdbEpi.Checked;
        }

        private void rdbEpi_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbProduto.Enabled = rdbProduto.Checked;
            this.cmbMaterial.Enabled = rdbMaterial.Checked;
            this.cmbFornecedor.Enabled = rdbFornecedor.Checked;
            this.cmbEpi.Enabled = rdbEpi.Checked;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    this.atualizaTotal();
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cmbFornecedor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTotal();
                this.loadFormaPagamentoFornecedor();
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnOutroFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                this.outroFornecedor();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Columns[e.ColumnIndex].Name == "menor_preco")
                {
                    if (this.dataGridView1["menor_preco", e.RowIndex].Value != null &&
                        this.dataGridView1["ultimo_preco", e.RowIndex].Value != null
                        )
                    {

                        double menorPreco = Convert.ToDouble(this.dataGridView1["menor_preco", e.RowIndex].Value);
                        double ultimoPreco = Convert.ToDouble(this.dataGridView1["ultimo_preco", e.RowIndex].Value);

                        if (ultimoPreco > menorPreco)
                        {

                            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                            {
                                cell.Style.BackColor = Color.Red;
                            }
                        }
                        else
                        {
                            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                            {
                                cell.Style.BackColor = Color.White;
                            }
                        }
                    }
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkFormaPagto_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbFormaPagto.Enabled = this.chkFormaPagto.Checked;
        }


        private void nudDesconto_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.atualizaTotal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #endregion

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    this.atualizaTotal();
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

       

    }

       



      

        
    }
