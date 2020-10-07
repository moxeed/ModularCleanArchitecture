using Charity.Application.FileModule.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Charity.Application.FileModule.Commands.V1.UploadFile
{
    public class FileUploadRequest : IRequest<Response<FileUploadResponse>>
    {
        public IFormFile File { get; set; }
    }
}