using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Charity.Domain.Common;

namespace Charity.Application.Module.Interfaces
{
    public interface IGenericAuditAbleRepositoryAsync<T> where T : AuditableBaseEntity
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();
        Task<IReadOnlyList<T>> GetAllViewAsync();
        Task<IReadOnlyList<T>> GetViewByConditionAsync(Expression<Func<T,bool>> expression);
        Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}