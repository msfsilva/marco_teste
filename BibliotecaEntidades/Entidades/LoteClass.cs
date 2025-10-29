using System;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;


using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTLog;
using IWTPostgreNpgsql;
using Newtonsoft.Json;

namespace BibliotecaEntidades.Entidades
{
    public class LoteClass : LoteBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do LoteClass";
        protected new const string ErroDelete = "Erro ao excluir o LoteClass  ";
        protected new const string ErroSave = "Erro ao salvar o LoteClass.";
        protected new const string ErroCollectionHistoricoCompraEpiClassLote = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
        protected new const string ErroCollectionHistoricoCompraMaterialClassLote = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
        protected new const string ErroCollectionHistoricoCompraProdutoClassLote = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
        protected new const string ErroCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoProducaoLoteClass.";
        protected new const string ErroCollectionLoteSolicitacaoCompraClassLote = "Erro ao carregar a coleção de LoteSolicitacaoCompraClass.";
        protected new const string ErroCollectionPedidoItemLoteClienteClassLote = "Erro ao carregar a coleção de PedidoItemLoteClienteClass.";
        protected new const string ErroNfSerieObrigatorio = "O campo NfSerie é obrigatório";
        protected new const string ErroNfSerieComprimento = "O campo NfSerie deve ter no máximo 255 caracteres";
        protected new const string ErroNfNumeroObrigatorio = "O campo NfNumero é obrigatório";
        protected new const string ErroNfNumeroComprimento = "O campo NfNumero deve ter no máximo 255 caracteres";
        protected new const string ErroCodigoItemFornecedorClienteObrigatorio = "O campo CodigoItemFornecedorCliente é obrigatório";
        protected new const string ErroCodigoItemFornecedorClienteComprimento = "O campo CodigoItemFornecedorCliente deve ter no máximo 255 caracteres";
        protected new const string ErroDescricaoItemFornecedorClienteObrigatorio = "O campo DescricaoItemFornecedorCliente é obrigatório";
        protected new const string ErroDescricaoItemFornecedorClienteComprimento = "O campo DescricaoItemFornecedorCliente deve ter no máximo 255 caracteres";
        protected new const string ErroNcmItemFornecedorClienteObrigatorio = "O campo NcmItemFornecedorCliente é obrigatório";
        protected new const string ErroNcmItemFornecedorClienteComprimento = "O campo NcmItemFornecedorCliente deve ter no máximo 255 caracteres";
        protected new const string ErroUnidadeItemFornecedorClienteObrigatorio = "O campo UnidadeItemFornecedorCliente é obrigatório";
        protected new const string ErroUnidadeItemFornecedorClienteComprimento = "O campo UnidadeItemFornecedorCliente deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do LoteClass.";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraEpiClassLote = "A entidade LoteClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassLote = "A entidade LoteClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
        protected new const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassLote = "A entidade LoteClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
        protected new const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote = "A entidade LoteClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoProducaoLoteClass:";
        protected new const string MensagemUtilizadoCollectionLoteSolicitacaoCompraClassLote = "A entidade LoteClass está sendo utilizada nos seguintes LoteSolicitacaoCompraClass:";
        protected new const string MensagemUtilizadoCollectionPedidoItemLoteClienteClassLote = "A entidade LoteClass está sendo utilizada nos seguintes PedidoItemLoteClienteClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade LoteClass está sendo utilizada.";

        #endregion



        public LoteClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        public string MaterialProduto
        {
            get { return this.Produto != null ? this.Produto.ToString() : this.Material.ToString(); }
        }

        public string FornecedorCliente
        {
            get { return this.Fornecedor != null ? this.Fornecedor.ToString() : this.Cliente.ToString(); }
        }

        public override string ToString()
        {
            return this.Numero;
        }

        public override bool SearchCustom(SearchParameterClass parametro, ref string whereClause, ref IWTPostgreNpgsqlCommand command)
        {
            switch (parametro.FieldName)
            {
                case "SaldoVinculoPedidoAberto":
                    if (parametro.Fieldvalue is bool)
                    {
                        if ((bool) parametro.Fieldvalue)
                        {
                            whereClause += " AND (public.lote.lot_saldo_vinculo_pedido > 0) ";
                        }
                        else
                        {
                            whereClause += " AND (public.lote.lot_saldo_vinculo_pedido <= 0) ";
                        }

                        return true;
                    }
                    else
                    {
                        throw new Exception("O parâmetro fornecidor não é do tipo boolean");
                    }
                default:
                    return false;
            }
        }

        public void VinculaLoteClienteAoPedido(double quantidade)
        {

            try
            {
                if (quantidade > this.SaldoVinculoPedido)
                {
                    throw new ExcecaoTratada("A quantidade a baixar é maior do que saldo de vinculo com os pedidos.");
                }

                this.SaldoVinculoPedido = Math.Round(SaldoVinculoPedido - quantidade, 5);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao baixar o saldo de vinculo do pedido do lote\r\n" + e.Message, e);
            }


        }

        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            base.InternalSaveCustom(ref command);

            try
            {
#if DEBUG
#else
                JsonSerializerSettings settings = new JsonSerializerSettings()
               {
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
               };
               string dados = JsonConvert.SerializeObject(this, settings);

               Log.Registrar(IWTLogSeveridade.Info, "SAVE-LOTE", this.GetType().ToString(), "Save", dados, SingleConnection.ConnectionString);
#endif
            }
            catch
            {
            }
        }

        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {
            if (inserting)
            {

                if (Fornecedor != null)
                {
                    
                    long idSimulador = -1;
                    if (Produto != null)
                    {
                        ProdutoFornecedorClass pf = Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == Fornecedor);
                        if (pf != null)
                        {
                            idSimulador = pf.ID + 10000000;
                            ApiSimuladorCompras.SincronizarProdutoFornecedor(idSimulador, false, UsuarioAtual, command);
                        } 
                    }

                    if (Material != null)
                    {
                        MaterialFornecedorClass mf = Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == Fornecedor);
                        if (mf != null)
                        {
                            idSimulador = mf.ID + 20000000;
                            ApiSimuladorCompras.SincronizarMaterialFornecedor(idSimulador, false, UsuarioAtual, command);
                        }
                    }

                    if (Epi != null)
                    {
                        EpiFornecedorClass ef = Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == Fornecedor);
                        if (ef != null)
                        {
                            idSimulador = ef.ID + 30000000;
                            ApiSimuladorCompras.SincronizarEpiFornecedor(idSimulador, false, UsuarioAtual, command);
                        }
                    }

                }
            }
        }
    }
}
