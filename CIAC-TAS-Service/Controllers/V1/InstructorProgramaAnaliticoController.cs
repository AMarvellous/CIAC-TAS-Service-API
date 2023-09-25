using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Domain.InstructorDomain;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Produces("application/json")]
    public class InstructorProgramaAnaliticoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInstructorProgramaAnaliticoService _instructorProgramaAnaliticoService;
        private readonly IUriService _uriService;

        public InstructorProgramaAnaliticoController(IMapper mapper, IInstructorProgramaAnaliticoService instructorProgramaAnaliticoService, IUriService uriService)
        {
            _mapper = mapper;
            _instructorProgramaAnaliticoService = instructorProgramaAnaliticoService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.InstructorProgramaAnaliticos.GetAll)]
        [ProducesResponseType(typeof(InstructorProgramaAnaliticoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var instructorProgramaAnaliticos = await _instructorProgramaAnaliticoService.GetInstructorProgramaAnaliticosAsync();
            var instructorProgramaAnaliticoResponses = _mapper.Map<List<InstructorProgramaAnaliticoResponse>>(instructorProgramaAnaliticos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<InstructorProgramaAnaliticoResponse>(instructorProgramaAnaliticoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, instructorProgramaAnaliticoResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.InstructorProgramaAnaliticos.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(InstructorProgramaAnaliticoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int instructorId, [FromRoute] int programaAnaliticoPdfId)
        {
            var instructorProgramaAnalitico = await _instructorProgramaAnaliticoService.GetInstructorProgramaAnaliticoByIdAsync(instructorId, programaAnaliticoPdfId);

            if (instructorProgramaAnalitico == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InstructorProgramaAnaliticoResponse>(instructorProgramaAnalitico));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.InstructorProgramaAnaliticos.Create)]
        [ProducesResponseType(typeof(InstructorProgramaAnaliticoResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInstructorProgramaAnaliticoRequest instructorProgramaAnaliticoRequest)
        {
            var instructorProgramaAnalitico = new InstructorProgramaAnalitico
            {
                InstructorId = instructorProgramaAnaliticoRequest.InstructorId,
                ProgramaAnaliticoPdfId = instructorProgramaAnaliticoRequest.ProgramaAnaliticoPdfId
            };

            var created = await _instructorProgramaAnaliticoService.CreateInstructorProgramaAnaliticoAsync(instructorProgramaAnalitico);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [InstructorProgramaAnalitico]"}
                }
                });
            }

            var locationUri = _uriService.GetInstructorProgramaAnaliticoUri(instructorProgramaAnalitico.InstructorId.ToString(), instructorProgramaAnalitico.ProgramaAnaliticoPdfId.ToString());

            var response = _mapper.Map<InstructorProgramaAnaliticoResponse>(instructorProgramaAnalitico);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.InstructorProgramaAnaliticos.Delete)]
        [ProducesResponseType(typeof(InstructorProgramaAnaliticoResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int instructorId, [FromRoute] int programaAnaliticoPdfId)
        {
            var deleted = await _instructorProgramaAnaliticoService.DeleteInstructorProgramaAnaliticoAsync(instructorId, programaAnaliticoPdfId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.InstructorProgramaAnaliticos.GetAllByInstructorId)]
        [ProducesResponseType(typeof(InstructorProgramaAnaliticoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByInstructorId([FromRoute] int instructorId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var instructorProgramaAnaliticos = await _instructorProgramaAnaliticoService.GetInstructorProgramaAnaliticosByInstructorIdAsync(instructorId);
            var instructorProgramaAnaliticoResponses = _mapper.Map<List<InstructorProgramaAnaliticoResponse>>(instructorProgramaAnaliticos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<InstructorProgramaAnaliticoResponse>(instructorProgramaAnaliticoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, instructorProgramaAnaliticoResponses);

            return Ok(paginationResponse);
        }
    }
}
