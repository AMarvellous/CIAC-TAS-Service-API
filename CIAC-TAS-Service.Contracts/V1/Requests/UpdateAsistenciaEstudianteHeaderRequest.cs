using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class UpdateAsistenciaEstudianteHeaderRequest
    {
        public int ProgramaId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public int ModuloId { get; set; }
        public int InstructorId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int TotalHorasTeoricas { get; set; }
        public int TotalHorasPracticas { get; set; }
        public string Tema { get; set; }
        public bool IsLocked { get; set; }
        public int TipoAsistenciaEstudianteHeaderId { get; set; }
    }
}
