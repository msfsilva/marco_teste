using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using IWTDotNetLib.ComplexLoginModule;
using dbProvider;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades.Base;
using IWTPostgreNpgsql;
using NpgsqlTypes;

namespace IWTNF.Entidades.Entidades
{
    public partial class NfPrincipalClass : NfPrincipalBaseClass
    {
        public List<NfPrincipalClass> getNotasPendentesEnvioReceita(bool homologacao, string modelo, string cnpjTransmissor)
        {
            return this.Search(new List<SearchParameterClass>()
                                   {
                                       new SearchParameterClass("EnviarNfeReceita",true),
                                       new SearchParameterClass("Homologacao", homologacao),
                                       new SearchParameterClass("ModeloDocFiscalExato", modelo),
                                       new SearchParameterClass("CnpjEmitente",cnpjTransmissor)
                                   }).ConvertAll(a => (NfPrincipalClass) a);
        }


        public List<NfPrincipalClass> getNotasPendentesEnvioFazendaLondrina( bool homologacao)
        {
            return this.Search(new List<SearchParameterClass>()
                                   {
                                       new SearchParameterClass("EnviarNfseLondrina",true),
                                       new SearchParameterClass("Homologacao", homologacao),
                                       new SearchParameterClass("ModeloDocFiscalExato", "SL")

                                   }).ConvertAll(a => (NfPrincipalClass)a);
        }

        public static void calculaNf(ref NfPrincipalClass nf, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection, IObservacaoCustomizada observacaoCustomizada, bool somarValorFreteBcIcms = false, bool somarValorFreteBcIpi = false, bool calcularImpostos = true, bool descontarIcmsBCPis = false, bool descontarIcmsBCCofins = false)
        {
            NfTotaisClass totais = new NfTotaisClass(usuarioAtual, singleConnection);
            totais.NfPrincipal = nf;
            nf.NfTotais = totais;

            List<string> obsDiferimento = new List<string>();
            List<string> obsSimples = new List<string>();
            

            double totalCreditoICMSSimples = 0;

            for (int i = 0; i < nf.CollectionNfItemClassNfPrincipal.Count; i++)
            {
                NfItemClass item = nf.CollectionNfItemClassNfPrincipal[i];

                if (calcularImpostos)
                {
                    item.NfItemTributo = new NfItemTributoClass(usuarioAtual, singleConnection)
                    {
                        NfItem = item
                    };


                    

                    item.NfItemTributo.NfItemTributoIimp = NfPrincipalClass.calculaIimp(item.NfProduto, Arredondar, usuarioAtual, singleConnection);
                    if (item.NfItemTributo.NfItemTributoIimp != null)
                    {
                        item.NfItemTributo.NfItemTributoIimp.NfItem = item;
                    }

                    item.NfItemTributo.NfItemTributoIpi = NfPrincipalClass.calculaIpi(item.NfProduto, Arredondar, usuarioAtual, singleConnection, somarValorFreteBcIpi);
                    if (item.NfItemTributo.NfItemTributoIpi != null)
                    {
                        item.NfItemTributo.NfItemTributoIpi.NfItem = item;
                    }

                    

                    item.NfItemTributo.NfItemTributoIss = NfPrincipalClass.calculaIss(item.NfProduto, Arredondar, usuarioAtual, singleConnection);
                    if (item.NfItemTributo.NfItemTributoIss != null)
                    {
                        item.NfItemTributo.NfItemTributoIss.NfItem = item;
                    }

                    item.NfItemTributo.NfItemTributoIcms = NfPrincipalClass.calculaIcms(item.NfProduto, Arredondar, usuarioAtual, singleConnection, somarValorFreteBcIcms);
                    if (item.NfItemTributo.NfItemTributoIcms != null)
                    {
                        item.NfItemTributo.NfItemTributoIcms.NfItem = item;
                    }

                    item.NfItemTributo.NfItemTributoCofins = NfPrincipalClass.calculaCofins(item.NfProduto, Arredondar, usuarioAtual, singleConnection, descontarIcmsBCCofins, item.NfItemTributo.NfItemTributoIcms, somarValorFreteBcIcms);
                    if (item.NfItemTributo.NfItemTributoCofins != null)
                    {
                        item.NfItemTributo.NfItemTributoCofins.NfItem = item;
                    }

                    item.NfItemTributo.NfItemTributoPis = NfPrincipalClass.calculaPis(item.NfProduto, Arredondar, usuarioAtual, singleConnection, descontarIcmsBCPis, item.NfItemTributo.NfItemTributoIcms, somarValorFreteBcIcms);
                    if (item.NfItemTributo.NfItemTributoPis != null)
                    {
                        item.NfItemTributo.NfItemTributoPis.NfItem = item;
                    }

                }
                //totais

                //ICMS
                if (item.NfItemTributo.NfItemTributoIcms != null)
                {
                    totais.BaseCalculoIcms += item.NfItemTributo.NfItemTributoIcms.ValorBc;
                    totais.BaseCalculoIcmsSt += item.NfItemTributo.NfItemTributoIcms.ValorBcSt;

                    totais.ValorTotalProdutosServicosIcms += Math.Round(item.NfProduto.ValorTotalTributavel, 2, MidpointRounding.ToEven);

                    totais.ValorTotalIcms += item.NfItemTributo.NfItemTributoIcms.ValorIcms;
                    totais.ValorTotalIcmsSt += item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt;

                    totais.ValorTotalIcmsDiferido += item.NfItemTributo.NfItemTributoIcms.IcmsDiferido;
                    

                    if (item.ValorTotalAproximadoTributos.HasValue)
                    {
                        if (!totais.ValorTotalAproximadoTributos.HasValue)
                        {
                            totais.ValorTotalAproximadoTributos = 0;
                        }

                        totais.ValorTotalAproximadoTributos += item.ValorTotalAproximadoTributos.Value;
                    }

                    if (item.NfItemTributo.NfItemTributoIcms.ObsDiferimento != null && item.NfItemTributo.NfItemTributoIcms.ObsDiferimento.Length > 0 && !obsDiferimento.Contains(item.NfItemTributo.NfItemTributoIcms.ObsDiferimento))
                    {
                        obsDiferimento.Add(item.NfItemTributo.NfItemTributoIcms.ObsDiferimento);
                    }

                    if (item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples > 0)
                    {
                        totalCreditoICMSSimples += item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples;
                        obsSimples.Add(item.NfItemTributo.NfItemTributoIcms.ObservacaoCreditoSimples);
                    }

                    totais.ValorTotalIcmsDesonerado += item.NfItemTributo.NfItemTributoIcms.ValorIcmsDesonerado;
                }

                //IPI
                if (item.NfItemTributo.NfItemTributoIpi != null)
                {
                    double teste = Math.Round(item.NfItemTributo.NfItemTributoIpi.ValorIpi, 2, MidpointRounding.AwayFromZero);
                    totais.ValorTotalIpi += teste;
                    totais.ValorTotalIpi = Math.Round(totais.ValorTotalIpi, 2, MidpointRounding.AwayFromZero);
                }

                //ISS
                if (item.NfItemTributo.NfItemTributoIss != null)
                {
                    totais.ValorTotalServicos += item.NfProduto.ValorTotalTributavel;
                    totais.ValorTotalIss += item.NfItemTributo.NfItemTributoIss.ValorIss;
                    totais.BaseCalculoIss += item.NfItemTributo.NfItemTributoIss.Bc;
                }

                //PIS
                if (item.NfItemTributo.NfItemTributoPis != null)
                {
                    if (item.NfItemTributo.NfItemTributoPis.ImpostoRetido == 0)
                    {
                        totais.ValorTotalPis += item.NfItemTributo.NfItemTributoPis.ValorPis;
                    }
                    else
                    {
                        totais.ValorRetidoPis += item.NfItemTributo.NfItemTributoPis.ValorPis;
                    }
                }
                totais.ValorTotalPisServicos += 0;

                //COFINS
                if (item.NfItemTributo.NfItemTributoCofins != null)
                {
                    if (item.NfItemTributo.NfItemTributoCofins.ImpostoRetido == 0)
                    {
                        totais.ValorTotalCofins += item.NfItemTributo.NfItemTributoCofins.ValorCofins;
                    }
                    else
                    {
                        totais.ValorRetidoCofins += item.NfItemTributo.NfItemTributoCofins.ValorCofins;
                    }
                }
                totais.ValorTotalCofinsServicos += 0;

                //IIMP
                if (item.NfItemTributo.NfItemTributoIimp != null)
                {
                    totais.ValorTotalIimp += item.NfItemTributo.NfItemTributoIimp.ValorIimp;
                }


                totais.ValorTotalDesconto += item.NfProduto.ValorDesconto;
                totais.OutrasDespesas += item.NfProduto.OutrasDespesasAcessorias;
                totais.ValorTotalDescontoIi += 0;
                totais.ValorTotalFrete += item.NfProduto.ValorFrete;
                totais.ValorTotalSeguro += item.NfProduto.ValorSeguro;

            }
            totais.ValorTotalNf +=
                totais.ValorTotalProdutosServicosIcms
                - totais.ValorTotalDesconto
                - totais.ValorTotalIcmsDesonerado
                + totais.ValorTotalIcmsSt
                + totais.ValorTotalFrete
                + totais.ValorTotalSeguro
                + totais.OutrasDespesas
                + totais.ValorTotalIimp
                + totais.ValorTotalIpi
                + (totais.ValorTotalServicos.HasValue ? totais.ValorTotalServicos.Value : 0);


            if (totais.ValorTotalIcmsDiferido > 0)
            {

                if (obsDiferimento.Count > 0)
                {
                    foreach (string obs in obsDiferimento)
                    {
                        nf.Observacoes += " " + obs + " ";
                    }
                }

                nf.Observacoes += "ICMS Diferido: " + totais.ValorTotalIcmsDiferido.ToString("C2", CultureInfo.CurrentCulture);

            }


           


            //Montagem da observação do Fisco

            if (nf.NfEmitente.Crt == 1 || nf.NfEmitente.Crt == 2)
            {

                if (observacaoCustomizada == null)
                {

                    if (totalCreditoICMSSimples > 0)
                    {
                        nf.ObservacoesFisco += " DOCUMENTO EMITIDO POR ME OU EPP OPTANTE PELO SIMPLES NACIONAL NÃO GERA DIREITO A CREDITO FISCAL DE IPI. ";

                        if (obsSimples.Count > 0)
                        {

                            nf.ObservacoesFisco += "Valor do Crédito de ICMS permitido: " + totalCreditoICMSSimples.ToString("C2", CultureInfo.CurrentCulture) + " ";

                            obsSimples = obsSimples.Distinct().ToList();

                            foreach (string obs in obsSimples)
                            {
                                nf.ObservacoesFisco += " " + obs + " ";
                            }
                        }
                        
                    }
                    else
                    {
                        nf.ObservacoesFisco += " DOCUMENTO EMITIDO POR ME OU EPP OPTANTE PELO SIMPLES NACIONAL NÃO GERA DIREITO A CREDITO FISCAL DE ICMS e IPI. ";
                    }
                }
                else
                {
                    nf.ObservacoesFisco += observacaoCustomizada.GetObservacaoCreditoSimples(nf);
                }
                

            }

            foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal.Where(a => a.NfItemTributo.NfItemTributoIcms != null && a.NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente != 0))
            {
                nf.ObservacoesFisco += "CODIGO " + item.NfProduto.Codigo + " VL BC DO ICMSST R$ " + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")) + " VL ICMSST R$ " + item.NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")) + " ";
            }


            if (totais.ValorTotalIcmsDesonerado > 0)
            {
                nf.Observacoes += "Valor de ICMS Desonerado: " + totais.ValorTotalIcmsDesonerado.ToString("C2", CultureInfo.CurrentCulture) + " ";
            }
            
        }


        /// <summary>
        /// Calcula o IBS (Grupo UB)
        /// Padrão baseado em 'calculaPis'
        /// </summary>
        public static NfTributoIbsClass calculaIBS(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            // Acessa a entidade de "produto" (origem)
            if (nfProduto.NfProdutoIbs != null)
            {
                try
                {
                    // Validação "Fail-Fast"
                    if (string.IsNullOrEmpty(nfProduto.NfProdutoIbs.CstIbs))
                    {
                        throw new Exception(string.Format(
                            "Erro de cálculo (calculaIBS): O item Produto={0} possui 'nf_produto_ibs' informada, mas o campo obrigatório (CstIbs) está nulo.",
                            nfProduto.Codigo
                        ));
                    }

                    // Cria a entidade de "tributo" (calculado)
                    NfTributoIbsClass toRet = new NfTributoIbsClass(usuarioAtual, singleConnection);

                    // Copia campos de origem (parâmetros do client)
                    toRet.CstIbs = nfProduto.NfProdutoIbs.CstIbs;
                    toRet.VBcIbsCred = nfProduto.NfProdutoIbs.VBcIbsCred.GetValueOrDefault(0);
                    toRet.PIbsCred = nfProduto.NfProdutoIbs.PIbsCred.GetValueOrDefault(0);
                    toRet.VIbsDif = nfProduto.NfProdutoIbs.VIbsDif.GetValueOrDefault(0);
                    toRet.VIbsDev = nfProduto.NfProdutoIbs.VIbsDev.GetValueOrDefault(0);
                    // (O flag CompoeTotal está na 'produto', não é copiado para 'tributo')

                    // Regra UB04-10 (inferida): vIBS = vBC * (pIBS / 100)
                    if (nfProduto.NfProdutoIbs.VBaseCalcIbs != null && nfProduto.NfProdutoIbs.PIbs != null)
                    {
                        toRet.VBcIbs = nfProduto.NfProdutoIbs.VBaseCalcIbs;
                        toRet.PIbs = nfProduto.NfProdutoIbs.PIbs;
                        toRet.VIbs = arredondaValor(
                            (toRet.VBcIbs.Value * (toRet.PIbs.Value / 100)), Arredondar, 2
                        );
                    }

                    // Regra UB06-10 (inferida): vIBSRet = vBCRet * (pIBSRet / 100)
                    if (nfProduto.NfProdutoIbs.VBaseCalcIbsRet != null && nfProduto.NfProdutoIbs.PIbsRet != null)
                    {
                        toRet.VBcIbsRet = nfProduto.NfProdutoIbs.VBaseCalcIbsRet;
                        // (Nota: DDL não previu PIbsRet na tabela de tributo, apenas na produto)
                        toRet.VIbsRet = arredondaValor(
                            (toRet.VBcIbsRet.Value * (nfProduto.NfProdutoIbs.PIbsRet.Value / 100)), Arredondar, 2
                        );
                    }

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao Calcular o IBS do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calcula o CBS (Grupo UB)
        /// Padrão baseado em 'calculaPis'
        /// </summary>
        public static NfTributoCbsClass calculaCBS(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            if (nfProduto.NfProdutoCbs != null)
            {
                try
                {
                    // Validação "Fail-Fast"
                    if (string.IsNullOrEmpty(nfProduto.NfProdutoCbs.CstCbs))
                    {
                        throw new Exception(string.Format(
                            "Erro de cálculo (calculaCBS): O item Produto={0} possui 'nf_produto_cbs' informada, mas o campo obrigatório (CstCbs) está nulo.",
                            nfProduto.Codigo
                        ));
                    }

                    NfTributoCbsClass toRet = new NfTributoCbsClass(usuarioAtual, singleConnection);

                    // Copia campos de origem
                    // O campo 'Orig' NÃO existe neste grupo, conforme NT 2025.002
                    toRet.CstCbs = nfProduto.NfProdutoCbs.CstCbs;
                    toRet.VBcCbsCred = nfProduto.NfProdutoCbs.VBcCbsCred.GetValueOrDefault(0);
                    toRet.PCbsCred = nfProduto.NfProdutoCbs.PCbsCred.GetValueOrDefault(0);
                    toRet.VCbsDif = nfProduto.NfProdutoCbs.VCbsDif.GetValueOrDefault(0);
                    toRet.VCbsDev = nfProduto.NfProdutoCbs.VCbsDev.GetValueOrDefault(0);

                    // Regra UB14-10 (inferida): vCBS = vBC * (pCBS / 100)
                    if (nfProduto.NfProdutoCbs.VBaseCalcCbs != null && nfProduto.NfProdutoCbs.PCbs != null)
                    {
                        toRet.VBcCbs = nfProduto.NfProdutoCbs.VBaseCalcCbs;
                        toRet.PCbs = nfProduto.NfProdutoCbs.PCbs;
                        toRet.VCbs = arredondaValor(
                            (toRet.VBcCbs.Value * (toRet.PCbs.Value / 100)), Arredondar, 2
                        );
                    }

                    // Regra UB16-10 (inferida): vCBSRet = vBCRet * (pCBSRet / 100)
                    if (nfProduto.NfProdutoCbs.VBaseCalcCbsRet != null && nfProduto.NfProdutoCbs.PCbsRet != null)
                    {
                        toRet.VBcCbsRet = nfProduto.NfProdutoCbs.VBaseCalcCbsRet;
                        // (Nota: DDL não previu PCbsRet na tabela de tributo, apenas na produto)
                        toRet.VCbsRet = arredondaValor(
                            (toRet.VBcCbsRet.Value * (nfProduto.NfProdutoCbs.PCbsRet.Value / 100)), Arredondar, 2
                        );
                    }

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao Calcular o CBS do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calcula o IS (Grupo UC)
        /// Padrão baseado em 'calculaPis'
        /// </summary>
        public static NfTributoIsClass calculaIS(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            if (nfProduto.NfProdutoIs != null)
            {
                try
                {
                    // Validação "Fail-Fast"
                    if (string.IsNullOrEmpty(nfProduto.NfProdutoIs.CstIs))
                    {
                        throw new Exception(string.Format(
                            "Erro de cálculo (calculaIS): O item Produto={0} possui 'nf_produto_is' informada, mas o campo obrigatório (CstIs) está nulo.",
                            nfProduto.Codigo
                        ));
                    }

                    NfTributoIsClass toRet = new NfTributoIsClass(usuarioAtual, singleConnection);

                    // Copia campos de origem
                    // O campo 'Orig' NÃO existe neste grupo, conforme NT 2025.002
                    toRet.CstIs = nfProduto.NfProdutoIs.CstIs;
                    toRet.IndSomIs = nfProduto.NfProdutoIs.IndSomIs; // Importante para totais
                    toRet.VIsDev = nfProduto.NfProdutoIs.VIsDev.GetValueOrDefault(0);

                    // Regra UC11-10 (inferida): vIS = vBCIS * (pIS / 100)
                    if (nfProduto.NfProdutoIs.VBaseCalcIs != null && nfProduto.NfProdutoIs.PIs != null)
                    {
                        toRet.VBcIs = nfProduto.NfProdutoIs.VBaseCalcIs;
                        toRet.PIs = nfProduto.NfProdutoIs.PIs;
                        toRet.VIs = arredondaValor(
                            (toRet.VBcIs.Value * (toRet.PIs.Value / 100)), Arredondar, 2
                        );
                    }

                    // Regra UC13-10 (inferida): vISRet = vBCISRet * (pISRet / 100)
                    if (nfProduto.NfProdutoIs.VBaseCalcIsRet != null && nfProduto.NfProdutoIs.PIsRet != null)
                    {
                        toRet.VBcIsRet = nfProduto.NfProdutoIs.VBaseCalcIsRet;
                        // (Nota: DDL não previu PIsRet na tabela de tributo, apenas na produto)
                        toRet.VIsRet = arredondaValor(
                            (toRet.VBcIsRet.Value * (nfProduto.NfProdutoIs.PIsRet.Value / 100)), Arredondar, 2
                        );
                    }

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao Calcular o IS do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Calcula o Imposto Devolvido (Grupo UA)
        /// Padrão baseado em 'calculaPis'
        /// </summary>
        public static NfTributoDevolucaoClass calculaDevolucao(NfProdutoClass nfProduto, NfItemTributoIcmsClass nfItemTributoIcms, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            // Propriedade 'PDev' da tabela 'nf_produto_devolucao'
            if (nfProduto.NfProdutoDevolucao != null && nfProduto.NfProdutoDevolucao.PDev != null && nfProduto.NfProdutoDevolucao.PDev > 0)
            {
                try
                {
                    // Validação "Fail-Fast"
                    // Usa a propriedade 'Vprod' (sem prefixo), baseado no seu exemplo 'calculaPis' que usa 'QuantidadeTributavel'
                    // E na análise de 'NfProdutoBaseClass.cs'
                    if (nfProduto.Vprod == null || nfProduto.Vprod <= 0)
                    {
                        throw new Exception(string.Format(
                            "Erro de cálculo (calculaDevolucao): O item Produto={0} possui 'nf_produto_devolucao' com pDev > 0, mas o vProd (Vprod) do item é nulo ou zero, impedindo o cálculo do vIPIDev.",
                            nfProduto.Codigo
                        ));
                    }

                    NfTributoDevolucaoClass toRet = new NfTributoDevolucaoClass(usuarioAtual, singleConnection);

                    double pDev = nfProduto.NfProdutoDevolucao.PDev.Value / 100;

                    // Regra UA02-10: vIPIDev = vProd * pDev
                    // Usando nfProduto.Vprod
                    toRet.VIpiDev = arredondaValor(nfProduto.Vprod.Value * pDev, Arredondar, 2);

                    // Regras UA03-10 e UA04-10 (inferência)
                    // A NT é ambígua, assumindo vBC * pDev
                    // Propriedade 'Vbcicms' da 'NfItemTributoIcmsClass' (assumindo sem prefixo)
                    if (nfItemTributoIcms != null && nfItemTributoIcms.Vbcicms != null && nfItemTributoIcms.Vbcicms > 0)
                    {
                        toRet.VBcIcmsDev = nfItemTributoIcms.Vbcicms; // Base original
                        toRet.VIcmsDev = arredondaValor(nfItemTributoIcms.Vbcicms.Value * pDev, Arredondar, 2);
                    }

                    // TODO: Validar regras de cálculo para ICMS-ST (Vbcst), PIS (ValorBc) e COFINS (ValorBc) devolvidos.

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao Calcular a Devolução de Imposto (UA) do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }



        public static NfItemTributoIssClass calculaIss(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
        {
            if (nfProduto.NfProdutoIss != null)
            {
                try
                {
                    NfItemTributoIssClass toRet = new NfItemTributoIssClass(usuarioAtual, singleConnection);
                    toRet.Aliquota = nfProduto.NfProdutoIss.Aliquota;
                    toRet.Bc = nfProduto.ValorTotalTributavel;
                    toRet.CodigoServico = nfProduto.NfProdutoIss.CodigoServico;
                    toRet.CodMunicipioFatoGerador = nfProduto.NfProdutoIss.CodMunicipioFatoGerador;
                    toRet.ValorIss = arredondaValor(toRet.Aliquota/100*toRet.Bc, Arredondar, 2);

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao calcular o ISS do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public static NfItemTributoPisClass calculaPis(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection, bool descontarIcmsBcPis = false, NfItemTributoIcmsClass nfItemTributoIcms = null, bool somarValorFreteBcIcms = false)
        {
            if (nfProduto.NfProdutoPis != null)
            {
                try
                {
                    double bcPisValor = nfProduto.ValorTotalTributavel;
                    if (nfItemTributoIcms != null && descontarIcmsBcPis)
                    {
                        bcPisValor = Math.Round(bcPisValor - nfItemTributoIcms.ValorIcms, 4, MidpointRounding.ToEven);
                        if (bcPisValor < 0) bcPisValor = 0;
                    }

                    if (somarValorFreteBcIcms)
                    {
                        bcPisValor = bcPisValor + nfProduto.ValorFrete;
                    }

                    NfItemTributoPisClass toRet = new NfItemTributoPisClass(usuarioAtual, singleConnection);
                    toRet.Cst = nfProduto.NfProdutoPis.Cst;
                    toRet.ImpostoRetido = nfProduto.NfProdutoPis.ImpostoRetido;
                    toRet.ModalidadeTributacao = nfProduto.NfProdutoPis.ModadlidadeTributacao;
                    switch (nfProduto.NfProdutoPis.Cst)
                    {
                        case "01":
                        case "02":
                            switch (nfProduto.NfProdutoPis.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:
                                    throw new Exception("CST Inválido para item não tributável");
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    throw new Exception("CST Inválido para item tributável por Quantidade");
                                    break;
                                case ModalidadeTributacao.Valor:
                                    toRet.ValorBc = bcPisValor;
                                    toRet.Aliquota = nfProduto.NfProdutoPis.Aliquota;
                                    toRet.ValorPis = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        case "03":
                            switch (nfProduto.NfProdutoPis.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:
                                    throw new Exception("CST Inválido para item não tributável");
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet.QuantidadeVendida = nfProduto.QuantidadeTributavel;
                                    toRet.Aliquota = nfProduto.NfProdutoPis.Aliquota;
                                    toRet.ValorPis = arredondaValor(toRet.Aliquota * toRet.QuantidadeVendida, Arredondar, 2);
                                    break;
                                case ModalidadeTributacao.Valor:
                                    throw new Exception("CST Inválido para item tributável por Valor");
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            switch (nfProduto.NfProdutoPis.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:

                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    throw new Exception("CST Inválido para item tributável por Quantidade");
                                    break;
                                case ModalidadeTributacao.Valor:
                                    throw new Exception("CST Inválido para item tributável por Valor");
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        case "49":
                        case "99":
                            switch (nfProduto.NfProdutoPis.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:

                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet.QuantidadeVendida = nfProduto.QuantidadeTributavel;
                                    toRet.Aliquota = nfProduto.NfProdutoPis.Aliquota;
                                    toRet.ValorPis = arredondaValor(toRet.Aliquota * toRet.QuantidadeVendida, Arredondar, 2);
                                    break;
                                case ModalidadeTributacao.Valor:
                                    toRet.ValorBc = bcPisValor;
                                    toRet.Aliquota = nfProduto.NfProdutoPis.Aliquota;
                                    toRet.ValorPis = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        default:
                            throw new Exception("CST Inválido");
                            break;
                    }

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao Calcular o Pis do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }

        }

        public static NfItemTributoIpiClass calculaIpi(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection, bool somarValorFreteBcIpi = false)
        {
            if (nfProduto.NfProdutoIpi != null)
            {
                try
                {
                    NfItemTributoIpiClass toRet = new NfItemTributoIpiClass(usuarioAtual, singleConnection);
                    toRet.Cst = nfProduto.NfProdutoIpi.Cst;
                    toRet.ModalidadeTributacao = nfProduto.NfProdutoIpi.ModalidadeTributacao;
                    toRet.ClasseEnquadramento = nfProduto.NfProdutoIpi.ClasseEnquadramento;
                    toRet.ClasseEnquadramentoCigarrosBebidas = nfProduto.NfProdutoIpi.ClasseEnquadramentoCigarrosBebidas;
                    toRet.CnpjProdutor = nfProduto.NfProdutoIpi.CnpjProdutor;
                    toRet.CodigoSeloControle = "";
                    toRet.QuantidadeSeloControle = 0;
                    toRet.ModalidadeTributacao = nfProduto.NfProdutoIpi.ModalidadeTributacao;


                    switch (nfProduto.NfProdutoIpi.Cst)
                    {
                        case "00":
                        case "49":
                        case "50":
                        case "99":
                            switch (nfProduto.NfProdutoIpi.ModalidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:
                                    throw new Exception("CST Inválido para item não tributável");
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet.QuantidadeVendida = nfProduto.QuantidadeTributavel;
                                    toRet.Aliquota = nfProduto.NfProdutoIpi.Aliquota;
                                    toRet.ValorIpi = arredondaValor(toRet.Aliquota * toRet.QuantidadeVendida, Arredondar, 2);
                                    break;
                                case ModalidadeTributacao.Valor:
                                    toRet.ValorBc = nfProduto.ValorTotalTributavel;
                                    if (somarValorFreteBcIpi)
                                    {
                                        toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                                    }
                                    toRet.Aliquota = nfProduto.NfProdutoIpi.Aliquota;
                                    toRet.ValorIpi = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        case "01":
                        case "02":
                        case "03":
                        case "04":
                        case "05":
                        case "51":
                        case "52":
                        case "53":
                        case "54":
                        case "55":
                            switch (nfProduto.NfProdutoIpi.ModalidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:

                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    throw new Exception("CST Inválido para item tributável por Quantidade");
                                    break;
                                case ModalidadeTributacao.Valor:
                                    throw new Exception("CST Inválido para item tributável por Valor");
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        default:
                            throw new Exception("CST Inválido");
                            break;
                    }

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao Calcular o Ipi do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public static NfItemTributoIimpClass calculaIimp(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            if (nfProduto.NfProdutoIimp != null)
            {
                try
                {
                    NfItemTributoIimpClass toRet = new NfItemTributoIimpClass(usuarioAtual,singleConnection);
                    toRet.ValorDespesasAduaneiras = nfProduto.NfProdutoIimp.ValorDespesasAduaneiras;
                    toRet.ValorIof = nfProduto.NfProdutoIimp.ValorIof;
                    switch (nfProduto.NfProdutoIimp.ModalidadeTributacao)
                    {
                        case ModalidadeTributacao.NaoTributado:
                            return null;
                            break;
                        case ModalidadeTributacao.Quantidade:
                            toRet.QuantidadeVendida = nfProduto.QuantidadeTributavel;
                            toRet.Aliquota = nfProduto.NfProdutoIimp.Aliquota;
                            toRet.ValorIimp = arredondaValor(toRet.Aliquota * toRet.QuantidadeVendida, Arredondar, 2);
                            break;
                        case ModalidadeTributacao.Valor:
                            toRet.ValorBc = nfProduto.ValorTotalTributavel;
                            toRet.Aliquota = nfProduto.NfProdutoIimp.Aliquota;
                            toRet.ValorIimp = arredondaValor(toRet.Aliquota / 100 * toRet.QuantidadeVendida, Arredondar, 2);
                            break;
                        default:
                            throw new Exception("Modalidade de Tributação Inválida");
                            break;

                    }

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao calcular o II do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public static NfItemTributoCofinsClass calculaCofins(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection, bool descontarIcmsBcCofins = false, NfItemTributoIcmsClass nfItemTributoIcms = null, bool somarValorFreteBcIcms = false)
        {
            if (nfProduto.NfProdutoCofins != null)
            {
                try
                {
                    double bcCofinsValor = nfProduto.ValorTotalTributavel;
                    if (nfItemTributoIcms != null && descontarIcmsBcCofins)
                    {
                        bcCofinsValor = Math.Round(bcCofinsValor - nfItemTributoIcms.ValorIcms, 4, MidpointRounding.ToEven);
                        if (bcCofinsValor < 0) bcCofinsValor = 0;
                    }

                    if (somarValorFreteBcIcms)
                    {
                        bcCofinsValor = bcCofinsValor + nfProduto.ValorFrete;
                    }

                    NfItemTributoCofinsClass toRet = new NfItemTributoCofinsClass(usuarioAtual, singleConnection);
                    toRet.Cst = nfProduto.NfProdutoCofins.Cst;
                    toRet.ImpostoRetido = nfProduto.NfProdutoCofins.ImpostoRetido;
                    toRet.ModalidadeTributacao = nfProduto.NfProdutoCofins.ModadlidadeTributacao;
                    switch (nfProduto.NfProdutoCofins.Cst)
                    {
                        case "01":
                        case "02":
                            switch (nfProduto.NfProdutoCofins.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:
                                    throw new Exception("CST Inválido para item não tributável");
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    throw new Exception("CST Inválido para item tributável por Quantidade");
                                    break;
                                case ModalidadeTributacao.Valor:
                                    toRet.ValorBc = bcCofinsValor;
                                    toRet.Aliquota = nfProduto.NfProdutoCofins.Aliquota;
                                    toRet.ValorCofins = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        case "03":
                            switch (nfProduto.NfProdutoCofins.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:
                                    throw new Exception("CST Inválido para item não tributável");
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet.QuantidadeVendida = nfProduto.QuantidadeTributavel;
                                    toRet.Aliquota = nfProduto.NfProdutoCofins.Aliquota;
                                    toRet.ValorCofins = arredondaValor(toRet.Aliquota * toRet.QuantidadeVendida, Arredondar, 2);
                                    break;
                                case ModalidadeTributacao.Valor:
                                    throw new Exception("CST Inválido para item tributável por Valor");
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            switch (nfProduto.NfProdutoCofins.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:

                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    throw new Exception("CST Inválido para item tributável por Quantidade");
                                    break;
                                case ModalidadeTributacao.Valor:
                                    throw new Exception("CST Inválido para item tributável por Valor");
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        case "49":
                        case "99":
                            switch (nfProduto.NfProdutoCofins.ModadlidadeTributacao)
                            {
                                case ModalidadeTributacao.NaoTributado:

                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet.QuantidadeVendida = nfProduto.QuantidadeTributavel;
                                    toRet.Aliquota = nfProduto.NfProdutoCofins.Aliquota;
                                    toRet.ValorCofins = arredondaValor(toRet.Aliquota * toRet.QuantidadeVendida, Arredondar, 2);
                                    break;
                                case ModalidadeTributacao.Valor:
                                    toRet.ValorBc = bcCofinsValor;
                                    toRet.Aliquota = nfProduto.NfProdutoCofins.Aliquota;
                                    toRet.ValorCofins = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                                    break;
                                default:
                                    throw new Exception("Modalidade de Tributação Inválida");
                                    break;

                            }
                            break;
                        default:
                            throw new Exception("CST Inválido");
                            break;
                    }

                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao Calcular o Cofins do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }

        }

        public static NfItemTributoIcmsClass calculaIcms(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection, bool somarValorFreteBcIcms = false)
        {
            if (nfProduto.NfProdutoIcms != null)
            {
                try
                {
                    double valorIpi = 0;
                    if (nfProduto.NfItem.NfItemTributo.NfItemTributoIpi != null)
                    {
                        valorIpi = nfProduto.NfItem.NfItemTributo.NfItemTributoIpi.ValorIpi;
                    }

                    double? aliquotaFCP =null;
                    if (nfProduto.NfItem.AlquotaFundoCombatePobreza > 0)
                    {
                        aliquotaFCP = nfProduto.NfItem.AlquotaFundoCombatePobreza;
                    }


                    NfItemTributoIcmsClass toRet = new NfItemTributoIcmsClass(usuarioAtual, singleConnection);



                    toRet.MotivoDesoneracaoIcms = nfProduto.NfProdutoIcms.MotivoDesoneracaoIcms;
                    toRet.CodigoAntecipacaoSt = nfProduto.NfProdutoIcms.CodigoAntecipacaoSt;
                    
                    switch (nfProduto.NfProdutoIcms.Cst)
                    {
                        case "00":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            toRet.ValorBc = nfProduto.ValorTotalTributavel;
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                            }

                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                            toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);

                            if (nfProduto.NfProdutoIcms.AliquotaSt > 0 || nfProduto.NfProdutoIcms.PercentualMvaSt > 0 || nfProduto.NfProdutoIcms.PercentualReducaoBcSt > 0)
                            {
                                throw new Exception("CST 00 não permite a utilização de Substituição Tributária");
                            }

                            if (nfProduto.NfProdutoIcms.PercentualReducaoBc > 0)
                            {
                                throw new Exception("CST 00 não permite a utilização de Redução de Base de Cálculo");
                            }

                            if (aliquotaFCP.HasValue)
                            {
                                toRet.FcpAliquota = aliquotaFCP;
                                toRet.FcpBc = toRet.ValorBc;
                                toRet.FcpValor = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);
                            }
                            
                            break;
                        case "10":

                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            toRet.ValorBc = nfProduto.ValorTotalTributavel;
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                            }

                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                            toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                            toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                            toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                            toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;
                            toRet.PercentualReducaoBcSt = nfProduto.NfProdutoIcms.PercentualReducaoBcSt;
                            toRet.ValorBcSt = arredondaValor(((100 - toRet.PercentualReducaoBcSt) * (toRet.ValorBc + valorIpi) / 100), Arredondar, 2);

                            if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                            {
                                toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                            }


                            toRet.ValorIcmsSt = arredondaValor((((toRet.AliquotaSt * toRet.ValorBcSt) / 100) - toRet.ValorIcms), Arredondar, 2);

                            if (nfProduto.NfProdutoIcms.PercentualReducaoBc > 0)
                            {
                                throw new Exception("CST 10 não permite a utilização de Redução de Base de Cálculo");
                            }

                            if (aliquotaFCP.HasValue)
                            {
                                toRet.FcpAliquota = aliquotaFCP;
                                toRet.FcpBc = toRet.ValorBc;
                                toRet.FcpValor = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);

                                toRet.FcpRetidoAliquota = aliquotaFCP;
                                toRet.FcpRetidoBc = toRet.ValorBcSt;
                                toRet.FcpRetidoValor = arredondaValor((((toRet.FcpRetidoAliquota.Value * toRet.FcpRetidoBc.Value) / 100) - toRet.FcpValor.Value), Arredondar, 2);
                            }

                            break;
                        case "20":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            toRet.PercentualReducaoBc = nfProduto.NfProdutoIcms.PercentualReducaoBc;
                            toRet.ValorBc = arredondaValor((((100 - toRet.PercentualReducaoBc) * (nfProduto.ValorTotalTributavel)) / 100), Arredondar, 2);
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                            }

                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                            toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);

                            if (nfProduto.NfProdutoIcms.AliquotaSt > 0 || nfProduto.NfProdutoIcms.PercentualMvaSt > 0 || nfProduto.NfProdutoIcms.PercentualReducaoBcSt > 0)
                            {
                                throw new Exception("CST 20 não permite a utilização de Substituição Tributária");
                            }

                            if (aliquotaFCP.HasValue)
                            {
                                toRet.FcpAliquota = aliquotaFCP;
                                toRet.FcpBc = toRet.ValorBc;
                                toRet.FcpValor = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);
                            }


                            break;
                        case "30":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                            toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                            toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;
                            toRet.PercentualReducaoBcSt = nfProduto.NfProdutoIcms.PercentualReducaoBcSt;

                       

                            toRet.ValorBcSt = arredondaValor((((100 - toRet.PercentualReducaoBcSt) * (nfProduto.ValorTotalTributavel + valorIpi)) / 100), Arredondar, 2);
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBcSt = toRet.ValorBcSt + nfProduto.ValorFrete;
                            }

                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                            {
                                toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                            }

                            toRet.ValorIcmsSt = arredondaValor(((toRet.AliquotaSt * toRet.ValorBcSt) / 100), Arredondar, 2);

                            if (nfProduto.NfProdutoIcms.Aliquota > 0 || nfProduto.NfProdutoIcms.PercentualReducaoBc > 0 || nfProduto.NfProdutoIcms.Aliquota > 0)
                            {
                                throw new Exception("CST 30 não permite a utilização dos campos de ICMS pois é isento");
                            }


                            if (aliquotaFCP.HasValue)
                            {
                                toRet.FcpRetidoAliquota = aliquotaFCP;
                                toRet.FcpRetidoBc = toRet.ValorBcSt;
                                toRet.FcpRetidoValor = arredondaValor((((toRet.FcpRetidoAliquota.Value * toRet.FcpRetidoBc.Value) / 100)), Arredondar, 2);
                            }

                            break;
                        case "40":
                        case "41":
                        case "50":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;

                            if (!nfProduto.NfProdutoIcms.MotivoDesoneracaoIcms.HasValue)
                            {
                                nfProduto.NfProdutoIcms.AliquotaSt = 0;
                                nfProduto.NfProdutoIcms.PercentualMvaSt = 0;
                                nfProduto.NfProdutoIcms.PercentualReducaoBcSt = 0;
                                nfProduto.NfProdutoIcms.Aliquota = 0;
                                nfProduto.NfProdutoIcms.PercentualReducaoBc = 0;
                            }
                            else
                            {
                                toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                                toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                                toRet.ValorBc = 0;
                                toRet.Aliquota = 0;

                                double tmpBc = nfProduto.ValorTotalTributavel - nfProduto.ValorDesconto;
                                if (somarValorFreteBcIcms)
                                {
                                    tmpBc = tmpBc + nfProduto.ValorFrete;
                                }

                                tmpBc += nfProduto.OutrasDespesasAcessorias;

                                double tmpAliquotaIcms = nfProduto.NfProdutoIcms.Aliquota;
                                toRet.ValorIcmsDesonerado = arredondaValor(tmpAliquotaIcms / 100 * tmpBc, Arredondar, 2);
                            }

                            break;
                        case "51":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            toRet.PercentualReducaoBc = nfProduto.NfProdutoIcms.PercentualReducaoBc;
                            toRet.ValorBc = arredondaValor((((100 - toRet.PercentualReducaoBc) * (nfProduto.ValorTotalTributavel)) / 100), Arredondar, 2);
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                            }

                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                            toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                            if (nfProduto.NfProdutoIcms.AliquotaSt > 0 || nfProduto.NfProdutoIcms.PercentualMvaSt > 0 || nfProduto.NfProdutoIcms.PercentualReducaoBcSt > 0)
                            {
                                throw new Exception("CST 51 não permite a utilização de Substituição Tributária");
                            }

                            if (aliquotaFCP.HasValue)
                            {
                                toRet.FcpAliquota = aliquotaFCP;
                                toRet.FcpBc = toRet.ValorBc;
                                toRet.FcpValor = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);
                            }

                            break;
                        case "60":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                            toRet.ValorBcSt = (nfProduto.ValorTotalTributavel + valorIpi);
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBcSt = toRet.ValorBcSt + nfProduto.ValorFrete;
                            }

                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                            {
                                toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                            }
                            toRet.ValorIcmsSt = arredondaValor(toRet.AliquotaSt / 100 * toRet.ValorBcSt, Arredondar, 2);

                            if (nfProduto.NfProdutoIcms.Aliquota > 0 || nfProduto.NfProdutoIcms.PercentualReducaoBc > 0 || nfProduto.NfProdutoIcms.Aliquota > 0)
                            {
                                throw new Exception("CST 60 não permite a utilização dos campos de ICMS");
                            }

                            if (nfProduto.NfProdutoIcms.FcpRetidoAliquota.HasValue)
                            {
                                toRet.FcpRetidoAliquota = nfProduto.NfProdutoIcms.FcpRetidoAliquota;
                                toRet.FcpRetidoBc = nfProduto.NfProdutoIcms.FcpRetidoBc;
                                toRet.FcpRetidoValor = nfProduto.NfProdutoIcms.FcpRetidoValor;
                            }

                            break;
                        case "70":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            toRet.PercentualReducaoBc = nfProduto.NfProdutoIcms.PercentualReducaoBc;
                            toRet.ValorBc = arredondaValor((((100 - toRet.PercentualReducaoBc) * (nfProduto.ValorTotalTributavel)) / 100), Arredondar, 2);
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                            }

                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                            toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                            toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                            toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                            toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;
                            toRet.PercentualReducaoBcSt = nfProduto.NfProdutoIcms.PercentualReducaoBcSt;
                            toRet.ValorBcSt = arredondaValor((((100 - toRet.PercentualReducaoBcSt) * (toRet.ValorBc + valorIpi)) / 100), Arredondar, 2);
                            if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                            {
                                toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                            }
                            toRet.ValorIcmsSt = arredondaValor(((toRet.AliquotaSt * toRet.ValorBcSt) / 100) - toRet.ValorIcms, Arredondar, 2);


                            if (aliquotaFCP.HasValue)
                            {
                                toRet.FcpAliquota = aliquotaFCP;
                                toRet.FcpBc = toRet.ValorBc;
                                toRet.FcpValor = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);

                                toRet.FcpRetidoAliquota = aliquotaFCP;
                                toRet.FcpRetidoBc = toRet.ValorBcSt;
                                toRet.FcpRetidoValor = arredondaValor((((toRet.FcpRetidoAliquota.Value * toRet.FcpRetidoBc.Value) / 100) - toRet.FcpValor.Value), Arredondar, 2);
                            }

                            break;
                        case "90":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            toRet.PercentualReducaoBc = nfProduto.NfProdutoIcms.PercentualReducaoBc;
                            toRet.ValorBc = arredondaValor((((100 - toRet.PercentualReducaoBc) * (nfProduto.ValorTotalTributavel)) / 100), Arredondar, 2);
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                            }
                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                            toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                            toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                            toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                            toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;
                            toRet.PercentualReducaoBcSt = nfProduto.NfProdutoIcms.PercentualReducaoBcSt;
                            if (Math.Abs(toRet.AliquotaSt) > 0.00001 || Math.Abs(toRet.PercentualMvaSt) > 0.00001 || Math.Abs(toRet.PercentualReducaoBcSt) > 0.00001)
                            {
                                toRet.ValorBcSt = arredondaValor((((100 - toRet.PercentualReducaoBcSt) * (toRet.ValorBc + valorIpi)) / 100), Arredondar, 2);
                                if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                                {
                                    toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                                }
                                toRet.ValorIcmsSt = arredondaValor((((toRet.AliquotaSt * toRet.ValorBcSt) / 100) - toRet.ValorIcms), Arredondar, 2);
                            }
                            else
                            {
                                toRet.ValorBcSt = 0;
                                toRet.ValorIcmsSt = 0;
                            }


                            if (aliquotaFCP.HasValue)
                            {
                                toRet.FcpAliquota = aliquotaFCP;
                                toRet.FcpBc = toRet.ValorBc;
                                toRet.FcpValor = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);

                                if (Math.Abs(toRet.ValorBcSt) > 0.00001)
                                {
                                    toRet.FcpRetidoAliquota = aliquotaFCP;
                                    toRet.FcpRetidoBc = toRet.ValorBcSt;
                                    toRet.FcpRetidoValor = arredondaValor((((toRet.FcpRetidoAliquota.Value * toRet.FcpRetidoBc.Value) / 100) - toRet.FcpValor.Value), Arredondar, 2);
                                }
                            }

                            break;
                        case "10a":
                        case "90a":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                            toRet.PercentualReducaoBc = nfProduto.NfProdutoIcms.PercentualReducaoBc;
                            toRet.ValorBc = arredondaValor((((100 - toRet.PercentualReducaoBc) * (nfProduto.ValorTotalTributavel)) / 100), Arredondar, 2);
                            if (somarValorFreteBcIcms)
                            {
                                toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                            }
                            toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                            toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                            toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                            toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                            toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                            toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;
                            toRet.PercentualReducaoBcSt = nfProduto.NfProdutoIcms.PercentualReducaoBcSt;
                            toRet.ValorBcSt = arredondaValor((((100 - toRet.PercentualReducaoBcSt) * (toRet.ValorBc + valorIpi)) / 100), Arredondar, 2);

                            if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                            {
                                toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                            }


                            toRet.ValorIcmsSt = arredondaValor((((toRet.AliquotaSt * toRet.ValorBcSt) / 100) - toRet.ValorIcms), Arredondar, 2);
                            toRet.PercentualBcOperacaoPropria = nfProduto.NfProdutoIcms.PercentualBcOperacaoPropria;
                            toRet.SiglaUfDevidoIcms = nfProduto.NfProdutoIcms.SiglaUfDevidoIcms;

                            if (toRet.PercentualBcOperacaoPropria == 0)
                            {
                                throw new Exception("O campo de percentual da base de cálculo para operção própria deve ser maior do que zero.");
                            }

                            if (toRet.SiglaUfDevidoIcms.Length != 2)
                            {
                                throw new Exception("A sigla do estado onde é devido o icms é inválida.");
                            }


                            break;
                        case "41a":
                        case "60a":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            toRet.ValorBcStRetidoRemetente = nfProduto.NfProdutoIcms.ValorBcStRetidoRemetente;
                            toRet.ValorIcmsStRetidoRemetente = nfProduto.NfProdutoIcms.ValorIcmsStRetidoRemetente;
                            toRet.ValorBcStRetidoDestinatario = nfProduto.NfProdutoIcms.ValorBcStRetidoDestinatario;
                            toRet.ValorIcmsStRetidoDestinatario = nfProduto.NfProdutoIcms.ValorIcmsStRetidoDestinatario;
                            if (nfProduto.NfProdutoIcms.AliquotaSt > 0 || nfProduto.NfProdutoIcms.PercentualMvaSt > 0 || nfProduto.NfProdutoIcms.PercentualReducaoBcSt > 0)
                            {
                                throw new Exception("CST 40, 41 e 50 não permitem a utilização dos campos de ICMS ST pois são isentos");
                            }
                            if (nfProduto.NfProdutoIcms.Aliquota > 0 || nfProduto.NfProdutoIcms.PercentualReducaoBc > 0 || nfProduto.NfProdutoIcms.Aliquota > 0)
                            {
                                throw new Exception("CST 40, 41 e 50 não permitem a utilização dos campos de ICMS pois são isentos");
                            }
                            break;

                        case "SN":
                            toRet.Origem = nfProduto.NfProdutoIcms.Origem;
                            toRet.Cst = nfProduto.NfProdutoIcms.Cst;
                            if (nfProduto.NfItem.NfPrincipal == null || nfProduto.NfItem.NfPrincipal.NfEmitente.Crt == 1)
                            {
                                toRet.CsoSimples = nfProduto.NfProdutoIcms.CsoSimples;
                                switch (nfProduto.NfProdutoIcms.CsoSimples)
                                {

                                    case 101:
                                        toRet.AliquotaCreditoSimples = nfProduto.NfProdutoIcms.AliquotaCreditoSimples;
                                        toRet.ValorCreditoIcmsSimples = arredondaValor(((toRet.AliquotaCreditoSimples * nfProduto.ValorTotalTributavel) / 100), Arredondar, 2);
                                        break;
                                    case 102:
                                    case 103:
                                    case 300:
                                    case 400:
                                        break;
                                    case 201:

                                        toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                                        toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                                        toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;
                                        toRet.PercentualReducaoBcSt = nfProduto.NfProdutoIcms.PercentualReducaoBcSt;
                                        toRet.ValorBcSt = arredondaValor((((100 - toRet.PercentualReducaoBcSt) * (nfProduto.ValorTotalTributavel + valorIpi)) / 100), Arredondar, 2);
                                        if (somarValorFreteBcIcms)
                                        {
                                            toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                                        }
                                        toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                                        if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                                        {
                                            toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                                        }


                                        toRet.ValorIcmsSt = arredondaValor((((toRet.AliquotaSt * toRet.ValorBcSt) / 100) - toRet.ValorIcms), Arredondar, 2);

                                        toRet.AliquotaCreditoSimples = nfProduto.NfProdutoIcms.AliquotaCreditoSimples;
                                        toRet.ValorCreditoIcmsSimples = arredondaValor(((toRet.AliquotaCreditoSimples * nfProduto.ValorTotalTributavel) / 100), Arredondar, 2);

                                        if (aliquotaFCP.HasValue)
                                        {
                                            toRet.FcpRetidoAliquota = aliquotaFCP;
                                            toRet.FcpRetidoBc = toRet.ValorBcSt;
                                            toRet.FcpRetidoValor = arredondaValor((((toRet.FcpRetidoAliquota.Value * toRet.FcpRetidoBc.Value) / 100)), Arredondar, 2);
                                        }

                                        break;
                                    case 202:
                                    case 203:
                                        toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                                        toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                                        toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;

                            
                                        toRet.ValorBcSt = arredondaValor((nfProduto.ValorTotalTributavel + valorIpi) / 100, Arredondar, 2);
                                        if (somarValorFreteBcIcms)
                                        {
                                            toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                                        }
                                        toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                                        if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                                        {
                                            toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                                        }


                                        toRet.ValorIcmsSt = arredondaValor((((toRet.AliquotaSt * toRet.ValorBcSt) / 100) - toRet.ValorIcms), Arredondar, 2);

                                        if (aliquotaFCP.HasValue)
                                        {
                                            toRet.FcpRetidoAliquota = aliquotaFCP;
                                            toRet.FcpRetidoBc = toRet.ValorBcSt;
                                            toRet.FcpRetidoValor = arredondaValor((((toRet.FcpRetidoAliquota.Value * toRet.FcpRetidoBc.Value) / 100)), Arredondar, 2);
                                        }

                                        break;
                                    case 500:
                                        toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                                        toRet.ValorBcStRetidoRemetente = nfProduto.NfProdutoIcms.ValorBcStRetidoRemetente;
                                        toRet.ValorIcmsStRetidoRemetente = nfProduto.NfProdutoIcms.ValorIcmsStRetidoRemetente;

                                        if (nfProduto.NfProdutoIcms.FcpRetidoAliquota.HasValue)
                                        {
                                            toRet.FcpRetidoAliquota = nfProduto.NfProdutoIcms.FcpRetidoAliquota;
                                            toRet.FcpRetidoBc = nfProduto.NfProdutoIcms.FcpRetidoBc;
                                            toRet.FcpRetidoValor = nfProduto.NfProdutoIcms.FcpRetidoValor;
                                        }

                                        break;
                                    case 900:
                                        toRet.ModalidadeBcIcms = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBc;
                                        toRet.PercentualReducaoBc = nfProduto.NfProdutoIcms.PercentualReducaoBc;
                                        toRet.ValorBc = arredondaValor((((100 - toRet.PercentualReducaoBc) * (nfProduto.ValorTotalTributavel)) / 100), Arredondar, 2);
                                        if (somarValorFreteBcIcms)
                                        {
                                            toRet.ValorBc = toRet.ValorBc + nfProduto.ValorFrete;
                                        }
                                        toRet.ValorBc += nfProduto.OutrasDespesasAcessorias;

                                        toRet.Aliquota = nfProduto.NfProdutoIcms.Aliquota;
                                        toRet.ValorIcms = arredondaValor(toRet.Aliquota / 100 * toRet.ValorBc, Arredondar, 2);
                                        toRet.AliquotaSt = nfProduto.NfProdutoIcms.AliquotaSt;
                                        toRet.ModalidadeBcSt = nfProduto.NfProdutoIcms.ModalidadeDeterminacaoBcSt;
                                        toRet.PercentualMvaSt = nfProduto.NfProdutoIcms.PercentualMvaSt;
                                        toRet.PercentualReducaoBcSt = nfProduto.NfProdutoIcms.PercentualReducaoBcSt;

                                        if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                                        {
                                            toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                                        }

                                        if (Math.Abs(toRet.AliquotaSt) > 0.00001 || Math.Abs(toRet.PercentualMvaSt) > 0.00001 || Math.Abs(toRet.PercentualReducaoBcSt) > 0.00001)
                                        {
                                            toRet.ValorBcSt = arredondaValor((((100 - toRet.PercentualReducaoBcSt) * (toRet.ValorBc + valorIpi)) / 100), Arredondar, 2);
                                            
                                            if (toRet.ModalidadeBcSt == ModalidadeDeterminacaoBCICMSST.MargemValorAgregado)
                                            {
                                                toRet.ValorBcSt = arredondaValor((toRet.ValorBcSt * (1 + (toRet.PercentualMvaSt / 100))), Arredondar, 2);
                                            }
                                            toRet.ValorIcmsSt = arredondaValor((((toRet.AliquotaSt * toRet.ValorBcSt) / 100) - toRet.ValorIcms), Arredondar, 2);
                                        }
                                        else
                                        {
                                            toRet.ValorBcSt = 0;
                                            toRet.ValorIcmsSt = 0;
                                        }

                                        toRet.AliquotaCreditoSimples = nfProduto.NfProdutoIcms.AliquotaCreditoSimples;
                                        toRet.ValorCreditoIcmsSimples = arredondaValor(((toRet.AliquotaCreditoSimples * toRet.ValorBc) / 100), Arredondar, 2);


                                        if (aliquotaFCP.HasValue)
                                        {
                                            //toRet.FcpAliquota = aliquotaFCP;
                                            //toRet.FcpBc = toRet.ValorBc;
                                            //toRet.FcpValor = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);

                                            double tmp = arredondaValor(toRet.FcpAliquota.Value / 100 * toRet.FcpBc.Value, Arredondar, 2);

                                            toRet.FcpRetidoAliquota = aliquotaFCP;
                                            toRet.FcpRetidoBc = toRet.ValorBcSt;
                                            toRet.FcpRetidoValor = arredondaValor((((toRet.FcpRetidoAliquota.Value * toRet.FcpRetidoBc.Value) / 100) - tmp), Arredondar, 2);
                                        }

                                        break;
                                    default:
                                        throw new Exception("CSOSN Inválido");
                                }
                            }
                            else
                            {
                                throw new Exception("O item " + nfProduto.Codigo + " está configurado para ser faturado pelo simples, mas o emitente não está.");
                            }
                            break;

                        default:
                            throw new Exception("CST Inválido");
                            break;


                    }

                    toRet.PercentualDiferimento = nfProduto.NfProdutoIcms.PercentualDiferimento;

                    if (toRet.PercentualDiferimento > 0)
                    {
                        double valorOriginalICMS = toRet.ValorIcms;
                        double valorICMSDiferido = arredondaValor(toRet.PercentualDiferimento / 100 * toRet.ValorIcms, Arredondar, 2);
                        toRet.ValorIcmsOperacao = valorOriginalICMS;
                        toRet.ValorIcms -= valorICMSDiferido;
                        toRet.IcmsDiferido = valorICMSDiferido;
                        
                        toRet.ObsDiferimento = nfProduto.NfProdutoIcms.ObsDiferimento;
                        
                    }
                    else
                    {
                        toRet.ObsDiferimento = "";
                    }


                    if (toRet.ValorCreditoIcmsSimples > 0)
                    {
                        toRet.ObservacaoCreditoSimples = nfProduto.NfProdutoIcms.ObservacaoCreditoSimples;
                    }
                    else
                    {
                        toRet.ObservacaoCreditoSimples = "";
                    }
                    return toRet;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao calcular o ICMS do item " + nfProduto.Codigo + ".\r\n" + e.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public static int maxNumeroNf(string CNPJEmitente, int serie, string modelo, bool homologacao, bool scan, IWTPostgreNpgsqlCommand command = null, IWTPostgreNpgsqlConnection singleConnection = null)
        {
            try
            {
                if (command == null)
                {
                    command = (singleConnection ?? DbConnection.Connection).CreateCommand();
                }

                command.CommandText =
                    "SELECT COALESCE(max(nf_principal.nfp_numero), 0) " +
                    "FROM nf_principal  " +
                    "     INNER JOIN nf_emitente ON nf_principal.id_nf_principal = nf_emitente.id_nf_principal " +
                    "WHERE nf_emitente.nfe_cnpj_cpf = :cnpj AND " +
                    "      nf_principal.nfp_serie = :serie AND " +
                    "      nf_principal.nfp_modelo_doc_fiscal = :modelo AND " +
                    "      nf_principal.nfp_homologacao = :homologacao AND ";
                if (scan)
                {
                    command.CommandText += " ((nf_principal.nfp_serie >= 900 AND nf_principal.nfp_serie <= 999) OR (public.nf_principal.nfp_forma_emissao = 3)) ";
                }
                else
                {
                    command.CommandText += " nf_principal.nfp_serie <= 889 AND public.nf_principal.nfp_forma_emissao <> 3 ";
                }



                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = CNPJEmitente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = serie;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = modelo;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("homologacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(homologacao);
                return Convert.ToInt32(command.ExecuteScalar());


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar o maior numero da NFe\r\n" + e.Message, e);
            }

        }

        public static int maxSerieNf(string CNPJEmitente, string modelo, bool homologacao, bool scan, IWTPostgreNpgsqlCommand command = null, IWTPostgreNpgsqlConnection singleConnection = null)
        {

            try
            {
                if (command == null)
                {
                    command = (singleConnection ?? DbConnection.Connection).CreateCommand();
                }

                command.CommandText =
                    "SELECT  " +
                    "COALESCE(max(nf_principal.nfp_serie), 0) " +
                    "FROM nf_principal " +
                    "     INNER JOIN nf_emitente ON nf_principal.id_nf_principal = nf_emitente.id_nf_principal " +
                    "WHERE nf_emitente.nfe_cnpj_cpf = :cnpj AND " +
                    "      nf_principal.nfp_modelo_doc_fiscal = :modelo AND " +
                    "      nf_principal.nfp_homologacao = :homologacao AND ";
                    
                if (scan)
                {
                    command.CommandText += " ((nf_principal.nfp_serie >= 900 AND nf_principal.nfp_serie <= 999) OR (public.nf_principal.nfp_forma_emissao = 3)) ";
                }
                else
                {
                    command.CommandText += " nf_principal.nfp_serie <= 889 AND public.nf_principal.nfp_forma_emissao <> 3";
                }



                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = CNPJEmitente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = modelo;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("homologacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(homologacao);
                return Convert.ToInt32(command.ExecuteScalar());


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar a maior série da NFe\r\n" + e.Message, e);
            }
        }

        public static double arredondaValor(double Valor, ArredondamentoNF Arredondar, int qtdCasas)
        {
            if (Arredondar == ArredondamentoNF.NaoArredondarValores)
            {
                return Valor;
            }
            else
            {

                return Math.Round(Valor, qtdCasas, MidpointRounding.ToEven);
                //return Math.Round(Math.Floor(Valor * 100) / 100, qtdCasas, MidpointRounding.ToEven);
            }

        }

        public List<NfPrincipalClass> Search(int? idNf,  int? nfpNumero, DateTime? nfpDataEmissaoIni, DateTime? nfpDataEmissaoFim)
        {
            return this.Search(idNf, nfpNumero, nfpDataEmissaoIni, nfpDataEmissaoFim, null, null);
        }

        public List<NfPrincipalClass> Search(int? idNf, int? nfpNumero, DateTime? nfpDataEmissaoIni, DateTime? nfpDataEmissaoFim, string nfpSituacao, string nfpNaturezaOperacao)
        {
            List<SearchParameterClass> parametrosBusca = new List<SearchParameterClass>();

            if (idNf.HasValue)
            {
                parametrosBusca.Add(new SearchParameterClass("ID", idNf.Value));
            }



            if (nfpNumero.HasValue)
            {
                parametrosBusca.Add(new SearchParameterClass("Numero", nfpNumero.Value));
            }

            if (nfpDataEmissaoIni.HasValue)
            {
                parametrosBusca.Add(new SearchParameterClass("DataEmissaoIni", nfpDataEmissaoIni.Value));
            }

            if (nfpDataEmissaoFim.HasValue)
            {
                parametrosBusca.Add(new SearchParameterClass("DataEmissaoFim", nfpDataEmissaoFim.Value));
            }

            if (nfpSituacao != null)
            {
                parametrosBusca.Add(new SearchParameterClass("Situacao", nfpSituacao));
            }

            if (nfpNaturezaOperacao != null)
            {
                parametrosBusca.Add(new SearchParameterClass("NaturezaOperacao", nfpNaturezaOperacao));
            }


            return this.Search(parametrosBusca).ConvertAll(a => (NfPrincipalClass)(a));


        }

        public NfPrincipalClass Search(int nfpNumero, int serie, string modeloDocumentoFiscal)
        {
            List<SearchParameterClass> parametrosBusca = new List<SearchParameterClass>();

            parametrosBusca.Add(new SearchParameterClass("Numero", nfpNumero));
            parametrosBusca.Add(new SearchParameterClass("Serie", serie));
            parametrosBusca.Add(new SearchParameterClass("ModeloDocFiscal", modeloDocumentoFiscal));
            return this.Search(parametrosBusca).ConvertAll(a => (NfPrincipalClass) a).FirstOrDefault();
        }
    }
}
