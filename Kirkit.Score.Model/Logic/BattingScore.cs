using System;

namespace Kirkit.Score.Model.Logic
{
    public class BattingScore : LogicBase
    {
        public int BattingScoreId { get; set; }
        public int InningsId { get; set; }
        public int BatsmenId { get; set; }
        public int RunsScored { get; set; }
        public int BallFaced { get; set; }
        public int Sixes { get; set; }
        public int Fours { get; set; }
        public int Dots { get; set; }
        public double StrikeRate { get; set; }
        public bool NotOut { get; set; }
    }
}
