using CIAC_TAS_Service.Contracts.V1.Requests;
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
    public interface IModuloMateriaServiceApi
    {
        [Get("/" + ModuloMaterias.GetAll)]
        Task<ApiResponse<PagedResponse<ModuloMateriaResponse>>> GetAllAsync();

        [Get("/" + ModuloMaterias.Get)]
        Task<ApiResponse<ModuloMateriaResponse>> GetAsync(int moduloId, int materiaId);

        [Post("/" + ModuloMaterias.Create)]
        Task<ApiResponse<ModuloMateriaResponse>> CreateAsync([Body] CreateModuloMateriaRequest moduloMateriaRequest);

        [Delete("/" + ModuloMaterias.Delete)]
        Task<ApiResponse<ModuloMateriaResponse>> DeleteAsync(int moduloId, int materiaId);

        [Get("/" + ModuloMaterias.GetModuloByMateria)]
        Task<ApiResponse<ModuloMateriaResponse>> GetModuloByMateriaAsync(int materiaId);
    }
}
