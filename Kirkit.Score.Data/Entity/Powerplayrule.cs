using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data.Enitity
{
    public class Powerplayrule : IEntityModel
    {
        public Powerplayrule()
        {
            Powerplayslot = new HashSet<PowerplaySlot>();
            Rule = new HashSet<Rule>();
        }

        public int PkPowerPlayRule { get; set; }
        public string Name { get; set; }
        public int? NoOfSlots { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<PowerplaySlot> Powerplayslot { get; set; }
        public ICollection<Rule> Rule { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Powerplayrule>(entity =>
            {
                entity.HasKey(e => e.PkPowerPlayRule);

                entity.ToTable("POWERPLAYRULE");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

        }
    }
}
