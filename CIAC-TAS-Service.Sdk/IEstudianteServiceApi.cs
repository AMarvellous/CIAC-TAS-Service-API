﻿using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Sdk
{
    [Headers("Authorization: Bearer")]
    public interface IEstudianteServiceApi
    {
        [Get("/" + Estudiantes.GetAll)]
        Task<ApiResponse<PagedResponse<EstudianteResponse>>> GetAllAsync();

        [Get("/" + Estudiantes.Get)]
        Task<ApiResponse<EstudianteResponse>> GetAsync(int estudianteId);

        [Post("/" + Estudiantes.Create)]
        Task<ApiResponse<EstudianteResponse>> CreateAsync([Body] CreateEstudianteRequest estudianteRequest);

        [Put("/" + Estudiantes.Update)]
        Task<ApiResponse<EstudianteResponse>> UpdateAsync(int estudianteId, [Body] UpdateEstudianteRequest estudianteRequest);

        [Delete("/" + Estudiantes.Delete)]
        Task<ApiResponse<EstudianteResponse>> DeleteAsync(int estudianteId);

        [Get("/" + Estudiantes.GetByUserId)]
        Task<ApiResponse<EstudianteResponse>> GetByUserIdAsync(string userId);

        [Get("/" + Estudiantes.GetAllNotAssignedToGrupo)]
        Task<ApiResponse<PagedResponse<EstudianteResponse>>> GetAllNotAssignedToGrupoAsync(int grupoId);

        [Get("/" + Estudiantes.GetAllNotAssignedAsistenciaEstudiante)]
        Task<ApiResponse<PagedResponse<EstudianteResponse>>> GetAllNotAssignedAsistenciaEstudianteAsync(int materiaId, int grupoId, int asistenciaEstudianteHeaderId);

        [Get("/" + Estudiantes.GetAllNotAssignedToRegistroNotaEstudianteHeader)]
        Task<ApiResponse<PagedResponse<EstudianteResponse>>> GetAllNotAssignedToRegistroNotaEstudianteHeaderAsync(int registroNotaHeaderId);

        [Get("/" + Estudiantes.GetAllNotAssignedInhabilitacionEstudiante)]
        Task<ApiResponse<PagedResponse<EstudianteResponse>>> GetAllNotAssignedInhabilitacionEstudianteAsync();
    }
}
