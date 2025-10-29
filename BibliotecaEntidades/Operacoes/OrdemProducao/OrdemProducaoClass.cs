#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTMDFe.Datasets.PLMDFE100a;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using OrdemProducaoDiferencaClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoDiferencaClass;
using OrdemProducaoDocumentoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoDocumentoClass;
using OrdemProducaoEstoqueClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoEstoqueClass;
using OrdemProducaoGrupoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoGrupoClass;
using OrdemProducaoHistoricoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoHistoricoClass;
using OrdemProducaoMaterialClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoMaterialClass;
using OrdemProducaoPedidoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoPedidoClass;
using OrdemProducaoPostoTrabalhoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoPostoTrabalhoClass;
using OrdemProducaoPostoTrabalhoProducaoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoPostoTrabalhoProducaoClass;
using OrdemProducaoRecursoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoRecursoClass;

#endregion

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public enum TipoItemSelecao { Todos, SomenteKit, SomenteNaoKit };

    public enum TipoErroDocumentoOrdemProducao { FaltaDocumento, ValidacaoRevisao };

    public abstract class OrdemProducaoClass
    {
        public long? idOrdemProducao { get; private set; }
        
        public double Quantidade
        {
            get
            {
                double qtdTmp = this.quantidadePedidos - quantidadeEstoque + this.qtdExtra;
                if (IWTConfiguration.Conf.getBoolConf(Constants.PERMITIR_QTD_FRACIONARIA_OP))
                {
                    return Math.Round(qtdTmp, 2);
                }
                else
                {

                    double sobra = qtdTmp%1;
                    if (sobra==0)
                    {
                        return qtdTmp;
                    }

                    this.qtdExtra += (1 - sobra);
                    return Math.Round(this.quantidadePedidos - quantidadeEstoque + this.qtdExtra, 2);
                }
            }
        }

        public double quantidadeEstoque { get; set; }
        //{
        //    get
        //    {
        //        double toRet = 0;
        //        if (this.Estoques != null)
        //        {
        //            foreach (OrdemProducaoEstoqueClass es in this.Estoques)
        //            {
        //                toRet += es.Quantidade;
        //            }
        //        }
        //        return toRet;
        //    }
        //}

        public double quantidadePedidos
        {
            get
            {
                double toRet = 0;
                if (this.Pedidos != null)
                {
                    foreach (OrdemProducaoPedidoClass pedido in this.Pedidos)
                    {
                        toRet += pedido.Quantidade;
                    }
                }
                return toRet;
            }
        }

        public double qtdExtra { get; set; }
        
        public DateTime Data { get; private set; }
        public int Situacao { get; private set; }
        public long idProduto { get; private set; }
        public int versaoEstruturaProduto { get; private set; }
        public string produtoCodigo { get; private set; }
        public string produtoDescricao { get; private set; }
        public string tipoDocumento { get; private set; }
        public string numeroDocumento { get; private set; }
        public string revisaoDocumento { get; private set; }
        public string Dimensao { get; private set; }

        public bool Pendencia { get; private set; }
        public bool Suspensa { get; private set; }
        public bool qtdMaiorVerificada { get; private set; }
        public bool rastrearMP { get; private set; }
        public bool imprimeOpsRelacionadas { get; private set; }



        public double? QuantidadeFinal { get; set; }
        public bool PendenciaQuantidade { get; set; }


        public string agrupadorOP { get; private set; }
        
        public ProdutoKClass ProdutoK { get; private set; }

        public ProdutoClass Produto { get; private set; }

        public OrdemProducaoGrupoClass Grupo { get; private set; }
        
        public List<OrdemProducaoPostoTrabalhoClass> postosTrabalho { get; private set; }
        public List<OrdemProducaoRecursoClass> Recursos { get; private set; }

        private List<OrdemProducaoDocumentoClass> _internalDocumentos;

        public List<OrdemProducaoDocumentoClass> getDocumentos(IWTPostgreNpgsqlCommand command)
        {


            if (this.Grupo != null)
            {
                List<OrdemProducaoDocumentoClass> toRet = new List<OrdemProducaoDocumentoClass>();
                foreach (int idDocumentoTipoFamilia in this.Grupo.Documentos.Keys)
                {
                    if (this.utilizaDocumento(idDocumentoTipoFamilia, command))
                    {
                        toRet.Add(this.Grupo.Documentos[idDocumentoTipoFamilia]);
                    }

                }

                return toRet;
            }
            else
            {
                if (this._internalDocumentos == null)
                {
                    this.loadDocumentosSemGrupo();
                }

                return this._internalDocumentos;
            }




        }

        public List<OrdemProducaoMaterialClass> Materiais { get; private set; }
        public List<OrdemProducaoPedidoClass> Pedidos { get; private set; }
        public List<OrdemProducaoDiferencaClass> Diferencas { get; private set; }
        public List<OrdemProducaoEstoqueClass> Estoques { get; private set; }
        public List<OrdemProducaoProdutoComponenteClass> ProdutosComponentes { get; private set; }
        public List<OrdemProducaoHistoricoClass> Historicos { get; private set; }

        public AcsUsuarioClass Usuario { get; private set; }
        public AcsUsuarioClass UsuarioAtual { get; private set; }

        public AcsUsuarioClass UsuarioImpressao { get; private set; }
        public DateTime? dataImpressao { get; private set; }

        public AcsUsuarioClass UsuarioReimpressao { get; private set; }
        public DateTime? dataReimpressao { get; private set; }


        public AcsUsuarioClass usuarioEncerramento { get; private set; }
        public DateTime? dataEncerramento { get; private set; }

        private IWTPostgreNpgsqlConnection conn;
        public EstoqueGavetaClass EstoqueGavetaSaidaOp { get; private set; }

        IOrdemProducaoFactory iOrdemProducaoFactory;

        public List<PlanoCorteItemOpClass> ItensPlanoCorte = new List<PlanoCorteItemOpClass>(); 

        public int maxSequenciaPosto
        {
            get
            {
                int maxSeqAtual = 0;
                foreach (OrdemProducaoPostoTrabalhoClass posto in this.postosTrabalho)
                {
                    if (posto.Sequencia > maxSeqAtual)
                    {
                        maxSeqAtual = posto.Sequencia;
                    }
                }
                return maxSeqAtual;
            }
        }

        public OrdemProducaoClass(long idProduto, int versaoEstruturaProduto, string produtoCodigo, string produtoDescricao, string tipoDocumento, string numeroDocumento, string revisaoDocumento, string Dimensao, bool rastrearMP, bool imprimeOpsRelacionadas, long? idProdutoK, OrdemProducaoGrupoClass Grupo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory)
        {
            this.Grupo = Grupo;
            this.idOrdemProducao = null;
            this.Data = Configurations.DataIndependenteClass.GetData();
            this.Situacao = 0;
            this.produtoCodigo = produtoCodigo;
            this.produtoDescricao = produtoDescricao;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.revisaoDocumento = revisaoDocumento;
            this.Dimensao = Dimensao;
            this.idProduto = idProduto;
            this.versaoEstruturaProduto = versaoEstruturaProduto;
            this.rastrearMP = rastrearMP;
            this.imprimeOpsRelacionadas = imprimeOpsRelacionadas;
            
            this.Pendencia = false;
            this.Suspensa = false;
            this.qtdMaiorVerificada = false;

            this.conn = conn;
            this.Usuario = Usuario;
            this.UsuarioAtual = Usuario;
            this.UsuarioReimpressao = null;
            this.dataReimpressao = null;

            this.postosTrabalho = new List<OrdemProducaoPostoTrabalhoClass>();
            this.Recursos = new List<OrdemProducaoRecursoClass>();
            this.Materiais = new List<OrdemProducaoMaterialClass>();
            this.Pedidos = new List<OrdemProducaoPedidoClass>();
            this.Diferencas = new List<OrdemProducaoDiferencaClass>();
            this.Estoques = new List<OrdemProducaoEstoqueClass>();
            this.Historicos = new List<OrdemProducaoHistoricoClass>();
            this.ProdutosComponentes = new List<OrdemProducaoProdutoComponenteClass>();

            this.Produto = ProdutoBaseClass.GetEntidade(idProduto, this.UsuarioAtual, this.conn);
            if (this.Produto.AgrupadorOp == null)
            {
                throw new ExcecaoTratada("O produto "+this.Produto.ToString()+" não possui Agrupador de Ordem de Produção definido");
            }
            this.agrupadorOP = this.Produto.AgrupadorOp.Identificacao;

            if (idProdutoK.HasValue)
            {
                this.ProdutoK = ProdutoKClass.GetEntidade(idProdutoK.Value, this.UsuarioAtual, this.conn);
            }
            else
            {
                this.ProdutoK = null;

            }

            this.iOrdemProducaoFactory = iOrdemProducaoFactory;
        }

        public OrdemProducaoClass(long idOrdemProducao, OrdemProducaoGrupoClass Grupo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory)
        {
          this.Load(idOrdemProducao,Grupo, Usuario,conn,iOrdemProducaoFactory);
        }

        private void Load(long idOrdemProducao, OrdemProducaoGrupoClass Grupo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, IOrdemProducaoFactory iOrdemProducaoFactory)
        {
            this.idOrdemProducao = idOrdemProducao;
            this.conn = conn;
            this.UsuarioAtual = Usuario;

            this.iOrdemProducaoFactory = iOrdemProducaoFactory;

            this.postosTrabalho = new List<OrdemProducaoPostoTrabalhoClass>();
            this.Recursos = new List<OrdemProducaoRecursoClass>();
            this.Materiais = new List<OrdemProducaoMaterialClass>();
            this.Pedidos = new List<OrdemProducaoPedidoClass>();
            this.Diferencas = new List<OrdemProducaoDiferencaClass>();
            this.Estoques = new List<OrdemProducaoEstoqueClass>();
            this.Historicos = new List<OrdemProducaoHistoricoClass>();
            this.ProdutosComponentes = new List<OrdemProducaoProdutoComponenteClass>();


            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                "SELECT  " +
                "  orp_quantidade, " +
                "  orp_data, " +
                "  orp_situacao, " +
                "  orp_produto_descricao, " +
                "  orp_produto_codigo, " +
                "  orp_tipo_documento, " +
                "  orp_numero_documento, " +
                "  orp_revisao_documento, " +
                "  orp_dimensao, " +
                "  id_produto, " +
                "  orp_versao_estrutura_produto, " +
                "  orp_pendencia, " +
                "  orp_suspensa, " +
                "  orp_qtd_maior_verificada, " +
                "  id_ordem_producao_grupo, " +
                "  id_acs_usuario,  " +
                "  orp_data_reimpressao, " +
                "  id_acs_usuario_reimpressao, " +
                "  id_acs_usuario_impressao, " +
                "  orp_data_impressao, " +
                "  orp_agrupador_op, " +
                "  id_acs_usuario_encerramento, " +
                "  orp_data_encerramento, " +
                "  orp_rastreamento_material, " +
                "  orp_quantidade_extra, " +
                "  id_estoque_gaveta, " +
                "  orp_imprime_relacionadas, " +
                "  id_produto_k, " +
                "  orp_quantidade_estoque, " +
                "  orp_quantidade_final, "  +
                "  orp_pendencia_de_quantidade " +
                "FROM " +
                "  public.ordem_producao " +
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    this.Data = Convert.ToDateTime(read["orp_data"]);
                    this.Situacao = Convert.ToInt32(read["orp_situacao"]);
                    this.produtoDescricao = read["orp_produto_descricao"].ToString();
                    this.produtoCodigo = read["orp_produto_codigo"].ToString();
                    this.tipoDocumento = read["orp_tipo_documento"].ToString();
                    this.numeroDocumento = read["orp_numero_documento"].ToString();
                    this.revisaoDocumento = read["orp_revisao_documento"].ToString();
                    this.Dimensao = read["orp_dimensao"].ToString();
                    this.idProduto = Convert.ToInt32(read["id_produto"]);
                    int? idProdutokTemp = read["id_produto_k"] as int?;
                    if (idProdutokTemp.HasValue)
                    {
                        this.ProdutoK = ProdutoKClass.GetEntidade(idProdutokTemp.Value, UsuarioAtual, conn);
                    }
                    else
                    {
                        this.ProdutoK = null;
                    }

                    this.versaoEstruturaProduto = Convert.ToInt32(read["orp_versao_estrutura_produto"]);
                    this.Produto = ProdutoBaseClass.GetEntidade(idProduto, UsuarioAtual, this.conn);

                    this.Pendencia = Convert.ToBoolean(Convert.ToInt16(read["orp_pendencia"]));
                    this.Suspensa = Convert.ToBoolean(Convert.ToInt16(read["orp_suspensa"]));
                    this.qtdMaiorVerificada = Convert.ToBoolean(Convert.ToInt16(read["orp_qtd_maior_verificada"]));

                    this.agrupadorOP = read["orp_agrupador_op"].ToString();

                    this.Usuario = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, this.conn);
                    if (read["id_acs_usuario_reimpressao"] != DBNull.Value)
                    {
                        this.UsuarioReimpressao = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_reimpressao"]), UsuarioAtual, this.conn);
                        this.dataReimpressao = Convert.ToDateTime(read["orp_data_reimpressao"]);
                    }

                    if (read["id_acs_usuario_impressao"] != DBNull.Value)
                    {
                        this.UsuarioImpressao = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_impressao"]), UsuarioAtual, this.conn);
                        this.dataImpressao = Convert.ToDateTime(read["orp_data_impressao"]);
                    }

                    if (Grupo != null)
                    {
                        this.Grupo = Grupo;
                    }
                    else
                    {
                        this.Grupo = this.iOrdemProducaoFactory.getInstanceOPGrupo(Convert.ToInt32(read["id_ordem_producao_grupo"]),  this.conn, this.UsuarioAtual, this, false);
                    }

                    if (read["id_acs_usuario_encerramento"] != DBNull.Value)
                    {
                        this.usuarioEncerramento = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_encerramento"]),UsuarioAtual, this.conn);
                        this.dataEncerramento = Convert.ToDateTime(read["orp_data_encerramento"]);
                    }

                    this.rastrearMP = Convert.ToBoolean(Convert.ToInt16(read["orp_rastreamento_material"]));

                    this.qtdExtra = Convert.ToDouble(read["orp_quantidade_extra"]);
                    this.quantidadeEstoque = Convert.ToDouble(read["orp_quantidade_estoque"]);
                    this.imprimeOpsRelacionadas = Convert.ToBoolean(Convert.ToInt16(read["orp_imprime_relacionadas"]));


                    if (read["id_estoque_gaveta"] != DBNull.Value)
                    {
                        this.EstoqueGavetaSaidaOp = EstoqueGavetaClass.GetEntidade(Convert.ToInt32(read["id_estoque_gaveta"]), UsuarioAtual, this.conn);
                    }



                    QuantidadeFinal = read["orp_quantidade_final"] as double?;
                    PendenciaQuantidade = Convert.ToBoolean(Convert.ToInt16(read["orp_pendencia_de_quantidade"]));

                    read.Close();
                }
                else
                {
                    throw new Exception("ID Inválido: " + this.idOrdemProducao);
                }


                #region Postos de trabalho
                command.CommandText =
                "SELECT  " +
                "  id_ordem_producao_posto_trabalho, " +
                "  posto_trabalho.id_posto_trabalho, " +
                "  opt_posto_codigo, " +
                "  opt_posto_nome, " +
                "  opt_posto_operacao, " +
                "  opt_sequencia, " +
                "  opt_tempo_setup, " +
                "  opt_tempo_producao, " +
                "  pos_rastreamento, " +
                "  pos_acompanhamento, " +
                "  opt_operador_tempo_1, " +
                "  id_acs_usuario_tempo_1, " +
                "  opt_tempo1, " +
                "  opt_tempo2, " +
                "  opt_tempo3, " +
                "  opt_tempo4, " +
                "  opt_quantidade_entrada, " +
                "  opt_quantidade_saida, " +
                "  opt_operador_tempo_2, " +
                "  id_acs_usuario_tempo_2, " +
                "  opt_operador_tempo_3, " +
                "  id_acs_usuario_tempo_3, " +
                "  opt_operador_tempo_4, " +
                "  id_acs_usuario_tempo_4, " +
                "  id_motivo_alteracao_qtd_op, " +
                "  pos_rastreamento_material " +
                "FROM  " +
                "  public.ordem_producao_posto_trabalho " +
                "  JOIN public.posto_trabalho ON posto_trabalho.id_posto_trabalho = ordem_producao_posto_trabalho.id_posto_trabalho " +
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao ";



                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;

                read = command.ExecuteReader();
                while (read.Read())
                {
                    this.postosTrabalho.Add(new OrdemProducaoPostoTrabalhoClass(Convert.ToInt32(read["id_ordem_producao_posto_trabalho"]),
                        Convert.ToInt32(read["id_posto_trabalho"]), read["opt_posto_codigo"].ToString(),
                        read["opt_posto_nome"].ToString(), read["opt_posto_operacao"].ToString(),
                        Convert.ToBoolean(Convert.ToInt16(read["pos_rastreamento"])),
                        Convert.ToBoolean(Convert.ToInt16(read["pos_rastreamento_material"])),
                        (PostoTrabalhoAcompanhamento)Enum.ToObject(typeof(PostoTrabalhoAcompanhamento), read["pos_acompanhamento"]),
                        Convert.ToDouble(read["opt_tempo_producao"]),
                        Convert.ToDouble(read["opt_tempo_setup"]), Convert.ToInt32(read["opt_sequencia"]),
                        read["opt_tempo1"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(read["opt_tempo1"]),
                        read["id_acs_usuario_tempo_1"] == DBNull.Value ? null : (Int32?)Convert.ToInt32(read["id_acs_usuario_tempo_1"]),
                        read["opt_operador_tempo_1"] == DBNull.Value ? null : read["opt_operador_tempo_1"].ToString(),
                        read["opt_tempo2"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(read["opt_tempo2"]),
                        read["id_acs_usuario_tempo_2"] == DBNull.Value ? null : (Int32?)Convert.ToInt32(read["id_acs_usuario_tempo_2"]),
                        read["opt_operador_tempo_2"] == DBNull.Value ? null : read["opt_operador_tempo_2"].ToString(),
                        read["opt_tempo3"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(read["opt_tempo3"]),
                        read["id_acs_usuario_tempo_3"] == DBNull.Value ? null : (Int32?)Convert.ToInt32(read["id_acs_usuario_tempo_3"]),
                        read["opt_operador_tempo_3"] == DBNull.Value ? null : read["opt_operador_tempo_3"].ToString(),
                        read["opt_tempo4"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(read["opt_tempo4"]),
                        read["id_acs_usuario_tempo_4"] == DBNull.Value ? null : (Int32?)Convert.ToInt32(read["id_acs_usuario_tempo_4"]),
                        read["opt_operador_tempo_4"] == DBNull.Value ? null : read["opt_operador_tempo_4"].ToString(),
                        read["opt_quantidade_entrada"] == DBNull.Value ? null : (Double?)Convert.ToDouble(read["opt_quantidade_entrada"]),
                        read["opt_quantidade_saida"] == DBNull.Value ? null : (Double?)Convert.ToDouble(read["opt_quantidade_saida"]),
                        read["id_motivo_alteracao_qtd_op"] == DBNull.Value ? null : (int?)Convert.ToInt32(read["id_motivo_alteracao_qtd_op"]),
                        this, this.conn));
                }
                read.Close();
                #endregion

                #region Recursos
                command.CommandText =
                "SELECT  " +
                "  id_ordem_producao_recurso, " +
                "  id_recurso, " +
                "  opr_recurso_codigo, " +
                "  opr_recurso_nome, " +
                "  opr_posto_trabalho_codigo, " +
                "  id_posto_trabalho, " +
                "  opr_recurso_revisao, " +
                "  opr_recurso_familia, " +
                "  opr_recurso_loc1, " +
                "  opr_recurso_loc2, " +
                "  opr_recurso_loc3, " +
                "  opr_recurso_loc4, " +
                "  opr_recurso_hierarquia, " +
                "  opr_recurso_tipo, " +
                "  opr_recurso_diretorio_origem, " +
                "  opr_recurso_diretorio_destino, " +
                "  opr_formulario_preenchido " +
                "FROM  " +
                "  public.ordem_producao_recurso " +
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;

                read = command.ExecuteReader();

                while (read.Read())
                {

                    byte[] formulario = null;
                    if (read["opr_formulario_preenchido"] != DBNull.Value)
                    {
                        formulario = (byte[])read["opr_formulario_preenchido"];
                    }

                    this.Recursos.Add(new OrdemProducaoRecursoClass(Convert.ToInt32(read["id_ordem_producao_recurso"]),
                        Convert.ToInt32(read["id_recurso"]), read["opr_posto_trabalho_codigo"].ToString(), read["opr_recurso_codigo"].ToString(),
                        read["opr_recurso_nome"].ToString(), read["opr_recurso_revisao"].ToString(), read["opr_recurso_familia"].ToString(),
                        read["opr_recurso_loc1"].ToString(), read["opr_recurso_loc2"].ToString(), read["opr_recurso_loc3"].ToString(),
                        read["opr_recurso_loc4"].ToString(),
                        (TipoRecurso)Enum.ToObject(typeof(TipoRecurso), read["opr_recurso_tipo"]),
                        read["opr_recurso_diretorio_origem"].ToString(),
                        read["opr_recurso_diretorio_destino"].ToString(),
                        formulario,
                        (HierarquiaRecursoEstrutura)Enum.ToObject(typeof(HierarquiaRecursoEstrutura), read["opr_recurso_hierarquia"]),
                        Convert.ToInt32(read["id_posto_trabalho"]),
                        this, this.conn));
                }
                read.Close();
                #endregion

                #region Materiais
                command.CommandText =
                "SELECT  " +
                "  id_ordem_producao_material, " +
                "  ordem_producao_material.id_material, " +
                "  opm_quantidade, " +
                "  opm_material_descricao, " +
                "  opm_material_unidade_medida, " +
                "  opm_material_medida, " +
                "  opm_material_medida_largura, " +
                "  opm_material_medida_comprimento, " +
                "  opm_material_tipo_acabamento, " +
                "  opm_material_codigo, " +
                "  familia_material.fam_codigo " +
                "FROM  " +
                "  public.ordem_producao_material " +
                "  LEFT JOIN public.material ON ordem_producao_material.id_material = material.id_material  " +
                "  LEFT JOIN public.familia_material ON familia_material.id_familia_material = material.id_familia_material " +
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;
                read = command.ExecuteReader();

                while (read.Read())
                {

                    MaterialClass material = MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]), UsuarioAtual, conn);

                    this.Materiais.Add(new OrdemProducaoMaterialClass(Convert.ToInt32(read["id_ordem_producao_material"]),
                        material, read["opm_material_descricao"].ToString(),
                        read["opm_material_unidade_medida"].ToString(), Convert.ToDouble(read["opm_material_medida"]),
                        Convert.ToDouble(read["opm_material_medida_largura"]), Convert.ToDouble(read["opm_material_medida_comprimento"]),
                        read["opm_material_tipo_acabamento"].ToString(), read["opm_material_codigo"].ToString(),
                        Convert.ToDouble(read["opm_quantidade"]),
                        read["fam_codigo"].ToString(), this, this.conn));
                }
                read.Close();
                #endregion

                #region Pedidos
                command.CommandText =

                "SELECT  " +
                "  id_ordem_producao_pedido, " +
                "  opp_produto_codigo, " +
                "  opp_produto_descricao, " +
                "  opp_order_number, " +
                "  opp_order_pos, " +
                "  opp_variavel_1, " +
                "  opp_valor_variavel_1, " +
                "  opp_variavel_2, " +
                "  opp_valor_variavel_2, " +
                "  opp_variavel_3, " +
                "  opp_valor_variavel_3, " +
                "  opp_variavel_4, " +
                "  opp_valor_variavel_4, " +
                "  opp_quantidade, " +
                "  opp_tipo_documento, " +
                "  opp_numero_documento, " +
                "  opp_saf, " +
                "  opp_cnc, " +
                "  opp_tipo_ligacao, " +
                "  opp_produto_codigo_pai, " +
                "  opp_produto_descricao_pai, " +
                "  opp_produto_acabamento_pai, " +
                "  opp_cliente, " +
                "  opp_semana_entrega, " +
                "  opp_revisao_documento, " +
                "  opp_dimensao, " +
                "  id_order_item_etiqueta " +
                "FROM  " +
                "  public.ordem_producao_pedido " +
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;

                read = command.ExecuteReader();
                while (read.Read())
                {

                    int? idOrderItemEtiqueta = null;
                    if (read["id_order_item_etiqueta"] != DBNull.Value)
                    {
                        idOrderItemEtiqueta = Convert.ToInt32(read["id_order_item_etiqueta"]);
                    }
                    this.Pedidos.Add(new OrdemProducaoPedidoClass(Convert.ToInt32(read["id_ordem_producao_pedido"]),
                        read["opp_order_number"].ToString(), Convert.ToInt32(read["opp_order_pos"].ToString()),
                        read["opp_produto_codigo"].ToString(), read["opp_produto_descricao"].ToString(),
                        read["opp_variavel_1"].ToString(), read["opp_valor_variavel_1"].ToString(),
                        read["opp_variavel_2"].ToString(), read["opp_valor_variavel_2"].ToString(), read["opp_variavel_3"].ToString(),
                        read["opp_valor_variavel_3"].ToString(), read["opp_variavel_4"].ToString(), read["opp_valor_variavel_4"].ToString(),
                        Convert.ToDouble(read["opp_quantidade"]), read["opp_tipo_documento"].ToString(), read["opp_numero_documento"].ToString(),
                        read["opp_revisao_documento"].ToString(), read["opp_saf"].ToString(), read["opp_cnc"].ToString(), read["opp_tipo_ligacao"].ToString(),
                        read["opp_produto_codigo_pai"].ToString(), read["opp_produto_descricao_pai"].ToString(), read["opp_produto_acabamento_pai"].ToString(),
                        Convert.ToInt32(read["opp_semana_entrega"]), read["opp_cliente"].ToString(),
                        read["opp_dimensao"].ToString(), idOrderItemEtiqueta, this, this.conn));
                }
                read.Close();
                #endregion

                #region Diferenças
                command.CommandText =
                "SELECT  " +
                "  id_ordem_producao_diferenca, " +
                "  id_ordem_producao, " +
                "  id_ordem_producao_posto_trabalho, " +
                "  id_acs_usuario, " +
                "  id_motivo_alteracao_qtd_op, " +
                "  opd_repor, " +
                "  opd_reposto, " +
                "  opd_quantidade, " +
                "  opd_destino, " +
                "  id_estoque " +
                "FROM  " +
                "  public.ordem_producao_diferenca " +
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;
                read = command.ExecuteReader();

                while (read.Read())
                {

                    bool? repor = null;

                    if (read["opd_repor"] != DBNull.Value)
                    {
                        repor = Convert.ToBoolean(Convert.ToInt16(read["opd_repor"]));
                    }

                    bool? reposto = null;

                    if (read["opd_reposto"] != DBNull.Value)
                    {
                        reposto = Convert.ToBoolean(Convert.ToInt16(read["opd_reposto"]));
                    }

                    int? destino = null;

                    if (read["opd_destino"] != DBNull.Value)
                    {
                        destino = Convert.ToInt16(read["opd_destino"]);
                    }

                    int? idEstoque = null;

                    if (read["id_estoque"] != DBNull.Value)
                    {
                        idEstoque = Convert.ToInt32(read["id_estoque"]);
                    }

                    this.Diferencas.Add(new OrdemProducaoDiferencaClass(Convert.ToInt32(read["id_ordem_producao_diferenca"]),
                        Convert.ToInt32(read["id_ordem_producao_posto_trabalho"]),
                        AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual,conn),
                        Convert.ToInt32(read["id_motivo_alteracao_qtd_op"]), repor, reposto, Convert.ToDouble(read["opd_quantidade"]),
                        destino, idEstoque, this, this.conn));
                }
                read.Close();
                #endregion

                #region Estoques
                /*
                command.CommandText =
                "SELECT  " +
                "  id_ordem_producao_estoque, "+
                "  id_ordem_producao, "+
                "  id_estoque_produto, "+
                "  ope_quantidade "+
                "FROM  "+
                "  public.ordem_producao_estoque "+
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;
                read = command.ExecuteReader();

                while (read.Read())
                {

                    this.Estoques.Add(new OrdemProducaoEstoqueClass(Convert.ToInt32(read["id_ordem_producao_estoque"]),
                        Convert.ToInt32(read["id_estoque_produto"]), Convert.ToDouble(read["ope_quantidade"]),
                        this, this.conn));
                }
                read.Close();
                */
                #endregion

                #region Historicos

                command.CommandText =
                "SELECT  " +
                "  id_ordem_producao_historico, " +
                "  id_acs_usuario, " +
                "  oph_historico, " +
                "  oph_data_hora " +
                "FROM  " +
                "  public.ordem_producao_historico " +
                "WHERE " +
                "  id_ordem_producao=:id_ordem_producao " +
                "ORDER BY " +
                "  oph_data_hora";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;
                read = command.ExecuteReader();

                while (read.Read())
                {

                    this.Historicos.Add(new OrdemProducaoHistoricoClass(Convert.ToInt32(read["id_ordem_producao_historico"]),
                        AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]), UsuarioAtual, this.conn), Convert.ToDateTime(read["oph_data_hora"]),
                        read["oph_historico"].ToString(), this, this.conn));
                }
                read.Close();

                #endregion

                #region Componentes

                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao_produto_componente.id_ordem_producao_produto_componente, " +
                    "  public.ordem_producao_produto_componente.id_produto, " +
                    "  public.ordem_producao_produto_componente.id_produto_k, " +
                    "  public.ordem_producao_produto_componente.opc_produto_codigo, " +
                    "  public.ordem_producao_produto_componente.opc_produto_descricao, " +
                    "  public.ordem_producao_produto_componente.opc_quantidade, " +
                    "  public.ordem_producao_produto_componente.opc_dimensao " +

                    "FROM " +
                    "  public.ordem_producao_produto_componente " +
                    "WHERE " +
                    "  public.ordem_producao_produto_componente.id_ordem_producao = :id_ordem_producao ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;
                read = command.ExecuteReader();

                while (read.Read())
                {
                    this.ProdutosComponentes.Add(new OrdemProducaoProdutoComponenteClass(
                        Convert.ToInt32(read["id_ordem_producao_produto_componente"]),
                        read["id_produto"] as int?,
                        read["id_produto_k"] as int?,
                        read["opc_produto_codigo"].ToString(),
                        read["opc_produto_descricao"].ToString(),
                        Convert.ToDouble(read["opc_quantidade"]),
                        Convert.ToString(read["opc_dimensao"]),
                        this, this.conn));
                }
                read.Close();
                #endregion

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da Ordem de Produção.\r\n" + e.Message);
            }

        }

        public void Save()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {

                if (this.Grupo != null && this.Grupo.idOrdemProducaoGrupo != null)
                {
                    command = this.conn.CreateCommand();
                    command.Transaction = this.conn.BeginTransaction();

                    this.Save(ref command);

                    command.Transaction.Commit();

                    this.AtualizarItensPlanoCorte();
                }
                else
                {
                    throw new Exception("Não é possível salvar a OP pois o grupo não foi salvo.");
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw e;
            }
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                bool opNova = false;
                if (this.idOrdemProducao == null)
                {
                    opNova = true;
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.ordem_producao " +
                        "( " +
                        "  orp_quantidade, " +
                        "  orp_data, " +
                        "  orp_situacao, " +
                        "  orp_produto_descricao, " +
                        "  orp_produto_codigo, " +
                        "  orp_tipo_documento, " +
                        "  orp_numero_documento, " +
                        "  orp_revisao_documento, " +
                        "  orp_dimensao, " +
                        "  id_produto, " +
                        "  orp_quantidade_estoque, " +
                        "  orp_quantidade_pedido, " +
                        "  orp_pendencia, "+
                        "  orp_suspensa, "+
                        "  orp_qtd_maior_verificada, "+
                        "  id_ordem_producao_grupo, "+
                        "  id_acs_usuario,  " +
                        "  orp_data_reimpressao, " +
                        "  id_acs_usuario_reimpressao, " +
                        "  id_acs_usuario_impressao, " +
                        "  orp_data_impressao, " +
                        "  orp_agrupador_op, "+
                        "  id_acs_usuario_encerramento, "+
                        "  orp_data_encerramento, "+
                        "  orp_versao_estrutura_produto, "+
                        "  orp_rastreamento_material, "+
                        "  orp_quantidade_extra, "+                        
                        "  id_estoque_gaveta," +
                        "  orp_imprime_relacionadas, " +
                        "  id_produto_k, " +
                        "  orp_quantidade_final,  "+
                        "  orp_pendencia_de_quantidade "+
                        ")  " +
                        "VALUES ( " +
                        "  :orp_quantidade, " +
                        "  :orp_data, " +
                        "  :orp_situacao, " +
                        "  :orp_produto_descricao, " +
                        "  :orp_produto_codigo, " +
                        "  :orp_tipo_documento, " +
                        "  :orp_numero_documento, " +
                        "  :orp_revisao_documento, " +
                        "  :orp_dimensao, " +
                        "  :id_produto, " +
                        "  :orp_quantidade_estoque, " +
                        "  :orp_quantidade_pedido, " +
                        "  :orp_pendencia, " +
                        "  :orp_suspensa, " +
                        "  :orp_qtd_maior_verificada, " +
                        "  :id_ordem_producao_grupo, "+
                        "  :id_acs_usuario,  " +
                        "  :orp_data_reimpressao, " +
                        "  :id_acs_usuario_reimpressao, " +
                        "  :id_acs_usuario_impressao, " +
                        "  :orp_data_impressao, " +
                        "  :orp_agrupador_op, "+
                        "  :id_acs_usuario_encerramento, " +
                        "  :orp_data_encerramento, " +
                        "  :orp_versao_estrutura_produto, " +
                        "  :orp_rastreamento_material, "+
                        "  :orp_quantidade_extra, "+
                        "  :id_estoque_gaveta," +
                        "  :orp_imprime_relacionadas, " +
                        "  :id_produto_k, " +
                        "  :orp_quantidade_final,  " +
                        "  :orp_pendencia_de_quantidade " +
                        ") RETURNING id_ordem_producao;";

                    this.addHistorico(this.UsuarioAtual, Configurations.DataIndependenteClass.GetData(), "Ordem criada");
                }
                else
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.ordem_producao   " +
                        "SET  " +
                        "  orp_quantidade = :orp_quantidade, " +
                        "  orp_data = :orp_data, " +
                        "  orp_situacao = :orp_situacao, " +
                        "  orp_produto_descricao = :orp_produto_descricao, " +
                        "  orp_produto_codigo = :orp_produto_codigo, " +
                        "  orp_tipo_documento = :orp_tipo_documento, " +
                        "  orp_numero_documento = :orp_numero_documento, " +
                        "  orp_revisao_documento = :orp_revisao_documento, " +
                        "  orp_dimensao = :orp_dimensao, " +
                        "  id_produto = :id_produto, " +
                        "  orp_quantidade_estoque = :orp_quantidade_estoque, " +
                        "  orp_quantidade_pedido = :orp_quantidade_pedido, " +
                        "  orp_pendencia = :orp_pendencia, " +
                        "  orp_suspensa = :orp_suspensa, " +
                        "  orp_qtd_maior_verificada = :orp_qtd_maior_verificada, " +
                        "  id_ordem_producao_grupo =:id_ordem_producao_grupo, "+
                        "  id_acs_usuario = :id_acs_usuario,  " +
                        "  orp_data_reimpressao = :orp_data_reimpressao, " +
                        "  id_acs_usuario_reimpressao = :id_acs_usuario_reimpressao, " +
                        "  id_acs_usuario_impressao = :id_acs_usuario_impressao, " +
                        "  orp_data_impressao = :orp_data_impressao, " +
                        "  orp_agrupador_op = :orp_agrupador_op, "+
                        "  id_acs_usuario_encerramento = :id_acs_usuario_encerramento, " +
                        "  orp_data_encerramento = :orp_data_encerramento, " +
                        "  orp_versao_estrutura_produto  = :orp_versao_estrutura_produto, "+
                        "  orp_rastreamento_material = :orp_rastreamento_material, "+
                        "  orp_quantidade_extra = orp_quantidade_extra, "+
                        "  id_estoque_gaveta  = :id_estoque_gaveta, " +
                        "  orp_imprime_relacionadas = :orp_imprime_relacionadas, " +
                        "  id_produto_k = :id_produto_k, " +
                        "  orp_quantidade_final = :orp_quantidade_final,  " +
                        "  orp_pendencia_de_quantidade = :orp_pendencia_de_quantidade " +
                        "WHERE  " +
                        "  id_ordem_producao = :id_ordem_producao " +
                        "RETURNING id_ordem_producao ;";
                }
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.Data;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.Situacao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_produto_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.produtoDescricao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_produto_codigo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.produtoCodigo;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_tipo_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.tipoDocumento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_numero_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.numeroDocumento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_revisao_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.revisaoDocumento;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_dimensao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Dimensao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idProduto;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_estoque", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.quantidadeEstoque;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_pedido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.quantidadePedidos;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_pendencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Pendencia);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_suspensa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Suspensa);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_qtd_maior_verificada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.qtdMaiorVerificada);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_grupo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Grupo.idOrdemProducaoGrupo;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Usuario.ID;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data_reimpressao", NpgsqlDbType.Timestamp));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_reimpressao", NpgsqlDbType.Integer));
                if (this.UsuarioReimpressao != null)
                {
                    command.Parameters[command.Parameters.Count - 2].Value = this.dataReimpressao;
                    command.Parameters[command.Parameters.Count - 1].Value = this.UsuarioReimpressao.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 2].Value = null;
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data_impressao", NpgsqlDbType.Timestamp));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_impressao", NpgsqlDbType.Integer));
                if (this.UsuarioImpressao != null)
                {
                    command.Parameters[command.Parameters.Count - 2].Value = this.dataImpressao;
                    command.Parameters[command.Parameters.Count - 1].Value = this.UsuarioImpressao.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 2].Value = null;
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_agrupador_op", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.agrupadorOP;


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_data_encerramento", NpgsqlDbType.Timestamp));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_encerramento", NpgsqlDbType.Integer));
                if (this.usuarioEncerramento != null)
                {
                    command.Parameters[command.Parameters.Count - 2].Value = this.dataEncerramento;
                    command.Parameters[command.Parameters.Count - 1].Value = this.usuarioEncerramento.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 2].Value = null;
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_versao_estrutura_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.versaoEstruturaProduto;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_rastreamento_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.rastrearMP);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_extra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.qtdExtra;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta", NpgsqlDbType.Integer));
                if (this.EstoqueGavetaSaidaOp != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.EstoqueGavetaSaidaOp.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_imprime_relacionadas", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.imprimeOpsRelacionadas);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (ProdutoK==null?(long?) null:ProdutoK.ID);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_quantidade_final", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (QuantidadeFinal);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_pendencia_de_quantidade", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (Convert.ToInt16(PendenciaQuantidade));

                this.idOrdemProducao = Convert.ToInt32(command.ExecuteScalar());

                //Salvar Materiais
                for (int i = 0; i < this.Materiais.Count; i++)
                {
                    this.Materiais[i].Save(ref command);
                }

                //Salvar Recursos
                for (int i = 0; i < this.Recursos.Count; i++)
                {
                    this.Recursos[i].Save(ref command);
                }

                

                //Salvar Pedidos
                for (int i = 0; i < this.Pedidos.Count; i++)
                {
                    this.Pedidos[i].Save(ref command);
                }

                //Salvar Postos de Trabalho
                for (int i = 0; i < this.postosTrabalho.Count; i++)
                {
                    this.postosTrabalho[i].Save(ref command);
                }

                //Salvar Diferenças
                for (int i = 0; i < this.Diferencas.Count; i++)
                {
                    this.Diferencas[i].Save(ref command);
                }

                //Salvar Estoques
                for (int i = 0; i < this.Estoques.Count; i++)
                {
                    this.Estoques[i].Save(ref command);
                }

                //Salvar Historicos
                for (int i = 0; i < this.Historicos.Count; i++)
                {
                    this.Historicos[i].Save(ref command);
                }

                //Salvar Componentes
                for (int i = 0; i < this.ProdutosComponentes.Count; i++)
                {
                    ProdutosComponentes[i].Save(ref command);
                }



                if (opNova)
                {
                    if (ProdutoK == null)
                    {
                        if (Produto.UtilizandoEstoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
                        {
                            Produto.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, false, "OP: " + this.idOrdemProducao);
                            bool tmp = Produto.ControleRevisaoHabilitado;
                            try
                            {
                                Produto.ControleRevisaoHabilitado = false;
                                Produto.DesabilitarJustificativaRevisaoProduto = true;
                                Produto.Save(ref command);
                            }
                            finally
                            {
                                Produto.ControleRevisaoHabilitado = tmp;
                                Produto.DesabilitarJustificativaRevisaoProduto = false;
                            }
                        }
                    }
                    else
                    {
                        if (ProdutoK.UtilizandoEstoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
                        {
                            ProdutoK.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, false, "OP: " + this.idOrdemProducao);
                            bool tmp = ProdutoK.ControleRevisaoHabilitado;
                            try
                            {
                                ProdutoK.ControleRevisaoHabilitado = false;
                                ProdutoK.Save(ref command);
                            }
                            finally
                            {
                                ProdutoK.ControleRevisaoHabilitado = tmp;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {

                throw new Exception("Erro ao salvar a Ordem de Produção.\r\n" + e.Message);
            }
        }

        public void addPostoTrabalho(long idPostoTrabalho, string Codigo, string Nome, string Operacao, bool Rastreamento, bool rastreamentoMP, PostoTrabalhoAcompanhamento Acompanhamento, double tempoProducao, double tempoSetup, int Sequencia)
        {
            this.postosTrabalho.Add(new OrdemProducaoPostoTrabalhoClass(null, idPostoTrabalho, Codigo, Nome, Operacao, Rastreamento, rastreamentoMP, Acompanhamento, tempoProducao, tempoSetup, Sequencia, null, null, null, null, null, null, null, null, null, null, null, null, null, null,null, this, this.conn));
        }

        public void addRecurso(long idRecurso, string postoTrabalhoCodigo, string recursoCodigo, string recursoDescricao, string recursoRev,
            string recursoFamilia, string recursoLoc1, string recursoLoc2, string recursoLoc3, string recursoLoc4,
            TipoRecurso recursoTipo, string recursoCaminhoArquivo, string recursoCaminhoDestino,
            byte[] formularioPreenchido, 
            HierarquiaRecursoEstrutura Hierarquia, long idPostoTrabalho)
        {
            this.Recursos.Add(new OrdemProducaoRecursoClass(null, idRecurso, postoTrabalhoCodigo, recursoCodigo,
                recursoDescricao, recursoRev, recursoFamilia, recursoLoc1, recursoLoc2, recursoLoc3, recursoLoc4,
                recursoTipo,recursoCaminhoArquivo,recursoCaminhoDestino,formularioPreenchido,
                Hierarquia,
                idPostoTrabalho, this, this.conn));
        }
        
        public void addMaterial(MaterialClass material, string Descricao, string unidadeMedida, double Espessura, double Largura, double Comprimento, string tipoAcabamento, string Codigo, double Quantidade, string Familia)
        {
            this.Materiais.Add(new OrdemProducaoMaterialClass(null, material, Descricao, unidadeMedida, Espessura, Largura, Comprimento, tipoAcabamento, Codigo, Quantidade,Familia, this, this.conn));
        }

        public void addPedido(string orderNumber, int orderPos, string produtoCodigo, string produtoDescricao,
            string Variavel1, string valorVariavel1, string Variavel2, string valorVariavel2, string Variavel3, string valorVariavel3, string Variavel4,
            string valorVariavel4, double Quantidade, string tipoDocumento, string numeroDocumento, string revisaoDocumento, string SAF, string CNC,
            string tipoLigacao, string produtoCodigoItemPai, string  produtoDescricaoItemPai, string  produtoAcabamentoItemPai, int semanaEntrega, string Cliente, string Dimensao, int idOrderItemEtiqueta)
        {
            this.Pedidos.Add(new OrdemProducaoPedidoClass(null, orderNumber, orderPos, produtoCodigo, produtoDescricao, Variavel1, valorVariavel1, Variavel2,
                valorVariavel2, Variavel3, valorVariavel3, Variavel4, valorVariavel4, Quantidade, tipoDocumento, numeroDocumento, revisaoDocumento, SAF, CNC,
                tipoLigacao, produtoCodigoItemPai,produtoDescricaoItemPai,produtoAcabamentoItemPai, semanaEntrega, Cliente, Dimensao, idOrderItemEtiqueta, this, this.conn));

        }

        public void addHistorico(AcsUsuarioClass Usuario, DateTime dataHora, string Historico)
        {
            this.Historicos.Add(new OrdemProducaoHistoricoClass(null, Usuario, dataHora, Historico, this, this.conn));
        }

        public void addDiferencas(long idOrdemProducaoPostoTrabalho, AcsUsuarioClass usuario, int idJustificativa, bool? Repor, bool? Reposto, double Quantidade, int? Destino, int? idEstoque)
        {
            this.Diferencas.Add(new OrdemProducaoDiferencaClass(null, idOrdemProducaoPostoTrabalho, usuario, idJustificativa, Repor, Reposto, Quantidade, Destino, idEstoque, this, this.conn));
        }

        public void addEstoque(EstoqueGavetaItemClass gavetaItem, double Quantidade)
        {
            this.Estoques.Add(new OrdemProducaoEstoqueClass(null, gavetaItem, Quantidade, this, this.conn));
        }

        public void addProdutoComponente(long? idProduto, long? idProdutoK,string codigo, string Descricao, double quantidade, string dimensao)
        {
            this.ProdutosComponentes.Add(new OrdemProducaoProdutoComponenteClass(null, idProduto, idProdutoK, codigo, Descricao, quantidade,dimensao, this, this.conn));
        }

        


        public bool preencherOP(ref IWTPostgreNpgsqlCommand command, out string error, ref List<OrdemProducaoErroDocumentoClass> Erros, out List<PedidoItemConfiguradoMaterialClass> itensIncluirPlanoCorte)
        {

            try
            {
                
               itensIncluirPlanoCorte = new List<PedidoItemConfiguradoMaterialClass>();
                //Forma nova de buscar os materiais -  Pedido configurado

                bool materiaisIdentificados = false;

                foreach (OrdemProducaoPedidoClass pedido in this.Pedidos)
                {
                    if (pedido.idOrderItemEtiqueta != null)
                    {
                        OrderItemEtiquetaClass pedidoConfigurado = OrderItemEtiquetaBaseClass.GetEntidade(pedido.idOrderItemEtiqueta.Value, this.UsuarioAtual, this.conn);
                        if (pedidoConfigurado.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Count>0)
                        {
                            materiaisIdentificados = true;
                            foreach (PedidoItemConfiguradoMaterialClass pedidoMaterial in pedidoConfigurado.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta)
                            {
                                this.addMaterial(
                                    pedidoMaterial.Material,
                                    pedidoMaterial.Descricao,
                                    pedidoMaterial.UnidadeMedida.ToString(),
                                    pedidoMaterial.Medida,
                                    pedidoMaterial.MedidaLargura,
                                    pedidoMaterial.MedidaComprimento,
                                    pedidoMaterial.Acabamento.ToString(),
                                    pedidoMaterial.Codigo,
                                    pedidoMaterial.QuantidadeTotal,
                                    pedidoMaterial.FamiliaMaterial.ToString());

                                if (pedidoMaterial.PlanoCorte)
                                {
                                    itensIncluirPlanoCorte.Add(pedidoMaterial);
                                    //this.ItensPlanoCorte.Add(planoCorte.AdicionarItemOP(pedidoMaterial));
                                }
                            }
                        }

                        foreach (OrderItemEtiquetaClass filho in pedidoConfigurado.CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai)
                        {
                            this.addProdutoComponente(
                                filho.Produto != null ? filho.Produto.ID : (long?) null,
                                filho.ProdutoK != null ? filho.ProdutoK.ID : (long?) null,
                                filho.CodigoItem,
                                filho.Descricao,
                                filho.Quantidade,
                                filho.Dimensao);
                        }


                    }
                }

                if (!materiaisIdentificados)
                { 
                    //Forma antiga de buscar os materiais - Cadastro de produto
                    //Utilizado quando a ordem não parte de pedidos.
                    foreach (ProdutoMaterialClass material in this.Produto.Materiais)
                    {
                        this.addMaterial(material.Material, material.Material.Descricao, material.Material.UnidadeMedida.ToString(), material.Material.Medida, material.Material.MedidaLargura, material.Material.MedidaComprimento,
                                         material.Material.Acabamento.ToString(), material.Material.Codigo, material.Quantidade*this.Quantidade, material.Material.FamiliaMaterial.ToString());
                    }
                    
                }



                bool existePostoRastreamentoMaterial = false;
                foreach (ProdutoPostoTrabalhoClass posto in this.Produto.CollectionProdutoPostoTrabalhoClassProduto)
                {
                    this.addPostoTrabalho(posto.PostoTrabalho.ID, posto.PostoTrabalho.Codigo, posto.PostoTrabalho.Nome, posto.PostoTrabalho.OperacaoPosto, posto.PostoTrabalho.Rastreamento, posto.PostoTrabalho.RastreamentoMaterial,
                                          posto.PostoTrabalho.Acompanhamento, posto.TempoProducao, posto.TempoSetup, posto.Sequencia);

                    if (posto.PostoTrabalho.RastreamentoMaterial)
                    {
                        existePostoRastreamentoMaterial = true;
                    }
                }

                if (this.rastrearMP && ! existePostoRastreamentoMaterial)
                {

                    string pedidos = "";
                    foreach (OrdemProducaoPedidoClass pedido in Pedidos)
                    {
                        pedidos = pedidos + pedido.orderNumber + "/" + pedido.orderPos + " - ";
                    }

                    if (pedidos.Length > 0)
                    {
                        pedidos = pedidos.Substring(0, pedidos.Length-3);
                    }

                    throw new Exception(
                        "A OP exigiria rastreamento de materiais mas não existe nenhum posto de trabalho capaz de realizar o rastreamento na estrutura do item. Os pedidos da OP são:" + Environment.NewLine + pedidos);
                }

                foreach (ProdutoRecursoClass recurso in this.Produto.Recursos)
                {
                    string estoque;
                    string corredor;
                    string prateleira;
                    string gaveta;
                    if (recurso.Recurso.Estoque != null)
                    {
                        estoque = recurso.Recurso.Estoque.Identificacao;
                        corredor = recurso.Recurso.EstoqueCorredor.Identificacao;
                        prateleira = recurso.Recurso.EstoquePrateleira.Identificacao;
                        gaveta = recurso.Recurso.EstoqueGaveta.Identificacao;
                    }
                    else
                    {
                        estoque = "SEM ESTOQUE";
                        corredor = "VERIFIQUE TIPO ESTOQUE";
                        prateleira = "";
                        gaveta = "";
                    }



                    this.addRecurso(recurso.Recurso.ID, recurso.Recurso.PostoTrabalho.Codigo, recurso.Recurso.Codigo,
                        recurso.Recurso.Nome, recurso.Recurso.Revisao, recurso.Recurso.FamiliaRecurso.ToString(),
                        estoque, corredor, prateleira, gaveta,
                        recurso.Recurso.Tipo,
                        recurso.Recurso.DiretorioOrigem, recurso.Recurso.DiretorioDestino, null,
                        recurso.Hierarquia, recurso.Recurso.PostoTrabalho.ID);
                }

                //Documentos reserva cópias
                error = "";

                if (IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_COPIA_DOCUMENTO))
                {
                    //List<ProdutoDocumentoTipoClass> docs = this.Produto.GetDocumentosFast(command);
                    List<ProdutoDocumentoTipoClass> docs;
                    if (Quantidade <= 0 && !IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_COPIA_DOC_OP_ZERADA))
                    {
                        docs = new List<ProdutoDocumentoTipoClass>();
                    }
                    else
                    {
                        docs = this.Produto.Documentos;
                    }

                    foreach (ProdutoDocumentoTipoClass documento in docs )
                    {
                        if (this.Grupo != null)
                        {
                            string listaPedidos = "";
                            string erroOp;
                            if (
                                !this.Grupo.addDocumento(documento.DocumentoTipoFamilia.ID, documento.DocumentoTipoFamilia.DocumentoTipoDescricao,
                                                         documento.DocumentoTipoFamilia.DocumentoTipo.Identificacao, documento.DocumentoTipoFamilia.FamiliaDocumento.Codigo, documento.DocumentoTipoFamilia.DocumentoTipo.RevisaoAtual, this,
                                                         ref command, out erroOp, ref Erros))
                            {

                                if (listaPedidos == "")
                                {
                                    foreach (OrdemProducaoPedidoClass ped in this.Pedidos)
                                    {
                                        listaPedidos += ped.orderNumber + "/" + ped.orderPos + " - " +
                                                        ped.produtoCodigoItemPai + "\r\n";
                                    }
                                }

                                error += erroOp + "\r\n" + listaPedidos;

                                //Retira essa OP de todos os documentos
                                
                                foreach (ProdutoDocumentoTipoClass documento2 in docs)
                                {
                                    if (this.Grupo.Documentos.ContainsKey(documento2.DocumentoTipoFamilia.ID))
                                    {
                                        this.Grupo.Documentos[documento2.DocumentoTipoFamilia.ID].
                                            removeOrdemProducaoUtilizando(this, command);
                                    }

                                }

                                return false;


                            }
                        }
                        else
                        {
                            throw new Exception("A OP não possui grupo definido");
                        }
                    }
                }


                return true;


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao preencher a OP \r\n" + e.Message);
            }
        }

        public void Cancelar()
        {
            IWTPostgreNpgsqlCommand command = null;

            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                if (this.dataImpressao.HasValue)
                {
                    CancelamentoOPForm form = new CancelamentoOPForm(this, "CANCELAMENTO");
                    form.ShowDialog();

                    if (form.Abortar)
                    {
                        throw new Exception("Operação abortada pelo usuário.");
                    }
                }

                if (this.Situacao == 2 || this.Situacao == 3)
                {
                    throw new Exception("Não é possível cancelar uma op encerrada ou já cancelada.");
                }

                this.Situacao = 3;

               

                command.CommandText = "UPDATE order_item_etiqueta SET oie_ordem_producao_impressa=0,oie_ordem_producao_impressa_data=NULL WHERE id_order_item_etiqueta=:id_order_item_etiqueta ";
                foreach (OrdemProducaoPedidoClass pedido in this.Pedidos)
                {


                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = pedido.idOrderItemEtiqueta;
                    command.ExecuteNonQuery();

                }

                //Devolução estoque
                foreach (OrdemProducaoEstoqueClass estoque in this.Estoques)
                {
                    //EstoqueClass.lancaMovimentoEstoque(estoque.idEstoqueProduto, estoque.Quantidade, false, "Cancelamento de Ordem de Produção", this.Usuario, ref command);
                }
                this.addHistorico(this.UsuarioAtual, Configurations.DataIndependenteClass.GetData(), "Ordem Cancelada");

                this.Save(ref command);

                this.Grupo.liberarCopias(ref command);

                this.apagaRecursosCNC();

                command.Transaction.Commit();


            }
            catch (Exception e)
            {
                if (command != null && command.Transaction!=null)
                {
                    command.Transaction.Rollback();

                }
                throw new Exception("Erro ao realizar o cancelamento.\r\n" + e.Message);
            }
        }

        public void Encerrar(AcsUsuarioClass usuario, bool exibirTelaCancelamento, bool encerramentoManual)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();

                command.Transaction = this.conn.BeginTransaction();

                if (exibirTelaCancelamento)
                {
                    CancelamentoOPForm form = new CancelamentoOPForm(this, "ENCERRAMENTO");
                    form.ShowDialog();

                    if (form.Abortar)
                    {
                        throw new Exception("Operação abortada pelo usuário.");
                    }
                }

                if (this.Situacao == 2 || this.Situacao == 3)
                {
                    throw new Exception("Não é possível encerrar uma op encerrada ou já cancelada.");
                }

                if (Situacao == Convert.ToInt16(StatusOrdemProducao.AguardandoServicoExterno))
                {
                    throw new ExcecaoTratada("A ordem de produção está em situação de \"Aguardando Serviço Externo\" e por isso não pode ser encerrada.");
                }

                this.Encerrar(ref command, usuario, encerramentoManual);

                command.Transaction.Commit();

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }

                if (this.idOrdemProducao.HasValue)
                {
                    this.Load(idOrdemProducao.Value, Grupo, UsuarioAtual, conn, iOrdemProducaoFactory);
                }

                throw e;
            }
        }

        public void Encerrar(ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario, bool encerramentoManual)
        {
            try
            {


                
                if (this.Produto.CollectionProdutoBloqueioQualidadeClassProduto.Any(a => a.Ativo))
                {
                    if (!idOrdemProducao.HasValue)
                    {
                        throw new ExcecaoTratada("Impossível carregar a OP pois ela ainda não foi salva, consulte a equipe IWT");
                    }
                    Entidades.OrdemProducaoClass opEntidade = Entidades.OrdemProducaoClass.GetEntidade(idOrdemProducao.Value, usuario, command.Connection);
                    AutorizacaoQualidadeForm form = new AutorizacaoQualidadeForm(opEntidade, command);
                    form.ShowDialog();
                    if (!form.Liberado)
                    {
                        throw new ExcecaoTratada("Não é possivel encerrar a OP pois ela possui bloqueio de qualidade e não foi autorizado pela qualidade");
                    }
                }



                if (this.Situacao == 2 || this.Situacao == 3)
                {
                    throw new Exception("Não é possível encerrar uma OP encerrada ou já cancelada.");
                }

                if (Situacao == Convert.ToInt16(StatusOrdemProducao.AguardandoServicoExterno))
                {
                    throw new ExcecaoTratada("A ordem de produção está em situação de \"Aguardando Serviço Externo\" e por isso não pode ser encerrada.");
                }

                if (this.Suspensa)
                {
                    throw new Exception("Não é possível encerrar uma OP Suspensa.");
                }

                this.postosTrabalho.Sort(new OrdemProducaoPostoTrabalhoComparer());
                this.QuantidadeFinal = this.Quantidade;

                for (int i = 0; i < postosTrabalho.Count; i++)
                {
                    if (this.postosTrabalho[i].qtdSaida != null)
                    {
                        QuantidadeFinal = (double)this.postosTrabalho[i].qtdSaida;
                    }

                }


                if (Math.Abs(QuantidadeFinal.Value - Quantidade) > 0.00001)
                {
                    PendenciaQuantidade = true;
                }





                //Verifica se lotes de materiais foram indicados caso necessário
                if (this.rastrearMP)
                {
                    bool lotesIndicados = false;

                    foreach (OrdemProducaoPostoTrabalhoClass postoTrabalhoClass in postosTrabalho)
                    {
                        if (!lotesIndicados && postoTrabalhoClass.Producao!=null)
                        {
                            
                            foreach (OrdemProducaoPostoTrabalhoProducaoClass producaoClass in postoTrabalhoClass.Producao)
                            {
                                if (producaoClass.LotesMP != null && producaoClass.LotesMP.Count > 0)
                                {
                                    lotesIndicados = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!lotesIndicados)
                    {
                        throw new Exception(
                            "Não é possível encerrar uma Op que possui rastreamento de materiais sem indicar nenhum lote de material na produção.");
                    }
                }


                //Encerra

                if (!this.Pendencia)
                {

                    this.Situacao = 2;
                    if (encerramentoManual)
                    {
                        this.addHistorico(usuario, Configurations.DataIndependenteClass.GetData(), "Ordem Encerrada Manualmente");
                    }
                    else
                    {
                        this.addHistorico(usuario, Configurations.DataIndependenteClass.GetData(), "Ordem Encerrada");
                    }
                    this.usuarioEncerramento = usuario;
                    this.dataEncerramento = Configurations.DataIndependenteClass.GetData();
                    this.Grupo.liberarCopias(ref command);

                }
                else
                {
                    this.addHistorico(usuario, Configurations.DataIndependenteClass.GetData(), "Ordem não Encerrada pois contêm pendências");
                }

                
                
                try
                {
                    if (!QuantidadeFinal.HasValue)
                    {
                        throw new Exception("Encerramento de OP sem quantidade final. Informe a equipe IWT");

                    }

                    double razaoBaixaMateriais = 1;

                    if (Math.Abs(this.quantidadePedidos) > 0.00001 && (Math.Abs(this.QuantidadeFinal.Value - Quantidade) > 0.00001) || (quantidadeEstoque > 0))
                    {
                        if (quantidadePedidos > 0)
                        {
                            razaoBaixaMateriais = Math.Round(this.QuantidadeFinal.Value / this.quantidadePedidos, 5);
                        }
                        else
                        {
                            razaoBaixaMateriais = Math.Round(this.QuantidadeFinal.Value / this.Quantidade, 5);
                        }
                    }

                    foreach (OrdemProducaoMaterialClass mat in this.Materiais.Where(a=>a.Quantidade>0))
                    {
                        double qtdBaixar = Math.Round(razaoBaixaMateriais*mat.Quantidade, 5);

                        EstoqueMovimentacao.LancaBaixaEstoqueAgrupadoMaterial(mat.Material, -1 * qtdBaixar,
                                                                              "Baixa pelo encerramento da OP",
                                                                              "OP Nº " + this.idOrdemProducao,
                                                                              this.UsuarioAtual, false, ref command, false);

                    }

                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao realizar a baixa de estoque dos materiais.\r\n" + e.Message, e);
                }

                if (this.QuantidadeFinal.Value > 0)
                {
                    EnviaItemEstoqueForm formEstoque;
                    if (this.ProdutoK!=null)
                    {

                        formEstoque = new EnviaItemEstoqueForm(EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK,
                                                               this.produtoCodigo, false, this.QuantidadeFinal.Value,
                                                               this.Produto.UnidadeMedida == null ? "" : this.Produto.UnidadeMedida.ToString(), true, "Encerramento da OP Nº "+this.idOrdemProducao,
                                                               this.ProdutoK, false, null, this.UsuarioAtual,
                                                               this.conn, ref command,
                                                               "OP Nº " + this.idOrdemProducao);

                    }
                    else
                    {
                        formEstoque = new EnviaItemEstoqueForm(EnviaItemEstoqueForm.tipoUtilizacao.Produto,
                                                               this.produtoCodigo, false, this.QuantidadeFinal.Value,
                                                               this.Produto.UnidadeMedida==null?"": this.Produto.UnidadeMedida.ToString(), true, "Encerramento da OP Nº " + this.idOrdemProducao,
                                                               this.Produto, false, null, this.UsuarioAtual,
                                                               this.conn, ref command,
                                                               "OP Nº " + this.idOrdemProducao);
                    }

                    formEstoque.ShowDialog();

                    if (!formEstoque.Salvo)
                    {
                        throw new Exception("Erro ao encerrar a OP, não foi definido o local de estoque para o envio dos produtos.");
                    }

                    this.EstoqueGavetaSaidaOp = formEstoque.GavetaSelecionada;
                }

                //Verifica se tem recursos do tipo de formulário e armazena junto com a op o formulário preenchido
                if (this.Recursos.Count(a => a.recursoTipo == TipoRecurso.Formulario) > 0)
                {
                    foreach (OrdemProducaoRecursoClass recursoClass in this.Recursos.Where(a => a.recursoTipo == TipoRecurso.Formulario))
                    {
                       OpRecursoUploadFormularioForm form = new OpRecursoUploadFormularioForm(recursoClass.ToString());
                       form.ShowDialog();

                       recursoClass.formularioPreenchido = form.NovoDocumentoScaneado;
                    }
                }



                this.Save(ref command);

                this.apagaRecursosCNC();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o encerramento.\r\n" + e.Message);
            }
        }

        

        internal void setEmProducao()
        {
            if (this.Situacao == 0)
            {
                this.addHistorico(this.UsuarioAtual, Configurations.DataIndependenteClass.GetData(), "Ordem entrou em produção");
                this.Situacao = 1;
            }
            else
            {
                if (this.Situacao == 2 || this.Situacao == 3)
                {
                    throw new Exception("Não é possível definir como em produção uma OP que já está encerrada ou cancelada.");
                }

                if (Situacao == Convert.ToInt16(StatusOrdemProducao.AguardandoServicoExterno))
                {
                    throw new ExcecaoTratada("A ordem de produção está em situação de \"Aguardando Serviço Externo\" e por isso não pode ser colocada em produção.");
                }
            }
        }

        public void SetAguardandoServicoExterno()
        {
            if (this.Situacao == Convert.ToInt16(StatusOrdemProducao.AguardandoInicioProducao) || this.Situacao == Convert.ToInt16(StatusOrdemProducao.Producao))
            {
                this.addHistorico(this.UsuarioAtual, Configurations.DataIndependenteClass.GetData(), "Ordem entrou em Aguardando Serviço Externo");
                this.Situacao = Convert.ToInt16(StatusOrdemProducao.AguardandoServicoExterno);
            }
            else
            {
                if (this.Situacao == 2 || this.Situacao == 3)
                {
                    throw new Exception("Não é possível definir como em produção uma OP que já está encerrada ou cancelada.");
                }

                if (Situacao == Convert.ToInt16(StatusOrdemProducao.AguardandoServicoExterno))
                {
                    throw new ExcecaoTratada("A ordem de produção está em situação de \"Aguardando Serviço Externo\" e por isso não pode ser colocada em produção.");
                }
            }
        }

        public void setPendencia(bool pendencia, AcsUsuarioClass usuario)
        {
            this.Pendencia = pendencia;
            string historico = "";
            if (this.Pendencia)
            {
                historico = "Ordem marcada como contendo pendências";
            }
            else
            {
                historico = "Retirada as pendências da ordem";
            }

            this.addHistorico(usuario, Configurations.DataIndependenteClass.GetData(), historico);
        }

        public void setSuspensa(bool suspensa, AcsUsuarioClass usuario)
        {
            this.Suspensa = suspensa;

            string historico = "";
            if (this.Suspensa)
            {
                historico = "Ordem colocada em suspensão";
            }
            else
            {
                historico = "Ordem retirada da suspensão";
            }

            this.addHistorico(usuario, Configurations.DataIndependenteClass.GetData(), historico);
        }

        public string resolverPendencia(AcsUsuarioClass usuario)
        {
            try
            {
                if (this.Pendencia)
                {
                    this.postosTrabalho.Sort(new OrdemProducaoPostoTrabalhoComparer());

                    double ultimaQtd = this.Quantidade;
                    foreach (OrdemProducaoPostoTrabalhoClass posto in this.postosTrabalho)
                    {
                        if (posto.qtdSaida != null)
                        {
                            ultimaQtd = posto.qtdSaida.Value;
                        }
                    }

                    if (ultimaQtd >= this.Quantidade)
                    {
                        this.setPendencia(false, usuario);
                        return "A pendência foi resolvida automaticamente pois a quantidade de saída do último posto ao qual a op passou é igual ou maior a quantidade prevista inicialmente.";
                    }

                    if (ultimaQtd < this.Quantidade)
                    {
                        JustificarQtdMenorForm form = new JustificarQtdMenorForm(this.conn, true);
                        form.ShowDialog();

                        if (form.repor.Value)
                        {
                            this.addDiferencas(this.postosTrabalho[this.postosTrabalho.Count - 1].idOrdemProducaoPostoTrabalho.Value, usuario, form.idJustificativa, true, false, this.Quantidade - ultimaQtd, null, null);
                        }
                        this.setPendencia(false, usuario);
                    }

                    return "";
                }
                else
                {
                    throw new Exception("A op selecionada não possui pendencias.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao resolver a pendência.\r\n" + e.Message);
            }

        }

        public void retirarSuspensao(AcsUsuarioClass usuario)
        {
            try
            {
                if (this.Suspensa)
                {

                    this.postosTrabalho.Sort(new OrdemProducaoPostoTrabalhoComparer());

                    double ultimaQtd = this.Quantidade;
                    foreach (OrdemProducaoPostoTrabalhoClass posto in this.postosTrabalho)
                    {
                        if (posto.qtdSaida != null)
                        {
                            ultimaQtd = posto.qtdSaida.Value;
                        }
                    }

                    if (ultimaQtd < this.Quantidade)
                    {
                        JustificarQtdMenorForm form = new JustificarQtdMenorForm(this.conn, true);
                        form.ShowDialog();

                        if (form.repor.Value)
                        {
                            this.addDiferencas(this.postosTrabalho[this.postosTrabalho.Count - 1].idOrdemProducaoPostoTrabalho.Value, usuario, form.idJustificativa, true, false, this.Quantidade - ultimaQtd, null, null);
                        }

                    }


                    this.setPendencia(false, usuario);
                    this.setSuspensa(false, usuario);
             
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao retirar a suspensão.\r\n" + e.Message);
            }
        }

        public void setReimpressao(AcsUsuarioClass usuario)
        {
            this.addHistorico(this.UsuarioAtual, Configurations.DataIndependenteClass.GetData(), "Ordem reimpressa");
            this.UsuarioReimpressao = usuario;
            this.dataReimpressao = Configurations.DataIndependenteClass.GetData();
        }

        public void setImpressao(AcsUsuarioClass usuario)
        {
            this.UsuarioImpressao = usuario;
            this.dataImpressao = Configurations.DataIndependenteClass.GetData();
            this.addHistorico(this.UsuarioAtual, Configurations.DataIndependenteClass.GetData(), "Ordem impressa");
        }

        internal bool utilizaDocumento(long idDocumentoTipoFamilia, IWTPostgreNpgsqlCommand command)
        {
            //List<ProdutoDocumentoTipoClass> docs = this.Produto.GetDocumentosFast(command);
            List<ProdutoDocumentoTipoClass> docs = this.Produto.Documentos;
            foreach (ProdutoDocumentoTipoClass doc in docs)
            {
                if (doc.DocumentoTipoFamilia.ID == idDocumentoTipoFamilia)
                {
                    return true;
                }
            }
            return false;

        }

        private void loadDocumentosSemGrupo()
        {
            try
            {
                this._internalDocumentos = new List<OrdemProducaoDocumentoClass>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao_documento.id_ordem_producao_documento, " +
                    "  public.ordem_producao_documento.id_documento_copia, " +
                    "  public.ordem_producao_documento.id_documento_tipo_familia, " +
                    "  public.ordem_producao_documento.opd_documento_descricao, " +
                    "  public.ordem_producao_documento.opd_documento_copia, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_codigo, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_tipo, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_revisao, " +
                    "  public.ordem_producao_documento.opd_documento_l1, " +
                    "  public.ordem_producao_documento.opd_documento_l2, " +
                    "  public.ordem_producao_documento.opd_documento_l3, " +
                    "  public.ordem_producao_documento.opd_documento_l4, " +
                    "  doc_ocupada, " +
                    "  public.ordem_producao_documento.opd_tipo_validacao, "+
                    "  public.ordem_producao_documento.opd_documento_pedido_familia, "+
                    "  public.ordem_producao_documento.opd_documento_pedido, "+
                    "  public.ordem_producao_documento.opd_documento_pedido_revisao, " +
                    "  public.ordem_producao_documento.opd_aviso "+
                    "  CASE WHEN liberacao_documento.id_liberacao_documento IS NOT NULL THEN 1 ELSE 0 END as liberacao_forcada "+
                    "FROM " +
                    "  public.ordem_producao_documento_op " +
                    "  INNER JOIN public.ordem_producao_documento ON (public.ordem_producao_documento_op.id_ordem_producao_documento = public.ordem_producao_documento.id_ordem_producao_documento) " +
                    "  INNER JOIN documento_copia ON documento_copia.id_documento_copia= ordem_producao_documento.id_documento_copia " +
                    "  LEFT JOIN liberacao_documento ON  ordem_producao_documento.id_ordem_producao_documento = liberacao_documento.id_ordem_producao_documento "+

                    "WHERE " +
                    "  public.ordem_producao_documento_op.id_ordem_producao = :id_ordem_producao";


                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducao;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    bool liberacaoForcada = false;
                    if (read["liberacao_forcada"] != DBNull.Value)
                    {
                        Convert.ToBoolean(Convert.ToInt16(read["liberacao_forcada"]));
                    }

                    this._internalDocumentos.Add(new OrdemProducaoDocumentoClass(Convert.ToInt32(read["id_ordem_producao_documento"]),
                                         Convert.ToInt32(read["id_documento_copia"]), Convert.ToInt32(read["id_documento_tipo_familia"]), read["opd_documento_descricao"].ToString(),
                                         read["opd_documento_copia"].ToString(), read["opd_documento_l1"].ToString(), read["opd_documento_l2"].ToString(),
                                         read["opd_documento_l3"].ToString(), read["opd_documento_l4"].ToString(),
                                         read["opd_documento_tipo_codigo"].ToString(),
                                         read["opd_documento_tipo_tipo"].ToString(), read["opd_documento_tipo_revisao"].ToString(),
                                         Convert.ToBoolean(Convert.ToInt16(read["doc_ocupada"])),
                                         liberacaoForcada,
                                         (TipoValidacaoDocumento)Enum.ToObject(typeof(TipoValidacaoDocumento), read["opd_tipo_validacao"]),
                                         read["opd_documento_pedido_familia"].ToString(),
                                         read["opd_documento_pedido"].ToString(),
                                         read["opd_documento_pedido_revisao"].ToString(),
                                         read["opd_aviso"].ToString(),
                                         null, this.conn));

                }
                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar os documentos utilizados na OP sem o grupo.\r\n" + e.Message, e);
            }
        }

        internal bool validarCodigoBarras(string barcode)
        {
            try
            {
                if (this.idOrdemProducao == null)
                {
                    return false;
                }

                barcode = barcode.Trim().Replace("\r", "").Replace("\n", "").Replace('}', '|');
                if (barcode.StartsWith("OP|"))
                {
                    int id = int.Parse(barcode.Substring((barcode.IndexOf("|") + 1)));
                    if (id == this.idOrdemProducao.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar o código de barras.\r\n" + e.Message, e);
            }
        }

        public List<string> getHistoricoPostos()
        {
            try
            {
                List<string> toRet = new List<string>();
                this.postosTrabalho.Sort(new OrdemProducaoPostoTrabalhoComparer());

                foreach (OrdemProducaoPostoTrabalhoClass posto in this.postosTrabalho.Where(a=>a.Acompanhamento!=PostoTrabalhoAcompanhamento.SemAcompanhamento))
                {
                    switch ( posto.Acompanhamento)
                    {
                        case PostoTrabalhoAcompanhamento.UmTempo:
                        case PostoTrabalhoAcompanhamento.UmTempoComQtd:
                            if (posto.Tempo1 != null)
                            {
                                toRet.Add(posto.Tempo1.Value.ToString("dd/MM/yyyy - HH:mm:ss") + " : " + "Passou no posto " + posto.Codigo);
                            }
                            else
                            {
                                return toRet;
                            }
                            break;

                        case PostoTrabalhoAcompanhamento.DoisTempos:
                            if (posto.Tempo2 != null)
                            {
                                toRet.Add(posto.Tempo2.Value.ToString("dd/MM/yyyy - HH:mm:ss") + " : " + "Saiu do posto " + posto.Codigo);
                            }
                            else
                            {
                                if (posto.Tempo1 != null)
                                {
                                    toRet.Add(posto.Tempo1.Value.ToString("dd/MM/yyyy - HH:mm:ss") + " : " + "Entrou no posto " + posto.Codigo);
                                }
                                else
                                {
                                    return toRet;
                                }
                            }
                            break;
                        case PostoTrabalhoAcompanhamento.TresTempos:
                            if (posto.Tempo3 != null)
                            {
                                toRet.Add(posto.Tempo3.Value.ToString("dd/MM/yyyy - HH:mm:ss") + " : " + "Saiu do posto " + posto.Codigo);
                            }
                            else
                            {
                                if (posto.Tempo2 != null)
                                {
                                    toRet.Add(posto.Tempo2.Value.ToString("dd/MM/yyyy - HH:mm:ss") + " : " + "Terminou o setup do posto " + posto.Codigo);
                                }
                                else
                                {
                                    if (posto.Tempo1 != null)
                                    {
                                        toRet.Add(posto.Tempo1.Value.ToString("dd/MM/yyyy - HH:mm:ss") + " : " + "Entrou no posto " + posto.Codigo);
                                    }
                                    else
                                    {
                                        return toRet;
                                    }
                                }
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o histórico de postos da OP\r\n" + e.Message, e);
            }
        }

        public void apagaRecursosCNC()
        {

            foreach (OrdemProducaoRecursoClass recurso in Recursos.Where(a => a.recursoTipo == TipoRecurso.CNC))
            {
                try
                {
                    if (File.Exists(recurso.recursoCaminhoArquivo) && Directory.Exists(recurso.recursoCaminhoDestino))
                    {
                        FileInfo f = new FileInfo(recurso.recursoCaminhoArquivo);
                        if (File.Exists(recurso.recursoCaminhoDestino + "\\" + f.Name))
                        {
                            File.Delete(recurso.recursoCaminhoDestino + "\\" + f.Name);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao apagar o recurso do tipo CNC: " + recurso.recursoCodigo + ".\r\n" + e.Message, e);
                }

            }
        }

        public List<OrdemProducaoClass> carregaOpsRelacionadas()
        {
            try
            {
                SortedDictionary<int, OrdemProducaoClass> toRet = new SortedDictionary<int, OrdemProducaoClass>();
                //Busca no banco de dados todas as ops relacionadas a todos os pedidos da op em questão
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao_pedido.id_ordem_producao " +
                    "FROM " +
                    "  public.ordem_producao_pedido " +
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_pedido.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "WHERE " +
                    "  public.ordem_producao_pedido.opp_order_number = :opp_order_number AND  " +
                    "  public.ordem_producao_pedido.opp_order_pos = :opp_order_pos  AND " +
                    "  public.ordem_producao.orp_situacao <> 3 ";


                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_order_number", NpgsqlDbType.Varchar));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_order_pos", NpgsqlDbType.Integer));
                foreach (OrdemProducaoPedidoClass pedido in Pedidos)
                {
                    command.Parameters["opp_order_number"].Value = pedido.orderNumber;
                    command.Parameters["opp_order_pos"].Value = pedido.orderPos;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    while (read.Read())
                    {
                        int idOp = Convert.ToInt32(read["id_ordem_producao"]);if (!toRet.ContainsKey(idOp))
                        {
                            toRet.Add(idOp, this.iOrdemProducaoFactory.getInstanceOp(idOp, null, this.UsuarioAtual, this.conn));
                        }
                    }

                    read.Close();
                }
                return new List<OrdemProducaoClass>(toRet.Values);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as ops relacionadas.\r\n" + e.Message, e);
            }
        }

        public void AtualizarItensPlanoCorte()
        {
            if (ItensPlanoCorte == null) return;
            foreach (PlanoCorteItemOpClass planoCorteItemOpClass in ItensPlanoCorte)
            {
                planoCorteItemOpClass.SetOP(this.idOrdemProducao.Value);
            }
        }
    
    }
}
