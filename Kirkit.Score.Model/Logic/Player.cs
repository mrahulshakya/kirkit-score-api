using System;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Player : LogicBase
    {
        public int PlayerId { get; set; }
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string CoolName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public long PhoneNumber { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }
    }
}