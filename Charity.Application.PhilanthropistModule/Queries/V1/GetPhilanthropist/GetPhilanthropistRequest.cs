using Charity.Application.AdminModule.DTOs;
using Charity.Application.Module.Wrappers;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.AdminModule.Queries.V1.GetPhilanthropist
{
    public class GetPhilanthropistRequest : IRequest<Response<PhilanthropistDto>>
    {
        public int Id { get; set; }
    }
}