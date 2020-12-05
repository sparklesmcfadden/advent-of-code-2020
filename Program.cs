using System;

namespace advent_of_code_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Day4();
        }

        static void Day1()
        {
            var day1 = new Day1();
            var day1Result1 = day1.ProcessPart1();
            Console.WriteLine(day1Result1);

            var day1Result2 = day1.ProcessPart2();
            Console.WriteLine(day1Result2);
        }

        static void Day2()
        {
            var day2 = new Day2();
            var day2Result1 = day2.ProcessPart1();
            Console.WriteLine(day2Result1);
        }

        static void Day3()
        {
            var day3 = new Day3();
            var day3Result1 = day3.CountTrees();
            Console.WriteLine(day3Result1);
            var day3Result2 = day3.TestSlopes();
            Console.WriteLine(day3Result2);
        }

        static void Day4()
        {
            var day4 = new Day4();
            var part2Result = day4.CountValid();
            Console.WriteLine(part2Result);
            // Part 1 result = 226
        }
    }
}