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
    public class ModuloController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IModuloService _moduloService;
        private readonly IUriService _uriService;

        public ModuloController(IMapper mapper, IModuloService moduloService, IUriService uriService)
        {
            _mapper = mapper;
            _moduloService = moduloService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.Modulos.GetAll)]
        [ProducesResponseType(typeof(ModuloResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var modulos = await _moduloService.GetModulosAsync();
            var moduloResponses = _mapper.Map<List<ModuloResponse>>(modulos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ModuloResponse>(moduloResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, moduloResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.Modulos.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ModuloResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int moduloId)
        {
            var modulo = await _moduloService.GetModuloByIdAsync(moduloId);

            if (modulo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ModuloResponse>(modulo));
        }

        [HttpPost(ApiRoute.Modulos.Create)]
        [ProducesResponseType(typeof(ModuloResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateModuloRequest moduloRequest)
        {
            var modulo = new Modulo
            {
                ModuloCodigo = moduloRequest.ModuloCodigo,
                Nombre = moduloRequest.Nombre
            };

            var created = await _moduloService.CreateModuloAsync(modulo);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [Modulo]"}
                }
                });
            }

            var locationUri = _uriService.GetModuloUri(modulo.Id.ToString());

            var response = _mapper.Map<ModuloResponse>(modulo);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.Modulos.Update)]
        [ProducesResponseType(typeof(ModuloResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int moduloId, [FromBody] UpdateModuloRequest request)
        {
            var modulo = await _moduloService.GetModuloByIdAsync(moduloId);

            modulo.ModuloCodigo = request.ModuloCodigo;
            modulo.Nombre = request.Nombre;

            var update = await _moduloService.UpdateModuloAsync(modulo);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ModuloResponse>(modulo));
        }

        [HttpDelete(ApiRoute.Modulos.Delete)]
        [ProducesResponseType(typeof(ModuloResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int moduloId)
        {
            var deleted = await _moduloService.DeleteModuloAsync(moduloId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
