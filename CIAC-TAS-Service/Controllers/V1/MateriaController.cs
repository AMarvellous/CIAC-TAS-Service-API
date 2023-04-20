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
    public class MateriaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMateriaService _materiaService;
        private readonly IUriService _uriService;

        public MateriaController(IMapper mapper, IMateriaService materiaService, IUriService uriService)
        {
            _mapper = mapper;
            _materiaService = materiaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.Materias.GetAll)]
        [ProducesResponseType(typeof(MateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var materias = await _materiaService.GetMateriasAsync(pagination);
            var materiaResponses = _mapper.Map<List<MateriaResponse>>(materias);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<MateriaResponse>(materiaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, materiaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.Materias.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int materiaId)
        {
            var materia = await _materiaService.GetMateriaByIdAsync(materiaId);

            if (materia == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MateriaResponse>(materia));
        }

        [HttpPost(ApiRoute.Materias.Create)]
        [ProducesResponseType(typeof(MateriaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMateriaRequest materiaRequest)
        {
            var materia = new Materia
            {
                MateriaCodigo = materiaRequest.MateriaCodigo,
                Nombre = materiaRequest.Nombre
            };

            var created = await _materiaService.CreateMateriaAsync(materia);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [Materia]"}
                }
                });
            }

            var locationUri = _uriService.GetMateriaUri(materia.Id.ToString());

            var response = _mapper.Map<MateriaResponse>(materia);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.Materias.Update)]
        [ProducesResponseType(typeof(MateriaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int materiaId, [FromBody] UpdateMateriaRequest request)
        {
            var materia = await _materiaService.GetMateriaByIdAsync(materiaId);

            materia.MateriaCodigo = request.MateriaCodigo;
            materia.Nombre = request.Nombre;

            var update = await _materiaService.UpdateMateriaAsync(materia);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MateriaResponse>(materia));
        }

        [HttpDelete(ApiRoute.Materias.Delete)]
        [ProducesResponseType(typeof(MateriaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int materiaId)
        {
            var deleted = await _materiaService.DeleteMateriaAsync(materiaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
