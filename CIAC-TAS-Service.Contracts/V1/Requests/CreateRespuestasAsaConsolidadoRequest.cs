using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreateRespuestasAsaConsolidadoRequest
    {
        public string UserId { get; set; }
        public int? ConfiguracionId { get; set; }
        public int NumeroPregunta { get; set; }
        public string PreguntaTexto { get; set; }
        public DateTime FechaLote { get; set; }
        public int? Opcion { get; set; }
        public string RespuestaTexto { get; set; }
        public bool RespuestaCorrecta { get; set; }
        public bool EsExamen { get; set; }
    }
}
