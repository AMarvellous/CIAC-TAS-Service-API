using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class RegistroNotaHeaderService : IRegistroNotaHeaderService
    {
        private readonly DataContext _dataContext;

        public RegistroNotaHeaderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<RegistroNotaHeader>> GetRegistroNotaHeadersAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RegistroNotaHeader
                .Include(x => x.Programa)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .Include(x => x.Instructor)
                .Include(x => x.Modulo)
                .Include(x => x.RegistroNotaEstudianteHeaders)
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

        public async Task<RegistroNotaHeader> GetRegistroNotaHeaderByIdAsync(int id)
        {
            return await _dataContext.RegistroNotaHeader
                .Include(x => x.Programa)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .Include(x => x.Instructor)
                .Include(x => x.Modulo)
                .Include(x => x.RegistroNotaEstudianteHeaders)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateRegistroNotaHeaderAsync(RegistroNotaHeader registroNotaHeader)
        {
            await _dataContext.RegistroNotaHeader.AddAsync(registroNotaHeader);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateRegistroNotaHeaderAsync(RegistroNotaHeader registroNotaHeader)
        {
            _dataContext.RegistroNotaHeader.Update(registroNotaHeader);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteRegistroNotaHeaderAsync(int registroNotaHeaderId)
        {
            var registroNotaHeader = await GetRegistroNotaHeaderByIdAsync(registroNotaHeaderId);

            if (registroNotaHeader == null)
            {
                return false;
            }

            _dataContext.RegistroNotaHeader.Remove(registroNotaHeader);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<RegistroNotaHeader>> GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(int grupoId, int materiaId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RegistroNotaHeader
                .Where(x => x.GrupoId == grupoId && x.MateriaId == materiaId)
                .Include(x => x.Programa)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .Include(x => x.Instructor)
                .Include(x => x.Modulo)
                .Include(x => x.RegistroNotaEstudianteHeaders)
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

        public async Task<bool> CreateRegistroNotaEstudianteHeaderAsync(RegistroNotaHeader registroNotaHeader)
        {
            await _dataContext.RegistroNotaHeader.AddAsync(registroNotaHeader);
            var created = await _dataContext.SaveChangesAsync();

            if (created > 0)
            {
                var queryable = _dataContext.EstudianteMateria
                    .Where(x => x.MateriaId == registroNotaHeader.MateriaId && x.GrupoId == registroNotaHeader.GrupoId)
                    .AsNoTracking()
                    .AsQueryable();

                var estudianteMateria = await queryable.ToListAsync();
                IEnumerable<RegistroNotaEstudianteHeader> registroNotaEstudianteHeaders = estudianteMateria.Select(x => new RegistroNotaEstudianteHeader
                {
                    EstudianteId = x.EstudianteId,
                    RegistroNotaHeaderId = registroNotaHeader.Id
                });

                await _dataContext.RegistroNotaEstudianteHeader.AddRangeAsync(registroNotaEstudianteHeaders);
                await _dataContext.SaveChangesAsync();
            }
            
            return created > 0;
        }
    }
}
