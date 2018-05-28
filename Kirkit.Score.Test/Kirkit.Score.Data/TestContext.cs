using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Test.Kirkit.Score.Data
{
    public class TestContext : IDisposable
    {
        /// <summary>
        /// Set your default context in the constructor.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="context"></param>
        public TestContext(string key, DbContext context)
        {
            contexts.Add(key, context);
            DefaultKey = key;
        }

        private Dictionary<string, DbContext> contexts = new Dictionary<string, DbContext>();

        public DbContext this[string key]
        {
            get
            {
                return contexts[key];
            }
            set
            {

                if (!contexts.ContainsKey(key))
                {
                    value.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                    contexts.Add(key, value);
                }
            }
        }

        public readonly string DefaultKey;

        public DbContext Default => contexts[DefaultKey];

        public void Dispose()
        {
            foreach (var context in contexts)
            {
                context.Value.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
