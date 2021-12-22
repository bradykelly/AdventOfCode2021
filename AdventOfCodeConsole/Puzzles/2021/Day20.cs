using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day20: IDay
{
    public static int DayNumber => 20;

    private static (string algorithm, List<Point> imagePixels) ParseInput(string input)
    {
        var inputSplit = input.Split("\n\n");
        var algorithm = inputSplit[0].Replace("\n", "");
        var imageRows = inputSplit[1].Split("\n");

        var imagePixels = new List<Point>();
        for (var row = 0; row < imageRows.Length; row++)
        {
            for (var col = 0; col < imageRows[row].Length; col++)
            {
                if (imageRows[row][col] == '#')
                {
                    imagePixels.Add(new Point(row, col));
                }
            }
        }

        return (algorithm, imagePixels);
    }

    private static List<Point> GetNeighbours(Point centre)
    {
        var deltas = new List<(int dy, int dx)>
        {
            (-1, -1), (-1, 0), (-1, +1),
            (0, -1), (0, 0), (0, +1),
            (+1, -1), (+1, 0), (+1, +1)
        };

        var retList = new List<Point>();
        foreach ((int dy, int dx) in deltas)
        {
            retList.Add(new Point(centre.X + dy, centre.Y + dx));
        }

        return retList;
    }

    public ulong Part1(string input)
    {
        var (algo, image) = ParseInput(input);

        var theGreatVoid = algo[0];

        var (borderMinY, borderMaxY, borderMinX, borderMaX) = (
            image.Select(p => p.Y).Min() - 1, 
            image.Select(p => p.Y).Max() + 1, 
            image.Select(p => p.X).Min() - 1,
            image.Select(p => p.X).Max() + 1);

        for (var row = borderMinY; row <= borderMaxY; row++)
        {
            for (var col = borderMinX; col <= borderMaxY; col++)
            {
                var neighbs = GetNeighbours(new Point(row, col));
                var binString = "";
                foreach (var n in neighbs)
                {
                    binString += image.Contains(n) ? "1" :"0";
                }

                var address = Convert.ToInt32(binString, 2);
            }
        }




        return 0;
    }


}
