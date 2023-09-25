using AutoMapper;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Domain.General;
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
    public class ProgramaAnaliticoPdfController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProgramaAnaliticoPdfService _programaAnaliticoPdfService;
        private readonly IUriService _uriService;

        public ProgramaAnaliticoPdfController(IMapper mapper, IProgramaAnaliticoPdfService programaAnaliticoPdfService, IUriService uriService)
        {
            _mapper = mapper;
            _programaAnaliticoPdfService = programaAnaliticoPdfService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.ProgramaAnaliticoPdfs.GetAll)]
        [ProducesResponseType(typeof(ProgramaAnaliticoPdfResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var programaAnaliticoPdfs = await _programaAnaliticoPdfService.GetProgramaAnaliticoPdfsAsync();
            var programaAnaliticoPdfResponses = _mapper.Map<List<ProgramaAnaliticoPdfResponse>>(programaAnaliticoPdfs);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ProgramaAnaliticoPdfResponse>(programaAnaliticoPdfResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, programaAnaliticoPdfResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.ProgramaAnaliticoPdfs.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProgramaAnaliticoPdfResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int programaAnaliticoPdfId)
        {
            var programaAnaliticoPdf = await _programaAnaliticoPdfService.GetProgramaAnaliticoPdfByIdAsync(programaAnaliticoPdfId);

            if (programaAnaliticoPdf == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProgramaAnaliticoPdfResponse>(programaAnaliticoPdf));
        }

        [HttpPost(ApiRoute.ProgramaAnaliticoPdfs.Create)]
        [ProducesResponseType(typeof(ProgramaAnaliticoPdfResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProgramaAnaliticoPdfRequest programaAnaliticoPdfRequest)
        {
            var programaAnaliticoPdf = new ProgramaAnaliticoPdf
            {
                RutaPdf = programaAnaliticoPdfRequest.RutaPdf,
                MateriaId = programaAnaliticoPdfRequest.MateriaId,
                Gestion = programaAnaliticoPdfRequest.Gestion
            };

            var created = await _programaAnaliticoPdfService.CreateProgramaAnaliticoPdfAsync(programaAnaliticoPdf);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [ProgramaAnaliticoPdf]"}
                }
                });
            }

            var locationUri = _uriService.GetProgramaAnaliticoPdfUri(programaAnaliticoPdf.Id.ToString());

            var response = _mapper.Map<ProgramaAnaliticoPdfResponse>(programaAnaliticoPdf);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.ProgramaAnaliticoPdfs.Update)]
        [ProducesResponseType(typeof(ProgramaAnaliticoPdfResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int programaAnaliticoPdfId, [FromBody] UpdateProgramaAnaliticoPdfRequest request)
        {
            var programaAnaliticoPdf = await _programaAnaliticoPdfService.GetProgramaAnaliticoPdfByIdAsync(programaAnaliticoPdfId);
            programaAnaliticoPdf.RutaPdf = request.RutaPdf;
            programaAnaliticoPdf.MateriaId = request.MateriaId;
            programaAnaliticoPdf.Gestion = request.Gestion;

            var update = await _programaAnaliticoPdfService.UpdateProgramaAnaliticoPdfAsync(programaAnaliticoPdf);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProgramaAnaliticoPdfResponse>(programaAnaliticoPdf));
        }

        [HttpDelete(ApiRoute.ProgramaAnaliticoPdfs.Delete)]
        [ProducesResponseType(typeof(ProgramaAnaliticoPdfResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int programaAnaliticoPdfId)
        {
            var deleted = await _programaAnaliticoPdfService.DeleteProgramaAnaliticoPdfAsync(programaAnaliticoPdfId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoute.ProgramaAnaliticoPdfs.GetAllNotAssignedInstructor)]
        [ProducesResponseType(typeof(ProgramaAnaliticoPdfResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllNotAssignedInstructor([FromRoute] int instructorId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var programaAnaliticoPdfs = await _programaAnaliticoPdfService.GetAllNotAssignedInstructorAsync(instructorId);
            var programaAnaliticoPdfResponses = _mapper.Map<List<ProgramaAnaliticoPdfResponse>>(programaAnaliticoPdfs);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ProgramaAnaliticoPdfResponse>(programaAnaliticoPdfResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, programaAnaliticoPdfResponses);

            return Ok(paginationResponse);
        }
    }
}
