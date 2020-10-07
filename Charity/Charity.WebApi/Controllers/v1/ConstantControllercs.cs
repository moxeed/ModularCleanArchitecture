using System.Threading.Tasks;
using Charity.Application.AdminModule.Commands.V1.AddPhilanthropist;
using Charity.Application.AdminModule.Commands.V1.DeletePhilanthropist;
using Charity.Application.AdminModule.Commands.V1.EditPhilanthropist;
using Charity.Application.AdminModule.Queries.V1;
using Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropists;
using Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCity;
using Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCityGroup;
using Charity.Application.FileModule.Commands.V1.UploadFile;
using Charity.Application.FileModule.Commands.V1.UploadPostImage;
using Charity.Application.FileModule.Commands.V1.UploadProjectFile;
using Charity.Application.FileModule.Queries;
using Charity.Application.FileModule.Queries.V1.GetFile;
using Charity.Application.ProjectModule.Commands.V1.AddProjectType;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Queries;
using Charity.Application.ProjectModule.Queries.V1.GetAllProjects;
using Charity.Application.ProjectModule.Queries.V1.GetProjectsByType;
using Charity.Application.Queries.GetCityState;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;

namespace Charity.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ConstantController : BaseApiController
    {
        [HttpGet("CityState")]
        public async Task<IActionResult> GetCityStates() 
        {
            return Ok(await Mediator.Send(new GetCityStateRequest()));
        }
    }
}
