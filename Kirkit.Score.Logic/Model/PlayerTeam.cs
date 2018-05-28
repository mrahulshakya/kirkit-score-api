using System;

namespace Kirkit.Score.Logic
{
    public class PlayerTeam
    {
        public int PkPlayerTeam { get; set; }
        public int? FkTeam { get; set; }
        public int? FkPlayer { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
