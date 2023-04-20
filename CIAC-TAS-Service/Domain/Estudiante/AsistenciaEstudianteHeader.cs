using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class AsistenciaEstudianteHeader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProgramaId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public int ModuloId { get; set; }
        public int InstructorId { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey(nameof(ProgramaId))]
        public Programa Programa { get; set; }

        [ForeignKey(nameof(GrupoId))]
        public Grupo Grupo { get; set; }

        [ForeignKey(nameof(MateriaId))]
        public Materia Materia { get;set; }

        [ForeignKey(nameof(ModuloId))]
        public Modulo Modulo { get; set; }

        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; }

        public virtual IEnumerable<AsistenciaEstudiante> AsistenciaEstudiantes { get; set; }
    }
}
