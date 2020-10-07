using System.Threading.Tasks;
using Charity.Application.FileModule.Commands.V1.UploadFile;
using Charity.Application.FileModule.Commands.V1.UploadPhilanthropsitImage;
using Charity.Application.FileModule.Commands.V1.UploadPostImage;
using Charity.Application.FileModule.Commands.V1.UploadProjectFile;
using Charity.Application.FileModule.Queries.V1.GetFile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Charity.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FileController : BaseApiController
    {
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadFile([FromForm] FileUploadRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpPost("Post")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadPostFile([FromForm] PostFileUploadRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpPost("Project")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ProjectUploadFile([FromForm] ProjectFileUploadRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpPost("Philanthropist")]
        public async Task<IActionResult> PhilanthropistUploadFile([FromForm] UploadPhilanthropistImageRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetFile(int id)
        {
            var file = await Mediator.Send(new GetFileRequest{Id = id}); 
            return File(file.Bytes,file.MimeType,file.Name);
        }
    }
}
