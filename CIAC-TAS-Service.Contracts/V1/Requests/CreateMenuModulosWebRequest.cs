using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreateMenuModulosWebRequest
    {
        public string RoleId { get; set; }
        public string Nombre { get; set; }
        public string Estilo { get; set; }
    }
}
