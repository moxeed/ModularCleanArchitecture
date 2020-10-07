using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.Module.Wrappers;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.AdminModule.Commands.V1.AddPhilanthropist
{
    public class AddPhilanthropistHandler : IRequestHandler<AddPhilanthropistRequest, Response<int>>
    {
        private readonly IPhilanthropistRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public AddPhilanthropistHandler(IPhilanthropistRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<int>> Handle(AddPhilanthropistRequest request, CancellationToken cancellationToken)
        {
            var philanthropist = _mapper.Map<Philanthropist>(request);
            await _repository.AddAsync(philanthropist);

            return new Response<int>(philanthropist.Id);
        }
    }
}
