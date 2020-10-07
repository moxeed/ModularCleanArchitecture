using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.DTOs.V1;
using Charity.Application.PostModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.PostModule.Queries.GetAllPosts
{
    public class GetAllPostsHandler : IRequestHandler<GetAllPostsRequest,Response<IEnumerable<PostDto>>>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public GetAllPostsHandler(IPostRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<IEnumerable<PostDto>>> Handle(GetAllPostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await _repository.GetAllViewAsync();
            return ResponseBuilder.Create(posts.Select(p => _mapper.Map<PostDto>(p)));
        }
    }
}