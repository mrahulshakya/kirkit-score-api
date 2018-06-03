using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class WicketDetail : LogicBase
    {
        public int WicketDetailId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int PerBallUpdateId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int WicketType { get; set; }
        public string Details { get; set; }

        public int? WicketOwnerId { get; set; }

        public int? FielderId { get; set; }
    }
}
