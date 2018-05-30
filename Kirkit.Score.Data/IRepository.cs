using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kirkit.Score.Data
{
    public interface IRepository<T> where T : class, IEntityModel
    {
        DbContext Context { get; }

        Task<T> Get(int primaryKey);

        Task<T> GetFirst(Expression<Func<T, bool>> predicate);

        Task<IList<T>> GetAll(Expression<Func<T, bool>> predicate);

        Task<IList<T>> GetAll();

        Task<T> Save(object entitity);

        Task<IList<T>> SaveAll(IList<T> entities);

        Task<T> Update(T entity);
    }
}
