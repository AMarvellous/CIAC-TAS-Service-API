using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
	public class CreateExamenGeneradoRequest
	{
		public int GrupoId { get; set; }
		public Guid ExamenGeneradoGuid { get; set; }
		public DateTime Fecha { get; set; }
		public int NumeroPregunta { get; set; }
		public string PreguntaTexto { get; set; }
		public int NumeroOpcion { get; set; }
		public string OpcionTexto { get; set; }
	}
}
