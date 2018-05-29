using System;

namespace Kirkit.Score.Model.Logic
{
    public class TournamentMatch
    {
        public int TournamentMatchId { get; set; }
        public int MatchId { get; set; }
        public int TournamentId { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
