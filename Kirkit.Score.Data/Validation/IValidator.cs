using Kirkit.Score.Common.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kirkit.Score.Data.Validation
{
    public interface IValidator<T> where T : class, IEntityModel
    {
        Task<Dictionary<string, IList<string>>> Validate(T entity);
    }
}