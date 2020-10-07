using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.AdminModule.Commands.V1.AddPhilanthropist;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.AdminModule.Commands.V1.EditPhilanthropist
{
    public class EditPhilanthropistHandler : IRequestHandler<EditPhilanthropistRequest, Response<int>>
    {
        private readonly IPhilanthropistRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public EditPhilanthropistHandler(IPhilanthropistRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<int>> Handle(EditPhilanthropistRequest request, CancellationToken cancellationToken)
        {

            var philanthropist = await _repository.GetByIdAsync(request.Id);
            if(philanthropist is null)
                throw new ApiException("خیر پیدا نشد");
            
            philanthropist = _mapper.Map<Philanthropist>(request);
            await _repository.UpdateAsync(philanthropist);

            return new Response<int>(philanthropist.Id);
        }
    }
}
