using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.InstructorDomain;
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
    public class InstructorMateriaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInstructorMateriaService _instructorMateriaService;
        private readonly IUriService _uriService;

        public InstructorMateriaController(IMapper mapper, IInstructorMateriaService instructorMateriaService, IUriService uriService)
        {
            _mapper = mapper;
            _instructorMateriaService = instructorMateriaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.InstructorMaterias.GetAll)]
        [ProducesResponseType(typeof(InstructorMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var instructorMaterias = await _instructorMateriaService.GetInstructorMateriasAsync();
            var instructorMateriaResponses = _mapper.Map<List<InstructorMateriaResponse>>(instructorMaterias);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<InstructorMateriaResponse>(instructorMateriaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, instructorMateriaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.InstructorMaterias.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(InstructorMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int instructorId, int materiaId, int grupoId)
        {
            var instructorMateria = await _instructorMateriaService.GetInstructorMateriaByIdAsync(instructorId, materiaId, grupoId);

            if (instructorMateria == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InstructorMateriaResponse>(instructorMateria));
        }

        [HttpPost(ApiRoute.InstructorMaterias.Create)]
        [ProducesResponseType(typeof(InstructorMateriaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInstructorMateriaRequest instructorMateriaRequest)
        {
            var instructorMateria = new InstructorMateria
            {
                InstructorId = instructorMateriaRequest.InstructorId,
                MateriaId = instructorMateriaRequest.MateriaId,
                GrupoId = instructorMateriaRequest.GrupoId,
            };

            var created = await _instructorMateriaService.CreateInstructorMateriaAsync(instructorMateria);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [InstructorMateria]"}
                }
                });
            }

            var locationUri = _uriService.GetInstructorMateriaUri(instructorMateria.InstructorId.ToString(), instructorMateria.MateriaId.ToString(), instructorMateria.GrupoId.ToString());

            var response = _mapper.Map<InstructorMateriaResponse>(instructorMateria);

            return Created(locationUri, response);
        }        

        [HttpDelete(ApiRoute.InstructorMaterias.Delete)]
        [ProducesResponseType(typeof(InstructorMateriaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int instructorId, int materiaId, int grupoId)
        {
            var deleted = await _instructorMateriaService.DeleteInstructorMateriaAsync(instructorId, materiaId, grupoId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoute.InstructorMaterias.GetAllByInstructorId)]
        [ProducesResponseType(typeof(InstructorMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByInstructorId([FromRoute] int instructorId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var instructorMaterias = await _instructorMateriaService.GetInstructorMateriasByInstructorIdAsync(instructorId);
            var instructorMateriaResponses = _mapper.Map<List<InstructorMateriaResponse>>(instructorMaterias);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<InstructorMateriaResponse>(instructorMateriaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, instructorMateriaResponses);

            return Ok(paginationResponse);
        }
    }
}
