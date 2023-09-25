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

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [Produces("application/json")]
    public class ImagenAsaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IImagenAsaService _imagenAsaService;
        private readonly IUriService _uriService;

        public ImagenAsaController(IMapper mapper, IImagenAsaService imagenAsaService, IUriService uriService)
        {
            _mapper = mapper;
            _imagenAsaService = imagenAsaService;
            _uriService = uriService;
        }

        [HttpGet(ApiRoute.ImagenAsas.GetAll)]
        [ProducesResponseType(typeof(ImagenAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll([FromQuery] PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var imagenAsas = await _imagenAsaService.GetImagenAsasAsync();
            var imagenAsaResponses = _mapper.Map<List<ImagenAsaResponse>>(imagenAsas);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<ImagenAsaResponse>(imagenAsaResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, imagenAsaResponses);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoute.ImagenAsas.Get)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ImagenAsaResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int imagenAsaId)
        {
            var imagenAsa = await _imagenAsaService.GetImagenAsaByIdAsync(imagenAsaId);

            if (imagenAsa == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ImagenAsaResponse>(imagenAsa));
        }

        [HttpPost(ApiRoute.ImagenAsas.Create)]
        [ProducesResponseType(typeof(ImagenAsaResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateImagenAsaRequest imagenAsaRequest)
        {
            var imagenAsa = new ImagenAsa
            {
                Ruta = imagenAsaRequest.Ruta
            };

            var created = await _imagenAsaService.CreateImagenAsaAsync(imagenAsa);

            if (!created)
            {
                return BadRequest(new ErrorResponse
                {
                    Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create [ImagenAsa]"}
                }
                });
            }

            var locationUri = _uriService.GetImagenAsaUri(imagenAsa.Id.ToString());

            var response = _mapper.Map<ImagenAsaResponse>(imagenAsa);

            return Created(locationUri, response);
        }

        [HttpPut(ApiRoute.ImagenAsas.Update)]
        [ProducesResponseType(typeof(ImagenAsaResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update([FromRoute] int imagenAsaId, [FromBody] UpdateImagenAsaRequest request)
        {
            var imagenAsa = await _imagenAsaService.GetImagenAsaByIdAsync(imagenAsaId);
            imagenAsa.Ruta = request.Ruta;

            var update = await _imagenAsaService.UpdateImagenAsaAsync(imagenAsa);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ImagenAsaResponse>(imagenAsa));
        }

        [HttpDelete(ApiRoute.ImagenAsas.Delete)]
        [ProducesResponseType(typeof(ImagenAsaResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int imagenAsaId)
        {
            var deleted = await _imagenAsaService.DeleteImagenAsaAsync(imagenAsaId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
