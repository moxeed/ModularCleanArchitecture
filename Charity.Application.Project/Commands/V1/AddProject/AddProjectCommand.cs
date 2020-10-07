using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.ProjectModule.Commands.V1.AddProject
{
    public class AddProjectRequestHandler : IRequestHandler<AddProjectRequest,Response<int>>
    {
        private readonly IProjectRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public AddProjectRequestHandler(IProjectRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddProjectRequest request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<Domain.Entities.Core.Project>(request);
            await _repository.AddAsync(project);
            return new Response<int>(project.Id);
        }
    }
}
