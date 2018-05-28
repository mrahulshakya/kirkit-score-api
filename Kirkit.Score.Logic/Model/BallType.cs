using System;

namespace Kirkit.Score.Logic
{
    public class BallType
    {
        public int PkBallType { get; set; }
        public string Detail { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
        public bool IsLegal { get; set; }
        public bool ExtraRun { get; set; }
    }
}
