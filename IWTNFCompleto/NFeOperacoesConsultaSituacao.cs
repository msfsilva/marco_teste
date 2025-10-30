using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.NfeConsulta;

namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {
        public static SituacaoNFe consultaSituacaoNfe(string chaveNFe, TAmbLegado Ambiente, string serialCertificado, out string retornoDetalhado, bool Scan)
        {
            TRetConsSitNFe tmp = null;
            retornoDetalhado = "";
            ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

            BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                ServicoNFe.NfeConsultaProtocolo,
                new List<object>()
                    {
                        chaveNFe,
                        Ambiente,
                        serialCertificado,
                        Scan
                    },
                new List<object>()
                    {
                        retornoDetalhado,
                        tmp
                    },
                    waitForm);

            BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += new DoWorkEventHandler(tr.Run);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tr.Completed);
            worker.RunWorkerAsync(tr);

            waitForm.ShowDialog();


            retornoDetalhado = (string)tr.ArgumentosSaida[0];
            return (SituacaoNFe)tr.Retorno;
        }

        internal static SituacaoNFe consultaSituacaoNfe(string chaveNFe, TAmbLegado Ambiente, string serialCertificado, out string retornoDetalhado, out TRetConsSitNFe resultatoCompleto, bool Scan)
        {
            try
            {
                #region Validações

                if (chaveNFe.Length != 44)
                {
                    throw new Exception("A chave da NFe deve ter exatamente 44 caracteres");
                }


                for (int i = 0; i < chaveNFe.Count(); i++)
                {
                    short tmp;
                    if (!short.TryParse(chaveNFe[i].ToString(), out tmp))
                    {
                        throw new Exception("Impossível converter a chave para um número para o cálculo do digito verificador");
                    }
                }

                string chaveSemDigito = chaveNFe.Substring(0, 43);



                int digitoChave = int.Parse(chaveNFe.Substring(43));

                int digitoCalculado = FuncoesAuxiliares.DigitoModulo11(chaveSemDigito);
                if (!digitoCalculado.Equals(digitoChave))
                {
                    throw new Exception("Chave de NFe inválida, digito de verificador deveria ser " + digitoCalculado);
                }

                #endregion

                int codigoUf = int.Parse(chaveNFe.Substring(0, 2));
                TMod modelo = chaveNFe.Substring(20, 2) == "65" ? TMod.Item65 : TMod.Item55;

                TConsSitNFe objConsulta = new TConsSitNFe
                {
                    versaoLegado = versaoLayoutConsulta,
                    tpAmbLegado = Ambiente,
                    xServ = TConsSitNFeXServ.CONSULTAR,
                    chNFe = chaveNFe
                };


                XmlSerializer serializer = new XmlSerializer(typeof(TConsSitNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                TCodUfIBGELegado estado = (TCodUfIBGELegado)Enum.ToObject(typeof(TCodUfIBGELegado), codigoUf);

                

                string urlWebservice = EnderecosWebservices.GetEndereco(estado, versaoLayout, Ambiente, ServicoNFe.NfeConsultaProtocolo, Scan, modelo);


                NfeConsulta.NfeConsulta4 client;
                switch (estado)
                {
                    case TCodUfIBGELegado.SP:
                        client = new NfeConsulta.NfeConsulta4 { Timeout = timeoutPadrao, Url = urlWebservice, SoapVersion = SoapProtocolVersion.Soap12, };
                        break;

                    default:
                        client = new NfeConsulta.NfeConsulta4 { Timeout = timeoutPadrao, Url = urlWebservice };
                        break;
                }
                

                if (ProxyClass.ComProxy)
                {
                    client.Proxy = new WebProxy(ProxyClass.EnderecoProxy, false)
                    {
                        Credentials = new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy, ProxyClass.DomainProxy)
                    };
                }

                client.ClientCertificates.Add(CertificadoOperacoes.BuscaCertficado(serialCertificado));


                XmlNode resultadoProcessamento = client.nfeConsultaNF(xmlConsulta);


                serializer = new XmlSerializer(typeof(TRetConsSitNFe));
                resultatoCompleto = (TRetConsSitNFe)serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                switch (resultatoCompleto.cStat)
                {
                    case "100":
                        retornoDetalhado = "Nota fiscal com uso autorizado em " + resultatoCompleto.protNFe.infProt.dhRecbto.ToString(CultureInfo.CurrentCulture) + " - " + resultatoCompleto.protNFe.infProt.xMotivo;
                        return SituacaoNFe.Autorizada;
                    case "110":
                        retornoDetalhado = "Nota fiscal com uso DENEGADO em " + resultatoCompleto.protNFe.infProt.dhRecbto.ToString(CultureInfo.CurrentCulture) + " - " + resultatoCompleto.protNFe.infProt.xMotivo;
                        return SituacaoNFe.Denegada;
                    case "101":

                        retornoDetalhado = "Nota fiscal CANCELADA";
                        if (resultatoCompleto.retCancNFe != null)
                        {
                            retornoDetalhado = "Nota fiscal CANCELADA em " + resultatoCompleto.retCancNFe.infCanc.dhRecbto.ToString(CultureInfo.CurrentCulture) + " - " + resultatoCompleto.retCancNFe.infCanc.xMotivo;
                        }
                        else
                        {
                            foreach (TProcEvento evento in resultatoCompleto.procEventoNFe)
                            {
                                if (evento.evento.infEvento.tpEvento == "110111")
                                {
                                    retornoDetalhado = "Nota fiscal CANCELADA em " + evento.evento.infEvento.dhEvento.ToString(CultureInfo.CurrentCulture) + " - " + evento.evento.infEvento.detEvento.Any;
                                    break;
                                }
                                
                            }
                            
                        }
                        return SituacaoNFe.Cancelada;
                    case "217":
                        retornoDetalhado = "Nota fiscal não encontrada na base da SEFAZ";
                        return SituacaoNFe.NaoEncontrada;
                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.cStat + " xMotivo: " + resultatoCompleto.xMotivo;
                        throw new Exception("Situação da NFe não prevista: " + erroDetalhado);
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
                    throw new Exception("Erro ao consultar a situação da NFe.\r\n" + e.Message, e);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar a situação da NFe.\r\n" + e.Message, e);
            }

        }
    }
}
