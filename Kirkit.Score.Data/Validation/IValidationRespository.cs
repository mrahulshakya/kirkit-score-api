using Kirkit.Score.Common.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace Kirkit.Score.Data.Validation
{
    public interface IValidationRespository<T> where T : class,  IEntityModel
    {
        Task<Dictionary<string, IList<string>>> Validate(object enity);
    }
}
