using Kirkit.Score.Common.Exception;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Kirkit.Score.Logic
{
    public abstract class ScoreLogicBase 
    {
        protected readonly ILogger _logger;

        public ScoreLogicBase(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger(nameof(ScoreLogicBase));
        }

       protected async Task HandleErrors(Action method)
       {
            try
            {
                method();
            }
            catch(ScoreDbValidationException ex)
            {
                _logger.LogError("Failed to validate the entity", ex.Errors);
                throw new ScoreException(HttpStatusCode.BadRequest, new { Errors =  ex.Errors });
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
       }
    }
}