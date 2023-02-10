using AutoMapper;
using CIAC_TAS_Service.Cache;
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
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Controllers.V1
{
    
    [Produces("application/json")]
    public class GrupoPreguntaAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGrupoPreguntaAsaService _grupoPreguntaAsaService;
        private readonly IUriService _uriService;

        public GrupoPreguntaAsaController(IMapper mapper, IGrupoPreguntaAsaService grupoPreguntaAsaService, IUriService uriService)
        {
            _mapper = mapper;
            _grupoPreguntaAsaService = grupoPreguntaAsaService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [HttpGet(ApiRoute.GrupoPreguntaAsas.GetAll)]
        [ProducesResponseType(typeof(GrupoPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var grupoPreguntaAsas = await _grupoPreguntaAsaService.GetGrupoPreguntaAsasAsync(pagination);
            var grupoPreguntaAsaResponses = _mapper.Map<List<GrupoPreguntaAsaResponse>>(grupoPreguntaAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<GrupoPreguntaAsaResponse>(grupoPreguntaAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, grupoPreguntaAsaResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.GrupoPreguntaAsas.Get)]
        [Cached(600)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GrupoPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int grupoPreguntaAsaId)
        {
            var grupoPreguntaAsa = await _grupoPreguntaAsaService.GetGrupoPreguntaAsaByIdAsync(grupoPreguntaAsaId);

            if (grupoPreguntaAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GrupoPreguntaAsaResponse>(grupoPreguntaAsa));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.GrupoPreguntaAsas.Create)]
        [ProducesResponseType(typeof(GrupoPreguntaAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateGrupoPreguntaAsaRequest grupoPreguntaAsaRequest)
        {
            var grupoPreguntaAsa = new GrupoPreguntaAsa
            {
                Nombre = grupoPreguntaAsaRequest.Nombre
            };

            var created = await _grupoPreguntaAsaService.CreateGrupoPreguntaAsaAsync(grupoPreguntaAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [GrupoPreguntaAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetGrupoPreguntaAsaUri(grupoPreguntaAsa.Id.ToString());

            var response = _mapper.Map<GrupoPreguntaAsaResponse>(grupoPreguntaAsa);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut(ApiRoute.GrupoPreguntaAsas.Update)]
        [ProducesResponseType(typeof(GrupoPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int grupoPreguntaAsaId, [FromBody] UpdateGrupoPreguntaAsaRequest request)
        {
            var grupoPreguntaAsa = await _grupoPreguntaAsaService.GetGrupoPreguntaAsaByIdAsync(grupoPreguntaAsaId);
            grupoPreguntaAsa.Nombre = request.Nombre;

            var update = await _grupoPreguntaAsaService.UpdateGrupoPreguntaAsaAsync(grupoPreguntaAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GrupoPreguntaAsaResponse>(grupoPreguntaAsa));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.GrupoPreguntaAsas.Delete)]
        [ProducesResponseType(typeof(GrupoPreguntaAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int grupoPreguntaAsaId)
        {
            var deleted = await _grupoPreguntaAsaService.DeleteGrupoPreguntaAsaAsync(grupoPreguntaAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
