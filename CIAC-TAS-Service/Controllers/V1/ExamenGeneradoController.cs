using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIAC_TAS_Service.Controllers.V1
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
	[Produces("application/json")]
	public class ExamenGeneradoController : Controller
	{
		private readonly IMapper _mapper;
		private readonly IExamenGeneradoService _examenGeneradoService;
		private readonly IGrupoService _grupoService;
		private readonly IUriService _uriService;

		public ExamenGeneradoController(IMapper mapper, IExamenGeneradoService examenGeneradoService, IGrupoService grupoService, IUriService uriService)
		{
			_mapper = mapper;
			_examenGeneradoService = examenGeneradoService;
			_grupoService = grupoService;
			_uriService = uriService;
		}

		[HttpGet(ApiRoute.ExamenGenerados.GetAll)]
		[ProducesResponseType(typeof(ExamenGeneradoResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
		{
			var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
			var examenGenerados = await _examenGeneradoService.GetExamenGeneradosAsync();
			var examenGeneradoResponses = _mapper.Map<List<ExamenGeneradoResponse>>(examenGenerados);

			if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
			{
				return Ok(new PagedResponse<ExamenGeneradoResponse>(examenGeneradoResponses));
			}

			var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, examenGeneradoResponses);

			return Ok(paginationResponse);
		}

		[HttpGet(ApiRoute.ExamenGenerados.Get)]
		[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
		[ProducesResponseType(typeof(ExamenGeneradoResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> Get([FromRoute] int examenGeneradoId)
		{
			var examenGenerado = await _examenGeneradoService.GetExamenGeneradoByIdAsync(examenGeneradoId);

			if (examenGenerado == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ExamenGeneradoResponse>(examenGenerado));
		}

		[HttpPost(ApiRoute.ExamenGenerados.Create)]
		[ProducesResponseType(typeof(ExamenGeneradoResponse), (int)HttpStatusCode.Created)]
		[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
		public async Task<IActionResult> Create([FromBody] CreateExamenGeneradoRequest examenGeneradoRequest)
		{
			if (!await _grupoService.CheckGrupoExistsAsync(examenGeneradoRequest.GrupoId))
			{
				return BadRequest(new ErrorResponse
				{
					Errors = new List<ErrorModel>
					{
						new ErrorModel { Message = $"Grupo Id {examenGeneradoRequest.GrupoId} no existe"}
					}
				});
			}			

			var examenGenerado = new ExamenGenerado
			{
				GrupoId = examenGeneradoRequest.GrupoId,
				Fecha = examenGeneradoRequest.Fecha,
				ExamenGeneradoGuid = examenGeneradoRequest.ExamenGeneradoGuid,
				NumeroPregunta = examenGeneradoRequest.NumeroPregunta,
				PreguntaTexto = examenGeneradoRequest.PreguntaTexto,
				NumeroOpcion = examenGeneradoRequest.NumeroOpcion,
				OpcionTexto = examenGeneradoRequest.OpcionTexto,
			};

			var created = await _examenGeneradoService.CreateExamenGeneradoAsync(examenGenerado);

			if (!created)
			{
				return BadRequest(new ErrorResponse
				{
					Errors = new List<ErrorModel>
				{
					new ErrorModel { Message = "Unable to create [ExamenGenerado]"}
				}
				});
			}

			var locationUri = _uriService.GetExamenGeneradoUri(examenGenerado.Id.ToString());

			var response = _mapper.Map<ExamenGeneradoResponse>(examenGenerado);

			return Created(locationUri, response);
		}

		[HttpPut(ApiRoute.ExamenGenerados.Update)]
		[ProducesResponseType(typeof(ExamenGeneradoResponse), (int)HttpStatusCode.OK)]
		[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Update([FromRoute] int examenGeneradoId, [FromBody] UpdateExamenGeneradoRequest request)
		{
			if (!await _grupoService.CheckGrupoExistsAsync(request.GrupoId))
			{
				return BadRequest(new ErrorResponse
				{
					Errors = new List<ErrorModel>
					{
						new ErrorModel { Message = $"Grupo Id {request.GrupoId} no existe"}
					}
				});
			}

			var examenGenerado = await _examenGeneradoService.GetExamenGeneradoByIdAsync(examenGeneradoId);
			examenGenerado.GrupoId = request.GrupoId;
			examenGenerado.Fecha = request.Fecha;
			examenGenerado.Fecha = request.Fecha;
			examenGenerado.ExamenGeneradoGuid = request.ExamenGeneradoGuid;
			examenGenerado.NumeroPregunta = request.NumeroPregunta;
			examenGenerado.PreguntaTexto = request.PreguntaTexto;
			examenGenerado.NumeroOpcion = request.NumeroOpcion;
			examenGenerado.OpcionTexto = request.OpcionTexto;

			var update = await _examenGeneradoService.UpdateExamenGeneradoAsync(examenGenerado);

			if (!update)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<ExamenGeneradoResponse>(examenGenerado));
		}

		[HttpDelete(ApiRoute.ExamenGenerados.Delete)]
		[ProducesResponseType(typeof(ExamenGeneradoResponse), (int)HttpStatusCode.NoContent)]
		[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
		public async Task<IActionResult> Delete([FromRoute] int examenGeneradoId)
		{
			var deleted = await _examenGeneradoService.DeleteExamenGeneradoAsync(examenGeneradoId);

			if (!deleted)
			{
				return NotFound();
			}

			return NoContent();
		}

		[HttpPost(ApiRoute.ExamenGenerados.CreatePreguntasExamenGenerado)]
		[ProducesResponseType(typeof(List<ExamenGeneradoResponse>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> CreatePreguntasExamenGenerado([FromRoute] int grupoId, [FromQuery] int numeroPreguntas)
		{
			var examenGeneradoPreguntas = await _examenGeneradoService.CreateExamenGeneradoRandomAsync(grupoId, numeroPreguntas);
			var examenGeneradoResponse = _mapper.Map<List<ExamenGeneradoResponse>>(examenGeneradoPreguntas);

			if (examenGeneradoResponse == null)
			{
				return BadRequest(new ErrorResponse
				{
					Errors = new List<ErrorModel>
				{
					new ErrorModel { Message = "Unable to create [ExamenGenerado]"}
				}
				});
			}

			var locationUri = _uriService.GetExamenGeneradoUri(examenGeneradoPreguntas.First().Id.ToString());

			return Created(locationUri, examenGeneradoResponse);
		}

		[HttpGet(ApiRoute.ExamenGenerados.GetExamenByGrupoGuid)]
		[ProducesResponseType(typeof(ExamenGeneradoResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetExamenByGrupoGuid([FromRoute] int grupoId, [FromRoute] Guid guid, [FromQuery] PaginationQuery paginationQuery)
		{
			var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
			pagination.PageSize = 9999;
            var examenGenerados = await _examenGeneradoService.GetExamenGeneradosByGrupoGuidAsync(grupoId, guid);
			var examenGeneradoResponses = _mapper.Map<List<ExamenGeneradoResponse>>(examenGenerados);

			if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
			{
				return Ok(new PagedResponse<ExamenGeneradoResponse>(examenGeneradoResponses));
			}

			var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, examenGeneradoResponses);

			return Ok(paginationResponse);
		}

        [HttpGet(ApiRoute.ExamenGenerados.GetExamenHeaders)]
        [ProducesResponseType(typeof(ExamenGeneradoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetExamenHeaders([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var examenGenerados = await _examenGeneradoService.GetExamenGeneradosHeadersAsync();
            var examenGeneradoResponses = _mapper.Map<List<ExamenGeneradoResponse>>(examenGenerados);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ExamenGeneradoResponse>(examenGeneradoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, examenGeneradoResponses);

            return Ok(paginationResponse);
        }
    }
}
