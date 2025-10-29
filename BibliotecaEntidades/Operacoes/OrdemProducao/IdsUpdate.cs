using System.Collections.Generic;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    internal class IdsUpdate
    {
        public List<string> idsOrderItemEtiqueta;
        public List<string> idsOrdemProducaoDiferencaToUpdate;

        public IdsUpdate()
        {
            this.idsOrdemProducaoDiferencaToUpdate = new List<string>();
            this.idsOrderItemEtiqueta = new List<string>();
        }
    }
}