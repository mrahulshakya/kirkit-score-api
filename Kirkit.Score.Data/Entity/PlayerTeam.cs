using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class PlayerTeam : IEntityModel
    {
        public int PkPlayerTeam { get; set; }
        public int? FkTeam { get; set; }
        public int? FkPlayer { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Player FkPlayerNavigation { get; set; }
        public Team FkTeamNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTeam>(entity =>
            {
                entity.HasKey(e => e.PkPlayerTeam);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkPlayerNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.FkPlayer)
                    .HasConstraintName("FK__PlayerTea__FkPla__29221CFB");

                entity.HasOne(d => d.FkTeamNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.FkTeam)
                    .HasConstraintName("FK__PlayerTea__FkTea__282DF8C2");
            });

        }
    }
}
