using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Test.Kirkit.Score.Data
{
    public abstract class RepositoryTestBase : TestBase, IDisposable
    {
        private Dictionary<string, List<object>> CreatedEntities { get; }

        protected TestContext Contexts { get; private set; }

        protected DbContext DefaultContext => Contexts[DefaultKey];

        protected string ContextKey { get; set; }

        protected string DefaultKey { get; set; }

        protected RepositoryTestBase()
        {
            CreatedEntities = new Dictionary<string, List<object>>();
            Contexts = SetAllContexts();
            DefaultKey = Contexts.DefaultKey;
        }

        protected abstract TestContext SetAllContexts();

        /// <summary>
        /// Gets the created entity based on  the index.
        /// </summary>
        /// <typeparam name="T">The key.</typeparam>
        /// <param name="index">The index defaulted to  zero.</param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected T GetCreated<T>(int index = 0, string key = null)
        {
            key = key ?? DefaultKey;

            if (CreatedEntities.ContainsKey(key + typeof(T).Name))
            {
                var obj = CreatedEntities[key + typeof(T).Name];
                return (T)obj.ToArray()[index];
            }

            throw new Exception("Requested key is not found.");
        }

        /// <summary>
        /// Gets the created entity based on  the index.
        /// </summary>
        /// <typeparam name="T">The key.</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        protected IList<T> GetAllCreated<T>(string key = null)
        {
            key = key ?? DefaultKey;
            if (CreatedEntities.ContainsKey(key + typeof(T).Name))
            {
                var obj = CreatedEntities[key + typeof(T).Name];
                return (IList<T>)obj;
            }

            throw new Exception("Requested key is not found.");
        }


        protected T Create<T>(Action<T> predicate = null, string key = null) where T : class, new()
        {
            key = key ?? DefaultKey;

            var contexts = SetAllContexts();
            using (contexts)
            {
                var currentContext = contexts[key];
                var obj = new T();

                predicate?.Invoke(obj);
                currentContext.Add<T>(obj);
                currentContext.SaveChanges();

                if (CreatedEntities.ContainsKey(key + typeof(T).Name))
                {
                    var value = CreatedEntities[key + typeof(T).Name];
                    value.Add(obj);
                }
                else
                {
                    CreatedEntities.Add(key + typeof(T).Name, new List<object> { obj });
                }

                return obj;
            }
        }


        protected int GetRandom() => Math.Abs(Guid.NewGuid().GetHashCode());

        public void Dispose()
        {
            Contexts.Dispose();
            GC.SuppressFinalize(this);
        }

        public void ResetContext()
        {
            Contexts.Dispose();
            Contexts = SetAllContexts();
        }
    }
}
