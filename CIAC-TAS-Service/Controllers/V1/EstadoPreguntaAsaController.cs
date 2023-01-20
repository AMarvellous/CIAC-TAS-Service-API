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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class EstadoPreguntaAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEstadoPreguntaAsaService _estadoPreguntaAsaService;
        private readonly IUriService _uriService;

        public EstadoPreguntaAsaController(IMapper mapper, IEstadoPreguntaAsaService estadoPreguntaAsaService, IUriService uriService)
        {
            _mapper = mapper;
            _estadoPreguntaAsaService = estadoPreguntaAsaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.EstadoPreguntaAsas.GetAll)]
        [ProducesResponseType(typeof(EstadoPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estadoPreguntaAsas = await _estadoPreguntaAsaService.GetEstadoPreguntaAsasAsync(pagination);
            var estadoPreguntaAsaResponses = _mapper.Map<List<EstadoPreguntaAsaResponse>>(estadoPreguntaAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstadoPreguntaAsaResponse>(estadoPreguntaAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estadoPreguntaAsaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.EstadoPreguntaAsas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstadoPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int estadoPreguntaAsaId)
        {
            var estadoPreguntaAsa = await _estadoPreguntaAsaService.GetEstadoPreguntaAsaByIdAsync(estadoPreguntaAsaId);

            if (estadoPreguntaAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstadoPreguntaAsaResponse>(estadoPreguntaAsa));
        }

        [HttpPost(ApiRoute.EstadoPreguntaAsas.Create)]
        [ProducesResponseType(typeof(EstadoPreguntaAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEstadoPreguntaAsaRequest estadoPreguntaAsaRequest)
        {
            var estadoPreguntaAsa = new EstadoPreguntaAsa
            {
                Estado = estadoPreguntaAsaRequest.Estado
            };

            var created = await _estadoPreguntaAsaService.CreateEstadoPreguntaAsaAsync(estadoPreguntaAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [EstadoPreguntaAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetEstadoPreguntaAsaUri(estadoPreguntaAsa.Id.ToString());

            var response = _mapper.Map<EstadoPreguntaAsaResponse>(estadoPreguntaAsa);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.EstadoPreguntaAsas.Update)]
        [ProducesResponseType(typeof(EstadoPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int estadoPreguntaAsaId, [FromBody] UpdateEstadoPreguntaAsaRequest request)
        {
            var estadoPreguntaAsa = await _estadoPreguntaAsaService.GetEstadoPreguntaAsaByIdAsync(estadoPreguntaAsaId);
            estadoPreguntaAsa.Estado = request.Estado;

            var update = await _estadoPreguntaAsaService.UpdateEstadoPreguntaAsaAsync(estadoPreguntaAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstadoPreguntaAsaResponse>(estadoPreguntaAsa));
        }

        [HttpDelete(ApiRoute.EstadoPreguntaAsas.Delete)]
        [ProducesResponseType(typeof(EstadoPreguntaAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int estadoPreguntaAsaId)
        {
            var deleted = await _estadoPreguntaAsaService.DeleteEstadoPreguntaAsaAsync(estadoPreguntaAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
