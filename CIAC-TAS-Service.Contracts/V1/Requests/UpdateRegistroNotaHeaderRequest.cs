using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class UpdateRegistroNotaHeaderRequest
    {
        public int ProgramaId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public int ModuloId { get; set; }
        public int InstructorId { get; set; }
        public bool IsLocked { get; set; }
        public int PorcentajeProgresoTotal { get; set; }
        public int PorcentajeDominioTotal { get; set; }
    }
}
