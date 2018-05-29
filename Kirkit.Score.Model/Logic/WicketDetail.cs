using System;

namespace Kirkit.Score.Model.Logic
{
    public class WicketDetail
    {
        public int WicketDetailId { get; set; }
        public int UpdatePerBallId { get; set; }
        public bool WicketType { get; set; }
        public string Details { get; set; }
        public int? WicketOwnerId { get; set; }
        public int? FielderId { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
