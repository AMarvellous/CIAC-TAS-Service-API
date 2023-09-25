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
    public class PreguntaAsaOpcionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPreguntaAsaOpcionService _preguntaAsaOpcionService;
        private readonly IPreguntaAsaService _preguntaAsaService;
        private readonly IUriService _uriService;

        public PreguntaAsaOpcionController(IMapper mapper, IPreguntaAsaOpcionService preguntaAsaOpcionService, IUriService uriService, IPreguntaAsaService preguntaAsaService)
        {
            _mapper = mapper;
            _preguntaAsaOpcionService = preguntaAsaOpcionService;
            _uriService = uriService;
            _preguntaAsaService = preguntaAsaService;
        }

        [HttpGet(ApiRoute.PreguntaAsaOpciones.GetAll)]
        [ProducesResponseType(typeof(PreguntaAsaOpcionResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var preguntaAsaOpcions = await _preguntaAsaOpcionService.GetPreguntaAsaOpcionsAsync();
            var preguntaAsaOpcionResponses = _mapper.Map<List<PreguntaAsaOpcionResponse>>(preguntaAsaOpcions);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<PreguntaAsaOpcionResponse>(preguntaAsaOpcionResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, preguntaAsaOpcionResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.PreguntaAsaOpciones.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(PreguntaAsaOpcionResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int preguntaAsaOpcionId)
        {
            var preguntaAsaOpcion = await _preguntaAsaOpcionService.GetPreguntaAsaOpcionByIdAsync(preguntaAsaOpcionId);

            if (preguntaAsaOpcion == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PreguntaAsaOpcionResponse>(preguntaAsaOpcion));
        }

        [HttpPost(ApiRoute.PreguntaAsaOpciones.Create)]
        [ProducesResponseType(typeof(PreguntaAsaOpcionResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePreguntaAsaOpcionRequest preguntaAsaOpcionRequest)
        {
            var preguntaAsaOpcion = new PreguntaAsaOpcion
            {
                Opcion = preguntaAsaOpcionRequest.Opcion,
                Texto = preguntaAsaOpcionRequest.Texto,
                RespuestaValida = preguntaAsaOpcionRequest.RespuestaValida,
                PreguntaAsaId = preguntaAsaOpcionRequest.PreguntaAsaId
            };

            if (!await _preguntaAsaService.CheckExistsPreguntaAsaAsync(preguntaAsaOpcionRequest.PreguntaAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"PreguntaAsa Id {preguntaAsaOpcionRequest.PreguntaAsaId} not found"}
                    }
                });
            }

            var created = await _preguntaAsaOpcionService.CreatePreguntaAsaOpcionAsync(preguntaAsaOpcion);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [PreguntaAsaOpcion]"}
                }
                });
            }

            var locationUri = _uriService.GetPreguntaAsaOpcionUri(preguntaAsaOpcion.Id.ToString());

            var response = _mapper.Map<PreguntaAsaOpcionResponse>(preguntaAsaOpcion);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.PreguntaAsaOpciones.Update)]
        [ProducesResponseType(typeof(PreguntaAsaOpcionResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int preguntaAsaOpcionId, [FromBody] UpdatePreguntaAsaOpcionRequest request)
        {
            if (!await _preguntaAsaService.CheckExistsPreguntaAsaAsync(request.PreguntaAsaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"PreguntaAsa Id {request.PreguntaAsaId} not found"}
                    }
                });
            }

            var preguntaAsaOpcion = await _preguntaAsaOpcionService.GetPreguntaAsaOpcionByIdAsync(preguntaAsaOpcionId);

            preguntaAsaOpcion.Opcion = request.Opcion;
            preguntaAsaOpcion.Texto = request.Texto;
            preguntaAsaOpcion.RespuestaValida = request.RespuestaValida;
            preguntaAsaOpcion.PreguntaAsaId = request.PreguntaAsaId;            

            var update = await _preguntaAsaOpcionService.UpdatePreguntaAsaOpcionAsync(preguntaAsaOpcion);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PreguntaAsaOpcionResponse>(preguntaAsaOpcion));
        }

        [HttpDelete(ApiRoute.PreguntaAsaOpciones.Delete)]
        [ProducesResponseType(typeof(PreguntaAsaOpcionResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int preguntaAsaOpcionId)
        {
            var deleted = await _preguntaAsaOpcionService.DeletePreguntaAsaOpcionAsync(preguntaAsaOpcionId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
