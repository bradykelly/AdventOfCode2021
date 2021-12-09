using System.Reflection;
using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

// BKTODO Get rid of wasteful ToLists

public class Day9 : IDay
{
    private static int[,] GetHeatMap(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var heatMap = new int[lines.Length, lines[0].Length];

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                heatMap[y, x] = line[x] - '0';
            }
        }

        return heatMap;
    }

    private static List<(int y, int x)> GetLowPoints(int[,] heatMap)
    {
        var rowCount = heatMap.GetLength(0);
        var colCount = heatMap.GetLength(1);

        var lowPoints = new List<(int y, int x)>();
        for (var y = 0; y < rowCount; y++)
        {
            for (var x = 0; x < colCount; x++)
            {
                var pointHeight = heatMap[y, x];
                var adjacents = GridMethods.AdjacentElements(heatMap, y, x).ToList();

                var isLow = true;
                foreach (var adj in adjacents)
                {
                    if (adj <= pointHeight)
                    {
                        isLow = false;
                        break;
                    }
                }

                if (isLow)
                {
                    lowPoints.Add((y, x));
                }
            }
        }

        return lowPoints;
    }

    private bool PointInBasin(Point point, List<List<Point>> basins)
    {
        return false;
    }

    private List<Point> GetBasinPoints(int[,] array, Point point, List<List<Point>> basins)
    {
        var basinPoints = new List<Point>();

        //foreach (var adj in EnumerableMatrixFunctions.AdjacentElements(array, point.Y, point.X))
        //{
        //    if (array[adj.Y, adj.X] == 9 || array[adj.Y, adj.X] < array[point.Y, point.X] || PointInBasin(adj, basins))
        //        return basinPoints;
            
        //    var points = GetBasinPoints(array, point, basins);
        //    basinPoints.AddRange(points);
        //}

        return basinPoints;
    }

    public long Part1(string input)
    {
        int bigTotal = 0;
        var heatMap = GetHeatMap(input);

        var lows = GetLowPoints(heatMap);

        foreach (var point in lows)
        {
            bigTotal += heatMap[point.y, point.x] + 1;
        }
        return bigTotal;
    }

    public long Part2(string input)
    {
        var bigTotal = 0;

        //var heatMap = GetHeatMap(input);
        //var basins = new List<List<Point>>();

        //foreach (var lowPoint in GetLowPoints(heatMap))
        //{
        //    var basinPoints = GetBasinPoints(heatMap, lowPoint, basins);
        //    basins.Add(basinPoints);
        //}

        return bigTotal;
    }
}