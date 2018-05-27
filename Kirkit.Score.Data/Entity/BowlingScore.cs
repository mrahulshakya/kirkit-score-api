using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class BowlingScore : IEntityModel
    {
        public int PkBowlingScore { get; set; }
        public int PkPlayerId { get; set; }
        public int Overs { get; set; }
        public int Balls { get; set; }
        public int TotalBalls { get; set; }
        public int RunsGiven { get; set; }
        public int Wickets { get; set; }
        public double StrikeRate { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        public Player PkPlayer { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BowlingScore>(entity =>
            {
                entity.HasKey(e => e.PkBowlingScore);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.PkPlayer)
                    .WithMany(p => p.BowlingScore)
                    .HasForeignKey(d => d.PkPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BowlingSc__PkPla__634EBE90");
            });

        }
    }
}
