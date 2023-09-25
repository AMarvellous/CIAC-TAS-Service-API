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
    public class PreguntaAsaImagenAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPreguntaAsaImagenAsaService _preguntaAsaImagenAsaService;
        private readonly IPreguntaAsaService _preguntaAsaService;
        private readonly IImagenAsaService _imagenAsaService;
        private readonly IUriService _uriService;

        public PreguntaAsaImagenAsaController(IMapper mapper, IPreguntaAsaImagenAsaService preguntaAsaImagenAsaService, IPreguntaAsaService preguntaAsaService, IImagenAsaService imagenAsaService, IUriService uriService)
        {
            _mapper = mapper;
            _preguntaAsaImagenAsaService = preguntaAsaImagenAsaService;
            _preguntaAsaService = preguntaAsaService;
            _imagenAsaService = imagenAsaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.PreguntaAsaImagenAsas.GetAll)]
        [ProducesResponseType(typeof(PreguntaAsaImagenAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var preguntaAsaImagenAsas = await _preguntaAsaImagenAsaService.GetPreguntaAsaImagenAsasAsync();
            var preguntaAsaImagenAsaResponses = _mapper.Map<List<PreguntaAsaImagenAsaResponse>>(preguntaAsaImagenAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<PreguntaAsaImagenAsaResponse>(preguntaAsaImagenAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, preguntaAsaImagenAsaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.PreguntaAsaImagenAsas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PreguntaAsaImagenAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int preguntaAsaId, [FromRoute] int imagenAsaId)
        {
            var preguntaAsaImagenAsa = await _preguntaAsaImagenAsaService.GetPreguntaAsaImagenAsaByIdAsync(preguntaAsaId, imagenAsaId);

            if (preguntaAsaImagenAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PreguntaAsaImagenAsaResponse>(preguntaAsaImagenAsa));
        }

        [HttpPost(ApiRoute.PreguntaAsaImagenAsas.Create)]
        [ProducesResponseType(typeof(PreguntaAsaImagenAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePreguntaAsaImagenAsaRequest preguntaAsaImagenAsaRequest)
        {
            var preguntaAsaImagenAsa = new PreguntaAsaImagenAsa
            {
                PreguntaAsaId = preguntaAsaImagenAsaRequest.PreguntaAsaId,
                ImagenAsaId = preguntaAsaImagenAsaRequest.ImagenAsaId
            };

            if (!await _preguntaAsaService.CheckExistsPreguntaAsaAsync(preguntaAsaImagenAsaRequest.PreguntaAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"PreguntaAsa Id {preguntaAsaImagenAsaRequest.PreguntaAsaId} not found"}
                    }
                });
            }

            if (!await _imagenAsaService.CheckExistsImagenAsaAsync(preguntaAsaImagenAsaRequest.ImagenAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"ImagenAsa Id {preguntaAsaImagenAsaRequest.ImagenAsaId} not found"}
                    }
                });
            }

            if (await _preguntaAsaImagenAsaService.CheckPreguntaAsaImagenAsaExistsAsync(preguntaAsaImagenAsaRequest.PreguntaAsaId, preguntaAsaImagenAsaRequest.ImagenAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { 
                            Message = $"PreguntaAsa Id {preguntaAsaImagenAsaRequest.PreguntaAsaId} and ImagenAsa Id {preguntaAsaImagenAsaRequest.ImagenAsaId} are already assigned"
                        }
                    }
                });
            }

            var created = await _preguntaAsaImagenAsaService.CreatePreguntaAsaImagenAsaAsync(preguntaAsaImagenAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [PreguntaAsaImagenAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetPreguntaAsaImagenAsaUri(preguntaAsaImagenAsa.PreguntaAsaId.ToString(), preguntaAsaImagenAsa.ImagenAsaId.ToString());

            var response = _mapper.Map<PreguntaAsaImagenAsaResponse>(preguntaAsaImagenAsa);

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoute.PreguntaAsaImagenAsas.Delete)]
        [ProducesResponseType(typeof(PreguntaAsaImagenAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int preguntaAsaId, [FromRoute] int imagenAsaId)
        {
            var deleted = await _preguntaAsaImagenAsaService.DeletePreguntaAsaImagenAsaAsync(preguntaAsaId, imagenAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
