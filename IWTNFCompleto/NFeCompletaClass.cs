using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Base;

namespace IWTNFCompleto
{
    public class NFeCompletaClass
    {
        public SituacaoNFe Situacao { get; set; }
        public TNFe Nfe { get { return this.NfeProc.NFe; } }
        public TNfeProc NfeProc{ get; set; }
    }
}
