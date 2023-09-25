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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class MenuModulosWebController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMenuModulosWebService _menuModulosWebService;
        private readonly IUriService _uriService;
        private readonly IIdentityRoleService _identityRoleService;

        public MenuModulosWebController(IMapper mapper, IMenuModulosWebService menuModulosWebService, IUriService uriService, IIdentityRoleService identityRoleService)
        {
            _mapper = mapper;
            _menuModulosWebService = menuModulosWebService;
            _uriService = uriService;
            _identityRoleService = identityRoleService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.MenuModulosWebs.GetAll)]
        [ProducesResponseType(typeof(MenuModulosWebResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var menuModulosWebs = await _menuModulosWebService.GetMenuModulosWebsAsync();
            var menuModulosWebResponses = _mapper.Map<List<MenuModulosWebResponse>>(menuModulosWebs);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<MenuModulosWebResponse>(menuModulosWebResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, menuModulosWebResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.MenuModulosWebs.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MenuModulosWebResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int menuModulosWebId)
        {
            var menuModulosWeb = await _menuModulosWebService.GetMenuModulosWebByIdAsync(menuModulosWebId);

            if (menuModulosWeb == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MenuModulosWebResponse>(menuModulosWeb));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.MenuModulosWebs.Create)]
        [ProducesResponseType(typeof(MenuModulosWebResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMenuModulosWebRequest menuModulosWebRequest)
        {
            var menuModulosWeb = new MenuModuloWeb
            {
                RoleId = menuModulosWebRequest.RoleId,
                Nombre = menuModulosWebRequest.Nombre,
                Estilo = menuModulosWebRequest.Estilo
            };
            
            if (!await _identityRoleService.CheckRoleIdExists(menuModulosWeb.RoleId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Role Id {menuModulosWeb.RoleId} not found"}
                    }
                });
            }

            var created = await _menuModulosWebService.CreateMenuModulosWebAsync(menuModulosWeb);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [MenuModulosWeb]"}
                }
                });
            }

            var locationUri = _uriService.GetMenuModulosWebUri(menuModulosWeb.Id.ToString());

            var response = _mapper.Map<MenuModulosWebResponse>(menuModulosWeb);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut(ApiRoute.MenuModulosWebs.Update)]
        [ProducesResponseType(typeof(MenuModulosWebResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int menuModulosWebId, [FromBody] UpdateMenuModulosWebRequest request)
        {
            var menuModulosWeb = await _menuModulosWebService.GetMenuModulosWebByIdAsync(menuModulosWebId);

            menuModulosWeb.RoleId = request.RoleId;
            menuModulosWeb.Nombre = request.Nombre;
            menuModulosWeb.Estilo = request.Estilo;

            if (!await _identityRoleService.CheckRoleIdExists(menuModulosWeb.RoleId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Role Id {menuModulosWeb.RoleId} not found"}
                    }
                });
            }

            var update = await _menuModulosWebService.UpdateMenuModulosWebAsync(menuModulosWeb);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MenuModulosWebResponse>(menuModulosWeb));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.MenuModulosWebs.Delete)]
        [ProducesResponseType(typeof(MenuModulosWebResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int menuModulosWebId)
        {
            var deleted = await _menuModulosWebService.DeleteMenuModulosWebAsync(menuModulosWebId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpGet(ApiRoute.MenuModulosWebs.GetByRoleName)]
        [ProducesResponseType(typeof(MenuModulosWebResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByRoleAsync([FromRoute] string roleName , [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var menuModulosWebs = await _menuModulosWebService.GetMenuModulosWebsByRoleNameAsync(roleName);
            var menuModulosWebResponses = _mapper.Map<List<MenuModulosWebResponse>>(menuModulosWebs);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<MenuModulosWebResponse>(menuModulosWebResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, menuModulosWebResponses);

            return Ok(paginationResponse);
        }
    }
}
