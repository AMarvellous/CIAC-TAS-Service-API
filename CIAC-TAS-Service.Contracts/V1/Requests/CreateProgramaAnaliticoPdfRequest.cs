using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreateProgramaAnaliticoPdfRequest
    {
        public string RutaPdf { get; set; }
        public int MateriaId { get; set; }
        public int Gestion { get; set; }
    }
}
