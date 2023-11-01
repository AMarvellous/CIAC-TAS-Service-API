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
    public class RegistroNotaEstudianteHeaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRegistroNotaEstudianteHeaderService _registroNotaEstudianteHeaderService;
        private readonly IUriService _uriService;

        public RegistroNotaEstudianteHeaderController(IMapper mapper, IRegistroNotaEstudianteHeaderService registroNotaEstudianteHeaderService, IUriService uriService)
        {
            _mapper = mapper;
            _registroNotaEstudianteHeaderService = registroNotaEstudianteHeaderService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.RegistroNotaEstudianteHeaders.GetAll)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var registroNotaEstudianteHeaders = await _registroNotaEstudianteHeaderService.GetRegistroNotaEstudianteHeadersAsync();
            var registroNotaEstudianteHeaderResponses = _mapper.Map<List<RegistroNotaEstudianteHeaderResponse>>(registroNotaEstudianteHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RegistroNotaEstudianteHeaderResponse>(registroNotaEstudianteHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, registroNotaEstudianteHeaderResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.RegistroNotaEstudianteHeaders.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int registroNotaEstudianteHeaderId)
        {
            var registroNotaEstudianteHeader = await _registroNotaEstudianteHeaderService.GetRegistroNotaEstudianteHeaderByIdAsync(registroNotaEstudianteHeaderId);

            if (registroNotaEstudianteHeader == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegistroNotaEstudianteHeaderResponse>(registroNotaEstudianteHeader));
        }

        [HttpPost(ApiRoute.RegistroNotaEstudianteHeaders.Create)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteHeaderResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRegistroNotaEstudianteHeaderRequest registroNotaEstudianteHeaderRequest)
        {
            var registroNotaEstudianteHeader = new RegistroNotaEstudianteHeader
            {
                EstudianteId = registroNotaEstudianteHeaderRequest.EstudianteId,
                RegistroNotaHeaderId = registroNotaEstudianteHeaderRequest.RegistroNotaHeaderId
            };

        var created = await _registroNotaEstudianteHeaderService.CreateRegistroNotaEstudianteHeaderAsync(registroNotaEstudianteHeader);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RegistroNotaEstudianteHeader]"}
                }
                });
            }

            var locationUri = _uriService.GetRegistroNotaEstudianteHeaderUri(registroNotaEstudianteHeader.Id.ToString());

            var response = _mapper.Map<RegistroNotaEstudianteHeaderResponse>(registroNotaEstudianteHeader);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.RegistroNotaEstudianteHeaders.Update)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int registroNotaEstudianteHeaderId, [FromBody] UpdateRegistroNotaEstudianteHeaderRequest request)
        {
            var registroNotaEstudianteHeader = await _registroNotaEstudianteHeaderService.GetRegistroNotaEstudianteHeaderByIdAsync(registroNotaEstudianteHeaderId);

            registroNotaEstudianteHeader.EstudianteId = request.EstudianteId;
            registroNotaEstudianteHeader.RegistroNotaHeaderId = request.RegistroNotaHeaderId;

            var update = await _registroNotaEstudianteHeaderService.UpdateRegistroNotaEstudianteHeaderAsync(registroNotaEstudianteHeader);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegistroNotaEstudianteHeaderResponse>(registroNotaEstudianteHeader));
        }

        [HttpDelete(ApiRoute.RegistroNotaEstudianteHeaders.Delete)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteHeaderResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int registroNotaEstudianteHeaderId)
        {
            var deleted = await _registroNotaEstudianteHeaderService.DeleteRegistroNotaEstudianteHeaderAsync(registroNotaEstudianteHeaderId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoute.RegistroNotaEstudianteHeaders.GetAllByRegistroNotaHeaderId)]
        [ProducesResponseType(typeof(RegistroNotaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByRegistroNotaHeaderId([FromRoute] int registroNotaHeaderId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var registroNotaEstudianteHeaders = await _registroNotaEstudianteHeaderService.GetRegistroNotaEstudianteHeadersByRegistroNotaHeaderIdAsync(registroNotaHeaderId);
            var registroNotaEstudianteHeaderResponses = _mapper.Map<List<RegistroNotaEstudianteHeaderResponse>>(registroNotaEstudianteHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RegistroNotaEstudianteHeaderResponse>(registroNotaEstudianteHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, registroNotaEstudianteHeaderResponses);

            return Ok(paginationResponse);
        }
    }
}
