using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class TournamentRule : IEntityModel
    {
        public int PkTournamentRule { get; set; }
        public int? Fktournament { get; set; }
        public int? Fkrule { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Rule FkruleNavigation { get; set; }
        public Tournament FktournamentNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TournamentRule>(entity =>
            {
                entity.HasKey(e => e.PkTournamentRule);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkrule).HasColumnName("FKRule");

                entity.Property(e => e.Fktournament).HasColumnName("FKTournament");

                entity.HasOne(d => d.FkruleNavigation)
                    .WithMany(p => p.TournamentRule)
                    .HasForeignKey(d => d.Fkrule)
                    .HasConstraintName("FK__Tournamen__FKRul__40F9A68C");

                entity.HasOne(d => d.FktournamentNavigation)
                    .WithMany(p => p.TournamentRule)
                    .HasForeignKey(d => d.Fktournament)
                    .HasConstraintName("FK__Tournamen__FKTou__40058253");
            });

        }
    }
}
