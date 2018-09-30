namespace Calculators
{
    using System;
    using System.Linq;
    using Calculators.Models;

    public class DelimiterManager : IDelimiterManager
    {
        public DelimiterManager(IRegexAdapter regexAdapter)
        {
            RegexAdapter = regexAdapter ??
                throw new ArgumentNullException(nameof(regexAdapter));
            StandardDelimiters = DefaultStandardDelimiters;
            CustomDelimiterSettings = DefaultCustomDelimiterSettings;
        }

        public static string[] DefaultStandardDelimiters => new[] { ",", "\n" };

        public static CustomDelimiterSettings DefaultCustomDelimiterSettings =>
            new CustomDelimiterSettings
            {
                StartTag = "//",
                StopTag = "\n",
                LeadingCharacter = '[',
                TrailingCharacter = ']',
                MatchPattern = "\\[.*?\\]"
            };

        public string[] StandardDelimiters { get; set; }

        public CustomDelimiterSettings CustomDelimiterSettings { get; set; }

        private IRegexAdapter RegexAdapter { get; }

        public bool ContainsCustomDelimiters(string inNumbers)
        {
            return inNumbers.StartsWith(CustomDelimiterSettings.StartTag);
        }

        public string[] GetCustomDelimiters(string inNumbers)
        {
            var delimiters =
                inNumbers.Substring(
                    CustomDelimiterSettings.StartTag.Length,
                    inNumbers.IndexOf(CustomDelimiterSettings.StopTag) - CustomDelimiterSettings.StartTag.Length);

            return delimiters.Length > 1 ? MatchDelimiters(delimiters) : new[] { delimiters };
        }

        public string RemoveDelimitersFromString(string numbers)
        {
            return numbers.Remove(0, numbers.IndexOf(CustomDelimiterSettings.StopTag));
        }

        private string[] MatchDelimiters(string delimiterString)
        {
            var regexMatches =
                RegexAdapter.Matches(CustomDelimiterSettings.MatchPattern, delimiterString);
            return regexMatches
                .Select(match => match.Value?
                    .TrimStart(CustomDelimiterSettings.LeadingCharacter).TrimEnd(CustomDelimiterSettings.TrailingCharacter))
                .ToArray();
        }
    }
}
