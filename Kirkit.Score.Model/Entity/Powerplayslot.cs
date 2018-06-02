using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class Powerplayslot : BaseEntity, IEntityModel
    {
        public int PowerPlaySlotId { get; set; }
        public int FkPowerPlayRule { get; set; }
        public int NoOfOvers { get; set; }
        
        public Powerplayrule FkPowerPlayRuleNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Powerplayslot>(entity =>
            {
                entity.ToTable("POWERPLAYSLOT");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkPowerPlayRuleNavigation)
                    .WithMany(p => p.Powerplayslot)
                    .HasForeignKey(d => d.FkPowerPlayRule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__POWERPLAY__FkPow__5535A963");
            });
        }
    }
}
