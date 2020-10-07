using System.Collections.Generic;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using MediatR;

namespace Charity.Application.ProjectModule.Queries.V1.GetProjectTypes
{
    public class GetProjectTypesRequest : IRequest<Response<IEnumerable<ProjectTypeDto>>>
    {
    }
}