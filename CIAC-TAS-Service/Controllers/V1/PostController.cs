using AutoMapper;
using CIAC_TAS_Service.Cache;
using CIAC_TAS_Service.Contracts.V1;
using CIAC_TAS_Service.Contracts.V1.Requests;
using CIAC_TAS_Service.Contracts.V1.Requests.Queries;
using CIAC_TAS_Service.Contracts.V1.Responses;
using CIAC_TAS_Service.Domain;
using CIAC_TAS_Service.Extensions;
using CIAC_TAS_Service.Helpers;
using CIAC_TAS_Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CIAC_TAS_Service.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PostController(IPostService postService, IMapper mapper, IUriService uriService)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Returns All Posts in the system
        /// </summary>
        /// <response code="200">Returns All Posts in the system</response>
        [HttpGet(ApiRoute.Posts.GetAll)]
        [Cached(600)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPostsQuery query, [FromQuery]PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var filter = _mapper.Map<GetAllPostsFilter>(query);
            var posts = await _postService.GetPostsAsync(filter, pagination);
            var postResponses = _mapper.Map<List<PostResponse>>(posts);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<PostResponse>(postResponses));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, postResponses);

            return Ok(paginationResponse);
        }

        [HttpDelete(ApiRoute.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            var userOwnPost = await _postService.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnPost)
            {
                return BadRequest(new { error = "You do not own this post" });
            }

            var deleted = await _postService.DeletePostAsync(postId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut(ApiRoute.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {
            var userOwnPost = await _postService.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnPost)
            {
                return BadRequest(new { error = "You do not own this post"});
            }

            var post = await _postService.GetPostByIdAsync(postId);
            post.Name = request.Name;

            var update = await _postService.UpdatePostAsync(post);

            if (!update)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PostResponse>(post));
        }

        [HttpGet(ApiRoute.Posts.Get)]
        [Cached(600)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PostResponse>(post));
        }

        
        [HttpPost(ApiRoute.Posts.Create)]
        [ProducesResponseType(typeof(PostResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var newPostId = Guid.NewGuid(); //
            var post = new Post {
                Id = newPostId, //
                Name = postRequest.Name,
                UserId = HttpContext.GetUserId(),
                Tags = postRequest.Tags.Select(x => new Tag { 
                    PostId = newPostId, 
                    Name = x,
                    CreatedBy = x,
                    CreatorId = HttpContext.GetUserId(),
                    CreatedOn = DateTime.UtcNow
                }).ToList()
            };

            var created = await _postService.CreatePostAsync(post);

            if (!created)
            {
                return BadRequest(new ErrorResponse { Errors = new List<ErrorModel>
                {
                    new ErrorModel { Message = "Unable to create Post"}
                } });
            }

            //var tags = new List<Tag>();
            //postRequest.Tags.ForEach(tag => tags.Add(new Tag
            //{
            //    Name = tag,
            //    PostId = post.Id,
            //    CreatorId = HttpContext.GetUserId(),
            //    CreatedBy = tag,
            //    CreatedOn = DateTime.UtcNow
            //}));

            //await _tagService.CreateTagsAsync(tags);

            //var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            //var locationUri = baseUrl + "/" + ApiRoute.Posts.Get.Replace("{postId}", post.Id.ToString());
            var locationUri = _uriService.GetPostUri(post.Id.ToString());

            var response = _mapper.Map<PostResponse>(post);

            return Created(locationUri, response);
        }
    }
}
