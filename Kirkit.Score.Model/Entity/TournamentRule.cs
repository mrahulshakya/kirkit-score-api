using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class TournamentRule : BaseEntity1, IEntityModel
    {
        public int TournamentRuleId { get; set; }
        public int? TournamentId { get; set; }
        public int? RuleId { get; set; }
   
        public Rule Rule { get; set; }
        public Tournament Tournament { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TournamentRule>(entity =>
            {
                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.TournamentRule)
                    .HasForeignKey(d => d.RuleId)
                    .HasConstraintName("FK__Tournamen__RuleI__66603565");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TournamentRule)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK__Tournamen__Tourn__656C112C");
            });

        }
    }
}
