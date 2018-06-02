using System;

namespace Kirkit.Score.Model.Logic
{
    public class WicketDetail : LogicBase
    {
        public int WicketDetailId { get; set; }
        public int PerBallUpdateId { get; set; }
        public bool WicketType { get; set; }
        public string Details { get; set; }
        public int? WicketOwnerId { get; set; }
        public int? FielderId { get; set; }
    }
}
