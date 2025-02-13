﻿using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain.InstructorDomain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAC_TAS_Service.Domain.General
{
    public class Grupo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Link to table
        public IEnumerable<EstudianteGrupo> EstudianteGrupos { get; set; }
        public IEnumerable<ConfiguracionPreguntaAsa> ConfiguracionPreguntaAsa { get; set; }
        public IEnumerable<ExamenGenerado> ExamenGenerado { get; set; }
        public IEnumerable<AsistenciaEstudianteHeader> AsistenciaEstudianteHeaders { get; set; }
        public IEnumerable<EstudianteMateria> EstudianteMaterias { get; set; }
        public IEnumerable<InstructorMateria> InstructorMaterias { get; set; }
        public IEnumerable<RegistroNotaHeader> RegistroNotaHeaders { get; set; }
        public IEnumerable<CierreMateria> CierreMaterias { get; set; }
    }
}
