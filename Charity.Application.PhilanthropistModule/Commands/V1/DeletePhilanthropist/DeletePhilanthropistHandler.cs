using System.Threading;
using System.Threading.Tasks;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Commands.V1.DeletePhilanthropist
{
    public class DeletePhilanthropistHandler : IRequestHandler<DeletePhilanthropistRequest,Response<int>>
    {
        private readonly IPhilanthropistRepositoryAsync _repository;

        public DeletePhilanthropistHandler(IPhilanthropistRepositoryAsync repository)
        {
            _repository = repository;
        }
        
        public async Task<Response<int>> Handle(DeletePhilanthropistRequest request, CancellationToken cancellationToken)
        {
            var phinathropist = await _repository.GetByIdAsync(request.Id);
            if(phinathropist is null)
                throw new ApiException("خیر پیدا نشد");

            await _repository.DeleteAsync(phinathropist);
            return new Response<int>(phinathropist.Id);
        }
    }
}