namespace AdventOfCodeConsole.Puzzles;

public class Day4 : IDay
{
    private class Number
    {
        internal int Value { get; set; }
        internal bool Marked { get; set; }
    }

    private class Board
    {
        public Number[,] Numbers { get; set; } = new Number[5, 5];
    }

    public int Part1(string input)
    {
        var inputLines = input.Split('\n');

        var calledNumbers = inputLines[0].Split(',').Select(c => int.Parse(c)).ToList();
        var boards = new List<Board>();

        for (var mainY = 2; mainY < inputLines.Length - 4; mainY += 6)
        {
            //Board? currentBoard = null;
            //if (string.IsNullOrWhiteSpace(inputLines[mainY]))
            //{
            //    if (currentBoard != null)
            //    {
            //        boards.Add(currentBoard);
            //        currentBoard = new Board();
            //    }
            //    continue;
            //}

            var boardLines = inputLines[(mainY) ..(mainY + 5)];
        }


        return 0;
    }

    public int Part2(string input)
    {
        return 0;
    }
}