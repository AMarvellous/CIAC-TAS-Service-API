using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class RegistroNotaEstudianteHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int RegistroNotaHeaderId { get; set; }

        [ForeignKey(nameof(EstudianteId))]
        public Estudiante Estudiante { get; set; }

        [ForeignKey(nameof(RegistroNotaHeaderId))]
        public RegistroNotaHeader RegistroNotaHeader { get; set; }

        public virtual IEnumerable<RegistroNotaEstudiante> RegistroNotaEstudiantes { get; set; }
    }
}
