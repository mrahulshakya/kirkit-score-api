using System;
using System.Collections.Generic;
using Kirkit.Score.Common.Data;
using Kirkit.Score.Data.Validation;

namespace Kirkit.Score.Data
{
    public interface IRepositoryFactory
    {
        dynamic GetRepository(string resource);

        Type GetModelType(string resource);

        IList<IValidator<T>> GetValidators<T>() where T : class, IEntityModel;

        dynamic GetValidatorRepository(string resources);
    }
}
