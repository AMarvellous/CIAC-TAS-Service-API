using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Domain.Estudiante;
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
    public class TipoRegistroNotaHeaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITipoRegistroNotaHeaderService _tipoRegistroNotaHeaderService;
        private readonly IUriService _uriService;

        public TipoRegistroNotaHeaderController(IMapper mapper, ITipoRegistroNotaHeaderService tipoRegistroNotaHeaderService, IUriService uriService)
        {
            _mapper = mapper;
            _tipoRegistroNotaHeaderService = tipoRegistroNotaHeaderService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.TipoRegistroNotaHeaders.GetAll)]
        [ProducesResponseType(typeof(TipoRegistroNotaHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var tipoRegistroNotaHeaders = await _tipoRegistroNotaHeaderService.GetTipoRegistroNotaHeadersAsync();
            var tipoRegistroNotaHeaderResponses = _mapper.Map<List<TipoRegistroNotaHeaderResponse>>(tipoRegistroNotaHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<TipoRegistroNotaHeaderResponse>(tipoRegistroNotaHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, tipoRegistroNotaHeaderResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.TipoRegistroNotaHeaders.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TipoRegistroNotaHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int tipoRegistroNotaHeaderId)
        {
            var tipoRegistroNotaHeader = await _tipoRegistroNotaHeaderService.GetTipoRegistroNotaHeaderByIdAsync(tipoRegistroNotaHeaderId);

            if (tipoRegistroNotaHeader == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoRegistroNotaHeaderResponse>(tipoRegistroNotaHeader));
        }

        [HttpPost(ApiRoute.TipoRegistroNotaHeaders.Create)]
        [ProducesResponseType(typeof(TipoRegistroNotaHeaderResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTipoRegistroNotaHeaderRequest tipoRegistroNotaHeaderRequest)
        {
            var tipoRegistroNotaHeader = new TipoRegistroNotaHeader
            {
                Nombre = tipoRegistroNotaHeaderRequest.Nombre
            };

            var created = await _tipoRegistroNotaHeaderService.CreateTipoRegistroNotaHeaderAsync(tipoRegistroNotaHeader);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [TipoRegistroNotaHeader]"}
                }
                });
            }

            var locationUri = _uriService.GetTipoRegistroNotaHeaderUri(tipoRegistroNotaHeader.Id.ToString());

            var response = _mapper.Map<TipoRegistroNotaHeaderResponse>(tipoRegistroNotaHeader);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.TipoRegistroNotaHeaders.Update)]
        [ProducesResponseType(typeof(TipoRegistroNotaHeaderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int tipoRegistroNotaHeaderId, [FromBody] UpdateTipoRegistroNotaHeaderRequest request)
        {
            var tipoRegistroNotaHeader = await _tipoRegistroNotaHeaderService.GetTipoRegistroNotaHeaderByIdAsync(tipoRegistroNotaHeaderId);
            tipoRegistroNotaHeader.Nombre = request.Nombre;

            var update = await _tipoRegistroNotaHeaderService.UpdateTipoRegistroNotaHeaderAsync(tipoRegistroNotaHeader);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoRegistroNotaHeaderResponse>(tipoRegistroNotaHeader));
        }

        [HttpDelete(ApiRoute.TipoRegistroNotaHeaders.Delete)]
        [ProducesResponseType(typeof(TipoRegistroNotaHeaderResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int tipoRegistroNotaHeaderId)
        {
            var deleted = await _tipoRegistroNotaHeaderService.DeleteTipoRegistroNotaHeaderAsync(tipoRegistroNotaHeaderId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
