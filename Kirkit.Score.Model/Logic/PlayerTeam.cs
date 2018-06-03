using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class PlayerTeam : LogicBase
    {
        public int PlayerTeamId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int TeamId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int PlayerId { get; set; }
    }
}
