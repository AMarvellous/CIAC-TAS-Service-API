using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Services
{
    public class EstudianteMateriaService : IEstudianteMateriaService
    {
        private readonly DataContext _dataContext;

        public EstudianteMateriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<EstudianteMateria>> GetEstudianteMateriasAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.EstudianteMateria.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<EstudianteMateria> GetEstudianteMateriaByIdAsync(int estudianteId, int grupoId, int materiaId)
        {
            return await _dataContext.EstudianteMateria
                .SingleOrDefaultAsync(x => x.EstudianteId == estudianteId && x.GrupoId == grupoId && x.MateriaId == materiaId);
        }

        public async Task<bool> CreateEstudianteMateriaAsync(EstudianteMateria estudianteMateria)
        {
            await _dataContext.EstudianteMateria.AddAsync(estudianteMateria);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> DeleteEstudianteMateriaAsync(int estudianteId, int grupoId, int materiaId)
        {
            var estudianteMateria = await GetEstudianteMateriaByIdAsync(estudianteId, grupoId, materiaId);

            if (estudianteMateria == null)
            {
                return false;
            }

            _dataContext.EstudianteMateria.Remove(estudianteMateria);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<List<EstudianteMateria>> GetAllByEstudianteGrupoAsync(int estudianteId, int grupoId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.EstudianteMateria
                .Where(x => x.EstudianteId == estudianteId && x.GrupoId == grupoId)
                .Include(x => x.Estudiante)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
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

        public async Task<bool> CreateAsignAllMaterias(int estudianteId, int grupoId)
        {
            List<EstudianteMateria> estudianteMaterias = new List<EstudianteMateria>();
            var materias = await _dataContext.Materia
                .Where(g => !_dataContext.EstudianteMateria
                    .Where(x => x.EstudianteId == estudianteId && x.GrupoId == grupoId)
                    .Select(eg => eg.MateriaId)
                        .Contains(g.Id)
                ).ToListAsync();

            materias.ForEach(materia => estudianteMaterias.Add(new EstudianteMateria
            {
                EstudianteId = estudianteId,
                GrupoId = grupoId,
                MateriaId = materia.Id
            }));

            await _dataContext.EstudianteMateria.AddRangeAsync(estudianteMaterias);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<List<EstudianteMateria>> GetAllByMateriaGrupoAsync(int materiaId, int grupoId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.EstudianteMateria
                .Where(x => x.MateriaId == materiaId && x.GrupoId == grupoId)
                .Include(x => x.Estudiante)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
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

        public async Task<List<EstudianteMateria>> GetAllByEstudianteIdAsync(int estudianteId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.EstudianteMateria
                .Where(x => x.EstudianteId == estudianteId)
                .Include(x => x.Estudiante)
                .Include(x => x.Grupo)
                .Include(x => x.Materia)
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
