using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class MatchRule : LogicBase
    {
        public int MacthRuleId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int MatchId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int RuleId { get; set; }
    }
}
