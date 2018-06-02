using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kirkit.Score.Model.Entity
{
    public class PlayerTeam : BaseEntity, IEntityModel
    {
        public int PlayerTeamId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        
        public Player Player { get; set; }
        public Team Team { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerTeam>(entity =>
            {
                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerTea__Playe__4E88ABD4");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerTea__TeamI__4D94879B");
            });
        }
    }
}
