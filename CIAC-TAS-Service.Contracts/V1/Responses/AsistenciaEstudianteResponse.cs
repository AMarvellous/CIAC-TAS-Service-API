using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class AsistenciaEstudianteResponse
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int AsistenciaEstudianteHeaderId { get; set; }
        public int TipoAsistenciaId { get; set; }

        public EstudianteResponse EstudianteResponse { get; set; }
        public TipoAsistenciaResponse TipoAsistenciaResponse { get; set; }
    }
}
