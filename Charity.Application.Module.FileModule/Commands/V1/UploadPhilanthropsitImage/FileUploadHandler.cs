﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Charity.Application.FileModule.Commands.V1.UploadPhilanthropsitImage;
using Charity.Application.FileModule.DTOs;
using Charity.Application.FileModule.Interfaces;
using Charity.Application.FileModule.Interfaces.Repositories;
using Charity.Application.Module.Exceptions;
using Charity.Application.Module.Wrappers;
using MediatR;

namespace Charity.Application.FileModule.Commands.V1.UploadPhilanthropistImage
{
    public class FileUploadHandler : IRequestHandler<UploadPhilanthropistImageRequest,Response<FileUploadResponse>>
    {
        private readonly IUploadedFileRepositoryAsync _repository;
        private readonly IUploadService _uploadService;

        public FileUploadHandler(IUploadedFileRepositoryAsync repository, IUploadService uploadService)
        {
            _repository = repository;
            _uploadService = uploadService;
        }
        
        public async Task<Response<FileUploadResponse>> Handle(UploadPhilanthropistImageRequest request, CancellationToken cancellationToken)
        {
            var res = await _uploadService.UploadPhilanthropistFile(request.PhilanthropistId,1, request.File);
            
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