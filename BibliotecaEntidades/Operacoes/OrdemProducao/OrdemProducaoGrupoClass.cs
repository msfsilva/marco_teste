using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public abstract class OrdemProducaoGrupoClass
    {
        public  List<OrdemProducaoClass> OPs { private set;  get; }
        public Dictionary<long, OrdemProducaoDocumentoClass> Documentos { private set; get; }
        public long? idOrdemProducaoGrupo { private set; get; }
        internal  bool opsCarregadas { private set; get; }
        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;
        private IOrdemProducaoFactory iOrdemProducaoFactory;


        public OrdemProducaoGrupoClass(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario, IOrdemProducaoFactory iOrdemProducaoFactory)
        {
            this.OPs = new List<OrdemProducaoClass>();
            this.Documentos = new Dictionary<long, OrdemProducaoDocumentoClass>();
            this.conn = conn;
            this.idOrdemProducaoGrupo = null;
            this.Usuario = Usuario;
            this.iOrdemProducaoFactory = iOrdemProducaoFactory;
        }

        public OrdemProducaoGrupoClass(long idOrdemProducaoGrupo, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario, OrdemProducaoClass OPAtual, bool loadAllOps, IOrdemProducaoFactory iOrdemProducaoFactory)
        {
            try
            {
                this.conn = conn;
                this.Usuario = Usuario;
                this.iOrdemProducaoFactory = iOrdemProducaoFactory;
                this.idOrdemProducaoGrupo = idOrdemProducaoGrupo;

                this.loadDocuments();

                this.OPs = new List<OrdemProducaoClass>();
                if (OPAtual != null)
                {
                    this.OPs.Add(OPAtual);
                }

                if (loadAllOps)
                {
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    this.loadOps(ref command);
                    this.opsCarregadas = true;
                }
                else
                {
                    this.opsCarregadas = false;
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o conteúdo do grupo.\r\n" + e.Message);
            }
        }
      
        public bool addDocumento(long idDocumentoTipoFamilia,string Descricao, string Identificacao, string Familia, string Revisao, OrdemProducaoClass OP,  ref IWTPostgreNpgsqlCommand command, out string errorMsg, ref List<OrdemProducaoErroDocumentoClass> Erros )
        {
            bool validacaoRevisaoDocumentosHabilitada = Configurations.IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.VALIDACAO_REVISAO_DOCUMENTO_HABILITADA);
            errorMsg = "";
            if (!this.Documentos.ContainsKey(idDocumentoTipoFamilia))
            {

                command.CommandText =
                    "SELECT  " +
                    "  public.documento_tipo_familia.id_documento_tipo_familia, " +
                    "  public.documento_copia.doc_identificacao, " +
                    "  public.documento_copia.id_documento_copia, " +
                    "  public.estoque.est_identificacao, " +
                    "  public.estoque_corredor.esc_identificacao, " +
                    "  public.estoque_prateleira.esp_identificacao, " +
                    "  public.estoque_gaveta.esg_identificacao, " +
                    "  public.documento_tipo_familia.dtf_tipo_validacao, " +
                    "  public.documento_tipo_familia.dtf_documento_pedido_familia, "+
                    "  public.documento_tipo_familia.dtf_documento_pedido, "+
                    "  public.documento_tipo_familia.dtf_documento_pedido_revisao "+
                    "FROM " +
                    "  public.documento_tipo_familia " +
                    "  INNER JOIN public.documento_tipo ON (public.documento_tipo_familia.id_documento_tipo = public.documento_tipo.id_documento_tipo) " +
                    "  INNER JOIN public.familia_documento ON (public.documento_tipo_familia.id_familia_documento = public.familia_documento.id_familia_documento) " +
                    "  INNER JOIN public.documento_copia ON (public.documento_tipo_familia.id_documento_tipo_familia = public.documento_copia.id_documento_tipo_familia) " +
                    "  INNER JOIN public.estoque_gaveta_item ON (public.documento_copia.id_documento_copia = public.estoque_gaveta_item.id_documento_copia) " +
                    "  INNER JOIN public.estoque_gaveta ON (public.estoque_gaveta_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                    "  INNER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) " +
                    "  INNER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) " +
                    "  INNER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) " +
                    "WHERE " +
                    "  public.documento_tipo_familia.id_documento_tipo_familia =:id_documento_tipo_familia AND  " +
                    "  public.documento_copia.doc_ativa <> 0 AND " +
                    "  public.documento_copia.doc_ocupada = 0 AND " +
                    "  public.documento_copia.doc_permite_utilizar_op = 1 ";


                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo_familia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idDocumentoTipoFamilia;
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    string copia = read["doc_identificacao"].ToString();
                    string Loc1 = read["est_identificacao"].ToString();
                    string Loc2 = read["esc_identificacao"].ToString();
                    string Loc3 = read["esp_identificacao"].ToString();
                    string Loc4 = read["esg_identificacao"].ToString();
                    int idDocumentoCopia = Convert.ToInt32(read["id_documento_copia"]);

                    TipoValidacaoDocumento TipoValidacao = (TipoValidacaoDocumento)Enum.ToObject(typeof(TipoValidacaoDocumento), read["dtf_tipo_validacao"]);
                    string DocumentoPedidoFamilia = read["dtf_documento_pedido_familia"].ToString();
                    string DocumentoPedido = read["dtf_documento_pedido"].ToString();
                    string DocumentoPedidoRevisao = read["dtf_documento_pedido_revisao"].ToString();
                    read.Close();

                    string avisoDocumento = "";
                    if (validacaoRevisaoDocumentosHabilitada)
                    {
                        if (TipoValidacao != TipoValidacaoDocumento.NaoValidar)
                        {
                            //Realizar validação de documento
                            //Busca o documento nos pedidos para verificar se bate a revisão
                            command.CommandText =
                                "SELECT  " +
                                "  COUNT(public.pedido_documento.id_pedido_documento) AS resultado " +
                                "FROM " +
                                "  public.pedido_documento " +
                                "  INNER JOIN public.pedido_item ON (public.pedido_documento.id_pedido_item = public.pedido_item.id_pedido_item) " +
                                "  INNER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                                "WHERE " +
                                "  public.order_item_etiqueta.id_order_item_etiqueta = :id_order_item_etiqueta AND  " +
                                "  public.pedido_documento.peo_tipo = :peo_tipo AND  " +
                                "  public.pedido_documento.peo_codigo = :peo_codigo AND  " +
                                "  public.pedido_documento.peo_revisao = :peo_revisao ";

                            command.Parameters.Clear();

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_tipo", NpgsqlDbType.Varchar));
                            command.Parameters[command.Parameters.Count - 1].Value = DocumentoPedidoFamilia;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_codigo", NpgsqlDbType.Varchar));
                            command.Parameters[command.Parameters.Count - 1].Value = DocumentoPedido;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_revisao", NpgsqlDbType.Varchar));
                            command.Parameters[command.Parameters.Count - 1].Value = DocumentoPedidoRevisao;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));

                            foreach (OrdemProducaoPedidoClass pedido in OP.Pedidos)
                            {
                                command.Parameters["id_order_item_etiqueta"].Value = pedido.idOrderItemEtiqueta;
                                int qtdEncontrada = Convert.ToInt32(command.ExecuteScalar());

                                if (qtdEncontrada == 0)
                                {
                                    if (!this.validaDocumentosItemFilho(pedido.orderNumber, pedido.orderPos, pedido.idOrderItemEtiqueta.Value, OP.idProduto, pedido.produtoCodigo))
                                    {
                                        if (TipoValidacao == TipoValidacaoDocumento.ValidarBloqueio)
                                        {
                                            errorMsg = "Não foi encontrado no pedido do cliente (" + pedido.orderNumber +
                                                       "/" + pedido.orderPos + ") o documento " + DocumentoPedidoFamilia +
                                                       " " + DocumentoPedido + " " + DocumentoPedidoRevisao;
                                            Erros.Add(new OrdemProducaoErroDocumentoClass(
                                                          pedido.orderNumber + "/" + pedido.orderPos,
                                                          pedido.Cliente,
                                                          pedido.produtoCodigoItemPai,
                                                          pedido.produtoCodigo,
                                                          TipoErroDocumentoOrdemProducao.ValidacaoRevisao,
                                                          idDocumentoTipoFamilia,
                                                          Familia,
                                                          Identificacao,
                                                          Revisao,
                                                          errorMsg,
                                                          conn
                                                          ));
                                            return false;
                                        }
                                        else
                                        {
                                            avisoDocumento = "Não foi encontrado no pedido do cliente (" +
                                                             pedido.orderNumber + "/" + pedido.orderPos + ") o documento " +
                                                             DocumentoPedidoFamilia + " " + DocumentoPedido + " " +
                                                             DocumentoPedidoRevisao;
                                        }
                                    }
                                }
                            }




                        }
                    }


              
                    this.Documentos.Add(
                        idDocumentoTipoFamilia, 
                        new OrdemProducaoDocumentoClass(
                            null,
                            idDocumentoCopia,
                            idDocumentoTipoFamilia,
                            Descricao,
                            copia,
                            Loc1,
                            Loc2,
                            Loc3,
                            Loc4,
                            Identificacao,
                            Familia,
                            Revisao,
                            true,
                            false,
                            TipoValidacao,
                            DocumentoPedidoFamilia,
                            DocumentoPedido,
                            DocumentoPedidoRevisao,
                            avisoDocumento,
                            this,
                            this.conn
                            )
                        );
                    
                }
                else
                {
                    //throw new Exception("Não existem documentos do tipo " + documento.Codigo + " livres para incluir na OP.");
                    errorMsg = "Não existem documentos do tipo " + Familia + " " + Identificacao + " " + Revisao + " livres que permitem a utilização em op para os seguintes pedidos: ";
                    foreach (OrdemProducaoPedidoClass pedido in OP.Pedidos)
                    {
                        Erros.Add(
                            new OrdemProducaoErroDocumentoClass(
                                pedido.orderNumber+"/"+pedido.orderPos,
                                pedido.Cliente,
                                pedido.produtoCodigoItemPai,
                                pedido.produtoCodigo,
                                TipoErroDocumentoOrdemProducao.FaltaDocumento,
                                idDocumentoTipoFamilia,
                                Familia,
                                Identificacao,
                                Revisao,
                                "",
                                conn
                                ));
                    }
                    return false;
                }

                
            }

            this.Documentos[idDocumentoTipoFamilia].addOrdemProducaoUtilizando(OP, command);

            return true;
        }

        public OrdemProducaoClass addOrdemProducao(int idProduto, int versaoEstruturaProduto, string produtoCodigo, string produtoDescricao, string tipoDocumento, string numeroDocumento, string revisaoDocumento, string Dimensao, bool rastrearMP, bool imprimeOpsRelacionadas, int? idProdutoK)
        {
            OrdemProducaoClass toRet = this.iOrdemProducaoFactory.getInstanceOp(
                idProduto,
                versaoEstruturaProduto,
                produtoCodigo,
                produtoDescricao,
                tipoDocumento,
                numeroDocumento,
                revisaoDocumento,
                Dimensao,
                rastrearMP,
                imprimeOpsRelacionadas, idProdutoK,
                this, this.Usuario, this.conn);
            this.OPs.Add(toRet);
            return toRet;
        }

        private void loadDocuments()
        {
            try
            {
                this.Documentos = new Dictionary<long, OrdemProducaoDocumentoClass>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT DISTINCT " +
                    "  ordem_producao_documento.id_ordem_producao_documento, " +
                    "  ordem_producao_documento.id_documento_copia, " +
                    "  ordem_producao_documento.id_documento_tipo_familia, " +
                    "  opd_documento_descricao, " +
                    "  opd_documento_copia, " +
                    "  opd_documento_tipo_codigo, " +
                    "  opd_documento_tipo_tipo, " +
                    "  opd_documento_tipo_revisao, " +
                    "  opd_documento_l1, " +
                    "  opd_documento_l2, " +
                    "  opd_documento_l3, " +
                    "  opd_documento_l4, " +
                    "  doc_ocupada, " +
                    "  public.ordem_producao_documento.opd_tipo_validacao, " +
                    "  public.ordem_producao_documento.opd_documento_pedido_familia, "+
                    "  public.ordem_producao_documento.opd_documento_pedido, "+
                    "  public.ordem_producao_documento.opd_documento_pedido_revisao, "+
                    "  public.ordem_producao_documento.opd_aviso, "+
                    "  CASE WHEN liberacao_documento.id_liberacao_documento IS NOT NULL THEN 1 ELSE 0 END as liberacao_forcada " +
                    "FROM " +
                    "  public.ordem_producao_documento " +
                    "  JOIN documento_copia ON documento_copia.id_documento_copia= ordem_producao_documento.id_documento_copia " +
                    "  LEFT JOIN liberacao_documento ON  ordem_producao_documento.id_ordem_producao_documento = liberacao_documento.id_ordem_producao_documento " +
                    "WHERE " +
                    "  id_ordem_producao_grupo=:id_ordem_producao_grupo ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_grupo", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoGrupo;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    bool liberacaoForcada = false;
                    if (read["liberacao_forcada"] != DBNull.Value)
                    {
                        Convert.ToBoolean(Convert.ToInt16(read["liberacao_forcada"]));
                    }

                    this.Documentos.Add(Convert.ToInt32(read["id_documento_tipo_familia"]), new OrdemProducaoDocumentoClass(Convert.ToInt32(read["id_ordem_producao_documento"]),
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
                                                                                                                            this, this.conn));
                }
                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os documentos do grupo de OP.\r\n" + e.Message);
            }
        }

        private void loadOps(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                command.CommandText = "SELECT id_ordem_producao FROM ordem_producao WHERE id_ordem_producao_grupo = " + this.idOrdemProducaoGrupo;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                List<long> OPInseridas = new List<long>();
                foreach (OrdemProducaoClass OP in this.OPs)
                {
                    OPInseridas.Add(OP.idOrdemProducao.Value);
                }

                while (read.Read())
                {
                    int idOp = Convert.ToInt32(read["id_ordem_producao"]);
                    if (!OPInseridas.Contains(idOp))
                    {
                        this.OPs.Add(this.iOrdemProducaoFactory.getInstanceOp(idOp, null, this.Usuario, this.conn));
                        OPInseridas.Add(idOp);
                    }
                }
                read.Close();
               
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as ordens de produção do grupo.\r\n" + e.Message);
            }
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {

            try
            {
                if (this.idOrdemProducaoGrupo == null)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.ordem_producao_grupo " +
                        "( " +
                        "  opg_data " +
                        ")  " +
                        "VALUES ( " +
                        "  :opg_data " +
                        ") RETURNING id_ordem_producao_grupo;";

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opg_data", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();

                    this.idOrdemProducaoGrupo = Convert.ToInt32(command.ExecuteScalar());
                   

                    for (int i = 0; i < this.OPs.Count; i++)
                    {
                        this.OPs[i].Save(ref command);
                    }

                    //Salvar Documentos
                    foreach (OrdemProducaoDocumentoClass doc in this.Documentos.Values)
                    {
                        doc.Save(ref command);
                    }
                }
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o grupo.\r\n" + e.Message);
            }
    
        }

        internal void liberarCopias(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                if (!this.opsCarregadas)
                {
                    this.loadOps(ref command);
                }



                foreach (OrdemProducaoDocumentoClass documento in this.Documentos.Values.Where(a => !a.liberacaoForcada && a.copiaOcupada))
                {
                    if (documento.getOPsAbertasUtilizandoDocumento(command).Count == 0)
                    {
                        //Criada uma função para verificar se existe alguma ordem mais nova que está utilizando, 
                        //essa situação não deveria acontecer nunca para cópias sem a liberação forçada, mas não 
                        //encontrei o bug e contornei dessa forma. Marco

                        if (!documento.utilizadoEmOpsFuturas())
                        {
                            command.CommandText =
                                "UPDATE  " +
                                "  public.documento_copia   " +
                                "SET  " +
                                "  doc_ocupada = 0, " +
                                "  doc_correcao_bug_ocupado = 0 "+
                                "WHERE  " +
                                "  id_documento_copia = :id_documento_copia " +
                                ";";

                            command.Parameters.Clear();

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = documento.idDocumentoCopia;
                            command.ExecuteNonQuery();
                        }
                    }
                   

                  
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao liberar as cópias dos documentos.\r\n" + e.Message);
            }

        }

        public void ordernaOPs()
        {

            this.OPs.Sort(new OrdemProducaoComparer());
        }

        public virtual bool validaDocumentosItemFilho(string oc, int pos, long idOrderItemEtiqueta, long idProd, string codProduto)
        {
            return true;
        }
    }
}