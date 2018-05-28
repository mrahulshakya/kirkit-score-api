using System;
using Kirkit.Score.Data.Enitity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Khaata.Enitities
{
    public class scorerContext : DbContext
    {
        public virtual DbSet<BallType> BallType { get; set; }
        public virtual DbSet<BallUpdate> BallUpdate { get; set; }
        public virtual DbSet<BallUpdate1> BallUpdate1 { get; set; }
        public virtual DbSet<BattingScore> BattingScore { get; set; }
        public virtual DbSet<BattingScore1> BattingScore1 { get; set; }
        public virtual DbSet<BowlingScore> BowlingScore { get; set; }
        public virtual DbSet<BowlingScore1> BowlingScore1 { get; set; }
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchOver> MatchOver { get; set; }
        public virtual DbSet<MatchOver1> MatchOver1 { get; set; }
        public virtual DbSet<MatchRule> MatchRule { get; set; }
        public virtual DbSet<MaxOverRule> MaxOverRule { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerStrike> PlayerStrike { get; set; }
        public virtual DbSet<PlayerStrike1> PlayerStrike1 { get; set; }
        public virtual DbSet<PlayerTeam> PlayerTeam { get; set; }
        public virtual DbSet<Powerplayrule> Powerplayrule { get; set; }
        public virtual DbSet<Powerplayslot> Powerplayslot { get; set; }
        public virtual DbSet<Rule> Rule { get; set; }
        public virtual DbSet<RunType> RunType { get; set; }
        public virtual DbSet<ScoreBoard> ScoreBoard { get; set; }
        public virtual DbSet<ScoreBoard1> ScoreBoard1 { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tournament> Tournament { get; set; }
        public virtual DbSet<TournamentMatch> TournamentMatch { get; set; }
        public virtual DbSet<TournamentRule> TournamentRule { get; set; }
        public virtual DbSet<WicketType> WicketType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server = tcp:kirkit.database.windows.net,1433; Initial Catalog = scorer; Persist Security Info = False; User ID = mrahulshakya; Password = Rahul@1504; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BallType>(entity =>
            {
                entity.HasKey(e => e.PkBallType);

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });

            modelBuilder.Entity<BallUpdate>(entity =>
            {
                entity.HasKey(e => e.PkBallUpdate);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkBattingTeamNavigation)
                    .WithMany(p => p.BallUpdateFkBattingTeamNavigation)
                    .HasForeignKey(d => d.FkBattingTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BallUpdat__FkBat__59C55456");

                entity.HasOne(d => d.FkBowlingTeamNavigation)
                    .WithMany(p => p.BallUpdateFkBowlingTeamNavigation)
                    .HasForeignKey(d => d.FkBowlingTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BallUpdat__FkBow__5AB9788F");

                entity.HasOne(d => d.FkScoreBoardNavigation)
                    .WithMany(p => p.BallUpdate)
                    .HasForeignKey(d => d.FkScoreBoard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BallUpdat__FkSco__58D1301D");
            });

            modelBuilder.Entity<BallUpdate1>(entity =>
            {
                entity.HasKey(e => e.PkBallUpdate);

                entity.ToTable("BallUpdate", "Current");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkBattingTeamNavigation)
                    .WithMany(p => p.BallUpdate1FkBattingTeamNavigation)
                    .HasForeignKey(d => d.FkBattingTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BallUpdat__FkBat__72910220");

                entity.HasOne(d => d.FkBowlingTeamNavigation)
                    .WithMany(p => p.BallUpdate1FkBowlingTeamNavigation)
                    .HasForeignKey(d => d.FkBowlingTeam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BallUpdat__FkBow__73852659");

                entity.HasOne(d => d.FkScoreBoardNavigation)
                    .WithMany(p => p.BallUpdate1)
                    .HasForeignKey(d => d.FkScoreBoard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BallUpdat__FkSco__719CDDE7");
            });

            modelBuilder.Entity<BattingScore>(entity =>
            {
                entity.HasKey(e => e.PkBattingScore);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.FkcatchTakenBy).HasColumnName("FKCatchTakenBy");

                entity.Property(e => e.FkstumpedBy).HasColumnName("FKStumpedBy");

                entity.HasOne(d => d.FkWicketTakenByNavigation)
                    .WithMany(p => p.BattingScoreFkWicketTakenByNavigation)
                    .HasForeignKey(d => d.FkWicketTakenBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FkWic__5E8A0973");

                entity.HasOne(d => d.FkcatchTakenByNavigation)
                    .WithMany(p => p.BattingScoreFkcatchTakenByNavigation)
                    .HasForeignKey(d => d.FkcatchTakenBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FKCat__5F7E2DAC");

                entity.HasOne(d => d.FkstumpedByNavigation)
                    .WithMany(p => p.BattingScoreFkstumpedByNavigation)
                    .HasForeignKey(d => d.FkstumpedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FKStu__607251E5");

                entity.HasOne(d => d.PkPlayer)
                    .WithMany(p => p.BattingScorePkPlayer)
                    .HasForeignKey(d => d.PkPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__PkPla__5D95E53A");
            });

            modelBuilder.Entity<BattingScore1>(entity =>
            {
                entity.HasKey(e => e.PkBattingScore);

                entity.ToTable("BattingScore", "Current");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.FkcatchTakenBy).HasColumnName("FKCatchTakenBy");

                entity.Property(e => e.FkstumpedBy).HasColumnName("FKStumpedBy");

                entity.HasOne(d => d.FkScoreBoardNavigation)
                    .WithMany(p => p.BattingScore1)
                    .HasForeignKey(d => d.FkScoreBoard)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FkSco__76619304");

                entity.HasOne(d => d.FkWicketTakenByNavigation)
                    .WithMany(p => p.BattingScore1FkWicketTakenByNavigation)
                    .HasForeignKey(d => d.FkWicketTakenBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FkWic__7849DB76");

                entity.HasOne(d => d.FkcatchTakenByNavigation)
                    .WithMany(p => p.BattingScore1FkcatchTakenByNavigation)
                    .HasForeignKey(d => d.FkcatchTakenBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FKCat__793DFFAF");

                entity.HasOne(d => d.FkstumpedByNavigation)
                    .WithMany(p => p.BattingScore1FkstumpedByNavigation)
                    .HasForeignKey(d => d.FkstumpedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__FKStu__7A3223E8");

                entity.HasOne(d => d.PkPlayer)
                    .WithMany(p => p.BattingScore1PkPlayer)
                    .HasForeignKey(d => d.PkPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSc__PkPla__7755B73D");
            });

            modelBuilder.Entity<BowlingScore>(entity =>
            {
                entity.HasKey(e => e.PkBowlingScore);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.PkPlayer)
                    .WithMany(p => p.BowlingScore)
                    .HasForeignKey(d => d.PkPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BowlingSc__PkPla__634EBE90");
            });

            modelBuilder.Entity<BowlingScore1>(entity =>
            {
                entity.HasKey(e => e.PkBowlingScore);

                entity.ToTable("BowlingScore", "Current");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.PkPlayer)
                    .WithMany(p => p.BowlingScore1)
                    .HasForeignKey(d => d.PkPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BowlingSc__PkPla__7D0E9093");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.PkMatch);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtSchedule).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkTeam1Navigation)
                    .WithMany(p => p.MatchFkTeam1Navigation)
                    .HasForeignKey(d => d.FkTeam1)
                    .HasConstraintName("FK__Match__FkTeam1__3864608B");

                entity.HasOne(d => d.FkTeam2Navigation)
                    .WithMany(p => p.MatchFkTeam2Navigation)
                    .HasForeignKey(d => d.FkTeam2)
                    .HasConstraintName("FK__Match__FkTeam2__395884C4");
            });

            modelBuilder.Entity<MatchOver>(entity =>
            {
                entity.HasKey(e => e.PkMatchOver);

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.MatchOver)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchOver__FKMat__4D5F7D71");
            });

            modelBuilder.Entity<MatchOver1>(entity =>
            {
                entity.HasKey(e => e.PkMatchOver);

                entity.ToTable("MatchOver", "Current");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.MatchOver1)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchOver__FKMat__662B2B3B");
            });

            modelBuilder.Entity<MatchRule>(entity =>
            {
                entity.HasKey(e => e.PkMacthRule);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.Property(e => e.Fkrule).HasColumnName("FKRule");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.MatchRule)
                    .HasForeignKey(d => d.Fkmatch)
                    .HasConstraintName("FK__MatchRule__FKMat__43D61337");

                entity.HasOne(d => d.FkruleNavigation)
                    .WithMany(p => p.MatchRule)
                    .HasForeignKey(d => d.Fkrule)
                    .HasConstraintName("FK__MatchRule__FKRul__44CA3770");
            });

            modelBuilder.Entity<MaxOverRule>(entity =>
            {
                entity.HasKey(e => e.PkMaxOverRule);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PkPlayer);

                entity.Property(e => e.CoolName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(10, 0)");
            });

            modelBuilder.Entity<PlayerStrike>(entity =>
            {
                entity.HasKey(e => e.PkPlayerStrike);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.Baller)
                    .WithMany(p => p.PlayerStrikeBaller)
                    .HasForeignKey(d => d.BallerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Balle__531856C7");

                entity.HasOne(d => d.BattingNonStriker)
                    .WithMany(p => p.PlayerStrikeBattingNonStriker)
                    .HasForeignKey(d => d.BattingNonStrikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Batti__5224328E");

                entity.HasOne(d => d.BattingStriker)
                    .WithMany(p => p.PlayerStrikeBattingStriker)
                    .HasForeignKey(d => d.BattingStrikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Batti__51300E55");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.PlayerStrike)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__FKMat__503BEA1C");
            });

            modelBuilder.Entity<PlayerStrike1>(entity =>
            {
                entity.HasKey(e => e.PkPlayerStrike);

                entity.ToTable("PlayerStrike", "Current");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.Baller)
                    .WithMany(p => p.PlayerStrike1Baller)
                    .HasForeignKey(d => d.BallerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Balle__6BE40491");

                entity.HasOne(d => d.BattingNonStriker)
                    .WithMany(p => p.PlayerStrike1BattingNonStriker)
                    .HasForeignKey(d => d.BattingNonStrikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Batti__6AEFE058");

                entity.HasOne(d => d.BattingStriker)
                    .WithMany(p => p.PlayerStrike1BattingStriker)
                    .HasForeignKey(d => d.BattingStrikerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__Batti__69FBBC1F");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.PlayerStrike1)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerStr__FKMat__690797E6");
            });

            modelBuilder.Entity<PlayerTeam>(entity =>
            {
                entity.HasKey(e => e.PkPlayerTeam);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkPlayerNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.FkPlayer)
                    .HasConstraintName("FK__PlayerTea__FkPla__29221CFB");

                entity.HasOne(d => d.FkTeamNavigation)
                    .WithMany(p => p.PlayerTeam)
                    .HasForeignKey(d => d.FkTeam)
                    .HasConstraintName("FK__PlayerTea__FkTea__282DF8C2");
            });

            modelBuilder.Entity<Powerplayrule>(entity =>
            {
                entity.HasKey(e => e.PkPowerPlayRule);

                entity.ToTable("POWERPLAYRULE");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Powerplayslot>(entity =>
            {
                entity.HasKey(e => e.PkPowerPlaySlot);

                entity.ToTable("POWERPLAYSLOT");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.FkPowerPlayRuleNavigation)
                    .WithMany(p => p.Powerplayslot)
                    .HasForeignKey(d => d.FkPowerPlayRule)
                    .HasConstraintName("FK__POWERPLAY__FkPow__2FCF1A8A");
            });

            modelBuilder.Entity<Rule>(entity =>
            {
                entity.HasKey(e => e.PkRule);

                entity.ToTable("RULE");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkMaxOverRuleNavigation)
                    .WithMany(p => p.Rule)
                    .HasForeignKey(d => d.FkMaxOverRule)
                    .HasConstraintName("FK__RULE__FkMaxOverR__32AB8735");

                entity.HasOne(d => d.FkPowerPlayRuleNavigation)
                    .WithMany(p => p.Rule)
                    .HasForeignKey(d => d.FkPowerPlayRule)
                    .HasConstraintName("FK__RULE__FkPowerPla__339FAB6E");
            });

            modelBuilder.Entity<RunType>(entity =>
            {
                entity.HasKey(e => e.PkRunType);

                entity.Property(e => e.Detail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });

            modelBuilder.Entity<ScoreBoard>(entity =>
            {
                entity.HasKey(e => e.PkScoreBoard);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.ScoreBoard)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScoreBoar__FKMat__55F4C372");
            });

            modelBuilder.Entity<ScoreBoard1>(entity =>
            {
                entity.HasKey(e => e.PkScoreBoard);

                entity.ToTable("ScoreBoard", "Current");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkmatch).HasColumnName("FKMatch");

                entity.HasOne(d => d.FkmatchNavigation)
                    .WithMany(p => p.ScoreBoard1)
                    .HasForeignKey(d => d.Fkmatch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ScoreBoar__FKMat__6EC0713C");
            });

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

            modelBuilder.Entity<TournamentMatch>(entity =>
            {
                entity.HasKey(e => e.PkTournamentMatch);

                entity.Property(e => e.PkTournamentMatch).HasColumnName("pkTournamentMatch");

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fktournament).HasColumnName("FKTournament");

                entity.HasOne(d => d.FkMatchNavigation)
                    .WithMany(p => p.TournamentMatch)
                    .HasForeignKey(d => d.FkMatch)
                    .HasConstraintName("FK__Tournamen__FkMat__3C34F16F");

                entity.HasOne(d => d.FktournamentNavigation)
                    .WithMany(p => p.TournamentMatch)
                    .HasForeignKey(d => d.Fktournament)
                    .HasConstraintName("FK__Tournamen__FKTou__3D2915A8");
            });

            modelBuilder.Entity<TournamentRule>(entity =>
            {
                entity.HasKey(e => e.PkTournamentRule);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Fkrule).HasColumnName("FKRule");

                entity.Property(e => e.Fktournament).HasColumnName("FKTournament");

                entity.HasOne(d => d.FkruleNavigation)
                    .WithMany(p => p.TournamentRule)
                    .HasForeignKey(d => d.Fkrule)
                    .HasConstraintName("FK__Tournamen__FKRul__40F9A68C");

                entity.HasOne(d => d.FktournamentNavigation)
                    .WithMany(p => p.TournamentRule)
                    .HasForeignKey(d => d.Fktournament)
                    .HasConstraintName("FK__Tournamen__FKTou__40058253");
            });

            modelBuilder.Entity<WicketType>(entity =>
            {
                entity.HasKey(e => e.PkWicketType);

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");
            });
        }
    }
}
