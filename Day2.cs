using System;
using System.Collections.Generic;
using System.Linq;

// 2-4 p: vpkpp

namespace advent_of_code_2020
{
    public class Day2
    {
        private List<string> _inputFile;
        private List<PasswordPolicy> _passwordList;

        public Day2()
        {
            _inputFile = Utilities.LoadFile("Data/Day2_Input.txt");
            LoadPasswords();
        }

        public int ProcessPart1()
        {
            return CountValidPasswords();
        }

        private class PasswordPolicy
        {
            public int MinCount;
            public int MaxCount;
            public char Character;
            public string Password;
        }

        private PasswordPolicy ParseRule(string ruleString)
        {
            var ruleList = ruleString.Replace(":", "").Split(" ");

            return new PasswordPolicy
            {
                MinCount = Convert.ToInt32(ruleList[0].Split("-")[0]),
                MaxCount = Convert.ToInt32(ruleList[0].Split("-")[1]),
                Character = Convert.ToChar(ruleList[1]),
                Password = ruleList[2]
            };
        }

        private void LoadPasswords()
        {
            _passwordList = _inputFile.Select(ParseRule).ToList();
        }

        private bool IsPasswordValidPart1(PasswordPolicy passwordPolicy)
        {
            return passwordPolicy.MinCount <= passwordPolicy.Password.Count(p => p == passwordPolicy.Character)
                   && passwordPolicy.Password.Count(p => p == passwordPolicy.Character) <= passwordPolicy.MaxCount;
        }

        private int CountValidPasswords()
        {
            var count = 0;
            foreach (var password in _passwordList)
            {
                if (IsPasswordValidPart2(password)) count++;
            }

            return count;
        }

        private bool IsPasswordValidPart2(PasswordPolicy pp)
        {
            return new List<char>
            {
                pp.Password[pp.MinCount - 1], 
                pp.Password[pp.MaxCount - 1]
            }.Count(c => c == pp.Character) == 1;
        }
        
    }
}