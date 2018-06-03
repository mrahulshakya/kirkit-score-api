using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class Powerplayrule : BaseEntity1, IEntityModel
    {
        public Powerplayrule()
        {
            Powerplayslot = new HashSet<Powerplayslot>();
            Rule = new HashSet<Rule>();
        }

        public int PowerPlayRuleId { get; set; }
        public string Name { get; set; }
        public int NoOfSlots { get; set; }
       
        public ICollection<Powerplayslot> Powerplayslot { get; set; }
        public ICollection<Rule> Rule { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Powerplayrule>(entity =>
            {
                entity.ToTable("POWERPLAYRULE");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
