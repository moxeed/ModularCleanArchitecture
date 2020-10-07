using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.AdminModule.Commands.V1.DeletePhilanthropist
{
    public class DeletePhilanthropistRequest : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}