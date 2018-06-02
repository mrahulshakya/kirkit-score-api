using System;

namespace Kirkit.Score.Model.Logic
{
    public class Match : LogicBase
    {

        public int MatchId { get; set; }
        public int TeamAid { get; set; }
        public int TeamBid { get; set; }
        public bool IsComplete { get; set; }
        public DateTime? DtSchedule { get; set; }
    }
}
