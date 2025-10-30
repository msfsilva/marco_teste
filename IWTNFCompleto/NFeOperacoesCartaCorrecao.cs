using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTNFCompleto.RecepcaoEvento;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ItemChoiceType = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.ItemChoiceType;
using TEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TEvento;
using TEventoInfEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TEventoInfEvento;
using TEventoInfEventoDetEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TEventoInfEventoDetEvento;
using TProcEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TProcEvento;


namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {

        public static bool CartaCorrecao(NfeCompletoNotaClass NFe, string dadosCarta, TAmb Ambiente, string serialCertificado, string usuario, IWTPostgreNpgsqlCommand command, out string retornoDetalhado, bool Scan)
        {
            try
            {
                retornoDetalhado = "";
                ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

                BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                    ServicoNFe.RecepcaoEvento,
                    new List<object>()
                    {
                        NFe,
                        dadosCarta,
                        Ambiente,
                        serialCertificado,
                        usuario,
                        command,
                        Scan
                    },
                    new List<object>()
                    {
                        retornoDetalhado
                    },
                    waitForm);

                BackgroundWorker worker = new BackgroundWorker {WorkerReportsProgress = true};
                worker.DoWork += new DoWorkEventHandler(tr.Run);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tr.Completed);
                worker.RunWorkerAsync(tr);

                waitForm.ShowDialog();


                retornoDetalhado = (string) tr.ArgumentosSaida[0];
                return (bool) tr.Retorno;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar a carta de correção da NFe.\r\n" + e.Message, e);
            }
        }

        public static bool CartaCorrecaoInterno(NfeCompletoNotaClass NFe, string dadosCarta, TAmbLegado Ambiente, string serialCertificado, string usuario, IWTPostgreNpgsqlCommand command, out string retornoDetalhado, bool Scan)
        {
            try
            {
                #region Validações

                if (NFe.Chave.Length != 44)
                {
                    throw new Exception("A chave da NFe deve ter exatamente 44 caracteres");
                }


                for (int i = 0; i < NFe.Chave.Count(); i++)
                {
                    short tmp;
                    if (!short.TryParse(NFe.Chave[i].ToString(), out tmp))
                    {
                        throw new Exception("Impossível converter a chave para um número para o cálculo do digito verificador");
                    }
                }

                string chaveSemDigito = NFe.Chave.Substring(0, 43);



                int digitoChave = int.Parse(NFe.Chave.Substring(43));

                int digitoCalculado = FuncoesAuxiliares.DigitoModulo11(chaveSemDigito);
                if (!digitoCalculado.Equals(digitoChave))
                {
                    throw new Exception("Chave de NFe inválida, digito de verificador deveria ser " + digitoCalculado);
                }

                #endregion

                int codigoUf = int.Parse(NFe.Chave.Substring(0, 2));


                //Buscar numero do lote
                command.CommandText =
                    "SELECT  " +
                    "  COALESCE(MAX(public.nfe_completo_carta_correcao.ncc_numero_lote),0) " +
                    "FROM " +
                    "  public.nfe_completo_carta_correcao ";
                int NumeroLote = (Convert.ToInt32(command.ExecuteScalar())) + 1;

                TRetConsSitNFe retConsultaNfe;
                string retConsultaDetalhado;
                //SituacaoNFe situacaoNfe = NFeOperacoes.consultaSituacaoNfe(NFe.Chave, Ambiente, serialCertificado, out retConsultaDetalhado, out retConsultaNfe, Scan);
                //if (situacaoNfe == SituacaoNFe.NaoEncontrada)
                //{
                //    throw new Exception("Não é possível enviar a cartea de correção da nfe pois ela não foi encontrada na base da SEFAZ");
                //}

                //if (situacaoNfe == SituacaoNFe.Denegada)
               // {
               //     throw new Exception("Não é possível enviar a cartea de correção da nfe pois ela foi denegada.\r\n" + retConsultaDetalhado);
                //}

                //if (situacaoNfe == SituacaoNFe.Cancelada)
                //{
                //    throw new Exception("Não é possível enviar a cartea de correção da nfe pois ela já foi cancelada anteriormente.\r\n" + retConsultaDetalhado);
                //}

                command.CommandText =
                    "SELECT  " +
                    "  COALESCE(public.nfe_completo_carta_correcao.ncc_sequencial,0) as sequencial, " +
                    "  nfe_completo_carta_correcao.id_nfe_completo_carta_correcao " +
                    "FROM " +
                    "  public.nfe_completo_carta_correcao " +
                    "  INNER JOIN public.nfe_completo_nota ON (public.nfe_completo_carta_correcao.id_nfe_completo_nota = public.nfe_completo_nota.id_nfe_completo_nota) " +
                    "WHERE " +
                    "  public.nfe_completo_nota.nfn_chave = :nfn_chave";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_chave", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = NFe.Chave;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                int seqEvento = 1;
                int? idNfCartaCorrecao = null;
                if (read.HasRows)
                {
                    read.Read();
                    seqEvento = (Convert.ToInt32(read["sequencial"])) + 1;
                    idNfCartaCorrecao = Convert.ToInt32(read["id_nfe_completo_carta_correcao"]);
                }

                DateTime dataEnvio = DateTime.Now;


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
                                                                                              Id = "ID" + "110110" + NFe.Chave + seqEvento.ToString("D2"),
                                                                                              cOrgao = FuncoesAuxiliares.Codigo2TCOrgaoIBGE(codigoUf),
                                                                                              tpAmbLegado = Ambiente,
                                                                                              ItemElementName = NFe.CnpjEmitente.Length == 14 ? ItemChoiceType.CNPJ : ItemChoiceType.CPF,
                                                                                              Item = NFe.CnpjEmitente,
                                                                                              chNFe = NFe.Chave,
                                                                                              dhEvento = dataEnvio.ToString("yyyy-MM-ddTHH:mm:sszzz"),
                                                                                              tpEvento = TEventoInfEventoTpEvento.Item110110,
                                                                                              nSeqEvento = seqEvento.ToString(CultureInfo.CurrentCulture),
                                                                                              verEvento = TEventoInfEventoVerEvento.Item100,
                                                                                              detEvento = new TEventoInfEventoDetEvento()
                                                                                                              {
                                                                                                                  descEvento = TEventoInfEventoDetEventoDescEvento.CartadeCorrecao,
                                                                                                                  versao = TEventoInfEventoDetEventoVersao.Item100,
                                                                                                                  xCorrecao = dadosCarta,
                                                                                                                  xCondUso =
                                                                                                                      TEventoInfEventoDetEventoXCondUso.
                                                                                                                      ACartadeCorrecaoedisciplinadapeloparagrafo1oAdoart7odoConvenioSNde15dedezembrode1970epodeserutilizadapararegularizacaodeerroocorridonaemissaodedocumentofiscaldesdequeoerronaoestejarelacionadocomIasvariaveisquedeterminamovalordoimpostotaiscomobasedecalculoaliquotadiferencadeprecoquantidadevalordaoperacaooudaprestacaoIIacorrecaodedadoscadastraisqueimpliquemudancadoremetenteoudodestinatarioIIIadatadeemissaooudesaida
                                                                                                              }

                                                                                          }
                                                                      }
                                                              }

                };

                XmlSerializer serializer = new XmlSerializer(typeof(TEvento));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta.evento[0], namespaces);

                XmlDocument xmlEvento = new XmlDocument();
                xmlEvento.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


                CertificadoOperacoes.AssinaDocumento(certificado, ref xmlEvento, "#" + objConsulta.evento[0].infEvento.Id);
                objConsulta.evento[0] = (TEvento)serializer.Deserialize(new XmlNodeReader(xmlEvento));




                serializer = new XmlSerializer(typeof(TEnvEvento));

                builder = new Utf8StringWriter();
                settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                xmlWriter = XmlWriter.Create(builder, settings);

                namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                TCodUfIBGELegado estado = (TCodUfIBGELegado)Enum.ToObject(typeof(TCodUfIBGELegado), codigoUf);

                
                //string _UrlWebservice = EnderecosWebservices.getEndereco(estado, versaoLayout, Ambiente, ServicoNFe.RecepcaoEvento, Scan);
                //Scan não da suporte ainda para carta de correção
                string urlWebservice = EnderecosWebservices.GetEndereco(estado, versaoLayout, Ambiente, ServicoNFe.RecepcaoEvento, false, NFe.Modelo == "65" ? TMod.Item65 : TMod.Item55);

                RecepcaoEvento.NFeRecepcaoEvento4 client = new RecepcaoEvento.NFeRecepcaoEvento4
                {
                    Timeout = timeoutPadrao,
                    Url = urlWebservice,
                    SoapVersion = SoapProtocolVersion.Soap12
                };

                if (ProxyClass.ComProxy)
                {
                    client.Proxy = new WebProxy(ProxyClass.EnderecoProxy, false)
                    {
                        Credentials = new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy, ProxyClass.DomainProxy)
                    };
                }

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
                            retornoDetalhado = resultatoCompleto.retEvento[0].infEvento.xMotivo;

                            TProcEvento proc = new TProcEvento()
                            {

                                versao = versaoLayoutConsultaString,
                                evento = objConsulta.evento[0],
                                retEvento = resultatoCompleto.retEvento[0]
                            };

                            serializer = new XmlSerializer(typeof(TProcEvento));

                            builder = new Utf8StringWriter();
                            settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                            xmlWriter = XmlWriter.Create(builder, settings);

                            namespaces = new XmlSerializerNamespaces();
                            namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                            serializer.Serialize(xmlWriter, proc, namespaces);


                            if (!idNfCartaCorrecao.HasValue)
                            {
                                command.CommandText =
                                    "INSERT INTO  " +
                                    "  public.nfe_completo_carta_correcao " +
                                    "( " +
                                    "  id_nfe_completo_nota, " +
                                    "  ncc_numero_lote, " +
                                    "  ncc_data_hora, " +
                                    "  ncc_sequencial, " +
                                    "  ncc_texto, " +
                                    "  ncc_xml, " +
                                    "  ncc_retorno, " +
                                    "  ncc_retorno_detalhado " +
                                    ")  " +
                                    "VALUES ( " +
                                    "  :id_nfe_completo_nota, " +
                                    "  :ncc_numero_lote, " +
                                    "  :ncc_data_hora, " +
                                    "  :ncc_sequencial, " +
                                    "  :ncc_texto, " +
                                    "  :ncc_xml, " +
                                    "  :ncc_retorno, " +
                                    "  :ncc_retorno_detalhado " +
                                    "); ";
                            }
                            else
                            {
                                command.CommandText =
                                    "UPDATE  " +
                                    "  public.nfe_completo_carta_correcao   " +
                                    "SET  " +
                                    "  id_nfe_completo_nota = :id_nfe_completo_nota, " +
                                    "  ncc_numero_lote = :ncc_numero_lote, " +
                                    "  ncc_data_hora = :ncc_data_hora, " +
                                    "  ncc_sequencial = :ncc_sequencial, " +
                                    "  ncc_texto = :ncc_texto, " +
                                    "  ncc_xml = :ncc_xml, " +
                                    "  ncc_retorno = :ncc_retorno, " +
                                    "  ncc_retorno_detalhado = :ncc_retorno_detalhado " +
                                    "WHERE  " +
                                    "  id_nfe_completo_carta_correcao = :id_nfe_completo_carta_correcao " +
                                    "; ";
                            }
                            command.Parameters.Clear();

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_carta_correcao", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = idNfCartaCorrecao;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_nota", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = NFe.ID;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_numero_lote", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = NumeroLote;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_data_hora", NpgsqlDbType.TimestampTZ));
                            command.Parameters[command.Parameters.Count - 1].Value = dataEnvio;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_sequencial", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = seqEvento;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_texto", NpgsqlDbType.Varchar));
                            command.Parameters[command.Parameters.Count - 1].Value = dadosCarta;
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_xml", NpgsqlDbType.Text));
                            command.Parameters[command.Parameters.Count - 1].Value = builder.ToString();
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_retorno", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = int.Parse(resultatoCompleto.cStat);
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncc_retorno_detalhado", NpgsqlDbType.Varchar));
                            command.Parameters[command.Parameters.Count - 1].Value = retornoDetalhado;
                            command.ExecuteNonQuery();

                            return true;

                            break;
                        default:
                            string erroDetalhado = "cStat: " + resultatoCompleto.retEvento[0].infEvento.cStat + " xMotivo: " + resultatoCompleto.retEvento[0].infEvento.xMotivo;
                            throw new Exception("Situação da NFe não prevista: " + erroDetalhado);
                    }


                }
                else
                {
                    string erroDetalhado = "cStat: " + resultatoCompleto.cStat + " xMotivo: " + resultatoCompleto.xMotivo;
                    throw new Exception("Situação da NFe não prevista: " + erroDetalhado);
                }

                return false;
            }
            catch (System.Net.WebException e)
            {
                if (e.Message == "A solicitação foi anulada: Não foi possível criar um canal seguro para SSL/TLS.")
                {
                    throw new Exception("O certificado digital não é válido ou não está disponível");
                }
                else
                {
                    throw new Exception("Erro ao gerar a carta de correção da NFe.\r\n" + e.Message, e);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar a carta de correção da NFe.\r\n" + e.Message, e);
            }
        }

    }
}
