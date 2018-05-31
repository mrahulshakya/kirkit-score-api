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

        public async Task<bool> Save()
        {
            var changed = await Context.SaveChangesAsync();

            return changed > 0;
        }

        public void Update(object entity)
        {
            var dbSet = Context.Set<T>();
            dbSet.Update(entity as T);
        }

        public void Add(object entitty)
        {
            var dbSet = Context.Set<T>();
            dbSet.Add(entitty as T);
        }

        public void AddRange(object objects)
        {
            var dbSet = Context.Set<T>();
            dbSet.AddRange(objects as List<T>);
        }
    }
}