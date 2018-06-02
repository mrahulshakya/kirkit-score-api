using System;

namespace Kirkit.Score.Model.Logic
{
    public class TournamentMatch : LogicBase
    {
        public int TournamentMatchId { get; set; }
        public int MatchId { get; set; }
        public int TournamentId { get; set; }
    }
}
