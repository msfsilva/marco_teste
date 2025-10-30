using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_Canc_PL_v101;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTNFCompleto.RecepcaoEvento;
using ItemChoiceType = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_Canc_PL_v101.ItemChoiceType;
using TEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_Canc_PL_v101.TEvento;
using TEventoInfEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_Canc_PL_v101.TEventoInfEvento;
using TEventoInfEventoDetEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_Canc_PL_v101.TEventoInfEventoDetEvento;


namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {

        public static bool CancelaNfe(NfeCompletoNotaClass NFe, TAmb Ambiente, string serialCertificado, string justificativa, out string retornoDetalhado,  bool modoBatch = false)
        {
            retornoDetalhado = "";
            ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

            BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                ServicoNFe.NfeCancelamento,
                new List<object>()
                    {
                       NFe,
                       Ambiente,
                       serialCertificado,
                       justificativa,
                       modoBatch
                    },
                new List<object>()
                    {
                        retornoDetalhado
                    },
                    waitForm);

            BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += new DoWorkEventHandler(tr.Run);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tr.Completed);
            worker.RunWorkerAsync(tr);

            waitForm.ShowDialog();


            retornoDetalhado = (string)tr.ArgumentosSaida[0];
            return (bool)tr.Retorno;
        }


        public static bool CancelaNfeEventoInterno(NfeCompletoNotaClass NFe, TAmbLegado Ambiente, string serialCertificado, string justificativa, out string retornoDetalhado,  bool modoBatch, DadosSalvarEnviarNfe _dadosSalvarEnviarNfe = null)
        {
            try
            {
                TRetConsSitNFe retConsultaNfe;
                string retConsultaDetalhado;

                bool scan = NFe.NfeCompletoLote.Scan;
                if (!scan)
                {
                    SituacaoNFe situacaoNfe = NFeOperacoes.consultaSituacaoNfe(NFe.Chave, Ambiente, serialCertificado, out retConsultaDetalhado, out retConsultaNfe, false);

                    if (situacaoNfe == SituacaoNFe.NaoEncontrada)
                    {
                        if (!modoBatch)
                        {
                            throw new Exception("Não é possível cancelar a nfe pois ela não foi encontrada na base da SEFAZ");
                        }
                        else
                        {
                            retornoDetalhado = "Não é possível cancelar a nfe pois ela não foi encontrada na base da SEFAZ";
                            return false;
                        }
                    }

                    if (situacaoNfe == SituacaoNFe.Denegada)
                    {
                        if (!modoBatch)
                        {
                            throw new Exception("Não é possível cancelar a nfe pois ela foi denegada.\r\n" + retConsultaDetalhado);
                        }
                        else
                        {
                            retornoDetalhado = "Não é possível cancelar a nfe pois ela foi denegada.\r\n" + retConsultaDetalhado;
                            return false;
                        }
                    }

                    if (situacaoNfe == SituacaoNFe.Cancelada)
                    {
                        retornoDetalhado = "Nota Cancelada Anteriormente";

                        if (NFe.Situacao != SituacaoNFe.Cancelada)
                        {
                            NFe.setCancelamento(justificativa, "");
                            NFe.Save();
                        }
                        return true;
                        if (!modoBatch)
                        {
                            throw new Exception("Não é possível cancelar a nfe pois ela já foi cancelada anteriormente.\r\n" + retConsultaDetalhado);
                        }
                        else
                        {
                            retornoDetalhado = "Não é possível cancelar a nfe pois ela já foi cancelada anteriormente.\r\n" + retConsultaDetalhado;
                            return false;
                        }
                    }
                }

                scan = false;

                XmlSerializer serializer2 = new XmlSerializer(typeof(TNfeProc));
                TNfeProc xmlNfe;
                using (TextReader reader = new StringReader(NFe.Xml))
                {
                    xmlNfe = (TNfeProc) serializer2.Deserialize(reader);
                }


                          

                string nProt = xmlNfe.protNFe.infProt.nProt;

                int NumeroLote = 1;
                int seqEvento = 1;
                DateTime dataEnvio = DateTime.Now;
                int codigoUf = int.Parse(NFe.Chave.Substring(0, 2));
                TEnvEvento objConsulta = new TEnvEvento
                {
                    versao = "1.00",
                    idLote = NumeroLote.ToString(CultureInfo.InvariantCulture),
                    evento = new TEvento[1]
                                                              {
                                                                  new TEvento()
                                                                      {
                                                                          versao = "1.00",
                                                                          infEvento = new TEventoInfEvento()
                                                                                          {
                                                                                              Id = "ID" + "110111" + NFe.Chave + seqEvento.ToString("D2"),
                                                                                              cOrgao = FuncoesAuxiliares.Codigo2TCOrgaoIBGE(codigoUf),
                                                                                              tpAmbLegado = Ambiente,
                                                                                              ItemElementName = NFe.CnpjEmitente.Length == 14 ? ItemChoiceType.CNPJ : ItemChoiceType.CPF,
                                                                                              Item = NFe.CnpjEmitente,
                                                                                              chNFe = NFe.Chave,
                                                                                              dhEvento = dataEnvio.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                                                                                              tpEvento = TEventoInfEventoTpEvento.Item110111,
                                                                                              nSeqEvento = seqEvento.ToString(CultureInfo.CurrentCulture),
                                                                                              verEvento = TEventoInfEventoVerEvento.Item100,
                                                                                              detEvento  = new TEventoInfEventoDetEvento()
                                                                                                              {
                                                                                                                  descEvento = TEventoInfEventoDetEventoDescEvento.Cancelamento,
                                                                                                                  versao = TEventoInfEventoDetEventoVersao.Item100,
                                                                                                                  xJust = justificativa,
                                                                                                                  nProt = nProt
                                                                                                                  //nProt = retConsultaNfe.protNFe.infProt.nProt
                                                                                                                  
                                                                                                              }

                                                                                          }
                                                                      }
                                                              }

                };






                




                XmlSerializer serializer = new XmlSerializer(typeof (TEnvEvento));
                
                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);
                

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


                XmlNodeList list = xmlConsulta.GetElementsByTagName("evento");
                //CertificadoOperacoes.AssinaDocumento(certificado, ref xmlConsulta, "#" + objConsulta.evento[0].infEvento.Id);

                XmlElement element = list.Item(0) as XmlElement;
                CertificadoOperacoes.AssinaDocumento(certificado, ref element, "#" + objConsulta.evento[0].infEvento.Id);

                string urlWebservice = EnderecosWebservices.GetEndereco(xmlNfe.NFe.infNFe.ide.cUFLegado, versaoLayout, Ambiente, ServicoNFe.RecepcaoEvento, scan, NFe.Modelo == "65" ? TMod.Item65 : TMod.Item55);


                NFeRecepcaoEvento4 client = new RecepcaoEvento.NFeRecepcaoEvento4
                {
                    Timeout = timeoutPadrao, Url = urlWebservice,
                    SoapVersion = SoapProtocolVersion.Soap12
                };

                if (ProxyClass.ComProxy)
                {
                    client.Proxy = new WebProxy(ProxyClass.EnderecoProxy, false)
                    {
                        Credentials = new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy, ProxyClass.DomainProxy)
                    };
                }

                client.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;

                client.ClientCertificates.Add(CertificadoOperacoes.BuscaCertficado(serialCertificado));
                
                XmlNode resultadoProcessamento = client.nfeRecepcaoEventoNF(xmlConsulta);



                serializer = new XmlSerializer(typeof(TRetEnvEvento));
                TRetEnvEvento resultatoCompleto = (TRetEnvEvento)serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                if (resultatoCompleto.cStat == "128")
                {

                    switch (resultatoCompleto.retEvento[0].infEvento.cStat)
                    {
                        case "135":
                        case "136":
                            retornoDetalhado = "NFe Cancelada com sucesso. " + resultatoCompleto.retEvento[0].infEvento.xMotivo;
                            break;
                        default:
                            retornoDetalhado = "cStat: " + resultatoCompleto.retEvento[0].infEvento.cStat + " xMotivo: " + resultatoCompleto.retEvento[0].infEvento.xMotivo;
                            if (!modoBatch)
                            {
                                throw new Exception("Retorno do cancelamento da NFe não previsto: " + retornoDetalhado);
                            }
                            else
                            {
                                return false;
                            }
                            break;
                    }
                }
                else
                {
                    string erroDetalhado = "cStat: " + resultatoCompleto.cStat + " xMotivo: " + resultatoCompleto.xMotivo;
                    throw new Exception("Situação da NFe não prevista: " + erroDetalhado);
                }


                builder = new Utf8StringWriter();
                settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                xmlWriter = XmlWriter.Create(builder, settings);

                namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, resultatoCompleto, namespaces);


                NFe.setCancelamento(justificativa, builder.ToString());
                NFe.Save();
                try
                {
                    if (_dadosSalvarEnviarNfe != null)
                    {
                        if (_dadosSalvarEnviarNfe.SalvarPastaHabilitado)
                        {
                            string pastaXML = _dadosSalvarEnviarNfe.SalvarPastaXml;

                            if (Directory.Exists(@pastaXML))
                            {
                                String xmlNome = NFe.Chave + "-procNfe-cancelamento.xml";

                                StreamWriter writer = new StreamWriter(@pastaXML + "\\" + xmlNome, false);
                                writer.Write(NFe.XmlCancelamento);
                                writer.Close();
                            }
                        }
                    }
                }
                catch
                {
                    
                }

                return true;

            }
            catch (System.Net.WebException e)
            {
                if (e.Message == "A solicitação foi anulada: Não foi possível criar um canal seguro para SSL/TLS.")
                {
                    throw new Exception("O certificado digital não é válido ou não está disponível");
                }
                else
                {
                    throw new Exception("Erro ao cancelar a NFe.\r\n" + e.Message, e);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar a NFe.\r\n" + e.Message, e);
            }
        }

    }
}
