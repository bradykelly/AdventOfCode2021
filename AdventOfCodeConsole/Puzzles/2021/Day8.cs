using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day8 : IDay
    {
        private readonly Dictionary<string, int> _uniqueDigits = new();
        private readonly Dictionary<string, int> _allDigits = new();

        public Day8()
        {
            _uniqueDigits.Add("cf", 1);
            _uniqueDigits.Add("bcdf", 4);
            _uniqueDigits.Add("acf", 7);
            _uniqueDigits.Add("abcdefg", 8);

            foreach (var kv in _uniqueDigits)
            {
                _allDigits.Add(kv.Key, kv.Value);
            }

            _allDigits.Add("acdeg", 2);
            _allDigits.Add("acdfg", 3);
            _allDigits.Add("abdfg", 5);
            _allDigits.Add("abdefg", 6);
            _allDigits.Add("abcdfg", 9);
        }

        public ulong Part1(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var uniqueLengths = _uniqueDigits.Select(kv => kv.Key.Length);

            var totalUniques = 0;
            foreach (var line in lines)
            {
                var output = line.Split('|')[1];
                var uniquesInOutput = output.Split(" ").Count(od => od.Length is 2 or 3 or 4 or 7);
                totalUniques += uniquesInOutput;
            }

            return (ulong)totalUniques;
        }

        public ulong Part2(string input)
        {
            var bigTotal = 0;
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var perms = "abcdefg".Permutations();
            var maps = perms.Select(p => new string(p)).Select(perm => new[] { "abcdefg", perm }).ToArray();
            foreach (var line in lines)
            {
                var digitsIn = line.Split('|')[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string MapSortDigit(string digit, string[] map)
                {
                    var mapped = "";
                    foreach (var ch in digit)
                    {
                        var pos = map[0].IndexOf(ch);
                        mapped += map[1][pos];
                    }
                    return new string(mapped.OrderBy(ch => ch).ToArray());
                }

                var correctMap = new string[2];
                foreach (var map in maps)
                {
                    var mappedDigits = digitsIn.Select(digit => MapSortDigit(digit, map)).ToList();
                    var mapIsGood = mappedDigits.All(digit => _allDigits.ContainsKey(digit));
                    if (!mapIsGood) continue;
                    correctMap = map;
                    break;
                }
            }

            return (ulong)bigTotal;
        }
    }
}
