using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Common;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.DTOs.V1;
using Charity.Application.PostModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.PostModule.Queries.GetPaginatedPosts
{
    public class GetPaginatedPostsHandler : IRequestHandler<GetPaginatedPostsRequest,PagedResponse<IEnumerable<PostDto>>>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public GetPaginatedPostsHandler(IPostRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<PostDto>>> Handle(GetPaginatedPostsRequest request, CancellationToken cancellationToken)
        {
            var postCount = _repository.GetAll().Count(c => c.Deleted == null);

            if ((request.PageNumber - 1) * request.PageSize > postCount)
                throw new ApiException(PersianErrorMessages.LastPage);

            var posts = await _repository.GetPagedResponseAsync(request.PageNumber, request.PageSize);
            var postsDto = posts.Select(p => _mapper.Map<PostDto>(p));

            return new PagedResponse<IEnumerable<PostDto>>(postsDto, request.PageNumber, request.PageSize,
                (int)Math.Ceiling((decimal)postCount / request.PageSize));
        }
    }
}