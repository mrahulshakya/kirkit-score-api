using Kirkit.Score.Api.DI;
using Kirkit.Score.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kirkit.Score.Api
{
    public static class GetFunction
    {
        [FunctionName("Get")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "references/{resource}")]HttpRequest req,
            string resource,
            TraceWriter log, [Inject]IRepositoryFactory factory)
        {
            try
            {
                log.Info($"C# HTTP trigger function processed a request.");


                var repo = factory.GetRepository(resource);

                var result = Enumerable.ToList<object>(await repo.GetAll()
                              .ConfigureAwait(false));

                var listResult = (List<object>)result;
                if (!listResult?.Any() ?? false)
                {
                    return (ActionResult)new NotFoundObjectResult(new { ErrorMessage = "CustomerNotFound" });
                }

                return (ActionResult)new OkObjectResult(new { Response = listResult });

            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
