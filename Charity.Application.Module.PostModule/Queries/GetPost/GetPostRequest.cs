using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.DTOs.V1;
using MediatR;

namespace Charity.Application.PostModule.Queries.GetPost
{
    public class GetPostRequest :IRequest<Response<PostDto>>
    {
        public int Id { get; set; }
    }
}