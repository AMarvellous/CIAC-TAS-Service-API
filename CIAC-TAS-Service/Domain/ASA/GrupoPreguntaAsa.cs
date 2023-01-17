using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.ASA
{
    public class GrupoPreguntaAsa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Grupo { get; set; }

        // Link to table
        public PreguntaAsa PreguntaAsa { get; set; }
    }
}
