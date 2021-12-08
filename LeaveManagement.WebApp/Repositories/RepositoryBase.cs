using LeaveManagement.WebApp.Data;
using LeaveManagement.WebApp.Data.Entities;
using LeaveManagement.WebApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Repositories
{
    public class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : struct
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
           await _dbContext.AddAsync(entity);
        }

        public void Delete(TKey entityId)
        {
            var entityExist = _dbSet.Where(x => x.Id.Equals(entityId)).FirstOrDefault();
            if (entityExist != null)
                _dbSet.Remove(entityExist);
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> expression = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (includes != null)
            {
                query = includes(query);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> FindByConditions(
                Expression<Func<TEntity, bool>> expression,
                Func<IQueryable<TEntity>,
                IIncludableQueryable<TEntity, object>> includes = null
            )
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
            {
                query = includes(query);
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}