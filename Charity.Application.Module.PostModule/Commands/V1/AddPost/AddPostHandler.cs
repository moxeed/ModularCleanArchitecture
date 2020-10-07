using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.Interfaces.Repositories;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.PostModule.Commands.V1.AddPost
{
    public class AddPostHandler : IRequestHandler<AddPostRequest,Response<int>>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public AddPostHandler(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<int>> Handle(AddPostRequest request, CancellationToken cancellationToken)
        {
            var post = _mapper.Map<Post>(request);
            await _repository.AddAsync(post);
            return ResponseBuilder.Create(post.Id);
        }
    }
}