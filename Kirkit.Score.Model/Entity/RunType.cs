using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class RunType : BaseEntity, IEntityModel
    {
        public int RunTypeId { get; set; }
        public string Detail { get; set; }
        
        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RunType>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);

                entity.Property(e => e.RunTypeId).ValueGeneratedNever();

                entity.Property(e => e.Detail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });
        }
    }
}
