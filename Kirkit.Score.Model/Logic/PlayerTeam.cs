using System;

namespace Kirkit.Score.Model.Logic
{
    public class PlayerTeam : LogicBase
    {
        public int PlayerTeamId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
    }
}
