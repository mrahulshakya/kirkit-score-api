using Kirkit.Score.Common.Attribute;
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

        [AllowedCount(1)]
        public int InningsId { get; set; }
        public int RunScored { get; set; }
        public int RunType { get; set; }
        public int BallType { get; set; }
        public bool WiketFallen { get; set; }
        public int WicketType { get; set; }
        public BallType BallTypeNavigation { get; set; }
        public Innings Innings { get; set; }
        public RunType RunTypeNavigation { get; set; }
        public WicketType WicketTypeNavigation { get; set; }
        public ICollection<WicketDetail> WicketDetail { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerBallUpdate>(entity =>
            {
                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.BallTypeNavigation)
                    .WithMany(p => p.PerBallUpdate)
                    .HasForeignKey(d => d.BallType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PerBallUp__BallT__7E37BEF6");

                entity.HasOne(d => d.Innings)
                    .WithMany(p => p.PerBallUpdate)
                    .HasForeignKey(d => d.InningsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PerBallUp__Innin__7C4F7684");

                entity.HasOne(d => d.RunTypeNavigation)
                    .WithMany(p => p.PerBallUpdate)
                    .HasForeignKey(d => d.RunType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PerBallUp__RunTy__7D439ABD");

                entity.HasOne(d => d.WicketTypeNavigation)
                    .WithMany(p => p.PerBallUpdate)
                    .HasForeignKey(d => d.WicketType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PerBallUp__Wicke__7F2BE32F");
            });
        }
    }
}
