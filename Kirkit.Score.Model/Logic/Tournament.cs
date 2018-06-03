using Kirkit.Score.Model.Logic.CustomVaildation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kirkit.Score.Model.Logic
{
    public class Tournament : LogicBase , IValidatableObject
    {
        public int TournamentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [FutureDate(6)]
        [Required]
        public DateTime? DtStartDate { get; set; }

        [Required]
        public DateTime? DtEndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DtEndDate < DtStartDate)
            {
                yield return new ValidationResult(errorMessage: "End date should be greater than start date", 
                    memberNames: new[] { nameof(DtEndDate) });
            }
        }
    }
}
