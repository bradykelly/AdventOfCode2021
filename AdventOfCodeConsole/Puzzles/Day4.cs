namespace AdventOfCodeConsole.Puzzles;

public class Day4 : IDay
{
    private class Number
    {
        public Number(int value)
        {
            Value = value;
        }

        internal int Value { get; }
        internal bool Marked { get; set; }
    }

    private class Board
    {
        private Number[,] Numbers { get; } = new Number[5, 5];

        public Board(ReadOnlySpan<string> rows)
        //public Board(IReadOnlyList<string> rows)
        {
            for (var y = 0; y < 5; y++)
            {
                ReadOnlySpan<string> rowNumbers = rows[y].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (var x = 0; x < 5; x++)
                {
                    Numbers[y, x] = new Number(int.Parse(rowNumbers[x]));
                }
            }
        }

        private bool HasRow()
        {
            for (var y = 0; y < 5; y++)
            {
                if (Numbers[y, 0].Marked && Numbers[y, 1].Marked && Numbers[y, 2].Marked && Numbers[y, 3].Marked && Numbers[y, 4].Marked)
                    return true;
            }
            return false;
        }

        private bool HasColumn()
        {
            for (var x = 0; x < 5; x++)
            {
                if (Numbers[0, x].Marked && Numbers[1, x].Marked && Numbers[2, x].Marked && Numbers[3, x].Marked && Numbers[4, x].Marked)
                    return true;
            }
            return false;
        }

        public bool Mark(int value)
        {
            foreach (var number in Numbers)
            {
                if (number.Value == value)
                {
                    number.Marked = true;
                    return HasColumn() || HasRow();
                }
            }
            return false;
        }

        public int SumUnmarked()
        {
            var sum = 0;
            foreach (var num in Numbers)
            {
                if (!num.Marked)
                    sum += num.Value;
            }

            return sum;
        }
    }

    public int Part1(string input)
    {
        var inputLines = input.Split('\n');

        var boards = new List<Board>();

        for (var mainY = 2; mainY < inputLines.Length - 4; mainY += 6)
        {
            var boardLines = inputLines[(mainY)..(mainY + 5)];
            boards.Add(new Board(boardLines));
        }

        var calledNumbers = inputLines[0].Split(',').Select(int.Parse).ToList();
        foreach (var call in calledNumbers)
        {
            foreach (var board in boards)
            {
                if (board.Mark(call))
                {
                    return board.SumUnmarked() * call;
                }
            }
        }

        return 0;
    }

    public int Part2(string input)
    {
        var inputLines = input.Split('\n');

        var boards = new List<Board?>();

        for (var mainY = 2; mainY < inputLines.Length - 4; mainY += 6)
        {
            var boardLines = inputLines[(mainY)..(mainY + 5)];
            boards.Add(new Board(boardLines));
        }

        var calledNumbers = inputLines[0].Split(',').Select(int.Parse).ToList();

        List<(Board board, int call)> winningBoards = new();
        foreach (var call in calledNumbers)
        {
            foreach (var board in boards)
            {
                if (winningBoards.Any(t => t.board == board))
                    continue;

                if (board!.Mark(call))
                {
                    winningBoards.Add((board, call));
                }
            }
        }

        var lastBoard = winningBoards.Last();
        return lastBoard.board.SumUnmarked() * lastBoard.call;
    }
}