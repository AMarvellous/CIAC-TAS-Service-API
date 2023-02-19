using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Produces("application/json")]
    public class RespuestasAsaConsolidadoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRespuestasAsaConsolidadoService _respuestasAsaConsolidadoService;
        private readonly IIdentityService _identityService;
        private readonly IConfiguracionPreguntaAsaService _configuracionPreguntaAsaService;
        private readonly IUriService _uriService;

        public RespuestasAsaConsolidadoController(IMapper mapper, IRespuestasAsaConsolidadoService respuestasAsaConsolidadoService, IUriService uriService, IIdentityService identityService, IConfiguracionPreguntaAsaService configuracionPreguntaAsaService)
        {
            _mapper = mapper;
            _respuestasAsaConsolidadoService = respuestasAsaConsolidadoService;
            _identityService = identityService;
            _configuracionPreguntaAsaService = configuracionPreguntaAsaService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [HttpGet(ApiRoute.RespuestasAsasConsolidado.GetAllByUserId)]
        [ProducesResponseType(typeof(List<RespuestasAsaConsolidadoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByUserId([FromRoute] string userId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var respuestasAsasConsolidado = await _respuestasAsaConsolidadoService.GetRespuestasAsasConsolidadoByUserIdAsync(userId, pagination);
            var respuestasAsaConsolidadoResponses = _mapper.Map<List<RespuestasAsaConsolidadoResponse>>(respuestasAsasConsolidado);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RespuestasAsaConsolidadoResponse>(respuestasAsaConsolidadoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, respuestasAsaConsolidadoResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [HttpPost(ApiRoute.RespuestasAsasConsolidado.CreateBatch)]
        [ProducesResponseType(typeof(List<RespuestasAsaResponse>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBatch([FromBody] List<CreateRespuestasAsaConsolidadoRequest> respuestasAsaConsolidadoRequest)
        {

            List<RespuestasAsaConsolidado> respuestasAsaConsolidados = new List<RespuestasAsaConsolidado>();
            var guid = Guid.NewGuid();
            foreach (var item in respuestasAsaConsolidadoRequest)
            {
                if (!await _identityService.CheckUserExistsByUserIdAsync(item.UserId))
                {
                    return BadRequest(new ErrorResponse
                    {
                        Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {item.UserId} not found"}
                    }
                    });
                }

                if (item.ConfiguracionId != null && !await _configuracionPreguntaAsaService.CheckConfiguracionPreguntaAsaExistsAsync((int)item.ConfiguracionId))
                {
                    return BadRequest(new ErrorResponse
                    {
                        Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Configuracion Id {item.ConfiguracionId} not found"}
                    }
                    });
                }

                
                respuestasAsaConsolidados.Add(new RespuestasAsaConsolidado
                {
                    LoteRespuestasId = guid,
                    UserId = item.UserId,
                    ConfiguracionId = item.ConfiguracionId,
                    NumeroPregunta = item.NumeroPregunta,
                    PreguntaTexto = item.PreguntaTexto,
                    FechaLote = item.FechaLote,
                    Opcion = item.Opcion,
                    RespuestaTexto = item.RespuestaTexto,
                    RespuestaCorrecta = item.RespuestaCorrecta,
                    EsExamen = item.EsExamen
                });
            }

            var created = await _respuestasAsaConsolidadoService.CreateRespuestasAsaBatchAsync(respuestasAsaConsolidados);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RespuestasAsasConsolidado]"}
                }
                });
            }

            var locationUri = _uriService.GetRespuestasAsaConsolidadoUri(string.Join(",", respuestasAsaConsolidados.Select(x => x.Id.ToString()).ToArray()));

            var response = _mapper.Map<List<RespuestasAsaConsolidadoResponse>>(respuestasAsaConsolidados);

            return Created(locationUri, response);
        }

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
		[HttpGet(ApiRoute.RespuestasAsasConsolidado.GetAllByUserIdAndLote)]
		[ProducesResponseType(typeof(List<RespuestasAsaConsolidadoResponse>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetAllByUserIdAndLote([FromRoute] Guid loteRespuestasId, [FromRoute] string userId, [FromQuery] PaginationQuery paginationQuery)
		{
			var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
			var respuestasAsasConsolidado = await _respuestasAsaConsolidadoService.GetRespuestasAsasConsolidadoByUserIdLoteRespuestasIdAsync(loteRespuestasId, userId, pagination);
			var respuestasAsaConsolidadoResponses = _mapper.Map<List<RespuestasAsaConsolidadoResponse>>(respuestasAsasConsolidado);

			if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
			{
				return Ok(new PagedResponse<RespuestasAsaConsolidadoResponse>(respuestasAsaConsolidadoResponses));
			}

			var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, respuestasAsaConsolidadoResponses);

			return Ok(paginationResponse);
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
		[HttpGet(ApiRoute.RespuestasAsasConsolidado.GetAllHeadersByUserId)]
		[ProducesResponseType(typeof(List<RespuestasAsaConsolidadoResponse>), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetAllHeadersByUserIdAndLote([FromRoute] string userId, [FromQuery] PaginationQuery paginationQuery)
		{
			var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
			var respuestasAsasConsolidado = await _respuestasAsaConsolidadoService.GetRespuestasAsasConsolidadoHeadersByUserIdAsync(userId, pagination);
			var respuestasAsaConsolidadoResponses = _mapper.Map<List<RespuestasAsaConsolidadoResponse>>(respuestasAsasConsolidado);

			if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
			{
				return Ok(new PagedResponse<RespuestasAsaConsolidadoResponse>(respuestasAsaConsolidadoResponses));
			}

			var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, respuestasAsaConsolidadoResponses);

			return Ok(paginationResponse);
		}
	}
}
