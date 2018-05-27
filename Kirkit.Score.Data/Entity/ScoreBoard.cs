using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data.Enitity
{
    public class ScoreBoard : IEntityModel
    {
        public ScoreBoard()
        {
            BallUpdate = new HashSet<BallUpdate>();
        }

        public int PkScoreBoard { get; set; }
        public int Fkmatch { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }

        public Match FkmatchNavigation { get; set; }
        public ICollection<BallUpdate> BallUpdate { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScoreBoard>(entity =>
            {
                entity.HasKey(e => e.PkScoreBoard);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.ScoreBoard)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScoreBoar__FKMat__55F4C372");
            });

        }
    }
}
