using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeConsole.Tools.AStar;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day15: IDay
{
    public static int DayNumber => 15;

    public ulong Part1(string input)
    {
        var astar = new AStarPathFinder(input);
        astar.FindPath((0, 0), (9, 9));

        return 0;
    }
}
