using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class AsistenciaEstudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public int AsistenciaEstudianteHeaderId { get; set; }

        [ForeignKey(nameof(EstudianteId))]
        public Estudiante Estudiante { get; set; }

        [ForeignKey(nameof(AsistenciaEstudianteHeaderId))]
        public AsistenciaEstudianteHeader AsistenciaEstudianteHeader { get; set; }
    }
}
