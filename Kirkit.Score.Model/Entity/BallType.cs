using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class BallType : BaseEntity,IEntityModel
    {
        public int BallTypeId { get; set; }
        public string Detail { get; set; }
        public bool IsLegal { get; set; }
        public bool ExtraRun { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BallType>(entity =>
            {
                entity.Property(e => e.BallTypeId).ValueGeneratedNever();

                entity.Property(e => e.Detail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });

        }
    }
}
