using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class WicketType : BaseEntity, IEntityModel
    {
        public WicketType()
        {
            PerBallUpdate = new HashSet<PerBallUpdate>();
            WicketDetail = new HashSet<WicketDetail>();
        }

        public int WicketTypeId { get; set; }
        public string Detail { get; set; }
     
        public ICollection<PerBallUpdate> PerBallUpdate { get; set; }
        public ICollection<WicketDetail> WicketDetail { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WicketType>(entity =>
            {
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
