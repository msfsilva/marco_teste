using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTNFCompleto.NfeAutorizacao;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {

        public static LoteEnviar EnviaNfe(NfPrincipalClass Nota, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor, AcsUsuarioClass usuarioAtual, out RetornoNFe notaRetornada)
        {
            ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

            notaRetornada = null;

            BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                ServicoNFe.NfeRecepcao,
                new List<object>()
                    {
                      Nota,
                      ufEmitente,
                      Ambiente,
                      serialCertificado,
                      conn,
                      cnpjTransmissor,
                      usuarioAtual,
                      waitForm
                    },
                new List<object>()
                {
                    notaRetornada
                },
                waitForm);

            BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += new DoWorkEventHandler(tr.Run);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tr.Completed);
            worker.RunWorkerAsync(tr);

            waitForm.ShowDialog();

            notaRetornada = (RetornoNFe)tr.ArgumentosSaida[0];

            return (LoteEnviar)tr.Retorno;
        }

        public static LoteEnviar EnviaNfe(NotaEnviar Nota, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor, AcsUsuarioClass usuarioAtual, out RetornoNFe notaRetornada)
        {
            ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

            notaRetornada = null;
            BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                ServicoNFe.NfeRecepcao,
                new List<object>()
                    {
                      Nota,
                      ufEmitente,
                      Ambiente,
                      serialCertificado,
                      conn,
                      cnpjTransmissor,
                      usuarioAtual,
                      waitForm
                    },
                new List<object>()
                {
                       notaRetornada
                },
                waitForm);

            BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += new DoWorkEventHandler(tr.Run);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tr.Completed);
            worker.RunWorkerAsync(tr);

            waitForm.ShowDialog();

            notaRetornada = (RetornoNFe)tr.ArgumentosSaida[0];

            return (LoteEnviar)tr.Retorno;
        }


        internal static void CalculaChaveNota(TNFe notaEnviar)
        {

            DateTime dataEmissao = DateTime.Parse(notaEnviar.infNFe.ide.dhEmi, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
            string modelo = notaEnviar.infNFe.ide.mod.ToString().Replace("Item", "");

            string chaveAcessoNfSemDigito =
                       Convert.ToInt32(notaEnviar.infNFe.ide.cUF).ToString() +
                       dataEmissao.ToString("yyMM") +
                       notaEnviar.infNFe.emit.Item.PadLeft(14, '0') +
                       modelo +
                       notaEnviar.infNFe.ide.serie.PadLeft(3, '0') +
                       notaEnviar.infNFe.ide.nNF.PadLeft(9, '0') +
                       notaEnviar.infNFe.ide.tpEmis.GetXmlEnumAttributeValueFromEnum() +
                       notaEnviar.infNFe.ide.cNF;

            int digitoNfe = FuncoesAuxiliares.DigitoModulo11(chaveAcessoNfSemDigito);

            notaEnviar.infNFe.ide.cDV = digitoNfe.ToString();
            notaEnviar.infNFe.Id = "NFe" + chaveAcessoNfSemDigito + "" + digitoNfe; 
        }

        internal static LoteEnviar EnviaNfeInterno(NfPrincipalClass nota, TCodUfIBGELegado ufEmitente, TAmbLegado Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor, AcsUsuarioClass usuarioAtual, ComunicacaoWaitForm waitForm, out RetornoNFe notaRetornada)
        {

            string numeroNota = "";
            string errosConversao = "";
            try
            {

                if (waitForm != null)
                {
                    waitForm.MudaMensagem("Preparando dados para transmissão, por favor aguarde");
                }

                Random r = new Random();


                NotaEnviar notaCompleta = new NotaEnviar()
                {
                    NfPrincipal = nota,
                    NfTnfe = new TNFe()
                };
                
                TNFe notaEnviar = notaCompleta.NfTnfe;

                numeroNota = nota.Numero.ToString();


                try
                {
                    #region Validações

                    if (nota.ModeloDocFiscal != "55" && nota.ModeloDocFiscal != "65")
                    {
                        throw new Exception("O modelo da NFe deve ser 55 ou 65");
                    }

                    if (nota.NfEmitente.NfEmitenteEndereco.CodPais != 1058)
                    {
                        throw new Exception("O código do país do emitente deve ser 1058");
                    }

                    if (!IWTFunctions.IWTFunctions.ValidaCep(nota.NfEmitente.NfEmitenteEndereco.Cep))
                    {
                        throw new Exception("O CEP do endereço do emitente é inválido");
                    }

                    if (nota.ModeloDocFiscal == "55" && nota.NfCliente == null)
                    {
                        throw new Exception("O cliente é obrigatório para NFe");
                    }

                    if (nota.ModeloDocFiscal == "65" && nota.NfCliente == null && nota.NfTotais.ValorTotalNf >= 10000)
                    {
                        throw new Exception("O cliente é obrigatório para NFCe com valor igual ou superior a R$ 10.000,00");
                    }



                    if (nota.NfCliente != null)
                    {

                        if (nota.ModeloDocFiscal == "55")
                        {
                            if (string.IsNullOrEmpty(nota.NfCliente.Razao))
                            {
                                throw new Exception("O nome/razão do cliente é obrigatório");
                            }
                            if (nota.NfCliente.NfClienteEndereco == null)
                            {
                                throw new Exception("O endereço do cliente é obrigatório");
                            }
                        }


                        if (nota.NfCliente.NfClienteEndereco != null)
                        {
                            
                            if (nota.NfCliente.NfClienteEndereco.CodPais==0)
                            {
                                throw new Exception("O código do país do cliente é inválido");
                            }

                            if (string.IsNullOrWhiteSpace(nota.NfCliente.NfClienteEndereco.Numero))
                            {
                                throw new Exception("O número do endereço do cliente é inválido");
                            }

                            if (string.IsNullOrWhiteSpace(nota.NfCliente.NfClienteEndereco.Bairro))
                            {
                                throw new Exception("O bairro do endereço do cliente é inválido");
                            }

                            if (nota.NfCliente.NfClienteEndereco.CodPais == 1058)
                            {
                                if (!IWTFunctions.IWTFunctions.ValidaCep(nota.NfCliente.NfClienteEndereco.Cep))
                                {
                                    throw new Exception("O CEP do endereço do cliente é inválido");
                                }
                            }

                        }

                    }
                    
                    #endregion

                    #region Dados Basicos


                    notaEnviar.infNFe = new TNFeInfNFe()
                    {
                        versao = versaoLayout
                    };

                    TNFeInfNFeIdeIdDest destino = TNFeInfNFeIdeIdDest.Item1;
                    if (nota.NfCliente != null && nota.NfCliente.NfClienteEndereco != null)
                    {

                        if (nota.NfCliente.NfClienteEndereco.CodPais == nota.NfEmitente.NfEmitenteEndereco.CodPais)
                        {
                            if (nota.NfCliente.NfClienteEndereco.SiglaUf == nota.NfEmitente.NfEmitenteEndereco.SiglaUf)
                            {
                                destino = TNFeInfNFeIdeIdDest.Item1;
                            }
                            else
                            {
                                destino = TNFeInfNFeIdeIdDest.Item2;
                            }
                        }
                        else
                        {
                            destino = TNFeInfNFeIdeIdDest.Item3;
                        }
                    }



                    notaEnviar.infNFe.ide = new TNFeInfNFeIde
                    {
                        cUFLegado = ufEmitente,
                        cNF = r.Next(1, 99999999).ToString("D8").Trim(),
                        natOp = nota.NaturezaOperacao.Trim(),
                        mod = nota.ModeloDocFiscal == "55" ? TMod.Item55 : TMod.Item65,
                        serie = nota.Serie.ToString().Trim(),
                        nNF = nota.Numero.ToString().Trim(),
                        dhEmi = nota.DataEmissao.ToString("yyyy-MM-ddTHH:mm:sszzz").Trim(),
                        dhSaiEnt = nota.DataSaidaEntrada.HasValue ? FuncoesAuxiliares.ValidaCampoOpcional(nota.DataSaidaEntrada.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")) : null,
                        tpNF = nota.Tipo == 0 ? TNFeInfNFeIdeTpNF.Item0 : TNFeInfNFeIdeTpNF.Item1,
                        cMunFG = nota.CodMunicipioFatoGerador.ToString().Trim(),
                        finNFe = (TFinNFe) Enum.Parse(typeof (TFinNFe), "Item" + Convert.ToInt16(nota.FinalidadeEmissao)),
                        procEmi = TProcEmi.Item0,
                        verProc = versaoAplicativoEmissor.Trim(),
                        tpAmbLegado = Ambiente,
                        idDest = destino,
                        indFinal = nota.ConsumidorFinal ? TNFeInfNFeIdeIndFinal.Item1 : TNFeInfNFeIdeIndFinal.Item0,
                        indPres = (TNFeInfNFeIdeIndPres) Enum.Parse(typeof (TNFeInfNFeIdeIndPres), "Item" + Convert.ToInt16(nota.PresencaComprador)),

                    };

                    if (notaEnviar.infNFe.ide.mod == TMod.Item65)
                    {
                        //Para nfce o timeout de validação é de apenas 5 minutos, então para não ficar travado em dias de mais carga atualiza a data e hora para agora antes de transmistir.
                        notaEnviar.infNFe.ide.dhEmi = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz").Trim();
                    }


                    if (notaEnviar.infNFe.ide.indPres == TNFeInfNFeIdeIndPres.Item2 || notaEnviar.infNFe.ide.indPres == TNFeInfNFeIdeIndPres.Item3 || notaEnviar.infNFe.ide.indPres == TNFeInfNFeIdeIndPres.Item4 || notaEnviar.infNFe.ide.indPres == TNFeInfNFeIdeIndPres.Item9)
                    {
                        if (notaEnviar.infNFe.ide.tpNF == TNFeInfNFeIdeTpNF.Item1 && notaEnviar.infNFe.ide.finNFe == TFinNFe.Item1)
                        {
                            notaEnviar.infNFe.ide.indIntermedSpecified = true;
                            notaEnviar.infNFe.ide.indIntermed = TNFeInfNFeIdeIndIntermed.Item0;
                        }
                        else
                        {
                            notaEnviar.infNFe.ide.indIntermedSpecified = false;
                        }
                    }
                    else
                    {
                        notaEnviar.infNFe.ide.indIntermedSpecified = false;
                    }
                    

                    if (notaEnviar.infNFe.ide.mod == TMod.Item55)
                    {
                        notaEnviar.infNFe.ide.tpImpLegado = TNFeInfNFeIdeTpImpLegado.DANFENormalRetrato;
                    }
                    else
                    {
                        notaEnviar.infNFe.ide.tpImpLegado = TNFeInfNFeIdeTpImpLegado.DANFENFCe;
                    }

                    switch (nota.FormaEmissao)
                    {
                        case FormaEmissaoNFe.Normal:
                            notaEnviar.infNFe.ide.TpEmisLegado = TNFeInfNFeIdeTpEmisLegado.EmissaoNormal;
                            break;
                        case FormaEmissaoNFe.ContingenciaScan:

                            if (notaEnviar.infNFe.ide.mod == TMod.Item55)
                            {


                                //notaEnviar.infNFe.ide.tpEmis = TNFeInfNFeIdeTpEmis.Item3;
                                TUfEmi estado = FuncoesAuxiliares.Sigla2TUfEmi(nota.NfEmitente.NfEmitenteEndereco.SiglaUf);

                                switch (estado)
                                {
                                    case TUfEmi.AC:
                                    case TUfEmi.AL:
                                    case TUfEmi.AP:
                                    case TUfEmi.MG:
                                    case TUfEmi.PA:
                                    case TUfEmi.RJ:
                                    case TUfEmi.RS:
                                    case TUfEmi.RO:
                                    case TUfEmi.RR:
                                    case TUfEmi.SC:
                                    case TUfEmi.SE:
                                    case TUfEmi.SP:
                                    case TUfEmi.TO:
                                    case TUfEmi.DF:
                                        notaEnviar.infNFe.ide.TpEmisLegado = TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN;
                                        break;
                                    case TUfEmi.AM:
                                    case TUfEmi.BA:
                                    case TUfEmi.CE:
                                    case TUfEmi.ES:
                                    case TUfEmi.GO:
                                    case TUfEmi.MA:
                                    case TUfEmi.MS:
                                    case TUfEmi.MT:
                                    case TUfEmi.PB:
                                    case TUfEmi.PE:
                                    case TUfEmi.PI:
                                    case TUfEmi.PR:
                                    case TUfEmi.RN:
                                        notaEnviar.infNFe.ide.TpEmisLegado = TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS;
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                            else
                            {
                                notaEnviar.infNFe.ide.TpEmisLegado = TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe;
                            }
                            break;
                        default:
                            throw new Exception("Tipo de emissão inválido ou não implementado: " + nota.FormaEmissao);
                    }




                    notaEnviar.infNFe.emit = new TNFeInfNFeEmit
                    {
                        ItemElementName = nota.NfEmitente.CnpjCpf.Length == 11 ? TNFeInfNFeEmit.ItemChoiceType2.CPF : TNFeInfNFeEmit.ItemChoiceType2.CNPJ,
                        xNome = nota.NfEmitente.Razao.Trim(),
                        xFant = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NomeFantasia),
                        enderEmit = new TEnderEmi
                        {
                            xLgr = nota.NfEmitente.NfEmitenteEndereco.Logradouro.Trim(),
                            nro = nota.NfEmitente.NfEmitenteEndereco.Numero.Trim(),
                            xCpl = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfEmitenteEndereco.Complemento),
                            xBairro = nota.NfEmitente.NfEmitenteEndereco.Bairro.Trim(),
                            cMun = nota.NfEmitente.NfEmitenteEndereco.CodMunicipio.ToString().Trim(),
                            xMun = nota.NfEmitente.NfEmitenteEndereco.NomeMunicipio.Trim(),
                            UF = FuncoesAuxiliares.Sigla2TUfEmi(nota.NfEmitente.NfEmitenteEndereco.SiglaUf),
                            CEP = nota.NfEmitente.NfEmitenteEndereco.Cep.Trim(),
                            cPais = TEnderEmiCPais.Item1058,
                            cPaisSpecified = true,
                            fone = nota.NfEmitente.NfEmitenteEndereco.Telefone == null ? null : FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfEmitenteEndereco.Telefone.Replace(" ", "").Replace("-", ""))
                        },
                        IE = nota.NfEmitente.Ie.Trim(),
                        IEST = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.IeSt),
                        IM = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.Im),
                        CRT = (TNFeInfNFeEmitCRT) Enum.Parse(typeof(TNFeInfNFeEmitCRT), "Item" + nota.NfEmitente.Crt)
                    };
                    notaEnviar.infNFe.emit.SetItem(nota.NfEmitente.CnpjCpf.Trim());

                    if (!string.IsNullOrEmpty(notaEnviar.infNFe.emit.IM))
                    {
                        notaEnviar.infNFe.emit.CNAE = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.Cnae);
                    }

                    CalculaChaveNota(notaEnviar);


                    if (nota.NfCliente != null)
                    {

                        notaEnviar.infNFe.dest = new TNFeInfNFeDest
                        {
                            ItemElementName = nota.NfCliente.CnpjCpf.Length == 11 ? TNFeInfNFeDest.ItemChoiceType3.CPF : TNFeInfNFeDest.ItemChoiceType3.CNPJ,
                            xNome = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.Razao.Trim()),

                            ISUF = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.Isuf),
                            email = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.Email)
                        };

                        notaEnviar.infNFe.dest.SetItem(nota.NfCliente.CnpjCpf.Trim());


                        if (nota.NfCliente.NfClienteEndereco != null)
                        {
                            notaEnviar.infNFe.dest.enderDest = new TEndereco()
                            {
                                xLgr = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.NfClienteEndereco.Logradouro.Trim()),
                                nro = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.NfClienteEndereco.Numero.Trim()),
                                xCpl = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfClienteEndereco.Complemento),
                                xBairro = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.NfClienteEndereco.Bairro.Trim()),
                                cMun = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.NfClienteEndereco.CodMunicipio.ToString().Trim()),
                                xMun = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.NfClienteEndereco.NomeMunicipio.Trim()),
                                UF = FuncoesAuxiliares.Sigla2TUf(nota.NfCliente.NfClienteEndereco.SiglaUf),
                                CEP = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfClienteEndereco.Cep),
                                cPais = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.NfClienteEndereco.CodPais.ToString()),
                                xPais = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.NfCliente.NfClienteEndereco.NomePais),
                                fone = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfClienteEndereco.Telefone)
                                
                            };

                            if (notaEnviar.infNFe.dest.xNome == "CLIENTE")
                            {
                                notaEnviar.infNFe.dest.xNome = null;
                            }

                            if (notaEnviar.infNFe.dest.enderDest.cPais != "1058")
                            {
                                notaEnviar.infNFe.dest.ItemElementName = TNFeInfNFeDest.ItemChoiceType3.idEstrangeiro;
                                notaEnviar.infNFe.dest.SetItem("EXTERIOR");

                                notaEnviar.infNFe.dest.enderDest.xMun = "EXTERIOR";
                                notaEnviar.infNFe.dest.enderDest.cMun = "9999999";
                              
                            }
                        }

                        if (notaEnviar.infNFe.dest.enderDest.cPais == "1058")
                        {
                            if (notaEnviar.infNFe.ide.mod == TMod.Item55)
                            {
                                //TODO: Verificar necessidade de envio da IE quando isento e tratativa da IE para pF
                                if (notaEnviar.infNFe.dest.ItemElementName == TNFeInfNFeDest.ItemChoiceType3.CNPJ)
                                {
                                    if (nota.NfCliente.IndicadorIe.HasValue)
                                    {
                                        switch (nota.NfCliente.IndicadorIe)
                                        {
                                            case IWTNFIndicadorIE.ContribuinteICMS:
                                                notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item1;
                                                notaEnviar.infNFe.dest.IE = nota.NfCliente.Ie.Trim();
                                                break;
                                            case IWTNFIndicadorIE.Isento:
                                                notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item2;
                                                notaEnviar.infNFe.dest.IE = null;
                                                break;
                                            case IWTNFIndicadorIE.NaoContribuinte:
                                                notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item9;
                                                notaEnviar.infNFe.dest.IE = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.Ie.Trim());
                                                break;
                                            default:
                                                throw new ArgumentOutOfRangeException();
                                        }
                                    }
                                    else
                                    {
                                        if (string.IsNullOrWhiteSpace(nota.NfCliente.Ie) || nota.NfCliente.Ie.Trim().ToUpper() == "ISENTO")
                                        {
                                            notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item2;
                                        }
                                        else
                                        {
                                            notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item1;
                                            notaEnviar.infNFe.dest.IE = nota.NfCliente.Ie.Trim();
                                        }
                                    }
                                }
                                else
                                {
                                    notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item9;
                                }
                            }
                            else
                            {
                                notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item9;
                            }
                        }
                        else
                        {
                            notaEnviar.infNFe.dest.indIEDest = TNFeInfNFeDestIndIEDest.Item9;
                        }
                    }


                    notaEnviar.infNFe.total = new TNFeInfNFeTotal
                    {
                        ICMSTot = new TNFeInfNFeTotalICMSTot
                        {
                            vBC = nota.NfTotais.BaseCalculoIcms.ToString("F2", CultureInfo.InvariantCulture),
                            vICMS = nota.NfTotais.ValorTotalIcms.ToString("F2", CultureInfo.InvariantCulture),
                            vBCST = nota.NfTotais.BaseCalculoIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                            vST = nota.NfTotais.ValorTotalIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                            vProd = nota.NfTotais.ValorTotalProdutosServicosIcms.ToString("F2", CultureInfo.InvariantCulture),
                            vFrete = nota.NfTotais.ValorTotalFrete.ToString("F2", CultureInfo.InvariantCulture),
                            vSeg = nota.NfTotais.ValorTotalSeguro.ToString("F2", CultureInfo.InvariantCulture),
                            vDesc = nota.NfTotais.ValorTotalDesconto.ToString("F2", CultureInfo.InvariantCulture),
                            vII = nota.NfTotais.ValorTotalIimp.ToString("F2", CultureInfo.InvariantCulture),
                            vIPI = nota.NfTotais.ValorTotalIpi.ToString("F2", CultureInfo.InvariantCulture),
                            vPIS = nota.NfTotais.ValorTotalPis.ToString("F2", CultureInfo.InvariantCulture),
                            vCOFINS = nota.NfTotais.ValorTotalCofins.ToString("F2", CultureInfo.InvariantCulture),
                            vOutro = nota.NfTotais.OutrasDespesas.ToString("F2", CultureInfo.InvariantCulture),
                            vNF = nota.NfTotais.ValorTotalNf.ToString("F2", CultureInfo.InvariantCulture),
                            vICMSDeson = nota.NfTotais.ValorTotalIcmsDesonerado.ToString("F2", CultureInfo.InvariantCulture),
                            

                        },
                        //ISSQNtot = new TNFeInfNFeTotalISSQNtot
                        //{
                        //    vServ =
                        //        FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorTotalServicos.HasValue ? nota.NfTotais.ValorTotalServicos.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                        //    vBC = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.BaseCalculoIss.HasValue ? nota.NfTotais.BaseCalculoIss.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                        //    vISS = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorTotalIss.HasValue ? nota.NfTotais.ValorTotalIss.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                        //    vPIS = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorTotalPisServicos.HasValue ? nota.NfTotais.ValorTotalPisServicos.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                        //    vCOFINS = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorTotalCofinsServicos.HasValue ? nota.NfTotais.ValorTotalCofinsServicos.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                            
                        //},
                        retTrib = new TNFeInfNFeTotalRetTrib
                        {
                            vRetPIS = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorRetidoPis.HasValue ? nota.NfTotais.ValorRetidoPis.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                            vRetCOFINS = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorRetidoCofins.HasValue ? nota.NfTotais.ValorRetidoCofins.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                            vBCIRRF = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorRetidoBcIrrf.HasValue ? nota.NfTotais.ValorRetidoBcIrrf.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                            vBCRetPrev = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorRetidoBcPrevidencia.HasValue ? nota.NfTotais.ValorRetidoBcPrevidencia.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                            vIRRF = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorRetidoIrrf.HasValue ? nota.NfTotais.ValorRetidoIrrf.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                            vRetCSLL = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorRetidoCsll.HasValue ? nota.NfTotais.ValorRetidoCsll.Value : 0).ToString("F2", CultureInfo.InvariantCulture)),
                            vRetPrev = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTotais.ValorRetidoPreviencia.HasValue ? nota.NfTotais.ValorRetidoPreviencia.Value : 0).ToString("F2", CultureInfo.InvariantCulture))
                        }
                    };

                    if (nota.NfTotais.ValorTotalAproximadoTributos.HasValue)
                    {
                        notaEnviar.infNFe.total.ICMSTot.vTotTrib = nota.NfTotais.ValorTotalAproximadoTributos.Value.ToString("F2", CultureInfo.InvariantCulture);
                    }

                    if (nota.NfTransporte == null)
                    {
                        notaEnviar.infNFe.transp = new TNFeInfNFeTransp
                        {
                            modFrete = TNFeInfNFeTranspModFrete.Item9
                        };
                    }
                    else
                    {
                        notaEnviar.infNFe.transp = new TNFeInfNFeTransp
                        {
                            modFrete = (TNFeInfNFeTranspModFrete) Enum.Parse(typeof (TNFeInfNFeTranspModFrete),
                                "Item" + Convert.ToInt16(nota.NfTransporte.Modalidade))
                        };


                        if (!string.IsNullOrWhiteSpace(nota.NfTransporte.CpfCnpj))
                        {

                            notaEnviar.infNFe.transp.transporta = new TNFeInfNFeTranspTransporta
                            {
                                ItemElementName = nota.NfTransporte.CpfCnpj.Length == 11 ? TNFeInfNFeTranspTransporta.ItemChoiceType6.CPF : TNFeInfNFeTranspTransporta.ItemChoiceType6.CNPJ,
                                xNome = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.Razao),
                                IE = FuncoesAuxiliares.ValidaCampoOpcional(string.IsNullOrWhiteSpace(nota.NfTransporte.Ie) ? "" : nota.NfTransporte.Ie.Replace("-", "")),
                                xMun = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.Municipio),
                                xEnder = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.Endereco)

                            };
                            notaEnviar.infNFe.transp.transporta.SetItem(nota.NfTransporte.CpfCnpj.Trim());

                            if (!string.IsNullOrWhiteSpace(nota.NfTransporte.SiglaUf))
                            {
                                notaEnviar.infNFe.transp.transporta.UFSpecified = true;
                                notaEnviar.infNFe.transp.transporta.UF = FuncoesAuxiliares.Sigla2TUf(nota.NfTransporte.SiglaUf);
                            }
                            else
                            {
                                notaEnviar.infNFe.transp.transporta.UFSpecified = false;
                            }

                            if (!string.IsNullOrWhiteSpace(nota.NfTransporte.Placa))
                            {

                                notaEnviar.infNFe.transp.AddItem(TNFeInfNFeTransp.ItemsChoiceType5.veicTransp, new TVeiculo()
                                {
                                    placa = nota.NfTransporte.Placa.Trim(),
                                    RNTC = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.RegistroAntt)
                                });

                                if (!string.IsNullOrWhiteSpace(nota.NfTransporte.SiglaUfVeiculo))
                                {
                                    ((TVeiculo) notaEnviar.infNFe.transp.Items[0]).UF = FuncoesAuxiliares.Sigla2TUf(nota.NfTransporte.SiglaUfVeiculo);
                                    ((TVeiculo) notaEnviar.infNFe.transp.Items[0]).UFSpecified = true;
                                }
                            }
                        }

                        TNFeInfNFeTranspVol tmpVol = new TNFeInfNFeTranspVol
                        {
                            qVol = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.Volumes.ToString()),
                            esp = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.VolumeEspecie),
                            pesoL = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTransporte.PesoLiquido.HasValue ? nota.NfTransporte.PesoLiquido.Value : 0).ToString("F3", CultureInfo.InvariantCulture)),
                            pesoB = FuncoesAuxiliares.ValidaCampoOpcional((nota.NfTransporte.PesoBruto.HasValue ? nota.NfTransporte.PesoBruto.Value : 0).ToString("F3", CultureInfo.InvariantCulture)),
                            marca = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.VolumeMarca)

                        };

                        if (tmpVol.qVol != null || tmpVol.esp != null || tmpVol.pesoL != null || tmpVol.pesoB != null || tmpVol.marca != null)
                        {
                            notaEnviar.infNFe.transp.vol = new Collection<TNFeInfNFeTranspVol>(System.Linq.Enumerable.Repeat<TNFeInfNFeTranspVol>(null, 1).ToList());
                            notaEnviar.infNFe.transp.vol[0] = tmpVol;
                        }
                    }

                    if (nota.NfCobranca != null)
                    {
                        double valorFatura = 0;
                        notaEnviar.infNFe.cobr = new TNFeInfNFeCobr();



                        if (nota.NfCobranca.CollectionNfDuplicataClassNfCobranca != null)
                        {
                            var duplicatas = nota.NfCobranca.CollectionNfDuplicataClassNfCobranca.Where(a => a.Valor >= 0.01).OrderBy(a => a.Vencimento).ToList();

                            if (duplicatas.Count > 0)
                            {
                                notaEnviar.infNFe.cobr.dup = new Collection<TNFeInfNFeCobrDup>(System.Linq.Enumerable.Repeat<TNFeInfNFeCobrDup>(null, nota.NfCobranca.CollectionNfDuplicataClassNfCobranca.Count).ToList());
                                for (int i = 0; i < duplicatas.Count; i++)
                                {
                                    notaEnviar.infNFe.cobr.dup[i] = new TNFeInfNFeCobrDup()
                                    {
                                        dVenc = FuncoesAuxiliares.ValidaCampoOpcional(duplicatas[i].Vencimento.ToString("yyyy-MM-dd")),
                                        nDup = (i + 1).ToString().PadLeft(3, '0'),
                                        vDup = FuncoesAuxiliares.ValidaCampoOpcional(duplicatas[i].Valor.ToString("F2", CultureInfo.InvariantCulture))
                                    };

                                    valorFatura = Math.Round(valorFatura + nota.NfCobranca.CollectionNfDuplicataClassNfCobranca[i].Valor, 2);
                                }
                            }

                        }

                        if (nota.NfCobranca.NfFatura != null)
                        {
                            notaEnviar.infNFe.cobr.fat = new TNFeInfNFeCobrFat()
                            {
                                nFat = nota.NfCobranca.NfFatura.Numero,
                                vDesc = nota.NfCobranca.NfFatura.Desconto.ToString("F2", CultureInfo.InvariantCulture),
                                vLiq = nota.NfCobranca.NfFatura.ValorLiquido.ToString("F2", CultureInfo.InvariantCulture),
                                vOrig = nota.NfCobranca.NfFatura.ValorOriginal.ToString("F2", CultureInfo.InvariantCulture)
                            };
                        }
                        else
                        {
                            notaEnviar.infNFe.cobr.fat = new TNFeInfNFeCobrFat()
                            {
                                nFat = "001",
                                vOrig = valorFatura.ToString("F2", CultureInfo.InvariantCulture),
                                vDesc = 0.ToString("F2", CultureInfo.InvariantCulture),
                                vLiq = valorFatura.ToString("F2", CultureInfo.InvariantCulture),
                            };
                        }
                    }

                    notaEnviar.infNFe.infAdic = new TNFeInfNFeInfAdic()
                    {
                        infAdFisco = FuncoesAuxiliares.ValidaCampoOpcional((nota.ObservacoesFisco ?? "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "")),
                        infCpl = FuncoesAuxiliares.ValidaCampoOpcional((nota.Observacoes ?? "").Replace("\r\n", "").Replace("\r", "").Replace("\n", ""))
                    };

                    if (nota.CollectionNfNotasRelacionadasClassNfPrincipal != null && nota.CollectionNfNotasRelacionadasClassNfPrincipal.Count > 0)
                    {
                        notaEnviar.infNFe.ide.NFref = new Collection<TNFeInfNFeIdeNFref>(System.Linq.Enumerable.Repeat<TNFeInfNFeIdeNFref>(null, nota.CollectionNfNotasRelacionadasClassNfPrincipal.Count).ToList());

                        int i = 0;
                        foreach (NfNotasRelacionadasClass relacionada in nota.CollectionNfNotasRelacionadasClassNfPrincipal)
                        {

                            if (relacionada.Chave.Length != 44)
                            {
                                throw new ExcecaoTratada("Chave de nota referenciada inválida: " + relacionada.Chave);
                            }
                            string codigoUf = relacionada.Chave.Substring(0, 2);
                            string aamm = relacionada.Chave.Substring(2, 4);
                            string cnpj = relacionada.Chave.Substring(6, 14);
                            string modelo = relacionada.Chave.Substring(20, 2);
                            string serie = relacionada.Chave.Substring(22, 3);
                            string numero = relacionada.Chave.Substring(25, 9);


                            notaEnviar.infNFe.ide.NFref[i] = new TNFeInfNFeIdeNFref()
                            {
                                ItemElementName = TNFeInfNFeIdeNFref.ItemChoiceType1.refNFe,
                                /*Item = new TNFeInfNFeIdeNFrefRefNF()
                                 {
                                     AAMM = aamm,
                                     CNPJ = cnpj,
                                     cUF = (TCodUfIBGE) int.Parse(codigoUf),
                                     nNF = numero,
                                     serie = serie,
                                     mod = (TNFeInfNFeIdeNFrefRefNFMod)Enum.Parse(typeof(TNFeInfNFeIdeNFrefRefNFMod), "Item" + (Convert.ToInt16(modelo).ToString().PadLeft(2, '0')))
                                 }
                                 */
                                };
                            notaEnviar.infNFe.ide.NFref[i].SetItem(relacionada.Chave);
                            i++;
                        }
                    }


                    if (nota.CollectionNfPagamentoClassNfPrincipal.Count > 0)
                    {
                        notaEnviar.infNFe.pag = new TNFeInfNFePag();
                        notaEnviar.infNFe.pag.detPag = new Collection<TNFeInfNFePagDetPag>(Enumerable.Repeat<TNFeInfNFePagDetPag>(null, nota.CollectionNfPagamentoClassNfPrincipal.Count).ToList());

                        int i = 0;
                        foreach (NfPagamentoClass pagamento in nota.CollectionNfPagamentoClassNfPrincipal)
                        {
                            notaEnviar.infNFe.pag.detPag[i] = new TNFeInfNFePagDetPag()
                            {
                                vPag = pagamento.Valor.ToString("F2", CultureInfo.InvariantCulture),

                            };

                            switch (pagamento.Tipo)
                            {
                                case NfPagamentoTipo.Dinheiro:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.Dinheiro;
                                    break;
                                case NfPagamentoTipo.Cheque:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.Cheque;
                                    break;
                                case NfPagamentoTipo.CartaoCredito:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.CartaoCredito;
                                    break;
                                case NfPagamentoTipo.CartaoDebito:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.CartaoDebito;
                                    break;
                                case NfPagamentoTipo.CreditoLoja:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.CreditoLoja;
                                    break;
                                case NfPagamentoTipo.ValeAlimentacao:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.ValeAlimentacao;
                                    break;
                                case NfPagamentoTipo.ValeRefeicao:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.ValeRefeicao;
                                    break;
                                case NfPagamentoTipo.ValePresente:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.ValePresente;
                                    break;
                                case NfPagamentoTipo.ValeCombustivel:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.ValeCombustivel;
                                    break;
                                case NfPagamentoTipo.BoletoBancario:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.BoletoBancario;
                                    break;
                                case NfPagamentoTipo.DepositoBancario:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.DepositoBancario;
                                    break;
                                case NfPagamentoTipo.Pix:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.Pix;
                                    break;
                                case NfPagamentoTipo.TransferenciaBancaria:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.TransfereciaBancaria;
                                    break;
                                case NfPagamentoTipo.ProgramaFidelidade:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.ProgramaFidelidade;
                                    break;
                                case NfPagamentoTipo.SemPagamento:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.SemPagamento;
                                    break;
                                case NfPagamentoTipo.Outros:
                                    notaEnviar.infNFe.pag.detPag[i].tPagLegado = TNFeInfNFePagDetPagTPagLegado.Outros;

                                    if (string.IsNullOrEmpty(pagamento.TipoDescricao) || pagamento.TipoDescricao.Trim().Length < 2)
                                    {
                                        throw new ExcecaoTratada("Para tipo de pagamento 99:Outros deve ser informada uma descrição de ao menos 2 caracteres");

                                    }
                                    notaEnviar.infNFe.pag.detPag[i].xPag = pagamento.TipoDescricao;
                                    break;

                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            if (notaEnviar.infNFe.pag.detPag[i].tPagLegado == TNFeInfNFePagDetPagTPagLegado.CartaoCredito || notaEnviar.infNFe.pag.detPag[i].tPagLegado == TNFeInfNFePagDetPagTPagLegado.CartaoDebito)
                            {

                                if (!pagamento.TipoIntegracao.HasValue)
                                {
                                    throw new Exception("O tipo do pagamento é cartão e não foi informado o tipo da integração");
                                }
                                if (pagamento.TipoIntegracao.Value == NfPagamentoTipoIntegracao.Integrado && (string.IsNullOrEmpty(pagamento.CnpjCredenciadora) || string.IsNullOrEmpty(pagamento.NumeroAutorizacao)))
                                {
                                    throw new Exception("O tipo do pagamento é cartão (Integrado) e não foi informado o CNPJ da credenciadora e/ou o número da autorização");
                                }

                                notaEnviar.infNFe.pag.detPag[i].card = new TNFeInfNFePagDetPagCard()
                                {
                                    tpIntegra = (TNFeInfNFePagDetPagCardTpIntegra) Enum.Parse(typeof(TNFeInfNFePagDetPagCardTpIntegra), "Item" + (Convert.ToInt16(pagamento.TipoIntegracao))),
                                    tpIntegraSpecified = true,
                                    tBandLegado = (TNFeInfNFePagDetPagCardTBandLegado) Enum.Parse(typeof(TNFeInfNFePagDetPagCardTBandLegado), "Item" + (Convert.ToInt16(pagamento.Bandeira.Value).ToString().PadLeft(2, '0'))),
                                    tBandSpecified = true
                                };

                                if (pagamento.TipoIntegracao.Value == NfPagamentoTipoIntegracao.Integrado)
                                {
                                    notaEnviar.infNFe.pag.detPag[i].card.cAut = pagamento.NumeroAutorizacao.Trim();
                                    notaEnviar.infNFe.pag.detPag[i].card.CNPJ = pagamento.CnpjCredenciadora.Trim();
                                }
                            }

                            i++;
                        }
                    }
                    else
                    {
                        throw new ExcecaoTratada("A nota fiscal não possui pagamento registrado e o campo de pagamento é obrigatório");
                    }





                    #endregion

                    #region Itens da NF

                    double totalIpiDevolvido = 0;
                    double totalvFCP = 0;
                    double totalvFCPSt = 0;
                    double totalvFCPRet = 0;

                    notaEnviar.infNFe.det = new Collection<TNFeInfNFeDet>(System.Linq.Enumerable.Repeat<TNFeInfNFeDet>(null, nota.CollectionNfItemClassNfPrincipal.Count).ToList());


                    for (int i = 0; i < nota.CollectionNfItemClassNfPrincipal.Count; i++)
                    {
                        #region validação EAN

                        if (!string.IsNullOrWhiteSpace(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Gtin))
                        {
                            Regex regEan = new Regex("[0-9]{0}|[0-9]{8}|[0-9]{12,14}");

                            if (!regEan.IsMatch(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Gtin.Trim()))
                            {
                                throw new Exception("Código Ean inválido para o produto " + nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Codigo.Trim() + ": " + nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Gtin.Trim());
                            }
                        }
                        else
                        {
                            nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Gtin = "SEM GTIN";
                        }


                        if (string.IsNullOrWhiteSpace(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.GtimUnidadeTrinutacao))
                        {
                            nota.CollectionNfItemClassNfPrincipal[i].NfProduto.GtimUnidadeTrinutacao = "SEM GTIN";
                        }


                        #endregion

                        string descricaoItem = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Descricao.Trim();
                        if (i == 0 && nota.ModeloDocFiscal == "65" && nota.Homologacao)
                        {
                            descricaoItem = "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                        }


                        TNFeInfNFeDetProd produto = new TNFeInfNFeDetProd
                        {
                            cProd = FuncoesAuxiliares.RemoveInvalidXmlChars(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Codigo.Trim()),
                            cEAN = (nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Gtin ?? "SEM GTIN").Trim(),
                            xProd = FuncoesAuxiliares.RemoveInvalidXmlChars(descricaoItem),
                            NCM = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Ncm.Trim(),
                            EXTIPI = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Extipi),

                            uCom = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Unidade.Trim(),
                            qCom = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Quantidade.ToString("F4", CultureInfo.InvariantCulture),
                            vUnCom = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.ValorUnitario.ToString("F10", CultureInfo.InvariantCulture),
                            vProd = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.ValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture),
                            cEANTrib = (nota.CollectionNfItemClassNfPrincipal[i].NfProduto.GtimUnidadeTrinutacao ?? "SEM GTIN").Trim(),
                            uTrib = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.UnidadeTributacao.Trim(),
                            qTrib = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.QuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture),
                            vUnTrib = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.ValorUnitarioTrinutacao.ToString("F10", CultureInfo.InvariantCulture),
                            vFrete = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.ValorFrete.ToString("F2", CultureInfo.InvariantCulture)),
                            vSeg = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.ValorSeguro.ToString("F2", CultureInfo.InvariantCulture)),
                            vDesc = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.ValorDesconto.ToString("F2", CultureInfo.InvariantCulture)),
                            indTot = TNFeInfNFeDetProdIndTot.Item1,
                            vOutro = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.OutrasDespesasAcessorias.ToString("F2", CultureInfo.InvariantCulture)),
                            xPed = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Xped),
                            nItemPed = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.NumeroItemPedido.HasValue ? nota.CollectionNfItemClassNfPrincipal[i].NfProduto.NumeroItemPedido.Value.ToString() : null),
                            CEST = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.Cest),
                            cBenef = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.CodigoBeneficio),
                           
                           
                        };

                        switch (nota.CollectionNfItemClassNfPrincipal[i].NfProduto.TipoProdutoEspecifico)
                        {
                            case NfeTipoProdutoEspecifico.Comum:
                                break;
                            case NfeTipoProdutoEspecifico.Medicamento:

                                if (string.IsNullOrWhiteSpace(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.MedicamentoCodigoAnvisa))
                                {
                                    throw new ExcecaoTratada("O item foi identificado como medicamento mas não possui código da anvisa: " + produto.cProd);
                                }

                                if (!nota.CollectionNfItemClassNfPrincipal[i].NfProduto.MedicamentoPrecoMaximoConsumidor.HasValue)
                                {
                                    throw new ExcecaoTratada("O item foi identificado como medicamento mas não possui preço máximo ao consumidor: " + produto.cProd);
                                }

                                if (nota.CollectionNfItemClassNfPrincipal[i].NfProduto.CollectionNfProdutoRastreabilidadeClassNfProduto.Count == 0)
                                {
                                    throw new ExcecaoTratada("O item foi identificado como medicamento mas não possui rastreabilidade: " + produto.cProd + " / linha " + (i + 1));
                                }

                                produto.AddItem(new TNFeInfNFeDetProdMed()
                                {
                                    cProdANVISA = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.MedicamentoCodigoAnvisa,
                                    vPMC = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.MedicamentoPrecoMaximoConsumidor.Value.ToString("F2", CultureInfo.InvariantCulture)
                                });
                              

                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }


                        if (nota.CollectionNfItemClassNfPrincipal[i].NfProduto.CollectionNfProdutoRastreabilidadeClassNfProduto.Count > 0)
                        {

                            if (Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfProduto.CollectionNfProdutoRastreabilidadeClassNfProduto.Sum(a => a.Quantidade) - nota.CollectionNfItemClassNfPrincipal[i].NfProduto.QuantidadeTributavel) > 0.001)
                            {
                                throw new ExcecaoTratada("A quantidade rastreada não é igual a quantidade do item na nota fiscal: " + produto.cProd + " / linha " + (i + 1));
                            }

                            produto.rastro = new Collection<TNFeInfNFeDetProdRastro>(System.Linq.Enumerable.Repeat<TNFeInfNFeDetProdRastro>(null, nota.CollectionNfItemClassNfPrincipal[i].NfProduto.CollectionNfProdutoRastreabilidadeClassNfProduto.Count).ToList());
                            int j = 0;
                            foreach (NfProdutoRastreabilidadeClass rastreabilidade in nota.CollectionNfItemClassNfPrincipal[i].NfProduto.CollectionNfProdutoRastreabilidadeClassNfProduto)
                            {
                                produto.rastro[j] = new TNFeInfNFeDetProdRastro()
                                {
                                    nLote = rastreabilidade.NumeroLote,
                                    qLote = rastreabilidade.Quantidade.ToString("F3", CultureInfo.InvariantCulture),
                                    dFab = rastreabilidade.DataFabricacao.ToString("yyyy-MM-dd"),
                                    dVal = rastreabilidade.DataValidade.ToString("yyyy-MM-dd"),
                                    cAgreg = FuncoesAuxiliares.ValidaCampoOpcional(rastreabilidade.CodigoAgregacao)
                                };
                                j++;

                            }

                        }


                        notaEnviar.infNFe.det[i] = new TNFeInfNFeDet
                        {
                            nItem = nota.CollectionNfItemClassNfPrincipal[i].NumeroItem.ToString().Trim(),
                            prod = produto,
                            infAdProd = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].InformacoesAdd),
                            imposto = new TNFeInfNFeDetImposto()
                        };

                        //int tmpNCM;
                        //if (int.TryParse(notaEnviar.infNFe.det[i].prod.NCM, out tmpNCM))
                        //{
                        //    if (tmpNCM == 0)
                        //    {
                        //        notaEnviar.infNFe.det[i].prod.NCM = "00";
                        //    }
                        //}

                        //CFOP

                        if (nota.CollectionNfItemClassNfPrincipal[i].Cfop < 1000 || nota.CollectionNfItemClassNfPrincipal[i].Cfop > 9999)
                        {
                            throw new Exception("CFOP inválido: " + nota.CollectionNfItemClassNfPrincipal[i].Cfop);
                        }
                        else
                        {
                            notaEnviar.infNFe.det[i].prod.CFOP = nota.CollectionNfItemClassNfPrincipal[i].Cfop.ToString();
                        }



                        int countImpostos = 0;
                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms != null)
                        {
                            countImpostos++;
                        }

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIimp != null)
                        {
                            countImpostos++;
                        }

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi != null)
                        {
                            countImpostos++;
                        }

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIss != null)
                        {
                            countImpostos++;
                        }


                        if (nota.CollectionNfItemClassNfPrincipal[i].ValorTotalAproximadoTributos.HasValue)
                        {
                            notaEnviar.infNFe.det[i].imposto.vTotTrib =
                                nota.CollectionNfItemClassNfPrincipal[i].ValorTotalAproximadoTributos.Value.ToString(
                                    "F2", CultureInfo.InvariantCulture);
                        }
                        
                        countImpostos = 0;

                        #region ICMS

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms != null)
                        {
                            TNFeInfNFeDetImpostoICMS icms = new TNFeInfNFeDetImpostoICMS();


                            switch (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Cst)
                            {
                                case "00":
                                    TNFeInfNFeDetImpostoICMSICMS00 icms00 = new TNFeInfNFeDetImpostoICMSICMS00()
                                    {
                                        CST = TNFeInfNFeDetImpostoICMSICMS00CST.Item00,
                                        modBC =
                                            (TNFeInfNFeDetImpostoICMSICMS00ModBC)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS00ModBC),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        pICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                    };

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms00.pFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms00.vFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        totalvFCP = Math.Round(totalvFCP + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value, 2), 2);
                                    }
                                    
                                    icms.SetItem(icms00);
                                    break;
                                case "10":
                                    TNFeInfNFeDetImpostoICMSICMS10 icms10 = new TNFeInfNFeDetImpostoICMSICMS10()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = TNFeInfNFeDetImpostoICMSICMS10CST.Item10, modBC = (TNFeInfNFeDetImpostoICMSICMS10ModBC) Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS10ModBC), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                        modBCST = (TNFeInfNFeDetImpostoICMSICMS10ModBCST) Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS10ModBCST), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt)),
                                        pMVAST = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture)),
                                        pRedBCST = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)),
                                        vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms10.pFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms10.vFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms10.vBCFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        icms10.pFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms10.vFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms10.vBCFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        totalvFCP = Math.Round(totalvFCP + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value, 2), 2);
                                        totalvFCPSt = Math.Round(totalvFCPSt + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                    }

                                    icms10.motDesICMSSTSpecified = false;

                                    icms.SetItem(icms10);
                                    break;
                                case "20":
                                    TNFeInfNFeDetImpostoICMSICMS20 icms20 = new TNFeInfNFeDetImpostoICMSICMS20()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = TNFeInfNFeDetImpostoICMSICMS20CST.Item20,
                                        modBC =
                                            (TNFeInfNFeDetImpostoICMSICMS20ModBC)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS20ModBC),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),
                                        pRedBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture),
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture)

                                    };

                                    if (icms20.vICMSDeson != null)
                                    {
                                        icms20.motDesICMSSpecified = true;

                                        icms20.motDesICMS = (TNFeInfNFeDetImpostoICMSICMS20MotDesICMS)
                                            Enum.Parse(typeof(TNFeInfNFeDetImpostoICMSICMS20MotDesICMS),
                                                "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms));
                                    }

                                    icms.SetItem(icms20);


                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms20.pFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms20.vFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms20.vBCFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        totalvFCP = Math.Round(totalvFCP + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value, 2), 2);
                                    }

                                    break;
                                case "30":
                                    TNFeInfNFeDetImpostoICMSICMS30 icms30 = new TNFeInfNFeDetImpostoICMSICMS30()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = TNFeInfNFeDetImpostoICMSICMS30CST.Item30,
                                        modBCST =
                                            (TNFeInfNFeDetImpostoICMSICMS30ModBCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS30ModBCST),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt)),
                                        pMVAST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        pRedBCST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture)


                                    };

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == 0 || nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == null)
                                    {
                                        //Antes existia um campo specified para deixar vazio.
                                        icms30.motDesICMSSpecified = false;
                                    }
                                    else
                                    {
                                        icms30.motDesICMS =
                                            (TNFeInfNFeDetImpostoICMSICMS30MotDesICMS)
                                                Enum.Parse(typeof(TNFeInfNFeDetImpostoICMSICMS30MotDesICMS), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms.ToString());
                                        icms30.vICMSDeson = 0.ToString("F2", CultureInfo.InvariantCulture);
                                    }


                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms30.pFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms30.vFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms30.vBCFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        totalvFCPSt = Math.Round(totalvFCPSt + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                    }

                                    icms.SetItem(icms30);
                                    break;

                                case "40":
                                case "41":
                                case "50":
                                    TNFeInfNFeDetImpostoICMSICMS40 icms40 = new TNFeInfNFeDetImpostoICMSICMS40()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = (TNFeInfNFeDetImpostoICMSICMS40CST)
                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS40CST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Cst)
                                        //  motDesICMS = (TNFeInfNFeDetImpostoICMSICMS40MotDesICMS) Enum.Parse(typeof(TNFeInfNFeDetImpostoICMSICMS40MotDesICMS), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracao.ToString())
                                    };

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == 0 || nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == null)
                                    {
                                        //Antes existia um campo specified para deixar vazio.
                                        icms40.motDesICMSSpecified = false;
                                    }
                                    else
                                    {
                                        icms40.motDesICMSSpecified = true;
                                        icms40.motDesICMS =
                                            (TNFeInfNFeDetImpostoICMSICMS40MotDesICMS)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS40MotDesICMS), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms.ToString());
                                        icms40.vICMSDeson = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsDesonerado.ToString("F2", CultureInfo.InvariantCulture);
                                    }

                                    icms.SetItem(icms40);

                                    break;
                                case "51":
                                    TNFeInfNFeDetImpostoICMSICMS51 icms51 = new TNFeInfNFeDetImpostoICMSICMS51()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = TNFeInfNFeDetImpostoICMSICMS51CST.Item51,
                                        modBCSpecified = true,
                                        modBC = (TNFeInfNFeDetImpostoICMSICMS51ModBC) Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS51ModBC), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),

                                        //Deixada a impressão na forma completa pois o PR aceita/exige dessa forma

                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMS =nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        

                                        pRedBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBc.ToString("F2",CultureInfo.InvariantCulture),
                                        vICMS  = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                        
                                        vICMSOp = (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsOperacao ?? 0).ToString("F2", CultureInfo.InvariantCulture),
                                        pDif = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualDiferimento.ToString("F4", CultureInfo.InvariantCulture),
                                        vICMSDif = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.IcmsDiferido.ToString("F2", CultureInfo.InvariantCulture),
                                    };

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms51.pFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms51.vFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms51.vBCFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        totalvFCP = Math.Round(totalvFCP + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value, 2), 2);
                                    }

                                    icms.SetItem(icms51);
                                    break;

                                case "60":
                                    TNFeInfNFeDetImpostoICMSICMS60 icms60 = new TNFeInfNFeDetImpostoICMSICMS60()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = (TNFeInfNFeDetImpostoICMSICMS60CST)
                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS60CST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Cst),
                                        vBCSTRet =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        vICMSSTRet =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente.ToString("F2",
                                                CultureInfo
                                                    .
                                                    InvariantCulture))
                                    };
                                    icms.SetItem(icms60);

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms60.pFCPSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms60.vFCPSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms60.vBCFCPSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);


                                        totalvFCPRet = Math.Round(totalvFCPRet + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                    }
                                    
                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfProduto.NfProdutoIcms.AliquotaSuportadaConsumidorFinal.HasValue)
                                    {
                                        icms60.pST = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.NfProdutoIcms.AliquotaSuportadaConsumidorFinal.Value.ToString("F2", CultureInfo.InvariantCulture);
                                    }



                                    break;

                                case "70":
                                    TNFeInfNFeDetImpostoICMSICMS70 icms70 = new TNFeInfNFeDetImpostoICMSICMS70()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = TNFeInfNFeDetImpostoICMSICMS70CST.Item70,
                                        modBC =
                                            (TNFeInfNFeDetImpostoICMSICMS70ModBC)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS70ModBC),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                        modBCST =
                                            (TNFeInfNFeDetImpostoICMSICMS70ModBCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS70ModBCST),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt)),
                                        pMVAST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        pRedBCST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pRedBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == 0 || nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == null)
                                    {
                                        //Antes existia um campo specified para deixar vazio.
                                        icms70.motDesICMSSpecified = false;
                                    }
                                    else
                                    {
                                        icms70.motDesICMS =
                                            (TNFeInfNFeDetImpostoICMSICMS70MotDesICMS)
                                                Enum.Parse(typeof(TNFeInfNFeDetImpostoICMSICMS70MotDesICMS), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms.ToString());
                                        icms70.vICMSDeson = 0.ToString("F2", CultureInfo.InvariantCulture);
                                    }

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms70.pFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms70.vFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms70.vBCFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        icms70.pFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms70.vFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms70.vBCFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        totalvFCP = Math.Round(totalvFCP + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value, 2), 2);
                                        totalvFCPSt = Math.Round(totalvFCPSt + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                    }

                                    icms70.motDesICMSSTSpecified = false;

                                    icms.SetItem(icms70);
                                    break;

                                case "90":
                                    TNFeInfNFeDetImpostoICMSICMS90 icms90 = new TNFeInfNFeDetImpostoICMSICMS90()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = TNFeInfNFeDetImpostoICMSICMS90CST.Item90,
                                        modBC =
                                            (TNFeInfNFeDetImpostoICMSICMS90ModBC)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS90ModBC),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                        modBCST =
                                            (TNFeInfNFeDetImpostoICMSICMS90ModBCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS90ModBCST),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt)),
                                        pMVAST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        pRedBCST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pRedBC =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture))
                                    };

                                    if (icms90.vBCST != null)
                                    {
                                        icms90.modBCSTSpecified = true;
                                    }

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == 0 || nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms == null)
                                    {
                                        //Antes existia um campo specified para deixar vazio.
                                        icms90.motDesICMSSpecified = false;
                                    }
                                    else
                                    {
                                        icms90.motDesICMS =
                                            (TNFeInfNFeDetImpostoICMSICMS90MotDesICMS)
                                                Enum.Parse(typeof(TNFeInfNFeDetImpostoICMSICMS90MotDesICMS), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.MotivoDesoneracaoIcms.ToString());
                                        icms90.vICMSDeson = 0.ToString("F2", CultureInfo.InvariantCulture);
                                    }

                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                    {
                                        icms90.pFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms90.vFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms90.vBCFCP = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                        icms90.pFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms90.vFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                        icms90.vBCFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);


                                        totalvFCP = Math.Round(totalvFCP + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpValor.Value, 2), 2);
                                        totalvFCPSt = Math.Round(totalvFCPSt + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                    }

                                    icms90.motDesICMSSTSpecified = false;

                                    icms.SetItem(icms90);
                                    break;

                                case "10a":
                                case "90a":
                                    TNFeInfNFeDetImpostoICMSICMSPart icmsPart = new TNFeInfNFeDetImpostoICMSICMSPart()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST =
                                            nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Cst == "10a"
                                                ? TNFeInfNFeDetImpostoICMSICMSPartCST.Item10
                                                : TNFeInfNFeDetImpostoICMSICMSPartCST.Item90,
                                        modBC =
                                            (TNFeInfNFeDetImpostoICMSICMSPartModBC)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSPartModBC),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                        modBCST =
                                            (TNFeInfNFeDetImpostoICMSICMSPartModBCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSPartModBCST),
                                                    "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt)),
                                        pMVAST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        pRedBCST =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                        pRedBC =
                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2",
                                                CultureInfo.
                                                    InvariantCulture)),
                                        UFST = FuncoesAuxiliares.Sigla2TUf(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.SiglaUfDevidoIcms),
                                        pBCOp = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualBcOperacaoPropria.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    icms.SetItem(icmsPart);
                                    break;
                                case "41a":
                                case "60a":
                                    TNFeInfNFeDetImpostoICMSICMSST icmsSt = new TNFeInfNFeDetImpostoICMSICMSST()
                                    {
                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                        CST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Cst == "41a"?TNFeInfNFeDetImpostoICMSICMSSTCST.Item41:TNFeInfNFeDetImpostoICMSICMSSTCST.Item60,
                                        vBCSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMSSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture),
                                        vBCSTDest = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture),
                                        vICMSSTDest = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture)
                                    };
                                    icms.SetItem(icmsSt);
                                    break;

                                case "SN":
                                    switch (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.CsoSimples)
                                    {
                                        case 101:
                                            TNFeInfNFeDetImpostoICMSICMSSN101 icms101 = new TNFeInfNFeDetImpostoICMSICMSSN101()
                                            {
                                                orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                                CSOSN = TNFeInfNFeDetImpostoICMSICMSSN101CSOSN.Item101,
                                                pCredSN = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                vCredICMSSN =
                                                    nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture)
                                            };

                                            icms.SetItem(icms101);
                                            break;

                                        case 102:
                                        case 103:
                                        case 300:
                                        case 400:
                                            TNFeInfNFeDetImpostoICMSICMSSN102 icms102 = new TNFeInfNFeDetImpostoICMSICMSSN102()
                                            {
                                                orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                                CSOSN =
                                                    (TNFeInfNFeDetImpostoICMSICMSSN102CSOSN)
                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN102CSOSN),
                                                            "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.CsoSimples)
                                            };

                                            icms.SetItem(icms102);
                                            break;

                                        case 201:
                                            TNFeInfNFeDetImpostoICMSICMSSN201 icms201 = new TNFeInfNFeDetImpostoICMSICMSSN201()
                                            {
                                                orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                                CSOSN = TNFeInfNFeDetImpostoICMSICMSSN201CSOSN.Item201,
                                                modBCST =
                                                    (TNFeInfNFeDetImpostoICMSICMSSN201ModBCST)
                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN201ModBCST),
                                                            "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt)),
                                                pMVAST =
                                                    FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2",
                                                        CultureInfo
                                                            .
                                                            InvariantCulture)),
                                                pRedBCST =
                                                    FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString(
                                                        "F2",
                                                        CultureInfo.
                                                            InvariantCulture)),
                                                vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                pCredSN = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                vCredICMSSN =
                                                    nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture)
                                            };

                                            if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                            {
                                                icms201.pFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms201.vFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms201.vBCFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                                totalvFCPSt = Math.Round(totalvFCPSt + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                            }

                                            icms.SetItem(icms201);
                                            break;
                                        case 202:
                                        case 203:
                                            TNFeInfNFeDetImpostoICMSICMSSN202 icms202 = new TNFeInfNFeDetImpostoICMSICMSSN202()
                                            {
                                                orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                                CSOSN =
                                                    (TNFeInfNFeDetImpostoICMSICMSSN202CSOSN)
                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN202CSOSN),
                                                            "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.CsoSimples),
                                                modBCST =
                                                    (TNFeInfNFeDetImpostoICMSICMSSN202ModBCST)
                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN202ModBCST),
                                                            "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt)),
                                                pMVAST =
                                                    FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2",
                                                        CultureInfo
                                                            .
                                                            InvariantCulture)),
                                                pRedBCST =
                                                    FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString(
                                                        "F2",
                                                        CultureInfo.
                                                            InvariantCulture)),
                                                vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture)
                                            };

                                            if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                            {
                                                icms202.pFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms202.vFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms202.vBCFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                                totalvFCPSt = Math.Round(totalvFCPSt + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                            }

                                            icms.SetItem(icms202);
                                            break;
                                        case 500:
                                            TNFeInfNFeDetImpostoICMSICMSSN500 icms500 = new TNFeInfNFeDetImpostoICMSICMSSN500()
                                            {
                                                orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                                CSOSN = TNFeInfNFeDetImpostoICMSICMSSN500CSOSN.Item500
                                              
                                            };

                                            if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                            {
                                                icms500.pFCPSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms500.vFCPSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms500.vBCFCPSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                
                                                totalvFCPRet = Math.Round(totalvFCPRet + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);

                                            }

                                            if (nota.CollectionNfItemClassNfPrincipal[i].NfProduto.NfProdutoIcms.AliquotaSuportadaConsumidorFinal.HasValue)
                                            {
                                                icms500.pST = nota.CollectionNfItemClassNfPrincipal[i].NfProduto.NfProdutoIcms.AliquotaSuportadaConsumidorFinal.Value.ToString("F2", CultureInfo.InvariantCulture);
                                            }

                                            if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente > 0 || nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente > 0)
                                            {
                                                icms500.vBCSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture);
                                                icms500.vICMSSTRet = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture);

                                            }

                                            icms.SetItem(icms500);
                                            break;
                                        case 900:
                                            TNFeInfNFeDetImpostoICMSICMSSN900 icms900 = new TNFeInfNFeDetImpostoICMSICMSSN900()
                                            {
                                                orig = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Origem)),
                                                CSOSN = TNFeInfNFeDetImpostoICMSICMSSN900CSOSN.Item900,
                                               
                                                pCredSN = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                vCredICMSSN = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                modBC =(TNFeInfNFeDetImpostoICMSICMSSN900ModBC)Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSPartModBC),"Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcIcms)),
                                                vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                pICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                vICMS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                pRedBC = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2",CultureInfo.InvariantCulture))
                                            };


                                            if (
                                                Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt) > Double.Epsilon ||
                                                Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt) > Double.Epsilon ||
                                                Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt) > Double.Epsilon 
                                                )
                                            {
                                                icms900.modBCSTSpecified = true;
                                                icms900.modBCST = (TNFeInfNFeDetImpostoICMSICMSSN900ModBCST) Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN900ModBCST), "Item" + Convert.ToInt16(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ModalidadeBcSt));
                                                icms900.pMVAST = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture));
                                                icms900.pRedBCST = FuncoesAuxiliares.ValidaCampoOpcional(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.PercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture));
                                                icms900.vBCST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorBcSt.ToString("F2", CultureInfo.InvariantCulture);
                                                icms900.pICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.AliquotaSt.ToString("F2", CultureInfo.InvariantCulture);
                                                icms900.vICMSST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.ValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture);

                                            
                                            }
                                            else
                                            {
                                                icms900.modBCSTSpecified = false;
                                                icms900.modBCST = TNFeInfNFeDetImpostoICMSICMSSN900ModBCST.Item4;
                                                icms900.pMVAST = null;
                                                icms900.pRedBCST = null;
                                                icms900.vBCST = null;
                                                icms900.pICMSST = null;
                                                icms900.vICMSST = null;

                                                
                                            }

                                            if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota.HasValue && Math.Abs(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpAliquota??0) > 0.0001)
                                            {
                                                icms900.pFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoAliquota.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms900.vFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value.ToString("F2", CultureInfo.InvariantCulture);
                                                icms900.vBCFCPST = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoBc.Value.ToString("F2", CultureInfo.InvariantCulture);

                                                totalvFCPSt = Math.Round(totalvFCPSt + Math.Round(nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIcms.FcpRetidoValor.Value, 2), 2);
                                            }

                                            icms.SetItem(icms900);
                                            break;

                                    }
                                    break;

                            }

                            notaEnviar.infNFe.det[i].imposto.AddImposto(icms);
                            countImpostos++;
                        }

                        #endregion

                        #region IPI

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi != null)
                        {

                            string cnpj = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.CnpjProdutor;
                            string codigoSelo = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.CodigoSeloControle;
                            int? quantidadeSelo = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.QuantidadeSeloControle;
                            string classeEnq = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.ClasseEnquadramento;
                            if (string.IsNullOrWhiteSpace(classeEnq))
                            {
                                throw new ExcecaoTratada("Classe de enquadramento do produto para o IPI é obrigatória");

                            }

                            TIpi ipi = new TIpi
                            {
                                CNPJProd = FuncoesAuxiliares.ValidaCampoOpcional(cnpj),
                                cSelo = FuncoesAuxiliares.ValidaCampoOpcional(codigoSelo),
                                qSelo =
                                    FuncoesAuxiliares.ValidaCampoOpcional(quantidadeSelo != null
                                        ? quantidadeSelo.Value.ToString("D")
                                        : ""),
                                cEnq = classeEnq.Trim()
                            };
                            switch (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.Cst)
                            {
                                case "00":
                                case "49":
                                case "50":
                                case "99":
                                    TIpiIPITrib ipiTrib = new TIpiIPITrib
                                    {
                                        CST = (TIpiIPITribCST) Enum.Parse(typeof(TIpiIPITribCST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.Cst),
                                        vIPI = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.ValorIpi.ToString("F2", CultureInfo.InvariantCulture),
                                    };

                                    //Tributacao por valor
                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.ModalidadeTributacao == 0)
                                    {
                                        ipiTrib.SetItem(TIpiIPITrib.ItemsChoiceType.vBC, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.ValorBc.ToString("F2", CultureInfo.InvariantCulture));
                                        ipiTrib.SetItem(TIpiIPITrib.ItemsChoiceType.pIPI, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.Aliquota.ToString("F2", CultureInfo.InvariantCulture));

                                    }
                                    else
                                    {
                                        ipiTrib.SetItem(TIpiIPITrib.ItemsChoiceType.qUnid, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.QuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture));
                                        ipiTrib.SetItem(TIpiIPITrib.ItemsChoiceType.vUnid, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.Aliquota.ToString("F4", CultureInfo.InvariantCulture));
                                    }
                                    ipi.SetItem(ipiTrib);
                                    break;

                                case "01":
                                case "02":
                                case "03":
                                case "04":
                                case "51":
                                case "52":
                                case "53":
                                case "54":
                                case "55":
                                    TIpiIPINT ipiNT = new TIpiIPINT()
                                    {
                                        CST = (TIpiIPINTCST) Enum.Parse(typeof (TIpiIPINTCST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIpi.Cst)
                                    };

                                    ipi.SetItem(ipiNT);
                                    break;


                            }

                            notaEnviar.infNFe.det[i].imposto.AddImposto(ipi);
                            countImpostos++;
                        }

                        #endregion

                        #region II

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIimp != null)
                        {
                            TNFeInfNFeDetImpostoII ii = new TNFeInfNFeDetImpostoII()
                            {
                                vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIimp.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                vDespAdu = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIimp.ValorDespesasAduaneiras.ToString("F2", CultureInfo.InvariantCulture),
                                vII = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIimp.ValorIimp.ToString("F2", CultureInfo.InvariantCulture),
                                vIOF = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIimp.ValorIof.ToString("F2", CultureInfo.InvariantCulture)
                            };

                            notaEnviar.infNFe.det[i].imposto.AddImposto(ii);
                            countImpostos++;
                        }

                        #endregion

                        #region ISS

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIss != null)
                        {
                            TNFeInfNFeDetImpostoISSQN iss = new TNFeInfNFeDetImpostoISSQN()
                            {
                                vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIss.Bc.ToString("F2", CultureInfo.InvariantCulture),
                                vAliq = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIss.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                vISSQN = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIss.ValorIss.ToString("F2", CultureInfo.InvariantCulture),
                                cMunFG = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIss.CodMunicipioFatoGerador.ToString().Trim(),
                                cListServLegado = (TCListServLegado) Enum.Parse(typeof (TCListServLegado), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoIss.CodigoServico.ToString())
                            };

                            notaEnviar.infNFe.det[i].imposto.AddImposto(iss);
                            countImpostos++;
                        }

                        #endregion

                        #region Pis

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis != null)
                        {
                            notaEnviar.infNFe.det[i].imposto.PIS = new TNFeInfNFeDetImpostoPIS();

                            switch (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Cst)
                            {
                                case "01":
                                case "02":
                                    TNFeInfNFeDetImpostoPISPISAliq pisAliq = new TNFeInfNFeDetImpostoPISPISAliq()
                                    {
                                        CST =
                                            nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Cst == "01"
                                                ? TNFeInfNFeDetImpostoPISPISAliqCST.Item01
                                                : TNFeInfNFeDetImpostoPISPISAliqCST.Item02,
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pPIS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vPIS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    notaEnviar.infNFe.det[i].imposto.PIS.SetItem(pisAliq);
                                    break;

                                case "03":
                                    TNFeInfNFeDetImpostoPISPISQtde pisQtd = new TNFeInfNFeDetImpostoPISPISQtde()
                                    {
                                        CST = TNFeInfNFeDetImpostoPISPISQtdeCST.Item03,
                                        qBCProd = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture),
                                        vAliqProd = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Aliquota.ToString("F4", CultureInfo.InvariantCulture),
                                        vPIS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    notaEnviar.infNFe.det[i].imposto.PIS.SetItem(pisQtd);
                                    break;

                                case "04":
                                case "06":
                                case "07":
                                case "08":
                                case "09":
                                    TNFeInfNFeDetImpostoPISPISNT pisNt = new TNFeInfNFeDetImpostoPISPISNT()
                                    {
                                        CST =
                                            (TNFeInfNFeDetImpostoPISPISNTCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoPISPISNTCST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Cst)
                                    };
                                    notaEnviar.infNFe.det[i].imposto.PIS.SetItem(pisNt);
                                    break;
                                case "49":
                                case "50":
                                case "51":
                                case "52":
                                case "53":
                                case "54":
                                case "55":
                                case "56":
                                case "60":
                                case "61":
                                case "62":
                                case "63":
                                case "64":
                                case "65":
                                case "66":
                                case "67":
                                case "70":
                                case "71":
                                case "72":
                                case "73":
                                case "74":
                                case "75":
                                case "98":
                                case "99":
                                    TNFeInfNFeDetImpostoPISPISOutr pisOut = new TNFeInfNFeDetImpostoPISPISOutr()
                                    {
                                        CST =
                                            (TNFeInfNFeDetImpostoPISPISOutrCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoPISPISOutrCST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Cst),
                                        vPIS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.ValorPis.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    //Tributacao por valor
                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.ModalidadeTributacao == 0)
                                    {
                                        pisOut.SetItem(TNFeInfNFeDetImpostoPISPISOutr.ItemsChoiceType1.vBC, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.ValorBc.ToString("F2", CultureInfo.InvariantCulture));
                                        pisOut.SetItem(TNFeInfNFeDetImpostoPISPISOutr.ItemsChoiceType1.pPIS, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Aliquota.ToString("F2", CultureInfo.InvariantCulture));

                                    }
                                    else
                                    {
                                        pisOut.SetItem(TNFeInfNFeDetImpostoPISPISOutr.ItemsChoiceType1.qBCProd, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.QuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture));
                                        pisOut.SetItem(TNFeInfNFeDetImpostoPISPISOutr.ItemsChoiceType1.vAliqProd, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoPis.Aliquota.ToString("F4", CultureInfo.InvariantCulture));
                                    }

                                    notaEnviar.infNFe.det[i].imposto.PIS.SetItem(pisOut);
                                    break;
                            }


                        }

                        #endregion

                        #region Confins

                        if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins != null)
                        {
                            notaEnviar.infNFe.det[i].imposto.COFINS = new TNFeInfNFeDetImpostoCOFINS();

                            switch (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Cst)
                            {
                                case "01":
                                case "02":
                                    TNFeInfNFeDetImpostoCOFINSCOFINSAliq cofinsAliq = new TNFeInfNFeDetImpostoCOFINSCOFINSAliq()
                                    {
                                        CST =
                                            nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Cst == "01"
                                                ? TNFeInfNFeDetImpostoCOFINSCOFINSAliqCST.Item01
                                                : TNFeInfNFeDetImpostoCOFINSCOFINSAliqCST.Item02,
                                        vBC = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                        pCOFINS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture),
                                        vCOFINS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    notaEnviar.infNFe.det[i].imposto.COFINS.SetItem(cofinsAliq);
                                    break;

                                case "03":
                                    TNFeInfNFeDetImpostoCOFINSCOFINSQtde cofinsQtd = new TNFeInfNFeDetImpostoCOFINSCOFINSQtde()
                                    {
                                        CST = TNFeInfNFeDetImpostoCOFINSCOFINSQtdeCST.Item03,
                                        qBCProd = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture),
                                        vAliqProd = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F4", CultureInfo.InvariantCulture),
                                        vCOFINS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    notaEnviar.infNFe.det[i].imposto.COFINS.SetItem(cofinsQtd);
                                    break;

                                case "04":
                                case "06":
                                case "07":
                                case "08":
                                case "09":
                                    TNFeInfNFeDetImpostoCOFINSCOFINSNT cofinsNt = new TNFeInfNFeDetImpostoCOFINSCOFINSNT()
                                    {
                                        CST =
                                            (TNFeInfNFeDetImpostoCOFINSCOFINSNTCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoCOFINSCOFINSNTCST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Cst)
                                    };
                                    notaEnviar.infNFe.det[i].imposto.COFINS.SetItem(cofinsNt);
                                    break;
                                case "49":
                                case "50":
                                case "51":
                                case "52":
                                case "53":
                                case "54":
                                case "55":
                                case "56":
                                case "60":
                                case "61":
                                case "62":
                                case "63":
                                case "64":
                                case "65":
                                case "66":
                                case "67":
                                case "70":
                                case "71":
                                case "72":
                                case "73":
                                case "74":
                                case "75":
                                case "98":
                                case "99":
                                    TNFeInfNFeDetImpostoCOFINSCOFINSOutr cofinsOut = new TNFeInfNFeDetImpostoCOFINSCOFINSOutr()
                                    {
                                        CST =
                                            (TNFeInfNFeDetImpostoCOFINSCOFINSOutrCST)
                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoCOFINSCOFINSOutrCST), "Item" + nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Cst),
                                        vCOFINS = nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.ValorCofins.ToString("F2", CultureInfo.InvariantCulture)
                                    };

                                    //Tributacao por valor
                                    if (nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.ModalidadeTributacao == 0)
                                    {

                                        cofinsOut.SetItem(TNFeInfNFeDetImpostoCOFINSCOFINSOutr.ItemsChoiceType3.vBC, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.ValorBc.ToString("F2", CultureInfo.InvariantCulture));
                                        cofinsOut.SetItem(TNFeInfNFeDetImpostoCOFINSCOFINSOutr.ItemsChoiceType3.pCOFINS, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F2", CultureInfo.InvariantCulture));

                                    }
                                    else
                                    {
                                        cofinsOut.SetItem(TNFeInfNFeDetImpostoCOFINSCOFINSOutr.ItemsChoiceType3.qBCProd, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.QuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture));
                                        cofinsOut.SetItem(TNFeInfNFeDetImpostoCOFINSCOFINSOutr.ItemsChoiceType3.vAliqProd, nota.CollectionNfItemClassNfPrincipal[i].NfItemTributo.NfItemTributoCofins.Aliquota.ToString("F4", CultureInfo.InvariantCulture));

                                    }

                                    notaEnviar.infNFe.det[i].imposto.COFINS.SetItem(cofinsOut);
                                    break;
                            }


                        }

                        #endregion

                        #region DI

                        NfItemClass item = nota.CollectionNfItemClassNfPrincipal[i];
                        if (nota.CollectionNfItemClassNfPrincipal[i].CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Count > 0)
                        {
                            notaEnviar.infNFe.det[i].prod.DI = new Collection<TNFeInfNFeDetProdDI>(System.Linq.Enumerable.Repeat<TNFeInfNFeDetProdDI>(null, item.CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Count).ToList());
                            for (int k = 0; k < item.CollectionNfProdutoDeclaracaoImportacaoClassNfItem.Count; k++)
                            {
                                NfProdutoDeclaracaoImportacaoClass declaracaoImportacao = item.CollectionNfProdutoDeclaracaoImportacaoClassNfItem[k];

                                notaEnviar.infNFe.det[i].prod.DI[k] = new TNFeInfNFeDetProdDI
                                {
                                    UFDesemb = FuncoesAuxiliares.Sigla2TUfEmi(declaracaoImportacao.UfDesembaraco),
                                    cExportador = declaracaoImportacao.CodigoExportador,
                                    dDI = declaracaoImportacao.DataRegistroDi.ToString("yyyy-MM-dd"),
                                    dDesemb = declaracaoImportacao.DataDesembaraco.ToString("yyyy-MM-dd"),
                                    nDI = declaracaoImportacao.NumeroDocImportacao,
                                    xLocDesemb = declaracaoImportacao.LocalDesembaraco,
                                    tpViaTransp = (TNFeInfNFeDetProdDITpViaTransp)Enum.Parse(typeof(TNFeInfNFeDetProdDITpViaTransp), "Item" + declaracaoImportacao.ViaTransporte),
                                    vAFRMM = FuncoesAuxiliares.ValidaCampoOpcional(declaracaoImportacao.ValorAfrmm.HasValue ? declaracaoImportacao.ValorAfrmm.Value.ToString("F2", CultureInfo.InvariantCulture) : ""),
                                    tpIntermedio = (TNFeInfNFeDetProdDITpIntermedio)Enum.Parse(typeof(TNFeInfNFeDetProdDITpIntermedio), "Item" + declaracaoImportacao.TipoIntermedio),
                                    CNPJ = FuncoesAuxiliares.ValidaCampoOpcional(declaracaoImportacao.CnpjAdquirente),
                                    adi = new Collection<TNFeInfNFeDetProdDIAdi>(System.Linq.Enumerable.Repeat<TNFeInfNFeDetProdDIAdi>(null, declaracaoImportacao.CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Count).ToList())
                                };

                                if (!string.IsNullOrEmpty(declaracaoImportacao.UfDesembaraco))
                                {
                                    notaEnviar.infNFe.det[i].prod.DI[k].UFTerceiro = FuncoesAuxiliares.Sigla2TUfEmi(declaracaoImportacao.UfDesembaraco);
                                    notaEnviar.infNFe.det[i].prod.DI[k].UFTerceiroSpecified = true;
                                }
                                else
                                {
                                    notaEnviar.infNFe.det[i].prod.DI[k].UFTerceiroSpecified = false;
                                }

                                for (int j = 0; j < declaracaoImportacao.CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao.Count; j++)
                                {
                                    NfProdutoDeclaracaoImportacaoAdicaoClass itemDi = declaracaoImportacao.CollectionNfProdutoDeclaracaoImportacaoAdicaoClassNfProdutoDeclaracaoImportacao[j];
                                    notaEnviar.infNFe.det[i].prod.DI[k].adi[j] = new TNFeInfNFeDetProdDIAdi()
                                    {
                                        cFabricante = itemDi.CodigoFabricante,
                                        nAdicao = itemDi.Numero.ToString(CultureInfo.InvariantCulture),
                                        nSeqAdic = itemDi.NumeroSequencialItem.ToString(CultureInfo.InvariantCulture),
                                        vDescDI = FuncoesAuxiliares.ValidaCampoOpcional(itemDi.ValorDescontoItemDi.HasValue ? itemDi.ValorDescontoItemDi.Value.ToString("F2", CultureInfo.InvariantCulture): "")
                                    };
                                }
                            }
                        }

                        #endregion

                        #region Devolução de tributos
                        item = nota.CollectionNfItemClassNfPrincipal[i];
                        if (nota.FinalidadeEmissao == Finalidade.DevolucaoMercadoria)
                        {
                            if (item.NfProduto.PercentualMercadoriaDevolvida.HasValue || item.NfProduto.ValorIpiDevolvido.HasValue)
                            {
                                double valorIpiDevolvido = Math.Round(item.NfProduto.ValorIpiDevolvido ?? 0, 2);
                                totalIpiDevolvido = Math.Round(totalIpiDevolvido + valorIpiDevolvido, 2);

                                notaEnviar.infNFe.det[i].impostoDevol = new TNFeInfNFeDetImpostoDevol
                                {
                                    pDevol = (item.NfProduto.PercentualMercadoriaDevolvida ?? 0).ToString("F2", CultureInfo.InvariantCulture),
                                    IPI = new TNFeInfNFeDetImpostoDevolIPI()
                                    {
                                        vIPIDevol = valorIpiDevolvido.ToString("F2", CultureInfo.InvariantCulture)
                                    }
                                };
                            }
                        }

                        #endregion
                    }

                    #endregion

                    #region Novos Totais Calculados

                    notaEnviar.infNFe.total.ICMSTot.vFCP = totalvFCP.ToString("F2", CultureInfo.InvariantCulture);
                    notaEnviar.infNFe.total.ICMSTot.vFCPST = totalvFCPSt.ToString("F2", CultureInfo.InvariantCulture);
                    notaEnviar.infNFe.total.ICMSTot.vFCPSTRet = totalvFCPRet.ToString("F2", CultureInfo.InvariantCulture);
                    notaEnviar.infNFe.total.ICMSTot.vIPIDevol = totalIpiDevolvido.ToString("F2", CultureInfo.InvariantCulture);
                    


                    #endregion

                    #region Partilha ICMS

                    double totalFUndoProbreza = 0;
                    double totalICMSUFDest = 0;
                    double totalICMSUFRemet = 0;

                    if (notaEnviar.infNFe.ide.indFinal == TNFeInfNFeIdeIndFinal.Item1 && notaEnviar.infNFe.dest!=null && notaEnviar.infNFe.dest.indIEDest == TNFeInfNFeDestIndIEDest.Item9)
                    {
                        //Nota ao consumidor final e interestadual
                        if (notaEnviar.infNFe.dest != null && notaEnviar.infNFe.dest.enderDest != null)
                        {
                            TUf ufDestinatario = notaEnviar.infNFe.dest.enderDest.UF;

                            if (ufDestinatario.ToString() != ufEmitente.ToString())
                            {
                                if (notaEnviar.infNFe.ide.finNFe != TFinNFe.Item2 && notaEnviar.infNFe.ide.finNFe != TFinNFe.Item3)
                                {
                                    for (int i = 0; i < notaEnviar.infNFe.det.Count; i++)
                                    {
                                        TNFeInfNFeDet item = notaEnviar.infNFe.det[i];
                                        NfItemClass itemNfPrincipal = nota.CollectionNfItemClassNfPrincipal[i];
                                        if (itemNfPrincipal.CfopPartilhaIcms)
                                        {
                                            item.imposto.ICMSUFDest = new TNFeInfNFeDetImpostoICMSUFDest();


                                            double aliquotaCombatePobreza = itemNfPrincipal.AlquotaFundoCombatePobreza;
                                            item.imposto.ICMSUFDest.pFCPUFDest = aliquotaCombatePobreza.ToString("F2", CultureInfo.InvariantCulture);

                                            double aliquotaInternaDestino;
                                            double aliquotaFECP = 0;
                                            switch (ufDestinatario)
                                            {
                                                case TUf.AC:
                                                case TUf.CE:
                                                case TUf.ES:
                                                case TUf.GO:
                                                case TUf.MT:
                                                case TUf.MS:
                                                case TUf.PA:
                                                case TUf.PI:
                                                case TUf.RR:
                                                case TUf.SC:
                                                case TUf.AL:
                                                    aliquotaInternaDestino = 17;
                                                    break;

                                                case TUf.RO:
                                                    aliquotaInternaDestino = 17.5;
                                                    break;

                                                case TUf.AM:
                                                case TUf.AP:
                                                case TUf.BA:
                                                case TUf.DF:
                                                case TUf.MA:
                                                case TUf.MG:
                                                case TUf.PB:
                                                case TUf.PR:
                                                case TUf.PE:
                                                case TUf.RN:
                                                case TUf.RS:
                                                
                                                case TUf.SP:
                                                case TUf.SE:
                                                case TUf.TO:
                                                    aliquotaInternaDestino = 18;
                                                    break;

                                                case TUf.RJ:
                                                    aliquotaInternaDestino = 18;
                                                    aliquotaFECP = 2;
                                                    break;

                                                case TUf.EX:
                                                    throw new ExcecaoTratada("Não é possível realizar a partilha do icms quando a UF do destinário é Exterior (EX)");
                                                default:
                                                    throw new ArgumentOutOfRangeException();
                                            }

                                            item.imposto.ICMSUFDest.pICMSUFDest = aliquotaInternaDestino.ToString("F2", CultureInfo.InvariantCulture);


                                            double aliquotaInterestadual;
                                            Torig origem = (Torig) Enum.Parse(typeof (Torig), "Item" + Convert.ToInt16(itemNfPrincipal.NfItemTributo.NfItemTributoIcms.Origem));
                                            if (origem == Torig.Item1 || origem == Torig.Item2 || origem == Torig.Item6 || origem == Torig.Item7)
                                            {
                                                item.imposto.ICMSUFDest.pICMSInterLegado = TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item400;
                                                aliquotaInterestadual = 4;
                                            }
                                            else
                                            {
                                                if (
                                                    (
                                                        ufEmitente == TCodUfIBGELegado.RS ||
                                                        ufEmitente == TCodUfIBGELegado.SC ||
                                                        ufEmitente == TCodUfIBGELegado.PR ||
                                                        ufEmitente == TCodUfIBGELegado.SP ||
                                                        ufEmitente == TCodUfIBGELegado.MG ||
                                                        ufEmitente == TCodUfIBGELegado.RJ
                                                        )
                                                    &&
                                                    (
                                                        ufDestinatario == TUf.ES ||
                                                        ufDestinatario == TUf.MS ||
                                                        ufDestinatario == TUf.GO ||
                                                        ufDestinatario == TUf.MT ||
                                                        ufDestinatario == TUf.TO ||
                                                        ufDestinatario == TUf.RO ||
                                                        ufDestinatario == TUf.AC ||
                                                        ufDestinatario == TUf.AM ||
                                                        ufDestinatario == TUf.PA ||
                                                        ufDestinatario == TUf.AP ||
                                                        ufDestinatario == TUf.RR ||
                                                        ufDestinatario == TUf.BA ||
                                                        ufDestinatario == TUf.SE ||
                                                        ufDestinatario == TUf.AL ||
                                                        ufDestinatario == TUf.PE ||
                                                        ufDestinatario == TUf.PB ||
                                                        ufDestinatario == TUf.RN ||
                                                        ufDestinatario == TUf.CE ||
                                                        ufDestinatario == TUf.PI ||
                                                        ufDestinatario == TUf.MA
                                                        )
                                                    )
                                                {

                                                    item.imposto.ICMSUFDest.pICMSInterLegado = TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item700;
                                                    aliquotaInterestadual = 7;

                                                }
                                                else
                                                {
                                                    item.imposto.ICMSUFDest.pICMSInterLegado = TNFeInfNFeDetImpostoICMSUFDestPICMSInterLegado.Item1200;
                                                    aliquotaInterestadual = 12;
                                                }

                                            }

                                            //percentual fixo a partir de 2019
                                            double percentualPartilha = 100;
                                            

                                            if (itemNfPrincipal.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc > 0)
                                            {
                                                throw new ExcecaoTratada("Erro inesperado ao calcular a partilha com ST e com redução da BC. Entre em contato com o suporte IWT");
                                                //Marco 2021-12-14: Avaliar como se deve o cálculo nesse caso, se afeta as duas bases de calculo ou somente 1
                                                //aliquotaInterestadual = Math.Round(aliquotaInterestadual * (itemNfPrincipal.NfItemTributo.NfItemTributoIcms.PercentualReducaoBc / 100), 5, MidpointRounding.AwayFromZero);
                                            }

                                            double vBCNormal = itemNfPrincipal.NfItemTributo.NfItemTributoIcms.ValorBc;
                                            double impostoOperacaoInterestadual = Math.Round(vBCNormal * (aliquotaInterestadual / 100), 5, MidpointRounding.AwayFromZero);
                                            double bcUfDestino = Math.Round((vBCNormal - impostoOperacaoInterestadual) / (1 - ((aliquotaInternaDestino + aliquotaFECP) / 100)), 5, MidpointRounding.AwayFromZero);
                                            double impostoOperacaoInterna = Math.Round(bcUfDestino * ((aliquotaInternaDestino + aliquotaFECP) / 100), 5, MidpointRounding.AwayFromZero);
                                            double icmsSemFECPOperacaoInterna = Math.Round(bcUfDestino * ((aliquotaInternaDestino) / 100), 5, MidpointRounding.AwayFromZero);

                                            double valorICMSDest = Math.Round(icmsSemFECPOperacaoInterna - impostoOperacaoInterestadual, 2, MidpointRounding.AwayFromZero);
                                            double valorFECP = Math.Round(bcUfDestino * (aliquotaFECP/100), 2, MidpointRounding.AwayFromZero);





                                            item.imposto.ICMSUFDest.vBCUFDest = bcUfDestino.ToString("F2", CultureInfo.InvariantCulture);
                                            item.imposto.ICMSUFDest.vBCFCPUFDest = bcUfDestino.ToString("F2", CultureInfo.InvariantCulture);
                                            item.imposto.ICMSUFDest.pICMSInterPart = percentualPartilha.ToString("F2", CultureInfo.InvariantCulture);


                                            item.imposto.ICMSUFDest.vFCPUFDest = FuncoesAuxiliares.ValidaCampoOpcional(valorFECP.ToString("F2", CultureInfo.InvariantCulture));
                                            item.imposto.ICMSUFDest.vICMSUFDest = valorICMSDest.ToString("F2", CultureInfo.InvariantCulture);
                                            item.imposto.ICMSUFDest.vICMSUFRemet = 0.ToString("F2", CultureInfo.InvariantCulture);


                                            totalFUndoProbreza = Math.Round(totalFUndoProbreza + valorFECP, 2);
                                            totalICMSUFDest = Math.Round(totalICMSUFDest + valorICMSDest, 2);
                                            totalICMSUFRemet = Math.Round(totalICMSUFRemet + 0, 2);
                                        }
                                    }
                                }

                            }

                        }
                    }


                    if (notaEnviar.infNFe.ide.indFinal == TNFeInfNFeIdeIndFinal.Item1 && notaEnviar.infNFe.ide.idDest == TNFeInfNFeIdeIdDest.Item2 && notaEnviar.infNFe.dest.indIEDest == TNFeInfNFeDestIndIEDest.Item9)
                    {
                        //Situação especial para notas para consumidor final, fora do estado, não contribuinte e com FCP
                        foreach (TNFeInfNFeDet item in notaEnviar.infNFe.det)
                        {
                            TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.FirstOrDefault(a => a is TNFeInfNFeDetImpostoICMS);
                            if (icms == null) continue;

                            TNFeInfNFeDetImpostoICMSICMS00 icms00 = icms.Item as TNFeInfNFeDetImpostoICMSICMS00;
                            if (icms00 != null)
                            {
                                icms00.vFCP = null;
                                icms00.pFCP = null;
                                continue;
                            }

                            TNFeInfNFeDetImpostoICMSICMS10 icms10 = icms.Item as TNFeInfNFeDetImpostoICMSICMS10;
                            if (icms10 != null)
                            {
                                icms10.vFCP = null;
                                icms10.pFCP = null;
                                continue;
                            }

                            TNFeInfNFeDetImpostoICMSICMS20 icms20 = icms.Item as TNFeInfNFeDetImpostoICMSICMS20;
                            if (icms20 != null)
                            {
                                icms20.vFCP = null;
                                icms20.pFCP = null;
                                continue;
                            }

                            TNFeInfNFeDetImpostoICMSICMS51 icms51 = icms.Item as TNFeInfNFeDetImpostoICMSICMS51;
                            if (icms51 != null)
                            {
                                icms51.vFCP = null;
                                icms51.pFCP = null;
                                continue;
                            }

                            TNFeInfNFeDetImpostoICMSICMS70 icms70 = icms.Item as TNFeInfNFeDetImpostoICMSICMS70;
                            if (icms70 != null)
                            {
                                icms70.vFCP = null;
                                icms70.pFCP = null;
                                continue;
                            }

                            TNFeInfNFeDetImpostoICMSICMS90 icms90 = icms.Item as TNFeInfNFeDetImpostoICMSICMS90;
                            if (icms90 != null)
                            {
                                icms90.vFCP = null;
                                icms90.pFCP = null;
                                continue;
                            }
                        }

                        notaEnviar.infNFe.total.ICMSTot.vFCP = 0.ToString("F2", CultureInfo.InvariantCulture);

                    }

                    notaEnviar.infNFe.total.ICMSTot.vFCPUFDest = FuncoesAuxiliares.ValidaCampoOpcional(totalFUndoProbreza.ToString("F2", CultureInfo.InvariantCulture));
                    notaEnviar.infNFe.total.ICMSTot.vICMSUFDest = FuncoesAuxiliares.ValidaCampoOpcional(totalICMSUFDest.ToString("F2", CultureInfo.InvariantCulture));
                    notaEnviar.infNFe.total.ICMSTot.vICMSUFRemet = FuncoesAuxiliares.ValidaCampoOpcional(totalICMSUFRemet.ToString("F2", CultureInfo.InvariantCulture));


                    if (Math.Abs(totalICMSUFDest) > 0.001 || Math.Abs(totalICMSUFRemet) > 0.001)
                    {
                        notaEnviar.infNFe.infAdic.infAdFisco += "Valores totais do ICMS Interestadual: ";
                        if (Math.Abs(totalICMSUFDest) > 0.001)
                        {
                            notaEnviar.infNFe.infAdic.infAdFisco += "DIFAL da UF Destino " + totalICMSUFDest.ToString("F2", CultureInfo.GetCultureInfo("pt-BR"));
                        }

                        if (Math.Abs(totalFUndoProbreza) > 0.001)
                        {
                            notaEnviar.infNFe.infAdic.infAdFisco += " + FCP " + totalFUndoProbreza.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")) + "; ";
                        }
                        else
                        {
                            notaEnviar.infNFe.infAdic.infAdFisco += "; ";
                        }

                        if (Math.Abs(totalICMSUFRemet) > 0.001)
                        {
                            notaEnviar.infNFe.infAdic.infAdFisco += "DIFAL da UF Origem " + totalICMSUFRemet.ToString("F2", CultureInfo.GetCultureInfo("pt-BR")) + "; ";
                        }

                    }

                    #endregion

                    
                    if (notaEnviar.infNFe.infAdic.infAdFisco!=null)
                    {
                        notaEnviar.infNFe.infAdic.infAdFisco = notaEnviar.infNFe.infAdic.infAdFisco.Trim();
                    }


                    #region Responsável Técnico
                    notaEnviar.infNFe.infRespTec = new TInfRespTec();
                    notaEnviar.infNFe.infRespTec.CNPJ = "05767323000129";
                    notaEnviar.infNFe.infRespTec.xContato = "Marco ou Marcelo";
                    notaEnviar.infNFe.infRespTec.email = "equipe@iwt.com.br";
                    notaEnviar.infNFe.infRespTec.fone = "4330272490";
                    #endregion

                    #region Autorização de Download do XML
                    List<NfPrincipalAutorizacaoXmlClass> autorizados = nota.CollectionNfPrincipalAutorizacaoXmlClassNfPrincipal.Where(a => !string.IsNullOrWhiteSpace(a.Documento)).ToList();
                    if (autorizados.Count > 0)
                    {
                        notaEnviar.infNFe.autXML = new Collection<TNFeInfNFeAutXML>(System.Linq.Enumerable.Repeat<TNFeInfNFeAutXML>(null, autorizados.Count).ToList());
                        for (int i = 0; i < autorizados.Count; i++)
                        {
                            string aut = autorizados[i].Documento.Trim().Replace("/", "").Replace("-", "").Replace(".", "");
                            notaEnviar.infNFe.autXML[i] = new TNFeInfNFeAutXML()
                            {
                                ItemElementName = aut.Length == 11 ? TNFeInfNFeAutXML.ItemChoiceType5.CPF : TNFeInfNFeAutXML.ItemChoiceType5.CNPJ,
                            };
                            notaEnviar.infNFe.autXML[i].SetItem(aut);
                        }
                    }
                    #endregion

                }
                catch (Exception a)
                {
                    errosConversao += "NF: " + numeroNota + " - " + a.Message;
                }


                if (errosConversao.Length > 0)
                {
                    throw new ExcecaoTratada("Ocorreram os seguintes erros de conversão das notas: " + errosConversao);
                }

                switch (notaEnviar.infNFe.ide.mod)
                {
                    case TMod.Item55:
                        return NFeOperacoes.EnviaNfeInterno(notaCompleta, ufEmitente, Ambiente, serialCertificado, conn, cnpjTransmissor, usuarioAtual, waitForm, out notaRetornada);
                        break;
                    case TMod.Item65:
                        notaRetornada = null;
                        return NFCeOperacoes.CriaLote(notaCompleta, Ambiente, serialCertificado, conn, cnpjTransmissor, usuarioAtual, waitForm);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar a NFe.\r\n" + e.Message, e);
            }
        }

        internal static LoteEnviar EnviaNfeInterno(NotaEnviar nota, TCodUfIBGELegado ufEmitente, TAmbLegado Ambiente,
            string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor, AcsUsuarioClass usuarioAtual,
            ComunicacaoWaitForm waitForm,  out RetornoNFe notaRetornada)

        {

            try
            {

                notaRetornada = null;


                DateTime? dataEntradaContingencia = null;
                IWTPostgreNpgsqlCommand command;
                if (nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN ||
                    nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS)
                {
                    command = conn.CreateCommand();
                    command.CommandText =
                        "SELECT  " +
                        "  public.nf_principal.nfp_serie, " +
                        "  public.nf_principal.nfp_data_emissao, " +
                        "  public.nf_principal.nfp_forma_emissao " +
                        "FROM " +
                        "  public.nf_principal " +
                        "WHERE " +
                        "  public.nf_principal.nfp_modelo_doc_fiscal = '55' " +
                        "ORDER BY " +
                        "  public.nf_principal.nfp_data_emissao DESC ";
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    dataEntradaContingencia = DateTime.Now;
                    while (read.Read())
                    {
                        if (Convert.ToInt32(read["nfp_forma_emissao"]) == 3)
                        {
                            dataEntradaContingencia = Convert.ToDateTime(read["nfp_data_emissao"]);
                        }
                        else
                        {
                            break;
                        }

                    }
                    read.Close();

                }


                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);

                if (waitForm != null)
                {
                    waitForm.MudaMensagem("Enviando notas fiscais para a receita, por favor aguarde");
                }


                LoteEnviar loteAtual = new LoteEnviar();
                command = null;

                try
                {

                    command = conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    //Buscar numero do lote
                    command.CommandText =
                        "SELECT  " +
                        "  COALESCE(MAX(public.nfe_completo_lote.ncl_numero_lote),0) " +
                        "FROM " +
                        "  public.nfe_completo_lote " +
                        "WHERE " +
                        "ncl_modelo = '55' ";
                    loteAtual.NumeroLoteInterno = (Convert.ToInt32(command.ExecuteScalar())) + 1;
                    //Assinar as NFes que serão enviadas

                    XmlSerializer serializer = new XmlSerializer(typeof (TNFe));
                    Utf8StringWriter builder = new Utf8StringWriter();
                    XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false, Indent = true};
                    XmlWriter xmlWriter;

                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");


                    NfeCompletoLoteClass lote = new NfeCompletoLoteClass(usuarioAtual, conn)
                    {
                        NumeroLote = loteAtual.NumeroLoteInterno,
                        DataEnvio = DateTime.Now,
                        Situacao = SituacaoLote.Enviado,
                        CnpjTransmissor = cnpjTransmissor,
                        Homologacao = Ambiente == TAmbLegado.Homologacao,
                        Scan =
                            nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN ||
                            nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS,
                        Modelo = "55"

                    };

                    //Insere o lote no banco de dados
                    lote.Save(ref command);
                    loteAtual.NfeCompletoLote = lote;


                    
                    if (nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN ||
                        nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS)
                    {
                        nota.NfTnfe.infNFe.ide.xJust = "O ambiente de produção do estado não está operacional";
                        nota.NfTnfe.infNFe.ide.dhCont = dataEntradaContingencia.Value.ToString("yyyy-MM-ddTHH:mm:sszzz");
                    }

                    builder = new Utf8StringWriter();
                    xmlWriter = XmlWriter.Create(builder, settings);

                    serializer.Serialize(xmlWriter, nota.NfTnfe, namespaces);

                    XmlDocument xmlNfe = new XmlDocument();
                    xmlNfe.LoadXml(builder.ToString());

                    CertificadoOperacoes.AssinaDocumento(certificado, ref xmlNfe, "#" + nota.NfTnfe.infNFe.Id);
                    nota.Xml = xmlNfe;


                    NfeCompletoNotaClass nFeEmitida = new NfeCompletoNotaClass(usuarioAtual, conn)
                    {
                        CnpjEmitente = nota.NfTnfe.infNFe.emit.Item,
                        Serie = int.Parse(nota.NfTnfe.infNFe.ide.serie),
                        Numero = int.Parse(nota.NfTnfe.infNFe.ide.nNF),
                        NfeCompletoLote = loteAtual.NfeCompletoLote,
                        Chave = nota.NfTnfe.infNFe.Id.Substring(3),
                        Homologacao = Ambiente == TAmbLegado.Homologacao,
                        DataSituacao = DateTime.Now,
                        Situacao = SituacaoNFe.Enviada,
                        DataEmissao = DateTime.Parse(nota.NfTnfe.infNFe.ide.dhEmi, CultureInfo.InvariantCulture),
                        SituacaoObservacao = "Enviada",
                        Modelo = "55",
                        NfPrincipal = nota.NfPrincipal

                    };


                    nFeEmitida.Xml = xmlNfe.InnerXml;


                    nFeEmitida.Save(ref command);

                    loteAtual.Notas.Add(nota);

                    NfeCompletoLogChavesClass logChave = new NfeCompletoLogChavesClass(usuarioAtual, conn)
                    {
                        Chave = nFeEmitida.Chave,
                        Homologacao = nFeEmitida.Homologacao,
                        Numero = nFeEmitida.Numero,
                        Serie = nFeEmitida.Serie,
                        Modelo = "55"
                    };

                    logChave.Save(ref command);

                    nota.NfPrincipal.EnviarNfeReceita = false;
                    nota.NfPrincipal.Save(ref command);



                    command.Transaction.Commit();
                    command.Transaction = null;

                    NfeSituacaoTransmissaoClass transmissao =
                        (NfeSituacaoTransmissaoClass)
                            new NfeSituacaoTransmissaoClass(usuarioAtual, command.Connection).Search(
                                new List<SearchParameterClass>()
                                {
                                    new SearchParameterClass("IdNfPrincipal", nota.NfPrincipal.ID)
                                }).FirstOrDefault();


                    if (transmissao == null)
                    {
                        transmissao = new NfeSituacaoTransmissaoClass(usuarioAtual, command.Connection)
                        {
                            IdNfPrincipal = (int)nota.NfPrincipal.ID,
                            NotaTipo =
                                nota.NfTnfe.infNFe.ide.mod == TMod.Item55 ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                            Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                            NotaNumero = nota.NfPrincipal.Numero,
                            NotaSerie = nota.NfTnfe.infNFe.ide.serie,
                            NotaModelo = nota.NfTnfe.infNFe.ide.mod.ToString().Replace("Item", ""),
                            NotaEmitente = nota.NfTnfe.infNFe.emit.xNome,
                            NotaDestinatario = nota.NfTnfe.infNFe.dest.xNome,
                            NotaDataEmissao = nota.NfPrincipal.DataEmissao,
                            

                        };

                        transmissao.Save();
                    }

                    transmissao.NotaNumero = nota.NfPrincipal.Numero;
                    transmissao.NotaSerie = nota.NfTnfe.infNFe.ide.serie;
                    transmissao.Situacao =  IWTNFSituacaoTransmissao.AguardandoResposta;
                    transmissao.Mensagem = "Nota enviada para a receita, aguardando a resposta.";
                    transmissao.DataAtualizacao = DataIndependenteClass.GetData();
                    transmissao.NotaChave = nota.NfTnfe.infNFe.Id.Replace("NFe", "");
                    transmissao.IdNfCompletoNota = (int)nFeEmitida.ID;

                    transmissao.Save();

                    TEnviNFe objetoEnvio = new TEnviNFe()
                    {
                        idLote = loteAtual.NumeroLoteInterno.ToString(),
                        versao = versaoLayout,
                        indSincLegado = TEnviNFeIndSincLegado.Sincrono
                    };


                    serializer = new XmlSerializer(typeof (TEnviNFe));
                    builder = new Utf8StringWriter();
                    settings = new XmlWriterSettings
                    {
                        OmitXmlDeclaration = false,
                        Indent = true,
                        ConformanceLevel = ConformanceLevel.Auto
                    };
                    xmlWriter = XmlWriter.Create(builder, settings);

                    namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                    serializer.Serialize(xmlWriter, objetoEnvio, namespaces);

                    XmlDocument xmlConsulta = new XmlDocument();
                    xmlConsulta.LoadXml(builder.ToString());



                    foreach (NotaEnviar notaLoteEnviar in loteAtual.Notas)
                    {
                        xmlConsulta.DocumentElement.AppendChild(
                            xmlConsulta.ImportNode(notaLoteEnviar.Xml.DocumentElement, true));
                    }

                    string urlWebservice = EnderecosWebservices.GetEndereco(ufEmitente, versaoLayout, Ambiente,
                        ServicoNFe.NfeRecepcao,
                        nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN ||
                        nota.NfTnfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS, TMod.Item55);

                    NFeAutorizacao4 client = new NFeAutorizacao4
                    {
                        Timeout = timeoutPadrao,
                        Url = urlWebservice,

                    };


                    if (ProxyClass.ComProxy)
                    {
                        client.Proxy = new WebProxy(ProxyClass.EnderecoProxy, false)
                        {
                            Credentials =
                                new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy,
                                    ProxyClass.DomainProxy)
                        };
                    }


                    client.ClientCertificates.Add(certificado);


                    try
                    {
                        //Salvar o XML
                        transmissao.XmlEnviado = xmlConsulta.InnerXml;
                        transmissao.Save();
                    }
                    catch (Exception)
                    {
                        
                    }

                    XmlNode resultadoProcessamento = null;
                    try
                    {
                        resultadoProcessamento = client.nfeAutorizacaoLote(xmlConsulta);
                    }
                    catch (Exception e)
                    {
                        loteAtual.Recibo = null;
                        loteAtual.Observacao = "Erro ao enviar a NFe para os servidores da receita: " + e.Message;
                        loteAtual.LoteEnviado = false;

                        loteAtual.NfeCompletoLote.Delete();

                        throw e;
                    }

                    serializer = new XmlSerializer(typeof (TRetEnviNFe));
                    TRetEnviNFe resultatoCompleto =
                        (TRetEnviNFe) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                    if (resultatoCompleto.cStat == "103" || resultatoCompleto.cStat == "105")
                    {

                        if (resultatoCompleto.Item is TRetEnviNFeInfRec)
                        {
                            //Lote recebido com sucesso

                            TRetEnviNFeInfRec retornoLote = (TRetEnviNFeInfRec) resultatoCompleto.Item;

                            loteAtual.NfeCompletoLote.Recibo = retornoLote.nRec;
                            loteAtual.NfeCompletoLote.ResultadoObs = resultatoCompleto.xMotivo;
                            loteAtual.NfeCompletoLote.Save();


                            //command.Transaction.Commit();

                            loteAtual.Recibo = retornoLote.nRec;
                            loteAtual.Observacao = "Lote processado com sucesso";
                            loteAtual.LoteEnviado = true;

                        }
                        else
                        {
                            loteAtual.Recibo = null;
                            loteAtual.Observacao = resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo +
                                                   " - Recebido CSTAT 103/105 porem sem objeto do tipo TRetEnviNFeInfRec";
                            loteAtual.LoteEnviado = false;

                            loteAtual.NfeCompletoLote.Delete();
                        }

                    }
                    else
                    {
                        if (resultatoCompleto.cStat == "104")
                        {

                            if (resultatoCompleto.Item is TProtNFe)
                            {

                                TProtNFe retornoLote = (TProtNFe) resultatoCompleto.Item;
                                NfeCompletoNotaClass notaEmitida =
                                    lote.CollectionNfeCompletoNotaClassNfeCompletoLote.FirstOrDefault(
                                        a => a.Chave == retornoLote.infProt.chNFe);
                                if (notaEmitida == null)
                                {
                                    throw new Exception("Não foi encontrada no lote NFe com a chave " +
                                                        retornoLote.infProt.chNFe);
                                }
                                processaRetornoLoteNfe(notaEmitida, retornoLote, usuarioAtual, command,
                                    out notaRetornada);


                                loteAtual.NfeCompletoLote.Situacao = SituacaoLote.Processado;
                                loteAtual.NfeCompletoLote.ResultadoObs = resultatoCompleto.xMotivo;
                                loteAtual.NfeCompletoLote.Save();



                            }
                            else
                            {
                                loteAtual.Recibo = null;
                                loteAtual.Observacao = resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo +
                                                       " - Recebido CSTAT 104 porem sem objeto do tipo TProtNFe";
                                loteAtual.LoteEnviado = false;

                                loteAtual.NfeCompletoLote.Delete();
                            }
                        }
                        else
                        {


                            loteAtual.Recibo = null;
                            loteAtual.Observacao = resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo;
                            loteAtual.LoteEnviado = false;

                            loteAtual.NfeCompletoLote.Delete();
                        }
                    }



                }
                catch (System.Net.WebException e)
                {
                    if (command != null && command.Transaction != null && command.Transaction.IsActive)
                    {
                        command.Transaction.Rollback();
                    }

                    if (e.Message == "A solicitação foi anulada: Não foi possível criar um canal seguro para SSL/TLS.")
                    {
                        throw new Exception("O certificado digital não é válido ou não está disponível");
                    }
                    else
                    {
                        throw new Exception("Erro ao enviar a NFe.\r\n" + e.Message, e);
                    }
                }
                catch (Exception e)
                {
                    if (command != null && command.Transaction != null && command.Transaction.IsActive)
                    {
                        command.Transaction.Rollback();
                    }
                    throw new Exception("Erro ao enviar a NFe.\r\n" + e.Message, e);
                }


                return loteAtual;
            }
            finally
            {
                
            }
        }

        private static void processaRetornoLoteNfe(NfeCompletoNotaClass nfeEmitida, TProtNFe protNFe, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlCommand command, out RetornoNFe notasRetornada)
        {
            if (nfeEmitida.Situacao != SituacaoNFe.Enviada)
            {

                if (nfeEmitida.Situacao == SituacaoNFe.Autorizada)
                {
                    notasRetornada = null;
                    return;
                }
                throw new Exception("A nota fiscal com a chave " + protNFe.infProt.chNFe + " não está no status correto");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(TNFe));
            XmlDocument docNF = new XmlDocument();
            docNF.LoadXml(nfeEmitida.Xml);
            TNFe nota = (TNFe)serializer.Deserialize(new XmlNodeReader(docNF));

            Utf8StringWriter builder = new Utf8StringWriter();
            TNfeProc proc;
            XmlWriterSettings settings;
            XmlWriter xmlWriter;
            XmlSerializerNamespaces namespaces;
            switch (protNFe.infProt.cStat)
            {
                case "100":
                    //Nota Aprovada
                    proc = new TNfeProc()
                    {
                        NFe = nota,
                        protNFe = protNFe,
                        versao = versaoLayout
                    };

                    serializer = new XmlSerializer(typeof(TNfeProc));

                   
                    settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                    xmlWriter = XmlWriter.Create(builder, settings);

                    namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                    serializer.Serialize(xmlWriter, proc, namespaces);


                    nfeEmitida.Xml = builder.ToString();
                    nfeEmitida.Situacao = SituacaoNFe.Autorizada;
                    nfeEmitida.DataSituacao = DateTime.Now;
                    nfeEmitida.SituacaoObservacao = protNFe.infProt.cStat + " - " + protNFe.infProt.xMotivo;

                    nfeEmitida.Save(ref command);

                    notasRetornada = new RetornoNFe()
                    {
                        codigoRetorno = "100",
                        NotaFiscal = nota,
                        NFeEmitida = nfeEmitida,
                        NFeProc = proc,
                        observacaoRetorno = protNFe.infProt.xMotivo,
                        situacao = SituacaoNFe.Autorizada
                    };


                    break;

                case "110":
                case "301":
                case "302":
                case "303":
                    //Nota denegada
                    try
                    {
                        proc = new TNfeProc()
                        {
                            NFe = nota,
                            protNFe = protNFe,
                            versao = versaoLayout
                        };

                        serializer = new XmlSerializer(typeof (TNfeProc));


                        settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                        xmlWriter = XmlWriter.Create(builder, settings);

                        namespaces = new XmlSerializerNamespaces();
                        namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                        serializer.Serialize(xmlWriter, proc, namespaces);


                        nfeEmitida.Xml = builder.ToString();
                    }
                    catch (Exception e)
                    {
                        nfeEmitida.Xml = "Erro ao gerar o XML: " + e.Message;
                    }

                    nfeEmitida.Situacao = SituacaoNFe.Denegada;
                    nfeEmitida.DataSituacao = DateTime.Now;
                    nfeEmitida.SituacaoObservacao = protNFe.infProt.cStat + " - " + protNFe.infProt.xMotivo;
                    
                    nfeEmitida.Save(ref command);

                    notasRetornada = new RetornoNFe()
                    {
                        codigoRetorno = "110",
                        NotaFiscal = nota,
                        NFeEmitida = nfeEmitida,
                        observacaoRetorno = protNFe.infProt.xMotivo,
                        situacao = SituacaoNFe.Denegada
                    };

                    break;
                default:
                    //Nota rejeitada
                    nfeEmitida.Delete(ref command);
                    nfeEmitida.NfeCompletoLote.CollectionNfeCompletoNotaClassNfeCompletoLote.Remove(nfeEmitida);

                    notasRetornada = new RetornoNFe()
                    {
                        codigoRetorno = protNFe.infProt.cStat,
                        NotaFiscal = nota,
                        NFeEmitida = nfeEmitida,
                        observacaoRetorno = protNFe.infProt.xMotivo,
                        situacao = SituacaoNFe.Rejeitada
                    };


                    break;


            }
            
        }

        public static RetornoProcessamentoLote ResultadoProcessamentoNFe(NfeCompletoLoteClass lote, TCodUfIBGELegado ufEmitente, string serialCertificado, IWTPostgreNpgsqlCommand command, out string retornoDetalhado, out List<RetornoNFe> notasRejeitadas, out List<RetornoNFe> notasDenegadas, out List<RetornoNFe> notasProcessadas, AcsUsuarioClass usuarioAtual, bool Scan)
        {
            ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

            retornoDetalhado = null;
            notasRejeitadas = null;
            notasDenegadas = null;
            notasProcessadas = null;
            BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                ServicoNFe.NfeRetRecepcao,
                new List<object>()
                    {
                        lote,
                        ufEmitente,
                        serialCertificado,
                        command,
                        usuarioAtual,
                        Scan
                    },
                new List<object>()
                    {
                        retornoDetalhado,
                        notasRejeitadas,
                        notasDenegadas,
                        notasProcessadas
                    },
                waitForm);

            BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += new DoWorkEventHandler(tr.Run);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tr.Completed);
            worker.RunWorkerAsync(tr);

            waitForm.ShowDialog();
            retornoDetalhado = (string)tr.ArgumentosSaida[0];
            notasRejeitadas = (List<RetornoNFe>)tr.ArgumentosSaida[1];
            notasDenegadas = (List<RetornoNFe>)tr.ArgumentosSaida[2];
            notasProcessadas = (List<RetornoNFe>)tr.ArgumentosSaida[3];

            return (RetornoProcessamentoLote)tr.Retorno;
        }

        internal static RetornoProcessamentoLote ResultadoProcessamentoNFeInterno(NfeCompletoLoteClass lote, TCodUfIBGELegado ufEmitente,  string serialCertificado, IWTPostgreNpgsqlCommand command, out string retornoDetalhado, out List<RetornoNFe> notasRejeitadas, out List<RetornoNFe> notasDenegadas, out List<RetornoNFe> notasProcessadas, AcsUsuarioClass usuarioAtual, bool Scan)
        {
            try
            {

                notasRejeitadas = new List<RetornoNFe>();
                notasDenegadas = new List<RetornoNFe>();
                notasProcessadas = new List<RetornoNFe>();

                TAmbLegado ambiente = lote.Homologacao ? TAmbLegado.Homologacao : TAmbLegado.Producao;
                

                TConsReciNFe objConsulta = new TConsReciNFe
                {
                    versao = versaoLayout,
                    nRec = lote.Recibo,
                    tpAmbLegado = ambiente

                };


                XmlSerializer serializer = new XmlSerializer(typeof(TConsReciNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


                string urlWebservice = EnderecosWebservices.GetEndereco(ufEmitente, versaoLayout, ambiente, ServicoNFe.NfeRetRecepcao, Scan, lote.Modelo == "65" ? TMod.Item65 : TMod.Item55);

                NfeRetAutorizacao.NFeRetAutorizacao4 client;
                switch (ufEmitente)
                {
                    case TCodUfIBGELegado.SP:
                        client = new NfeRetAutorizacao.NFeRetAutorizacao4
                        {
                            Timeout = timeoutPadrao,
                            Url = urlWebservice,
                            SoapVersion = SoapProtocolVersion.Soap12
                        };
                        break;
                    default:
                        client = new NfeRetAutorizacao.NFeRetAutorizacao4
                        {
                            Timeout = timeoutPadrao,
                            Url = urlWebservice,

                        };
                        break;
                }
                


                if (ProxyClass.ComProxy)
                {
                    client.Proxy = new WebProxy(ProxyClass.EnderecoProxy, false)
                    {
                        Credentials = new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy, ProxyClass.DomainProxy)
                    };
                }

                client.ClientCertificates.Add(certificado);

               

                XmlNode resultadoProcessamento = client.nfeRetAutorizacaoLote(xmlConsulta);

                serializer = new XmlSerializer(typeof(TRetConsReciNFe));
                TRetConsReciNFe resultatoCompleto = (TRetConsReciNFe)serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));


                switch (resultatoCompleto.cStat)
                {
                    case "104":
                        //Lote processado
                        retornoDetalhado = "Lote Processado";
                       

                        
                        if (lote.Situacao!=SituacaoLote.Enviado)
                        {
                            throw new Exception("O Recibo " + lote.Recibo + " não está no status correto");
                        }


                     
                        
                        foreach (TProtNFe protNFe in resultatoCompleto.protNFe)
                        {
                            NfeCompletoNotaClass notaEmitida = lote.CollectionNfeCompletoNotaClassNfeCompletoLote.FirstOrDefault(a => a.Chave == protNFe.infProt.chNFe);
                            if (notaEmitida == null)
                            {
                                throw new Exception("Não foi encontrada no lote NFe com a chave " + protNFe.infProt.chNFe);
                            }
                            RetornoNFe notasRetornada;
                            processaRetornoLoteNfe(notaEmitida,protNFe, usuarioAtual, command, out notasRetornada);
                            if (notasRetornada != null)
                            {
                                switch (notasRetornada.situacao)
                                {
                                    case SituacaoNFe.Autorizada:
                                        notasProcessadas.Add(notasRetornada);
                                        break;
                                    case SituacaoNFe.Denegada:
                                        notasDenegadas.Add(notasRetornada);
                                        break;
                                    case SituacaoNFe.Rejeitada:
                                        notasRejeitadas.Add(notasRetornada);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }

                        lote.Situacao = SituacaoLote.Processado;
                        lote.ResultadoObs = resultatoCompleto.xMotivo + " - " + resultatoCompleto.xMsg;
                        
                        return notasDenegadas.Count > 0 || notasRejeitadas.Count > 0 ? RetornoProcessamentoLote.ProcessadoComProblemas : RetornoProcessamentoLote.Processado;


                        break;
                    case "225":
                    case "106":
                        //Lote Rejeitado
                        retornoDetalhado = resultatoCompleto.xMotivo;

                        List<NfeCompletoNotaClass> notasLote = new List<NfeCompletoNotaClass>();
                        notasLote.AddRange(lote.CollectionNfeCompletoNotaClassNfeCompletoLote);

                        foreach (NfeCompletoNotaClass notaEmitida in notasLote)
                        {
                        
                            
                            RetornoNFe notasRetornada;
                            TProtNFe protNFe = new TProtNFe()
                            {
                                infProt = new TProtNFeInfProt()
                                {
                                    xMotivo = retornoDetalhado,
                                    cStat = "225",
                                    chNFe = notaEmitida.Chave
                                }
                            };
                            processaRetornoLoteNfe(notaEmitida, protNFe, usuarioAtual, command, out notasRetornada);

                            if (notasRetornada != null)
                            {
                                switch (notasRetornada.situacao)
                                {
                                    case SituacaoNFe.Autorizada:
                                        notasProcessadas.Add(notasRetornada);
                                        break;
                                    case SituacaoNFe.Denegada:
                                        notasDenegadas.Add(notasRetornada);
                                        break;
                                    case SituacaoNFe.Rejeitada:
                                        notasRejeitadas.Add(notasRetornada);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException();
                                }
                            }
                        }

                        lote.Situacao = SituacaoLote.Processado;
                        lote.ResultadoObs = resultatoCompleto.xMotivo + " - " + resultatoCompleto.xMsg;

                        return notasDenegadas.Count > 0 || notasRejeitadas.Count > 0 ? RetornoProcessamentoLote.ProcessadoComProblemas : RetornoProcessamentoLote.Processado;


                    case "105":
                        //Lote em processamento
                        retornoDetalhado = "";
                        return RetornoProcessamentoLote.EmProcessamento;
                        break;
                    

                    case "248":
                    case "223":
                        //Recibo inválido
                        lote.Situacao = SituacaoLote.ErroLote;
                        lote.ResultadoObs = resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo;
                        retornoDetalhado = "Lote ou recibo inválidos: cStat: " + resultatoCompleto.cStat + " xMotivo: " + resultatoCompleto.xMotivo;
                        return RetornoProcessamentoLote.Erro;
                        break;
                    default:
                        lote.Situacao = SituacaoLote.ErroLote;
                        lote.ResultadoObs = resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo;
                        string erroDetalhado = "cStat: " + resultatoCompleto.cStat + " xMotivo: " + resultatoCompleto.xMotivo;
                        throw new Exception("Retorno da consulta do resultado de processamento não previsto: " + erroDetalhado);
                }
            }
            catch (System.Net.WebException e)
            {
                if (e.Message == "A solicitação foi anulada: Não foi possível criar um canal seguro para SSL/TLS.")
                {
                    throw new Exception("O certificado digital não é válido ou não está disponível");
                }
                else
                {
                    throw new Exception("Erro ao consultar os recibos.\r\n" + e.Message, e);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Erro ao consultar os recibos.\r\n" + e.Message, e);
            }
        }

    }
}
