using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class PreguntaAsaResponse
    {
        public int Id { get; set; }
        public int PreguntaAsaId { get; set; }
        public int NumeroPregunta { get; set; }
        public string Pregunta { get; set; }
        public int GrupoPreguntaAsaId { get; set; }
        public int EstadoPreguntaAsaId { get; set; }
    }
}
