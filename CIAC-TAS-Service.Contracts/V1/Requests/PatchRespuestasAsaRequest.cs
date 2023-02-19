using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class PatchRespuestasAsaRequest
    {
        public int? OpcionSeleccionadaId { get; set; }
		public string? ColorInterfaz { get; set; }
	}
}
