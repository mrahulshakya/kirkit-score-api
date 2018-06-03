using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Innings : LogicBase
    {
        public int InningsId { get; set; }
        public string Name { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BattingTeamId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BowlingTeamId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int PlayeOnStrikeId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int PlayerOnNonStrikeId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BallerId { get; set; }

        [Range(0, Int32.MaxValue)]
        public int TotalScoreId { get; set; }
    }
}