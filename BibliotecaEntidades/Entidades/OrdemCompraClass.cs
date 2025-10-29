using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.SDC.dto;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

namespace BibliotecaEntidades.Entidades
{
    public class OrdemCompraClass : OrdemCompraBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do OrdemCompraClass";
        protected new const string ErroDelete = "Erro ao excluir o OrdemCompraClass  ";
        protected new const string ErroSave = "Erro ao salvar o OrdemCompraClass.";
        protected new const string ErroCollectionSolicitacaoCompraClassOrdemCompra = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
        protected new const string ErroCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra = "Erro ao carregar a coleção de OrdemCompraDocumentoEnviadoClass.";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do OrdemCompraClass.";
        protected new const string MensagemUtilizadoCollectionSolicitacaoCompraClassOrdemCompra = "A entidade OrdemCompraClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
        protected new const string MensagemUtilizadoCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra = "A entidade OrdemCompraClass está sendo utilizada nos seguintes OrdemCompraDocumentoEnviadoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade OrdemCompraClass está sendo utilizada.";

        #endregion


        public OrdemCompraClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
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

        public void SetFornecedor(FornecedorClass fornecedor)
        {
            try
            {

                foreach (SolicitacaoCompraClass solicitacao in CollectionSolicitacaoCompraClassOrdemCompra)
                {
                    if (solicitacao.Material != null && solicitacao.Material.CollectionMaterialFornecedorClassMaterial.All(a => a.Fornecedor != fornecedor))
                    {
                        throw new Exception("Não é possível utilizar esse fornecedor pois ele não possui o material " + solicitacao.Material);
                    }

                    if (solicitacao.Produto != null && solicitacao.Produto.CollectionProdutoFornecedorClassProduto.All(a => a.Fornecedor != fornecedor))
                    {
                        throw new Exception("Não é possível utilizar esse fornecedor pois ele não possui o produto " + solicitacao.Produto);
                    }
                }


                this.Fornecedor = fornecedor;
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }



        }

        public void SetMensagens(string email, string rodape)
        {
            this.MsgEmail = email;
            this.Rodape = rodape;

        }

        public void SetFormaPagamento(FormaPagamentoClass formaPagamento)
        {
            this.FormaPagamento = formaPagamento;
        }

        public void SetObservacao(string obs)
        {
            this.Observacao = obs;
        }

        public void RemoverLinha(SolicitacaoCompraClass solicitacao)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();
                if (!this.CollectionSolicitacaoCompraClassOrdemCompra.Contains(solicitacao))
                {
                    throw new Exception("Linha não encontrada.");
                }

                if (this.CollectionSolicitacaoCompraClassOrdemCompra.Count == 1)
                {
                    throw new Exception("Não é possível excluir a última solicitação da OC, você deve excluir a OC.");
                }


                solicitacao.RemoverOC();
                CollectionSolicitacaoCompraClassOrdemCompra.Remove(solicitacao);

                this.RecalcularTotais();

                this.Save(ref command);
                solicitacao.Save(ref command);

                command.Transaction.Commit();
            }

            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }

            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao remover a linha da OC\r\n" + e.Message, e);
            }
        }

        public void RecalcularTotais()
        {
            try
            {
                double tmpValorTotal = 0;
                double tmpValorTotalComImpostos = 0;
                double totalScsSemDesconto = CollectionSolicitacaoCompraClassOrdemCompra.Sum(a => (a.ValorTotalOc ?? 0));

                foreach (SolicitacaoCompraClass sol in CollectionSolicitacaoCompraClassOrdemCompra)
                {

                    double razao = Math.Round((sol.ValorTotalOc??0) / totalScsSemDesconto, 15, MidpointRounding.ToEven);

                    if (DescontoP > 0 && !IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO))
                    {
                        sol.AplicaDescontos(this.DescontoP/100);
                    }

                    if (DescontoR > 0 && !IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO))
                    {
                        sol.AplicaDescontosReais(Math.Round(DescontoR * razao, 4));
                    }

                    tmpValorTotal += sol.ValorTotalOc ?? 0;
                    tmpValorTotalComImpostos += sol.ValorTotalOcComImpostos;
                }
                
                this.Valor = tmpValorTotal;
                this.ValorComImpostos = tmpValorTotalComImpostos;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recalcular os totais.\r\n" + e.Message, e);
            }
        }

        public double ValorFinalComDesconto()
        {
            double valorComDesconto = 0;

            if (this.DescontoP > 0)
            {
                double desconto = this.DescontoP / 100;

                Double? valorTotal = (this.Valor * (1 - desconto));

                if (valorTotal.HasValue)
                {
                    valorComDesconto = valorTotal.Value;
                }

            }

            else if (this.DescontoR > 0)
            {
                Double? valorTotal = this.Valor - this.DescontoR;

                if (valorTotal.HasValue)
                {
                    valorComDesconto = valorTotal.Value;
                }

            }

            return Math.Round(valorComDesconto, 2);
        }
        
        public static OrdemCompraClass GerarOc(OrdemCompraDto dto, FormaPagamentoClass formaPagamento, string observacoes, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            OrdemCompraClass toRet = new OrdemCompraClass(usuario, conn)
            {
                AcsUsuario = usuario,
                Comprador = CompradorClass.GetComprador(usuario, conn),
                Data = dto.data,
                DescontoP = dto.descontoP,
                DescontoR = dto.descontoR,
                Status = StatusOrdemCompra.Nova,
                Tipo = TipoOrdemCompra.OrdemCompra,
                Valor = dto.valor,
                ValorComImpostos = dto.valor
            };
            if (Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.FLUXO_APROVACAO_COMPRAS_HABILITADO)) == 1 &&
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.SIMULADOR_COMPRAS_HABILITADO)) == 1)
            {
                toRet.Status = StatusOrdemCompra.AguardandoAprovacaoCompras;
            }
            {
                    
            }
            toRet.SetFormaPagamento(formaPagamento);
            FornecedorClass fornecedor = FornecedorClass.GetEntidade(dto.fornecedorId, LoginClass.UsuarioLogado.loggedUser, conn);

            if (fornecedor == null)
            {
                throw new ExcecaoTratada("Fornecedor não encontrado com o ID " + dto.id);
            }

            toRet.SetFornecedor(fornecedor);
            toRet.SetObservacao(observacoes);

            toRet.SetMensagens(IWTConfiguration.Conf.getConf(Constants.COMPRAS_EMAIL_MENSAGEM), IWTConfiguration.Conf.getConf(Constants.COMPRAS_RODAPE));

            double valorComImpostos = 0;

            double valorTotalProdutosOc = dto.collectionSolicitacaoCompra.Sum(a => a.valorTotalOc);


            foreach (SolicitacaoCompraDto solicitacaoDto in dto.collectionSolicitacaoCompra)
            {
                SolicitacaoCompraClass sc = SolicitacaoCompraClass.GetEntidade(solicitacaoDto.id, usuario, conn);

                if (sc == null)
                {
                    throw new Exception("Não foi encontrada a SC com número " + solicitacaoDto.id);
                }

                sc.EntregaPrevista = solicitacaoDto.entregaPrevista;
                sc.UnidadeCompra = solicitacaoDto.unidadeCompra;

                sc.Qtd = Math.Round(solicitacaoDto.qtdUnidadeCompra, 4, MidpointRounding.ToEven);
                sc.SaldoRecebimento = sc.Qtd;

                sc.QtdUnidadeUso = Math.Round(solicitacaoDto.qtdUnidadeUso, 4, MidpointRounding.ToEven);

                
                double conversao = Math.Round(sc.QtdUnidadeUso / sc.Qtd.Value, 10, MidpointRounding.AwayFromZero);

                if (Math.Abs(solicitacaoDto.aliquotaIcmsOc) > 0.000001)
                {
                    sc.AliquotaIcmsOc = Math.Round(solicitacaoDto.aliquotaIcmsOc, 4, MidpointRounding.ToEven);
                }
                else
                {
                    sc.AliquotaIcmsOc = 0;
                }

                if (Math.Abs(solicitacaoDto.aliquotaIpiOc) > 0.000001)
                {
                    sc.AliquotaIpiOc = Math.Round(solicitacaoDto.aliquotaIpiOc, 4, MidpointRounding.ToEven);
                }
                else
                {
                    sc.AliquotaIpiOc = 0;
                }


                double razaoTotalOc = Math.Round(solicitacaoDto.valorTotalOc / valorTotalProdutosOc, 15, MidpointRounding.ToEven);

                if (Math.Abs(solicitacaoDto.valorTotalOc) > 0.000001)
                {
                    sc.ValorTotalOc = Math.Round(solicitacaoDto.valorTotalOc, 4, MidpointRounding.ToEven);
                    if (dto.frete > 0)
                    {
                        sc.ValorTotalOc = sc.ValorTotalOc + Math.Round(dto.frete * razaoTotalOc, 4, MidpointRounding.ToEven);
                    }

                    if (dto.descontoR > 0)
                    {
                        //sc.ValorTotalOc = sc.ValorTotalOc - Math.Round(dto.descontoR * razaoTotalOc, 4, MidpointRounding.ToEven);
                    }

                    if (dto.descontoP > 0)
                    {
                        //sc.ValorTotalOc = Math.Round(sc.ValorTotalOc.Value * (1 - (dto.descontoP) / 100), 4, MidpointRounding.ToEven);
                    }
                }
                else
                {
                    sc.ValorTotalOc = sc.ValorTotalOc ?? 0;
                }


                if (Math.Abs(solicitacaoDto.valorUnitarioOc) > 0.000001)
                {
                    sc.ValorUnitarioOc = Math.Round(sc.ValorTotalOc.Value / sc.Qtd.Value, 4, MidpointRounding.ToEven);
                    
                }

                //valorComImpostos = Math.Round(valorComImpostos + sc.ValorTotalOcComImpostos, 4, MidpointRounding.ToEven);


                bool itemNaoDeveAtualizarPrecosNoRecebimento = false;
                bool possuiDesconto = false;

                if (toRet.DescontoP > 0 || toRet.DescontoR > 0)
                {
                    possuiDesconto = true;
                }

                if (
                    IWTConfiguration.Conf.getBoolConf(Constants.MARCAR_AUTOMATICAMENTE_OC_COM_DESCONTO_PARA_NAO_ATUALIZAR_PRECO_PRODUTOS) &&
                    possuiDesconto
                    )
                {
                    itemNaoDeveAtualizarPrecosNoRecebimento = true;
                }

                sc.SetNaoAtualizaPrecoRecebimento(itemNaoDeveAtualizarPrecosNoRecebimento);

                sc.Comprar(toRet);
            }


            //toRet.ValorComImpostos = valorComImpostos;



            return toRet;
        }

        public static void GerarAprovacao(OrdemCompraClass oc, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn, ref IWTPostgreNpgsqlCommand command)
        {
            if (oc.CollectionOrdemCompraAprovacaoClassOrdemCompra.ToArray().Length > 0)
            {
                try
                {
                    foreach (OrdemCompraAprovacaoClass ordemCompraAprovacao in oc.CollectionOrdemCompraAprovacaoClassOrdemCompra)
                    {
                        ordemCompraAprovacao.Delete(ref command);
                    }
                    oc.CollectionOrdemCompraAprovacaoClassOrdemCompra.Clear();
                }
                catch (ExcecaoTratada)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw;
                }

                catch (Exception e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw new Exception("Erro ao remover os aprovadores da OC\r\n" + e.Message, e);
                }
            }
            List<NivelAprovacaoComprasClass> nivelAprovacaoComprasList = NivelAprovacaoComprasClass.GetAllAprovacaoComprasClasses(usuario, conn);
            if (nivelAprovacaoComprasList.Count == 0 || nivelAprovacaoComprasList[nivelAprovacaoComprasList.Count - 1].LimiteMaxAprovacao < oc.ValorFinalComDesconto())
            {
                throw new Exception("Não existem aprovadores com o limite máximo suficiente para suportar o valor de R$ " + oc.ValorFinalComDesconto() + "\r\n");
            }
            int sequencia = 1;
            foreach (NivelAprovacaoComprasClass nivelAprovacaoCompras in nivelAprovacaoComprasList)
            {
                if (oc.ValorFinalComDesconto() >= nivelAprovacaoCompras.LimiteMaxAprovacao)
                {
                    OrdemCompraAprovacaoClass ordemCompraAprovacaoClass = new OrdemCompraAprovacaoClass(usuario, conn)
                    {
                        OrdemCompra = (oc),
                        AcsUsuarioAprovador = (nivelAprovacaoCompras.AcsUsuario),
                        Sequencia = sequencia,
                        Aprovado = null
                    };
                    oc.CollectionOrdemCompraAprovacaoClassOrdemCompra.Add(ordemCompraAprovacaoClass);
                    sequencia++;
                }
                else
                {
                    OrdemCompraAprovacaoClass ordemCompraAprovacaoClass = new OrdemCompraAprovacaoClass(usuario, conn)
                    {
                        OrdemCompra = (oc),
                        AcsUsuarioAprovador = (nivelAprovacaoCompras.AcsUsuario),
                        Sequencia = sequencia,
                        Aprovado = null
                    };
                    oc.CollectionOrdemCompraAprovacaoClassOrdemCompra.Add(ordemCompraAprovacaoClass);

                    break;
                }
            }
        }

        private void VerificaStatus()
        {

            try
            {

                if (Status != StatusOrdemCompra.AguardandoAprovacaoCompras)
                {

                    StatusSolicitacaoCompra menorStatus = StatusSolicitacaoCompra.Cancelada;
                    StatusSolicitacaoCompra maiorStatus = StatusSolicitacaoCompra.Nova;

                    foreach (SolicitacaoCompraClass sol in CollectionSolicitacaoCompraClassOrdemCompra)
                    {
                        if (sol.Status < menorStatus)
                        {
                            menorStatus = sol.Status.Value;
                        }

                        if (sol.Status > maiorStatus)
                        {
                            maiorStatus = sol.Status.Value;
                        }

                    }



                    StatusOrdemCompra statusOc = StatusOrdemCompra.Nova;

                    if (menorStatus == StatusSolicitacaoCompra.Cancelada)
                    {
                        statusOc = StatusOrdemCompra.Cancelada;
                    }

                    if (menorStatus == StatusSolicitacaoCompra.RecebidaTotal)
                    {
                        statusOc = StatusOrdemCompra.Recebida;
                    }
                    else
                    {
                        if (maiorStatus == StatusSolicitacaoCompra.RecebidaParcial ||
                            menorStatus == StatusSolicitacaoCompra.RecebidaParcial || (maiorStatus == StatusSolicitacaoCompra.RecebidaTotal && menorStatus != StatusSolicitacaoCompra.RecebidaTotal))
                        {
                            statusOc = StatusOrdemCompra.RecebidaParcial;
                        }
                        else
                        {
                            if (menorStatus == maiorStatus)
                            {
                                switch (menorStatus)
                                {
                                    case StatusSolicitacaoCompra.Nova:
                                        break;
                                    case StatusSolicitacaoCompra.AprovadaPCP:
                                        break;
                                    case StatusSolicitacaoCompra.AprovadaCompras:
                                        break;
                                    case StatusSolicitacaoCompra.Comprada:
                                        if (this.Status == StatusOrdemCompra.Enviada)
                                        {
                                            statusOc = StatusOrdemCompra.Enviada;
                                        }

                                        break;
                                    case StatusSolicitacaoCompra.RecebidaParcial:
                                        statusOc = StatusOrdemCompra.RecebidaParcial;
                                        break;
                                    case StatusSolicitacaoCompra.RecebidaTotal:
                                        statusOc = StatusOrdemCompra.Recebida;
                                        break;
                                    case StatusSolicitacaoCompra.Cancelada:
                                        statusOc = StatusOrdemCompra.Cancelada;
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }
                    }

                    if (statusOc != Status)
                    {
                        Status = statusOc;
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ajustar o status da ordem de compra.\r\n" + e.Message, e);
            }
            
        }

        protected override void CalcularCamposAntesValidacaoSalvar(ref IWTPostgreNpgsqlCommand command)
        {
            RecalcularTotais();
            VerificaStatus();
        }
    }
}
