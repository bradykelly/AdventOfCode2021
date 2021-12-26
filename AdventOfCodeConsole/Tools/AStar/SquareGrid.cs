namespace AdventOfCodeConsole.Tools.AStar;

public class SquareGrid : IWeightedGraph<Tile>
{
    // Code from: https://www.redblobgames.com/pathfinding/a-star/implementation.html

    private static readonly Tile[] _dirs = new[]
    {
        new Tile(0, 1),
        new Tile(-1, 0),
        new Tile(0, -1),
        new Tile(1, 0)
    };

    private readonly Tile[,] _grid;
    private readonly long _height;
    private readonly long _width;
    private readonly HashSet<Tile> _forests = new HashSet<Tile>();

    public SquareGrid(long height, long width)
    {
        _height = height;
        _width = width;
        _grid = new Tile[_height, _width];

        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                _grid[y, x] = new Tile(y, x);
            }
        }
    }

    private bool InBounds(Tile id)
    {
        return 0 <= id.Y && id.Y <= _height && 0 <= id.X && id.X <= _width;
    }

    public Tile this[long y, long x]
    {
        get => _grid[y, x];
        set => _grid[y, x] = value;
    }

    public long Cost(Tile start, Tile end)
    {
        //return Math.Abs((start.Content - '0') - (end.Content - '0'));
        return end.Content - '0';
    }

    public IEnumerable<Tile> Neighbours(Tile id)
    {
        foreach (var dir in _dirs)
        {
            var next = new Tile(id.Y + dir.Y, id.X + dir.X);
            if (InBounds(next))
            {
                yield return next;
            }
        }
    }
}