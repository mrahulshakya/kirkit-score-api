using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Data.Enitity
{
    public class Player : IEntityModel
    {
        public Player()
        {
            BattingScoreFkWicketTakenByNavigation = new HashSet<BattingScore>();
            BattingScoreFkcatchTakenByNavigation = new HashSet<BattingScore>();
            BattingScoreFkstumpedByNavigation = new HashSet<BattingScore>();
            BattingScorePkPlayer = new HashSet<BattingScore>();
            BowlingScore = new HashSet<BowlingScore>();
            PlayerStrikeBaller = new HashSet<PlayerStrike>();
            PlayerStrikeBattingNonStriker = new HashSet<PlayerStrike>();
            PlayerStrikeBattingStriker = new HashSet<PlayerStrike>();
            PlayerTeam = new HashSet<PlayerTeam>();
        }

        public int PkPlayer { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CoolName { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<BattingScore> BattingScoreFkWicketTakenByNavigation { get; set; }
        public ICollection<BattingScore> BattingScoreFkcatchTakenByNavigation { get; set; }
        public ICollection<BattingScore> BattingScoreFkstumpedByNavigation { get; set; }
        public ICollection<BattingScore> BattingScorePkPlayer { get; set; }
        public ICollection<BowlingScore> BowlingScore { get; set; }
        public ICollection<PlayerStrike> PlayerStrikeBaller { get; set; }
        public ICollection<PlayerStrike> PlayerStrikeBattingNonStriker { get; set; }
        public ICollection<PlayerStrike> PlayerStrikeBattingStriker { get; set; }
        public ICollection<PlayerTeam> PlayerTeam { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
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

        }
    }
}
