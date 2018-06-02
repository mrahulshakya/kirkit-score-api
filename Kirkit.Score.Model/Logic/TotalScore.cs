using System;

namespace Kirkit.Score.Model.Logic
{
    public class TotalScore : LogicBase
    {
        public int TotalScoreId { get; set; }
        public int TotalRuns { get; set; }
        public int TotalOvers { get; set; }
        public int TotalBalls { get; set; }
        public int TotalWikets { get; set; }
        public int ExtraRuns { get; set; }
    }
}
