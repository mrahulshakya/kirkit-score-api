using System;
using System.Collections.Generic;

namespace Kirkit.Score.Logic
{
    public class Team
    {
        public Team()
        {
        }

        public int PkTeam { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }

        //public ICollection<BallUpdate> BallUpdateFkBattingTeamNavigation { get; set; }
        //public ICollection<BallUpdate> BallUpdateFkBowlingTeamNavigation { get; set; }
        public ICollection<Match> MatchFkTeam1Navigation { get; set; }
        public ICollection<Match> MatchFkTeam2Navigation { get; set; }
        public ICollection<PlayerTeam> PlayerTeam { get; set; }
    }
}
