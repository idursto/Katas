namespace Calculators.Models
{
    public class CustomDelimiterSettings
    {
        public static string[] DefaultDelimiters => new[] { ",", "\n" };

        public string StartTag { get; set; }

        public string StopTag { get; set; }

        public char LeadingCharacter { get; set; }

        public char TrailingCharacter { get; set; }

        public string MatchPattern { get; set; }
    }
}
