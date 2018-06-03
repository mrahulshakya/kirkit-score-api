using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class WicketDetail : BaseEntity, IEntityModel
    {
        public int WicketDetailId { get; set; }
        public int UpdatePerBallId { get; set; }
        public int WicketType { get; set; }
        public string Details { get; set; }
        public int? WicketOwnerId { get; set; }
        public int? FielderId { get; set; }
      
        public Player Fielder { get; set; }
        public PerBallUpdate UpdatePerBall { get; set; }
        public Player WicketOwner { get; set; }
        public WicketType WicketTypeNavigation { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WicketDetail>(entity =>
            {
                entity.Property(e => e.Details)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Fielder)
                    .WithMany(p => p.WicketDetailFielder)
                    .HasForeignKey(d => d.FielderId)
                    .HasConstraintName("FK__WicketDet__Field__04E4BC85");

                entity.HasOne(d => d.UpdatePerBall)
                    .WithMany(p => p.WicketDetail)
                    .HasForeignKey(d => d.UpdatePerBallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WicketDet__Updat__02084FDA");

                entity.HasOne(d => d.WicketOwner)
                    .WithMany(p => p.WicketDetailWicketOwner)
                    .HasForeignKey(d => d.WicketOwnerId)
                    .HasConstraintName("FK__WicketDet__Wicke__03F0984C");

                entity.HasOne(d => d.WicketTypeNavigation)
                    .WithMany(p => p.WicketDetail)
                    .HasForeignKey(d => d.WicketType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WicketDet__Wicke__02FC7413");
            });


        }
    }
}
