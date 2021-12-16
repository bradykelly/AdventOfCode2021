using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021
{
    public class Day12: IDay
    {
        public long Part1(string input)
        {
            var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var graph = new Graph();
            foreach (var line in lines)
            {
                var edgeSplit = line.Split('-');
                graph.AddEdge(edgeSplit[0], edgeSplit[1]);
            }
            
            graph.FindAllPaths(new Node("start"), new Node("end"));

            return 0;
        }

        public long Part2(string input)
        {
            return 0;
        }
    }
}
