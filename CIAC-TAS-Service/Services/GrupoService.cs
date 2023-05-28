using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.General;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class GrupoService : IGrupoService
    {
        private readonly DataContext _dataContext;

        public GrupoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Grupo>> GetGruposAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Grupo.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            // https://learn.microsoft.com/en-us/ef/ef6/querying/related-data?redirectedfrom=MSDN
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Grupo> GetGrupoByIdAsync(int id)
        {
            return await _dataContext.Grupo.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateGrupoAsync(Grupo grupo)
        {
            await _dataContext.Grupo.AddAsync(grupo);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateGrupoAsync(Grupo grupo)
        {
            _dataContext.Grupo.Update(grupo);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteGrupoAsync(int grupoId)
        {
            var grupo = await GetGrupoByIdAsync(grupoId);

            if (grupo == null)
            {
                return false;
            }

            _dataContext.Grupo.Remove(grupo);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

		public async Task<bool> CheckGrupoExistsAsync(int id)
		{
			return await _dataContext.Grupo.SingleOrDefaultAsync(x => x.Id == id) != null;
		}

		public async Task<List<Grupo>> GetGruposNotAssignedEstudentsAsync(PaginationFilter paginationFilter = null)
		{
			var queryable = _dataContext.Grupo
                .Where(g => !_dataContext.EstudianteGrupo
                    .Select(eg => eg.GrupoId)
                    .Contains(g.Id)
                )
                .AsQueryable();

			if (paginationFilter == null)
			{
				return await queryable.ToListAsync();
			}

			var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
			return await queryable.Skip(skip)
				.Take(paginationFilter.PageSize)
				.ToListAsync();
		}
	}
}
