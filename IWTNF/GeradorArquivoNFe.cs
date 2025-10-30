#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using IWTNF.Entidades;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;

#endregion

namespace IWTNF
{
    public enum VersaoLayoutNF { Layout11, Layout20,Layout3_10, Todos };
    

    public class GeradorArquivoNFe
    {
        public const int CODIGO_BRASIL = 1058;

        public GeradorArquivoNFe()
        {

        }

        public void Generate(List<NfPrincipalClass> notasFiscais, List<string> fileName, VersaoLayoutNF versaoLayout)
        {
            StreamWriter writer = null;
            try
            {
                if (versaoLayout == VersaoLayoutNF.Todos && fileName.Count < 2)
                {
                    throw new Exception("É necessário indicar os nomes de arquivo para os dois layouts de nfe selecionados.");
                }

                switch (versaoLayout)
                {
                    case VersaoLayoutNF.Layout11:
                    case VersaoLayoutNF.Layout20:
                    case VersaoLayoutNF.Layout3_10:
                        writer = new StreamWriter(fileName[0]);
                        writer.AutoFlush = true;
                        writer.Write(this.Generate(notasFiscais, versaoLayout));
                        writer.Close();
                        break;

                    case VersaoLayoutNF.Todos:
                        writer = new StreamWriter(fileName[0]);
                        writer.AutoFlush = true;
                        writer.Write(this.Generate(notasFiscais, VersaoLayoutNF.Layout11));
                        writer.Close();

                        writer = new StreamWriter(fileName[1]);
                        writer.AutoFlush = true;
                        writer.Write(this.Generate(notasFiscais, VersaoLayoutNF.Layout20));
                        writer.Close();

                        writer = new StreamWriter(fileName[1]);
                        writer.AutoFlush = true;
                        writer.Write(this.Generate(notasFiscais, VersaoLayoutNF.Layout3_10));
                        writer.Close();

                        break;
                }

                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao escrever o arquivo de NFe.\r\n" + e.Message);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public string Generate(List<NfPrincipalClass> notasFiscais, VersaoLayoutNF versaoLayout)
        {
            try
            {
                string fileContents = "";


                //Cabeçalho
                fileContents += "NOTA FISCAL|" + notasFiscais.Count.ToString() + "\r\n";

                //Notas
                foreach (NfPrincipalClass nf in notasFiscais)
                {
                    switch (versaoLayout)
                    {
                        case VersaoLayoutNF.Layout11:
                            fileContents += this.generateNFe11(nf);
                            break;
                        case VersaoLayoutNF.Layout20:
                            fileContents += this.generateNFe(nf);
                            break;

                        case VersaoLayoutNF.Layout3_10:
                            fileContents += this.generateNFe310(nf);
                            break;
                        case VersaoLayoutNF.Todos:
                            throw new Exception("Não é possível gerar a nfe ao mesmo para os layouts selecionados");
                            break;

                    }
                }

                return fileContents;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o arquivo de NFe.\r\n" + e.Message);
            }
        }


        #region Layout 2.0
        private string generateNFe(NfPrincipalClass nf)
        {
            string toRet = "A|2.00|" + nf.NfAtributo.IdNfe + "|\r\n";
            string codUf = nf.NfEmitente.NfEmitenteEndereco.CodMunicipio.ToString().Substring(0, 2);

            string DataSaidaTmp;
            if (nf.DataSaidaEntrada != null && nf.DataSaidaEntrada != new DateTime(0) )
            {
                DataSaidaTmp = nf.DataSaidaEntrada.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                DataSaidaTmp = "";
            }
            toRet += "B|" + codUf + "||" + nf.NaturezaOperacao + "|" + (int)nf.FormaPagamento + "|" + nf.ModeloDocFiscal + "|" + nf.Serie + "|" + nf.Numero + "|" + nf.DataEmissao.ToString("yyyy-MM-dd") + "|" + DataSaidaTmp + "|" + nf.DataEmissao.ToString("HH:mm:ss") + "|" + (int)nf.Tipo + "|" + nf.CodMunicipioFatoGerador + "|" + (int)nf.FormatoImpressao + "|" + (int)nf.FormaEmissao + "||" + (int)nf.IdentificacaoAmbiente + "|" + (int)nf.FinalidadeEmissao + "|" + (int)nf.ProcessoEmissao + "|" + nf.VersaoProcessoEmissao + "|||\r\n";

            toRet += "C|" + nf.NfEmitente.Razao + "|" + nf.NfEmitente.NomeFantasia + "|" + nf.NfEmitente.Ie + "|" + nf.NfEmitente.IeSt + "|" + nf.NfEmitente.Im + "|" + nf.NfEmitente.Cnae + "|" + nf.NfEmitente.Crt.ToString() + "|\r\n";
            if (nf.NfEmitente.CnpjCpf.Length == 14)
            {
                toRet += "C02|" + nf.NfEmitente.CnpjCpf + "|\r\n";
            }
            else
            {
                toRet += "C02a|" + nf.NfEmitente.CnpjCpf + "|\r\n";
            }

            string codMunicipioString = nf.NfEmitente.NfEmitenteEndereco.CodMunicipio.ToString();
            if (nf.NfEmitente.NfEmitenteEndereco.CodMunicipio == 0) codMunicipioString = "";

            string codPaisString = nf.NfEmitente.NfEmitenteEndereco.CodPais.ToString();
            if (nf.NfEmitente.NfEmitenteEndereco.CodPais == 0) codPaisString = "";

            toRet += "C05|" + nf.NfEmitente.NfEmitenteEndereco.Logradouro + "|" + nf.NfEmitente.NfEmitenteEndereco.Numero + "|" + nf.NfEmitente.NfEmitenteEndereco.Complemento + "|" + nf.NfEmitente.NfEmitenteEndereco.Bairro + "|" + codMunicipioString + "|" + nf.NfEmitente.NfEmitenteEndereco.NomeMunicipio + "|" + nf.NfEmitente.NfEmitenteEndereco.SiglaUf + "|" + nf.NfEmitente.NfEmitenteEndereco.Cep + "|" + codPaisString + "|" + nf.NfEmitente.NfEmitenteEndereco.NomePais + "|" + nf.NfEmitente.NfEmitenteEndereco.Telefone + "|\r\n";

            toRet += "E|" + nf.NfCliente.Razao + "|" + nf.NfCliente.Ie + "|" + nf.NfCliente.Isuf + "|" + nf.NfCliente.Email + "|\r\n";
            if (nf.NfCliente.CnpjCpf.Length == 14 || nf.NfCliente.NfClienteEndereco.CodPais != CODIGO_BRASIL)
            {
                toRet += "E02|" + nf.NfCliente.CnpjCpf + "|\r\n";
            }
            else
            {
                toRet += "E03|" + nf.NfCliente.CnpjCpf + "|\r\n";
            }

            codMunicipioString = nf.NfCliente.NfClienteEndereco.CodMunicipio.ToString();
            if (nf.NfCliente.NfClienteEndereco.CodMunicipio == 0) codMunicipioString = "";

            codPaisString = nf.NfCliente.NfClienteEndereco.CodPais.ToString();
            if (nf.NfCliente.NfClienteEndereco.CodPais == 0) codPaisString = "";


            toRet += "E05|" + nf.NfCliente.NfClienteEndereco.Logradouro + "|" + nf.NfCliente.NfClienteEndereco.Numero + "|" + nf.NfCliente.NfClienteEndereco.Complemento + "|" + nf.NfCliente.NfClienteEndereco.Bairro + "|" + codMunicipioString + "|" + nf.NfCliente.NfClienteEndereco.NomeMunicipio + "|" + nf.NfCliente.NfClienteEndereco.SiglaUf + "|" + nf.NfCliente.NfClienteEndereco.Cep + "|" + codPaisString + "|" + nf.NfCliente.NfClienteEndereco.NomePais + "|" + nf.NfCliente.NfClienteEndereco.Telefone + "|\r\n";

            #region Itens
            foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
            {
                toRet += "H|" + item.NumeroItem + "|" + item.InformacoesAdd + "|\r\n";
                string freteTeste = "";
                if (item.NfProduto.ValorFrete != 0)
                {
                    freteTeste = item.NfProduto.ValorFrete.ToString("F2", CultureInfo.InvariantCulture);
                }

                toRet += "I|" + item.NfProduto.Codigo + "|" + item.NfProduto.Gtin + "|" + item.NfProduto.Descricao + "|" + item.NfProduto.Ncm + "|" + item.NfProduto.Extipi + "|" + item.Cfop + "|" + item.NfProduto.Unidade + "|" + item.NfProduto.QuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorUnitario.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfProduto.GtimUnidadeTrinutacao + "|" + item.NfProduto.UnidadeTributacao + "|" + item.NfProduto.QuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorUnitarioTrinutacao.ToString("F4", CultureInfo.InvariantCulture) + "|" + freteTeste + "||||1|||\r\n";

                toRet += "M|\r\n";
                if (item.NfItemTributo.NfItemTributoIcms != null)
                {
                    string redBaseSTString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt != 0)
                    {
                        redBaseSTString = item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    string redBaseString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc != 0)
                    {
                        redBaseString = item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    string percentualBCOPString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualBcOperacaoPropria != 0)
                    {
                        percentualBCOPString = item.NfItemTributo.NfItemTributoIcms.PercentualBcOperacaoPropria.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    string percentualMvaStString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt != 0)
                    {
                        percentualMvaStString = item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture);
                    }


                    toRet += "N|\r\n";
                    switch (item.NfItemTributo.NfItemTributoIcms.Cst)
                    {
                        case "00":
                            toRet += "N02|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "10":
                            toRet += "N03|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "20":
                            toRet += "N04|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "30":
                            toRet += "N05|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "40":
                        case "41":
                        case "50":
                            toRet += "N06|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|||";
                            break;
                        case "51":
                            toRet += "N07|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "60":
                            toRet += "N08|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "70":
                            toRet += "N09|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "90":
                            toRet += "N10|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "10a":
                        case "90a":
                            toRet += "N10a|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst.Substring(0, 2) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + percentualBCOPString + "|" + item.NfItemTributo.NfItemTributoIcms.SiglaUfDevidoIcms + "|";
                            break;
                        case "41a":
                            toRet += "N10b|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst.Substring(0, 2) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "SN":
                            //Tratamento especial do Simples Nacional
                            if (nf.NfEmitente.Crt == 1)
                            {
                                switch (item.NfItemTributo.NfItemTributoIcms.CsoSimples)
                                {
                                    case 101:
                                        toRet += "N10c|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 102:
                                    case 103:
                                    case 300:
                                    case 400:
                                        toRet += "N10d|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|";
                                        break;
                                    case 201:
                                        toRet += "N10e|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 202:
                                    case 203:
                                        toRet += "N10f|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 500:
                                        toRet += "N10g|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 900:
                                        toRet += "N10h|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;



                                }
                            }
                            else
                            {
                                throw new Exception("O item " + item.NfProduto.Codigo + " está configurado para ser faturado pelo simples, mas o emitente não está.");
                            }
                            break;
                        default:
                            throw new Exception("CST do ICMS inválido");
                            break;
                    }
                    toRet += "\r\n";
                }

                if (item.NfItemTributo.NfItemTributoIpi != null)
                {
                    toRet += "O|" + item.NfItemTributo.NfItemTributoIpi.ClasseEnquadramentoCigarrosBebidas + "|" + item.NfItemTributo.NfItemTributoIpi.CnpjProdutor + "|" + item.NfItemTributo.NfItemTributoIpi.CodigoSeloControle + "|" + item.NfItemTributo.NfItemTributoIpi.QuantidadeSeloControle + "|999|\r\n";

                    if (item.NfItemTributo.NfItemTributoIpi.Cst == "00" || item.NfItemTributo.NfItemTributoIpi.Cst == "49" || item.NfItemTributo.NfItemTributoIpi.Cst == "50" || item.NfItemTributo.NfItemTributoIpi.Cst == "99")
                    {
                        toRet += "O07|" + item.NfItemTributo.NfItemTributoIpi.Cst + "|" + item.NfItemTributo.NfItemTributoIpi.ValorIpi.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                        toRet += "O10|" + item.NfItemTributo.NfItemTributoIpi.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIpi.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";

                    }
                    else
                    {
                        toRet += "O08|" + item.NfItemTributo.NfItemTributoIpi.Cst + "|\r\n";
                    }
                }

                if (item.NfItemTributo.NfItemTributoIimp != null)
                {
                    toRet += "P|" + item.NfItemTributo.NfItemTributoIimp.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorDespesasAduaneiras.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorIimp.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorIof.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                }

                if (item.NfItemTributo.NfItemTributoIss != null)
                {
                    toRet += "U|" + item.NfProduto.ValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.ValorIss.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.CodMunicipioFatoGerador.ToString() + "|" + item.NfItemTributo.NfItemTributoIss.CodigoServico.ToString() + "||\r\n";


                }

                if (item.NfItemTributo.NfItemTributoPis != null)
                {
                    toRet += "Q|\r\n";
                    switch (item.NfItemTributo.NfItemTributoPis.Cst)
                    {
                        case "01":
                        case "02":
                            toRet += "Q02|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "03":
                            toRet += "Q03|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            toRet += "Q04|" + item.NfItemTributo.NfItemTributoPis.Cst + "|\r\n";
                            break;
                        case "99":
                            toRet += "Q05|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            switch ((ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), item.NfItemTributo.NfItemTributoPis.ModalidadeTributacao))
                            {
                                case ModalidadeTributacao.Valor:
                                    toRet += "Q07|" + item.NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet += "Q10|" + item.NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                            }
                            break;
                    }
                }

                if (item.NfItemTributo.NfItemTributoCofins != null)
                {
                    toRet += "S|\r\n";
                    switch (item.NfItemTributo.NfItemTributoCofins.Cst)
                    {
                        case "01":
                        case "02":
                            toRet += "S02|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "03":
                            toRet += "S03|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            toRet += "S04|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|\r\n";
                            break;
                        case "99":
                            toRet += "S05|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            switch ((ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), item.NfItemTributo.NfItemTributoCofins.ModalidadeTributacao))
                            {
                                case ModalidadeTributacao.Valor:
                                    toRet += "S07|" + item.NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet += "S10|" + item.NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                            }
                            break;
                    }
                }

             


            }
            #endregion

            toRet += "W|\r\n";
            toRet += "W02|" + nf.NfTotais.BaseCalculoIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.BaseCalculoIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalProdutosServicosIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalFrete.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalSeguro.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalDesconto.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIimp.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIpi.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalPis.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalCofins.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.OutrasDespesas.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalNf.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";

            if (nf.NfTransporte != null)
            {
                toRet += "X|" + (int)nf.NfTransporte.Modalidade + "|\r\n";
                toRet += "X03|" + nf.NfTransporte.Razao + "|" + nf.NfTransporte.Ie + "|" + nf.NfTransporte.Endereco + "|" + nf.NfTransporte.SiglaUf + "|" + nf.NfTransporte.Municipio + "|\r\n";
                
                

                if (nf.NfTransporte.CpfCnpj != null && nf.NfTransporte.CpfCnpj.Length == 14)
                {
                    toRet += "X04|" + nf.NfTransporte.CpfCnpj + "|\r\n";
                }
                else
                {
                    toRet += "X05|" + nf.NfTransporte.CpfCnpj + "|\r\n";
                }

                /*if (nf.NfTransporte.retencaoICMS)
                {
                    //X11|VServ|VBCRet|PICMSRet|VICMSRet|CFOP|CMunFG|
                    toRet += "X11|" + nf.NfTransporte.valorServico.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.bcRetencaoIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.aliquotaRetencao.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.valorICMSRetido.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.cfopRetencao.ToString() + "|" + nf.NfTransporte.codMuninicipioFatoGerador.ToString() + "|\r\n";
                }*/

                if (nf.NfTransporte.Placa != null && nf.NfTransporte.SiglaUfVeiculo != null)
                {

                    toRet += "X18|" + nf.NfTransporte.Placa + "|" + nf.NfTransporte.SiglaUfVeiculo + "|" + nf.NfTransporte.RegistroAntt + "|\r\n";
                }

                if (nf.NfTransporte.Volumes > 0)
                {
                    toRet += "X26|" + nf.NfTransporte.Volumes.ToString() + "|VOLUMES|||" + (nf.NfTransporte.PesoLiquido.HasValue ? nf.NfTransporte.PesoLiquido.Value.ToString("F3", CultureInfo.InvariantCulture) : "") + "|" +
                             (nf.NfTransporte.PesoBruto.HasValue ? nf.NfTransporte.PesoBruto.Value.ToString("F3", CultureInfo.InvariantCulture) : "") + "|\r\n";
                }
            }

            string obsCob = "";
            if (nf.NfCobranca != null)
            {
                if (nf.NfCobranca.NfFatura != null || nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Count > 0)
                {
                    toRet += "Y|\r\n";
                    if (nf.NfCobranca.NfFatura != null)
                    {
                        toRet += "Y02|" + nf.NfCobranca.NfFatura.Numero + "|" + nf.NfCobranca.NfFatura.ValorOriginal.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfCobranca.NfFatura.Desconto.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfCobranca.NfFatura.ValorLiquido.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                    }
                    foreach (NfDuplicataClass dup in nf.NfCobranca.CollectionNfDuplicataClassNfCobranca)
                    {
                        toRet += "Y07|" + dup.Numero + "|" + dup.Vencimento.ToString("yyyy-MM-dd") + "|" + dup.Valor.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                    }
                }

                foreach (NfDuplicataClass dup in nf.NfCobranca.CollectionNfDuplicataClassNfCobranca)
                {
                    obsCob += " - " + dup.Numero + " - " + dup.Vencimento.ToString("dd/MM/yyyy") + " - R$ " + dup.Valor.ToString("F2", CultureInfo.CurrentCulture);
                }

                if (obsCob.Length > 0)
                {
                    obsCob = obsCob.Substring(3);
                }

            }


            if (!string.IsNullOrEmpty(nf.Observacoes) || !string.IsNullOrEmpty(obsCob))
            {
                toRet += "Z||" + (nf.Observacoes ?? "").Replace("\r", " ").Replace("\n", "") + " " + obsCob + "|\r\n";
            }


            return this.stringCleaner(toRet) + "\r\n";
        }
        #endregion

        #region Layout 1.1
        private string generateNFe11(NfPrincipalClass nf)
        {
            string toRet = "A|1.10|" + nf.NfAtributo.IdNfe + "|\r\n";
            string codUf = nf.NfEmitente.NfEmitenteEndereco.CodMunicipio.ToString().Substring(0, 2);

            string DataSaidaTmp;
            if (nf.DataSaidaEntrada != null && nf.DataSaidaEntrada != new DateTime(0))
            {
                DataSaidaTmp = nf.DataSaidaEntrada.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                DataSaidaTmp = "";
            }
            toRet += "B|" + codUf + "||" + nf.NaturezaOperacao + "|" + (int)nf.FormaPagamento + "|" + nf.ModeloDocFiscal + "|" + nf.Serie + "|" + nf.Numero + "|" + nf.DataEmissao.ToString("yyyy-MM-dd") + "|" + DataSaidaTmp + "|" + (int)nf.Tipo + "|" + nf.CodMunicipioFatoGerador + "|" + (int)nf.FormatoImpressao + "|" + (int)nf.FormaEmissao + "||" + (int)nf.IdentificacaoAmbiente + "|" + (int)nf.FinalidadeEmissao + "|" + (int)nf.ProcessoEmissao + "|" + nf.VersaoProcessoEmissao + "|\r\n";

            toRet += "C|" + nf.NfEmitente.Razao + "|" + nf.NfEmitente.NomeFantasia + "|" + nf.NfEmitente.Ie + "|" + nf.NfEmitente.IeSt + "|" + nf.NfEmitente.Im + "|" + nf.NfEmitente.Cnae + "|\r\n";
            if (nf.NfEmitente.CnpjCpf.Length == 14)
            {
                toRet += "C02|" + nf.NfEmitente.CnpjCpf + "|\r\n";
            }
            else
            {
                toRet += "C02a|" + nf.NfEmitente.CnpjCpf + "|\r\n";
            }

            string codMunicipioString = nf.NfEmitente.NfEmitenteEndereco.CodMunicipio.ToString();
            if (nf.NfEmitente.NfEmitenteEndereco.CodMunicipio == 0) codMunicipioString = "";

            string codPaisString = nf.NfEmitente.NfEmitenteEndereco.CodPais.ToString();
            if (nf.NfEmitente.NfEmitenteEndereco.CodPais == 0) codPaisString = "";

            toRet += "C05|" + nf.NfEmitente.NfEmitenteEndereco.Logradouro + "|" + nf.NfEmitente.NfEmitenteEndereco.Numero + "|" + nf.NfEmitente.NfEmitenteEndereco.Complemento + "|" + nf.NfEmitente.NfEmitenteEndereco.Bairro + "|" + codMunicipioString + "|" + nf.NfEmitente.NfEmitenteEndereco.NomeMunicipio + "|" + nf.NfEmitente.NfEmitenteEndereco.SiglaUf + "|" + nf.NfEmitente.NfEmitenteEndereco.Cep + "|" + codPaisString + "|" + nf.NfEmitente.NfEmitenteEndereco.NomePais + "|" + nf.NfEmitente.NfEmitenteEndereco.Telefone + "|\r\n";

            toRet += "E|" + nf.NfCliente.Razao + "|" + nf.NfCliente.Ie + "|" + nf.NfCliente.Isuf + "|\r\n";
            if (nf.NfCliente.CnpjCpf.Length == 14)
            {
                toRet += "E02|" + nf.NfCliente.CnpjCpf + "|\r\n";
            }
            else
            {
                toRet += "E03|" + nf.NfCliente.CnpjCpf + "|\r\n";
            }

            codMunicipioString = nf.NfCliente.NfClienteEndereco.CodMunicipio.ToString();
            if (nf.NfCliente.NfClienteEndereco.CodMunicipio == 0) codMunicipioString = "";

            codPaisString = nf.NfCliente.NfClienteEndereco.CodPais.ToString();
            if (nf.NfCliente.NfClienteEndereco.CodPais == 0) codPaisString = "";


            toRet += "E05|" + nf.NfCliente.NfClienteEndereco.Logradouro + "|" + nf.NfCliente.NfClienteEndereco.Numero + "|" + nf.NfCliente.NfClienteEndereco.Complemento + "|" + nf.NfCliente.NfClienteEndereco.Bairro + "|" + codMunicipioString + "|" + nf.NfCliente.NfClienteEndereco.NomeMunicipio + "|" + nf.NfCliente.NfClienteEndereco.SiglaUf + "|" + nf.NfCliente.NfClienteEndereco.Cep + "|" + codPaisString + "|" + nf.NfCliente.NfClienteEndereco.NomePais + "|" + nf.NfCliente.NfClienteEndereco.Telefone + "\r\n";

            #region Itens
            foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
            {
                toRet += "H|" + item.NumeroItem + "|" + item.InformacoesAdd + "|\r\n";
                string freteTeste = "";
                if (item.NfProduto.ValorFrete != 0)
                {
                    freteTeste = item.NfProduto.ValorFrete.ToString("F2", CultureInfo.InvariantCulture);
                }

                toRet += "I|" + item.NfProduto.Codigo + "|" + item.NfProduto.Gtin + "|" + item.NfProduto.Descricao + "|" + item.NfProduto.Ncm + "|" + item.NfProduto.Extipi + "|" + item.NfProduto.Genero + "|" + item.Cfop + "|" + item.NfProduto.Unidade + "|" + item.NfProduto.QuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorUnitario.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfProduto.GtimUnidadeTrinutacao + "|" + item.NfProduto.UnidadeTributacao + "|" + item.NfProduto.QuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorUnitarioTrinutacao.ToString("F4", CultureInfo.InvariantCulture) + "|" + freteTeste + "|||\r\n";

                toRet += "M|\r\n";
                if (item.NfItemTributo.NfItemTributoIcms != null)
                {
                    string redBaseSTString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt != 0)
                    {
                        redBaseSTString = item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    toRet += "N|\r\n";
                    switch (item.NfItemTributo.NfItemTributoIcms.Cst)
                    {
                        case "00":
                            toRet += "N02|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "10":
                            toRet += "N03|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "20":
                            toRet += "N04|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "30":
                            toRet += "N05|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "40":
                        case "41":
                        case "50":
                            toRet += "N06|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|";
                            break;
                        case "51":
                            toRet += "N07|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "60":
                            toRet += "N08|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "70":
                            toRet += "N09|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "90":
                            toRet += "N10|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        default:
                            throw new Exception("CST do ICMS inválido");
                            break;
                    }
                    toRet += "\r\n";
                }

                if (item.NfItemTributo.NfItemTributoIpi != null)
                {
                    toRet += "O|" + item.NfItemTributo.NfItemTributoIpi.ClasseEnquadramentoCigarrosBebidas + "|" + item.NfItemTributo.NfItemTributoIpi.CnpjProdutor + "|" + item.NfItemTributo.NfItemTributoIpi.CodigoSeloControle + "|" + item.NfItemTributo.NfItemTributoIpi.QuantidadeSeloControle + "|999|\r\n";

                    if (item.NfItemTributo.NfItemTributoIpi.Cst == "00" || item.NfItemTributo.NfItemTributoIpi.Cst == "49" || item.NfItemTributo.NfItemTributoIpi.Cst == "50" || item.NfItemTributo.NfItemTributoIpi.Cst == "99")
                    {
                        toRet += "O07|" + item.NfItemTributo.NfItemTributoIpi.Cst + "|" + item.NfItemTributo.NfItemTributoIpi.ValorIpi.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                        toRet += "O10|" + item.NfItemTributo.NfItemTributoIpi.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIpi.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";

                    }
                    else
                    {
                        toRet += "O08|" + item.NfItemTributo.NfItemTributoIpi.Cst + "|\r\n";
                    }
                }

                if (item.NfItemTributo.NfItemTributoIimp != null)
                {
                    toRet += "P|" + item.NfItemTributo.NfItemTributoIimp.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorDespesasAduaneiras.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorIimp.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorIof.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                }

                if (item.NfItemTributo.NfItemTributoPis != null)
                {
                    toRet += "Q|\r\n";
                    switch (item.NfItemTributo.NfItemTributoPis.Cst)
                    {
                        case "01":
                        case "02":
                            toRet += "Q02|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "03":
                            toRet += "Q03|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            toRet += "Q04|" + item.NfItemTributo.NfItemTributoPis.Cst + "|\r\n";
                            break;
                        case "99":
                            toRet += "Q05|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            switch ((ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), item.NfItemTributo.NfItemTributoPis.ModalidadeTributacao))
                            {
                                case ModalidadeTributacao.Valor:
                                    toRet += "Q07|" + item.NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet += "Q10|" + item.NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                            }
                            break;
                    }
                }

                if (item.NfItemTributo.NfItemTributoCofins != null)
                {
                    toRet += "S|\r\n";
                    switch (item.NfItemTributo.NfItemTributoCofins.Cst)
                    {
                        case "01":
                        case "02":
                            toRet += "S02|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "03":
                            toRet += "S03|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            toRet += "S04|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|\r\n";
                            break;
                        case "99":
                            toRet += "S05|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            switch ((ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), item.NfItemTributo.NfItemTributoCofins.ModalidadeTributacao))
                            {
                                case ModalidadeTributacao.Valor:
                                    toRet += "S07|" + item.NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet += "S10|" + item.NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                            }
                            break;
                    }
                }

                if (item.NfItemTributo.NfItemTributoIss != null)
                {
                    toRet += "U|" + item.NfProduto.ValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.ValorIss.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.CodMunicipioFatoGerador.ToString() + "|" + item.NfItemTributo.NfItemTributoIss.CodigoServico.ToString() + "|\r\n";


                }


            }
            #endregion

            toRet += "W|\r\n";
            toRet += "W02|" + nf.NfTotais.BaseCalculoIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.BaseCalculoIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalProdutosServicosIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalFrete.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalSeguro.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalDesconto.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIimp.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIpi.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalPis.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalCofins.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.OutrasDespesas.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalNf.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";

            if (nf.NfTransporte != null)
            {
                toRet += "X|" + (int)nf.NfTransporte.Modalidade + "|\r\n";
                toRet += "X03|" + nf.NfTransporte.Razao + "|" + nf.NfTransporte.Ie + "|" + nf.NfTransporte.Endereco + "|" + nf.NfTransporte.SiglaUf + "|" + nf.NfTransporte.Municipio + "|\r\n";
                if (nf.NfTransporte.CpfCnpj != null && nf.NfTransporte.CpfCnpj.Length == 14)
                {
                    toRet += "X04|" + nf.NfTransporte.CpfCnpj + "|\r\n";
                }
                else
                {
                    toRet += "X05|" + nf.NfTransporte.CpfCnpj + "|\r\n";
                }

                /*if (nf.NfTransporte.retencaoICMS)
                {
                    //X11|VServ|VBCRet|PICMSRet|VICMSRet|CFOP|CMunFG|
                    toRet += "X11|" + nf.NfTransporte.valorServico.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.bcRetencaoIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.aliquotaRetencao.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.valorICMSRetido.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.cfopRetencao.ToString() + "|" + nf.NfTransporte.codMuninicipioFatoGerador.ToString() + "|\r\n";
                }*/

                if (nf.NfTransporte.Placa != null && nf.NfTransporte.SiglaUfVeiculo != null)
                {

                    toRet += "X18|" + nf.NfTransporte.Placa + "|" + nf.NfTransporte.SiglaUfVeiculo + "|" + nf.NfTransporte.RegistroAntt + "|\r\n";
                }

                if (nf.NfTransporte.Volumes > 0)
                {
                    toRet += "X26|" + nf.NfTransporte.Volumes.ToString() + "|VOLUMES|||" + (nf.NfTransporte.PesoLiquido.HasValue ? nf.NfTransporte.PesoLiquido.Value.ToString("F3", CultureInfo.InvariantCulture) : "") + "|" +
                             (nf.NfTransporte.PesoBruto.HasValue ? nf.NfTransporte.PesoBruto.Value.ToString("F3", CultureInfo.InvariantCulture) : "") + "|\r\n";
                }
            }

            string obsCob = "";
            if (nf.NfCobranca != null)
            {
                if (nf.NfCobranca.NfFatura != null || nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Count > 0)
                {
                    toRet += "Y|\r\n";
                    if (nf.NfCobranca.NfFatura != null)
                    {
                        toRet += "Y02|" + nf.NfCobranca.NfFatura.Numero + "|" + nf.NfCobranca.NfFatura.ValorOriginal.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfCobranca.NfFatura.Desconto.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfCobranca.NfFatura.ValorLiquido.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                    }
                    foreach (NfDuplicataClass dup in nf.NfCobranca.CollectionNfDuplicataClassNfCobranca)
                    {
                        toRet += "Y07|" + dup.Numero + "|" + dup.Vencimento.ToString("yyyy-MM-dd") + "|" + dup.Valor.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                    }
                }

                foreach (NfDuplicataClass dup in nf.NfCobranca.CollectionNfDuplicataClassNfCobranca)
                {
                    obsCob += " - " + dup.Numero + " - " + dup.Vencimento.ToString("dd/MM/yyyy") + " - R$ " + dup.Valor.ToString("F2", CultureInfo.CurrentCulture);
                }

                if (obsCob.Length > 0)
                {
                    obsCob = obsCob.Substring(3);
                }

            }


            if (!string.IsNullOrEmpty(nf.Observacoes) || !string.IsNullOrEmpty(obsCob))
            {
                toRet += "Z||" + (nf.Observacoes ?? "").Replace("\r", " ").Replace("\n", "") + " " + obsCob + "|\r\n";
            }


            return this.stringCleaner(toRet) + "\r\n";
        }
        #endregion

        #region Layout 3.10
        private string generateNFe310(NfPrincipalClass nf)
        {
            string toRet = "A|3.10|" + nf.NfAtributo.IdNfe + "||\r\n";
            string codUf = nf.NfEmitente.NfEmitenteEndereco.CodMunicipio.ToString().Substring(0, 2);

            string DataSaidaTmp;
            if (nf.DataSaidaEntrada != null && nf.DataSaidaEntrada != new DateTime(0))
            {
                DataSaidaTmp = nf.DataSaidaEntrada.Value.ToString("yyyy-MM-ddTHH:mm:sszzz");
            }
            else
            {
                DataSaidaTmp = "";
            }

             int destino = 1;
                    if (nf.NfCliente.NfClienteEndereco.CodPais == nf.NfEmitente.NfEmitenteEndereco.CodPais)
                    {
                        if (nf.NfCliente.NfClienteEndereco.SiglaUf == nf.NfEmitente.NfEmitenteEndereco.SiglaUf)
                        {
                            destino = 1;
                        }
                        else
                        {
                            destino = 2;
                        }
                    }
                    else
                    {
                        destino = 3;
                    }

            toRet += "B|" + codUf + "||" + nf.NaturezaOperacao + "|" + (int) nf.FormaPagamento + "|" + nf.ModeloDocFiscal + "|" + nf.Serie + "|" + nf.Numero + "|" + nf.DataEmissao.ToString("yyyy-MM-ddTHH:mm:sszzz") + "|" + DataSaidaTmp + "|" +
                     (int) nf.Tipo + "|" + destino + "|" + nf.CodMunicipioFatoGerador + "|" + (int) nf.FormatoImpressao + "|" + (int) nf.FormaEmissao + "||" + (int) nf.IdentificacaoAmbiente + "|" + (int) nf.FinalidadeEmissao + "|" +
                     (nf.ConsumidorFinal ? 1 : 0) + "|" + (int) nf.PresencaComprador + "|" + (int) nf.ProcessoEmissao + "|" + nf.VersaoProcessoEmissao + "|||\r\n";

            toRet += "C|" + nf.NfEmitente.Razao + "|" + nf.NfEmitente.NomeFantasia + "|" + nf.NfEmitente.Ie + "|" + nf.NfEmitente.IeSt + "|" + nf.NfEmitente.Im + "|" + nf.NfEmitente.Cnae + "|" + nf.NfEmitente.Crt.ToString() + "|\r\n";
            if (nf.NfEmitente.CnpjCpf.Length == 14)
            {
                toRet += "C02|" + nf.NfEmitente.CnpjCpf + "|\r\n";
            }
            else
            {
                toRet += "C02a|" + nf.NfEmitente.CnpjCpf + "|\r\n";
            }

            string codMunicipioString = nf.NfEmitente.NfEmitenteEndereco.CodMunicipio.ToString();
            if (nf.NfEmitente.NfEmitenteEndereco.CodMunicipio == 0) codMunicipioString = "";

            string codPaisString = nf.NfEmitente.NfEmitenteEndereco.CodPais.ToString();
            if (nf.NfEmitente.NfEmitenteEndereco.CodPais == 0) codPaisString = "";

            toRet += "C05|" + nf.NfEmitente.NfEmitenteEndereco.Logradouro + "|" + nf.NfEmitente.NfEmitenteEndereco.Numero + "|" + nf.NfEmitente.NfEmitenteEndereco.Complemento + "|" + nf.NfEmitente.NfEmitenteEndereco.Bairro + "|" + codMunicipioString + "|" + nf.NfEmitente.NfEmitenteEndereco.NomeMunicipio + "|" + nf.NfEmitente.NfEmitenteEndereco.SiglaUf + "|" + nf.NfEmitente.NfEmitenteEndereco.Cep + "|" + codPaisString + "|" + nf.NfEmitente.NfEmitenteEndereco.NomePais + "|" + nf.NfEmitente.NfEmitenteEndereco.Telefone + "|\r\n";

            int indIEDest = 1;
            string IEDest = "";
            if (string.IsNullOrWhiteSpace(nf.NfCliente.Ie) || nf.NfCliente.Ie.Trim().ToUpper() == "ISENTO")
            {
                indIEDest = 2;
                IEDest = "";

            }
            else
            {
                indIEDest = 1;
                IEDest = nf.NfCliente.Ie.Trim();
            }


            toRet += "E|" + nf.NfCliente.Razao + "|" + indIEDest + "|" + IEDest + "|" + nf.NfCliente.Isuf + "|" + nf.NfCliente.Im + "|" + nf.NfCliente.Email + "|\r\n";
            if (nf.NfCliente.CnpjCpf.Length == 14 || nf.NfCliente.NfClienteEndereco.CodPais != CODIGO_BRASIL)
            {
                toRet += "E02|" + nf.NfCliente.CnpjCpf + "|\r\n";
            }
            else
            {
                toRet += "E03|" + nf.NfCliente.CnpjCpf + "|\r\n";
            }

            codMunicipioString = nf.NfCliente.NfClienteEndereco.CodMunicipio.ToString();
            if (nf.NfCliente.NfClienteEndereco.CodMunicipio == 0) codMunicipioString = "";

            codPaisString = nf.NfCliente.NfClienteEndereco.CodPais.ToString();
            if (nf.NfCliente.NfClienteEndereco.CodPais == 0) codPaisString = "";


            toRet += "E05|" + nf.NfCliente.NfClienteEndereco.Logradouro + "|" + nf.NfCliente.NfClienteEndereco.Numero + "|" + nf.NfCliente.NfClienteEndereco.Complemento + "|" + nf.NfCliente.NfClienteEndereco.Bairro + "|" + codMunicipioString + "|" + nf.NfCliente.NfClienteEndereco.NomeMunicipio + "|" + nf.NfCliente.NfClienteEndereco.SiglaUf + "|" + nf.NfCliente.NfClienteEndereco.Cep + "|" + codPaisString + "|" + nf.NfCliente.NfClienteEndereco.NomePais + "|" + nf.NfCliente.NfClienteEndereco.Telefone + "|\r\n";

            #region Itens
            foreach (NfItemClass item in nf.CollectionNfItemClassNfPrincipal)
            {
                toRet += "H|" + item.NumeroItem + "|" + item.InformacoesAdd + "|\r\n";
                string freteTeste = "";
                if (item.NfProduto.ValorFrete != 0)
                {
                    freteTeste = item.NfProduto.ValorFrete.ToString("F2", CultureInfo.InvariantCulture);
                }

                toRet += "I|" + item.NfProduto.Codigo + "|" + item.NfProduto.Gtin + "|" + item.NfProduto.Descricao + "|" + item.NfProduto.Ncm + "|" + item.NfProduto.Extipi + "|" + item.Cfop + "|" + item.NfProduto.Unidade + "|" + item.NfProduto.QuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorUnitario.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfProduto.GtimUnidadeTrinutacao + "|" + item.NfProduto.UnidadeTributacao + "|" + item.NfProduto.QuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture) + "|" + item.NfProduto.ValorUnitarioTrinutacao.ToString("F4", CultureInfo.InvariantCulture) + "|" + freteTeste + "||||1|||\r\n";

                toRet += "M|\r\n";
                if (item.NfItemTributo.NfItemTributoIcms != null)
                {
                    string redBaseSTString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt != 0)
                    {
                        redBaseSTString = item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    string redBaseString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc != 0)
                    {
                        redBaseString = item.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    string percentualBCOPString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualBcOperacaoPropria != 0)
                    {
                        percentualBCOPString = item.NfItemTributo.NfItemTributoIcms.PercentualBcOperacaoPropria.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    string percentualMvaStString = "";
                    if (item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt != 0)
                    {
                        percentualMvaStString = item.NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture);
                    }


                    toRet += "N|\r\n";
                    switch (item.NfItemTributo.NfItemTributoIcms.Cst)
                    {
                        case "00":
                            toRet += "N02|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "10":
                            toRet += "N03|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "20":
                            toRet += "N04|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "30":
                            toRet += "N05|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "40":
                        case "41":
                        case "50":
                            toRet += "N06|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|||";
                            break;
                        case "51":
                            toRet += "N07|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "60":
                            toRet += "N08|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "70":
                            toRet += "N09|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "90":
                            toRet += "N10|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "10a":
                        case "90a":
                            toRet += "N10a|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst.Substring(0, 2) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + percentualBCOPString + "|" + item.NfItemTributo.NfItemTributoIcms.SiglaUfDevidoIcms + "|";
                            break;
                        case "41a":
                            toRet += "N10b|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.Cst.Substring(0, 2) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture) + "|";
                            break;
                        case "SN":
                            //Tratamento especial do Simples Nacional
                            if (nf.NfEmitente.Crt == 1)
                            {
                                switch (item.NfItemTributo.NfItemTributoIcms.CsoSimples)
                                {
                                    case 101:
                                        toRet += "N10c|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 102:
                                    case 103:
                                    case 300:
                                    case 400:
                                        toRet += "N10d|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|";
                                        break;
                                    case 201:
                                        toRet += "N10e|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 202:
                                    case 203:
                                        toRet += "N10f|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 500:
                                        toRet += "N10g|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;
                                    case 900:
                                        toRet += "N10h|" + (int)item.NfItemTributo.NfItemTributoIcms.Origem + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + redBaseString + "|" + item.NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + (int)item.NfItemTributo.NfItemTributoIcms.ModalidadeBcSt + "|" + percentualMvaStString + "|" + redBaseSTString + "|" + item.NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.CsoSimples.ToString() + "|" + item.NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture) + "|";
                                        break;



                                }
                            }
                            else
                            {
                                throw new Exception("O item " + item.NfProduto.Codigo + " está configurado para ser faturado pelo simples, mas o emitente não está.");
                            }
                            break;
                        default:
                            throw new Exception("CST do ICMS inválido");
                            break;
                    }
                    toRet += "\r\n";
                }

                if (item.NfItemTributo.NfItemTributoIpi != null)
                {
                    toRet += "O|" + item.NfItemTributo.NfItemTributoIpi.ClasseEnquadramentoCigarrosBebidas + "|" + item.NfItemTributo.NfItemTributoIpi.CnpjProdutor + "|" + item.NfItemTributo.NfItemTributoIpi.CodigoSeloControle + "|" + item.NfItemTributo.NfItemTributoIpi.QuantidadeSeloControle + "|999|\r\n";

                    if (item.NfItemTributo.NfItemTributoIpi.Cst == "00" || item.NfItemTributo.NfItemTributoIpi.Cst == "49" || item.NfItemTributo.NfItemTributoIpi.Cst == "50" || item.NfItemTributo.NfItemTributoIpi.Cst == "99")
                    {
                        toRet += "O07|" + item.NfItemTributo.NfItemTributoIpi.Cst + "|" + item.NfItemTributo.NfItemTributoIpi.ValorIpi.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                        toRet += "O10|" + item.NfItemTributo.NfItemTributoIpi.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIpi.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";

                    }
                    else
                    {
                        toRet += "O08|" + item.NfItemTributo.NfItemTributoIpi.Cst + "|\r\n";
                    }
                }

                if (item.NfItemTributo.NfItemTributoIimp != null)
                {
                    toRet += "P|" + item.NfItemTributo.NfItemTributoIimp.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorDespesasAduaneiras.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorIimp.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIimp.ValorIof.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                }

                if (item.NfItemTributo.NfItemTributoIss != null)
                {
                    toRet += "U|" + item.NfProduto.ValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.ValorIss.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoIss.CodMunicipioFatoGerador.ToString() + "|" + item.NfItemTributo.NfItemTributoIss.CodigoServico.ToString() + "||\r\n";


                }

                if (item.NfItemTributo.NfItemTributoPis != null)
                {
                    toRet += "Q|\r\n";
                    switch (item.NfItemTributo.NfItemTributoPis.Cst)
                    {
                        case "01":
                        case "02":
                            toRet += "Q02|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "03":
                            toRet += "Q03|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            toRet += "Q04|" + item.NfItemTributo.NfItemTributoPis.Cst + "|\r\n";
                            break;
                        case "99":
                            toRet += "Q05|" + item.NfItemTributo.NfItemTributoPis.Cst + "|" + item.NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            switch ((ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), item.NfItemTributo.NfItemTributoPis.ModalidadeTributacao))
                            {
                                case ModalidadeTributacao.Valor:
                                    toRet += "Q07|" + item.NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet += "Q10|" + item.NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                            }
                            break;
                    }
                }

                if (item.NfItemTributo.NfItemTributoCofins != null)
                {
                    toRet += "S|\r\n";
                    switch (item.NfItemTributo.NfItemTributoCofins.Cst)
                    {
                        case "01":
                        case "02":
                            toRet += "S02|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "03":
                            toRet += "S03|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            break;

                        case "04":
                        case "06":
                        case "07":
                        case "08":
                        case "09":
                            toRet += "S04|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|\r\n";
                            break;
                        case "99":
                            toRet += "S05|" + item.NfItemTributo.NfItemTributoCofins.Cst + "|" + item.NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                            switch ((ModalidadeTributacao)Enum.ToObject(typeof(ModalidadeTributacao), item.NfItemTributo.NfItemTributoCofins.ModalidadeTributacao))
                            {
                                case ModalidadeTributacao.Valor:
                                    toRet += "S07|" + item.NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                                case ModalidadeTributacao.Quantidade:
                                    toRet += "S10|" + item.NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F2", CultureInfo.InvariantCulture) + "|" + item.NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                                    break;
                            }
                            break;
                    }
                }




            }
            #endregion

            toRet += "W|\r\n";
            toRet += "W02|" + nf.NfTotais.BaseCalculoIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.BaseCalculoIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIcmsSt.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalProdutosServicosIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalFrete.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalSeguro.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalDesconto.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIimp.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalIpi.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalPis.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalCofins.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.OutrasDespesas.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTotais.ValorTotalNf.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";

            if (nf.NfTransporte != null)
            {
                toRet += "X|" + (int)nf.NfTransporte.Modalidade + "|\r\n";
                toRet += "X03|" + nf.NfTransporte.Razao + "|" + nf.NfTransporte.Ie + "|" + nf.NfTransporte.Endereco + "|" + nf.NfTransporte.Municipio + "|" + nf.NfTransporte.SiglaUf + "|\r\n";



                if (nf.NfTransporte.CpfCnpj != null && nf.NfTransporte.CpfCnpj.Length == 14)
                {
                    toRet += "X04|" + nf.NfTransporte.CpfCnpj + "|\r\n";
                }
                else
                {
                    toRet += "X05|" + nf.NfTransporte.CpfCnpj + "|\r\n";
                }

                /*if (nf.NfTransporte.retencaoICMS)
                {
                    //X11|VServ|VBCRet|PICMSRet|VICMSRet|CFOP|CMunFG|
                    toRet += "X11|" + nf.NfTransporte.valorServico.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.bcRetencaoIcms.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.aliquotaRetencao.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.valorICMSRetido.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfTransporte.cfopRetencao.ToString() + "|" + nf.NfTransporte.codMuninicipioFatoGerador.ToString() + "|\r\n";
                }*/

                if (nf.NfTransporte.Placa != null && nf.NfTransporte.SiglaUfVeiculo != null)
                {

                    toRet += "X18|" + nf.NfTransporte.Placa + "|" + nf.NfTransporte.SiglaUfVeiculo + "|" + nf.NfTransporte.RegistroAntt + "|\r\n";
                }

                if (nf.NfTransporte.Volumes > 0)
                {
                    toRet += "X26|" + nf.NfTransporte.Volumes.ToString() + "|VOLUMES|||" + (nf.NfTransporte.PesoLiquido.HasValue ? nf.NfTransporte.PesoLiquido.Value.ToString("F3", CultureInfo.InvariantCulture) : "") + "|" +
                             (nf.NfTransporte.PesoBruto.HasValue ? nf.NfTransporte.PesoBruto.Value.ToString("F3", CultureInfo.InvariantCulture) : "") + "|\r\n";
                }
            }

            string obsCob = "";
            if (nf.NfCobranca != null)
            {
                if (nf.NfCobranca.NfFatura != null || nf.NfCobranca.CollectionNfDuplicataClassNfCobranca.Count > 0)
                {
                    toRet += "Y|\r\n";
                    if (nf.NfCobranca.NfFatura != null)
                    {
                        toRet += "Y02|" + nf.NfCobranca.NfFatura.Numero + "|" + nf.NfCobranca.NfFatura.ValorOriginal.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfCobranca.NfFatura.Desconto.ToString("F2", CultureInfo.InvariantCulture) + "|" + nf.NfCobranca.NfFatura.ValorLiquido.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                    }
                    foreach (NfDuplicataClass dup in nf.NfCobranca.CollectionNfDuplicataClassNfCobranca)
                    {
                        toRet += "Y07|" + dup.Numero + "|" + dup.Vencimento.ToString("yyyy-MM-dd") + "|" + dup.Valor.ToString("F2", CultureInfo.InvariantCulture) + "|\r\n";
                    }
                }

                foreach (NfDuplicataClass dup in nf.NfCobranca.CollectionNfDuplicataClassNfCobranca)
                {
                    obsCob += " - " + dup.Numero + " - " + dup.Vencimento.ToString("dd/MM/yyyy") + " - R$ " + dup.Valor.ToString("F2", CultureInfo.CurrentCulture);
                }

                if (obsCob.Length > 0)
                {
                    obsCob = obsCob.Substring(3);
                }

            }


            if (!string.IsNullOrEmpty(nf.Observacoes) || !string.IsNullOrEmpty(obsCob))
            {
                toRet += "Z|" + (nf.ObservacoesFisco ?? "").Replace("\r", " ").Replace("\n", "") + "|" + (nf.Observacoes ?? "").Replace("\r", " ").Replace("\n", "") + " " + obsCob + "|\r\n";
            }


            return this.stringCleaner(toRet) + "\r\n";
        }
        #endregion

        private string stringCleaner(string str)
        {
            //str = str.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(",", "").Replace("/", "");
            string C_acentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç '`´ø";

            string S_acentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc     ";

            for (int i = 0; i < C_acentos.Length; i++)

                str = str.Replace(C_acentos[i].ToString(), S_acentos[i].ToString()).Trim();

            //str = "Resultado = " + str;

            char[] strExploded = str.ToCharArray();
            for (int i = 0; i < strExploded.Length; i++)
            {
                int charCode = (int)strExploded[i];

                if ((charCode < 44 || (charCode > 57 && charCode < 65) || (charCode > 90 && charCode < 97) || charCode > 122) && (charCode != 10 && charCode != 12 && charCode != 32 && charCode != 124 && charCode != 36 && charCode != 58 && charCode != 64))
                {
                    strExploded[i] = ' ';
                }
            }

            return new String(strExploded);

        }
    }

}
