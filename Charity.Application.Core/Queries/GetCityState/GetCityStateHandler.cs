using Charity.Application.DTOs;
using Charity.Application.Interfaces;
using Charity.Application.Module.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Charity.Application.Queries.GetCityState
{
    public class GetCityStateHandler : IRequestHandler<GetCityStateRequest, Response<IEnumerable<CityStateDto>>>
    {
        private readonly IConstantService _constantService;

        public GetCityStateHandler(IConstantService constantService)
        {
            _constantService = constantService;
        }
        public async Task<Response<IEnumerable<CityStateDto>>> Handle(GetCityStateRequest request, CancellationToken cancellationToken)
        {
            return ResponseBuilder.Create(_constantService.GetCityStates());
        }
    }
}
