namespace BibliotecaExpedicao
{
    public class OcConferenciaVolumeClass
    {
        public long IdOrderItemEtiquetaConferenciaVolumes { get; private set; }
        public int NumeroVolume { get; private set; }
        public bool Conferido { get; set; }

        public OcConferenciaVolumeClass(long idOrderItemEtiquetaConferenciaVolumes, int numeroVolume)
        {
            this.IdOrderItemEtiquetaConferenciaVolumes = idOrderItemEtiquetaConferenciaVolumes;
            this.NumeroVolume = numeroVolume;
            Conferido = false;
        }
    }
}