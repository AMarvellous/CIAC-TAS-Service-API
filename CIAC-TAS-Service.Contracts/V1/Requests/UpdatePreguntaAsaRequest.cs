using CIAC_TAS_Service.Contracts.V1.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class UpdatePreguntaAsaRequest
    {
        public int NumeroPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Ruta { get; set; }
        public int GrupoPreguntaAsaId { get; set; }
        public int EstadoPreguntaAsaId { get; set; }
    }
}
