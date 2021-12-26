using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day13 : IDay
{
    private static List<Point> GetPointsList(string input)
    {
        var points = new List<Point>();
        var pairs = input.Split('\n', StringSplitOptions.RemoveEmptyEntries).Where(p => !p.StartsWith("fold"));
        foreach (var pair in pairs)
        {
            var pairSplit = pair.Split(',');
            points.Add(new Point { X = int.Parse(pairSplit[0]), Y = int.Parse(pairSplit[1]) });
        }
        return points;
    }

    private static List<(char, int)> GetFoldInstructions(string input)
    {
        var folds = new List<(char, int)>();
        var instructions = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Where(p => p.StartsWith("fold"))
            .Select(p => p.Replace("fold along ", ""));
        foreach (var inst in instructions)
        {
            var instSplit = inst.Split('=');
            folds.Add((instSplit[0][0], int.Parse(instSplit[1])));
        }

        return folds;
    }

    private static void FoldUp(ref List<Point> points, int foldLineY)
    {
        var pointsToMove = points.Where(p => p.Y > foldLineY).ToList();
        foreach (var oldPoint in pointsToMove)
        {
            var newY = foldLineY - (oldPoint.Y - foldLineY);
            if (newY < 0) continue;
            points.Add(new Point(newY, oldPoint.X));
            points.Remove(oldPoint);
        }
        points = points.Distinct().ToList();
    }

    private static void FoldLeft(ref List<Point> points, int foldLineX)
    {
        var pointsToMove = points.Where(p => p.X > foldLineX).ToList();
        foreach (var oldPoint in pointsToMove)
        {
            var newX = foldLineX - (oldPoint.X - foldLineX);
            if (newX < 0) continue;
            points.Add(new Point { X = newX, Y = oldPoint.Y });
            points.Remove(oldPoint);
        }
        points = points.Distinct().ToList();
    }

    public static int DayNumber => 13;

    public ulong Part1(string input)
    {
        var points = GetPointsList(input);

        var foldLineX = 655;

        FoldLeft(ref points, foldLineX);

        return (ulong)points.Count();
    }

    public ulong Part2(string input)
    {
        var points = GetPointsList(input);
        var folds = GetFoldInstructions(input);
        foreach (var fold in folds)
        {
            if (fold.Item1 == 'x')
            {
                FoldLeft(ref points, fold.Item2);
                continue;
            }

            if (fold.Item1 == 'y')
            {
                FoldUp(ref points, fold.Item2);
            }
        }

        var maxY = points.Select(p => p.Y).Max();
        var maxX = points.Select(p => p.X).Max();

        for (var y = 0; y < maxY + 5; y++)
        {
            for (var x = 0; x < maxX + 5; x++)
            {
                var point = new Point(y, x);
                Console.Write(points.Contains(point) ? "#" : ".");
            }
            Console.WriteLine();
        }

        //Console.ReadLine();

        return (ulong)points.Count();
    }
}