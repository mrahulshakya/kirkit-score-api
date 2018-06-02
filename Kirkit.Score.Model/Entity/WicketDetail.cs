using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class WicketDetail : BaseEntity, IEntityModel
    {
        public int WicketDetailId { get; set; }
        public int PerBallUpdateId { get; set; }
        public bool WicketType { get; set; }
        public string Details { get; set; }
        public int? WicketOwnerId { get; set; }
        public int? FielderId { get; set; }
       
        public Player Fielder { get; set; }
        public PerBallUpdate PerBallUpdate { get; set; }
        public Player WicketOwner { get; set; }

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
                    .HasConstraintName("FK__WicketDet__Field__00200768");

                entity.HasOne(d => d.PerBallUpdate)
                    .WithMany(p => p.WicketDetail)
                    .HasForeignKey(d => d.PerBallUpdateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WicketDet__Updat__7E37BEF6");

                entity.HasOne(d => d.WicketOwner)
                    .WithMany(p => p.WicketDetailWicketOwner)
                    .HasForeignKey(d => d.WicketOwnerId)
                    .HasConstraintName("FK__WicketDet__Wicke__7F2BE32F");
            });
        }
    }
}
