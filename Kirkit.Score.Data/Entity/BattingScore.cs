using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class BattingScore : IEntityModel
    {
        public int PkBattingScore { get; set; }
        public int PkPlayerId { get; set; }
        public int RunsScored { get; set; }
        public int BallFaced { get; set; }
        public int Sixes { get; set; }
        public int Fours { get; set; }
        public int Dots { get; set; }
        public double StrikeRate { get; set; }
        public bool NotOut { get; set; }
        public int FkWicketTakenBy { get; set; }
        public int FkcatchTakenBy { get; set; }
        public int FkstumpedBy { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        public Player FkWicketTakenByNavigation { get; set; }
        public Player FkcatchTakenByNavigation { get; set; }
        public Player FkstumpedByNavigation { get; set; }
        public Player PkPlayer { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BattingScore>(entity =>
            {
                entity.HasKey(e => e.PkBattingScore);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.FkcatchTakenBy).HasColumnName("FKCatchTakenBy");

                entity.Property(e => e.FkstumpedBy).HasColumnName("FKStumpedBy");

                entity.HasOne(d => d.FkWicketTakenByNavigation)
                    .WithMany(p => p.BattingScoreFkWicketTakenByNavigation)
                    .HasForeignKey(d => d.FkWicketTakenBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FkWic__5E8A0973");

                entity.HasOne(d => d.FkcatchTakenByNavigation)
                    .WithMany(p => p.BattingScoreFkcatchTakenByNavigation)
                    .HasForeignKey(d => d.FkcatchTakenBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FKCat__5F7E2DAC");

                entity.HasOne(d => d.FkstumpedByNavigation)
                    .WithMany(p => p.BattingScoreFkstumpedByNavigation)
                    .HasForeignKey(d => d.FkstumpedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FKStu__607251E5");

                entity.HasOne(d => d.PkPlayer)
                    .WithMany(p => p.BattingScorePkPlayer)
                    .HasForeignKey(d => d.PkPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__PkPla__5D95E53A");
            });

        }
    }
}
