﻿using System;

namespace Kirkit.Score.Logic
{
    public class BattingScore
    {
        public int PkBattingScore { get; set; }
        public int PkPlayerId { get; set; }
        public int RunsScored { get; set; }
        public int BallFaced { get; set; }
        public int Sixes { get; set; }
        public int Fours { get; set; }
        public int Dots { get; set; }
        public double StrikeRate { get; set; }
        public bool NotOut { get; set; }
        public int FkWicketTakenBy { get; set; }
        public int FkcatchTakenBy { get; set; }
        public int FkstumpedBy { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}