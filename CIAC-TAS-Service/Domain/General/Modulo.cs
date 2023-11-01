using CIAC_TAS_Service.Domain.Estudiante;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.General
{
    public class Modulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ModuloCodigo { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<ModuloMateria> ModuloMaterias { get; set; }
        public IEnumerable<AsistenciaEstudianteHeader> AsistenciaEstudianteHeaders { get; set; }
        public IEnumerable<RegistroNotaHeader> RegistroNotaHeaders { get; set; }
    }
}
