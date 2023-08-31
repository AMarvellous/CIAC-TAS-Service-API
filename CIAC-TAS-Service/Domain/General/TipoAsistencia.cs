using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;

namespace CIAC_TAS_Service.Domain.General
{
    public class TipoAsistencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }


        public IEnumerable<AsistenciaEstudiante> AsistenciaEstudiantes { get; set; }
    }
}
