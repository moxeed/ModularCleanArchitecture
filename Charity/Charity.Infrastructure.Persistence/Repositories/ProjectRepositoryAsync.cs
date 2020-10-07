using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Charity.Application.Module.Interfaces;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using Charity.Domain.Entities.Core;
using Charity.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Charity.Infrastructure.Persistence.Repositories
{
    public class ProjectRepositoryAsync : GenericAuditAbleRepositoryAsync<Project>,IProjectRepositoryAsync
    {
        private readonly IGenericRepositoryAsync<ProjectType> _typeRepository;
        public ProjectRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _typeRepository = new GenericRepositoryAsync<ProjectType>(dbContext);
        }

        protected override IQueryable<Project> GetDbSet()
        {
            return base.GetDbSet().Include(c=> c.City).Include(c => c.Philanthropist).Include(c => c.Type).
                Include(c => c.AttachedFiles);
        }

        public async Task<IQueryable<Project>> GetByTypeAsync(int typeId)
        {
            return DbContext.Projects.Where(p => p.TypeId == typeId);
        }

        public async Task<ProjectType> GetTypeByIdAsync(int id)
        {
            return await _typeRepository.GetByIdAsync(id);
        }

        public async Task<int> AddProjectTypeAsync(ProjectType type)
        {
            await _typeRepository.AddAsync(type);
            return type.Id;
        }

        public async Task<int> DeleteProjectTypeAsync(ProjectType type)
        {
            await _typeRepository.DeleteAsync(type);
            return type.Id;
        }
        
        public async Task<IReadOnlyList<ProjectType>> GetProjectTypeViewAsync()
        {
            return await _typeRepository.GetAllAsync();
        }
    }
}
