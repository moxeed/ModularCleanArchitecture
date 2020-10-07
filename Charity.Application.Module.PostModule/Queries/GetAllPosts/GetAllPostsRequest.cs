using System.Collections.Generic;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.DTOs.V1;
using MediatR;

namespace Charity.Application.PostModule.Queries.GetAllPosts
{
    public class GetAllPostsRequest : IRequest<Response<IEnumerable<PostDto>>>
    {
    }
}