using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.ASA
{
    public class PreguntaAsa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NumeroPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Ruta { get; set; }
        public int GrupoPreguntaAsaId { get; set; }
        public int EstadoPreguntaAsaId { get; set; }

        // FK
        [ForeignKey(nameof(GrupoPreguntaAsaId))]
        public virtual GrupoPreguntaAsa GrupoPreguntaAsa { get; set; }
        [ForeignKey(nameof(EstadoPreguntaAsaId))]
        public virtual EstadoPreguntaAsa EstadoPreguntaAsa { get; set; }

        // Link to tables
        public virtual IEnumerable<PreguntaAsaOpcion> PreguntaAsaOpciones { get; set; }
        public virtual IEnumerable<PreguntaAsaImagenAsa> PreguntaAsaImagenAsas { get; set; }
    }
}
