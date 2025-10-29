using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoDocumentoClass
    {

        public long? idOrdemProducaoDocumento { get; private set; }
        public long idDocumentoCopia { get; private set; }
        public long idDocumentoTipoFamilia { get; private set; }
        public string Descricao { get; private set; }
        public string Copia { get; private set; }

        public string Loc1 { get; private set; }
        public string Loc2 { get; private set; }
        public string Loc3 { get; private set; }
        public string Loc4 { get; private set; }

        public string documentoTipoCodigo { get; private set; }
        public string documentoTipoTipo { get; private set; }
        public string documentoTipoRevisao { get; private set; }

        public TipoValidacaoDocumento TipoValidacao { get; private set; }
        public string DocumentoPedidoFamilia { get; private set; }
        public string DocumentoPedido { get; private set; }
        public string DocumentoPedidoRevisao { get; private set; }
        public string AvisoDocumento { get; private set; }

        public bool copiaOcupada { get; private set; }
        public bool liberacaoForcada { get; private set; }
        private List<OrdemProducaoClass> _OPsUtilizandoDocumento;
        
            

        public List<OrdemProducaoClass> getOPsUtilizandoDocumento(IWTPostgreNpgsqlCommand command)
        {
           
                if (!this.OpsIsInitialized)
                {
                    this.loadOpsUtilizandoDocumento(command);
                }
                return this._OPsUtilizandoDocumento;
            
        }

        public List<OrdemProducaoClass> getOPsAbertasUtilizandoDocumento(IWTPostgreNpgsqlCommand command)
        {
            
                return new List<OrdemProducaoClass>(this.getOPsUtilizandoDocumento(command).Where(a => a.Situacao == 0 || a.Situacao == 1 || a.Situacao == 4));
            
        }

        private bool _ultimaOpUtilizandoInitialized = false;
        private string _ultimaOpUtilizando { get; set; }
        public string UltimaOpUtilizando
        {
            get
            {
                if (!this._ultimaOpUtilizandoInitialized)
                {
                    this.loadDadosUltimaUtilizacao();
                }
                return this._ultimaOpUtilizando;
            }
        }

        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoGrupoClass Parent;

        internal bool OpsIsInitialized { get; private set; }

        public bool toDelete { get; private set; }

        public OrdemProducaoDocumentoClass(long? idOrdemProducaoDocumento, long idDocumentoCopia, long idDocumentoTipoFamilia, string Descricao, string Copia,
                                           string Loc1, string Loc2, string Loc3, string Loc4, string documentoTipoCodigo, string documentoTipoTipo, string documentoTipoRevisao,
                                           bool copiaOcupada, bool liberacaoForcada,
                                           TipoValidacaoDocumento tipoValidacao, string documentoPedidoFamilia, string documentoPedido, string documentoPedidoRevisao,
                                           string avisoDocumento,
                                           OrdemProducaoGrupoClass Parent, IWTPostgreNpgsqlConnection conn)
        {
            this.idOrdemProducaoDocumento = idOrdemProducaoDocumento;
            this.idDocumentoCopia = idDocumentoCopia;
            this.idDocumentoTipoFamilia = idDocumentoTipoFamilia;

            this.Descricao = Descricao;
            this.Copia = Copia;
            this.documentoTipoCodigo = documentoTipoCodigo;
            this.documentoTipoRevisao = documentoTipoRevisao;
            this.documentoTipoTipo = documentoTipoTipo;

            TipoValidacao = tipoValidacao;
            DocumentoPedidoFamilia = documentoPedidoFamilia;
            DocumentoPedido = documentoPedido;
            DocumentoPedidoRevisao = documentoPedidoRevisao;
            this.AvisoDocumento = avisoDocumento;

            this.Loc1 = Loc1;
            this.Loc2 = Loc2;
            this.Loc3 = Loc3;
            this.Loc4 = Loc4;

            this.copiaOcupada = copiaOcupada;
            this.liberacaoForcada = liberacaoForcada;

            this.conn = conn;
            this.Parent = Parent;

            this.OpsIsInitialized = false;
          

            this.toDelete = false;
        }

        public void loadOpsUtilizandoDocumento(IWTPostgreNpgsqlCommand command)
        {
            try
            {
                this._OPsUtilizandoDocumento = new List<OrdemProducaoClass>();
                if (this.Parent != null)
                {
                    foreach (OrdemProducaoClass OP in this.Parent.OPs)
                    {
                        if (OP.utilizaDocumento(this.idDocumentoTipoFamilia, command))
                        {
                            this._OPsUtilizandoDocumento.Add(OP);
                        }
                    }
                }

                this.OpsIsInitialized = true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as ops que utilizam o documento.\r\n" + e.Message,e);
            }

        }


        public void Delete()
        {
            this.toDelete = true;
        }

        public void addOrdemProducaoUtilizando(OrdemProducaoClass OP, IWTPostgreNpgsqlCommand command)
        {
            if (!this.OpsIsInitialized)
            {
                this.loadOpsUtilizandoDocumento(command);
            }

            if (!this._OPsUtilizandoDocumento.Contains(OP))
            {
                this._OPsUtilizandoDocumento.Add(OP);
            }
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (idOrdemProducaoDocumento != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_documento  " +
                            "WHERE  " +
                            "  id_ordem_producao_documento = :id_ordem_producao_documento " +
                            ";";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_documento", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoDocumento;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {


                    if (this._OPsUtilizandoDocumento.Count != 0)
                    {
                        command.CommandText =

                            "UPDATE  " +
                            "  public.documento_copia   " +
                            "SET  " +
                            "  doc_ocupada = 1 " +
                            "WHERE  " +
                            "  id_documento_copia = :id_documento_copia " +
                            ";";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = idDocumentoCopia;
                        command.ExecuteNonQuery();

                    }


                    if (this.idOrdemProducaoDocumento == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_documento " +
                            "( " +
                            "  id_ordem_producao_grupo, " +
                            "  id_documento_copia, " +
                            "  id_documento_tipo_familia, " +
                            "  opd_documento_descricao, " +
                            "  opd_documento_copia, " +
                            "  opd_documento_tipo_codigo, "+
                            "  opd_documento_tipo_tipo, " +
                            "  opd_documento_tipo_revisao, " +
                            "  opd_documento_l1, "+
                            "  opd_documento_l2, " +
                            "  opd_documento_l3, " +
                            "  opd_documento_l4, " +
                            "  opd_tipo_validacao, "+
                            "  opd_documento_pedido_familia, "+
                            "  opd_documento_pedido, "+
                            "  opd_documento_pedido_revisao, "+
                            "  opd_aviso "+
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao_grupo, " +
                            "  :id_documento_copia, " +
                            "  :id_documento_tipo_familia, " +
                            "  :opd_documento_descricao, " +
                            "  :opd_documento_copia, " +
                            "  :opd_documento_tipo_codigo, " +
                            "  :opd_documento_tipo_tipo, " +
                            "  :opd_documento_tipo_revisao, " +
                            "  :opd_documento_l1, " +
                            "  :opd_documento_l2, " +
                            "  :opd_documento_l3, " +
                            "  :opd_documento_l4, " +
                            "  :opd_tipo_validacao, " +
                            "  :opd_documento_pedido_familia, " +
                            "  :opd_documento_pedido, " +
                            "  :opd_documento_pedido_revisao, " +
                            "  :opd_aviso " +
                            ") RETURNING id_ordem_producao_documento;";
                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_documento   " +
                            "SET  " +
                            "  id_ordem_producao_grupo = :id_ordem_producao_grupo, " +
                            "  id_documento_copia = :id_documento_copia, " +
                            "  id_documento_tipo_familia = :id_documento_tipo_familia, " +
                            "  opd_documento_descricao = :opd_documento_descricao, " +
                            "  opd_documento_copia = :opd_documento_copia, " +
                            "  opd_documento_tipo_codigo = :opd_documento_tipo_codigo, " +
                            "  opd_documento_tipo_tipo = :opd_documento_tipo_tipo, " +
                            "  opd_documento_tipo_revisao = :opd_documento_tipo_revisao, " +
                            "  opd_documento_l1 = :opd_documento_l1, " +
                            "  opd_documento_l2 = :opd_documento_l2, " +
                            "  opd_documento_l3 = :opd_documento_l3, " +
                            "  opd_documento_l4 = :opd_documento_l4, " +
                            "  opd_tipo_validacao = :opd_tipo_validacao, " +
                            "  opd_documento_pedido_familia = :opd_documento_pedido_familia, " +
                            "  opd_documento_pedido = :opd_documento_pedido, " +
                            "  opd_documento_pedido_revisao = :opd_documento_pedido_revisao, " +
                            "  opd_aviso = :opd_aviso "+
                            "WHERE " +
                            "  id_ordem_producao_documento = :id_ordem_producao_documento " +
                            "RETURNING  id_ordem_producao_documento;";
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_documento", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoDocumento;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_grupo", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducaoGrupo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idDocumentoCopia;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo_familia", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idDocumentoTipoFamilia;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_descricao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Descricao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_copia", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Copia;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_tipo_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.documentoTipoCodigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_tipo_tipo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.documentoTipoTipo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_tipo_revisao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.documentoTipoRevisao;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l1", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Loc1;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l2", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Loc2;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l3", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Loc3;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_l4", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Loc4;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_tipo_validacao", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = this.TipoValidacao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_pedido_familia", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.DocumentoPedidoFamilia;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_pedido", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.DocumentoPedido;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_documento_pedido_revisao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.documentoTipoRevisao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opd_aviso", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.AvisoDocumento;
                    

                    this.idOrdemProducaoDocumento = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "DELETE FROM ordem_producao_documento_op WHERE id_ordem_producao_documento = :id_ordem_producao_documento";
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_documento", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoDocumento;

                    command.ExecuteNonQuery();

                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.ordem_producao_documento_op " +
                        "( " +
                        "  id_ordem_producao_documento, " +
                        "  id_ordem_producao " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao_documento, " +
                        "  :id_ordem_producao " +
                        ");";

                    foreach (OrdemProducaoClass OP in this.getOPsUtilizandoDocumento(command) )
                    {
                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_documento", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoDocumento;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = OP.idOrdemProducao;

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o Documento.\r\n" + e.Message);
            }
        }

        public void loadDadosUltimaUtilizacao()
        {
            try
            {
                /*//Menor OP Grupo
                int idMenorOpGrupo = this.OPsUtilizandoDocumento[0].idOrdemProducao;
                foreach (OrdemProducaoClass op in this.OPsUtilizandoDocumento)
                {
                    if (op.idOrdemProducao < idMenorOpGrupo)
                    {
                        idMenorOpGrupo = op.idOrdemProducao;
                    }
                }*/


                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =

                    "SELECT  " +
                    "  public.ordem_producao.id_ordem_producao, " +
                    "  public.ordem_producao.orp_data, " +
                    "  CASE orp_situacao WHEN 0 THEN 'Nova' WHEN 1 THEN 'Em produção' WHEN 2 THEN 'Encerrada' WHEN 3 THEN 'Cancelada' ELSE 'Erro' END as situacao, " +
                    "  public.acs_usuario.aus_login, " +
                    "  public.liberacao_documento.lid_data " +
                    "FROM " +
                    "  public.ordem_producao_documento " +
                    "  INNER JOIN public.ordem_producao_documento_op ON (public.ordem_producao_documento.id_ordem_producao_documento = public.ordem_producao_documento_op.id_ordem_producao_documento) " +
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_documento_op.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  LEFT OUTER JOIN public.liberacao_documento ON (public.ordem_producao_documento.id_ordem_producao_documento = public.liberacao_documento.id_ordem_producao_documento) " +
                    "  LEFT OUTER JOIN public.acs_usuario ON (public.liberacao_documento.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                    "WHERE " +
                    "  public.ordem_producao_documento.id_documento_copia = " + this.idDocumentoCopia + " AND " +
                    "  public.ordem_producao.id_ordem_producao IN ( " +
                    " SELECT  " +
                    "      MAX(public.ordem_producao.id_ordem_producao) " +
                    "    FROM " +
                    "  		public.ordem_producao_documento " +
                    "		INNER JOIN public.ordem_producao_documento_op ON (public.ordem_producao_documento.id_ordem_producao_documento = public.ordem_producao_documento_op.id_ordem_producao_documento) " +
                    "		INNER JOIN public.ordem_producao ON (public.ordem_producao_documento_op.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "    WHERE " +
                    "      public.ordem_producao_documento.id_documento_copia = " + this.idDocumentoCopia + " " +
                    "      AND public.ordem_producao_documento.id_ordem_producao_grupo < " + this.Parent.idOrdemProducaoGrupo + " " +
                    ") ";
              

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    this._ultimaOpUtilizando = "OP: " + read["id_ordem_producao"] + " " + read["situacao"];

                    if (read["lid_data"] != DBNull.Value)
                    {
                        this._ultimaOpUtilizando += " - LF: " + read["aus_login"] + " - " + Convert.ToDateTime(read["lid_data"]).ToString("dd/MM/yyyy");
                    }
                    read.Close();
                }

                this._ultimaOpUtilizandoInitialized = true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar a ultima OP utilizando o documento.\r\n" + e.Message, e);

            }
        }

        internal bool utilizadoEmOpsFuturas()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao.id_ordem_producao " +
                    "FROM " +
                    "  public.ordem_producao " +
                    "  INNER JOIN public.ordem_producao_documento_op ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_documento_op.id_ordem_producao) " +
                    "  INNER JOIN public.ordem_producao_documento ON (public.ordem_producao_documento_op.id_ordem_producao_documento = public.ordem_producao_documento.id_ordem_producao_documento) " +
                    "WHERE " +
                    "  public.ordem_producao.id_ordem_producao_grupo > " + this.Parent.idOrdemProducaoGrupo + " AND  " +
                    "  (public.ordem_producao.orp_situacao = 0 OR  " +
                    "  public.ordem_producao.orp_situacao = 4 OR  " +
                    "  public.ordem_producao.orp_situacao = 1) AND " +
                    "  public.ordem_producao_documento.id_documento_copia = " + this.idDocumentoCopia + " ";

                object tmp = command.ExecuteScalar();
                if (tmp != null && tmp != DBNull.Value)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar se a cópia de documento está sendo utilizada em alguma op futura.\r\n" + e.Message, e);
            }
        }

        public void removeOrdemProducaoUtilizando(OrdemProducaoClass OP, IWTPostgreNpgsqlCommand command)
        {
            if (!this.OpsIsInitialized)
            {
                this.loadOpsUtilizandoDocumento(command);
            }

            if (this._OPsUtilizandoDocumento.Contains(OP))
            {
                this._OPsUtilizandoDocumento.Remove(OP);
            }
           
        }
    }
}