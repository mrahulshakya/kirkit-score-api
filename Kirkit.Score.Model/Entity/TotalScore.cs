using Kirkit.Score.Common.Attribute;
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
        }

        public int TotalScoreId { get; set; }

        [AllowedCount(1)]
        public int InningsId { get; set; }
        public int TotalRuns { get; set; }
        public int TotalOvers { get; set; }
        public int TotalBalls { get; set; }
        public int TotalWikets { get; set; }
        public int ExtraRuns { get; set; }

        public Innings Innings { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TotalScore>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);
                entity.HasKey(x => x.TotalScoreId);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Innings)
                .WithMany(p => p.TotalScore)
                .HasForeignKey(d => d.InningsId);
            });
        }
    }
}
