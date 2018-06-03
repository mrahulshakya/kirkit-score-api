using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Powerplayslot : LogicBase
    {
        public int PowerPlaySlotId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int FkPowerPlayRule { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int NoOfOvers { get; set; }
    }
}
