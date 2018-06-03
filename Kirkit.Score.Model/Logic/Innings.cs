using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Innings : LogicBase, IValidatableObject
    {
        public int InningsId { get; set; }
        public string Name { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BattingTeamId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BowlingTeamId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int PlayeOnStrikeId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int PlayerOnNonStrikeId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int BallerId { get; set; }

        [Range(0, Int32.MaxValue)]
        public int TotalScoreId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(PlayeOnStrikeId == PlayerOnNonStrikeId)
            {
                    yield return new ValidationResult(errorMessage: "Player on string and non strike should be different.",
                        memberNames: new[] { nameof(PlayerOnNonStrikeId) });
            }

            if (BattingTeamId == BowlingTeamId)
            {
                yield return new ValidationResult(errorMessage: "Opponent teamsm should be different.",
                    memberNames: new[] { nameof(BowlingTeamId) });
            }

            if (PlayerOnNonStrikeId == BallerId || PlayeOnStrikeId == BallerId)
            {
                yield return new ValidationResult(errorMessage: "Baller should not be from the same team.",
                    memberNames: new[] { nameof(BallerId) });
            }
        }
    }
}