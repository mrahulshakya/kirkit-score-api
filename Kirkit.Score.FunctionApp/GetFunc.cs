using Kirkit.Score.Api.DI;
using Kirkit.Score.Common.Data;
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
    public static class GetFunc
    {
        [FunctionName("Get")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "{resource}/{id}")]HttpRequest req,
            string resource,int id,
            TraceWriter log, [Inject]IRepositoryFactory factory)
        {
            try
            {
                log.Info($"C# HTTP trigger function processed a request.");
                var querystring = req.GetQueryParameterDictionary();
                var repo = factory.GetRepository(resource);
                var results = new List<object>();

                if (querystring.ContainsKey("key"))
                {
                    var key = querystring["key"];
                    var query = new CustomQuery(id);
                    results = Enumerable.ToList<object>(await repo.Get(query.GetQuery(key)).ConfigureAwait(false));
                    if (results == null)
                    {
                        return (ActionResult)new NotFoundObjectResult(new { ErrorMessage = "CustomerNotFound" });
                    }

                    return (ActionResult)new OkObjectResult(new { Response = results });
                }

                var result = await repo.Get(id).ConfigureAwait(false);

                if (result == null)
                {
                    return (ActionResult)new NotFoundObjectResult(new { ErrorMessage = "CustomerNotFound" });
                }

                return (ActionResult)new OkObjectResult(new { Response = result });

            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
