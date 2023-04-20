using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class ModuloMateriaResponse
    {
        public int ModuloId { get; set; }
        public int MateriaId { get; set; }
        public ModuloResponse ModuloResponse { get; set; }
        public MateriaResponse MateriaResponse { get; set; }
    }
}
