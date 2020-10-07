using System.Threading.Tasks;
using Charity.Application.ProjectModule.Commands.V1.AddProjectType;
using Charity.Application.ProjectModule.Commands.V1.DeleteProjectType;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Queries;
using Charity.Application.ProjectModule.Queries.V1.GetAllProjects;
using Charity.Application.ProjectModule.Queries.V1.GetProjectsByType;
using Charity.Application.ProjectModule.Queries.V1.GetProjectsSection;
using Charity.Application.ProjectModule.Queries.V1.GetProjectTypes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;

namespace Charity.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProjectController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProjectsQueryRequest()));
        }
        
        [HttpGet("ByType")]
        public async Task<IActionResult> GetByType([FromQuery] GetProjectsByTypeQueryRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("Section")]
        public async Task<IActionResult> GetSection([FromQuery] GetProjectSectionRequest request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(AddProjectRequest request)
        {
            return Created(Request.Path, await Mediator.Send(request));
        }

        [HttpPost("Edit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Edit(EditProjectRequest request)
        {
            return Accepted(await Mediator.Send(request));
        }

        [HttpPost("Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Delete([FromQuery] DeleteProjectRequest request)
        {
            return Accepted(await Mediator.Send(request));
        }
        
        [HttpGet("Type")]
        public async Task<IActionResult> AddType()
        {
            return Ok(await Mediator.Send(new GetProjectTypesRequest()));
        }
        
        [HttpPost("Type")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddType(AddProjectTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpPost("Type/Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddType(DeleteProjectTypeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
