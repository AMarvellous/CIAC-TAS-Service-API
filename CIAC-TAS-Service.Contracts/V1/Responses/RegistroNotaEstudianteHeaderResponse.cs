using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class RegistroNotaEstudianteHeaderResponse
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int RegistroNotaHeaderId { get; set; }

        public EstudianteResponse Estudiante { get; set; }
        public RegistroNotaHeaderResponse RegistroNotaHeader { get; set; }
    }
}
