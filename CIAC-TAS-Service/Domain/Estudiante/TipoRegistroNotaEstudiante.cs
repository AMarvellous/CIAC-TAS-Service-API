using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class TipoRegistroNotaEstudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public IEnumerable<RegistroNotaEstudiante> RegistroNotaEstudiantes { get; set; }
    }
}
