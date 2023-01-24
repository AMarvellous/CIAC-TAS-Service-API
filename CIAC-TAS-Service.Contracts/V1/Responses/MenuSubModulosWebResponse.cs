using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class MenuSubModulosWebResponse
    {
        public int Id { get; set; }
        public int ModuloId { get; set; }
        public string Nombre { get; set; }
        public string Pagina { get; set; }
        public string Estilo { get; set; }
    }
}
