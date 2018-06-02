using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirkit.Score.Logic
{
    public interface IScoreLogic<T>
    {
        Task<T> Save(string resource, string json);

        Task<IList<T>> Get(string resource,int id);

        Task<IList<T>> GetAll(string resource);

        Task<T> Update(string resource, int id, string newJson);

        Task<T> Delete(string resorce, int id);
    }
}
