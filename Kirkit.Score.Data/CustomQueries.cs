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

        public static Expression FilterByProperty<T>(T obj, string key)
        {
            var entityType = typeof(T);
            var funcType = typeof(Func<,>).MakeGenericType(entityType, typeof(bool));
            var param = Expression.Parameter(entityType, "x");
            var property = Expression.Property(param, key);
            var paramR = Expression.Constant(entityType.GetProperty(key).GetValue(obj, null));

            var exp = Expression.Lambda(funcType, Expression.Equal(property, paramR), param);

            return exp;
        }
    }
}
