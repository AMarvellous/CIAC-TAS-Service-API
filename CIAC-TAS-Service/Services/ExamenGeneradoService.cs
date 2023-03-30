using CIAC_TAS_Service.Data;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain;
using Microsoft.EntityFrameworkCore;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Services
{
	public class ExamenGeneradoService : IExamenGeneradoService
	{
		private readonly DataContext _dataContext;
		private readonly IPreguntaAsaService _preguntaAsaService;
		private readonly IGrupoService _grupoService;

		public ExamenGeneradoService(DataContext dataContext, IPreguntaAsaService preguntaAsaService, IGrupoService grupoService)
		{
			_dataContext = dataContext;
			_preguntaAsaService = preguntaAsaService;
			_grupoService =	grupoService;
		}

		public async Task<List<ExamenGenerado>> GetExamenGeneradosAsync(PaginationFilter paginationFilter = null)
		{
			var queryable = _dataContext.ExamenGenerado.AsQueryable();

			if (paginationFilter == null)
			{
				return await queryable.ToListAsync();
			}

			var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
			return await queryable.Skip(skip)
				.Take(paginationFilter.PageSize)
				.ToListAsync();
		}

		public async Task<ExamenGenerado> GetExamenGeneradoByIdAsync(int id)
		{
			return await _dataContext.ExamenGenerado.SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task<bool> CreateExamenGeneradoAsync(ExamenGenerado examenGenerado)
		{
			await _dataContext.ExamenGenerado.AddAsync(examenGenerado);
			var created = await _dataContext.SaveChangesAsync();

			return created > 0;
		}
		public async Task<bool> UpdateExamenGeneradoAsync(ExamenGenerado examenGenerado)
		{
			_dataContext.ExamenGenerado.Update(examenGenerado);
			var updated = await _dataContext.SaveChangesAsync();

			return updated > 0;
		}

		public async Task<bool> DeleteExamenGeneradoAsync(int examenGeneradoId)
		{
			var examenGenerado = await GetExamenGeneradoByIdAsync(examenGeneradoId);

			if (examenGenerado == null)
			{
				return false;
			}

			_dataContext.ExamenGenerado.Remove(examenGenerado);
			var deleted = await _dataContext.SaveChangesAsync();

			return deleted > 0;
		}

		public async Task<List<ExamenGenerado>> CreateExamenGeneradoRandomAsync(int grupoId, int numeroPreguntas)
		{
			var examenGeneradoPreguntas = new List<ExamenGenerado>();
			var guidExamen = Guid.NewGuid();
			var fecha = DateTime.Now;

			var grupo = await _grupoService.GetGrupoByIdAsync(grupoId);

            var preguntasAsa = await _preguntaAsaService.GetRandomGeneratedPreguntasAsaAsync(numeroPreguntas, 0, 0, new List<int>());

			preguntasAsa.ForEach(pregunta =>
				pregunta.PreguntaAsaOpciones.ToList().ForEach(opcion =>
				examenGeneradoPreguntas.Add(new ExamenGenerado
				{
					GrupoId = grupoId,
					Grupos = grupo,
					ExamenGeneradoGuid = guidExamen,
					Fecha = fecha,
					NumeroPregunta = pregunta.NumeroPregunta,
					PreguntaTexto = pregunta.Pregunta,
					NumeroOpcion = opcion.Opcion,
					OpcionTexto = opcion.Texto
				})
			));

			await _dataContext.ExamenGenerado.AddRangeAsync(examenGeneradoPreguntas);
			await _dataContext.SaveChangesAsync();

			return examenGeneradoPreguntas;
		}

		public async Task<List<ExamenGenerado>> GetExamenGeneradosByGrupoGuidAsync(int grupoId, Guid examenGeneradoGuid, PaginationFilter paginationFilter = null)
		{
			var queryable = _dataContext.ExamenGenerado
                .Include(x => x.Grupos)
                .Where(x => x.GrupoId == grupoId && x.ExamenGeneradoGuid == examenGeneradoGuid)
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

        public async Task<List<ExamenGenerado>> GetExamenGeneradosHeadersAsync(PaginationFilter paginationFilter = null)
        {
            var resultGrouping = _dataContext.ExamenGenerado
				.Include(x => x.Grupos)
				.GroupBy(x => new { x.ExamenGeneradoGuid, x.Grupos.Nombre, x.GrupoId, x.Fecha  })
				.Select(x => new
				{
					GrupoId = x.Key.GrupoId,
					GrupoNombre = x.Key.Nombre,
					Fecha = x.Key.Fecha,
					ExamenGeneradoGuid = x.Key.ExamenGeneradoGuid
				})
                .AsQueryable();

            List<ExamenGenerado> examenGenerados = new List<ExamenGenerado>();

			await resultGrouping.ForEachAsync(x =>
			{
				examenGenerados.Add(new ExamenGenerado
				{
					Id = 0,
					GrupoId = x.GrupoId,
					Grupos = new Domain.General.Grupo { Nombre = x.GrupoNombre },
					Fecha = x.Fecha,
					ExamenGeneradoGuid = x.ExamenGeneradoGuid,
				});
			});

            return examenGenerados;         
        }
    }
}
