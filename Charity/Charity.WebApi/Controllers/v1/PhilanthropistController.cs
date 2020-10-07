using System.Threading.Tasks;
using Charity.Application.AdminModule.Commands.V1.AddPhilanthropist;
using Charity.Application.AdminModule.Commands.V1.DeletePhilanthropist;
using Charity.Application.AdminModule.Commands.V1.EditPhilanthropist;
using Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropists;
using Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCity;
using Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCityGroup;
using Charity.Application.AdminModule.Queries.V1.GetPhilanthropist;
using Charity.Application.AdminModule.Queries.V1.GetPhilnathropistSection;
using Charity.Application.ProjectModule.Queries.V1.GetProjectsSection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Charity.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PhilanthropistController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPhilanthropistsRequest()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPhilanthropistRequest { Id = id}));
        }
        
        [HttpGet("Group/ByCity")]
        public async Task<IActionResult> GetGrouped()
        {
            return Ok(await Mediator.Send(new GetAllPhilanthropistsByCityGroupRequest()));
        }
        
        [HttpGet("ByCity")]
        public async Task<IActionResult> GetByType([FromQuery]GetAllPhilanthropistsByCityRequest  request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpGet("Section")]
        public async Task<IActionResult> GetSection(    [FromQuery] GetPhilnathropistRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
        
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Add(AddPhilanthropistRequest request)
        {
            return Created(Request.Path, await Mediator.Send(request));
        }

        [HttpPost("Edit")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Edit(EditPhilanthropistRequest request)
        {
            return Accepted(await Mediator.Send(request));
        }

        [HttpPost("Delete")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> Delete([FromQuery] DeletePhilanthropistRequest request)
        {
            return Accepted(await Mediator.Send(request));
        }
    }
}
