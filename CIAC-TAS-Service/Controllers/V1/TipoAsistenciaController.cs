using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Produces("application/json")]
    public class TipoAsistenciaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITipoAsistenciaService _tipoAsistenciaService;
        private readonly IUriService _uriService;

        public TipoAsistenciaController(IMapper mapper, ITipoAsistenciaService tipoAsistenciaService, IUriService uriService)
        {
            _mapper = mapper;
            _tipoAsistenciaService = tipoAsistenciaService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.TipoAsistencias.GetAll)]
        [ProducesResponseType(typeof(TipoAsistenciaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var tipoAsistencias = await _tipoAsistenciaService.GetTipoAsistenciasAsync(pagination);
            var tipoAsistenciaResponses = _mapper.Map<List<TipoAsistenciaResponse>>(tipoAsistencias);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<TipoAsistenciaResponse>(tipoAsistenciaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, tipoAsistenciaResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.TipoAsistencias.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TipoAsistenciaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int tipoAsistenciaId)
        {
            var tipoAsistencia = await _tipoAsistenciaService.GetTipoAsistenciaByIdAsync(tipoAsistenciaId);

            if (tipoAsistencia == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoAsistenciaResponse>(tipoAsistencia));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.TipoAsistencias.Create)]
        [ProducesResponseType(typeof(TipoAsistenciaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTipoAsistenciaRequest tipoAsistenciaRequest)
        {
            var tipoAsistencia = new TipoAsistencia
            {
                Nombre = tipoAsistenciaRequest.Nombre
            };

            var created = await _tipoAsistenciaService.CreateTipoAsistenciaAsync(tipoAsistencia);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [TipoAsistencia]"}
                }
                });
            }

            var locationUri = _uriService.GetTipoAsistenciaUri(tipoAsistencia.Id.ToString());

            var response = _mapper.Map<TipoAsistenciaResponse>(tipoAsistencia);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut(ApiRoute.TipoAsistencias.Update)]
        [ProducesResponseType(typeof(TipoAsistenciaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int tipoAsistenciaId, [FromBody] UpdateTipoAsistenciaRequest request)
        {
            var tipoAsistencia = await _tipoAsistenciaService.GetTipoAsistenciaByIdAsync(tipoAsistenciaId);
            tipoAsistencia.Nombre = request.Nombre;

            var update = await _tipoAsistenciaService.UpdateTipoAsistenciaAsync(tipoAsistencia);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoAsistenciaResponse>(tipoAsistencia));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.TipoAsistencias.Delete)]
        [ProducesResponseType(typeof(TipoAsistenciaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int tipoAsistenciaId)
        {
            var deleted = await _tipoAsistenciaService.DeleteTipoAsistenciaAsync(tipoAsistenciaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
