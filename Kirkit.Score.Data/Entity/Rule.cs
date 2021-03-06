﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data.Enitity
{
    public class Rule : IEntityModel
    {
        public Rule()
        {
            MatchRule = new HashSet<MatchRule>();
            TournamentRule = new HashSet<TournamentRule>();
        }

        public int PkRule { get; set; }
        public string Name { get; set; }
        public int? TotalOvers { get; set; }
        public int? FkMaxOverRule { get; set; }
        public bool? SuperOver { get; set; }
        public bool? FreeHit { get; set; }
        public int? FkPowerPlayRule { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public MaxOverRule FkMaxOverRuleNavigation { get; set; }
        public Powerplayrule FkPowerPlayRuleNavigation { get; set; }
        public ICollection<MatchRule> MatchRule { get; set; }
        public ICollection<TournamentRule> TournamentRule { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rule>(entity =>
            {
                entity.HasKey(e => e.PkRule);

                entity.ToTable("RULE");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkMaxOverRuleNavigation)
                    .WithMany(p => p.Rule)
                    .HasForeignKey(d => d.FkMaxOverRule)
                    .HasConstraintName("FK__RULE__FkMaxOverR__32AB8735");

                entity.HasOne(d => d.FkPowerPlayRuleNavigation)
                    .WithMany(p => p.Rule)
                    .HasForeignKey(d => d.FkPowerPlayRule)
                    .HasConstraintName("FK__RULE__FkPowerPla__339FAB6E");
            });

        }
    }
}
