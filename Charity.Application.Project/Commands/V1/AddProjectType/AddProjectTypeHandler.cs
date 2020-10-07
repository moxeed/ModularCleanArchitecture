using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.ProjectModule.Commands.V1.AddProjectType
{
    public class AddProjectTypeHandler : IRequestHandler<AddProjectTypeRequest,Response<int>>
    {
        private readonly IProjectRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public AddProjectTypeHandler(IProjectRepositoryAsync repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<int>> Handle(AddProjectTypeRequest request, CancellationToken cancellationToken)
        {
            var projectType = _mapper.Map<ProjectType>(request);
            await _repository.AddProjectTypeAsync(projectType);
            return new Response<int>(projectType.Id);
        }
    }
}