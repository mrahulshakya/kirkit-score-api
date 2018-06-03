using Kirkit.Score.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirkit.Score.Data.Validation
{
    public class InningsValidator : IValidator<Innings>
    {
        public InningsValidator(ScoreContext context)
        {
            Context = context;
        }

        public ScoreContext Context { get; }

        public async Task<Dictionary<string, IList<string>>> Validate(Innings entity)
        {
            var res = new Dictionary<string, IList<string>>();
            // Validate the player id's.
            // Strike and non strike player should belong to the team.
            var isValidPlayerOnStrike = await Context.PlayerTeam.FirstOrDefaultAsync(x => x.PlayerId == entity.PlayeOnStrikeId 
            && x.TeamId == entity.BattingTeamId).ConfigureAwait(false);

            if (isValidPlayerOnStrike == null)
            {
                res[nameof(Innings.PlayeOnStrikeId)]
                    = new List<string> { "Player does not belong to batting team" };
            }

            var isValidPlayerOnNonStrike = await Context.PlayerTeam.FirstOrDefaultAsync(x => x.PlayerId == entity.PlayerOnNonStrikeId
            && x.TeamId == entity.BattingTeamId).ConfigureAwait(false);

            if (isValidPlayerOnNonStrike == null)
            {
                res[nameof(Innings.PlayerOnNonStrike)]
                    = new List<string> { "Player on on non strike does not belong to batting team" };
            }

            var isValidBaller = await Context.PlayerTeam.FirstOrDefaultAsync(x => x.PlayerId == entity.BallerId && x.TeamId == entity.BowlingTeamId);
            if(isValidBaller == null)
            {
                res[nameof(Innings.BallerId)]
            = new List<string> { "Baller does not belong to the balling team." };

            }

            return res.Any() ? res : null;
        }
    }
}
