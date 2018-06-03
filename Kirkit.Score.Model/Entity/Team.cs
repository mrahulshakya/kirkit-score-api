using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class Team : BaseEntity1, IEntityModel
    {
        public Team()
        {
            InningsBattingTeam = new HashSet<Innings>();
            InningsBowlingTeam = new HashSet<Innings>();
            MatchTeamA = new HashSet<Match>();
            MatchTeamB = new HashSet<Match>();
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
     
        public ICollection<Innings> InningsBattingTeam { get; set; }
        public ICollection<Innings> InningsBowlingTeam { get; set; }
        public ICollection<Match> MatchTeamA { get; set; }
        public ICollection<Match> MatchTeamB { get; set; }
        public ICollection<PlayerTeam> PlayerTeam { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
