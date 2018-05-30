using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirkit.Score.Logic
{
    public class ScoreLogic : IScoreLogic
    {
        public Task Delete(string resorce, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<object>> Get(string resource, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<object>> GetAll(string resource)
        {
            throw new NotImplementedException();
        }

        public Task<object> Save(string resource, string json)
        {
            throw new NotImplementedException();
        }

        public Task<object> Update(string resource, int id, string newJson)
        {
            throw new NotImplementedException();
        }
    }
}