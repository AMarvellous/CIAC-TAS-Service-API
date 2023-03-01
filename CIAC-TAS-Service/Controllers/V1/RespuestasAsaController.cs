using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
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
    public class RespuestasAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRespuestasAsaService _respuestasAsaService;
        private readonly IUriService _uriService;
        private readonly IIdentityService _identityService;
        private readonly IConfiguracionPreguntaAsaService _configuracionPreguntaAsaService;
        private readonly IRespuestasAsaConsolidadoService _respuestasAsaConsolidadoService;
        private readonly IPreguntaAsaService _preguntaAsaService;
        private readonly IPreguntaAsaOpcionService _preguntaAsaOpcionService;

        public RespuestasAsaController(IMapper mapper, IRespuestasAsaService respuestasAsaService, IUriService uriService, IIdentityService identityService, IConfiguracionPreguntaAsaService configuracionPreguntaAsaService, IPreguntaAsaService preguntaAsaService, IPreguntaAsaOpcionService preguntaAsaOpcionService, IRespuestasAsaConsolidadoService respuestasAsaConsolidadoService)
        {
            _mapper = mapper;
            _respuestasAsaService = respuestasAsaService;
            _uriService = uriService;
            _identityService = identityService;
            _configuracionPreguntaAsaService = configuracionPreguntaAsaService;
            _preguntaAsaService = preguntaAsaService;
            _preguntaAsaOpcionService = preguntaAsaOpcionService;
            _respuestasAsaConsolidadoService = respuestasAsaConsolidadoService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [HttpGet(ApiRoute.RespuestasAsas.GetAllByUserId)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByUserId([FromRoute] string userId , [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var respuestasAsas = await _respuestasAsaService.GetRespuestasAsasByUserIdAsync(userId, pagination);
            var respuestasAsaResponses = _mapper.Map<List<RespuestasAsaResponse>>(respuestasAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<RespuestasAsaResponse>(respuestasAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, respuestasAsaResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpGet(ApiRoute.RespuestasAsas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int respuestasAsaId)
        {
            var respuestasAsa = await _respuestasAsaService.GetRespuestasAsaByIdAsync(respuestasAsaId);

            if (respuestasAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RespuestasAsaResponse>(respuestasAsa));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpPost(ApiRoute.RespuestasAsas.Create)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateRespuestasAsaRequest respuestasAsaRequest)
        {
            var respuestasAsa = new RespuestasAsa
            {
                UserId = respuestasAsaRequest.UserId,
                ConfiguracionId = respuestasAsaRequest.ConfiguracionId,
                PreguntaAsaId = respuestasAsaRequest.PreguntaAsaId,
                FechaEntrada = respuestasAsaRequest.FechaEntrada,
                OpcionSeleccionadaId = respuestasAsaRequest.OpcionSeleccionadaId,
                EsExamen = respuestasAsaRequest.EsExamen,
                ColorInterfaz = respuestasAsaRequest.ColorInterfaz
            };

            var created = await _respuestasAsaService.CreateRespuestasAsaAsync(respuestasAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RespuestasAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetRespuestasAsaUri(respuestasAsa.Id.ToString());

            var response = _mapper.Map<RespuestasAsaResponse>(respuestasAsa);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpPut(ApiRoute.RespuestasAsas.Update)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int respuestasAsaId, [FromBody] UpdateRespuestasAsaRequest request)
        {
            var respuestasAsa = await _respuestasAsaService.GetRespuestasAsaByIdAsync(respuestasAsaId);
            respuestasAsa.UserId = request.UserId;
            respuestasAsa.ConfiguracionId = request.ConfiguracionId;
            respuestasAsa.PreguntaAsaId = request.PreguntaAsaId;
            respuestasAsa.FechaEntrada = request.FechaEntrada;
            respuestasAsa.OpcionSeleccionadaId = request.OpcionSeleccionadaId;
            respuestasAsa.EsExamen = request.EsExamen;
            respuestasAsa.ColorInterfaz = request.ColorInterfaz;

            var update = await _respuestasAsaService.UpdateRespuestasAsaAsync(respuestasAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RespuestasAsaResponse>(respuestasAsa));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.RespuestasAsas.Delete)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int respuestasAsaId)
        {
            var deleted = await _respuestasAsaService.DeleteRespuestasAsaAsync(respuestasAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpPost(ApiRoute.RespuestasAsas.CreateBatch)]
        [ProducesResponseType(typeof(List<RespuestasAsaResponse>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBatch([FromBody] List<CreateRespuestasAsaRequest> respuestasAsaRequest)
        {

            List<RespuestasAsa> respuestasAsa = new List<RespuestasAsa>();
            foreach (var item in respuestasAsaRequest)
            {
                if (!await _identityService.CheckUserExistsByUserIdAsync(item.UserId))
                {
                    return BadRequest(new ErrorResponse
                    {
                        Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {item.UserId} not found"}
                    }
                    });
                }

                if (item.ConfiguracionId != null && !await _configuracionPreguntaAsaService.CheckConfiguracionPreguntaAsaExistsAsync((int)item.ConfiguracionId))
                {
                    return BadRequest(new ErrorResponse
                    {
                        Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"Configuracion Id {item.ConfiguracionId} not found"}
                    }
                    });
                }

                if (!await _preguntaAsaService.CheckExistsPreguntaAsaAsync(item.PreguntaAsaId))
                {
                    return BadRequest(new ErrorResponse
                    {
                        Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"PreguntaAsa Id {item.PreguntaAsaId} not found"}
                    }
                    });
                }

                if (item.OpcionSeleccionadaId != null && !await _preguntaAsaOpcionService.CheckPreguntaAsaOpcionExistsAsync((int)item.OpcionSeleccionadaId))
                {
                    return BadRequest(new ErrorResponse
                    {
                        Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"OpcionSeleccionada Id {item.OpcionSeleccionadaId} not found"}
                    }
                    });
                }

                respuestasAsa.Add(new RespuestasAsa
                {
                    UserId = item.UserId,
                    ConfiguracionId = item.ConfiguracionId,
                    PreguntaAsaId = item.PreguntaAsaId,
                    FechaEntrada = item.FechaEntrada,
                    OpcionSeleccionadaId = item.OpcionSeleccionadaId,
                    EsExamen = item.EsExamen,
                    ColorInterfaz = item.ColorInterfaz,
                });
            }            

            var created = await _respuestasAsaService.CreateRespuestasAsaBatchAsync(respuestasAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [RespuestasAsas]"}
                }
                });
            }

            var locationUri = _uriService.GetRespuestasAsaUri(string.Join(",", respuestasAsa.Select(x => x.Id.ToString()).ToArray()));

            var response = _mapper.Map<List<RespuestasAsaResponse>>(respuestasAsa);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpPatch(ApiRoute.RespuestasAsas.Patch)]
        [ProducesResponseType(typeof(RespuestasAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Patch([FromRoute] int respuestasAsaId, [FromBody] PatchRespuestasAsaRequest request)
        {
            if (request.OpcionSeleccionadaId != null && !await _preguntaAsaOpcionService.CheckPreguntaAsaOpcionExistsAsync((int)request.OpcionSeleccionadaId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"OpcionSeleccionada Id {request.OpcionSeleccionadaId} not found"}
                    }
                });
            }

            var respuestasAsa = await _respuestasAsaService.GetRespuestasAsaByIdAsync(respuestasAsaId);

            if (request.OpcionSeleccionadaId != null)
            {
				respuestasAsa.OpcionSeleccionadaId = request.OpcionSeleccionadaId;
			}

			if (request.ColorInterfaz != null)
			{
				respuestasAsa.ColorInterfaz = request.ColorInterfaz;
			}

			var update = await _respuestasAsaService.UpdateRespuestasAsaAsync(respuestasAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RespuestasAsaResponse>(respuestasAsa));
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [HttpGet(ApiRoute.RespuestasAsas.GetUserIdHasRespuestasAsa)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserIdHasRespuestasAsa([FromRoute] string userId)
        {
            if (!await _identityService.CheckUserExistsByUserIdAsync(userId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {userId} not found"}
                    }
                });
            }

            var hasRespuestasAsa = await _respuestasAsaService.GetUserIdHasRespuestasAsaAsync(userId);

            return Ok(hasRespuestasAsa);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [HttpGet(ApiRoute.RespuestasAsas.GetFirstByUserId)]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFirstByUserId([FromRoute] string userId)
        {
            if (!await _identityService.CheckUserExistsByUserIdAsync(userId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {userId} not found"}
                    }
                });
            }

            var respuestasAsa = await _respuestasAsaService.GetFirstRespuestasAsaByUserIdAsync(userId);

            if (respuestasAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RespuestasAsaResponse>(respuestasAsa));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante")]
        [HttpPost(ApiRoute.RespuestasAsas.ProcessRespuestasAsa)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ProcessRespuestasAsa([FromRoute] string userId)
        {
            if (!await _identityService.CheckUserExistsByUserIdAsync(userId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {userId} not found"}
                    }
                });
            }

            var guidResponse = await _respuestasAsaConsolidadoService.ProcessRespuestasAsaAsync(userId);

            return Ok(guidResponse);
        }
    }
}
