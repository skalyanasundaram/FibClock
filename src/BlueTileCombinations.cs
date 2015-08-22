// -------------------------------------------------------------------------------------
// Defines BlueTileCombinations type
// Written by Kalyan <s.kalyanasundaram@gmail.com>
//
// This file is made available under terms of the GNU General Public License, version 2,
// or at your option, any later version, incorporated herein by reference.
// --------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FibClock
{
    public class BlueTileCombinations : IEnumerable<List<int>>
    {
        private List<int> fibonacciNumbers = new List<int> { 1, 1, 2, 3, 5 };
        private List<List<int>> results = new List<List<int>>();

        private void Solve(List<int> result, List<int> available)
        {
            if (result.Count > 0)
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

            if (available.Count == 0)
            {
                return;
            }

            foreach (var number in available)
            {
                var newResult = new List<int>(result);
                newResult.Add(number);

                var newAvailable = new List<int>(available);
                newAvailable.Remove(number);

                Solve(newResult, newAvailable);
            }
        }

        public IEnumerator<List<int>> GetEnumerator()
        {
            Solve(new List<int>(), fibonacciNumbers);

            foreach (var result in results)
            {
                yield return result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
