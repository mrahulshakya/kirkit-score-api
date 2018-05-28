using System;

namespace Kirkit.Score.Logic
{
    public class PlayerStrike
    {
        public int PkPlayerStrike { get; set; }
        public int Fkmatch { get; set; }
        public int BattingStrikerId { get; set; }
        public int BattingNonStrikerId { get; set; }
        public int BallerId { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
