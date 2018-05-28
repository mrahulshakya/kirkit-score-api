using System;

namespace Kirkit.Score.Logic
{
    public class TournamentMatch
    {
        public int PkTournamentMatch { get; set; }
        public int? FkMatch { get; set; }
        public int? Fktournament { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Match FkMatchNavigation { get; set; }
        public Tournament FktournamentNavigation { get; set; }

    }
}
