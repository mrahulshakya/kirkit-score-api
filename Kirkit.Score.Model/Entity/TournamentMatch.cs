using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class TournamentMatch : BaseEntity, IEntityModel
    {
        public int TournamentMatchId { get; set; }
        public int MatchId { get; set; }
        public int TournamentId { get; set; }

        public Match Match { get; set; }
        public Tournament Tournament { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TournamentMatch>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.TournamentMatch)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tournamen__Match__619B8048");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentMatch)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tournamen__Tourn__628FA481");
            });
        }
    }
}
