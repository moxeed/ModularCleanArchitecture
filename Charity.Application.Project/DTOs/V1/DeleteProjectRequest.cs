using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.ProjectModule.DTOs.V1
{
    public class DeleteProjectRequest : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}
