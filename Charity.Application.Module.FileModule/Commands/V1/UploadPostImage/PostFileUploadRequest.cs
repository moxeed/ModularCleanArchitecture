using Charity.Application.FileModule.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Charity.Application.FileModule.Commands.V1.UploadPostImage
{
    public class PostFileUploadRequest : IRequest<Response<FileUploadResponse>>
    {
        public int PostId { get; set; }
        public IFormFile File { get; set; }
    }
}