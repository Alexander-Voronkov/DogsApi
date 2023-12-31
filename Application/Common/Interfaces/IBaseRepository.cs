﻿using System.Linq.Expressions;

namespace Application.Common.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(int id);
        Task<IQueryable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> FindMany(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> FindOne(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
    }
}
