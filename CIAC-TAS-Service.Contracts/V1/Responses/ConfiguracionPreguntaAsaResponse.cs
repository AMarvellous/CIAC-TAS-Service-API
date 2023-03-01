using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class ConfiguracionPreguntaAsaResponse
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int CantitdadPreguntas { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFin { get; set; }

        public GrupoResponse GrupoResponse { get; set; }
    }
}
