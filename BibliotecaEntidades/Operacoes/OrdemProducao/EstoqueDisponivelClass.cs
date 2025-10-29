using System;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    internal class EstoqueDisponivelClass
    {
        public ProdutoClass Produto { get; private set; }
        public ProdutoKClass ProdutoK { get; set; }
        public int RevisaoProduto { get; private set; }
        public string Dimensao { get; private set; }
        public double QtdEstoqueAtual { get; private set; }
        public double QtdOpsAguardandoEncerramento { get; private set; }
        public double QtdAguardandoBaixar { get; private set; }
        public double QtdUtilizadaNesseProcesso { get; set; }
        

        //estoque disponivel = estoque previsto - ( consumo total previsto - qtd ja baixada)
        public double EstoqueDisponivel
        {
            get { return QtdEstoqueAtual + QtdOpsAguardandoEncerramento - QtdAguardandoBaixar - QtdUtilizadaNesseProcesso; }
        }

        private IWTPostgreNpgsqlCommand command;
        private string idsIgnorarSoma;

        public EstoqueDisponivelClass(ProdutoClass produto, int revisaoProduto, string dimensao,string idsIgnorarSoma, ProdutoKClass produtoK, ref IWTPostgreNpgsqlCommand command)
        {
            Produto = produto;
            RevisaoProduto = revisaoProduto;
            Dimensao = dimensao;
            ProdutoK = produtoK;
            this.command = command;
            this.idsIgnorarSoma = idsIgnorarSoma;
            
            this.Load();


        }

        private void Load()
        {
            try
            {
             
                if (this.ProdutoK!=null)
                {
                    this.LoadProdutoK();
                }
                else
                {
                    this.LoadProduto();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados dos estoques disponíveis\r\n" + e.Message, e);
            }

        }

        private void LoadProdutoK()
        {

            this.QtdEstoqueAtual = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProdutoK(
                this.ProdutoK,
                ref command);
      }

        private void LoadProduto()
        {
            //Buscar a qtd atual do estoque


            this.QtdEstoqueAtual = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(
                this.Produto,
                ref command);


            //Pegar a quantidade total prevista das ops geradas e não encerradas
            //e somar o saldo previsto do estoque após o encerramento dessas ops

            command.CommandText =
                "SELECT  " +
                "  SUM(public.ordem_producao.orp_quantidade) AS qtdTotal " +
                "FROM " +
                "  public.ordem_producao " +
                "WHERE " +
                "  public.ordem_producao.id_produto = :id_produto AND  " +
                "  public.ordem_producao.orp_versao_estrutura_produto = :orp_versao_estrutura_produto AND " +
                "  public.ordem_producao.orp_dimensao = :orp_dimensao AND " +
                "  (public.ordem_producao.orp_situacao = 0 OR  " +
                "  public.ordem_producao.orp_situacao = 4 OR  " +
                "  public.ordem_producao.orp_situacao = 1) ";

            command.Parameters.Clear();

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = this.Produto.ID;
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_versao_estrutura_produto", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = this.RevisaoProduto;
            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orp_dimensao", NpgsqlDbType.Varchar));
            command.Parameters[command.Parameters.Count - 1].Value = this.Dimensao;

            object tmp = command.ExecuteScalar();

            if (tmp != null && tmp != DBNull.Value)
            {
                this.QtdOpsAguardandoEncerramento = Convert.ToDouble(tmp);
            }
            else
            {
                this.QtdOpsAguardandoEncerramento = 0;
            }


            //Pegar pedidos não encerrados com esse item e com op gerada e somar o saldo de consumo total previsto

            if (this.idsIgnorarSoma.Length > 0)
            {
                this.idsIgnorarSoma = " AND " + this.idsIgnorarSoma;
            }

            command.CommandText =
                "SELECT " +
                "  public.ordem_producao.orp_quantidade, " +
                "  public.order_item_etiqueta.oie_nota_fiscal, " +
                "  public.order_item_etiqueta.oie_etiqueta_interna, " +
                "  public.order_item_etiqueta.oie_situacao_conferencia, " +
                "  public.order_item_etiqueta.oie_saldo_conferencia, " +
                "  public.order_item_etiqueta.oie_quantidade, " +
                "  pedido_pai.pei_saldo " +
                "FROM " +
                "  public.ordem_producao " +
                "  INNER JOIN public.ordem_producao_pedido ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao) " +
                "  INNER JOIN public.order_item_etiqueta ON (public.ordem_producao_pedido.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                "  JOIN (SELECT p.pei_status, p.pei_numero, p.pei_posicao, p.id_cliente, p.pei_saldo FROM pedido_item p WHERE p.pei_sub_linha = 0 ) pedido_pai ON  " +
                "      	(pedido_pai.pei_numero = order_item_etiqueta.oie_order_number AND  " +
                "         pedido_pai.pei_posicao = order_item_etiqueta.oie_order_pos AND " +
                "         pedido_pai.id_cliente = order_item_etiqueta.id_cliente) " +
                "WHERE " +
                "  public.ordem_producao.id_produto = :id_produto  " +
                "  AND (public.ordem_producao.orp_situacao = 0 OR public.ordem_producao.orp_situacao = 1 OR public.ordem_producao.orp_situacao = 2 OR public.ordem_producao.orp_situacao = 4 ) " +
                "  AND (pedido_pai.pei_status = 0 OR pedido_pai.pei_status = 3)" +
                idsIgnorarSoma;

            command.Parameters.Clear();

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = this.Produto.ID;


            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            double qtdTmp = 0;
            while (read.Read())
            {
                //Item Emite NF, o que já foi faturado já foi baixado do estoque, o que não foi deve ser considerado
                if (Convert.ToBoolean(Convert.ToInt16(read["oie_nota_fiscal"])))
                {
                    qtdTmp += Convert.ToDouble(read["pei_saldo"]);
                    continue;
                }


                //Se o item já foi totalmente conferido o assunto já foi resolvido no estoque para os itens que não são da NF
                if (read["oie_situacao_conferencia"].ToString() != "2")
                {
                    //Item realiza conferência, utilizar o saldo de conferência para saber quanto falta baixar
                    if (Convert.ToBoolean(Convert.ToInt16(read["oie_etiqueta_interna"])))
                    {
                        qtdTmp += Convert.ToDouble(read["oie_saldo_conferencia"]);
                        continue;
                    }

                    //Se o item não realiza conferência e não foi conferido inteiro deve-se contar como quantidade necessária toda a quantidade necessparia para o item do pedido
                    qtdTmp += Convert.ToDouble(read["oie_quantidade"]);
                    continue;
                }



            }
            read.Close();

            this.QtdAguardandoBaixar = qtdTmp;

        }
    }
}