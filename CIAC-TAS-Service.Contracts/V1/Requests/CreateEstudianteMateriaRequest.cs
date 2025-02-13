﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAC_TAS_Service.Contracts.V1.Requests
{
    public class CreateEstudianteMateriaRequest
    {
        public int EstudianteId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public bool InscritoTutorial { get; set; }
    }
}
