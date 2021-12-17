﻿using AdventOfCodeConsole.Tools;
using System.Diagnostics;

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

    private static List<Point> GetLowPoints(int[,] heatMap)
    {
        var rowCount = heatMap.GetLength(0);
        var colCount = heatMap.GetLength(1);

        var lowPoints = new List<Point>();
        for (var y = 0; y < rowCount; y++)
        {
            for (var x = 0; x < colCount; x++)
            {
                var pointHeight = heatMap[y, x];
                var adjacents = GridMethods.AdjacentPoints(heatMap, y, x).ToList();

                var isLow = true;
                foreach (var adj in adjacents)
                {
                    if (heatMap[adj.Y, adj.X] <= pointHeight)
                    {
                        isLow = false;
                        break;
                    }
                }

                if (isLow)
                {
                    lowPoints.Add(new Point(y, x));
                }
            }
        }

        return lowPoints;
    }

    private bool PointInBasin(Point point)
    {
        foreach (var basin in basins)
            foreach (var bp in basin)
                if (bp.Y == point.Y && bp.X == point.X)
                    return true;
        return false;
    }

    private List<List<Point>> basins = new List<List<Point>>();

    private void GetBasinPoints(int[,] array, Point point, List<Point> basin)
    {
        var neighbours = GridMethods.AdjacentPoints(array, point.Y, point.X).ToList();
        foreach (var adj in neighbours)
        {
            if (array[adj.Y, adj.X] == 9 || PointInBasin(adj))
                continue;

            basin.Add(adj);
            GetBasinPoints(array, adj, basin);
        }
    }

    public long Part1(string input)
    {
        int bigTotal = 0;
        var heatMap = GetHeatMap(input);

        var lows = GetLowPoints(heatMap);

        foreach (var point in lows)
        {
            bigTotal += heatMap[point.Y, point.X] + 1;
        }
        return bigTotal;
    }

    public long Part2(string input)
    {
        var bigTotal = 0;

        var heatMap = GetHeatMap(input);

        foreach (var lowPoint in GetLowPoints(heatMap))
        {
            var basin = new List<Point> { lowPoint };
            basins.Add(basin);
            GetBasinPoints(heatMap, lowPoint, basin);
        }

        var largest = basins.OrderByDescending(b => b.Count).Take(3).ToList();

        return largest[0].Count * largest[1].Count * largest[2].Count;
    }
}