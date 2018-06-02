using System;

namespace Kirkit.Score.Model.Logic
{
    public class PerBallUpdate : LogicBase
    {
        public int PerBallUpdateId { get; set; }
        public int InningsId { get; set; }
        public int RunScored { get; set; }
        public int RunType { get; set; }
        public int BallType { get; set; }
        public bool WiketFallen { get; set; }
        public bool WicketType { get; set; }
     }
}
