using Charity.Application.Module.Interfaces;
using Charity.Domain.Entities.Core;

namespace Charity.Application.PostModule.Interfaces.Repositories
{
    public interface IPostRepository : IGenericAuditAbleRepositoryAsync<Post>
    {
    }
}