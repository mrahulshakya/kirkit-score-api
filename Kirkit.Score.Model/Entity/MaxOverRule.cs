using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class MaxOverRule : BaseEntity, IEntityModel
    {
        public MaxOverRule()
        {
            Rule = new HashSet<Rule>();
        }

        public int MaxOverRuleId { get; set; }
        public string Name { get; set; }
        public int Bowler1 { get; set; }
        public int Bowler2 { get; set; }
        public int Bowler3 { get; set; }
        public int Bowler4 { get; set; }
        public int Bowler5 { get; set; }
        
        public ICollection<Rule> Rule { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaxOverRule>(entity =>
            {
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
