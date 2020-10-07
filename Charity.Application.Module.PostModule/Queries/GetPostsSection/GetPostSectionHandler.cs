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

namespace Charity.Application.PostModule.Queries.GetPostsSection
{
    public class GetPostSectionHandler : IRequestHandler<GetPostSectionRequest,Response<PostSectionDto>>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public GetPostSectionHandler(IPostRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<PostSectionDto>> Handle(GetPostSectionRequest request, CancellationToken cancellationToken)
        {
            var postCount = _repository.GetAll().Count(c => c.Deleted == null);
            
            var posts = await _repository.GetPagedResponseAsync(1, request.PostCount);
            var postsDto = posts.Select(p => _mapper.Map<PostDto>(p));

            var postBanners = _repository.GetAll().OrderBy(r => Guid.NewGuid()).Take(request.BannerCount).
                Select(p => _mapper.Map<PostBannerDto>(p));

            return ResponseBuilder.Create(new PostSectionDto
            {
                Posts = postsDto,
                BannerPosts = postBanners
            });
        }
    }
}