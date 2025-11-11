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

                    /* =================================================================== */
                    /* INÍCIO REFORMA TRIBUTÁRIA (FRENTE 3A)                               */
                    /* =================================================================== */

                    item.NfItemTributo.NfItemTributoIbs = NfPrincipalClass.calculaIBS(item.NfProduto, Arredondar, usuarioAtual, singleConnection);
                    // ... (if ... set item) ...

                    item.NfItemTributo.NfItemTributoCbs = NfPrincipalClass.calculaCBS(item.NfProduto, Arredondar, usuarioAtual, singleConnection);
                    // ... (if ... set item) ...

                    item.NfItemTributo.NfItemTributoIs = NfPrincipalClass.calculaIS(item.NfProduto, Arredondar, usuarioAtual, singleConnection);
                    // ... (if ... set item) ...

                    // Chamada Atualizada (passando os tributos antigos)
                    item.NfItemTributo.NfItemfTributoDevolucao = NfPrincipalClass.calculaDevolucao(
                        item.NfProduto,
                        item.NfItemTributo.NfItemTributoIpi,
                        item.NfItemTributo.NfItemTributoIcms,
                        item.NfItemTributo.NfItemTributoPis,
                        item.NfItemTributo.NfItemTributoCofins,
                        Arredondar, usuarioAtual, singleConnection);

                    if (item.NfItemTributo.NfItemfTributoDevolucao != null)
                    {
                        item.NfItemTributo.NfItemfTributoDevolucao.NfItem = item;
                    }

                    /* =================================================================== */
                    /* FIM REFORMA TRIBUTÁRIA (FRENTE 3A)                                  */
                    /* =================================================================== */

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
        /// Calcula o IBS (Grupo UB) - REFATORADO (FRENTE 3A)
        /// Padrão ADR-002 (calculaPis) e ADR-005 (Produto vs Tributo)
        /// Lê de NfProdutoIbsClass (Parâmetros) e retorna NfTributoIbsClass (Calculado)
        /// </summary>
        public static NfTributoIbsClass calculaIBS(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            // 1. Validação "Fail-Fast" (ADR-004)
            if (nfProduto.NfProdutoIbs == null)
                return null;

            var pIbs = nfProduto.NfProdutoIbs; // Alias para "Produto" (Parâmetros de entrada)

            if (string.IsNullOrEmpty(pIbs.CstIbs))
            {
                // Validação mínima para garantir que o objeto foi intencionalmente preenchido
                throw new Exception(string.Format(
                    "Erro de cálculo (calculaIBS): O item Produto={0} possui 'nf_produto_ibs' informada, mas o campo obrigatório (CstIbs - UB13) está nulo.",
                    nfProduto.Codigo
                ));
            }

            // 2. Criação da entidade de "Tributo" (Calculado) (ADR-005)
            var toRet = new NfTributoIbsClass(usuarioAtual, singleConnection);
            toRet.CstIbs = pIbs.CstIbs; // ntb_cst_ibs (Cópia do parâmetro)

            /* =============================================================================
             * RAMO 1: Tributação Regular (gIBSCBS - UB15) e Crédito (gCredPresOper - UB120)
             * ============================================================================= */

            // 3. Base de Cálculo Principal (vBC - UB16) - PENDÊNCIA 3 (Híbrida)
            double vBC = pIbs.VBaseCalcIbs.GetValueOrDefault(0);

            if (vBC == 0)
            {
                // Cenário 2: Cliente não informou, nós calculamos.
                // Segue o padrão ADR-002 (calculaIcms)
                vBC = nfProduto.ValorTotalTributavel;
                vBC += nfProduto.OutrasDespesasAcessorias;

                // Nota: O padrão (calculaIcms) também somaria Frete/Seguro se o flag global
                // 'somarValorFreteBcIcms' estivesse disponível, mas ele não é passado
                // para este método estático, então seguimos o padrão mais básico.
            }
            // Se vBC > 0, usamos o Cenário 1 (valor informado pelo cliente).

            toRet.VBcIbs = arredondaValor(vBC, Arredondar, 2); // ntb_v_bc_ibs (UB16)

            // 4. Cálculo: Alíquotas e Redução (gRed - UB26, UB45)
            double pIbsUf = pIbs.PIbsUf.GetValueOrDefault(0);     // (Parâmetro) npb_p_ibs_uf (UB18)
            double pIbsMun = pIbs.PIbsMun.GetValueOrDefault(0);   // (Parâmetro) npb_p_ibs_mun (UB37)
            double pRedAliq = pIbs.PRedAliq.GetValueOrDefault(0); // (Parâmetro) npb_p_red_aliq (UB27/UB45)

            double pIbsUfEfetiva = pIbsUf;
            double pIbsMunEfetiva = pIbsMun;

            if (pRedAliq > 0)
            {
                // A NT (UB28) indica redução na Alíquota, não na BC
                double fatorReducao = (1 - (pRedAliq / 100));
                pIbsUfEfetiva = pIbsUf * fatorReducao;
                pIbsMunEfetiva = pIbsMun * fatorReducao;
            }

            // Salva a Alíquota Efetiva total (Calculado)
            toRet.PAliqEfet = arredondaValor(pIbsUfEfetiva + pIbsMunEfetiva, Arredondar, 4); // ntb_p_aliq_efet (UB28/UB45)

            // 5. Cálculo: Valores Brutos (Antes do Diferimento)
            double vIbsUfBruto = arredondaValor((toRet.VBcIbs.Value * (pIbsUfEfetiva / 100)), Arredondar, 2);
            double vIbsMunBruto = arredondaValor((toRet.VBcIbs.Value * (pIbsMunEfetiva / 100)), Arredondar, 2);
            double vIbsTotalBruto = vIbsUfBruto + vIbsMunBruto;

            // 6. Cálculo: Diferimento (gDif - UB21, UB40)
            double pDif = pIbs.PDif.GetValueOrDefault(0); // (Parâmetro) npb_p_dif (UB22/UB40)
            double vDifTotal = 0;
            if (pDif > 0)
            {
                // O valor do diferimento (vDif) é calculado sobre o imposto bruto
                vDifTotal = arredondaValor((vIbsTotalBruto * (pDif / 100)), Arredondar, 2);
            }
            toRet.VIbsDif = vDifTotal; // (Calculado) ntb_v_ibs_dif (UB23/UB40)

            // 7. Cálculo: Valores Líquidos (vIBSUF - UB35, vIBSMun - UB54)
            // (Abatendo o Diferimento)
            double vIbsUfLiquido = vIbsUfBruto;
            double vIbsMunLiquido = vIbsMunBruto;

            if (vDifTotal > 0 && vIbsTotalBruto > 0)
            {
                // Rateia o vDifTotal proporcionalmente
                vIbsUfLiquido = vIbsUfBruto - arredondaValor(vDifTotal * (vIbsUfBruto / vIbsTotalBruto), Arredondar, 2);
                vIbsMunLiquido = vIbsMunBruto - arredondaValor(vDifTotal * (vIbsMunBruto / vIbsTotalBruto), Arredondar, 2);
            }

            toRet.VIbsUf = vIbsUfLiquido;   // (Calculado) ntb_v_ibs_uf (UB35)
            toRet.VIbsMun = vIbsMunLiquido; // (Calculado) ntb_v_ibs_mun (UB54)

            // vIBS (UB54a) é a soma dos valores líquidos, ANTES de abater o vCredPres
            double vIbsLiquido = arredondaValor(toRet.VIbsUf.Value + toRet.VIbsMun.Value, Arredondar, 2);
            toRet.VIbs = vIbsLiquido; // ntb_v_ibs

            // 8. Cálculo: Crédito Presumido (gCredPresOper - UB120)
            double pCredPres = pIbs.PCredPres.GetValueOrDefault(0);     // (Parâmetro) Alíquota
            string cCredPres = pIbs.CCredPres;                         // (Parâmetro) Código

            // PENDÊNCIA 4 (Híbrida)
            double vBCCredPres = pIbs.VBcCredPres.GetValueOrDefault(0); // (Parâmetro) UB121
            if (vBCCredPres == 0 && pCredPres > 0)
            {
                // Cenário 2: Cliente não informou. Assumimos que a BC do crédito
                // é a mesma BC principal do imposto (calculada/informada no Passo 3).
                vBCCredPres = toRet.VBcIbs.Value;
            }
            // Se vBCCredPres > 0, usamos o Cenário 1 (valor informado pelo cliente).

            // Cálculo do valor do crédito
            double vCredPresCalculado = arredondaValor((vBCCredPres * (pCredPres / 100)), Arredondar, 2);

            // PENDÊNCIA 1 (Regra do CSV 'ind_DeduzCredPres')
            // Apenas cCredPres "4", "7" e "11" são dedução imediata.
            bool isCondSus = (cCredPres != "4" && cCredPres != "7" && cCredPres != "11");

            if (isCondSus)
            {
                toRet.VCredPres = 0;
                toRet.VCredPresCondSus = vCredPresCalculado; // ntb_v_cred_pres_cond_sus (UB126)
            }
            else
            {
                toRet.VCredPres = vCredPresCalculado; // ntb_v_cred_pres (UB125)
                toRet.VCredPresCondSus = 0;
            }

            // 9. Cálculo: vIBS Total (UB54a) - Abatendo Crédito Presumido
            // Regra UB54a: "...o vCredPres deve ser abatido desse valor."
            vIbsLiquido = vIbsLiquido - toRet.VCredPres.Value - toRet.VCredPresCondSus.Value;
            toRet.VIbs = arredondaValor(vIbsLiquido, Arredondar, 2); // (Calculado) ntb_v_ibs (final)


            /* =============================================================================
             * RAMO 2: Tributação Regular (Informativa) (gTribRegular - UB68)
             * ============================================================================= */

            // Calcula os valores que *seriam* devidos (informativo)
            double pAliqRegUf = pIbs.PAliqEfetRegIbsUf.GetValueOrDefault(0);   // (Parâmetro) npb_p_aliq_efet_reg_ibs_uf (UB71)
            double pAliqRegMun = pIbs.PAliqEfetRegIbsMun.GetValueOrDefault(0); // (Parâmetro) npb_p_aliq_efet_reg_ibs_mun (UB72a)

            toRet.VTribRegIbsUf = arredondaValor((toRet.VBcIbs.Value * (pAliqRegUf / 100)), Arredondar, 2);   // (Calculado) ntb_v_trib_reg_ibs_uf (UB72)
            toRet.VTribRegIbsMun = arredondaValor((toRet.VBcIbs.Value * (pAliqRegMun / 100)), Arredondar, 2); // (Calculado) ntb_v_trib_reg_ibs_mun (UB72b)

            /* =============================================================================
             * RAMO 3: Compras Governamentais (Informativo) (gTribCompraGov - UB82a)
             * ============================================================================= */

            // Calcula os valores *cheios* (informativo)
            double pAliqGovUf = pIbs.PAliqIbsUfGov.GetValueOrDefault(0);   // (Parâmetro) npb_p_aliq_ibs_uf_gov (UB82b)
            double pAliqGovMun = pIbs.PAliqIbsMunGov.GetValueOrDefault(0); // (Parâmetro) npb_p_aliq_ibs_mun_gov (UB82d)

            toRet.VTribIbsUfGov = arredondaValor((toRet.VBcIbs.Value * (pAliqGovUf / 100)), Arredondar, 2);   // (Calculado) ntb_v_trib_ibs_uf_gov (UB82c)
            toRet.VTribIbsMunGov = arredondaValor((toRet.VBcIbs.Value * (pAliqGovMun / 100)), Arredondar, 2); // (Calculado) ntb_v_trib_ibs_mun_gov (UB82e)

            /* =============================================================================
             * RAMOS 4, 5, 6: (Transf, Ajuste, Estorno, ZFM) - PENDÊNCIA 2 (DDL Corrigido)
             * ============================================================================= */

            // Estes campos são "copiados" dos parâmetros informados pelo cliente (ADR-005)
            // Assumindo que o DDL foi corrigido e as entidades regeneradas.

            toRet.VIbsTransfCred = arredondaValor(pIbs.VIbsTransfCred.GetValueOrDefault(0), Arredondar, 2);    // ntb_v_ibs_transf_cred (UB107)
            toRet.VIbsAjuste = arredondaValor(pIbs.VIbsAjuste.GetValueOrDefault(0), Arredondar, 2);              // ntb_v_ibs_ajuste (UB114)
            toRet.VIbsEstornoCred = arredondaValor(pIbs.VIbsEstornoCred.GetValueOrDefault(0), Arredondar, 2);   // ntb_v_ibs_estorno_cred (UB117)
            toRet.VCredPresIbszfm = arredondaValor(pIbs.VCredPresIbszfm.GetValueOrDefault(0), Arredondar, 2);   // ntb_v_cred_pres_ibszfm (UB134)

            // 10. Retorna a entidade de tributo calculada
            return toRet;
        }



        /// <summary>
        /// Calcula o CBS (Grupo UB) - REFATORADO (FRENTE 3A)
        /// Padrão ADR-002 (calculaPis) e ADR-005 (Produto vs Tributo)
        /// Lê de NfProdutoCbsClass (Parâmetros) e retorna NfTributoCbsClass (Calculado)
        /// </summary>
        public static NfTributoCbsClass calculaCBS(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            // 1. Validação "Fail-Fast" (ADR-004)
            if (nfProduto.NfProdutoCbs == null)
                return null;

            var pCbs = nfProduto.NfProdutoCbs; // Alias para "Produto" (Parâmetros de entrada)

            if (string.IsNullOrEmpty(pCbs.CstCbs))
            {
                // Validação mínima para garantir que o objeto foi intencionalmente preenchido
                throw new Exception(string.Format(
                    "Erro de cálculo (calculaCBS): O item Produto={0} possui 'nf_produto_cbs' informada, mas o campo obrigatório (CstCbs - UB13) está nulo.",
                    nfProduto.Codigo
                ));
            }

            // 2. Criação da entidade de "Tributo" (Calculado) (ADR-005)
            var toRet = new NfTributoCbsClass(usuarioAtual, singleConnection);
            toRet.CstCbs = pCbs.CstCbs; // nts_cst_cbs (Cópia do parâmetro)

            /* =============================================================================
             * RAMO 1: Tributação Regular (gIBSCBS - UB15) e Crédito (gCredPresOper - UB127)
             * ============================================================================= */

            // 3. Base de Cálculo Principal (vBC - UB16) - PENDÊNCIA 3 (Híbrida)
            double vBC = pCbs.VBaseCalcCbs.GetValueOrDefault(0);

            if (vBC == 0)
            {
                // Cenário 2: Cliente não informou, nós calculamos.
                // Segue o padrão ADR-002 (calculaIcms)
                vBC = nfProduto.ValorTotalTributavel;
                vBC += nfProduto.OutrasDespesasAcessorias;
            }
            // Se vBC > 0, usamos o Cenário 1 (valor informado pelo cliente).

            toRet.VBcCbs = arredondaValor(vBC, Arredondar, 2); // nts_v_bc_cbs (UB16)

            // 4. Cálculo: Alíquotas e Redução (gRed - UB64)
            double pCbsAliq = pCbs.PCbs.GetValueOrDefault(0);       // (Parâmetro) nps_p_cbs (UB56)
            double pRedAliq = pCbs.PRedAliq.GetValueOrDefault(0);   // (Parâmetro) nps_p_red_aliq (UB64)

            double pCbsEfetiva = pCbsAliq;

            if (pRedAliq > 0)
            {
                // A NT (UB64) indica redução na Alíquota
                double fatorReducao = (1 - (pRedAliq / 100));
                pCbsEfetiva = pCbsAliq * fatorReducao;
            }

            // Salva a Alíquota Efetiva (Calculado)
            toRet.PAliqEfet = arredondaValor(pCbsEfetiva, Arredondar, 4); // nts_p_aliq_efet (UB64)

            // 5. Cálculo: Valor Bruto (Antes do Diferimento)
            double vCbsBruto = arredondaValor((toRet.VBcCbs.Value * (pCbsEfetiva / 100)), Arredondar, 2);

            // 6. Cálculo: Diferimento (gDif - UB59)
            double pDif = pCbs.PDif.GetValueOrDefault(0); // (Parâmetro) nps_p_dif (UB59)
            double vDifTotal = 0;
            if (pDif > 0)
            {
                // O valor do diferimento (vDif) é calculado sobre o imposto bruto
                vDifTotal = arredondaValor((vCbsBruto * (pDif / 100)), Arredondar, 2);
            }
            toRet.VCbsDif = vDifTotal; // (Calculado) nts_v_cbs_dif (UB59)

            // 7. Cálculo: Valor Líquido (vCBS - UB67)
            // (Abatendo o Diferimento)
            double vCbsLiquido = vCbsBruto - vDifTotal;

            toRet.VCbs = vCbsLiquido; // nts_v_cbs (Valor ANTES do Crédito Presumido)

            // 8. Cálculo: Crédito Presumido (gCredPresOper - UB127)
            double pCredPres = pCbs.PCredPres.GetValueOrDefault(0);     // (Parâmetro) Alíquota (UB128)
            string cCredPres = pCbs.CCredPres;                         // (Parâmetro) Código (UB122)

            // PENDÊNCIA 4 (Híbrida)
            double vBCCredPres = pCbs.VBcCredPres.GetValueOrDefault(0); // (Parâmetro) UB121
            if (vBCCredPres == 0 && pCredPres > 0)
            {
                // Cenário 2: Cliente não informou. Assumimos que a BC do crédito
                // é a mesma BC principal do imposto (calculada/informada no Passo 3).
                vBCCredPres = toRet.VBcCbs.Value;
            }
            // Se vBCCredPres > 0, usamos o Cenário 1 (valor informado pelo cliente).

            // Cálculo do valor do crédito
            double vCredPresCalculado = arredondaValor((vBCCredPres * (pCredPres / 100)), Arredondar, 2);

            // PENDÊNCIA 1 (Regra do CSV 'ind_DeduzCredPres')
            // Apenas cCredPres "4", "7" e "11" são dedução imediata.
            bool isCondSus = (cCredPres != "4" && cCredPres != "7" && cCredPres != "11");

            if (isCondSus)
            {
                toRet.VCredPres = 0;
                toRet.VCredPresCondSus = vCredPresCalculado; // nts_v_cred_pres_cond_sus (UB130)
            }
            else
            {
                toRet.VCredPres = vCredPresCalculado; // nts_v_cred_pres (UB129)
                toRet.VCredPresCondSus = 0;
            }

            // 9. Cálculo: vCBS Total (UB67) - Abatendo Crédito Presumido
            // A regra do vIBS (UB54a) sobre abater o crédito se aplica analogamente à CBS.
            vCbsLiquido = vCbsLiquido - toRet.VCredPres.Value - toRet.VCredPresCondSus.Value;
            toRet.VCbs = arredondaValor(vCbsLiquido, Arredondar, 2); // (Calculado) nts_v_cbs (final)


            /* =============================================================================
             * RAMO 2: Tributação Regular (Informativa) (gTribRegular - UB68)
             * ============================================================================= */

            double pAliqRegCbs = pCbs.PAliqEfetRegCbs.GetValueOrDefault(0);   // (Parâmetro) nps_p_aliq_efet_reg_cbs (UB72c)
            toRet.VTribRegCbs = arredondaValor((toRet.VBcCbs.Value * (pAliqRegCbs / 100)), Arredondar, 2);   // (Calculado) nts_v_trib_reg_cbs (UB72d)

            /* =============================================================================
             * RAMO 3: Compras Governamentais (Informativo) (gTribCompraGov - UB82a)
             * ============================================================================= */

            double pAliqGovCbs = pCbs.PAliqCbsGov.GetValueOrDefault(0);   // (Parâmetro) nps_p_aliq_cbs_gov (UB82f)
            toRet.VTribCbsGov = arredondaValor((toRet.VBcCbs.Value * (pAliqGovCbs / 100)), Arredondar, 2);   // (Calculado) nts_v_trib_cbs_gov (UB82g)

            /* =============================================================================
             * RAMOS 4, 5, 6: (Transf, Ajuste, Estorno) - PENDÊNCIA 2 (DDL Corrigido)
             * ============================================================================= */

            // Estes campos são "copiados" dos parâmetros informados pelo cliente (ADR-005)
            // Assumindo que o DDL foi corrigido e as entidades regeneradas.

            toRet.VCbsTransfCred = arredondaValor(pCbs.VCbsTransfCred.GetValueOrDefault(0), Arredondar, 2);    // nts_v_cbs_transf_cred (UB108)
            toRet.VCbsAjuste = arredondaValor(pCbs.VCbsAjuste.GetValueOrDefault(0), Arredondar, 2);              // nts_v_cbs_ajuste (UB115)
            toRet.VCbsEstornoCred = arredondaValor(pCbs.VCbsEstornoCred.GetValueOrDefault(0), Arredondar, 2);   // nts_v_cbs_estorno_cred (UB118)

            // 10. Retorna a entidade de tributo calculada
            return toRet;
        }


        /// <summary>
        /// Calcula o IS (Grupo UB01) - REFATORADO (FRENTE 3A)
        /// Padrão ADR-002 (calculaPis) e ADR-005 (Produto vs Tributo)
        /// Lê de NfProdutoIsClass (Parâmetros) e retorna NfTributoIsClass (Calculado)
        /// </summary>
        public static NfTributoIsClass calculaIS(NfProdutoClass nfProduto, ArredondamentoNF Arredondar, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            // 1. Validação "Fail-Fast" (ADR-004)
            if (nfProduto.NfProdutoIs == null)
                return null;

            var pIs = nfProduto.NfProdutoIs; // Alias para "Produto" (Parâmetros de entrada)

            if (string.IsNullOrEmpty(pIs.CstIs))
            {
                // Validação mínima para garantir que o objeto foi intencionalmente preenchido
                throw new Exception(string.Format(
                    "Erro de cálculo (calculaIS): O item Produto={0} possui 'nf_produto_is' informada, mas o campo obrigatório (CstIs - UB02) está nulo.",
                    nfProduto.Codigo
                ));
            }

            // 2. Criação da entidade de "Tributo" (Calculado) (ADR-005)
            var toRet = new NfTributoIsClass(usuarioAtual, singleConnection);
            toRet.CstIs = pIs.CstIs; // ntl_cst_is (Cópia do parâmetro)

            /* =============================================================================
             * CÁLCULO DO IMPOSTO (vIS - UB11)
             * ============================================================================= */

            // 3. Base de Cálculo Principal (vBCIS - UB05) - PENDÊNCIA 3 (Híbrida)
            double vBC = pIs.VBaseCalcIs.GetValueOrDefault(0);

            if (vBC == 0)
            {
                // Cenário 2: Cliente não informou, nós calculamos.
                // Segue o padrão ADR-002 (calculaIcms)
                vBC = nfProduto.ValorTotalTributavel;
                vBC += nfProduto.OutrasDespesasAcessorias;
            }
            // Se vBC > 0, usamos o Cenário 1 (valor informado pelo cliente).

            toRet.VBcIs = arredondaValor(vBC, Arredondar, 2); // ntl_v_bc_is (UB05)

            // 4. Cálculo do Valor (vIS - UB11)
            // O IS pode ser (A) Percentual (ad valorem) ou (B) Específico (ad rem)
            // O DDL (npl_p_is vs npl_p_is_espec / npl_q_trib) reflete isso.

            double vIS = 0;
            double pIS_Percentual = pIs.PIs.GetValueOrDefault(0);         // (Parâmetro) npl_p_is (UB06)
            double pIS_Especifico = pIs.PIsEspec.GetValueOrDefault(0);   // (Parâmetro) npl_p_is_espec (UB07) - (Valor R$ ad-rem)
            double qTrib = pIs.QTrib.GetValueOrDefault(0);               // (Parâmetro) npl_q_trib (UB10)

            if (pIS_Percentual > 0)
            {
                // Método 1: Percentual (ad valorem)
                vIS = arredondaValor((toRet.VBcIs.Value * (pIS_Percentual / 100)), Arredondar, 2);
                toRet.PIs = pIS_Percentual; // Salva a alíquota (percentual) usada
            }
            else if (pIS_Especifico > 0 && qTrib > 0)
            {
                // Método 2: Específico (ad rem)
                // (Segue padrão do calculaPis - Modalidade Quantidade)
                vIS = arredondaValor((qTrib * pIS_Especifico), Arredondar, 2);
                toRet.PIs = pIS_Especifico; // Salva a alíquota (R$ ad-rem) usada
            }

            toRet.VIs = vIS; // (Calculado) ntl_v_is (UB11)

            // 5. Cópia de Campos de Parâmetro (ADR-005)
            // O DDL (npl_v_is_dev) define a devolução como um PARÂMETRO R$
            toRet.VIsDev = arredondaValor(pIs.VIsDev.GetValueOrDefault(0), Arredondar, 2); // ntl_v_is_dev

            // 6. Remoção de Lógica Zumbi (Campos "Retidos")
            // O DDL 'Alterações BD NFe.sql' removeu os parâmetros de IS Retido 
            // (npl_v_base_calc_is_ret, npl_p_is_ret) e o .md (UB01-UB11) não os prevê.
            // O código antigo (linhas 461-470) estava incorreto.
            // Os campos 'ntl_v_bc_is_ret' e 'ntl_v_is_ret' no DDL 'nf_tributo_is'
            // são "zumbis" da Frente 1 e não devem ser calculados.
            toRet.VBcIsRet = 0;
            toRet.VIsRet = 0;

            // 7. Retorna a entidade de tributo calculada
            return toRet;
        }

        /// <summary>
        /// Calcula o Imposto Devolvido (Grupo UA) - REFATORADO (FRENTE 3A)
        /// Padrão ADR-002 (calculaPis) e ADR-005 (Produto vs Tributo)
        /// Lê de NfProdutoDevolucao (Parâmetro pDev) e dos tributos antigos (R$)
        /// Retorna NfTributoDevolucaoClass (Calculado)
        /// </summary>
        public static NfTributoDevolucaoClass calculaDevolucao(
            NfProdutoClass nfProduto,
            NfItemTributoIpiClass nfIpi,       // (Inclusão para regra UA03)
            NfItemTributoIcmsClass nfIcms,
            NfItemTributoPisClass nfPis,       // (Inclusão para regra UA08)
            NfItemTributoCofinsClass nfCofins, // (Inclusão para regra UA09)
            ArredondamentoNF Arredondar,
            AcsUsuarioClass usuarioAtual,
            IWTPostgreNpgsql.IWTPostgreNpgsqlConnection singleConnection)
        {
            // 1. Validação "Fail-Fast" (ADR-004)
            // Verifica se o grupo de devolução foi informado e se o percentual é válido
            if (nfProduto.NfProdutoDevolucao == null || nfProduto.NfProdutoDevolucao.PDev.GetValueOrDefault(0) <= 0)
            {
                return null;
            }

            var pDevol = nfProduto.NfProdutoDevolucao; // Parâmetro de entrada (npv_p_dev)
            double pDev = pDevol.PDev.Value / 100;     // (Parâmetro) UA02

            // 2. Criação da entidade de "Tributo" (Calculado) (ADR-005)
            var toRet = new NfTributoDevolucaoClass(usuarioAtual, singleConnection);

            // 3. Cálculo IPI Devolvido (UA03)
            // Regra: vIPIDev = vIPI * (pDev / 100)
            if (nfIpi != null && nfIpi.ValorIpi > 0)
            {
                toRet.VIpiDev = arredondaValor(nfIpi.ValorIpi * pDev, Arredondar, 2);
            }

            // 4. Cálculo ICMS Devolvido (UA04, UA05)
            // Regra: vICMSDev = vICMS * (pDev / 100)
            if (nfIcms != null && nfIcms.ValorIcms > 0)
            {
                toRet.VBcIcmsDev = nfIcms.ValorBc; // Informa a BC Original (UA04)
                toRet.VIcmsDev = arredondaValor(nfIcms.ValorIcms * pDev, Arredondar, 2); // (UA05)
            }

            // 5. Cálculo ICMS-ST Devolvido (UA06, UA07)
            // Regra: vICMSSTDev = vICMSST * (pDev / 100)
            if (nfIcms != null && nfIcms.ValorIcmsSt > 0)
            {
                toRet.VBcIcmsStDev = nfIcms.ValorBcSt; // Informa a BC ST Original (UA06)
                toRet.VIcmsStDev = arredondaValor(nfIcms.ValorIcmsSt * pDev, Arredondar, 2); // (UA07)
            }

            // 6. Cálculo PIS Devolvido (UA08)
            // Regra: vPISDev = vPIS * (pDev / 100)
            if (nfPis != null && nfPis.ValorPis > 0)
            {
                toRet.VPisDev = arredondaValor(nfPis.ValorPis * pDev, Arredondar, 2);
            }

            // 7. Cálculo COFINS Devolvido (UA09)
            // Regra: vCOFINSDev = vCOFINS * (pDev / 100)
            if (nfCofins != null && nfCofins.ValorCofins > 0)
            {
                toRet.VCofinsDev = arredondaValor(nfCofins.ValorCofins * pDev, Arredondar, 2);
            }

            return toRet;
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
