using System;
using System.Collections.Generic;
using System.Linq;
using Scorers.Models;

namespace Scorers.Extensions
{
    // TODO - Add documentation
    public static class IntegerExtensions
    {
        public static bool IsNaturalMultipleOf(this int number, int multiple)
        {
            if (number == 0)
            {
                return false;
            }

            return number%multiple == 0;
        }

        public static bool IsNaturalMultipleOfAny(this int number, IEnumerable<int> multiples)
        {
            if (number == 0 || multiples?.Any() != true)
            {
                return false;
            }

            return multiples.Any(x => number.IsNaturalMultipleOf(x));
        }
    }
}
