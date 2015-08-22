// -------------------------------------------------------------------------------------
// Defines FibonacciClockHelper type
// Written by Kalyan <s.kalyanasundaram@gmail.com>
//
// This file is made available under terms of the GNU General Public License, version 2,
// or at your option, any later version, incorporated herein by reference.
// --------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace FibClock
{
    public class FibonacciClockHelper
    {
        private Dictionary<Color, SolidColorBrush> brushMap;
        private bool isTileOneUsed;
        private Dictionary<int, Action<SolidColorBrush>> map;

        public FibonacciClockHelper(Dictionary<int, Action<SolidColorBrush>> map, Dictionary<Color, SolidColorBrush> brushMap)
        {
            this.map = map;
            this.brushMap = brushMap;
        }

        public void SetTime(Tuple<int, int, int> tiles)
        {
            isTileOneUsed = false;

            ResetClock();
            SetColor(tiles.Item1, Colors.Blue);
            SetColor(tiles.Item2, Colors.Red);
            SetColor(tiles.Item3, Colors.Green);
        }

        private void ResetClock()
        {
            foreach (var tile in map.Values)
            {
                tile(this.brushMap[Colors.White]);
            }
        }

        private void SetColor(int tiles, Color color)
        {
            foreach (var tile in tiles.ToList())
            {
                var key = tile;
                if (tile == 1)
                {
                    if (isTileOneUsed)
                    {
                        key = 0;
                    }
                    else
                    {
                        isTileOneUsed = true;
                    }
                }

                map[key](this.brushMap[color]);
            }

        }
    }
}
