using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using IWTNFCompleto.BibliotecaDatasets;

using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.NfeInutilizacao;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {
        public static bool InutilizarFaixaNumeracao(int serie, int numeroInicial, int numeroFinal, string cnpj, TCodUfIBGELegado ufEmitente, TAmbLegado Ambiente, TMod modelo, string serialCertificado, string justificativa, string usuario, IWTPostgreNpgsqlConnection conn, out string retornoDetalhado, bool Scan)
        {
            retornoDetalhado = "";
            ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

            BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                ServicoNFe.NfeInutilizacao,
                new List<object>()
                    {
                      serie,
                      numeroInicial,
                      numeroFinal,
                      cnpj,
                      ufEmitente,
                      Ambiente,
                      modelo,
                      serialCertificado,
                      justificativa,
                      usuario,
                      conn,
                      Scan
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

        internal static bool InutilizarFaixaNumeracaoInterno(int serie, int numeroInicial, int numeroFinal, string cnpj, TCodUfIBGELegado ufEmitente, TAmbLegado Ambiente, TMod modelo, string serialCertificado, string justificativa, out string retornoDetalhado, string usuario, IWTPostgreNpgsqlConnection conn, bool Scan)
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
                    "  public.nfe_completo_inutilizacao.nci_homologacao = :nci_homologacao AND "+
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
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Ambiente == TAmbLegado.Homologacao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("inicio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = numeroInicial;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fim", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = numeroFinal;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
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
                    "  public.nfe_completo_nota.nfn_cnpj_emitente = :nci_cnpj AND " +
                    "  public.nfe_completo_nota.nfn_homologacao = :nci_homologacao";


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
                        cUFLegado = ufEmitente,
                        Id =
                            "ID" + Convert.ToInt32(ufEmitente).ToString("D2") + DateTime.Now.ToString("yy") + cnpj + "55" + serie.ToString("D3") + numeroInicial.ToString("D9") + numeroFinal.ToString("D9"),
                        mod = TMod.Item55,
                        nNFFin = numeroFinal.ToString(),
                        nNFIni = numeroInicial.ToString(),
                        serie = serie.ToString(),
                        tpAmbLegado = Ambiente,
                        xJust = justificativa,
                        xServ = TInutNFeInfInutXServ.INUTILIZAR
                    }
                };


                XmlSerializer serializer = new XmlSerializer(typeof(TInutNFe));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);

                CertificadoOperacoes.AssinaDocumento(certificado, ref xmlConsulta, "#" + objConsulta.infInut.Id);

                string urlWebservice = EnderecosWebservices.GetEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeInutilizacao, Scan, modelo);

                NFeInutilizacao4 client = new NFeInutilizacao4
                {
                    Timeout = timeoutPadrao,
                    Url = urlWebservice,
                   

                };


                if (ProxyClass.ComProxy)
                {
                    client.Proxy = new WebProxy(ProxyClass.EnderecoProxy, false)
                    {
                        Credentials = new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy, ProxyClass.DomainProxy)
                    };
                }


                client.ClientCertificates.Add(certificado);
                XmlNode resultadoProcessamento = client.nfeInutilizacaoNF(xmlConsulta);

                serializer = new XmlSerializer(typeof(TRetInutNFe));
                TRetInutNFe resultatoCompleto = (TRetInutNFe)serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                switch (resultatoCompleto.infInut.cStat)
                {
                    case "102":
                        retornoDetalhado = "Inutilização homologada com sucesso. " + resultatoCompleto.infInut.xMotivo;
                        break;
                    case "241":
                    case "213":
                        retornoDetalhado = "cStat: " + resultatoCompleto.infInut.cStat + " xMotivo: " + resultatoCompleto.infInut.xMotivo;
                        return false;
                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.infInut.cStat + " xMotivo: " + resultatoCompleto.infInut.xMotivo;
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
                    "  nci_xml, " +
                    "  nci_homologacao " +
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
                    "  :nci_xml, " +
                    "  :nci_homologacao " +
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
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nci_homologacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Ambiente == TAmbLegado.Homologacao ? 1 : 0;

                command.ExecuteNonQuery();

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
                    throw new Exception("Erro ao inutilizar a faixa.\r\n" + e.Message, e);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inutilizar a faixa.\r\n" + e.Message, e);
            }
        }

    }
}
