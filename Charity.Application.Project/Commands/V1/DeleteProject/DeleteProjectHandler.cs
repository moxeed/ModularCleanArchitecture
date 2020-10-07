using System.Threading;
using System.Threading.Tasks;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.ProjectModule.Commands.V1.DeleteProject
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectRequest,Response<int>>
    {
        private readonly IProjectRepositoryAsync _repository;

        public DeleteProjectHandler(IProjectRepositoryAsync repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.Id);

            if(project == null)
                throw new ApiException("پروژه پیدا نشد");

            await _repository.DeleteAsync(project);

            return new Response<int>(project.Id);
        }
    }
}

