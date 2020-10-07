using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.DTOs;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Charity.Application.ProjectModule.Queries.V1.GetProjectsSection
{
    public class ProjectSectionHandler : IRequestHandler<GetProjectSectionRequest,Response<IEnumerable<SectionDto<ProjectDto>>>>
    {
        private readonly IProjectRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public ProjectSectionHandler(IProjectRepositoryAsync repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<IEnumerable<SectionDto<ProjectDto>>>> Handle(GetProjectSectionRequest request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllViewAsync();

            var groupedProjects = projects.GroupBy(c => c.Type)
                .Select(s => new SectionDto<ProjectDto>()
                {
                    Id = s.Key.Id,
                    Title = s.Key.TypeName,
                    Data = s.Take(request.Length).Select(p => _mapper.Map<ProjectDto>(p))
                }).AsEnumerable();

            return ResponseBuilder.Create(groupedProjects);
        }
    }
}