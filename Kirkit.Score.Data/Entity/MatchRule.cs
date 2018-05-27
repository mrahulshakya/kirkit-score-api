using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class MatchRule : IEntityModel
    {
        public int PkMacthRule { get; set; }
        public int? Fkmatch { get; set; }
        public int? Fkrule { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Match FkmatchNavigation { get; set; }
        public Rule FkruleNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchRule>(entity =>
            {
                entity.HasKey(e => e.PkMacthRule);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.Property(e => e.Fkrule).HasColumnName("FKRule");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.MatchRule)
                    .HasForeignKey(d => d.Fkmatch)
                    .HasConstraintName("FK__MatchRule__FKMat__43D61337");

                entity.HasOne(d => d.FkruleNavigation)
                    .WithMany(p => p.MatchRule)
                    .HasForeignKey(d => d.Fkrule)
                    .HasConstraintName("FK__MatchRule__FKRul__44CA3770");
            });

        }
    }
}
