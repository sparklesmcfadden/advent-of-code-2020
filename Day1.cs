using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2020
{
    public class Day1
    {
        private readonly List<int> _inputFile;
        
        public Day1()
        {
            _inputFile = Utilities.LoadFile("Data/Day1_Input.txt").Select(i => Convert.ToInt32(i)).ToList();
        }

        private bool Is2020(List<int> input)
        {
            return input.Sum() == 2020;
        }

        public int ProcessPart1()
        {
            foreach (var a in _inputFile)
            {
                var match = _inputFile.Any(b => b == (2020 - a));
                if (match)
                {
                    return a * (2020 - a);
                }
            }

            return 0;
        }

        public int ProcessPart2()
        {
            for (int i = 0; i < _inputFile.Count(); i++)
            {
                for (int j = i + 1; j < _inputFile.Count(); j++)
                {
                    for (int k = j + 1; k < _inputFile.Count(); k++)
                    {
                        var intList = new List<int> {_inputFile[i], _inputFile[j], _inputFile[k]};
                        if (Is2020(intList))
                        {
                            return _inputFile[i] * _inputFile[j] * _inputFile[k];
                        }
                    }
                }
            }
            
            return 0;
        }
    }
}