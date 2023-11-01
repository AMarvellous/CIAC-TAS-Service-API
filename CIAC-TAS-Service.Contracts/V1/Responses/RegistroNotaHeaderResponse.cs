using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Contracts.V1.Responses
{
    public class RegistroNotaHeaderResponse
    {
        public int Id { get; set; }
        public int ProgramaId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public int ModuloId { get; set; }
        public int InstructorId { get; set; }
        public bool IsLocked { get; set; }
        public int PorcentajeProgresoTotal { get; set; }
        public int PorcentajeDominioTotal { get; set; }

        public ProgramaResponse Programa { get; set; }
        public GrupoResponse Grupo { get; set; }
        public MateriaResponse Materia { get; set; }
        public ModuloResponse Modulo { get; set; }
        public InstructorResponse Instructor { get; set; }
    }
}
