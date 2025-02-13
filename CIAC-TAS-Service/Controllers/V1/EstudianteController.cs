﻿using AutoMapper;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Domain.Estudiante;
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
    public class EstudianteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEstudianteService _estudianteService;
        private readonly IUriService _uriService;
        private readonly IIdentityService _identityService;

        public EstudianteController(IMapper mapper, IEstudianteService estudianteService, IUriService uriService, IIdentityService identityService)
        {
            _mapper = mapper;
            _estudianteService = estudianteService;
            _uriService = uriService;
            _identityService = identityService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.Estudiantes.GetAll)]
        [ProducesResponseType(typeof(EstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudiantes = await _estudianteService.GetEstudiantesAsync();
            var estudianteResponses = _mapper.Map<List<EstudianteResponse>>(estudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteResponse>(estudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.Estudiantes.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int estudianteId)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(estudianteId);

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstudianteResponse>(estudiante));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost(ApiRoute.Estudiantes.Create)]
        [ProducesResponseType(typeof(EstudianteResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEstudianteRequest estudianteRequest)
        {
            var estudiante = _mapper.Map<Estudiante>(estudianteRequest);

            if (!await _identityService.CheckUserExistsByUserIdAsync(estudiante.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {estudiante.UserId} not found"}
                    }
                });
            }

            if (await _estudianteService.CheckUserIdIsAssignedAsync(estudiante.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {estudiante.UserId} is already assigned to another Estudiante"}
                    }
                });
            }

            var created = await _estudianteService.CreateEstudianteAsync(estudiante);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [Estudiante]"}
                }
                });
            }

            var locationUri = _uriService.GetEstudianteUri(estudiante.Id.ToString());

            var response = _mapper.Map<EstudianteResponse>(estudiante);

            return Created(locationUri, response);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut(ApiRoute.Estudiantes.Update)]
        [ProducesResponseType(typeof(EstudianteResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update([FromRoute] int estudianteId, [FromBody] UpdateEstudianteRequest request)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(estudianteId);

            if (estudiante == null)
            {
                return NotFound();
            }

            _mapper.Map(request, estudiante);

            if (!await _identityService.CheckUserExistsByUserIdAsync(estudiante.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {estudiante.UserId} not found"}
                    }
                });
            }

            if (!await _estudianteService.CheckUserIdIsAssignableToThisEstudianteAsync(estudiante.Id, estudiante.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {estudiante.UserId} is already assigned to another Estudiante"}
                    }
                });
            }

            var update = await _estudianteService.UpdateEstudianteAsync(estudiante);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstudianteResponse>(estudiante));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete(ApiRoute.Estudiantes.Delete)]
        [ProducesResponseType(typeof(EstudianteResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int estudianteId)
        {
            var deleted = await _estudianteService.DeleteEstudianteAsync(estudianteId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Estudiante,Instructor")]
        [HttpGet(ApiRoute.Estudiantes.GetByUserId)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(EstudianteResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEstudianteByUserId([FromRoute] string userId)
        {
            var estudiante = await _estudianteService.GetEstudianteByUserIdAsync(userId);

            if (estudiante == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EstudianteResponse>(estudiante));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.Estudiantes.GetAllNotAssignedToGrupo)]
        [ProducesResponseType(typeof(List<EstudianteResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllNotAssignedToGrupo([FromRoute] int grupoId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudiantes = await _estudianteService.GetAllNotAssignedToGrupoAsync(grupoId);
            var estudianteResponses = _mapper.Map<List<EstudianteResponse>>(estudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteResponse>(estudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.Estudiantes.GetAllNotAssignedAsistenciaEstudiante)]
        [ProducesResponseType(typeof(List<EstudianteResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllNotAssignedAsistenciaEstudiante([FromRoute] int materiaId, [FromRoute] int grupoId, [FromRoute] int asistenciaEstudianteHeaderId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudiantes = await _estudianteService.GetAllNotAssignedAsistenciaEstudianteAsync(materiaId, grupoId, asistenciaEstudianteHeaderId);
            var estudianteResponses = _mapper.Map<List<EstudianteResponse>>(estudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteResponse>(estudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Instructor")]
        [HttpGet(ApiRoute.Estudiantes.GetAllNotAssignedToRegistroNotaEstudianteHeader)]
        [ProducesResponseType(typeof(List<EstudianteResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllNotAssignedToRegistroNotaEstudianteHeader([FromRoute] int registroNotaHeaderId, [FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudiantes = await _estudianteService.GetAllNotAssignedToRegistroNotaEstudianteHeaderAsync(registroNotaHeaderId);
            var estudianteResponses = _mapper.Map<List<EstudianteResponse>>(estudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteResponse>(estudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteResponses);

            return Ok(paginationResponse);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet(ApiRoute.Estudiantes.GetAllNotAssignedInhabilitacionEstudiante)]
        [ProducesResponseType(typeof(List<EstudianteResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllNotAssignedInhabilitacionEstudiante([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var estudiantes = await _estudianteService.GetAllNotAssignedInhabilitacionEstudianteAsync();
            var estudianteResponses = _mapper.Map<List<EstudianteResponse>>(estudiantes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<EstudianteResponse>(estudianteResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, estudianteResponses);

            return Ok(paginationResponse);
        }
    }
}
