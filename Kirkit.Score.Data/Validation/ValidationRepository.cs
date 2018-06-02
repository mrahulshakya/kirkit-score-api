using Kirkit.Score.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kirkit.Score.Data.Validation
{
    public class ValidationRepository<T> : IValidationRespository<T> where T : class,IEntityModel
    {
        private readonly IList<IValidator<T>> _validators;

        public ValidationRepository(IRepositoryFactory factory)
        {
            _validators = factory.GetValidators<T>();
        }
        
        public async Task<Dictionary<string, IList<string>>> Validate(object enity)
        {
            var errorMessages = new Dictionary<string, IList<string>>();

            foreach (var validator in _validators)
            {
                var errors = await validator.Validate(enity as T);
                if (errors?.Any() ?? false)
                {
                    foreach(var error in errors)
                    {
                        if (!errorMessages.ContainsKey(error.Key))
                        {
                            errorMessages.Add(error.Key, error.Value);
                        }
                    }
                }
            }

            return errorMessages;
        }
    }
}