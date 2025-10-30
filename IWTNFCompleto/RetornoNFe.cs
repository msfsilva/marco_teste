using IWTNFCompleto.BibliotecaDatasets;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using IWTNFCompleto.BibliotecaEntidades;
using IWTNFCompleto.BibliotecaEntidades.Base;
using IWTNFCompleto.BibliotecaEntidades.Entidades;

namespace IWTNFCompleto
{
    public class RetornoNFe
    {
        public TNFe NotaFiscal { get; set; }
        public TNfeProc NFeProc { get; set; }
        public SituacaoNFe situacao { get; set; }
        public string codigoRetorno { get; set; }
        public string observacaoRetorno { get; set; }
        public NfeCompletoNotaClass NFeEmitida { get; set; }
    }
}