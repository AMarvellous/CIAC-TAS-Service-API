using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class InstructorMateriaResponse
    {
        public int InstructorId { get; set; }
        public int MateriaId { get; set; }
        public int GrupoId { get; set; }

        public InstructorResponse Instructor { get; set; }
        public MateriaResponse Materia { get; set; }
        public GrupoResponse Grupo { get; set; }
    }
}
