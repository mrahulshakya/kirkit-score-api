using System;

namespace Kirkit.Score.Logic
{
    public class BowlingScore
    {
        public int PkBowlingScore { get; set; }
        public int PkPlayerId { get; set; }
        public int Overs { get; set; }
        public int Balls { get; set; }
        public int TotalBalls { get; set; }
        public int RunsGiven { get; set; }
        public int Wickets { get; set; }
        public double StrikeRate { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
