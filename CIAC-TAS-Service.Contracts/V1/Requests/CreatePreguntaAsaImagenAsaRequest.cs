﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreatePreguntaAsaImagenAsaRequest
    {
        public int PreguntaAsaId { get; set; }
        public int ImagenAsaId { get; set; }
    }
}
