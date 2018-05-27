using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class PowerplaySlot : IEntityModel
    {
        public int PkPowerPlaySlot { get; set; }
        public int? FkPowerPlayRule { get; set; }
        public int? NoOfOvers { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Powerplayrule FkPowerPlayRuleNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PowerplaySlot>(entity =>
            {
                entity.HasKey(e => e.PkPowerPlaySlot);

                entity.ToTable("POWERPLAYSLOT");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkPowerPlayRuleNavigation)
                    .WithMany(p => p.Powerplayslot)
                    .HasForeignKey(d => d.FkPowerPlayRule)
                    .HasConstraintName("FK__POWERPLAY__FkPow__2FCF1A8A");
            });

        }
    }
}
