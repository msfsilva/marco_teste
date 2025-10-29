using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class OrderItemEtiquetaConferenciaClass : OrderItemEtiquetaConferenciaBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do OrderItemEtiquetaConferenciaClass";
        protected new const string ErroDelete = "Erro ao excluir o OrderItemEtiquetaConferenciaClass  ";
        protected new const string ErroSave = "Erro ao salvar o OrderItemEtiquetaConferenciaClass.";
        protected new const string ErroCollectionAtendimentoClassOrderItemEtiquetaConferencia = "Erro ao carregar a coleção de AtendimentoClass.";
        protected new const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
        protected new const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
        protected new const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
        protected new const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
        protected new const string ErroIdentificacaoEstacaoObrigatorio = "O campo IdentificacaoEstacao é obrigatório";
        protected new const string ErroIdentificacaoEstacaoComprimento = "O campo IdentificacaoEstacao deve ter no máximo 255 caracteres";
        protected new const string ErroIdentificacaoUsuarioObrigatorio = "O campo IdentificacaoUsuario é obrigatório";
        protected new const string ErroIdentificacaoUsuarioComprimento = "O campo IdentificacaoUsuario deve ter no máximo 255 caracteres";
        protected new const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do OrderItemEtiquetaConferenciaClass.";
        protected new const string MensagemUtilizadoCollectionAtendimentoClassOrderItemEtiquetaConferencia = "A entidade OrderItemEtiquetaConferenciaClass está sendo utilizada nos seguintes AtendimentoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade OrderItemEtiquetaConferenciaClass está sendo utilizada.";

        #endregion


        public OrderItemEtiquetaConferenciaClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "":
                    whereClause += "";
                    return true;
                default:
                    return false;
            }
        }

        public static void DesfazerConferencia(OrderItemEtiquetaConferenciaClass conferenciaPai, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command,string justificativa = "Cancelamento da Conferência")
        {
            try
            {


               List<EstornoEstoqueHelper> itensEstornar = new List<EstornoEstoqueHelper>();

                if (!conferenciaPai.ConferenciaPai)
                {
                    throw new ExcecaoTratada("A conferência informada não representa um item pai");
                }

                if (conferenciaPai.OrderItemEtiqueta.SituacaoConferencia == SituacaoConferencia.Total)
                {
                    //Identifica os itens baixados e que não realizam conferencia -- Total do Pedido
                    List<OrderItemEtiquetaClass> itensSemConferencia = new OrderItemEtiquetaClass(usuario, command.Connection).Search(new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("OrderNumberExato", conferenciaPai.OrderItemEtiqueta.OrderNumber),
                        new SearchParameterClass("OrderPos", conferenciaPai.OrderItemEtiqueta.OrderPos),
                        new SearchParameterClass("Cliente", conferenciaPai.OrderItemEtiqueta.Cliente),
                        new SearchParameterClass("NotaFiscal", false),
                        new SearchParameterClass("EtiquetaInterna", false)
                    }).ConvertAll(a => (OrderItemEtiquetaClass) a).ToList();

                    itensEstornar.AddRange(itensSemConferencia.Select(item => new EstornoEstoqueHelper()
                    {
                        ItemPedido = item, QuantidadeEstorno = item.Quantidade
                    }));
                }


                foreach (OrderItemEtiquetaConferenciaClass conferenciaFilho in conferenciaPai.CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai)
                {
                    itensEstornar.Add(new EstornoEstoqueHelper()
                    {
                        ItemPedido = conferenciaFilho.OrderItemEtiqueta,
                        QuantidadeEstorno = conferenciaFilho.QuantidadeConferida
                    });
                }

                #region Realiza os Estornos do Estoque

                foreach (EstornoEstoqueHelper estorno in itensEstornar)
                {

                    bool EmiteOp;
                    double multiplicadorQuantidadeItemK = 1;
                    if (estorno.ItemPedido.ProdutoK == null)
                    {
                        EmiteOp = estorno.ItemPedido.Produto.EmiteOp;
                    }
                    else
                    {
                        EmiteOp = estorno.ItemPedido.ProdutoK.EmiteOp;

                        if (estorno.ItemPedido.ProdutoK.UtilizaDimensaoQuantidadeBaixa)
                        {
                            //Utiliza a dimensão do agrupador para indicar a quantidade de itens que devem ser baixados
                            //do estoque por unidade do agrupador
                            double tmp;

                            if (double.TryParse(estorno.ItemPedido.ProdutoK.Dimensao, out tmp))
                            {
                                multiplicadorQuantidadeItemK = tmp;
                            }
                            else
                            {
                                throw new Exception("O item " + estorno.ItemPedido.CodigoItem + " possui um item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                            }
                        }
                    }

                    double QuantidadeItem = estorno.QuantidadeEstorno;

                    if (EmiteOp)
                    {
                        //item Emite OP, baixa o item produzido
                        if (estorno.ItemPedido.ProdutoK == null)
                        {
                            EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(
                                estorno.ItemPedido.Produto,
                                QuantidadeItem,
                                "Estorno de  Produto Produzido por " + justificativa,
                                "Pedido " + estorno.ItemPedido.OrderNumber + "/" + estorno.ItemPedido.OrderPos,
                                usuario, false, ref command, false);
                        }
                        else
                        {
                            EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProdutoK(
                                estorno.ItemPedido.ProdutoK,
                                QuantidadeItem,
                                "Estorno de  Produto KB Produzido por " + justificativa,
                                "Pedido " + estorno.ItemPedido.OrderNumber + "/" + estorno.ItemPedido.OrderPos,
                                usuario, false, ref command);
                        }
                    }
                    else
                    {
                        //item é não emite OP, baixa os materiais ou  o produto comprado

                        //Identifica se o item é comprado

                        bool retEstorno = true;
                        switch (estorno.ItemPedido.Produto.TipoAquisicao)
                        {
                            case TipoAquisicao.Fabricado:

                                //Verifica se existe estoque do produto acabado, se existir ele tem precedencia sobre a baixa de materiais
                               
                                
                                if (estorno.ItemPedido.ProdutoK == null)
                                {
                                    retEstorno = EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(
                                                estorno.ItemPedido.Produto,
                                                QuantidadeItem,
                                                "Estorno de produto Fabricado por "+justificativa,
                                                "Pedido " + estorno.ItemPedido.OrderNumber + "/" + estorno.ItemPedido.OrderPos,
                                                usuario, false, ref command, false);
                                    
                                }
                                else
                                {
                                    double qtdEstornar = QuantidadeItem * multiplicadorQuantidadeItemK;
                                    retEstorno = EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProdutoK(
                                               estorno.ItemPedido.ProdutoK,
                                               qtdEstornar,
                                               "Estorno de produto KB Fabricado por " + justificativa,
                                               "Pedido " + estorno.ItemPedido.OrderNumber + "/" + estorno.ItemPedido.OrderPos,
                                               usuario, false, ref command);
                                }

                                break;

                            case TipoAquisicao.Comprado:
                                retEstorno = EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(
                                    estorno.ItemPedido.Produto,
                                    QuantidadeItem,
                                    "Estorno de Produto Comprado por " + justificativa,
                                    "Estorno " + estorno.ItemPedido.OrderNumber + "/" + estorno.ItemPedido.OrderPos,
                                    usuario, false, ref command, false);
                                break;


                        }

                        if (!retEstorno)
                        {
                            foreach (PedidoItemConfiguradoMaterialClass material in estorno.ItemPedido.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta)
                            {
                                EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoMaterial(
                                    material.Material,
                                    QuantidadeItem*material.QuantidadeUnidadePai,
                                    "Estorno de Material (Produto " + estorno.ItemPedido.Produto + " sem local de estoque definido) por " + justificativa,
                                    "Estorno " + estorno.ItemPedido.OrderNumber + "/" + estorno.ItemPedido.OrderPos,
                                    usuario, false, ref command, false);
                            }
                        }
                    }



                    estorno.ItemPedido.SaldoConferencia = Math.Round(estorno.ItemPedido.SaldoConferencia + estorno.QuantidadeEstorno, 5);
                    if (estorno.ItemPedido.SaldoConferencia == estorno.ItemPedido.Quantidade)
                    {
                        estorno.ItemPedido.SituacaoConferencia = SituacaoConferencia.NaoIniciada;
                    }
                    else
                    {
                        estorno.ItemPedido.SituacaoConferencia = SituacaoConferencia.Parcial;    
                    }

                    estorno.ItemPedido.Save(ref command);
                }

                #endregion

                OrderItemEtiquetaClass oiePrincipal = conferenciaPai.OrderItemEtiqueta;
                oiePrincipal.EtiquetaExpedicaoImpressa = false;
                oiePrincipal.SaldoConferencia = Math.Round(oiePrincipal.SaldoConferencia + conferenciaPai.QuantidadeConferida, 5);
                if (oiePrincipal.SaldoConferencia == oiePrincipal.Quantidade)
                {
                    oiePrincipal.SituacaoConferencia = SituacaoConferencia.NaoIniciada;
                }
                else
                {
                    oiePrincipal.SituacaoConferencia = SituacaoConferencia.Parcial;
                }


            

                foreach (OrderItemEtiquetaConferenciaClass item in conferenciaPai.CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai)
                {
                    oiePrincipal.CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Remove(item);
                    item.Delete(ref command);
                }
                oiePrincipal.CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Remove(conferenciaPai);
                conferenciaPai.Delete(ref command);

                oiePrincipal.Save(ref command);




            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao desfazer a conferência.\r\n" + e.Message, e);
            }
        }



        private class EstornoEstoqueHelper
        {
            public OrderItemEtiquetaClass ItemPedido { get; set; }
            public double QuantidadeEstorno { get; set; }
        }
    }


    


}
