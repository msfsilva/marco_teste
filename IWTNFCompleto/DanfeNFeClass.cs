using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets;
using iTextSharp.text.pdf;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;
using TNFeInfNFeIdeTpNF = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeIdeTpNF;
using TNFeInfNFeTranspModFrete = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete;


namespace IWTNFCompleto
{
    public class DanfeNFeClass
    {
        public static bool IncluirDuplicatasObs { get; set; } = true;


        #region Principal/NFe
        public string DfeChaveAcesso { get; private set; }
        public string DfeNumeroNFe { get; private set; }
        public string DfeSerieNFe { get; private set; }
        public string DfeTipoNFe { get; private set; }
        public string DfeNaturezaOperacao { get; private set; }
        public string DfeProtocoloAutorizacaoUso { get; private set; }
        public byte[] Barcode { get; private set; }
        #endregion

        #region Emitente

        public string EmitRazaoSocial { get; private set; }
        public string EmitIncricaoEstadual { get; private set; }
        public string EmitIncricaoEstadualST { get; private set; }
        public string EmitCNPJ { get; private set; }
        public string EmitEndereco { get; private set; }
        public string EmitEndNumero { get; private set; }
        public string EmitEndComplemento { get; private set; }
        public string EmitBairro { get; private set; }
        public string EmitCidade { get; private set; }
        public string EmitUF { get; private set; }
        public string EmitPais { get; private set; }
        public string EmitCEP { get; private set; }
        public string EmitFone { get; private set; }
        public string EmitFax { get; private set; }
        public byte[] EmitLogo { get; private set; }

        #endregion

        #region Destinatário/Remetente

        public string RemetRazaoSocial { get; private set; }
        public string RemetCnpjCpf { get; private set; }
        public DateTime RemetDataEmissao { get; private set; }
        public string RemetEndereco { get; private set; }
        public string RemetEndNumero { get; private set; }
        public string RemetBairro { get; private set; }
        public string RemetCEP { get; private set; }
        public string RemetDataEntradaSaida { get; private set; } //DateTime?
        public string RemetCidade { get; private set; }
        public string RemetFoneFax { get; private set; }
        public string RemetUF { get; private set; }
        public string RemetIE { get; private set; }
        public string RemetHoraSaida { get; private set; }

        #endregion

        #region Fatura/Duplicatas

        public string FatNumero { get; private set; }
        public string FatValorOriginal { get; private set; } //double
        public string FatValorDesconto { get; private set; } //double
        public string FatValorLiquido { get; private set; } //double

        public List<DanfeNFeDuplicataClass> DfeDuplicatas { get; private set; }
        public List<DanfeDuplicatasDto> DfeDuplicatasDto { get; private set; }


        #endregion

        #region Cálculo do Imposto

        public double ImpBcIcms { get; private set; }
        public double ImpValorIcms { get; private set; }
        public double ImpBcIcmsSt { get; private set; }
        public double ImpValorIcmsSt { get; private set; }
        public double ImpValorTotalProdutos { get; private set; }
        public double ImpValorFrete { get; private set; }
        public double ImpValorSeguro { get; private set; }
        public double ImpDesconto { get; private set; }
        public double ImpOutrasDespesas { get; private set; }
        public double ImpValorTotalIpi { get; private set; }
        public double ImpValorTotalNF { get; private set; }

        #endregion

        #region Transportador/Volumes Trasportados

        public string TranspRazaoSocial { get; private set; }
        public string TranspResponsavelFrete { get; private set; }
        public string TranspCodigoANTT { get; private set; }
        public string TranspPlacaVeiculo { get; private set; }
        public string TranspPlacaVeiculoUF { get; private set; }
        public string TranspCnpjCpf { get; private set; }
        public string TranspEndereco { get; private set; }
        public string TranspCidade { get; private set; }
        public string TranspUF { get; private set; }
        public string TranspIE { get; private set; }
        public string TranspQuantidade { get; private set; }
        public string TranspEspecie { get; private set; }
        public string TranspMarca { get; private set; }
        public string TranspNumeracao { get; private set; }
        public string TranspPesoBruto { get; private set; }
        public string TranspPesoLiquido { get; private set; }

        #endregion

        #region Dados do Produto/Serviços

        public List<DanfeNFeItemClass> DfeItens { get; private set; }

        #endregion

        #region ISSQN

        public string IssInscricaoMunicipal { get; private set; }
        public string IssValorTotalServicos { get; private set; }
        public string IssBCIssqn { get; private set; }
        public string IssValorIssqn { get; private set; }

        #endregion

        #region Dados Adicionais

        public string DfeInformacoesComplementares { get; private set; }
        public string DfeReservadoFisco { get; private set; }



        #endregion





        public static List<DanfeNFeClass> preencheDanfe( List<BibliotecaDatasets.v4_0.TNfeProc> listNFV4, byte[] logoEmitente, bool imprimirZerosTributosVazios)
        {

            List<DanfeNFeClass> list = new List<DanfeNFeClass>();

            #region V4.0
            foreach (IWTNFCompleto.BibliotecaDatasets.v4_0.TNfeProc retNFe in listNFV4)
            {
                list.Add(preencheNfeV4(retNFe, logoEmitente, imprimirZerosTributosVazios));
            }

            #endregion
            
            return list;
        }



        private static DanfeNFeClass preencheNfeV4(BibliotecaDatasets.v4_0.TNfeProc retNFe, byte[] logoEmitente, bool imprimirZerosTributosVazios)
        {
            DanfeNFeClass danfe = new DanfeNFeClass();
            CultureInfo culturePtBr = new CultureInfo("pt-BR");
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe NFe = retNFe.NFe; //Classe NFe

            //Classes que compõe a NFe
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeIde identificacaoNFe = NFe.infNFe.ide;
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeEmit emitente = NFe.infNFe.emit;
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDest remetente = NFe.infNFe.dest;
            Collection<TNFeInfNFeDet> detalhes = NFe.infNFe.det;
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTotal totalNFe = NFe.infNFe.total;
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTransp transporte = NFe.infNFe.transp;
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeCobr cobranca = NFe.infNFe.cobr;
            IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeInfAdic infoAdd = NFe.infNFe.infAdic;
            //TNFeInfNFeAvulsa avulsa = NFe.infNFe.avulsa;
            //TLocal localRetirada = NFe.infNFe.retirada;
            //TLocal localEntrega = NFe.infNFe.entrega;
            //TNFeInfNFeExporta exporta = NFe.infNFe.exporta;
            //TNFeInfNFeCompra compra = NFe.infNFe.compra;
            //TNFeInfNFeCana cana = NFe.infNFe.cana;

            //Identificacao

            string chaveAcesso = NFe.infNFe.Id.Substring(3);
            danfe.DfeChaveAcesso = "";
            for (int i = 1; i <= chaveAcesso.Count(); i++)
            {
                danfe.DfeChaveAcesso += chaveAcesso[i - 1];
                if ((i % 4) == 0)
                {
                    danfe.DfeChaveAcesso += " ";
                }
            }



            Barcode128 code128 = new Barcode128
            {
                X = 1000f,
                CodeType = iTextSharp.text.pdf.Barcode.CODE128,
                ChecksumText = true,
                GenerateChecksum = true,
                StartStopText = true,
                Code = chaveAcesso,
                BarHeight = 45,
            };



            Bitmap codeBar = new Bitmap(code128.CreateDrawingImage(Color.Black, Color.White));
            ImageConverter converter = new ImageConverter();
            danfe.Barcode = (byte[])converter.ConvertTo(codeBar, typeof(byte[]));



            danfe.DfeNumeroNFe = identificacaoNFe.nNF;
            danfe.DfeSerieNFe = identificacaoNFe.serie;
            if (identificacaoNFe.tpNF == IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeIdeTpNF.Item0)
            {
                danfe.DfeTipoNFe = "0";
            }
            else
            {
                danfe.DfeTipoNFe = "1";
            }
            danfe.DfeNaturezaOperacao = identificacaoNFe.natOp;
            danfe.DfeProtocoloAutorizacaoUso = retNFe.protNFe.infProt.nProt + " " + retNFe.protNFe.infProt.dhRecbto;

            //Emitente
            danfe.preencheEmitenteV4(emitente, logoEmitente);

            //Remetente
            if (NFe.infNFe.versao == "4.00")
            {
                danfe.RemetDataEmissao = DateTime.Parse(identificacaoNFe.dhEmi, CultureInfo.InvariantCulture);
            }


            DateTime? dataEntradaSaida = null;
            if (!string.IsNullOrWhiteSpace(identificacaoNFe.dhSaiEnt))
            {
                dataEntradaSaida = DateTime.Parse(identificacaoNFe.dhSaiEnt, CultureInfo.InvariantCulture);
                danfe.RemetDataEntradaSaida = dataEntradaSaida.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                danfe.RemetDataEntradaSaida = "";
            }

            if (dataEntradaSaida.HasValue && dataEntradaSaida.Value.Hour != 0 && dataEntradaSaida.Value.Minute != 0)
            {
                danfe.RemetHoraSaida = dataEntradaSaida.Value.ToString("hh:mm:ss");
            }
            else
            {
                danfe.RemetHoraSaida = "";
            }
            danfe.preencheRemetenteV4(remetente);


            if (cobranca != null)
            {
                //Fatura
                if (cobranca.fat != null)
                {
                    danfe.FatNumero = cobranca.fat.nFat;
                    if (!string.IsNullOrWhiteSpace(cobranca.fat.vOrig))
                    {
                        danfe.FatValorOriginal = "R$ "+double.Parse(cobranca.fat.vOrig, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                    }
                    else
                    {
                        danfe.FatValorOriginal = "";
                    }
                    if (!string.IsNullOrWhiteSpace(cobranca.fat.vDesc))
                    {
                        danfe.FatValorDesconto = "R$ " + double.Parse(cobranca.fat.vDesc, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                    }
                    else
                    {
                        danfe.FatValorDesconto = "";
                    }

                    if (!string.IsNullOrWhiteSpace(cobranca.fat.vLiq))
                    {
                        danfe.FatValorLiquido = "R$ " + double.Parse(cobranca.fat.vLiq, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                    }
                    else
                    {
                        danfe.FatValorLiquido = "";
                    }
                }
                else
                {
                    danfe.FatNumero = "";
                    danfe.FatValorOriginal = "";
                    danfe.FatValorDesconto = "";
                    danfe.FatValorLiquido = "";
                }

                if (cobranca.dup != null)
                {
                    //Duplicatas
                    danfe.DfeDuplicatas = new List<DanfeNFeDuplicataClass>();
                    danfe.DfeDuplicatasDto = new List<DanfeDuplicatasDto>();
                    DanfeNFeDuplicataClass dup1 = null;
                    DanfeNFeDuplicataClass dup2 = null;
                    DanfeNFeDuplicataClass dup3 = null;

                    int contador = 0;

                    foreach (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeCobrDup dup in cobranca.dup)
                    {

                        if (contador > 0 && contador % 3 == 0)
                        {
                            danfe.DfeDuplicatasDto.Add(new DanfeDuplicatasDto(dup1, dup2, dup3,
                                danfe.DfeChaveAcesso));
                            dup1 = null;
                            dup2 = null;
                            dup3 = null;
                        }

                        DanfeNFeDuplicataClass tmp = new DanfeNFeDuplicataClass(dup.nDup, DateTime.Parse(dup.dVenc),
                            double.Parse(dup.vDup, CultureInfo.InvariantCulture));
                        if (dup1 == null)
                        {
                            dup1 = tmp;
                        }
                        else
                        {
                            if (dup2 == null)
                            {
                                dup2 = tmp;
                            }
                            else
                            {
                                dup3 = tmp;
                            }
                        }

                        danfe.DfeDuplicatas.Add(tmp);
                        contador++;

                    }

                    if (dup1 != null || dup2 != null || dup3 != null)
                    {
                        danfe.DfeDuplicatasDto.Add(new DanfeDuplicatasDto(dup1, dup2, dup3, danfe.DfeChaveAcesso));
                    }
                }
            }

            if (totalNFe != null)
            {
                //Imposto
                danfe.ImpBcIcms = double.Parse(totalNFe.ICMSTot.vBC, CultureInfo.InvariantCulture);
                danfe.ImpValorIcms = double.Parse(totalNFe.ICMSTot.vICMS, CultureInfo.InvariantCulture);
                danfe.ImpBcIcmsSt = double.Parse(totalNFe.ICMSTot.vBCST, CultureInfo.InvariantCulture);
                danfe.ImpValorIcmsSt = double.Parse(totalNFe.ICMSTot.vST, CultureInfo.InvariantCulture);
                danfe.ImpValorTotalProdutos = double.Parse(totalNFe.ICMSTot.vProd, CultureInfo.InvariantCulture);
                danfe.ImpValorFrete = double.Parse(totalNFe.ICMSTot.vFrete, CultureInfo.InvariantCulture);
                danfe.ImpValorSeguro = double.Parse(totalNFe.ICMSTot.vSeg, CultureInfo.InvariantCulture);
                danfe.ImpDesconto = double.Parse(totalNFe.ICMSTot.vDesc, CultureInfo.InvariantCulture);
                danfe.ImpOutrasDespesas = double.Parse(totalNFe.ICMSTot.vOutro, CultureInfo.InvariantCulture);
                danfe.ImpValorTotalIpi = double.Parse(totalNFe.ICMSTot.vIPI, CultureInfo.InvariantCulture);
                danfe.ImpValorTotalNF = double.Parse(totalNFe.ICMSTot.vNF, CultureInfo.InvariantCulture);
            }

            if (transporte != null)
            {
                //Transporte
                switch (transporte.modFrete)
                {
                    case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete.Item0:
                        danfe.TranspResponsavelFrete = "0 - Emitente";
                        break;
                    case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete.Item1:
                        switch (identificacaoNFe.tpNF)
                        {
                            case TNFeInfNFeIdeTpNF.Item0:
                                //nota de entrada
                                danfe.TranspResponsavelFrete = "1 - Remetente";
                                break;
                            case TNFeInfNFeIdeTpNF.Item1:
                                //nota de saída
                                danfe.TranspResponsavelFrete = "1 - Destinatário";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        break;
                    case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete.Item2:
                        danfe.TranspResponsavelFrete = "2 - Terceiros";
                        break;
                    case TNFeInfNFeTranspModFrete.Item3:
                        danfe.TranspResponsavelFrete = "3 - Próprio Rem";
                        break;
                    case TNFeInfNFeTranspModFrete.Item4:
                        danfe.TranspResponsavelFrete = "4 - Próprio Dest";
                        break;
                    case IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete.Item9:
                        danfe.TranspResponsavelFrete = "9 - Sem Frete";
                        break;
                }

                if (transporte.ItemsElementName != null)
                {
                    for (int i = 0; i < transporte.ItemsElementName.Count(); i++)
                    {
                        if (transporte.ItemsElementName[i] == IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTransp.ItemsChoiceType5.veicTransp)
                        {
                            danfe.TranspCodigoANTT = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TVeiculo)transporte.Items[i]).RNTC ?? "";
                            danfe.TranspPlacaVeiculo = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TVeiculo)transporte.Items[i]).placa ?? "";
                            danfe.TranspPlacaVeiculoUF = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TVeiculo)transporte.Items[i]).UF.ToString();
                        }
                    }
                }
                else
                {
                    danfe.TranspCodigoANTT = "";
                    danfe.TranspPlacaVeiculo = "";
                    danfe.TranspPlacaVeiculoUF = "";
                }

                if (transporte.transporta != null)
                {
                    danfe.TranspRazaoSocial = transporte.transporta.xNome ?? "";
                    danfe.TranspCnpjCpf = transporte.transporta.Item ?? "";
                    danfe.TranspEndereco = transporte.transporta.xEnder ?? "";
                    danfe.TranspCidade = transporte.transporta.xMun ?? "";
                    danfe.TranspUF = transporte.transporta.UF.ToString();
                    danfe.TranspIE = transporte.transporta.IE ?? "";
                }
                else
                {
                    danfe.TranspRazaoSocial = "";
                    danfe.TranspCnpjCpf = "";
                    danfe.TranspEndereco = "";
                    danfe.TranspCidade = "";
                    danfe.TranspUF = "";
                    danfe.TranspIE = "";
                }

                if (transporte.vol != null && transporte.vol.Count() > 0)
                {
                    IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspVol volume = transporte.vol[0]; //Volume
                    if (volume != null)
                    {
                        danfe.TranspQuantidade = volume.qVol ?? "";
                        danfe.TranspEspecie = volume.esp ?? "";
                        danfe.TranspMarca = volume.marca ?? "";
                        danfe.TranspNumeracao = volume.nVol ?? "";
                        if (volume.pesoB != null)
                        {
                            danfe.TranspPesoBruto = double.Parse(volume.pesoB, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                        }
                        else
                        {
                            danfe.TranspPesoBruto = "";
                        }

                        if (volume.pesoL != null)
                        {
                            danfe.TranspPesoLiquido = double.Parse(volume.pesoL, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                        }
                        else
                        {
                            danfe.TranspPesoLiquido = "";
                        }
                    }
                }

                if (danfe.TranspCnpjCpf.Length == 14)
                {
                    danfe.TranspCnpjCpf = danfe.TranspCnpjCpf.Substring(0, 2) + "." + danfe.TranspCnpjCpf.Substring(2, 3) + "." + danfe.TranspCnpjCpf.Substring(5, 3) + "/" + danfe.TranspCnpjCpf.Substring(8, 4) + "-" + danfe.TranspCnpjCpf.Substring(12, 2);
                }

                if (danfe.TranspCnpjCpf.Length == 11)
                {
                    danfe.TranspCnpjCpf = danfe.TranspCnpjCpf.Substring(0, 3) + "." + danfe.TranspCnpjCpf.Substring(3, 3) + "." + danfe.TranspCnpjCpf.Substring(6, 3) + "-" + danfe.TranspCnpjCpf.Substring(9, 2);
                }
            }


            //Produtos/Serviços
            danfe.DfeItens = new List<DanfeNFeItemClass>();
            foreach (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet tnFeInfNFeDet in detalhes)
            {
                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetProd produto = tnFeInfNFeDet.prod;
                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImposto imp = tnFeInfNFeDet.imposto;
                IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMS icms = new IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMS();
                IWTNFCompleto.BibliotecaDatasets.v4_0.TIpi ipi = new IWTNFCompleto.BibliotecaDatasets.v4_0.TIpi();

                #region ICMS/IPI - Produtos/Serviços

                string CST = ""; //N11 + N12 
                string bcIcms = ""; //N15     
                string bcIcmsSt = ""; //N21
                string valorIcms = ""; //N17
                string valorIcmsSt = ""; //N23
                string valorIpi = ""; //O14
                string aliquotaIcms = ""; //N16
                string aliquotaIpi = ""; //013

                //Busca a classe de ICMS do produto(item)
                foreach (object tipoImp in imp.Items)
                {
                    //ICMS
                    if (tipoImp is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMS)
                    {
                        icms = (IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMS) tipoImp;

                        if (icms != null)
                        {
                            if (icms.Item != null)
                            {
                                //Identifica qual o Grupo de tributação do ICMS
                                //00
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00) icms.Item).vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    bcIcmsSt = "";
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00) icms.Item).vICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcmsSt = "";
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS00) icms.Item).pICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                }

                                //10
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10) icms.Item).vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10) icms.Item).vICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS10) icms.Item).pICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                }

                                //20
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20) icms.Item).vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    bcIcmsSt = "";
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20) icms.Item).vICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcmsSt = "";
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS20) icms.Item).pICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                }

                                //30
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = "";
                                    valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS30) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = "";
                                }

                                //40
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = "";
                                    if (!string.IsNullOrWhiteSpace(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40) icms.Item).vICMSDeson))
                                    {
                                        valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS40) icms.Item).vICMSDeson, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    }
                                    else
                                    {
                                        valorIcms = "";
                                    }

                                    valorIcmsSt = "";
                                    aliquotaIcms = "";
                                }

                                //51
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51) icms.Item).vBC ?? "0", CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    bcIcmsSt = "";
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51) icms.Item).vICMS ?? "0", CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcmsSt = "";
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS51) icms.Item).pICMS ?? "0", CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                }

                                //60
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS60)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS60) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS60) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = "";
                                    valorIcms = "";
                                    valorIcmsSt = "";
                                    aliquotaIcms = "";
                                }

                                //70
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70) icms.Item).vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70) icms.Item).vICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS70) icms.Item).pICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                }

                                //90
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90) icms.Item).vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90) icms.Item).vICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMS90) icms.Item).pICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                }

                                //Part
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart) icms.Item).vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart) icms.Item).vICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSPart) icms.Item).pICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                }

                                //101
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN101)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN101) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN101) icms.Item).CSOSN.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = "";
                                    valorIcms = "";
                                    valorIcmsSt = "";
                                    aliquotaIcms = "";
                                }

                                //102
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN102)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN102) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN102) icms.Item).CSOSN.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = "";
                                    valorIcms = "";
                                    valorIcmsSt = "";
                                    aliquotaIcms = "";
                                }

                                //201
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201) icms.Item).CSOSN.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = "";
                                    valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN201) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = "";
                                }

                                //202
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202) icms.Item).CSOSN.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = "";
                                    valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN202) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = "";
                                }

                                //500
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN500)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN500) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN500) icms.Item).CSOSN.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = "";
                                    valorIcms = "";
                                    valorIcmsSt = "";
                                    aliquotaIcms = "";
                                }

                                //900
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).CSOSN.ToString().Replace("Item", "");
                                    bcIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    valorIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).vICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    aliquotaIcms = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).pICMS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);

                                    if (!string.IsNullOrWhiteSpace(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).vICMSST))
                                    {
                                        valorIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).vICMSST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    }

                                    if (!string.IsNullOrWhiteSpace(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).vBCST))
                                    {
                                        bcIcmsSt = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).vBCST, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                    }
                                }

                                //ST
                                if (icms.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSST)
                                {
                                    CST = ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSST) icms.Item).orig.ToString().Replace("Item", "") + ((IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDetImpostoICMSICMSST) icms.Item).CST.ToString().Replace("Item", "");
                                    bcIcms = "";
                                    bcIcmsSt = "";
                                    valorIcms = "";
                                    valorIcmsSt = "";
                                    aliquotaIcms = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        //IPI
                        if (tipoImp is IWTNFCompleto.BibliotecaDatasets.v4_0.TIpi)
                        {
                            ipi = (IWTNFCompleto.BibliotecaDatasets.v4_0.TIpi) tipoImp;
                            if (ipi != null)
                            {
                                if (ipi.Item is IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib)
                                {
                                    valorIpi = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib) ipi.Item).vIPI, CultureInfo.InvariantCulture).ToString("F2", culturePtBr);

                                    for (int i = 0; i < ((IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib) ipi.Item).ItemsElementName.Count(); i++)
                                    {
                                        if (((IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib) ipi.Item).ItemsElementName[i].ToString() == "pIPI")
                                        {
                                            aliquotaIpi = double.Parse(((IWTNFCompleto.BibliotecaDatasets.v4_0.TIpiIPITrib) ipi.Item).Items[i], CultureInfo.InvariantCulture).ToString("F2", culturePtBr);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                #endregion


                if (imprimirZerosTributosVazios)
                {
                    if (string.IsNullOrWhiteSpace(bcIcms))
                    {
                        bcIcms = 0.ToString("F2", culturePtBr);
                    }

                    if (string.IsNullOrWhiteSpace(bcIcmsSt))
                    {
                        bcIcmsSt = 0.ToString("F2", culturePtBr);
                    }

                    if (string.IsNullOrWhiteSpace(valorIcms))
                    {
                        valorIcms = 0.ToString("F2", culturePtBr);
                    }

                    if (string.IsNullOrWhiteSpace(valorIcmsSt))
                    {
                        valorIcmsSt = 0.ToString("F2", culturePtBr);
                    }

                    if (string.IsNullOrWhiteSpace(valorIpi))
                    {
                        valorIpi = 0.ToString("F2", culturePtBr);
                    }

                    if (string.IsNullOrWhiteSpace(aliquotaIcms))
                    {
                        aliquotaIcms = 0.ToString("F2", culturePtBr);
                    }

                    if (string.IsNullOrWhiteSpace(aliquotaIpi))
                    {
                        aliquotaIpi = 0.ToString("F2", culturePtBr);
                    }
                
                        
                }

                    danfe.DfeItens.Add(new DanfeNFeItemClass(danfe.DfeChaveAcesso,
                                                         produto.cProd,
                                                         produto.xProd,
                                                         tnFeInfNFeDet.infAdProd,
                                                         produto.NCM,
                                                         CST,
                                                         produto.CFOP.ToString().Replace("Item", ""),
                                                         produto.uCom,
                                                         double.Parse(produto.qCom, CultureInfo.InvariantCulture),
                                                         double.Parse(produto.vUnCom, CultureInfo.InvariantCulture),
                                                         produto.vDesc != null ? double.Parse(produto.vDesc, CultureInfo.InvariantCulture).ToString("F2", culturePtBr) : "",
                                                         double.Parse(produto.vProd, CultureInfo.InvariantCulture),
                                                         bcIcms,
                                                         bcIcmsSt,
                                                         valorIcms,
                                                         valorIcmsSt,
                                                         valorIpi,
                                                         aliquotaIcms,
                                                         aliquotaIpi));
            }

            if (totalNFe.ISSQNtot != null)
            {
                //ISSQN
                danfe.IssInscricaoMunicipal = emitente.IM;
                danfe.IssValorTotalServicos = totalNFe.ISSQNtot.vServ != null ? double.Parse(totalNFe.ISSQNtot.vServ, CultureInfo.InvariantCulture).ToString("F2", culturePtBr) : "";
                danfe.IssBCIssqn = totalNFe.ISSQNtot.vBC != null ? double.Parse(totalNFe.ISSQNtot.vBC, CultureInfo.InvariantCulture).ToString("F2", culturePtBr) : "";
                danfe.IssValorIssqn = totalNFe.ISSQNtot.vISS != null ? double.Parse(totalNFe.ISSQNtot.vISS, CultureInfo.InvariantCulture).ToString("F2", culturePtBr) : "";
            }

            //Dados Adicionais                
            string infAddFiscoTmp = "";

            //Inclui as notas de nota em contingência nas informações complementares
            if (NFe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS || NFe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN)
            {
                infAddFiscoTmp += "Data e Hora da Entrada em Contingência: " + NFe.infNFe.ide.dhCont + "; ";
                infAddFiscoTmp += "motivo da Entrada em Contingência: " + NFe.infNFe.ide.xJust + "; ";
            }


            //Inclui as duplicatas nas informações complementares
            if (IncluirDuplicatasObs)
            {
                if (danfe.DfeDuplicatas != null)
                {
                    foreach (DanfeNFeDuplicataClass duplicata in danfe.DfeDuplicatas)
                    {
                        infAddFiscoTmp += " " + duplicata + "; ";
                    }
                }
            }


            infAddFiscoTmp += " " + infoAdd.infCpl + " " + infoAdd.infAdFisco;

            //Verifica o limite do campo de Informação Complementar (5256)
            if (infAddFiscoTmp.Length > 5256)
            {
                string infAddTmp = infAddFiscoTmp.Substring(0, 5256);
                //Busca o primeiro caracter vazio anterior ao limite da informação complementar para realizar a quebra p o campo Fisco
                for (int i = 5255; i > 0; i--)
                {
                    if (infAddTmp[i].Equals(' '))
                    {
                        danfe.DfeInformacoesComplementares = infAddFiscoTmp.Substring(0, i); // string até o caracter vazio(não inclusive)
                        danfe.DfeReservadoFisco = infAddFiscoTmp.Substring(i + 1, infAddFiscoTmp.Length - 1 - i); // string a partir do caracter vazio(nao inclusive), até o final
                        break;
                    }
                }
            }
            else
            {
                danfe.DfeInformacoesComplementares = infAddFiscoTmp;
                danfe.DfeReservadoFisco = "";
            }

            return danfe;
        }


        private void preencheEmitenteV4(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeEmit emitente, byte[] logo)
        {
            if (emitente != null)
            {
                this.EmitRazaoSocial = emitente.xNome ?? "";
                this.EmitIncricaoEstadual = emitente.IE ?? "";
                this.EmitIncricaoEstadualST = emitente.IEST ?? "";
                this.EmitCNPJ = emitente.Item ?? "";

                if (this.EmitCNPJ.Length == 14)
                {
                    this.EmitCNPJ = this.EmitCNPJ.Substring(0, 2) + "." + this.EmitCNPJ.Substring(2, 3) + "." + this.EmitCNPJ.Substring(5, 3) + "/" + this.EmitCNPJ.Substring(8, 4) + "-" + this.EmitCNPJ.Substring(12, 2);
                }

                if (this.EmitCNPJ.Length == 11)
                {
                    this.EmitCNPJ = this.EmitCNPJ.Substring(0, 3) + "." + this.EmitCNPJ.Substring(3, 3) + "." + this.EmitCNPJ.Substring(6, 3) + "-" + this.EmitCNPJ.Substring(9, 2);
                }

                this.EmitEndereco = emitente.enderEmit.xLgr + ", " + emitente.enderEmit.nro ;
                this.EmitEndNumero = emitente.enderEmit.nro ?? "";
                this.EmitEndComplemento = emitente.enderEmit.xCpl ?? "";
                this.EmitBairro = emitente.enderEmit.xBairro ?? "";
                this.EmitCidade = emitente.enderEmit.xMun ?? "";
                this.EmitUF = emitente.enderEmit.UF.ToString();
                this.EmitPais = emitente.enderEmit.xPais.ToString();
                this.EmitCEP = emitente.enderEmit.CEP ?? "";
                this.EmitFone = emitente.enderEmit.fone ?? "";
                this.EmitFax = "";

                byte[] tmp = logo;

                if (logo != null)
                {
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 200, 200, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    tmp = ms.ToArray();
                }

                this.EmitLogo = tmp;
            }
        }

        private void preencheRemetenteV4(IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDest remetente)
        {
            if (remetente != null)
            {
                this.RemetRazaoSocial = remetente.xNome ?? "";
                this.RemetCnpjCpf = remetente.Item ?? "";

                if (this.RemetCnpjCpf.Length == 14)
                {
                    this.RemetCnpjCpf = this.RemetCnpjCpf.Substring(0, 2) + "." + this.RemetCnpjCpf.Substring(2, 3) + "." + this.RemetCnpjCpf.Substring(5, 3) + "/" + this.RemetCnpjCpf.Substring(8, 4) + "-" + this.RemetCnpjCpf.Substring(12, 2);
                }

                if (this.RemetCnpjCpf.Length == 11)
                {
                    this.RemetCnpjCpf = this.RemetCnpjCpf.Substring(0, 3) + "." + this.RemetCnpjCpf.Substring(3, 3) + "." + this.RemetCnpjCpf.Substring(6, 3) + "-" + this.RemetCnpjCpf.Substring(9, 2);
                }

                this.RemetEndereco = remetente.enderDest.xLgr + ", " + remetente.enderDest.nro + " " + remetente.enderDest.xCpl;
                this.RemetEndNumero = remetente.enderDest.nro  ?? "";
                this.RemetBairro = remetente.enderDest.xBairro ?? "";
                this.RemetCEP = remetente.enderDest.CEP ?? "";
                this.RemetCidade = remetente.enderDest.xMun ?? "";
                this.RemetFoneFax = remetente.enderDest.fone ?? "";
                this.RemetUF = remetente.enderDest.UF.ToString();
                this.RemetIE = remetente.IE ?? "";
            }
        }


        public List<DanfeNFeItemCompleto> paginarNFe()
        {
            const int qtdLinhasPorPagina = 14;
            int qtdTotalPaginas;
            double tmp = this.DfeItens.Count/(double)qtdLinhasPorPagina;
            if ((tmp%1)==0)
            {
                qtdTotalPaginas = (int) tmp;
            }
            else
            {
                qtdTotalPaginas = (int)tmp+1;
            }
            
            
            List<DanfeNFeItemCompleto> toRet = new List<DanfeNFeItemCompleto>();
            int pagAtual = 0;
            for (int i=0;i<this.DfeItens.Count;i++)
            {
                if ((i%qtdLinhasPorPagina)==0)
                {
                    pagAtual++;
                }

                toRet.Add(new DanfeNFeItemCompleto(this, this.DfeItens[i], pagAtual, qtdTotalPaginas));
            }

            return toRet;

        }

        

    }

    public class DanfeDuplicatasDto
    {
        public string ChaveAcessoNFe { get; }

        public string TextoDuplicata1 { get;  }
        public string TextoDuplicata2 { get;  }
        public string TextoDuplicata3 { get;  }

        public DanfeDuplicatasDto(DanfeNFeDuplicataClass duplicata1, DanfeNFeDuplicataClass duplicata2,
            DanfeNFeDuplicataClass duplicata3, string chaveAcessoNFe)
        {
            ChaveAcessoNFe = chaveAcessoNFe;
            if (duplicata1 != null)
            {
                TextoDuplicata1 = duplicata1.ToString();
            }

            if (duplicata2 != null)
            {
                TextoDuplicata2 = duplicata2.ToString();
            }

            if (duplicata3 != null)
            {
                TextoDuplicata3 = duplicata3.ToString();
            }
        }


    }
}
