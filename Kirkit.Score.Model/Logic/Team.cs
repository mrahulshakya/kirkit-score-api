using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Team : LogicBase
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }
     }
}
