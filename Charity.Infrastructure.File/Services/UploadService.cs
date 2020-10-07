using System;
using System.IO;
using System.Threading.Tasks;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.FileModule.DTOs;
using Charity.Application.FileModule.Interfaces;
using Charity.Application.FileModule.Interfaces.Repositories;
using Charity.Application.IdentityModule.Interfaces;
using Charity.Domain.Entities.dbo;
using Charity.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Charity.Infrastructure.File.Services
{
    public class UploadService : IUploadService
    {
        private readonly IUploadedFileRepositoryAsync _fileRepository;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IPhilanthropistRepositoryAsync _philanthropistRepository;
        private readonly UploadSettings _options;

        public UploadService(IOptions<UploadSettings> options,
                            IUploadedFileRepositoryAsync repository,
                            IAuthenticatedUserService authenticatedUserService,
                            IPhilanthropistRepositoryAsync philanthropistRepository
                            )
        {
            _fileRepository = repository;
            _authenticatedUserService = authenticatedUserService;
            _philanthropistRepository = philanthropistRepository;
            _options = options.Value;
        }

        private static string GetUniqueId() => Guid.NewGuid().ToString();

        private async Task<string> UploadFile(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            
            var filename = _options.FileUploadPath + "/" + GetUniqueId() + extension;

            await using var fileStream = new FileStream(filename, FileMode.Create);
            await file.CopyToAsync(fileStream);

            return filename;
        }

        public async Task<UploadResult> UploadUserFile(int typeId, IFormFile file)
        {
            if(file == null)
                return UploadResult.Failed(string.Empty ,"فایل خالی است");
            
            var filename =  await UploadFile(file);
            var userFile = new UploadedFile
            {
                FilePath = filename,
                TypeId = typeId,
                FileName= file.FileName,
                CreatedBy = _authenticatedUserService.UserId,
                Created = DateTime.Now
            };

            await _fileRepository.AddAsync(userFile);
            return UploadResult.Succeed(filename, userFile.Id);
        }

        public async Task<UploadResult> UploadPostFile(int postId, int typeId, IFormFile file)
        {
            if(file == null)
                return UploadResult.Failed(string.Empty ,"فایل خالی است");
            
            var filename =  await UploadFile(file);
            var userFile = new UploadedFile
            {
                FilePath = filename,
                TypeId = typeId,
                FileName= file.FileName,
                PostId = postId,
                CreatedBy = _authenticatedUserService.UserId,
                Created = DateTime.Now
            };

            await _fileRepository.AddAsync(userFile);
            return UploadResult.Succeed(filename, userFile.Id);
        }

        public async Task<UploadResult> UploadProjectFile(int projectId, int typeId, IFormFile file)
        {
            if(file == null)
                return UploadResult.Failed(string.Empty ,"فایل خالی است");
            
            var filename =  await UploadFile(file);
            var userFile = new UploadedFile
            {
                FilePath = filename,
                TypeId = typeId,
                FileName= file.FileName,
                ProjectId = projectId,
                CreatedBy = _authenticatedUserService.UserId,
                Created = DateTime.Now
            };

            await _fileRepository.AddAsync(userFile);
            return UploadResult.Succeed(filename, userFile.Id);
        }

        public async Task<UploadResult> UploadPhilanthropistFile(int philanthropistId, int typeId, IFormFile file)
        {
            if(file == null)
                return UploadResult.Failed(string.Empty ,"فایل خالی است");
            
            var filename =  await UploadFile(file);
            var userFile = new UploadedFile
            {
                FilePath = filename,
                TypeId = typeId,
                FileName= file.FileName,
                CreatedBy = _authenticatedUserService.UserId,
                Created = DateTime.Now
            };
            await _fileRepository.AddAsync(userFile);

            var ph = await _philanthropistRepository.GetByIdAsync(philanthropistId);
            ph.ImageId = userFile.Id;
            await _philanthropistRepository.UpdateAsync(ph);

            return UploadResult.Succeed(filename, userFile.Id);
        }
    }
}
