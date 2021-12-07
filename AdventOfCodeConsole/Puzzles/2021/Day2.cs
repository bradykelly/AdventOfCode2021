namespace AdventOfCodeConsole.Puzzles._2021;

public class Day2: IDay
{
    public long Part1(string? input)
    {
        var (horizontal, vertical) = (0, 0);

        var directions = input is null ? new List<string>() : input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        foreach (var direction in directions)
        {
            var move = direction.Split(" ");
            var distance = int.Parse(move[1]);

            switch (move[0])
            {
                case "forward":
                    horizontal += distance;
                    break;
                case "down":
                    vertical += distance;
                    break;
                case "up":
                    vertical -= distance;
                    break;
            }
        }

        return vertical * horizontal;
    }

    public long Part2(string? input)
    {
        var (horizontal, vertical) = (0, 0);
        var aim = 0;

        var directions = input is null ? new List<string>() : input
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        foreach (var direction in directions)
        {
            var move = direction.Split(" ");
            var distance = int.Parse(move[1]);

            switch (move[0])
            {
                case "forward":
                    horizontal += distance;
                    vertical += aim * distance;
                    break;
                case "down":
                    aim += distance;
                    break;
                case "up":
                    aim -= distance;
                    break;
            }
        }

        return vertical * horizontal;
    }
}