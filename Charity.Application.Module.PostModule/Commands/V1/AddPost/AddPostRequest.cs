using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.PostModule.Commands.V1.AddPost
{
    public class AddPostRequest : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public string CreatedBy { get; set; }   
    }
}