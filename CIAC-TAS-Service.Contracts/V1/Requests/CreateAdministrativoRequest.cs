using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreateAdministrativoRequest
    {
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
        public string Email { get; set; }
        public string? Formacion { get; set; }
        public string? Cursos { get; set; }
        public string? ExperienciaLaboral { get; set; }
        public string? ExperienciaInstruccion { get; set; }
        public bool VacunaAntitetanica { get; set; }
    }
}
