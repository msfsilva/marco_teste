using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque;
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;

namespace BibliotecaEntidades.Entidades
{
    public class EstoqueGavetaItemClass : EstoqueGavetaItemBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do EstoqueGavetaItemClass";
        protected new const string ErroDelete = "Erro ao excluir o EstoqueGavetaItemClass  ";
        protected new const string ErroSave = "Erro ao salvar o EstoqueGavetaItemClass.";
        protected new const string ErroCollectionEstoqueMovimentacaoClassEstoqueGavetaItem = "Erro ao carregar a coleção de EstoqueMovimentacaoClass.";
        protected new const string ErroCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem = "Erro ao carregar a coleção de OrdemProducaoEstoqueClass.";
        protected new const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
        protected new const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
        protected new const string ErroEstoqueObrigatorio = "O campo Estoque é obrigatório";
        protected new const string ErroEstoqueCorredorObrigatorio = "O campo EstoqueCorredor é obrigatório";
        protected new const string ErroEstoquePrateleiraObrigatorio = "O campo EstoquePrateleira é obrigatório";
        protected new const string ErroEstoqueGavetaObrigatorio = "O campo EstoqueGaveta é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do EstoqueGavetaItemClass.";
        protected new const string MensagemUtilizadoCollectionEstoqueMovimentacaoClassEstoqueGavetaItem = "A entidade EstoqueGavetaItemClass está sendo utilizada nos seguintes EstoqueMovimentacaoClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoEstoqueClassEstoqueGavetaItem = "A entidade EstoqueGavetaItemClass está sendo utilizada nos seguintes OrdemProducaoEstoqueClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade EstoqueGavetaItemClass está sendo utilizada.";

        #endregion

 

        public EstoqueGavetaItemClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
        }

        public override bool Ativo
        {
            get { return base.Ativo; }
            set
            {
                if (value == Ativo) return;
                if (!value)
                {
                    //Desativando Gaveta
                    if (Math.Abs(this.Quantidade) > 0.00001)
                    {
                        throw new ExcecaoTratada("Não é possível desativar a gaveta " + this.EstoqueGaveta.GetLocalizacaoCompleta() + " pois ela possui itens com quantidade diferente de zero.");
                    }
                }

                base.Ativo = value;

            }
        }

        public override string ToString()
        {
            return IdentificacaoCompleta + " - " + CodigoItem;
        }

        public string IdentificacaoCompleta
        {
            get { return this.EstoqueGaveta.GetLocalizacaoCompleta(); }
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "TipoConsumo":
                    if (parametro.Fieldvalue is EASITipoAlocacaoEstoque)
                    {
                     
                        whereClause += " AND  (tipoconsumoestoque.est_tipo_alocacao_estoque = :TipoConsumo) ";

                        command.CommandText +=
                            "  INNER JOIN public.estoque_gaveta tipoconsumoestoque_gaveta ON (estoque_gaveta_item.id_estoque_gaveta = tipoconsumoestoque_gaveta.id_estoque_gaveta) " +
                            "  INNER JOIN public.estoque_prateleira tipoconsumoestoque_prateleira ON(tipoconsumoestoque_gaveta.id_estoque_prateleira = tipoconsumoestoque_prateleira.id_estoque_prateleira) " +
                            "  INNER JOIN public.estoque_corredor tipoconsumoestoque_corredor ON(tipoconsumoestoque_prateleira.id_estoque_corredor = tipoconsumoestoque_corredor.id_estoque_corredor) " +
                            "  INNER JOIN public.estoque tipoconsumoestoque ON(tipoconsumoestoque_corredor.id_estoque = tipoconsumoestoque.id_estoque) ";

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("TipoConsumo", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                    }
                    else
                    {
                        throw new Exception("Tipo de dados inválido, esperado EASITipoAlocacaoEstoque");
                    }
                    return true;
                case "IdentificacaoCompleta":
                        whereClause += " AND  (identificacaocompletasearch_estoque.est_identificacao || ' - ' || identificacaocompletasearch_estoque_corredor.esc_identificacao||' - ' || identificacaocompletasearch_estoque_prateleira.esp_identificacao||' - ' || identificacaocompletasearch_estoque_gaveta.esg_identificacao ILIKE :IdentificacaoCompletaSearch) ";

                    command.CommandText +=
                        "  INNER JOIN public.estoque_gaveta identificacaocompletasearch_estoque_gaveta ON(public.estoque_gaveta_item.id_estoque_gaveta = identificacaocompletasearch_estoque_gaveta.id_estoque_gaveta) " +
                        "  INNER JOIN public.estoque_prateleira identificacaocompletasearch_estoque_prateleira ON(identificacaocompletasearch_estoque_gaveta.id_estoque_prateleira = identificacaocompletasearch_estoque_prateleira.id_estoque_prateleira) " +
                        "  INNER JOIN public.estoque_corredor identificacaocompletasearch_estoque_corredor ON(identificacaocompletasearch_estoque_prateleira.id_estoque_corredor = identificacaocompletasearch_estoque_corredor.id_estoque_corredor) " +
                        "  INNER JOIN public.estoque identificacaocompletasearch_estoque ON(identificacaocompletasearch_estoque_corredor.id_estoque = identificacaocompletasearch_estoque.id_estoque) ";

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("IdentificacaoCompletaSearch", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue + "%"));

                    return true;

                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "IdentificacaoCompleta":
                    orderByClause += " ,  identificacaocompletaorder_estoque.est_identificacao " + ordenacao.ToString() + ", identificacaocompletaorder_estoque_corredor.esc_identificacao " + ordenacao.ToString() + ", identificacaocompletaorder_estoque_prateleira.esp_identificacao " + ordenacao.ToString() + ", identificacaocompletaorder_estoque_gaveta.esg_identificacao " + ordenacao.ToString() + " ";

                    command.CommandText +=
                        "  INNER JOIN public.estoque_gaveta identificacaocompletaorder_estoque_gaveta ON(public.estoque_gaveta_item.id_estoque_gaveta = identificacaocompletaorder_estoque_gaveta.id_estoque_gaveta) " +
                        "  INNER JOIN public.estoque_prateleira identificacaocompletaorder_estoque_prateleira ON(identificacaocompletaorder_estoque_gaveta.id_estoque_prateleira = identificacaocompletaorder_estoque_prateleira.id_estoque_prateleira) " +
                        "  INNER JOIN public.estoque_corredor identificacaocompletaorder_estoque_corredor ON(identificacaocompletaorder_estoque_prateleira.id_estoque_corredor = identificacaocompletaorder_estoque_corredor.id_estoque_corredor) " +
                        "  INNER JOIN public.estoque identificacaocompletaorder_estoque ON(identificacaocompletaorder_estoque_corredor.id_estoque = identificacaocompletaorder_estoque.id_estoque) ";

                    return true;

                default:
                    return false;
            }
        }

        protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            if (!Ativo)
            {
                if (Math.Abs(Quantidade) > 0.00001)
                {
                    throw new ExcecaoTratada("Não é possível inativar um item de estoque( " + this + " ) cuja quantidade seja diferente de zero");
                }
            }

            int countConteudo = 0;
            if (Produto != null)
            {
                countConteudo++;
            }

            if (Material != null)
            {
                countConteudo++;
            }

            if (DocumentoCopia != null)
            {
                countConteudo++;
            }

            if (Recurso != null)
            {
                countConteudo++;
            }

            if (ProdutoK != null)
            {
                countConteudo++;
            }

            if (Epi != null)
            {
                countConteudo++;
            }

            if (countConteudo > 1)
            {
                throw new ExcecaoTratada("Não é possível definir para uma mesma gaveta item mais de um conteúdo");
            }

            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

  

        public string EstoqueString
        {
            get
            {
                if (this.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Estoque != null)
                {
                    return this.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Estoque.Identificacao;
                }
                else
                {
                    return "";
                }
            }
        }

        public string CorredorString
        {
            get
            {
                if (this.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor != null)
                {
                    return this.EstoqueGaveta.EstoquePrateleira.EstoqueCorredor.Identificacao;
                }
                else
                {
                    return "";
                }
            }
        }

        public string PrateleiraString
        {
            get
            {
                if (this.EstoqueGaveta.EstoquePrateleira != null)
                {
                    return this.EstoqueGaveta.EstoquePrateleira.Identificacao;
                }
                else
                {
                    return "";
                }
            }
        }

        public string GavetaString
        {
            get
            {
                if (this.EstoqueGaveta != null)
                {
                    return this.EstoqueGaveta.Identificacao;
                }
                else
                {
                    return "";
                }
                ;
            }
        }

        public string LocalizacaoCompleta
        {
            get { return EstoqueGaveta.GetLocalizacaoCompleta(); }
        }

        #region Propriedades do Conteudo

   
        public TipoConteudoEstoque TipoConteudo
        {
            get
            {
            

                if (Produto != null)
                {
                    return TipoConteudoEstoque.Produto;
                }

                if (Material != null)
                {
                    return TipoConteudoEstoque.Material;
                }

                if (Epi != null)
                {
                    return TipoConteudoEstoque.Epi;
                }

                if (DocumentoCopia != null)
                {
                    return TipoConteudoEstoque.Documento;
                }

                if (Recurso != null)
                {
                    return TipoConteudoEstoque.Recurso;
                }

                if (ProdutoK != null)
                {
                    return TipoConteudoEstoque.AgrupadorProdutoSemelhante;
                }

                return TipoConteudoEstoque.SemConteudo;
            }
           
        }

        public string TipoConteudoTela
        {
            get
            {
                switch (TipoConteudo)
                {
                    case TipoConteudoEstoque.Produto:
                    case TipoConteudoEstoque.Material:
                    case TipoConteudoEstoque.Documento:
                    case TipoConteudoEstoque.Recurso:
                    case TipoConteudoEstoque.Epi:
                        return TipoConteudo.ToString();
                        break;
                    case TipoConteudoEstoque.AgrupadorProdutoSemelhante:
                        return "Agrupador de Itens Semelhantes";
                        break;
                    case TipoConteudoEstoque.SemConteudo:
                        return "Sem Conteúdo";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string CodigoItem
        {
            get
            {
                switch (TipoConteudo)
                {
                    case TipoConteudoEstoque.Produto:
                        return Produto.Codigo;
                    case TipoConteudoEstoque.Material:
                        return Material.IdentificacaoCompleta;

                    case TipoConteudoEstoque.Documento:
                        return this.DocumentoCopia.IdentificacaoCompleta;

                    case TipoConteudoEstoque.Recurso:
                        return Recurso.IdentificacaoCompleta;

                    case TipoConteudoEstoque.Epi:
                        return Epi.Identificacao;

                    case TipoConteudoEstoque.AgrupadorProdutoSemelhante:
                        return ProdutoK.Codigo;

                    case TipoConteudoEstoque.SemConteudo:
                        return "";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string DescricaoItem
        {
            get
            {
                switch (TipoConteudo)
                {
                    case TipoConteudoEstoque.Produto:
                        return Produto.Descricao;
                    case TipoConteudoEstoque.Material:
                        return Material.Descricao;

                    case TipoConteudoEstoque.Documento:
                        return this.DocumentoCopia.Identificacao;

                    case TipoConteudoEstoque.Recurso:
                        return Recurso.Nome;

                    case TipoConteudoEstoque.Epi:
                        return Epi.Descricao;

                    case TipoConteudoEstoque.AgrupadorProdutoSemelhante:
                        return ProdutoK.Descricao;

                    case TipoConteudoEstoque.SemConteudo:
                        return "";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

       
        public string UnidadeItem
        {
            get
            {
                switch (TipoConteudo)
                {
                    case TipoConteudoEstoque.Produto:
                        return Produto.UnidadeMedida != null ? Produto.UnidadeMedida.ToString() : "";
                    case TipoConteudoEstoque.Material:
                        return Material.UnidadeMedida != null ? Material.UnidadeMedida.ToString() : "";

                    case TipoConteudoEstoque.Epi:
                        return Epi.UnidadeMedidaUso != null ? Epi.UnidadeMedidaUso.ToString() : "";

                    case TipoConteudoEstoque.Documento:
                    case TipoConteudoEstoque.Recurso:
                        return "UN";

                    case TipoConteudoEstoque.AgrupadorProdutoSemelhante:
                    case TipoConteudoEstoque.SemConteudo:
                        return "";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
        #endregion

        #region Valores

        private bool _valorUnitarioCarregado = false;
        private double _valorUnitario;

        public double ValorUnitario
        {
            get
            {
                if (!this._valorUnitarioCarregado)
                {
                    this.LoadValorUnitario();
                }

                return this._valorUnitario;
            }
        }

        public double ValorTotal
        {
            get
            {
                return this.ValorUnitario * this.Quantidade;
            }
        }

    

        #endregion

        #region Funções de Carregamento dos valores (Lazy)
        private void LoadValorUnitario()
        {

            if (IWTConfiguration.Conf.getBoolConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO))
            {
                LoadValorUnitarioMedia();
            }
            else
            {
                LoadValorUnitarioUltimoValor();
            }
        }

        private void LoadValorUnitarioUltimoValor()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                if (this.Produto!=null)
                {


                  
                    command.CommandText =
                        "SELECT  " +
                        "  produto.pro_unidades_por_un_compra, " +
                        "  public.produto_preco.prp_preco, " +
                        " public.produto_ultima_compra.ultimo_preco_unidade_uso " +
                        "FROM " +
                        "  public.produto " +
                        "  LEFT OUTER JOIN public.produto_preco ON (public.produto.id_produto = public.produto_preco.id_produto) " +
                        "  LEFT OUTER JOIN public.produto_ultima_compra ON (public.produto.id_produto = public.produto_ultima_compra.id_produto) " +
                        "WHERE " +
                        "  public.produto.id_produto = :id_produto ";
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Produto.ID;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (read["prp_preco"] is double)
                        {
                            this._valorUnitario = Convert.ToDouble(read["prp_preco"]);
                            this._valorUnitarioCarregado = true;

                        }
                        else
                        {
                            if (read["ultimo_preco_unidade_uso"] is double)
                            {
                                this._valorUnitario = Convert.ToDouble(read["ultimo_preco_unidade_uso"]);
                                this._valorUnitarioCarregado = true;
                            }

                        }
                    }
                    read.Close();
                    return;
                }


                if (this.Material!=null)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  coalesce(public.material_fornecedor.maf_unidades_por_un_compra, public.material.mat_unidades_por_un_compra,1) AS unidades_por_unidade_compra, " +
                        "  public.material_ultima_compra.ultimo_preco_unidade_uso " +
                        "FROM " +
                        "  public.material " +
                        "  LEFT OUTER JOIN public.material_ultima_compra ON (public.material.id_material = public.material_ultima_compra.id_material) " +
                        "  LEFT OUTER JOIN public.material_fornecedor ON (public.material.id_material = public.material_fornecedor.id_material) " +
                        "  AND (public.material_fornecedor.id_fornecedor = public.material_ultima_compra.id_fornecedor_ultima_compra) " +
                        "WHERE " +
                        "  public.material.id_material = :id_material ";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Material.ID;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (read["ultimo_preco_unidade_uso"] is double)
                        {
                            this._valorUnitario = Convert.ToDouble(read["ultimo_preco_unidade_uso"]);
                            this._valorUnitarioCarregado = true;

                        }
                    }
                    read.Close();
                    return;
                }

                if (this.Epi!=null)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  coalesce(public.epi_fornecedor.epf_unidades_por_un_compra, public.epi.epi_unidades_por_unidade_compra,1) AS unidades_por_unidade_compra, " +
                        "  public.epi_ultima_compra.ultimo_preco_unidade_uso " +
                        "FROM " +
                        "  public.epi " +
                        "  LEFT OUTER JOIN public.epi_ultima_compra ON (public.epi.id_epi = public.epi_ultima_compra.id_epi) " +
                        "  LEFT OUTER JOIN public.epi_fornecedor ON (public.epi.id_epi = public.epi_fornecedor.id_epi) " +
                        "  AND (public.epi_fornecedor.id_fornecedor = public.epi_ultima_compra.id_fornecedor_ultima_compra) " +
                        "WHERE " +
                        "  public.epi.id_epi = :id_epi";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Epi.ID;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (read["ultimo_preco_unidade_uso"] is double)
                        {
                            this._valorUnitario = Convert.ToDouble(read["ultimo_preco_unidade_uso"]);
                            this._valorUnitarioCarregado = true;
                        }
                    }
                    read.Close();
                    return;
                }

                this._valorUnitario = 0;
                this._valorUnitarioCarregado = true;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o valor Unitario pelo ulimo valor\r\n" + e.Message, e);
            }
        }

        private void LoadValorUnitarioMedia()
        {
            try
            {
                int nMeses = int.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO_MESES));

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data_inicial", NpgsqlDbType.Date, DateTime.Now.Date.AddMonths(-1 * nMeses)));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data_final", NpgsqlDbType.Date, DateTime.Now.Date));

                if (Produto !=null)
                {
                    command.CommandText =
                        "SELECT  " +
                            "  AVG(public.historico_compra_produto.hcp_preco_unitario /  " +
                            "  CASE  " +
                            "  	WHEN produto_fornecedor.id_unidade_medida_compra IS NOT NULL THEN " +
                            "    	 public.produto_fornecedor.prf_unidades_por_un_compra " +
                            "    ELSE  " +
                            "         CASE  " +
                            "         	WHEN public.produto.id_unidade_medida_compra IS NOT NULL THEN  " +
                            "		    	public.produto.pro_unidades_por_un_compra " +
                            "            ELSE " +
                            "            	1 " +
                            "    	 END " +
                            "    END " +
                            "  ) as preco " +
                        "FROM " +
                        "  public.historico_compra_produto " +
                        "  INNER JOIN public.produto ON (public.historico_compra_produto.id_produto = public.produto.id_produto) " +
                        "  LEFT OUTER JOIN public.produto_fornecedor ON (public.produto.id_produto = public.produto_fornecedor.id_produto) " +
                        "  AND (public.historico_compra_produto.id_fornecedor = public.produto_fornecedor.id_fornecedor) " +
                        "WHERE " +
                        "  public.historico_compra_produto.hcp_data_recebimento BETWEEN :data_inicial AND :data_final AND  " +
                        "  public.historico_compra_produto.id_produto = :id ";
                    command.Parameters["id"].Value = Produto.ID;
                }
                else
                {
                    if (Material!=null)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  AVG(public.historico_compra_material.hcm_preco_unitario /  " +
                            "  CASE  " +
                            "  	WHEN material_fornecedor.id_unidade_medida_compra IS NOT NULL THEN " +
                            "    	 public.material_fornecedor.maf_unidades_por_un_compra " +
                            "    ELSE  " +
                            "         CASE  " +
                            "         	WHEN public.material.id_unidade_medida_compra IS NOT NULL THEN  " +
                            "		    	public.material.mat_unidades_por_un_compra " +
                            "            ELSE " +
                            "            	1 " +
                            "    	 END " +
                            "    END " +
                            "  ) as preco " +
                            "FROM " +
                            "  public.historico_compra_material " +
                            "  INNER JOIN public.material ON (public.historico_compra_material.id_material = public.material.id_material) " +
                            "  LEFT OUTER JOIN public.material_fornecedor ON (public.material.id_material = public.material_fornecedor.id_material) " +
                            "  AND (public.historico_compra_material.id_fornecedor = public.material_fornecedor.id_fornecedor) " +
                            "WHERE " +
                            "  public.historico_compra_material.hcm_data_recebimento BETWEEN :data_inicial AND :data_final AND  " +
                            "  public.historico_compra_material.id_material = :id ";
                        command.Parameters["id"].Value = Material.ID;
                    }
                    else
                    {
                        if (Epi != null)
                        {
                            command.CommandText =
                                "SELECT  " +
                                "  AVG(public.historico_compra_epi.hce_preco_unitario /  " +
                                "  CASE  " +
                                "  	WHEN epi_fornecedor.id_unidade_medida_compra IS NOT NULL THEN " +
                                "    	 public.epi_fornecedor.epf_unidades_por_un_compra " +
                                "    ELSE  " +
                                "         CASE  " +
                                "         	WHEN public.epi.id_unidade_medida_compra IS NOT NULL THEN  " +
                                "		    	public.epi.epi_unidades_por_unidade_compra " +
                                "            ELSE " +
                                "            	1 " +
                                "    	 END " +
                                "    END " +
                                "  ) as preco " +
                                "FROM " +
                                "  public.historico_compra_epi " +
                                "  INNER JOIN public.epi ON (public.historico_compra_epi.id_epi = public.epi.id_epi) " +
                                "  LEFT OUTER JOIN public.epi_fornecedor ON (public.epi.id_epi = public.epi_fornecedor.id_epi) " +
                                "  AND (public.historico_compra_epi.id_fornecedor = public.epi_fornecedor.id_fornecedor) " +
                                "WHERE " +
                                "  public.historico_compra_epi.hce_data_recebimento BETWEEN :data_inicial AND :data_final AND  " +
                                "  public.historico_compra_epi.id_epi = :id ";
                            command.Parameters["id"].Value = Epi.ID;
                        }
                    }
                }

                if (command.CommandText != null)
                {
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (read["preco"] is double)
                        {
                            this._valorUnitario = (double) read["preco"];
                            this._valorUnitarioCarregado = true;
                        }
                        else
                        {
                            this._valorUnitario = 0;
                            this._valorUnitarioCarregado = true;
                        }
                    }
                    else
                    {
                        this._valorUnitario = 0;
                        this._valorUnitarioCarregado = true;
                    }
                    read.Close();
                }
                else
                {
                    this._valorUnitario = 0;
                    this._valorUnitarioCarregado = true;

                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar o valor unitário do item do estoque por valor médio\r\n" + e.Message, e);
            }
        }

        #endregion

        public void SetConteudo(ProdutoClass produto, MaterialClass material, DocumentoCopiaClass documento, RecursoClass recurso, ProdutoKClass produtoK, EpiClass epi)
        {
            int countConteudo = 0;
            if (produto != null)
            {
                countConteudo++;
            }

            if (material != null)
            {
                countConteudo++;
            }

            if (documento != null)
            {
                countConteudo++;
            }

            if (recurso != null)
            {
                countConteudo++;
            }

            if (produtoK != null)
            {
                countConteudo++;
            }

            if (epi != null)
            {
                countConteudo++;
            }

            if (countConteudo > 1)
            {
                throw new ExcecaoTratada("Não é possível definir para uma mesma gaveta item mais de um conteúdo");
            }

            Produto = produto;
            Material = material;
            DocumentoCopia = documento;
            Recurso = recurso;
            ProdutoK = produtoK;
            Epi = epi;
        }


  
    }
}
