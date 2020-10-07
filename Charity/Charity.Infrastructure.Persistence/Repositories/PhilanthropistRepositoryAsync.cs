using System.Linq;
using System.Threading.Tasks;
using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Domain.Entities.Core;
using Charity.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Charity.Infrastructure.Persistence.Repositories
{
    public class PhilanthropistRepositoryAsync :GenericAuditAbleRepositoryAsync<Philanthropist>, IPhilanthropistRepositoryAsync
    {
        public PhilanthropistRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Philanthropist> GetDbSet()
        {
            return base.GetDbSet().Include(c => c.City)
                .Include(c => c.Projects);
        }
    }
}