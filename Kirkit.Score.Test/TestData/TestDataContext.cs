using Kirkit.Score.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kirkit.Score.Test.TestData
{
    public class TestDataContextFixture  : IDisposable
    {
        public ScoreContext  Context { get; }

        public TestDataContextFixture()
        {
            var builder = new DbContextOptionsBuilder<ScoreContext>();
            builder.UseInMemoryDatabase("Scoring");
            Context = new ScoreContext(builder.Options);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
