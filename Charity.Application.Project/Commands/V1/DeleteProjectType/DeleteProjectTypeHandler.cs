using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.ProjectModule.Commands.V1.DeleteProjectType
{
    public class DeleteProjectTypeHandler : IRequestHandler<DeleteProjectTypeRequest,Response<int>>
    {
        private readonly IProjectRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public DeleteProjectTypeHandler(IProjectRepositoryAsync repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<int>> Handle(DeleteProjectTypeRequest request, CancellationToken cancellationToken)
        {
            var type = await _repository.GetTypeByIdAsync(request.Id);
            if (type is null)
                throw new ApiException("دسته بندی پیدا نشد");
            
            var projectType = _mapper.Map<ProjectType>(request);
            await _repository.DeleteProjectTypeAsync(projectType);
            return new Response<int>(projectType.Id);
        }    
    }
}