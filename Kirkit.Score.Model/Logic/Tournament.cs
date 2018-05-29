using System;

namespace Kirkit.Score.Model.Logic
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DtStartDate { get; set; }
        public DateTime? DtEndDate { get; set; }
    }
}
