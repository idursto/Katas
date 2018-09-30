namespace Calculators
{
    using System;
    using System.Linq;
    using Calculators.Extensions;
    using Newtonsoft.Json;

    public class StringCalculator : IStringCalculator
    {
        public StringCalculator(IDelimiterManager delimiterManager)
        {
            DelimiterManager = delimiterManager ??
                throw new ArgumentNullException(nameof(delimiterManager));
        }

        public int AddIntMax { get; set; } = 1000;

        private IDelimiterManager DelimiterManager { get; }

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            string[] delimiters;

            if (DelimiterManager.ContainsCustomDelimiters(numbers))
            {
                delimiters = DelimiterManager.GetCustomDelimiters(numbers);
                numbers = DelimiterManager.RemoveDelimitersFromString(numbers);
            }
            else
            {
                delimiters = DelimiterManager.StandardDelimiters;
            }

            var stringNumbers = numbers.Split(delimiters, StringSplitOptions.None);

            var numberArray = stringNumbers.TryParseInt32();

            if (numberArray.Any(x => x < 0))
            {
                throw new InvalidOperationException(
                    JsonConvert.SerializeObject(
                        new { Message = "negatives not allowed", InvalidNegativeNumbers = numberArray.Where(x => x < 0) }));
            }

            return numberArray
                .Where(x => x < AddIntMax)
                .Sum();
        }
    }
}
