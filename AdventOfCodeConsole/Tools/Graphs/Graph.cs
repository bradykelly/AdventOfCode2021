namespace AdventOfCodeConsole.Tools.Graphs;

// A directed graph using adjacency list representation
public class Graph
{
    private List<Edge> _edges = new();
    private Stack<Edge> _currentPath = new Stack<Edge>();
    private List<List<Vertex>> _paths = new();

    public void FindAllPaths(Vertex start, Vertex end)
    {
        var routes = _edges.Where(e => e.Start.Equals(start) || e.End.Equals(start)).ToList();
        foreach (var edge in routes)
        {
            var next = edge.End;
            _currentPath.Push(edge);
            if (next.Equals(end))
            {
                break;
            }
            FindAllPaths(next, end);
        }
    }

    public void AddEdge(string start, string end)
    {
        _edges.Add(new Edge(new Vertex(start), new Vertex(end)));
    }
}
