namespace Calculators
{
    public interface IStringCalculator
    {
        /// <summary>
        /// Ignore integers sent in above this value in the sum of the return.  Default is 1000
        /// </summary>
        int AddIntMax { get; set; }

        /// <summary>
        /// Adds a string of numbers seperated by a delimiter(s).
        /// </summary>
        /// <param name="numbers">String of Numbers seperated by a delimiter(s).</param>
        /// <returns>Sum of string of numbers</returns>
        int Add(string numbers);
    }
}
