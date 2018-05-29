using System;

namespace Kirkit.Score.Model.Logic
{
    public class Match
    {

        public int MatchId { get; set; }
        public int TeamAid { get; set; }
        public int TeamBid { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? DtSchedule { get; set; }
    }
}
