﻿using Kirkit.Score.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kirkit.Score.Data
{
    public class ScoreContext : DbContext
    {
        public virtual DbSet<BallType> BallType { get; set; }
        public virtual DbSet<BattingScore> BattingScore { get; set; }
        public virtual DbSet<BowlingScore> BowlingScore { get; set; }
        public virtual DbSet<Innings> Innings { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchRule> MatchRule { get; set; }
        public virtual DbSet<MaxOverRule> MaxOverRule { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerTeam> PlayerTeam { get; set; }
        public virtual DbSet<Powerplayrule> Powerplayrule { get; set; }
        public virtual DbSet<Powerplayslot> Powerplayslot { get; set; }
        public virtual DbSet<Rule> Rule { get; set; }
        public virtual DbSet<RunType> RunType { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TotalScore> TotalScore { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentMatch> TournamentMatch { get; set; }
        public virtual DbSet<TournamentRule> TournamentRule { get; set; }
        public virtual DbSet<UpdatePerBall> UpdatePerBall { get; set; }
        public virtual DbSet<WicketDetail> WicketDetail { get; set; }
        public virtual DbSet<WicketType> WicketType { get; set; }

        public ScoreContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var composite = RepositoryFactory.GetModels();

            composite.Build(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
