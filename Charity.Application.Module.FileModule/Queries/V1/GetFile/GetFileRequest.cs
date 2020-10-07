using Charity.Application.FileModule.DTOs;
using MediatR;

namespace Charity.Application.FileModule.Queries.V1.GetFile
{
    public class GetFileRequest : IRequest<DownloadFileResponse>
    {
        public int Id { get; set; }
    }
}