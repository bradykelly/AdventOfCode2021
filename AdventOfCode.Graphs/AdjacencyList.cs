using System.Collections;

namespace AdventOfCode.Graphs;

/// <summary>
/// AdjacencyList maintains a list of neighbors for a particular <see cref="Node"/>.  It is derived from CollectionBase
/// and provides a strongly-typed collection of <see cref="EdgeToNeighbour{TNode}"/> instances.
/// </summary>
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class AdjacencyList<TNode> : CollectionBase where TNode : INode<TNode>
{
    /// <summary>
    /// Adds a new <see cref="EdgeToNeighbour{TNode}"/> instance to the AdjacencyList.
    /// </summary>
    /// <param name="e">The <see cref="EdgeToNeighbour{TNode}"/> instance to add.</param>
    protected internal virtual void Add(EdgeToNeighbour<TNode> e)
    {
        InnerList.Add(e);
    }

    /// <summary>
    /// Returns a particular <see cref="EdgeToNeighbour{TNode}"/> instance by index.
    /// </summary>
    public virtual EdgeToNeighbour<TNode> this[int index]
    {
        get => (EdgeToNeighbour<TNode>)InnerList[index]!;
        set => InnerList[index] = value;
    }
}