using System.Threading.Tasks;
using Charity.Application.FileModule.DTOs;
using Microsoft.AspNetCore.Http;

namespace Charity.Application.FileModule.Interfaces
{
    public interface IUploadService
    {
        public Task<UploadResult> UploadUserFile(int typeId, IFormFile file);
        public Task<UploadResult> UploadPostFile(int postId,int typeId, IFormFile file);
        public Task<UploadResult> UploadProjectFile(int projectId,int typeId, IFormFile file);
        
        public Task<UploadResult> UploadPhilanthropistFile(int philanthropistId,int typeId, IFormFile file);
    }
}