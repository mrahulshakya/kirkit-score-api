using Kirkit.Score.Model.Logic.CustomVaildation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Match : LogicBase
    {
        public int MatchId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int TeamAid { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int TeamBid { get; set; }

        public bool IsComplete { get; set; }

        [Required]
        [FutureDate(6)]
        public DateTime? DtSchedule { get; set; }
    }
}
