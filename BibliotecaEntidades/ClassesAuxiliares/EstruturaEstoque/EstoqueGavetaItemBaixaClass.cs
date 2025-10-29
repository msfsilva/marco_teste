using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque
{
    public class  EstoqueGavetaItemBaixaClass
    {
        public EstoqueGavetaItemClass GavetaItem { get; private set; }
        public double QtdBaixada { get; private set; }

        public EstoqueGavetaItemBaixaClass(EstoqueGavetaItemClass gavetaItem, double qtdBaixada)
        {
            GavetaItem = gavetaItem;
            QtdBaixada = qtdBaixada;
        }
    }
}