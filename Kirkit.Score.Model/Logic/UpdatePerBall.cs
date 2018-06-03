using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class PerBallUpdate : LogicBase
    {
        public int PerBallUpdateId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int InningsId { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public int RunScored { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int RunType { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BallType { get; set; }

        [Required]
        public bool WiketFallen { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int WicketType { get; set; }
     }
}
