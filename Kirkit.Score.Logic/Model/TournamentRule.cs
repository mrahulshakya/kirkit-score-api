using System;

namespace Kirkit.Score.Logic
{
    public class TournamentRule
    {
        public int PkTournamentRule { get; set; }
        public int? Fktournament { get; set; }
        public int? Fkrule { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        public Rule FkruleNavigation { get; set; }
        public Tournament FktournamentNavigation { get; set; }
    }
}
