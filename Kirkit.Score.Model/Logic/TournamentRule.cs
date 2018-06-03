using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class TournamentRule : LogicBase
    {
        public int TournamentRuleId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int? TournamentId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int? RuleId { get; set; }
    }
}
