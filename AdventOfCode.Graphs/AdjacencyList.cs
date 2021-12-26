using System.Collections;

namespace AdventOfCode.Graphs;

/// <summary>
/// AdjacencyList maintains a list of neighbors for a particular <see cref="Node"/>.  It is derived from CollectionBase
/// and provides a strongly-typed collection of <see cref="EdgeToNeighbor"/> instances.
/// </summary>
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class AdjacencyList<TNode> : CollectionBase where TNode : INode<TNode>
{
    /// <summary>
    /// Adds a new <see cref="EdgeToNeighbor"/> instance to the AdjacencyList.
    /// </summary>
    /// <param name="e">The <see cref="EdgeToNeighbor"/> instance to add.</param>
    protected internal virtual void Add(EdgeToNeighbor<TNode> e)
    {
        base.InnerList.Add(e);
    }

    /// <summary>
    /// Returns a particular <see cref="EdgeToNeighbor"/> instance by index.
    /// </summary>
    public virtual EdgeToNeighbor<TNode> this[int index]
    {
        get => (EdgeToNeighbor<TNode>)InnerList[index];
        set => InnerList[index] = value;
    }
}