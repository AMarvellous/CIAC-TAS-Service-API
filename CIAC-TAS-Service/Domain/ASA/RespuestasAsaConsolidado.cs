using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.ASA
{
    public class RespuestasAsaConsolidado
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid LoteRespuestasId { get; set; }
        public string UserId { get; set; }
        public int? ConfiguracionId { get; set; }
        //public int PreguntaAsaId { get; set; }
        public int NumeroPregunta { get; set; }
        public string PreguntaTexto { get; set; }
        public DateTime FechaLote { get; set; }
        //public int? OpcionSeleccionadaId { get; set; }
        public int? Opcion { get; set; }
        public string RespuestaTexto { get; set; }
        public bool RespuestaCorrecta { get; set; }
        public bool EsExamen { get; set; }


        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        [ForeignKey(nameof(ConfiguracionId))]
        public ConfiguracionPreguntaAsa ConfiguracionPreguntaAsa { get; set; }
    }
}
