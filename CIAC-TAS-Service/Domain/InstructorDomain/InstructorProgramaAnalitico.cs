using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.InstructorDomain
{
    public class InstructorProgramaAnalitico
    {
        public int InstructorId { get; set; }
        public int ProgramaAnaliticoPdfId { get; set; }

        public Instructor Instructor { get; set; }
        public ProgramaAnaliticoPdf ProgramaAnaliticoPdf { get; set; }
    }
}
