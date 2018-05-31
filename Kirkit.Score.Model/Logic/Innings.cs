﻿using System;

namespace Kirkit.Score.Model.Logic
{
    public class Innings
    {
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
    }
}