using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Menu;
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
    public class MenuSubModulosWebController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMenuSubModulosWebService _menuSubModulosWebService;
        private readonly IMenuModulosWebService _menuModulosWebService;
        private readonly IUriService _uriService;

        public MenuSubModulosWebController(IMapper mapper, IMenuSubModulosWebService menuSubModulosWebService, IMenuModulosWebService menuModulosWebService, IUriService uriService)
        {
            _mapper = mapper;
            _menuSubModulosWebService = menuSubModulosWebService;
            _menuModulosWebService = menuModulosWebService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.MenuSubModulosWebs.GetAll)]
        [ProducesResponseType(typeof(MenuSubModulosWebResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var menuSubModulosWebs = await _menuSubModulosWebService.GetMenuSubModulosWebsAsync(pagination);
            var menuSubModulosWebResponses = _mapper.Map<List<MenuSubModulosWebResponse>>(menuSubModulosWebs);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<MenuSubModulosWebResponse>(menuSubModulosWebResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, menuSubModulosWebResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.MenuSubModulosWebs.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MenuSubModulosWebResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int menuSubModulosWebId)
        {
            var menuSubModulosWeb = await _menuSubModulosWebService.GetMenuSubModulosWebByIdAsync(menuSubModulosWebId);

            if (menuSubModulosWeb == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MenuSubModulosWebResponse>(menuSubModulosWeb));
        }

        [HttpPost(ApiRoute.MenuSubModulosWebs.Create)]
        [ProducesResponseType(typeof(MenuSubModulosWebResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMenuSubModulosWebRequest menuSubModulosWebRequest)
        {
            var menuSubModulosWeb = new MenuSubModuloWeb
            {
                ModuloId = menuSubModulosWebRequest.ModuloId,
                Nombre = menuSubModulosWebRequest.Nombre,
                Pagina = menuSubModulosWebRequest.Pagina,
                Estilo = menuSubModulosWebRequest.Estilo
            };

            if (!await _menuModulosWebService.CheckModuloExists(menuSubModulosWeb.ModuloId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"ModuloId Id {menuSubModulosWeb.ModuloId} not found"}
                    }
                });
            }

            var created = await _menuSubModulosWebService.CreateMenuSubModulosWebAsync(menuSubModulosWeb);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [MenuSubModulosWeb]"}
                }
                });
            }

            var locationUri = _uriService.GetMenuSubModulosWebUri(menuSubModulosWeb.Id.ToString());

            var response = _mapper.Map<MenuSubModulosWebResponse>(menuSubModulosWeb);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.MenuSubModulosWebs.Update)]
        [ProducesResponseType(typeof(MenuSubModulosWebResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int menuSubModulosWebId, [FromBody] UpdateMenuSubModulosWebRequest request)
        {
            var menuSubModulosWeb = await _menuSubModulosWebService.GetMenuSubModulosWebByIdAsync(menuSubModulosWebId);
            menuSubModulosWeb.ModuloId = request.ModuloId;
            menuSubModulosWeb.Nombre = request.Nombre;
            menuSubModulosWeb.Pagina = request.Pagina;
            menuSubModulosWeb.Estilo = request.Estilo;

            if (!await _menuModulosWebService.CheckModuloExists(menuSubModulosWeb.ModuloId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"ModuloId Id {menuSubModulosWeb.ModuloId} not found"}
                    }
                });
            }

            var update = await _menuSubModulosWebService.UpdateMenuSubModulosWebAsync(menuSubModulosWeb);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MenuSubModulosWebResponse>(menuSubModulosWeb));
        }

        [HttpDelete(ApiRoute.MenuSubModulosWebs.Delete)]
        [ProducesResponseType(typeof(MenuSubModulosWebResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int menuSubModulosWebId)
        {
            var deleted = await _menuSubModulosWebService.DeleteMenuSubModulosWebAsync(menuSubModulosWebId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
