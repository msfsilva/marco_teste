using System;
using ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

namespace BibliotecaEstoque
{
    public class EstoqueGavetaItem : IEquatable<EstoqueGavetaItem>
    {
        private int? ID;

        public EstoqueGaveta Gaveta { set; get; }
        public string gavetaString
        {
            get
            {
                if (this.Gaveta != null)
                {
                    return this.Gaveta.Identificacao;
                }
                else
                {
                    return "";
                }
            }
        }


        public EstoquePrateleira Prateleira { set; get; }
        public string prateleiraString
        {
            get
            {
                if (this.Prateleira != null)
                {
                    return this.Prateleira.Identificacao;
                }
                else
                {
                    return "";
                }
            }
        }

        public EstoqueCorredor Corredor { set; get; }
        public string corredorString
        {
            get
            {
                if (this.Corredor != null)
                {
                    return this.Corredor.Identificacao;
                }
                else
                {
                    return "";
                }
            }
        }

        public Estoque Estoque { set; get; }
        public string estoqueString
        {
            get
            {
                if (this.Estoque != null)
                {
                    return this.Estoque.Identificacao;
                }
                else
                {
                    return "";
                }
            }
        }

        private int? idProduto;
        private int? idMaterial; 
        private int? idDocumentoCopia; 
        private int? idRecurso;
        private int? idProdutoK;
        private int? idEpi;

        public double Quantidade { internal set; get; }
        public bool Ativo { private set; get; }

        private bool conteudoLoaded = false;


        private string _codigoItem = null;
        public string codigoItem
        {
            get
            {
                if (!conteudoLoaded)
                {
                    this.loadDadosConteudo();
                }
                return this._codigoItem;
            }
        }

        private string _descricaoItem = null;
        public string descricaoItem
        {
            get
            {
                if (!conteudoLoaded)
                {
                    this.loadDadosConteudo();
                }
                return this._descricaoItem;
            }
        }

        private string _unidadeItem = null;
        public string unidadeItem
        {
            get
            {
                if (!conteudoLoaded)
                {
                    this.loadDadosConteudo();
                }
                return this._unidadeItem;
            }
        }

        private bool _valorUnitarioCarregado = false;
        private double _valorUnitario;

        public double ValorUnitario
        {
            get
            {
                if (!this._valorUnitarioCarregado)
                {
                    this.loadValorUnitario();
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

        private readonly IWTPostgreNpgsqlConnection conn;
        private DateTime? _dataUltimaUtilizacao = null;

        public string DataUltimaUtilizacaoFormatada
        {
            get
            {
                if (_dataUltimaUtilizacao.HasValue)
                {
                    return this._dataUltimaUtilizacao.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
                return "";
            }
        }

        public DateTime DataUltimaUtilizacao
        {
            get
            {
                if (_dataUltimaUtilizacao.HasValue)
                {
                    return _dataUltimaUtilizacao.Value;
                }
                else
                {
                    return new DateTime(1900, 1, 1);
                }
            }
        }


        public string LocalizacaoCompleta
        {
            get { return Gaveta.getLocalizacaoCompleta(); }
        }

        public string TipoConteudo { get; set; }


        public EstoqueGavetaItem(int ID, IWTPostgreNpgsqlConnection conn)
        {
            TipoConteudo = null;
            this.ID = ID;
            this.conn = conn;

            if (this.ID != null)
            {
                this.Load(false);
            }
            else
            {
                this.Ativo = true;
            }

        }

   

        public EstoqueGavetaItem(EstoqueGaveta gaveta, int? idProduto, int? idMaterial, int? idDocumentoCopia, int? idRecurso, int? idProdutoK, int? idEpi, IWTPostgreNpgsqlConnection conn)
        {
            TipoConteudo = null;
            this.setGaveta(gaveta);
            this.Ativo = true;

            this.setConteudo(idProduto, idMaterial, idDocumentoCopia, idRecurso, idProdutoK, idEpi);
        }

        internal EstoqueGavetaItem(int id, DateTime? dataUltimaUtilizacao, IWTPostgreNpgsqlConnection connection)
        {
            TipoConteudo = null;
            this.ID = id;
            this.conn = connection;

            if (this.ID != null)
            {
                this.Load(false);
            }
            else
            {
                this.Ativo = true;
            }

            this._dataUltimaUtilizacao = dataUltimaUtilizacao;

        }

        private void Load(bool parcial)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  id_estoque, " +
                    "  id_estoque_corredor, " +
                    "  id_estoque_prateleira, " +
                    "  id_estoque_gaveta, " +
                    "  id_produto, " +
                    "  id_material, " +
                    "  id_documento_copia, " +
                    "  id_recurso, " +
                    "  id_produto_k, " +
                    "  id_epi, " +
                    "  egi_quantidade, " +
                    "  egi_ativo " +
                    "FROM  " +
                    "  public.estoque_gaveta_item " +
                    "WHERE " +
                    "  id_estoque_gaveta_item = " + this.ID + "; ";

                NpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();

                    if (!parcial)
                    {
                        this.Estoque = new Estoque(Convert.ToInt32(read["id_estoque"]), this.conn);
                        this.Corredor = new EstoqueCorredor(Convert.ToInt32(read["id_estoque_corredor"]), this.conn);
                        this.Prateleira = new EstoquePrateleira(Convert.ToInt32(read["id_estoque_prateleira"]), this.conn);
                        this.Gaveta = new EstoqueGaveta(Convert.ToInt32(read["id_estoque_gaveta"]), this.conn);
                    }

                    if (read["id_documento_copia"] != DBNull.Value)
                    {
                        this.idDocumentoCopia = Convert.ToInt32(read["id_documento_copia"]);
                    }
                    if (read["id_material"] != DBNull.Value)
                    {
                        this.idMaterial = Convert.ToInt32(read["id_material"]);
                    }
                    if (read["id_produto"] != DBNull.Value)
                    {
                        this.idProduto = Convert.ToInt32(read["id_produto"]);
                    }
                    if (read["id_recurso"] != DBNull.Value)
                    {
                        this.idRecurso = Convert.ToInt32(read["id_recurso"]);
                    }

                    if (read["id_produto_k"] != DBNull.Value)
                    {
                        this.idProdutoK = Convert.ToInt32(read["id_produto_k"]);
                    }

                    if (read["id_epi"] != DBNull.Value)
                    {
                        this.idEpi = Convert.ToInt32(read["id_epi"]);
                    }

                    this.Quantidade = Convert.ToDouble(read["egi_quantidade"]);
                    this.Ativo = Convert.ToBoolean(Convert.ToInt16(read["egi_ativo"]));

                    read.Close();
                }
                else
                {
                    throw new Exception("ID Inválido.");
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o item da gaveta.\r\n" + e.Message);
            }
        }

        public void setGaveta(int idEstoqueGaveta)
        {
            this.setGaveta(new EstoqueGaveta(idEstoqueGaveta, conn));
        }

        public void setGaveta(EstoqueGaveta estoqueGaveta)
        {
            this.Gaveta = estoqueGaveta;
            this.Prateleira = estoqueGaveta.Prateleira;
            this.Corredor = estoqueGaveta.Corredor;
            this.Estoque = estoqueGaveta.Estoque;
        }

        public void setConteudo(int? idProduto, int? idMaterial, int? idDocumentoCopia, int? idRecurso, int? idProdutoK, int? idEpi)
        {
            if (idProduto != null)
            {
                this.idProduto = idProduto;
                return;
            }

            if (idMaterial != null)
            {
                this.idMaterial = idMaterial;
            }

            this.idDocumentoCopia = idDocumentoCopia;
            this.idRecurso = idRecurso;
            this.idProdutoK = idProdutoK;
            this.idEpi = idEpi;
        }

        public void setQuantidade(double Quantidade)
        {
            this.Quantidade = Quantidade;
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID == null)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.estoque_gaveta_item " +
                        "( " +
                        "  id_estoque, " +
                        "  id_estoque_corredor, " +
                        "  id_estoque_prateleira, " +
                        "  id_estoque_gaveta, " +
                        "  id_produto, " +
                        "  id_material, " +
                        "  id_documento_copia, " +
                        "  id_recurso, " +
                        "  id_produto_k, " +
                        "  id_epi, " +
                        "  egi_quantidade, " +
                        "  egi_ativo " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_estoque, " +
                        "  :id_estoque_corredor, " +
                        "  :id_estoque_prateleira, " +
                        "  :id_estoque_gaveta, " +
                        "  :id_produto, " +
                        "  :id_material, " +
                        "  :id_documento_copia, " +
                        "  :id_recurso, " +
                        "  :id_produto_k, " +
                        "  :id_epi, " +
                        "  :egi_quantidade, " +
                        "  :egi_ativo " +
                        ") RETURNING id_estoque_gaveta_item;";
                }
                else
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.estoque_gaveta_item   " +
                        "SET  " +
                        "  id_estoque = :id_estoque, " +
                        "  id_estoque_corredor = :id_estoque_corredor, " +
                        "  id_estoque_prateleira = :id_estoque_prateleira, " +
                        "  id_estoque_gaveta = :id_estoque_gaveta, " +
                        "  id_produto = :id_produto, " +
                        "  id_material = :id_material, " +
                        "  id_documento_copia = :id_documento_copia, " +
                        "  id_recurso = :id_recurso, " +
                        "  id_produto_k = :id_produto_k, " +
                        "  id_epi = :id_epi, " +
                        "  egi_quantidade = :egi_quantidade, " +
                        "  egi_ativo = :egi_ativo " +
                        "WHERE  " +
                        "  id_estoque_gaveta_item = :id_estoque_gaveta_item " +
                        "RETURNING id_estoque_gaveta_item;";

                }

                command.Parameters.Clear();


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Estoque.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_corredor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Corredor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_prateleira", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Prateleira.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Gaveta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idProduto;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idMaterial;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idDocumentoCopia;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_recurso", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idRecurso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idProdutoK;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idEpi;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("egi_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("egi_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Ativo);

                this.ID = (int)command.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o item na gaveta.\r\n" + e.Message);
            }
        }       

        public void Delete(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID != null)
                {
                    command.CommandText =
                        "DELETE FROM  " +
                        "  public.estoque_gaveta_item  " +
                        "WHERE  " +
                        "  id_estoque_gaveta_item = :id_estoque_gaveta_item " +
                        ";";

                    command.Parameters.Clear();


                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta_item", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o item da gaveta.\r\n" + e.Message);
            }
        }

        public void setAtivo(bool Ativo, AcsUsuario Usuario,  ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                double qtdMovimentada = 0;
                string observacao = "";
                if (!Ativo)
                {
                    qtdMovimentada = -1 * this.Quantidade;
                    this.Quantidade = 0;
                    observacao = "Item retirado da Gaveta";
                }
                else
                {
                    observacao = "Item recolocado em gaveta pré existente";
                }



                command.CommandText =
                    "INSERT INTO  " +
                    "  public.estoque_movimentacao " +
                    "( " +
                    "  id_acs_usuario, " +
                    "  esm_quantidade, " +
                    "  esm_observacao, " +
                    "  esm_manual, " +
                    "  id_estoque_gaveta_item, " +
                    "  esm_data " +
                    ")  " +
                    "VALUES ( " +
                    "  :id_acs_usuario, " +
                    "  :esm_quantidade, " +
                    "  :esm_observacao, " +
                    "  :esm_manual, " +
                    "  :id_estoque_gaveta_item, " +
                    "  :esm_data " +
                    ");";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Usuario.Id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esm_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = qtdMovimentada;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esm_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = observacao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esm_manual", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = false;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esm_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();


                command.ExecuteNonQuery();


                this.Ativo = Ativo;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ativar ou desativar a gaveta item.\r\n" + e.Message, e);
            }
        }

        public int? getID()
        {
            return this.ID;
        }

        private void loadDadosConteudo()
        {
            try
            {
                string sql = "";

                if (this.idProduto != null)
                {
                    sql =
                        "SELECT  " +
                        "  public.produto.pro_codigo as codigo, " +
                        "  public.produto.pro_descricao as descricao, " +
                        "  public.unidade_medida.unm_abreviada as unidade, "+
                        "  'Produto' as tipo "+
                        "FROM " +
                        "  public.produto " +
                        "  LEFT OUTER JOIN public.unidade_medida ON (public.produto.id_unidade_medida = public.unidade_medida.id_unidade_medida) "+                    
                        "WHERE " +
                        "  public.produto.id_produto = " + idProduto + " ";
                }

                if (this.idMaterial != null)
                {
                    sql =
                        "SELECT  " +
                        "  public.familia_material.fam_codigo || ' ' || " +
                        "  public.material.mat_codigo as codigo,  " +
                        "  public.material.mat_descricao as descricao, " +
                        "  public.unidade_medida.unm_abreviada as unidade, " +
                        "  'Material' as tipo " +
                        "FROM " +
                        "  public.material " +
                        "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                        "  LEFT OUTER JOIN public.unidade_medida ON (public.material.id_unidade_medida = public.unidade_medida.id_unidade_medida )" +               
                        "WHERE " +
                        "  public.material.id_material = " + idMaterial + "";
                }

                if (this.idRecurso != null)
                {
                    sql =
                        "SELECT  " +
                        "  public.familia_recurso.far_identificacao ||' ' || " +
                        "  public.recurso.rec_codigo as codigo, " +
                        "  public.recurso.rec_nome as descricao, "  +
                        "  'UN' as unidade, " +
                        "  'Recurso' as tipo " +
                        "FROM " +
                        "  public.recurso " +
                        "  INNER JOIN public.familia_recurso ON (public.recurso.id_familia_recurso = public.familia_recurso.id_familia_recurso) " +
                        "WHERE " +
                        "  public.recurso.id_recurso = " + idRecurso + " ";
                }

                if (this.idDocumentoCopia != null)
                {
                    sql =
                        "SELECT  " +
                        "  public.familia_documento.fad_codigo || ' ' || " +
                        "  public.documento_tipo.dot_identificacao  as codigo, " +
                        "  public.documento_copia.doc_identificacao  as descricao, " +
                        "  'UN' as unidade, " +
                        "  'Documento' as tipo " +
                        "FROM " +
                        "  public.documento_copia " +
                        "  INNER JOIN public.documento_tipo_familia ON (public.documento_copia.id_documento_tipo_familia = public.documento_tipo_familia.id_documento_tipo_familia) " +
                        "  INNER JOIN public.documento_tipo ON (public.documento_tipo_familia.id_documento_tipo = public.documento_tipo.id_documento_tipo) " +
                        "  INNER JOIN public.familia_documento ON (public.documento_tipo_familia.id_familia_documento = public.familia_documento.id_familia_documento) " +
                        "WHERE " +
                        "  public.documento_copia.id_documento_copia = " + idDocumentoCopia + "";
                }

                if (this.idProdutoK!=null)
                {
                    sql +=
                        "SELECT  " +
                        "  public.produto_k.prk_codigo as codigo, " +
                        "  public.produto_k.prk_dimensao as descricao, " +
                        "  '' as unidade, " +
                        "  'Kanban de Manufaturados' as tipo " +
                        "FROM " +
                        "  public.produto_k " +
                        "WHERE " +
                        "  public.produto_k.id_produto_k = " + idProdutoK + "";

                }

                if (this.idEpi != null)
                {
                    sql +=
                        "SELECT  " +
                        "  public.epi.epi_identificacao as codigo, " +
                        "  public.epi.epi_descricao as descricao, " +
                        "  public.unidade_medida.unm_abreviada as unidade, " +
                        "  'EPI' as tipo " +
                        "FROM " +
                        "  public.epi " +
                        "  JOIN public.unidade_medida ON (public.epi.id_unidade_medida_uso = public.unidade_medida.id_unidade_medida )" +   
                        "WHERE " +
                        "  public.epi.id_epi = " + idEpi + "";

                }


                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText = sql;
                NpgsqlDataReader read = command.ExecuteReader();
                Console.WriteLine(this.ToString());
                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }

                read.Read();
                this._codigoItem = read["codigo"].ToString();
                this._descricaoItem = read["descricao"].ToString();
                this._unidadeItem = read["unidade"].ToString();
                this.TipoConteudo = read["tipo"].ToString();
                read.Close();

                conteudoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do conteudo da gaveta.\r\n" + e.Message, e);
            }
        }

        private void loadValorUnitario()
        {
           
            if (IWTConfiguration.Conf.getBoolConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO))
            {
                loadValorUnitarioMedia();
            }
            else
            {
                loadValorUnitarioUltimoValor();
            }
        }

        private void loadValorUnitarioUltimoValor()
        {
            try
            {
                if (this.idProduto.HasValue)
                {


                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    command.CommandText =
                        "SELECT  " +
                        "  produto.pro_unidades_por_un_compra, " +
                        "  public.produto_preco.prp_preco, " +
                        " public.produto_ultima_compra.ultimo_preco " +
                        "FROM " +
                        "  public.produto " +
                        "  LEFT OUTER JOIN public.produto_preco ON (public.produto.id_produto = public.produto_preco.id_produto) " +
                        "  LEFT OUTER JOIN public.produto_ultima_compra ON (public.produto.id_produto = public.produto_ultima_compra.id_produto) " +
                        "WHERE " +
                        "  public.produto.id_produto = :id_produto ";
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idProduto.Value;

                    NpgsqlDataReader read = command.ExecuteReader();
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
                            if (read["ultimo_preco"] is double)
                            {
                                this._valorUnitario = Convert.ToDouble(read["ultimo_preco"]) / Convert.ToDouble(read["pro_unidades_por_un_compra"]);
                                this._valorUnitarioCarregado = true;
                            }

                        }
                    }
                    read.Close();
                    return;
                }


                if (this.idMaterial.HasValue)
                {
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    command.CommandText =
                        "SELECT  " +
                        "  coalesce(public.material_fornecedor.maf_unidades_por_un_compra, public.material.mat_unidades_por_un_compra,1) AS unidades_por_unidade_compra, " +
                        "  public.material_ultima_compra.ultimo_preco " +
                        "FROM " +
                        "  public.material " +
                        "  LEFT OUTER JOIN public.material_ultima_compra ON (public.material.id_material = public.material_ultima_compra.id_material) " +
                        "  LEFT OUTER JOIN public.material_fornecedor ON (public.material.id_material = public.material_fornecedor.id_material) " +
                        "  AND (public.material_fornecedor.id_fornecedor = public.material_ultima_compra.id_fornecedor_ultima_compra) " +
                        "WHERE " +
                        "  public.material.id_material = :id_material ";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idMaterial.Value;

                    NpgsqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (read["ultimo_preco"] is double)
                        {
                            this._valorUnitario = Convert.ToDouble(read["ultimo_preco"]) / Convert.ToDouble(read["unidades_por_unidade_compra"]);
                            this._valorUnitarioCarregado = true;

                        }
                    }
                    read.Close();
                    return;
                }

                if (this.idEpi.HasValue)
                {
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    command.CommandText =
                        "SELECT  " +
                        "  coalesce(public.epi_fornecedor.epf_unidades_por_un_compra, public.epi.epi_unidades_por_unidade_compra,1) AS unidades_por_unidade_compra, " +
                        "  public.epi_ultima_compra.ultimo_preco " +
                        "FROM " +
                        "  public.epi " +
                        "  LEFT OUTER JOIN public.epi_ultima_compra ON (public.epi.id_epi = public.epi_ultima_compra.id_epi) " +
                        "  LEFT OUTER JOIN public.epi_fornecedor ON (public.epi.id_epi = public.epi_fornecedor.id_epi) " +
                        "  AND (public.epi_fornecedor.id_fornecedor = public.epi_ultima_compra.id_fornecedor_ultima_compra) " +
                        "WHERE " +
                        "  public.epi.id_epi = :id_epi";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idEpi.Value;

                    NpgsqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        read.Read();
                        if (read["ultimo_preco"] is double)
                        {
                            this._valorUnitario = Convert.ToDouble(read["ultimo_preco"]) / Convert.ToDouble(read["unidades_por_unidade_compra"]);
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

        private void loadValorUnitarioMedia()
        {
            try
            {
                int nMeses = int.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_INVENTARIO_PRECO_MEDIO_MESES));

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data_inicial", NpgsqlDbType.Date, DateTime.Now.Date.AddMonths(-1*nMeses)));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data_final", NpgsqlDbType.Date, DateTime.Now.Date));

                if (idProduto.HasValue)
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
                    command.Parameters["id"].Value = idProduto.Value;
                }
                else
                {
                    if (idMaterial.HasValue)
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
                        command.Parameters["id"].Value = idMaterial.Value;
                    }
                    else
                    {
                        if (idEpi.HasValue)
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
                            command.Parameters["id"].Value = idEpi.Value;
                        }
                    }
                }

                NpgsqlDataReader read = command.ExecuteReader();
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
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar o valor unitário do item do estoque por valor médio\r\n" + e.Message, e);
            }
        }

        public bool Equals(EstoqueGavetaItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.ID.Equals(ID);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (EstoqueGavetaItem)) return false;
            return Equals((EstoqueGavetaItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (ID.HasValue ? ID.Value : 0);
                result = (result*397) ^ (idProduto.HasValue ? idProduto.Value : 0);
                result = (result*397) ^ (idMaterial.HasValue ? idMaterial.Value : 0);
                result = (result*397) ^ (idDocumentoCopia.HasValue ? idDocumentoCopia.Value : 0);
                result = (result*397) ^ (idRecurso.HasValue ? idRecurso.Value : 0);
                result = (result*397) ^ (idProdutoK.HasValue ? idProdutoK.Value : 0);
                result = (result*397) ^ (idEpi.HasValue ? idEpi.Value : 0);
                result = (result*397) ^ (_codigoItem != null ? _codigoItem.GetHashCode() : 0);
                result = (result*397) ^ (_descricaoItem != null ? _descricaoItem.GetHashCode() : 0);
                result = (result*397) ^ (_unidadeItem != null ? _unidadeItem.GetHashCode() : 0);
                result = (result*397) ^ _valorUnitarioCarregado.GetHashCode();
                result = (result*397) ^ _valorUnitario.GetHashCode();
                result = (result*397) ^ (Gaveta != null ? Gaveta.GetHashCode() : 0);
                result = (result*397) ^ (Prateleira != null ? Prateleira.GetHashCode() : 0);
                result = (result*397) ^ (Corredor != null ? Corredor.GetHashCode() : 0);
                result = (result*397) ^ (Estoque != null ? Estoque.GetHashCode() : 0);
                result = (result*397) ^ Quantidade.GetHashCode();
                result = (result*397) ^ Ativo.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(EstoqueGavetaItem left, EstoqueGavetaItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EstoqueGavetaItem left, EstoqueGavetaItem right)
        {
            return !Equals(left, right);
        }

        public void forcarCarregamentoConteudo()
        {
            loadDadosConteudo();
        }
    }
}