using Kirkit.Score.Common.Attribute;
using Kirkit.Score.Common.Data;
using Kirkit.Score.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kirkit.Score.Data.Validation
{
    public class BelongsToValidator<T> : IValidator<T> where T : class, IEntityModel
    {
        private ScoreContext _context;
        private static Dictionary<string, int> _countMap = new Dictionary<string, int>();
        public BelongsToValidator(ScoreContext context)
        {
            _context = context;
        }

        private static Lazy<IList<string>> PropertiesToValidate = new Lazy<IList<string>>(() =>
        {
            var properties = typeof(T).GetProperties();
            IList<string> names = new List<string>();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(true);
                foreach (var attribute in attributes)
                {
                    if (attribute is BelongsToAttribute)
                    {
                        var key = $"{(typeof(T).Name.ToLower())}:{property.Name.ToLower()}";
                        if (_countMap.ContainsKey(key))
                        {
                            _countMap[key] = ((AllowedCountAttribute)attribute).MaxCount;
                        }
                        else
                        {
                            _countMap.Add(key, ((AllowedCountAttribute)attribute).MaxCount);
                        }
                        names.Add(property.Name);
                    }
                }
            }
            return names;
        });

        public async Task<Dictionary<string, IList<string>>> Validate(T entity)
        {
            var errors = new Dictionary<string, IList<string>>();
            var dbset = _context.Set<T>();

            foreach (var propertyName in PropertiesToValidate.Value)
            {
                var key = $"{(typeof(T).Name.ToLower())}:{propertyName.ToLower()}";

                if (_countMap.ContainsKey(key))
                {
                    var count = _countMap[key];


                    var query = CustomQuery.FilterByProperty(entity, propertyName);
                    var result = await dbset.CountAsync(query as Expression<Func<T, bool>>).ConfigureAwait(false);
                    var errorMessages = new List<string>();

                    if (result == count)
                    {
                        errorMessages.Add($"Cannot add  repeated {propertyName}");
                    }

                    if (result > count)
                    {
                        errorMessages.Add($"Errors as more than one entries are present for ::{propertyName}");
                    }

                    if (errorMessages.Any())
                    {
                        errors.Add(propertyName, errorMessages);
                    }
                }                
            }

            return errors.Any() ? errors : null;
        }
    }
}