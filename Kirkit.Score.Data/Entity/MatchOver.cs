using Microsoft.EntityFrameworkCore;

namespace Kirkit.Score.Data.Enitity
{
    public class MatchOver : IEntityModel
    {
        public int PkMatchOver { get; set; }
        public int Fkmatch { get; set; }
        public int CurrentOver { get; set; }
        public int CurrentBall { get; set; }

        public Match FkmatchNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchOver>(entity =>
            {
                entity.HasKey(e => e.PkMatchOver);

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.MatchOver)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchOver__FKMat__4D5F7D71");
            });

        }
    }
}
