using System;

namespace Kirkit.Score.Model.Logic
{
    public class TournamentRule : LogicBase
    {
        public int TournamentRuleId { get; set; }
        public int? TournamentId { get; set; }
        public int? RuleId { get; set; }
    }
}
