using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.ASA
{
    public class PreguntaAsaOpcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Opcion { get; set; }
        public string Texto { get; set; }
        public bool RespuestaValida { get; set; }
        public int PreguntaAsaId { get; set; }

        [ForeignKey(nameof(PreguntaAsaId))]
        public virtual PreguntaAsa PreguntaAsa { get; set; }
    }
}
