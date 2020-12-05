using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_2020
{
    public class Day4
    {
        private List<string> _inputFile;
        private List<string> _rawPassports = new List<string>();
        private List<Passport> _passports = new List<Passport>();
        
        public Day4()
        {
            _inputFile = Utilities.LoadFile("Data/Day4_Input.txt");
            LoadPassports();
        }

        public int CountValid()
        {
            return _passports.Count(p => p.IsValid);
        }
        
        public void LoadPassports()
        {
            var passportString = "";
            var count = 0;
            
            foreach (var line in _inputFile)
            {
                count++;
                if (line != "")
                {
                    passportString += $" {line}";
                }
                else
                {
                    _rawPassports.Add(passportString);
                    passportString = "";
                }
                if (count == _inputFile.Count) _rawPassports.Add(passportString);
            }

            foreach (var raw in _rawPassports)
            {
                var passport = new Passport(raw);
                _passports.Add(passport);
            }
        }
    }

    public class Passport
    {
        public int BirthYear { get; set; }
        public int IssueYear { get; set; }
        public int ExpirationYear { get; set; }
        public int Height { get; set; }
        public string HeightUnit { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }
        public bool IsValid { get; set; } = false;
        public List<string> ValidationErrors { get; set; } = new List<string>();

        private string _rawPassport;

        public Passport(string rawPassport)
        {
            _rawPassport = rawPassport;
            ParseRawPassport();
            Validator();
        }

        private void ParseRawPassport()
        {
            var passwordParts = _rawPassport.Trim().Split(" ");
            foreach (var prop in passwordParts)
            {
                var propType = prop.Split(":")[0];
                var propValue = prop.Split(":")[1];

                switch (propType)
                {
                    case "byr":
                        BirthYear = Convert.ToInt32(propValue);
                        break;
                    case "iyr":
                        IssueYear = Convert.ToInt32(propValue);
                        break;
                    case "eyr":
                        ExpirationYear = Convert.ToInt32(propValue);
                        break;
                    case "hgt":
                        Height = Convert.ToInt32(Regex.Replace(propValue, "[^0-9.]", ""));
                        HeightUnit = Regex.Replace(propValue, "[0-9.]", "").ToLower();
                        break;
                    case "hcl":
                        HairColor = propValue;
                        break;
                    case "ecl":
                        EyeColor = propValue;
                        break;
                    case "pid":
                        PassportId = propValue;
                        break;
                    case "cid":
                        CountryId = propValue;
                        break;
                }
            }
        }

        private void Validator()
        {
            if (BirthYear == 0) ValidationErrors.Add("Invalid Birth Year");
            if (BirthYear < 1920 || BirthYear > 2002) ValidationErrors.Add("Birth Year out of rage");
            if (IssueYear == 0) ValidationErrors.Add("Invalid Issue Year");
            if (IssueYear < 2010 || IssueYear > 2020) ValidationErrors.Add("Issue Year out of range");
            if (ExpirationYear == 0) ValidationErrors.Add("Invalid Expiration Year");
            if (ExpirationYear < 2020 || ExpirationYear > 2030) ValidationErrors.Add("Expiration Year out of range");
            if (Height == 0) ValidationErrors.Add("Invalid Height");
            if (HeightUnit != "cm" && HeightUnit != "in") ValidationErrors.Add("Missing Height Unit");
            if (HeightUnit == "cm" && (Height < 150 || Height > 193)) ValidationErrors.Add("Height out of range (cm)");
            if (HeightUnit == "in" && (Height < 59 || Height > 76)) ValidationErrors.Add("Height out of range (in)");
            if (HairColor == null) ValidationErrors.Add("Invalid Hair color");
            if (HairColor != null && !HairColor.StartsWith("#")) ValidationErrors.Add("Hair color code missing #");
            if (HairColor != null && Regex.IsMatch(HairColor, "[g-z.]")) ValidationErrors.Add("Hair color code is not valid");
            if (HairColor != null && HairColor.Length != 7) ValidationErrors.Add("Hair color code is wrong length");
            if (EyeColor == null) ValidationErrors.Add("Invalid Eye color");
            if (!new List<string> {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(EyeColor))
                ValidationErrors.Add("Eye color is not a valid option");
            if (PassportId == null) ValidationErrors.Add("Invalid PassportId");
            if (PassportId != null && PassportId.Length != 9) ValidationErrors.Add("PassportId must be 9 characters");

            if (!ValidationErrors.Any()) IsValid = true;
        }
    }
}