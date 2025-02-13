using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class AsistenciaEstudianteHeaderResponse
    {
        public int Id { get; set; }
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
        public ProgramaResponse ProgramaResponse { get; set; }
        public GrupoResponse GrupoResponse { get; set; }
        public MateriaResponse MateriaResponse { get; set; }
        public ModuloResponse ModuloResponse { get; set; }
        public InstructorResponse InstructorResponse { get; set; }
        public TipoAsistenciaEstudianteHeaderResponse TipoAsistenciaEstudianteHeaderResponse { get; set; }
        public List<AsistenciaEstudianteResponse> AsistenciaEstudiantesResponse { get; set; }
    }
}
