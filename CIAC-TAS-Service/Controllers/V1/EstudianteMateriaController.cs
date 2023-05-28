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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class EstudianteMateriaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEstudianteMateriaService _estudianteMateriaService;
        private readonly IUriService _uriService;

        public EstudianteMateriaController(IMapper mapper, IEstudianteMateriaService estudianteMateriaService, IUriService uriService)
        {
            _mapper = mapper;
            _estudianteMateriaService = estudianteMateriaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.EstudianteMaterias.GetAll)]
        [ProducesResponseType(typeof(EstudianteMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudianteMaterias = await _estudianteMateriaService.GetEstudianteMateriasAsync(pagination);
            var estudianteMateriaResponses = _mapper.Map<List<EstudianteMateriaResponse>>(estudianteMaterias);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteMateriaResponse>(estudianteMateriaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteMateriaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.EstudianteMaterias.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstudianteMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int estudianteId,  int grupoId, int materiaId)
        {
            var estudianteMateria = await _estudianteMateriaService.GetEstudianteMateriaByIdAsync(estudianteId, grupoId, materiaId);

            if (estudianteMateria == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstudianteMateriaResponse>(estudianteMateria));
        }

        [HttpPost(ApiRoute.EstudianteMaterias.Create)]
        [ProducesResponseType(typeof(EstudianteMateriaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEstudianteMateriaRequest estudianteMateriaRequest)
        {
            var estudianteMateria = new EstudianteMateria
            {
                EstudianteId = estudianteMateriaRequest.EstudianteId,
                GrupoId = estudianteMateriaRequest.GrupoId,
                MateriaId = estudianteMateriaRequest.MateriaId
            };

            var estudianteMateriaDB = await _estudianteMateriaService.GetEstudianteMateriaByIdAsync(estudianteMateria.EstudianteId, estudianteMateria.GrupoId, estudianteMateria.MateriaId);
            if (estudianteMateriaDB != null)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel {
                            Message = $"El Estudiante {estudianteMateria.EstudianteId}, Grupo {estudianteMateria.GrupoId} y Materia {estudianteMateria.MateriaId} ya fueron asignados previamente"}
                    }
                });
            }

            var created = await _estudianteMateriaService.CreateEstudianteMateriaAsync(estudianteMateria);
            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [EstudianteMateria]"}
                }
                });
            }

            var locationUri = _uriService.GetEstudianteMateriaUri(estudianteMateria.EstudianteId.ToString(), estudianteMateria.GrupoId.ToString(), estudianteMateria.MateriaId.ToString());

            var response = _mapper.Map<EstudianteMateriaResponse>(estudianteMateria);

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoute.EstudianteMaterias.Delete)]
        [ProducesResponseType(typeof(EstudianteMateriaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int estudianteId, int grupoId, int materiaId)
        {
            var deleted = await _estudianteMateriaService.DeleteEstudianteMateriaAsync(estudianteId, grupoId, materiaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
