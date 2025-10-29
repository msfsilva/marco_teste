#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;
using SolicitacaoCompraPedidoClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraPedidoClass;

#endregion

namespace BibliotecaCompras
{
    public class GeradorAutomaticoSolicitacaoCompra
    {
        readonly IWTPostgreNpgsqlConnection conn;
        string tipoCalculoSemana;
        string diaCalculoSemana;
        readonly double disparoAutomaticoSolicitacao;
        readonly int diasPCP;
        readonly AcsUsuarioClass Usuario;
        readonly NecessidadeCompra relat;

        public GeradorAutomaticoSolicitacaoCompra(string tipoCalculoSemana, string diaCalculoSemana,int diasPCP,
             int leadtimeCompras,
            int diasVerde,
            int diasAmarelo, int diasVermelho, int mesesMedia,
            double categoriaAAcimaDe, double categoriaBAcimaDe,
            double margemAvisoKB,
             double sugestaoCompraAcimaConfigurado,
            double disparoAutomaticoSolicitacao,
            AcsUsuarioClass usuario, 
            IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.diasPCP = diasPCP;
            this.Usuario = usuario;
            this.disparoAutomaticoSolicitacao = disparoAutomaticoSolicitacao;

            this.relat = new NecessidadeCompra(
                tipoCalculoSemana,
                diaCalculoSemana,
                diasPCP, 
                leadtimeCompras, 
                diasVerde, 
                diasAmarelo,
                diasVermelho,
                mesesMedia, 
                categoriaAAcimaDe, 
                categoriaBAcimaDe, 
                margemAvisoKB,
                sugestaoCompraAcimaConfigurado, 
                conn,
                usuario);
        }


        public void Start()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {

                this.relat.gerarRelatorio(null, null, null,new List<SolicitacaoCompraClass>());

                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                List<itemNecessidadeCompra> tmp = null;



                

                tmp = new List<itemNecessidadeCompra>(this.relat.itensComprar.Values);

                foreach (itemNecessidadeCompra item in tmp)
                {


                    if (item.impedirSolicitacaoAutomatica)
                    {
                        continue;
                    }

                    double qtd = Math.Round(item.qtdAComprar, 4);
                    if (qtd > 0)
                    {
                        if (item.Kanban)
                        {
                            if ((item.estoqueMinimo/item.EVP) >= (this.disparoAutomaticoSolicitacao/100))
                            {
                                continue;
                            }
                        }

                        SolicitacaoCompraClass sol = new SolicitacaoCompraClass(null, null, this.Usuario, this.conn);
                        if (item.tipoItem == TipoItemCompra.Material)
                        {
                            MaterialClass mat = (MaterialClass) item.Item;
                            DateTime dataEntrega = mat.calculaEntregaPrevistaCompra(Configurations.DataIndependenteClass.GetData());


                            List<SolicitacaoCompraPedidoClass> pedidosMaterial =
                                new List<SolicitacaoCompraPedidoClass>();
                            foreach (itemNecessidadeCompraPedidoClass pedido in item.Pedidos)
                            {
                                pedidosMaterial.Add(new SolicitacaoCompraPedidoClass(pedido.IdPedidoItem,
                                                                                     pedido.Quantidade, sol, this.conn));
                            }



                            sol.setMaterial(
                                mat,
                                qtd,
                                item.qtdAComprarUnidadeUso,
                                pedidosMaterial,
                                dataEntrega,
                                "Lançamento Automático");

                        }
                        else
                        {
                            if (item.tipoItem == TipoItemCompra.Epi)
                            {
                                EpiClass epi = (EpiClass) item.Item;

                                DateTime? dataEntrega = epi.calculaEntregaPrevistaCompra(this.diasPCP, Configurations.DataIndependenteClass.GetData());
                                if (dataEntrega == null)
                                {
                                    dataEntrega = Configurations.DataIndependenteClass.GetData();
                                }
                               
                                List<SolicitacaoCompraPedidoClass> pedidosEpi = new List<SolicitacaoCompraPedidoClass>();
                                /*
                               foreach (itemNecessidadeCompraPedidoClass pedido in item.Pedidos)
                               {
                                   pedidosEpi.Add(new SolicitacaoCompraPedidoClass(pedido.IdPedidoItem,
                                                                                       pedido.Quantidade, sol,
                                                                                       this.conn));
                               }
                               */
                                sol.setEpi(
                                    epi,
                                    qtd,
                                    item.qtdAComprarUnidadeUso,
                                    pedidosEpi,
                                    dataEntrega.Value,
                                    "Lançamento Automático");
                            }
                            else
                            {

                                ProdutoClass prod = (ProdutoClass) item.Item;
                                DateTime? dataEntrega = prod.calculaEntregaPrevistaCompra(this.diasPCP, Configurations.DataIndependenteClass.GetData());
                                if (dataEntrega == null)
                                {
                                    dataEntrega = Configurations.DataIndependenteClass.GetData();
                                }

                                List<SolicitacaoCompraPedidoClass> pedidosProduto =
                                    new List<SolicitacaoCompraPedidoClass>();
                                foreach (itemNecessidadeCompraPedidoClass pedido in item.Pedidos)
                                {
                                    pedidosProduto.Add(new SolicitacaoCompraPedidoClass(pedido.IdPedidoItem,
                                                                                        pedido.Quantidade, sol,
                                                                                        this.conn));
                                }

                                sol.setProduto(
                                    prod,
                                    qtd,
                                    item.qtdAComprarUnidadeUso,
                                    pedidosProduto,
                                    dataEntrega.Value,
                                    "Lançamento Automático");
                            }

                        }


                        #region MOnta Histórico de Cálculo

                        sol.HistoricoCalculoNecessidade = item.HistoricoCalculo;

                        #endregion

                        sol.Save(ref command, null, false);
                    }

                }
                command.Transaction.Commit();


            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao gerar as solicitações de compra automáticamente.\r\n" + e.Message, e);
            }

        }
    }
}
