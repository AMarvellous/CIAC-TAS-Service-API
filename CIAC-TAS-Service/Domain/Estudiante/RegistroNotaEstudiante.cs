using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class RegistroNotaEstudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RegistroNotaEstudianteHeaderId { get; set; }
        public double Nota { get; set; }
        public bool TipoDominio { get; set; }
        public bool AplicaRecuperatorio { get; set; }

        [ForeignKey(nameof(RegistroNotaEstudianteHeaderId))]
        public RegistroNotaEstudianteHeader RegistroNotaEstudianteHeader { get; set; }
    }
}
