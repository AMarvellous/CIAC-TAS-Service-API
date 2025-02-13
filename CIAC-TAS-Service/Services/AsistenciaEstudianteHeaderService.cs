using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

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
                .Include(x => x.TipoAsistenciaEstudianteHeader)
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
                .Include(x => x.AsistenciaEstudiantes)
                .ThenInclude(x => x.TipoAsistencia)
                .Include(x => x.TipoAsistenciaEstudianteHeader)
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

        public async Task<List<AsistenciaEstudianteHeader>> GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(int grupoId, int materiaId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.AsistenciaEstudianteHeader
                .Where(x => x.GrupoId == grupoId && x.MateriaId == materiaId)
                .Include(x => x.Programa)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .Include(x => x.Modulo)
                .Include(x => x.Instructor)
                .Include(x => x.AsistenciaEstudiantes)
                .ThenInclude(x => x.Estudiante)
                .Include(x => x.AsistenciaEstudiantes)
                .ThenInclude(x => x.TipoAsistencia)
                .Include(x => x.TipoAsistenciaEstudianteHeader)
                .OrderBy(x => x.Fecha)
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

        public async Task<List<AsistenciaEstudianteHeader>> GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdEstudianteIdAsync(int grupoId, int materiaId, int estudianteId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.AsistenciaEstudianteHeader
                .Where(x => x.GrupoId == grupoId && x.MateriaId == materiaId)
                .Include(x => x.Programa)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
                .Include(x => x.Modulo)
                .Include(x => x.Instructor)
                .Include(x => x.AsistenciaEstudiantes.Where(e => e.EstudianteId == estudianteId))
                .ThenInclude(x => x.Estudiante)
                .Include(x => x.AsistenciaEstudiantes)
                .ThenInclude(x => x.TipoAsistencia)
                .Include(x => x.TipoAsistenciaEstudianteHeader)
                .OrderBy(x => x.Fecha)
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

        public async Task<bool> UpdateAsistenciaEstudianteHeaderLockAsync(int grupoId, int materiaId, bool isLocked)
        {
            var asistenciaEstudianteHeaders = await _dataContext.AsistenciaEstudianteHeader
                .Where(x => x.GrupoId == grupoId && x.MateriaId == materiaId)
                .ToListAsync();

            asistenciaEstudianteHeaders.ForEach(asistenciaEstudianteHeader => asistenciaEstudianteHeader.IsLocked = isLocked);

            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }
    }
}
