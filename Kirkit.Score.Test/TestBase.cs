using Microsoft.Extensions.Configuration;
using System.IO;

namespace Kirkit.Score.Test
{
    public class TestBase
    {
        public readonly IConfiguration configuration;
        public TestBase()
        {
            var directoryInfo =
               Directory.GetParent(Directory.GetCurrentDirectory())
                   .Parent.Parent.Parent.Parent;

            configuration = new ConfigurationBuilder()
            .SetBasePath(directoryInfo.FullName + "/Kirkit.Score.FunctionApp")
            .AddJsonFile("appsettings.json")
            .Build();
        }
    }
}
