// -------------------------------------------------------------------------------------
// Defines FibonacciCombinations type
// Written by Kalyan <s.kalyanasundaram@gmail.com>
//
// This file is made available under terms of the GNU General Public License, version 2,
// or at your option, any later version, incorporated herein by reference.
// --------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FibClock
{
    public class FibonacciCombinations : IEnumerable<List<int>>
    {
        private List<int> avilableNumbers = new List<int> { 1, 1, 2, 3, 5 };
        private int targetValue;
        private List<List<int>> results = new List<List<int>>();

        public FibonacciCombinations(int targetValue) : this(targetValue, new List<int>())
        {
        }

        public FibonacciCombinations(int targetValue, List<int> excludeNumbers)
        {
            Debug.Assert(targetValue < 12, "Fibonacci Number overflow, send number smaller than 12");

            this.targetValue = targetValue;
            excludeNumbers.ForEach(x => avilableNumbers.Remove(x));
        }

        public static void print(List<int> numbers)
        {
            Console.Write('{');
            foreach (var number in numbers)
            {
                Console.Write(number + ",");
            }
            Console.Write('}');
        }

        public IEnumerator<List<int>> GetEnumerator()
        {
            Solve(0, new List<int>(), avilableNumbers);

            foreach (var result in results)
            {
                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Solve(int total, List<int> result, List<int> available)
        {
            if (total == targetValue)
            {
                bool exists = false;
                foreach (var existingResult in results)
                {
                    if (Enumerable.SequenceEqual(existingResult.OrderBy(x => x), result.OrderBy(y => y)))
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    results.Add(result);
                }
            }

            foreach (var number in available)
            {
                if (total + number <= targetValue)
                {
                    total += number;

                    var newResult = new List<int>(result);
                    newResult.Add(number);

                    var newAvailable = new List<int>(available);
                    newAvailable.Remove(number);

                    Solve(total, newResult, newAvailable);

                    total -= number;
                }
            }
        }
    }
}
