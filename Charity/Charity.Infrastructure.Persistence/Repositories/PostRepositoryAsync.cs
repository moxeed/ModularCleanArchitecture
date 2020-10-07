using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.PostModule.Interfaces.Repositories;
using Charity.Domain.Entities.Core;
using Charity.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Charity.Infrastructure.Persistence.Repositories
{
    public class PostRepositoryAsync :GenericAuditAbleRepositoryAsync<Post>, IPostRepository
    {
        public PostRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Post> GetDbSet()
        {
            return base.GetDbSet().Include(c => c.Files);
        }
    }
}