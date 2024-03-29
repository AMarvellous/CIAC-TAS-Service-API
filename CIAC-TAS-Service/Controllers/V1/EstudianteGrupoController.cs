﻿using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.ASA;
using CIAC_TAS_Service.Domain.Estudiante;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Controllers.V1
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class EstudianteGrupoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEstudianteGrupoService _estudianteGrupoService;
        private readonly IUriService _uriService;

        public EstudianteGrupoController(IMapper mapper, IEstudianteGrupoService estudianteGrupoService, IUriService uriService)
        {
            _mapper = mapper;
            _estudianteGrupoService = estudianteGrupoService;
            _uriService = uriService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Estudiante")]
        [HttpGet(ApiRoute.EstudianteGrupos.GetAll)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudianteGrupos = await _estudianteGrupoService.GetEstudianteGruposAsync();
            var estudianteGrupoResponses = _mapper.Map<List<EstudianteGrupoResponse>>(estudianteGrupos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteGrupoResponse>(estudianteGrupoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteGrupoResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.EstudianteGrupos.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int estudianteId, [FromRoute] int grupoId)
        {
            var estudianteGrupo = await _estudianteGrupoService.GetEstudianteGrupoByIdAsync(estudianteId, grupoId);

            if (estudianteGrupo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstudianteGrupoResponse>(estudianteGrupo));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.EstudianteGrupos.Create)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEstudianteGrupoRequest estudianteGrupoRequest)
        {
            var estudianteGrupo = new EstudianteGrupo
            {
                EstudianteId = estudianteGrupoRequest.EstudianteId,
                GrupoId = estudianteGrupoRequest.GrupoId
            };

            var estudianteGrupoDB = await _estudianteGrupoService.GetEstudianteGrupoByIdAsync(estudianteGrupo.EstudianteId, estudianteGrupo.GrupoId);
            if (estudianteGrupoDB != null)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { 
                            Message = $"El Estudiante {estudianteGrupo.EstudianteId} y Grupo {estudianteGrupo.GrupoId} ya fueron asignados previamente"}
                    }
                });
            }

            var created = await _estudianteGrupoService.CreateEstudianteGrupoAsync(estudianteGrupo);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [EstudianteGrupo]"}
                }
                });
            }

            var locationUri = _uriService.GetEstudianteGrupoUri(estudianteGrupo.EstudianteId.ToString(), estudianteGrupo.GrupoId.ToString());

            var response = _mapper.Map<EstudianteGrupoResponse>(estudianteGrupo);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.EstudianteGrupos.Delete)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int estudianteId, [FromRoute] int grupoId)
        {
            var deleted = await _estudianteGrupoService.DeleteEstudianteGrupoAsync(estudianteId, grupoId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Estudiante")]
        [HttpGet(ApiRoute.EstudianteGrupos.GetHeaders)]
        [ProducesResponseType(typeof(EstudianteGrupoResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllGrupoHeaders([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudianteGrupos = await _estudianteGrupoService.GetEstudianteGruposHeadersAsync();
            var estudianteGrupoResponses = _mapper.Map<List<EstudianteGrupoResponse>>(estudianteGrupos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteGrupoResponse>(estudianteGrupoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteGrupoResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.EstudianteGrupos.CreateBatch)]
        [ProducesResponseType(typeof(List<EstudianteGrupoResponse>), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateBatch([FromBody] List<CreateEstudianteGrupoRequest> estudianteGrupoRequest)
        {
            List<EstudianteGrupo> estudianteGrupos = new List<EstudianteGrupo>();
            foreach (var item in estudianteGrupoRequest)
            {
                var estudianteGrupo = new EstudianteGrupo
                {
                    EstudianteId = item.EstudianteId,
                    GrupoId = item.GrupoId
                };

                var estudianteGrupoDB = await _estudianteGrupoService.GetEstudianteGrupoByIdAsync(estudianteGrupo.EstudianteId, estudianteGrupo.GrupoId);
                if (estudianteGrupoDB != null)
                {
                    return BadRequest(new ErrorResponse
                    {
                        Errors = new List<ErrorModel>
                        {
                            new ErrorModel {
                                Message = $"El Estudiante {estudianteGrupo.EstudianteId} y Grupo {estudianteGrupo.GrupoId} ya fueron asignados previamente"}
                        }
                    });
                }

                estudianteGrupos.Add(estudianteGrupo);
            }
            

            var created = await _estudianteGrupoService.CreateEstudianteGrupoBatchAsync(estudianteGrupos);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [EstudianteGrupo]"}
                }
                });
            }

            var locationUri = _uriService.GetEstudianteGrupoUri(string.Join(",", estudianteGrupos.Select(x => x.EstudianteId.ToString()).ToArray()), string.Join(",", estudianteGrupos.Select(x => x.GrupoId.ToString()).ToArray()));

            var response = _mapper.Map<List<EstudianteGrupoResponse>>(estudianteGrupos);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Estudiante")]
        [HttpGet(ApiRoute.EstudianteGrupos.GetAllByGrupoId)]
        [ProducesResponseType(typeof(List<EstudianteGrupoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllByGrupoId([FromRoute] int grupoId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudianteGrupos = await _estudianteGrupoService.GetEstudianteGruposByGrupoIdAsync(grupoId);
            var estudianteGrupoResponses = _mapper.Map<List<EstudianteGrupoResponse>>(estudianteGrupos);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteGrupoResponse>(estudianteGrupoResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteGrupoResponses);

            return Ok(paginationResponse);
        }
    }
}
