namespace Calculators
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public interface IRegexAdapter
    {
        /// <summary>
        /// Accepts a match pattern and using the Regex pattern and input string returns an Enumerable of matched Regex matches
        /// Regex is disposed once completed so the regular expressions are not cached
        /// </summary>
        /// <param name="matchPattern">Regex Pattern to Match</param>
        /// <param name="input">String to check</param>
        /// <returns>Enumerable of matched Regex matches</returns>
        IEnumerable<Match> Matches(string matchPattern, string input);
    }
}
