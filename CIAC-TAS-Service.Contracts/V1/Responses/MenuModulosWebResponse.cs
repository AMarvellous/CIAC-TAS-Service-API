using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class MenuModulosWebResponse
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string Nombre { get; set; }
        public string Estilo { get; set; }
        public ICollection<MenuSubModulosWebResponse> MenuSubModulosWebResponse { get; set; }
    }
}
