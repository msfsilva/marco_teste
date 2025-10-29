namespace BibliotecaTributos
{
    public class PisCofinsInfo
    {
        public string PisCST { private set; get; }
        public int PisImpostoRetido { private set; get; }
        public int PisModalidadeTributacao { private set; get; }
        public double PisAliquota { private set; get; }

        public string CofinsCST { private set; get; }
        public int CofinsImpostoRetido { private set; get; }
        public int CofinsModalidadeTributacao { private set; get; }
        public double CofinsAliquota { private set; get; }

        public PisCofinsInfo(string PisCST, int PisImpostoRetido, int PisModalidadeTributacao, double PisAliquota,
                             string CofinsCST, int CofinsImpostoRetido, int CofinsModalidadeTributacao, double CofinsAliquota)
        {
            this.PisAliquota = PisAliquota;
            this.PisCST = PisCST;
            this.PisImpostoRetido = PisImpostoRetido;
            this.PisModalidadeTributacao = PisModalidadeTributacao;

            this.CofinsAliquota = CofinsAliquota;
            this.CofinsCST = CofinsCST;
            this.CofinsImpostoRetido = CofinsImpostoRetido;
            this.CofinsModalidadeTributacao = CofinsModalidadeTributacao;

        }

    }
}