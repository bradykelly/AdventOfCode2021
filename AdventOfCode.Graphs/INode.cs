namespace AdventOfCode.Graphs;

public interface INode<TNode> where TNode: INode<TNode>
{
    /// <summary>
    /// Returns the Node's Key.
    /// </summary>
    public string Key { get; init; }

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
    public object Data { get; init; }

    public void AddDirected(TNode n);

    public void AddDirected(TNode n, int cost);

    public void AddDirected(TNode n, double cost);

    public void AddDirected(EdgeToNeighbor<TNode> e);
}