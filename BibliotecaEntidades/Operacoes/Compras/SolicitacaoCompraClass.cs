#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTLog;
using IWTNFCompleto.BibliotecaDatasets.v3_10;
using IWTPostgreNpgsql;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

#endregion

namespace BibliotecaEntidades.Operacoes.Compras
{

    public enum  SolicitacaoCompraStatus { Nova, AprovadaPCP, AprovadaCompras,Comprada, RecebidaParcial, RecebidaTotal, Cancelada}

    public class SolicitacaoCompraClass : INotifyPropertyChanged
    {
        public long? idSolicitacaoCompra { get; private set; }

        public SolicitacaoCompraStatus _statusAnterior = SolicitacaoCompraStatus.Nova;

        [JsonIgnore]
        public OrdemCompraClass OrdemCompra { get; private set; }


        private FornecedorClass _fornecedor = null;
        [JsonIgnore]
        public FornecedorClass Fornecedor
        {
            get
            {
                if (this._fornecedor == null)
                {
                    this.loadFornecedor();
                }

                return this._fornecedor;
            }
        }

        public int linhaOC { get; internal set; }
        [JsonIgnore]
        public MaterialClass Material { get; private set; }
        [JsonIgnore]
        public ProdutoClass Produto { get; private set; }
        [JsonIgnore]
        public EpiClass Epi { get; private set; }

        public long idProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.ID;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.ID;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.ID;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }

        public string codigoProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.Codigo;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.CodigoComFamilia + " (" + this.Material.CodigoInterno + ")";
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.Identificacao;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }

        public string descricaoProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.Descricao;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.Descricao;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.Descricao;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }

        public string infoAdicionalProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.ClassificacaoProduto != null ? this.Produto.ClassificacaoProduto.ToString() : null;
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.MedidaCompleta;
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.DescricaoAdicional;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }

        public string unidadeCompraProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    if (this.Fornecedor != null)
                    {

                        ProdutoFornecedorClass produtoFornecedor = this.Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
                        if (produtoFornecedor == null)
                        {
                            throw new ExcecaoTratada("Esse produto não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o produto e o fornecedor no cadastro do produto.");
                        }

                        if (produtoFornecedor.UnidadeMedidaCompra!=null)
                        {
                            return produtoFornecedor.UnidadeMedidaCompra.ToString();
                        }
                    }

                    if (Produto.UnidadeMedida == null)
                    {
                        throw new ExcecaoTratada("O produto "+Produto+ " não possui unidade de medida definida");

                    }
                    return this.Produto.UnidadeMedidaCompra != null ? this.Produto.UnidadeMedidaCompra.ToString() : this.Produto.UnidadeMedida.ToString();
                }

                if (this.Material != null)
                {
                    if (this.Fornecedor != null)
                    {

                        MaterialFornecedorClass materialFornecedor = this.Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
                        if (materialFornecedor == null)
                        {
                            throw new ExcecaoTratada("Esse material não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o material e o fornecedor no cadastro do material.");
                        }

                        if (materialFornecedor.UnidadeMedidaCompra !=null)
                        {
                            return materialFornecedor.UnidadeMedidaCompra.ToString();
                        }
                    }


                    return this.Material.UnidadeMedidaCompra != null ? this.Material.UnidadeMedidaCompra.ToString() : this.Material.UnidadeMedida.ToString();
                }

                if (this.Epi != null)
                {

                    if (this.Fornecedor != null)
                    {

                        EpiFornecedorClass epiFornecedor = this.Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
                        if (epiFornecedor == null)
                        {
                            throw new ExcecaoTratada("Esse epi não pode ser vendido pelo fornecedor indicado, verifique se existe o vinculo entre o epi e o fornecedor no cadastro do epi.");
                        }

                        if (epiFornecedor.UnidadeMedidaCompra != null)
                        {
                            return epiFornecedor.UnidadeMedidaCompra.ToString();
                        }
                    }
                    return this.Epi.UnidadeMedidaCompra != null ? this.Epi.UnidadeMedidaCompra.NomeUnidade : this.Epi.UnidadeMedidaUso.NomeUnidade;
                }


                throw new Exception("Solicitação não possui produto, material nem epi.");
            }
        }

        public string unidadeUsoProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    return this.Produto.UnidadeMedida.ToString();
                }
                else
                {
                    if (this.Material != null)
                    {
                        return this.Material.UnidadeMedida.ToString();
                    }
                    else
                    {
                        if (this.Epi != null)
                        {
                            return this.Epi.UnidadeMedidaUso.NomeUnidade;
                        }
                        else
                        {
                            throw new Exception("Solicitação não possui produto, material nem epi.");
                        }
                    }
                }
            }
        }

        public double unidadesPorUnidadeCompraProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {
                    if (this.Fornecedor != null)
                    {

                        ProdutoFornecedorClass produtoFornecedor = this.Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
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
                        if (this.Fornecedor != null)
                        {

                            MaterialFornecedorClass materialFornecedor = this.Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
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
                            if (this.Fornecedor != null)
                            {

                                EpiFornecedorClass epiFornecedor = this.Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
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

        public double LotePadraoCompraProdutoMaterial
        {
            get
            {
                if (this.Produto != null)
                {

                    if (this.Fornecedor != null)
                    {

                        ProdutoFornecedorClass produtoFornecedor = this.Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
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

                        if (this.Fornecedor != null)
                        {

                            MaterialFornecedorClass materialFornecedor = this.Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
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
                            if (this.Fornecedor != null)
                            {

                                EpiFornecedorClass epiFornecedor = this.Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
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

        public string politicaEstoque
        {
            get
            {
                if (this.Material != null)
                {
                    return this.Material.PoliticaEstoqueTela;
                }



                if (this.Produto != null)
                {
                    return this.Produto.PoliticaEstoqueTela;
                }

                PoliticaEstoque toRet;

                if (this.Epi != null)
                {
                    toRet = PoliticaEstoque.Kanban;
                }
                else
                {
                    throw new Exception("Solicitação não possui produto, material nem epi.");
                }

                switch (toRet)
                {
                    case PoliticaEstoque.MRP:
                        return "MRP";
                    case PoliticaEstoque.Kanban:
                        return "Kanban";
                    default:
                        return "Não Aplicável";
                }
            }
        }

        public double SaldoEntregaMaximo
        {
            get
            {


                double qtdTotal = this.saldoEntrega;
                double margemRecebimento = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS));
                if (this.Material != null && this.Material.MargemRecebimento.HasValue)
                {
                    margemRecebimento = this.Material.MargemRecebimento.Value;
                }

                if (this.Produto != null && this.Produto.MargemRecebimento.HasValue)
                {
                    margemRecebimento = this.Produto.MargemRecebimento ?? 0;
                }

                if (this.Epi != null && this.Epi.MargemRecebimento.HasValue)
                {
                    margemRecebimento = this.Epi.MargemRecebimento ?? 0;
                }

                return Math.Round((qtdTotal * (1 + (margemRecebimento / 100))), 4, MidpointRounding.ToEven);

            }
        }

        private double _qtdUnidadeCompra;
        public double Quantidade
        {
            get { return _qtdUnidadeCompra; }
            set
            {

                value = Math.Round(value, 10, MidpointRounding.ToEven);
                double difQuantidade = Math.Round(value - _qtdUnidadeCompra, 10, MidpointRounding.ToEven);

                this._qtdUnidadeCompra = value;

                double qtdPorUnidadeCompra = this.unidadesPorUnidadeCompraProdutoMaterial;



                //this.QtdUnidadeUso = Math.Round(this.QtdUnidadeUso + (difQuantidade*qtdPorUnidadeCompra), 10, MidpointRounding.ToEven);
                this.QtdUnidadeUso = this._qtdUnidadeCompra * qtdPorUnidadeCompra;
                this.saldoEntrega = Math.Round(this.saldoEntrega + difQuantidade, 10, MidpointRounding.ToEven);
                

                if (this.Status == SolicitacaoCompraStatus.RecebidaParcial || this.Status == SolicitacaoCompraStatus.RecebidaTotal)
                {
                    ValidacaoOnAlterarStatus();
                    if (saldoEntrega > 0.0001)
                    {
                        this.Status = SolicitacaoCompraStatus.RecebidaParcial;
                    }
                    else
                    {
                        this.saldoEntrega = 0;
                        this.Status = SolicitacaoCompraStatus.RecebidaTotal;
                    }
                }
                else
                {
                    if (Math.Abs(this._qtdUnidadeCompra) < 0.00001 && Math.Abs(this.saldoEntrega) < 0.00001)
                    {
                        ValidacaoOnAlterarStatus();
                        this.Status = SolicitacaoCompraStatus.RecebidaTotal;
                    }
                }
            }
        }

        public double saldoEntrega { get; private set; }
        public double saldoEntregaOriginal { get; private set; }
        public string Observacao { get; set; }
        public DateTime dataAbertura { get; private set; }
        public DateTime? DataEntregaPrevista { get; set; }
        public DateTime? dataAprovacaoPCP { get; private set; }
        public DateTime? dataAprovacaoCompras { get; private set; }

        public SolicitacaoCompraStatus Status
        {
            get { return _status; }
            private set { _status = value; }
        }

        [JsonIgnore]
        public AcsUsuarioClass usuarioAbertura { get; private set; }
        [JsonIgnore]
        public AcsUsuarioClass usuarioPCP { get; private set; }
        [JsonIgnore]
        public AcsUsuarioClass usuarioCompras { get; private set; }

        [JsonIgnore]
        private readonly AcsUsuarioClass usuarioAtual;

        [JsonIgnore]
        public AcsUsuarioClass usuarioCancelamento { get; private set; }

        public DateTime? dataCancelamento { get; private set; }

        public double? ValorUnitarioCompra { get; internal set; }
        public double ValorTotalCompra
        {
            get
            {
                if (this.ValorUnitarioCompra.HasValue)
                {
                    return this.Quantidade * this.ValorUnitarioCompra.Value;
                }
                return 0;
            }
        }

        public double? AliquotaIPICompra { get; internal set; }
        public double? AliquotaICMSCompra { get; internal set; }

        public double ValorTotalCompraComImpostos
        {
            get
            {
                if (this.AliquotaIPICompra.HasValue)
                {
                    return this.ValorComDesconto * (1 + this.AliquotaIPICompra.Value / 100);
                }
                return 0;
            }
        }

        public double? ValorUnitarioCompraComImpostos
        {
            get
            {
                if (this.AliquotaIPICompra.HasValue)
                {
                    if (this.ValorUnitarioCompra.HasValue)
                    {
                        return this.ValorUnitarioCompra.Value*(1 + this.AliquotaIPICompra.Value/100);
                    }
                    return null;
                }
                return 0;
            }
        }

        public string identificacaoCompleta
        {
            get
            {
                return "OC: " + this.OrdemCompra?.Id + " Linha: " + this.linhaOC + " - Saldo: " + this.saldoEntrega;
            }
        }


        public double QtdUnidadeUso { get; private set; }
        public string UnidadeCompra { get; internal set; }

        public double UnidadesUsoPorUnidadeCompra
        {
            get
            {
                // VERIFICAÇÃO DE SEGURANÇA: Previne a exceção de divisão por zero.
                // Se a quantidade de compra for zero, o fator de conversão é logicamente zero.
                if (this.Quantidade == 0)
                {
                    return 0;
                }

                // Se a quantidade não for zero, a lógica original é segura para ser executada.
                double toRet = (this.QtdUnidadeUso == 0 ? this.Quantidade : this.QtdUnidadeUso) / this.Quantidade;
                return toRet;
            }
        }

        [JsonIgnore]
        readonly IWTPostgreNpgsqlConnection conn;
        private SolicitacaoCompraStatus _status;

        [JsonIgnore]
        public List<SolicitacaoCompraPedidoClass> Pedidos { get; private set; }



        public string HistoricoCalculoNecessidade { get; set; }


        private bool _consumo;
        public bool Consumo
        {
            get { return _consumo; }
            set
            {
                if (this.Epi != null)
                {
                    _consumo = true;
                    return;
                }

                if (Produto != null)
                {
                    if (Produto.ClassificacaoProduto == null)
                    {
                        _consumo = false;
                        return;
                    }
                    switch (Produto.ClassificacaoProduto.TipoConsumoEstoque)
                    {
                        case EASITipoConsumoEstoque.MateriaPrima:
                            _consumo = false;
                            break;
                        case EASITipoConsumoEstoque.Consumo:
                            _consumo = true;
                            break;
                        case EASITipoConsumoEstoque.Escolher:
                            _consumo = value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    return;
                }

                if (Material != null)
                {
                    if (Material.FamiliaMaterial == null || Material.FamiliaMaterial.AgrupadorMaterial == null)
                    {
                        _consumo = false;
                        return;
                    }
                    switch (Material.FamiliaMaterial.AgrupadorMaterial.TipoConsumoEstoque)
                    {
                        case EASITipoConsumoEstoque.MateriaPrima:
                            _consumo = false;
                            break;
                        case EASITipoConsumoEstoque.Consumo:
                            _consumo = true;
                            break;
                        case EASITipoConsumoEstoque.Escolher:
                            _consumo = value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    return;
                }



            }
        }


        public bool itemNaoDeveAtualizarPrecosNoRecebimento;



        public SolicitacaoCompraClass(long? idSolicitacaoCompra, OrdemCompraClass ordemCompra, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
            this.idSolicitacaoCompra = idSolicitacaoCompra;
            this.usuarioAtual = usuario;

            this.DataEntregaPrevista = null;
            this.dataAprovacaoPCP = null;
            this.dataAprovacaoCompras = null;
            this.dataCancelamento = null;

            this.Status = SolicitacaoCompraStatus.Nova;

            this.Pedidos = new List<SolicitacaoCompraPedidoClass>();

            this.OrdemCompra = ordemCompra;

            if (this.idSolicitacaoCompra != null)
            {
                this.loadDados();
            }
            else
            {
                this.usuarioAbertura = this.usuarioAtual;
                this.dataAbertura = Configurations.DataIndependenteClass.GetData();
            }

            this._statusAnterior = Status;

        }

        private void loadDados()
        {
            try
            {

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.Transaction = conn.GetActiveTransaction();

                command.CommandText =
                "SELECT  " +
                "  id_material, " +
                "  id_produto, " +
                "  id_epi, " +
                "  id_ordem_compra, " +
                "  id_acs_usuario, " +
                "  soc_qtd, " +
                "  soc_status, " +
                "  soc_data_abertura, " +
                "  soc_saldo_recebimento, " +
                "  soc_entrega_prevista, " +
                "  id_acs_usuario_pcp, " +
                "  id_acs_usuario_comprador, " +
                "  soc_data_aprovacao_pcp, " +
                "  soc_data_aprovacao_compras, " +
                "  soc_observacao, "+
                "  solicitacao_compra.id_marca, "+
                "  id_acs_usuario_cancelamento, "+
                "  soc_data_cancelamento, "+
                "  soc_numero_linha_oc, "+
                "  soc_valor_unitario_oc, " +
                "  soc_valor_total_oc, " +
                "  soc_aliquota_ipi_oc, "+
                "  soc_aliquota_icms_oc, "+
                "  soc_qtd_unidade_uso, "+
                "  soc_unidade_compra, "+
                "  soc_historico_calculo_necessidade, "+
                "  soc_tipo_alocacao_estoque, "+
                "  soc_nao_atualiza_preco_recebimento " +
                "FROM " +
                "  public.solicitacao_compra " +
                "WHERE " +
                "  id_solicitacao_compra = :id_solicitacao_compra ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idSolicitacaoCompra;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido!");
                }
                read.Read();

                if (read["id_material"] != DBNull.Value)
                {
                    this.Material = MaterialBaseClass.GetEntidade(Convert.ToInt32(read["id_material"]), this.usuarioAtual, this.conn);
                }

                if (read["id_produto"] != DBNull.Value)
                {
                    this.Produto = ProdutoBaseClass.GetEntidade(Convert.ToInt32(read["id_produto"]), this.usuarioAtual, this.conn);
                }

                if (read["id_epi"] != DBNull.Value)
                {
                    this.Epi = EpiBaseClass.GetEntidade(Convert.ToInt32(read["id_epi"]), this.usuarioAtual, this.conn);
                }

                if (this.OrdemCompra == null)
                {
                    if (read["id_ordem_compra"] != DBNull.Value)
                    {
                        this.OrdemCompra = new OrdemCompraClass(Convert.ToInt32(read["id_ordem_compra"]), this.conn, this.usuarioAtual,false);
                    }
                }


                if (read["soc_valor_unitario_oc"] != DBNull.Value)
                {
                    this.ValorUnitarioCompra = Convert.ToDouble(read["soc_valor_unitario_oc"]);
                }


                if (read["soc_aliquota_ipi_oc"] != DBNull.Value)
                {
                    this.AliquotaIPICompra = Convert.ToDouble(read["soc_aliquota_ipi_oc"]);
                }

                if (read["soc_aliquota_icms_oc"] != DBNull.Value)
                {
                    this.AliquotaICMSCompra = Convert.ToDouble(read["soc_aliquota_icms_oc"]);
                }



                this.usuarioAbertura = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]), usuarioAtual, this.conn);

                this.Status = (SolicitacaoCompraStatus)Enum.ToObject(typeof(SolicitacaoCompraStatus), read["soc_status"]);
                this._qtdUnidadeCompra = Convert.ToDouble(read["soc_qtd"]);
                this.saldoEntrega = Convert.ToDouble(read["soc_saldo_recebimento"]);
                this.saldoEntregaOriginal = this.saldoEntrega;

                this.Observacao = read["soc_observacao"].ToString();

                if (read["id_acs_usuario_comprador"] != DBNull.Value)
                {
                    this.usuarioCompras = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_comprador"]), usuarioAtual, this.conn);

                    this.dataAprovacaoCompras = Convert.ToDateTime(read["soc_data_aprovacao_compras"]);
                }

                if (read["id_acs_usuario_pcp"] != DBNull.Value)
                {
                    this.usuarioPCP = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_pcp"]), usuarioAtual, this.conn);
                    this.dataAprovacaoPCP = Convert.ToDateTime(read["soc_data_aprovacao_pcp"]);
                }

                if (read["soc_entrega_prevista"] != DBNull.Value)
                {
                    this.DataEntregaPrevista = Convert.ToDateTime(read["soc_entrega_prevista"]);
                }


                if (read["soc_data_abertura"] != DBNull.Value)
                {
                    this.dataAbertura = Convert.ToDateTime(read["soc_data_abertura"]);
                }


                if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                {
                    this.dataCancelamento = Convert.ToDateTime(read["soc_data_cancelamento"]);
                    this.usuarioCancelamento = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]), usuarioAtual, this.conn);
                }

                if (read["soc_numero_linha_oc"] != DBNull.Value)
                {
                    this.linhaOC = Convert.ToInt32(read["soc_numero_linha_oc"]);
                }

                if (read["soc_numero_linha_oc"] != DBNull.Value)
                {
                    this.itemNaoDeveAtualizarPrecosNoRecebimento = Convert.ToBoolean(read["soc_nao_atualiza_preco_recebimento"]);
                }


                this.QtdUnidadeUso = Convert.ToDouble(read["soc_qtd_unidade_uso"]);
                this.UnidadeCompra = read["soc_unidade_compra"].ToString();

                this.HistoricoCalculoNecessidade = read["soc_historico_calculo_necessidade"].ToString();

                this.Consumo = Convert.ToBoolean(Convert.ToInt16(read["soc_tipo_alocacao_estoque"]));

                read.Close();

                #region Load dos Pedidos
                this.Pedidos = new List<SolicitacaoCompraPedidoClass>();
                command.CommandText =
                    "SELECT  " +
                    "  public.solicitacao_compra_pedido.id_solicitacao_compra_pedido " +
                    "FROM " +
                    "  public.solicitacao_compra_pedido " +
                    "WHERE " +
                    "  public.solicitacao_compra_pedido.id_solicitacao_compra = :id_solicitacao_compra ";



                 read = command.ExecuteReader();
                 while (read.Read())
                 {
                     this.Pedidos.Add(new SolicitacaoCompraPedidoClass(
                                          Convert.ToInt32(read["id_solicitacao_compra_pedido"]),
                                          this,
                                          this.conn));
                 }
                read.Close();


                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da Solicitação de Compra.\r\n" + e.Message, e);
            }
        }

        public void Save( bool disparadoOC= false)
        {

            IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
            this.Save(ref command, null, disparadoOC);

        }



        private void VerificarCadastroFornecedorHabilitado()
        {
            if (this.Produto != null)
            {
                if (this.Fornecedor != null)
                {

                    ProdutoFornecedorClass produtoFornecedor = this.Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
                    if (produtoFornecedor == null)
                    {
                        throw new ExcecaoTratada("Esse produto (" + Produto + ") não pode ser vendido pelo fornecedor indicado (" + Fornecedor + "), verifique se existe o vinculo entre o produto e o fornecedor no cadastro do produto.");
                    }

                }


            }

            if (this.Material != null)
            {
                if (this.Fornecedor != null)
                {

                    MaterialFornecedorClass materialFornecedor = this.Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
                    if (materialFornecedor == null)
                    {
                        throw new ExcecaoTratada("Esse material (" + Material.IdentificacaoCompleta + ") não pode ser vendido pelo fornecedor indicado (" + Fornecedor + "), verifique se existe o vinculo entre o material e o fornecedor no cadastro do material.");
                    }


                }

            }

            if (this.Epi != null)
            {

                if (this.Fornecedor != null)
                {

                    EpiFornecedorClass epiFornecedor = this.Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Fornecedor == this.Fornecedor);
                    if (epiFornecedor == null)
                    {
                        throw new ExcecaoTratada("Esse epi (" + Epi + ") não pode ser vendido pelo fornecedor indicado (" + Fornecedor + "), verifique se existe o vinculo entre o epi e o fornecedor no cadastro do epi.");
                    }


                }
            }
        }

        private void GerarLog(string local)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string dados = JsonConvert.SerializeObject(this, settings);
            Log.Registrar(IWTLogSeveridade.Info, "SAVE", this.GetType().ToString(), local , dados, conn.ConnectionString);

        }

        public void Save(ref IWTPostgreNpgsqlCommand command, bool? ocNova, bool disparadoOC = false)
        {
            try
            {
                VerificarCadastroFornecedorHabilitado();

                GerarLog("Classe Antiga");

                bool inserting = idSolicitacaoCompra == null || idSolicitacaoCompra <=0;

                if (this.idSolicitacaoCompra == null)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "public.solicitacao_compra " +
                        "( " +
                        "  id_material, " +
                        "  id_produto, " +
                        "  id_epi, " +
                        "  id_ordem_compra, " +
                        "  id_acs_usuario, " +
                        "  soc_qtd, " +
                        "  soc_status, " +
                        "  soc_data_abertura, " +
                        "  soc_saldo_recebimento, " +
                        "  soc_entrega_prevista, " +
                        "  id_acs_usuario_pcp, " +
                        "  id_acs_usuario_comprador, " +
                        "  soc_data_aprovacao_pcp, " +
                        "  soc_data_aprovacao_compras, " +
                        "  soc_observacao, " +
                        "  id_acs_usuario_cancelamento, " +
                        "  soc_data_cancelamento, " +
                        "  soc_numero_linha_oc, "+
                        "  soc_valor_unitario_oc, "+
                        "  soc_valor_total_oc, "+
                        "  soc_aliquota_ipi_oc, " +
                        "  soc_aliquota_icms_oc, " +
                        "  soc_qtd_unidade_uso, " +
                        "  soc_unidade_compra, " +
                        "  soc_historico_calculo_necessidade, "+
                        "  soc_entrega_prevista_original, "+
                        "  soc_qtd_original, "+
                        "  soc_tipo_alocacao_estoque, "+
                        "  soc_nao_atualiza_preco_recebimento " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_material, " +
                        "  :id_produto, " +
                        "  :id_epi, " +
                        "  :id_ordem_compra, " +
                        "  :id_acs_usuario, " +
                        "  :soc_qtd, " +
                        "  :soc_status, " +
                        "  :soc_data_abertura, " +
                        "  :soc_saldo_recebimento, " +
                        "  :soc_entrega_prevista, " +
                        "  :id_acs_usuario_pcp, " +
                        "  :id_acs_usuario_comprador, " +
                        "  :soc_data_aprovacao_pcp, " +
                        "  :soc_data_aprovacao_compras, " +
                        "  :soc_observacao, " +
                        "  :id_acs_usuario_cancelamento, " +
                        "  :soc_data_cancelamento, " +
                        "  :soc_numero_linha_oc, " +
                        "  :soc_valor_unitario_oc, " +
                        "  :soc_valor_total_oc, " +
                        "  :soc_aliquota_ipi_oc, " +
                        "  :soc_aliquota_icms_oc, " +
                        "  :soc_qtd_unidade_uso, " +
                        "  :soc_unidade_compra, " +
                        "  :soc_historico_calculo_necessidade, " +
                        "  :soc_entrega_prevista_original, " +
                        "  :soc_qtd_original, " +
                        "  :soc_tipo_alocacao_estoque, " +
                        "  :soc_nao_atualiza_preco_recebimento " +
                        ") RETURNING id_solicitacao_compra;";
                }
                else
                {
                    command.CommandText =
                         "UPDATE  " +
                         "  public.solicitacao_compra   " +
                         "SET  " +
                         "  id_material = :id_material, " +
                         "  id_produto = :id_produto, " +
                         "  id_epi = :id_epi, " +
                         "  id_ordem_compra = :id_ordem_compra, " +
                         "  id_acs_usuario = :id_acs_usuario, " +
                         "  soc_qtd = :soc_qtd, " +
                         "  soc_status = :soc_status, " +
                         "  soc_data_abertura = :soc_data_abertura, " +
                         "  soc_saldo_recebimento = :soc_saldo_recebimento, " +
                         "  soc_entrega_prevista = :soc_entrega_prevista, " +
                         "  id_acs_usuario_pcp = :id_acs_usuario_pcp, " +
                         "  id_acs_usuario_comprador = :id_acs_usuario_comprador, " +
                         "  soc_data_aprovacao_pcp = :soc_data_aprovacao_pcp, " +
                         "  soc_data_aprovacao_compras = :soc_data_aprovacao_compras, " +
                         "  soc_observacao = :soc_observacao, " +
                         "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento, " +
                         "  soc_data_cancelamento = :soc_data_cancelamento, " +
                         "  soc_numero_linha_oc = :soc_numero_linha_oc, " +
                         "  soc_valor_unitario_oc = :soc_valor_unitario_oc, " +
                         "  soc_valor_total_oc = :soc_valor_total_oc, " +
                         "  soc_aliquota_ipi_oc = :soc_aliquota_ipi_oc, " +
                         "  soc_aliquota_icms_oc = :soc_aliquota_icms_oc, " +
                         "  soc_qtd_unidade_uso = :soc_qtd_unidade_uso, " +
                         "  soc_unidade_compra = :soc_unidade_compra, " +
                         "  soc_historico_calculo_necessidade = :soc_historico_calculo_necessidade, "+
                         "  soc_tipo_alocacao_estoque = :soc_tipo_alocacao_estoque, " +
                         "  soc_nao_atualiza_preco_recebimento = :soc_nao_atualiza_preco_recebimento " +
                         "WHERE  " +
                         "  id_solicitacao_compra = :id_solicitacao_compra " +
                         " RETURNING id_solicitacao_compra; ";
                }
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idSolicitacaoCompra;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                if (this.Produto != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Produto.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                if (this.Material != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Material.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                if (this.Epi != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Epi.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.usuarioAbertura.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_qtd", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_abertura", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataAbertura;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_saldo_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.saldoEntrega;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_entrega_prevista", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.DataEntregaPrevista;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_pcp", NpgsqlDbType.Integer));
                if (this.usuarioPCP != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.usuarioPCP.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_comprador", NpgsqlDbType.Integer));
                if (this.usuarioCompras != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.usuarioCompras.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_aprovacao_pcp", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataAprovacaoPCP;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_aprovacao_compras", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataAprovacaoCompras;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Observacao;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
                if (this.OrdemCompra != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.OrdemCompra.Id;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                if (this.usuarioCancelamento != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.usuarioCancelamento.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataCancelamento;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_numero_linha_oc", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.linhaOC;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_valor_unitario_oc", NpgsqlDbType.Double));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_valor_total_oc", NpgsqlDbType.Double));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_aliquota_ipi_oc", NpgsqlDbType.Double));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_aliquota_icms_oc", NpgsqlDbType.Double));

                if (this.OrdemCompra != null)
                {
                    if (this.ValorUnitarioCompra == null)
                    {
                        this.ValorUnitarioCompra = 0;
                    }

                    if (this.AliquotaICMSCompra == null)
                    {
                        this.AliquotaICMSCompra = 0;
                    }

                    if (this.AliquotaIPICompra == null)
                    {
                        this.AliquotaIPICompra = 0;
                    }

                    command.Parameters["soc_valor_unitario_oc"].Value = this.ValorUnitarioCompra;
                    command.Parameters["soc_valor_total_oc"].Value = this.ValorTotalCompra;
                    command.Parameters["soc_aliquota_ipi_oc"].Value = this.AliquotaIPICompra;
                    command.Parameters["soc_aliquota_icms_oc"].Value = this.AliquotaICMSCompra;

                }
                else
                {
                    command.Parameters["soc_valor_unitario_oc"].Value = null;
                    command.Parameters["soc_valor_total_oc"].Value = null;
                    command.Parameters["soc_aliquota_ipi_oc"].Value = null;
                    command.Parameters["soc_aliquota_icms_oc"].Value = null;
                }



                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_qtd_unidade_uso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.QtdUnidadeUso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_unidade_compra", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.UnidadeCompra;


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_historico_calculo_necessidade", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = this.HistoricoCalculoNecessidade;


                if (this.idSolicitacaoCompra == null)
                {
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_entrega_prevista_original", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = this.DataEntregaPrevista;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_qtd_original", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;

                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_tipo_alocacao_estoque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Consumo);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_nao_atualiza_preco_recebimento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.itemNaoDeveAtualizarPrecosNoRecebimento);
                


                this.idSolicitacaoCompra = Convert.ToInt32(command.ExecuteScalar());
                


                if (this.Pedidos != null)
                {
                    foreach (SolicitacaoCompraPedidoClass pedido in Pedidos)
                    {
                        pedido.Save(ref command);
                    }
                }

                if (!disparadoOC)
                {
                    if (this.OrdemCompra != null)
                    {
                        this.OrdemCompra.verificaStatus(ref command);
                    }
                }

         


                if (ocNova.HasValue && ocNova.Value)
                {
                    if (Material != null && Material.UtilizandoEstoqueSeguranca!=EstoqueSeguranca.NaoUtilizando)
                    {
                        Material.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, false, "SC: " + this.idSolicitacaoCompra);
                        bool tmp = Material.ControleRevisaoHabilitado;
                        try
                        {
                            Material.ControleRevisaoHabilitado = false;
                            Material.Save(ref command);
                        }
                        finally
                        {
                            Material.ControleRevisaoHabilitado = tmp;
                        }
                    }

                    if (Produto != null && Produto.UtilizandoEstoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
                    {
                        Produto.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, false, "SC: " + this.idSolicitacaoCompra);
                        bool tmp = Produto.ControleRevisaoHabilitado;
                        try
                        {
                            Produto.ControleRevisaoHabilitado = false;
                            Produto.DesabilitarJustificativaRevisaoProduto = true;
                            Produto.Save(ref command);
                        }
                        finally
                        {
                            Produto.ControleRevisaoHabilitado = tmp;
                            Produto.DesabilitarJustificativaRevisaoProduto = false;
                        }
                    }

                    if (Epi != null && Epi.UtilizandoEstoqueSeguranca != EstoqueSeguranca.NaoUtilizando)
                    {
                        Epi.SetUtilizandoEstoqueSeguranca(EstoqueSeguranca.NaoUtilizando, false, "SC: " + this.idSolicitacaoCompra);
                        bool tmp = Epi.ControleRevisaoHabilitado;
                        try
                        {
                            Epi.ControleRevisaoHabilitado = false;
                            Epi.Save(ref command);
                        }
                        finally
                        {
                            Epi.ControleRevisaoHabilitado = tmp;
                        }
                    }
                }

                if (_status == SolicitacaoCompraStatus.AprovadaPCP)
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

                    SolicitacaoCompraDto dto = new SolicitacaoCompraDto()
                    {
                        id = idSolicitacaoCompra.Value,
                        dataAprovacaoLiberacao = dataAprovacaoPCP,
                        entregaPrevista = DataEntregaPrevista,
                        ordemCompraId = (long?) (OrdemCompra == null?null:OrdemCompra.Id),
                        produtoId = idSimulador,
                        solicitante = usuarioPCP.Login,
                        qtdUnidadeUso = QtdUnidadeUso,
                        unidadeUso = unidadeUsoProdutoMaterial
                        
                        
                    };

                    if (_statusAnterior == SolicitacaoCompraStatus.Nova)
                    {
                        ApiSimuladorCompras.SincronizarSolicitacaoCompra(dto.id, "CRIAR", usuarioAtual, command);
                    }
                    else
                    {
                        ApiSimuladorCompras.SincronizarSolicitacaoCompra(dto.id, "ATUALIZAR", usuarioAtual, command);
                    }

                
                }

                if (_statusAnterior != SolicitacaoCompraStatus.Cancelada && Status == SolicitacaoCompraStatus.Cancelada && OrdemCompra == null)
                {
                    ApiSimuladorCompras.SincronizarSolicitacaoCompra(idSolicitacaoCompra.Value, "EXCLUIR", usuarioAtual, command);
                }


                GerarLog("Classe antiga, pós save");

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a solicitação.\r\n" + e.Message, e);
            }


        }

        public void setMaterial(MaterialClass material, double quantidade, double quantidadeEmUnidadesUso, List<SolicitacaoCompraPedidoClass> pedidos, DateTime dataEntrega, string Observacao)
        {
            this.Material = material;

            this.DataEntregaPrevista = dataEntrega;
            this.Observacao = Observacao;
            this.Pedidos = pedidos;
            this.QtdUnidadeUso = quantidadeEmUnidadesUso;
            this.Quantidade = quantidade;
            this.UnidadeCompra = this.unidadeCompraProdutoMaterial ?? this.unidadeUsoProdutoMaterial;

        }

        public void setProduto(ProdutoClass produto, double quantidade, double quantidadeEmUnidadesUso, List<SolicitacaoCompraPedidoClass> pedidos, DateTime dataEntrega, string Observacao)
        {
            this.Produto = produto;

            this.DataEntregaPrevista = dataEntrega;
            this.Observacao = Observacao;
            this.Pedidos = pedidos;
            this.QtdUnidadeUso = quantidadeEmUnidadesUso;
            this.Quantidade = quantidade;
            this.UnidadeCompra = this.unidadeCompraProdutoMaterial ?? this.unidadeUsoProdutoMaterial;
        }

        public void setEpi(EpiClass epi, double quantidade, double quantidadeEmUnidadesUso, List<SolicitacaoCompraPedidoClass> pedidos, DateTime dataEntrega, string Observacao)
        {
            this.Epi = epi;

            this.DataEntregaPrevista = dataEntrega;
            this.Observacao = Observacao;
            this.Pedidos = pedidos;
            this.QtdUnidadeUso = quantidadeEmUnidadesUso;
            this.Quantidade = quantidade;
            this.UnidadeCompra = this.unidadeCompraProdutoMaterial ?? this.unidadeUsoProdutoMaterial;
        }


        public void aprovarPCP()
        {
            ValidacaoOnAlterarStatus();

            this.Status = SolicitacaoCompraStatus.AprovadaPCP;
            this.usuarioPCP = this.usuarioAtual;
            this.dataAprovacaoPCP = Configurations.DataIndependenteClass.GetData();
        }

        internal void Comprar(OrdemCompraClass ordemCompra, int linhaOC)
        {
            ValidacaoOnAlterarStatus();

            this.Status = SolicitacaoCompraStatus.Comprada;
            this.OrdemCompra = ordemCompra;
            this.dataAprovacaoCompras = Configurations.DataIndependenteClass.GetData();
            this.usuarioCompras = this.usuarioAtual;
            this.linhaOC = linhaOC;
            
        }

        internal void DefinirValores(double valorUnitario, double aliquotaIpi, double aliquotaICMS)
        {
            this.ValorUnitarioCompra = valorUnitario;
            this.AliquotaICMSCompra = aliquotaICMS;
            this.AliquotaIPICompra = aliquotaIpi;
        }

        public void Cancelar()
        {
            try
            {
                if (this.Status == SolicitacaoCompraStatus.Cancelada)
                {
                    throw new Exception("Não é possível cancelar uma Solicitação já cancelada");
                }


                if (this.Status == SolicitacaoCompraStatus.RecebidaParcial)
                {
                    throw new Exception("A solicitação de compra "+this.idSolicitacaoCompra+" possui recebimentos realizados utilize a função de cancelar o saldo.");
                }

                if (this.Status == SolicitacaoCompraStatus.RecebidaTotal)
                {
                    throw new Exception("A solicitação de compra " + this.idSolicitacaoCompra + " não pode ser cancelada pois já foi totalmente recebida");
                }

                ValidacaoOnAlterarStatus();
                
                this.Status = SolicitacaoCompraStatus.Cancelada;
                this.dataCancelamento = Configurations.DataIndependenteClass.GetData();
                this.usuarioCancelamento = this.usuarioAtual;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar a Solicitação de Compra.\r\n" + e.Message, e);
            }
        }

        internal void lancarBaixa(double Quantidade)
        {
            try
            {
                this.saldoEntrega -= Quantidade;
                this.saldoEntrega = Math.Round(this.saldoEntrega, 4, MidpointRounding.ToEven);

                if (this.saldoEntrega < 0)
                {
                    throw new Exception("Saldo insuficiente.");
                }
                else {
                    ValidacaoOnAlterarStatus();

                    if (saldoEntrega <= 0.00001)
                    {
                        this.saldoEntrega = 0;
                        this.Status = SolicitacaoCompraStatus.RecebidaTotal;
                    }
                    else
                    {
                        this.Status = SolicitacaoCompraStatus.RecebidaParcial;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao lançar a baixa da solicitação\r\n" + e.Message, e);
            }
        }

        private void loadFornecedor()
        {
            try
            {
                if (this.OrdemCompra != null)
                {

                    this._fornecedor = this.OrdemCompra.Fornecedor;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o fornecedor.\r\n" + e.Message, e);
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void removerOC()
        {
            ValidacaoOnAlterarStatus();

            this.Status = SolicitacaoCompraStatus.AprovadaPCP;
            this.OrdemCompra = null;
            this.dataAprovacaoCompras = null;
            this.usuarioCompras = null;
            this.linhaOC = 0;
            this.ValorUnitarioCompra = null;
            this.AliquotaICMSCompra = null;
            this.AliquotaIPICompra = null;

            //Volta a quantidade e a unidade de medida originais caso tenha sido alterado pela seleção do fornecedor
            double quantidade = this.QtdUnidadeUso/this.unidadesPorUnidadeCompraProdutoMaterial;

            int qtdLotesPadrao = (int)Math.Truncate(quantidade / this.LotePadraoCompraProdutoMaterial);
            double tmp = Math.Round(qtdLotesPadrao*this.LotePadraoCompraProdutoMaterial, 4);
            if (tmp < quantidade)
            {
                tmp += this.LotePadraoCompraProdutoMaterial;
            }

            quantidade = Math.Round(tmp, 4);
            this.Quantidade =quantidade;
            this.UnidadeCompra = unidadeCompraProdutoMaterial;

        }

        public void atualizarDadosCompra(double valorUnitario, double aliquotaIcms, double aliquotaIpi)
        {
            this.ValorUnitarioCompra = valorUnitario;
            this.AliquotaICMSCompra = aliquotaIcms;
            this.AliquotaIPICompra = aliquotaIpi;
        }


        public void CancelarSaldo()
        {
            this.Quantidade = this.Quantidade - this.saldoEntrega;
        }

        public void aplicaDescontos(double descontoP)
        {
            this.ValorUnitarioCompra = (this.ValorUnitarioCompra*(1 - descontoP));
        }

        public double ValorComDesconto
        {
            get
            {
                double valorComDesconto = this.ValorTotalCompra;

                if (this.OrdemCompra == null || this.OrdemCompra.ValorTotal <= 0)
                {
                    return this.ValorTotalCompra;
                }

                double razao = Math.Round((this.ValorTotalCompra / this.OrdemCompra.ValorTotal), 15, MidpointRounding.ToEven);

                if (this.OrdemCompra.DescontoP > 0)
                {
                    double desconto = this.OrdemCompra.DescontoP / 100;

                    Double? valorUnitarioOc = (this.ValorUnitarioCompra * (1 - desconto));
                    Double? valorTotalOc = valorUnitarioOc * this.Quantidade;

                    if (valorTotalOc.HasValue)
                    {
                        valorComDesconto = valorTotalOc.Value;
                    }

                }

                else if (this.OrdemCompra.DescontoR > 0)
                {
                    double desconto = Math.Round(this.OrdemCompra.DescontoR * razao, 4);

                    Double? valorTotalOc = this.ValorTotalCompra - desconto;

                    if (valorTotalOc.HasValue)
                    {
                        valorComDesconto = valorTotalOc.Value;
                    }

                }

                return Math.Round(valorComDesconto, 2);
            }

        }


        public double ValorUnitarioComDesconto
        {
            get
            {
                double valorComDesconto = ValorComDesconto;

                double valorUnitarioComDesconto = Math.Round(valorComDesconto, 2)/this.Quantidade;

                return Math.Round(valorUnitarioComDesconto, 2);
            }

        }

        public void ValidacaoOnAlterarStatus()
        {
            if (IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO) && this.idSolicitacaoCompra.HasValue)
            {
                DadosScOnAlterarStatusDto dadosScOnAlterarStatus = ApiSimuladorCompras.BuscarDadosOnAlterarStatusSC(this.idSolicitacaoCompra.Value);

                if (dadosScOnAlterarStatus.solicitacaoId > 0)
                {
                    if (dadosScOnAlterarStatus.ordemCompraId > 0)
                    {
                        if (this.OrdemCompra == null)
                        {
                            throw new Exception("Para realizar a operação da solicitação de compra " + this.idSolicitacaoCompra + " ela deve ser sincronizada com o SDC. Favor sincronizar as OCs.");
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return idSolicitacaoCompra.ToString();
        }
    }   

    public class SolicitacaoCompraPedidoClass
    {
        private int? ID;

        public int IdPedidoItem { get; private set; }
        public double Quantidade { get; private set; }


        private readonly SolicitacaoCompraClass Pai;
        private readonly IWTPostgreNpgsqlConnection conn;

        public SolicitacaoCompraPedidoClass(int idPedidoItem, double quantidade, SolicitacaoCompraClass pai, IWTPostgreNpgsqlConnection conn)
        {
            IdPedidoItem = idPedidoItem;
            Quantidade = quantidade;
            Pai = pai;
            this.conn = conn;
        }

        public SolicitacaoCompraPedidoClass(int id, SolicitacaoCompraClass pai, IWTPostgreNpgsqlConnection conn)
        {
            ID = id;
            this.conn = conn;
            Pai = pai;

            this.Load();
        }

        private void Load()
        {
            try
            {

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  id_pedido_item, " +
                    "  scp_quantidade " +
                    "FROM  " +
                    "  public.solicitacao_compra_pedido " +
                    "WHERE " +
                    "  id_solicitacao_compra_pedido = :id_solicitacao_compra_pedido ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra_pedido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }
                read.Read();

                this.IdPedidoItem = (int)read["id_pedido_item"];
                this.Quantidade = (double)read["scp_quantidade"];


                read.Close();




            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do pedido da solicitação de compra\r\n" + e.Message, e);
            }
        }


        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID==null)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.solicitacao_compra_pedido " +
                        "( " +
                        "  id_solicitacao_compra, " +
                        "  id_pedido_item, " +
                        "  scp_quantidade " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_solicitacao_compra, " +
                        "  :id_pedido_item, " +
                        "  :scp_quantidade " +
                        ") RETURNING id_solicitacao_compra_pedido; ";
                }
                else
                {
                    command.CommandText =
                        "UPDATE " +
                        "  public.solicitacao_compra_pedido   " +
                        "SET  " +
                        "  id_solicitacao_compra = :id_solicitacao_compra, " +
                        "  id_pedido_item = :id_pedido_item, " +
                        "  scp_quantidade = :scp_quantidade " +
                        "WHERE  " +
                        "  id_solicitacao_compra_pedido = :id_solicitacao_compra_pedido " +
                        " RETURNING id_solicitacao_compra_pedido ; ";

                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra_pedido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Pai.idSolicitacaoCompra;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.IdPedidoItem;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("scp_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;

                this.ID = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o pedido da solicitação de compra\r\n" + e.Message, e);
            }

        }
    }

    public class SolicitacaoComparerOrdenacaoLinha : IComparer<SolicitacaoCompraClass>
    {
        #region Implementation of IComparer<SolicitacaoCompraClass>

        public int Compare(SolicitacaoCompraClass x, SolicitacaoCompraClass y)
        {
            return x.linhaOC.CompareTo(y.linhaOC);
        }

        #endregion
    }
    
}
