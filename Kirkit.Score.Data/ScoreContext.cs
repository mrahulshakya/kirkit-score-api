using Kirkit.Score.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        public virtual DbSet<PerBallUpdate> PerBallUpdate { get; set; }
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity)
                               .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted);
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DtCreated = DateTime.Now;
                    ((BaseEntity)entity.Entity).DtUpdated = DateTime.Now;
                    ((BaseEntity)entity.Entity).IsActive = true;
                }
                if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).DtUpdated = DateTime.Now;
                }
                if (entity.State == EntityState.Deleted)
                {
                    ((BaseEntity)entity.Entity).DtUpdated = DateTime.Now;
                    ((BaseEntity)entity.Entity).IsActive = false;
                    entity.State = EntityState.Modified;
                }
            };

            return base.SaveChangesAsync(cancellationToken);
        }
      }
}
