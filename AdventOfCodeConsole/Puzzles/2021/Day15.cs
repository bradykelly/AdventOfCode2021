using AdventOfCode.Graphs;
using AdventOfCode.Graphs.AStar;
using AdventOfCodeConsole.Tools;

namespace AdventOfCodeConsole.Puzzles._2021;

public class Day15: IDay
{
    public static int DayNumber => 15;

    private string CoordsToString(long y, long x)
    {
        return $"{y},{x}";
    }

    public ulong Part1(string input)
    {
        var graph = new Graph<Node>();

        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var array = new long[lines.Length, lines[0].Length];
        for (var y = 0; y < lines.Length; y++)
        {
            for (var x = 0; x < lines[0].Length; x++)
            {
                var centreNode = graph.AddNode(CoordsToString(y, x), lines[y][x], y, x);
                array[y,x] = lines[y][x];
                var neigbs = GridMethods.AdjacentPoints(array, y, x);
                foreach (var n in neigbs)
                {
                    var key = CoordsToString(n.Y, n.X);
                    var neighbourNode = graph.Nodes.ContainsKey(key) 
                        ? graph.Nodes[key] 
                        : graph.AddNode(key, lines[n.Y][(int)n.X], (int)n.Y, (int)n.X);
                    var riskHere = lines[centreNode.Y][centreNode.X] - '0';
                    var riskThere = lines[neighbourNode.Y][neighbourNode.X] - '0';
                    graph.AddDirectedEdge(centreNode, neighbourNode, (riskHere - riskThere) * -1);
                }
            }
        }

        Node start = graph.Nodes[CoordsToString(0, 0)];
        Node destination = graph.Nodes[CoordsToString(lines.Length - 1, lines[0].Length - 1)];

        Func<Node, Node, double> distance = (node1, node2) => node1.Adjacencies!.Cast<EdgeToNeighbour<Node>>()
            .Single(etn => etn.Neighbor.Key == node2.Key).Cost;

        Func<Node, double> estimation = (startNode) => 
            (((lines[startNode.Y][startNode.X] - '0') - (lines[destination.Y][destination.X] - '0')) * -1)
            * (Math.Abs(destination.Y - startNode.Y) + Math.Abs(destination.X - startNode.X));

        var thePath = AStarPathFinder.FindPath(start, destination, distance, estimation);


        return 0;
    }
}
