using System;

namespace Kirkit.Score.Model.Logic
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
