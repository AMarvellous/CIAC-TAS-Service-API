using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class ProgramaAnaliticoPdfResponse
    {
        public int Id { get; set; }
        public string RutaPdf { get; set; }
        public int MateriaId { get; set; }
        public int Gestion { get; set; }

        public MateriaResponse Materia { get; set; }
    }
}
