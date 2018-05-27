using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class PlayerStrike : IEntityModel
    {
        public int PkPlayerStrike { get; set; }
        public int Fkmatch { get; set; }
        public int BattingStrikerId { get; set; }
        public int BattingNonStrikerId { get; set; }
        public int BallerId { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        public Player Baller { get; set; }
        public Player BattingNonStriker { get; set; }
        public Player BattingStriker { get; set; }
        public Match FkmatchNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStrike>(entity =>
            {
                entity.HasKey(e => e.PkPlayerStrike);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.Baller)
                    .WithMany(p => p.PlayerStrikeBaller)
                    .HasForeignKey(d => d.BallerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Balle__531856C7");

                entity.HasOne(d => d.BattingNonStriker)
                    .WithMany(p => p.PlayerStrikeBattingNonStriker)
                    .HasForeignKey(d => d.BattingNonStrikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Batti__5224328E");

                entity.HasOne(d => d.BattingStriker)
                    .WithMany(p => p.PlayerStrikeBattingStriker)
                    .HasForeignKey(d => d.BattingStrikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Batti__51300E55");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.PlayerStrike)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__FKMat__503BEA1C");
            });

        }
    }
}
