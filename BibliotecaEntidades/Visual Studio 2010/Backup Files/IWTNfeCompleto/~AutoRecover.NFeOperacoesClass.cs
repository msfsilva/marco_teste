using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using BibliotecaDatasets;
using BibliotecaWebservices.br.gov.pr.fazenda.nfe2;
using BibliotecaWebservices.br.gov.pr.fazenda.nfe2.homologacao;
using BibliotecaWebservices.br.gov.pr.fazenda.nfe21;
using BibliotecaWebservices.br.gov.pr.fazenda.nfe22;
using BibliotecaWebservices.br.gov.pr.fazenda.nfe23;
using BibliotecaWebservices.br.gov.pr.fazenda.nfe24;
using BibliotecaWebservices.br.gov.sp.fazenda.nfe;
using IWTNF.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace IWTNFCompleto
{
    public enum SituacaoNFe
    {
        Enviada,
        Autorizada,
        Denegada,
        Cancelada,
        NaoEncontrada,
        Rejeitada
    }

    public enum SituacaoServico
    {
        EmOperacao,
        ParalizadoTemporariamente,
        ParalizadoSemPrevisao
    }

    public enum RetornoProcessamentoLote
    {
        EmProcessamento,
        Processado,
        ProcessadoComProblemas,
        Erro
    }

    public static class NFeOperacoes
    {

        private static string versaoLayout = "2.00";
        private static int timeoutPadrao = 30000;
        private static string versaoAplicativoEmissor = "1.00";

        public static SituacaoNFe consultaSituacaoNfe(string chaveNFe, TAmb Ambiente, string serialCertificado, out string retornoDetalhado)
        {
            TRetConsSitNFe tmp;
            return NFeOperacoes.consultaSituacaoNfe(chaveNFe, Ambiente, serialCertificado, out retornoDetalhado, out tmp);
        }

        private static SituacaoNFe consultaSituacaoNfe(string chaveNFe, TAmb Ambiente, string serialCertificado, out string retornoDetalhado, out TRetConsSitNFe resultatoCompleto)
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

                TConsSitNFe objConsulta = new TConsSitNFe
                                              {
                                                  versao = versaoLayout,
                                                  tpAmb = Ambiente,
                                                  xServ = TConsSitNFeXServ.CONSULTAR,
                                                  chNFe = chaveNFe
                                              };


                XmlSerializer serializer = new XmlSerializer(typeof (TConsSitNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());


                string _UrlWebservice = EnderecosWebservices.getEndereco((TCodUfIBGE) Enum.ToObject(typeof (TCodUfIBGE), codigoUf), versaoLayout, Ambiente, ServicoNFe.NfeConsultaProtocolo);

                NfeConsulta2 client = new NfeConsulta2 {Timeout = timeoutPadrao, Url = _UrlWebservice};

                client.ClientCertificates.Add(CertificadoOperacoes.BuscaCertficado(serialCertificado));
                BibliotecaWebservices.br.gov.pr.fazenda.nfe2.homologacao.nfeCabecMsg cabec = new BibliotecaWebservices.br.gov.pr.fazenda.nfe2.homologacao.nfeCabecMsg
                                                                                                 {
                                                                                                     versaoDados = versaoLayout,
                                                                                                     cUF = Convert.ToInt32(codigoUf).ToString()
                                                                                                 };
                client.nfeCabecMsgValue = cabec;

                XmlNode resultadoProcessamento = client.nfeConsultaNF2(xmlConsulta);


                serializer = new XmlSerializer(typeof (TRetConsSitNFe));
                resultatoCompleto = (TRetConsSitNFe) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                switch (resultatoCompleto.cStat)
                {
                    case "100":
                        retornoDetalhado = "Nota fiscal com uso autorizado em " + resultatoCompleto.protNFe.infProt.dhRecbto.ToString(CultureInfo.CurrentCulture) + " - " + resultatoCompleto.protNFe.infProt.xMotivo;
                        return SituacaoNFe.Autorizada;
                    case "110":
                        retornoDetalhado = "Nota fiscal com uso DENEGADO em " + resultatoCompleto.protNFe.infProt.dhRecbto.ToString(CultureInfo.CurrentCulture) + " - " + resultatoCompleto.protNFe.infProt.xMotivo;
                        return SituacaoNFe.Denegada;
                    case "101":
                        retornoDetalhado = "Nota fiscal CANCELADA em " + resultatoCompleto.retCancNFe.infCanc.dhRecbto.ToString(CultureInfo.CurrentCulture) + " - " + resultatoCompleto.retCancNFe.infCanc.xMotivo;
                        return SituacaoNFe.Cancelada;
                    case "217":
                        retornoDetalhado = "Nota fiscal não encontrada na base da SEFAZ";
                        return SituacaoNFe.NaoEncontrada;
                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.cStat + "xMotivo" + resultatoCompleto.xMotivo;
                        throw new Exception("Situação da NFe não prevista: " + erroDetalhado);
                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar a situação da NFe.\r\n" + e.Message, e);
            }

        }

        public static bool CancelaNfe(NFeEmitidaClass NFe, TAmb Ambiente, string serialCertificado, string justificativa, out string retornoDetalhado,  string usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                TRetConsSitNFe retConsultaNfe;
                string retConsultaDetalhado;
                SituacaoNFe situacaoNfe = NFeOperacoes.consultaSituacaoNfe(, Ambiente, serialCertificado, out retConsultaDetalhado, out retConsultaNfe);
                if (situacaoNfe == SituacaoNFe.NaoEncontrada)
                {
                    throw new Exception("Não é possível cancelar a nfe pois ela não foi encontrada na base da SEFAZ");
                }

                if (situacaoNfe == SituacaoNFe.Denegada)
                {
                    throw new Exception("Não é possível cancelar a nfe pois ela foi denegada.\r\n" + retConsultaDetalhado);
                }

                if (situacaoNfe == SituacaoNFe.Cancelada)
                {
                    throw new Exception("Não é possível cancelar a nfe pois ela já foi cancelada anteriormente.\r\n" + retConsultaDetalhado);
                }

                TCancNFe objConsulta = new TCancNFe
                                           {
                                               versao = versaoLayout,
                                               infCanc = new TCancNFeInfCanc()
                                                             {
                                                                 chNFe = chaveNFe,
                                                                 Id = "ID" + chaveNFe,
                                                                 nProt = retConsultaNfe.protNFe.infProt.nProt,
                                                                 tpAmb = Ambiente,
                                                                 xJust = justificativa,
                                                                 xServ = TCancNFeInfCancXServ.CANCELAR
                                                             }
                                           };

                XmlSerializer serializer = new XmlSerializer(typeof(TCancNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);

                CertificadoOperacoes.AssinaDocumento(certificado, ref xmlConsulta, "#" + objConsulta.infCanc.Id);

                string _UrlWebservice = EnderecosWebservices.getEndereco(retConsultaNfe.cUF, versaoLayout, Ambiente, ServicoNFe.NfeCancelamento);

                NfeCancelamento2 client = new NfeCancelamento2
                                              {
                                                  Timeout = timeoutPadrao,
                                                  Url = _UrlWebservice,
                                                  nfeCabecMsgValue = new BibliotecaWebservices.br.gov.pr.fazenda.nfe2.nfeCabecMsg()
                                                                         {
                                                                             versaoDados = versaoLayout,
                                                                             cUF = Convert.ToInt32(retConsultaNfe.cUF).ToString()
                                                                         }

                                              };
                client.ClientCertificates.Add(certificado);

                XmlNode resultadoProcessamento = client.nfeCancelamentoNF2(xmlConsulta);

                serializer = new XmlSerializer(typeof(TRetCancNFe));
                TRetCancNFe resultatoCompleto = (TRetCancNFe) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                switch (resultatoCompleto.infCanc.cStat)
                {
                    case "101":
                        retornoDetalhado = "NFe Cancelada com sucesso. " + resultatoCompleto.infCanc.xMotivo;
                        break;
                    default:
                        retornoDetalhado = "cStat: " + resultatoCompleto.infCanc.cStat + "xMotivo" + resultatoCompleto.infCanc.xMotivo;
                        throw new Exception("Retorno do cancelamento da NFe não previsto: " + retornoDetalhado);
                }

                
                builder = new Utf8StringWriter();
                settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                xmlWriter = XmlWriter.Create(builder, settings);

                namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, resultatoCompleto, namespaces);

                IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                command.CommandText =
                    "UPDATE  " +
                    "  public.nfe_completo_nota " +
                    "SET " +
                    "  nfn_situacao = 3, " +
                    "  nfn_xml_cancelamento = :nfn_xml_cancelamento, " +
                    "  nfn_data_cancelamento = :nfn_data_cancelamento, " +
                    "  nfn_justificativa_cancelamento = :nfn_justificativa_cancelamento, " +
                    "  nfn_usuario_cancelamento = :nfn_usuario_cancelamento " +
                    "WHERE " +
                    "  public.nfe_completo_nota.nfn_chave = :nfn_chave ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_chave", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infCanc.chNFe;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_xml_cancelamento", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = builder.ToString();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = DateTime.Now;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_justificativa_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infCanc.xJust;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_usuario_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = usuario;

                command.ExecuteNonQuery();


                return true;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar a NFe.\r\n" + e.Message, e);
            }
        }

        public static bool InutilizarFaixaNumeracao(int serie, int numeroInicial, int numeroFinal, string cnpj, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, string justificativa, out string retornoDetalhado, string usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {

                IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                command.CommandText =
                    "SELECT    " +
                    "  public.nfe_completo_inutilizacao.id_nfe_completo_inutilizacao   " +
                    "FROM   " +
                    "  public.nfe_completo_inutilizacao   " +
                    "WHERE   " +
                    "  public.nfe_completo_inutilizacao.nci_cnpj = :nci_cnpj AND    " +
                    "  public.nfe_completo_inutilizacao.nci_serie = :nci_serie AND   " +
                    " ( " +
                    " date '2000-01-01' + public.nfe_completo_inutilizacao.nci_inicio * (interval '1 day'), " +
                    " date '2000-01-01' + public.nfe_completo_inutilizacao.nci_fim * (interval '1 day') " +
                    " ) OVERLAPS( " +
                    " date '2000-01-01' + :inicio * (interval '1 day'), " +
                    " date '2000-01-01' + :fim * (interval '1 day') " +
                    " ) ; ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = cnpj;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = serie;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("inicio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = numeroInicial;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fim", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = numeroFinal;

                NpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    throw new Exception("Não é possível inutilizar a faixa de numeração pois ela possui notas já inutilizadas");
                }

                read.Close();


                command.CommandText =
                    "SELECT  " +
                    "  public.nfe_completo_nota.nfn_numero " +
                    "FROM " +
                    "  public.nfe_completo_nota " +
                    "WHERE " +
                    "  (public.nfe_completo_nota.nfn_numero BETWEEN :inicio AND :fim) AND " +
                    "  public.nfe_completo_nota.nfn_serie = :nci_serie AND " +
                    "  public.nfe_completo_nota.nfn_cnpj_emitente =:nci_cnpj ";


                read = command.ExecuteReader();
                if (read.HasRows)
                {
                    throw new Exception("Não é possível inutilizar a faixa de numeração pois ela possui notas emitidas");
                }

                read.Close();


                TInutNFe objConsulta = new TInutNFe
                                           {
                                               versao = versaoLayout,
                                               infInut = new TInutNFeInfInut()
                                                             {
                                                                 ano = DateTime.Now.ToString("yy"),
                                                                 CNPJ = cnpj,
                                                                 cUF = ufEmitente,
                                                                 Id =
                                                                     "ID" + Convert.ToInt32(ufEmitente).ToString("D2") + DateTime.Now.ToString("yy") + cnpj + "55" + serie.ToString("D3") + numeroInicial.ToString("D9") + numeroFinal.ToString("D9"),
                                                                 mod = TMod.Item55,
                                                                 nNFFin = numeroFinal.ToString(),
                                                                 nNFIni = numeroInicial.ToString(),
                                                                 serie = serie.ToString(),
                                                                 tpAmb = Ambiente,
                                                                 xJust = justificativa,
                                                                 xServ = TInutNFeInfInutXServ.INUTILIZAR
                                                             }
                                           };


                XmlSerializer serializer = new XmlSerializer(typeof (TInutNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);

                CertificadoOperacoes.AssinaDocumento(certificado, ref xmlConsulta, "#" + objConsulta.infInut.Id);

                string _UrlWebservice = EnderecosWebservices.getEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeInutilizacao);

                NfeInutilizacao2 client = new NfeInutilizacao2
                                              {
                                                  Timeout = timeoutPadrao,
                                                  Url = _UrlWebservice,
                                                  nfeCabecMsgValue = new BibliotecaWebservices.br.gov.pr.fazenda.nfe21.nfeCabecMsg()
                                                                         {
                                                                             versaoDados = versaoLayout,
                                                                             cUF = Convert.ToInt32(ufEmitente).ToString()
                                                                         }

                                              };
                client.ClientCertificates.Add(certificado);
                XmlNode resultadoProcessamento = client.nfeInutilizacaoNF2(xmlConsulta);

                serializer = new XmlSerializer(typeof(TRetInutNFe));
                TRetInutNFe resultatoCompleto = (TRetInutNFe) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                switch (resultatoCompleto.infInut.cStat)
                {
                    case "102":
                        retornoDetalhado = "Inutilização homologada com sucesso. " + resultatoCompleto.infInut.xMotivo;

                        break;
                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.infInut.cStat + "xMotivo" + resultatoCompleto.infInut.xMotivo;
                        throw new Exception("Retorno da inutilização da faixa não previsto: " + erroDetalhado);
                }

                builder = new Utf8StringWriter();
                settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                xmlWriter = XmlWriter.Create(builder, settings);

                namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, resultatoCompleto, namespaces);

                command = conn.CreateCommand();
                command.CommandText =
                    "INSERT INTO  " +
                    "  public.nfe_completo_inutilizacao " +
                    "( " +
                    "  nci_cnpj, " +
                    "  nci_uf, " +
                    "  nci_serie, " +
                    "  nci_inicio, " +
                    "  nci_fim, " +
                    "  nci_justificativa, " +
                    "  nci_data, " +
                    "  nci_usuario, " +
                    "  nci_xml "+
                    ")  " +
                    "VALUES ( " +
                    "  :nci_cnpj, " +
                    "  :nci_uf, " +
                    "  :nci_serie, " +
                    "  :nci_inicio, " +
                    "  :nci_fim, " +
                    "  :nci_justificativa, " +
                    "  :nci_data, " +
                    "  :nci_usuario, " +
                    "  :nci_xml " +
                    "); ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_cnpj", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infInut.CNPJ;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_uf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infInut.cUF.ToString();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infInut.serie;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_inicio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infInut.nNFIni;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_fim", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infInut.nNFFin;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = objConsulta.infInut.xJust;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = DateTime.Now;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = usuario;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_xml", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = builder.ToString();

                command.ExecuteNonQuery();

                return true;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inutilizar a faixa.\r\n" + e.Message, e);
            }
        }

        public static SituacaoServico SituacaoServico(TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, out string retornoDetalhado)
        {
            try
            {


                TConsStatServ objConsulta = new TConsStatServ
                                                {
                                                    versao = versaoLayout,
                                                    cUF = ufEmitente,
                                                    tpAmb = Ambiente,
                                                    xServ = TConsStatServXServ.STATUS
                                                };


                XmlSerializer serializer = new XmlSerializer(typeof (TInutNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


                string _UrlWebservice = EnderecosWebservices.getEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeStatusServico);

                NfeStatusServico2 client = new NfeStatusServico2
                                               {
                                                   Timeout = timeoutPadrao,
                                                   Url = _UrlWebservice,
                                                   nfeCabecMsgValue = new BibliotecaWebservices.br.gov.pr.fazenda.nfe22.nfeCabecMsg()
                                                                          {
                                                                              versaoDados = versaoLayout,
                                                                              cUF = Convert.ToInt32(ufEmitente).ToString()
                                                                          }

                                               };

                client.ClientCertificates.Add(certificado);

                XmlNode resultadoProcessamento = client.nfeStatusServicoNF2(xmlConsulta);

                serializer = new XmlSerializer(typeof (TRetConsSitNFe));
                TRetConsStatServ resultatoCompleto = (TRetConsStatServ) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                switch (resultatoCompleto.cStat)
                {
                    case "107":
                        retornoDetalhado = "Serviço em Operação";
                        return IWTNFCompleto.SituacaoServico.EmOperacao;
                        break;

                    case "108":
                        retornoDetalhado = "Serviço Paralizado Temporariamente - " + resultatoCompleto.xMotivo + " - " + resultatoCompleto.xObs;
                        return IWTNFCompleto.SituacaoServico.ParalizadoTemporariamente;
                        break;

                    case "109":
                        retornoDetalhado = "Serviço Paralizado Sem Previsão de Retorno - " + resultatoCompleto.xMotivo + " - " + resultatoCompleto.xObs;
                        return IWTNFCompleto.SituacaoServico.ParalizadoSemPrevisao;
                        break;

                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.cStat + "xMotivo" + resultatoCompleto.xMotivo;
                        throw new Exception("Retorno da inutilização da faixa não previsto: " + erroDetalhado);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inutilizar a faixa.\r\n" + e.Message, e);
            }
        }

        public static TRetConsCad ConsultaCadastro(TipoDocumento tipoDocumento, string numeroDocumento, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, out string retornoDetalhado)
        {
            try
            {


                TConsCad objConsulta = new TConsCad
                                           {
                                               versao = versaoLayout,
                                               infCons = new TConsCadInfCons()
                                                             {
                                                                 ItemElementName = tipoDocumento,
                                                                 Item = numeroDocumento,
                                                                 UF = FuncoesAuxiliares.TCodUfIBGE2TUfCons(ufEmitente),
                                                                 xServ = TConsCadInfConsXServ.CONSCAD
                                                             }
                                           };


                XmlSerializer serializer = new XmlSerializer(typeof (TConsCad));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


                string _UrlWebservice = EnderecosWebservices.getEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeConsultaCadastro);

                CadConsultaCadastro2 client = new CadConsultaCadastro2
                                                  {
                                                      Timeout = timeoutPadrao,
                                                      Url = _UrlWebservice,
                                                      nfeCabecMsgValue = new BibliotecaWebservices.br.gov.sp.fazenda.nfe.nfeCabecMsg()
                                                                             {
                                                                                 versaoDados = versaoLayout,
                                                                                 cUF = Convert.ToInt32(ufEmitente).ToString()
                                                                             }

                                                  };

                client.ClientCertificates.Add(certificado);

                XmlNode resultadoProcessamento = client.consultaCadastro2(xmlConsulta);

                serializer = new XmlSerializer(typeof (TRetConsSitNFe));
                TRetConsCad resultatoCompleto = (TRetConsCad) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                switch (resultatoCompleto.infCons.cStat)
                {
                    case "111":
                        retornoDetalhado = "Consulta com uma Ocorrência";
                        return resultatoCompleto;
                        break;

                    case "112":
                        retornoDetalhado = "Consulta com mais de uma ocorrência";
                        return resultatoCompleto;
                        break;



                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.infCons.cStat + "xMotivo" + resultatoCompleto.infCons.xMotivo;
                        throw new Exception("Retorno da consulta de cadastro não previsto: " + erroDetalhado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao consultar o cadastro.\r\n" + e.Message, e);
            }
        }

        public static List<LoteEnviar> EnviaNfe(List<NfPrincipal> Notas, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor)
        {

            string numeroNota = "";
            string errosConversao = "";
            try
            {
                Random r = new Random();

                List<TNFe> notasEnviar = new List<TNFe>();
                
                foreach (NfPrincipal nota in Notas)
                {
                    numeroNota = nota.NfpNumero.ToString();

                    try
                    {
                        #region Validações

                        if (nota.NfpModeloDocFiscal != "55")
                        {
                            throw new Exception("O modelo da NFe deve ser 55");
                        }

                        if (nota.NfEmitente.NfEmitenteEndereco.NeeCodPais != 1058)
                        {
                            throw new Exception("O código do país do emitente deve ser 1058");
                        }

                        Tpais testePais;
                        if (!Enum.TryParse("Item" + nota.NfCliente.NfClienteEndereco.NceCodPais, out testePais))
                        {
                            throw new Exception("O código do país do cliente é inválido");
                        }

                        if (string.IsNullOrWhiteSpace(nota.NfCliente.NfClienteEndereco.NceNumero))
                        {
                            throw new Exception("O número do endereço do cliente é inválido");
                        }

                        if (string.IsNullOrWhiteSpace(nota.NfCliente.NfClienteEndereco.NceBairro))
                        {
                            throw new Exception("O bairro do endereço do cliente é inválido");
                        }




                        #endregion

                        #region Dados Basicos

                        TNFe notaEnviar = new TNFe();
                        notaEnviar.infNFe = new TNFeInfNFe()
                                                {
                                                    versao = versaoLayout
                                                };

                        notaEnviar.infNFe.ide = new TNFeInfNFeIde
                                                    {
                                                        cUF = ufEmitente,
                                                        cNF = r.Next(1, 99999999).ToString("D8"),
                                                        natOp = nota.NfpNaturezaOperacao,
                                                        indPag = (TNFeInfNFeIdeIndPag) Enum.Parse(typeof (TNFeInfNFeIdeIndPag), "Item" + nota.NfpFormaPagamento.ToString()),
                                                        mod = TMod.Item55,
                                                        serie = nota.NfpSerie.ToString(),
                                                        nNF = nota.NfpNumero.ToString(),
                                                        dEmi = nota.NfpDataEmissao.Date.ToString("yyyy-MM-dd"),
                                                        dSaiEnt = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfpDataSaidaEntrada.Date.ToString("yyyy-MM-dd")),
                                                        hSaiEnt = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfpDataSaidaEntrada.ToString("HH:mm:ss")),
                                                        tpNF = nota.NfpTipo == 0 ? TNFeInfNFeIdeTpNF.Item0 : TNFeInfNFeIdeTpNF.Item1,
                                                        cMunFG = nota.NfpCodMunicipioFatoGerador.ToString(),
                                                        tpImp = TNFeInfNFeIdeTpImp.Item1,
                                                        tpEmis = TNFeInfNFeIdeTpEmis.Item1,
                                                        finNFe = (TFinNFe) Enum.Parse(typeof (TFinNFe), "Item" + nota.NfpFinalidadeEmissao),
                                                        procEmi = TProcEmi.Item0,
                                                        verProc = versaoAplicativoEmissor,
                                                        tpAmb = Ambiente,
                                                    };



                        notaEnviar.infNFe.emit = new TNFeInfNFeEmit
                                                     {
                                                         ItemElementName = nota.NfEmitente.NfeCnpjCpf.Length == 11 ? ItemChoiceType2.CPF : ItemChoiceType2.CNPJ,
                                                         Item = nota.NfEmitente.NfeCnpjCpf,
                                                         xNome = nota.NfEmitente.NfeRazao,
                                                         xFant = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfeNomeFantasia),
                                                         enderEmit = new TEnderEmi
                                                                         {
                                                                             xLgr = nota.NfEmitente.NfEmitenteEndereco.NeeLogradouro,
                                                                             nro = nota.NfEmitente.NfEmitenteEndereco.NeeNumero,
                                                                             xCpl = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfEmitenteEndereco.NeeComplemento),
                                                                             xBairro = nota.NfEmitente.NfEmitenteEndereco.NeeBairro,
                                                                             cMun = nota.NfEmitente.NfEmitenteEndereco.NeeCodMunicipio.ToString(),
                                                                             xMun = nota.NfEmitente.NfEmitenteEndereco.NeeNomeMunicipio,
                                                                             UF = FuncoesAuxiliares.Sigla2TUfEmi(nota.NfEmitente.NfEmitenteEndereco.NeeSiglaUf),
                                                                             CEP = nota.NfEmitente.NfEmitenteEndereco.NeeCep,
                                                                             cPais = TEnderEmiCPais.Item1058,
                                                                             fone = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfEmitenteEndereco.NeeTelefone)
                                                                         },
                                                         IE = nota.NfEmitente.NfeIe,
                                                         IEST = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfeIeSt),
                                                         IM = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfeIm),
                                                         CNAE = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfEmitente.NfeCnae),
                                                         CRT = (TNFeInfNFeEmitCRT) Enum.Parse(typeof (TNFeInfNFeEmitCRT), "Item" + nota.NfEmitente.NfeCrt)
                                                     };

                        string chaveAcessoNfSemDigito =
                            Convert.ToInt32(notaEnviar.infNFe.ide.cUF).ToString() +
                            nota.NfpDataEmissao.ToString("yyMM") +
                            notaEnviar.infNFe.emit.Item.PadLeft(14, '0') +
                            "55" +
                            notaEnviar.infNFe.ide.serie.PadLeft(3, '0') +
                            notaEnviar.infNFe.ide.nNF.PadLeft(9, '0') +
                            notaEnviar.infNFe.ide.tpEmis.ToString().Replace("Item", "") +
                            notaEnviar.infNFe.ide.cNF;

                        int digitoNfe = FuncoesAuxiliares.DigitoModulo11(chaveAcessoNfSemDigito);
                        string chaveCompleta = chaveAcessoNfSemDigito + "" + digitoNfe;

                        notaEnviar.infNFe.ide.cDV = digitoNfe.ToString();




                        notaEnviar.infNFe.dest = new TNFeInfNFeDest
                                                     {
                                                         ItemElementName = nota.NfCliente.NfcCnpjCpf.Length == 11 ? ItemChoiceType3.CPF : ItemChoiceType3.CNPJ,
                                                         Item = nota.NfCliente.NfcCnpjCpf,
                                                         xNome = nota.NfCliente.NfcRazao,
                                                         enderDest = new TEndereco()
                                                                         {
                                                                             xLgr = nota.NfCliente.NfClienteEndereco.NceLogradouro,
                                                                             nro = nota.NfCliente.NfClienteEndereco.NceNumero,
                                                                             xCpl = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfClienteEndereco.NceComplemento),
                                                                             xBairro = nota.NfCliente.NfClienteEndereco.NceBairro,
                                                                             cMun = nota.NfCliente.NfClienteEndereco.NceCodMunicipio.ToString(),
                                                                             xMun = nota.NfCliente.NfClienteEndereco.NceNomeMunicipio,
                                                                             UF = FuncoesAuxiliares.Sigla2TUf(nota.NfCliente.NfClienteEndereco.NceSiglaUf),
                                                                             CEP = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfClienteEndereco.NceCep),
                                                                             cPais = (Tpais) Enum.Parse(typeof (Tpais), "Item" + nota.NfCliente.NfClienteEndereco.NceCodPais),
                                                                             fone = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfClienteEndereco.NceTelefone)
                                                                         },
                                                         IE = nota.NfCliente.NfcIe,
                                                         ISUF = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfcIsuf),
                                                         email = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCliente.NfcEmail)
                                                     };


                        notaEnviar.infNFe.total = new TNFeInfNFeTotal
                                                      {
                                                          ICMSTot = new TNFeInfNFeTotalICMSTot
                                                                        {
                                                                            vBC = nota.NfTotais.NfoBaseCalculoIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vICMS = nota.NfTotais.NfoValorTotalIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vBCST = nota.NfTotais.NfoBaseCalculoIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vST = nota.NfTotais.NfoValorTotalIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vProd = nota.NfTotais.NfoValorTotalProdutosServicosIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vFrete = nota.NfTotais.NfoValorTotalFrete.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vSeg = nota.NfTotais.NfoValorTotalSeguro.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vDesc = nota.NfTotais.NfoValorTotalDesconto.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vII = nota.NfTotais.NfoValorTotalIimp.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vIPI = nota.NfTotais.NfoValorTotalIpi.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vPIS = nota.NfTotais.NfoValorTotalPis.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vCOFINS = nota.NfTotais.NfoValorTotalCofins.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vOutro = nota.NfTotais.NfoOutrasDespesas.ToString("F2", CultureInfo.InvariantCulture),
                                                                            vNF = nota.NfTotais.NfoValorTotalNf.ToString("F2", CultureInfo.InvariantCulture)
                                                                        },
                                                          ISSQNtot = new TNFeInfNFeTotalISSQNtot
                                                                         {
                                                                             vServ = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTotais.NfoValorTotalServicos.ToString("F2", CultureInfo.InvariantCulture)),
                                                                             vBC = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTotais.NfoBaseCalculoIss.ToString("F2", CultureInfo.InvariantCulture)),
                                                                             vISS = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTotais.NfoValorTotalIss.ToString("F2", CultureInfo.InvariantCulture)),
                                                                             vPIS = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTotais.NfoValorTotalPisServicos.ToString("F2", CultureInfo.InvariantCulture)),
                                                                             vCOFINS = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTotais.NfoValorTotalCofinsServicos.ToString("F2", CultureInfo.InvariantCulture))
                                                                         },
                                                          retTrib = new TNFeInfNFeTotalRetTrib
                                                                        {
                                                                            vRetPIS = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTotais.NfoValorTotalPis.ToString("F2", CultureInfo.InvariantCulture)),
                                                                            vRetCOFINS = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTotais.NfoValorTotalCofins.ToString("F2", CultureInfo.InvariantCulture))
                                                                        }
                                                      };


                        notaEnviar.infNFe.transp = new TNFeInfNFeTransp
                                                       {
                                                           modFrete = (TNFeInfNFeTranspModFrete) Enum.Parse(typeof (TNFeInfNFeTranspModFrete), "Item" + nota.NfTransporte.NftModalidade)
                                                       };

                        if (!string.IsNullOrWhiteSpace(nota.NfTransporte.NftCpfCnpj))
                        {

                            notaEnviar.infNFe.transp.transporta = new TNFeInfNFeTranspTransporta
                                                                      {
                                                                          ItemElementName = nota.NfTransporte.NftCpfCnpj.Length == 11 ? ItemChoiceType5.CPF : ItemChoiceType5.CNPJ,
                                                                          Item = nota.NfTransporte.NftCpfCnpj,
                                                                          xNome = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.NftRazao),
                                                                          IE = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.NftIe),
                                                                          xMun = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.NftMunicipio)
                                                                      };

                            if (!string.IsNullOrWhiteSpace(nota.NfTransporte.NftSiglaUf))
                            {
                                notaEnviar.infNFe.transp.transporta.UFSpecified = true;
                                notaEnviar.infNFe.transp.transporta.UF = FuncoesAuxiliares.Sigla2TUf(nota.NfTransporte.NftSiglaUf);
                            }
                            else
                            {
                                notaEnviar.infNFe.transp.transporta.UFSpecified = false;
                            }

                            if (!string.IsNullOrWhiteSpace(nota.NfTransporte.NftPlaca))
                            {
                                notaEnviar.infNFe.transp.ItemsElementName = new ItemsChoiceType5[1];
                                notaEnviar.infNFe.transp.ItemsElementName[0] = ItemsChoiceType5.veicTransp;
                                notaEnviar.infNFe.transp.Items = new object[1];
                                notaEnviar.infNFe.transp.Items[0] = new TVeiculo()
                                                                        {
                                                                            placa = nota.NfTransporte.NftPlaca,
                                                                            RNTC = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.NftRegistroAntt)
                                                                        };

                                if (!string.IsNullOrWhiteSpace(nota.NfTransporte.NftSiglaUfVeiculo))
                                {
                                    ((TVeiculo) notaEnviar.infNFe.transp.Items[0]).UF = FuncoesAuxiliares.Sigla2TUf(nota.NfTransporte.NftSiglaUfVeiculo);
                                }
                            }
                        }

                        notaEnviar.infNFe.transp.vol = new TNFeInfNFeTranspVol[1];
                        notaEnviar.infNFe.transp.vol[0] = new TNFeInfNFeTranspVol
                                                              {
                                                                  qVol = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.NftVolumes.ToString()),
                                                                  esp = "VOLUME",
                                                                  pesoL = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.NftPesoLiquido.ToString("F3", CultureInfo.InvariantCulture)),
                                                                  pesoB = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfTransporte.NftPesoBruto.ToString("F3", CultureInfo.InvariantCulture))

                                                              };


                        if (nota.NfCobranca != null)
                        {
                            notaEnviar.infNFe.cobr = new TNFeInfNFeCobr();
                            if (nota.NfCobranca.NfDuplicata != null && nota.NfCobranca.NfDuplicata.Count > 0)
                            {
                                notaEnviar.infNFe.cobr.dup = new TNFeInfNFeCobrDup[nota.NfCobranca.NfDuplicata.Count];
                                for (int i = 0; i < nota.NfCobranca.NfDuplicata.Count; i++)
                                {
                                    notaEnviar.infNFe.cobr.dup[i] = new TNFeInfNFeCobrDup()
                                                                        {
                                                                            dVenc = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCobranca.NfDuplicata[i].NfdVencimento.ToString("yyyy-MM-dd")),
                                                                            nDup = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCobranca.NfDuplicata[i].NfdNumero),
                                                                            vDup = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCobranca.NfDuplicata[i].NfdValor.ToString("F2", CultureInfo.InvariantCulture))
                                                                        };
                                }

                            }

                            if (nota.NfCobranca.NfFatura != null)
                            {
                                notaEnviar.infNFe.cobr.fat = new TNFeInfNFeCobrFat()
                                                                 {
                                                                     nFat = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCobranca.NfFatura.NffNumero),
                                                                     vDesc = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCobranca.NfFatura.NffDesconto.ToString("F2", CultureInfo.InvariantCulture)),
                                                                     vLiq = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCobranca.NfFatura.NffValorLiquido.ToString("F2", CultureInfo.InvariantCulture)),
                                                                     vOrig = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfCobranca.NfFatura.NffValorOriginal.ToString("F2", CultureInfo.InvariantCulture))
                                                                 };
                            }
                        }

                        notaEnviar.infNFe.infAdic = new TNFeInfNFeInfAdic()
                                                        {
                                                            infAdFisco = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfpObservacoesFisco),
                                                            infCpl = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfpObservacoes)
                                                        };

                        #endregion

                        #region Itens da NF

                        notaEnviar.infNFe.det = new TNFeInfNFeDet[nota.NfItem.Count];
                        for (int i = 0; i < nota.NfItem.Count; i++)
                        {
                            notaEnviar.infNFe.det[i] = new TNFeInfNFeDet
                                                           {
                                                               nItem = nota.NfItem[i].NfiNumeroItem.ToString(),
                                                               prod =
                                                                   new TNFeInfNFeDetProd
                                                                       {
                                                                           cProd = nota.NfItem[i].NfProduto.NfpCodigo,
                                                                           cEAN = nota.NfItem[i].NfProduto.NfpGtin,
                                                                           xProd = nota.NfItem[i].NfProduto.NfpDescricao,
                                                                           NCM = nota.NfItem[i].NfProduto.NfpNcm,
                                                                           EXTIPI = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfProduto.NfpExtipi),
                                                                           CFOP = (TCfop) Enum.Parse(typeof (TCfop), "Item" + nota.NfItem[i].NfiCfop),
                                                                           uCom = nota.NfItem[i].NfProduto.NfpUnidade,
                                                                           qCom = nota.NfItem[i].NfProduto.NfpQuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture),
                                                                           vUnCom = nota.NfItem[i].NfProduto.NfpValorUnitario.ToString("F10", CultureInfo.InvariantCulture),
                                                                           vProd = nota.NfItem[i].NfProduto.NfpValorTotalTributavel.ToString("F2", CultureInfo.InvariantCulture),
                                                                           cEANTrib = nota.NfItem[i].NfProduto.NfpGtimUnidadeTrinutacao,
                                                                           uTrib = nota.NfItem[i].NfProduto.NfpUnidadeTributacao,
                                                                           qTrib = nota.NfItem[i].NfProduto.NfpQuantidadeTributavel.ToString("F4", CultureInfo.InvariantCulture),
                                                                           vUnTrib = nota.NfItem[i].NfProduto.NfpValorUnitarioTrinutacao.ToString("F10", CultureInfo.InvariantCulture),
                                                                           vFrete = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfProduto.NfpValorFrete.ToString("F2", CultureInfo.InvariantCulture)),
                                                                           vSeg = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfProduto.NfpValorSeguro.ToString("F2", CultureInfo.InvariantCulture)),
                                                                           vDesc = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfProduto.NfpValorDesconto.ToString("F2", CultureInfo.InvariantCulture)),
                                                                           indTot = TNFeInfNFeDetProdIndTot.Item1
                                                                       },
                                                               infAdProd = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfiInformacoesAdd),
                                                               imposto = new TNFeInfNFeDetImposto()
                                                           };



                            int countImpostos = 0;
                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIcms != null)
                            {
                                countImpostos++;
                            }

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIimp != null)
                            {
                                countImpostos++;
                            }

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIpi != null)
                            {
                                countImpostos++;
                            }

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIss != null)
                            {
                                countImpostos++;
                            }
                            notaEnviar.infNFe.det[i].imposto.Items = new object[countImpostos];
                            countImpostos = 0;

                            #region ICMS

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIcms != null)
                            {
                                TNFeInfNFeDetImpostoICMS icms = new TNFeInfNFeDetImpostoICMS();


                                switch (nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcCst)
                                {
                                    case "00":
                                        TNFeInfNFeDetImpostoICMSICMS00 icms00 = new TNFeInfNFeDetImpostoICMSICMS00()
                                                                                    {
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMS00CST.Item00,
                                                                                        modBC =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS00ModBC)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS00ModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        pICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture)
                                                                                    };
                                        icms.Item = icms00;
                                        break;
                                    case "10":
                                        TNFeInfNFeDetImpostoICMSICMS10 icms10 = new TNFeInfNFeDetImpostoICMSICMS10()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMS10CST.Item10,
                                                                                        modBC =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS10ModBC)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS10ModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                        vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        modBCST =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS10ModBCST)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS10ModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                        pMVAST = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        pRedBCST =
                                                                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture)
                                                                                    };
                                        icms.Item = icms10;
                                        break;
                                    case "20":
                                        TNFeInfNFeDetImpostoICMSICMS20 icms20 = new TNFeInfNFeDetImpostoICMSICMS20()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMS20CST.Item20,
                                                                                        modBC =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS20ModBC)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS20ModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                        pRedBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture)

                                                                                    };
                                        ((TNFeInfNFeDetImpostoICMS) (notaEnviar.infNFe.det[i].imposto.Items[countImpostos])).Item = icms20;
                                        break;
                                    case "30":
                                        TNFeInfNFeDetImpostoICMSICMS30 icms30 = new TNFeInfNFeDetImpostoICMSICMS30()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMS30CST.Item30,
                                                                                        modBCST =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS30ModBCST)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS30ModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                        pMVAST = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        pRedBCST =
                                                                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture)
                                                                                    };
                                        icms.Item = icms30;
                                        break;

                                    case "40":
                                    case "41":
                                    case "50":
                                        TNFeInfNFeDetImpostoICMSICMS40 icms40 = new TNFeInfNFeDetImpostoICMSICMS40()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = (TNFeInfNFeDetImpostoICMSICMS40CST)
                                                                                              Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS40CST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcCst)
                                                                                    };
                                        ((TNFeInfNFeDetImpostoICMS) (notaEnviar.infNFe.det[i].imposto.Items[countImpostos])).Item = icms40;

                                        break;
                                    case "51":
                                        TNFeInfNFeDetImpostoICMSICMS51 icms51 = new TNFeInfNFeDetImpostoICMSICMS51()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMS51CST.Item51,
                                                                                        modBCSpecified = true,
                                                                                        modBC =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS51ModBC)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS51ModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                        vBC = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        pICMS = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        vICMS = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture)),

                                                                                        pRedBC = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBc.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                    };
                                        icms.Item = icms51;
                                        break;

                                    case "60":
                                        TNFeInfNFeDetImpostoICMSICMS60 icms60 = new TNFeInfNFeDetImpostoICMSICMS60()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = (TNFeInfNFeDetImpostoICMSICMS60CST)
                                                                                              Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS60CST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcCst),
                                                                                        vBCSTRet =
                                                                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        vICMSSTRet =
                                                                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture))
                                                                                    };
                                        icms.Item = icms60;

                                        break;

                                    case "70":
                                        TNFeInfNFeDetImpostoICMSICMS70 icms70 = new TNFeInfNFeDetImpostoICMSICMS70()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMS70CST.Item70,
                                                                                        modBC =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS70ModBC)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS70ModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                        vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        modBCST =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS70ModBCST)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS70ModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                        pMVAST = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        pRedBCST =
                                                                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pRedBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)
                                                                                    };
                                        icms.Item = icms70;
                                        break;

                                    case "90":
                                        TNFeInfNFeDetImpostoICMSICMS90 icms90 = new TNFeInfNFeDetImpostoICMSICMS90()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMS90CST.Item90,
                                                                                        modBC =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS90ModBC)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS90ModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                        vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        modBCST =
                                                                                            (TNFeInfNFeDetImpostoICMSICMS90ModBCST)
                                                                                            Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMS90ModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                        pMVAST = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        pRedBCST =
                                                                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                        vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        pRedBC =
                                                                                            FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture))
                                                                                    };
                                        icms.Item = icms90;
                                        break;

                                    case "10a":
                                    case "90a":
                                        TNFeInfNFeDetImpostoICMSICMSPart icmsPart = new TNFeInfNFeDetImpostoICMSICMSPart()
                                                                                        {
                                                                                            orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                            CST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcCst == "10a" ? TNFeInfNFeDetImpostoICMSICMSPartCST.Item10 : TNFeInfNFeDetImpostoICMSICMSPartCST.Item90,
                                                                                            modBC =
                                                                                                (TNFeInfNFeDetImpostoICMSICMSPartModBC)
                                                                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSPartModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                            vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                            pICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                            vICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                                            modBCST =
                                                                                                (TNFeInfNFeDetImpostoICMSICMSPartModBCST)
                                                                                                Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSPartModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                            pMVAST = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                            pRedBCST =
                                                                                                FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                            vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                            pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                            vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                            pRedBC =
                                                                                                FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2", CultureInfo.InvariantCulture)),
                                                                                            UFST = FuncoesAuxiliares.Sigla2TUf(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcSiglaUfDevidoIcms),
                                                                                            pBCOp = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualBcOperacaoPropria.ToString("F2", CultureInfo.InvariantCulture)
                                                                                        };
                                        icms.Item = icmsPart;
                                        break;
                                    case "41a":
                                        TNFeInfNFeDetImpostoICMSICMSST icmsSt = new TNFeInfNFeDetImpostoICMSICMSST()
                                                                                    {
                                                                                        orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                        CST = TNFeInfNFeDetImpostoICMSICMSSTCST.Item41,
                                                                                        vBCSTRet = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMSSTRet = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsStRetidoRemetente.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vBCSTDest = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture),
                                                                                        vICMSSTDest = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsStRetidoDestinatario.ToString("F2", CultureInfo.InvariantCulture)
                                                                                    };
                                        icms.Item = icmsSt;
                                        break;

                                    case "SN":
                                        switch (nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcCsoSimples)
                                        {
                                            case 101:
                                                TNFeInfNFeDetImpostoICMSICMSSN101 icms101 = new TNFeInfNFeDetImpostoICMSICMSSN101()
                                                                                                {
                                                                                                    orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                                    CSOSN = TNFeInfNFeDetImpostoICMSICMSSN101CSOSN.Item101,
                                                                                                    pCredSN = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    vCredICMSSN = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture)
                                                                                                };

                                                icms.Item = icms101;
                                                break;

                                            case 102:
                                            case 103:
                                            case 300:
                                            case 400:
                                                TNFeInfNFeDetImpostoICMSICMSSN102 icms102 = new TNFeInfNFeDetImpostoICMSICMSSN102()
                                                                                                {
                                                                                                    orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                                    CSOSN =
                                                                                                        (TNFeInfNFeDetImpostoICMSICMSSN102CSOSN)
                                                                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN102CSOSN), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcCsoSimples)
                                                                                                };

                                                icms.Item = icms102;
                                                break;

                                            case 201:
                                                TNFeInfNFeDetImpostoICMSICMSSN201 icms201 = new TNFeInfNFeDetImpostoICMSICMSSN201()
                                                                                                {
                                                                                                    orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                                    CSOSN = TNFeInfNFeDetImpostoICMSICMSSN201CSOSN.Item201,
                                                                                                    modBCST =
                                                                                                        (TNFeInfNFeDetImpostoICMSICMSSN201ModBCST)
                                                                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN201ModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                                    pMVAST =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2",
                                                                                                                                                                                                                         CultureInfo.InvariantCulture)),
                                                                                                    pRedBCST =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2",
                                                                                                                                                                                                                               CultureInfo.
                                                                                                                                                                                                                                   InvariantCulture)),
                                                                                                    vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    pCredSN = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    vCredICMSSN = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture)
                                                                                                };

                                                icms.Item = icms201;
                                                break;
                                            case 202:
                                            case 203:
                                                TNFeInfNFeDetImpostoICMSICMSSN202 icms202 = new TNFeInfNFeDetImpostoICMSICMSSN202()
                                                                                                {
                                                                                                    orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                                    CSOSN =
                                                                                                        (TNFeInfNFeDetImpostoICMSICMSSN202CSOSN)
                                                                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN202CSOSN), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcCsoSimples),
                                                                                                    modBCST =
                                                                                                        (TNFeInfNFeDetImpostoICMSICMSSN202ModBCST)
                                                                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN202ModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                                    pMVAST =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2",
                                                                                                                                                                                                                         CultureInfo.InvariantCulture)),
                                                                                                    pRedBCST =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2",
                                                                                                                                                                                                                               CultureInfo.
                                                                                                                                                                                                                                   InvariantCulture)),
                                                                                                    vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture)
                                                                                                };

                                                icms.Item = icms202;
                                                break;
                                            case 500:
                                                TNFeInfNFeDetImpostoICMSICMSSN500 icms500 = new TNFeInfNFeDetImpostoICMSICMSSN500()
                                                                                                {
                                                                                                    orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                                    CSOSN = TNFeInfNFeDetImpostoICMSICMSSN500CSOSN.Item500,
                                                                                                    vBCSTRet =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcStRetidoRemetente.ToString("F2",
                                                                                                                                                                                                                                  CultureInfo.
                                                                                                                                                                                                                                      InvariantCulture)),
                                                                                                    vICMSSTRet =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsStRetidoRemetente.ToString("F2",
                                                                                                                                                                                                                                    CultureInfo.
                                                                                                                                                                                                                                        InvariantCulture))
                                                                                                };

                                                icms.Item = icms500;
                                                break;
                                            case 900:
                                                TNFeInfNFeDetImpostoICMSICMSSN900 icms900 = new TNFeInfNFeDetImpostoICMSICMSSN900()
                                                                                                {
                                                                                                    orig = (Torig) Enum.Parse(typeof (Torig), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcOrigem),
                                                                                                    CSOSN = TNFeInfNFeDetImpostoICMSICMSSN900CSOSN.Item900,
                                                                                                    modBCST =
                                                                                                        (TNFeInfNFeDetImpostoICMSICMSSN900ModBCST)
                                                                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSSN900ModBCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcSt),
                                                                                                    pMVAST =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualMvaSt.ToString("F2",
                                                                                                                                                                                                                         CultureInfo.InvariantCulture)),
                                                                                                    pRedBCST =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2",
                                                                                                                                                                                                                               CultureInfo.
                                                                                                                                                                                                                                   InvariantCulture)),
                                                                                                    vBCST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBcSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    pICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    vICMSST = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcmsSt.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    pCredSN = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquotaCreditoSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    vCredICMSSN = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorCreditoIcmsSimples.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    modBC =
                                                                                                        (TNFeInfNFeDetImpostoICMSICMSSN900ModBC)
                                                                                                        Enum.Parse(typeof (TNFeInfNFeDetImpostoICMSICMSPartModBC), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcModalidadeBcIcms),
                                                                                                    vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    pICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    vICMS = nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcValorIcms.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                    pRedBC =
                                                                                                        FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIcms.NtcPercentualReducaoBcSt.ToString("F2",
                                                                                                                                                                                                                               CultureInfo.
                                                                                                                                                                                                                                   InvariantCulture))

                                                                                                };

                                                icms.Item = icms900;
                                                break;

                                        }
                                        break;

                                }

                                notaEnviar.infNFe.det[i].imposto.Items[countImpostos] = icms;
                                countImpostos++;
                            }

                            #endregion

                            #region IPI

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIpi != null)
                            {
                                TNFeInfNFeDetImpostoIPI ipi = new TNFeInfNFeDetImpostoIPI
                                                                  {
                                                                      clEnq = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiClasseEnquadramentoCigarrosBebidas),
                                                                      CNPJProd = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiCnpjProdutor),
                                                                      cSelo = FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiCodigoSeloControle),
                                                                      qSelo =
                                                                          FuncoesAuxiliares.ValidaCampoOpcional(nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiQuantidadeSeloControle.HasValue
                                                                                                                    ? nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiQuantidadeSeloControle.Value.ToString("D")
                                                                                                                    : ""),
                                                                      cEnq = nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiClasseEnquadramento
                                                                  };
                                switch (nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiCst)
                                {
                                    case "00":
                                    case "49":
                                    case "50":
                                    case "99":
                                        TNFeInfNFeDetImpostoIPIIPITrib ipiTrib = new TNFeInfNFeDetImpostoIPIIPITrib
                                                                                     {
                                                                                         CST = TNFeInfNFeDetImpostoIPIIPITribCST.Item49,
                                                                                         vIPI = nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiValorIpi.ToString("F2", CultureInfo.InvariantCulture),
                                                                                         ItemsElementName = new ItemsChoiceType[2],
                                                                                         Items = new string[2]
                                                                                     };

                                        //Tributacao por valor
                                        if (nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiModalidadeTributacao == 0)
                                        {
                                            ipiTrib.ItemsElementName[0] = ItemsChoiceType.vBC;
                                            ipiTrib.ItemsElementName[1] = ItemsChoiceType.pIPI;
                                            ipiTrib.Items[0] = nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiValorBc.ToString("F2", CultureInfo.InvariantCulture);
                                            ipiTrib.Items[1] = nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiAliquota.ToString("F2", CultureInfo.InvariantCulture);

                                        }
                                        else
                                        {
                                            ipiTrib.ItemsElementName[0] = ItemsChoiceType.qUnid;
                                            ipiTrib.ItemsElementName[1] = ItemsChoiceType.vUnid;
                                            ipiTrib.Items[0] = nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiQuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture);
                                            ipiTrib.Items[1] = nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiAliquota.ToString("F4", CultureInfo.InvariantCulture);
                                        }
                                        ipi.Item = ipiTrib;
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
                                        TNFeInfNFeDetImpostoIPIIPINT ipiNT = new TNFeInfNFeDetImpostoIPIIPINT()
                                                                                 {
                                                                                     CST = (TNFeInfNFeDetImpostoIPIIPINTCST) Enum.Parse(typeof (TNFeInfNFeDetImpostoIPIIPINTCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIpi.NtiCst)
                                                                                 };

                                        ipi.Item = ipiNT;
                                        break;


                                }

                                notaEnviar.infNFe.det[i].imposto.Items[countImpostos] = ipi;
                                countImpostos++;
                            }

                            #endregion

                            #region II

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIimp != null)
                            {
                                TNFeInfNFeDetImpostoII ii = new TNFeInfNFeDetImpostoII()
                                                                {
                                                                    vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIimp.NtmValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                    vDespAdu = nota.NfItem[i].NfItemTributo.NfItemTributoIimp.NtmValorDespesasAduaneiras.ToString("F2", CultureInfo.InvariantCulture),
                                                                    vII = nota.NfItem[i].NfItemTributo.NfItemTributoIimp.NtmValorIimp.ToString("F2", CultureInfo.InvariantCulture),
                                                                    vIOF = nota.NfItem[i].NfItemTributo.NfItemTributoIimp.NtmValorIof.ToString("F2", CultureInfo.InvariantCulture)
                                                                };

                                notaEnviar.infNFe.det[i].imposto.Items[countImpostos] = ii;
                                countImpostos++;
                            }

                            #endregion

                            #region ISS

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoIss != null)
                            {
                                TNFeInfNFeDetImpostoISSQN iss = new TNFeInfNFeDetImpostoISSQN()
                                                                    {
                                                                        vBC = nota.NfItem[i].NfItemTributo.NfItemTributoIss.NtsBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                        vAliq = nota.NfItem[i].NfItemTributo.NfItemTributoIss.NtsAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                        vISSQN = nota.NfItem[i].NfItemTributo.NfItemTributoIss.NtsValorIss.ToString("F2", CultureInfo.InvariantCulture),
                                                                        cMunFG = nota.NfItem[i].NfItemTributo.NfItemTributoIss.NtsCodMunicipioFatoGerador.ToString(),
                                                                        cListServ = (TCListServ) Enum.Parse(typeof (TCListServ), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoIss.NtsCodigoServico.ToString()),
                                                                        cSitTrib = TNFeInfNFeDetImpostoISSQNCSitTrib.N

                                                                    };

                                notaEnviar.infNFe.det[i].imposto.Items[countImpostos] = iss;
                                countImpostos++;
                            }

                            #endregion

                            #region Pis

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoPis != null)
                            {
                                notaEnviar.infNFe.det[i].imposto.PIS = new TNFeInfNFeDetImpostoPIS();

                                switch (nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpCst)
                                {
                                    case "01":
                                    case "02":
                                        TNFeInfNFeDetImpostoPISPISAliq pisAliq = new TNFeInfNFeDetImpostoPISPISAliq()
                                                                                     {
                                                                                         CST = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpCst == "01" ? TNFeInfNFeDetImpostoPISPISAliqCST.Item01 : TNFeInfNFeDetImpostoPISPISAliqCST.Item02,
                                                                                         vBC = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                         pPIS = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                         vPIS = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpValorPis.ToString("F2", CultureInfo.InvariantCulture)
                                                                                     };

                                        notaEnviar.infNFe.det[i].imposto.PIS.Item = pisAliq;
                                        break;

                                    case "03":
                                        TNFeInfNFeDetImpostoPISPISQtde pisQtd = new TNFeInfNFeDetImpostoPISPISQtde()
                                                                                    {
                                                                                        CST = TNFeInfNFeDetImpostoPISPISQtdeCST.Item03,
                                                                                        qBCProd = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpQuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture),
                                                                                        vAliqProd = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpAliquota.ToString("F4", CultureInfo.InvariantCulture),
                                                                                        vPIS = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpValorPis.ToString("F2", CultureInfo.InvariantCulture)
                                                                                    };

                                        notaEnviar.infNFe.det[i].imposto.PIS.Item = pisQtd;
                                        break;

                                    case "04":
                                    case "06":
                                    case "07":
                                    case "08":
                                    case "09":
                                        TNFeInfNFeDetImpostoPISPISNT pisNt = new TNFeInfNFeDetImpostoPISPISNT()
                                                                                 {
                                                                                     CST = (TNFeInfNFeDetImpostoPISPISNTCST) Enum.Parse(typeof (TNFeInfNFeDetImpostoPISPISNTCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpCst)
                                                                                 };
                                        notaEnviar.infNFe.det[i].imposto.PIS.Item = pisNt;
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
                                                                                        CST = (TNFeInfNFeDetImpostoPISPISOutrCST) Enum.Parse(typeof (TNFeInfNFeDetImpostoPISPISOutrCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpCst),
                                                                                        Items = new string[2],
                                                                                        ItemsElementName = new ItemsChoiceType1[2],
                                                                                        vPIS = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpValorPis.ToString("F2", CultureInfo.InvariantCulture)
                                                                                    };

                                        //Tributacao por valor
                                        if (nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpModalidadeTributacao == 0)
                                        {
                                            pisOut.ItemsElementName[0] = ItemsChoiceType1.vBC;
                                            pisOut.ItemsElementName[1] = ItemsChoiceType1.pPIS;
                                            pisOut.Items[0] = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpValorBc.ToString("F2", CultureInfo.InvariantCulture);
                                            pisOut.Items[1] = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpAliquota.ToString("F2", CultureInfo.InvariantCulture);

                                        }
                                        else
                                        {
                                            pisOut.ItemsElementName[0] = ItemsChoiceType1.qBCProd;
                                            pisOut.ItemsElementName[1] = ItemsChoiceType1.vAliqProd;
                                            pisOut.Items[0] = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpQuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture);
                                            pisOut.Items[1] = nota.NfItem[i].NfItemTributo.NfItemTributoPis.NtpAliquota.ToString("F4", CultureInfo.InvariantCulture);
                                        }

                                        notaEnviar.infNFe.det[i].imposto.PIS.Item = pisOut;
                                        break;
                                }


                            }

                            #endregion

                            #region Confins

                            if (nota.NfItem[i].NfItemTributo.NfItemTributoCofins != null)
                            {
                                notaEnviar.infNFe.det[i].imposto.COFINS = new TNFeInfNFeDetImpostoCOFINS();

                                switch (nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoCst)
                                {
                                    case "01":
                                    case "02":
                                        TNFeInfNFeDetImpostoCOFINSCOFINSAliq cofinsAliq = new TNFeInfNFeDetImpostoCOFINSCOFINSAliq()
                                                                                              {
                                                                                                  CST =
                                                                                                      nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoCst == "01"
                                                                                                          ? TNFeInfNFeDetImpostoCOFINSCOFINSAliqCST.Item01
                                                                                                          : TNFeInfNFeDetImpostoCOFINSCOFINSAliqCST.Item02,
                                                                                                  vBC = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoValorBc.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                  pCOFINS = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoAliquota.ToString("F2", CultureInfo.InvariantCulture),
                                                                                                  vCOFINS = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoValorCofins.ToString("F2", CultureInfo.InvariantCulture)
                                                                                              };

                                        notaEnviar.infNFe.det[i].imposto.COFINS.Item = cofinsAliq;
                                        break;

                                    case "03":
                                        TNFeInfNFeDetImpostoCOFINSCOFINSQtde cofinsQtd = new TNFeInfNFeDetImpostoCOFINSCOFINSQtde()
                                                                                             {
                                                                                                 CST = TNFeInfNFeDetImpostoCOFINSCOFINSQtdeCST.Item03,
                                                                                                 qBCProd = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoQuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture),
                                                                                                 vAliqProd = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoAliquota.ToString("F4", CultureInfo.InvariantCulture),
                                                                                                 vCOFINS = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoValorCofins.ToString("F2", CultureInfo.InvariantCulture)
                                                                                             };

                                        notaEnviar.infNFe.det[i].imposto.COFINS.Item = cofinsQtd;
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
                                                                                                  Enum.Parse(typeof (TNFeInfNFeDetImpostoCOFINSCOFINSNTCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoCst)
                                                                                          };
                                        notaEnviar.infNFe.det[i].imposto.COFINS.Item = cofinsNt;
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
                                                                                                     Enum.Parse(typeof (TNFeInfNFeDetImpostoCOFINSCOFINSOutrCST), "Item" + nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoCst),
                                                                                                 Items = new string[2],
                                                                                                 ItemsElementName = new ItemsChoiceType3[2],
                                                                                                 vCOFINS = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoValorCofins.ToString("F2", CultureInfo.InvariantCulture)
                                                                                             };

                                        //Tributacao por valor
                                        if (nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoModalidadeTributacao == 0)
                                        {
                                            cofinsOut.ItemsElementName[0] = ItemsChoiceType3.vBC;
                                            cofinsOut.ItemsElementName[1] = ItemsChoiceType3.pCOFINS;
                                            cofinsOut.Items[0] = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoValorBc.ToString("F2", CultureInfo.InvariantCulture);
                                            cofinsOut.Items[1] = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoAliquota.ToString("F2", CultureInfo.InvariantCulture);

                                        }
                                        else
                                        {
                                            cofinsOut.ItemsElementName[0] = ItemsChoiceType3.qBCProd;
                                            cofinsOut.ItemsElementName[1] = ItemsChoiceType3.vAliqProd;
                                            cofinsOut.Items[0] = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoQuantidadeVendida.ToString("F4", CultureInfo.InvariantCulture);
                                            cofinsOut.Items[1] = nota.NfItem[i].NfItemTributo.NfItemTributoCofins.NtoAliquota.ToString("F4", CultureInfo.InvariantCulture);
                                        }

                                        notaEnviar.infNFe.det[i].imposto.COFINS.Item = cofinsOut;
                                        break;
                                }


                            }

                            #endregion


                        }

                        #endregion

                        notaEnviar.infNFe.Id = "NFe" + chaveCompleta;
                        notasEnviar.Add(notaEnviar);
                    }
                    catch (Exception a)
                    {
                        errosConversao += "NF: " + numeroNota + " - " + a.Message;
                        continue;
                    }
                }

                if (errosConversao.Length > 0)
                {
                    MessageBox.Show(null, "Ocorreram os seguintes erros de conversão das notas: " + errosConversao, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string toRet = "";
                if (notasEnviar.Count > 0)
                {
                    return NFeOperacoes.EnviaNfe(notasEnviar, ufEmitente, Ambiente, serialCertificado, conn, cnpjTransmissor);
                }
                else
                {
                    return new List<LoteEnviar>();
                }


               


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar a NFe.\r\n" + e.Message, e);
            }
        }

        public static List<LoteEnviar> EnviaNfe(List<TNFe> notasEnviar, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor)
        {

            List<LoteEnviar> lotes = new List<LoteEnviar>();
            X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);

            for (int jLote = 0; jLote < notasEnviar.Count / Convert.ToDouble(10); jLote++)
            {
                LoteEnviar loteAtual = new LoteEnviar();
                IWTPostgreNpgsqlCommand command = null;

                try
                {

                    command = conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();

                    //Buscar numero do lote
                    command.CommandText =
                        "SELECT  " +
                        "  COALESCE(MAX(public.nfe_completo_lote.ncl_numero_lote),0) " +
                        "FROM " +
                        "  public.nfe_completo_lote ";
                    loteAtual.NumeroLoteInterno = (Convert.ToInt32(command.ExecuteScalar())) + 1;
                    //Assinar as NFes que serão enviadas

                    XmlSerializer serializer = new XmlSerializer(typeof (TNFe));
                    Utf8StringWriter builder = new Utf8StringWriter();
                    XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false, Indent = true};
                    XmlWriter xmlWriter;

                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");


                    //Insere o lote no banco de dados
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.nfe_completo_lote " +
                        "( " +
                        "  ncl_numero_lote, " +
                        "  ncl_data_envio, " +
                        "  ncl_situacao, " +
                        "  ncl_cnpj_transmissor " +
                        ")  " +
                        "VALUES ( " +
                        "  :ncl_numero_lote, " +
                        "  :ncl_data_envio, " +
                        "  :ncl_situacao, " +
                        "  :ncl_cnpj_transmissor " +
                        ") RETURNING id_nfe_completo_lote; ";
                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_numero_lote", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = loteAtual.NumeroLoteInterno;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_data_envio", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = DateTime.Now;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_situacao", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = 0;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_cnpj_transmissor", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = cnpjTransmissor;

                    loteAtual.idNfCompletoLote = Convert.ToInt32(command.ExecuteScalar());
       

                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.nfe_completo_nota " +
                        "( " +
                        "  id_nfe_completo_lote, " +
                        "  nfn_numero, " +
                        "  nfn_serie, " +
                        "  nfn_xml, " +
                        "  nfn_situacao, " +
                        "  nfn_data_situacao, " +
                        "  nfn_chave, " +
                        "  nfn_data_emissao, " +
                        "  nfn_cnpj_emitente" +
                        ")  " +
                        "VALUES ( " +
                        "  :id_nfe_completo_lote, " +
                        "  :nfn_numero, " +
                        "  :nfn_serie, " +
                        "  :nfn_xml, " +
                        "  :nfn_situacao, " +
                        "  :nfn_data_situacao, " +
                        "  :nfn_chave, " +
                        "  :nfn_data_emissao, " +
                        "  :nfn_cnpj_emitente" +
                        "); ";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_lote", NpgsqlDbType.Integer));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_numero", NpgsqlDbType.Integer));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_serie", NpgsqlDbType.Integer));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_xml", NpgsqlDbType.Text));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_situacao", NpgsqlDbType.Smallint));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_situacao", NpgsqlDbType.Timestamp));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_chave", NpgsqlDbType.Varchar));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_emissao", NpgsqlDbType.Date));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_cnpj_emitente", NpgsqlDbType.Varchar));

                    for (int i = (jLote*10); i < notasEnviar.Count && i< (((jLote+1)*10)); i++)
                    {
                        NotaEnviar notaAtual = new NotaEnviar()
                                                   {
                                                       Nota = notasEnviar[i]
                                                   };


                        builder = new Utf8StringWriter();
                        xmlWriter = XmlWriter.Create(builder, settings);

                        serializer.Serialize(xmlWriter, notasEnviar[i], namespaces);

                        XmlDocument xmlNfe = new XmlDocument();
                        xmlNfe.LoadXml(builder.ToString());

                        CertificadoOperacoes.AssinaDocumento(certificado, ref xmlNfe, "#" + notaAtual.Nota.infNFe.Id);
                        notaAtual.Xml = xmlNfe;

                        command.Parameters["id_nfe_completo_lote"].Value = loteAtual.idNfCompletoLote;
                        command.Parameters["nfn_numero"].Value = int.Parse(notaAtual.Nota.infNFe.ide.nNF);
                        command.Parameters["nfn_serie"].Value = int.Parse(notaAtual.Nota.infNFe.ide.serie);
                        command.Parameters["nfn_xml"].Value = builder.ToString();
                        command.Parameters["nfn_situacao"].Value = 0;
                        command.Parameters["nfn_data_situacao"].Value = DateTime.Now;
                        command.Parameters["nfn_chave"].Value = notaAtual.Nota.infNFe.Id.Substring(3);
                        command.Parameters["nfn_data_emissao"].Value = DateTime.Parse(notaAtual.Nota.infNFe.ide.dEmi, CultureInfo.InvariantCulture);
                        command.Parameters["nfn_cnpj_emitente"].Value = notaAtual.Nota.infNFe.emit.Item;

                        command.ExecuteNonQuery();

                        loteAtual.Notas.Add(notaAtual);
                    }




                    TEnviNFe objetoEnvio = new TEnviNFe()
                                               {
                                                   idLote = loteAtual.NumeroLoteInterno.ToString(),
                                                   versao = versaoLayout
                                               };


                    serializer = new XmlSerializer(typeof (TEnviNFe));
                    builder = new Utf8StringWriter();
                    settings = new XmlWriterSettings {OmitXmlDeclaration = false, Indent = true, ConformanceLevel = ConformanceLevel.Auto};
                    xmlWriter = XmlWriter.Create(builder, settings);

                    namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                    serializer.Serialize(xmlWriter, objetoEnvio, namespaces);

                    XmlDocument xmlConsulta = new XmlDocument();
                    xmlConsulta.LoadXml(builder.ToString());



                    foreach (NotaEnviar notaEnviar in loteAtual.Notas)
                    {
                        xmlConsulta.DocumentElement.AppendChild(xmlConsulta.ImportNode(notaEnviar.Xml.DocumentElement, true));
                    }

                    string _UrlWebservice = EnderecosWebservices.getEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeRecepcao);

                    NfeRecepcao2 client = new NfeRecepcao2
                                              {
                                                  Timeout = timeoutPadrao,
                                                  Url = _UrlWebservice,
                                                  nfeCabecMsgValue = new BibliotecaWebservices.br.gov.pr.fazenda.nfe23.nfeCabecMsg()
                                                                         {
                                                                             versaoDados = versaoLayout,
                                                                             cUF = Convert.ToInt32(ufEmitente).ToString()
                                                                         }

                                              };


                    client.ClientCertificates.Add(certificado);

                    XmlNode resultadoProcessamento = client.nfeRecepcaoLote2(xmlConsulta);

                    serializer = new XmlSerializer(typeof (TRetEnviNFe));
                    TRetEnviNFe resultatoCompleto = (TRetEnviNFe) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                    if (resultatoCompleto.cStat == "103")
                    {
                        //Lote recebido com sucesso
                        command.CommandText =
                            "UPDATE  " +
                            "  public.nfe_completo_lote   " +
                            "SET  " +
                            "  ncl_recibo = :ncl_recibo, " +
                            "  ncl_resultado_obs = :ncl_resultado_obs " +
                            "WHERE  " +
                            "  id_nfe_completo_lote = :id_nfe_completo_lote " +
                            "; ";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_lote", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = loteAtual.idNfCompletoLote;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_recibo", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = resultatoCompleto.infRec.nRec;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_resultado_obs", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = resultatoCompleto.xMotivo;

                        command.ExecuteNonQuery();

                        command.Transaction.Commit();

                        loteAtual.Recibo = resultatoCompleto.infRec.nRec;
                        loteAtual.Observacao = "Lote processado com sucesso";
                        loteAtual.LoteEnviado = true;
                    }
                    else
                    {
                        loteAtual.Recibo = null;
                        loteAtual.Observacao = resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo;
                        loteAtual.LoteEnviado = false;

                        command.Transaction.Rollback();

                    }

                    lotes.Add(loteAtual);

                }
                catch (Exception e)
                {
                    if (command != null && command.Transaction != null)
                    {
                        command.Transaction.Rollback();
                    }
                    throw new Exception("Erro ao enviar a NFe.\r\n" + e.Message, e);
                }
            }

            return lotes;
        }

        public static RetornoProcessamentoLote ResultadoProcessamentoNFe(string Recibo, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, out string retornoDetalhado, out List<RetornoNFe> notasRejeitadas,out List<RetornoNFe> notasDenegadas)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                notasRejeitadas = new List<RetornoNFe>();
                notasDenegadas = new List<RetornoNFe>();

                TConsReciNFe objConsulta = new TConsReciNFe
                                               {
                                                   versao = versaoLayout,
                                                   nRec = Recibo,
                                                   tpAmb = Ambiente

                                               };


                XmlSerializer serializer = new XmlSerializer(typeof (TConsReciNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


                string _UrlWebservice = EnderecosWebservices.getEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeRetRecepcao);

                NfeRetRecepcao2 client = new NfeRetRecepcao2
                                             {
                                                 Timeout = timeoutPadrao,
                                                 Url = _UrlWebservice,
                                                 nfeCabecMsgValue = new BibliotecaWebservices.br.gov.pr.fazenda.nfe24.nfeCabecMsg()
                                                                        {
                                                                            versaoDados = versaoLayout,
                                                                            cUF = Convert.ToInt32(ufEmitente).ToString()
                                                                        }

                                             };

                client.ClientCertificates.Add(certificado);

                XmlNode resultadoProcessamento = client.nfeRetRecepcao2(xmlConsulta);

                serializer = new XmlSerializer(typeof (TRetConsReciNFe));
                TRetConsReciNFe resultatoCompleto = (TRetConsReciNFe) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));


                switch (resultatoCompleto.cStat)
                {
                    case "104":
                        //Lote processado
                        retornoDetalhado = "Lote Processado";
                        command = conn.CreateCommand();
                        IWTPostgreNpgsqlCommand command2 = conn.CreateCommand();
                        command.Transaction = command.Connection.BeginTransaction();
                        command2.Transaction = command.Transaction;

                        command.CommandText =
                            "SELECT  " +
                            "  public.nfe_completo_lote.id_nfe_completo_lote, " +
                            "  public.nfe_completo_lote.ncl_situacao " +
                            "FROM " +
                            "  public.nfe_completo_lote " +
                            "WHERE " +
                            "  public.nfe_completo_lote.ncl_recibo = :ncl_recibo";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_recibo", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = Recibo;
                        NpgsqlDataReader read = command.ExecuteReader();
                        if (!read.HasRows)
                        {
                            throw new Exception("Não foi encontrada na base de dados do sistema um recibo com o número " + Recibo);
                        }

                        read.Read();
                        if (read["ncl_situacao"].ToString() != "0")
                        {
                            throw new Exception("O Recibo " + Recibo + " não está no status correto");
                        }

                        int idNfeCompletoLote = Convert.ToInt32(read["id_nfe_completo_lote"]);
                        read.Close();

                        foreach (TProtNFe protNFe in resultatoCompleto.protNFe)
                        {
                            command.CommandText =
                                "SELECT  " +
                                "  public.nfe_completo_nota.id_nfe_completo_nota, " +
                                "  public.nfe_completo_nota.nfn_numero, " +
                                "  public.nfe_completo_nota.nfn_serie, " +
                                "  public.nfe_completo_nota.nfn_xml, " +
                                "  public.nfe_completo_nota.nfn_situacao " +
                                "FROM " +
                                "  public.nfe_completo_nota " +
                                "WHERE " +
                                "  public.nfe_completo_nota.nfn_chave = :nfn_chave ";
                            command.Parameters.Clear();

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_chave", NpgsqlDbType.Varchar));
                            command.Parameters[command.Parameters.Count - 1].Value = protNFe.infProt.chNFe;

                            read = command.ExecuteReader();
                            if (!read.HasRows)
                            {
                                throw new Exception("Não foi encontrada nota fiscal com a chave " + protNFe.infProt.chNFe);
                            }

                            read.Read();
                            if (read["nfn_situacao"].ToString() != "0")
                            {
                                throw new Exception("A nota fiscal com a chave " + protNFe.infProt.chNFe + " não está no status correto");
                            }

                            serializer = new XmlSerializer(typeof (TNFe));
                            XmlDocument docNF = new XmlDocument();
                            docNF.LoadXml(read["nfn_xml"].ToString());
                            TNFe nota = (TNFe) serializer.Deserialize(new XmlNodeReader(docNF));


                            switch (protNFe.infProt.cStat)
                            {
                                case "100":
                                    //Nota Aprovada
                                    TNfeProc proc = new TNfeProc()
                                                        {
                                                            NFe = nota,
                                                            protNFe = protNFe,
                                                            versao = versaoLayout
                                                        };

                                    serializer = new XmlSerializer(typeof (TNfeProc));

                                    builder = new Utf8StringWriter();
                                    settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                                    xmlWriter = XmlWriter.Create(builder, settings);

                                    namespaces = new XmlSerializerNamespaces();
                                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                                    serializer.Serialize(xmlWriter, proc, namespaces);

                                    command2.CommandText =
                                        "UPDATE  " +
                                        "  public.nfe_completo_nota   " +
                                        "SET  " +
                                        "  nfn_xml = :nfn_xml, " +
                                        "  nfn_situacao = :nfn_situacao, " +
                                        "  nfn_data_situacao = :nfn_data_situacao, " +
                                        "  nfn_situacao_observacao = :nfn_situacao_observacao " +
                                        "WHERE " +
                                        "  id_nfe_completo_nota = :id_nfe_completo_nota ";

                                    command2.Parameters.Clear();

                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_nota", NpgsqlDbType.Integer));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = read["id_nfe_completo_nota"];
                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_xml", NpgsqlDbType.Text));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = builder.ToString();
                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_situacao", NpgsqlDbType.Smallint));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = 1;
                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_situacao", NpgsqlDbType.Timestamp));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = DateTime.Now;
                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_situacao_observacao", NpgsqlDbType.Varchar));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = protNFe.infProt.cStat + " - " + protNFe.infProt.xMotivo;

                                    command2.ExecuteNonQuery();

                                    break;
                                case "110":
                                    //Nota denegada
                                    command2.CommandText =
                                        "UPDATE  " +
                                        "  public.nfe_completo_nota   " +
                                        "SET  " +
                                        "  nfn_situacao = :nfn_situacao, " +
                                        "  nfn_data_situacao = :nfn_data_situacao, " +
                                        "  nfn_situacao_observacao = :nfn_situacao_observacao " +
                                        "WHERE " +
                                        "  id_nfe_completo_nota = :id_nfe_completo_nota ";

                                    command2.Parameters.Clear();

                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_nota", NpgsqlDbType.Integer));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = read["id_nfe_completo_nota"];
                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_situacao", NpgsqlDbType.Smallint));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = 2;
                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_data_situacao", NpgsqlDbType.Timestamp));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = DateTime.Now;
                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_situacao_observacao", NpgsqlDbType.Varchar));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = protNFe.infProt.cStat + " - " + protNFe.infProt.xMotivo;

                                    command2.ExecuteNonQuery();

                                    notasDenegadas.Add(new RetornoNFe()
                                                           {
                                                               codigoRetorno = "110",
                                                               NotaFiscal = nota,
                                                               observacaoRetorno = protNFe.infProt.xMotivo,
                                                               situacao = SituacaoNFe.Denegada
                                                           });

                                    break;
                                default:
                                    //Nota rejeitada
                                    command2.CommandText =
                                        "DELETE FROM   " +
                                        "  public.nfe_completo_nota   " +
                                        "WHERE " +
                                        "  id_nfe_completo_nota = :id_nfe_completo_nota ";

                                    command2.Parameters.Clear();

                                    command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_nota", NpgsqlDbType.Integer));
                                    command2.Parameters[command2.Parameters.Count - 1].Value = read["id_nfe_completo_nota"];

                                    command2.ExecuteNonQuery();

                                    notasRejeitadas.Add(new RetornoNFe()
                                                            {
                                                                codigoRetorno = protNFe.infProt.cStat,
                                                                NotaFiscal = nota,
                                                                observacaoRetorno = protNFe.infProt.xMotivo,
                                                                situacao = SituacaoNFe.Rejeitada
                                                            });


                                    break;


                            }
                            read.Close();
                        }

                        command.CommandText =
                            "UPDATE  " +
                            "  public.nfe_completo_lote   " +
                            "SET  " +
                            "  ncl_situacao = :ncl_situacao, " +
                            "  ncl_resultado_obs = :ncl_resultado_obs " +
                            "WHERE " +
                            "  id_nfe_completo_lote = :id_nfe_completo_lote ";
                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nfe_completo_lote", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = idNfeCompletoLote;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_situacao", NpgsqlDbType.Smallint));
                        command.Parameters[command.Parameters.Count - 1].Value = 1;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncl_resultado_obs", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = resultatoCompleto.xMotivo + " - " + resultatoCompleto.xMsg;

                        command.ExecuteNonQuery();

                        command.Transaction.Commit();

                        return notasDenegadas.Count > 0 || notasRejeitadas.Count > 0 ? RetornoProcessamentoLote.ProcessadoComProblemas : RetornoProcessamentoLote.Processado;


                        break;
                    case "105":
                        //Lote em processamento
                        retornoDetalhado = "";
                        return RetornoProcessamentoLote.EmProcessamento;
                        break;
                    case "106":
                        //Lote não encontrado
                        retornoDetalhado = "Lote não encontrado: cStat: " + resultatoCompleto.cStat + "xMotivo" + resultatoCompleto.xMotivo;
                        return RetornoProcessamentoLote.Erro;
                        break;
                    case "248":
                    case "223":
                        //Recibo inválido
                        retornoDetalhado = "Lote ou recibo inválidos: cStat: " + resultatoCompleto.cStat + "xMotivo" + resultatoCompleto.xMotivo;
                        return RetornoProcessamentoLote.Erro;
                        break;
                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.cStat + "xMotivo" + resultatoCompleto.xMotivo;
                        throw new Exception("Retorno da consulta do resultado de processamento não previsto: " + erroDetalhado);
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao consultar os recibos.\r\n" + e.Message, e);
            }
        }

        public static int getProximoNumeroNf(string cnpjEmitente, string serie, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  MAX(public.nfe_completo_nota.nfn_numero) " +
                    "FROM " +
                    "  public.nfe_completo_nota " +
                    "WHERE " +
                    "  public.nfe_completo_nota.nfn_serie = :nfn_serie AND " +
                    "  public.nfe_completo_nota.nfn_cnpj_emitente = :nfn_cnpj_emitente ";

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_serie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = serie;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfn_cnpj_emitente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = cnpjEmitente;
                int ultimaNFEmitida = Convert.ToInt32(command.ExecuteScalar());

                int toRet = ultimaNFEmitida + 1;

                //Testa faixas inutilizadas
                command.CommandText =
                    "SELECT  " +
                    "  MAX(public.nfe_completo_inutilizacao.nci_fim) " +
                    "FROM " +
                    "  public.nfe_completo_inutilizacao " +
                    "WHERE " +
                    "  :numeroteste >= public.nfe_completo_inutilizacao.nci_inicio AND  " +
                    "  :numeroteste <= public.nfe_completo_inutilizacao.nci_fim AND " +
                    "  public.nfe_completo_inutilizacao.nci_cnpj =:nfn_cnpj_emitente AND  " +
                    "  public.nfe_completo_inutilizacao.nci_serie = :nfn_serie ";

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("numeroteste", NpgsqlDbType.Integer));

                bool numeroEncontrado = false;
                while (!numeroEncontrado)
                {
                    command.Parameters["numeroteste"].Value = serie;
                    object tmp = command.ExecuteScalar();
                    if (tmp == null)
                    {
                        numeroEncontrado = true;
                    }
                    else
                    {
                        toRet = Convert.ToInt32(tmp) + 1;
                    }
                }

                return toRet;


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o próximo numero de NF.\r\n" + e.Message, e);
            }
        }

    }

    public class RetornoNFe
    {
        public TNFe NotaFiscal { get; set; }
        public SituacaoNFe situacao { get; set; }
        public string codigoRetorno { get; set; }
        public string observacaoRetorno { get; set; }
    }

    public class LoteEnviar
    {
        public int idNfCompletoLote { get; set; }
        public int NumeroLoteInterno { get; set; }
        public bool LoteEnviado { get; set; }
        public string Recibo { get; set; }
        public string Observacao { get; set; }
        public List<NotaEnviar> Notas { get; set; }

        public LoteEnviar()
        {
            this.Notas = new List<NotaEnviar>();
            this.LoteEnviado = false;
        }
    }

    public class NotaEnviar
    {
        public TNFe Nota { get; set; }
        public XmlDocument Xml { get; set; }
    }

}
