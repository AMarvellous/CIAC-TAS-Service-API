using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class CierreMateriaResponse
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }

        public GrupoResponse Grupo { get; set; }
        public MateriaResponse Materia { get; set; }
    }
}
