using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class ModuloResponse
    {
        public int Id { get; set; }
        public string ModuloCodigo { get; set; }
        public string Nombre { get; set; }
    }
}
