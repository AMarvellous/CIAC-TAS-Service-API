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
    public interface ICierreMateriaServiceApi
    {
        [Get("/" + CierreMaterias.GetAll)]
        Task<ApiResponse<PagedResponse<CierreMateriaResponse>>> GetAllAsync();

        [Get("/" + CierreMaterias.Get)]
        Task<ApiResponse<CierreMateriaResponse>> GetAsync(int cierreMateriaId);

        [Post("/" + CierreMaterias.Create)]
        Task<ApiResponse<CierreMateriaResponse>> CreateAsync([Body] CreateCierreMateriaRequest cierreMateriaRequest);

        //[Put("/" + CierreMaterias.Update)]
        //Task<ApiResponse<CierreMateriaResponse>> UpdateAsync(int cierreMateriaId, [Body] UpdateCierreMateriaRequest cierreMateriaRequest);

        [Delete("/" + CierreMaterias.Delete)]
        Task<ApiResponse<CierreMateriaResponse>> DeleteAsync(int cierreMateriaId);

        [Get("/" + CierreMaterias.GetByGrupoIdMateriaId)]
        Task<ApiResponse<CierreMateriaResponse>> GetByGrupoIdMateriaIdAsync(int grupoId, int materiaId);
    }
}
