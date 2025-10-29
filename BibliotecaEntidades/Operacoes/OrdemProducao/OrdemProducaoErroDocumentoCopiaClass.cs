namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoErroDocumentoCopiaClass
    {
        public long IdDocumentoCopia { get; private set; }
        public string Copia { get; private set; }
        public string UltimoPostoPassagem { get; private set; }
        public long IdDocumentoTipoFamilia { get; private set; }

        public OrdemProducaoErroDocumentoCopiaClass(long idDocumentoCopia, string copia, string ultimoPostoPassagem, long idDocumentoTipoFamilia)
        {
            IdDocumentoCopia = idDocumentoCopia;
            Copia = copia;
            UltimoPostoPassagem = ultimoPostoPassagem;
            IdDocumentoTipoFamilia = idDocumentoTipoFamilia;
        }
    }
}