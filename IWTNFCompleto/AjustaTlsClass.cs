using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace IWTNFCompleto
{
    public static class AjustaTlsClass
    {
        public static void Ajustar(TCodUfIBGELegado ufEmitente)
        {
            switch (ufEmitente)
            {
                case TCodUfIBGELegado.PR:
                case TCodUfIBGELegado.SP:
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    break;
                default:
                    //System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; ;
                    break;
            }
            
        }
    }
}
