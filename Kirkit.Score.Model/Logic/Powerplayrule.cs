using System;

namespace Kirkit.Score.Model.Logic
{
    public class Powerplayrule
    {
        public int PowerPlayRuleId { get; set; }
        public string Name { get; set; }
        public int NoOfSlots { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
