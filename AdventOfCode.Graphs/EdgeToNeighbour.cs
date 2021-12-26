namespace AdventOfCode.Graphs;
// ReSharper disable once InvalidXmlDocComment

/// <summary>
/// EdgeToNeighbor represents an edge emanating from one <typeparamref name="TNode"/> to its neighbor.  The EdgeToNeighbor
/// class, then, contains a reference to the neighbor and the weight of the edge.
/// </summary>
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public record EdgeToNeighbour<TNode> where TNode : INode<TNode>
{
    /// <summary>
    /// The weight of the edge.
    /// </summary>
    /// <remarks>A value of 0 would indicate that there is no weight, and is the value used when an unweighted
    /// edge is added via the <see cref="Graph"/> class.</remarks>
    public virtual double Cost { get; private set; }

    /// <summary>
    /// The neighbor the edge is leading to.
    /// </summary>
    public virtual TNode Neighbor { get; private set; }

    public EdgeToNeighbour(TNode neighbor, double cost = 0)
    {
        Cost = cost;
        Neighbor = neighbor;
    }

    // BKTODO This shouldn't be needed on a record
    //public override string ToString()
    //{
    //    return $"Neighbor = {Neighbor.Key} | Cost = {Cost}";
    //}
}