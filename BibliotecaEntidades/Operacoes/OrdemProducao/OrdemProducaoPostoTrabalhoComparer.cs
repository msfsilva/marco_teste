using System.Collections.Generic;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoPostoTrabalhoComparer : IComparer<OrdemProducaoPostoTrabalhoClass>
    {
        #region IComparer<OrdemProducaoPostoTrabalhoComparer> Members

        public int Compare(OrdemProducaoPostoTrabalhoClass x, OrdemProducaoPostoTrabalhoClass y)
        {
            return x.Sequencia.CompareTo(y.Sequencia);
        }

        #endregion
    }
}