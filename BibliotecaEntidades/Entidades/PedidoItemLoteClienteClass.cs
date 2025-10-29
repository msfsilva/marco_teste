using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Entidades
{
    public class PedidoItemLoteClienteClass : PedidoItemLoteClienteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do PedidoItemLoteClienteClass";
        protected new const string ErroDelete = "Erro ao excluir o PedidoItemLoteClienteClass  ";
        protected new const string ErroSave = "Erro ao salvar o PedidoItemLoteClienteClass.";
        protected new const string ErroPedidoItemObrigatorio = "O campo PedidoItem é obrigatório";
        protected new const string ErroLoteObrigatorio = "O campo Lote é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do PedidoItemLoteClienteClass.";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade PedidoItemLoteClienteClass está sendo utilizada.";

        #endregion



        public string NumeroNf
        {
            get { return this.Lote?.NfNumero; }
        }


        public string ListaNfsEmitidas
        {
            get
            {
                if (this.Lote == null)
                {
                    return String.Empty;
                }

                string toRet = "";
                foreach (AtendimentoClass atendimento in PedidoItem.CollectionAtendimentoClassPedidoItem)
                {
                    if (atendimento.NfPrincipal.Observacoes.Contains(" DO ITEM " + this.Lote.CodigoItemFornecedorCliente + " DA NF " +NumeroNf))
                    {
                        toRet += atendimento.NfPrincipal.Numero + "/";
                    }
                }

                if (toRet.Length > 0)
                {
                    toRet = toRet.Substring(0, toRet.Length - 1);
                }

                return toRet;

            }
        }

        public PedidoItemLoteClienteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        protected override void InitClass()
        {
        }


        public List<OrdemProducaoClass> OpsUtilizandoPedidoLote
        {
            get { return this.Lote.CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote.Select(ordemProducaoPostoTrabalhoProducaoLote => ordemProducaoPostoTrabalhoProducaoLote.OrdemProducaoPostoTrabalhoProducao.OrdemProducaoPostoTrabalho.OrdemProducao).ToList(); }
        }

        public string OpsUtilizandoPedidoLoteString
        {
            get
            {
                string toRet = "";
                if (this.OpsUtilizandoPedidoLote != null)
                {
                    foreach (OrdemProducaoClass op in OpsUtilizandoPedidoLote)
                    {
                        toRet += " / " + op;
                    }

                    if (toRet.Length > 0)
                    {
                        toRet = toRet.Substring(3);
                    }
                }

                return toRet;
            }
        }


        public override string ToString()
        {
            return ID.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "PedidoItemTexto":
                    command.CommandText += " INNER JOIN pedido_item PedidoItemTexto ON pedido_item_lote_cliente.id_pedido_item = PedidoItemTexto.id_pedido_item ";
                    whereClause += " AND (PedidoItemTexto.pei_numero || '/'|| PedidoItemTexto.pei_posicao LIKE :PedidoItemTextoParametro) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("PedidoItemTextoParametro", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue + "%"));
                    return true;

                case "NumeroNf":
                    command.CommandText += "  LEFT OUTER JOIN public.lote loteNumeroNf ON (public.pedido_item_lote_cliente.id_lote = loteNumeroNf.id_lote) ";
                    whereClause += " AND ( loteNumeroNf.lot_nf_numero LIKE :NumeroNf) ";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("NumeroNf", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue + "%"));
                    return true;
                default:
                    return false;
            }
        }

        public override bool OrderByCustom(SearchParameterClass parametro, ref string orderByClause, SearchOrdenacao ordenacao, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "NumeroNf":
                    command.CommandText += "  LEFT OUTER JOIN public.lote loteNumeroNfOrder ON (public.pedido_item_lote_cliente.id_lote = loteNumeroNfOrder.id_lote) ";
                    orderByClause += " , loteNumeroNfOrder.lot_nf_numero " + ordenacao.ToString() + " ";
                    return true;
                case "ListaNfsEmitidas":
                    return true;
                default:
                    return false;
            }

           
        }

        

        public void AlterarQuantidadePedido(double novaQuantidade)
        {
            try
            {
                double qtdAnterior = this.Quantidade;

                double novoSaldoDevolucao = Math.Round(SaldoDevolucao + (novaQuantidade - qtdAnterior), 5);

                if (novoSaldoDevolucao < 0)
                {
                    throw new ExcecaoTratada("O novo saldo de devolução (" + novoSaldoDevolucao.ToString("F5", CultureInfo.GetCultureInfo("pt-Br")) + ") seria menor do que zero");
                }

                this.Lote.VinculaLoteClienteAoPedido(novaQuantidade - qtdAnterior);
                this.SaldoDevolucao = novoSaldoDevolucao;
                this.Quantidade = novaQuantidade;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao alterar a quantidade.\r\n" + e.Message, e);
            }
        }


    }
}
