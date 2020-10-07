using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.ProjectModule.Queries.V1.GetProjectsByType
{
    public class GetProjectsByTypeHandler : IRequestHandler<GetProjectsByTypeQueryRequest,Response<IEnumerable<ProjectDto>>>
    {
        private readonly IProjectRepositoryAsync _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetProjectsByTypeHandler(IProjectRepositoryAsync repository, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<ProjectDto>>> Handle(GetProjectsByTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetByTypeAsync(request.TypeId ?? throw new NullReferenceException());
            return new Response<IEnumerable<ProjectDto>>(projects.Select(p => _mapper.Map<ProjectDto>(p)));
        }
    }
}
