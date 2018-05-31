using Kirkit.Score.Common.Data;
using Kirkit.Score.Model.Entity;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private Lazy<Dictionary<string, Type>> lazyMap =
           new Lazy<Dictionary<string, Type>>(
               () => Mapping);

        private readonly IServiceProvider _provider;

        private static Dictionary<string, Type> Mapping
        {
            get
            {
                var dic = new Dictionary<string, Type>();
                foreach (var model in GetModels().Models)
                {
                    var instanceType = typeof(IRepository<>).MakeGenericType(model.GetType());
                    var key = model.GetType().Name.ToLower();
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(model.GetType().Name.ToLower(), instanceType);
                    }

                }

                return dic;
            }
        }

        public RepositoryFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public dynamic GetRepository(string resource)
        {
            return _provider.GetService(lazyMap.Value[resource.ToLower()]);

            //    return new Repository<BallType>(con)
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public Type GetModelType(string resource)
        {
            if (lazyMap.Value.ContainsKey(resource.ToLower()))
            {
                var type = lazyMap.Value[resource.ToLower()].GetGenericArguments()[0];
                return type;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CompositeModelBuilder GetModels()
        {
            var model = new CompositeModelBuilder();
            model.AddModel(new BallType())
                         .AddModel(new BattingScore())
                         .AddModel(new BowlingScore())
                         .AddModel(new Match())
                         .AddModel(new Innings())
                         .AddModel(new MatchRule())
                         .AddModel(new MaxOverRule())
                         .AddModel(new Player())
                         .AddModel(new PlayerTeam())
                         .AddModel(new Powerplayrule())
                         .AddModel(new Powerplayslot())
                         .AddModel(new Rule())
                         .AddModel(new RunType())
                         .AddModel(new Team())
                         .AddModel(new Tournament())
                         .AddModel(new TournamentMatch())
                         .AddModel(new TournamentRule())
                         .AddModel(new WicketType())
                         .AddModel(new WicketDetail())
                         .AddModel(new TotalScore());
            return model;
        }

    }
}
