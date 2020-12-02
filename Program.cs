using System;

namespace advent_of_code_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1();
        }

        static void Day1()
        {
            var day1 = new Day1();
            var day1Result1 = day1.ProcessPart1();
            Console.WriteLine(day1Result1);

            var day1Result2 = day1.ProcessPart2();
            Console.WriteLine(day1Result2);
        }
    }
}