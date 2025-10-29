using System;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.Entidades
{
    public class PlanoCorteClass : PlanoCorteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do PlanoCorteClass";
        protected new const string ErroDelete = "Erro ao excluir o PlanoCorteClass  ";
        protected new const string ErroSave = "Erro ao salvar o PlanoCorteClass.";
        protected new const string ErroCollectionPlanoCorteItemClassPlanoCorte = "Erro ao carregar a coleção de PlanoCorteItemClass.";
        protected new const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
        protected new const string ErroValidate = "Erro ao validar os dados do PlanoCorteClass.";
        protected new const string MensagemUtilizadoCollectionPlanoCorteItemClassPlanoCorte = "A entidade PlanoCorteClass está sendo utilizada nos seguintes PlanoCorteItemClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade PlanoCorteClass está sendo utilizada.";

        #endregion


        public PlanoCorteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }

       

        protected override void InitClass()
        {
            this.AcsUsuario = UsuarioAtual;
            this.Data = Configurations.DataIndependenteClass.GetData();
        }



        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "BuscaNumero":
                    whereClause += " AND CAST(id_plano_corte AS VARCHAR) LIKE '%" + parametro.Fieldvalue + "%' ";
                    return true;
                default:
                    return false;
            }
        }

       protected override bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return true;
        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        }

        public PlanoCorteItemOpClass AdicionarItemOP(PedidoItemConfiguradoMaterialClass pedidoMaterial, Operacoes.OrdemProducao.OrdemProducaoClass op)
        {
            try
            {
                PlanoCorteItemClass item =
                    this.CollectionPlanoCorteItemClassPlanoCorte.FirstOrDefault(
                        a =>
                        a.Material == pedidoMaterial.Material &&
                        a.Dimensao1 == pedidoMaterial.DimensaoCorte1 &&
                        a.Dimensao1Valor == pedidoMaterial.PlanoCorteDimensao1Valor &&
                        a.UnidadeMedida1 == pedidoMaterial.UnidadeMedidaDimensao1 &&
                        a.Dimensao2 == pedidoMaterial.DimensaoCorte2 &&
                        a.Dimensao2Valor == pedidoMaterial.PlanoCorteDimensao2Valor &&
                        a.UnidadeMedida2 == pedidoMaterial.UnidadeMedidaDimensao2 &&
                        a.Dimensao3 == pedidoMaterial.DimensaoCorte3 &&
                        a.Dimensao3Valor == pedidoMaterial.PlanoCorteDimensao3Valor &&
                        a.UnidadeMedida3 == pedidoMaterial.UnidadeMedidaDimensao3 &&
                        a.InformacoesAdicionais == pedidoMaterial.PlanoCorteInformacoesAdicionais &&
                        a.PostoTrabalhoCorte == pedidoMaterial.PostoTrabalhoCorte
                        );

                if (item == null)
                {
                    item = new PlanoCorteItemClass(this.UsuarioAtual,this.SingleConnection)
                    {
                        PlanoCorte = this,
                        Material = pedidoMaterial.Material,
                        Quantidade = 0,
                        PostoTrabalhoCorte = pedidoMaterial.PostoTrabalhoCorte,
                        MaterialCodigo = pedidoMaterial.Material.Codigo,
                        MaterialFamilia = pedidoMaterial.FamiliaMaterial.ToString(),
                        MaterialAgrupador = pedidoMaterial.Material.FamiliaMaterial.AgrupadorMaterial.ToString(),
                        PostoNome = pedidoMaterial.PostoTrabalhoCorte.Codigo,
                        PostoDescricao = pedidoMaterial.PostoTrabalhoCorte.Nome,
                        Cancelado = false
                    };

                    item.Dimensao1 = pedidoMaterial.DimensaoCorte1;
                    item.Dimensao1Valor = pedidoMaterial.PlanoCorteDimensao1Valor;
                    item.UnidadeMedida1 = pedidoMaterial.UnidadeMedidaDimensao1;
                    item.Dimensao2 = pedidoMaterial.DimensaoCorte2;
                    item.Dimensao2Valor = pedidoMaterial.PlanoCorteDimensao2Valor;
                    item.UnidadeMedida2 = pedidoMaterial.UnidadeMedidaDimensao2;
                    item.Dimensao3 = pedidoMaterial.DimensaoCorte3;
                    item.Dimensao3Valor = pedidoMaterial.PlanoCorteDimensao3Valor;
                    item.UnidadeMedida3 = pedidoMaterial.UnidadeMedidaDimensao3;
                    item.InformacoesAdicionais = pedidoMaterial.PlanoCorteInformacoesAdicionais;

                    this.CollectionPlanoCorteItemClassPlanoCorte.Add(item);
                }


                //Alteração Marco, OP considerar Estoque Utilizado

                double razao = op.Quantidade / op.quantidadePedidos;

                double qtdFinalPc = Math.Round(pedidoMaterial.PlanoCorteQuantidade.Value * razao, 5);

                item.Quantidade += qtdFinalPc;
                PlanoCorteItemOpClass tmp = new PlanoCorteItemOpClass(this.UsuarioAtual, this.SingleConnection)
                {
                    PlanoCorteItem = item,
                    OrdemProducao = null,
                    CodigoItem = "",
                    Quantidade = qtdFinalPc, 
                };
                item.CollectionPlanoCorteItemOpClassPlanoCorteItem.Add(tmp);

                return tmp;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o item ao plano de corte\r\n" + e.Message, e);
            }
        }

        public void AdicionarItemSemOP(PedidoItemConfiguradoMaterialClass pedidoMaterial, OrderItemEtiquetaClass orderItemEtiqueta)
        {
            try
            {
                if (pedidoMaterial.PostoTrabalhoCorte == null || !pedidoMaterial.PlanoCorteQuantidade.HasValue) return;
                
                PlanoCorteItemClass item =
                                    this.CollectionPlanoCorteItemClassPlanoCorte.FirstOrDefault(
                                        a =>
                                        a.Material == pedidoMaterial.Material &&
                                        a.Dimensao1 == pedidoMaterial.DimensaoCorte1 &&
                                        a.Dimensao1Valor == pedidoMaterial.PlanoCorteDimensao1Valor &&
                                        a.Dimensao2 == pedidoMaterial.DimensaoCorte2 &&
                                        a.Dimensao2Valor == pedidoMaterial.PlanoCorteDimensao2Valor &&
                                        a.Dimensao3 == pedidoMaterial.DimensaoCorte3 &&
                                        a.Dimensao3Valor == pedidoMaterial.PlanoCorteDimensao3Valor &&
                                        a.InformacoesAdicionais == pedidoMaterial.PlanoCorteInformacoesAdicionais &&
                                        a.PostoTrabalhoCorte == pedidoMaterial.PostoTrabalhoCorte
                                        );

                if (item == null )
                {
                    item = new PlanoCorteItemClass(this.UsuarioAtual,this.SingleConnection)
                    {
                         PlanoCorte = this,
                        Material = pedidoMaterial.Material,
                        Quantidade = 0,
                        PostoTrabalhoCorte = pedidoMaterial.PostoTrabalhoCorte,
                        MaterialCodigo = pedidoMaterial.Material.Codigo,
                        MaterialFamilia = pedidoMaterial.FamiliaMaterial.ToString(),
                        MaterialAgrupador = pedidoMaterial.Material.FamiliaMaterial.AgrupadorMaterial.ToString(),
                        PostoNome = pedidoMaterial.PostoTrabalhoCorte != null ? pedidoMaterial.PostoTrabalhoCorte.Codigo : "",
                        PostoDescricao = pedidoMaterial.PostoTrabalhoCorte != null ? pedidoMaterial.PostoTrabalhoCorte.Nome : "",
                        Cancelado = false,
                    };

                    item.Dimensao1 = pedidoMaterial.DimensaoCorte1;
                    item.Dimensao1Valor = pedidoMaterial.PlanoCorteDimensao1Valor;
                    item.Dimensao2 = pedidoMaterial.DimensaoCorte2;
                    item.Dimensao2Valor = pedidoMaterial.PlanoCorteDimensao2Valor;
                    item.Dimensao3 = pedidoMaterial.DimensaoCorte3;
                    item.Dimensao3Valor = pedidoMaterial.PlanoCorteDimensao3Valor;
                    item.InformacoesAdicionais = pedidoMaterial.PlanoCorteInformacoesAdicionais;

                    this.CollectionPlanoCorteItemClassPlanoCorte.Add(item);
                }


                if (pedidoMaterial.PlanoCorteQuantidade != null)
                {
                    item.Quantidade += pedidoMaterial.PlanoCorteQuantidade.Value;


                    item.CollectionPlanoCorteItemPedidoClassPlanoCorteItem.Add(new PlanoCorteItemPedidoClass(this.UsuarioAtual, this.SingleConnection)
                    {
                        PlanoCorteItem = item,
                        OrderItemEtiqueta = orderItemEtiqueta,
                        CodigoItem = orderItemEtiqueta.CodigoItem,
                        Quantidade = pedidoMaterial.PlanoCorteQuantidade.Value,
                        PedidoNumero = orderItemEtiqueta.OrderNumber,
                        PedidoPosicao = orderItemEtiqueta.OrderPos.Value,
                        PedidoCliente = orderItemEtiqueta.Cliente.ToString()
                    });
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar o item ao plano de corte\r\n" + e.Message, e);
            }

        }

        public void CancelarPC(string justificativa, IWTPostgreNpgsqlCommand command = null)
        {
            bool commandInterno = false;
            try
            {
                justificativa = justificativa.Trim();
                if (string.IsNullOrWhiteSpace(justificativa) || justificativa.Length < 10)
                {
                    throw new ExcecaoTratada("A justificativa deve possuir ao menos 10 caracteres.");
                }

                if (this.Cancelado)
                {
                    throw new ExcecaoTratada("O plano de corte já foi cancelado anteriormente.");
                }

                this.Cancelado = true;
                this.CancelamentoData = Configurations.DataIndependenteClass.GetData();
                this.CancelamentoJustificativa = justificativa;
                this.AcsUsuarioCancelamento = UsuarioAtual;


                if (command == null)
                {
                    command = this.SingleConnection.CreateCommand();
                    commandInterno = true;

                    command.Transaction = command.Connection.BeginTransaction();
                }


                foreach (PlanoCorteItemClass item in CollectionPlanoCorteItemClassPlanoCorte.Where(a => !a.Cancelado))
                {
                    item.CancelarItemPC(justificativa, command);
                }

                this.Save(ref command);

                if (commandInterno)
                {
                    command.Transaction.Commit();
                }
            }
            catch (ExcecaoTratada)
            {
                if (commandInterno)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                if (commandInterno)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                }
                throw new Exception("Erro inesperado ao Cancelar o Plano de Corte.\r\n" + e.Message, e);
            }
        }

    }
}
