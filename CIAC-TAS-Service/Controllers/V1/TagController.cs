using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Poster")]
    public class TagController : Controller
    {
        private readonly IPostService _postService;

        public TagController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoute.Tags.GetAll)]
        //[Authorize(Policy = "TagViewer")]
        [Authorize(Roles = "Admin")] //Just the admin can do this action
        [Authorize(Policy = "MustWorkForChapsas")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetAllTagsAsync());
        }
    }
}
