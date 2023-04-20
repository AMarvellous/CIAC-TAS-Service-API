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
using CIAC_TAS_Service.Domain.Estudiante;
using static CIAC_TAS_Service.Contracts.V1.ApiRoute;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class InstructorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        private readonly IUriService _uriService;
        private readonly IIdentityService _identityService;

        public InstructorController(IMapper mapper, IInstructorService instructorService, IUriService uriService, IIdentityService identityService)
        {
            _mapper = mapper;
            _instructorService = instructorService;
            _uriService = uriService;
            _identityService = identityService;
        }

        [HttpGet(ApiRoute.Instructores.GetAll)]
        [ProducesResponseType(typeof(InstructorResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var instructors = await _instructorService.GetInstructorsAsync(pagination);
            var instructorResponses = _mapper.Map<List<InstructorResponse>>(instructors);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<InstructorResponse>(instructorResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, instructorResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.Instructores.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(InstructorResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int instructorId)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(instructorId);

            if (instructor == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InstructorResponse>(instructor));
        }

        [HttpPost(ApiRoute.Instructores.Create)]
        [ProducesResponseType(typeof(InstructorResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInstructorRequest instructorRequest)
        {
            var instructor = _mapper.Map<Instructor>(instructorRequest);

            if (!await _identityService.CheckUserExistsByUserIdAsync(instructor.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {instructor.UserId} not found"}
                    }
                });
            }

            if (await _instructorService.CheckUserIdIsAssignedAsync(instructor.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {instructor.UserId} is already assigned to another Instructor"}
                    }
                });
            }

            var created = await _instructorService.CreateInstructorAsync(instructor);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [Instructor]"}
                }
                });
            }

            var locationUri = _uriService.GetInstructorUri(instructor.Id.ToString());

            var response = _mapper.Map<InstructorResponse>(instructor);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.Instructores.Update)]
        [ProducesResponseType(typeof(InstructorResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int instructorId, [FromBody] UpdateInstructorRequest request)
        {
            var instructor = await _instructorService.GetInstructorByIdAsync(instructorId);
            
            if (instructor == null)
            {
                return NotFound();
            }

            _mapper.Map(request, instructor);

            if (!await _identityService.CheckUserExistsByUserIdAsync(instructor.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {instructor.UserId} not found"}
                    }
                });
            }

            if (!await _instructorService.CheckUserIdIsAssignableToThisInstructorAsync(instructor.Id, instructor.UserId))
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                    {
                        new ErrorModel { Message = $"User Id {instructor.UserId} is already assigned to another Instructor"}
                    }
                });
            }

            var update = await _instructorService.UpdateInstructorAsync(instructor);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<InstructorResponse>(instructor));
        }

        [HttpDelete(ApiRoute.Instructores.Delete)]
        [ProducesResponseType(typeof(InstructorResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int instructorId)
        {
            var deleted = await _instructorService.DeleteInstructorAsync(instructorId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
