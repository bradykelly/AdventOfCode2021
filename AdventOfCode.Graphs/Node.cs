namespace AdventOfCode.Graphs;

/// <summary>
/// A Node is uniquely identified by its string Key.  A Node also has a Data property of type object
/// that can be used to store any extra information associated with the Node.
/// 
/// A Node has an X and Y properties that represent the node coordinates on a Grid Map and. It also has
/// a Latitude and Longitude properties that represent the node coordinates on the Earth. 
/// 
/// The Node has a property of type AdjacencyList, which represents the node's neighbors.  To add a neighbor,
/// the Node class exposes an AddDirected() method, which adds a directed edge with an (optional) weight to
/// some other Node.  These methods are marked internal, and are called by the Graph class.
/// </summary>
// BKTODO Override equality
public partial record Node : INode<Node>
{
    /// <summary>
    /// Returns the Node's Key.
    /// </summary>
    public string? Key { get; init; }

    /// <summary>
    /// Returns the Node's Y coordinate.
    /// </summary>
    public int Y { get; init; }

    /// <summary>
    /// Returns the Node's X coordinate.
    /// </summary>
    public int X { get; init; }

    /// <summary>
    /// Returns the Node's Data.
    /// </summary>
    // BKTODO Make this generic
    public object? Data { get; init; }

    /// <summary>
    /// Returns an AdjacencyList of the Node's neighbors.
    /// </summary>
    public AdjacencyList<Node>? EdgesOut { get; } = new AdjacencyList<Node>();

    /// <summary>
    /// Returns the Node's Path Parent.
    /// </summary>
    public Node? PathParent { get; set; }

    /// <summary>
    /// This ctor is not intended for general use and it will leave property <see cref="Key"/> uninitialized.
    /// </summary>
    public Node() {}

    public Node(string? key, object? data, AdjacencyList<Node>? neighbors = null)
    {
        Key = key;
        Data = data;

        EdgesOut = neighbors ?? new AdjacencyList<Node>();
    }

    public Node(string? key, object? data, int y, int x, AdjacencyList<Node>? neighbors = null)
    {
        Y = y;
        X = x;

        Key = key;
        Data = data;

        EdgesOut = neighbors ?? new AdjacencyList<Node>();
    }

    /// <summary>
    /// Adds an unweighted, directed edge from this node to the passed-in Node n.
    /// </summary>
    public void AddDirected(Node n)
    {
        AddDirected(new EdgeToNeighbour<Node>(n));
    }

    /// <summary>
    /// Adds a weighted, directed edge from this node to the passed-in Node n.
    /// </summary>
    /// <param name="n">The other node of the edge</param>
    /// <param name="cost">The weight of the edge.</param>
    public void AddDirected(Node n, int cost)
    {
        AddDirected(new EdgeToNeighbour<Node>(n, cost));
    }

    /// <summary>
    /// Adds a weighted, directed edge from this node to the passed-in Node n.
    /// </summary>
    /// <param name="n">The other node of the edge</param>
    /// <param name="cost">The weight of the edge.</param>
    public void AddDirected(Node n, double cost)
    {
        AddDirected(new EdgeToNeighbour<Node>(n, cost));
    }

    /// <summary>
    /// Adds an edge based on the data in the passed-in EdgeToNeighbor instance.
    /// </summary>
    public void AddDirected(EdgeToNeighbour<Node> e)
    {
        EdgesOut!.Add(e);
    }
}