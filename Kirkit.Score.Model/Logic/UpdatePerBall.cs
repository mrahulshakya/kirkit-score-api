using System;

namespace Kirkit.Score.Model.Logic
{
    public class UpdatePerBall
    {
        public int UpdatePerBallId { get; set; }
        public int RunScored { get; set; }
        public int RunType { get; set; }
        public int BallType { get; set; }
        public bool WiketFallen { get; set; }
        public bool WicketType { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
