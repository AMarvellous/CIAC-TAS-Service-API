using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
    [Produces("application/json")]
    public class TipoAsistenciaEstudianteHeaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITipoAsistenciaEstudianteHeaderService _tipoAsistenciaEstudianteHeaderService;
        private readonly IUriService _uriService;

        public TipoAsistenciaEstudianteHeaderController(IMapper mapper, ITipoAsistenciaEstudianteHeaderService tipoAsistenciaEstudianteHeaderService, IUriService uriService)
        {
            _mapper = mapper;
            _tipoAsistenciaEstudianteHeaderService = tipoAsistenciaEstudianteHeaderService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.TipoAsistenciaEstudianteHeaders.GetAll)]
        [ProducesResponseType(typeof(TipoAsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var tipoAsistenciaEstudianteHeaders = await _tipoAsistenciaEstudianteHeaderService.GetTipoAsistenciaEstudianteHeadersAsync();
            var tipoAsistenciaEstudianteHeaderResponses = _mapper.Map<List<TipoAsistenciaEstudianteHeaderResponse>>(tipoAsistenciaEstudianteHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<TipoAsistenciaEstudianteHeaderResponse>(tipoAsistenciaEstudianteHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, tipoAsistenciaEstudianteHeaderResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.TipoAsistenciaEstudianteHeaders.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TipoAsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int tipoAsistenciaEstudianteHeaderId)
        {
            var tipoAsistenciaEstudianteHeader = await _tipoAsistenciaEstudianteHeaderService.GetTipoAsistenciaEstudianteHeaderByIdAsync(tipoAsistenciaEstudianteHeaderId);

            if (tipoAsistenciaEstudianteHeader == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoAsistenciaEstudianteHeaderResponse>(tipoAsistenciaEstudianteHeader));
        }

        [HttpPost(ApiRoute.TipoAsistenciaEstudianteHeaders.Create)]
        [ProducesResponseType(typeof(TipoAsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTipoAsistenciaEstudianteHeaderRequest tipoAsistenciaEstudianteHeaderRequest)
        {
            var tipoAsistenciaEstudianteHeader = new TipoAsistenciaEstudianteHeader
            {
                Nombre = tipoAsistenciaEstudianteHeaderRequest.Nombre
            };

            var created = await _tipoAsistenciaEstudianteHeaderService.CreateTipoAsistenciaEstudianteHeaderAsync(tipoAsistenciaEstudianteHeader);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [TipoAsistenciaEstudianteHeader]"}
                }
                });
            }

            var locationUri = _uriService.GetTipoAsistenciaEstudianteHeaderUri(tipoAsistenciaEstudianteHeader.Id.ToString());

            var response = _mapper.Map<TipoAsistenciaEstudianteHeaderResponse>(tipoAsistenciaEstudianteHeader);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.TipoAsistenciaEstudianteHeaders.Update)]
        [ProducesResponseType(typeof(TipoAsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int tipoAsistenciaEstudianteHeaderId, [FromBody] UpdateTipoAsistenciaEstudianteHeaderRequest request)
        {
            var tipoAsistenciaEstudianteHeader = await _tipoAsistenciaEstudianteHeaderService.GetTipoAsistenciaEstudianteHeaderByIdAsync(tipoAsistenciaEstudianteHeaderId);
            tipoAsistenciaEstudianteHeader.Nombre = request.Nombre;

            var update = await _tipoAsistenciaEstudianteHeaderService.UpdateTipoAsistenciaEstudianteHeaderAsync(tipoAsistenciaEstudianteHeader);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoAsistenciaEstudianteHeaderResponse>(tipoAsistenciaEstudianteHeader));
        }

        [HttpDelete(ApiRoute.TipoAsistenciaEstudianteHeaders.Delete)]
        [ProducesResponseType(typeof(TipoAsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int tipoAsistenciaEstudianteHeaderId)
        {
            var deleted = await _tipoAsistenciaEstudianteHeaderService.DeleteTipoAsistenciaEstudianteHeaderAsync(tipoAsistenciaEstudianteHeaderId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
