using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class EstudianteGrupo
    {
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
