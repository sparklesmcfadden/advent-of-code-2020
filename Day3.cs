using System;
using System.Collections.Generic;

namespace advent_of_code_2020
{
    public class Day3
    {
        private List<string> _inputFile;
        
        public Day3()
        {
            _inputFile = Utilities.LoadFile("Data/Day3_Input.txt");
        }

        public long TestSlopes()
        {
            var slopes = new List<int[]>
            {
                new int[] {1, 1},
                new int[] {3, 1},
                new int[] {5, 1},
                new int[] {7, 1},
                new int[] {1, 2}
            };

            var resultList = new List<int>();

            foreach (var slope in slopes)
            {
                var treeCount = CountTreesAtSlope(slope[0], slope[1]);
                resultList.Add(treeCount);
            }

            long result = 1;
            foreach (var r in resultList)
            {
                result = result * r;
            }

            return result;
        }

        public int CountTreesAtSlope(int dX, int dY)
        {
            var count = 0;
            var x = 0;
            var y = 0;

            foreach (var row in _inputFile)
            {
                if (y % dY != 0)
                {
                    y++;
                    continue;
                }
                
                var charAtIndex = row[x];
                if (charAtIndex == '#') count++;
                
                var newX = x + dX;

                if (newX > row.Length - 1)
                {
                    newX = dX - (row.Length - x);
                }

                x = newX;
                y++;
            }

            return count;
        }

        public int CountTrees()
        {
            var count = 0;
            var x = 0;

            foreach (var row in _inputFile)
            {
                var charAtIndex = row[x];
                if (charAtIndex == '#') count++;
                
                var newX = x + 3;

                if (newX > row.Length - 1)
                {
                    newX = 3 - (row.Length - x);
                }

                x = newX;
            }

            return count;
        }
    }
}