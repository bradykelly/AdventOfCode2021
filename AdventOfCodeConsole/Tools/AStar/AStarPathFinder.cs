namespace AdventOfCodeConsole.Tools.AStar;

public class AStarPathFinder
{
    // Code taken from https://dotnetcoretutorials.com/2020/07/25/a-search-pathfinding-algorithm-in-c/

    private readonly Tile[,] _grid;

    public AStarPathFinder(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        _grid = new Tile[lines.Length, lines[0].Length];

        for (var y = 0; y < _grid.GetLongLength(0); y++)
        {
            var line = lines[y];
            for (var x = 0; x < _grid.GetLongLength(1); x++)
            {
                _grid[y, x] = new Tile(y, x, line[x]);
            }
        }
    }

    private List<Tile> GetWalkableTiles(Tile currentTile, Tile targetTile)
    {
        var possibleTiles = new List<Tile>()
        {
            //new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
            //new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
            //new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            //new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile },
            new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile },
            new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile },
            new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile },
        };

        possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

        long maxX = _grid!.GetLongLength(0) - 1;
        long maxY = _grid.GetLongLength(1) - 1;

        return possibleTiles
            .Where(tile => tile.X >= 0 && tile.X <= maxX)
            .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
            .Where(tile => _grid[tile.Y, tile.X].Content is >= '0' and <= '9')
            .ToList();
    }

    public void FindPath((long x, long y) pathStart, (long x, long y) pathFinish)
    {
        var start = new Tile
        {
            Y = pathStart.y,
            X = pathStart.x
        };

        var finish = new Tile
        {
            Y = pathFinish.y,
            X = pathFinish.x
        };

        start.SetDistance(finish.X, finish.Y);

        var activeTiles = new List<Tile> { start };
        var visitedTiles = new List<Tile>();

        while (activeTiles.Any())
        {
            var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

            if (checkTile.X == finish.X && checkTile.Y == finish.Y)
            {
                //We found the destination and we can be sure (Because the the OrderBy above)
                //That it's the most low cost option. 
                var tile = checkTile;
                Console.WriteLine("Retracing steps backwards...");
                while (true)
                {
                    Console.WriteLine($"{tile.Y} : {tile.X}");
                    if (_grid[tile.Y, tile.X].Content.IsDigit())
                    {
                        _grid[tile.Y, tile.X].Content = '*';
                    }
                    tile = tile.Parent;
                    if (tile == null)
                    {
                        Console.WriteLine("Map looks like :");
                        for (var y = 0; y < _grid.GetLongLength(0); y++)
                        {
                            for (var x = 0; x < _grid.GetLongLength(1); x++)
                            {
                                Console.Write(_grid[y, x].Content);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine("Done!");
                        return;
                    }
                }
            }

            visitedTiles.Add(checkTile);
            activeTiles.Remove(checkTile);

            var walkableTiles = GetWalkableTiles(checkTile, finish);

            foreach (var walkableTile in walkableTiles)
            {
                //We have already visited this tile so we don't need to do so again!
                if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    continue;

                //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                {
                    var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                    if (existingTile.CostDistance > checkTile.CostDistance)
                    {
                        activeTiles.Remove(existingTile);
                        activeTiles.Add(walkableTile);
                    }
                }
                else
                {
                    //We've never seen this tile before so add it to the list. 
                    activeTiles.Add(walkableTile);
                }
            }
        }
    }

}
