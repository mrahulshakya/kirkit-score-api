using System;

namespace Kirkit.Score.Logic
{
    public class ScoreBoard
    {
        public ScoreBoard()
        {
        }

        public int PkScoreBoard { get; set; }
        public int Fkmatch { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
        public bool IsComplete { get; set; }
    }
}
