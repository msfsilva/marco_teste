using System;

namespace BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque
{
    [Serializable()]

    public enum TipoConteudoEstoque
    {
        Produto,
        Material,
        Documento,
        Recurso,
        Epi,
        AgrupadorProdutoSemelhante,
        SemConteudo
    }
}