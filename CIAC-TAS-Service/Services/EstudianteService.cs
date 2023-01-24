﻿using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            await _dataContext.Estudiante.AddAsync(estudiante);
            var created = await _dataContext.SaveChangesAsync();

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

        public async Task<bool> CheckUserExistsByUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user != null;
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
    }
}