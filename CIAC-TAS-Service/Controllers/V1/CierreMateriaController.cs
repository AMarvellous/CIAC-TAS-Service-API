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
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Produces("application/json")]
    public class CierreMateriaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICierreMateriaService _cierreMateriaService;
        private readonly IAsistenciaEstudianteHeaderService _asistenciaEstudianteHeaderService;
        private readonly IRegistroNotaHeaderService _registroNotaHeaderService;
        private readonly IUriService _uriService;

        public CierreMateriaController(IMapper mapper, ICierreMateriaService cierreMateriaService, IUriService uriService, IAsistenciaEstudianteHeaderService asistenciaEstudianteHeaderService, IRegistroNotaHeaderService registroNotaHeaderService)
        {
            _mapper = mapper;
            _cierreMateriaService = cierreMateriaService;
            _asistenciaEstudianteHeaderService = asistenciaEstudianteHeaderService;
            _registroNotaHeaderService = registroNotaHeaderService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.CierreMaterias.GetAll)]
        [ProducesResponseType(typeof(CierreMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var cierreMaterias = await _cierreMateriaService.GetCierreMateriasAsync();
            var cierreMateriaResponses = _mapper.Map<List<CierreMateriaResponse>>(cierreMaterias);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<CierreMateriaResponse>(cierreMateriaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, cierreMateriaResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.CierreMaterias.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CierreMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int cierreMateriaId)
        {
            var cierreMateria = await _cierreMateriaService.GetCierreMateriaByIdAsync(cierreMateriaId);

            if (cierreMateria == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CierreMateriaResponse>(cierreMateria));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.CierreMaterias.Create)]
        [ProducesResponseType(typeof(CierreMateriaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCierreMateriaRequest cierreMateriaRequest)
        {
            var cierreMateria = new CierreMateria
            {
                GrupoId = cierreMateriaRequest.GrupoId,
                MateriaId = cierreMateriaRequest.MateriaId,
            };

            var created = await _cierreMateriaService.CreateCierreMateriaAsync(cierreMateria);

            if (created)
            {
                await _asistenciaEstudianteHeaderService.UpdateAsistenciaEstudianteHeaderLockAsync(cierreMateriaRequest.GrupoId, cierreMateriaRequest.MateriaId, true);
                await _registroNotaHeaderService.UpdateRegistroNotaHeaderLockAsync(cierreMateriaRequest.GrupoId, cierreMateriaRequest.MateriaId, true);
            } else
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [CierreMateria]"}
                }
                });
            }

            var locationUri = _uriService.GetCierreMateriaUri(cierreMateria.Id.ToString());

            var response = _mapper.Map<CierreMateriaResponse>(cierreMateria);

            return Created(locationUri, response);
        }

        //[HttpPut(ApiRoute.CierreMaterias.Update)]
        //[ProducesResponseType(typeof(CierreMateriaResponse), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        //public async Task<IActionResult> Update([FromRoute] int cierreMateriaId, [FromBody] UpdateCierreMateriaRequest request)
        //{
        //    var cierreMateria = await _cierreMateriaService.GetCierreMateriaByIdAsync(cierreMateriaId);
        //    cierreMateria.AsistenciaEstudianteHeaderId = request.AsistenciaEstudianteHeaderId;
        //    cierreMateria.RegistroNotaHeaderId = request.RegistroNotaHeaderId;

        //    var update = await _cierreMateriaService.UpdateCierreMateriaAsync(cierreMateria);

        //    if (!update)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(_mapper.Map<CierreMateriaResponse>(cierreMateria));
        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.CierreMaterias.Delete)]
        [ProducesResponseType(typeof(CierreMateriaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int cierreMateriaId)
        {
            var cierreMateria = await _cierreMateriaService.GetCierreMateriaByIdAsync(cierreMateriaId);
            var deleted = await _cierreMateriaService.DeleteCierreMateriaAsync(cierreMateriaId);

            if (deleted)
            {
                await _asistenciaEstudianteHeaderService.UpdateAsistenciaEstudianteHeaderLockAsync(cierreMateria.GrupoId, cierreMateria.MateriaId, false);
                await _registroNotaHeaderService.UpdateRegistroNotaHeaderLockAsync(cierreMateria.GrupoId, cierreMateria.MateriaId, false);
            } else
            {
                return NotFound();
            }

            return NoContent();
        }

        //[HttpPost(ApiRoute.CierreMaterias.CreateAllByMateriaIdAndGrupoId)]
        //[ProducesResponseType(typeof(CierreMateriaResponse), (int)HttpStatusCode.Created)]
        //[ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> CreateAllByMateriaIdAndGrupoId([FromBody] CreateCierreMateriaMateriaGrupoRequest request)
        //{
        //    var asistenciaEstudianteHeaders = await _asistenciaEstudianteHeaderService.GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(request.GrupoId, request.MateriaId);
        //    var registroNotaHeaders = await _registroNotaHeaderService.GetAsistenciaEstudianteHeadersByGrupoIdMateriaIdAsync(request.GrupoId, request.MateriaId);

        //    Dictionary<string, List<int>> cierreMateriaMap = new Dictionary<string, List<int>> ();
        //    var registroNotaHeaderIds = new List<int>();
        //    foreach (var registroNotaHeader in registroNotaHeaders)
        //    {
        //        registroNotaHeaderIds.Add(registroNotaHeader.Id);
        //    }
        //    cierreMateriaMap.Add("RegistroNotaHeader", registroNotaHeaderIds);

        //    var asistenciaEstudianteHeaderIds = new List<int>();
        //    foreach (var asistenciaEstudianteHeader in asistenciaEstudianteHeaders)
        //    {
        //        asistenciaEstudianteHeaderIds.Add(asistenciaEstudianteHeader.Id);
        //    }
        //    cierreMateriaMap.Add("AsistenciaEstudianteHeader", asistenciaEstudianteHeaderIds);

        //    var created = await _cierreMateriaService.CreateCierreMateriaAsync(cierreMateria);

        //    if (!created)
        //    {
        //        return BadRequest(new ErrorResponse
        //        {
        //            Errors = new List<ErrorModel>
        //        {
        //            new ErrorModel { Message = "Unable to create [CierreMateria]"}
        //        }
        //        });
        //    }

        //    var locationUri = _uriService.GetCierreMateriaUri(cierreMateria.Id.ToString());

        //    var response = _mapper.Map<CierreMateriaResponse>(cierreMateria);

        //    return Created(locationUri, response);
        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.CierreMaterias.GetByGrupoIdMateriaId)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(CierreMateriaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByGrupoIdMateriaId([FromRoute] int grupoId, [FromRoute] int materiaId)
        {
            var cierreMateria = await _cierreMateriaService.GetByGrupoIdMateriaId(grupoId, materiaId);

            if (cierreMateria == null)
            {
                return Ok(null);
            }

            return Ok(_mapper.Map<CierreMateriaResponse>(cierreMateria));
        }
    }
}
