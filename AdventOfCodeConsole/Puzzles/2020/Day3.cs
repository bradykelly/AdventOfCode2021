namespace AdventOfCodeConsole.Puzzles._2020
{
    public class Day3 : IDay
    {
        private struct Slope
        {
            public int Down { get; init; }
            public int Right { get; init; }
        }

        public static int DayNumber => 3;

        public ulong Part1(string input)
        {
            var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var trees = 0;

            var posX = 0;
            foreach (var row in rows)
            {
                var ch = row[posX];
                if (ch == '#')
                {
                    trees++;
                }

                posX += 3;
                if (posX > row.Length - 1)
                {
                    posX -= row.Length;
                }
            }

            return (ulong)trees;
        }

        public ulong Part2(string input)
        {
            var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            var slopes = new List<Slope>
            {
                new() { Down = 1, Right = 1 },
                new() { Down = 1, Right = 3 },
                new() { Down = 1, Right = 5 },
                new() { Down = 1, Right = 7 },
                new() { Down = 2, Right = 1 }
            };

            var treesProduct = 1;
            foreach (var slope in slopes)
            {
                var trees = 0;

                var posX = 0;
                var posY = 0;
                while (posY < rows.Length)
                {
                    var row = rows[posY];
                    if (row[posX] == '#')
                    {
                        trees++;
                    }

                    posY += slope.Down;
                    posX += slope.Right;
                    if (posX > row.Length - 1)
                    {
                        posX -= row.Length;
                    }

                }

                treesProduct *= trees;
            }

            return (ulong)treesProduct;
        }
    }
}
