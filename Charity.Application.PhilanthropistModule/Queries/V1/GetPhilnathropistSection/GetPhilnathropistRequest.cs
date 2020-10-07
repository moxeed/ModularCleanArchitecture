using System.Collections.Generic;
using Charity.Application.AdminModule.DTOs;
using Charity.Application.Module.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetPhilnathropistSection
{
    public class GetPhilnathropistRequest : IRequest<Response<IEnumerable<SectionDto<PhilanthropistDto>>>>
    {
        public int Length { get; set; }
    }
}