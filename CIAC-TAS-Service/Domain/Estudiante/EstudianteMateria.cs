using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class EstudianteMateria
    {
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public bool InscritoTutorial { get; set; }
    }
}
