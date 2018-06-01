using Kirkit.Score.Common.Data;
using System;
using System.Linq.Expressions;

namespace Kirkit.Score.Data
{
    public class CustomQuery
    {
        public CustomQuery(int val)
        {
            ID = val;
        }

        public static int ID { get; private set; }

        public static Expression GetQuery(Type resourceType, string key)
        {
            var funcType = typeof(Func<,>).MakeGenericType(resourceType, typeof(bool));
            var param = Expression.Parameter(resourceType, "inning");
            var prop = Expression.Property(param, key);
            var parmaR = Expression.Variable(typeof(int), "ID");
            var exp = Expression.Lambda(funcType, Expression.Equal(prop, parmaR));

            return exp;
        }
    }

    public interface ICustomQuery<T> where T : class, IEntityModel
    {
        Expression<Func<T, bool>> GetQuery(string key);
    }
}
