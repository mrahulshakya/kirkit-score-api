using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Data.Enitity
{
    public class BallType : IEntityModel
    {
        public int PkBallType { get; set; }
        public string Detail { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
        public bool IsLegal { get; set; }
        public bool ExtraRun { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BallType>(entity =>
            {
                entity.HasKey(e => e.PkBallType);

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
