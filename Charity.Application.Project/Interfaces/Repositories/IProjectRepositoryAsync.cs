using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charity.Application.Module.Interfaces;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Domain.Entities.Core;

namespace Charity.Application.ProjectModule.Interfaces.Repositories
{
    public interface IProjectRepositoryAsync : IGenericAuditAbleRepositoryAsync<Project>
    {
        Task<IQueryable<Project>> GetByTypeAsync(int typeId);

        Task<ProjectType> GetTypeByIdAsync(int id);
        Task<int> AddProjectTypeAsync(ProjectType type);
        Task<int> DeleteProjectTypeAsync(ProjectType type);
        Task<IReadOnlyList<ProjectType>> GetProjectTypeViewAsync();
    }
}
