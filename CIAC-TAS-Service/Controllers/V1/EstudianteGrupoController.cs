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
    public class EstudianteGrupoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEstudianteGrupoService _estudianteGrupoService;
        private readonly IUriService _uriService;

        public EstudianteGrupoController(IMapper mapper, IEstudianteGrupoService estudianteGrupoService, IUriService uriService)
        {
            _mapper = mapper;
            _estudianteGrupoService = estudianteGrupoService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.EstudianteGrupos.GetAll)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudianteGrupos = await _estudianteGrupoService.GetEstudianteGruposAsync(pagination);
            var estudianteGrupoResponses = _mapper.Map<List<EstudianteGrupoResponse>>(estudianteGrupos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteGrupoResponse>(estudianteGrupoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteGrupoResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.EstudianteGrupos.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int estudianteId, [FromRoute] int grupoId)
        {
            var estudianteGrupo = await _estudianteGrupoService.GetEstudianteGrupoByIdAsync(estudianteId, grupoId);

            if (estudianteGrupo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstudianteGrupoResponse>(estudianteGrupo));
        }

        [HttpPost(ApiRoute.EstudianteGrupos.Create)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEstudianteGrupoRequest estudianteGrupoRequest)
        {
            var estudianteGrupo = new EstudianteGrupo
            {
                EstudianteId = estudianteGrupoRequest.EstudianteId,
                GrupoId = estudianteGrupoRequest.GrupoId
            };

            var estudianteGrupoDB = await _estudianteGrupoService.GetEstudianteGrupoByIdAsync(estudianteGrupo.EstudianteId, estudianteGrupo.GrupoId);
            if (estudianteGrupoDB != null)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { 
                            Message = $"EstudianteId {estudianteGrupo.EstudianteId} and GrupoId {estudianteGrupo.GrupoId} are already assigned to another Entity"}
                    }
                });
            }

            var created = await _estudianteGrupoService.CreateEstudianteGrupoAsync(estudianteGrupo);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [EstudianteGrupo]"}
                }
                });
            }

            var locationUri = _uriService.GetEstudianteGrupoUri(estudianteGrupo.EstudianteId.ToString(), estudianteGrupo.GrupoId.ToString());

            var response = _mapper.Map<EstudianteGrupoResponse>(estudianteGrupo);

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoute.EstudianteGrupos.Delete)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int estudianteId, [FromRoute] int grupoId)
        {
            var deleted = await _estudianteGrupoService.DeleteEstudianteGrupoAsync(estudianteId, grupoId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
