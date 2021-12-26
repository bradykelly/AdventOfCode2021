using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Tools.AStar;

internal class AStarTest
{
    public static void DrawGrid(SquareGrid grid, AStarSearch aStar)
    {
        for (var y = 0; y < 10; y++)
        {
            for (var x = 0; x < 10; x++)
            {
                var id = new Tile(y, x);

                if (!aStar.CameFrom.TryGetValue(id, out var cursor))
                {
                    cursor = id;
                }

                if (cursor.X == x + 1)
                {
                    Console.Write("\u2192 ");
                }
                else if (cursor.X == x - 1)
                {
                    Console.Write("\u2190 ");
                }
                else if (cursor.Y == y + 1)
                {
                    Console.Write("\u2193 ");
                }
                else if (cursor.Y == y - 1)
                {
                    Console.Write("\u2191 ");
                }
                else
                {
                    Console.Write("* ");
                }
            }
            Console.WriteLine();
        }
    }

    public static void DoTest(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var grid = new SquareGrid(lines.LongLength, lines[0].LongCount());

        for (var y = 0; y < lines.LongLength; y++)
        {
            for (var x = 0; x < lines[0].LongCount(); x++)
            {
                grid[y, x].Content = lines[y][x];
            }
        }

        var aStar = new AStarSearch(grid, new Tile(0, 0), new Tile(9, 9));
        aStar.FindPath();
        DrawGrid(grid, aStar);
    }
}
