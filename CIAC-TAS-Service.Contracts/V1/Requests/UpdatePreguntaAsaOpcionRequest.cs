using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class UpdatePreguntaAsaOpcionRequest
    {
        public int Opcion { get; set; }
        public string Texto { get; set; }
        public bool RespuestaValida { get; set; }
        public int PreguntaAsaId { get; set; }
    }
}
