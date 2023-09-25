using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CIAC_TAS_Service.Domain.InstructorDomain;

namespace CIAC_TAS_Service.Domain.General
{
    public class ProgramaAnaliticoPdf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RutaPdf { get; set; }
        public int MateriaId { get; set; }
        public int Gestion { get; set; }

        public Materia Materia { get; set; }
        public IEnumerable<InstructorProgramaAnalitico> InstructorProgramaAnaliticos { get; set; }
    }
}
