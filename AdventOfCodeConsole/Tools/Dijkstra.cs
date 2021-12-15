using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeConsole.Tools;

// How to use
//Dijkstra d = new Dijkstra(_edges, _nodes);
//d.calculateDistance(_dictNodes["A"]);
//List<Node> path = d.getPathTo(_dictNodes["C"]);

class Dijkstra
{
    private List<Node> _nodes;
    private List<Edge> _edges;
    private List<Node?> _basis;
    private Dictionary<string, double> _dist;
    private Dictionary<string, Node?> _previous;

    public Dijkstra(List<Edge> edges, List<Node> nodes)
    {
        _edges = edges;
        _nodes = nodes;
        _basis = new List<Node?>();
        _dist = new Dictionary<string, double>();
        _previous = new Dictionary<string, Node?>();

        // record node 
        foreach (var n in _nodes)
        {
            _previous.Add(n.Name, null);
            _basis.Add(n);
            _dist.Add(n.Name, double.MaxValue);
        }
    }

    /// Calculates the shortest path from the start to all other nodes
    public void CalculateDistance(Node start)
    {
        _dist[start.Name] = 0;

        while (_basis.Count > 0)
        {
            Node? u = GetNodeWithSmallestDistance();
            if (u == null)
            {
                _basis.Clear();
            }
            else
            {
                foreach (Node v in GetNeighbours(u))
                {
                    double alt = _dist[u.Value.Name] + GetDistanceBetween(u, v);
                    if (alt < _dist[v.Name])
                    {
                        _dist[v.Name] = alt;
                        _previous[v.Name] = u;
                    }
                }

                _basis.Remove(u);
            }
        }
    }

    public List<Node?> GetPathTo(Node? d)
    {
        var path = new List<Node?>();

        path.Insert(0, d);

        while (_previous[d?.Name!] != null)
        {
            d = _previous[d?.Name!];
            path.Insert(0, d);
        }

        return path;
    }

    private Node? GetNodeWithSmallestDistance()
    {
        double distance = double.MaxValue;
        Node? smallest = null;

        foreach (Node n in _basis)
        {
            if (_dist[n.Name] < distance)
            {
                distance = _dist[n.Name];
                smallest = n;
            }
        }

        return smallest;
    }

    public List<Node> GetNeighbours(Node? n)
    {
        List<Node> neighbors = new List<Node>();

        foreach (Edge e in _edges)
        {
            if (e.Start.Equals(n) && _basis.Contains(n))
            {
                neighbors.Add(e.End);
            }
        }

        return neighbors;
    }

    private double GetDistanceBetween(Node? o, Node? d)
    {
        foreach (Edge e in _edges)
        {
            if (e.Start.Equals(o) && e.End.Equals(d))
            {
                //return e.Distance;
                // No weights yet so return 1
                return 1;
            }
        }

        return 0;
    }

    public void BreadthFirst(Edge graph, LinkedList<String> visited)
    {
        //LinkedList<String> nodes = graph.GetNeighbours(visited.Last());

        //// Examine adjacent nodes
        //foreach (String node in nodes)
        //{
        //    if (visited.Contains(node))
        //    {
        //        continue;
        //    }

        //    if (node.Equals(endNode))
        //    {
        //        visited.AddLast(node);

        //        printPath(visited);

        //        visited.RemoveLast();

        //        break;
        //    }
        //}
    }
}
