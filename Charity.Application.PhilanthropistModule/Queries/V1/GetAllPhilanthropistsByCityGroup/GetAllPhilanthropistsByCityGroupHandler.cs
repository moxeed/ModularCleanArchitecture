using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.Module.Wrappers;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCityGroup
{
    public class GetAllPhilanthropistsByCityGroupHandler : IRequestHandler<GetAllPhilanthropistsByCityGroupRequest,Response<IEnumerable<CityPhilanthropistsDto>>>
    {
        private readonly IPhilanthropistRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public GetAllPhilanthropistsByCityGroupHandler(IPhilanthropistRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<CityPhilanthropistsDto>>> Handle(GetAllPhilanthropistsByCityGroupRequest request, CancellationToken cancellationToken)
        {
            var philanthropists = (await _repository.
                GetAllViewAsync()).GroupBy(c => c.CityId);
            
            return ResponseBuilder.Create(philanthropists.Select(gp => 
                new CityPhilanthropistsDto
                {
                    CityId = gp.Key,
                    Philanthropists = gp.Select(p => _mapper.Map<PhilanthropistDto>(p))
                }).AsEnumerable());
        }
    }
}