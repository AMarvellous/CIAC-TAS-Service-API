using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class EstudianteProgramaService : IEstudianteProgramaService
    {
        private readonly DataContext _dataContext;

        public EstudianteProgramaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EstudiantePrograma>> GetEstudianteProgramasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.EstudiantePrograma.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<EstudiantePrograma> GetEstudianteProgramaByIdAsync(int estudianteId, int programaId)
        {
            return await _dataContext.EstudiantePrograma.SingleOrDefaultAsync(x => x.EstudianteId == estudianteId && x.ProgramaId == programaId);
        }

        public async Task<bool> CreateEstudianteProgramaAsync(EstudiantePrograma estudiantePrograma)
        {
            var estudianteExists = await _dataContext.Estudiante.SingleOrDefaultAsync(x => x.Id == estudiantePrograma.EstudianteId);
            var grupoExists = await _dataContext.Programa.SingleOrDefaultAsync(x => x.Id == estudiantePrograma.ProgramaId);

            if (estudianteExists == null || grupoExists == null)
            {
                return false;
            }

            await _dataContext.EstudiantePrograma.AddAsync(estudiantePrograma);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteEstudianteProgramaAsync(int estudianteId, int programaId)
        {
            var estudiantePrograma = await GetEstudianteProgramaByIdAsync(estudianteId, programaId);

            if (estudiantePrograma == null)
            {
                return false;
            }

            _dataContext.EstudiantePrograma.Remove(estudiantePrograma);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
