using Kirkit.Score.Common.Data;
using System;

namespace Kirkit.Score.Data
{
    public interface IRepositoryFactory
    {
        dynamic GetRepository(string resource);

        Type GetModelType(string resource);

        dynamic GetCustomQuery(string resource);
    }
}
