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
    public class TipoRegistroNotaEstudianteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITipoRegistroNotaEstudianteService _tipoRegistroNotaEstudianteService;
        private readonly IUriService _uriService;

        public TipoRegistroNotaEstudianteController(IMapper mapper, ITipoRegistroNotaEstudianteService tipoRegistroNotaEstudianteService, IUriService uriService)
        {
            _mapper = mapper;
            _tipoRegistroNotaEstudianteService = tipoRegistroNotaEstudianteService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.TipoRegistroNotaEstudiantes.GetAll)]
        [ProducesResponseType(typeof(TipoRegistroNotaEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var tipoRegistroNotaEstudiantes = await _tipoRegistroNotaEstudianteService.GetTipoRegistroNotaEstudiantesAsync();
            var tipoRegistroNotaEstudianteResponses = _mapper.Map<List<TipoRegistroNotaEstudianteResponse>>(tipoRegistroNotaEstudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<TipoRegistroNotaEstudianteResponse>(tipoRegistroNotaEstudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, tipoRegistroNotaEstudianteResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.TipoRegistroNotaEstudiantes.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TipoRegistroNotaEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int tipoRegistroNotaEstudianteId)
        {
            var tipoRegistroNotaEstudiante = await _tipoRegistroNotaEstudianteService.GetTipoRegistroNotaEstudianteByIdAsync(tipoRegistroNotaEstudianteId);

            if (tipoRegistroNotaEstudiante == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoRegistroNotaEstudianteResponse>(tipoRegistroNotaEstudiante));
        }

        [HttpPost(ApiRoute.TipoRegistroNotaEstudiantes.Create)]
        [ProducesResponseType(typeof(TipoRegistroNotaEstudianteResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateTipoRegistroNotaEstudianteRequest tipoRegistroNotaEstudianteRequest)
        {
            var tipoRegistroNotaEstudiante = new TipoRegistroNotaEstudiante
            {
                Nombre = tipoRegistroNotaEstudianteRequest.Nombre
            };

            var created = await _tipoRegistroNotaEstudianteService.CreateTipoRegistroNotaEstudianteAsync(tipoRegistroNotaEstudiante);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [TipoRegistroNotaEstudiante]"}
                }
                });
            }

            var locationUri = _uriService.GetTipoRegistroNotaEstudianteUri(tipoRegistroNotaEstudiante.Id.ToString());

            var response = _mapper.Map<TipoRegistroNotaEstudianteResponse>(tipoRegistroNotaEstudiante);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.TipoRegistroNotaEstudiantes.Update)]
        [ProducesResponseType(typeof(TipoRegistroNotaEstudianteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int tipoRegistroNotaEstudianteId, [FromBody] UpdateTipoRegistroNotaEstudianteRequest request)
        {
            var tipoRegistroNotaEstudiante = await _tipoRegistroNotaEstudianteService.GetTipoRegistroNotaEstudianteByIdAsync(tipoRegistroNotaEstudianteId);
            tipoRegistroNotaEstudiante.Nombre = request.Nombre;

            var update = await _tipoRegistroNotaEstudianteService.UpdateTipoRegistroNotaEstudianteAsync(tipoRegistroNotaEstudiante);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TipoRegistroNotaEstudianteResponse>(tipoRegistroNotaEstudiante));
        }

        [HttpDelete(ApiRoute.TipoRegistroNotaEstudiantes.Delete)]
        [ProducesResponseType(typeof(TipoRegistroNotaEstudianteResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int tipoRegistroNotaEstudianteId)
        {
            var deleted = await _tipoRegistroNotaEstudianteService.DeleteTipoRegistroNotaEstudianteAsync(tipoRegistroNotaEstudianteId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
