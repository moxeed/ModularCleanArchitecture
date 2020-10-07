using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Charity.Application.FileModule.DTOs;
using Charity.Application.FileModule.Interfaces.Repositories;
using Charity.Application.FileModule.Mappings;
using Charity.Application.Module.Exceptions;
using Charity.Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;

namespace Charity.Application.FileModule.Queries.V1.GetFile
{
    public class GetFileHandler : IRequestHandler<GetFileRequest, DownloadFileResponse>
    {
        private readonly IUploadedFileRepositoryAsync _repository;
        private readonly IOptions<UploadSettings> _options;

        public GetFileHandler(IUploadedFileRepositoryAsync repository)
        {
            _repository = repository;
        }
        public async Task<DownloadFileResponse> Handle(GetFileRequest request, CancellationToken cancellationToken)
        {
            var file = await _repository.GetByIdAsync(request.Id);
            if (file is null)
                throw new ApiException("فایل مورد نظر پیدا نشد");

            return new DownloadFileResponse
            {
                Name = file.FileName,
                MimeType = MimeTypes.GetContentType(file.FileName),
                Bytes = await File.ReadAllBytesAsync(file.FilePath, cancellationToken)
            };
        }
    }
}