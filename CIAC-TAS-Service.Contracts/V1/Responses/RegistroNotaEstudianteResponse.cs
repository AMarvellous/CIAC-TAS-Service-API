using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class RegistroNotaEstudianteResponse
    {
        public int Id { get; set; }
        public int RegistroNotaEstudianteHeaderId { get; set; }
        public double Nota { get; set; }
        public int TipoRegistroNotaEstudianteId { get; set; }

        public TipoRegistroNotaEstudianteResponse TipoRegistroNotaEstudiante { get; set; }
    }
}
