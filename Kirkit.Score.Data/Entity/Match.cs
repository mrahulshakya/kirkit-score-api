using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data.Enitity
{
    public class Match : IEntityModel
    {
        public Match()
        {
            MatchOver = new HashSet<MatchOver>();
            MatchRule = new HashSet<MatchRule>();
            PlayerStrike = new HashSet<PlayerStrike>();
            TournamentMatch = new HashSet<TournamentMatch>();
        }

        public int PkMatch { get; set; }
        public int? FkTeam1 { get; set; }
        public int? FkTeam2 { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsComplete { get; set; }
        public DateTime? DtSchedule { get; set; }

        public Team FkTeam1Navigation { get; set; }
        public Team FkTeam2Navigation { get; set; }
        public ICollection<MatchOver> MatchOver { get; set; }
        public ICollection<MatchRule> MatchRule { get; set; }
        public ICollection<PlayerStrike> PlayerStrike { get; set; }
        public ICollection<TournamentMatch> TournamentMatch { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.PkMatch);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtSchedule).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkTeam1Navigation)
                    .WithMany(p => p.MatchFkTeam1Navigation)
                    .HasForeignKey(d => d.FkTeam1)
                    .HasConstraintName("FK__Match__FkTeam1__3864608B");

                entity.HasOne(d => d.FkTeam2Navigation)
                    .WithMany(p => p.MatchFkTeam2Navigation)
                    .HasForeignKey(d => d.FkTeam2)
                    .HasConstraintName("FK__Match__FkTeam2__395884C4");
            });

        }
    }
}
