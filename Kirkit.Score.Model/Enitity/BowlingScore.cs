using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class BowlingScore : IEntityModel
    {
        public int BowlingScoreId { get; set; }
        public int InningsId { get; set; }
        public int BallerId { get; set; }
        public int Overs { get; set; }
        public int Balls { get; set; }
        public int TotalBalls { get; set; }
        public int RunsGiven { get; set; }
        public int Wickets { get; set; }
        public int Wides { get; set; }
        public int NoBall { get; set; }
        public double StrikeRate { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        public Player Baller { get; set; }
        public Innings Innings { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BowlingScore>(entity =>
            {
                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Baller)
                    .WithMany(p => p.BowlingScore)
                    .HasForeignKey(d => d.BallerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BowlingSc__Balle__07C12930");

                entity.HasOne(d => d.Innings)
                    .WithMany(p => p.BowlingScore)
                    .HasForeignKey(d => d.InningsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BowlingSc__Innin__06CD04F7");
            });
        }
    }
}
