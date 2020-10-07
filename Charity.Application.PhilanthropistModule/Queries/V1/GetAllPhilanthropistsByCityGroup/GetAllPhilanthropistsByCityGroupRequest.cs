using System.Collections.Generic;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCityGroup
{
    public class GetAllPhilanthropistsByCityGroupRequest : IRequest<Response<IEnumerable<CityPhilanthropistsDto>>>
    {
    }
}