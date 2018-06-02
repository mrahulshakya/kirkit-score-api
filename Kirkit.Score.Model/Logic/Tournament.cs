using System;

namespace Kirkit.Score.Model.Logic
{
    public class Tournament : LogicBase
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DtStartDate { get; set; }
        public DateTime? DtEndDate { get; set; }
    }
}
