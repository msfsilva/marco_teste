using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using IWTLog;
using Newtonsoft.Json;

namespace BibliotecaEntidades.Entidades
{
    public class SolicitacaoCompraClass : SolicitacaoCompraBaseClass
    {
        #region Constantes

        protected new const string ErroLoad = "Erro ao carregar os dados do SolicitacaoCompraClass";
        protected new const string ErroDelete = "Erro ao excluir o SolicitacaoCompraClass  ";
        protected new const string ErroSave = "Erro ao salvar o SolicitacaoCompraClass.";
        protected new const string ErroCollectionLoteSolicitacaoCompraClassSolicitacaoCompra = "Erro ao carregar a coleção de LoteSolicitacaoCompraClass.";
        protected new const string ErroCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra = "Erro ao carregar a coleção de SolicitacaoCompraPedidoClass.";
        protected new const string ErroUnidadeCompraObrigatorio = "O campo UnidadeCompra é obrigatório";
        protected new const string ErroUnidadeCompraComprimento = "O campo UnidadeCompra deve ter no máximo 255 caracteres";
        protected new const string ErroValidate = "Erro ao validar os dados do SolicitacaoCompraClass.";
        protected new const string MensagemUtilizadoCollectionLoteSolicitacaoCompraClassSolicitacaoCompra = "A entidade SolicitacaoCompraClass está sendo utilizada nos seguintes LoteSolicitacaoCompraClass:";
        protected new const string MensagemUtilizadoCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra = "A entidade SolicitacaoCompraClass está sendo utilizada nos seguintes SolicitacaoCompraPedidoClass:";
        protected new const string ErroUtilizado = "Erro ao verificar se a entidade SolicitacaoCompraClass está sendo utilizada.";

        #endregion



        public SolicitacaoCompraClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection) : base(usuarioAtual, singleConnection)
        {
        }



        public double ValorTotalOcComImpostos
        {
            get
            {
                if (this.AliquotaIpiOc.HasValue)
                {
                    return (this.ValorComDesconto) *(1 + this.AliquotaIpiOc.Value/100);
                }
                return 0;
            }
        }

        public string CodigoItem
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.Codigo;
                }
                if (this.Material != null)
                {
                    return this.Material.CodigoComFamilia + " (" + this.Material.CodigoInterno + ")";
                }
                if (this.Epi != null)
                {
                    return this.Epi.Identificacao;
                }
                throw new Exception("Solicitação não possui produto, material nem epi.");
            }
        }

        public double UnidadesPorUnidadeCompraItem
        {
            get
            {
                if (this.Produto != null)
                {
                    if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor!=null)
                    {

                        ProdutoFornecedorClass produtoFornecedor = this.Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                        if (produtoFornecedor == null)
                        {
                            throw new ExcecaoTratada("Esse produto não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o produto e o fornecedor no cadastro do produto.");
                        }

                        if (produtoFornecedor.UnidadesPorUnCompra.HasValue)
                        {
                            return produtoFornecedor.UnidadesPorUnCompra.Value;
                        }
                    }

                    return this.Produto.UnidadesPorUnCompra;
                }
                else
                {
                    if (this.Material != null)
                    {
                        if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                        {

                            MaterialFornecedorClass materialFornecedor = this.Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                            if (materialFornecedor == null)
                            {
                                throw new ExcecaoTratada("Esse material não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o material e o fornecedor no cadastro do material.");
                            }

                            if (materialFornecedor.UnidadesPorUnCompra.HasValue)
                            {
                                return materialFornecedor.UnidadesPorUnCompra.Value;
                            }
                        }
                        return this.Material.UnidadesPorUnCompra;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                            {

                                EpiFornecedorClass epiFornecedor = this.Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                                if (epiFornecedor == null)
                                {
                                    throw new ExcecaoTratada("Esse epi não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o epi e o fornecedor no cadastro do epi.");
                                }

                                if (epiFornecedor.UnidadesPorUnCompra.HasValue)
                                {
                                    return epiFornecedor.UnidadesPorUnCompra.Value;
                                }
                            }
                            return this.Epi.UnidadesPorUnidadeCompra;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }

        public string UnidadeCompraItem
        {
            get
            {
                if (this.Produto != null)
                {
                    if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                    {

                        ProdutoFornecedorClass produtoFornecedor = this.Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                        if (produtoFornecedor == null)
                        {
                            throw new ExcecaoTratada("Esse produto não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o produto e o fornecedor no cadastro do produto.");
                        }

                        if (produtoFornecedor.UnidadeMedidaCompra != null)
                        {
                            return produtoFornecedor.UnidadeMedidaCompra.Abreviada;
                        }
                    }

                    return this.Produto.UnidadeMedidaCompra?.Abreviada;
                }
                else
                {
                    if (this.Material != null)
                    {
                        if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                        {

                            MaterialFornecedorClass materialFornecedor = this.Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                            if (materialFornecedor == null)
                            {
                                throw new ExcecaoTratada("Esse material não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o material e o fornecedor no cadastro do material.");
                            }

                            if (materialFornecedor.UnidadeMedidaCompra!=null)
                            {
                                return materialFornecedor.UnidadeMedidaCompra.Abreviada;
                            }
                        }
                        return this.Material.UnidadeMedidaCompra?.Abreviada;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                            {

                                EpiFornecedorClass epiFornecedor = this.Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                                if (epiFornecedor == null)
                                {
                                    throw new ExcecaoTratada("Esse epi não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o epi e o fornecedor no cadastro do epi.");
                                }

                                if (epiFornecedor.UnidadeMedidaCompra!=null)
                                {
                                    return epiFornecedor.UnidadeMedidaCompra.Abreviada;
                                }
                            }
                            return this.Epi.UnidadeMedidaCompra?.Abreviada;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }

        public double LotePadraoCompraItem
        {
            get
            {
                if (this.Produto != null)
                {

                    if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                    {

                        ProdutoFornecedorClass produtoFornecedor = this.Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                        if (produtoFornecedor == null)
                        {
                            throw new ExcecaoTratada("Esse produto não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o produto e o fornecedor no cadastro do produto.");
                        }

                        if (produtoFornecedor.LotePadrao.HasValue)
                        {
                            return produtoFornecedor.LotePadrao.Value;
                        }
                    }


                    if (this.Produto.LotePadraoCompra.HasValue)
                        return this.Produto.LotePadraoCompra.Value;
                    return 0;
                }
                else
                {
                    if (this.Material != null)
                    {

                        if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                        {

                            MaterialFornecedorClass materialFornecedor = this.Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                            if (materialFornecedor == null)
                            {
                                throw new ExcecaoTratada("Esse material não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o material e o fornecedor no cadastro do material.");
                            }

                            if (materialFornecedor.LotePadrao.HasValue)
                            {
                                return materialFornecedor.LotePadrao.Value;
                            }
                        }
                        return this.Material.LotePadrao;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            if (this.OrdemCompra != null && this.OrdemCompra.Fornecedor != null)
                            {

                                EpiFornecedorClass epiFornecedor = this.Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == this.OrdemCompra.Fornecedor);
                                if (epiFornecedor == null)
                                {
                                    throw new ExcecaoTratada("Esse epi não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o epi e o fornecedor no cadastro do epi.");
                                }

                                if (epiFornecedor.LotePadrao.HasValue)
                                {
                                    return epiFornecedor.LotePadrao.Value;
                                }
                            }

                            return this.Epi.LotePadrao;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }
        
        public override string ToString()
        {
            return this.ID.ToString(CultureInfo.InvariantCulture);
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

        public SolicitacaoCompraFeedbackClass AdicionarFeedback(string textoFeedback)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textoFeedback))
                {
                    throw new Exception("O feedback não pode ser vazio");
                }

                SolicitacaoCompraFeedbackClass feedback = new SolicitacaoCompraFeedbackClass( LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                                                              {
                                                                  SolicitacaoCompra = this,
                                                                  Data =  Configurations.DataIndependenteClass.GetData(),
                                                                  Texto = textoFeedback.Trim(),
                                                                  Atual = true,
                                                                  AcsUsuario = LoginClass.UsuarioLogado.loggedUser
                                                                  
                                                              };

                foreach (SolicitacaoCompraFeedbackClass feedbackClass in CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra)
                {
                    feedbackClass.Atual = false;
                }
                
                this.CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra.Add(feedback);

                return feedback;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adiconar o feedback na solicitação de compra\r\n" + e.Message, e);
            }
        }

        public void AplicaDescontos(double descontoP)
        {
            this.ValorUnitarioOc = (this.ValorUnitarioOc * (1 - descontoP));
            this.ValorTotalOc = this.ValorUnitarioOc*Qtd;
        }

        public void AplicaDescontosReais(double descontoR)
        {
            this.ValorTotalOc = ValorTotalOc - descontoR;
            this.ValorUnitarioOc = Math.Round((ValorTotalOc ?? 0) / Qtd ?? 1, 4, MidpointRounding.ToEven);
        }

        public double ValorComDesconto
        {
            get
            {
                double valorComDesconto = ValorTotalOc.HasValue ? ValorTotalOc.Value : 0 ;

                double razao = Math.Round((ValorTotalOc ?? 0) / OrdemCompra.Valor, 15, MidpointRounding.ToEven);

                if (this.OrdemCompra.DescontoP > 0)
                {
                    double desconto = this.OrdemCompra.DescontoP / 100;

                    Double? valorUnitarioOc = (this.ValorUnitarioOc * (1 - desconto));
                    Double? valorTotalOc = valorUnitarioOc * Qtd;

                    if (valorTotalOc.HasValue)
                    {
                        valorComDesconto = valorTotalOc.Value;
                    }

                }

                else if (this.OrdemCompra.DescontoR > 0)
                {
                    double desconto = Math.Round(this.OrdemCompra.DescontoR * razao, 4);

                    Double? valorTotalOc = ValorTotalOc - desconto;

                    if (valorTotalOc.HasValue)
                    {
                        valorComDesconto = valorTotalOc.Value;
                    }

                }

                return Math.Round(valorComDesconto, 2);
            }
            
        }
        
        public void RemoverOC()
        {
            this.Status = StatusSolicitacaoCompra.AprovadaPCP;
            this.OrdemCompra = null;
            this.DataAprovacaoCompras = null;
            this.AcsUsuarioComprador = null;
            this.NumeroLinhaOc = 0;
            this.ValorUnitarioOc = null;
            this.ValorTotalOc = null;
            this.AliquotaIcmsOc = null;
            this.AliquotaIpiOc = null;

            //Volta a quantidade e a unidade de medida originais caso tenha sido alterado pela seleção do fornecedor
            double quantidade = this.QtdUnidadeUso/this.UnidadesPorUnidadeCompraItem;

            int qtdLotesPadrao = (int)Math.Truncate(quantidade / this.LotePadraoCompraItem);
            double tmp = Math.Round(qtdLotesPadrao * this.LotePadraoCompraItem, 4);
            if (tmp < quantidade)
            {
                tmp += this.LotePadraoCompraItem;
            }

            quantidade = Math.Round(tmp, 4);

            this.SetQuantidade(quantidade);
            this.UnidadeCompra = UnidadeCompraItem;

        }

        public void SetQuantidade(double novaQtd)
        {
            novaQtd = Math.Round(novaQtd, 10, MidpointRounding.ToEven);
            double difQuantidade = Math.Round(novaQtd - (Qtd??0), 10, MidpointRounding.ToEven);

            this.Qtd = novaQtd;

            double qtdPorUnidadeCompra = this.UnidadesPorUnidadeCompraItem;



            //this.QtdUnidadeUso = Math.Round(this.QtdUnidadeUso + (difQuantidade*qtdPorUnidadeCompra), 10, MidpointRounding.ToEven);
            this.QtdUnidadeUso = (Qtd??0) * qtdPorUnidadeCompra;
            this.SaldoRecebimento = Math.Round((SaldoRecebimento ?? 0) + difQuantidade, 10, MidpointRounding.ToEven);

            if (this.Status == StatusSolicitacaoCompra.RecebidaParcial || this.Status == StatusSolicitacaoCompra.RecebidaTotal)
            {
                if (SaldoRecebimento > 0.0001)
                {
                    this.Status = StatusSolicitacaoCompra.RecebidaParcial;
                }
                else
                {
                    this.SaldoRecebimento = 0;
                    this.Status = StatusSolicitacaoCompra.RecebidaTotal;
                }
            }

            this.ValorTotalOc = this.ValorUnitarioOc * Qtd;
        }

        public void SetNaoAtualizaPrecoRecebimento(bool valor)
        {
            this.NaoAtualizaPrecoRecebimento = valor;
        }

        public void AtualizarDadosCompra(double valorUnitario, double aliquotaIcms, double aliquotaIpi, DateTime entregaPrevista, bool naoAtualizaPrecoRecebimento)
        {
            this.ValorUnitarioOc = valorUnitario;
            this.AliquotaIcmsOc = aliquotaIcms;
            this.AliquotaIpiOc = aliquotaIpi;
            this.EntregaPrevista = entregaPrevista;
            this.SetNaoAtualizaPrecoRecebimento(naoAtualizaPrecoRecebimento);

            this.ValorTotalOc = this.ValorUnitarioOc * Qtd;

        }
        
        protected override void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            bool tmp = DisableLoadCollection;
            try
            {
                
                string dados =this.ExportacaoDadosJson();
                Log.Registrar(IWTLogSeveridade.Info, "SAVE", this.GetType().ToString(), "", dados, command.Connection.ConnectionString);
            }
            catch(JsonReaderException)
            {

            }
            finally
            {
                DisableLoadCollection = tmp;
            }
        }
        
        public override void AcoesExtrasAposSalvar(ref IWTPostgreNpgsqlCommand command, bool inserting)
        {

            //Conversão forçada de ID: Produtos começa com 10 milhões, material com 20 milhoes e epi com 30 milhoes;
            if (Status == StatusSolicitacaoCompra.AprovadaPCP)
            {
                long idSimulador = -1;
                if (Produto != null)
                {
                    idSimulador = Produto.ID + 10000000;
                }

                if (Material != null)
                {
                    idSimulador = Material.ID + 20000000;
                }

                if (Epi != null)
                {
                    idSimulador = Epi.ID + 30000000;
                }


                string unidMedida = null;
                if (this.Produto != null)
                {
                    unidMedida = this.Produto.UnidadeMedida.ToString();
                }
                else
                {
                    if (this.Material != null)
                    {
                        unidMedida = this.Material.UnidadeMedida.ToString();
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            unidMedida = this.Epi.UnidadeMedidaUso.NomeUnidade;
                        }

                    }
                }

                SolicitacaoCompraDto dto = new SolicitacaoCompraDto()
                {
                    id = ID,
                    dataAprovacaoLiberacao = DataAprovacaoPcp,
                    entregaPrevista = EntregaPrevista,
                    ordemCompraId = (OrdemCompra == null ? null : (long?) OrdemCompra.ID),
                    produtoId = idSimulador,
                    solicitante = AcsUsuarioPcp.Login,
                    qtdUnidadeUso = QtdUnidadeUso,
                    unidadeUso = unidMedida


                };


                if (_statusOriginal == StatusSolicitacaoCompra.Nova)
                {

                    ApiSimuladorCompras.SincronizarSolicitacaoCompra(dto.id,"CRIAR",UsuarioAtual,command);
                    
                }
                else
                {
                    ApiSimuladorCompras.SincronizarSolicitacaoCompra(dto.id, "ATUALIZAR", UsuarioAtual, command);
                }
            }

            if (_statusOriginal != StatusSolicitacaoCompra.Cancelada && Status == StatusSolicitacaoCompra.Cancelada && OrdemCompra == null)
            {
                ApiSimuladorCompras.SincronizarSolicitacaoCompra(ID, "EXCLUIR", UsuarioAtual, command);
            }

        }

        protected override void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {

            ApiSimuladorCompras.SincronizarSolicitacaoCompra(ID, "EXCLUIR", UsuarioAtual, command);
        }
        
        public void Comprar(OrdemCompraClass ordemCompra)
        {
            if (this.Status != StatusSolicitacaoCompra.AprovadaPCP)
            {
                throw new Exception("A SC " + ID + " não pode ser incluída na OC pois não está em um status válido para a operação");
            }

            Status = StatusSolicitacaoCompra.Comprada;
            OrdemCompra = ordemCompra;
            DataAprovacaoCompras = ordemCompra.Data;

            AcsUsuarioComprador = UsuarioAtual;
            NumeroLinhaOc = ordemCompra.CollectionSolicitacaoCompraClassOrdemCompra.Count + 1;

            ordemCompra.CollectionSolicitacaoCompraClassOrdemCompra.Add(this);
        }
       
    }
}
