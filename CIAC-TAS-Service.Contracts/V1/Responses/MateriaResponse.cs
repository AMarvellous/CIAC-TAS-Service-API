using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class MateriaResponse
    {
        public int Id { get; set; }
        public string MateriaCodigo { get; set; }
        public string Nombre { get; set; }
    }
}
