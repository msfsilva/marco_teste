using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public static class NotaFiscalEntradaFuncoesAuxiliares
    {

        //Operação para desfazer o recebimento, a operação não desfaz a movimentação de estoque.
        public static string DesfazerRecebimento(string cnpjFornecedor, string serieNfe, string numeroNfe, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            string erro = null;

            if (string.IsNullOrEmpty(cnpjFornecedor.Trim()))
            {
                return "Informe o CNPJ do fornecedor";
            }

            if (string.IsNullOrEmpty(serieNfe.Trim()))
            {
                return "Informe a Série da Nota Fiscal de Entrada";
            }

            if (string.IsNullOrEmpty(numeroNfe.Trim()))
            {
                return "Informe o Número da Nota Fiscal de Entrada";
            }


            NotaFiscalEntradaClass nf = NotaFiscalEntradaClass.GetByFornecedorNumero(cnpjFornecedor, serieNfe, numeroNfe, usuario, conn);

            if (!nf.TotalmenteRecebida)
            {
                return "A nota fiscal informada não foi totalmente recebida, conclua o recebimento antes de desfaze-lo";
            }

            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.Transaction = conn.BeginTransaction();

            try
            {

                foreach (ContaPagarClass pagar in nf.CollectionContaPagarClassNotaFiscalEntrada)
                {
                    if (pagar.DataPagamento != null)
                    {
                        return "Não é possível desfazer o recebimento pois existem contas a pagar vincualadas a essa nota fiscal já baixadas. Faça o estorno através do módulo financeiro e repita a operação";
                    }
                    pagar.Delete(ref command);
                }
                nf.CollectionContaPagarClassNotaFiscalEntrada.Clear();



                foreach (NotaFiscalEntradaLinhaClass linha in nf.CollectionNotaFiscalEntradaLinhaClassNotaFiscalEntrada)
                {
                    if (linha.CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha.Count > 0)
                    {
                        foreach (HistoricoCompraMaterialClass historicoCompra in linha.CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha)
                        {
                            foreach (LoteSolicitacaoCompraClass loteSolicitacaoCompra in historicoCompra.Lote.CollectionLoteSolicitacaoCompraClassLote)
                            {
                                DesfazerRecebimentoSc(loteSolicitacaoCompra, command);
                                loteSolicitacaoCompra.Delete(ref command);
                            }

                            historicoCompra.Delete(ref command);
                            historicoCompra.Lote.Delete(ref command);
                            
                        }
                    }
                    else
                    {
                        if (linha.CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha.Count > 0)
                        {
                            foreach (HistoricoCompraProdutoClass historicoCompra in linha.CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha)
                            {
                                foreach (LoteSolicitacaoCompraClass loteSolicitacaoCompra in historicoCompra.Lote.CollectionLoteSolicitacaoCompraClassLote)
                                {
                                    DesfazerRecebimentoSc(loteSolicitacaoCompra, command);
                                    loteSolicitacaoCompra.Delete(ref command);
                                }

                                historicoCompra.Delete(ref command);
                                historicoCompra.Lote.Delete(ref command);
                            
                            }
                        }
                        else
                        {
                            if (linha.CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha.Count > 0)
                            {
                                foreach (HistoricoCompraEpiClass historicoCompra in linha.CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha)
                                {
                                    foreach (LoteSolicitacaoCompraClass loteSolicitacaoCompra in historicoCompra.Lote.CollectionLoteSolicitacaoCompraClassLote)
                                    {
                                        DesfazerRecebimentoSc(loteSolicitacaoCompra, command);
                                        loteSolicitacaoCompra.Delete(ref command);
                                    }

                                    historicoCompra.Delete(ref command);
                                    historicoCompra.Lote.Delete(ref command);
                                    
                                }
                            }
                            else
                            {
                                return "Erro ao identificar os históricos de compra, consulte a equipe IWT. (1)";
                            }
                        }
                    }

                    linha.CollectionHistoricoCompraEpiClassNotaFiscalEntradaLinha.Clear();
                    linha.CollectionHistoricoCompraMaterialClassNotaFiscalEntradaLinha.Clear();
                    linha.CollectionHistoricoCompraProdutoClassNotaFiscalEntradaLinha.Clear();

                    linha.Vinculada = false;
                    linha.Save(ref command);
                }

                

                command.Transaction.Commit();
            }
            catch
            {
                command?.Transaction?.Rollback();
                throw;
            }
            finally
            {
                BufferAbstractEntity.limparBuffer();
            }


            return erro;
        }

        private static void DesfazerRecebimentoSc(LoteSolicitacaoCompraClass loteSolicitacaoCompra, IWTPostgreNpgsqlCommand command)
        {
            double qtdCompraRecebidaNaSc = loteSolicitacaoCompra.QuantidadeCompra;

            SolicitacaoCompraClass sc = loteSolicitacaoCompra.SolicitacaoCompra;
            sc.SaldoRecebimento = Math.Round((sc.SaldoRecebimento ?? 0) + qtdCompraRecebidaNaSc, 5, MidpointRounding.AwayFromZero);
            if (Math.Abs((sc.SaldoRecebimento ?? 0) - (sc.Qtd ?? 0)) < 0.00001)
            {
                sc.Status = StatusSolicitacaoCompra.Comprada;
            }
            else
            {
                sc.Status = StatusSolicitacaoCompra.RecebidaParcial;
            }

            sc.CollectionLoteSolicitacaoCompraClassSolicitacaoCompra.Clear();

            sc.OrdemCompra.Save(ref command);

            
        }
    }
}
