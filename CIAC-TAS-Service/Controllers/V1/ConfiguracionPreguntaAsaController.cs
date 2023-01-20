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
    public class ConfiguracionPreguntaAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguracionPreguntaAsaService _configuracionPreguntaAsaService;
        private readonly IUriService _uriService;

        public ConfiguracionPreguntaAsaController(IMapper mapper, IConfiguracionPreguntaAsaService configuracionPreguntaAsaService, IUriService uriService)
        {
            _mapper = mapper;
            _configuracionPreguntaAsaService = configuracionPreguntaAsaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.ConfiguracionPreguntaAsas.GetAll)]
        [ProducesResponseType(typeof(ConfiguracionPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var configuracionPreguntaAsas = await _configuracionPreguntaAsaService.GetConfiguracionPreguntaAsasAsync(pagination);
            var configuracionPreguntaAsaResponses = _mapper.Map<List<ConfiguracionPreguntaAsaResponse>>(configuracionPreguntaAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ConfiguracionPreguntaAsaResponse>(configuracionPreguntaAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, configuracionPreguntaAsaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.ConfiguracionPreguntaAsas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ConfiguracionPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int configuracionPreguntaAsaId)
        {
            var configuracionPreguntaAsa = await _configuracionPreguntaAsaService.GetConfiguracionPreguntaAsaByIdAsync(configuracionPreguntaAsaId);

            if (configuracionPreguntaAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ConfiguracionPreguntaAsaResponse>(configuracionPreguntaAsa));
        }

        [HttpPost(ApiRoute.ConfiguracionPreguntaAsas.Create)]
        [ProducesResponseType(typeof(ConfiguracionPreguntaAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateConfiguracionPreguntaAsaRequest configuracionPreguntaAsaRequest)
        {
            var configuracionPreguntaAsa = _mapper.Map<ConfiguracionPreguntaAsa>(configuracionPreguntaAsaRequest);

            var created = await _configuracionPreguntaAsaService.CreateConfiguracionPreguntaAsaAsync(configuracionPreguntaAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [ConfiguracionPreguntaAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetConfiguracionPreguntaAsaUri(configuracionPreguntaAsa.Id.ToString());

            var response = _mapper.Map<ConfiguracionPreguntaAsaResponse>(configuracionPreguntaAsa);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.ConfiguracionPreguntaAsas.Update)]
        [ProducesResponseType(typeof(ConfiguracionPreguntaAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int configuracionPreguntaAsaId, [FromBody] UpdateConfiguracionPreguntaAsaRequest request)
        {
            var configuracionPreguntaAsa = await _configuracionPreguntaAsaService.GetConfiguracionPreguntaAsaByIdAsync(configuracionPreguntaAsaId);
            _mapper.Map(request, configuracionPreguntaAsa);

            var update = await _configuracionPreguntaAsaService.UpdateConfiguracionPreguntaAsaAsync(configuracionPreguntaAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ConfiguracionPreguntaAsaResponse>(configuracionPreguntaAsa));
        }

        [HttpDelete(ApiRoute.ConfiguracionPreguntaAsas.Delete)]
        [ProducesResponseType(typeof(ConfiguracionPreguntaAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int configuracionPreguntaAsaId)
        {
            var deleted = await _configuracionPreguntaAsaService.DeleteConfiguracionPreguntaAsaAsync(configuracionPreguntaAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
