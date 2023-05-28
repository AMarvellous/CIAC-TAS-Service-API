using CIAC_TAS_Service.Domain.General;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.Estudiante
{
    public class Estudiante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CarnetIdentidad { get; set; }
        public string CodigoTas { get; set; }
        public DateTime? Fecha { get; set; }
        public string Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? LugarNacimiento { get; set; } 
        public string? Sexo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? FamiliarTutor { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? NombrePadre { get; set; }
        public string? CelularPadre { get; set; }
        public string? NombreMadre { get; set; }
        public string? CelularMadre { get; set; }
        public string? NombreTutor { get; set; }
        public string? CelularTutor { get; set; }
        public bool VacunaAntitetanica { get; set; }
        public bool ExamenPsicofisiologico { get; set; }
        public string? CodigoSeguro { get; set; }
        public DateTime? FechaSeguro { get; set; }
        public bool InstruccionPrevia { get; set; }
        public bool ExperienciaPrevia { get; set; }

        // Link to tables
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public IEnumerable<EstudianteGrupo> EstudianteGrupos { get; set; }
        public IEnumerable<EstudiantePrograma> EstudianteProgramas { get; set; }
        public IEnumerable<AsistenciaEstudiante> AsistenciaEstudiantes { get; set; }
        public IEnumerable<EstudianteMateria> EstudianteMaterias { get; set; }
    }
}
