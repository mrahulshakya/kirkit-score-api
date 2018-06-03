using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class BattingScore : LogicBase
    {
        public int BattingScoreId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int InningsId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BatsmenId { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int RunsScored { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int BallFaced { get; set; }
        
        [Required]
        [Range(0, Int32.MaxValue)]
        public int Sixes { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Fours { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int Dots { get; set; }

        [Required]
        [Range(0.00, double.MaxValue)]
        public double StrikeRate { get; set; }
        
        [Required]
        public bool NotOut { get; set; }
    }
}
