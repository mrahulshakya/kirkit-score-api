using AutoMapper;
using Kirkit.Score.Common.Exception;
using Kirkit.Score.Data;
using Kirkit.Score.Model.Logic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Kirkit.Score.Logic
{
    public class ScoreLogic<T> : ScoreLogicBase, IScoreLogic<T> where T : LogicBase
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IMapper _mapper;

        private dynamic ScoreRepository(string resource) => _repositoryFactory.GetRepository(resource);
        private dynamic ValidationRepository(string resource) => _repositoryFactory.GetValidatorRepository(resource);
        private Type ResourceType(string resource) => _repositoryFactory.GetModelType(resource);
        
        public ScoreLogic(IRepositoryFactory repositoryFactory, 
            ILoggerFactory logger, IMapper mapper) : base(logger) 
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<T> Save(string resource, string json)
        {
            T res = null;
            try
            {
                Type resourceType = GetResourceType(resource);
                var obj = GetObjectFromJson(json, typeof(T));
                ValidateModelState(obj);

                var entityObj = _mapper.Map(obj, typeof(T), resourceType);

                await ValidateDb(resource, entityObj);

                var repo = ScoreRepository(resource);

                repo.Add(entityObj);
                var isSaved = await repo.Save()
                              .ConfigureAwait(false);

                if (!isSaved)
                {
                    throw new ScoreException(HttpStatusCode.BadRequest, new { Response = "Failed to  create entity" });
                }

                res = _mapper.Map<T>(entityObj);
            }
            catch (ScoreDbValidationException ex)
            {
                _logger.LogError("Failed to validate the entity", ex.Errors);
                throw new ScoreException(HttpStatusCode.BadRequest, new { Errors = ex.Errors });
            }
            catch (ScoreException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Unhandled error");
                throw new ScoreException(System.Net.HttpStatusCode.InternalServerError, "Some issue occured.");
            }
         
            return res;
        }

        public async Task<T> SaveAll(string resource, string json)
        {
            T res = null;
            try
            {
                Type resourceType = GetResourceType(resource);
                var obj = GetObjectFromJson(json, typeof(IList<T>));
                ValidateModelState(obj);

                var entityObj = _mapper.Map(obj, typeof(T), resourceType);

                await ValidateDb(resource, entityObj);

                var repo = ScoreRepository(resource);

                repo.Add(entityObj);
                var isSaved = await repo.Save()
                              .ConfigureAwait(false);

                if (!isSaved)
                {
                    throw new ScoreException(HttpStatusCode.BadRequest, new { Response = "Failed to  create entity" });
                }

                res = _mapper.Map<T>(entityObj);
            }
            catch (ScoreDbValidationException ex)
            {
                _logger.LogError("Failed to validate the entity", ex.Errors);
                throw new ScoreException(HttpStatusCode.BadRequest, new { Errors = ex.Errors });
            }
            catch (ScoreException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Unhandled error");
                throw new ScoreException(System.Net.HttpStatusCode.InternalServerError, "Some issue occured.");
            }

            return res;
        }

        private async Task ValidateDb(string resource, object obj)
        {
            var validationRepo = ValidationRepository(resource);
            dynamic errors = await validationRepo.Validate(obj).ConfigureAwait(false);

            if (errors != null && ((Dictionary<string, IList<string>>)errors).Count > 0)
            {
                throw new ScoreException(HttpStatusCode.BadRequest, new { Resonse = errors });
            }
        }

        private void ValidateModelState(object obj)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(obj, null, null);
            var validationResult = new List<ValidationResult>();

            if (!Validator.TryValidateObject(obj, context, validationResult, true))
            {
                throw new ScoreException(HttpStatusCode.BadRequest, new { Response = validationResult });
            }
        }

        private object GetObjectFromJson(string json, Type resourceType)
        {
            if (json == null)
            {
                throw new ScoreException(HttpStatusCode.BadRequest, new { Response = "Invalid request json" });
            }

            var obj = JsonConvert.DeserializeObject(json, resourceType);

            if (obj == null)
            {
                throw new ScoreException(HttpStatusCode.BadRequest, new { Response = "Invalid request json" });
            }

            return obj;
        }

        private Type GetResourceType(string resource)
        {
            var resourceType = ResourceType(resource);

            if (resourceType == null)
            {
                throw new ScoreException(HttpStatusCode.NotFound, new { Response = "Invalid resource key in request." });
            }

            return resourceType;
        }

        public Task<IList<T>> Get(string resource, int id)
        {
            HandleErrors(() =>
            {

            });

            return null;
        }

        public Task<IList<T>> GetAll(string resource)
        {
            HandleErrors(() =>
            {

            });

            return null;
        }

        public Task<T> Update(string resource, int id, string newJson)
        {
            HandleErrors(() =>
            {

            });

            return null;
        }

        public Task<T> Delete(string resorce, int id)
        {
            HandleErrors(() =>
            {

            });

            return null;
        }
    }
}