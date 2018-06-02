using Kirkit.Score.Api.DI;
using Kirkit.Score.Common.Exception;
using Kirkit.Score.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kirkit.Score.Api
{
    public static class PostFunc
    {
        [FunctionName("Post")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "{resource}")]HttpRequest req,
            string resource,
            ILogger log, [Inject]ILogicFactory factory)
        {
            ObjectResult returnResult = new ObjectResult(null);

            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request.");

                var json = await req.ReadAsStringAsync();

                var repo = factory.GetLogic(resource);

                var result = await repo.Save(resource, json)
                              .ConfigureAwait(false);

                return (ActionResult)new CreatedResult(resource, result);
            }
            catch(ScoreException ex)
            {
                var objResult = new ObjectResult(ex.Response);
                objResult.StatusCode = (int)ex.StatusCode;
                returnResult = objResult;
            }
            catch (Exception ex)
            {
                log.LogCritical(ex.Message, ex);
                throw;
            }

            return returnResult;
        }
    }
}