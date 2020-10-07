using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.PostModule.Commands.V1.EditPost
{
    public class EditPostRequest : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
    }
}