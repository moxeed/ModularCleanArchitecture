using System.Collections.Generic;
using System.Collections.Specialized;
using Charity.Application.Module.DTOs;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using MediatR;

namespace Charity.Application.ProjectModule.Queries.V1.GetProjectsSection
{
    public class GetProjectSectionRequest : IRequest<Response<IEnumerable<SectionDto<ProjectDto>>>>
    {
        public int Length { get; set; }
    }
}