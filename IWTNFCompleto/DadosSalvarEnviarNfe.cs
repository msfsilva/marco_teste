namespace IWTNFCompleto
{
    public class DadosSalvarEnviarNfe
    {
        public bool EnvioEmailHabilitado { get; set; }
        public bool EnvioEmailXmlHhabilitado { get; set; }
        public string EnvioEmailXmlDestino { get; set; }
        public bool EnvioEmailDanfeHabilitado { get; set; }
        public string EnvioEmailDanfeDestino { get; set; }
        public bool EnvioEmailClienteHabilitado { get; set; }
        public bool ImprimirDanfeHabilitado { get; set; }

        public string ImprimirDanfeImpressora1 { get; set; }
        public string ImprimirDanfeImpressora2 { get; set; }

        public bool SalvarPastaHabilitado { get; set; }
        public string SalvarPastaDanfe { get; set; }
        public string SalvarPastaXml { get; set; }

        public string EnvioEmailRemetente { get; set; }
    }
}