using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.ProjectModule.Commands.V1.DeleteProjectType
{
    public class DeleteProjectTypeRequest : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
}