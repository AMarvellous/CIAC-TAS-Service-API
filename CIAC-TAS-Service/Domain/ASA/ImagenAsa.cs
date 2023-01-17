using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.ASA
{
    public class ImagenAsa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Ruta { get; set; }

        // Link to table
        public IEnumerable<PreguntaAsaImagenAsa> PreguntaAsaImagenAsas { get; set; }
    }
}
