using AutoMapper;
using CIAC_TAS_Service.Cache;
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

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class GrupoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGrupoService _grupoService;
        private readonly IUriService _uriService;

        public GrupoController(IMapper mapper, IGrupoService grupoService, IUriService uriService)
        {
            _mapper = mapper;
            _grupoService = grupoService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.Grupos.GetAll)]
        [ProducesResponseType(typeof(GrupoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var grupos = await _grupoService.GetGruposAsync(pagination);
            var grupoResponses = _mapper.Map<List<GrupoResponse>>(grupos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<GrupoResponse>(grupoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, grupoResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.Grupos.Get)]
        //[Cached(600)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(GrupoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int grupoId)
        {
            var grupo = await _grupoService.GetGrupoByIdAsync(grupoId);

            if (grupo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GrupoResponse>(grupo));
        }

        [HttpPost(ApiRoute.Grupos.Create)]
        [ProducesResponseType(typeof(GrupoResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateGrupoRequest grupoRequest)
        {
            var grupo = new Grupo
            {
                Nombre = grupoRequest.Nombre
            };

            var created = await _grupoService.CreateGrupoAsync(grupo);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [Grupo]"}
                }
                });
            }

            var locationUri = _uriService.GetGrupoUri(grupo.Id.ToString());

            var response = _mapper.Map<GrupoResponse>(grupo);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.Grupos.Update)]
        [ProducesResponseType(typeof(GrupoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int grupoId, [FromBody] UpdateGrupoRequest request)
        {
            //var userOwnGrupo = await _grupoService.UserOwnsGrupoAsync(grupoId, HttpContext.GetUserId());

            //if (!userOwnGrupo)
            //{
            //    return BadRequest(new { error = "You do not own this Grupo" });
            //}

            var grupo = await _grupoService.GetGrupoByIdAsync(grupoId);
            grupo.Nombre = request.Nombre;

            var update = await _grupoService.UpdateGrupoAsync(grupo);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GrupoResponse>(grupo));
        }

        [HttpDelete(ApiRoute.Grupos.Delete)]
        [ProducesResponseType(typeof(GrupoResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int grupoId)
        {
            //var userOwnGrupo = await _grupoService.UserOwnsGrupoAsync(grupoId, HttpContext.GetUserId());

            //if (!userOwnGrupo)
            //{
            //    return BadRequest(new { error = "You do not own this Grupo" });
            //}

            var deleted = await _grupoService.DeleteGrupoAsync(grupoId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


		[HttpGet(ApiRoute.Grupos.GetAllNotAssignedEstudents)]
		[ProducesResponseType(typeof(GrupoResponse), (int)HttpStatusCode.OK)]
		public async Task<IActionResult> GetAllNotAssignedEstudents([FromQuery] PaginationQuery paginationQuery)
		{
			var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
			var grupos = await _grupoService.GetGruposNotAssignedEstudentsAsync(pagination);
			var grupoResponses = _mapper.Map<List<GrupoResponse>>(grupos);

			if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
			{
				return Ok(new PagedResponse<GrupoResponse>(grupoResponses));
			}

			var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, grupoResponses);

			return Ok(paginationResponse);
		}
	}
}
