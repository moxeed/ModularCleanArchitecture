using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.ProjectModule.Queries.V1.GetAllProjects
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQueryRequest,Response<IEnumerable<ProjectDto>>>
    {
        private readonly IProjectRepositoryAsync _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetAllProjectsHandler(IProjectRepositoryAsync repository, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ProjectDto>>> Handle(GetAllProjectsQueryRequest request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllViewAsync();
            return new Response<IEnumerable<ProjectDto>>(projects.Select(p => _mapper.Map<ProjectDto>(p)));
        }
    }
}
