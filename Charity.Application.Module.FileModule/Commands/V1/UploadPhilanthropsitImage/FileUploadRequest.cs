using Charity.Application.FileModule.DTOs;
using Charity.Application.Module.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Charity.Application.FileModule.Commands.V1.UploadPhilanthropsitImage
{
    public class UploadPhilanthropistImageRequest : IRequest<Response<FileUploadResponse>>
    {
        public int PhilanthropistId { get; set; }
        public IFormFile File { get; set; }
    }
}