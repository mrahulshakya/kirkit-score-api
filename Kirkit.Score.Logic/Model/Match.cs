using System;

namespace Kirkit.Score.Logic
{
    public class Match
    {
        public Match()
        {
        }

        public int PkMatch { get; set; }
        public int? FkTeam1 { get; set; }
        public int? FkTeam2 { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsComplete { get; set; }
        public DateTime? DtSchedule { get; set; }
    }
}

