using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class BallType : LogicBase
    {
        [Required]
        public int BallTypeId { get; set; }

        public string Detail { get; set; }

        [Required]
        public bool IsLegal { get; set; }

        [Required]
        public bool ExtraRun { get; set; }
    }
}