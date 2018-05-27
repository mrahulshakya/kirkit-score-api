using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data.Enitity
{
    public class Team : IEntityModel
    {
        public Team()
        {
            //BallUpdateFkBattingTeamNavigation = new HashSet<BallUpdate>();
            //BallUpdateFkBowlingTeamNavigation = new HashSet<BallUpdate>();
            MatchFkTeam1Navigation = new HashSet<Match>();
            MatchFkTeam2Navigation = new HashSet<Match>();
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public int PkTeam { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        //public ICollection<BallUpdate> BallUpdateFkBattingTeamNavigation { get; set; }
        //public ICollection<BallUpdate> BallUpdateFkBowlingTeamNavigation { get; set; }
        public ICollection<Match> MatchFkTeam1Navigation { get; set; }
        public ICollection<Match> MatchFkTeam2Navigation { get; set; }
        public ICollection<PlayerTeam> PlayerTeam { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.PkTeam);

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
