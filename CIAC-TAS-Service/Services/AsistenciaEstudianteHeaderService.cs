using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class AsistenciaEstudianteHeaderService : IAsistenciaEstudianteHeaderService
    {
        private readonly DataContext _dataContext;

        public AsistenciaEstudianteHeaderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<AsistenciaEstudianteHeader>> GetAsistenciaEstudianteHeadersAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.AsistenciaEstudianteHeader
                .Include(x => x.Programa)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .Include(x => x.Modulo)
                .Include(x => x.Instructor)
                .Include(x => x.AsistenciaEstudiantes)
                .ThenInclude(x => x.Estudiante)
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

        public async Task<AsistenciaEstudianteHeader> GetAsistenciaEstudianteHeaderByIdAsync(int id)
        {
            return await _dataContext.AsistenciaEstudianteHeader
                .Include(x => x.Programa)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .Include(x => x.Modulo)
                .Include(x => x.Instructor)
                .Include(x => x.AsistenciaEstudiantes)
                .ThenInclude(x => x.Estudiante)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateAsistenciaEstudianteHeaderAsync(AsistenciaEstudianteHeader asistenciaEstudianteHeader)
        {
            await _dataContext.AsistenciaEstudianteHeader.AddAsync(asistenciaEstudianteHeader);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }
        public async Task<bool> UpdateAsistenciaEstudianteHeaderAsync(AsistenciaEstudianteHeader asistenciaEstudianteHeader)
        {
            _dataContext.AsistenciaEstudianteHeader.Update(asistenciaEstudianteHeader);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteAsistenciaEstudianteHeaderAsync(int asistenciaEstudianteHeaderId)
        {
            var asistenciaEstudianteHeader = await GetAsistenciaEstudianteHeaderByIdAsync(asistenciaEstudianteHeaderId);

            if (asistenciaEstudianteHeader == null)
            {
                return false;
            }

            _dataContext.AsistenciaEstudianteHeader.Remove(asistenciaEstudianteHeader);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
