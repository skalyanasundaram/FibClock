// -------------------------------------------------------------------------------------
// Defines FibonacciResolver type
// Written by Kalyan <s.kalyanasundaram@gmail.com>
//
// This file is made available under terms of the GNU General Public License, version 2,
// or at your option, any later version, incorporated herein by reference.
// --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FibClock
{
    public class FibonacciResolver
    {
        private const int MaxHour = 12;
        private const int MaxMinute = 60;

        private static Dictionary<string, Dictionary<int, Dictionary<int, List<int>>>> solutions = new Dictionary<string, Dictionary<int, Dictionary<int, List<int>>>>();

        public FibonacciResolver()
        {
            GenerateAllCombination();
        }

        public Tuple<int, int, int> GetTileColors(int hour, int minute)
        {
            Debug.Assert(hour < MaxHour, "Hour hand can not be greater than 11");
            Debug.Assert(minute < MaxMinute, "Minute hand can not be greater than 59");
            Debug.Assert(solutions.Count > 0, "Solutions are not generated");

            minute = minute / 5;
            
            Random random = new Random();
            var key = hour + ":" + minute;

            var blueResults = solutions[key];
            var blue = new List<int>(blueResults.Keys)[random.Next(blueResults.Keys.Count)];

            // Hour
            var redResults = blueResults[blue];
            var red = new List<int>(redResults.Keys)[random.Next(redResults.Keys.Count)];

            // Minute
            var greenResults = redResults[red];
            var green = greenResults[random.Next(greenResults.Count)];

            return new Tuple<int, int, int>(blue, red, green);
        }

        private void GenerateAllCombination()
        {
            solutions.Clear();

            for (int hour = 0; hour < MaxHour; hour++)
            {
                for (int minute = 0; minute < MaxMinute; minute += 5)
                {
                    var minuteHand = minute / 5;
                    var result = new Dictionary<int, Dictionary<int, List<int>>>();

                    if (hour + minuteHand <= MaxHour)
                    {
                        var combination = GenerateFibonacciCombinations(hour, minuteHand);
                        if (combination.Count > 0)
                        {
                            // No Blue tile combination
                            result.Add(0, combination);
                        }
                    }

                    foreach (var blueTiles in new BlueTileCombinations())
                    {
                        var totalBlueTilesSum = blueTiles.Sum();

                        // Check if the number of blue tile is sufficient to solve the problem
                        if (hour + minuteHand - (totalBlueTilesSum * 2) <= MaxHour)
                        {
                            // Generate combination without occupied blue tiles
                            var combination = GenerateFibonacciCombinations(hour - totalBlueTilesSum, minuteHand - totalBlueTilesSum, blueTiles);

                            if (combination.Count > 0)
                            {
                                // Blue tiles combination
                                result.Add(blueTiles.ToNumber(), combination);
                            }
                        }
                    }

                    if (result.Count > 0)
                    {
                        solutions.Add(hour + ":" + minuteHand, result);
                    }
                }
            }
        }

        private Dictionary<int, List<int>> GenerateFibonacciCombinations(int hour, int minute)
        {
            return GenerateFibonacciCombinations(hour, minute, new List<int>());
        }

        private Dictionary<int, List<int>> GenerateFibonacciCombinations(int hour, int minute, List<int> exclude)
        {
            Debug.Assert(hour + minute <= 12, "Fibonacci Number overflow, sum of hour and minute hand should be smaller than 12");

            var result = new Dictionary<int, List<int>>();

            foreach (var hourResult in new FibonacciCombinations(hour, exclude))
            {
                int key = hourResult.ToNumber();
                List<int> combinations = new List<int>();

                var occupiedTiles = new List<int>(hourResult);
                occupiedTiles.AddRange(exclude);

                foreach (var minuteResult in new FibonacciCombinations(minute, occupiedTiles))
                {
                    //Console.Write("[" + key);
                    //FibonacciCombinations.print(hourResult);
                    //Console.Write(":");
                    //FibonacciCombinations.print(minuteResult);
                    //Console.Write(minuteResult.ToNumber() + "] ");
                    combinations.Add(minuteResult.ToNumber());
                }

                if (combinations.Count > 0)
                {
                    //Console.WriteLine("");
                    result.Add(key, combinations);
                }
            }

            return result;
        }
    }
}
