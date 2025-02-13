using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CIAC_TAS_Service.Domain.General;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class RegistroNotaHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProgramaId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public int ModuloId { get; set; }
        public int InstructorId { get; set; }
        public bool IsLocked { get; set; }
        public int PorcentajeProgresoTotal { get; set; }
        public int PorcentajeDominioTotal { get; set; }
        public int TipoRegistroNotaHeaderId { get; set; }


        [ForeignKey(nameof(ProgramaId))]
        public Programa Programa { get; set; }

        [ForeignKey(nameof(GrupoId))]
        public Grupo Grupo { get; set; }

        [ForeignKey(nameof(MateriaId))]
        public Materia Materia { get; set; }

        [ForeignKey(nameof(ModuloId))]
        public Modulo Modulo { get; set; }

        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; }

        [ForeignKey(nameof(TipoRegistroNotaHeaderId))]
        public TipoRegistroNotaHeader TipoRegistroNotaHeader { get; set; }

        public virtual IEnumerable<RegistroNotaEstudianteHeader> RegistroNotaEstudianteHeaders { get; set; }
    }
}
