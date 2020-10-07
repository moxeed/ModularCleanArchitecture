using System.Threading.Tasks;
using Charity.Application.PostModule.Commands.V1.AddPost;
using Charity.Application.PostModule.Commands.V1.EditPost;
using Charity.Application.PostModule.Queries.GetAllPosts;
using Charity.Application.PostModule.Queries.GetPaginatedPosts;
using Charity.Application.PostModule.Queries.GetPost;
using Charity.Application.PostModule.Queries.GetPostsSection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Charity.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PostController : BaseApiController
    {
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreatePost(AddPostRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpPost("Edit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> EditPost(EditPostRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            return Ok(await Mediator.Send(new GetAllPostsRequest()));
        }
        
        [HttpGet("Paginated")]
        public async Task<IActionResult> GetPaginatedPost([FromQuery]GetPaginatedPostsRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPost(int id)
        {
            return Ok(await Mediator.Send(new GetPostRequest{Id = id}));
        }
        
        [HttpGet("Section")]
        public async Task<IActionResult> GetPost([FromQuery] GetPostSectionRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
