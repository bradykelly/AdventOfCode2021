// ReSharper disable InvalidXmlDocComment
namespace AdventOfCode.Graphs;

/// <summary>
/// The Graph class represents a graph, which is composed of a collection of nodes and edges.  This Graph class
/// maintains its collection of nodes using the <see cref="NodeList" /> class, which is a collection of <typeparamref name="TNode" /> objects.
/// It delegates the edge maintenance to the <typeparamref name="TNode" /> class.
/// The <typeparamref name="TNode" /> class maintains the edge information using the adjacency list technique.
/// </summary>
public class Graph<TNode> where TNode : INode<TNode>, new()
{
    /// <summary>
    /// Returns a reference to the set of nodes in the graph.
    /// </summary>
    public NodeList<TNode> Nodes = new NodeList<TNode>();

    /// <summary>
    /// Default constructor.  Creates a new Graph class instance.
    /// </summary>
    public Graph() { }

    /// <summary>
    /// Creates a new graph class instance based on a list of nodes.
    /// </summary>
    /// <param name="nodes">The list of nodes to populate the newly created Graph class with.</param>
    public Graph(NodeList<TNode> nodes)
    {
        this.Nodes = nodes;
    }

    /// <summary>
    /// Clears out all of the nodes in the graph.
    /// </summary>
    public virtual void Clear()
    {
        Nodes.Clear();
    }

    /// <summary>
    /// Adds a new node to the graph.
    /// </summary>
    /// <param name="key">The key value of the node to add.</param>
    /// <param name="data">The data of the node to add.</param>
    /// <returns>A reference to the TNode that was created and added to the graph.</returns>
    /// <remarks>If there already exists a node in the graph with the same <b>key</b> value then an
    /// <b>ArgumentException</b> exception will be thrown.</remarks>
    public virtual TNode AddNode(string? key, object data)
    {
        // Make sure the key is unique
        if (!Nodes.ContainsKey(key))
        {
            TNode n = new TNode() { Key = key, Data = data };
            Nodes.Add(n);
            return n;
        }
        else
            throw new ArgumentException("There already exists a node in the graph with key " + key);
    }

    /// <summary>
    /// Adds a new node to the graph.
    /// </summary>
    /// <param name="key">The key value of the node to add.</param>
    /// <param name="data">The data of the node to add.</param>
    /// <param name="y">The y coordinate of the node to add.</param>
    /// <param name="x">The x coordinate of the node to add.</param>
    /// <returns></returns>
    /// <remarks>If there already exists a node in the graph with the same <b>key</b> value then an
    /// <b>ArgumentException</b> exception will be thrown.</remarks>
    public virtual TNode AddNode(string? key, object data, int y, int x)
    {
        // Make sure the key is unique
        if (!Nodes.ContainsKey(key))
        {
            TNode n = new TNode
            {
                Key = key,
                Data = data,
                Y = y,
                X = x
            };
            Nodes.Add(n);
            return n;
        }
        else
        {
            throw new ArgumentException("There already exists a node in the graph with key " + key);
        }
    }

    /// <summary>
    /// Adds a new node to the graph.
    /// </summary>
    /// <param name="n">A node instance to add to the graph</param>
    /// <remarks>If there already exists a node in the graph with the same <b>key</b> value as <b>n</b> then an
    /// <b>ArgumentException</b> exception will be thrown.</remarks>
    public virtual void AddNode(TNode n)
    {
        // Make sure this node is unique
        if (!Nodes.ContainsKey(n.Key))
            Nodes.Add(n);
        else
            throw new ArgumentException("There already exists a node in the graph with key " + n.Key);
    }
    /// <summary>
    /// Adds a directed edge from one node to another.
    /// </summary>
    /// <param name="uKey">The <b>Key</b> of the node from which the directed edge eminates.</param>
    /// <param name="vKey">The <b>Key</b> of the node from which the directed edge leads to.</param>
    /// <remarks>If nodes with <b>uKey</b> and <b>vKey</b> do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddDirectedEdge(string? uKey, string? vKey)
    {
        AddDirectedEdge(uKey, vKey, 0);
    }

    /// <summary>
    /// Adds a directed, weighted edge from one node to another.
    /// </summary>
    /// <param name="uKey">The <b>Key</b> of the node from which the directed edge eminates.</param>
    /// <param name="vKey">The <b>Key</b> of the node from which the directed edge leads to.</param>
    /// <param name="cost">The weight of the edge.</param>
    /// <remarks>If nodes with <b>uKey</b> and <b>vKey</b> do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddDirectedEdge(string? uKey, string? vKey, int cost)
    {
        // get references to uKey and vKey
        if (Nodes.ContainsKey(uKey) && Nodes.ContainsKey(vKey))
            AddDirectedEdge(Nodes[uKey], Nodes[vKey], cost);
        else
            throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
    }

    /// <summary>
    /// Adds a directed edge from one node to another.
    /// </summary>
    /// <param name="u">The node from which the directed edge eminates.</param>
    /// <param name="v">The node from which the directed edge leads to.</param>
    /// <remarks>If the passed-in nodes do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddDirectedEdge(TNode u, TNode v)
    {
        AddDirectedEdge(u, v, 0);
    }

    /// <summary>
    /// Adds a directed, weighted edge from one node to another.
    /// </summary>
    /// <param name="u">The node from which the directed edge eminates.</param>
    /// <param name="v">The node from which the directed edge leads to.</param>
    /// <param name="cost">The weight of the edge.</param>
    /// <remarks>If the passed-in nodes do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddDirectedEdge(TNode u, TNode v, int cost)
    {
        // Make sure u and v are Nodes in this graph
        if (Nodes.ContainsKey(u.Key) && Nodes.ContainsKey(v.Key))
            // add an edge from u -> v
            u.AddDirected(v, cost);
        else
            // one or both of the nodes were not found in the graph
            throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
    }

    /// <summary>
    /// Adds an undirected edge from one node to another.
    /// </summary>
    /// <remarks>If nodes with <b>uKey</b> and <b>vKey</b> do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddUndirectedEdge(string? uKey, string? vKey)
    {
        AddUndirectedEdge(uKey, vKey, 0);
    }

    /// <summary>
    /// Adds an undirected, weighted edge from one node to another.
    /// </summary>
    /// <param name="cost">The weight of the edge.</param>
    /// <remarks>If nodes with <b>uKey</b> and <b>vKey</b> do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddUndirectedEdge(string? uKey, string? vKey, int cost)
    {
        // get references to uKey and vKey
        if (Nodes.ContainsKey(uKey) && Nodes.ContainsKey(vKey))
            AddUndirectedEdge(Nodes[uKey], Nodes[vKey], cost);
        else
            throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
    }

    /// <summary>
    /// Adds an undirected edge from one node to another.
    /// </summary>
    /// <remarks>If the passed-in nodes do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddUndirectedEdge(TNode u, TNode v)
    {
        AddUndirectedEdge(u, v, 0);
    }

    /// <summary>
    /// Adds an undirected, weighted edge from one node to another.
    /// </summary>
    /// <param name="cost">The weight of the edge.</param>
    /// <remarks>If the passed-in nodes do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddUndirectedEdge(TNode u, TNode v, int cost)
    {
        // Make sure u and v are Nodes in this graph
        if (Nodes.ContainsKey(u.Key) && Nodes.ContainsKey(v.Key))
        {
            // Add an edge from u -> v and from v -> u
            u.AddDirected(v, cost);
            v.AddDirected(u, cost);
        }
        else
            // one or both of the nodes were not found in the graph
            throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
    }

    /// <summary>
    /// Adds an undirected, weighted edge from one node to another.
    /// </summary>
    /// <param name="cost">The weight of the edge.</param>
    /// <remarks>If the passed-in nodes do not exist in the graph, an <b>ArgumentException</b>
    /// exception is thrown.</remarks>
    public virtual void AddUndirectedEdge(TNode u, TNode v, double cost)
    {
        // Make sure u and v are Nodes in this graph
        if (Nodes.ContainsKey(u.Key) && Nodes.ContainsKey(v.Key))
        {
            // Add an edge from u -> v and from v -> u
            u.AddDirected(v, cost);
            v.AddDirected(u, cost);
        }
        else
            // one or both of the nodes were not found in the graph
            throw new ArgumentException("One or both of the nodes supplied were not members of the graph.");
    }

    /// <summary>
    /// Returns the number of nodes in the graph.
    /// </summary>
    public virtual int Count => Nodes.Count;
}