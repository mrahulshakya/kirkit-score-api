using System;

namespace Kirkit.Score.Model.Logic
{
    public class TournamentRule
    {
        public int TournamentRuleId { get; set; }
        public int? TournamentId { get; set; }
        public int? RuleId { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
