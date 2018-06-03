using AutoMapper;

namespace Kirkit.Score.Model.Mapper
{
    public class ScoreProfile : Profile
    {
        public ScoreProfile()
        {
            CreateMap<Logic.Player, Entity.Player>()
                .ReverseMap();

            CreateMap<Logic.Team, Entity.Team>()
                .ReverseMap();

            CreateMap<Logic.PlayerTeam, Entity.PlayerTeam>()
               .ReverseMap();

            CreateMap<Logic.Match, Entity.Match>()
               .ReverseMap();

            CreateMap<Logic.Innings, Entity.Innings>()
               .ReverseMap();

            CreateMap<Logic.PerBallUpdate, Entity.PerBallUpdate>()
               .ReverseMap();

            CreateMap<Logic.TotalScore, Entity.TotalScore>()
    .ReverseMap();
        }
    }
}
