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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class AdministrativoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IAdministrativoService _administrativoService;
        private readonly IUriService _uriService;

        public AdministrativoController(IMapper mapper, IAdministrativoService administrativoService, IUriService uriService, IIdentityService identityService)
        {
            _mapper = mapper;
            _administrativoService = administrativoService;
            _uriService = uriService;
            _identityService = identityService;
        }

        [HttpGet(ApiRoute.Administrativos.GetAll)]
        [ProducesResponseType(typeof(AdministrativoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var administrativos = await _administrativoService.GetAdministrativosAsync();
            var administrativoResponses = _mapper.Map<List<AdministrativoResponse>>(administrativos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<AdministrativoResponse>(administrativoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, administrativoResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.Administrativos.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(AdministrativoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int administrativoId)
        {
            var administrativo = await _administrativoService.GetAdministrativoByIdAsync(administrativoId);

            if (administrativo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AdministrativoResponse>(administrativo));
        }

        [HttpPost(ApiRoute.Administrativos.Create)]
        [ProducesResponseType(typeof(AdministrativoResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAdministrativoRequest administrativoRequest)
        {
            var administrativo = _mapper.Map<Administrativo>(administrativoRequest);

            if (!await _identityService.CheckUserExistsByUserIdAsync(administrativo.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {administrativo.UserId} not found"}
                    }
                });
            }

            if (await _administrativoService.CheckUserIdIsAssignedAsync(administrativo.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {administrativo.UserId} is already assigned to another Administrativo"}
                    }
                });
            }

            var created = await _administrativoService.CreateAdministrativoAsync(administrativo);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [Administrativo]"}
                }
                });
            }

            var locationUri = _uriService.GetAdministrativoUri(administrativo.Id.ToString());

            var response = _mapper.Map<AdministrativoResponse>(administrativo);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.Administrativos.Update)]
        [ProducesResponseType(typeof(AdministrativoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int administrativoId, [FromBody] UpdateAdministrativoRequest request)
        {
            var administrativo = await _administrativoService.GetAdministrativoByIdAsync(administrativoId);

            if (administrativo == null)
            {
                return NotFound();
            }

            _mapper.Map(request, administrativo);

            if (!await _identityService.CheckUserExistsByUserIdAsync(administrativo.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {administrativo.UserId} not found"}
                    }
                });
            }

            if (!await _administrativoService.CheckUserIdIsAssignableToThisAdministrativoAsync(administrativo.Id, administrativo.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {administrativo.UserId} is already assigned to another Administrativo"}
                    }
                });
            }

            var update = await _administrativoService.UpdateAdministrativoAsync(administrativo);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AdministrativoResponse>(administrativo));
        }

        [HttpDelete(ApiRoute.Administrativos.Delete)]
        [ProducesResponseType(typeof(AdministrativoResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int administrativoId)
        {
            var deleted = await _administrativoService.DeleteAdministrativoAsync(administrativoId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
