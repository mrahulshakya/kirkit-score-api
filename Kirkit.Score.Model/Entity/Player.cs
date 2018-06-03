using Kirkit.Score.Common.Attribute;
using Kirkit.Score.Common.Data;
using Kirkit.Score.Common.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class Player : BaseEntity, IEntityModel
    {
        public Player()
        {
            BattingScore = new HashSet<BattingScore>();
            BowlingScore = new HashSet<BowlingScore>();
            InningsBaller = new HashSet<Innings>();
            InningsPlayeOnStrike = new HashSet<Innings>();
            InningsPlayerOnNonStrike = new HashSet<Innings>();
            PlayerTeam = new HashSet<PlayerTeam>();
            WicketDetailFielder = new HashSet<WicketDetail>();
            WicketDetailWicketOwner = new HashSet<WicketDetail>();
        }

        public int PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CoolName { get; set; }

        [AllowedCount(1)]
        public string Email { get; set; }

        [AllowedCount(1)]
        public decimal PhoneNumber { get; set; }

        public int Age { get; set; }
        
        public ICollection<BattingScore> BattingScore { get; set; }
        public ICollection<BowlingScore> BowlingScore { get; set; }
        public ICollection<Innings> InningsBaller { get; set; }
        public ICollection<Innings> InningsPlayeOnStrike { get; set; }
        public ICollection<Innings> InningsPlayerOnNonStrike { get; set; }
        public ICollection<PlayerTeam> PlayerTeam { get; set; }
        public ICollection<WicketDetail> WicketDetailFielder { get; set; }
        public ICollection<WicketDetail> WicketDetailWicketOwner { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasQueryFilter(x => x.IsActive);

                entity.Property(e => e.PlayerId).HasColumnName("PLayerId");

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
