using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class WicketType : LogicBase
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int WicketTypeId { get; set; }

        [Required]
        public string Detail { get; set; }
    }
}
