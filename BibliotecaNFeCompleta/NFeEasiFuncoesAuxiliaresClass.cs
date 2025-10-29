using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaNotasFiscais;
using BibliotecaProdutos;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTFunctions;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;


namespace BibliotecaNFeCompleta
{
    public class NFeEasiFuncoesAuxiliaresClass
    {

        public static EmbarqueClass SeparaNotaRejeitadaEmbarque(NfPrincipalClass nf, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command)
        {
            try
            {
                try
                {
                    LogClass.EscreverLog("TratamentoRejeicaoSeparaEmbarque:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch { }
                List<AtendimentoClass> atendimentos = new AtendimentoClass(usuario, command.Connection).Search(
                    new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("NfPrincipal", nf)
                    }).ConvertAll(a => (AtendimentoClass) a).ToList();


                EmbarqueClass embarque = null;
                EmbarqueClass embarqueAntigo = null;
                foreach (AtendimentoClass atendimento in atendimentos)
                {
                    try
                    {
                        LogClass.EscreverLog("TratamentoRejeicaoSeparaEmbarqueAtendimento:" +atendimento.ID, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }

                    if (embarque == null)
                    {
                        try
                        {
                            LogClass.EscreverLog("TratamentoRejeicaoSeparaEmbarqueEmbarqueVazio:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                        }
                        catch { }

                        bool criaNovoEmbarque = false;
                        embarqueAntigo = atendimento.OrderItemEtiquetaConferencia.Embarque;

                        foreach (OrderItemEtiquetaConferenciaClass item in embarqueAntigo.CollectionOrderItemEtiquetaConferenciaClassEmbarque)
                        {
                            if (item.CollectionAtendimentoClassOrderItemEtiquetaConferencia.Any(atendimentoEmbarqueAntigo => atendimentoEmbarqueAntigo.NfPrincipal != nf))
                            {
                                criaNovoEmbarque = true;
                            }
                        }

                        if (criaNovoEmbarque)
                        {
                            try
                            {
                                LogClass.EscreverLog("TratamentoRejeicaoSeparaEmbarqueCriaNovoEmbarque:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                            }
                            catch { }

                            //Cria um novo embarque
                            embarque = new EmbarqueClass(usuario, command.Connection)
                            {
                                DataHora = atendimento.OrderItemEtiquetaConferencia.Embarque.DataHora,
                                LiberacaoHora = atendimento.OrderItemEtiquetaConferencia.Embarque.LiberacaoHora,
                                LiberacaoUsuario = atendimento.OrderItemEtiquetaConferencia.Embarque.LiberacaoUsuario,
                                LiberadoNf = atendimento.OrderItemEtiquetaConferencia.Embarque.LiberadoNf,
                                NfAutorizada = false,
                                NfEmitida = false,
                                Transporte = atendimento.OrderItemEtiquetaConferencia.Embarque.Transporte,
                                Usuario = atendimento.OrderItemEtiquetaConferencia.Embarque.Usuario,
                            };
                        }
                        else
                        {
                            embarque = embarqueAntigo;
                            embarque.NfAutorizada = false;
                            embarque.NfEmitida = false;
                        }


                    }

                    if (embarque != embarqueAntigo)
                    {
                        try
                        {
                            LogClass.EscreverLog("TratamentoRejeicaoSeparaEmbarqueNovoDifAntigo:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                        }
                        catch { }
                        embarqueAntigo.CollectionOrderItemEtiquetaConferenciaClassEmbarque.Remove(atendimento.OrderItemEtiquetaConferencia);
                        
                        atendimento.OrderItemEtiquetaConferencia.Embarque = embarque;
                        embarque.CollectionOrderItemEtiquetaConferenciaClassEmbarque.Add(atendimento.OrderItemEtiquetaConferencia);
                    }

                    try
                    {
                        LogClass.EscreverLog("TratamentoRejeicaoSeparaEmbarqueEmbarqueSave:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }
                    embarque.Save(ref command);


                    double qtdAtendimento = atendimento.Quantidade ?? 0;

                    #region Atualizar Saldos


                    PedidoItemClass pedidoItem = atendimento.PedidoItem;

                    pedidoItem.Saldo = Math.Round(pedidoItem.Saldo + qtdAtendimento, 5);
                    pedidoItem.Status = StatusPedido.Pendente;
                    pedidoItem.DataEncerramento = null;
                    pedidoItem.CollectionAtendimentoClassPedidoItem.Remove(atendimento);

                    pedidoItem.Save(ref command);


                    //Atualiza o saldo do item configurado;
                    OrderItemEtiquetaClass pedidoConfigurado = atendimento.OrderItemEtiqueta;


                    pedidoConfigurado.Saldo = Math.Round(pedidoConfigurado.Saldo + qtdAtendimento, 5);
                    pedidoConfigurado.StatusPedido = "P";
                    pedidoConfigurado.CollectionAtendimentoClassOrderItemEtiqueta.Remove(atendimento);

                    pedidoConfigurado.Save(ref command);


                    if (atendimento.Atlas)
                    {
                        command.CommandText = "UPDATE order_item SET \"status\" = 'WAIT_INVOI' WHERE order_number='" + pedidoItem.Numero + "' AND order_pos=" + pedidoItem.Posicao + "; ";
                        command.ExecuteNonQuery();
                    }

                    #endregion

                    #region Estorno do estoque

                    ProdutoClass produto = pedidoItem.Produto;
                    ProdutoKClass prk = null;

                    if (pedidoConfigurado.ProdutoK != null)
                    {
                        prk = pedidoConfigurado.ProdutoK;
                    }

                    bool EmiteOp;
                    double multiplicadorQuantidadeItemK = 1;
                    if (prk == null)
                    {
                        EmiteOp = produto.EmiteOp;
                    }
                    else
                    {
                        EmiteOp = prk.EmiteOp;
                        if (prk.UtilizaDimensaoQuantidadeBaixa)
                        {
                            //Utiliza a dimensão do agrupador para indicar a quantidade de itens que devem ser baixados
                            //do estoque por unidade do agrupador
                            double tmp;

                            if (double.TryParse(prk.Dimensao, out tmp))
                            {
                                multiplicadorQuantidadeItemK = tmp;
                            }
                            else
                            {
                                throw new Exception("O item " + produto.CodigoCliente + " possui um item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                            }
                        }
                    }

                    if (prk != null)
                    {
                        EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProdutoK(
                            prk,
                            qtdAtendimento,
                            "Estorno de Baixa de Materiais por Rejeição da NFe",
                            "",
                            LoginClass.UsuarioLogado.loggedUser, false, ref command);
                    }
                    else
                    {
                        EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(
                            produto,
                            qtdAtendimento * multiplicadorQuantidadeItemK,
                            "Estorno de Baixa de Materiais por Rejeição da NFe",
                            "",
                            LoginClass.UsuarioLogado.loggedUser, false, ref command, false);
                    }



                    #endregion

                    #region Estorno Material Cliente

                    double razaoPedido = qtdAtendimento / pedidoItem.Quantidade;
                    foreach (PedidoItemLoteClienteClass pedidoLote in pedidoItem.CollectionPedidoItemLoteClienteClassPedidoItem)
                    {
                        double qtdDevolver = Math.Round((pedidoLote.Quantidade * razaoPedido), 5);
                        pedidoLote.SaldoDevolucao = Math.Round(pedidoLote.SaldoDevolucao + qtdDevolver, 5);
                        pedidoLote.Lote.SaldoDevolucao = Math.Round(pedidoLote.Lote.SaldoDevolucao + qtdDevolver, 5);
                        if (pedidoLote.Lote.SaldoDevolucao > 0.00001)
                        {
                            pedidoLote.Lote.Situacao = StatusLote.EmAberto;
                        }


                        if (pedidoLote.Lote.Material != null)
                        {
                            EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoMaterial(pedidoLote.Lote.Material, qtdDevolver,
                                "Estorno da Devolução Material do Cliente",
                                " NF Nº" + atendimento.NfPrincipal.Numero,
                                usuario, false, ref command, false);
                        }
                        else
                        {
                            EstoqueMovimentacao.EstornarBaixaEstoqueAgrupadoProduto(pedidoLote.Lote.Produto, qtdDevolver,
                                "Estorno da Devolução Produtos do Cliente",
                                " NF Nº" + atendimento.NfPrincipal.Numero,
                                usuario, false, ref command, false);
                        }

                        pedidoLote.Lote.Save(ref command);
                        pedidoLote.Save(ref command);
                    }

                    #endregion

                    try
                    {
                        LogClass.EscreverLog("TratamentoRejeicaoSeparaEmbarqueAtendimentoDelete:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }

                    atendimento.Delete(ref command);
                }

                return embarque;

            }
            catch (ExcecaoTratada)
            {

                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao separar uma nota rejeitada do embarque:\r\n" + e.Message, e);
            }




        }


        public static void RejeicaoNFe(NfPrincipalClass nf, string motivo, AcsUsuarioClass usuario, IWTPostgreNpgsqlCommand command, out string mensagemUsuario)
        {
            mensagemUsuario = null;

            try
            {
                LogClass.EscreverLog("TratamentoRejeicao:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
            }
            catch { }

            if (nf.Tipo == TipoNota.Saida)
            {
                try
                {
                    LogClass.EscreverLog("TratamentoRejeicaoSaida:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch { }

                List<ContaReceberClass> contasReceber = new ContaReceberClass(usuario, command.Connection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("NfPrincipal", nf)
                }).ConvertAll(a => (ContaReceberClass)a).ToList();

                foreach (ContaReceberClass conta in contasReceber)
                {
                    conta.Delete(ref command);
                }


                string pedidosFaturamentoAntecipado = "";


                #region NotasRelacionadas

                List<NfDependeClass> dependentes = new NfDependeClass(usuario, command.Connection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("NfPrincipalDepende", nf)
                }).ToList().ConvertAll(a => (NfDependeClass) a);

                foreach (NfDependeClass dependente in dependentes)
                {
                    dependente.NfPrincipal.Delete(ref command);
                    dependente.Delete(ref command);
                }

                #endregion

                #region Notas de Faturamento Antecipado
                List<PedidoItemClass> pedidos = new PedidoItemClass(usuario, command.Connection).Search(
                    new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("NfPrincipalFaturamentoAntecipado", nf)
                    }).ConvertAll(a => (PedidoItemClass) a).ToList();


                if (pedidos.Count > 0)
                {
                    try
                    {
                        LogClass.EscreverLog("TratamentoRejeicaoFaturamentoAntecipado:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }
                    foreach (PedidoItemClass pedido in pedidos)
                    {
                        NotaFiscalFuncoesAuxiliares.DesfazerEmissaoNFeFaturamentoAntecipado(pedido, nf, usuario, command);
                        pedidosFaturamentoAntecipado += pedido.NumeroPosicao + " - ";
                    }

                    nf.Delete(ref command);

                    mensagemUsuario = "A nota fiscal " + nf.Numero + " foi rejeitada com o seguinte motivo: " + motivo + ", o seguintes pedidos de faturamento antecipado foram reabertos: " + pedidosFaturamentoAntecipado + ".";
                    return;
                }

                #endregion


                #region Notas de Remessa de Serviço Externo
                List<OrdemProducaoEnvioTerceirosClass> opsEnvioTerceiro = new OrdemProducaoEnvioTerceirosClass(usuario, command.Connection).Search(
                    new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("NfPrincipal", nf)
                    }).ConvertAll(a => (OrdemProducaoEnvioTerceirosClass)a).ToList();


                if (opsEnvioTerceiro.Count > 0)
                {
                    try
                    {
                        LogClass.EscreverLog("TratamentoRejeicaoOrdemProducaoEnvioTerceirosClass:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }
                    foreach (OrdemProducaoEnvioTerceirosClass opEnvio in opsEnvioTerceiro)
                    {
                        NotaFiscalFuncoesAuxiliares.DesfazerEmissaoNFeFaturamentoEnvioServicoExterno(opEnvio, nf, usuario, command);
                        pedidosFaturamentoAntecipado += opEnvio.ID + " - ";
                    }

                    nf.Delete(ref command);

                    mensagemUsuario = "A nota fiscal " + nf.Numero + " foi rejeitada com o seguinte motivo: " + motivo + ", as seguintes OP tiveram seu envio para Serviço Externo desfeito: " + pedidosFaturamentoAntecipado + ".";
                    return;
                }

                #endregion



                AtendimentoClass atendimento = (AtendimentoClass) new AtendimentoClass(usuario, command.Connection).Search(
                    new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("NfPrincipal", nf)
                    }).FirstOrDefault();


                if (atendimento == null || atendimento.OrderItemEtiquetaConferencia==null || atendimento.OrderItemEtiquetaConferencia.Embarque == null)
                {
                    //Busca se é uma nota de remessa

                    try
                    {
                        LogClass.EscreverLog("TratamentoRejeicaoDelecaoNotaremessa:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                    }
                    catch { }

                    if (atendimento != null)
                    {
                        //Isso não deveria acontecer nunca, mas se acontecer pelo menos permite que o usuário continue. Pode "ferrar" os saldos do pedido pois não vai voltar saldo nenhum, vai só excluir o atendimento.
                        atendimento.Delete(ref command);
                    }

                    nf.Delete(ref command);

                    mensagemUsuario =
                        "A nota fiscal " + nf.Numero + " foi rejeitada com o seguinte motivo: " + motivo + ", não foram encontrados embarques vinculados a mesma. Se essa nota era a segunda nota fiscal de um faturamento com envio para terceiros será necessário emiti-la manualmente pela tela de emissão manual.";
                    return;
                }

                EmbarqueClass novoEmbarque = NFeEasiFuncoesAuxiliaresClass.SeparaNotaRejeitadaEmbarque(nf, usuario, command);

                try
                {
                    LogClass.EscreverLog("TratamentoRejeicaoDelete:" + nf.Numero, ProjectConstants.Constants.CAMINHO_LOG_NF, true);
                }
                catch { }

                nf.Delete(ref command);


                mensagemUsuario =
                    "A nota fiscal " + nf.Numero + " foi rejeitada com o seguinte motivo: " + motivo + ", o pedidos contidos nessa nota estão disponíveis para o faturamento no embarque " + novoEmbarque.ID + ".";
            }
            else
            {
                //Nota de Entrada
              

                DeclaracaoImportacaoClass search3 = new DeclaracaoImportacaoClass(usuario, command.Connection);
                DeclaracaoImportacaoClass di = (DeclaracaoImportacaoClass) search3.Search(new List<SearchParameterClass>() {new SearchParameterClass("NfPrincipal", nf)}).FirstOrDefault();

                if (di != null)
                {
                    di.NfGerada = false;
                    di.Save(ref command);
                }


                NotaFiscalEntradaClass search2 = new NotaFiscalEntradaClass(usuario, command.Connection);
                NotaFiscalEntradaClass nfEntrada = (NotaFiscalEntradaClass) search2.Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("NfPrincipal", nf)
                }).FirstOrDefault();

                if (nfEntrada == null)
                {
                    mensagemUsuario =
                        "A nota fiscal " + nf.Numero + " foi rejeitada com o seguinte motivo: " + motivo;
                    nf.Delete(ref command);
                    return;
                }


                if (nfEntrada.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada.Any(a => a.Vinculada))
                {
                    mensagemUsuario =
                        "A nota fiscal " + nf.Numero + " foi rejeitada com o seguinte motivo: " + motivo +
                        ", é uma nota de entrada, no entanto ela já possui recebimentos realizados, você deve ajustar o estoque manualmente.";

                    return;
                }

                nfEntrada.Delete(ref command);
                nf.Delete(ref command);
            }
        }
    }
}
