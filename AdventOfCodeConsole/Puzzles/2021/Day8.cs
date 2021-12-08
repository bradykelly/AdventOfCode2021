using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day8 : IDay
    {
        private Dictionary<int, string> _uniqueDigits = new();

        public Day8()
        {
            _uniqueDigits.Add(1, "cf");
            _uniqueDigits.Add(4, "bcdf");
            _uniqueDigits.Add(7, "acf");
            _uniqueDigits.Add(8, "abcdefg");
        }

        public long Part1(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var uniqueLengths = _uniqueDigits.Select(kv => kv.Value.Length);

            var totalUniques = 0;
            foreach (var line in lines)
            {
                var output = line.Split('|', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)[1];
                var uniquesInOutput = output.Split(" ").Count(od => uniqueLengths.Contains(od.Length));
                totalUniques += uniquesInOutput;
            }

            return totalUniques;
        }

        public long Part2(string input)
        {
            return 0;
        }
    }
}
