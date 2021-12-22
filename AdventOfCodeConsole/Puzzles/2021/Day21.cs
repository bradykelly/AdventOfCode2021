namespace AdventOfCodeConsole.Puzzles._2021;

public class Day21: IDay
{
    public static int DayNumber => 21;

    private (int player1, int player2) GetStartingPositions(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var p1 = int.Parse(lines[0].Split(':', StringSplitOptions.TrimEntries)[1]);
        var p2 = int.Parse(lines[1].Split(':', StringSplitOptions.TrimEntries)[1]);
        return (p1, p2);
    }

    private int rollCount = 0;
    private int RollDie(ref int dieFace)
    {
        var total = 0;
        for (var i = 0; i < 3; i++)
        {
            total += dieFace++;
            if (dieFace == 101)
            {
                dieFace = 1;
            }
            rollCount++;
        }
        return total;
    }

    public ulong Part1(string input)
    {
        var dieFace = 1;

        (int player1, int player2) pos = GetStartingPositions(input);

        int p1Score = 0, p2Score = 0;
        while (true)
        {
            var p1Die = RollDie(ref dieFace);
            pos.player1 = (pos.player1 + p1Die - 1) % 10 + 1;
            p1Score += pos.player1;

            if (p1Score >= 1000)
            {
                return (ulong)(p2Score * rollCount);
            }

            var p2Die = RollDie(ref dieFace);
            pos.player2 = (pos.player2 + p2Die - 1) % 10 + 1;
            p2Score += pos.player2;

            if (p2Score >= 1000)
            {
                return (ulong)(p1Score * rollCount);
            }
        }
    }
}
