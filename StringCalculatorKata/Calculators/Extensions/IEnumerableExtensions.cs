namespace Calculators.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Casts the elements of an IEnumerable to a 32-bit integer.  If the elements are not castable they are returned as 0.
        /// </summary>
        /// <param name="source">IEnumerable that contains the elements to be cast to a 32-bit integer</param>
        /// <returns>IEnumerable of casted 32-bit integers.  Failed casts return as 0.</returns>
        public static IEnumerable<int> TryParseInt32(this IEnumerable<string> source)
        {
            IEnumerable<int> castedSource = source as IEnumerable<int>;
            if (castedSource != null)
            {
                return castedSource;
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return TryParseInt32Iterator(source);
        }

        /// <summary>
        /// Tries to cast to a 32-bit integer returns 0 if the cast fails
        /// </summary>
        /// <param name="source">IEnumerable that contains the elements to be parsed to a 32-bit integer</param>
        /// <returns>Collection of casted strings to integers</returns>
        public static IEnumerable<int> TryParseInt32Iterator(IEnumerable<string> source)
        {
            foreach (string @string in source)
            {
                yield return int.TryParse(@string, out int parsedInt) ? parsedInt : 0;
            }
        }
    }
}
