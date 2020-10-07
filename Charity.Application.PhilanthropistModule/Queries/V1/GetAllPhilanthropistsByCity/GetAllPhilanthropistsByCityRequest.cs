using System.Collections.Generic;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetAllPhilanthropistsByCity
{
    public class GetAllPhilanthropistsByCityRequest : IRequest<Response<IEnumerable<PhilanthropistDto>>>
    {
        public int CityId { get; set; }
    }
}