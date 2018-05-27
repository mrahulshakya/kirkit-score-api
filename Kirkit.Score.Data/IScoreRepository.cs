using Kirkit.Score.Data.Enitity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirkit.Score.Data
{
    public interface IScoreRepository
    {
        //Task<IList<Customer>> GetCustomers(int id);

        Task<IList<BallType>> GetAllBallTypes();
    }
}