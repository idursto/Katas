namespace Calculators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class RegexAdapter : IRegexAdapter
    {
        public IEnumerable<Match> Matches(string matchPattern, string input)
        {
            return new Regex(matchPattern).Matches(input)?.OfType<Match>();
        }
    }
}
