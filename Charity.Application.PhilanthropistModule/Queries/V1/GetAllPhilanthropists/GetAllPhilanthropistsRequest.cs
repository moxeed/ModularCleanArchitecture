using System.Collections.Generic;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropists
{
    public class GetAllPhilanthropistsRequest : IRequest<Response<IEnumerable<PhilanthropistDto>>>
    {
    }
}