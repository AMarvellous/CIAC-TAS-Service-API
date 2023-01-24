using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class EstudianteGrupoService : IEstudianteGrupoService
    {
        private readonly DataContext _dataContext;

        public EstudianteGrupoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EstudianteGrupo>> GetEstudianteGruposAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.EstudianteGrupo.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<EstudianteGrupo> GetEstudianteGrupoByIdAsync(int estuadianteId, int grupoId)
        {
            return await _dataContext.EstudianteGrupo
                .SingleOrDefaultAsync(x => x.EstudianteId == estuadianteId && x.GrupoId == grupoId);
        }

        public async Task<bool> CreateEstudianteGrupoAsync(EstudianteGrupo estudianteGrupo)
        {
            var estudianteExists = await _dataContext.Estudiante.SingleOrDefaultAsync(x => x.Id == estudianteGrupo.EstudianteId);
            var grupoExists = await _dataContext.Grupo.SingleOrDefaultAsync(x => x.Id == estudianteGrupo.GrupoId);
            
            if (estudianteExists == null || grupoExists == null)
            {
                return false;
            }

            await _dataContext.EstudianteGrupo.AddAsync(estudianteGrupo);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteEstudianteGrupoAsync(int estuadianteId, int grupoId)
        {
            var estudianteGrupo = await GetEstudianteGrupoByIdAsync(estuadianteId, grupoId);

            if (estudianteGrupo == null)
            {
                return false;
            }

            _dataContext.EstudianteGrupo.Remove(estudianteGrupo);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
