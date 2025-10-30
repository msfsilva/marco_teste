using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using iTextSharp.text.pdf;
using IWTDotNetLib;
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using ItemChoiceType = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.ItemChoiceType;
using TEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TEvento;
using TEventoInfEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TEventoInfEvento;
using TEventoInfEventoDetEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TEventoInfEventoDetEvento;
using TProcEvento = IWTNFCompleto.BibliotecaDatasets.Eventos.Evento_CCe_PL_v101.TProcEvento;

namespace IWTNFCompleto
{
    public  class CartaCorrecaoNFeReportClass
    {
        public byte[] EmitenteLogo { get; private set;}
        public string EmitenteRazao { get; private set;}
        public string EmitenteEndereco { get; private set;}
        public string EmitenteEndereco2 { get; private set;}
        public string EmitenteFone { get; private set;}
        public string EmitenteIe { get; private set;}
        public string EmitenteCNPJ { get; private set;}

        public string DestinatarioRazao { get; private set;}
        public string DestinatarioCNPJ { get; private set;}
        public string DestinatarioEndereco { get; private set;}
        public string DestinatarioBairro { get; private set;}
        public string DestinatarioCep { get; private set;}
        public string DestinatarioCidade { get; private set;}
        public string DestinatarioFone { get; private set;}
        public string DestinatarioUF { get; private set;}
        public string DestinatarioIe { get; private set;}

        public string NFeNumero { get; private set;}
        public string NFeSerie { get; private set;}
        public string NFeChaveAcesso { get; private set;}
        public byte[] NFeBarcode { get; private set;}
        public DateTime NFeEmissao { get; private set;}

        public string CCeStatus { get; private set;}
        public string CCeProtocolo { get; private set;}
        public DateTime CCeDataRegistro { get; private set;}
        public string CCeCondicoes { get; private set;}
        public string CCeCorrecao { get; private set;}

        public int CCeId { get; private set;}



        public static List<CartaCorrecaoNFeReportClass> Gerar(List<NfeCompletoNotaClass> notas, byte[] logoEmitente)
        {
            
            
            try
            {
                if (logoEmitente != null)
                {
                    byte[] tmp = logoEmitente;
                    MemoryStream ms = new MemoryStream(tmp);
                    Image imagem = Image.FromStream(ms);

                    imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 200, 200, false);

                    ms = new MemoryStream();
                    imagem.Save(ms, ImageFormat.Bmp);
                    tmp = ms.ToArray();

                    logoEmitente = tmp;
                }

                List<CartaCorrecaoNFeReportClass> toRet = new List<CartaCorrecaoNFeReportClass>();

                foreach (NfeCompletoNotaClass nota in notas)
                {
                    if (nota.CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota.Count == 0)
                    {
                        throw new ExcecaoTratada("A nota fiscal " + nota.ToString() + " não possui nenhuma carta de correção vinculada");
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(TProcEvento));
                    TProcEvento xmlCCe;


                    foreach (NfeCompletoCartaCorrecaoClass cartaCorrecao in nota.CollectionNfeCompletoCartaCorrecaoClassNfeCompletoNota)
                    {
                        using (TextReader reader = new StringReader(cartaCorrecao.Xml))
                        {
                            xmlCCe = (TProcEvento)serializer.Deserialize(reader);
                        }


                        byte[] barcodeNota;

                        string chaveAcesso = nota.Chave;
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
                        barcodeNota = (byte[])converter.ConvertTo(codeBar, typeof(byte[]));


                        string cnpjEmitente = "";
                        if (nota.NfPrincipal.NfEmitente.CnpjCpf.Length == 14)
                        {
                            cnpjEmitente = nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(0, 2) + "." + nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(2, 3) + "." + nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(5, 3) + "/" + nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(8, 4) + "-" + nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(12, 2);
                        }

                        if (nota.NfPrincipal.NfEmitente.CnpjCpf.Length == 11)
                        {
                            cnpjEmitente = nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(0, 3) + "." + nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(3, 3) + "." + nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(6, 3) + "-" + nota.NfPrincipal.NfEmitente.CnpjCpf.Substring(9, 2);
                        }

                        string enderecoDestinatario = nota.NfPrincipal.NfCliente.NfClienteEndereco.Logradouro + ", " + nota.NfPrincipal.NfCliente.NfClienteEndereco.Numero + " " + nota.NfPrincipal.NfCliente.NfClienteEndereco.Complemento;
                        string enderecoEmitente1 = nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.Logradouro + ", "+ nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.Numero+ " "+ nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.Complemento;
                        string enderecoEmitente2 = nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.Bairro + "  " + nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.NomeMunicipio + "-" + nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.SiglaUf + " CEP " + nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.Cep;

                        
                        toRet.Add(new CartaCorrecaoNFeReportClass()
                        {
                            CCeCondicoes = xmlCCe.evento.infEvento.detEvento.xCondUso.GetXmlEnumAttributeValueFromEnum(),
                            CCeCorrecao = xmlCCe.evento.infEvento.detEvento.xCorrecao,
                            CCeDataRegistro = DateTime.Parse(xmlCCe.retEvento.infEvento.dhRegEvento,CultureInfo.InvariantCulture),
                            CCeId = (int)cartaCorrecao.ID,
                            CCeProtocolo = xmlCCe.retEvento.infEvento.nProt,
                            CCeStatus = xmlCCe.retEvento.infEvento.xMotivo,
                            NFeNumero = nota.Numero.ToString(CultureInfo.InvariantCulture),
                            NFeChaveAcesso = nota.Chave,
                            NFeEmissao = nota.DataEmissao,
                            NFeSerie = nota.Serie.ToString(CultureInfo.InvariantCulture),
                            NFeBarcode = barcodeNota,
                            DestinatarioBairro = nota.NfPrincipal.NfCliente.NfClienteEndereco.Bairro,
                            DestinatarioCNPJ = nota.NfPrincipal.NfCliente.CnpjCpf,
                            DestinatarioCep = nota.NfPrincipal.NfCliente.NfClienteEndereco.Cep,
                            DestinatarioCidade = nota.NfPrincipal.NfCliente.NfClienteEndereco.NomeMunicipio,
                            DestinatarioEndereco = enderecoDestinatario,
                            DestinatarioFone = nota.NfPrincipal.NfCliente.NfClienteEndereco.Telefone,
                            DestinatarioIe = nota.NfPrincipal.NfCliente.Ie,
                            DestinatarioRazao = nota.NfPrincipal.NfCliente.Razao,
                            DestinatarioUF = nota.NfPrincipal.NfCliente.NfClienteEndereco.SiglaUf,
                            EmitenteCNPJ = cnpjEmitente,
                            EmitenteEndereco = enderecoEmitente1,
                            EmitenteEndereco2 = enderecoEmitente2,
                            EmitenteFone = nota.NfPrincipal.NfEmitente.NfEmitenteEndereco.Telefone,
                            EmitenteIe = nota.NfPrincipal.NfEmitente.Ie,
                            EmitenteLogo = logoEmitente,
                            EmitenteRazao = nota.NfPrincipal.NfEmitente.Razao
                        });

                    }

                   

                }
                return toRet;
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar a impressão da carta de correção das notas selecionadas:" + e.Message, e);
            }
        }
    }
}
