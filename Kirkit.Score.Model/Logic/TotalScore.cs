using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class TotalScore : LogicBase
    {
        public int TotalScoreId { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int TotalRuns { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int TotalOvers { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int TotalBalls { get; set; }

        [Required]
        [Range(0,10)]
        public int TotalWikets { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int ExtraRuns { get; set; }
    }
}