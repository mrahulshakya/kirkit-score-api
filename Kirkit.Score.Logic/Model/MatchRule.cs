using System;

namespace Kirkit.Score.Logic
{
    public class MatchRule
    {
        public int PkMacthRule { get; set; }
        public int? Fkmatch { get; set; }
        public int? Fkrule { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
