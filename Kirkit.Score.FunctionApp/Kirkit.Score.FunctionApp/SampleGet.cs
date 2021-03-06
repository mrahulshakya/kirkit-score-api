using Kirkit.Score.Api.DI;
using Kirkit.Score.Data;
using Kirkit.Score.Data.Enitity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kirkit.Score.Api
{
    public static class SampleGet
    {

        [FunctionName("GetBallTypes")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "references/BallType")]HttpRequest req,
            ILogger log, [Inject] IScoreRepository repository)
        {
            try
            {
                log.LogInformation($"C# HTTP trigger function processed a request.");

                IList<BallType> customers = null;

                customers = await repository.GetAllBallTypes()
                                .ConfigureAwait(false);

                if (!customers.Any())
                {
                    return (ActionResult)new NotFoundObjectResult(new { ErrorMessage = "CustomerNotFound" });
                }

                return (ActionResult)new OkObjectResult(new { BallTypes = customers });

            }
            catch (Exception ex)
            {
                log.LogCritical(ex.Message, ex);
                throw;
            }


        }
    }
}
