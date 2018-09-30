namespace Scorers
{
    public interface IScorer
    {
        /// <summary>
        /// Scores a number based on the scoring rules configured.
        /// </summary>
        /// <param name="number">Number to Score</param>
        /// <returns>Score</returns>
        string Score(int number);
    }
}