using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCity
{
    public class GetAllPhilanthropistsByCityHandler : IRequestHandler<GetAllPhilanthropistsByCityRequest,Response<IEnumerable<PhilanthropistDto>>>
    {
        private readonly IPhilanthropistRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public GetAllPhilanthropistsByCityHandler(IPhilanthropistRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<PhilanthropistDto>>> Handle(GetAllPhilanthropistsByCityRequest request, CancellationToken cancellationToken)
        {
            var philanthropists = await _repository.
                GetViewByConditionAsync(p => p.CityId == request.CityId);
            
            return ResponseBuilder.Create(philanthropists.Select(p => _mapper.Map<PhilanthropistDto>(p)));
        }
    }
}