using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Tools.AStar;

public class AStarSearch
{
    // Code from: https://www.redblobgames.com/pathfinding/a-star/implementation.html

    private readonly IWeightedGraph<Tile> _graph;
    private readonly Tile _start;
    private readonly Tile _goal;
    private readonly PriorityQueue<Tile, long> _frontier = new();
    private readonly Dictionary<Tile, long> _costSoFar = new();

    public Dictionary<Tile, Tile> CameFrom { get; } = new();


    public AStarSearch(IWeightedGraph<Tile> graph, Tile start, Tile goal)
    {
        _graph = graph;
        _start = start;
        _goal = goal;
    }

    private static long Heuristic(Tile a, Tile b)
    {
        return Math.Abs(a.Y - b.Y) + Math.Abs(a.X - b.X);
    }

    public void FindPath()
    {
        _frontier.Enqueue(_start, 0);
        CameFrom[_start] = _start;
        _costSoFar[_start] = 0;

        while (_frontier.Count > 0)
        {
            var current = _frontier.Dequeue();
            if (current == _goal)
            {
                break;
            }

            foreach(var next in _graph.Neighbours(current))
            {
                long newCost = _costSoFar[current] + _graph.Cost(current, next);

                if (!_costSoFar.ContainsKey(next) || newCost < _costSoFar[next])
                {
                    _costSoFar[next] = newCost;
                    long priority = newCost + Heuristic(next, _goal);
                    _frontier.Enqueue(next, priority);
                    CameFrom[next] = current;
                }
            }
        }
    }
}
