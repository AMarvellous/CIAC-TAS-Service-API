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
    [Produces("application/json")]
    public class InhabilitacionEstudianteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInhabilitacionEstudianteService _inhabilitacionEstudianteService;
        private readonly IUriService _uriService;

        public InhabilitacionEstudianteController(IMapper mapper, IInhabilitacionEstudianteService inhabilitacionEstudianteService, IUriService uriService)
        {
            _mapper = mapper;
            _inhabilitacionEstudianteService = inhabilitacionEstudianteService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.InhabilitacionEstudiantes.GetAll)]
        [ProducesResponseType(typeof(InhabilitacionEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var inhabilitacionEstudiantes = await _inhabilitacionEstudianteService.GetInhabilitacionEstudiantesAsync();
            var inhabilitacionEstudianteResponses = _mapper.Map<List<InhabilitacionEstudianteResponse>>(inhabilitacionEstudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<InhabilitacionEstudianteResponse>(inhabilitacionEstudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, inhabilitacionEstudianteResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.InhabilitacionEstudiantes.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(InhabilitacionEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int inhabilitacionEstudianteId)
        {
            var inhabilitacionEstudiante = await _inhabilitacionEstudianteService.GetInhabilitacionEstudianteByIdAsync(inhabilitacionEstudianteId);

            if (inhabilitacionEstudiante == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InhabilitacionEstudianteResponse>(inhabilitacionEstudiante));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.InhabilitacionEstudiantes.Create)]
        [ProducesResponseType(typeof(InhabilitacionEstudianteResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInhabilitacionEstudianteRequest inhabilitacionEstudianteRequest)
        {
            var inhabilitacionEstudiante = new InhabilitacionEstudiante
            {
                 EstudianteId = inhabilitacionEstudianteRequest.EstudianteId,
                 Motivo = inhabilitacionEstudianteRequest.Motivo
            };

            var created = await _inhabilitacionEstudianteService.CreateInhabilitacionEstudianteAsync(inhabilitacionEstudiante);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [InhabilitacionEstudiante]"}
                }
                });
            }

            var locationUri = _uriService.GetInhabilitacionEstudianteUri(inhabilitacionEstudiante.Id.ToString());

            var response = _mapper.Map<InhabilitacionEstudianteResponse>(inhabilitacionEstudiante);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut(ApiRoute.InhabilitacionEstudiantes.Update)]
        [ProducesResponseType(typeof(InhabilitacionEstudianteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int inhabilitacionEstudianteId, [FromBody] UpdateInhabilitacionEstudianteRequest request)
        {
            var inhabilitacionEstudiante = await _inhabilitacionEstudianteService.GetInhabilitacionEstudianteByIdAsync(inhabilitacionEstudianteId);
            inhabilitacionEstudiante.EstudianteId = request.EstudianteId;
            inhabilitacionEstudiante.Motivo = request.Motivo;

            var update = await _inhabilitacionEstudianteService.UpdateInhabilitacionEstudianteAsync(inhabilitacionEstudiante);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InhabilitacionEstudianteResponse>(inhabilitacionEstudiante));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.InhabilitacionEstudiantes.Delete)]
        [ProducesResponseType(typeof(InhabilitacionEstudianteResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int inhabilitacionEstudianteId)
        {
            var deleted = await _inhabilitacionEstudianteService.DeleteInhabilitacionEstudianteAsync(inhabilitacionEstudianteId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor,Estudiante")]
        [HttpGet(ApiRoute.InhabilitacionEstudiantes.GetByEstudianteId)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(InhabilitacionEstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByEstudianteId([FromRoute] int estudianteId)
        {
            var inhabilitacionEstudiante = await _inhabilitacionEstudianteService.GetInhabilitacionEstudianteByEstudianteIdAsync(estudianteId);

            if (inhabilitacionEstudiante == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InhabilitacionEstudianteResponse>(inhabilitacionEstudiante));
        }
    }
}
