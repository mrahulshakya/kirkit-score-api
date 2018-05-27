using Kirkit.Score.Api.DI;
using Kirkit.Score.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Kirkit.Score.Api
{
    public class ServiceProviderBuilder : IServiceProviderBuilder
    {
        private static readonly IConfiguration configuration;

        static ServiceProviderBuilder()
        {
            configuration = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddEnvironmentVariables()
                          .AddJsonFile("local.settings.json", optional: true)
                          .Build();
        }

        public IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddDbContextPool<ScoreContext>((options) =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:Scorer"]);
            });

            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IScoreRepository, ScoreRepository>();

            // services.AddTransient<IGreeter, Lib.Greeter>();

            return services.BuildServiceProvider(true);
        }

        public static DbContextOptions<ScoreContext> GetOptions()
        {
            var options = new DbContextOptionsBuilder<ScoreContext>();

            return options.Options;

        }

    }

}
