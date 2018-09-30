using Scorers.Models;

namespace Scorers
{
    public interface IFizzBuzzScorer : IScorer
    {
        ScoringSettings ScoringSettings { get; set; }
    }
}
