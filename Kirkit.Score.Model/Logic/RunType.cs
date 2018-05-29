using System;
using System.Collections.Generic;

namespace Kirkit.Score.Model.Logic
{
    public class RunType
    {
        public int RunTypeId { get; set; }
        public string Detail { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
