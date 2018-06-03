using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class TournamentMatch : LogicBase
    {
        public int TournamentMatchId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int MatchId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int TournamentId { get; set; }
    }
}
