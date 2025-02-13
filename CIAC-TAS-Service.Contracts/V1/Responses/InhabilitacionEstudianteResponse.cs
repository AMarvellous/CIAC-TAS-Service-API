using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class InhabilitacionEstudianteResponse
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public string Motivo { get; set; }

        public EstudianteResponse Estudiante { get; set; }
    }
}
