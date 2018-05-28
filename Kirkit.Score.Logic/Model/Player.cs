using System;

namespace Kirkit.Score.Logic
{
    public class Player
    {
        public Player()
        {
        }

        public int PkPlayer { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CoolName { get; set; }
        public string Email { get; set; }
        public decimal? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public DateTime? DtCreated { get; set; }
        public DateTime? DtUpdated { get; set; }
        public bool? IsActive { get; set; }
    }
}
