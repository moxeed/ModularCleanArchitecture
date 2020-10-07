using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.Module.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetPhilnathropistSection
{
    public class GetPhilnathropistHandler : IRequestHandler<GetPhilnathropistRequest,Response<IEnumerable<SectionDto<PhilanthropistDto>>>>
    {
        private readonly IPhilanthropistRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public GetPhilnathropistHandler(IPhilanthropistRepositoryAsync repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<IEnumerable<SectionDto<PhilanthropistDto>>>> Handle(GetPhilnathropistRequest request, CancellationToken cancellationToken)
        {
            var philanthropists = await _repository.GetAllViewAsync();

            var section = new List<SectionDto<PhilanthropistDto>> {new SectionDto<PhilanthropistDto>()
                {
                    Id = -1 ,
                    Title = "خیرین",
                    Data = philanthropists.Take(request.Length).Select(p => _mapper.Map<PhilanthropistDto>(p))
                } 
            }.AsEnumerable();

            return ResponseBuilder.Create(section);
        }
    }
}