﻿using CIAC_TAS_Service.Contracts.V1.Requests.Queries;

namespace CIAC_TAS_Service.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);

        Uri GetAllPostUri(PaginationQuery pagination = null);

        Uri GetGrupoUri(string grupoId);

        Uri GetGrupoPreguntaAsaUri(string grupoPreguntaAsaId);
        Uri GetProgramaUri(string programaId);
        Uri GetImagenAsaUri(string imagenAsaId);
        Uri GetEstadoPreguntaAsaUri(string estadoPreguntaAsaId);
        Uri GetConfiguracionPreguntaAsaUri(string configuracionPreguntaAsaId);
        Uri GetEstudianteUri(string estudianteId);
        Uri GetEstudianteGrupoUri(string estudianteId, string grupoId);
        Uri GetEstudianteProgramaUri(string estudianteId, string programaId);
        Uri GetMenuModulosWebUri(string menuModulosWebId);
        Uri GetMenuSubModulosWebUri(string menuSubModulosWebId);
        Uri GetPreguntaAsaUri(string preguntaAsaId);
        Uri GetPreguntaAsaImagenAsaUri(string preguntaAsaId, string imagenAsaId);
        Uri GetPreguntaAsaOpcionUri(string preguntaAsaOpcionId);
        Uri GetRespuestasAsaUri(string respuestasAsaId);
        Uri GetRespuestasAsaConsolidadoUri(string userId);
		Uri GetExamenGeneradoUri(string examenGeneradoId);
        Uri GetInstructorUri(string instructorId);
        Uri GetAdministrativoUri(string administrativoId);
        Uri GetMateriaUri(string materiaId);
        Uri GetModuloUri(string moduloId);
        Uri GetModuloMateriaUri(string moduloId, string materiaId);
        Uri GetAsistenciaEstudianteHeaderUri(string asistenciaEstudianteHeaderId);
        Uri GetAsistenciaEstudianteUri(string asistenciaEstudianteId);
        Uri GetEstudianteMateriaUri(string estudianteId, string grupoId,string materiaId);
        Uri GetTipoAsistenciaUri(string tipoAsistenciaId);
        Uri GetProgramaAnaliticoPdfUri(string programaAnaliticoPdfId);
        Uri GetInstructorMateriaUri(string instructorId, string materiaId, string grupoId);
        Uri GetInstructorProgramaAnaliticoUri(string instructorId, string programaAnaliticoId);
        Uri GetRegistroNotaHeaderUri(string registroNotaHeaderId);
        Uri GetRegistroNotaEstudianteHeaderUri(string registroNotaEstudianteHeaderId);
        Uri GetRegistroNotaEstudianteUri(string registroNotaEstudianteId);
        Uri GetTipoRegistroNotaEstudianteUri(string tipoRegistroNotaEstudianteId);
        Uri GetTipoRegistroNotaHeaderUri(string tipoRegistroNotaHeaderId);
        Uri GetInhabilitacionEstudianteUri(string inhabilitacionEstudianteId);
        Uri GetCierreMateriaUri(string cierreMateriaId);
        Uri GetTipoAsistenciaEstudianteHeaderUri(string tipoAsistenciaEstudianteHeaderId);
    }
}
