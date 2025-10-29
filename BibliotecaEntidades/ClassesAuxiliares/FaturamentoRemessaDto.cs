using BibliotecaEntidades.Entidades;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public class FaturamentoRemessaDto
    {
        public OrdemProducaoClass OrdemProducao { get; set; }
        public double Quantidade { get; set; }
        public FornecedorClass Fornecedor { get; set; }
        public TransporteClass Transporte { get; set; }
        public OperacaoClass Operacao { get; set; }
        public OperacaoCompletaClass OperacaoCompleta { get; set; }

        public OrdemProducaoEnvioTerceirosClass OrdemProducaoEnvioTerceiros { get; set; }


    }
}