namespace Calculators
{
    using Calculators.Models;

    public interface IDelimiterManager
    {
        /// <summary>
        /// Standard Delimiters.  Default Standard Delimiters are "," & "\n"
        /// </summary>
        string[] StandardDelimiters { get; set; }

        /// <summary>
        /// Custom Delimiter Settings.  Default Custom Delimiter Settings are:
        ///
        /// StartTag = "//"
        /// StopTag = "\n"
        /// LeadingCharacter = '['
        /// TrailingCharacter = ']'
        /// MatchPattern : Regex("\\[.*?\\]"):
        ///     \\[ <- Match on '['
        ///     .*? <- Match any sequence of characters
        ///     \\] <- Match on ']'
        /// </summary>
        CustomDelimiterSettings CustomDelimiterSettings { get; set; }

        /// <summary>
        /// Checks if a string contains custom delimiters in it
        /// </summary>
        /// <param name="input">String to check for delimiters</param>
        /// <returns>True if the string contains custom delimiters</returns>
        bool ContainsCustomDelimiters(string input);

        /// <summary>
        /// Retrieves delimiters contained in string
        /// </summary>
        /// <param name="input">string with delimiters</param>
        /// <returns>string array containing custom delimiters</returns>
        string[] GetCustomDelimiters(string input);

        /// <summary>
        /// Removes specified custom delimiters from string
        /// </summary>
        /// <param name="input">string input</param>
        /// <returns>input string without custom delimiters</returns>
        string RemoveDelimitersFromString(string input);
    }
}
