using System.Xml;
using IWTNF.Entidades.Entidades;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace IWTNFCompleto
{
    public class NotaEnviar
    {
        public TNFe NfTnfe { get; set; }
        public XmlDocument Xml { get; set; }
        public NfPrincipalClass NfPrincipal { get; set; }


    }
}