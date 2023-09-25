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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class EstudianteProgramaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEstudianteProgramaService _estudianteProgramaService;
        private readonly IUriService _uriService;

        public EstudianteProgramaController(IMapper mapper, IEstudianteProgramaService estudianteProgramaService, IUriService uriService)
        {
            _mapper = mapper;
            _estudianteProgramaService = estudianteProgramaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.EstudianteProgramas.GetAll)]
        [ProducesResponseType(typeof(EstudianteProgramaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudianteProgramas = await _estudianteProgramaService.GetEstudianteProgramasAsync();
            var estudianteProgramaResponses = _mapper.Map<List<EstudianteProgramaResponse>>(estudianteProgramas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteProgramaResponse>(estudianteProgramaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteProgramaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.EstudianteProgramas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstudianteProgramaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int estudianteId, [FromRoute] int programaId)
        {
            var estudiantePrograma = await _estudianteProgramaService.GetEstudianteProgramaByIdAsync(estudianteId, programaId);

            if (estudiantePrograma == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstudianteProgramaResponse>(estudiantePrograma));
        }

        [HttpPost(ApiRoute.EstudianteProgramas.Create)]
        [ProducesResponseType(typeof(EstudianteProgramaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEstudianteProgramaRequest estudianteProgramaRequest)
        {
            var estudiantePrograma = new EstudiantePrograma
            {
                EstudianteId = estudianteProgramaRequest.EstudianteId,
                ProgramaId = estudianteProgramaRequest.ProgramaId
            };

            var estudianteGrupoDB = await _estudianteProgramaService.GetEstudianteProgramaByIdAsync(estudiantePrograma.EstudianteId, estudiantePrograma.ProgramaId);
            
            if (estudianteGrupoDB != null)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel {
                            Message = $"El Estudiante {estudiantePrograma.EstudianteId} y Programa {estudiantePrograma.ProgramaId} ya fueron asignados previamente"}
                    }
                });
            }

            var created = await _estudianteProgramaService.CreateEstudianteProgramaAsync(estudiantePrograma);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [EstudiantePrograma]"}
                }
                });
            }

            var locationUri = _uriService.GetEstudianteProgramaUri(estudiantePrograma.EstudianteId.ToString(), estudiantePrograma.ProgramaId.ToString());

            var response = _mapper.Map<EstudianteProgramaResponse>(estudiantePrograma);

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoute.EstudianteProgramas.Delete)]
        [ProducesResponseType(typeof(EstudianteProgramaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int estudianteId, [FromRoute] int programaId)
        {
            var deleted = await _estudianteProgramaService.DeleteEstudianteProgramaAsync(estudianteId, programaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
