using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.CadConsultaCadastro;

namespace IWTNFCompleto
{
    public static partial class NFeOperacoes
    {


        //public static TRetConsCad ConsultaCadastro(NFeTipoDocumento tipoDocumento, string numeroDocumento, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, out string retornoDetalhado, bool Scan)
        //{
        //    retornoDetalhado = "";
        //    ComunicacaoWaitForm waitForm = new ComunicacaoWaitForm();

        //    BackgroundRunnerDefinition tr = new BackgroundRunnerDefinition(
        //        ServicoNFe.NfeConsultaCadastro,
        //        new List<object>()
        //            {
        //                tipoDocumento,
        //                numeroDocumento,
        //                ufEmitente,
        //                Ambiente,
        //                serialCertificado,
        //                Scan
        //            },
        //        new List<object>()
        //            {
        //                retornoDetalhado
        //            },
        //        waitForm);

        //    BackgroundWorker worker = new BackgroundWorker { WorkerReportsProgress = true };
        //    worker.DoWork += new DoWorkEventHandler(tr.Run);
        //    worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(tr.Completed);
        //    worker.RunWorkerAsync(tr);

        //    waitForm.ShowDialog();


        //    retornoDetalhado = (string)tr.ArgumentosSaida[0];
        //    return (TRetConsCad)tr.Retorno;
        //}

        //internal static TRetConsCad ConsultaCadastroInterno(NFeTipoDocumento tipoDocumento, string numeroDocumento, TCodUfIBGE ufEmitente, TAmb Ambiente, string serialCertificado, out string retornoDetalhado, bool Scan)
        //{
        //    try
        //    {


        //        TConsCad objConsulta = new TConsCad
        //        {
        //            versao = versaoLayout,
        //            infCons = new TConsCadInfCons()
        //            {
        //                ItemElementName = tipoDocumento,
        //                Item = numeroDocumento,
        //                UF = FuncoesAuxiliares.TCodUfIBGE2TUfCons(ufEmitente),
        //                xServ = TConsCadInfConsXServ.CONSCAD
        //            }
        //        };


        //        XmlSerializer serializer = new XmlSerializer(typeof(TConsCad));

        //        Utf8StringWriter builder = new Utf8StringWriter();
        //        XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false };
        //        XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

        //        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        //        namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

        //        serializer.Serialize(xmlWriter, objConsulta, namespaces);

        //        XmlDocument xmlConsulta = new XmlDocument();
        //        xmlConsulta.LoadXml(builder.ToString());

        //        X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);


        //        string _UrlWebservice = EnderecosWebservices.getEndereco(ufEmitente, versaoLayout, Ambiente, ServicoNFe.NfeConsultaCadastro, Scan);

        //        CadConsultaCadastro.CadConsultaCadastro2 client = new CadConsultaCadastro.CadConsultaCadastro2()
        //        {
        //            Timeout = timeoutPadrao,
        //            Url = _UrlWebservice,
        //            nfeCabecMsgValue = new nfeCabecMsg()
        //            {
        //                versaoDados = versaoLayout,
        //                cUF = Convert.ToInt32(ufEmitente).ToString()
        //            }

        //        };

        //        client.ClientCertificates.Add(certificado);

        //        XmlNode resultadoProcessamento = client.consultaCadastro2(xmlConsulta);

        //        serializer = new XmlSerializer(typeof(TRetConsSitNFe));
        //        TRetConsCad resultatoCompleto = (TRetConsCad)serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));

        //        switch (resultatoCompleto.infCons.cStat)
        //        {
        //            case "111":
        //                retornoDetalhado = "Consulta com uma Ocorrência";
        //                return resultatoCompleto;
        //                break;

        //            case "112":
        //                retornoDetalhado = "Consulta com mais de uma ocorrência";
        //                return resultatoCompleto;
        //                break;



        //            default:
        //                string erroDetalhado = "cStat: " + resultatoCompleto.infCons.cStat + " xMotivo: " + resultatoCompleto.infCons.xMotivo;
        //                throw new Exception("Retorno da consulta de cadastro não previsto: " + erroDetalhado);
        //        }
        //    }
        //    catch (System.Net.WebException e)
        //    {
        //        if (e.Message == "A solicitação foi anulada: Não foi possível criar um canal seguro para SSL/TLS.")
        //        {
        //            throw new Exception("O certificado digital não é válido ou não está disponível");
        //        }
        //        else
        //        {
        //            throw new Exception("Erro ao consultar o cadastro.\r\n" + e.Message, e);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Erro ao consultar o cadastro.\r\n" + e.Message, e);
        //    }
        //}

    }
}
