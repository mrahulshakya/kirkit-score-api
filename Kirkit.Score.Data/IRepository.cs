﻿using Kirkit.Score.Common.Data;
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

        Task<IList<T>> Get(Expression predicate);

        Task<IList<T>> GetAll();

        void Add(object entitty);

        Task<bool> Save();

        void Update(object entity);

        void AddRange(object entitty);
    }
}
