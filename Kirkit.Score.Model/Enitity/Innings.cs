﻿using Kirkit.Score.Common.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Entity
{
    public class Innings : IEntityModel
    {
        public Innings()
        {
            BattingScore = new HashSet<BattingScore>();
            BowlingScore = new HashSet<BowlingScore>();
            UpdatePerBall = new HashSet<UpdatePerBall>();
        }

        public int InningsId { get; set; }
        public string Name { get; set; }
        public int MatchId { get; set; }
        public int BattingTeamId { get; set; }
        public int BowlingTeamId { get; set; }
        public int PlayeOnStrikeId { get; set; }
        public int PlayerOnNonStrikeId { get; set; }
        public int BallerId { get; set; }
        public int TotalScoreId { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        public Player Baller { get; set; }
        public Team BattingTeam { get; set; }
        public Team BowlingTeam { get; set; }
        public Player PlayeOnStrike { get; set; }
        public Player PlayerOnNonStrike { get; set; }
        public TotalScore TotalScore { get; set; }
        public ICollection<BattingScore> BattingScore { get; set; }
        public ICollection<BowlingScore> BowlingScore { get; set; }
        public ICollection<UpdatePerBall> UpdatePerBall { get; set; }

        public void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Innings>(entity =>
            {
                entity.HasKey(e => e.InningsId);

                entity.Property(e => e.DtCreated).HasColumnType("datetime");

                entity.Property(e => e.DtUpdated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Baller)
                    .WithMany(p => p.InningsBaller)
                    .HasForeignKey(d => d.BallerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Innings__BallerI__787EE5A0");

                entity.HasOne(d => d.BattingTeam)
                    .WithMany(p => p.InningsBattingTeam)
                    .HasForeignKey(d => d.BattingTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Innings__Batting__74AE54BC");

                entity.HasOne(d => d.BowlingTeam)
                    .WithMany(p => p.InningsBowlingTeam)
                    .HasForeignKey(d => d.BowlingTeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Innings__Bowling__75A278F5");

                entity.HasOne(d => d.PlayeOnStrike)
                    .WithMany(p => p.InningsPlayeOnStrike)
                    .HasForeignKey(d => d.PlayeOnStrikeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Innings__PlayeOn__76969D2E");

                entity.HasOne(d => d.PlayerOnNonStrike)
                    .WithMany(p => p.InningsPlayerOnNonStrike)
                    .HasForeignKey(d => d.PlayerOnNonStrikeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Innings__PlayerO__778AC167");

                entity.HasOne(d => d.TotalScore)
                    .WithMany(p => p.Innings)
                    .HasForeignKey(d => d.TotalScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Innings__TotalSc__797309D9");
            });
        }
    }
}