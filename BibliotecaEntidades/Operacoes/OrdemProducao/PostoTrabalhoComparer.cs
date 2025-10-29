using System.Collections.Generic;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class PostoTrabalhoComparer : IComparer<OrdemProducaoPostoTrabalhoClass>
    {
        #region IComparer<OrdemProducaoPostoTrabalhoClass> Members

        public int Compare(OrdemProducaoPostoTrabalhoClass x, OrdemProducaoPostoTrabalhoClass y)
        {
            return x.Sequencia.CompareTo(y.Sequencia);
        }

        #endregion
    }
}