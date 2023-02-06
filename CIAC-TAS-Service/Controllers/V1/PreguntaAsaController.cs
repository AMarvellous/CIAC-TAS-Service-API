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
    public class PreguntaAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPreguntaAsaService _preguntaAsaService;
        private readonly IGrupoPreguntaAsaService _grupoPreguntaAsaService;
        private readonly IEstadoPreguntaAsaService _estadoPreguntaAsaService;
        private readonly IUriService _uriService;

        public PreguntaAsaController(IMapper mapper, IPreguntaAsaService preguntaAsaService, IGrupoPreguntaAsaService grupoPreguntaAsaService, IEstadoPreguntaAsaService estadoPreguntaAsaService, IUriService uriService)
        {
            _mapper = mapper;
            _preguntaAsaService = preguntaAsaService;
            _grupoPreguntaAsaService = grupoPreguntaAsaService;
            _estadoPreguntaAsaService = estadoPreguntaAsaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.PreguntaAsas.GetAll)]
        [ProducesResponseType(typeof(PreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var preguntaAsas = await _preguntaAsaService.GetPreguntaAsasAsync(pagination);
            var preguntaAsaResponses = _mapper.Map<List<PreguntaAsaResponse>>(preguntaAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<PreguntaAsaResponse>(preguntaAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, preguntaAsaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.PreguntaAsas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PreguntaAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int preguntaAsaId)
        {
            var preguntaAsa = await _preguntaAsaService.GetPreguntaAsaByIdAsync(preguntaAsaId);

            if (preguntaAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PreguntaAsaResponse>(preguntaAsa));
        }

        [HttpPost(ApiRoute.PreguntaAsas.Create)]
        [ProducesResponseType(typeof(PreguntaAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePreguntaAsaRequest preguntaAsaRequest)
        {
            var preguntaAsa = new PreguntaAsa
            {
                NumeroPregunta = preguntaAsaRequest.NumeroPregunta,
                Ruta = preguntaAsaRequest.Ruta,
                Pregunta = preguntaAsaRequest.Pregunta,
                GrupoPreguntaAsaId = preguntaAsaRequest.GrupoPreguntaAsaId,
                EstadoPreguntaAsaId = preguntaAsaRequest.EstadoPreguntaAsaId,
            };

            if (!await _grupoPreguntaAsaService.CheckGrupoPreguntaAsaExists(preguntaAsaRequest.GrupoPreguntaAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Grupo Pregunta Asa Id {preguntaAsaRequest.GrupoPreguntaAsaId} not found"}
                    }
                });
            }

            if (!await _estadoPreguntaAsaService.CheckEstadoPreguntaAsaExists(preguntaAsaRequest.EstadoPreguntaAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Estado Pregunta Asa Id {preguntaAsaRequest.EstadoPreguntaAsaId} not found"}
                    }
                });
            }

            var created = await _preguntaAsaService.CreatePreguntaAsaAsync(preguntaAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [PreguntaAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetPreguntaAsaUri(preguntaAsa.Id.ToString());

            var response = _mapper.Map<PreguntaAsaResponse>(preguntaAsa);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.PreguntaAsas.Update)]
        [ProducesResponseType(typeof(PreguntaAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int preguntaAsaId, [FromBody] UpdatePreguntaAsaRequest request)
        {
            var preguntaAsa = await _preguntaAsaService.GetPreguntaAsaByIdAsync(preguntaAsaId);
            preguntaAsa.NumeroPregunta = request.NumeroPregunta;
            preguntaAsa.Pregunta = request.Pregunta;
            preguntaAsa.Ruta = request.Ruta;
            preguntaAsa.GrupoPreguntaAsaId = request.GrupoPreguntaAsaId;
            preguntaAsa.EstadoPreguntaAsaId = request.EstadoPreguntaAsaId;

            if (!await _grupoPreguntaAsaService.CheckGrupoPreguntaAsaExists(request.GrupoPreguntaAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Grupo Pregunta Asa Id {request.GrupoPreguntaAsaId} not found"}
                    }
                });
            }

            if (!await _estadoPreguntaAsaService.CheckEstadoPreguntaAsaExists(request.EstadoPreguntaAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Estado Pregunta Asa Id {request.EstadoPreguntaAsaId} not found"}
                    }
                });
            }

            var update = await _preguntaAsaService.UpdatePreguntaAsaAsync(preguntaAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PreguntaAsaResponse>(preguntaAsa));
        }

        [HttpDelete(ApiRoute.PreguntaAsas.Delete)]
        [ProducesResponseType(typeof(PreguntaAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int preguntaAsaId)
        {
            var deleted = await _preguntaAsaService.DeletePreguntaAsaAsync(preguntaAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
