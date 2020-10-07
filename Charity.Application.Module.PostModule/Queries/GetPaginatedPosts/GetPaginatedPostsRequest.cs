using System.Collections.Generic;
using Charity.Application.Module.Parameters;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.DTOs.V1;
using MediatR;

namespace Charity.Application.PostModule.Queries.GetPaginatedPosts
{
    public class GetPaginatedPostsRequest : RequestParameter, IRequest<PagedResponse<IEnumerable<PostDto>>>
    {
    }
}