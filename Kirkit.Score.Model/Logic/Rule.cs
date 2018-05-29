using System;

namespace Kirkit.Score.Model.Logic
{
    public class Rule
    {
        public int RuleId { get; set; }
        public string Name { get; set; }
        public int TotalOvers { get; set; }
        public int FkMaxOverRule { get; set; }
        public bool SuperOver { get; set; }
        public bool FreeHit { get; set; }
        public int FkPowerPlayRule { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
