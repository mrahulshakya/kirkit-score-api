using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class BowlingScore : LogicBase
    {
        public int BowlingScoreId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int InningsId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BallerId { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Overs { get; set; }

        [Required]
        [Range(0, 5)]
        public int Balls { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int TotalBalls { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int RunsGiven { get; set; }

        [Required]
        [Range(0, 10)]
        public int Wickets { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Wides { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int NoBall { get; set; }

        [Required]
        [Range(0.00, double.MaxValue)]
        public double StrikeRate { get; set; }
    }
}