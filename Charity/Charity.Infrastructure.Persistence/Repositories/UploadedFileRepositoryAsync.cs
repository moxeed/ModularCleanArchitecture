using Charity.Application.FileModule.Interfaces.Repositories;
using Charity.Domain.Entities.dbo;
using Charity.Infrastructure.Persistence.Contexts;

namespace Charity.Infrastructure.Persistence.Repositories
{
    public class UploadedFileRepositoryAsync : GenericRepositoryAsync<UploadedFile>,IUploadedFileRepositoryAsync
    {
        public UploadedFileRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}