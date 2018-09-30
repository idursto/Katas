using System.Linq;
using Scorers.Models;
using Scorers.Extensions;

namespace Scorers
{
    public class FizzBuzzScorer : IFizzBuzzScorer
    {
        /// <summary>
        /// Scorer for the FizzBuzz game.  Uses standard scoring rules unless custom rules are specified.
        /// </summary>
        /// <param name="scoringSettings">Custom Scoring Rules</param>
        public FizzBuzzScorer(ScoringSettings scoringSettings = null)
        {
            ScoringSettings = scoringSettings ?? ScoringSettings.DefaultScoringSettings;
        }

        public ScoringSettings ScoringSettings { get; set; }

        /// <summary>
        /// Scores a number based on the FizzBuzz scoring rules configured.
        /// </summary>
        /// <param name="number">Number to Score</param>
        /// <returns>FizzBuzz score</returns>
        public string Score(int number)
        {
            if (number.IsNaturalMultipleOfAny(ScoringSettings.ScoringMultiples))
            {
                var fizzBuzzScore = string.Empty;
                foreach (var scoringRule in ScoringSettings?.ScoringRules.OrderBy(x => x.Multiple))
                {
                    if (number.IsNaturalMultipleOf(scoringRule.Multiple))
                    {
                        fizzBuzzScore += $"{scoringRule.Score} ";
                    }

                }

                return fizzBuzzScore.Trim();
            }

            return number.ToString();
        }
    }
}
