using AutoMapper;

namespace Kirkit.Score.Model.Mapper
{
    public class ScoreProfile : Profile
    {
        public ScoreProfile()
        {
            CreateMap<Logic.Player, Entity.Player>()
                .ReverseMap();
        }
    }
}
