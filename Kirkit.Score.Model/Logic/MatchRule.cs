using System;

namespace Kirkit.Score.Model.Logic
{
    public class MatchRule
    {
        public int MacthRuleId { get; set; }
        public int MatchId { get; set; }
        public int RuleId { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
