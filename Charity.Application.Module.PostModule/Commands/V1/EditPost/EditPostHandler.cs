using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Charity.Application.Module.Common;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using Charity.Application.PostModule.Commands.V1.AddPost;
using Charity.Application.PostModule.Interfaces.Repositories;
using Charity.Domain.Entities.Core;
using MediatR;

namespace Charity.Application.PostModule.Commands.V1.EditPost
{
    public class EditPostHandler : IRequestHandler<EditPostRequest,Response<int>>
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;

        public EditPostHandler(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<Response<int>> Handle(EditPostRequest request, CancellationToken cancellationToken)
        {
            var post = await _repository.GetByIdAsync(request.Id);
            if (post is null)
                throw new ApiException(PersianErrorMessages.NotFound);

            post = _mapper.Map<Post>(request);
            await _repository.UpdateAsync(post);
            return ResponseBuilder.Create(post.Id);
        }
    }
}