using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class ImagenAsaService : IImagenAsaService
    {
        private readonly DataContext _dataContext;

        public ImagenAsaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ImagenAsa>> GetImagenAsasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.ImagenAsa.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<ImagenAsa> GetImagenAsaByIdAsync(int id)
        {
            return await _dataContext.ImagenAsa.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateImagenAsaAsync(ImagenAsa imagenAsa)
        {
            await _dataContext.ImagenAsa.AddAsync(imagenAsa);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateImagenAsaAsync(ImagenAsa imagenAsa)
        {
            _dataContext.ImagenAsa.Update(imagenAsa);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteImagenAsaAsync(int imagenAsaId)
        {
            var imagenAsa = await GetImagenAsaByIdAsync(imagenAsaId);

            if (imagenAsa == null)
            {
                return false;
            }

            _dataContext.ImagenAsa.Remove(imagenAsa);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckExistsImagenAsaAsync(int imagenAsaId)
        {
            return await _dataContext.ImagenAsa.SingleOrDefaultAsync(x => x.Id == imagenAsaId) != null;
        }
    }
}
