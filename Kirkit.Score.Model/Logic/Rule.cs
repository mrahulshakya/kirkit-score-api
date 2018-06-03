using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Rule : LogicBase
    {
        public int RuleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int TotalOvers { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int FkMaxOverRule { get; set; }

        [Required]
        public bool SuperOver { get; set; }

        [Required]
        public bool FreeHit { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int FkPowerPlayRule { get; set; }
     }
}
