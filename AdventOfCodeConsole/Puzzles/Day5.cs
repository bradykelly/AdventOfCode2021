using System.Diagnostics;
using System.Linq;

namespace AdventOfCodeConsole.Puzzles;

public class Day5 : IDay
{
    private record Point
    {
        internal int X { get; init; }
        internal int Y { get; init; }
    }

    private record Line
    {
        internal Point Start { get; init; } = new Point();
        internal Point End { get; init; } = new Point();

        public List<Point> GetPoints(bool diagonals = false)
        {
            var points = new List<Point>();

            switch (diagonals)
            {
                // Is line south-east?
                case true when Start.X < End.X && Start.Y < End.Y:
                {
                    Debug.WriteLine("south-east");
                    var x = Start.X;
                    var y = Start.Y;
                    while (x <= End.X && y <= End.Y)
                    {
                        var point = new Point { X = x, Y = y };
                        points.Add(point);
                        x++;
                        y++;
                    }
                    return points;
                }

                // Is line south-west?
                case true when Start.X > End.X && Start.Y < End.Y:
                {
                    Debug.WriteLine("south-west");
                    var x = Start.X;
                    var y = Start.Y;
                    while (x >= End.X && y <= End.Y)
                    {
                        var point = new Point { X = x, Y = y };
                        points.Add(point);
                        x--;
                        y++;
                    }
                    return points;
                }

                // Is line north-east?
                case true when Start.X < End.X && Start.Y > End.Y:
                {
                    Debug.WriteLine("north-east");
                    var x = Start.X;
                    var y = Start.Y;
                    while (x <= End.X && y >= End.Y)
                    {
                        var point = new Point { X = x, Y = y };
                        points.Add(point);
                        y--;
                        x++;
                    }
                    return points;
                }

                // Is line north-west?
                case true when Start.X > End.X && Start.Y > End.Y:
                {
                    Debug.WriteLine("north-west");
                    var x = Start.X;
                    var y = Start.Y;
                    while (x >= End.X && y >= End.Y)
                    {
                        var point = new Point { X = x, Y = y };
                        points.Add(point);
                        x--;
                        y--;
                    }
                    return points;
                }
            }

            // Is line south?
            if (Start.X == End.X && Start.Y <= End.Y)
            {
                for (var y = Start.Y; y <= End.Y; y++)
                {
                    var point = new Point { X = Start.X, Y = y };
                    points.Add(point);
                }
                return points;
            }

            // Is line north?
            if (Start.X == End.X && Start.Y >= End.Y)
            {
                for (var y = Start.Y; y >= End.Y; y--)
                {
                    var point = new Point { X = Start.X, Y = y };
                    points.Add(point);
                }
                return points;
            }

            // Is line east?
            if (Start.X <= End.X && Start.Y == End.Y)
            {
                for (var x = Start.X; x <= End.X; x++)
                {
                    var point = new Point { X = x, Y = Start.Y };
                    points.Add(point);
                }
                return points;
            }

            // Is line west
            if (Start.X >= End.X && Start.Y == End.Y)
            {
                for (var x = Start.X; x >= End.X; x--)
                {
                    var point = new Point { X = x, Y = Start.Y };
                    points.Add(point);
                }
                return points;
            }

            return new List<Point>(0);
        }
    }

    private List<Line> ParsePointsAndLines(string input)
    {
        var lines = new List<Line>();

        var lineDefs = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (var def in lineDefs)
        {
            var pointDefs = def.Split("->", StringSplitOptions.TrimEntries);

            var startParts = pointDefs[0].Split(',');
            var endParts = pointDefs[1].Split(',');

            var start = new Point { X = int.Parse(startParts[0]), Y = int.Parse(startParts[1]) };
            var end = new Point { X = int.Parse(endParts[0]), Y = int.Parse(endParts[1]) };

            lines.Add(new Line { Start = start, End = end });
        }

        return lines;

    }

    public int Part1(string input)
    {
        var lines = ParsePointsAndLines(input);

        var pointCounts = new Dictionary<Point, int>();
        foreach (var line in lines)
        {
            foreach (var point in line.GetPoints())
            {
                if (!pointCounts.Keys.Contains(point))
                    pointCounts.Add(point, 0);
                pointCounts[point] += 1;
            }
        }

        return pointCounts.Values.Count(v => v >= 2);
    }

    public int Part2(string input)
    {
        var lines = ParsePointsAndLines(input);

        var pointCounts = new Dictionary<Point, int>();
        foreach (var line in lines)
        {
            foreach (var point in line.GetPoints(true))
            {
                if (!pointCounts.Keys.Contains(point))
                    pointCounts.Add(point, 0);
                pointCounts[point] += 1;
            }
        }

        return pointCounts.Values.Count(v => v >= 2);
    }
}
