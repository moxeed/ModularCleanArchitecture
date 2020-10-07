using Charity.Application.FileModule.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Charity.Application.FileModule.Commands.V1.UploadProjectFile
{
    public class ProjectFileUploadRequest : IRequest<Response<FileUploadResponse>>
    {
        public int ProjectId { get; set; }
        public IFormFile File { get; set; }
    }
}