using Charity.Application.Module.Wrappers;
using Charity.Application.ProjectModule.DTOs.V1;
using MediatR;

namespace Charity.Application.ProjectModule.Commands.V1.AddProjectType
{
    public class AddProjectTypeRequest : IRequest<Response<int>>
    {
        public string TypeName { get; set; }
    }
}