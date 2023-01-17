using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class EstudiantePrograma
    {
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int ProgramaId { get; set; }
        public Programa Programa { get; set; }
    }
}
