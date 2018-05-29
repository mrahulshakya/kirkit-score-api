using System;

namespace Kirkit.Score.Model.Logic
{
    public class Powerplayslot
    {
        public int PowerPlaySlotId { get; set; }
        public int FkPowerPlayRule { get; set; }
        public int NoOfOvers { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
