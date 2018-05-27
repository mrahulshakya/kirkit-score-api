using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data.Enitity
{
    public class Tournament : IEntityModel
    {
        public Tournament()
        {
            TournamentMatch = new HashSet<TournamentMatch>();
            TournamentRule = new HashSet<TournamentRule>();
        }

        public int PkTournament { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DtStartDate { get; set; }
        public DateTime? DtEndDate { get; set; }

        public ICollection<TournamentMatch> TournamentMatch { get; set; }
        public ICollection<TournamentRule> TournamentRule { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.HasKey(e => e.PkTournament);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtEndDate).HasColumnType("datetime");

                entity.Property(e => e.DtStartDate).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

        }
    }
}
