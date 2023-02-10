using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIAC_TAS_Service.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IIdentityRoleService _identityRoleService;
        private readonly IUriService _uriService;
        private readonly IMapper _mapper;
        public IdentityController(IIdentityService identityService, IIdentityRoleService identityRoleService, IUriService uriService, IMapper mapper)
        {
            _identityService = identityService;
            _identityRoleService = identityRoleService;
            _uriService = uriService;
            _mapper = mapper;
        }

        [HttpPost(ApiRoute.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(error => error.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request.UserName , request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });
        }

        [HttpPost(ApiRoute.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            var authResponse = await _identityService.LoginAsync(userLoginRequest.UserName, userLoginRequest.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });
        }

        [HttpPost(ApiRoute.Identity.Refresh)]
        public async Task<IActionResult> RefreshTokenRequest([FromBody] RefreshTokenRequest request)
        {
            var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
                RefreshToken = authResponse.RefreshToken
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Produces("application/json")]
        [HttpGet(ApiRoute.Identity.GetRolesNames)]
        public async Task<IActionResult> GetRolesName()
        {
            var roles = await _identityRoleService.GetRolesNamesAsync();

            return Ok(roles);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [Produces("application/json")]
        [HttpGet(ApiRoute.Identity.GetRolesUserName)]
        public async Task<IActionResult> GetRolesByUserName([FromRoute] string userName)
        {
            var roles = await _identityService.GetRolesByUserNameAsync(userName);

            if (roles.Count() <= 0)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = "Unable to find Roles"}
                    }
                });
            }

            return Ok(roles);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Produces("application/json")]
        [HttpGet(ApiRoute.Identity.GetUsers)]
        public async Task<IActionResult> GetUsers([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var users = await _identityService.GetUsersAsync();
            var usersResponses = _mapper.Map<List<IdentityUserResponse>>(users);

            //if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            //{
            //    return Ok(new PagedResponse<IdentityUserResponse>(usersResponses));
            //}

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, usersResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [Produces("application/json")]
        [HttpGet(ApiRoute.Identity.GetUserByName)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IdentityUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserByName([FromRoute] string userName)
        {
            var user = await _identityService.GetUserByNameAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IdentityUserResponse>(user));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Produces("application/json")]
        [HttpPost(ApiRoute.Identity.GetAsignToRole)]
        public async Task<IActionResult> AsignUserToRole([FromBody] AsignRoleToUserRequest request)
        {
            if (!await _identityService.CheckUserExistsByUserIdAsync(request.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {request.UserId} not found"}
                    }
                });
            }

            if (!await _identityRoleService.CheckRoleNameExists(request.RoleName))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Role Name {request.RoleName} not found"}
                    }
                });
            }

            var identityResult = await _identityService.AddUserToRoleAsync(request.UserId.ToString(), request.RoleName);

            if (!identityResult.Succeeded)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = identityResult.Errors.Select(x => new ErrorModel { Message = x.Description }).ToList()
                });
            }

            return Ok(identityResult.Succeeded);
        }
    }
}
