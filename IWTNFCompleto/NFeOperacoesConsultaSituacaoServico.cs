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
using IWTNFCompleto.NfeStatusServico;

namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {
        private static UltimoRetornoSituacaoServivoClass _ultimoRetornoSituacaoServivo;

        private class UltimoRetornoSituacaoServivoClass
        {
            public DateTime DataVerificacao { get; set; }
            public TAmbLegado Ambiente { get; set; }
            public TCodUfIBGELegado UfEmitente { get; set; }
            public string RetornoDetalhado { get; set; }
            public bool Scan { get; set; }
            public TMod ModeloNf { get; set; }
            public SituacaoServico SituacaoServico { get; set; }

        }


        public static SituacaoServico SituacaoServico(TCodUfIBGELegado ufEmitente,TAmbLegado Ambiente, string serialCertificado, out string retornoDetalhado, bool Scan, TMod modeloNf)
        {
            retornoDetalhado = "";
            ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

            BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
                ServicoNFe.NfeStatusServico,
                new List<object>()
                    {
                    ufEmitente,
                    Ambiente,
                    serialCertificado,
                    Scan,
                    modeloNf
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
            return (SituacaoServico)tr.Retorno;
        }

        internal static SituacaoServico SituacaoServicoInterno(TCodUfIBGELegado ufEmitente,TAmbLegado Ambiente, string serialCertificado, out string retornoDetalhado, bool Scan, TMod modeloNf)
        {
            try
            {

                if (
                    _ultimoRetornoSituacaoServivo != null && 
                    DateTime.Now.Subtract(_ultimoRetornoSituacaoServivo.DataVerificacao).TotalMinutes < 3 && 
                    _ultimoRetornoSituacaoServivo.Scan == Scan &&
                    _ultimoRetornoSituacaoServivo.UfEmitente == ufEmitente &&
                    _ultimoRetornoSituacaoServivo.Ambiente == Ambiente &&
                    _ultimoRetornoSituacaoServivo.ModeloNf == modeloNf
                    )
                {

                    retornoDetalhado = _ultimoRetornoSituacaoServivo.RetornoDetalhado;
                    return _ultimoRetornoSituacaoServivo.SituacaoServico;
                }

                

                TConsStatServ objConsulta = new TConsStatServ
                {
                    versao = versaoLayout,
                    cUFLegado = ufEmitente,
                    tpAmbLegado = Ambiente,
                    xServ = TConsStatServXServ.STATUS
                };


                XmlSerializer serializer = new XmlSerializer(typeof(TConsStatServ));

                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false };
                XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                serializer.Serialize(xmlWriter, objConsulta, namespaces);

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


                string urlWebservice = EnderecosWebservices.GetEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeStatusServico, Scan, modeloNf);

                NFeStatusServico4 client = new NFeStatusServico4
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

                XmlNode resultadoProcessamento = client.nfeStatusServicoNF(xmlConsulta);

                serializer = new XmlSerializer(typeof(TRetConsStatServ));
                TRetConsStatServ resultatoCompleto = (TRetConsStatServ)serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

                SituacaoServico toRet;
                switch (resultatoCompleto.cStat)
                {
                    case "107":
                        retornoDetalhado = "Serviço em Operação";
                        toRet = IWTNFCompleto.SituacaoServico.EmOperacao;
                        break;

                    case "108":
                        retornoDetalhado = "Serviço Paralizado Temporariamente - " + resultatoCompleto.xMotivo + " - " + resultatoCompleto.xObs;
                        toRet = IWTNFCompleto.SituacaoServico.ParalizadoTemporariamente;
                        break;

                    case "109":
                        retornoDetalhado = "Serviço Paralizado Sem Previsão de Retorno - " + resultatoCompleto.xMotivo + " - " + resultatoCompleto.xObs;
                        toRet = IWTNFCompleto.SituacaoServico.ParalizadoSemPrevisao;
                        break;

                    default:
                        string erroDetalhado = "cStat: " + resultatoCompleto.cStat + " xMotivo: " + resultatoCompleto.xMotivo;
                        throw new Exception("Retorno da situação de serviço não previsto: " + erroDetalhado);
                }

                _ultimoRetornoSituacaoServivo = new UltimoRetornoSituacaoServivoClass()
                {
                    Ambiente = Ambiente,
                    DataVerificacao = DateTime.Now,
                    RetornoDetalhado = retornoDetalhado,
                    Scan = Scan,
                    UfEmitente = ufEmitente,
                    ModeloNf = modeloNf,
                    SituacaoServico = toRet
                };

                return toRet;

            }
            catch (System.Net.WebException e)
            {
                if (e.Message == "A solicitação foi anulada: Não foi possível criar um canal seguro para SSL/TLS.")
                {
                    throw new Exception("O certificado digital não é válido ou não está disponível");
                }
                else
                {
                    _ultimoRetornoSituacaoServivo = null;
                   retornoDetalhado = e.Message;
                    return IWTNFCompleto.SituacaoServico.ParalizadoSemPrevisao;
                }
            }
            catch (Exception e)
            {
                _ultimoRetornoSituacaoServivo = null;
                retornoDetalhado = e.Message;
                return IWTNFCompleto.SituacaoServico.ParalizadoSemPrevisao;
                //throw new Exception("Erro ao verificar a situação do serviço.\r\n" + e.Message, e);
            }
        }

    }
}
