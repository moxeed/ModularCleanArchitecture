using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Common;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.DTOs.V1;
using Charity.Application.PostModule.Interfaces.Repositories;
using MediatR;

namespace Charity.Application.PostModule.Queries.GetPost
{
    public class GetPostRequestHandler : IRequestHandler<GetPostRequest,Response<PostDto>>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public GetPostRequestHandler(IPostRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<PostDto>> Handle(GetPostRequest request, CancellationToken cancellationToken)
        {
            var post = await _repository.GetByIdAsync(request.Id);
            if(post is null)
                throw new ApiException(PersianErrorMessages.NotFound);

            return ResponseBuilder.Create(_mapper.Map<PostDto>(post));
        }
    }
}