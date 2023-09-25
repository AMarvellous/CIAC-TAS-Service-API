using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class InstructorProgramaAnaliticoResponse
    {
        public int InstructorId { get; set; }
        public int ProgramaAnaliticoPdfId { get; set; }

        public InstructorResponse Instructor { get; set; }
        public ProgramaAnaliticoPdfResponse ProgramaAnaliticoPdf { get; set; }
    }
}
