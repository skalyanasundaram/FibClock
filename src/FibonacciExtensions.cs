// -------------------------------------------------------------------------------------
// Defines FibonacciExtensions type
// Written by Kalyan <s.kalyanasundaram@gmail.com>
//
// This file is made available under terms of the GNU General Public License, version 2,
// or at your option, any later version, incorporated herein by reference.
// --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace FibClock
{
    public static class FibonacciExtensions
    {
        public static int ToNumber(this List<int> numbers)
        {
            int result = 0;

            for (int index = 0; index < numbers.Count; index++)
            {
                result = result + (numbers[numbers.Count - index - 1] * (int)Math.Pow(10, index));
            }

            return result;
        }

        public static int Sum(this List<int> numbers)
        {
            var total = 0;
            numbers.ForEach(x => total += x);

            return total;
        }

        public static List<int> ToList(this int number)
        {
            List<int> result = new List<int>();

            while (number > 0)
            {
                result.Add(number % 10);
                number = number / 10;
            }

            return result;
        }
    }
}
