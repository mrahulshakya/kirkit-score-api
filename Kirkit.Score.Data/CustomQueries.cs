using Kirkit.Score.Common.Data;
using System;
using System.Linq;
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
            var property = resourceType.GetProperties().FirstOrDefault(x => string.Equals(x.Name, key, StringComparison.OrdinalIgnoreCase));
            
            var prop = Expression.Property(param, property.Name);
            var parmaR = Expression.Constant(ID);
            var exp = Expression.Lambda(funcType, Expression.Equal(prop, parmaR), param);

            return exp;
        }
    }

    public interface ICustomQuery<T> where T : class, IEntityModel
    {
        Expression<Func<T, bool>> GetQuery(string key);
    }
}
