using CIAC_TAS_Service.Domain.Estudiante;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.General
{
    public class Programa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Link to tables
        public IEnumerable<EstudiantePrograma> EstudianteProgramas { get; set; }
    }
}
