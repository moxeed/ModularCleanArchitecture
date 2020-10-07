using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Charity.Application.FileModule.DTOs;
using Charity.Application.FileModule.Interfaces;
using Charity.Application.FileModule.Interfaces.Repositories;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using Charity.Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace Charity.Application.FileModule.Commands.V1.UploadPostImage
{
    public class FileUploadHandler : IRequestHandler<PostFileUploadRequest,Response<FileUploadResponse>>
    {
        private readonly IUploadService _uploadService;
        private readonly IOptions<UploadSettings> options;

        public FileUploadHandler(IUploadService uploadService,IOptions<UploadSettings> options)
        {
            _uploadService = uploadService;
            this.options = options;
        }
        
        public async Task<Response<FileUploadResponse>> Handle(PostFileUploadRequest request, CancellationToken cancellationToken)
        {
            var res = await _uploadService.UploadPostFile(request.PostId,1, request.File);
            
            if (res.Succeeded)
            {
                return ResponseBuilder.Create(new FileUploadResponse
                {
                    FileId = res.FileId ?? -1
                });
            }
            
            throw new ApiException(res.Errors.FirstOrDefault()); 
        }
    }
}