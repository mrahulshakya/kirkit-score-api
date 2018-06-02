using Kirkit.Score.Api.DI;
using Kirkit.Score.Data;
using Kirkit.Score.Data.Validation;
using Kirkit.Score.Logic;
using Kirkit.Score.Model.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            services.AddSingleton(new MapperInitialize().Mapper);
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<ILogicFactory, LogicFactory>();
            services.AddScoped(typeof(IScoreLogic<>), typeof(ScoreLogic<>));
            services.AddScoped<IScoreRepository, ScoreRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IValidationRespository<>), typeof(ValidationRepository<>));
            services.AddScoped(typeof(IValidator<>), typeof(UniqueValidator<>));
            return services.BuildServiceProvider(true);
        }

        public static DbContextOptions<ScoreContext> GetOptions()
        {
            var options = new DbContextOptionsBuilder<ScoreContext>();

            return options.Options;

        }

    }

}
