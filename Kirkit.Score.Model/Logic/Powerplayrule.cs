using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Powerplayrule : LogicBase
    {
        public int PowerPlayRuleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int NoOfSlots { get; set; }
    }
}
