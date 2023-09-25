using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreateInstructorProgramaAnaliticoRequest
    {
        public int InstructorId { get; set; }
        public int ProgramaAnaliticoPdfId { get; set; }
    }
}
