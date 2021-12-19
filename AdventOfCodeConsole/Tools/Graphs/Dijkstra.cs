namespace AdventOfCodeConsole.Tools.Graphs;

// How to use
//Dijkstra d = new Dijkstra(_edges, _nodes);
//d.calculateDistance(_dictNodes["A"]);
//List<Vertex> path = d.getPathTo(_dictNodes["C"]);

class Dijkstra
{
    private List<Vertex> _nodes;
    private List<Edge> _edges;
    private List<Vertex?> _basis;
    private Dictionary<string, double> _dist;
    private Dictionary<string, Vertex?> _previous;

    public Dijkstra(List<Edge> edges, List<Vertex> nodes)
    {
        _edges = edges;
        _nodes = nodes;
        _basis = new List<Vertex?>();
        _dist = new Dictionary<string, double>();
        _previous = new Dictionary<string, Vertex?>();

        // record node 
        foreach (var n in _nodes)
        {
            _previous.Add(n.Name, null);
            _basis.Add(n);
            _dist.Add(n.Name, double.MaxValue);
        }
    }

    /// Calculates the shortest path from the start to all other nodes
    public void CalculateDistance(Vertex start)
    {
        _dist[start.Name] = 0;

        while (_basis.Count > 0)
        {
            Vertex? u = GetNodeWithSmallestDistance();
            if (u == null)
            {
                _basis.Clear();
            }
            else
            {
                foreach (Vertex v in GetNeighbours(u))
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

    public List<Vertex?> GetPathTo(Vertex? d)
    {
        var path = new List<Vertex?>();

        path.Insert(0, d);

        while (_previous[d?.Name!] != null)
        {
            d = _previous[d?.Name!];
            path.Insert(0, d);
        }

        return path;
    }

    private Vertex? GetNodeWithSmallestDistance()
    {
        double distance = double.MaxValue;
        Vertex? smallest = null;

        foreach (Vertex n in _basis)
        {
            if (_dist[n.Name] < distance)
            {
                distance = _dist[n.Name];
                smallest = n;
            }
        }

        return smallest;
    }

    public List<Vertex> GetNeighbours(Vertex? n)
    {
        List<Vertex> neighbors = new List<Vertex>();

        foreach (Edge e in _edges)
        {
            if (e.Start.Equals(n) && _basis.Contains(n))
            {
                neighbors.Add(e.End);
            }
        }

        return neighbors;
    }

    private double GetDistanceBetween(Vertex? o, Vertex? d)
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
