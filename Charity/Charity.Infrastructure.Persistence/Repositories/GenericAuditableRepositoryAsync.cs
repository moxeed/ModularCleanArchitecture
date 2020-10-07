using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Charity.Application.Module.Interfaces;
using Charity.Application.ProjectModule.DTOs.V1;
using Charity.Domain.Common;
using Charity.Infrastructure.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Charity.Infrastructure.Persistence.Repositories
{
    public class GenericAuditAbleRepositoryAsync<T> : IGenericAuditAbleRepositoryAsync<T> where T : AuditableBaseEntity
    {
        protected readonly ApplicationDbContext DbContext;

        public GenericAuditAbleRepositoryAsync(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual IQueryable<T> GetDbSet()
        {
            return DbContext.Set<T>()
                .Where(e => e.Deleted == null);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await GetDbSet().Where(c => c.Deleted == null && c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetViewByConditionAsync(Expression<Func<T,bool>> expression)
        {
            return await GetDbSet()
                .Where(expression)
                .ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedResponseAsync(int pageNumber, int pageSize)
        {
            return await GetDbSet()
                .OrderByDescending(c =>c.Created)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return DbContext
                .Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllViewAsync()
        {
            return await GetDbSet()
                .ToListAsync();
        }
    }
}
