using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;

namespace CIAC_TAS_Service.Services
{
    public interface IImagenAsaService
    {
        Task<List<ImagenAsa>> GetImagenAsasAsync(PaginationFilter paginationFilter = null);
        Task<bool> CreateImagenAsaAsync(ImagenAsa imagenAsa);
        Task<ImagenAsa> GetImagenAsaByIdAsync(int id);
        Task<bool> UpdateImagenAsaAsync(ImagenAsa imagenAsa);
        Task<bool> DeleteImagenAsaAsync(int id);
        Task<bool> CheckExistsImagenAsaAsync(int imagenAsaId);
    }
}
