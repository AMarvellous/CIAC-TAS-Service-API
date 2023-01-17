using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.Menu
{
    public class MenuSubModuloWeb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ModuloId { get; set; }
        public string Nombre { get; set; }
        public string Pagina { get; set; }
        public string Estilo { get; set; }

        [ForeignKey(nameof(ModuloId))]
        public MenuModuloWeb MenuModuloWeb { get; set; }
    }
}
