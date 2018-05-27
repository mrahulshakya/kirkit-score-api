using Kirkit.Score.Data.Enitity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirkit.Score.Data
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly ScoreContext context;

        public ScoreRepository(ScoreContext context)
        {
            this.context = context;
        }

        public async Task<IList<BallType>> GetAllBallTypes()
        {
            return await context.BallType.ToListAsync();
        }

        //public async Task<IList<Customer>> GetCustomers(int id)
        //{
        //    return await context.Customers.Where(x => x.CustomerId == id).ToListAsync()
        //                .ConfigureAwait(false);
        //}
    }
}
