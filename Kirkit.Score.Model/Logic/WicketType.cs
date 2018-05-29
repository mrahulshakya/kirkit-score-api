using System;

namespace Kirkit.Score.Model.Logic
{
    public class WicketType
    {
        public int WicketTypeId { get; set; }
        public string Detail { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
