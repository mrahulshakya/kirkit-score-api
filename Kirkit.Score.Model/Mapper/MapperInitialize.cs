﻿using AutoMapper;

namespace Kirkit.Score.Model.Mapper
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
                cfg.AddProfile(new ScoreProfile());
            });


            this.Mapper = config.CreateMapper();
        }

    }
}