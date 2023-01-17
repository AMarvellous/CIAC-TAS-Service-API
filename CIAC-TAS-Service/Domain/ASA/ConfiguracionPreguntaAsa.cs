using CIAC_TAS_Service.Domain.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.ASA
{
    public class ConfiguracionPreguntaAsa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int CantitdadPreguntas { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFin { get; set; }

        // FK
        [ForeignKey(nameof(GrupoId))]
        public Grupo Grupo { get; set; }
    }
}
