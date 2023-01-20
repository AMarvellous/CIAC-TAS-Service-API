using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class UpdateEstudianteRequest
    {
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
    }
}
