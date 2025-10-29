using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoErroDocumentoClass
    {
        public string Pedido { get; private set; }
        public string Cliente { get; private set; }
        public string ItemPai { get; private set; }
        public string Item { get; private set; }
        public string Familia { get; private set; }
        public string Documento { get; private set; }
        public string Revisao { get; private set; }
        public string Mensagem { get; private set; }

        public TipoErroDocumentoOrdemProducao TipoErro { get; private set; }
        public long IdDocumentoTipoFamilia { get; private set; }
        public List<OrdemProducaoErroDocumentoCopiaClass> Copias { get; private set; }

        IWTPostgreNpgsqlConnection conn;

        public OrdemProducaoErroDocumentoClass(string pedido, string cliente, string itemPai, string item, TipoErroDocumentoOrdemProducao tipoErro, long idDocumentoTipoFamilia, string familia, string documento, string revisao,string mensagem, IWTPostgreNpgsqlConnection conn)
        {
            Pedido = pedido;
            Cliente = cliente;
            ItemPai = itemPai;
            Item = item;
            TipoErro = tipoErro;
            IdDocumentoTipoFamilia = idDocumentoTipoFamilia;
            this.Familia = familia;
            this.Revisao = revisao;
            this.Documento = documento;
            this.conn = conn;

            this.CarregarCopias();
        }

        private void CarregarCopias()
        {

            try
            {
                this.Copias = new List<OrdemProducaoErroDocumentoCopiaClass>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "   id_documento_copia, " +
                    "    doc_identificacao, " +
                    "    opt_posto_codigo, " +
                    "    CASE maior_tempo WHEN '1900-01-01' THEN NULL ELSE maior_tempo END " +
                    " FROM ( " +
                    "SELECT  " +
                    "	id_documento_copia, " +
                    "    doc_identificacao, " +
                    "    opt_posto_codigo, " +
                    "    maior_tempo,    " +
                    "	rank() OVER w AS ran " +
                    "	  FROM ( " +
                    "      SELECT  " +
                    "          public.documento_copia.id_documento_copia, " +
                    "          public.documento_copia.doc_identificacao, " +
                    "          public.ordem_producao_posto_trabalho.opt_posto_codigo, " +
                    "          greatest(coalesce(ordem_producao_posto_trabalho.opt_tempo1, '1900-01-01'), coalesce(ordem_producao_posto_trabalho.opt_tempo2, '1900-01-01'), coalesce(ordem_producao_posto_trabalho.opt_tempo3, '1900-01-01'), coalesce(ordem_producao_posto_trabalho.opt_tempo4, '1900-01-01')) AS maior_tempo " +
                    "        FROM " +
                    "          public.documento_copia " +
                    "          LEFT OUTER JOIN public.ordem_producao_documento ON (public.documento_copia.id_documento_copia = public.ordem_producao_documento.id_documento_copia) " +
                    "          LEFT OUTER JOIN public.ordem_producao_documento_op ON (public.ordem_producao_documento.id_ordem_producao_documento = public.ordem_producao_documento_op.id_ordem_producao_documento) " +
                    "          LEFT OUTER JOIN public.ordem_producao ON (public.ordem_producao_documento_op.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "          LEFT OUTER JOIN public.ordem_producao_posto_trabalho ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_posto_trabalho.id_ordem_producao) " +
                    "        WHERE " +
                    "          public.documento_copia.id_documento_tipo_familia = :id_documento_tipo_familia AND  " +
                    "          public.documento_copia.doc_ativa = 1 AND public.documento_copia.doc_permite_utilizar_op = 1 " +
                    "        ) " +
                    "    as tab WINDOW w AS (PARTITION BY " +
                    "        	tab.id_documento_copia " +
                    "            ORDER BY id_documento_copia, maior_tempo DESC " +
                    "        ) " +
                    ") as tab2 WHERE ran = 1; ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo_familia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.IdDocumentoTipoFamilia;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    this.Copias.Add(
                        new OrdemProducaoErroDocumentoCopiaClass(
                            Convert.ToInt32(read["id_documento_copia"]),
                            read["doc_identificacao"].ToString(),
                            read["opt_posto_codigo"].ToString(),
                            this.IdDocumentoTipoFamilia
                            )
                        );
                }
                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as cópias para o relatório de erro.\r\n" + e.Message, e);
            }
        }
    }
}