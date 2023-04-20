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
    public class ModuloMateriaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IModuloMateriaService _moduloMateriaService;
        private readonly IUriService _uriService;

        public ModuloMateriaController(IMapper mapper, IModuloMateriaService moduloMateriaService, IUriService uriService)
        {
            _mapper = mapper;
            _moduloMateriaService = moduloMateriaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.ModuloMaterias.GetAll)]
        [ProducesResponseType(typeof(ModuloMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var moduloMaterias = await _moduloMateriaService.GetModuloMateriasAsync(pagination);
            var moduloMateriaResponses = _mapper.Map<List<ModuloMateriaResponse>>(moduloMaterias);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ModuloMateriaResponse>(moduloMateriaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, moduloMateriaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.ModuloMaterias.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ModuloMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int moduloId, [FromRoute] int materiaId)
        {
            var moduloMateria = await _moduloMateriaService.GetModuloMateriaByIdAsync(moduloId, materiaId);

            if (moduloMateria == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ModuloMateriaResponse>(moduloMateria));
        }

        [HttpPost(ApiRoute.ModuloMaterias.Create)]
        [ProducesResponseType(typeof(ModuloMateriaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateModuloMateriaRequest moduloMateriaRequest)
        {
            var moduloMateria = new ModuloMateria
            {
                ModuloId = moduloMateriaRequest.ModuloId,
                MateriaId = moduloMateriaRequest.MateriaId
            };

            var created = await _moduloMateriaService.CreateModuloMateriaAsync(moduloMateria);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [ModuloMateria]"}
                }
                });
            }

            var locationUri = _uriService.GetModuloMateriaUri(moduloMateria.ModuloId.ToString(), moduloMateria.MateriaId.ToString());

            var response = _mapper.Map<ModuloMateriaResponse>(moduloMateria);

            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoute.ModuloMaterias.Delete)]
        [ProducesResponseType(typeof(ModuloMateriaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int moduloId, [FromRoute] int materiaId)
        {
            var deleted = await _moduloMateriaService.DeleteModuloMateriaAsync(moduloId, materiaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
