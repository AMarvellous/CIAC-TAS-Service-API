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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Instructor")]
    [Produces("application/json")]
    public class AsistenciaEstudianteHeaderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAsistenciaEstudianteHeaderService _asistenciaEstudianteHeaderService;
        private readonly IUriService _uriService;

        public AsistenciaEstudianteHeaderController(IMapper mapper, IAsistenciaEstudianteHeaderService asistenciaEstudianteHeaderService, IUriService uriService)
        {
            _mapper = mapper;
            _asistenciaEstudianteHeaderService = asistenciaEstudianteHeaderService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.AsistenciaEstudianteHeaders.GetAll)]
        [ProducesResponseType(typeof(AsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var asistenciaEstudianteHeaders = await _asistenciaEstudianteHeaderService.GetAsistenciaEstudianteHeadersAsync();
            var asistenciaEstudianteHeaderResponses = _mapper.Map<List<AsistenciaEstudianteHeaderResponse>>(asistenciaEstudianteHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<AsistenciaEstudianteHeaderResponse>(asistenciaEstudianteHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, asistenciaEstudianteHeaderResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.AsistenciaEstudianteHeaders.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(AsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int asistenciaEstudianteHeaderId)
        {
            var asistenciaEstudianteHeader = await _asistenciaEstudianteHeaderService.GetAsistenciaEstudianteHeaderByIdAsync(asistenciaEstudianteHeaderId);

            if (asistenciaEstudianteHeader == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AsistenciaEstudianteHeaderResponse>(asistenciaEstudianteHeader));
        }

        [HttpPost(ApiRoute.AsistenciaEstudianteHeaders.Create)]
        [ProducesResponseType(typeof(AsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAsistenciaEstudianteHeaderRequest asistenciaEstudianteHeaderRequest)
        {
            var asistenciaEstudianteHeader = new AsistenciaEstudianteHeader
            {
               
                ProgramaId = asistenciaEstudianteHeaderRequest.ProgramaId,
                GrupoId = asistenciaEstudianteHeaderRequest.GrupoId,
                MateriaId = asistenciaEstudianteHeaderRequest.MateriaId,
                ModuloId = asistenciaEstudianteHeaderRequest.ModuloId,
                InstructorId = asistenciaEstudianteHeaderRequest.InstructorId,
                Fecha = asistenciaEstudianteHeaderRequest.Fecha,
                HoraInicio = asistenciaEstudianteHeaderRequest.HoraInicio,
                HoraFin = asistenciaEstudianteHeaderRequest.HoraFin,
                TotalHorasTeoricas = asistenciaEstudianteHeaderRequest.TotalHorasTeoricas,
                TotalHorasPracticas = asistenciaEstudianteHeaderRequest.TotalHorasPracticas,
                Tema = asistenciaEstudianteHeaderRequest.Tema
            };

            var created = await _asistenciaEstudianteHeaderService.CreateAsistenciaEstudianteHeaderAsync(asistenciaEstudianteHeader);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [AsistenciaEstudianteHeader]"}
                }
                });
            }

            var locationUri = _uriService.GetAsistenciaEstudianteHeaderUri(asistenciaEstudianteHeader.Id.ToString());

            var response = _mapper.Map<AsistenciaEstudianteHeaderResponse>(asistenciaEstudianteHeader);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.AsistenciaEstudianteHeaders.Update)]
        [ProducesResponseType(typeof(AsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int asistenciaEstudianteHeaderId, [FromBody] UpdateAsistenciaEstudianteHeaderRequest request)
        {
            var asistenciaEstudianteHeader = await _asistenciaEstudianteHeaderService.GetAsistenciaEstudianteHeaderByIdAsync(asistenciaEstudianteHeaderId);

            asistenciaEstudianteHeader.ProgramaId = request.ProgramaId;               
            asistenciaEstudianteHeader.GrupoId = request.GrupoId;           
            asistenciaEstudianteHeader.MateriaId = request.MateriaId;
            asistenciaEstudianteHeader.ModuloId = request.ModuloId;                
            asistenciaEstudianteHeader.InstructorId = request.InstructorId;           
            asistenciaEstudianteHeader.Fecha = request.Fecha;
            asistenciaEstudianteHeader.HoraInicio = request.HoraInicio;
            asistenciaEstudianteHeader.HoraFin = request.HoraFin;
            asistenciaEstudianteHeader.TotalHorasTeoricas = request.TotalHorasTeoricas;
            asistenciaEstudianteHeader.TotalHorasPracticas = request.TotalHorasPracticas;
            asistenciaEstudianteHeader.Tema = request.Tema;

            var update = await _asistenciaEstudianteHeaderService.UpdateAsistenciaEstudianteHeaderAsync(asistenciaEstudianteHeader);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AsistenciaEstudianteHeaderResponse>(asistenciaEstudianteHeader));
        }

        [HttpDelete(ApiRoute.AsistenciaEstudianteHeaders.Delete)]
        [ProducesResponseType(typeof(AsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int asistenciaEstudianteHeaderId)
        {
            var deleted = await _asistenciaEstudianteHeaderService.DeleteAsistenciaEstudianteHeaderAsync(asistenciaEstudianteHeaderId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet(ApiRoute.AsistenciaEstudianteHeaders.GetAllHeadersByGrupoAndMateriaId)]
        [ProducesResponseType(typeof(AsistenciaEstudianteHeaderResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllHeadersByGrupoAndMateriaId([FromRoute] int grupoId, [FromRoute] int materiaId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var asistenciaEstudianteHeaders = await _asistenciaEstudianteHeaderService.GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(grupoId, materiaId);
            var asistenciaEstudianteHeaderResponses = _mapper.Map<List<AsistenciaEstudianteHeaderResponse>>(asistenciaEstudianteHeaders);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<AsistenciaEstudianteHeaderResponse>(asistenciaEstudianteHeaderResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, asistenciaEstudianteHeaderResponses);

            return Ok(paginationResponse);
        }
    }
}
