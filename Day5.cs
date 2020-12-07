using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace advent_of_code_2020
{
    public class Day5
    {
        private List<string> _inputFile;
        private readonly int[] _startRowRange = Enumerable.Range(0, 128).ToArray();
        private readonly int[] _startSeatRange = Enumerable.Range(0, 8).ToArray();
        private List<int> _seatIds = new List<int>();

        public Day5()
        {
            _inputFile = Utilities.LoadFile("Data/Day5_Input.txt");
            ProcessPasses();
        }

        private int[] SplitRange(char splitType, int[] currentRange)
        {
            var rangeLength = currentRange.Length / 2;
            var newRange = splitType switch
            {
                'F' => currentRange.Take(rangeLength),
                'L' => currentRange.Take(rangeLength),
                'B' => currentRange.Skip(rangeLength),
                'R' => currentRange.Skip(rangeLength),
                _ => currentRange
            };

            return newRange.ToArray();
        }

        private int ProcessBoardingPass(string pass)
        {
            var rowCode = pass[..7];
            var seatCode = pass[7..];
            var rowResult = _startRowRange;
            var seatResult = _startSeatRange;

            foreach (var split in rowCode)
            {
                rowResult = SplitRange(split, rowResult);
            }

            var row = rowResult[0];
            
            foreach (var split in seatCode)
            {
                seatResult = SplitRange(split, seatResult);
            }

            var seat = seatResult[0];

            return GetSeatId(row, seat);
        }

        private int GetSeatId(int row, int seat)
        {
            return row * 8 + seat;
        }

        public void ProcessPasses()
        {
            
            foreach (var pass in _inputFile)
            {
                var seatId = ProcessBoardingPass(pass);
                _seatIds.Add(seatId);
            }
        }

        public int FindHighestSeatId()
        {
            return _seatIds.Max();
        }

        public int FindMySeat()
        {
            for (int i = 1; i < _seatIds.Count; i++)
            {
                var thisSeat = _seatIds[i];
                var prevSeat = thisSeat - 1;
                var nextSeat = thisSeat + 1;
                if (!_seatIds.Contains(nextSeat))
                {
                    return nextSeat;
                }
            }

            return 0;
        }
    }
}