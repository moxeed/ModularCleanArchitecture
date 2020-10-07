using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.Module.Common;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetPhilanthropist
{
    public class GetPhilanthropistHandler : IRequestHandler<GetPhilanthropistRequest,Response<PhilanthropistDto>>
    {
        private readonly IPhilanthropistRepositoryAsync _repository;
        private readonly IMapper _mapper;

        public GetPhilanthropistHandler(IPhilanthropistRepositoryAsync repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<PhilanthropistDto>> Handle(GetPhilanthropistRequest request, CancellationToken cancellationToken)
        {
            var philanthropist = await _repository.GetByIdAsync(request.Id);

            if (philanthropist is null)
                throw new ApiException(PersianErrorMessages.NotFound);

            return ResponseBuilder.Create(_mapper.Map<PhilanthropistDto>(philanthropist));
        }
    }
}