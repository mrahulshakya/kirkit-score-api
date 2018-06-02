using System;

namespace Kirkit.Score.Model.Logic
{
    public class BowlingScore : LogicBase
    {
        public int BowlingScoreId { get; set; }
        public int InningsId { get; set; }
        public int BallerId { get; set; }
        public int Overs { get; set; }
        public int Balls { get; set; }
        public int TotalBalls { get; set; }
        public int RunsGiven { get; set; }
        public int Wickets { get; set; }
        public int Wides { get; set; }
        public int NoBall { get; set; }
        public double StrikeRate { get; set; }
    }
}
