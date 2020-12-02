using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2020
{
    public class Utilities
    {
        public static string LoadCsvFile(string path)
        {
            var file = File.ReadAllLines(path);
            return file[0];
        }

        public static List<string> LoadFile(string path)
        {
            var file = File.ReadAllLines(path);
            return file.ToList();
        }
    }
}