using System.Collections.Generic;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using MediatR;

namespace Charity.Application.ProjectModule.Queries.V1.GetAllProjects
{
    public class GetAllProjectsQueryRequest : IRequest<Response<IEnumerable<ProjectDto>>>
    {
    }
}
