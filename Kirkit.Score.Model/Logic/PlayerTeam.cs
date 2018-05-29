using System;

namespace Kirkit.Score.Model.Logic
{
    public class PlayerTeam
    {
        public int PlayerTeamId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
