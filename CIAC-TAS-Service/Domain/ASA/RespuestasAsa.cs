using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.ASA
{
    public class RespuestasAsa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? ConfiguracionId { get; set; }
        public int PreguntaAsaId { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int? OpcionSeleccionadaId { get; set; }
        public bool EsExamen { get; set; }
		public string? ColorInterfaz { get; set; }


		[ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        [ForeignKey(nameof(ConfiguracionId))]
        public ConfiguracionPreguntaAsa ConfiguracionPreguntaAsa { get; set; }
        [ForeignKey(nameof(PreguntaAsaId))]
        public PreguntaAsa PreguntaAsa { get; set; }
        [ForeignKey(nameof(OpcionSeleccionadaId))]
        public PreguntaAsaOpcion PreguntaAsaOpcionSeleccionada { get; set; }
    }
}
