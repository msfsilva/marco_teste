using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public class EvolucaoPrecoCompraReportClass
    {

        public enum SelecaoRelatorio
        {
            SomenteA,
            SomenteB,
            SomenteC,
            Todos
        }

        public enum SelecaoEntidadeRelatorio
        {
            Produto,
            Material,
            Epi
        }

        private ProdutoClass produto;
        private MaterialClass material;
        private EpiClass epi;
        public DateTime DataNfe { get; private set; }
        public string NumeroNfe { get; private set; }
        public string Fornecedor { get; private set; }
        public double ValorUnitarioUnidadeUso { get; private set; }

        public  double QuantidadeUnidadeUso { get; private set; }
        public double ICMS { get; private set; }
        public double IPI { get; private set; }

        public string Codigo
        {
            get
            {
                if (this.produto != null)
                {
                    return produto.Codigo;
                }

                if (material != null)
                {
                    return material.IdentificacaoCompleta;
                }

                if (epi != null)
                {
                    return epi.Identificacao;
                }
                return null;
            }
        }

        public string Descricao
        {
            get
            {
                if (this.produto != null)
                {
                    return produto.Descricao;
                }

                if (material != null)
                {
                    return material.Descricao;
                }

                if (epi != null)
                {
                    return epi.Descricao;
                }
                return null;
            }
        }

        public string Dimensao
        {
            get
            {
                if (this.produto != null)
                {
                    return "";
                }

                if (material != null)
                {
                    return material.MedidaCompleta;
                }

                if (epi != null)
                {
                    return "";
                }
                return null;
            }
        }

        public string ClassificacaoABC
        {
            get
            {
                if (this.produto != null)
                {
                    return produto.sugestaoKB.ClassificacaoABC;
                }

                if (material != null)
                {
                    return material.sugestaoKB.ClassificacaoABC;
                }

                if (epi != null)
                {
                    return epi.sugestaoKB.ClassificacaoABC;
                }
                return null;
            }
        }

        public string Tipo
        {
            get
            {
                if (this.produto != null)
                {
                    return "Produto";
                }

                if (material != null)
                {
                    return "Material";
                }

                if (epi != null)
                {
                    return "EPI";
                }
                return null;
            }
        }

        public EvolucaoPrecoCompraReportClass(ProdutoClass produto, MaterialClass material, EpiClass epi, DateTime dataNfe, string numeroNfe, string fornecedor, double valorUnitarioUnidadeUso, double icms, double ipi, double quantidadeUnidadeUso)
        {
            this.produto = produto;
            this.material = material;
            this.epi = epi;
            DataNfe = dataNfe;
            NumeroNfe = numeroNfe;
            Fornecedor = fornecedor;
            ValorUnitarioUnidadeUso = valorUnitarioUnidadeUso;
            ICMS = icms;
            IPI = ipi;
            QuantidadeUnidadeUso = quantidadeUnidadeUso;
        }




        public static List<EvolucaoPrecoCompraReportClass> Gerar(List<AbstractEntity> entidadesSelecionada, DateTime? inicio, DateTime? fim, SelecaoRelatorio tipoRelatorio, SelecaoEntidadeRelatorio tipoEntidade, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                List<EvolucaoPrecoCompraReportClass> toRet;



                switch (tipoEntidade)
                {
                    case SelecaoEntidadeRelatorio.Produto:
                        toRet = GerarInterno((entidadesSelecionada == null ? null : entidadesSelecionada.ConvertAll(a => (ProdutoClass) a).ToList()), inicio, fim, tipoRelatorio,singleConnection);
                        break;
                    case SelecaoEntidadeRelatorio.Material:
                        toRet = GerarInterno((entidadesSelecionada == null ? null : entidadesSelecionada.ConvertAll(a => (MaterialClass)a).ToList()), inicio, fim, tipoRelatorio, singleConnection);
                        break;
                    case SelecaoEntidadeRelatorio.Epi:
                        toRet = GerarInterno((entidadesSelecionada == null ? null : entidadesSelecionada.ConvertAll(a => (EpiClass)a).ToList()), inicio, fim, tipoRelatorio, singleConnection);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("entidade");
                }

                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar o relatório de evolução de preço de compra.\r\n" + e.Message, e);
            }

        }

        private static List<EvolucaoPrecoCompraReportClass> GerarInterno(List<EpiClass> epis, DateTime? inicio, DateTime? fim, SelecaoRelatorio tipoRelatorio, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                List<EvolucaoPrecoCompraReportClass> toRet = new List<EvolucaoPrecoCompraReportClass>();

                if (epis == null)
                {
                    EpiClass search = new EpiClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                    epis = search.Search(new List<SearchParameterClass>()).ConvertAll(a => (EpiClass) a).ToList();
                }

                foreach (EpiClass epi in epis)
                {
                    switch (tipoRelatorio)
                    {
                        case SelecaoRelatorio.SomenteA:
                            if (epi.sugestaoKB.ClassificacaoABC != "A")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.SomenteB:
                            if (epi.sugestaoKB.ClassificacaoABC != "B")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.SomenteC:
                            if (epi.sugestaoKB.ClassificacaoABC != "C")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.Todos:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("tipoRelatorio");
                    }


                    foreach (HistoricoCompraEpiClass compra in epi.CollectionHistoricoCompraEpiClassEpi.Where(a => a.Lote != null).OrderBy(a => a.DataOc))
                    {
                        if (inicio.HasValue)
                        {
                            if (compra.DataOc.Date.CompareTo(inicio.Value.Date) == -1)
                            {
                                continue;
                            }
                        }

                        if (fim.HasValue)
                        {
                            if (compra.DataOc.Date.CompareTo(fim.Value.Date) == 1)
                            {
                                continue;
                            }
                        }

                        double valorUnitarioUnidadeUso = 0;
                        if (compra.Lote.Qtd > 0)
                        {
                            valorUnitarioUnidadeUso = (compra.PrecoUnitario * compra.Lote.QtdCompra) / compra.Lote.Qtd;
                        }
                        else
                        {
                            if (epi.UnidadesPorUnidadeCompra > 0)
                            {
                                valorUnitarioUnidadeUso = compra.PrecoUnitario/epi.UnidadesPorUnidadeCompra;
                            }
                            else
                            {
                                valorUnitarioUnidadeUso = compra.PrecoUnitario;
                            }
                        }

                        
                        toRet.Add(new EvolucaoPrecoCompraReportClass(null, null, epi, compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.DataNf,compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.NumeroNf, compra.Lote.Fornecedor.ToString(), valorUnitarioUnidadeUso, compra.IcmIncluso, compra.IpiNaoIncluso, compra.Lote.Qtd));
                    }
                }


                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de evolução de preços de epis\r\n" + e.Message, e);
            }
        }

        private static List<EvolucaoPrecoCompraReportClass> GerarInterno(List<MaterialClass> materiais, DateTime? inicio, DateTime? fim, SelecaoRelatorio tipoRelatorio, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                List<EvolucaoPrecoCompraReportClass> toRet = new List<EvolucaoPrecoCompraReportClass>();

                if (materiais == null)
                {
                    MaterialClass search = new MaterialClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                    materiais = search.Search(new List<SearchParameterClass>()).ConvertAll(a => (MaterialClass) a).ToList();
                }

                foreach (MaterialClass material in materiais)
                {
                    switch (tipoRelatorio)
                    {
                        case SelecaoRelatorio.SomenteA:
                            if (material.sugestaoKB.ClassificacaoABC != "A")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.SomenteB:
                            if (material.sugestaoKB.ClassificacaoABC != "B")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.SomenteC:
                            if (material.sugestaoKB.ClassificacaoABC != "C")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.Todos:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("tipoRelatorio");
                    }


                    foreach (HistoricoCompraMaterialClass compra in material.CollectionHistoricoCompraMaterialClassMaterial.Where(a => a.Lote != null).OrderBy(a => a.NotaFiscalEntradaLinha.NotaFiscalEntrada.DataNf))
                    {
                        if (inicio.HasValue)
                        {
                            if (compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.DataNf.CompareTo(inicio.Value.Date) == -1)
                            {
                                continue;
                            }
                        }

                        if (fim.HasValue)
                        {
                            if (compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.DataNf.CompareTo(fim.Value.Date) == 1)
                            {
                                continue;
                            }
                        }

                        if (compra.Lote.Qtd== 0 && compra.Lote.QtdCompra!=0)
                        {
                            compra.Lote.Qtd = compra.Lote.QtdCompra;
                        }
                        double valorUnitarioUnidadeUso = (compra.PrecoUnitario*compra.Lote.QtdCompra)/compra.Lote.Qtd;
                        toRet.Add(new EvolucaoPrecoCompraReportClass(null, material, null, compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.DataNf, compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.NumeroNf, compra.Lote.Fornecedor.ToString(), valorUnitarioUnidadeUso, compra.IcmIncluso, compra.IpiNaoIncluso, compra.Lote.Qtd));
                    }
                }


                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de evolução de preços de materiais\r\n" + e.Message, e);
            }
        }


        private static List<EvolucaoPrecoCompraReportClass> GerarInterno(List<ProdutoClass> produtos, DateTime? inicio, DateTime? fim, SelecaoRelatorio tipoRelatorio, IWTPostgreNpgsqlConnection singleConnection)
        {
            try
            {
                List<EvolucaoPrecoCompraReportClass> toRet = new List<EvolucaoPrecoCompraReportClass>();

                if (produtos == null)
                {
                    ProdutoClass search = new ProdutoClass(LoginClass.UsuarioLogado.loggedUser, singleConnection);
                    produtos = search.Search(new List<SearchParameterClass>()
                                                 {
                                                     new SearchParameterClass("TipoAquisicao", TipoAquisicao.Comprado)
                                                 }).ConvertAll(a => (ProdutoClass) a).ToList();
                }



                foreach (ProdutoClass produto in produtos)
                {

                    switch (tipoRelatorio)
                    {
                        case SelecaoRelatorio.SomenteA:
                            if (produto.sugestaoKB.ClassificacaoABC != "A")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.SomenteB:
                            if (produto.sugestaoKB.ClassificacaoABC != "B")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.SomenteC:
                            if (produto.sugestaoKB.ClassificacaoABC != "C")
                            {
                                continue;
                            }
                            break;
                        case SelecaoRelatorio.Todos:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("tipoRelatorio");
                    }
                    foreach (HistoricoCompraProdutoClass compra in produto.CollectionHistoricoCompraProdutoClassProduto.Where(a => a.Lote != null).OrderBy(a => a.DataOc))
                    {
                        if (inicio.HasValue)
                        {
                            if (compra.DataOc.Date.CompareTo(inicio.Value.Date) == -1)
                            {
                                continue;
                            }
                        }

                        if (fim.HasValue)
                        {
                            if (compra.DataOc.Date.CompareTo(fim.Value.Date) == 1)
                            {
                                continue;
                            }
                        }

                        double valorUnitarioUnidadeUso = (compra.PrecoUnitario*compra.Lote.QtdCompra)/compra.Lote.Qtd;
                        toRet.Add(new EvolucaoPrecoCompraReportClass(produto, null, null, compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.DataNf, compra.NotaFiscalEntradaLinha.NotaFiscalEntrada.NumeroNf, compra.Lote.Fornecedor.ToString(), valorUnitarioUnidadeUso, compra.IcmIncluso, compra.IpiNaoIncluso, compra.Lote.Qtd));
                    }
                }


                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de evolução de preços de produto\r\n" + e.Message, e);
            }
        }




    }
}
