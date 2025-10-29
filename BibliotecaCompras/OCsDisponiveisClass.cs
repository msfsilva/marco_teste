#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

#endregion

namespace BibliotecaCompras
{
    public class OCsDisponiveisClass
    {
        readonly AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;

        public SortedDictionary<OCDisponivelKey, SolicitacaoDisponivel> SolicitacoesNaoRecebidas;

        public SortedDictionary<OCDisponivelKey, SolicitacaoDisponivel> SolicitacoesNaoRecebidasComSaldo
        {
            get
            {
                return new SortedDictionary<OCDisponivelKey, SolicitacaoDisponivel>(this.SolicitacoesNaoRecebidas.Where(a => a.Value.saldoDisponivel > 0).ToDictionary(a => a.Key, a => a.Value));
            }
        }

        public List<AgrupamentoSolicitacaoDisponivel> SolicitacoesNaoRecebidasComSaldoProduto
        {
            get
            {
                Dictionary<AgrupamentoSolicitacaoDisponivelKey,AgrupamentoSolicitacaoDisponivel> tmp = new Dictionary<AgrupamentoSolicitacaoDisponivelKey, AgrupamentoSolicitacaoDisponivel>();
                foreach (SolicitacaoDisponivel solicitacaoDisponivel in this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Produto != null))
                {
                    

                    AgrupamentoSolicitacaoDisponivelKey tmpKey = new AgrupamentoSolicitacaoDisponivelKey(
                        TipoItemCompra.Produto,
                        solicitacaoDisponivel.idProdutoMaterial,
                        solicitacaoDisponivel.Solicitacao.Fornecedor);

 
                    if (!tmp.ContainsKey(tmpKey))
                    {
                        tmp.Add(tmpKey,
                                new AgrupamentoSolicitacaoDisponivel(tmpKey.TipoItem, tmpKey.Id, tmpKey.Fornecedor));
                    }

                    tmp[tmpKey].adicionarSolicitacao(solicitacaoDisponivel);
                }

                return new List<AgrupamentoSolicitacaoDisponivel>(tmp.Values);
                //return new List<SolicitacaoDisponivel>(this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Produto != null));
            }
        }

        public List<AgrupamentoSolicitacaoDisponivel> SolicitacoesNaoRecebidasComSaldoMaterial
        {
            get
            {
                Dictionary<AgrupamentoSolicitacaoDisponivelKey, AgrupamentoSolicitacaoDisponivel> tmp = new Dictionary<AgrupamentoSolicitacaoDisponivelKey, AgrupamentoSolicitacaoDisponivel>();
                foreach (SolicitacaoDisponivel solicitacaoDisponivel in this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Material != null))
                {
                    //bool isMaterial = solicitacaoDisponivel.Material != null;

                    AgrupamentoSolicitacaoDisponivelKey tmpKey = new AgrupamentoSolicitacaoDisponivelKey(
                        TipoItemCompra.Material, 
                        solicitacaoDisponivel.idProdutoMaterial,
                        solicitacaoDisponivel.Solicitacao.Fornecedor);


                    if (!tmp.ContainsKey(tmpKey))
                    {
                        tmp.Add(tmpKey,
                                new AgrupamentoSolicitacaoDisponivel(tmpKey.TipoItem, tmpKey.Id, tmpKey.Fornecedor));
                    }

                    tmp[tmpKey].adicionarSolicitacao(solicitacaoDisponivel);
                }

                return new List<AgrupamentoSolicitacaoDisponivel>(tmp.Values);
                //return new List<SolicitacaoDisponivel>(this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Material != null));

            }
        }

        public List<AgrupamentoSolicitacaoDisponivel> SolicitacoesNaoRecebidasComSaldoEpi
        {
            get
            {
                Dictionary<AgrupamentoSolicitacaoDisponivelKey, AgrupamentoSolicitacaoDisponivel> tmp = new Dictionary<AgrupamentoSolicitacaoDisponivelKey, AgrupamentoSolicitacaoDisponivel>();
                foreach (SolicitacaoDisponivel solicitacaoDisponivel in this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Epi != null))
                {
                    AgrupamentoSolicitacaoDisponivelKey tmpKey = new AgrupamentoSolicitacaoDisponivelKey(
                        TipoItemCompra.Epi, 
                        solicitacaoDisponivel.idProdutoMaterial,
                        solicitacaoDisponivel.Solicitacao.Fornecedor);


                    if (!tmp.ContainsKey(tmpKey))
                    {
                        tmp.Add(tmpKey,
                                new AgrupamentoSolicitacaoDisponivel(tmpKey.TipoItem, tmpKey.Id, tmpKey.Fornecedor));
                    }

                    tmp[tmpKey].adicionarSolicitacao(solicitacaoDisponivel);
                }

                return new List<AgrupamentoSolicitacaoDisponivel>(tmp.Values);
                //return new List<SolicitacaoDisponivel>(this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Material != null));

            }
        }

        public OCsDisponiveisClass(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
            this.Usuario = Usuario;
            this.loadOcsLivres();
        }

        public void loadOcsLivres()
        {
            try
            {
                this.SolicitacoesNaoRecebidas = new SortedDictionary<OCDisponivelKey, SolicitacaoDisponivel>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                command.CommandText =
                "SELECT  " +
                "  public.solicitacao_compra.id_solicitacao_compra " +
                "FROM " +
                "  public.solicitacao_compra " +
                "WHERE " +
                "  public.solicitacao_compra.soc_status = 3 OR " +
                "  public.solicitacao_compra.soc_status = 4 ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("Não existem Solicitações de compra para recebimento.");
                }

                while (read.Read())
                {


                    SolicitacaoCompraClass tmp = new SolicitacaoCompraClass(Convert.ToInt32(read["id_solicitacao_compra"]),null, this.Usuario, this.conn);


                    TipoItemCompra tipoTmp;
                    long id = 0;
                    if (tmp.Material != null)
                    {
                        tipoTmp = TipoItemCompra.Material;
                        id = tmp.Material.ID;
                    }
                    else
                    {
                        if (tmp.Epi != null)
                        {
                            tipoTmp = TipoItemCompra.Epi;
                            id = tmp.Epi.ID;
                        }
                        else
                        {
                            tipoTmp = TipoItemCompra.Produto;
                            id = tmp.Produto.ID;

                        }

                    }


                    OCDisponivelKey key = new OCDisponivelKey(
                        tipoTmp,
                        id,
                        tmp.OrdemCompra.Id.Value,
                        tmp.linhaOC,
                        tmp.UnidadeCompra);

                    this.SolicitacoesNaoRecebidas.Add(key, new SolicitacaoDisponivel() { Solicitacao = tmp });
                }
                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar as Solicitações livres.\r\n" + e.Message, e);
            }

        }

        public List<SolicitacaoDisponivel> getSolicitacoesProdutoComSaldo(long idProduto)
        {
            try
            {
                return new List<SolicitacaoDisponivel>(this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Produto != null && a.Produto.ID == idProduto)).OrderBy(a => a.Solicitacao.DataEntregaPrevista).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar as solicitações de produto com saldo.\r\n" + e.Message, e);
            }
        }

        public List<SolicitacaoDisponivel> getSolicitacoesMaterialComSaldo(long idMaterial)
        {
            try
            {
                return new List<SolicitacaoDisponivel>(this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Material != null && a.Material.ID == idMaterial)).OrderBy(a=>a.Solicitacao.DataEntregaPrevista).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar as solicitações de material com saldo.\r\n" + e.Message, e);
            }
        }

        public List<SolicitacaoDisponivel> getSolicitacoesEpiComSaldo(long idEpi)
        {
            try
            {
                return new List<SolicitacaoDisponivel>(this.SolicitacoesNaoRecebidasComSaldo.Values.Where(a => a.Epi != null && a.Epi.ID == idEpi)).OrderBy(a => a.Solicitacao.DataEntregaPrevista).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar as solicitações de Epi com saldo.\r\n" + e.Message, e);
            }
        }

        internal SolicitacaoDisponivel getSolicitacaoByID(long idSolicitacaoCompra)
        {
            try
            {
                return this.SolicitacoesNaoRecebidas.Values.First(a => a.idSolicitacaoCompra == idSolicitacaoCompra);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar a solicitação pelo id.\r\n" + e.Message, e);
            }
        }

        internal void setQuantidadesLinhaSelecionada(List<SolicitacaoQuantidadeClass> SolicitacoesLinha)
        {

            foreach (SolicitacaoDisponivel solDisponivel in this.SolicitacoesNaoRecebidas.Values)
            {
                bool found = false;
                foreach (SolicitacaoQuantidadeClass solLinha in SolicitacoesLinha)
                {
                    if (solDisponivel.Solicitacao.idSolicitacaoCompra == solLinha.Solicitacao.idSolicitacaoCompra)
                    {
                        solDisponivel.quantidadeUtilizadaLinhaSelecionada = solLinha.quantidadeUtilizada;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    solDisponivel.quantidadeUtilizadaLinhaSelecionada = 0;
                }

            }
        }
    }



    public class OCDisponivelKey : IEquatable<OCDisponivelKey>, IComparable<OCDisponivelKey>
    {
        readonly TipoItemCompra tipoItem;
        readonly long ID;
        readonly long idOC;
        readonly int linhaOC;
        readonly string unidadeCompra;

        public OCDisponivelKey(TipoItemCompra _tipoItem, long ID, long idOC, int linhaOC, string unidadeCompra)
        {
            this.ID = ID;
            this.idOC = idOC;
            this.linhaOC = linhaOC;
            this.tipoItem = _tipoItem;
            this.unidadeCompra = unidadeCompra;
        }

        #region IEquatable<OCDisponivelKey> Members

        public bool Equals(OCDisponivelKey other)
        {
            bool resultEqualUnidadeCompra;
            if (this.unidadeCompra!=null)
            {
                resultEqualUnidadeCompra = this.unidadeCompra.Equals(other.unidadeCompra);
            }
            else
            {
                if (other.unidadeCompra==null)
                {
                    resultEqualUnidadeCompra = true;
                }
                else
                {
                    resultEqualUnidadeCompra = false;
                }
            }
            return this.tipoItem.Equals(other.tipoItem) && this.ID.Equals(other.ID) && this.idOC.Equals(other.idOC) && this.linhaOC.Equals(other.linhaOC) && resultEqualUnidadeCompra ;
        }

        #endregion

        #region IComparable<OCDisponivelKey> Members

        public int CompareTo(OCDisponivelKey other)
        {
            if (this.tipoItem.CompareTo(other.tipoItem) == 0)
            {
                if (this.ID.CompareTo(other.ID) == 0)
                {
                    if (this.idOC.CompareTo(other.idOC) == 0)
                    {
                        if (this.linhaOC.CompareTo(other.linhaOC) == 0)
                        {
                            if (this.unidadeCompra!=null)
                            {
                                return this.unidadeCompra.CompareTo(other.unidadeCompra);
                            }
                            else
                            {
                                if (other.unidadeCompra==null)
                                {
                                    return 0;
                                }
                                else
                                {
                                    return -1;
                                }
                            }
                        }
                        else
                        {
                            return this.linhaOC.CompareTo(other.linhaOC);
                        }
                    }
                    else
                    {
                        return this.idOC.CompareTo(other.idOC);
                    }
                }
                else
                {
                    return this.ID.CompareTo(other.ID);
                }
            }
            else
            {
                return this.tipoItem.CompareTo(other.tipoItem);
            }
        }

        #endregion
    }

    public class SolicitacaoDisponivel
    {
        public SolicitacaoCompraClass Solicitacao { get; set; }
        public double quantidadeUtilizadaLinhaSelecionada { get; set; }

        public long idProdutoMaterial
        {
            get
            {
                return this.Solicitacao.idProdutoMaterial;
            }
        }

        public string codigoProdutoMaterial
        {
            get
            {
                return this.Solicitacao.codigoProdutoMaterial;
            }
        }

        public string descricaoProdutoMaterial
        {
            get
            {
                return this.Solicitacao.descricaoProdutoMaterial;
            }
        }

        public string infoAdicionalProdutoMaterial
        {
            get
            {
                return this.Solicitacao.infoAdicionalProdutoMaterial;
            }
        }

        public string unidadeCompraProdutoMaterial
        {
            get
            {
                return this.Solicitacao.UnidadeCompra;
            }
        }

        public string unidadeUsoProdutoMaterial
        {
            get
            {
                return this.Solicitacao.unidadeUsoProdutoMaterial;
            }
        }

        public double unidadesPorUnidadeCompraProdutoMaterial
        {
            get
            {
                return this.Solicitacao.UnidadesUsoPorUnidadeCompra;
            }
        }

        public double saldoDisponivel
        {
            get
            {
                return this.Solicitacao.saldoEntrega + this.quantidadeUtilizadaLinhaSelecionada;
            }
        }
        public double saldoDisponivelOriginal
        {
            get
            {
                return this.Solicitacao.saldoEntregaOriginal;
            }
        }

        public ProdutoClass Produto
        {
            get
            {
                return this.Solicitacao.Produto;
            }
        }

        public MaterialClass Material
        {
            get
            {
                return this.Solicitacao.Material;
            }
        }

        public EpiClass Epi
        {
            get
            {
                return this.Solicitacao.Epi;
            }
        }


        public long? idSolicitacaoCompra
        {
            get
            {
                return this.Solicitacao.idSolicitacaoCompra;
            }
        }

        public string identificacaoCompletaSolicitacao
        {
            get
            {
                int? idOC = null;
                if (this.Solicitacao.OrdemCompra != null)
                {
                    idOC = this.Solicitacao.OrdemCompra.Id;
                }


                return "OC: " + idOC + " SC: " + this.idSolicitacaoCompra + " (" + (this.Solicitacao.Consumo ? "Consumo" : "Matéria Prima") + ") " + " Linha: " + this.Solicitacao.linhaOC + " - Saldo: " + this.saldoDisponivel + " " + (this.unidadeCompraProdutoMaterial ?? this.unidadeUsoProdutoMaterial);
            }
        }

        public string politicaEstoque
        {
            get
            {
                return this.Solicitacao.politicaEstoque;
            }
        }

        public string StringQuantidadeMaxima
        {
            get
            {


                double qtdTotal = this.saldoDisponivel;
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

                return (qtdTotal.ToString("F4", CultureInfo.CurrentCulture) + " + " + margemRecebimento + "% = " + this.QuantidadeMaxima.ToString("F4", CultureInfo.CurrentCulture) + " " +
                        (string.IsNullOrEmpty(this.unidadeCompraProdutoMaterial) ? this.unidadeUsoProdutoMaterial : this.unidadeCompraProdutoMaterial)).Replace(",0000", "");

            }
        }


        public double QuantidadeMaxima
        {
            get
            {


                double qtdTotal = this.saldoDisponivel;
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

                return Math.Round((qtdTotal*(1 + (margemRecebimento/100))), 4, MidpointRounding.ToEven);

            }
        }
    }

    public class AgrupamentoSolicitacaoDisponivelKey : IEquatable<AgrupamentoSolicitacaoDisponivelKey>, IComparable<AgrupamentoSolicitacaoDisponivelKey>
    {
        public TipoItemCompra TipoItem { get; private set; }
        public long Id { get; private set; }
        public FornecedorClass Fornecedor { get; private set; }

        public AgrupamentoSolicitacaoDisponivelKey(TipoItemCompra TipoItem, long ID, FornecedorClass fornecedor)
        {
            this.Id = ID;
            this.TipoItem = TipoItem;
            this.Fornecedor = fornecedor;
        }

        public bool Equals(AgrupamentoSolicitacaoDisponivelKey other)
        {
            bool toRet =
                this.Id.Equals(other.Id) && this.TipoItem.Equals(other.TipoItem);
            if (toRet)
            {
                if (this.Fornecedor == null)
                {
                    if (other.Fornecedor == null)
                    {
                        return true;
                    }

                    return false;
                }

                if (other.Fornecedor == null)
                {
                    return false;
                }

                return this.Fornecedor.Equals(other.Fornecedor);
            }

            return toRet;
        }
 
        public int CompareTo(AgrupamentoSolicitacaoDisponivelKey other)
        {
            if (this.TipoItem.CompareTo(other.TipoItem) == 0)
            {
                if (this.Id.CompareTo(other.Id) == 0)
                {
                    if (this.Fornecedor == null)
                    {
                        if (other.Fornecedor == null)
                        {
                            return 0;
                        }

                        return -1;
                    }

                    if (other.Fornecedor == null)
                    {
                        return 1;
                    }

                    return this.Fornecedor.RazaoSocial.CompareTo(other.Fornecedor.RazaoSocial);
                }
                else
                {
                    return this.Id.CompareTo(other.Id);
                }
            }
            else
            {
                return this.TipoItem.CompareTo(other.TipoItem);
            }
        }

        public override int GetHashCode()
        {
            int toRet = this.Id.GetHashCode() * this.TipoItem.GetHashCode();
            if (this.Fornecedor!=null)
            {
                return toRet * this.Fornecedor.ID.GetHashCode();
            }
            return toRet;
        }
    }

    public class AgrupamentoSolicitacaoDisponivel
    {
        readonly TipoItemCompra TipoItem;
        readonly long ID;
        public FornecedorClass Fornecedor { get; private set; }
        readonly List<SolicitacaoDisponivel> SolicitacoesDisponiveis;

        public long idProdutoMaterial
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].idProdutoMaterial;
                }

                return -1;
            }
        }

        public string codigoProdutoMaterial
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].codigoProdutoMaterial;
                }

                return "";
            }
        }

        public string descricaoProdutoMaterial
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].descricaoProdutoMaterial;
                }

                return "";
            }
        }

        public string infoAdicionalProdutoMaterial
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].infoAdicionalProdutoMaterial;
                }

                return "";
            }
        }

        public string unidadeCompraProdutoMaterial
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].unidadeCompraProdutoMaterial;
                }

                return "";
            }
        }

        public string unidadeUsoProdutoMaterial
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].unidadeUsoProdutoMaterial;
                }

                return "";
            }
        }

        public double unidadesPorUnidadeCompraProdutoMaterial
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].unidadesPorUnidadeCompraProdutoMaterial;
                }

                return 0;
            }
        }

        public double saldoDisponivel
        {
            get
            {
                double toRet = 0;
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    toRet = SolicitacoesDisponiveis.Sum(solicitacaoDisponivel => solicitacaoDisponivel.saldoDisponivel + solicitacaoDisponivel.quantidadeUtilizadaLinhaSelecionada);
                }

                return toRet;
            }
        }

        public string politicaEstoque
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].politicaEstoque;
                }

                return "";
            }
        }

        public string UnidadeCompra
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].Solicitacao.UnidadeCompra;
                }

                return "";
            }
        }

        public double UnidadesUsoPorUnidadeCompra
        {
            get
            {
                if (this.SolicitacoesDisponiveis != null && this.SolicitacoesDisponiveis.Count > 0)
                {
                    return this.SolicitacoesDisponiveis[0].Solicitacao.UnidadesUsoPorUnidadeCompra;
                }

                return 1;
            }
        }

        public string StringQuantidadeMaxima
        {
            get
            {
                if (this.SolicitacoesDisponiveis == null || this.SolicitacoesDisponiveis.Count == 0)
                {
                    return "0";
                }

                double qtdTotal = this.SolicitacoesDisponiveis.Sum(a => a.saldoDisponivelOriginal);
                double margemRecebimento = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.MARGEM_PADRAO_ACEITE_RECEBIMENTO_COMPRAS));
                if (this.SolicitacoesDisponiveis[0].Material != null && this.SolicitacoesDisponiveis[0].Material.MargemRecebimento.HasValue)
                {
                    margemRecebimento = this.SolicitacoesDisponiveis[0].Material.MargemRecebimento.Value;
                }

                if (this.SolicitacoesDisponiveis[0].Produto != null && this.SolicitacoesDisponiveis[0].Produto.MargemRecebimento.HasValue)
                {
                    margemRecebimento = this.SolicitacoesDisponiveis[0].Produto.MargemRecebimento ?? 0;
                }

                if (this.SolicitacoesDisponiveis[0].Epi != null && this.SolicitacoesDisponiveis[0].Epi.MargemRecebimento.HasValue)
                {
                    margemRecebimento = this.SolicitacoesDisponiveis[0].Epi.MargemRecebimento ?? 0;
                }

                return (qtdTotal.ToString("F4", CultureInfo.CurrentCulture) + " + " + margemRecebimento + "% = " + Math.Round((qtdTotal*(1 + (margemRecebimento/100))), 4, MidpointRounding.ToEven).ToString("F4", CultureInfo.CurrentCulture) + " " +
                        (string.IsNullOrEmpty(this.UnidadeCompra) ? this.unidadeUsoProdutoMaterial : this.UnidadeCompra)).Replace(",0000", "");

            }
        }

        public AgrupamentoSolicitacaoDisponivel(TipoItemCompra tipoItem, long id, FornecedorClass fornecedor)
        {
            this.SolicitacoesDisponiveis = new List<SolicitacaoDisponivel>();
            TipoItem = tipoItem;
            ID = id;
            Fornecedor = fornecedor;
        }

        public void adicionarSolicitacao(SolicitacaoDisponivel solicitacaoDisponivel)
        {
            try
            {
                switch (this.TipoItem)
                {
                    case TipoItemCompra.Material:
                        if (solicitacaoDisponivel.Material == null)
                        {
                            throw new Exception("Solicitação incompativel.");
                        }

                        if (this.ID != solicitacaoDisponivel.Material.ID)
                        {
                            throw new Exception("Solicitação incompativel.");
                        }
                        break;
                    case TipoItemCompra.Produto:
                        if (solicitacaoDisponivel.Produto == null)
                        {
                            throw new Exception("Solicitação incompativel.");
                        }

                        if (this.ID != solicitacaoDisponivel.Produto.ID)
                        {
                            throw new Exception("Solicitação incompativel.");
                        }
                        break;
                    case TipoItemCompra.Epi:
                         if (solicitacaoDisponivel.Epi == null)
                        {
                            throw new Exception("Solicitação incompativel.");
                        }

                        if (this.ID != solicitacaoDisponivel.Epi.ID)
                        {
                            throw new Exception("Solicitação incompativel.");
                        }
                        break;
                }

                this.SolicitacoesDisponiveis.Add(solicitacaoDisponivel);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar a solicitação.\r\n" + e.Message, e);
            }
        }
    }

    public class SolicitacaoQuantidadeClass
    {
        public SolicitacaoCompraClass Solicitacao { get; private set; }
        public double quantidadeUtilizada { get; private set; }

        public SolicitacaoQuantidadeClass(SolicitacaoCompraClass Solicitacao, double quantidadeUtilizada)
        {
            this.Solicitacao = Solicitacao;
            this.quantidadeUtilizada = quantidadeUtilizada;
        }
    }



}
