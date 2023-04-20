using CIAC_TAS_Service.Domain.Estudiante;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.General
{
    public class Materia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MateriaCodigo { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<ModuloMateria> ModuloMaterias { get; set; }
        public IEnumerable<AsistenciaEstudianteHeader> AsistenciaEstudianteHeaders { get; set; }
    }
}
