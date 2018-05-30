using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kirkit.Score.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntityModel
    {
        public DbContext Context { get; }

        public Repository(ScoreContext context)
        {
            Context = context;
        }

        public async Task<T> Get(int primaryKey)
        {
            return await Context
                             .FindAsync<T>(primaryKey)
                             .ConfigureAwait(false);
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        {
            var dbSet = Context.Set<T>();
            return await dbSet.AsNoTracking().Where(predicate)
                        .FirstOrDefaultAsync()
                        .ConfigureAwait(false);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> predicate)
        {
            var dbSet = Context.Set<T>();
            return await dbSet.AsNoTracking().Where(predicate)
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        public async Task<IList<T>> GetAll()
        {
            var dbSet = Context.Set<T>();
            return await dbSet
                        .AsNoTracking()
                        .ToListAsync()
                        .ConfigureAwait(false);
        }

        public async Task<T> Save(object entity)
        {
            var dbSet = Context.Set<T>();
            dbSet.Add(entity as T);
            var changed = await Context.SaveChangesAsync();

            return changed > 0 ? entity as T : null;
        }

        public async Task<IList<T>> SaveAll(IList<T> entities)
        {
            var dbSet = Context.Set<T>();
            dbSet.AddRange(entities);
            var changed = await Context.SaveChangesAsync();

            return changed == entities.Count ? entities : null;
        }

        public async Task<T> Update(T entity)
        {
            var dbSet = Context.Set<T>();
            dbSet.Update(entity);
            var changed = await Context.SaveChangesAsync();

            return changed > 0 ? entity : null;
        }
    }
}