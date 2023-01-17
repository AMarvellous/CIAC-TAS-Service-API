namespace CIAC_TAS_Service.Domain.ASA
{
    public class PreguntaAsaImagenAsa
    {
        public int PreguntaAsaId { get; set; }
        public PreguntaAsa PreguntaAsa { get; set; }
        public int ImagenAsaId { get; set; }
        public ImagenAsa ImagenAsa { get; set; }
    }
}
