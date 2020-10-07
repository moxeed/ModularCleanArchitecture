using Charity.Application.Module.Interfaces;
using Charity.Domain.Entities.dbo;

namespace Charity.Application.FileModule.Interfaces.Repositories
{
    public interface IUploadedFileRepositoryAsync : IGenericRepositoryAsync<UploadedFile>
    {
    }
}