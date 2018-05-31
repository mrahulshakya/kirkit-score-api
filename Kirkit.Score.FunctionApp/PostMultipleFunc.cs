using Kirkit.Score.Api.DI;
using Kirkit.Score.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kirkit.Score.Api
{
    public static class PostMultipleFunc
    {
        [FunctionName("PostMultiple")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "collection/{resource}")]HttpRequest req,
            string resource,
            TraceWriter log, [Inject]IRepositoryFactory factory)
        {
            try
            {
                log.Info($"C# HTTP trigger function processed a request.");

                var json = await req.ReadAsStringAsync();
                var resourceType = factory.GetModelType(resource);

                if (resourceType == null)
                {
                    return (ActionResult)new NotFoundObjectResult(new { ErrorMessage = "Invalid resource key." });
                }

                if (json == null)
                {
                    return (ActionResult)new BadRequestResult();
                }

                var objects = JsonConvert.DeserializeObject(json, typeof(List<>).MakeGenericType(resourceType));

                var repo = factory.GetRepository(resource);
                repo.AddRange(objects);

                var result = await repo.Save()
                              .ConfigureAwait(false);

                if (!result)
                {
                    return (ActionResult)new NotFoundObjectResult(new { ErrorMessage = "CustomerNotFound" });
                }

                return (ActionResult)new CreatedResult(resource, new { Response = objects });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
