#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using IWTNF.Entidades;
using IWTNF.Entidades.Entidades;

#endregion

namespace IWTNF
{
    public class GeradorArquivoMagnetico
    {
        public GeradorArquivoMagnetico()
        {
        }

        public void Generate(List<NfPrincipalClass> notasFiscais, string fileName, string CNPJ, string InscricaoEstadual, string NomeContribuinte, string Municipio, string UF, Int64 Fax, DateTime DataInicial, DateTime DataFinal, int CodigoConvenio, int CodigoNaturezaOperacao, FinalidadeArquivoMagnetico CodigoFinalidadeArquivo, string Logradouro, Int64 Numero, string Complemento, string Bairro, Int64 CEP, string NomeContato, Int64 Fone)
        {
            StreamWriter writer = null;
            try
            {

                reg10 Reg10 = new reg10(CNPJ, InscricaoEstadual, NomeContribuinte, Municipio, UF, Fax, DataInicial, DataFinal, CodigoConvenio, CodigoNaturezaOperacao, CodigoFinalidadeArquivo);
                reg11 Reg11 = new reg11(Logradouro, Numero, Complemento, Bairro, CEP, NomeContato, Fone);

                ArquivoMagnetico arq = new ArquivoMagnetico(Reg10, Reg11);
                try
                {
                    this.GenerateReg50(notasFiscais, ref arq);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar os registros 50.\r\n" + e.Message);
                }

                try
                {
                    this.GenerateReg51(notasFiscais, ref arq);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar os registros 51.\r\n" + e.Message);
                }

                try
                {
                    this.GenerateReg53(notasFiscais, ref arq);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar os registros 53.\r\n" + e.Message);
                }

                try
                {
                    this.GenerateReg54(notasFiscais, ref arq);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar os registros 54.\r\n" + e.Message);
                }

                try
                {
                    this.GenerateReg75(notasFiscais, ref arq);
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao gerar os registros 75.\r\n" + e.Message);
                }

                writer = new StreamWriter(fileName);
                writer.AutoFlush = true;
                writer.Write(arq.GenerateString());
                writer.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o arquivo magnético.\r\n" + e.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }

        }

        private void GenerateReg50(List<NfPrincipalClass> notasFiscais, ref ArquivoMagnetico arq)
        {
            //Registro 50 1 registro para cada combinação de emitente, nota fiscal, CFOP, aliquota ICMS
            foreach (NfPrincipalClass nf in notasFiscais)
            {
                /* 
                 * ICMS
                [0] -> ValorTotal;
                [1] -> BaseCalculoICMS;
                [2] -> ValorICMS;
                [3] -> Isenta;
                [4] -> Outras;

                */

                Dictionary<CfopAliquotaPair, List<double>> itensTmp = new Dictionary<CfopAliquotaPair, List<double>>();
                foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
                {
                    if (item.NfItemTributo.NfItemTributoIcms != null)
                    {
                        CfopAliquotaPair chave = new CfopAliquotaPair() { Cfop = item.Cfop, Aliquota = item.NfItemTributo.NfItemTributoIcms.Aliquota };
                        if (itensTmp.ContainsKey(chave))
                        {
                            itensTmp[chave][0] += item.NfProduto.ValorTotalTributavel + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt;
                            if (item.NfItemTributo.NfItemTributoIpi != null)
                            {
                                itensTmp[chave][0] += item.NfItemTributo.NfItemTributoIpi.ValorIpi;
                            }
                            
                            if (item.NfItemTributo.NfItemTributoIcms.Cst == "30" || item.NfItemTributo.NfItemTributoIcms.Cst == "40")
                            {
                                //Isento ICMS
                                itensTmp[chave][1] += 0;
                                itensTmp[chave][2] += item.NfItemTributo.NfItemTributoIcms.ValorIcms;
                                itensTmp[chave][3] += item.NfProduto.ValorTotalTributavel;
                            }
                            else
                            {
                                itensTmp[chave][1] += item.NfItemTributo.NfItemTributoIcms.ValorBc;
                                itensTmp[chave][2] += item.NfItemTributo.NfItemTributoIcms.ValorIcms;
                                itensTmp[chave][3] += 0;
                            }
                            itensTmp[chave][4] += 0;
                        }
                        else
                        {
                            List<double> listTmp = new List<double>();
                            listTmp.Add(0);
                            listTmp.Add(0);
                            listTmp.Add(0);
                            listTmp.Add(0);
                            listTmp.Add(0);

                            listTmp[0] = item.NfProduto.ValorTotalTributavel + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt;
                            if (item.NfItemTributo.NfItemTributoIpi != null)
                            {
                                listTmp[0] += item.NfItemTributo.NfItemTributoIpi.ValorIpi;
                            }
                            if (item.NfItemTributo.NfItemTributoIcms.Cst == "30" || item.NfItemTributo.NfItemTributoIcms.Cst == "40")
                            {
                                //Isento
                                listTmp[1] = 0;
                                listTmp[2] = item.NfItemTributo.NfItemTributoIcms.ValorIcms;
                                listTmp[3] = item.NfItemTributo.NfItemTributoIcms.ValorBc;
                            }
                            else
                            {
                                listTmp[1] = item.NfItemTributo.NfItemTributoIcms.ValorBc;
                                listTmp[2] = item.NfItemTributo.NfItemTributoIcms.ValorIcms;
                                listTmp[3] = 0;
                            }
                            listTmp[4] = 0;

                            itensTmp.Add(chave, listTmp);
                        }
                    }
                }
                foreach (CfopAliquotaPair item in itensTmp.Keys)
                {

                    reg50 reg50Tmp = new reg50(nf.NfCliente.CnpjCpf, nf.NfCliente.Ie, nf.DataEmissao, nf.NfCliente.NfClienteEndereco.SiglaUf, int.Parse(nf.ModeloDocFiscal), nf.Serie.ToString(),
                        nf.Numero, item.Cfop, nf.TipoEmitente, itensTmp[item][0], itensTmp[item][1], itensTmp[item][2], itensTmp[item][3], itensTmp[item][4], item.Aliquota, nf.Situacao);

                    arq.addReg50(reg50Tmp);
                }
            }
        }

        private void GenerateReg51(List<NfPrincipalClass> notasFiscais, ref ArquivoMagnetico arq)
        {
            //Registro 51 1 registro para cada combinação de emitente, nota fiscal, CFOP, aliquota ICMS
            foreach (NfPrincipalClass nf in notasFiscais)
            {

                /* IPI
                [0] -> ValorTotal;
                [1] -> ValorIPI;
                [2] -> Isenta;
                [3] -> Outras;
                 */

                Dictionary<CfopAliquotaPair, List<double>> itensTmp = new Dictionary<CfopAliquotaPair, List<double>>();
                foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
                {
                    if (item.NfItemTributo.NfItemTributoIpi != null)
                    {
                        CfopAliquotaPair chave = new CfopAliquotaPair() { Cfop = item.Cfop, Aliquota = item.NfItemTributo.NfItemTributoIpi.Aliquota };
                        if (itensTmp.ContainsKey(chave))
                        {
                            itensTmp[chave][0] += item.NfProduto.ValorTotalTributavel;
                            if (item.NfItemTributo.NfItemTributoIpi.Cst != "00" && item.NfItemTributo.NfItemTributoIpi.Cst != "49" && item.NfItemTributo.NfItemTributoIpi.Cst != "50" && item.NfItemTributo.NfItemTributoIpi.Cst != "99")
                            {
                                //Isento IPI
                                itensTmp[chave][1] += 0;
                                itensTmp[chave][2] += item.NfProduto.ValorTotalTributavel;

                            }
                            else
                            {
                                itensTmp[chave][1] += item.NfItemTributo.NfItemTributoIpi.ValorIpi;
                                itensTmp[chave][2] += 0;
                            }
                            itensTmp[chave][3] += 0;
                        }
                        else
                        {
                            List<double> listTmp = new List<double>();
                            listTmp.Add(0);
                            listTmp.Add(0);
                            listTmp.Add(0);
                            listTmp.Add(0);

                            listTmp[0] = item.NfProduto.ValorTotalTributavel;
                            if (item.NfItemTributo.NfItemTributoIpi.Cst != "00" && item.NfItemTributo.NfItemTributoIpi.Cst != "49" && item.NfItemTributo.NfItemTributoIpi.Cst != "50" && item.NfItemTributo.NfItemTributoIpi.Cst != "99")
                            {
                                //Isento IPI
                                listTmp[1] = 0;
                                listTmp[2] = item.NfProduto.ValorTotalTributavel;

                            }
                            else
                            {
                                listTmp[1] = item.NfItemTributo.NfItemTributoIpi.ValorIpi;
                                listTmp[2] = 0;
                            }
                            listTmp[3] = 0;

                            itensTmp.Add(chave, listTmp);
                        }
                    }
                }
                foreach (CfopAliquotaPair item in itensTmp.Keys)
                {
                    reg51 reg51Tmp = new reg51(nf.NfCliente.CnpjCpf, nf.NfCliente.Ie, nf.DataEmissao, nf.NfEmitente.NfEmitenteEndereco.SiglaUf, nf.Serie.ToString(), nf.Numero, item.Cfop, itensTmp[item][0],
                        itensTmp[item][1], itensTmp[item][2], itensTmp[item][3], nf.Situacao);

                    arq.addReg51(reg51Tmp);
                }
            }
        }

        private void GenerateReg53(List<NfPrincipalClass> notasFiscais, ref ArquivoMagnetico arq)
        {
            foreach (NfPrincipalClass nf in notasFiscais)
            {
                Dictionary<CfopAliquotaPair, List<double>> itensTmp = new Dictionary<CfopAliquotaPair, List<double>>();
                foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
                {
                    if (item.NfItemTributo.NfItemTributoIcms != null)
                    {
                        if (item.NfItemTributo.NfItemTributoIcms.Cst == "10" || item.NfItemTributo.NfItemTributoIcms.Cst == "30" || item.NfItemTributo.NfItemTributoIcms.Cst == "60" || item.NfItemTributo.NfItemTributoIcms.Cst == "70" || item.NfItemTributo.NfItemTributoIcms.Cst == "90")
                        {
                            reg53 reg53Tmp = new reg53(nf.NfCliente.CnpjCpf, nf.NfCliente.Ie, nf.DataEmissao, nf.NfEmitente.NfEmitenteEndereco.SiglaUf, int.Parse(nf.ModeloDocFiscal), nf.Serie.ToString(), nf.Numero, item.Cfop, nf.TipoEmitente,
                                item.NfItemTributo.NfItemTributoIcms.ValorBcSt, item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt, item.NfProduto.ValorFrete + item.NfProduto.ValorSeguro, nf.Situacao, item.NfItemTributo.NfItemTributoIcms.CodigoAntecipacaoSt);
                            arq.addReg53(reg53Tmp);
                        }

                    }
                }
            }

        }

        private void GenerateReg54(List<NfPrincipalClass> notasFiscais, ref ArquivoMagnetico arq)
        {
            foreach (NfPrincipalClass nf in notasFiscais)
            {

                foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
                {
                    if (item.NfItemTributo.NfItemTributoIcms != null)
                    {

                        double valorIPI = 0;
                        if (item.NfItemTributo.NfItemTributoIpi != null)
                        {
                            valorIPI = item.NfItemTributo.NfItemTributoIpi.ValorIpi;
                        }


                        reg54 reg54Tmp = new reg54(nf.NfCliente.CnpjCpf, int.Parse(nf.ModeloDocFiscal), nf.Serie.ToString(), nf.Numero, item.Cfop, item.NfProduto.NfProdutoIcms.Origem.ToString() + item.NfProduto.NfProdutoIcms.Cst,
                            item.NumeroItem, item.NfProduto.Codigo, item.NfProduto.QuantidadeTributavel, item.NfProduto.ValorTotalTributavel, item.NfProduto.ValorDesconto,
                            item.NfItemTributo.NfItemTributoIcms.ValorBc, item.NfItemTributo.NfItemTributoIcms.ValorBcSt, valorIPI, item.NfItemTributo.NfItemTributoIcms.Aliquota);

                        arq.addReg54(reg54Tmp);
                    }
                }

            }

        }

        private void GenerateReg75(List<NfPrincipalClass> notasFiscais, ref ArquivoMagnetico arq)
        {
            //[0] -> Data Inicial
            //[1] -> Data Final

            Dictionary<ProdutoVigenciaClass, List<DateTime>> produtos = new Dictionary<ProdutoVigenciaClass, List<DateTime>>();


            foreach (NfPrincipalClass nf in notasFiscais)
            {
                foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
                {
                    ProdutoVigenciaClass prodTmp = new ProdutoVigenciaClass();
                    if (item.NfItemTributo.NfItemTributoIcms != null)
                    {
                        prodTmp.AloquotaICMS = item.NfItemTributo.NfItemTributoIcms.Aliquota;
                        prodTmp.ReducaoBCICms = item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc;
                        prodTmp.BaseCalculoICMSST = (item.NfItemTributo.NfItemTributoIcms.ValorBcSt / item.NfProduto.QuantidadeTributavel);
                    }

                    if (item.NfItemTributo.NfItemTributoIpi != null)
                    {
                        prodTmp.AloquotaIPI = item.NfItemTributo.NfItemTributoIpi.Aliquota;
                    }
                 
              
                    prodTmp.Codigo = item.NfProduto.Codigo;
                    prodTmp.Descricao = item.NfProduto.Descricao;
                    prodTmp.NCM = item.NfProduto.Ncm;
                 
                    prodTmp.Unidade = item.NfProduto.UnidadeTributacao;


                    if (produtos.ContainsKey(prodTmp))
                    {
                        if (nf.DataEmissao.Date < produtos[prodTmp][0].Date)
                        {
                            produtos[prodTmp][0]= nf.DataEmissao.Date;
                        }
                        else
                        {
                            if (nf.DataEmissao.Date > produtos[prodTmp][1].Date)
                            {
                                produtos[prodTmp][1] = nf.DataEmissao.Date;
                            }
                        }
                    }
                    else
                    {
                        produtos.Add(prodTmp, new List<DateTime>() { nf.DataEmissao.Date, nf.DataEmissao.Date });
                    }
                }
            }

            foreach (KeyValuePair<ProdutoVigenciaClass, List<DateTime>> prod in produtos)
            {
                reg75 reg75Tmp = new reg75(prod.Value[0], prod.Value[1], prod.Key.Codigo, prod.Key.NCM, prod.Key.Descricao, prod.Key.Unidade, prod.Key.AloquotaIPI,
                    prod.Key.AloquotaICMS, prod.Key.ReducaoBCICms, prod.Key.BaseCalculoICMSST);
                arq.addReg75(reg75Tmp);
            }
        }
    }

    internal class CfopAliquotaPair
    {
        internal long Cfop { get; set; }
        internal double Aliquota { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            CfopAliquotaPair castObj = (CfopAliquotaPair)obj;
            return (castObj != null) &&
               this.Aliquota == castObj.Aliquota &&
               this.Cfop == castObj.Cfop;
        }

        public override int GetHashCode()
        {

            return ((this.Aliquota.ToString(CultureInfo.InvariantCulture) + this.Cfop.ToString(CultureInfo.InvariantCulture)).GetHashCode());
        }
    }

    internal class ProdutoVigenciaClass
    {
        internal string Codigo { get; set; }
        internal string NCM { get; set; }
        internal string Descricao { get; set; }
        internal string Unidade { get; set; }
        internal double AloquotaIPI { get; set; }
        internal double AloquotaICMS { get; set; }
        internal double ReducaoBCICms { get; set; }
        internal double BaseCalculoICMSST { get; set; }


        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            ProdutoVigenciaClass castObj = (ProdutoVigenciaClass)obj;
            return (castObj != null) &&
               this.Codigo == castObj.Codigo &&
               this.NCM == castObj.NCM &&
               this.Descricao == castObj.Descricao &&
               this.Unidade == castObj.Unidade &&
               this.AloquotaIPI == castObj.AloquotaIPI &&
               this.AloquotaICMS == castObj.AloquotaICMS &&
               this.ReducaoBCICms == castObj.ReducaoBCICms &&
               this.BaseCalculoICMSST == castObj.BaseCalculoICMSST;
        }

        public override int GetHashCode()
        {
            string tmp = this.Codigo + this.NCM + this.Descricao + this.Unidade + this.AloquotaIPI.ToString(CultureInfo.InvariantCulture) + this.AloquotaICMS.ToString(CultureInfo.InvariantCulture) + this.ReducaoBCICms.ToString(CultureInfo.InvariantCulture) + this.BaseCalculoICMSST.ToString(CultureInfo.InvariantCulture);


            return tmp.GetHashCode();
        }
    }
}
