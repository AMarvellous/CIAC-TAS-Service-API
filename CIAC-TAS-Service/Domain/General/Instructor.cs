using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain.InstructorDomain;

namespace CIAC_TAS_Service.Domain.General
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string NumeroLicencia { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoTas { get; set; }
        public string Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? Formacion { get; set; }
        public string? Cursos { get; set; }
        public string? ExperienciaLaboral { get; set; }
        public string? ExperienciaInstruccion { get; set; }
        public bool VacunaAntitetanica { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public IEnumerable<AsistenciaEstudianteHeader> AsistenciaEstudianteHeaders { get; set; }
        public IEnumerable<InstructorMateria> InstructorMaterias { get; set; }
        public IEnumerable<InstructorProgramaAnalitico> InstructorProgramaAnaliticos { get; set; }
    }
}
