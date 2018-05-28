using Kirkit.Score.Data.Enitity;
using Microsoft.EntityFrameworkCore;

namespace Kirkit.Score.Data
{
    public class ScoreContext : DbContext
    {
        public virtual DbSet<BallType> BallType { get; set; }
        public virtual DbSet<BallUpdate> BallUpdate { get; set; }
        public virtual DbSet<BattingScore> BattingScore { get; set; }
        public virtual DbSet<BowlingScore> BowlingScore { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchOver> MatchOver { get; set; }
        public virtual DbSet<MatchRule> MatchRule { get; set; }
        public virtual DbSet<MaxOverRule> MaxOverRule { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerStrike> PlayerStrike { get; set; }
        public virtual DbSet<PlayerTeam> PlayerTeam { get; set; }
        public virtual DbSet<Powerplayrule> Powerplayrule { get; set; }
        public virtual DbSet<PowerplaySlot> Powerplayslot { get; set; }
        public virtual DbSet<Rule> Rule { get; set; }
        public virtual DbSet<RunType> RunType { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentMatch> TournamentMatch { get; set; }
        public virtual DbSet<TournamentRule> TournamentRule { get; set; }
        public virtual DbSet<WicketType> WicketType { get; set; }

        public ScoreContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var composite = new CompositeModelBuilder();
            composite.AddModel(new BallType())
                     .AddModel(new BallUpdate())
                     .AddModel(new BattingScore())
                     .AddModel(new BowlingScore())
                     .AddModel(new Match())
                     .AddModel(new MatchOver())
                     .AddModel(new MatchRule())
                     .AddModel(new MaxOverRule())
                     .AddModel(new Player())
                     .AddModel(new PlayerStrike())
                     .AddModel(new PlayerTeam())
                     .AddModel(new Powerplayrule())
                     .AddModel(new PowerplaySlot())
                     .AddModel(new Rule())
                     .AddModel(new RunType())
                     .AddModel(new Team())
                     .AddModel(new Tournament())
                     .AddModel(new TournamentMatch())
                     .AddModel(new TournamentRule())
                     .AddModel(new WicketType())
                     .AddModel(new Innings());

            composite.Build(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
