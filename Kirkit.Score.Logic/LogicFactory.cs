using Kirkit.Score.Common.Data;
using Kirkit.Score.Data.Validation;
using Kirkit.Score.Model.Logic;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Logic
{
    public class LogicFactory : ILogicFactory
    {
        private Lazy<Dictionary<string, Type>> logicMap =
           new Lazy<Dictionary<string, Type>>(
               () => Mapping(typeof(IScoreLogic<>)));

        private readonly IServiceProvider _provider;

        private static Dictionary<string, Type> Mapping(Type genericType)
        {
                var dic = new Dictionary<string, Type>();
                foreach (var model in GetModels())
                {
                    var instanceType = genericType.MakeGenericType(model.GetType());
                    var key = model.GetType().Name.ToLower();
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(model.GetType().Name.ToLower(), instanceType);
                    }

                }

                return dic;
        }

        public LogicFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public dynamic GetLogic(string resource)
        {
            return _provider.GetService(logicMap.Value[resource.ToLower()]);

            //    return new Repository<BallType>(con)
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public Type GetModelType(string resource)
        {
            if (logicMap.Value.ContainsKey(resource.ToLower()))
            {
                var type = logicMap.Value[resource.ToLower()].GetGenericArguments()[0];
                return type;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<LogicBase> GetModels()
        {
            var model = new List<LogicBase>();
            model.Add(new BallType());
            model.Add(new BattingScore());
            model.Add(new BowlingScore());
            model.Add(new Match());
            model.Add(new Innings());
            model.Add(new MatchRule());
            model.Add(new MaxOverRule());
            model.Add(new Player());
            model.Add(new PlayerTeam());
            model.Add(new Powerplayrule());
            model.Add(new Powerplayslot());
            model.Add(new Rule());
            model.Add(new RunType());
            model.Add(new Team());
            model.Add(new Tournament());
            model.Add(new TournamentMatch());
            model.Add(new TournamentRule());
            model.Add(new WicketType());
            model.Add(new WicketDetail());
            model.Add(new TotalScore());
            model.Add(new PerBallUpdate());
            return model;
        }
        
       }
}