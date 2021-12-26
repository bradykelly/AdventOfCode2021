namespace AdventOfCode.Graphs.AStar;

internal interface IHasNeighbours<N>
{
    IEnumerable<N> Neighbours { get; }
}