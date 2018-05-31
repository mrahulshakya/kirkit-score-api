using Kirkit.Score.Api.DI;
using Kirkit.Score.Data;
using Kirkit.Score.Model.Payload;
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
    public static class GetAllFunc
    {
        [FunctionName("GetAll")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "collection/{resource}")]HttpRequest req,
            string resource,
            TraceWriter log, [Inject]IRepositoryFactory factory)
        {
            try
            {
                log.Info($"C# HTTP trigger function processed a request.");

                var result = new List<object>();
                var repo = factory.GetRepository(resource);

                result = Enumerable.ToList<object>(await repo.GetAll()
                                  .ConfigureAwait(false));
           
                var listResult = (List<object>)result;
                if (!listResult?.Any() ?? false)
                {
                    return (ActionResult)new NotFoundObjectResult(new { ErrorMessage = "CustomerNotFound" });
                }

                return (ActionResult)new OkObjectResult(new { Response = listResult });

            }
            catch(ScoreException ex)
            {
                log.Error(ex.Message, ex);
                return (ActionResult)new NotFoundObjectResult(new { Response = ex.Message });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
