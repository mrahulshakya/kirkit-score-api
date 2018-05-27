using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class TournamentMatch : IEntityModel
    {
        public int PkTournamentMatch { get; set; }
        public int? FkMatch { get; set; }
        public int? Fktournament { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Match FkMatchNavigation { get; set; }
        public Tournament FktournamentNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TournamentMatch>(entity =>
            {
                entity.HasKey(e => e.PkTournamentMatch);

                entity.Property(e => e.PkTournamentMatch).HasColumnName("pkTournamentMatch");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fktournament).HasColumnName("FKTournament");

                entity.HasOne(d => d.FkMatchNavigation)
                    .WithMany(p => p.TournamentMatch)
                    .HasForeignKey(d => d.FkMatch)
                    .HasConstraintName("FK__Tournamen__FkMat__3C34F16F");

                entity.HasOne(d => d.FktournamentNavigation)
                    .WithMany(p => p.TournamentMatch)
                    .HasForeignKey(d => d.Fktournament)
                    .HasConstraintName("FK__Tournamen__FKTou__3D2915A8");
            });

        }
    }
}
