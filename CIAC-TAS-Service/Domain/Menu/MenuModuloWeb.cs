using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.Menu
{
    public class MenuModuloWeb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string Nombre { get; set; }
        public string Estilo { get; set; }


        [ForeignKey(nameof(RoleId))]
        public IdentityRole Role { get; set; }
        public IEnumerable<MenuSubModuloWeb> MenuSubModulosWeb { get; set; }
    }
}
