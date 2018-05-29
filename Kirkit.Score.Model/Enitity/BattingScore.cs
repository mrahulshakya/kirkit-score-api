using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class BattingScore : IEntityModel
    {
        public int BattingScoreId { get; set; }
        public int InningsId { get; set; }
        public int BatsmenId { get; set; }
        public int RunsScored { get; set; }
        public int BallFaced { get; set; }
        public int Sixes { get; set; }
        public int Fours { get; set; }
        public int Dots { get; set; }
        public double StrikeRate { get; set; }
        public bool NotOut { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        public Player Batsmen { get; set; }
        public Innings Innings { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BattingScore>(entity =>
            {
                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Batsmen)
                    .WithMany(p => p.BattingScore)
                    .HasForeignKey(d => d.BatsmenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__Batsm__03F0984C");

                entity.HasOne(d => d.Innings)
                    .WithMany(p => p.BattingScore)
                    .HasForeignKey(d => d.InningsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__Innin__02FC7413");
            });

        }
    }
}
