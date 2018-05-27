using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class BallUpdate : IEntityModel
    {
        public int PkBallUpdate { get; set; }
        public int FkScoreBoard { get; set; }
        public int FkBattingTeam { get; set; }
        public int FkBowlingTeam { get; set; }
        public int RunScored { get; set; }
        public int RunType { get; set; }
        public int BallType { get; set; }
        public bool WiketFallen { get; set; }
        public bool WicketType { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        //public Team FkBattingTeamNavigation { get; set; }
        //public Team FkBowlingTeamNavigation { get; set; }
        public ScoreBoard FkScoreBoardNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BallUpdate>(entity =>
            {
                entity.HasKey(e => e.PkBallUpdate);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                //entity.HasOne(d => d.FkBattingTeamNavigation)
                //    .WithMany(p => p.BallUpdateFkBattingTeamNavigation)
                //    .HasForeignKey(d => d.FkBattingTeam)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__BallUpdat__FkBat__59C55456");

                //entity.HasOne(d => d.FkBowlingTeamNavigation)
                //    .WithMany(p => p.BallUpdateFkBowlingTeamNavigation)
                //    .HasForeignKey(d => d.FkBowlingTeam)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__BallUpdat__FkBow__5AB9788F");

                entity.HasOne(d => d.FkScoreBoardNavigation)
                    .WithMany(p => p.BallUpdate)
                    .HasForeignKey(d => d.FkScoreBoard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BallUpdat__FkSco__58D1301D");
            });

        }
    }
}
