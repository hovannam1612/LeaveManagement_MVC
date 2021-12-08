using LeaveManagement.WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LeaveManagement.WebApp.Interfaces
{
    public interface IRepositoryBase<TEntity, TKey>
        where TEntity : class, IBaseEntity<TKey>
        where TKey : struct
    {
        Task<IEnumerable<TEntity>> FindAll(
            Expression<Func<TEntity, bool>> expression = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null);

        Task<TEntity> FindByConditions(
            Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>> includes = null);

        Task Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TKey entityId);
    }
}