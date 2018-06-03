using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class WicketType : BaseEntity, IEntityModel
    {
        public int WicketTypeId { get; set; }
        public string Detail { get; set; }
        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WicketType>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);

                entity.Property(e => e.WicketTypeId).ValueGeneratedNever();

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });
        }
    }
}