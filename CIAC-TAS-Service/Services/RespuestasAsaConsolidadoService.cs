using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using Microsoft.EntityFrameworkCore;

namespace CIAC_TAS_Service.Services
{
    public class RespuestasAsaConsolidadoService : IRespuestasAsaConsolidadoService
    {
        private readonly DataContext _dataContext;
        private readonly IRespuestasAsaService _respuestasAsaService;

        public RespuestasAsaConsolidadoService(DataContext dataContext, IRespuestasAsaService respuestasAsaService)
        {
            _dataContext = dataContext;
            _respuestasAsaService = respuestasAsaService;
        }                

        public async Task<List<RespuestasAsaConsolidado>> GetRespuestasAsasConsolidadoByUserIdAsync(string userId, PaginationFilter paginationFilter = null)
        {
            var queryable = _dataContext.RespuestasAsaConsolidado
                .Where(x => x.UserId == userId)
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

		public async Task<List<RespuestasAsaConsolidado>> GetRespuestasAsasConsolidadoByUserIdLoteRespuestasIdAsync(Guid loteRespuestasId, string userId, PaginationFilter paginationFilter = null)
		{
			var queryable = _dataContext.RespuestasAsaConsolidado
				.Where(x => x.UserId == userId && x.LoteRespuestasId == loteRespuestasId)
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

		public async Task<List<RespuestasAsaConsolidado>> GetRespuestasAsasConsolidadoHeadersByUserIdAsync(string userId, PaginationFilter paginationFilter = null)
		{
			var resultGrouping = _dataContext.RespuestasAsaConsolidado
                .GroupBy(x => new { x.LoteRespuestasId, x.UserId , x.FechaLote, x.EsExamen })
                .Select(x => new { 
                    UserId = x.Key.UserId, 
                    LoteRespuestasId = x.Key.LoteRespuestasId, 
                    FechaLote = x.Key.FechaLote,
                    EsExamen = x.Key.EsExamen,
                    CountRows = x.Count() 
                })
				.Where(x => x.UserId == userId)
                .AsQueryable();

            List<RespuestasAsaConsolidado> respuestasAsaConsolidados = new List<RespuestasAsaConsolidado>();

            await resultGrouping.ForEachAsync(x =>
            {
                respuestasAsaConsolidados.Add(new RespuestasAsaConsolidado
                {
                    Id = 0,
                    LoteRespuestasId = x.LoteRespuestasId,
                    UserId= x.UserId,
                    FechaLote= x.FechaLote,
                    EsExamen = x.EsExamen
                });
			});

            return respuestasAsaConsolidados;

			//if (paginationFilter == null)
			//{
			//	return await queryable.ToListAsync();
			//}

			//var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
			//return await queryable.Skip(skip)
			//	.Take(paginationFilter.PageSize)
			//	.ToListAsync();
		}

		public async Task<bool> CreateRespuestasAsaBatchAsync(List<RespuestasAsaConsolidado> respuestasAsaConsolidado)
        {
            await _dataContext.RespuestasAsaConsolidado.AddRangeAsync(respuestasAsaConsolidado);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<Guid> ProcessRespuestasAsaAsync(string userId)
        {
            var respuestasAsas = await _dataContext.RespuestasAsas
                .Include(x => x.PreguntaAsa)
                .Include(x => x.PreguntaAsaOpcionSeleccionada)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            List<RespuestasAsaConsolidado> respuestasAsaConsolidados = new List<RespuestasAsaConsolidado>();
            var guid = Guid.NewGuid();

            respuestasAsas.ForEach(item => respuestasAsaConsolidados.Add(new RespuestasAsaConsolidado
            {
                LoteRespuestasId = guid,
                UserId = userId,
                ConfiguracionId = item.ConfiguracionId,
                NumeroPregunta = item.PreguntaAsa.NumeroPregunta,
                PreguntaTexto = item.PreguntaAsa.Pregunta,
                FechaLote = item.FechaEntrada,
                Opcion = item.PreguntaAsaOpcionSeleccionada == null ? null : item.PreguntaAsaOpcionSeleccionada.Opcion,
                RespuestaTexto = item.PreguntaAsaOpcionSeleccionada == null ? string.Empty : item.PreguntaAsaOpcionSeleccionada.Texto,
                RespuestaCorrecta = item.PreguntaAsaOpcionSeleccionada == null ? false : item.PreguntaAsaOpcionSeleccionada.RespuestaValida,
                EsExamen = item.EsExamen
            }));

            await CreateRespuestasAsaBatchAsync(respuestasAsaConsolidados);

            await _respuestasAsaService.DeleteRespuestasAsaBatchByUserIdAsync(userId);

            return guid;
        }

        public async Task<bool> UserHasAnswersInConsolidadoByConfiguracionIdAsync(string userId, int configuracionId)
        {
            return await _dataContext.RespuestasAsaConsolidado
                .Where(x => x.UserId == userId && x.ConfiguracionId == configuracionId)
                .CountAsync() > 0;
        }
    }
}
