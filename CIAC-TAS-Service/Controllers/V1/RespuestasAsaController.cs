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
    public class RespuestasAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRespuestasAsaService _respuestasAsaService;
        private readonly IUriService _uriService;

        public RespuestasAsaController(IMapper mapper, IRespuestasAsaService respuestasAsaService, IUriService uriService)
        {
            _mapper = mapper;
            _respuestasAsaService = respuestasAsaService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpGet(ApiRoute.RespuestasAsas.GetAll)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var respuestasAsas = await _respuestasAsaService.GetRespuestasAsasAsync(pagination);
            var respuestasAsaResponses = _mapper.Map<List<RespuestasAsaResponse>>(respuestasAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RespuestasAsaResponse>(respuestasAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, respuestasAsaResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpGet(ApiRoute.RespuestasAsas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int respuestasAsaId)
        {
            var respuestasAsa = await _respuestasAsaService.GetRespuestasAsaByIdAsync(respuestasAsaId);

            if (respuestasAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RespuestasAsaResponse>(respuestasAsa));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpPost(ApiRoute.RespuestasAsas.Create)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRespuestasAsaRequest respuestasAsaRequest)
        {
            var respuestasAsa = new RespuestasAsa
            {
                UserId = respuestasAsaRequest.UserId,
                ConfiguracionId = respuestasAsaRequest.ConfiguracionId,
                PreguntaAsaId = respuestasAsaRequest.PreguntaAsaId,
                FechaEntrada = respuestasAsaRequest.FechaEntrada,
                OpcionSeleccionadaId = respuestasAsaRequest.OpcionSeleccionadaId,
                EsExamen = respuestasAsaRequest.EsExamen
            };

            var created = await _respuestasAsaService.CreateRespuestasAsaAsync(respuestasAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RespuestasAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetRespuestasAsaUri(respuestasAsa.Id.ToString());

            var response = _mapper.Map<RespuestasAsaResponse>(respuestasAsa);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpPut(ApiRoute.RespuestasAsas.Update)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int respuestasAsaId, [FromBody] UpdateRespuestasAsaRequest request)
        {
            var respuestasAsa = await _respuestasAsaService.GetRespuestasAsaByIdAsync(respuestasAsaId);
            respuestasAsa.UserId = request.UserId;
            respuestasAsa.ConfiguracionId = request.ConfiguracionId;
            respuestasAsa.PreguntaAsaId = request.PreguntaAsaId;
            respuestasAsa.FechaEntrada = request.FechaEntrada;
            respuestasAsa.OpcionSeleccionadaId = request.OpcionSeleccionadaId;
            respuestasAsa.EsExamen = request.EsExamen;

            var update = await _respuestasAsaService.UpdateRespuestasAsaAsync(respuestasAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RespuestasAsaResponse>(respuestasAsa));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.RespuestasAsas.Delete)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int respuestasAsaId)
        {
            var deleted = await _respuestasAsaService.DeleteRespuestasAsaAsync(respuestasAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
