using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirkit.Score.Logic
{
    public interface IScoreLogic
    {
        Task<object> Save(string resource, string json);

        Task<IList<object>> Get(string resource,int id);

        Task<IList<object>> GetAll(string resource);

        Task<object> Update(string resource, int id, string newJson);

        Task Delete(string resorce, int id);
    }
}
