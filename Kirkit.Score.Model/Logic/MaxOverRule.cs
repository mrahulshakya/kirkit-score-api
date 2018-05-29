using System;

namespace Kirkit.Score.Model.Logic
{
    public class MaxOverRule
    {
        public int MaxOverRuleId { get; set; }
        public string Name { get; set; }
        public int Bowler1 { get; set; }
        public int Bowler2 { get; set; }
        public int Bowler3 { get; set; }
        public int Bowler4 { get; set; }
        public int Bowler5 { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
