using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CIAC_TAS_Service.Domain.General
{
    public class Administrativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string LicenciaCarnetIdentidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? LugarNacimiento { get; set; }
        public string? Sexo { get; set; }
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
    }
}
