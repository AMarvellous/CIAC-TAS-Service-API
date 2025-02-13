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
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
    [Produces("application/json")]
    public class RegistroNotaEstudianteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRegistroNotaEstudianteService _registroNotaEstudianteService;
        private readonly IUriService _uriService;

        public RegistroNotaEstudianteController(IMapper mapper, IRegistroNotaEstudianteService registroNotaEstudianteService, IUriService uriService)
        {
            _mapper = mapper;
            _registroNotaEstudianteService = registroNotaEstudianteService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.RegistroNotaEstudiantes.GetAll)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var registroNotaEstudiantes = await _registroNotaEstudianteService.GetRegistroNotaEstudiantesAsync();
            var registroNotaEstudianteResponses = _mapper.Map<List<RegistroNotaEstudianteResponse>>(registroNotaEstudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RegistroNotaEstudianteResponse>(registroNotaEstudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, registroNotaEstudianteResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.RegistroNotaEstudiantes.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int registroNotaEstudianteId)
        {
            var registroNotaEstudiante = await _registroNotaEstudianteService.GetRegistroNotaEstudianteByIdAsync(registroNotaEstudianteId);

            if (registroNotaEstudiante == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegistroNotaEstudianteResponse>(registroNotaEstudiante));
        }

        [HttpPost(ApiRoute.RegistroNotaEstudiantes.Create)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRegistroNotaEstudianteRequest registroNotaEstudianteRequest)
        {
            var registroNotaEstudiante = new RegistroNotaEstudiante
            {
                RegistroNotaEstudianteHeaderId = registroNotaEstudianteRequest.RegistroNotaEstudianteHeaderId,
                Nota = registroNotaEstudianteRequest.Nota,
                TipoRegistroNotaEstudianteId = registroNotaEstudianteRequest.TipoRegistroNotaEstudianteId,
            };

        var created = await _registroNotaEstudianteService.CreateRegistroNotaEstudianteAsync(registroNotaEstudiante);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RegistroNotaEstudiante]"}
                }
                });
            }

            var locationUri = _uriService.GetRegistroNotaEstudianteUri(registroNotaEstudiante.Id.ToString());

            var response = _mapper.Map<RegistroNotaEstudianteResponse>(registroNotaEstudiante);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.RegistroNotaEstudiantes.Update)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int registroNotaEstudianteId, [FromBody] UpdateRegistroNotaEstudianteRequest request)
        {
            var registroNotaEstudiante = await _registroNotaEstudianteService.GetRegistroNotaEstudianteByIdAsync(registroNotaEstudianteId);

            registroNotaEstudiante.RegistroNotaEstudianteHeaderId = request.RegistroNotaEstudianteHeaderId;
            registroNotaEstudiante.Nota = request.Nota;
            registroNotaEstudiante.TipoRegistroNotaEstudianteId = request.TipoRegistroNotaEstudianteId;

            var update = await _registroNotaEstudianteService.UpdateRegistroNotaEstudianteAsync(registroNotaEstudiante);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegistroNotaEstudianteResponse>(registroNotaEstudiante));
        }

        [HttpDelete(ApiRoute.RegistroNotaEstudiantes.Delete)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int registroNotaEstudianteId)
        {
            var deleted = await _registroNotaEstudianteService.DeleteRegistroNotaEstudianteAsync(registroNotaEstudianteId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoute.RegistroNotaEstudiantes.GetAllByRegistroNotaEstudianteHeaderId)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByRegistroNotaEstudianteHeaderId([FromRoute] int registroNotaEstudianteHeaderId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var registroNotaEstudiantes = await _registroNotaEstudianteService.GetRegistroNotaEstudiantesByRegistroNotaEstudianteHeaderIdAsync(registroNotaEstudianteHeaderId);
            var registroNotaEstudianteResponses = _mapper.Map<List<RegistroNotaEstudianteResponse>>(registroNotaEstudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RegistroNotaEstudianteResponse>(registroNotaEstudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, registroNotaEstudianteResponses);

            return Ok(paginationResponse);
        }
    }
}
