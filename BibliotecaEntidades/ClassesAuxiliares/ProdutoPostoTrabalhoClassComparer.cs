using System.Collections.Generic;
using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public class ProdutoPostoTrabalhoClassComparer : IComparer<ProdutoPostoTrabalhoClass>
    {
        #region IComparer Members
        public int Compare(ProdutoPostoTrabalhoClass a, ProdutoPostoTrabalhoClass b)
        {
            return a.Sequencia.CompareTo(b.Sequencia);
        }
        #endregion
    }
}