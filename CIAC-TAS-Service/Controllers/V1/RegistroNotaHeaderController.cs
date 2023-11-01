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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
    [Produces("application/json")]
    public class RegistroNotaHeaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRegistroNotaHeaderService _registroNotaHeaderService;
        private readonly IUriService _uriService;

        public RegistroNotaHeaderController(IMapper mapper, IRegistroNotaHeaderService registroNotaHeaderService, IUriService uriService)
        {
            _mapper = mapper;
            _registroNotaHeaderService = registroNotaHeaderService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.RegistroNotaHeaders.GetAll)]
        [ProducesResponseType(typeof(RegistroNotaHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var registroNotaHeaders = await _registroNotaHeaderService.GetRegistroNotaHeadersAsync();
            var registroNotaHeaderResponses = _mapper.Map<List<RegistroNotaHeaderResponse>>(registroNotaHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RegistroNotaHeaderResponse>(registroNotaHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, registroNotaHeaderResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.RegistroNotaHeaders.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RegistroNotaHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int registroNotaHeaderId)
        {
            var registroNotaHeader = await _registroNotaHeaderService.GetRegistroNotaHeaderByIdAsync(registroNotaHeaderId);

            if (registroNotaHeader == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegistroNotaHeaderResponse>(registroNotaHeader));
        }

        [HttpPost(ApiRoute.RegistroNotaHeaders.Create)]
        [ProducesResponseType(typeof(RegistroNotaHeaderResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRegistroNotaHeaderRequest registroNotaHeaderRequest)
        {
            var registroNotaHeader = new RegistroNotaHeader
            {
                ProgramaId = registroNotaHeaderRequest.ProgramaId,
                GrupoId = registroNotaHeaderRequest.GrupoId,
                MateriaId = registroNotaHeaderRequest.MateriaId,
                ModuloId = registroNotaHeaderRequest.ModuloId,
                InstructorId = registroNotaHeaderRequest.InstructorId,
                IsLocked = registroNotaHeaderRequest.IsLocked,
                PorcentajeDominioTotal = registroNotaHeaderRequest.PorcentajeDominioTotal,
                PorcentajeProgresoTotal = registroNotaHeaderRequest.PorcentajeProgresoTotal
            };

        var created = await _registroNotaHeaderService.CreateRegistroNotaHeaderAsync(registroNotaHeader);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RegistroNotaHeader]"}
                }
                });
            }

            var locationUri = _uriService.GetRegistroNotaHeaderUri(registroNotaHeader.Id.ToString());

            var response = _mapper.Map<RegistroNotaHeaderResponse>(registroNotaHeader);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.RegistroNotaHeaders.Update)]
        [ProducesResponseType(typeof(RegistroNotaHeaderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int registroNotaHeaderId, [FromBody] UpdateRegistroNotaHeaderRequest request)
        {
            var registroNotaHeader = await _registroNotaHeaderService.GetRegistroNotaHeaderByIdAsync(registroNotaHeaderId);

            registroNotaHeader.ProgramaId = request.ProgramaId;
            registroNotaHeader.GrupoId = request.GrupoId;
            registroNotaHeader.MateriaId = request.MateriaId;
            registroNotaHeader.ModuloId = request.ModuloId;
            registroNotaHeader.InstructorId = request.InstructorId;
            registroNotaHeader.IsLocked = request.IsLocked;
            registroNotaHeader.PorcentajeDominioTotal = request.PorcentajeDominioTotal;
            registroNotaHeader.PorcentajeProgresoTotal = request.PorcentajeProgresoTotal;

            var update = await _registroNotaHeaderService.UpdateRegistroNotaHeaderAsync(registroNotaHeader);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegistroNotaHeaderResponse>(registroNotaHeader));
        }

        [HttpDelete(ApiRoute.RegistroNotaHeaders.Delete)]
        [ProducesResponseType(typeof(RegistroNotaHeaderResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int registroNotaHeaderId)
        {
            var deleted = await _registroNotaHeaderService.DeleteRegistroNotaHeaderAsync(registroNotaHeaderId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoute.RegistroNotaHeaders.GetAllHeadersByGrupoAndMateriaId)]
        [ProducesResponseType(typeof(RegistroNotaHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllHeadersByGrupoAndMateriaId([FromRoute] int grupoId, [FromRoute] int materiaId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var registroNotaHeaders = await _registroNotaHeaderService.GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(grupoId, materiaId);
            var registroNotaHeaderResponses = _mapper.Map<List<RegistroNotaHeaderResponse>>(registroNotaHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RegistroNotaHeaderResponse>(registroNotaHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, registroNotaHeaderResponses);

            return Ok(paginationResponse);
        }

        [HttpPost(ApiRoute.RegistroNotaHeaders.CreateRegistroNotaEstudianteHeader)]
        [ProducesResponseType(typeof(RegistroNotaHeaderResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRegistroNotaEstudianteHeader([FromBody] CreateRegistroNotaHeaderRequest request)
        {
            var registroNotaHeader = new RegistroNotaHeader
            {
                ProgramaId = request.ProgramaId,
                GrupoId = request.GrupoId,
                MateriaId = request.MateriaId,
                ModuloId = request.ModuloId,
                InstructorId = request.InstructorId,
                IsLocked = request.IsLocked,
                PorcentajeDominioTotal = request.PorcentajeDominioTotal,
                PorcentajeProgresoTotal = request.PorcentajeProgresoTotal
            };

            var created = await _registroNotaHeaderService.CreateRegistroNotaEstudianteHeaderAsync(registroNotaHeader);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RegistroNotaHeader]"}
                }
                });
            }

            var locationUri = _uriService.GetRegistroNotaHeaderUri(registroNotaHeader.Id.ToString());

            var response = _mapper.Map<RegistroNotaHeaderResponse>(registroNotaHeader);

            return Created(locationUri, response);
        }
    }
}
