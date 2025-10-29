#region Referencias

using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaWhereUsed
{
    public enum WhereUsedTipo { Produto, Material, Documento, Recurso, Acabamento, Fornecedor, PostoTrabalho }

    public enum WhereUsedItemTipo
    {
        Produto,
        Pedido,
        OrdemCompra,
        OrdemProducao,
        Material,
        ProdutoPosto
    }

    public class WhereUsedReport
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public WhereUsedReport(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }

        public List<WhereUsedItem> gerarRelatorio(WhereUsedTipo tipo, string filtroIdentificacao)
        {

            try
            {
                switch (tipo)
                {
                    case WhereUsedTipo.Produto:
                        return this.gerarRelatorioProduto(filtroIdentificacao);
                        break;
                    case WhereUsedTipo.Material:
                        return this.gerarRelatorioMaterial(filtroIdentificacao);
                        break;
                    case WhereUsedTipo.Documento:
                        return this.gerarRelatorioDocumento(filtroIdentificacao);
                        break;
                    case WhereUsedTipo.Recurso:
                        return this.gerarRelatorioRecurso(filtroIdentificacao);
                        break;
                    case WhereUsedTipo.Acabamento:
                        return this.gerarRelatorioAcabamento(filtroIdentificacao);
                        break;
                        case WhereUsedTipo.Fornecedor:
                        return this.gerarRelatorioFornecedor(filtroIdentificacao);
                        break;
                        case WhereUsedTipo.PostoTrabalho:
                        return this.gerarRelatorioPostoTrabalho(filtroIdentificacao);
                        break;
                    default:
                        throw new Exception("Tipo Inválido");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }
        }

        private List<WhereUsedItem> gerarRelatorioProduto(string filtroIdentificacao)
        {
            try
            {
                List<WhereUsedItem> toRet = new List<WhereUsedItem>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;
                /*
                
                #region Pedidos Sem Configurar
                command.CommandText =
                    "SELECT  " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao " +
                    "FROM " +
                    "  public.produto " +
                    "  INNER JOIN public.pedido_item ON (public.produto.id_produto = public.pedido_item.id_produto) " +
                    "WHERE " +
                    "  public.produto.pro_codigo ILIKE '%" + filtroIdentificacao + "%' AND " +
                    "  public.pedido_item.pei_configurado = 0 ";

                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        WhereUsedItemTipo.Pedido,
                        read["pei_numero"].ToString() + "/" + read["pei_posicao"].ToString(),
                        "");

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();
                #endregion

                #region Pedidos Configurados
                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos " +
                    "FROM " +
                    "  public.produto " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.produto.id_produto = public.order_item_etiqueta.id_produto) " +
                    "WHERE " +
                    "  public.produto.pro_codigo ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        WhereUsedItemTipo.Pedido,
                        read["oie_order_number"].ToString() + "/" + read["oie_order_pos"].ToString(),
                        "");

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion
                */

                #region Produtos
                command.CommandText =
                    "SELECT  " +
                    "  produto_pai.id_produto, "+
                    "  produto_pai.pro_codigo, "+
                    "  produto_pai.pro_descricao, "+
                    "  produto_filho.pro_codigo as filho, " +
                    "  produto_filho.id_produto as id_filho, " +
                    "  produto_pai_filho.ppf_quantidade_filho, "+
                    "  unidade_medida.unm_abreviada, " +
                    "  COALESCE(public.produto_ultima_compra.ultimo_preco,0) as ultima_compra_filho "+
                    "FROM "+
                    "  public.produto produto_pai "+
                    "  INNER JOIN public.produto_pai_filho ON (produto_pai.id_produto = public.produto_pai_filho.id_produto_pai) "+
                    "  AND (produto_pai.pro_versao_estrutura_atual = public.produto_pai_filho.ppf_versao_estrutura) "+
                    "  INNER JOIN public.produto produto_filho ON (public.produto_pai_filho.id_produto_filho = produto_filho.id_produto) "+
                    "  AND (public.produto_pai_filho.ppf_versao_estrutura_filho = produto_filho.pro_versao_estrutura_atual) "+
                    "  INNER JOIN public.unidade_medida ON (produto_filho.id_unidade_medida = unidade_medida.id_unidade_medida) "+
                    "  LEFT OUTER JOIN public.produto_ultima_compra ON (produto_filho.id_produto = public.produto_ultima_compra.id_produto) "+
                    "WHERE "+
                    "  produto_filho.pro_codigo ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["id_filho"].ToString(),
                        read["filho"].ToString(),
                        read["unm_abreviada"].ToString(),
                        WhereUsedItemTipo.Produto,
                        read["id_produto"].ToString(),
                        read["pro_codigo"].ToString(),
                        read["pro_descricao"].ToString(),
                        Convert.ToDouble(read["ppf_quantidade_filho"]),
                        Convert.ToDouble(read["ultima_compra_filho"])
                        );

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                /*
                #region OP
                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao.id_ordem_producao, "+
                    "  public.ordem_producao.orp_situacao "+
                    "FROM "+
                    "  public.produto "+
                    "  INNER JOIN public.ordem_producao ON (public.produto.id_produto = public.ordem_producao.id_produto) "+
                    "WHERE "+
                    "  public.produto.pro_codigo ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        WhereUsedItemTipo.OrdemProducao,
                        "OP "+read["id_ordem_producao"].ToString(),
                        read["orp_situacao"].ToString());

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion
                */

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de produtos.\r\n" + e.Message, e);
            }
        }

        private List<WhereUsedItem> gerarRelatorioMaterial(string filtroIdentificacao)
        {
            try
            {
                List<WhereUsedItem> toRet = new List<WhereUsedItem>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;

                #region Produtos
                command.CommandText =
                    "SELECT  " +
                    "  'M' || CAST(public.material.id_material AS VARCHAR) as materialID, "+
                    "  public.familia_material.fam_codigo || ' '|| public.material.mat_codigo as item, "+
                    "  public.produto.id_produto, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao, " +
                    "  produto_material.prm_quantidade, " +
                    "  unm_abreviada, "+
                    "  COALESCE(public.material_ultima_compra.ultimo_preco, 0) as ultima_compra "+
                    "FROM " +
                    "  public.material " +
                    "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                    "  INNER JOIN public.produto_material ON (public.material.id_material = public.produto_material.id_material) " +
                    "  INNER JOIN public.produto ON (public.produto_material.id_produto = public.produto.id_produto) " +
                    "  AND (public.produto_material.prm_versao_estrutura = public.produto.pro_versao_estrutura_atual) " +
                    "  INNER JOIN public.unidade_medida ON (unidade_medida.id_unidade_medida = material.id_unidade_medida) " +
                    "  LEFT OUTER JOIN public.material_ultima_compra ON (public.material.id_material = public.material_ultima_compra.id_material) "+
                    "WHERE " +
                    "  public.familia_material.fam_codigo || ' '|| public.material.mat_codigo ILIKE '%" + filtroIdentificacao + "%' OR "+
                    "  'M'|| CAST(public.material.id_material AS VARCHAR) ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["materialID"].ToString(),
                        read["item"].ToString(),
                        read["unm_abreviada"].ToString(),
                        WhereUsedItemTipo.Produto,
                        read["id_produto"].ToString(),
                        read["pro_codigo"].ToString(),
                        read["pro_descricao"].ToString(),
                        Convert.ToDouble(read["prm_quantidade"]),
                        Convert.ToDouble(read["ultima_compra"])
                        );

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de materiais.\r\n" + e.Message, e);
            }
        }

        private List<WhereUsedItem> gerarRelatorioDocumento(string filtroIdentificacao)
        {
            try
            {
                List<WhereUsedItem> toRet = new List<WhereUsedItem>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;

                #region Produtos
                command.CommandText =
                    "SELECT  " +
                    "  public.documento_tipo_familia.id_documento_tipo_familia, " +
                    "  public.familia_documento.fad_codigo || ' '|| public.documento_tipo.dot_identificacao || ' '|| public.documento_tipo.dot_revisao_atual as item, "+
                    "  public.produto.id_produto, " +
                    "  public.produto.pro_codigo, "+
                    "  public.produto.pro_descricao "+
                    "FROM "+
                    "  public.documento_tipo "+
                    "  INNER JOIN public.documento_tipo_familia ON (public.documento_tipo.id_documento_tipo = public.documento_tipo_familia.id_documento_tipo) "+
                    "  INNER JOIN public.familia_documento ON (public.documento_tipo_familia.id_familia_documento = public.familia_documento.id_familia_documento) "+
                    "  INNER JOIN public.produto_documento_tipo ON (public.documento_tipo_familia.id_documento_tipo_familia = public.produto_documento_tipo.id_documento_tipo_familia) "+
                    "  INNER JOIN public.produto ON (public.produto_documento_tipo.id_produto = public.produto.id_produto) "+
                    "  AND (public.produto_documento_tipo.pdt_versao_estrutura = public.produto.pro_versao_estrutura_atual) " +
                    "WHERE "+
                    "  public.familia_documento.fad_codigo || ' '|| public.documento_tipo.dot_identificacao || ' '|| public.documento_tipo.dot_revisao_atual ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["id_documento_tipo_familia"].ToString(),
                        read["item"].ToString(),
                        "",
                        WhereUsedItemTipo.Produto,
                        read["id_produto"].ToString(),
                        read["pro_codigo"].ToString(),
                        read["pro_descricao"].ToString(),
                        1,
                        0);

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de Documentos.\r\n" + e.Message, e);
            }
        }

        private List<WhereUsedItem> gerarRelatorioRecurso(string filtroIdentificacao)
        {
            try
            {
                List<WhereUsedItem> toRet = new List<WhereUsedItem>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;

                #region Produtos
                command.CommandText =
                    "SELECT  " +
                    "  public.recurso.id_recurso, "+
                    "  public.familia_recurso.far_identificacao || ' '||  public.recurso.rec_codigo || ' '||  public.recurso.rec_revisao as item, "+
                    "  public.produto.id_produto, "+
                    "  public.produto.pro_codigo, "+
                    "  public.produto.pro_descricao "+
                    "FROM "+
                    "  public.recurso "+
                    "  INNER JOIN public.familia_recurso ON (public.recurso.id_familia_recurso = public.familia_recurso.id_familia_recurso) "+
                    "  INNER JOIN public.produto_recurso ON (public.recurso.id_recurso = public.produto_recurso.id_recurso) "+
                    "  INNER JOIN public.produto ON (public.produto_recurso.id_produto = public.produto.id_produto) "+
                    "  AND (public.produto_recurso.prr_versao_estrutura = public.produto.pro_versao_estrutura_atual) " +
                    "WHERE "+
                    "  public.familia_recurso.far_identificacao || ' '||  public.recurso.rec_codigo || ' '||  public.recurso.rec_revisao ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["id_recurso"].ToString(),
                        read["item"].ToString(),
                        "",
                        WhereUsedItemTipo.Produto,
                        read["id_produto"].ToString(),
                        read["pro_codigo"].ToString(),
                        read["pro_descricao"].ToString(),
                        1,0);

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de recursos.\r\n" + e.Message, e);
            }
        }

        private List<WhereUsedItem> gerarRelatorioAcabamento(string filtroIdentificacao)
        {
            try
            {
                List<WhereUsedItem> toRet = new List<WhereUsedItem>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;

                #region Produtos
                command.CommandText =
                    "SELECT  " +
                    "  public.acabamento.id_acabamento, "+
                    "  public.acabamento.acb_identificacao, "+
                    "  public.produto.id_produto, " +
                    "  public.produto.pro_codigo, "+
                    "  public.produto.pro_descricao "+
                    "FROM "+
                    "  public.acabamento "+
                    "  INNER JOIN public.produto_acabamento ON (public.acabamento.id_acabamento = public.produto_acabamento.id_acabamento) "+
                    "  INNER JOIN public.produto ON (public.produto_acabamento.id_produto = public.produto.id_produto) "+
                    "  AND (public.produto_acabamento.pac_versao_estrutura = public.produto.pro_versao_estrutura_atual) "+
                    "WHERE "+
                    "  public.acabamento.acb_identificacao ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["id_acabamento"].ToString(),
                         read["acb_identificacao"].ToString(),
                         "",
                        WhereUsedItemTipo.Produto,
                        read["id_produto"].ToString(),
                        read["pro_codigo"].ToString(),
                        read["pro_descricao"].ToString(),
                        1,0);

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de acabamentos.\r\n" + e.Message, e);
            }
        }

        private List<WhereUsedItem> gerarRelatorioFornecedor(string filtroIdentificacao)
        {
            try
            {
                List<WhereUsedItem> toRet = new List<WhereUsedItem>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;

                #region Produtos
                command.CommandText =
                    "SELECT  " +
                    "  public.fornecedor.id_fornecedor, "+
                    "  public.fornecedor.for_nome_fantasia, " +
                    "  public.produto.id_produto, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao " +
                    "FROM " +
                    "  public.fornecedor " +
                    "  INNER JOIN public.produto_fornecedor ON (public.fornecedor.id_fornecedor = public.produto_fornecedor.id_fornecedor) " +
                    "  INNER JOIN public.produto ON (public.produto_fornecedor.id_produto = public.produto.id_produto) " +
                    "WHERE " +
                    "  public.fornecedor.for_nome_fantasia ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["id_fornecedor"].ToString(),
                         read["for_nome_fantasia"].ToString(),
                         "",
                        WhereUsedItemTipo.Produto,
                        read["id_produto"].ToString(),
                        read["pro_codigo"].ToString(),
                        read["pro_descricao"].ToString(),
                        1, 0);

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                #region Materiais

                command.CommandText =
                    "SELECT  " +
                    "  public.material.id_material, " +
                    "  public.familia_material.fam_codigo || ' ' || public.material.mat_codigo as mat, " +
                    "  public.material.mat_descricao, " +
                    "  public.fornecedor.id_fornecedor, " +
                    "  public.fornecedor.for_nome_fantasia   " +
                    "FROM " +
                    "  public.material " +
                    "  INNER JOIN public.material_fornecedor ON (public.material.id_material = public.material_fornecedor.id_material) " +
                    "  INNER JOIN public.fornecedor ON (public.material_fornecedor.id_fornecedor = public.fornecedor.id_fornecedor) " +
                    "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                    "WHERE " +
                    "  public.fornecedor.for_nome_fantasia ILIKE '%" + filtroIdentificacao + "%' ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["id_fornecedor"].ToString(),
                         read["for_nome_fantasia"].ToString(),
                         "",
                        WhereUsedItemTipo.Material,
                        read["id_material"].ToString(),
                        read["mat"].ToString(),
                        read["mat_descricao"].ToString(),
                        1, 0);

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de acabamentos.\r\n" + e.Message, e);
            }
        }

        private List<WhereUsedItem> gerarRelatorioPostoTrabalho(string filtroIdentificacao)
        {
            try
            {
                List<WhereUsedItem> toRet = new List<WhereUsedItem>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;

                #region Produtos

                command.CommandText =
                    "SELECT    " +
                    "  public.posto_trabalho.id_posto_trabalho,   " +
                    "  public.posto_trabalho.pos_codigo as item,   " +
                    "  public.produto.id_produto,   " +
                    "  public.produto.pro_codigo,   " +
                    "  public.produto.pro_descricao, " +
                    "  'Seq: '||public.produto_posto_trabalho.ppt_sequencia ||' Setup: '||public.produto_posto_trabalho.ppt_tempo_setup ||' Produção:'||public.produto_posto_trabalho.ppt_tempo_producao as info_complementar  " +
                    "FROM   " +
                    "  public.posto_trabalho   " +
                    "  INNER JOIN public.produto_posto_trabalho ON (public.posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho)   " +
                    "  INNER JOIN public.produto ON (public.produto_posto_trabalho.id_produto = public.produto.id_produto)   " +
                    "WHERE  " +
                    "   public.posto_trabalho.pos_codigo ILIKE '%"+filtroIdentificacao+"%' ; ";


                read = command.ExecuteReader();
                while (read.Read())
                {

                    WhereUsedItem item = new WhereUsedItem(
                        read["id_posto_trabalho"].ToString(),
                        read["item"].ToString(),
                        read["info_complementar"].ToString(),
                        WhereUsedItemTipo.ProdutoPosto,
                        read["id_produto"].ToString(),
                        read["pro_codigo"].ToString(),
                        read["pro_descricao"].ToString(),
                        1, 0);

                    if (!toRet.Contains(item))
                    {
                        toRet.Add(item);
                    }

                }
                read.Close();

                #endregion

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de postos de trabalho.\r\n" + e.Message, e);
            }
        }
    }




    public class WhereUsedItem: IEquatable<WhereUsedItem>
    {
        public WhereUsedItemTipo Tipo { get; private set; }

        public string itemBuscaCodigoInterno { get; private set; }
        public string itemBusca { get; private set; }
        public string itemBuscaUnidadeMedida { get; private set; }
        public string utilizadoEmCodigoInterno { get; private set; }
        public string utilizadoEmIdentificacao { get; private set; }
        public string utilizadoEmDescricao { get; private set; }
        public double utilizadoEmQtd { get; private set; }

        public string utilizadoEmQtdCompleto
        {
            get
            {
                return this.utilizadoEmQtd.ToString() + " " + this.itemBuscaUnidadeMedida;
            }
        }

        public double itemBuscaUltimoPrecoCompra { get; private set; }

        public WhereUsedItem(string itemBuscaCodigoInterno, string itemBusca, string itemBuscaUnidadeMedida, WhereUsedItemTipo Tipo, string utilizadoEmCodigoInterno, string utilizadoEmIdentificacao, string utilizadoEmDescricao, double utilizadoEmQtd, double itemBuscaUltimoPrecoCompra)
        {
            this.itemBuscaUltimoPrecoCompra = itemBuscaUltimoPrecoCompra;
            this.Tipo = Tipo;
            this.utilizadoEmIdentificacao = utilizadoEmIdentificacao;
            this.utilizadoEmDescricao = utilizadoEmDescricao;
            this.itemBusca = itemBusca;
            this.itemBuscaCodigoInterno = itemBuscaCodigoInterno;
            this.itemBuscaUnidadeMedida = itemBuscaUnidadeMedida;

            this.utilizadoEmCodigoInterno = utilizadoEmCodigoInterno;
            this.utilizadoEmQtd = utilizadoEmQtd;
        }

        #region IEquatable<WhereUsedItem> Members

        public bool Equals(WhereUsedItem other)
        {
            return
                this.Tipo.Equals(other.Tipo) &&
                this.utilizadoEmIdentificacao.Equals(other.utilizadoEmIdentificacao) &&
                this.utilizadoEmDescricao.Equals(other.utilizadoEmDescricao) &&
                this.itemBusca.Equals(other.itemBusca) &&
                this.itemBuscaCodigoInterno.Equals(other.itemBuscaCodigoInterno) &&
                this.itemBuscaUnidadeMedida.Equals(other.itemBuscaUnidadeMedida) &&
                this.utilizadoEmCodigoInterno.Equals(other.utilizadoEmCodigoInterno) &&
                this.utilizadoEmQtd.Equals(other.utilizadoEmQtd) &&
                this.itemBuscaUltimoPrecoCompra.Equals(other.itemBuscaUltimoPrecoCompra);

        }

        #endregion
    }
}
