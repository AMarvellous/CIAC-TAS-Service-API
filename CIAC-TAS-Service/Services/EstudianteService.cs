using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<IdentityUser> _userManager;

        public EstudianteService(DataContext dataContext, UserManager<IdentityUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task<List<Estudiante>> GetEstudiantesAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Estudiante.AsQueryable();

            if (paginationFilter == null)
            {
                return await queryable.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await queryable.Skip(skip)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Estudiante> GetEstudianteByIdAsync(int id)
        {
            return await _dataContext.Estudiante.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> CreateEstudianteAsync(Estudiante estudiante)
        {
            //estudiante.EstudianteProgramas = new List<EstudiantePrograma>()
            //{
            //    new EstudiantePrograma { ProgramaId = 1 }
            //};
            var estudianteResponse = await _dataContext.Estudiante.AddAsync(estudiante);
            
            var created = await _dataContext.SaveChangesAsync();

            if (created > 0)
            {
				await _dataContext.EstudiantePrograma.AddAsync(new EstudiantePrograma
				{
					EstudianteId = estudiante.Id,
					ProgramaId = 1 // Programa = TMA
				}); //Hardcoding this, just chang if we got another programa
				created = await _dataContext.SaveChangesAsync();
			}
			

			return created > 0;
        }
        public async Task<bool> UpdateEstudianteAsync(Estudiante estudiante)
        {
            _dataContext.Estudiante.Update(estudiante);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteEstudianteAsync(int estudianteId)
        {
            var estudiante = await GetEstudianteByIdAsync(estudianteId);

            if (estudiante == null)
            {
                return false;
            }

            _dataContext.Estudiante.Remove(estudiante);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> CheckUserIdIsAssignedAsync(string userId)
        {
            var user = await _dataContext.Estudiante.AsNoTracking()
                .SingleOrDefaultAsync(x => x.UserId == userId);

            return user != null;
        }

        public async Task<bool> CheckUserIdIsAssignableToThisEstudianteAsync(int estudianteId, string proposedUserId)
        {
            var estudiante = await _dataContext.Estudiante.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == estudianteId);

            if (proposedUserId == estudiante.UserId)
            {
                return true;
            }

            return !await CheckUserIdIsAssignedAsync(proposedUserId);
        }

        public async Task<Estudiante> GetEstudianteByUserIdAsync(string userId)
        {
            return await _dataContext.Estudiante.SingleOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<Estudiante>> GetAllNotAssignedToGrupoAsync(int grupoId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext
                .Estudiante
                .Where(e => !_dataContext.EstudianteGrupo
                    .Where(x => x.GrupoId == grupoId)
                    .Select(x => x.EstudianteId)
                    .Contains(e.Id))
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

        public async Task<List<Estudiante>> GetAllNotAssignedAsistenciaEstudianteAsync(int materiaId, int grupoId, int asistenciaEstudianteHeaderId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Estudiante
                .Where(e => _dataContext.EstudianteMateria
                    .Where(x => x.MateriaId == materiaId && x.GrupoId == grupoId)
                    .Select(x => x.EstudianteId)
                    .Contains(e.Id) &&
                    !_dataContext.AsistenciaEstudiante
                    .Where(x => x.AsistenciaEstudianteHeaderId == asistenciaEstudianteHeaderId)
                    .Select(x => x.EstudianteId)
                    .Contains(e.Id))
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

        public async Task<List<Estudiante>> GetAllNotAssignedToRegistroNotaEstudianteHeaderAsync(int registroNotaHeaderId, PaginationFilter paginationFilter = null)
        {
            var registroNotaHeader = await _dataContext.RegistroNotaHeader
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == registroNotaHeaderId);

            if (registroNotaHeader == null)
            {
                return new List<Estudiante> ();
            }

            var queryable = _dataContext.Estudiante
               .Where(e => _dataContext.EstudianteMateria
                    .Where(x => x.MateriaId == registroNotaHeader.MateriaId && x.GrupoId == registroNotaHeader.GrupoId)
                    .Select(x => x.EstudianteId)
                    .Contains(e.Id) &&
                    !_dataContext.RegistroNotaEstudianteHeader
                    .Where(x => x.RegistroNotaHeaderId == registroNotaHeaderId)
                    .Select(x => x.EstudianteId)
                    .Contains(e.Id))
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

        public async Task<List<Estudiante>> GetAllNotAssignedInhabilitacionEstudianteAsync(PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.Estudiante
                .Where(e => !_dataContext.InhabilitacionEstudiante
                    .Select(x => x.EstudianteId)
                    .Contains(e.Id))
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
