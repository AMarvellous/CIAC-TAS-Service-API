using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.InstructorDomain
{
    public class InstructorMateria
    {
        public int InstructorId { get; set; }
        public int MateriaId { get; set; }
        public int GrupoId { get; set; }        
        

        public Instructor Instructor { get; set; }
        public Materia Materia { get; set; }
        public Grupo Grupo { get; set; }
    }
}
