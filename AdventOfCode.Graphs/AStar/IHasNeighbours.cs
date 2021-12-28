namespace AdventOfCode.Graphs.AStar;

// ReSharper disable once TypeParameterCanBeVariant
public interface IHasNeighbours<TNode>
{
    IEnumerable<TNode> Neighbours { get; }
}