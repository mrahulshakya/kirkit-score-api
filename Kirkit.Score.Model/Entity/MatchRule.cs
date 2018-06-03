using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class MatchRule : BaseEntity, IEntityModel
    {
        public int MacthRuleId { get; set; }
        public int MatchId { get; set; }
        public int RuleId { get; set; }
        
        public Match Match { get; set; }
        public Rule Rule { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchRule>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);

                entity.HasKey(e => e.MacthRuleId);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchRule)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchRule__Match__693CA210");

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.MatchRule)
                    .HasForeignKey(d => d.RuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchRule__RuleI__6A30C649");
            });
        }
    }
}
