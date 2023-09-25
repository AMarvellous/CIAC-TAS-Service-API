using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.General;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class ProgramaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProgramaService _programaService;
        private readonly IUriService _uriService;

        public ProgramaController(IMapper mapper, IProgramaService programaService, IUriService uriService)
        {
            _mapper = mapper;
            _programaService = programaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.Programas.GetAll)]
        [ProducesResponseType(typeof(ProgramaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var programas = await _programaService.GetProgramasAsync();
            var programaResponses = _mapper.Map<List<ProgramaResponse>>(programas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ProgramaResponse>(programaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, programaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.Programas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProgramaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int programaId)
        {
            var programa = await _programaService.GetProgramaByIdAsync(programaId);

            if (programa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProgramaResponse>(programa));
        }

        [HttpPost(ApiRoute.Programas.Create)]
        [ProducesResponseType(typeof(ProgramaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProgramaRequest programaRequest)
        {
            var programa = new Programa
            {
                Nombre = programaRequest.Nombre
            };

            var created = await _programaService.CreateProgramaAsync(programa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [Programa]"}
                }
                });
            }

            var locationUri = _uriService.GetProgramaUri(programa.Id.ToString());

            var response = _mapper.Map<ProgramaResponse>(programa);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.Programas.Update)]
        [ProducesResponseType(typeof(ProgramaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int programaId, [FromBody] UpdateProgramaRequest request)
        {
            var programa = await _programaService.GetProgramaByIdAsync(programaId);
            programa.Nombre = request.Nombre;

            var update = await _programaService.UpdateProgramaAsync(programa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProgramaResponse>(programa));
        }

        [HttpDelete(ApiRoute.Programas.Delete)]
        [ProducesResponseType(typeof(ProgramaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int programaId)
        {
            var deleted = await _programaService.DeleteProgramaAsync(programaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
