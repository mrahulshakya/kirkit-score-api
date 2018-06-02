using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class TotalScore : BaseEntity, IEntityModel
    {
        public TotalScore()
        {
            Innings = new HashSet<Innings>();
        }

        public int TotalScoreId { get; set; }
        public int TotalRuns { get; set; }
        public int TotalOvers { get; set; }
        public int TotalBalls { get; set; }
        public int TotalWikets { get; set; }
        public int ExtraRuns { get; set; }

        public ICollection<Innings> Innings { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TotalScore>(entity =>
            {
                entity.HasKey(x => x.TotalScoreId);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });
        }
    }
}
