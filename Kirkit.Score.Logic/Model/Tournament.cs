using System;
using System.Collections.Generic;

namespace Kirkit.Score.Logic
{
    public class Tournament
    {
        public Tournament()
        {
        }

        public int PkTournament { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DtStartDate { get; set; }
        public DateTime? DtEndDate { get; set; }

        public ICollection<TournamentMatch> TournamentMatch { get; set; }
        public ICollection<TournamentRule> TournamentRule { get; set; }
    }
}
