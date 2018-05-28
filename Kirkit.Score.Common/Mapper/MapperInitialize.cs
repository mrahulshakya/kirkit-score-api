using AutoMapper;

namespace Kirkit.Score.Common.Mapper
{
    public class MapperInitialize
    {
        /// <summary>
        /// Get the mapper object.
        /// </summary>
        public IMapper Mapper { get; }

        /// <summary>
        /// Get the mapper object.
        /// </summary>
        public MapperInitialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new SearchDtoDomainMapper());
                //cfg.AddProfile(new SearchEntityDomainMapper());
            });


            this.Mapper = config.CreateMapper();
        }

    }
}
