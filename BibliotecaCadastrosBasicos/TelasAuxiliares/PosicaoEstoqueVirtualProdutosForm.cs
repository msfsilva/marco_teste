using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class PosicaoEstoqueVirtualProdutosForm : IWTBaseForm
    {
        public PosicaoEstoqueVirtualProdutosForm()
        {
            InitializeComponent();
            this.ensProduto.FormSelecao = new CadProdutoListForm(TipoModulo.Tipo, true, somenteAtivos: true);
            this.ensProdutoK.FormSelecao = new CadAgrupadorItemSemelhanteListForm(TipoModulo.Tipo);
            this.ensProdutoK.Enabled = false;
        }

        private void CarregaDadosEstoqueVirtual()
        {

            try
            {
                IWTPostgreNpgsqlCommand command = SingleConnection.CreateCommand();


                ProdutoClass produto = (ProdutoClass) this.ensProduto.EntidadeSelecionada;
                double qtdEstoqueFisico = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto(produto, ref command);

                command.CommandText =
                "SELECT  " +
                "  SUM(public.ordem_producao.orp_quantidade) AS qtdTotal " +
                "FROM " +
                "  public.ordem_producao " +
                "WHERE " +
                "  public.ordem_producao.id_produto = :id_produto AND  " +
                "  (public.ordem_producao.orp_situacao = 0 OR  " +
                "  public.ordem_producao.orp_situacao = 4 OR  " +
                "  public.ordem_producao.orp_situacao = 1) ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer, produto.ID));

                double qtdOps = 0;
                object tmp = command.ExecuteScalar();
                if (tmp != null && tmp != DBNull.Value)
                {
                    qtdOps = Convert.ToDouble(tmp);
                }

                command.CommandText =
                    "        SELECT " +
                    "        public.order_item_etiqueta.oie_order_number, " +
                    "        public.order_item_etiqueta.oie_order_pos, " +
                    "        public.order_item_etiqueta.oie_nota_fiscal,  " +
                    "        public.order_item_etiqueta.oie_etiqueta_interna, " +
                    "        public.order_item_etiqueta.oie_situacao_conferencia, " +
                    "        public.order_item_etiqueta.oie_saldo_conferencia,  " +
                    "        public.order_item_etiqueta.oie_quantidade,  " +
                    "        pedido_pai.pei_saldo " +
                    "            FROM " +
                    "        public.order_item_etiqueta " +
                    "            LEFT JOIN public.ordem_producao_pedido ON(public.ordem_producao_pedido.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta)  " +
                    "        LEFT JOIN public.ordem_producao ON(public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao)  " +
                    "        JOIN(SELECT p.pei_status, p.pei_numero, p.pei_posicao, p.id_cliente, p.pei_saldo FROM pedido_item p WHERE p.pei_sub_linha = 0) pedido_pai ON " +
                    "            (pedido_pai.pei_numero = order_item_etiqueta.oie_order_number AND " +
                    "        pedido_pai.pei_posicao = order_item_etiqueta.oie_order_pos AND " +
                    "        pedido_pai.id_cliente = order_item_etiqueta.id_cliente) " +
                    "        JOIN produto ON(order_item_etiqueta.id_produto = produto.id_produto) " +
                    "        WHERE " +
                    "            (public.order_item_etiqueta.id_produto = :id_produto AND public.order_item_etiqueta.id_produto_k IS NULL) " +
                    "        AND( " +
                    "            (public.ordem_producao.orp_situacao = 0 OR public.ordem_producao.orp_situacao = 1 OR public.ordem_producao.orp_situacao = 2  OR public.ordem_producao.orp_situacao = 4) " +
                    "        OR " +
                    "            (public.ordem_producao.id_ordem_producao IS NULL ) " +
                    "        )  " +
                    "        AND(pedido_pai.pei_status = 0 OR pedido_pai.pei_status = 3) ";

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

                double qtdReservada = Math.Round(qtdTmp, 5);

                double saldoPrevisto = Math.Round(qtdEstoqueFisico + qtdOps - qtdReservada, 5);


                this.lblEstoqueFisico.Text = qtdEstoqueFisico.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + produto.UnidadeMedida.Abreviada;
                this.lblQtdProducao.Text = qtdOps.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + produto.UnidadeMedida.Abreviada;
                this.lblQtdReservada.Text = qtdReservada.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + produto.UnidadeMedida.Abreviada;
                this.lblSaldoVirtualEstoque.Text = saldoPrevisto.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + produto.UnidadeMedida.Abreviada;


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar os dados do estoque Virtual do produto\r\n" + e.Message, e);
            }
        }

        private void CarregaDadosEstoqueVirtualProdutoK()
        {

            try
            {
                IWTPostgreNpgsqlCommand command = SingleConnection.CreateCommand();


                ProdutoKClass produtoK = (ProdutoKClass)this.ensProdutoK.EntidadeSelecionada;
                double qtdEstoqueFisico = EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProdutoK(produtoK, ref command);

                command.CommandText =
                "SELECT  " +
                "  SUM(public.ordem_producao.orp_quantidade) AS qtdTotal " +
                "FROM " +
                "  public.ordem_producao " +
                "WHERE " +
                "  public.ordem_producao.id_produto_k = :id_produto_k AND  " +
                "  (public.ordem_producao.orp_situacao = 0 OR  " +
                "  public.ordem_producao.orp_situacao = 4 OR  " +
                "  public.ordem_producao.orp_situacao = 1) ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer, produtoK.ID));

                double qtdOps = 0;
                object tmp = command.ExecuteScalar();
                if (tmp != null && tmp != DBNull.Value)
                {
                    qtdOps = Convert.ToDouble(tmp);
                }

                command.CommandText =
                    "SELECT  " +
                    "        public.order_item_etiqueta.oie_order_number, " +
                    "        public.order_item_etiqueta.oie_order_pos, " +
                    "        public.order_item_etiqueta.oie_nota_fiscal,  " +
                    "        public.order_item_etiqueta.oie_etiqueta_interna,  " +
                    "        public.order_item_etiqueta.oie_situacao_conferencia,  " +
                    "        public.order_item_etiqueta.oie_saldo_conferencia,  " +
                    "        public.order_item_etiqueta.oie_quantidade,  " +
                    "        pedido_pai.pei_saldo " +
                    "            FROM " +
                    "        public.order_item_etiqueta " +
                    "            LEFT JOIN public.ordem_producao_pedido ON(public.ordem_producao_pedido.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta)  " +
                    "        LEFT JOIN public.ordem_producao ON(public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao)  " +
                    "        JOIN(SELECT p.pei_status, p.pei_numero, p.pei_posicao, p.id_cliente, p.pei_saldo FROM pedido_item p WHERE p.pei_sub_linha = 0) pedido_pai ON " +
                    "            (pedido_pai.pei_numero = order_item_etiqueta.oie_order_number AND " +
                    "        pedido_pai.pei_posicao = order_item_etiqueta.oie_order_pos AND " +
                    "        pedido_pai.id_cliente = order_item_etiqueta.id_cliente) " +
                    "        JOIN produto_k ON(order_item_etiqueta.id_produto_k = produto_k.id_produto_k) " +
                    "        WHERE " +
                    "            (public.order_item_etiqueta.id_produto_k = :id_produto_k ) " +
                    "        AND( " +
                    "            (public.ordem_producao.orp_situacao = 0 OR public.ordem_producao.orp_situacao = 1 OR public.ordem_producao.orp_situacao = 2 OR public.ordem_producao.orp_situacao = 4 ) " +
                    "        OR " +
                    "            (public.ordem_producao.id_ordem_producao IS NULL) " +
                    "        ) " +
                    "        AND(pedido_pai.pei_status = 0 OR pedido_pai.pei_status = 3)"; 

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

                double qtdReservada = Math.Round(qtdTmp, 5);

                double saldoPrevisto = Math.Round(qtdEstoqueFisico + qtdOps - qtdReservada, 5);

                string unMedida = "";
                if (produtoK.CollectionProdutoKProdutoClassProdutoK.Count > 0)
                {
                    unMedida = produtoK.CollectionProdutoKProdutoClassProdutoK.First().Produto.UnidadeMedida.Abreviada;
                }

                this.lblEstoqueFisico.Text = qtdEstoqueFisico.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + unMedida;
                this.lblQtdProducao.Text = qtdOps.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + unMedida;
                this.lblQtdReservada.Text = qtdReservada.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + unMedida;
                this.lblSaldoVirtualEstoque.Text = saldoPrevisto.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + unMedida;


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao carregar os dados do estoque Virtual do produto\r\n" + e.Message, e);
            }
        }

        #region Eventos

        private void ensProduto_EntityChange(object sender, EventArgs e)
        {
            try
            {
                if (this.ensProduto.EntidadeSelecionada != null && this.ensProduto.Enabled)
                {
                    CarregaDadosEstoqueVirtual();
                }

                if (this.ensProdutoK.EntidadeSelecionada != null && this.ensProdutoK.Enabled)
                {
                    CarregaDadosEstoqueVirtualProdutoK();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            this.ensProduto.Enabled = rdbProduto.Checked;
            this.ensProdutoK.Enabled = rdbProdutoK.Checked;
            ensProduto_EntityChange(null, null);
        }
    }
}
