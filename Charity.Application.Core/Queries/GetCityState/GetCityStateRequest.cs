using Charity.Application.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Charity.Application.Queries.GetCityState
{
    public class GetCityStateRequest : IRequest<Response<IEnumerable<CityStateDto>>>
    {
    }
}
