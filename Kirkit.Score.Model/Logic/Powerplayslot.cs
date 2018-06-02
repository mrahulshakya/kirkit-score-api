using System;

namespace Kirkit.Score.Model.Logic
{
    public class Powerplayslot : LogicBase
    {
        public int PowerPlaySlotId { get; set; }
        public int FkPowerPlayRule { get; set; }
        public int NoOfOvers { get; set; }
    }
}
