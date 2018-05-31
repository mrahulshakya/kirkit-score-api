using Kirkit.Score.Common.Data;
using Kirkit.Score.Model.Entity;
using Kirkit.Score.Model.Payload;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kirkit.Score.Data
{
    public class CustomQuery
    {
        public CustomQuery(object val)
        {
            ID = val;
        }

        public  static object ID { get; private set; }

        public static Expression<Func<Innings, bool>>  GetQuery(string key)
        {
            if(string.Equals(key, nameof(Innings.MatchId), StringComparison.OrdinalIgnoreCase))
            {
                return x => x.MatchId ==  (int)ID;
            }

            throw new ScoreException(System.Net.HttpStatusCode.BadRequest , "Invalid key passed in request");
        }
    }

    public interface ICustomQuery<T> where T : class, IEntityModel
    {
        Expression<Func<T, bool>> GetQuery(string key);
    }
}
