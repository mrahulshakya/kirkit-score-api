using System;

namespace Kirkit.Score.Logic
{
    public class BallUpdate
    {
        public int PkBallUpdate { get; set; }
        public int FkScoreBoard { get; set; }
        public int FkBattingTeam { get; set; }
        public int FkBowlingTeam { get; set; }
        public int RunScored { get; set; }
        public int RunType { get; set; }
        public int BallType { get; set; }
        public bool WiketFallen { get; set; }
        public bool WicketType { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }

        //public Team FkBattingTeamNavigation { get; set; }
        //public Team FkBowlingTeamNavigation { get; set; }
        public ScoreBoard FkScoreBoardNavigation { get; set; }
    }
}
