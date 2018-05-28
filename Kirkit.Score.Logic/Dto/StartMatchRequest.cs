using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Logic.Dto
{
    public class StartMatchRequest
    {
        /// <summary>
        /// Name of the first team.
        /// </summary>
        [Required]
        public int BattingTeamId { get; set; }

        /// <summary>
        /// Get or set the batsman on  strike.
        /// </summary>
        [Required]
        public int StrikerId { get; set; }

        /// <summary>
        /// Get or set the batmans on non-strike.
        /// </summary>
        [Required]
        public int NonStrikerId { get; set; }

        /// <summary>
        /// Id of the second team.
        /// </summary>
        [Required]
        public int BallingTeamId { get; set; }

        /// <summary>
        /// Get the name of the baller.
        /// </summary>
        [Required]
        public int BallerId { get; set; }
    }
}
