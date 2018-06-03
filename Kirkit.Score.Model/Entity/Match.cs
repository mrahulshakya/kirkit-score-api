using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class Match : BaseEntity, IEntityModel
    {
        public Match()
        {
            MatchRule = new HashSet<MatchRule>();
            TournamentMatch = new HashSet<TournamentMatch>();
        }

        public int MatchId { get; set; }
        public int TeamAid { get; set; }
        public int TeamBid { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? DtSchedule { get; set; }

        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public ICollection<MatchRule> MatchRule { get; set; }
        public ICollection<TournamentMatch> TournamentMatch { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtSchedule).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.TeamAid).HasColumnName("TeamAId");

                entity.Property(e => e.TeamBid).HasColumnName("TeamBId");

                entity.HasOne(d => d.TeamA)
                    .WithMany(p => p.MatchTeamA)
                    .HasForeignKey(d => d.TeamAid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match__TeamAId__5DCAEF64");

                entity.HasOne(d => d.TeamB)
                    .WithMany(p => p.MatchTeamB)
                    .HasForeignKey(d => d.TeamBid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Match__TeamBId__5EBF139D");
            });
        }
    }
}
