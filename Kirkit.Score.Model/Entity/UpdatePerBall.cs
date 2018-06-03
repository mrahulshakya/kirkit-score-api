using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class PerBallUpdate : BaseEntity, IEntityModel
    {
        public PerBallUpdate()
        {
            WicketDetail = new HashSet<WicketDetail>();
        }

        public int PerBallUpdateId { get; set; }
        public int RunScored { get; set; }
        public int RunType { get; set; }
        public int BallType { get; set; }
        public bool WiketFallen { get; set; }
        public bool WicketType { get; set; }
        public int InningsId { get; set; }

        public Innings Innings { get; set; }
        public ICollection<WicketDetail> WicketDetail { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerBallUpdate>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Innings)
                    .WithMany(p => p.PerBallUpdate)
                    .HasForeignKey(d => d.InningsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UpdatePer__Innin__08B54D69");
            });
        }
    }
}
