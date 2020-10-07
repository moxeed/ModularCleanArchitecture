using System.Collections.Generic;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using MediatR;

namespace Charity.Application.ProjectModule.Queries.V1.GetProjectsByType
{
    public class GetProjectsByTypeQueryRequest : IRequest<Response<IEnumerable<ProjectDto>>>
    {
        public int? TypeId { get; set; }
    }
}
