using System;

namespace Kirkit.Score.Logic
{
    public class PowerplaySlot
    {
        public int PkPowerPlaySlot { get; set; }
        public int? FkPowerPlayRule { get; set; }
        public int? NoOfOvers { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Powerplayrule FkPowerPlayRuleNavigation { get; set; }

    }
}
