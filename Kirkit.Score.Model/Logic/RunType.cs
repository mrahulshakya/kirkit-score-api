using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class RunType : LogicBase
    {
        [Required]
        public int RunTypeId { get; set; }

        [Required]
        public string Detail { get; set; }
    }
}
