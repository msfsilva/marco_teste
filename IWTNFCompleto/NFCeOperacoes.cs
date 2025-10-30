using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using BibliotecaValidacoes;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.CrystalReports.SCREventLog;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.qrcode;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNF.Entidades.Base;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTNFCompleto.NfeAutorizacao;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;


namespace IWTNFCompleto
{
    public static class NFCeOperacoes
    {
        private static void processaRetornoLoteNfe(TProtNFe protNFe, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlCommand commandSearch, IWTPostgreNpgsqlCommand commandSave, out RetornoNFe notasRetornada)
        {



            NfeCompletoNotaClass searchNF = new NfeCompletoNotaClass(usuarioAtual, commandSearch.Connection);
            List<NfeCompletoNotaClass> tmp = searchNF.Search(new List<SearchParameterClass>() {new SearchParameterClass("Chave", protNFe.infProt.chNFe)}).ConvertAll(a => (NfeCompletoNotaClass) a);


            if (tmp.Count == 0)
            {
                throw new Exception("Não foi encontrada nota fiscal com a chave " + protNFe.infProt.chNFe);
            }

            NfeCompletoNotaClass nfeEmitida = tmp[0];

            if (nfeEmitida.Situacao != SituacaoNFe.Enviada)
            {
                throw new Exception("A nota fiscal com a chave " + protNFe.infProt.chNFe + " não está no status correto");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(TNFe), new XmlRootAttribute("NFe") { Namespace = "http://www.portalfiscal.inf.br/nfe" });
            XmlDocument docNF = new XmlDocument();
            docNF.LoadXml(nfeEmitida.Xml);
            TNFe nota = (TNFe) serializer.Deserialize(new XmlNodeReader(docNF));

            Utf8StringWriter builder = new Utf8StringWriter();
            switch (protNFe.infProt.cStat)
            {
                case "100":
                    //Nota Aprovada
                    TNfeProc proc = new TNfeProc()
                    {
                        NFe = nota,
                        protNFe = protNFe,
                        versao = NFeOperacoes.versaoLayout
                    };

                    serializer = new XmlSerializer(typeof (TNfeProc));


                    XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false};
                    XmlWriter xmlWriter = XmlWriter.Create(builder, settings);

                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                    serializer.Serialize(xmlWriter, proc, namespaces);


                    nfeEmitida.Xml = builder.ToString();
                    nfeEmitida.Situacao = SituacaoNFe.Autorizada;
                    nfeEmitida.DataSituacao = DateTime.Now;
                    nfeEmitida.SituacaoObservacao = protNFe.infProt.cStat + " - " + protNFe.infProt.xMotivo;

                    nfeEmitida.Save(ref commandSave);

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

                    nfeEmitida.Xml = builder.ToString();
                    nfeEmitida.Situacao = SituacaoNFe.Denegada;
                    nfeEmitida.DataSituacao = DateTime.Now;
                    nfeEmitida.SituacaoObservacao = protNFe.infProt.cStat + " - " + protNFe.infProt.xMotivo;

                    nfeEmitida.Save(ref commandSave);

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
                    nfeEmitida.Delete(ref commandSave);

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

        // Dentro do arquivo IWTNfeCompleto/NFCeOperacoes.cs

        /// <summary>
        /// Gera o conteúdo completo da URL para o QR Code da NFC-e, tratando a diferença entre o PR (versão 2.0) e outras UFs (versão 3.0).
        /// </summary>
        /// <param name="notaEnviar">O objeto contendo todos os dados da nota fiscal.</param>
        /// <param name="offline">Indica se a nota está sendo emitida em modo de contingência offline.</param>
        /// <param name="certificado">O certificado digital do emitente, obrigatório para emissão offline.</param>
        /// <returns>A string completa da URL do QR Code.</returns>
        internal static string GerarConteudoQrCode(NotaEnviar notaEnviar, bool offline, X509Certificate2 certificado, string csc, string idCSC)
        {
            string chaveNfe = notaEnviar.NfTnfe.infNFe.Id.Substring(3);
            string tpAmb = notaEnviar.NfTnfe.infNFe.ide.tpAmbLegado == TAmbLegado.Producao ? "1" : "2";
             string enderecoConsulta = GetNfceQrCodeUrl(notaEnviar.NfTnfe.infNFe.ide.cUFLegado, notaEnviar.NfTnfe.infNFe.ide.tpAmbLegado); // trocar pelo endereço pra colocar no qrcode

            string parametros;

            // VERIFICA SE A UF É O PARANÁ
            if (notaEnviar.NfTnfe.infNFe.ide.cUFLegado == TCodUfIBGELegado.PR)
            {
                // --- LÓGICA PARA O PARANÁ (VERSÃO 2.0) ---

                // Você precisará obter o CSC e seu ID. Substitua os valores abaixo pela forma como você armazena/obtém esses dados.
                // Exemplo: buscando de um banco de dados ou arquivo de configuração.

                if (string.IsNullOrEmpty(csc) || string.IsNullOrEmpty(idCSC))
                {
                    throw new Exception("CSC e ID do CSC são obrigatórios para emissão no Paraná.");
                }

                if (offline)
                {

                    // --- LÓGICA CORRETA para QR Code v2.0 OFFLINE ---

                    // 1. Verificar se realmente é o tipo de emissão offline da NFC-e
                    if (notaEnviar.NfTnfe.infNFe.ide.TpEmisLegado != TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe)
                    {
                        throw new Exception("Tipo de emissão inválido para QR Code offline v2.0: " + notaEnviar.NfTnfe.infNFe.ide.tpEmis);
                    }
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(notaEnviar.Xml.NameTable);
                    nsmgr.AddNamespace("nfe", "http://www.portalfiscal.inf.br/nfe");
                    nsmgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");

                    string xPathQuery = "//ds:DigestValue";

                    XmlNode noEncontrado = notaEnviar.Xml.SelectSingleNode(xPathQuery, nsmgr);

                    if (noEncontrado == null)
                    {
                        throw new ExcecaoTratada("O Digest Value não foi encontrado no XML da nota. Consulte a equipe IWT");
                    }


                    string digestValueHex = FuncoesAuxiliares.ConverteParaStringHexa(noEncontrado.InnerText);

                    // 4. Montar a string de parâmetros específica do QR Code v2.0 OFFLINE
                    string diaEmissao = DateTime.Parse(notaEnviar.NfTnfe.infNFe.ide.dhEmi).Day.ToString("D2");
                    string valorNf = notaEnviar.NfTnfe.infNFe.total.ICMSTot.vNF;

                    // String antes do Hash final (formato: chave|versao|ambiente|dia|valor|digest|idCSC)
                    string parametrosParaHash = $"{chaveNfe}|2|{tpAmb}|{diaEmissao}|{valorNf}|{digestValueHex}|{idCSC}";

                    // 5. Calcular o Hash Final (SHA-1) com o CSC
                    string sha1TextoQrComSCS = FuncoesAuxiliares.CalcularHashSHA1(parametrosParaHash + csc);

                    // 6. Montar a string final do QR Code v2.0 OFFLINE
                    //    Formato: URL?p=chave|versao|ambiente|dia|valor|digest|idCSC|hashCSC

                    parametros = $"{parametrosParaHash}|{sha1TextoQrComSCS}";
                }
                else
                {
                    // Lógica para emissão online (v2.0)
                    string parametrosParaHash = $"{chaveNfe}|2|{tpAmb}|{idCSC}" + csc;

                    using (SHA1Managed sha1 = new SHA1Managed())
                    {
                        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(parametrosParaHash));
                        var hashHex = new StringBuilder(hash.Length * 2);
                        foreach (byte b in hash)
                        {
                            hashHex.Append(b.ToString("x2"));
                        }

                        string codigoHash = hashHex.ToString();
                        parametros = $"{chaveNfe}|2|{tpAmb}|{idCSC}|{codigoHash}";
                    }
                }
            }
            else
            {
                // ------------ NÃO VALIDADO ------------
                // --- LÓGICA PARA OUTRAS UFs (VERSÃO 3.0 ) --- 
                string versaoQrCode = "3"; // Conforme NT 2025.001

                if (offline)
                {
                    string diaEmissao = DateTime.Parse(notaEnviar.NfTnfe.infNFe.ide.dhEmi).Day.ToString("D2");
                    string valorNf = notaEnviar.NfTnfe.infNFe.total.ICMSTot.vNF;

                    string tipoDocDest = "";
                    string docDest = "";

                    if (notaEnviar.NfTnfe.infNFe.dest != null && !string.IsNullOrWhiteSpace(notaEnviar.NfTnfe.infNFe.dest.Item))
                    {
                        if (notaEnviar.NfTnfe.infNFe.dest.Item.Length == 11) { tipoDocDest = "1"; docDest = notaEnviar.NfTnfe.infNFe.dest.Item; }
                        else if (notaEnviar.NfTnfe.infNFe.dest.Item.Length == 14) { tipoDocDest = "2"; docDest = notaEnviar.NfTnfe.infNFe.dest.Item; }
                    }

                    string parametrosParaAssinar = $"{chaveNfe}|{versaoQrCode}|{tpAmb}|{diaEmissao}|{valorNf}|{tipoDocDest}|{docDest}";
                    string assinatura = AssinarDados(parametrosParaAssinar, certificado);
                    parametros = $"{parametrosParaAssinar}|{assinatura}";
                }
                else
                {
                    parametros = $"{chaveNfe}|{versaoQrCode}|{tpAmb}";
                }
            }

            // Retorna a URL completa
            return $"{enderecoConsulta}?p={parametros}";
        }

        /// <summary>
        /// Retorna a URL base para a montagem do QR Code da NFC-e para um determinado estado e ambiente.
        /// Fonte: https://nfce.encat.org/desenvolvedor/qrcode/
        /// </summary>
        /// <param name="uf">O código IBGE do estado (UF).</param>
        /// <param name="ambiente">O ambiente de destino (Produção ou Homologação).</param>
        /// <returns>A URL para o QR Code como uma string. Retorna string vazia se a UF não emitir NFC-e ou não for encontrada.</returns>
        public static string GetNfceQrCodeUrl(TCodUfIBGELegado uf, TAmbLegado ambiente)
        {
            bool isProducao = ambiente == TAmbLegado.Producao;

            switch (uf)
            {
                case TCodUfIBGELegado.AC: return "http://www.sefaznet.ac.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.AL: return "http://nfce.sefaz.al.gov.br/QRCode/consultarNFCe.jsp";
                case TCodUfIBGELegado.AP: return "https://www.sefaz.ap.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.AM: return isProducao ? "http://sistemas.sefaz.am.gov.br/nfceweb/consultarNFCe.do" : "http://homnfce.sefaz.am.gov.br/nfceweb/consultarNFCe.do";
                case TCodUfIBGELegado.BA: return isProducao ? "http://nfe.sefaz.ba.gov.br/servicos/nfce/qrcode.aspx" : "http://hnfe.sefaz.ba.gov.br/servicos/nfce/qrcode.aspx";
                case TCodUfIBGELegado.CE: return isProducao ? "http://nfce.sefaz.ce.gov.br/pages/ShowNFCe.html" : "http://nfceh.sefaz.ce.gov.br/pages/ShowNFCe.html";
                case TCodUfIBGELegado.DF: return "http://dec.fazenda.df.gov.br/ConsultarNFCe.aspx";
                case TCodUfIBGELegado.ES: return isProducao ? "http://app.sefaz.es.gov.br/QRCode/consultarNFCe.aspx" : "http://homologacao.sefaz.es.gov.br/QRCode/consultarNFCe.aspx";
                case TCodUfIBGELegado.GO: return isProducao ? "http://nfe.sefaz.go.gov.br/nfeweb/sites/nfce/danfeNFCe" : "http://homolog.sefaz.go.gov.br/nfeweb/sites/nfce/danfeNFCe";
                case TCodUfIBGELegado.MA: return isProducao ? "http://www.nfce.sefaz.ma.gov.br/portal/consultarNFCe.jsp" : "http://www.hom.nfce.sefaz.ma.gov.br/portal/consultarNFCe.jsp";
                case TCodUfIBGELegado.MT: return isProducao ? "http://www.sefaz.mt.gov.br/nfce/consultanfce" : "http://homologacao.sefaz.mt.gov.br/nfce/consultanfce";
                case TCodUfIBGELegado.MS: return "http://www.dfe.ms.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.MG: return "https://portalsped.fazenda.mg.gov.br/portalnfce/sistema/qrcode.xhtml";
                case TCodUfIBGELegado.PA: return "https://www.sefa.pa.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.PB: return isProducao ? "http://www.receita.pb.gov.br/nfce/qrcode" : "http://www.receita.pb.gov.br/nfcehom/qrcode";
                case TCodUfIBGELegado.PR: return "http://www.fazenda.pr.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.PE: return isProducao ? "http://nfce.sefaz.pe.gov.br/nfce/consulta" : "http://nfcehomolog.sefaz.pe.gov.br/nfce/consulta";
                case TCodUfIBGELegado.PI: return "http://www.sefaz.pi.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.RJ: return "http://www4.fazenda.rj.gov.br/consultaNFCe/QRCode";
                case TCodUfIBGELegado.RN: return isProducao ? "http://nfce.set.rn.gov.br/consultarNFCe.aspx" : "http://hom.nfce.set.rn.gov.br/consultarNFCe.aspx";
                case TCodUfIBGELegado.RS: return isProducao ? "https://www.sefaz.rs.gov.br/nfce/consulta" : "https://www.sefaz.rs.gov.br/nfce/consulta-d";
                case TCodUfIBGELegado.RO: return "http://www.sefin.ro.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.RR: return isProducao ? "https://www.sefaz.rr.gov.br/nfce/servlet/qrcode" : "http://200.174.9.67/nfce/servlet/qrcode";
                case TCodUfIBGELegado.SP: return isProducao ? "https://www.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/Paginas/ConsultaQRCode.aspx" : "https://homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/Paginas/ConsultaQRCode.aspx";
                case TCodUfIBGELegado.SE: return isProducao ? "http://www.nfce.se.gov.br/nfce/qrcode" : "http://www.hom.nfce.se.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.TO: return isProducao ? "http://www.sefaz.to.gov.br/nfce/qrcode" : "http://hom.sefaz.to.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.SC: return string.Empty; // SC não usa NFC-e
                default: return string.Empty;
            }
        }

        internal static string GetEnderecoConsulta(NotaEnviar notaEnviar)
        {
            return GetEnderecoConsulta(notaEnviar.NfTnfe.infNFe.ide.cUFLegado, notaEnviar.NfTnfe.infNFe.ide.tpAmbLegado);
        }

        /// Fornece métodos para obter URLs de serviços da NFC-e.
        /// </summary>
        /// <summary>
        /// Retorna a URL de consulta pública do QR Code da NFC-e para um determinado estado e ambiente.
        /// </summary>
        /// <param name="uf">O código IBGE do estado (UF).</param>
        /// <param name="ambiente">O ambiente de destino (Produção ou Homologação).</param>
        /// <returns>A URL de consulta como uma string. Retorna string vazia se a UF não emitir NFC-e ou não for encontrada.</returns>
        public static string GetEnderecoConsulta(TCodUfIBGELegado uf, TAmbLegado ambiente)
        {
            bool isProducao = ambiente == TAmbLegado.Producao;

            switch (uf)
            {
                case TCodUfIBGELegado.AC:
                    return "http://www.sefaznet.ac.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.AL:
                    return "http://nfce.sefaz.al.gov.br/QRCode/consultarNFCe.jsp";
                case TCodUfIBGELegado.AP:
                    return "https://www.sefaz.ap.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.AM:
                    return isProducao
                        ? "http://sistemas.sefaz.am.gov.br/nfceweb/consultarNFCe.do"
                        : "http://homnfce.sefaz.am.gov.br/nfceweb/consultarNFCe.do";
                case TCodUfIBGELegado.BA:
                    return isProducao
                        ? "http://nfe.sefaz.ba.gov.br/servicos/nfce/qrcode.aspx"
                        : "http://hnfe.sefaz.ba.gov.br/servicos/nfce/qrcode.aspx";
                case TCodUfIBGELegado.CE:
                    return isProducao
                        ? "http://nfce.sefaz.ce.gov.br/pages/ShowNFCe.html"
                        : "http://nfceh.sefaz.ce.gov.br/pages/ShowNFCe.html";
                case TCodUfIBGELegado.DF:
                    return "http://dec.fazenda.df.gov.br/ConsultarNFCe.aspx";
                case TCodUfIBGELegado.ES:
                    return isProducao
                        ? "http://app.sefaz.es.gov.br/QRCode/consultarNFCe.aspx"
                        : "http://homologacao.sefaz.es.gov.br/QRCode/consultarNFCe.aspx";
                case TCodUfIBGELegado.GO:
                    return isProducao
                        ? "http://nfe.sefaz.go.gov.br/nfeweb/sites/nfce/danfeNFCe"
                        : "http://homolog.sefaz.go.gov.br/nfeweb/sites/nfce/danfeNFCe";
                case TCodUfIBGELegado.MA:
                    return isProducao
                        ? "http://www.nfce.sefaz.ma.gov.br/portal/consultarNFCe.jsp"
                        : "http://www.hom.nfce.sefaz.ma.gov.br/portal/consultarNFCe.jsp";
                case TCodUfIBGELegado.MT:
                    return isProducao
                        ? "http://www.sefaz.mt.gov.br/nfce/consultanfce"
                        : "http://homologacao.sefaz.mt.gov.br/nfce/consultanfce";
                case TCodUfIBGELegado.MS:
                    return "http://www.dfe.ms.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.MG:
                    return "https://portalsped.fazenda.mg.gov.br/portalnfce/sistema/qrcode.xhtml";
                case TCodUfIBGELegado.PA:
                    return "https://www.sefa.pa.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.PB:
                    return isProducao
                        ? "http://www.receita.pb.gov.br/nfce/qrcode"
                        : "http://www.receita.pb.gov.br/nfcehom/qrcode";
                case TCodUfIBGELegado.PR:
                    return "http://www.fazenda.pr.gov.br/nfce/consulta";
                case TCodUfIBGELegado.PE:
                    return isProducao
                        ? "http://nfce.sefaz.pe.gov.br/nfce/consulta"
                        : "http://nfcehomolog.sefaz.pe.gov.br/nfce/consulta";
                case TCodUfIBGELegado.PI:
                    return "http://www.sefaz.pi.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.RJ:
                    return "http://www4.fazenda.rj.gov.br/consultaNFCe/QRCode";
                case TCodUfIBGELegado.RN:
                    return isProducao
                        ? "http://nfce.set.rn.gov.br/consultarNFCe.aspx"
                        : "http://hom.nfce.set.rn.gov.br/consultarNFCe.aspx";
                case TCodUfIBGELegado.RS:
                    return isProducao
                        ? "https://www.sefaz.rs.gov.br/nfce/consulta"
                        : "https://www.sefaz.rs.gov.br/nfce/consulta-d";
                case TCodUfIBGELegado.RO:
                    return "http://www.sefin.ro.gov.br/nfce/qrcode.jsp";
                case TCodUfIBGELegado.RR:
                    return isProducao
                        ? "https://www.sefaz.rr.gov.br/nfce/servlet/qrcode"
                        : "http://200.174.9.67/nfce/servlet/qrcode";
                case TCodUfIBGELegado.SP:
                    return isProducao
                        ? "https://www.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/Paginas/ConsultaQRCode.aspx"
                        : "https://homologacao.nfce.fazenda.sp.gov.br/NFCeConsultaPublica/Paginas/ConsultaQRCode.aspx";
                case TCodUfIBGELegado.SE:
                    return isProducao
                        ? "http://www.nfce.se.gov.br/nfce/qrcode"
                        : "http://www.hom.nfce.se.gov.br/nfce/qrcode";
                case TCodUfIBGELegado.TO:
                    return isProducao
                        ? "http://www.sefaz.to.gov.br/nfce/qrcode"
                        : "http://hom.sefaz.to.gov.br/nfce/qrcode";

                // Santa Catarina não utiliza o modelo NFC-e.
                case TCodUfIBGELegado.SC:
                    return string.Empty;

                default:
                    return string.Empty;
            }
        }
    

    internal static LoteEnviar CriaLote(NotaEnviar notaEnviar, TAmbLegado Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor, string csc, string idCSC, AcsUsuarioClass usuarioAtual, ComunicacaoWaitForm waitForm)
        {
            
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);

                if (waitForm != null)
                {
                    waitForm.MudaMensagem("Enviando notas fiscais para a receita, por favor aguarde");
                }


                LoteEnviar loteAtual = new LoteEnviar();



                command = conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                //Buscar numero do lote
                command.CommandText =
                    "SELECT  " +
                    "  COALESCE(MAX(public.nfe_completo_lote.ncl_numero_lote),0) " +
                    "FROM " +
                    "  public.nfe_completo_lote " +
                    "WHERE " +
                    "ncl_modelo = '65' ";
                loteAtual.NumeroLoteInterno = (Convert.ToInt32(command.ExecuteScalar())) + 1;
                //Assinar as NFes que serão enviadas


                // Trata infAdic
                if (notaEnviar.NfTnfe.infNFe.infAdic == null || 
                    (string.IsNullOrEmpty(notaEnviar.NfTnfe.infNFe.infAdic.infCpl) &&
                     (notaEnviar.NfTnfe.infNFe.infAdic.obsCont == null || notaEnviar.NfTnfe.infNFe.infAdic.obsCont.Count == 0)))
                {
                    notaEnviar.NfTnfe.infNFe.infAdic = null; // Não serializa a tag
                }

                // Trata retTrib dentro de total
                if (notaEnviar.NfTnfe.infNFe.total?.retTrib != null)
                {
                    // Verifica se retTrib está vazio (sem propriedades preenchidas)
                    var retTrib = notaEnviar.NfTnfe.infNFe.total.retTrib;

                    // Assumindo que retTrib tem propriedades como vRetPIS, vRetCOFINS, etc.
                    // Se todas estiverem nulas ou zeradas, remove o objeto
                    bool isRetTribEmpty = true;

                    // Use reflection para verificar se todas as propriedades são nulas/zero
                    var properties = retTrib.GetType().GetProperties();
                    foreach (var prop in properties)
                    {
                        var value = prop.GetValue(retTrib);
                        if (value != null && !value.Equals(0m) && !value.Equals(0.0m) && !string.IsNullOrEmpty(value.ToString()))
                        {
                            isRetTribEmpty = false;
                            break;
                        }
                    }

                    if (isRetTribEmpty)
                    {
                        notaEnviar.NfTnfe.infNFe.total.retTrib = null; // Não serializa a tag
                    }
                }




                NfeCompletoLoteClass lote = new NfeCompletoLoteClass(usuarioAtual, conn)
                {
                    NumeroLote = loteAtual.NumeroLoteInterno,
                    DataEnvio = DateTime.Now,
                    Situacao = SituacaoLote.AguardandoEnvio,
                    CnpjTransmissor = cnpjTransmissor,
                    Homologacao = Ambiente == TAmbLegado.Homologacao,
                    Scan = false,
                    Modelo = "65",
                    

                };

                //Insere o lote no banco de dados
                lote.Save(ref command);
                loteAtual.NfeCompletoLote = lote;


                
                //Assina a nota antes de gerar o QR Code pois o QR depdende da tag da assinatura
                notaEnviar.Xml = assinaNfe(notaEnviar.NfTnfe, certificado);

                XmlSerializer serializer = new XmlSerializer(typeof(TNFe), new XmlRootAttribute("NFe") { Namespace = "http://www.portalfiscal.inf.br/nfe" });
                notaEnviar.NfTnfe = (TNFe) serializer.Deserialize(new XmlNodeReader(notaEnviar.Xml));

                notaEnviar.NfTnfe.infNFeSupl = new TNFeInfNFeSupl()
                {
                    qrCode = NFCeOperacoes.GerarConteudoQrCode(notaEnviar, false,certificado,csc, idCSC),
                    UrlChave = GetEnderecoConsulta(notaEnviar)

                };


             
                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false, Indent = false };
                XmlWriter xmlWriter;

                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                builder = new Utf8StringWriter();
                xmlWriter = XmlWriter.Create(builder, settings);

                serializer.Serialize(xmlWriter, notaEnviar.NfTnfe, namespaces);

                XmlDocument xmlNfe = new XmlDocument();
                xmlNfe.LoadXml(builder.ToString());


                notaEnviar.Xml = xmlNfe;


                #region Validações
                List<IValidacao> validacoes = (from t in Assembly.GetAssembly(typeof(IValidacao)).GetTypes()
                                               where t.GetInterfaces().Contains(typeof(IValidacao)) && t.GetConstructor(Type.EmptyTypes) != null
                                               select (IValidacao)Activator.CreateInstance(t)
                    ).ToList();

                string erroCompletoValidacoes = "";
                foreach (IValidacao validacao in validacoes)
                {
                    string erro = null;
                    try
                    {
                        validacao.Validar(notaEnviar.NfTnfe, out erro);
                    }
                    catch (Exception e)
                    {
                        erro = "Erro inesperado ao executar a regra " + validacao.GetType().ToString() + ": " + e.Message;
                    }
                    if (!string.IsNullOrWhiteSpace(erro))
                    {
                        erroCompletoValidacoes += validacao.GetType().Name + ": " + erro + Environment.NewLine;
                    }
                }

                if (erroCompletoValidacoes.Length > 0)
                {
                    command.Transaction.Rollback();
                    command.Transaction = null;
                    notaEnviar.NfPrincipal.EnviarNfeReceita = false;
                    notaEnviar.NfPrincipal.Save();

                    throw new Exception("Erro ao realizar as validações da nota: " + Environment.NewLine + erroCompletoValidacoes);
                }
                #endregion

                NfeCompletoNotaClass nFeEmitida = new NfeCompletoNotaClass(usuarioAtual, conn)
                {
                    CnpjEmitente = notaEnviar.NfTnfe.infNFe.emit.Item,
                    Serie = int.Parse(notaEnviar.NfTnfe.infNFe.ide.serie),
                    Numero = int.Parse(notaEnviar.NfTnfe.infNFe.ide.nNF),
                    NfeCompletoLote = loteAtual.NfeCompletoLote,
                    Chave = notaEnviar.NfTnfe.infNFe.Id.Substring(3),
                    Homologacao = Ambiente == TAmbLegado.Homologacao,
                    DataSituacao = DateTime.Now,
                    Situacao = SituacaoNFe.NFCeAguardandoEnvio,
                    DataEmissao = DateTime.Parse(notaEnviar.NfTnfe.infNFe.ide.dhEmi, CultureInfo.InvariantCulture),
                    SituacaoObservacao = "Aguardando Envio",
                    Modelo = "65",
                    Xml = xmlNfe.InnerXml,
                    NfPrincipal = notaEnviar.NfPrincipal
                };

                
                nFeEmitida.Save(ref command);

                loteAtual.Notas.Add(notaEnviar);

                NfeCompletoLogChavesClass logChave = new NfeCompletoLogChavesClass(usuarioAtual, conn)
                {
                    Chave = nFeEmitida.Chave,
                    Homologacao = nFeEmitida.Homologacao,
                    Numero = nFeEmitida.Numero,
                    Serie = nFeEmitida.Serie,
                    Modelo = "65"
                };

                logChave.Save(ref command);

                notaEnviar.NfPrincipal.EnviarNfeReceita = false;
                notaEnviar.NfPrincipal.Save(ref command);

                command.Transaction.Commit();
                command.Transaction = null;

                NfeSituacaoTransmissaoClass transmissao =
                     (NfeSituacaoTransmissaoClass)
                         new NfeSituacaoTransmissaoClass(usuarioAtual, command.Connection).Search(
                             new List<SearchParameterClass>()
                             {
                                    new SearchParameterClass("IdNfPrincipal", notaEnviar.NfPrincipal.ID)
                             }).FirstOrDefault();


                if (transmissao == null)
                {
                    transmissao = new NfeSituacaoTransmissaoClass(usuarioAtual, command.Connection)
                    {
                        IdNfPrincipal = (int)notaEnviar.NfPrincipal.ID,
                        NotaTipo =
                            notaEnviar.NfTnfe.infNFe.ide.mod == TMod.Item55 ? IWTNFTipoNota.NFe : IWTNFTipoNota.NFCe,
                        Situacao = IWTNFSituacaoTransmissao.AguardandoEnvio,
                        NotaNumero = notaEnviar.NfPrincipal.Numero,
                        NotaSerie = notaEnviar.NfTnfe.infNFe.ide.serie,
                        NotaModelo = notaEnviar.NfTnfe.infNFe.ide.mod.ToString().Replace("Item", ""),
                        NotaEmitente = notaEnviar.NfTnfe.infNFe.emit.xNome,
                        NotaDestinatario = notaEnviar.NfTnfe.infNFe.dest.xNome,
                        NotaDataEmissao = notaEnviar.NfPrincipal.DataEmissao,


                    };

                    transmissao.Save();
                }

                transmissao.NotaNumero = notaEnviar.NfPrincipal.Numero;
                transmissao.NotaSerie = notaEnviar.NfTnfe.infNFe.ide.serie;
                transmissao.Situacao = IWTNFSituacaoTransmissao.AguardandoResposta;
                transmissao.Mensagem = "Nota enviada para a receita, aguardando a resposta.";
                transmissao.DataAtualizacao = DataIndependenteClass.GetData();
                transmissao.NotaChave = notaEnviar.NfTnfe.infNFe.Id.Replace("NFe", "");
                transmissao.IdNfCompletoNota = (int)nFeEmitida.ID;

                transmissao.Save(ref command);

                return loteAtual;
            }
            catch (System.Net.WebException e)
            {
                if (command != null && command.Transaction != null)
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
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro inesperado ao criar o lote da NFCe.\r\n" + e.Message, e);

            }
            finally
            {
                
            }
        }

        private static XmlDocument assinaNfe(TNFe notaAssinar, X509Certificate2 certificado)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TNFe), new XmlRootAttribute("NFe") { Namespace = "http://www.portalfiscal.inf.br/nfe" });
            Utf8StringWriter builder = new Utf8StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false, Indent = false };
            XmlWriter xmlWriter;

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

            builder = new Utf8StringWriter();
            xmlWriter = XmlWriter.Create(builder, settings);

            serializer.Serialize(xmlWriter, notaAssinar, namespaces);

            XmlDocument xmlNfe = new XmlDocument();
            xmlNfe.LoadXml(builder.ToString());

            CertificadoOperacoes.AssinaDocumento(certificado, ref xmlNfe, "#" + notaAssinar.infNFe.Id);
            return xmlNfe;
        }

        /// <summary>
        /// Assina uma string de dados com a chave privada de um certificado digital usando RSA-SHA1.
        /// Esta versão é compatível com .NET Framework 4.5.2.
        /// </summary>
        /// <param name="dados">A string de dados a ser assinada.</param>
        /// <param name="certificado">O certificado digital contendo a chave privada.</param>
        /// <returns>A assinatura digital formatada como uma string Base64.</returns>
        private static string AssinarDados(string dados, X509Certificate2 certificado)
        {
            if (!certificado.HasPrivateKey)
            {
                throw new CryptographicException("O certificado não contém uma chave privada ou a chave não é exportável.");
            }

            // No .NET Framework 4.5.2, é necessário fazer o cast da chave privada para o provedor de serviço específico.
            var rsa = (System.Security.Cryptography.RSACryptoServiceProvider) certificado.PrivateKey;

            // Converte os dados para um array de bytes
            var dadosBytes = Encoding.UTF8.GetBytes(dados);

            // Assina os dados usando o algoritmo SHA1
            var signatureBytes = rsa.SignData(dadosBytes, "SHA1");

            // Retorna a assinatura no formato Base64, conforme exigido pelo manual
            return Convert.ToBase64String(signatureBytes);
        }

        internal static RetornoNFe EnviarLote(NfeCompletoLoteClass loteEnviar, TCodUfIBGELegado ufEmitente, TAmbLegado Ambiente, string serialCertificado, IWTPostgreNpgsqlConnection conn, string cnpjTransmissor, string csc, string idCSC, AcsUsuarioClass usuarioAtual, ComunicacaoWaitForm waitForm)
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {

                command = conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                X509Certificate2 certificado = CertificadoOperacoes.BuscaCertficado(serialCertificado);

                if (waitForm != null)
                {
                    waitForm.MudaMensagem("Enviando notas fiscais para a receita, por favor aguarde");
                }

                TEnviNFe objetoEnvio = new TEnviNFe()
                {
                    idLote = loteEnviar.NumeroLote.ToString(),
                    versao = NFeOperacoes.versaoLayout,
                    indSincLegado = TEnviNFeIndSincLegado.Sincrono
                };



                XmlAttributeOverrides overrides = new XmlAttributeOverrides();

                // Override para a classe TEnviNFe
                XmlAttributes attrs = new XmlAttributes();
                XmlRootAttribute root = new XmlRootAttribute("enviNFe");
                root.Namespace = "http://www.portalfiscal.inf.br/nfe";
                attrs.XmlRoot = root;
                overrides.Add(typeof(TEnviNFe), attrs);

                // Override para as propriedades filhas (remove namespace)
                //XmlAttributes attrsIdLote = new XmlAttributes();
                //attrsIdLote.XmlElements.Add(new XmlElementAttribute("idLote") { Namespace = "" });
                //overrides.Add(typeof(TEnviNFe), "idLote", attrsIdLote);

                //XmlAttributes attrsIndSinc = new XmlAttributes();
                //attrsIndSinc.XmlElements.Add(new XmlElementAttribute("indSinc") { Namespace = "" });
                //overrides.Add(typeof(TEnviNFe), "indSinc", attrsIndSinc);

                //XmlAttributes attrsNFe = new XmlAttributes();
                //attrsNFe.XmlElements.Add(new XmlElementAttribute("NFe") { Namespace = "" });
                //overrides.Add(typeof(TEnviNFe), "NFe", attrsNFe);



                XmlSerializer serializer = new XmlSerializer(typeof (TEnviNFe), overrides);
                Utf8StringWriter builder = new Utf8StringWriter();
                XmlWriterSettings settings = new XmlWriterSettings {OmitXmlDeclaration = false, Indent = false, ConformanceLevel = ConformanceLevel.Auto};
                using (XmlWriter xmlWriter = XmlWriter.Create(builder, settings))
                {
                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");
                    serializer.Serialize(xmlWriter, objetoEnvio, namespaces);
                }

                XmlDocument xmlConsulta = new XmlDocument();
                xmlConsulta.LoadXml(builder.ToString());



                foreach (NfeCompletoNotaClass notaLoteEnviar in loteEnviar.CollectionNfeCompletoNotaClassNfeCompletoLote)
                {
                    if (loteEnviar.Scan)
                    {

                       AtualizarQrCodeTransmissaoContingencia(notaLoteEnviar,command,certificado, csc, idCSC);
                    }

                    XmlDocument xmlNota = new XmlDocument();
                    xmlNota.LoadXml(notaLoteEnviar.Xml);
                    xmlConsulta.DocumentElement.AppendChild(xmlConsulta.ImportNode(xmlNota.DocumentElement, true));
                }

                string urlWebservice = EnderecosWebservices.GetEndereco(ufEmitente, NFeOperacoes.versaoLayout, Ambiente, ServicoNFe.NfeRecepcao, false, TMod.Item65);

                NFeAutorizacao4 client = new NFeAutorizacao4()
                { 
                    Url = urlWebservice,
                    Timeout = NFeOperacoes.timeoutPadrao

                };


                if (ProxyClass.ComProxy)
                {
                    client.Proxy = new WebProxy(ProxyClass.EnderecoProxy, false)
                    {
                        Credentials = new NetworkCredential(ProxyClass.UsuarioProxy, ProxyClass.SenhaProxy, ProxyClass.DomainProxy)
                    };
                }


                client.ClientCertificates.Add(certificado);



                TRetEnviNFe resultatoCompleto = null;
                try
                {

#if DEBUG
                //Log do evento completo pra avaliação caso necessário


                //    string xmlCompleto = xmlConsulta.OuterXml;

                //    // Salva o XML enviado para análise
                //    string pastaTemp = @"C:\temp\nfce_logs";
                //    if (!System.IO.Directory.Exists(pastaTemp))
                //        System.IO.Directory.CreateDirectory(pastaTemp);

                //    string nomeArquivo = $"xml_enviado_{DateTime.Now:yyyyMMdd_HHmmss}.xml";
                //    System.IO.File.WriteAllText(System.IO.Path.Combine(pastaTemp, nomeArquivo), xmlCompleto);

                //    // Log também em formato legível (com quebras de linha)
                //    XmlDocument docFormatado = new XmlDocument();
                //    docFormatado.LoadXml(xmlCompleto);
                //    using (var stringWriter = new System.IO.StringWriter())
                //    using (var xmlTextWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                //    {
                //        docFormatado.WriteTo(xmlTextWriter);
                //        xmlTextWriter.Flush();
                //        System.IO.File.WriteAllText(
                //            System.IO.Path.Combine(pastaTemp, nomeArquivo.Replace(".xml", "_formatado.xml")),
                //            stringWriter.GetStringBuilder().ToString()
                //        );
                //    }
#endif


                XmlNode resultadoProcessamento = client.nfeAutorizacaoLote(xmlConsulta);

                    serializer = new XmlSerializer(typeof(TRetEnviNFe));
                    resultatoCompleto = (TRetEnviNFe) serializer.Deserialize(new XmlNodeReader(resultadoProcessamento));
                }
                catch (System.Net.WebException e)
                {
                    if (!loteEnviar.Scan)
                    {
                        MudaLoteContingencia(loteEnviar, command, certificado, usuarioAtual, csc, idCSC);
                    }

                    loteEnviar.Retry = true;
                    loteEnviar.ResultadoObs = "Falha ao enviar a NFC-e: " + e.Message;
                    loteEnviar.Save(ref command);
                    command.Transaction.Commit();

                    return null;
                }
                catch (Exception e)
                {

                    loteEnviar.Retry = false;
                    loteEnviar.ResultadoObs = "Falha ao enviar a NFC-e: " + e.Message;
                    loteEnviar.Save(ref command);
                    command.Transaction.Commit();
                    
                    return null;
                }

                RetornoNFe toRet= null;
                

                loteEnviar.Situacao = SituacaoLote.Enviado;
                foreach (NfeCompletoNotaClass nota in loteEnviar.CollectionNfeCompletoNotaClassNfeCompletoLote)
                {
                    nota.Situacao = SituacaoNFe.Enviada;
                }


                if (resultatoCompleto.cStat == "103" || resultatoCompleto.cStat == "105")
                {

                    if (resultatoCompleto.Item is TRetEnviNFeInfRec)
                    {
                        //Lote recebido com sucesso

                        TRetEnviNFeInfRec retornoLote = (TRetEnviNFeInfRec) resultatoCompleto.Item;

                        loteEnviar.Recibo = retornoLote.nRec;
                        loteEnviar.ResultadoObs = resultatoCompleto.xMotivo;
                        loteEnviar.Save(ref command);

                    }
                    else
                    {
                        throw new Exception(resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo + " - Recebido CSTAT 103/105 porem sem objeto do tipo TRetEnviNFeInfRec");
                    }

                }
                else
                {
                    if (resultatoCompleto.cStat == "104")
                    {

                        if (resultatoCompleto.Item is TProtNFe)
                        {

                            TProtNFe retornoLote = (TProtNFe) resultatoCompleto.Item;

                            
                            processaRetornoLoteNfe(retornoLote, usuarioAtual, command, command, out toRet);


                            loteEnviar.ResultadoObs = resultatoCompleto.xMotivo;
                            loteEnviar.Situacao = SituacaoLote.Processado;
                            loteEnviar.Save(ref command);

                        }
                        else
                        {
                            throw new Exception(resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo + " - Recebido CSTAT 104 porem sem objeto do tipo TProtNFe");

                        }
                    }
                    else
                    {
                        throw new Exception(resultatoCompleto.cStat + " - " + resultatoCompleto.xMotivo);

                    }
                }

                command.Transaction.Commit();
                command.Transaction = null;

                return toRet;
            }
            catch (System.Net.WebException e)
            {
                if (command != null && command.Transaction != null)
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
            catch (ExcecaoTratada)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro inesperado ao enviar o lote da NFCe.\r\n" + e.Message, e);

            }
            finally
            {
                
            }
        }

        private static void MudaLoteContingencia(NfeCompletoLoteClass lote, IWTPostgreNpgsqlCommand command, X509Certificate2 certificado, AcsUsuarioClass usuario, string csc, string idCSC)
        {
            try
            {

                command.CommandText =
                    "SELECT  " +
                    "  public.nf_principal.nfp_serie, " +
                    "  public.nf_principal.nfp_data_emissao, " +
                    "  public.nf_principal.nfp_forma_emissao " +
                    "FROM " +
                    "  public.nf_principal " +
                    "WHERE " +
                    "  public.nf_principal.nfp_modelo_doc_fiscal = '65' " +
                    "ORDER BY " +
                    "  public.nf_principal.nfp_data_emissao DESC ";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                DateTime dataEntradaContingencia = DateTime.Now;
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

                lote.Scan = true;
                lote.GerarDanfeOffline = true;
                foreach (NfeCompletoNotaClass nota in lote.CollectionNfeCompletoNotaClassNfeCompletoLote)
                {
                    nota.NfPrincipal.FormaEmissao = FormaEmissaoNFe.ContingenciaScan;

                    XmlSerializer serializerV3 = new XmlSerializer(typeof(TNFe), new XmlRootAttribute("NFe") { Namespace = "http://www.portalfiscal.inf.br/nfe" });
                    XmlDocument docNF = new XmlDocument();
                    docNF.LoadXml(nota.Xml);
                    TNFe nfe = (TNFe)serializerV3.Deserialize(new XmlNodeReader(docNF));

                    nfe.Signature = null;
                    nfe.infNFe.ide.xJust = "Falha de comunicação com o ambiente de produção";
                    nfe.infNFe.ide.dhCont = dataEntradaContingencia.ToString("yyyy-MM-ddTHH:mm:sszzz");

                    nfe.infNFe.ide.TpEmisLegado = TNFeInfNFeIdeTpEmisLegado.ContingenciaOffLineNFCe;

                    NFeOperacoes.CalculaChaveNota(nfe);

                    nota.Xml = assinaNfe(nfe, certificado).InnerXml;
                    docNF.LoadXml(nota.Xml);

                    NotaEnviar notaEnviar = new NotaEnviar()
                    {
                        NfPrincipal = nota.NfPrincipal,
                        NfTnfe = nfe,
                        Xml = docNF
                    };
                    notaEnviar.NfTnfe.infNFeSupl.qrCode = GerarConteudoQrCode(notaEnviar, true,certificado, csc, idCSC);


                    XmlSerializer serializer = new XmlSerializer(typeof(TNFe), new XmlRootAttribute("NFe") { Namespace = "http://www.portalfiscal.inf.br/nfe" });
                    Utf8StringWriter builder = new Utf8StringWriter();
                    XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false, Indent = false };
                    XmlWriter xmlWriter;

                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

                    builder = new Utf8StringWriter();
                    xmlWriter = XmlWriter.Create(builder, settings);

                    serializer.Serialize(xmlWriter, notaEnviar.NfTnfe, namespaces);

                    XmlDocument xmlNfe = new XmlDocument();
                    xmlNfe.LoadXml(builder.ToString());

                    notaEnviar.Xml = xmlNfe;
                    nota.Xml = notaEnviar.Xml.InnerXml;
                    nota.Chave = nfe.infNFe.Id.Substring(3);



                    NfeCompletoLogChavesClass logChave = new NfeCompletoLogChavesClass(usuario, command.Connection)
                    {
                        Chave = nota.Chave,
                        Homologacao = nota.Homologacao,
                        Numero = nota.Numero,
                        Serie = nota.Serie,
                        Modelo = "65"
                    };

                    logChave.Save(ref command);

       
                    nota.Save(ref command);
                  
                    nota.NfPrincipal.Save(ref command);
                }

                
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao mudar o lote para contingencia.\r\n" + e.Message, e);
            }
        }

        private static void AtualizarQrCodeTransmissaoContingencia(NfeCompletoNotaClass nota, IWTPostgreNpgsqlCommand command, X509Certificate2 certificado, string csc, string idCSC)
        {

            XmlSerializer serializerV3 = new XmlSerializer(typeof(TNFe), new XmlRootAttribute("NFe") { Namespace = "http://www.portalfiscal.inf.br/nfe" });
            XmlDocument docNF = new XmlDocument();
            docNF.LoadXml(nota.Xml);
            TNFe nfe = (TNFe)serializerV3.Deserialize(new XmlNodeReader(docNF));

            nfe.Signature = null;
          
            nota.Xml = assinaNfe(nfe, certificado).InnerXml;
            docNF.LoadXml(nota.Xml);

            nfe = (TNFe)serializerV3.Deserialize(new XmlNodeReader(docNF));

            NotaEnviar notaEnviar = new NotaEnviar()
            {
                NfPrincipal = nota.NfPrincipal,
                NfTnfe = nfe,
                Xml = docNF
            };
            notaEnviar.NfTnfe.infNFeSupl.qrCode = GerarConteudoQrCode(notaEnviar, true,certificado, csc, idCSC);


            XmlSerializer serializer = new XmlSerializer(typeof(TNFe), new XmlRootAttribute("NFe") { Namespace = "http://www.portalfiscal.inf.br/nfe" });
            Utf8StringWriter builder = new Utf8StringWriter();
            XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false, Indent = false };
            XmlWriter xmlWriter;

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "http://www.portalfiscal.inf.br/nfe");

            builder = new Utf8StringWriter();
            xmlWriter = XmlWriter.Create(builder, settings);

            serializer.Serialize(xmlWriter, notaEnviar.NfTnfe, namespaces);

            XmlDocument xmlNfe = new XmlDocument();
            xmlNfe.LoadXml(builder.ToString());

            notaEnviar.Xml = xmlNfe;
            nota.Xml = notaEnviar.Xml.InnerXml;

            nota.NfPrincipal.Save(ref command);
        }
    }
}
